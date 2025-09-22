namespace App


open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch
open Feliz.DaisyUI

type Counter =
    [<ReactComponent>]
    static member Render() =
        let (count, setCount) = React.useState (0)
        React.fragment [
            Html.h1 count
            Html.button [
                prop.onClick (fun _ ->
                    let c = count
                    setCount (count + 1))
                prop.text "Incremenct"
            ]
        ]