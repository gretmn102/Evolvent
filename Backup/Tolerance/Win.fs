module Win

open System
open System.Drawing
open System.Windows.Forms

let button1 = new System.Windows.Forms.Button()
let radioButton1 = new System.Windows.Forms.RadioButton();
let radioButton2 = new System.Windows.Forms.RadioButton();
let rangeInput = new System.Windows.Forms.TextBox();
let qualInput = new System.Windows.Forms.TextBox();
let label3 = new System.Windows.Forms.Label();
let label4 = new System.Windows.Forms.Label();
let outputTxtBox = new System.Windows.Forms.TextBox();
let comboBox1 = new System.Windows.Forms.ComboBox();

let getDB _ = 
        match Int32.TryParse rangeInput.Text with
        | false, _ -> printfn "число, быдло!"
        | true, r -> 
                outputTxtBox.Text <- 
                    
                    match Program.getVal r comboBox1.Text (fun () -> MessageBox.Show("Error range") |> ignore) (fun () -> MessageBox.Show("Error qual") |> ignore) with
                    | Some r -> 
                        let r =
                            match radioButton1.Checked with
                            | true -> r.Replace(',', '.')
                            | false -> r
                        let t = new System.Threading.Thread( fun () -> Clipboard.SetText r )
                        t.SetApartmentState( System.Threading.ApartmentState.STA)
                        t.Start()
                        t.Join()
                        r
                    | None -> ""

// 
// button1
// 
button1.Location <- new System.Drawing.Point(106, 146);
button1.Name <- "button1";
button1.Size <- new System.Drawing.Size(75, 31);
button1.TabIndex <- 0;
button1.TabStop <- false
button1.Text <- "button1";
button1.UseVisualStyleBackColor <- true;
button1.Click.Add( getDB )

// 
// radioButton1
// 
radioButton1.AutoSize <- true;
radioButton1.Location <- new System.Drawing.Point(12, 88);
radioButton1.Name <- "radioButton1";
radioButton1.Size <- new System.Drawing.Size(132, 17);
radioButton1.TabIndex <- 1;
radioButton1.Checked <- true
radioButton1.TabStop <- false;
radioButton1.TabStopChanged.Add (fun _ -> radioButton1.TabStop <- false)
radioButton1.Text <- "Разделитель \"точка\"";
radioButton1.UseVisualStyleBackColor <- true;


// 
// radioButton2
// 
radioButton2.AutoSize <- true;
radioButton2.Location <- new System.Drawing.Point(12, 111);
radioButton2.Name <- "radioButton2";
radioButton2.Size <- new System.Drawing.Size(145, 17);
radioButton2.TabIndex <- 2;
radioButton2.TabStop <- false;
radioButton2.TabStopChanged.Add (fun _ -> radioButton2.TabStop <- false)
radioButton2.Text <- "Разделитель \"запятая\"";
radioButton2.UseVisualStyleBackColor <- true;
// 
// rangeInput
// 
rangeInput.Location <- new System.Drawing.Point(12, 21);
rangeInput.Name <- "rangeInput";
rangeInput.Size <- new System.Drawing.Size(85, 20);
rangeInput.TabIndex <- 5;
rangeInput.KeyPress.Add (fun e ->
                            let s = e.KeyChar.ToString()
                            if not <| System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"\d+|[\b]|\r") then
                                e.Handled <- true
                                printfn "%s число, быдло!" s)
rangeInput.Enter.Add (fun _ -> rangeInput.SelectAll())



// 
// qualInput
// 
qualInput.Location <- new System.Drawing.Point(12, 47);
qualInput.Name <- "qualInput";
qualInput.Size <- new System.Drawing.Size(85, 20);
qualInput.TabIndex <- 6;
qualInput.Enter.Add (fun _ -> qualInput.SelectAll())
// 
// label3
// 
label3.AutoSize <- true;
label3.Location <- new System.Drawing.Point(103, 28);
label3.Name <- "label3";
label3.Size <- new System.Drawing.Size(46, 13);
label3.TabIndex <- 7;
label3.Text <- "Размер";
// 
// label4
// 
label4.AutoSize <- true;
label4.Location <- new System.Drawing.Point(103, 54);
label4.Name <- "label4";
label4.Size <- new System.Drawing.Size(54, 13);
label4.TabIndex <- 8;
label4.Text <- "Квалитет";
// 
// outputTxtBox
// 
outputTxtBox.AutoSize <- true;
outputTxtBox.Location <- new System.Drawing.Point(103, 206);
outputTxtBox.Name <- "outputTxtBox";
outputTxtBox.Size <- new System.Drawing.Size(200, 500);
outputTxtBox.TabIndex <- 3;
outputTxtBox.TabStop <- false
outputTxtBox.Text <- "outputTxtBox";



// 
// Form
// 
type newForm = //(a:int) =
    
    inherit Form

    
      //new newForm() 
    member this.Init() =
        
        // 
        // comboBox1
        // 
        comboBox1.AutoCompleteMode <- System.Windows.Forms.AutoCompleteMode.Suggest;
        comboBox1.AutoCompleteSource <- System.Windows.Forms.AutoCompleteSource.ListItems;
        comboBox1.Sorted <- true
        comboBox1.FormattingEnabled <- true;
        comboBox1.Items.AddRange( Program.Quals )
        comboBox1.Location <- new System.Drawing.Point(12, 47);
        comboBox1.Name <- "comboBox1";
        comboBox1.Size <- new System.Drawing.Size(85, 20);
        comboBox1.TabIndex <- 0;

        this.Controls.Add comboBox1

    new () as this = //Form()
        
        {
            inherit Form()
        }
        then
            this.Init()
            
    override this.ProcessCmdKey(msg, keyData) = 
        let code = keyData &&& Keys.KeyCode
        match code with
        | Keys.Enter -> getDB ()
        | _ -> ()
        base.ProcessCmdKey(ref msg, keyData)




[<EntryPoint; STAThread>]
let Main args =

    let form = new newForm()
    form.AutoScaleDimensions <- new System.Drawing.SizeF(6.0f, 13.0f);
    form.AutoScaleMode <- System.Windows.Forms.AutoScaleMode.Font;
    form.ClientSize <- new System.Drawing.Size(284, 262);
    form.Controls.Add(label4);
    form.Controls.Add(label3);
    //form.Controls.Add(qualInput);
    form.Controls.Add(rangeInput);
    form.Controls.Add(outputTxtBox);
    form.Controls.Add(radioButton2);
    form.Controls.Add(radioButton1);
    form.Controls.Add(button1);
    //form.Controls.Add(comboBox1)
    form.Name <- "Form1";
    form.Text <- "Form1";
    form.ResumeLayout(false);
    form.PerformLayout();

    form.Show()
    //CsvParse.main
    Application.Run(form)
    0