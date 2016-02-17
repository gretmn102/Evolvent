module Program
open System
open System.Reflection
open System.IO
open System.Collections.Generic
open System.Runtime.Serialization.Formatters.Binary

type Table(file:Stream) =
    let ser = 
        use fileStream = file //new FileStream(file, FileMode.Open)
        let bf = new BinaryFormatter()
        let result = bf.Deserialize(fileStream)
        (result :?> string list * (float*float) list * (float*float) option list list)

    let ranges =
        let _, r, _ = ser
        r |> List.mapi (fun i x -> x, i)

    let db =
        let _, _, v = ser
        v

    let quals =
        let q, _, _ = ser
        q |> List.tail
        |> List.mapi (fun i x -> x, i)
        |> Map.ofList

    member this.Quals =
        quals
        |> Seq.map (fun x -> box x.Key)
        |> Array.ofSeq

    member this.GetVal nRange qual rangeErrorMsg qualErrorMsg = 
        ranges
        |> List.tryFind (fun ((min, max), _) -> min <= nRange && nRange < max)
        |> (function 
            | None -> rangeErrorMsg (); None
            | Some(_, range) ->
                match quals.TryFind qual with
                | Some(x) -> Some (db.[range]).[x]
                | None -> qualErrorMsg(); None)

let loadRes resourceName =
    let assembly = Assembly.GetExecutingAssembly()
    let res = assembly.GetManifestResourceNames()
    using (assembly.GetManifestResourceStream(resourceName))
            (fun stream -> 
            using (new StreamReader(stream, Text.Encoding.UTF8))
                    (fun reader -> reader.ReadToEnd()))
    assembly.GetManifestResourceStream(resourceName)

let table1 = new Table(loadRes "input.dat")
let table2 = new Table(loadRes "input2.dat")