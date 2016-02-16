open System
open System.IO
open System.Text.RegularExpressions

type T = 
    | None
    | Up
    | S of string * string

[<EntryPoint>]
let main args = 
    let file = File.ReadAllText ("Таблица допусков и посадок.csv", Text.Encoding.Default)
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
                | 0 -> None //failwithf "число в диапазоне не обнаружено %A" m
                | 1 -> S("", m.[0].Value)
                | 2 -> S(m.[0].Value, m.[1].Value)
                | _ -> failwithf "чисел в диапазоне больше двух %A" m)

    let range =
        columns
        |> List.tail
        |> List.map (List.head)
        |> f
        |> List.map (function
                         | S("", "") -> ""
                         | S("", a) -> "0," + a
                         | S(a, "") -> a + ",0"
                         | S(a, b) -> a + "," + b
                         | a -> "")

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
                                            a + " " + b
                                            (*
                                            let form =
                                                function
                                                | "" -> ""
                                                | s -> 
                                                    let n = Double.Parse(s) / 1000.0
                                                    if n > 0.0 then "+" + n.ToString() else n.ToString()
                                            String.Format ("<>{{\\H0,5x;\\S{0}^{1};}}", form a, form b)
                                            *)
                                        match x with
                                        | None -> "None"
                                        | S("", "") -> ""
                                        | S("", b) | S("0", b) -> erase "0" b
                                        | S(a, "") | S(a, "0") -> erase a "0"
                                        | S(a, b) -> erase a b
                                        | _ -> //"Up"
                                            failwith "откуда-то взялся UP"
                                            ))

    let other =
        let rowf = List.reduce (fun x1 x2 -> x1 + "\t" + x2)
        let t = values3 |> List.mapi (fun i x -> range.[i] :: x)
        qual :: t
        |> List.map rowf

    File.WriteAllLines ("input.txt", other)
    0