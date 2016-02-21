open System
open System.IO
open System.Text.RegularExpressions
open System.Runtime.Serialization.Formatters.Binary

type T = 
    | None
    | Up
    | S of string * string

[<EntryPoint>]
let main args = 
    let file = File.ReadAllText (args.[0], Text.Encoding.Default)
    let rows = file.Split( [|"\r\n"|], StringSplitOptions.None)
    let columns = rows |> Seq.map (fun x -> x.Split ';' |> List.ofSeq) |> List.ofSeq

    let qual = List.head columns

    let f =
        List.map (fun x -> 
            if x = "" then
                Up
            else
                let m = Regex.Matches (x, @"((-\d+,\d+)|\d+,\d+)|((-\d+)|\d+)")
                match m.Count with
                | 0 -> None
                | 1 -> S("", m.[0].Value)
                | 2 -> S(m.[0].Value, m.[1].Value)
                | _ -> failwithf "чисел в диапазоне больше двух %A" m)

    let range =
        let toDouble x = 
            let erase a b = 
                let f = function
                | "" -> 0.0
                | x -> Double.Parse x              
                (f a, f b)

            match x with
            | S(a, b) -> erase a b
            | a -> failwithf "некуда вставить %A" a

        columns
        |> List.tail
        |> List.map (List.head)
        |> f
        // Костыль. В теории, в данном списке не должно быть ничего кроме S, однако в конце появляется Up
        |> List.filter (function S _ -> true | _ -> false)
        |> List.map (toDouble)

    let values = 
        let values =
            columns
            |> List.tail
            |> List.map (List.tail)
            |> List.map f
        /// <summary> Transposes rectangular matrices </summary>
        let transpose matrix =
            let rec fetch_column acc (matr:'a list list) =
                if matr.Head.Length = 0 then (List.rev acc)
                else fetch_column
                        ([for row in matr -> row.Head]::acc)
                        (List.map (fun row -> match row with [] -> [] | h::t -> t) matr)
            fetch_column [] matrix
        
        /// <summary> Заменяет Up'ы в матрице на верхние величины </summary>
        let toUp values = 
            let rec f last = function
                | [] -> []
                | Up :: t -> last :: f last t
                | None :: t -> None :: f None t
                | x :: t -> x :: f x t

            values |> List.filter (List.length >> (<>) 0)
            |> transpose //values
            |> List.map (f None)
            |> transpose

        let toDouble x = 
            let erase a b = 
                let f = function
                | "" -> 0.0
                | x -> Double.Parse x            
                Some(f a, f b)

            match x with
            | None -> Option.None
            | S(a, b) -> erase a b
            | Up -> failwith "откуда-то взялся UP"

        toUp values 
        |> List.map (List.map toDouble)

    let writeRawToFile () =
        let srange = range |> List.map (sprintf "%A")
        let svalues = values |> List.map (List.map (function Option.None -> "Nan" | Some(a, b) -> "(" + a.ToString() + " " + b.ToString() + ")"))
        
        let all = 
            let t = List.map2 (fun x1 x2 -> x1 :: x2) srange svalues
            let rowf = List.reduce (fun x1 x2 -> x1 + "\t" + x2)
            qual :: t
            |> List.map rowf

        File.WriteAllLines ("outputRaw.txt", all)
        
    let saveDB() =
        let serializeThing thing =
            let bf = new BinaryFormatter()
            use mstream = new MemoryStream()
        
            bf.Serialize(mstream, thing)
            mstream.ToArray()

        let seqr = (qual, range, values)
        let byteArr = serializeThing seqr
        use fileStream = new FileStream(args.[0] + "1", FileMode.Create)
        fileStream.Write(byteArr, 0, byteArr.Length)
        fileStream.Close()
    saveDB()
    writeRawToFile ()

    0