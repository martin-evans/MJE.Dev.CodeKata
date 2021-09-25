namespace MJE.Dev.CodeKata.FingStringCalculator

open System

type StringCalculator() =
    class
    
    let mutable calledCount =  0
              
    let  standardDelimiters =
        [|",";"\n"; "//"|]
    
    let  getCustomDelimiter (csvString: string) =
        csvString.Split([|"//"; "\n"|], StringSplitOptions.RemoveEmptyEntries).[0]
             
    let  getNegatives (numbers : int[]) =
         seq { for number in numbers do if number < 0 then yield number } |> Seq.toArray
         
    let  validate (numbers: int[]) =
        let negativesInString = getNegatives numbers        
        if (negativesInString.Length > 0) then
            let message = String.Join(",", negativesInString);
            raise (Exception($"Negatives not allowed {message}"))
        else
            numbers
                                                     
    let  splitAndSum (csvString: string, delimiters: string[])  = 
        csvString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries) |> Array.map(int) |> validate |> Array.sum
                    
    member this.CalledCount : int = calledCount        
                
    member this.Add numberString =
        calledCount <- calledCount + 1
        match numberString with
            | "" -> 0
            | x when x.StartsWith("//") -> splitAndSum (x, Array.append  standardDelimiters [| getCustomDelimiter x|])          
            | x when x.Contains(",") -> splitAndSum (x, standardDelimiters)
            | _  ->  int numberString
          
end