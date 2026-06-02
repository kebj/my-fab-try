namespace App



open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch



type HomePage =
    [<ReactComponent>]
    static member Render() =
        React.fragment [
            Html.h1 "Home"

        ]