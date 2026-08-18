namespace App
open Browser.Dom
open Fable.Core
open Fable.Core.JsInterop
open Fable.React

module FableReact =

    let Render() =

        // Import the component from the local relative path, using Fable.React style
        let inline myComponent (props: {| title: string; onClick: unit -> unit |}) : ReactElement =
            ofImport "default" "../components/MyComponent.tsx" props []

        let clickHandler () =
            window.alert "Button clicked and handled in Fable.React F#"

        fragment [] [
            h1 [] [ str "Fable React Page" ]
            myComponent {| title = "Hello from a React.tsx component"; onClick = clickHandler |}
        ]
