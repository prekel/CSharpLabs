module ArcothArcothBenchmark

open System
open BenchmarkDotNet.Attributes

open CSharpLabs.Lab01.Core.InverseHyperbolicCotangent

let calcAsync (calcCreator: (unit -> AbstractArcoth)) x =
    async {
        let calc = calcCreator ()
        calc.Calculate(x, 1e-7, Int32.MaxValue) |> ignore
    }

[<HtmlExporter>]
[<CsvExporter>]
[<RPlotExporter>]
type ArcothArcothBenchmark() =
    let arr =
        [| 1.0000000 .. 0.0000001 .. 1.0000120 |]

    member val public CalcCreators: (unit -> AbstractArcoth) list = [ fun () -> upcast (ArcothAvx())
                                                                      //fun () -> upcast (ArcothLinq())
                                                                      //fun () -> upcast (ArcothNaive())
                                                                      fun () -> upcast (ArcothOptimized()) ] with get, set

    [<ParamsSource("CalcCreators")>]
    member val public CalcCreator: (unit -> AbstractArcoth) = fun () -> upcast (ArcothAvx()) with get, set

    member val public Degrees = [ 1 .. Environment.ProcessorCount * 2 ] with get, set

    [<ParamsSource("Degrees")>]
    member val public Degree = 0 with get, set

    [<Benchmark>]
    member this.BenchmarkParallelDegree() =
        arr
        |> Seq.map (calcAsync this.CalcCreator)
        |> (fun r -> Async.Parallel(r, this.Degree))
        |> Async.RunSynchronously
