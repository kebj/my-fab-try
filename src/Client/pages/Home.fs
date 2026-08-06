namespace App
open Fable.Core.JsInterop
open Feliz
open Feliz.DaisyUI
open Fable.Core.JS
open Browser

type Home =
    [<ReactComponent>]
    static member Render() =

        // Import the component from the local relative path
        let myComponent (props: {| title: string; onClick: unit -> unit |}) : ReactElement =
            import "default" "../components/MyComponent.tsx"

        let clickHandler () =
            window.alert "Button clicked and handled in Fable.Feliz F#"

        React.Fragment [
            
            myComponent {| title = "Hello from a React.tsx component"; onClick = clickHandler |}


        ]
