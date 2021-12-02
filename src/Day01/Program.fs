open System.IO

let readLines filename = File.ReadAllLines filename

let countLargerAsPrevious (list: int []) =
    list
    |> Array.windowed 2
    |> Array.fold
        (fun acc item ->
            let prev = item |> Array.item 0
            let curr = item |> Array.item 1
            if curr > prev then acc + 1 else acc)
        0

[<EntryPoint>]
let main args =
    let filename =
        Array.tryItem 0 args
        |> Option.defaultValue "./input.txt"

    let lines =
        readLines filename
        |> Array.map (fun line -> int line)

    printfn "Read %i lines from %s" lines.Length filename

    // Part 1
    let part1 = countLargerAsPrevious lines

    printfn "The solution to part 1 is %i" part1

    // Part 2
    let part2 =
        lines
        |> Array.windowed 3
        |> Array.map (fun item -> item |> Array.sum)
        |> countLargerAsPrevious

    printfn "The solution to part 2 is %i" part2

    0 // return an integer exit code
