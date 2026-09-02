using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;

// Token: 0x020018B2 RID: 6322
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class UiResourceConfig : ConfigBase<UiResourceConfig>
{
	// Token: 0x0600B5B7 RID: 46519 RVA: 0x00305B48 File Offset: 0x00303D48
	public string GetResourcePath(string resourceId)
	{
		UiResource? config = ConfigUiResourceById.GetConfig(resourceId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Resource;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "查找资源配置失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ResourceId", resourceId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return "";
		}
		return this.GetResourcePathNormal(config.Value);
	}

	// Token: 0x0600B5B8 RID: 46520 RVA: 0x00305BA0 File Offset: 0x00303DA0
	public string GetResourcePathNormal(UiResource resource)
	{
		if (Singleton<Info>.Instance.IsInTouch() || string.IsNullOrEmpty(resource.PcPath))
		{
			return resource.Path;
		}
		return resource.PcPath;
	}

	// Token: 0x0600B5B9 RID: 46521 RVA: 0x00305BCB File Offset: 0x00303DCB
	public UiResource? GetResourceConfig(string resourceId)
	{
		return ConfigUiResourceById.GetConfig(resourceId, true);
	}

	// Token: 0x0600B5BA RID: 46522 RVA: 0x00305BD4 File Offset: 0x00303DD4
	public string GetLogoPathByLanguage(string logoName)
	{
		LangOfLogo? config = ConfigLangOfLogoByName.GetConfig(logoName, true);
		if (config == null)
		{
			return "";
		}
		string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		if (packageLanguage == "en")
		{
			return config.Value.EnLogo;
		}
		if (packageLanguage == "zh-Hans")
		{
			return config.Value.ZhHansLogo;
		}
		if (packageLanguage == "ja")
		{
			return config.Value.JpLogo;
		}
		if (packageLanguage == "zh-Hant")
		{
			return config.Value.ZhHantLogo;
		}
		if (!(packageLanguage == "ko"))
		{
			return config.Value.EnLogo;
		}
		return config.Value.KrLogo;
	}

	// Token: 0x0600B5BB RID: 46523 RVA: 0x00305CA8 File Offset: 0x00303EA8
	public string GetThirdPartyLogoTexturePath(ELogoSize size)
	{
		if (!Singleton<Info>.Instance.IsHomeConsolePlatform())
		{
			return "";
		}
		string p0Id;
		if (Singleton<Info>.Instance.IsPs5Platform())
		{
			p0Id = "T_PlatformPs" + size.ToValue();
		}
		else
		{
			p0Id = "T_PlatformXbox" + size.ToValue();
		}
		return ConfigUiResourceById.GetConfig(p0Id, true).Value.Path;
	}

	// Token: 0x0600B5BC RID: 46524 RVA: 0x00305D14 File Offset: 0x00303F14
	public string GetThirdPartyTextColor(EConsoleColorSet set)
	{
		string result = "ffffffff";
		if (!Singleton<Info>.Instance.IsHomeConsolePlatform())
		{
			return result;
		}
		if (set == EConsoleColorSet.Set1)
		{
			if (Singleton<Info>.Instance.IsPs5Platform())
			{
				result = "0092D4FF";
			}
			else
			{
				result = "379337FF";
			}
		}
		else if (Singleton<Info>.Instance.IsPs5Platform())
		{
			result = "0049A8FF";
		}
		else
		{
			result = "107C10ff";
		}
		return result;
	}

	// Token: 0x0600B5BD RID: 46525 RVA: 0x00305D70 File Offset: 0x00303F70
	public string GetThirdPartySearchColor(EThirdPartySearchColorSet set)
	{
		string result;
		if (set == EThirdPartySearchColorSet.Set1)
		{
			if (Singleton<Info>.Instance.IsPs5Platform())
			{
				result = "1E7EC5FF";
			}
			else
			{
				result = "137E12FF";
			}
		}
		else if (Singleton<Info>.Instance.IsPs5Platform())
		{
			result = "1E7EC5FF";
		}
		else
		{
			result = "137E12FF";
		}
		return result;
	}

	// Token: 0x040055A2 RID: 21922
	public bool IsPcPlatform;
}
