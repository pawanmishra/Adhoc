<Query Kind="FSharpProgram">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Core.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

// Problem 7 : Flatten a nested list structure
// e.g. [1;2;[3;4;];5;[6;7;]]
// output : [1;2;3;4;5;6;7]

let rec flattenList (data:int list list) acc =
    match data with
    | [] -> []
    | [x] -> acc @ x
    | head::tail -> acc @ head |> flattenList tail
	
printfn "%A" (flattenList [[1;2;];[3;4;];[5];[6;7;]] [])