using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;
using UnrealEngine;

// Token: 0x02000E60 RID: 3680
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MultiTextCsvModule : Singleton<MultiTextCsvModule>
{
	// Token: 0x06005895 RID: 22677 RVA: 0x001071E2 File Offset: 0x001053E2
	private string ReplaceTermHyperlink(string text)
	{
		return MultiTextCsvModule.TermHyperlinkRegex.Replace(text, delegate(Match m)
		{
			string value = m.Groups["Term"].Value;
			TermConfig? config = ConfigTermConfigByKey.GetConfig(value, true);
			if (config == null)
			{
				return m.Value;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<te href=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(config.Value.Id);
			defaultInterpolatedStringHandler.AppendLiteral(">");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("</te>");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		});
	}

	// Token: 0x06005896 RID: 22678 RVA: 0x00107210 File Offset: 0x00105410
	private void AnalyzeCsvContent(string csvContent)
	{
		List<List<string>> list = StringUtils.ParseCsvContent(csvContent);
		List<string> list2 = list[1];
		for (int i = 8; i < list.Count; i++)
		{
			List<string> list3 = list[i];
			if (list3.Count >= 2)
			{
				string text = list3[1];
				if (!StringUtils.IsBlank(text))
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					for (int j = 0; j < list3.Count; j++)
					{
						string text2 = list3[j];
						if (j > 1)
						{
							string text3 = this.ReplaceTermHyperlink(text2.Replace("\\n", "\n"));
							dictionary[list2[j]] = (text3 ?? "test/NoLocalTextNoLocalTextNoLocalText");
						}
					}
					this.MultiTextMap[text] = dictionary;
				}
			}
		}
	}

	// Token: 0x06005897 RID: 22679 RVA: 0x001072D4 File Offset: 0x001054D4
	private void AnalyzeCsvContentWithParam(string csvContent, int csvLangIndex, int csvStartIndex, int csvStartIdIndex)
	{
		List<List<string>> list = StringUtils.ParseCsvContent(csvContent);
		List<string> list2 = list[csvLangIndex];
		for (int i = csvStartIndex; i < list.Count; i++)
		{
			List<string> list3 = list[i];
			if (list3.Count >= 2)
			{
				string text = list3[csvStartIdIndex];
				if (!StringUtils.IsBlank(text))
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					for (int j = 0; j < list3.Count; j++)
					{
						string text2 = list3[j];
						if (j > csvStartIdIndex)
						{
							string text3 = this.ReplaceTermHyperlink(text2.Replace("\\n", "\n"));
							dictionary[list2[j]] = (text3 ?? "test/NoLocalTextNoLocalTextNoLocalText");
						}
					}
					this.MultiTextMap[text] = dictionary;
				}
			}
		}
	}

	// Token: 0x06005898 RID: 22680 RVA: 0x0010739C File Offset: 0x0010559C
	public void RegisterTextLocalConfig(string csvPath, bool isReload = false)
	{
		if (!isReload && this.CacheCsvNameSet.Contains(csvPath))
		{
			return;
		}
		this.CacheCsvNameSet.Add(csvPath);
		string csvContent = "";
		UKuroStaticLibrary.LoadFileToString(ref csvContent, csvPath);
		this.AnalyzeCsvContent(csvContent);
	}

	// Token: 0x06005899 RID: 22681 RVA: 0x001073E0 File Offset: 0x001055E0
	public void RegisterTextLocalConfigWithParam(string csvPath, bool isReload = false, int csvLangIndex = 1, int csvStartIndex = 8, int csvStartIdIndex = 2)
	{
		if (!isReload && this.CacheCsvNameSet.Contains(csvPath))
		{
			return;
		}
		this.CacheCsvNameSet.Add(csvPath);
		string csvContent = "";
		UKuroStaticLibrary.LoadFileToString(ref csvContent, csvPath);
		this.AnalyzeCsvContentWithParam(csvContent, csvLangIndex, csvStartIndex, csvStartIdIndex);
	}

	// Token: 0x0600589A RID: 22682 RVA: 0x00107428 File Offset: 0x00105628
	public string GetLocalText(string stringKey)
	{
		string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		Dictionary<string, string> dictionary;
		string result;
		if (this.MultiTextMap.TryGetValue(stringKey, out dictionary) && dictionary.Count > 0 && dictionary.TryGetValue(packageLanguage, out result))
		{
			return result;
		}
		return stringKey;
	}

	// Token: 0x0400292C RID: 10540
	private readonly HashSet<string> CacheCsvNameSet = new HashSet<string>();

	// Token: 0x0400292D RID: 10541
	private readonly Dictionary<string, Dictionary<string, string>> MultiTextMap = new Dictionary<string, Dictionary<string, string>>();

	// Token: 0x0400292E RID: 10542
	[StaticVariableRuleIgnore]
	private static readonly Regex TermHyperlinkRegex = new Regex("<a href=(?<Term>[^>]+)></a>", RegexOptions.None);
}
