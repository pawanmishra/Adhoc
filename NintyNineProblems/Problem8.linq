<Query Kind="FSharpProgram">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Core.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

// Problem 8 : Eliminate consecutive duplicates of list elements.
// e.g. RemoveDuplicate [1;2;2;3;3;3;4;5;6;6;]
// output : [1;2;3;4;5;6;]

let rec RemoveDuplicate (data:'a list) (acc) =
    let isPresent num = 
        match List.tryFind (fun n -> n = num) acc with
        | None -> acc @ [num]
        | Some _ -> acc
    match data with
    | [] -> []
    | [x] -> isPresent x
    | head::tail -> head |> isPresent |> RemoveDuplicate tail
	
printfn "%A" (RemoveDuplicate [1;2;2;3;3;3;4;5;6;6;] [])
		

