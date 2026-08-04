namespace App



open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch


type Hello =
    [<ReactComponent>]
    static member Render() =
        React.Fragment [
            Html.h1 "Hello"

            Html.button [
                prop.onClick (fun _ -> Browser.Dom.window.alert "Hello!")
                prop.text "Say Hello" ]
        ]
