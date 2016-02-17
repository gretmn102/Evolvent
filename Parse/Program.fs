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
        let toDouble = function
            | "" -> 0.0
            | x -> Double.Parse x 
        let l = 
            columns
            |> List.tail
            |> List.map (List.head)
            |> f
            |> List.filter (function S _ -> true | _ -> false)
        l |> List.map (function
                         | S("", "") -> 0.0, 0.0
                         | S("", a) -> 0.0, toDouble a
                         | S(a, "") -> toDouble a, 0.0
                         | S(a, b) -> toDouble a, toDouble b
                         | a -> failwith "")

    let values =
        columns
        |> List.tail
        |> List.map (List.tail)
        |> List.map f

    /// <summary>Заменяет Up'ы на верхние величины</summary>
    let values2 =
        let f' =
                List.tail
                >> List.mapi (fun i x ->
                    x |> List.mapi (fun j y -> 
                        if j < 36 then
                            match y with
                            | None -> y
                            | Up -> 
                                let rec f'' i = 
                                    let k = values.[i]
                                    let current = (values.[i]).[j]
                                    if current = Up then
                                        f'' (i - 1)
                                    else
                                        current
                                f'' i
                            | _ -> y
                        else
                            y))
        values.Head :: ( f' values )

    let values3 =
        values2
        |> List.map (List.map (fun x ->
                                        let erase a b = 
                                            let f = function
                                            | "" -> 0.0
                                            | x -> Double.Parse x 
                                            
                                            Some(f a, f b)

                                        match x with
                                        | None -> Option.None
                                        | S("", "") -> Some (0.0, 0.0)
                                        | S("", b) | S("0", b) -> erase "" b
                                        | S(a, "") | S(a, "0") -> erase a ""
                                        | S(a, b) -> erase a b
                                        | _ -> //"Up"
                                            failwith "откуда-то взялся UP"
                                            ))
    
    (*
    let other =
        let rowf = List.reduce (fun x1 x2 -> x1 + "\t" + x2)
        let t = values3 |> List.mapi (fun i x -> range.[i] :: x)
        qual :: t
        |> List.map rowf
        *)
    let saveDB() =
        let serializeThing thing =
            let bf = new BinaryFormatter()
            use mstream = new MemoryStream()
        
            bf.Serialize(mstream, thing)
            mstream.ToArray()

        
        let seqr = (qual, range, values3)
        let byteArr = serializeThing seqr
        use fileStream = new FileStream("output.dat", FileMode.Create)
        fileStream.Write(byteArr, 0, byteArr.Length)
        fileStream.Close()
    saveDB()
    //File.WriteAllLines ("input.txt", other)
    0