BEGIN TRY
BEGIN TRANSACTION

SET NOCOUNT ON

declare @temp_Permisisons table (
    permission nvarchar(max),
    permissionname nvarchar(max)
    )

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER OFF

--__USER_PERMISISON_STATEMENTS__

SET QUOTED_IDENTIFIER ON

SET NOCOUNT OFF

DECLARE @stmt nvarchar(MAX)

-- merge primary patterns
PRINT '
Merging user permissions...'

SET NOCOUNT ON

IF OBJECT_ID('tempdb..#temp_USerPermissions') IS NOT null
    DROP TABLE #temp_UserPermisisons
SELECT * INTO #temp_UserPermisisons FROM @temp_UserPermisisons

SET NOCOUNT OFF

SET @stmt = N'
MERGE crt.Permissions AS t
USING (
    SELECT *
    FROM #temp_USerPermisisons 
    ) AS s ON t.Permisison = s.Permisison
WHEN NOT MATCHED BY TARGET
    THEN INSERT (PErmisison, ref_nm, pattern, tbl_source, column_nm'
+ CASE WHEN @hasPatternFilter = 1 THEN ', pattern_filter, is_negative_filter' ELSE '' END
+ CASE WHEN @hasContainsClause = 1 THEN ', contains_clause' ELSE '' END
+ ')
    VALUES (s.pattern_id, s.ref_nm, s.pattern, s.tbl_source, s.column_nm'
+ CASE WHEN @hasPatternFilter = 1 THEN ', s.pattern_filter, s.is_negative_filter' ELSE '' END 
+ CASE WHEN @hasContainsClause = 1 THEN ', s.contains_clause' ELSE '' END
+ ')
WHEN MATCHED AND (
       t.ref_nm <> s.ref_nm 
    OR t.pattern <> s.pattern 
    OR t.tbl_source <> s.tbl_source 
    OR t.column_nm IS null 
    OR t.column_nm <> s.column_nm '
+ CASE WHEN @hasPatternFilter = 1 THEN '
    OR (t.pattern_filter IS null AND s.pattern_filter IS NOT null)
    OR (t.pattern_filter IS NOT null AND s.pattern_filter IS null)
    OR t.pattern_filter <> s.pattern_filter
    OR t.is_negative_filter <> s.is_negative_filter' ELSE '' END
+ CASE WHEN @hasContainsClause = 1 THEN '
    OR (t.contains_clause IS null AND s.contains_clause IS NOT null)
    OR (t.contains_clause IS NOT null AND s.contains_clause IS null)
    OR t.contains_clause <> s.contains_clause' ELSE '' END
+ ')
    THEN UPDATE SET 
      ref_nm = s.ref_nm,
      pattern = s.pattern,
      tbl_source = s.tbl_source,
      column_nm = s.column_nm'
+ CASE WHEN @hasPatternFilter = 1 THEN '
      ,pattern_filter = s.pattern_filter
      , is_negative_filter = s.is_negative_filter' ELSE '' END
+ CASE WHEN @hasContainsClause = 1 THEN '
      ,contains_clause = s.contains_clause' ELSE '' END
+ CASE WHEN @hasLastUpdate = 1 THEN '
      , LastUpdate = SYSDATETIMEOFFSET()' ELSE '' END
+ ';'

EXEC sp_executesql @stmt


COMMIT 

END TRY
BEGIN CATCH
    DECLARE @ERROR_MESSAGE nvarchar(4000)
    SET @ERROR_MESSAGE = ERROR_MESSAGE()
    RAISERROR(@ERROR_MESSAGE, 16, 1)

    IF @@TRANCOUNT > 0 ROLLBACK
END CATCH
GO
IF OBJECT_ID('tempdb..#temp_TextPattern') IS NOT null
    DROP TABLE #temp_TextPattern
GO
