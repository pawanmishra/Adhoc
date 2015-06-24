<Query Kind="FSharpProgram">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Core.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

// Problem 1 : Find the last element of a list
// e.g : myLast [1;2;3;4;]

let rec myLast (data:int list) =
    let data = match data with
                | [] -> failwith "empty list"
                | [x] -> x
                | head::tail -> myLast tail
    data   

let myLastSimple (data:int list) =
    data.[data.Length - 1]
	
printfn "%A" (myLast [1;2;3;4])
printfn "%A" (myLastSimple [1;2;3;4])