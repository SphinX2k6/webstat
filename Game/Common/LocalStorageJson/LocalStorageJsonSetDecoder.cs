using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Common.LocalStorageJson
{
	// Token: 0x0200706C RID: 28780
	[NullableContext(1)]
	[Nullable(0)]
	internal static class LocalStorageJsonSetDecoder
	{
		// Token: 0x06045ADB RID: 285403 RVA: 0x01236500 File Offset: 0x01234700
		public static bool TryDecode<[Nullable(2)] T>(JsonElement contentArray, Type targetType, JsonSerializerOptions elementOptions, [Nullable(2)] out T result)
		{
			if (targetType == typeof(HashSet<EMapNoteId>))
			{
				result = (T)((object)LocalStorageJsonSetDecoder.DecodeHashSet<EMapNoteId>(contentArray, elementOptions));
				return true;
			}
			if (targetType == typeof(HashSet<int>))
			{
				result = (T)((object)LocalStorageJsonSetDecoder.DecodeHashSet<int>(contentArray, elementOptions));
				return true;
			}
			result = default(T);
			return false;
		}

		// Token: 0x06045ADC RID: 285404 RVA: 0x01236564 File Offset: 0x01234764
		private static HashSet<TElement> DecodeHashSet<[Nullable(2)] TElement>(JsonElement contentArray, JsonSerializerOptions elementOptions)
		{
			HashSet<TElement> hashSet = new HashSet<TElement>();
			foreach (JsonElement element in contentArray.EnumerateArray())
			{
				TElement telement = element.Deserialize(elementOptions);
				if (telement != null)
				{
					hashSet.Add(telement);
				}
			}
			return hashSet;
		}
	}
}
