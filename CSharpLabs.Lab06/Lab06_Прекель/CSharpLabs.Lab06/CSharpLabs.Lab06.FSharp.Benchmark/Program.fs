open BenchmarkDotNet.Running
open ArcothArcothBenchmark

[<EntryPoint>]
let main argv =
    BenchmarkRunner.Run<ArcothArcothBenchmark>() |> ignore
    0