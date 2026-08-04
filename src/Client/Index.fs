

module Index

open Feliz
open Browser.Dom
open SharedTypes

let root = ReactDOM.createRoot (document.getElementById "root")
root.render (App.Navigator.Render())