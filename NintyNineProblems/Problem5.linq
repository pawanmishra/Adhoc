<Query Kind="FSharpProgram">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Core.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

// Problem 5 : Reverse a list
// e.g. ReverseList [1;2;3;4;5]
// output : [5;4;3;2;1]

let rec reverseList data:int list =
	match data with
	| [] -> []
	| head::tail -> reverseList tail @ [head]
	
let betterReverse data =
	let mutable result = []
	let mutable curr = data
	while curr <> [] do
		let h::t = curr
		result <- h::result
		curr <- t
	result
	
printfn "%A" (reverseList [1;2;3;4])
printfn "%A" (betterReverse [1;2;3;4])