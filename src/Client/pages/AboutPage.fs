namespace App



open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch



type AboutPage =
    [<ReactComponent>]
    static member Render() =
        React.fragment [
            Html.h1 "About"

        ]