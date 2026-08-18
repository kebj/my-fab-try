namespace App
open Fable.Core.JsInterop
open Feliz
open Feliz.DaisyUI
open Fable.Core.JS
open Browser

module FableFeliz =
    [<ReactComponent>]
    let Render() =

        // Import the component from the local relative path, using Feli
        let myComponent (props: {| title: string; onClick: unit -> unit |}) : ReactElement =
            import "default" "../components/MyComponent.tsx"

        let clickHandler () =
            window.alert "Button clicked and handled in Fable.Feliz F#"

        React.Fragment [
            Html.h1 "Fable Feliz Page"
            myComponent {| title = "Hello from a React.tsx component"; onClick = clickHandler |}
        ]
