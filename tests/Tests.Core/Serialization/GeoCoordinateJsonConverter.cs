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
using Nest;
using Newtonsoft.Json;

namespace Tests.Core.Serialization
{
	/// <summary>
	/// Copied over because writing coordinates out manually in ExpectJson is tedious
	/// </summary>
	internal class TestGeoCoordinateJsonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(GeoCoordinate);

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var p = (GeoCoordinate)value;
			if (p == null)
			{
				writer.WriteNull();
				return;
			}
			writer.WriteStartArray();
			serializer.Serialize(writer, p.Longitude);
			serializer.Serialize(writer, p.Latitude);
			writer.WriteEndArray();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.StartArray) return null;

			var doubles = serializer.Deserialize<double[]>(reader);
			if (doubles.Length != 2) return null;

			return new GeoCoordinate(doubles[1], doubles[0]);
		}
	}
}
