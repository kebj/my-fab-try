namespace App
open Feliz
open Feliz.Router
open Feliz.DaisyUI


type Page =
    | Home
    | FableFeliz
    | FableReact
    | UserProfile of int
    | NotFound

type Navigator =

    [<ReactComponent>]
    static member Render() =

        let parseUrl (segments: string list) =
            match segments with
            | [] -> Home
            | [ "fable-feliz" ] -> FableFeliz
            | [ "fable-react" ] -> FableReact
            | [ "users"; Route.Int userId ] -> UserProfile userId
            | _ -> NotFound

        let currentUrl, updateUrl = React.useState (Router.currentPath ())

        let activePage = parseUrl currentUrl

        let renderPage =
            match activePage with
            | Home -> Home.Render()
            | FableFeliz -> FableFeliz.Render()
            | FableReact -> FableReact.Render()
            | UserProfile id -> Html.h1 (sprintf "User %d" id)
            | NotFound -> Html.h1 "Page not found"

        // To keep the request local See: router.pathMode
        let navigateTo (path: string) (e: Browser.Types.Event) =
            e.preventDefault ()
            Router.navigatePath (path)

        // Build the UI using Feliz helpers, then cast to Fable.React.ReactElement
        let view =
            React.router [
                router.pathMode
                router.onUrlChanged updateUrl
                // This component is the equivalent of a React Router Outlet
                router.children [
                    // Clean paths with no '#'
                    Daisy.navbar [
                        //prop.className "mb-2 shadow-lg bg-neutral text-neutral-content rounded-box"
                        prop.className "shadow-sm rounded-box"
                        prop.children [
                            Html.div [
                                prop.className "flex"
                                prop.children [
                                    Daisy.input [ input.ghost; prop.placeholder "Search" ]
                                    Daisy.button.button [
                                        button.square
                                        button.ghost
                                        prop.children [ Html.i [ prop.className "fa fa-search" ] ]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.className "flex-1"
                                prop.children [
                                    Daisy.button.button [
                                        button.square
                                        button.ghost
                                        prop.children [
                                            Html.a [ prop.href "/"; prop.onClick (navigateTo "/"); prop.text "Home" ]
                                        ]
                                    ]
                                    Daisy.button.button [
                                        button.square
                                        button.ghost
                                        prop.children [
                                            Html.a [ prop.href "/fable-feliz"; prop.onClick (navigateTo "/fable-feliz"); prop.text "Fable Feliz" ]
                                        ]
                                    ]
                                    Daisy.button.button [
                                        button.square
                                        button.ghost
                                        prop.children [
                                            Html.a [ prop.href "/fable-react"; prop.onClick (navigateTo "/fable-react"); prop.text "Fable React" ]
                                        ]
                                    ]
                                    Daisy.button.button [
                                        button.square
                                        button.ghost
                                        prop.children [
                                            Html.a [
                                                prop.href "/"
                                                prop.onClick (navigateTo "/users/42")
                                                prop.text "User 42"
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.className "flex-none"
                                prop.children [
                                    Daisy.toggle [
                                        theme.controller
                                        prop.value "light"
                                    ]

                                    (*
                                    Daisy.button.button [
                                        button.square
                                        button.ghost
                                        prop.children [ Html.i [ prop.className "fa fa-bars" ] ]
                                    ]
                                    *)

                                ]
                            ]
                        ]
                    ]
                    Html.div [ prop.className "container px-4 py-1"; prop.children [ renderPage ] ]
                ]
            ]

        // Return the Feliz.ReactElement view
        view
