namespace App
open Feliz
open Feliz.Router
open SharedTypes

open Fable.Core
open Thoth.Fetch


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
            

            if getUsers.Length > 0 then
                renderUsers getUsers
        ]

