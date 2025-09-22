namespace App



open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch
open Feliz.DaisyUI


type Navbar =
    [<ReactComponent>]
    static member Render() =
        Daisy.navbar [
            prop.className "mb-2 shadow-lg bg-neutral text-neutral-content rounded-box"
            prop.children [
                Html.div [
                    prop.className "flex-none"
                    prop.children [
                        Daisy.button.button [
                            button.square
                            button.ghost
                            prop.children [
                                Html.i [ prop.className "fas fa-arrow-left" ++ color.textSuccess ]
                            ]
                        ]
                    ]
                ]
                Html.div [
                    prop.className "flex-1 px-2 mx-2"
                    prop.children [
                        Html.span [prop.className "text-lg font-bold"; prop.text "With one icon"]
                    ]
                ]
            ]
        ]
