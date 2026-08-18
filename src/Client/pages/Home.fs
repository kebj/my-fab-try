namespace App
open Fable.Core.JsInterop
open Feliz
open Feliz.DaisyUI
open Fable.Core.JS
open Browser

module Home =

    [<ReactComponent>]
    let Render() =
        Html.h1 "Home"

