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

using System.Runtime.Serialization;

namespace Nest
{
	[DataContract]
	public class CatTrainedModelsRecord : ICatRecord
	{
		/// <summary>
		/// The time when the trained model was created.
		/// </summary>
		[DataMember(Name = "create_time")]
		public string CreateTime { get; set; }

		/// <summary>
		/// Information on the creator of the trained model.
		/// </summary>
		[DataMember(Name = "created_by")]
		public string CreatedBy { get; set; }

		/// <summary>
		/// Identifier for the data frame analytics job that created the model. Only displayed if it is still available.
		/// </summary>
		[DataMember(Name = "data_frame_analytics_id")]
		public string DataFrameAnalyticsId { get; set; }

		/// <summary>
		/// The description of the trained model.
		/// </summary>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		/// (Default) The estimated heap size to keep the trained model in memory.
		/// </summary>
		[DataMember(Name = "heap_size")]
		public string HeapSize { get; set; }

		/// <summary>
		/// (Default) Identifier for the trained model.
		/// </summary>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// The total number of documents that are processed by the model.
		/// </summary>
		[DataMember(Name = "ingest.count")]
		public long? IngestCount { get; set; }

		/// <summary>
		/// The total number of documents that are currently being handled by the trained model.
		/// </summary>
		[DataMember(Name = "ingest.current")]
		public long? IngestCurrent { get; set; }

		/// <summary>
		/// The total number of failed ingest attempts with the trained model.
		/// </summary>
		[DataMember(Name = "ingest.failed")]
		public long? IngestFailed { get; set; }

		/// <summary>
		/// (Default) The total number of ingest pipelines that are referencing the trained model.
		/// </summary>
		[DataMember(Name = "ingest.pipelines")]
		public string IngestPipelines { get; set; }

		/// <summary>
		/// The total time that is spent processing documents with the trained model.
		/// </summary>
		[DataMember(Name = "ingest.time")]
		public long? IngestTime { get; set; }

		/// <summary>
		/// The license level of the trained model.
		/// </summary>
		[DataMember(Name = "license")]
		public string License { get; set; }

		/// <summary>
		/// (Default) The estimated number of operations to use the trained model. This number helps measuring the computational
		/// complexity of the model.
		/// </summary>
		[DataMember(Name = "operations")]
		public string Operations { get; set; }

		/// <summary>
		/// The Elasticsearch version number in which the trained model was created.
		/// </summary>
		[DataMember(Name = "version")]
		public string Version { get; set; }
	}
}
