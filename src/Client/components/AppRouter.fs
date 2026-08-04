namespace App

open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch



type AppRouter =

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
                            prop.className "p-6"
                            prop.children [
                                match currentUrl with
                                | [] -> Hello.Render()
                                | otherwise -> Html.h1 "Not found"
                               ]
                            ]
                        ]
                    ]
                ]
        ]