namespace App

open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch
open Feliz.DaisyUI


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
                        Navbar.Render()
                        Html.div [
                            prop.className "p-6"
                            prop.children [
                                match currentUrl with
                                | [] -> Html.h1 "Index"
                                | [ "hello" ] -> Hello.Render()
                                | [ "counter" ] -> Counter.Render()
                                | [ "users" ] -> Users.Render()
                                | otherwise -> Html.h1 "Not found"
                               ]
                            ]
                        ]
                    ]
                ]
        ]