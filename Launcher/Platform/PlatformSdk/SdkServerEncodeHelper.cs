using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using UnrealEngine;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045BE RID: 17854
	[NullableContext(1)]
	[Nullable(0)]
	public static class SdkServerEncodeHelper
	{
		// Token: 0x0602EC82 RID: 191618 RVA: 0x00B12F00 File Offset: 0x00B11100
		public static string MarkData(params object[] keyValPairs)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			for (int i = 0; i < keyValPairs.Length; i += 2)
			{
				if (i + 1 < keyValPairs.Length && keyValPairs[i] != null && keyValPairs[i + 1] != null)
				{
					dictionary[keyValPairs[i].ToString()] = keyValPairs[i + 1];
				}
			}
			return SdkServerEncodeHelper.MarkDataFlag(dictionary);
		}

		// Token: 0x0602EC83 RID: 191619 RVA: 0x00B12F50 File Offset: 0x00B11150
		private static string MarkDataFlag(Dictionary<string, object> paramsMap)
		{
			string text = UKuroStaticLibrary.Base64EncodeWithConvertToUTF8(JsonSerializer.Serialize<Dictionary<string, object>>(paramsMap, null));
			string result;
			if (text.Length > 42)
			{
				char[] array = text.ToCharArray();
				SdkServerEncodeHelper.ChangeArray(array, new int[]
				{
					1,
					33,
					10,
					42,
					18,
					50,
					19,
					51
				});
				result = new string(array);
			}
			else
			{
				result = text;
			}
			return result;
		}

		// Token: 0x0602EC84 RID: 191620 RVA: 0x00B12FA0 File Offset: 0x00B111A0
		private static void ChangeArray(char[] chars, params int[] index)
		{
			for (int i = 0; i < index.Length; i += 2)
			{
				int num = index[i];
				int num2 = index[i + 1];
				if (num >= 0 && num < chars.Length && num2 >= 0 && num2 < chars.Length)
				{
					char c = chars[num];
					chars[num] = chars[num2];
					chars[num2] = c;
				}
			}
		}

		// Token: 0x0602EC85 RID: 191621 RVA: 0x00B12FE8 File Offset: 0x00B111E8
		public static string MarkSign(string appKey, params string[] keyVal)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			for (int i = 0; i < keyVal.Length; i += 2)
			{
				if (i + 1 < keyVal.Length && keyVal[i] != null && keyVal[i + 1] != null)
				{
					dictionary[keyVal[i]] = keyVal[i + 1];
				}
			}
			return SdkServerEncodeHelper.MarkSignFlag(appKey, dictionary);
		}

		// Token: 0x0602EC86 RID: 191622 RVA: 0x00B13034 File Offset: 0x00B11234
		private static string MarkSignFlag(string appKey, Dictionary<string, string> paramsMap)
		{
			List<string> list = new List<string>();
			foreach (string text in paramsMap.Keys)
			{
				if (text != "sign")
				{
					list.Add(text);
				}
			}
			list.Sort();
			string text2 = "";
			for (int i = 0; i < list.Count; i++)
			{
				string text3 = list[i];
				string text4 = paramsMap[text3];
				if (text3.Length > 0)
				{
					text2 = string.Concat(new string[]
					{
						text2,
						text3,
						"=",
						text4,
						"&"
					});
				}
			}
			text2 += appKey;
			return UKuroStaticLibrary.Md5HashAnsiString(text2);
		}
	}
}
