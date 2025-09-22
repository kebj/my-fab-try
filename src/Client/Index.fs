

module Index

open Feliz
open Browser.Dom
open SharedTypes
open App




let root = ReactDOM.createRoot (document.getElementById "root")
root.render (Router.Render())