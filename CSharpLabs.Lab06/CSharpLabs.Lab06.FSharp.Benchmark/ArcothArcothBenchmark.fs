module ArcothArcothBenchmark

open System
open BenchmarkDotNet.Attributes

open CSharpLabs.Lab01.Core.InverseHyperbolicCotangent

let calcAsync (calcCreator: (unit -> AbstractArcoth)) (x, eps) =
    async {
        let calc = calcCreator ()
        calc.Calculate(x, eps, Int32.MaxValue) |> ignore
    }

[<HtmlExporter>]
[<CsvExporter>]
[<RPlotExporter>]
type ArcothArcothBenchmark() =
    let arr =
        [| 1.00000001 .. 0.00000001 .. 1.0000024 |]
        |> Array.map (fun i -> (i, 1e-8))

    member val public CalcCreators: (unit -> AbstractArcoth) list = [ fun () -> upcast (ArcothAvx())
                                                                      fun () -> upcast (ArcothLinq())
                                                                      fun () -> upcast (ArcothNaive())
                                                                      fun () -> upcast (ArcothOptimized())
                                                                      ] with get, set

    [<ParamsSource("CalcCreators")>]
    member val public CalcCreator: (unit -> AbstractArcoth) = fun () -> upcast (ArcothAvx()) with get, set

    member val public Degrees = [ 1 .. 24 ] with get, set

    [<ParamsSource("Degrees")>]
    member val public Degree = 0 with get, set

    [<Benchmark>]
    member this.BenchmarkParallelDegree() =
        arr
        |> Seq.map (calcAsync this.CalcCreator)
        |> (fun r -> Async.Parallel(r, this.Degree))
        |> Async.RunSynchronously
