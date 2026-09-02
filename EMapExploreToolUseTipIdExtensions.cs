using System;

// Token: 0x020034FC RID: 13564
public static class EMapExploreToolUseTipIdExtensions
{
	// Token: 0x0601CA7E RID: 117374 RVA: 0x008999A8 File Offset: 0x00897BA8
	public static string ToEnumString(this EMapExploreToolUseTipId value)
	{
		string result;
		if (value != EMapExploreToolUseTipId.MapExploreToolDeploySuccess)
		{
			if (value != EMapExploreToolUseTipId.SoundBoxUseReachLimit)
			{
				result = value.ToString();
			}
			else
			{
				result = "ShengXiaDetectTip";
			}
		}
		else
		{
			result = "ExploreDeploySuccess";
		}
		return result;
	}

	// Token: 0x0601CA7F RID: 117375 RVA: 0x008999E0 File Offset: 0x00897BE0
	public static EMapExploreToolUseTipId FromString(string name)
	{
		EMapExploreToolUseTipId result;
		if (!EMapExploreToolUseTipIdExtensions.TryFromString(name, out result))
		{
			throw new InvalidCastException("从字符串转成枚举 EMapExploreToolUseTipId 失败, 字符串: " + name);
		}
		return result;
	}

	// Token: 0x0601CA80 RID: 117376 RVA: 0x00899A09 File Offset: 0x00897C09
	public static bool TryFromString(string name, out EMapExploreToolUseTipId value)
	{
		if (string.IsNullOrEmpty(name))
		{
			value = EMapExploreToolUseTipId.MapExploreToolDeploySuccess;
			return false;
		}
		if (name == "ExploreDeploySuccess")
		{
			value = EMapExploreToolUseTipId.MapExploreToolDeploySuccess;
			return true;
		}
		if (!(name == "ShengXiaDetectTip"))
		{
			value = EMapExploreToolUseTipId.MapExploreToolDeploySuccess;
			return false;
		}
		value = EMapExploreToolUseTipId.SoundBoxUseReachLimit;
		return true;
	}

	// Token: 0x0601CA81 RID: 117377 RVA: 0x00899A42 File Offset: 0x00897C42
	public static string[] GetStringValues()
	{
		return new string[]
		{
			"ExploreDeploySuccess",
			"ShengXiaDetectTip"
		};
	}

	// Token: 0x0601CA82 RID: 117378 RVA: 0x00899A5A File Offset: 0x00897C5A
	public static EMapExploreToolUseTipId[] GetValues()
	{
		return new EMapExploreToolUseTipId[]
		{
			EMapExploreToolUseTipId.MapExploreToolDeploySuccess,
			EMapExploreToolUseTipId.SoundBoxUseReachLimit
		};
	}

	// Token: 0x0601CA83 RID: 117379 RVA: 0x00899A66 File Offset: 0x00897C66
	public static string[] GetNames()
	{
		return new string[]
		{
			"MapExploreToolDeploySuccess",
			"SoundBoxUseReachLimit"
		};
	}
}
