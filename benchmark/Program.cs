// See https://aka.ms/new-console-template for more information

using benchmark;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Http2VsHttp3BenchMark>();