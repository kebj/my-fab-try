# Read me


## Install pre-requisites

You'll need to install the following pre-requisites in order to build

* [.NET SDK](https://www.microsoft.com/net/download) 10.0 or higher
* [Node 18](https://nodejs.org/en/download/) or higher
* [NPM 9](https://www.npmjs.com/package/npm) or higher

## Starting the application

To concurrently run the server and the client components in watch mode use the following command in the project root:

```bash
dotnet run
```
Then open `http://localhost:8080` in your browser.


To shut down the server use the following command:
```bash
Ctrl + c
```


Use `Bundle` target to package your app:

```bash
dotnet run -- Bundle

```
