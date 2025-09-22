module Server

open SharedTypes

open Falco
open Falco.Routing

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.AspNetCore.Cors.Infrastructure

module ErrorResponse =
    let badRequest error : HttpHandler =
        Response.withStatusCode 400 >> Response.ofJson error

    let notFound: HttpHandler =
        Response.withStatusCode 404
        >> Response.ofJson { Code = "404"; Message = "Not Found" }

    let serverException: HttpHandler =
        Response.withStatusCode 500
        >> Response.ofJson {
            Code = "500"
            Message = "Server Error"
        }

module Route =
    let allUsers = "/users"

module UserEndpoint =


    let allUsers: HttpHandler =


        fun ctx -> task {
            // raise( System.Exception "Error")
            // printfn "Call: /users"

            let allUsers = [
                {
                    UserName = "aUserName"
                    FullName = "aFullName"
                }
                {
                    UserName = "bUserName"
                    FullName = "bFullName"
                }
                {
                    UserName = "cUserName"
                    FullName = "cFullName"
                }
            ]

            return! Response.ofJson allUsers ctx
        }

module App =
    let endpoints = [ get Route.allUsers UserEndpoint.allUsers ]

module Program =

    [<EntryPoint>]
    let main args =

        let isDevelopment = true

        let corsDevelopmentPolicy (builder: CorsPolicyBuilder) =
            builder.WithOrigins("http://localhost:5000", "http://localhost:8080").AllowAnyMethod().AllowAnyHeader()
            |> ignore

        let webApplicationBuilder = WebApplication.CreateBuilder(args)

        // Set up: Services
        webApplicationBuilder.Services.AddAntiforgery() |> ignore

        // Set up: CorsDevelopmentPolicy
        if isDevelopment then
            webApplicationBuilder.Services.AddCors(fun (options: CorsOptions) ->
                options.AddPolicy("CorsDevelopmentPolicy", corsDevelopmentPolicy))
            |> ignore



        // Build...
        let webApplication = webApplicationBuilder.Build()

        if isDevelopment then
            webApplication.UseCors("CorsDevelopmentPolicy").UseDeveloperExceptionPage()
            |> ignore
        else
            webApplication.UseFalcoExceptionHandler(ErrorResponse.serverException) |> ignore

        webApplication.UseRouting().UseFalco(App.endpoints).Run(ErrorResponse.notFound)


        0





(*
module Server

open System
open System.IO
open Giraffe
open SharedTypes
open Fable.Remoting.Server
open Fable.Remoting.Giraffe
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.AspNetCore.Cors.Infrastructure


let getStudents() =
  async {
    raise ( FileNotFoundException("File not found"))
    return [
        { Name = "Mike";  Age = 23; }
        { Name = "John";  Age = 22; }
        { Name = "Diana"; Age = 22; }
    ]
  }

let findStudentByName name =
  async {
    let! students = getStudents()
    let student = List.tryFind (fun student -> student.Name = name) students
    return student
  }

let studentApi : IStudentApi = {
    studentByName = findStudentByName
    allStudents = getStudents
}

let webApp : HttpHandler =
    Remoting.createApi()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromValue studentApi
    |> Remoting.buildHttpHandler

let configureCors (builder : CorsPolicyBuilder) =
    builder
        .WithOrigins(
            "http://localhost:5000",
            "http://localhost:8080")
       .AllowAnyMethod()
       .AllowAnyHeader()
       |> ignore

let configureApp (app : IApplicationBuilder) =
    app.UseCors configureCors |> ignore
    // Add Giraffe to the ASP.NET Core pipeline
    app.UseGiraffe webApp


let configureServices (services : IServiceCollection) =
    // Add Giraffe dependencies
    services.AddCors() |> ignore
    services.AddGiraffe() |> ignore

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .Configure(configureApp)
                    .ConfigureServices configureServices
                    |> ignore)
        .Build()
        .Run()
    0


//--- Falco ---//



module Server

open System.Data
open Donald
// ^-- external package that makes using databases simpler
open Falco
open Falco.Routing
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open System.Data.SQLite
open SharedTypes
// ^-- official SQLite package
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.AspNetCore.Cors.Infrastructure


type IDbConnectionFactory =
    abstract member Create : unit -> IDbConnection

type IStore<'TKey, 'TItem> =
    abstract member List : unit   -> 'TItem list
    abstract member Create : 'TItem -> Result<unit, Error>
    abstract member Read : 'TKey -> 'TItem option
    abstract member Delete : 'TKey -> Result<unit, Error>

type UserStore(dbConnection : IDbConnectionFactory) =
    let userOfDataReader (rd : IDataReader) =
        { UserName = rd.ReadString "username"
          FullName = rd.ReadString "full_name" }

    interface IStore<string, User> with
        member _.List() =
            use conn = dbConnection.Create()
            conn
            |> Db.newCommand "SELECT username, full_name FROM user"
            |> Db.query userOfDataReader

        member _.Create(user : User) =
            use conn = dbConnection.Create()
            try
                conn
                |> Db.newCommand "
                    INSERT INTO user (username, full_name)
                    SELECT    @username
                            , @full_name
                    WHERE     @username NOT IN (
                                SELECT username FROM user)"
                |> Db.setParams [
                    "username", SqlType.String user.UserName
                    "full_name", SqlType.String user.FullName ]
                |> Db.exec
                |> Ok
            with
            | :? DbExecutionException ->
                Error { Code = "FAILED"; Message = "Could not add user" }

        member _.Read(username : string) =
            use conn = dbConnection.Create()
            conn
            |> Db.newCommand "
                SELECT    username
                        , full_name
                FROM      user
                WHERE     username = @username"
            |> Db.setParams [ "username", SqlType.String username ]
            |> Db.querySingle userOfDataReader

        member _.Delete(username : string) =
            use conn = dbConnection.Create()
            try
                conn
                |> Db.newCommand "DELETE FROM user WHERE username = @username"
                |> Db.setParams [ "username", SqlType.String username ]
                |> Db.exec
                |> Ok
            with
            | :? DbExecutionException ->
                Error { Code = "FAILED"; Message = "Could not add user" }

