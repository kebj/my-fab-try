namespace App



open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch



type Drawer =
    [<ReactComponent>]
    static member Render(content:ReactElement) =
        Html.div [
            prop.className "drawer"
            prop.children [
                Html.input [
                    prop.id "my-drawer"
                    prop.type' "checkbox"
                    prop.className "drawer-toggle"
                ]
                Html.div [
                    prop.className "drawer-content"
                    prop.children [
                        Html.label [
                            prop.classes [ "btn"; "btn-primary"; "drawer-button" ]
                            prop.for' "my-drawer"
                            prop.text "Open drawer"
                        ]
                    ]
                ]
                Html.div [
                    prop.className "drawer-side"
                    prop.children [
                        Html.label [
                            prop.for' "my-drawer"
                            prop.ariaLabel "close sidebar"
                            prop.className "drawer-overlay"
                        ]
                        Html.ul [
                            prop.classes [ "menu"; "bg-base-200"; "text-base-content"; "min-h-full"; "w-80"; "p-4" ]
                            prop.children [
                                Html.li [
                                    Html.p "Sidebar Item 1"
                                ]
                                Html.li [
                                    Html.p "Sidebar Item 2"
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]


(*
Html.div [
    prop.className "drawer"
    prop.children [
        Html.input [
            prop.id "my-drawer"
            prop.type' "checkbox"
            prop.className "drawer-toggle"
        ]
        Html.div [
            prop.className "drawer-content"
            prop.children [
                Html.label [
                    prop.classes [ "btn"; "btn-primary"; "drawer-button" ]
                    prop.for' "my-drawer"
                    prop.text "Open drawer"
                ]
            ]
        ]
        Html.div [
            prop.className "drawer-side"
            prop.children [
                Html.label [
                    prop.for' "my-drawer"
                    prop.ariaLabel "close sidebar"
                    prop.className "drawer-overlay"
                ]
                Html.ul [
                    prop.classes [ "menu"; "bg-base-200"; "text-base-content"; "min-h-full"; "w-80"; "p-4" ]
                    prop.children [
                        Html.li [
                            Html.a "Sidebar Item 1"
                        ]
                        Html.li [
                            Html.a "Sidebar Item 2"
                        ]
                    ]
                ]
            ]
        ]
    ]
]

*)