module Program
open System
open System.Reflection
open System.IO
open System.Collections.Generic


(*
let fu =
    new ResolveEventHandler( fun obj arg ->
        
        let resourceName = "AssemblyLoadingAndReflection." + (new AssemblyName(arg.Name)).Name + ".dll";
        using (Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                (fun stream ->
                    let assemblyData:byte [] = Array.empty // [||] // [stream.Length];
                    printfn "kjdf"
                    stream.Read(assemblyData, 0, assemblyData.Length);
                  
                    Assembly.Load(assemblyData)))

AppDomain.CurrentDomain.add_AssemblyResolve( fu )

*)


let private f =
    let assembly = Assembly.GetExecutingAssembly()
    let res = assembly.GetManifestResourceNames()
    let resourceName = "input.txt";

    let file = using (assembly.GetManifestResourceStream(resourceName))
                        (fun stream -> 
                        using (new StreamReader(stream, Text.Encoding.Default))
                                (fun reader -> reader.ReadToEnd()))
        
    (file.Replace ("\r", "")).Split '\n'
    |> Seq.filter (fun x -> x <> "")
    |> Seq.map (fun x -> x.Split '\t' |> List.ofSeq)
    |> List.ofSeq
    
// квалитеты
let private quals =
    f
    |> List.head
    |> List.tail
    |> List.mapi (fun i value -> value, i)
    |> Map.ofList

let Quals =
    quals
    |> Seq.map (fun x -> box x.Key)
    |> Array.ofSeq

// диапазоны
let private ranges =
    f
    |> List.tail
    |> List.map (fun x -> x |> List.head)    
    |> List.mapi (fun i value -> 
                            let range = value.Split ','
                            if range.Length <> 2 then
                                failwithf "диапазон ныверный %s" value
                            else
                                let p str = 
                                    match Int32.TryParse str with
                                    | false, _ -> failwithf "не распознано число %s" str
                                    | true, r -> r
                                        
                                (p range.[0], p range.[1]), i)
    
let private db =
    f
    |> List.tail
    |> List.map List.tail 

let getVal nRange qual rangeError qualError = 
    ranges
    |> List.tryFind (fun ((min, max), _) -> min <= nRange && nRange < max)
    |> (function 
        | None -> rangeError (); None
        | Some(_, range) ->
            match quals.TryFind qual with
            | Some(x) -> Some (db.[range]).[x]
            | None -> qualError(); None)
