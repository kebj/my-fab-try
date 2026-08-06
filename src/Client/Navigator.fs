namespace App
open Feliz
open Feliz.Router
open Feliz.DaisyUI


type Page =
    | Home
    | Users
    | UserProfile of int
    | NotFound

type Navigator =

    [<ReactComponent>]
    static member Render() =

        let parseUrl (segments: string list) =
            match segments with
            | [] -> Home
            | [ "users" ] -> Users
            | [ "users"; Route.Int userId ] -> UserProfile userId
            | _ -> NotFound

        let currentUrl, updateUrl = React.useState (Router.currentPath ())

        let activePage = parseUrl currentUrl

        let renderPage =
            match activePage with
            | Home -> Home.Render()
            | Users -> Html.h1 "Users"
            | UserProfile id -> Html.h1 (sprintf "Profile for user %d" id)
            | NotFound -> Html.h1 "Page not found"

        // To keep the request local See: router.pathMode
        let navigateTo (path: string) (e: Browser.Types.Event) =
            e.preventDefault ()
            Router.navigatePath (path)

        React.router [

            router.pathMode
            router.onUrlChanged updateUrl
            // This component is the equivalent of a React Router Outlet

            router.children [
                // Clean paths with no '#'
                Daisy.navbar [

                    prop.className "mb-2 shadow-lg bg-neutral text-neutral-content rounded-box"
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
                                        Html.a [ prop.href "/"; prop.onClick (navigateTo "/users"); prop.text "Users" ]
                                    ]
                                ]
                                Daisy.button.button [
                                    button.square
                                    button.ghost
                                    prop.children [
                                        Html.a [
                                            prop.href "/"
                                            prop.onClick (navigateTo "/users/42")
                                            prop.text "Profile for user"
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