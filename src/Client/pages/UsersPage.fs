namespace App



open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch

open Feliz.Shadcn

type UsersPage =
    [<ReactComponent>]
    static member Render() =
        React.fragment [
            Html.h1 "Users"
            Shadcn.button [
                prop.text "Click me"
                prop.onClick (fun _ -> Browser.Dom.window.alert "Hello, shadcn/ui!")
            ]
        ]