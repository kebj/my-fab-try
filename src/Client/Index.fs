

module Index

open Feliz
open Browser.Dom
open SharedTypes
open App
open Feliz.Router

let root = ReactDOM.createRoot (document.getElementById "root")
root.render (AppRouter.Render())