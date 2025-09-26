namespace App



open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch
open Feliz.Shadcn



type Hello =
    [<ReactComponent>]
    static member Render() =
        React.fragment [
            Html.h1 "Hello"
            Shadcn.button [
                prop.text "Button" ]
        ]
