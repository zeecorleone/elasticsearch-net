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

// ███╗   ██╗ ██████╗ ████████╗██╗ ██████╗███████╗
// ████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██╔════╝
// ██╔██╗ ██║██║   ██║   ██║   ██║██║     █████╗  
// ██║╚██╗██║██║   ██║   ██║   ██║██║     ██╔══╝  
// ██║ ╚████║╚██████╔╝   ██║   ██║╚██████╗███████╗
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝╚══════╝
// -----------------------------------------------
//  
// This file is automatically generated 
// Please do not edit these files manually
// Run the following in the root of the repos:
//
// 		*NIX 		:	./build.sh codegen
// 		Windows 	:	build.bat codegen
//
// -----------------------------------------------
// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Elasticsearch.Net;
using Elasticsearch.Net.Utf8Json;
using Elasticsearch.Net.Specification.TransformApi;

// ReSharper disable RedundantBaseConstructorCall
// ReSharper disable UnusedTypeParameter
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
namespace Nest
{
	///<summary>Descriptor for Delete <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/delete-transform.html</para></summary>
	public partial class DeleteTransformDescriptor : RequestDescriptorBase<DeleteTransformDescriptor, DeleteTransformRequestParameters, IDeleteTransformRequest>, IDeleteTransformRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.TransformDelete;
		///<summary>/_transform/{transform_id}</summary>
		///<param name = "transformId">this parameter is required</param>
		public DeleteTransformDescriptor(Id transformId): base(r => r.Required("transform_id", transformId))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DeleteTransformDescriptor(): base()
		{
		}

