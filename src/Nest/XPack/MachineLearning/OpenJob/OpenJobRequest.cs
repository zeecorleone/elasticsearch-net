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
	/// <summary>
	/// Open a machine learning job.
	/// </summary>
	[MapsApi("ml.open_job.json")]
	public partial interface IOpenJobRequest
	{
		/// <summary>
		/// Controls the time to wait until a job has opened. The default value is 30 minutes.
		/// </summary>
		[DataMember(Name ="timeout")]
		Time Timeout { get; set; }
	}

	/// <inheritdoc />
	public partial class OpenJobRequest
	{
		/// <inheritdoc />
		public Time Timeout { get; set; }
	}

	/// <inheritdoc />
	public partial class OpenJobDescriptor
	{
		Time IOpenJobRequest.Timeout { get; set; }

		/// <inheritdoc />
		public OpenJobDescriptor Timeout(Time timeout) => Assign(timeout, (a, v) => a.Timeout = v);
	}
}
