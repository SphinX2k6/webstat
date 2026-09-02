using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace CSharpScript.Utils
{
	// Token: 0x020046B8 RID: 18104
	public class FormulaParamsCacheManager : IStaticVariableResetter
	{
		// Token: 0x0602F194 RID: 192916 RVA: 0x00B2800C File Offset: 0x00B2620C
		static FormulaParamsCacheManager()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(FormulaParamsCacheManager.CreateStaticDefaultValue), new Action(FormulaParamsCacheManager.ResetStaticDefaultValue));
		}

		// Token: 0x0602F195 RID: 192917 RVA: 0x00B2802B File Offset: 0x00B2622B
		public static void CreateStaticDefaultValue()
		{
			FormulaParamsCacheManager.Cache = new Dictionary<string, FormulaParamsCacheManager.CachedParamsEntry>();
		}

		// Token: 0x0602F196 RID: 192918 RVA: 0x00B28037 File Offset: 0x00B26237
		public static void ResetStaticDefaultValue()
		{
			FormulaParamsCacheManager.Cache = null;
		}

		// Token: 0x0602F197 RID: 192919 RVA: 0x00B28040 File Offset: 0x00B26240
		[NullableContext(1)]
		public static Dictionary<string, TFormulaValue> Acquire(string paramsRaw)
		{
			FormulaParamsCacheManager.CachedParamsEntry cachedParamsEntry;
			if (FormulaParamsCacheManager.Cache.TryGetValue(paramsRaw, out cachedParamsEntry))
			{
				cachedParamsEntry.RefCount++;
				return cachedParamsEntry.Params;
			}
			Dictionary<string, TFormulaValue> result;
			using (JsonDocument jsonDocument = JsonDocument.Parse(paramsRaw, default(JsonDocumentOptions)))
			{
				if (jsonDocument.RootElement.ValueKind != JsonValueKind.Object)
				{
					throw new Exception("Formula default params must be a JSON object");
				}
				Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
				foreach (JsonProperty jsonProperty in jsonDocument.RootElement.EnumerateObject())
				{
					dictionary[jsonProperty.Name] = Formula.FromJsonElement(jsonProperty.Value);
				}
				FormulaParamsCacheManager.Cache[paramsRaw] = new FormulaParamsCacheManager.CachedParamsEntry
				{
					Params = dictionary,
					RefCount = 1
				};
				result = dictionary;
			}
			return result;
		}

		// Token: 0x0602F198 RID: 192920 RVA: 0x00B28148 File Offset: 0x00B26348
		[NullableContext(1)]
		public static void Release(string paramsRaw)
		{
			FormulaParamsCacheManager.CachedParamsEntry cachedParamsEntry;
			if (!FormulaParamsCacheManager.Cache.TryGetValue(paramsRaw, out cachedParamsEntry))
			{
				return;
			}
			cachedParamsEntry.RefCount--;
			if (cachedParamsEntry.RefCount <= 0)
			{
				FormulaParamsCacheManager.Cache.Remove(paramsRaw);
			}
		}

		// Token: 0x0401AD30 RID: 109872
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private static Dictionary<string, FormulaParamsCacheManager.CachedParamsEntry> Cache;

		// Token: 0x0200A846 RID: 43078
		private class CachedParamsEntry
		{
			// Token: 0x040343E0 RID: 213984
			[Nullable(1)]
			public Dictionary<string, TFormulaValue> Params = new Dictionary<string, TFormulaValue>();

			// Token: 0x040343E1 RID: 213985
			public int RefCount;
		}
	}
}
