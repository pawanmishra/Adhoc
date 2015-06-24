<Query Kind="FSharpProgram">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Core.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

// Problem 3 : Find the kth element of a list
// e.g : kthElement [1;2;3;4;] 2
// output : 2

let rec kthElement (data) k =
    let data = match data, k-1 with
                | [], _ -> failwith "empty list"
                | head::tail, k when k = 0 -> head
                | head::tail, k -> kthElement tail k
    data
	
printfn "%A" (kthElement [1;2;3;4;5] 2)