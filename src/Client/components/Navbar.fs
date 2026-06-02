namespace App



open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch


type NavbarLinkButton =
    [<ReactComponent>]
    static member Render(arguments: {| text: string; href: string |}) =
        
        // btn-ghost link link-hover
        Html.a [
            prop.className "btn btn-ghost link link-hover mx[8px]" 
            prop.text arguments.text
            prop.href arguments.href
        ]

type Navbar =
    [<ReactComponent>]
    static member Render() =
        Html.div [
            prop.classes [ "navbar"; "bg-base-100"; "shadow-sm" ]
            prop.children [
                Html.div [
                    prop.className "flex-1"
                    prop.children [
                        Html.a [
                            prop.classes [ "btn"; "btn-ghost"; "text-xl" ]
                            prop.text "App name"
                        ]
                        NavbarLinkButton.Render {| text = "Home";  href = "/"|}
                        NavbarLinkButton.Render {| text = "About";  href = "/about"|}
                        NavbarLinkButton.Render {| text = "Users";  href = "/users"|}


                    ]
                ]
                Html.div [
                    prop.classes [ "flex"; "gap-2" ]
                    prop.children [
                        Html.input [
                            prop.type' "text"
                            prop.placeholder "Search"
                            prop.classes [ "input"; "input-bordered"; "w-24"; "md:w-auto" ]
                        ]
                        Html.div [
                            prop.classes [ "dropdown"; "dropdown-end" ]
                            prop.children [
                                Html.div [
                                    prop.classes [ "btn"; "btn-ghost"; "btn-circle"; "avatar" ]
                                    prop.role "button"
                                    prop.tabIndex 0
                                    prop.children [
                                        Html.div [
                                            prop.classes [ "w-10"; "rounded-full" ]
                                            prop.children [
                                                Html.img [
                                                    prop.alt "Tailwind CSS Navbar component"
                                                    
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                                Html.ul [
                                    prop.classes [ "menu"; "menu-sm"; "dropdown-content"; "bg-base-100"; "rounded-box"; "z-1"; "mt-3"; "w-52"; "p-2"; "shadow" ]
                                    prop.tabIndex 0
                                    prop.children [
                                        Html.li [
                                            Html.a [
                                                prop.className "justify-between"
                                                prop.children [
                                                    Html.text "Profile "
                                                    Html.span [
                                                        prop.className "badge"
                                                        prop.text "New"
                                                    ]
                                                ]
                                            ]
                                        ]
                                        Html.li [
                                            Html.p "Settings"
                                        ]
                                        Html.li [
                                            Html.p "Logout"
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]    



                
    //             Html.div [
    //                 prop.className "flex-none"
    //                 prop.children [
    //                     NavbarLinkButton.Render {| text = "Home";  href = "/"|}
    //                     NavbarLinkButton.Render {| text = "About";  href = "/about"|}
    //                     NavbarLinkButton.Render {| text = "Users";  href = "/users"|}
    //                 ]
    //             ]
    //         ]
    //     ]





        // Html.div [
        //     prop.className [ "navbar"; "bg-base-100"; "shadow-sm" ]
        //     prop.children [
        //         Html.div [
        //             prop.className "navbar-start"
        //             prop.children [
        //                 Html.div [
        //                     prop.className "dropdown"
        //                     prop.children [
        //                         Html.div [
        //                             prop.classes [ "btn"; "btn-ghost"; "lg:hidden" ]
        //                             prop.role "button"
        //                             //prop.tabindex "0"
        //                             prop.children [
        //                             ]
        //                         ]
        //                         Html.ul [
        //                             prop.classes [ "menu"; "menu-sm"; "dropdown-content"; "bg-base-100"; "rounded-box"; "z-1"; "mt-3"; "w-52"; "p-2"; "shadow" ]
        //                             //prop.tabindex "0"
        //                             prop.children [
        //                                 Html.li [
        //                                     Html.p "Submenu 1"
        //                                 ]
        //                                 Html.li [
        //                                     Html.p "Parent"
        //                                     Html.ul [
        //                                         prop.className "p-2"
        //                                         prop.children [
        //                                             Html.li [
        //                                                 Html.p "Submenu 1"
        //                                             ]
        //                                             Html.li [
        //                                                 Html.p "Submenu 2"
        //                                             ]
        //                                         ]
        //                                     ]
        //                                 ]
        //                                 Html.li [
        //                                     Html.p "Item 3"
        //                                 ]
        //                             ]
        //                         ]
        //                     ]
        //                 ]
        //             ]
        //         ]
        //     ]
        // ]

        // Html.div [
        //     prop.classes [ "navbar"; "bg-bae-100"; "shadow-sm" ]
        //     prop.children [
        //         Html.div [ prop.className "flex-none" ]
        //         Html.div [
        //             prop.className "flex-1"
        //             prop.children [
        //                 Html.a [
        //                     prop.classes [ "btn"; "btn-ghost"; "link"; "link-hover" ]
        //                     prop.href "/"
        //                     prop.text "Home"
        //                 ]
        //                 Html.a [
        //                     prop.classes [ "btn"; "btn-ghost"; "link"; "link-hover" ]
        //                     prop.href "/users"
        //                     prop.text "Users"
        //                 ]
        //             ]
        //         ]
        //         Html.div [ prop.className "flex-none" ]
        //     ]
        // ]        