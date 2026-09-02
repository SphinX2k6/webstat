using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using CSharpScript.Launcher.Util.Json;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004645 RID: 17989
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PatchManifestConverter : JsonConverter<PatchManifest>
	{
		// Token: 0x0602EF62 RID: 192354 RVA: 0x00B206D8 File Offset: 0x00B1E8D8
		public override PatchManifest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartObject)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Expected StartObject, found ");
				defaultInterpolatedStringHandler.AppendFormatted<JsonTokenType>(reader.TokenType);
				throw new JsonException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			PatchManifest patchManifest = new PatchManifest();
			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.EndObject)
				{
					return patchManifest;
				}
				if (reader.TokenType != JsonTokenType.PropertyName)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Expected PropertyName, found ");
					defaultInterpolatedStringHandler.AppendFormatted<JsonTokenType>(reader.TokenType);
					throw new JsonException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				string @string = reader.GetString();
				reader.Read();
				if (!(@string == "BaseFiles"))
				{
					if (!(@string == "PatchFiles"))
					{
						if (!(@string == "BaseDiffMap"))
						{
							if (!(@string == "CurDiffMap"))
							{
								if (!(@string == "RevertMap"))
								{
									reader.Skip();
								}
								else
								{
									if (reader.TokenType != JsonTokenType.StartObject && reader.TokenType != JsonTokenType.Null)
									{
										DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 1);
										defaultInterpolatedStringHandler.AppendLiteral("Expected object or null for RevertMap, found ");
										defaultInterpolatedStringHandler.AppendFormatted<JsonTokenType>(reader.TokenType);
										throw new JsonException(defaultInterpolatedStringHandler.ToStringAndClear());
									}
									patchManifest.RevertMap = (LauncherJsonReader.Read<Dictionary<string, List<PatchInfo>>>(ref reader, options) ?? new Dictionary<string, List<PatchInfo>>());
									patchManifest.RevertMap.Remove("__kr_map__");
								}
							}
							else
							{
								if (reader.TokenType != JsonTokenType.StartObject && reader.TokenType != JsonTokenType.Null)
								{
									DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 1);
									defaultInterpolatedStringHandler.AppendLiteral("Expected object or null for CurDiffMap, found ");
									defaultInterpolatedStringHandler.AppendFormatted<JsonTokenType>(reader.TokenType);
									throw new JsonException(defaultInterpolatedStringHandler.ToStringAndClear());
								}
								patchManifest.CurDiffMap = (LauncherJsonReader.Read<Dictionary<string, List<PatchInfo>>>(ref reader, options) ?? new Dictionary<string, List<PatchInfo>>());
								patchManifest.CurDiffMap.Remove("__kr_map__");
							}
						}
						else
						{
							if (reader.TokenType != JsonTokenType.StartObject && reader.TokenType != JsonTokenType.Null)
							{
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 1);
								defaultInterpolatedStringHandler.AppendLiteral("Expected object or null for BaseDiffMap, found ");
								defaultInterpolatedStringHandler.AppendFormatted<JsonTokenType>(reader.TokenType);
								throw new JsonException(defaultInterpolatedStringHandler.ToStringAndClear());
							}
							patchManifest.BaseDiffMap = (LauncherJsonReader.Read<Dictionary<string, List<PatchInfo>>>(ref reader, options) ?? new Dictionary<string, List<PatchInfo>>());
							patchManifest.BaseDiffMap.Remove("__kr_map__");
						}
					}
					else if (reader.TokenType == JsonTokenType.StartArray)
					{
						patchManifest.PatchFiles = (LauncherJsonReader.Read<List<ResFileInfo>>(ref reader, options) ?? new List<ResFileInfo>());
					}
					else
					{
						if (reader.TokenType != JsonTokenType.Null)
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 1);
							defaultInterpolatedStringHandler.AppendLiteral("Expected array or null for PatchFiles, found ");
							defaultInterpolatedStringHandler.AppendFormatted<JsonTokenType>(reader.TokenType);
							throw new JsonException(defaultInterpolatedStringHandler.ToStringAndClear());
						}
						patchManifest.PatchFiles = new List<ResFileInfo>();
					}
				}
				else if (reader.TokenType == JsonTokenType.StartArray)
				{
					patchManifest.BaseFiles = (LauncherJsonReader.Read<List<ResFileInfo>>(ref reader, options) ?? new List<ResFileInfo>());
				}
				else
				{
					if (reader.TokenType != JsonTokenType.Null)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(44, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Expected array or null for BaseFiles, found ");
						defaultInterpolatedStringHandler.AppendFormatted<JsonTokenType>(reader.TokenType);
						throw new JsonException(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					patchManifest.BaseFiles = new List<ResFileInfo>();
				}
			}
			throw new JsonException("Unexpected end of JSON input");
		}

		// Token: 0x0602EF63 RID: 192355 RVA: 0x00B20A10 File Offset: 0x00B1EC10
		public override void Write(Utf8JsonWriter writer, PatchManifest value, JsonSerializerOptions options)
		{
			writer.WriteStartObject();
			writer.WritePropertyName("BaseFiles");
			JsonSerializer.Serialize<List<ResFileInfo>>(writer, value.BaseFiles, options);
			writer.WritePropertyName("PatchFiles");
			JsonSerializer.Serialize<List<ResFileInfo>>(writer, value.PatchFiles, options);
			writer.WritePropertyName("BaseDiffMap");
			JsonSerializer.Serialize<Dictionary<string, List<PatchInfo>>>(writer, value.BaseDiffMap, options);
			writer.WritePropertyName("CurDiffMap");
			JsonSerializer.Serialize<Dictionary<string, List<PatchInfo>>>(writer, value.CurDiffMap, options);
			writer.WritePropertyName("RevertMap");
			JsonSerializer.Serialize<Dictionary<string, List<PatchInfo>>>(writer, value.RevertMap, options);
			writer.WriteEndObject();
		}
	}
}
