open System
open System.IO
open System.Text.RegularExpressions
open System.Runtime.Serialization.Formatters.Binary

module List = 
    /// <summary> Transposes rectangular matrices </summary>
    let transpose matrix =
        let rec fetch_column acc (matr:'a list list) =
            if matr.Head.Length = 0 then (List.rev acc)
            else fetch_column
                    ([for row in matr -> row.Head]::acc)
                    (List.map (fun row -> match row with [] -> [] | h::t -> t) matr)
        fetch_column [] matrix    

type T = 
    | Empty
    | Up
    | Value of string * string

type Result = string list * (float * float) list * (float * float) option list list

let parsing columns =
    let qual = List.head columns
    let toDouble = function
        | Empty -> Option.None
        | Value(a, b) -> 
            let f = function "" -> 0.0 | x -> Double.Parse x
            Some(f a, f b)
        | Up -> failwith "UP in double"

    let parse = function 
        | "" -> Up
        | x ->
            let m = Regex.Matches (x, @"((-\d+,\d+)|\d+,\d+)|((-\d+)|\d+)")
            match m.Count with
            | 0 -> Empty
            | 1 -> Value("", m.[0].Value)
            | 2 -> Value(m.[0].Value, m.[1].Value)
            | _ -> failwithf "чисел в диапазоне больше двух %A" m
    let rest = columns |> List.tail
    let range =
        rest
        |> List.map (List.head >> parse)
        // Костыль. В теории, в данном списке не должно быть ничего кроме S, однако в конце появляется Up
        |> List.filter (function Value _ -> true | _ -> false)
        |> List.map (toDouble >> Option.get)

    let values = 
        /// <summary> Заменяет Up'ы в матрице на верхние величины </summary>
        let toUp values = 
            let rec f last = function
                | [] -> []
                | Up :: t -> last :: f last t
                | Empty :: t -> Empty :: f Empty t
                | x :: t -> x :: f x t

            values |> List.filter (List.isEmpty >> not)
            |> List.transpose
            |> List.map (f Empty)
            |> List.transpose

        rest
        |> List.map (List.tail >> List.map parse)
        |> toUp         
        |> List.map (List.map toDouble)
    (qual, range, values) : Result
let writeRawToFile (qual,range,values) =
    let all = 
        let fvalues = 
            let f = function Option.None -> "Nan" | Some(a, b) -> "(" + a.ToString() + " " + b.ToString() + ")"
            List.map (List.map f)
        let t = List.map2 (fun x1 x2 -> x1 :: x2) (List.map (sprintf "%A") range) (fvalues values)
        let rowf = List.reduce (fun x1 x2 -> x1 + "\t" + x2)
        qual :: t |> List.map rowf

    File.WriteAllLines ("outputRaw.txt", all)
        
let saveDB thing path =
    let serializeThing thing =
        let bf = new BinaryFormatter()
        use mstream = new MemoryStream()
        
        bf.Serialize(mstream, thing)
        mstream.ToArray()
    let byteArr = serializeThing thing
    use fileStream = new FileStream(path, FileMode.Create)
    fileStream.Write(byteArr, 0, byteArr.Length)
    fileStream.Close()
[<EntryPoint>]
let main args = 
    if Array.isEmpty args then printfn "input path to excel db"; Console.ReadKey() |> ignore
    else
        let file = File.ReadAllText (args.[0], Text.Encoding.Default)
        let rows = file.Split( [|"\r\n"|], StringSplitOptions.None)
        let columns = rows |> Seq.map (fun x -> x.Split ';' |> List.ofSeq) |> List.ofSeq
        
        let res = parsing columns
        saveDB res <| args.[0] + "1"
        writeRawToFile res
    0