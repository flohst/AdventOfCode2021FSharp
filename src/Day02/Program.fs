open System.IO

let readLines filename = File.ReadAllLines filename

[<EntryPoint>]
let main args =
    let filename =
        Array.tryItem 0 args
        |> Option.defaultValue "./input.txt"

    let part1 =
        readLines filename
        |> Array.map (fun line -> line.Split [| ' ' |])
        |> Array.map (fun line -> (Array.item 0 line, Array.item 1 line |> int))
        |> Array.fold
            (fun acc curr ->
                let (vert, hor) = acc

                match curr with
                | (d, v) when d.StartsWith("forward") -> (vert, hor + v)
                | (d, v) when d.StartsWith("down") -> (vert + v, hor)
                | (d, v) when d.StartsWith("up") -> (vert - v, hor)
                | _ -> (vert, hor))
            (0, 0)
        |> fun (vert, hor) -> vert * hor


    // Part 1
    printfn "The solution to part 1 is %i" part1

    // Part 2

    let part2 =
        readLines filename
        |> Array.map (fun line -> line.Split [| ' ' |])
        |> Array.map (fun line -> (Array.item 0 line, Array.item 1 line |> int))
        |> Array.fold
            (fun acc curr ->
                let (depth, hor, aim) = acc

                match curr with
                | (d, v) when d.StartsWith("forward") -> (depth + aim * v, hor + v, aim)
                | (d, v) when d.StartsWith("down") -> (depth, hor, aim + v)
                | (d, v) when d.StartsWith("up") -> (depth, hor, aim - v)
                | _ -> (depth, hor, aim))
            (0, 0, 0)
        |> fun (depth, hor, _) -> depth * hor

    printfn "The solution to part 2 is %i" part2

    0 // return an integer exit code