module ErrorResponse =
    let badRequest error : HttpHandler =
        Response.withStatusCode 400
        >> Response.ofJson error

    let notFound : HttpHandler =
        Response.withStatusCode 404 >>
        Response.ofJson { Code = "404"; Message = "Not Found" }

    let serverException : HttpHandler =
        Response.withStatusCode 500 >>
        Response.ofJson { Code = "500"; Message = "Server Error" }

module Route =
    let userIndex = "/users"
    let userAdd = "/users"
    let userView = "/users/{username}"
    let userRemove = "/users/{username}"

module UserEndpoint =
    let index : HttpHandler = fun ctx ->
        let userStore = ctx.Plug<IStore<string, User>>()
        let allUsers = userStore.List()
        Response.ofJson allUsers ctx

    let add : HttpHandler = fun ctx -> task {
        let userStore = ctx.Plug<IStore<string, User>>()
        let! userJson = Request.getJson<User> ctx
        let userAddResponse =
            match userStore.Create(userJson) with
            | Ok result -> Response.ofJson result ctx
            | Error error -> ErrorResponse.badRequest error ctx
        return! userAddResponse }

    let view : HttpHandler = fun ctx ->
        let userStore = ctx.Plug<IStore<string, User>>()
        let route = Request.getRoute ctx
        let username = route?username.AsString()
        match userStore.Read(username) with
        | Some user -> Response.ofJson user ctx
        | None -> ErrorResponse.notFound ctx

    let remove : HttpHandler = fun ctx ->
        let userStore = ctx.Plug<IStore<string, User>>()
        let route = Request.getRoute ctx
        let username = route?username.AsString()
        match userStore.Delete(username) with
        | Ok result -> Response.ofJson result ctx
        | Error error -> ErrorResponse.badRequest error ctx

module App =
    let endpoints =
        [ get Route.userIndex UserEndpoint.index
          post Route.userAdd UserEndpoint.add
          get Route.userView UserEndpoint.view
          delete Route.userRemove UserEndpoint.remove ]

module Program =
    open Microsoft.AspNetCore.Cors.Infrastructure
    [<EntryPoint>]
    let main args =
        let dbConnectionFactory =
            { new IDbConnectionFactory with
                member _.Create() = new SQLiteConnection "Data Source=store.db" }

        let initializeDatabase (dbConnection : IDbConnectionFactory) =
            use conn = dbConnection.Create()
            conn
            |> Db.newCommand "CREATE TABLE IF NOT EXISTS user (username, full_name)"
            |> Db.exec

        initializeDatabase dbConnectionFactory

        let configureCors (builder : CorsPolicyBuilder) =
            builder
                .WithOrigins(
                    "http://localhost:5000",
                    "http://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader() |> ignore



        let bldr = WebApplication.CreateBuilder(args)

        bldr.Services
            .AddAntiforgery()
            .AddSingleton<IDbConnectionFactory>(dbConnectionFactory)
            .AddScoped<IStore<string, User>, UserStore>()
            .AddCors(fun options -> options.AddPolicy("Dev",configureCors))

            |> ignore

        let wapp = bldr.Build()

        let isDevelopment = wapp.Environment.EnvironmentName = "Development"

        // wapp.UseIf(isDevelopment, DeveloperExceptionPageExtensions.UseDeveloperExceptionPage)
        //     .UseIf(not(isDevelopment), FalcoExtensions.UseFalcoExceptionHandler ErrorResponse.serverException)

        wapp.UseIf(isDevelopment, FalcoExtensions.UseFalcoExceptionHandler ErrorResponse.serverException)
            .UseIf(not(isDevelopment), FalcoExtensions.UseFalcoExceptionHandler ErrorResponse.serverException)
            .UseCors()
            .UseRouting()
            .UseFalco(App.endpoints)
            .Run(ErrorResponse.notFound)

        0



(*
module Server

open System
open System.IO
open Giraffe
open SharedTypes
open Fable.Remoting.Server
open Fable.Remoting.Giraffe
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.AspNetCore.Cors.Infrastructure


let getStudents() =
  async {
    raise ( FileNotFoundException("File not found"))
    return [
        { Name = "Mike";  Age = 23; }
        { Name = "John";  Age = 22; }
        { Name = "Diana"; Age = 22; }
    ]
  }

let findStudentByName name =
  async {
    let! students = getStudents()
    let student = List.tryFind (fun student -> student.Name = name) students
    return student
  }

let studentApi : IStudentApi = {
    studentByName = findStudentByName
    allStudents = getStudents
}

let webApp : HttpHandler =
    Remoting.createApi()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromValue studentApi
    |> Remoting.buildHttpHandler

let configureCors (builder : CorsPolicyBuilder) =
    builder
        .WithOrigins(
            "http://localhost:5000",
            "http://localhost:8080")
       .AllowAnyMethod()
       .AllowAnyHeader()
       |> ignore

let configureApp (app : IApplicationBuilder) =
    app.UseCors configureCors |> ignore
    // Add Giraffe to the ASP.NET Core pipeline
    app.UseGiraffe webApp


let configureServices (services : IServiceCollection) =
    // Add Giraffe dependencies
    services.AddCors() |> ignore
    services.AddGiraffe() |> ignore

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .Configure(configureApp)
                    .ConfigureServices configureServices
                    |> ignore)
        .Build()
        .Run()
    0

*)



*)