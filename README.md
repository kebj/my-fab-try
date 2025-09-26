# Read me


## Install pre-requisites

You'll need to install the following pre-requisites in order to build SAFE applications

* [.NET SDK](https://www.microsoft.com/net/download) 8.0 or higher
* [Node 18](https://nodejs.org/en/download/) or higher
* [NPM 9](https://www.npmjs.com/package/npm) or higher

## Starting the application

To concurrently run the server and the client components in watch mode use the following command:

```bash
dotnet run
```
Then open `http://localhost:8080` in your browser.

Use `Bundle` target to package your app:

```bash
dotnet run -- Bundle

```
See:
https://safe-stack.github.io/docs/recipes/ui/add-shadcn/

npx shadcn@latest add button









