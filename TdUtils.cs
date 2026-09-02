using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Aki.TDConfigMgr.Component;

// Token: 0x02003461 RID: 13409
[NullableContext(1)]
[Nullable(0)]
public class TdUtils : IStaticVariableResetter
{
	// Token: 0x0601C213 RID: 115219 RVA: 0x00864C02 File Offset: 0x00862E02
	static TdUtils()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TdUtils.CreateStaticDefaultValue), new Action(TdUtils.ResetStaticDefaultValue));
	}

	// Token: 0x17002661 RID: 9825
	// (get) Token: 0x0601C214 RID: 115220 RVA: 0x00864C21 File Offset: 0x00862E21
	public static Dictionary<ELevelPrefabBpType, string> LevelPrefabBpPathConfig
	{
		get
		{
			return TdUtils._levelPrefabBpPathConfig;
		}
	}

	// Token: 0x0601C215 RID: 115221 RVA: 0x00864C28 File Offset: 0x00862E28
	[NullableContext(0)]
	[return: Nullable(2)]
	public static T GetComponent<T>([Nullable(new byte[]
	{
		1,
		2
	})] Dictionary<EConfigComponent, IComponentBase> componentsData, EConfigComponent componentType) where T : IComponentBase
	{
		if (componentsData == null)
		{
			return default(T);
		}
		IComponentBase componentBase;
		if (!componentsData.TryGetValue(componentType, out componentBase))
		{
			return default(T);
		}
		if (componentBase != null && componentBase.Disabled.GetValueOrDefault())
		{
			return default(T);
		}
		return componentBase as T;
	}

	// Token: 0x0601C216 RID: 115222 RVA: 0x00864C7F File Offset: 0x00862E7F
	public static void CreateStaticDefaultValue()
	{
		TdUtils._levelPrefabBpPathConfig = new Dictionary<ELevelPrefabBpType, string>
		{
			{
				ELevelPrefabBpType.Item,
				"/Game/Aki/Character/Item/BP_BaseItem.BP_BaseItem_C"
			},
			{
				ELevelPrefabBpType.InteractedBox,
				"/Game/Aki/GamePlay/InteractiveObject/BP_InteractedBox.BP_InteractedBox_C"
			},
			{
				ELevelPrefabBpType.PhysicsItem,
				"/Game/Aki/GamePlay/InteractiveObject/BP_PhysicsItem.BP_PhysicsItem_C"
			}
		};
	}

	// Token: 0x0601C217 RID: 115223 RVA: 0x00864CAF File Offset: 0x00862EAF
	public static void ResetStaticDefaultValue()
	{
		TdUtils._levelPrefabBpPathConfig = null;
	}

	// Token: 0x0601C218 RID: 115224 RVA: 0x00864CB7 File Offset: 0x00862EB7
	public static bool IgnoreUnderScore(string key)
	{
		return key.StartsWith('_');
	}

	// Token: 0x0601C219 RID: 115225 RVA: 0x00864CC1 File Offset: 0x00862EC1
	public static bool IsGuid(string key)
	{
		return key == "Guid" || key == "ActionGuid";
	}

	// Token: 0x0601C21A RID: 115226 RVA: 0x00864CDD File Offset: 0x00862EDD
	public static bool isTemplateOnly(string key)
	{
		return key == "EdIsLocked";
	}

	// Token: 0x0601C21B RID: 115227 RVA: 0x00864CEA File Offset: 0x00862EEA
	public static bool EntityDataSerializeIgnoreFunc(string key)
	{
		return TdUtils.IgnoreUnderScore(key) || TdUtils.IsGuid(key) || TdUtils.isTemplateOnly(key);
	}

	// Token: 0x0601C21C RID: 115228 RVA: 0x00864D04 File Offset: 0x00862F04
	public static void Merge(JsonElement jElement1, JsonElement jElement2, ArrayBufferWriter<byte> outputBuffer)
	{
		outputBuffer.Clear();
		using (Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(outputBuffer, default(JsonWriterOptions)))
		{
			if (jElement1.ValueKind != JsonValueKind.Object)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(94, 1);
				defaultInterpolatedStringHandler.AppendLiteral("The original JSON document to merge new content into must be a container type. Instead it is ");
				defaultInterpolatedStringHandler.AppendFormatted<JsonValueKind>(jElement1.ValueKind);
				defaultInterpolatedStringHandler.AppendLiteral(".");
				throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (jElement1.ValueKind != jElement2.ValueKind)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 2);
				defaultInterpolatedStringHandler.AppendLiteral("The json ValueKind is different ");
				defaultInterpolatedStringHandler.AppendFormatted<JsonValueKind>(jElement1.ValueKind);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted<JsonValueKind>(jElement2.ValueKind);
				throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (jElement1.ValueKind == JsonValueKind.Object)
			{
				TdUtils.MergeObjects(utf8JsonWriter, jElement1, jElement2);
			}
		}
	}

	// Token: 0x0601C21D RID: 115229 RVA: 0x00864DF8 File Offset: 0x00862FF8
	private static void MergeObjects(Utf8JsonWriter jsonWriter, JsonElement jObject1, JsonElement jObject2)
	{
		jsonWriter.WriteStartObject();
		foreach (JsonProperty jsonProperty in jObject1.EnumerateObject())
		{
			string name = jsonProperty.Name;
			JsonElement jObject3;
			if (jObject2.TryGetProperty(name, out jObject3))
			{
				JsonValueKind valueKind = jObject3.ValueKind;
				if (valueKind != JsonValueKind.Null)
				{
					jsonWriter.WritePropertyName(name);
					JsonElement value = jsonProperty.Value;
					JsonValueKind valueKind2 = value.ValueKind;
					if (valueKind == JsonValueKind.Object && valueKind2 == JsonValueKind.Object)
					{
						TdUtils.MergeObjects(jsonWriter, value, jObject3);
					}
					else
					{
						jObject3.WriteTo(jsonWriter);
					}
				}
			}
			else
			{
				jsonProperty.WriteTo(jsonWriter);
			}
		}
		foreach (JsonProperty jsonProperty2 in jObject2.EnumerateObject())
		{
			JsonElement value2;
			if (!jObject1.TryGetProperty(jsonProperty2.Name, out value2))
			{
				value2 = jsonProperty2.Value;
				if (value2.ValueKind != JsonValueKind.Null)
				{
					jsonProperty2.WriteTo(jsonWriter);
				}
			}
		}
		jsonWriter.WriteEndObject();
	}

	// Token: 0x0400E31A RID: 58138
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<ELevelPrefabBpType, string> _levelPrefabBpPathConfig;
}
