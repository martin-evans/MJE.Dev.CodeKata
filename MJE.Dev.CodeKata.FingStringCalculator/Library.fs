namespace MJE.Dev.CodeKata.FingStringCalculator

module StringCalculator =
    
    let splitAndSum (csvString: string)  = 
        csvString.Split(',') |> Array.map(int) |> Array.sum        
    let Add numberString =
        match numberString with
            | "" -> 0
            | x when x.Contains(",") -> splitAndSum x 
            | _  ->  int numberString;
         
    