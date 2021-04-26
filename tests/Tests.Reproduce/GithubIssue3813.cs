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

using System;
using System.Text;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;

namespace Tests.Reproduce
{
	public class GithubIssue3813
	{
		[U]
		public void CanDeserializeQuerySqlResponseWithNullValuesInRows()
		{
			var json = "{\"columns\":[{\"name\":\"@timestamp\",\"type\":\"datetime\"},{\"name\":\"@version\",\"type\":\"text\"},{\"name\":\"agent.ephemeral_id\",\"type\":\"text\"},{\"name\":\"agent.hostname\",\"type\":\"text\"},{\"name\":\"agent.id\",\"type\":\"text\"},{\"name\":\"agent.type\",\"type\":\"text\"},{\"name\":\"agent.version\",\"type\":\"text\"},{\"name\":\"cpu_final\",\"type\":\"float\"},{\"name\":\"disk_space_free\",\"type\":\"long\"},{\"name\":\"disk_space_total\",\"type\":\"long\"},{\"name\":\"disk_space_used_pct\",\"type\":\"float\"},{\"name\":\"ecs.version\",\"type\":\"text\"},{\"name\":\"error.message\",\"type\":\"text\"},{\"name\":\"event.dataset\",\"type\":\"text\"},{\"name\":\"event.duration\",\"type\":\"long\"},{\"name\":\"event.module\",\"type\":\"text\"},{\"name\":\"fields.app_id\",\"type\":\"text\"},{\"name\":\"fields.env\",\"type\":\"text\"},{\"name\":\"host.architecture\",\"type\":\"text\"},{\"name\":\"host.hostname\",\"type\":\"text\"},{\"name\":\"host.id\",\"type\":\"text\"},{\"name\":\"host.name\",\"type\":\"text\"},{\"name\":\"host.os.build\",\"type\":\"text\"},{\"name\":\"host.os.family\",\"type\":\"text\"},{\"name\":\"host.os.kernel\",\"type\":\"text\"},{\"name\":\"host.os.name\",\"type\":\"text\"},{\"name\":\"host.os.platform\",\"type\":\"text\"},{\"name\":\"host.os.version\",\"type\":\"text\"},{\"name\":\"memory_final\",\"type\":\"float\"},{\"name\":\"metricset.name\",\"type\":\"text\"},{\"name\":\"process.args\",\"type\":\"text\"},{\"name\":\"process.name\",\"type\":\"text\"},{\"name\":\"process.pgid\",\"type\":\"long\"},{\"name\":\"process.pid\",\"type\":\"long\"},{\"name\":\"process.ppid\",\"type\":\"long\"},{\"name\":\"service.type\",\"type\":\"text\"},{\"name\":\"system.cpu.cores\",\"type\":\"long\"},{\"name\":\"system.cpu.idle.norm.pct\",\"type\":\"float\"},{\"name\":\"system.cpu.iowait.norm.pct\",\"type\":\"long\"},{\"name\":\"system.cpu.irq.norm.pct\",\"type\":\"long\"},{\"name\":\"system.cpu.nice.norm.pct\",\"type\":\"long\"},{\"name\":\"system.cpu.softirq.norm.pct\",\"type\":\"long\"},{\"name\":\"system.cpu.steal.norm.pct\",\"type\":\"long\"},{\"name\":\"system.cpu.system.norm.pct\",\"type\":\"float\"},{\"name\":\"system.cpu.total.norm.pct\",\"type\":\"float\"},{\"name\":\"system.cpu.user.norm.pct\",\"type\":\"float\"},{\"name\":\"system.filesystem.available\",\"type\":\"long\"},{\"name\":\"system.filesystem.device_name\",\"type\":\"text\"},{\"name\":\"system.filesystem.files\",\"type\":\"long\"},{\"name\":\"system.filesystem.free\",\"type\":\"long\"},{\"name\":\"system.filesystem.free_files\",\"type\":\"long\"},{\"name\":\"system.filesystem.mount_point\",\"type\":\"text\"},{\"name\":\"system.filesystem.total\",\"type\":\"long\"},{\"name\":\"system.filesystem.type\",\"type\":\"text\"},{\"name\":\"system.filesystem.used.bytes\",\"type\":\"long\"},{\"name\":\"system.filesystem.used.pct\",\"type\":\"float\"},{\"name\":\"system.fsstat.count\",\"type\":\"long\"},{\"name\":\"system.fsstat.total_files\",\"type\":\"long\"},{\"name\":\"system.fsstat.total_size.free\",\"type\":\"long\"},{\"name\":\"system.fsstat.total_size.total\",\"type\":\"long\"},{\"name\":\"system.fsstat.total_size.used\",\"type\":\"long\"},{\"name\":\"system.memory.actual.free\",\"type\":\"long\"},{\"name\":\"system.memory.actual.used.bytes\",\"type\":\"long\"},{\"name\":\"system.memory.actual.used.pct\",\"type\":\"float\"},{\"name\":\"system.memory.free\",\"type\":\"long\"},{\"name\":\"system.memory.swap.free\",\"type\":\"long\"},{\"name\":\"system.memory.swap.total\",\"type\":\"long\"},{\"name\":\"system.memory.swap.used.bytes\",\"type\":\"long\"},{\"name\":\"system.memory.swap.used.pct\",\"type\":\"float\"},{\"name\":\"system.memory.total\",\"type\":\"long\"},{\"name\":\"system.memory.used.bytes\",\"type\":\"long\"},{\"name\":\"system.memory.used.pct\",\"type\":\"float\"},{\"name\":\"system.process.cmdline\",\"type\":\"text\"},{\"name\":\"system.process.cpu.start_time\",\"type\":\"datetime\"},{\"name\":\"system.process.cpu.total.norm.pct\",\"type\":\"long\"},{\"name\":\"system.process.cpu.total.pct\",\"type\":\"long\"},{\"name\":\"system.process.cpu.total.value\",\"type\":\"long\"},{\"name\":\"system.process.memory.rss.bytes\",\"type\":\"long\"},{\"name\":\"system.process.memory.rss.pct\",\"type\":\"float\"},{\"name\":\"system.process.memory.share\",\"type\":\"long\"},{\"name\":\"system.process.memory.size\",\"type\":\"long\"},{\"name\":\"system.process.state\",\"type\":\"text\"},{\"name\":\"system.uptime.duration.ms\",\"type\":\"long\"},{\"name\":\"tags\",\"type\":\"text\"},{\"name\":\"user.name\",\"type\":\"text\"},{\"name\":\"windows.service.display_name\",\"type\":\"text\"},{\"name\":\"windows.service.exit_code\",\"type\":\"text\"},{\"name\":\"windows.service.id\",\"type\":\"text\"},{\"name\":\"windows.service.name\",\"type\":\"text\"},{\"name\":\"windows.service.pid\",\"type\":\"long\"},{\"name\":\"windows.service.start_type\",\"type\":\"text\"},{\"name\":\"windows.service.state\",\"type\":\"text\"},{\"name\":\"windows.service.uptime.ms\",\"type\":\"long\"}],\"rows\":[[\"2019-06-12T11:33:17.452Z\",\"1\",\"f180270c-cd24-4d91-a690-6862c5d754e5\",\"C029A3214\",\"30cfa13e-7376-4359-a268-7675db3172a6\",\"metricbeat\",\"7.0.1\",null,null,null,null,\"1.0.0\",null,\"system.memory\",null,\"system\",\"RAPHAEL\",\"DEV\",\"x86_64\",\"#########\",\"8aff5b83-db62-4f69-8552-fb2919a62c73\",\"#########\",\"7601.24443\",\"windows\",\"6.1.7601.24441 (win7sp1_ldr.190418-1735)\",\"Windows 7 Enterprise\",\"windows\",\"6.1\",95.30000305175781,\"memory\",null,null,null,null,null,\"system\",null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,803860480,16292683776,0.953000009059906,803860480,2642485248,20792926208,18150440960,0.8729000091552734,17096544256,16292683776,0.953000009059906,null,null,null,null,null,null,null,null,null,null,null,\"beats_input_raw_event\",null,null,null,null,null,null,null,null,null],[\"2019-06-12T11:33:32.452Z\",\"1\",\"f180270c-cd24-4d91-a690-6862c5d754e5\",\"C029A3214\",\"30cfa13e-7376-4359-a268-7675db3172a6\",\"metricbeat\",\"7.0.1\",null,null,null,null,\"1.0.0\",null,\"system.memory\",null,\"system\",\"RAPHAEL\",\"DEV\",\"x86_64\",\"C029A3214\",\"8aff5b83-db62-4f69-8552-fb2919a62c73\",\"C029A3214\",\"7601.24443\",\"windows\",\"6.1.7601.24441 (win7sp1_ldr.190418-1735)\",\"Windows 7 Enterprise\",\"windows\",\"6.1\",95.33999633789062,\"memory\",null,null,null,null,null,\"system\",null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,796999680,16299544576,0.9534000158309937,796999680,2624344064,20792926208,18168582144,0.8737999796867371,17096544256,16299544576,0.9534000158309937,null,null,null,null,null,null,null,null,null,null,null,\"beats_input_raw_event\",null,null,null,null,null,null,null,null,null]]}";

			var bytes = Encoding.UTF8.GetBytes(json);

			var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
			var connectionSettings = new ConnectionSettings(pool, new InMemoryConnection(bytes)).DefaultIndex("default_index");
			var client = new ElasticClient(connectionSettings);

			var response = client.Sql.Query(s => s);
			var rows = response.Rows;
			rows.Should().NotBeNull();

			rows.Count.Should().Be(2);
			foreach (var row in rows)
			{
				row.Count.Should().Be(response.Columns.Count);
			}
		}
	}
}
