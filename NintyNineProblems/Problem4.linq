<Query Kind="FSharpProgram">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Core.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

// Problem 4 : Find the number of elements in the list
// e.g : numberOfElements [1;2;3;4;] 
// output : 4

let numberOfElements (data:int list) =
	data.Length
	
printfn "%A" (numberOfElements [1;2;3;4;])