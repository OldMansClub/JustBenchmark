﻿using JustBenchmark.BenchmarkSubscribers;
using System.Threading.Tasks;
using Xunit;

namespace JustBenchmark.Tests {
	public class TestTaskBenchmark {
		class BenchmarkClass {
			public int ExecuteCount;

			[TaskBenchmark(100)]
			public async Task BenchmarkMethod() {
				await Task.Delay(1);
				++ExecuteCount;
			}
		}

		[Fact]
		public void Benchmark() {
			var benchmark = new JustBenchmark(new IBenchmarkSubscribers[0]);
			var obj = new BenchmarkClass();
			benchmark.Run(obj);
			Assert.Equal(obj.ExecuteCount, 100);
			benchmark.Run(obj);
			Assert.Equal(obj.ExecuteCount, 200);
		}
	}
}
