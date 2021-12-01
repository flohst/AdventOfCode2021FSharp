open System.IO

let readLines filename = File.ReadAllLines filename

let isPreviousValueSmaller value previousIndex array =
    array
    |> Array.tryItem previousIndex
    |> Option.map (fun previousValue -> previousValue < value)
    |> Option.defaultValue false

[<EntryPoint>]
let main args =
    let filename =
        Array.tryItem 0 args
        |> Option.defaultValue "./input.txt"

    let lines =
        readLines filename
        |> Array.map (fun line -> int line)

    printfn "Read %i lines from %s" lines.Length filename

    let largerThanPrevious =
        lines
        |> Array.indexed
        |> Array.fold
            (fun acc line ->
                let (index, content) = line
                let previousIndex = index - 1

                if index = 0 then
                    acc
                elif isPreviousValueSmaller content previousIndex lines then
                    acc + 1
                else
                    acc)
            0

    printfn "%i values are larger than the previous" largerThanPrevious

    0 // return an integer exit code
