namespace App



open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch



type Hello =
    [<ReactComponent>]
    static member Render() =
        React.fragment [
            Html.h1 "Hello"
            
            Shadcn.Shadcn.button [
                prop.onClick (fun _ -> Browser.Dom.window.alert "Hello, shadcn/ui!")
                prop.text "Button" ]
        ]
