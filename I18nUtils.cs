using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;
using CSharpScript.Game.Module.Plot;
using UnrealEngine;

// Token: 0x0200345D RID: 13405
[NullableContext(1)]
[Nullable(0)]
public class I18nUtils
{
	// Token: 0x0601C1F4 RID: 115188 RVA: 0x0086419C File Offset: 0x0086239C
	[return: Nullable(2)]
	public static string GetI18nPathAtCurrentLanguage(string key)
	{
		I18nResources? config = ConfigI18nResourcesById.GetConfig(key, true);
		if (config == null)
		{
			return null;
		}
		I18nTextures? config2 = ConfigI18nTexturesById.GetConfig(config.Value.TextureRef, true);
		if (config2 == null)
		{
			return null;
		}
		string text = null;
		string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		if (packageLanguage == "zh-Hans")
		{
			text = config2.Value.ZhHans;
		}
		else if (packageLanguage == "zh-Hant")
		{
			text = config2.Value.ZhHant;
		}
		else if (packageLanguage == "en")
		{
			text = config2.Value.En;
		}
		else if (packageLanguage == "ja")
		{
			text = config2.Value.Ja;
		}
		else if (packageLanguage == "ko")
		{
			text = config2.Value.Ko;
		}
		else if (packageLanguage == "ru")
		{
			text = config2.Value.Ru;
		}
		else if (packageLanguage == "de")
		{
			text = config2.Value.De;
		}
		else if (packageLanguage == "es")
		{
			text = config2.Value.Es;
		}
		else if (packageLanguage == "pt")
		{
			text = config2.Value.Pt;
		}
		else if (packageLanguage == "id")
		{
			text = config2.Value.Idn;
		}
		else if (packageLanguage == "fr")
		{
			text = config2.Value.Fr;
		}
		else if (packageLanguage == "vi")
		{
			text = config2.Value.Vi;
		}
		else if (packageLanguage == "th")
		{
			text = config2.Value.Th;
		}
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		if (!StringUtils.IsEmpty(config2.Value.HandleType))
		{
			if (config2.Value.HandleType == "main_player")
			{
				return I18nUtils.ParseGenderContent(text, ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male);
			}
			if (config2.Value.HandleType == "main_player_new")
			{
				return I18nUtils.ParseGenderContentNew(text, ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male);
			}
		}
		return text;
	}

	// Token: 0x0601C1F5 RID: 115189 RVA: 0x00864424 File Offset: 0x00862624
	[return: Nullable(2)]
	public static string GetI18nPlotAudioMediaName(string key)
	{
		I18nResources? config = ConfigI18nResourcesById.GetConfig(key, true);
		if (config == null)
		{
			return null;
		}
		PlotAudio? config2 = ConfigPlotAudioById.GetConfig(config.Value.PlotAudioRef, true);
		if (config2 == null)
		{
			return null;
		}
		return ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(config2.Value);
	}

	// Token: 0x0601C1F6 RID: 115190 RVA: 0x00864478 File Offset: 0x00862678
	private static string ParseGenderContent(string content, bool isMale)
	{
		if (StringUtils.IsEmpty(content))
		{
			return "";
		}
		return new Regex("\\{Male:(.*?),Female:(.*?)\\}").Replace(content, delegate(Match match)
		{
			string value = match.Groups[1].Value;
			string value2 = match.Groups[2].Value;
			if (!isMale)
			{
				return value2;
			}
			return value;
		});
	}

	// Token: 0x0601C1F7 RID: 115191 RVA: 0x008644BC File Offset: 0x008626BC
	private static string ParseGenderContentNew(string content, bool isMale)
	{
		if (StringUtils.IsEmpty(content))
		{
			return "";
		}
		Match match = new Regex("\\{Male:(?<quote1>['\"])(?<maleText>.*?)\\1,Female:(?<quote2>['\"])(?<femaleText>.*?)\\3\\}").Match(content);
		return (isMale ? match.Groups["maleText"].Value : match.Groups["femaleText"].Value) ?? "";
	}

	// Token: 0x0601C1F8 RID: 115192 RVA: 0x00864520 File Offset: 0x00862720
	public static void SetRenderComponentTextByTextId(UTextRenderComponent textRenderComponent, string textId)
	{
		if (textRenderComponent != null && textRenderComponent.IsValid())
		{
			textRenderComponent.SetText(ConfigMultiTextLang.GetLocalTextNew(textId, null) ?? "");
		}
	}

	// Token: 0x0601C1F9 RID: 115193 RVA: 0x00864544 File Offset: 0x00862744
	public static void SetI18nBillboardComponentSpriteById(UBillboardComponent spriteComponent, string id)
	{
		string i18nPathAtCurrentLanguage = I18nUtils.GetI18nPathAtCurrentLanguage(id);
		if (i18nPathAtCurrentLanguage != null)
		{
			UTexture2D sprite = Singleton<ResourceSystem>.Instance.Load<UTexture2D>(i18nPathAtCurrentLanguage, "Ui.PlotUi");
			spriteComponent.SetSprite(sprite);
		}
	}
}
