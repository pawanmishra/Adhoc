<Query Kind="FSharpProgram">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Core.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

// Problem 2 : Find the last but one element of a list
// e.g : myLastButOne [1;2;3;4;]

let rec myLastButOne (data:int list) =
    let data = match data with
                | [] -> failwith "empty list"
                | head::tail when tail.Length = 1 -> head
                | head::tail -> myLastButOne tail
    data   

let myLastButOneSimple (data:int list) =
    data.[data.Length - 2]
	
printfn "%A" (myLastButOne [1;2;3;4])
printfn "%A" (myLastButOneSimple [1;2;3;4])