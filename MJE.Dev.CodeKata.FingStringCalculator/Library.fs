namespace MJE.Dev.CodeKata.FingStringCalculator

open System

module StringCalculator =
    
    let  mutable calledCount =  0
    
    let ResetCalledCount startVal =
        calledCount <- startVal;
             
    let private standardDelimiters =
        [|",";"\n"; "//"|]
    
    let private getCustomDelimiter (csvString: string) =
        csvString.Split([|"//"; "\n"|], StringSplitOptions.RemoveEmptyEntries).[0]
             
    let private getNegatives (numbers : int[]) =
         seq { for number in numbers do if number < 0 then yield number } |> Seq.toArray
         
    let private validate (numbers: int[]) =
        let negativesInString = getNegatives numbers        
        if (negativesInString.Length > 0) then
            let message = String.Join(",", negativesInString);
            raise (Exception($"Negatives not allowed {message}"))
        else
            numbers
                                                     
    let private splitAndSum (csvString: string, delimiters: string[])  = 
        csvString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries) |> Array.map(int) |> validate |> Array.sum
                
    let public Add numberString =
        calledCount <- calledCount + 1
        match numberString with
            | "" -> 0
            | x when x.StartsWith("//") -> splitAndSum (x, Array.append  standardDelimiters [| getCustomDelimiter x|])          
            | x when x.Contains(",") -> splitAndSum (x, standardDelimiters)
            | _  ->  int numberString;