		// values part of the url path
		Id IDeleteTransformRequest.TransformId => Self.RouteValues.Get<Id>("transform_id");
		// Request parameters
		///<summary>When `true`, the transform is deleted regardless of its current state. The default value is `false`, meaning that the transform must be `stopped` before it can be deleted.</summary>
		public DeleteTransformDescriptor Force(bool? force = true) => Qs("force", force);
	}

	///<summary>Descriptor for Get <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform.html</para></summary>
	public partial class GetTransformDescriptor : RequestDescriptorBase<GetTransformDescriptor, GetTransformRequestParameters, IGetTransformRequest>, IGetTransformRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.TransformGet;
		///<summary>/_transform/{transform_id}</summary>
		///<param name = "transformId">Optional, accepts null</param>
		public GetTransformDescriptor(Id transformId): base(r => r.Optional("transform_id", transformId))
		{
		}

		///<summary>/_transform</summary>
		public GetTransformDescriptor(): base()
		{
		}

		// values part of the url path
		Id IGetTransformRequest.TransformId => Self.RouteValues.Get<Id>("transform_id");
		///<summary>The id or comma delimited list of id expressions of the transforms to get, '_all' or '*' implies get all transforms</summary>
		public GetTransformDescriptor TransformId(Id transformId) => Assign(transformId, (a, v) => a.RouteValues.Optional("transform_id", v));
		// Request parameters
		///<summary>Whether to ignore if a wildcard expression matches no transforms. (This includes `_all` string or when no transforms have been specified)</summary>
		public GetTransformDescriptor AllowNoMatch(bool? allownomatch = true) => Qs("allow_no_match", allownomatch);
		///<summary>Omits fields that are illegal to set on transform PUT</summary>
		public GetTransformDescriptor ExcludeGenerated(bool? excludegenerated = true) => Qs("exclude_generated", excludegenerated);
		///<summary>skips a number of transform configs, defaults to 0</summary>
		public GetTransformDescriptor From(int? from) => Qs("from", from);
		///<summary>specifies a max number of transforms to get, defaults to 100</summary>
		public GetTransformDescriptor Size(int? size) => Qs("size", size);
	}

	///<summary>Descriptor for GetStats <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform-stats.html</para></summary>
	public partial class GetTransformStatsDescriptor : RequestDescriptorBase<GetTransformStatsDescriptor, GetTransformStatsRequestParameters, IGetTransformStatsRequest>, IGetTransformStatsRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.TransformGetStats;
		///<summary>/_transform/{transform_id}/_stats</summary>
		///<param name = "transformId">this parameter is required</param>
		public GetTransformStatsDescriptor(Id transformId): base(r => r.Required("transform_id", transformId))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected GetTransformStatsDescriptor(): base()
		{
		}

		// values part of the url path
		Id IGetTransformStatsRequest.TransformId => Self.RouteValues.Get<Id>("transform_id");
		// Request parameters
		///<summary>Whether to ignore if a wildcard expression matches no transforms. (This includes `_all` string or when no transforms have been specified)</summary>
		public GetTransformStatsDescriptor AllowNoMatch(bool? allownomatch = true) => Qs("allow_no_match", allownomatch);
		///<summary>skips a number of transform stats, defaults to 0</summary>
		public GetTransformStatsDescriptor From(long? from) => Qs("from", from);
		///<summary>specifies a max number of transform stats to get, defaults to 100</summary>
		public GetTransformStatsDescriptor Size(long? size) => Qs("size", size);
	}

	///<summary>Descriptor for Preview <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/preview-transform.html</para></summary>
	public partial class PreviewTransformDescriptor<TDocument> : RequestDescriptorBase<PreviewTransformDescriptor<TDocument>, PreviewTransformRequestParameters, IPreviewTransformRequest>, IPreviewTransformRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.TransformPreview;
	// values part of the url path
	// Request parameters
	}

	///<summary>Descriptor for Put <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/put-transform.html</para></summary>
	public partial class PutTransformDescriptor<TDocument> : RequestDescriptorBase<PutTransformDescriptor<TDocument>, PutTransformRequestParameters, IPutTransformRequest>, IPutTransformRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.TransformPut;
		///<summary>/_transform/{transform_id}</summary>
		///<param name = "transformId">this parameter is required</param>
		public PutTransformDescriptor(Id transformId): base(r => r.Required("transform_id", transformId))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected PutTransformDescriptor(): base()
		{
		}

		// values part of the url path
		Id IPutTransformRequest.TransformId => Self.RouteValues.Get<Id>("transform_id");
		// Request parameters
		///<summary>If validations should be deferred until transform starts, defaults to false.</summary>
		public PutTransformDescriptor<TDocument> DeferValidation(bool? defervalidation = true) => Qs("defer_validation", defervalidation);
	}

	///<summary>Descriptor for Start <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/start-transform.html</para></summary>
	public partial class StartTransformDescriptor : RequestDescriptorBase<StartTransformDescriptor, StartTransformRequestParameters, IStartTransformRequest>, IStartTransformRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.TransformStart;
		///<summary>/_transform/{transform_id}/_start</summary>
		///<param name = "transformId">this parameter is required</param>
		public StartTransformDescriptor(Id transformId): base(r => r.Required("transform_id", transformId))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected StartTransformDescriptor(): base()
		{
		}

		// values part of the url path
		Id IStartTransformRequest.TransformId => Self.RouteValues.Get<Id>("transform_id");
		// Request parameters
		///<summary>Controls the time to wait for the transform to start</summary>
		public StartTransformDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
	}

	///<summary>Descriptor for Stop <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/stop-transform.html</para></summary>
	public partial class StopTransformDescriptor : RequestDescriptorBase<StopTransformDescriptor, StopTransformRequestParameters, IStopTransformRequest>, IStopTransformRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.TransformStop;
		///<summary>/_transform/{transform_id}/_stop</summary>
		///<param name = "transformId">this parameter is required</param>
		public StopTransformDescriptor(Id transformId): base(r => r.Required("transform_id", transformId))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected StopTransformDescriptor(): base()
		{
		}

		// values part of the url path
		Id IStopTransformRequest.TransformId => Self.RouteValues.Get<Id>("transform_id");
		// Request parameters
		///<summary>Whether to ignore if a wildcard expression matches no transforms. (This includes `_all` string or when no transforms have been specified)</summary>
		public StopTransformDescriptor AllowNoMatch(bool? allownomatch = true) => Qs("allow_no_match", allownomatch);
		///<summary>Whether to force stop a failed transform or not. Default to false</summary>
		public StopTransformDescriptor Force(bool? force = true) => Qs("force", force);
		///<summary>Controls the time to wait until the transform has stopped. Default to 30 seconds</summary>
		public StopTransformDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
		///<summary>Whether to wait for the transform to reach a checkpoint before stopping. Default to false</summary>
		public StopTransformDescriptor WaitForCheckpoint(bool? waitforcheckpoint = true) => Qs("wait_for_checkpoint", waitforcheckpoint);
		///<summary>Whether to wait for the transform to fully stop before returning or not. Default to false</summary>
		public StopTransformDescriptor WaitForCompletion(bool? waitforcompletion = true) => Qs("wait_for_completion", waitforcompletion);
	}

	///<summary>Descriptor for Update <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/update-transform.html</para></summary>
	public partial class UpdateTransformDescriptor<TDocument> : RequestDescriptorBase<UpdateTransformDescriptor<TDocument>, UpdateTransformRequestParameters, IUpdateTransformRequest>, IUpdateTransformRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.TransformUpdate;
		///<summary>/_transform/{transform_id}/_update</summary>
		///<param name = "transformId">this parameter is required</param>
		public UpdateTransformDescriptor(Id transformId): base(r => r.Required("transform_id", transformId))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected UpdateTransformDescriptor(): base()
		{
		}

		// values part of the url path
		Id IUpdateTransformRequest.TransformId => Self.RouteValues.Get<Id>("transform_id");
		// Request parameters
		///<summary>If validations should be deferred until transform starts, defaults to false.</summary>
		public UpdateTransformDescriptor<TDocument> DeferValidation(bool? defervalidation = true) => Qs("defer_validation", defervalidation);
	}
}