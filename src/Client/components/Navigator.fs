namespace App

open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch
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
            | Home -> Html.h1 "Välkommen hem!"
            | Users -> Html.h1 "Användarlista"
            | UserProfile id -> Html.h1 (sprintf "Profil för användare %d" id)
            | NotFound -> Html.h1 "Sidan kunde inte hittas"

        // To keep the request local See: router.pathMode
        let navigateTo (path: string) (e: Browser.Types.Event) =
            e.preventDefault ()
            Router.navigatePath (path)

        // React.Fragment [
        //     Html.h1 "H1"
        //     Html.h2 "H2"
        //     Html.h3 "H3"
        //     Daisy.button.button [
        //         prop.onClick (fun _ -> Browser.Dom.window.alert "Router!")
        //         prop.text "Say Router" ]
 
        //     Daisy.button.button [
        //                         button.square
        //                         button.ghost
        //                         prop.children [ Html.i [ prop.className "fa fa-bars" ] ]
        //                     ]
                        

        // ]

        

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
                            prop.className "flex-none"
                            prop.children [
                                Daisy.fieldset [
                                    Daisy.input [ input.ghost; prop.placeholder "Search" ]
                                ]
                            ]
                        ]
                        Html.div [
                            prop.className "flex-none"
                            prop.children [
                                Daisy.button.button [
                                    button.square
                                    button.ghost
                                    prop.children [
                                        Html.i [ prop.className "fa fa-search" ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
                

                Html.div [ prop.className "container px-4 py-1"; prop.children [ renderPage ] ]
            ]

        ]



(*
                Html.a([ 
                    prop.href "/"
                    prop.onClick (navigateTo "/")
                    prop.text "Hem" 
                ])
                Html.text " | "
                Html.a([ 
                    prop.href "/users"
                    prop.onClick (navigateTo "/users")
                    prop.text "Användare" 
                ])
                Html.text " | "
                Html.a([ 
                    prop.href "/users/42"
                    prop.onClick (navigateTo "/users/42")
                    prop.text "Profil 42" 
                ])
                *)