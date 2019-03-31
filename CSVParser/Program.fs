open FParsec

let separator = ';'

let pqouting = 
    let normalChar c = satisfy (fun c' -> c' <> c)
    let p c = manyChars (normalChar c <|> attempt(pchar c >>. pchar c))

    between (pchar '"') (pchar '"') (p '"')
let pNotQoute = many1Satisfy (fun c -> c <> separator && c <> '\n')

let pline = sepBy1 (pqouting <|> pNotQoute) (pchar separator)
let pall = sepEndBy1 ((pchar separator >>. ((pline |>> fun xs -> ""::xs) <|>% [])) <|> pline) newline

let parsing p str =
    match run p str with
    | Success(result, _, _)   -> result
    | Failure(errorMsg, _, _) -> failwithf "Failure: %s" errorMsg

System.IO.File.ReadAllText(@"e:\Disc D\All\Project\Tolerance\Tolerance\Parse\bin\Debug\sandbox.csv")
|> parsing (pall .>> eof)

open FsControl
open FsControl.Operators

//FsControl.Operators.map

//let k = (map (fun a b -> a, b) ((*) 2)) //<*> ((+)2)
//(map (fun a b -> a, b) [1..5]) <*> [1..5]
//let res3n4:List<int*int> = [fun a b -> a, b] <*> [1;2] <*> [2;3]
let res3n4 = map (fun a b c -> [a; b;c]) [1;2] <*> [2;3] <*> [4;5]
//traverse()
sequenceA [[1;2];[3;4]]
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code

