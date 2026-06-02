namespace App

open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch



type Router =

    [<ReactComponent>]
    static member Render() =
        let (currentUrl, updateUrl) = React.useState (Router.currentUrl ())

        React.router [
            router.pathMode
            router.onUrlChanged updateUrl

             // This component is the equivalent of a React Router Outlet
            router.children [
                Html.div [
                    prop.className "container mx-auto px-4 py-4"
                    prop.children [

                        Html.div [
                            prop.className "drawer-side"
                            prop.children [
                                Html.label [
                                    prop.for' "my-drawer-2"
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
                        Html.div [
                            prop.className "p-6"
                            prop.children [
                                match currentUrl with
                                | [] -> Html.h1 "Index"
                                | [ "home" ] -> HomePage.Render()
                                | [ "about" ] -> AboutPage.Render()
                                | [ "users" ] -> UsersPage.Render()
                                | otherwise -> Html.h1 "Not found"
                            ]
                        ]
                     ]
                ]
            ]
        ]