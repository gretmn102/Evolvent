namespace GreetersNamespace
open System
open System.Windows
open System.Windows.Input
/// Класс, реализующий вывод приветствия
type GreetUserCommand() =
    let m_canExecuteChangedEvent = new Event<System.EventHandler, EventArgs>()
    interface ICommand with
        member this.CanExecute(param : obj) = true
        member this.Execute(param : obj) =
            MessageBox.Show(sprintf "Hello, %s" (string param))
            |> ignore
        [<CLIEvent>]
        member this.CanExecuteChanged with get() = m_canExecuteChangedEvent.Publish
/// Класс с информацией о пользователе – используется при создании 
/// текста приветствия
type Greeter() =
    let m_greetCommand = new GreetUserCommand()
    let mutable m_name = "[name goes here]"
    /// Текст предварительного сообщения
    member this.Introduction = "Hello, what is your name?"
    member this.Name with get () = m_name
                     and set x = m_name <- x
    member this.GreetCommand = m_greetCommand

//module File1
(*
#r "WindowsBase.dll"
#r "PresentationCore.dll"
#r "PresentationFramework.dll"
*)
