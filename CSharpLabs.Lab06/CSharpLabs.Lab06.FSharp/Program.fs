open System
open System.Diagnostics
open System.IO
open CSharpLabs.Lab01.Core.InverseHyperbolicCotangent
open CSharpLabs.Lab01.Core

let calcAsync (x, eps) =
    async {
        let calc = ArcothAvx()
        let a = calc.Calculate(x, eps, Int32.MaxValue)
        return (x, a, calc.N, calc.Status)
    }

[<EntryPoint>]
let main argv =
    let sw = Stopwatch()
    sw.Start()
    let a =
        [ 1.0 .. 0.0000000001 .. 1.000001 ]
        |> Seq.map (fun i -> (i, 1e-9))
        |> Seq.map calcAsync
        |> Async.Parallel
        |> Async.RunSynchronously
    printfn "%f" sw.Elapsed.TotalMilliseconds

    printfn
        "%s"
        (a
         |> Array.take 10
         |> Array.map (fun (x, res, n, status) ->
             $" {x, 20} | {ArcothAvx.ReferenceFunction(x), 20} | {res, 20} | {n, 10} | {status, 20}")
         |> String.concat "\n")

    0
