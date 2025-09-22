namespace App
open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch
open Feliz.DaisyUI

type Users =
    [<ReactComponent>]
    static member Render() =
        let getUsers, setUsers = React.useState ([||])

        UserApi.loadUsers
        |> Promise.map (fun response ->
            let users:User[] = response
            setUsers users)
        |> Promise.catch (fun error -> printfn "Fel: %A" error)
        |> Async.AwaitPromise
        |> Async.StartImmediate
        |> ignore

        let renderUsers (users: User array) =
            Html.ul [
                for user in users do
                    Html.li user.UserName
            ]

        Html.div [
            Daisy.button.button [
                button.primary
                prop.text "DaisyUI"
                prop.onClick (fun a -> printfn "DaisyUI cli")
            ]

            if getUsers.Length > 0 then
                renderUsers getUsers
        ]

