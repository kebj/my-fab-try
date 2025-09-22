

module UserApi

open Fable.Core
open Thoth.Fetch
open System
open SharedTypes


let loadUsers: JS.Promise<User array> = promise {
    let url = sprintf "http://localhost:5000/users"
    return! Fetch.get (url, caseStrategy = Thoth.Json.CaseStrategy.PascalCase)
}
