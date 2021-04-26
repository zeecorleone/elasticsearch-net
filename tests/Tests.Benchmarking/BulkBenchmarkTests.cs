/*
 * Licensed to Elasticsearch B.V. under one or more contributor
 * license agreements. See the NOTICE file distributed with
 * this work for additional information regarding copyright
 * ownership. Elasticsearch B.V. licenses this file to you under
 * the Apache License, Version 2.0 (the "License"); you may
 * not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Elasticsearch.Net;
using Nest;
using Tests.Benchmarking.Framework;
using Tests.Core.Client;
using Tests.Domain;

namespace Tests.Benchmarking
{
	[BenchmarkConfig(5)]
	public class BulkBenchmarkTests
	{
		private static readonly IList<Project> Projects = Project.Generator.Clone().Generate(10000);
		private static readonly byte[] Response = TestClient.DefaultInMemoryClient.ConnectionSettings.RequestResponseSerializer.SerializeToBytes(ReturnBulkResponse(Projects));

		private static readonly IElasticClient Client =
			new ElasticClient(new ConnectionSettings(new InMemoryConnection(Response, 200, null, null))
				.DefaultIndex("index")
				.EnableHttpCompression(false)
			);

		private static readonly IElasticClient ClientNoRecyclableMemory =
			new ElasticClient(new ConnectionSettings(new InMemoryConnection(Response, 200, null, null))
				.DefaultIndex("index")
				.EnableHttpCompression(false)
			);

		private static readonly Nest7.IElasticClient ClientV7 =
			new Nest7.ElasticClient(new Nest7.ConnectionSettings(
					new Elasticsearch.Net7.InMemoryConnection(Response, 200, null, null))
				.DefaultIndex("index")
				.EnableHttpCompression(false)
			);

		[GlobalSetup]
		public void Setup() { }

		[Benchmark(Description = "PR")]
		public BulkResponse NestUpdatedBulk() => Client.Bulk(b => b.IndexMany(Projects));

		[Benchmark(Description = "PR no recyclable")]
		public BulkResponse NoRecyclableMemory() => ClientNoRecyclableMemory.Bulk(b => b.IndexMany(Projects));

		[Benchmark(Description = "7.x")]
		public Nest7.BulkResponse NestCurrentBulk() => ClientV7.Bulk(b => b.IndexMany(Projects));

		private static object BulkItemResponse(Project project) => new
		{
			index = new
			{
				_index = "nest-52cfd7aa",
				_id = project.Name,
				_version = 1,
				_shards = new
				{
					total = 2,
					successful = 1,
					failed = 0
				},
				created = true,
				status = 201
			}
		};

		private static object ReturnBulkResponse(IList<Project> projects) => new
		{
			took = 276,
			errors = false,
			items = projects
				.Select(p => BulkItemResponse(p))
				.ToArray()
		};
	}
}
