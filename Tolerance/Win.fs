module Win

open System
open System.Drawing
open System.Windows.Forms

let table1 = Program.table1
let table2 = Program.table2

type nform =
    inherit WindowsFormsApplication1.Form1
    val getDB : EventArgs -> unit

    member this.Init() =
        this.rbT1.TabStopChanged.Add (fun _ -> this.rbT1.TabStop <- false)
        this.rbT2.TabStopChanged.Add (fun _ -> this.rbT2.TabStop <- false)

        this.txbRange.KeyPress.Add (fun e ->
                            let s = e.KeyChar.ToString()
                            if not <| System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"\d+|[\b]|\r|,") then
                                e.Handled <- true
                                this.txbOutput.Text <- "Число, быдло!")
        this.txbRange.Enter.Add (fun _ -> this.txbRange.SelectAll())
        
        let removeDups is =
            let d = System.Collections.Generic.Dictionary()
            [| for i in is do match d.TryGetValue i with
                                | (false,_) -> d.[i] <- (); yield i
                                | _ -> () |]
        Array.append table1.Quals table2.Quals
        |> removeDups
        |> this.cmbQual.Items.AddRange

    new () as this =
        {
             inherit WindowsFormsApplication1.Form1()
             getDB = (fun _ ->
                    match Double.TryParse this.txbRange.Text with
                    | false, _ -> MessageBox.Show("число") |> ignore
                    | true, r ->
                                let f tS1 tGet =
                                    let TSend1 s = tS1 s s
                                    match tGet r this.cmbQual.Text (fun () -> TSend1 "r err") (fun () -> TSend1 "q err") with
                                    | Some r -> 
                                        let f = function 
                                            | Some(a, b) -> tS1 (a.ToString()) (b.ToString())
                                            | None -> TSend1 "NaN"
                                        f r
                                        let format = function
                                            | Some(a, b) -> 
                                                    let f n = 
                                                        let n = n / 1000.0
                                                        if n > 0.0 then "+" + n.ToString() else n.ToString()
                                                    String.Format ("<>{{\\H0,5x;\\S{0}^{1};}}", f a, f b)
                                            | None -> "NaN"
                                        format r
                                    | None -> "NaN"
                                let v1 = 
                                    f (fun s1 s2 ->
                                            this.txbT11.Text <- s1
                                            this.txbT12.Text <- s2) table1.GetVal
                                let v2 =
                                    f (fun s1 s2 ->
                                            this.txbT21.Text <- s1
                                            this.txbT22.Text <- s2) table2.GetVal
                                ///<summary> отправить в буффер </summary>
                                let toBuff s =
                                        this.txbOutput.Text <- s
                                        let t = new System.Threading.Thread( fun () -> Clipboard.SetText s )
                                        t.SetApartmentState( System.Threading.ApartmentState.STA)
                                        t.Start()
                                        t.Join()
                                let commRep (s:string) =
                                        match this.chkComma.Checked with
                                        | true -> s
                                        | false -> s.Replace(',', '.')
                                if this.rbT1.Checked then v1 else v2
                                |> commRep |> toBuff
                                )
        }
        then
            this.Init()

    override this.ProcessCmdKey(msg, keyData) = 
        let code = keyData &&& Keys.KeyCode
        match code with
        | Keys.Enter -> this.getDB( null )
        | _ -> ()
        base.ProcessCmdKey(ref msg, keyData)

[<EntryPoint; STAThread>]
let Main args =
    let form = new nform()
    form.Show()
    Application.Run(form)
    0
    