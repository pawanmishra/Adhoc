<Query Kind="FSharpProgram">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Core.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

// Problem 6 : Find out whether a list is a palindrome. A palindrome can be read forward or backward; e.g. (x a m a x). 
// e.g. [1,2,4,8,16,8,4,2,1] 
// output : True

let palindromNormal (data:int list) =
    let mutable result = true
    let range = data.Length / 2
    for count in 0..range - 1 do
        let res = if data.[count] = data.[data.Length - (count + 1)] then
                    true
                  else
                    false
        result <- result && res
    result

printfn "%A" (palindromNormal [1;2;3;2;1])
		
		