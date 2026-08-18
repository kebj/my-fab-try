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

(dotnet new tool-manifest --force)

dotnet tool install --global Fable --version 5.13.0

AI
https://www.google.com/search?q=how+to+use+an+react+component+%28.tsx%29+in+fable&rlz=1C1FHFK_svSE1077SE1077&sourceid=chrome&ie=UTF-8&amc=1&aep=42&cud=0&source=chrome.crn.rb&atvm=2&mstk=AUtExfClR0kb1CtGjPLawGEsBvO75lk9MV_bs4bZWtoJ7qNq_jq-wLtjMHDcx8ubLuufXcK7iUzUeQFb9Z2Nk-dBKFPRtAxITjJgbHhKMf6xMAGeVr2aW4m4myTo1AUFmLnw0Pu7OwXZ4u9bgRLn-1DDpqFh23jaHX3MGWDFWOah_KyLKJ_CB1H_tukvlT8cetb8qUuDaxBr-974GCBrLsvc1T-JSty4LzyOxRfGWhM1YxzJPp1OsstKBapy_xJGKbtfEqihRoZzKfidQw&csuir=1&udm=50

https://www.google.com/search?q=how+to+use+an+react+component+%28.tsx%29+in+fable&rlz=1C1FHFK_svSE1077SE1077&sourceid=chrome&ie=UTF-8&amc=1&aep=42&cud=0&source=chrome.crn.rb&atvm=2&mstk=AUtExfClR0kb1CtGjPLawGEsBvO75lk9MV_bs4bZWtoJ7qNq_jq-wLtjMHDcx8ubLuufXcK7iUzUeQFb9Z2Nk-dBKFPRtAxITjJgbHhKMf6xMAGeVr2aW4m4myTo1AUFmLnw0Pu7OwXZ4u9bgRLn-1DDpqFh23jaHX3MGWDFWOah_KyLKJ_CB1H_tukvlT8cetb8qUuDaxBr-974GCBrLsvc1T-JSty4LzyOxRfGWhM1YxzJPp1OsstKBapy_xJGKbtfEqihRoZzKfidQw&csuir=1&udm=50

https://www.google.com/search?q=how+to+use+an+react+component+%28.tsx%29+in+fable&rlz=1C1FHFK_svSE1077SE1077&sourceid=chrome&ie=UTF-8&amc=1&aep=42&cud=0&source=chrome.crn.rb&atvm=2&mstk=AUtExfClR0kb1CtGjPLawGEsBvO75lk9MV_bs4bZWtoJ7qNq_jq-wLtjMHDcx8ubLuufXcK7iUzUeQFb9Z2Nk-dBKFPRtAxITjJgbHhKMf6xMAGeVr2aW4m4myTo1AUFmLnw0Pu7OwXZ4u9bgRLn-1DDpqFh23jaHX3MGWDFWOah_KyLKJ_CB1H_tukvlT8cetb8qUuDaxBr-974GCBrLsvc1T-JSty4LzyOxRfGWhM1YxzJPp1OsstKBapy_xJGKbtfEqihRoZzKfidQw&csuir=1&udm=50

3. Implementation using Fable.ReactIf your project uses the standard Fable.React syntax, you can model properties using a Discriminated Union (DU) combined with keyValueList.
open Fable.Core
open Fable.Core.JsInterop
open Fable.React

// 1. Define your React properties as Discriminated Union cases
type MyComponentProp =
    | Title of string
    | Count of int
    | OnReset of (unit -> unit)

// 2. Create the wrapper function using 'ofImport'
let inline MyComponent (props: MyComponentProp list) : ReactElement =
    // LowerFirst rule ensures 'Title' becomes 'title', 'OnReset' becomes 'onReset' in JS
    let propsObj = keyValueList CaseRules.LowerFirst props
    ofImport "default" "./MyComponent.tsx" propsObj []

// 3. Render it inside your application view
let view() =
    div [] [
        h1 [] [ str "My Fable App" ]

        MyComponent [
            Title "Hello from F#"
            Count 42
            OnReset (fun () -> printfn "Reset clicked!")
        ]
    ]