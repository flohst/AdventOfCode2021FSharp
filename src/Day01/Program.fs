open System

[<EntryPoint>]
let main args =
    printfn "Nice command-line arguments! Here's what System.Text.Json has to say about them:"


    args |> Array.iter (fun item -> printfn "%s" item)

    0 // return an integer exit code
