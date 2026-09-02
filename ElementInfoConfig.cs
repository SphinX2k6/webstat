using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020018AE RID: 6318
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ElementInfoConfig : ConfigBase<ElementInfoConfig>
{
	// Token: 0x0600B59F RID: 46495 RVA: 0x003050A4 File Offset: 0x003032A4
	public List<ElementInfo> GetConfigList(int[] idList)
	{
		List<ElementInfo> list = new List<ElementInfo>();
		for (int i = 0; i < idList.Length; i++)
		{
			ElementInfo? config = ConfigElementInfoById.GetConfig(idList[i], true);
			if (config != null)
			{
				list.Add(config.Value);
			}
		}
		list.Sort((ElementInfo a, ElementInfo b) => a.Id.CompareTo(b.Id));
		return list;
	}

	// Token: 0x0600B5A0 RID: 46496 RVA: 0x0030510D File Offset: 0x0030330D
	public ElementInfo? GetElementInfo(int elementId)
	{
		return ConfigElementInfoById.GetConfig(elementId, true);
	}

	// Token: 0x0600B5A1 RID: 46497 RVA: 0x00305118 File Offset: 0x00303318
	[NullableContext(2)]
	public string GetElementInfoValueByParam(int elementId, string param, [Nullable(1)] string tag)
	{
		ElementInfo? elementInfo = this.GetElementInfo(elementId);
		if (elementInfo == null || param == null)
		{
			return null;
		}
		if (param != null)
		{
			switch (param.Length)
			{
			case 4:
			{
				char c = param[0];
				if (c != 'I')
				{
					if (c == 'N')
					{
						if (param == "Name")
						{
							return elementInfo.Value.Name;
						}
					}
				}
				else if (param == "Icon")
				{
					return elementInfo.Value.Icon;
				}
				break;
			}
			case 5:
				switch (param[4])
				{
				case '2':
					if (param == "Icon2")
					{
						return elementInfo.Value.Icon2;
					}
					break;
				case '3':
					if (param == "Icon3")
					{
						return elementInfo.Value.Icon3;
					}
					break;
				case '4':
					if (param == "Icon4")
					{
						return elementInfo.Value.Icon4;
					}
					break;
				case '5':
					if (param == "Icon5")
					{
						return elementInfo.Value.Icon5;
					}
					break;
				case '6':
					if (param == "Icon6")
					{
						return elementInfo.Value.Icon6;
					}
					break;
				case '7':
					if (param == "Icon7")
					{
						return elementInfo.Value.Icon7;
					}
					break;
				}
				break;
			case 6:
				if (param == "Effect")
				{
					return elementInfo.Value.Effect;
				}
				break;
			case 8:
				if (param == "Describe")
				{
					return elementInfo.Value.Describe;
				}
				break;
			case 9:
				if (param == "Icon4Pure")
				{
					return elementInfo.Value.Icon4Pure;
				}
				break;
			case 10:
				if (param == "AudioEvent")
				{
					return elementInfo.Value.AudioEvent;
				}
				break;
			case 11:
				if (param == "SpriteIcon1")
				{
					return elementInfo.Value.SpriteIcon1;
				}
				break;
			case 12:
				if (param == "ElementColor")
				{
					return elementInfo.Value.ElementColor;
				}
				break;
			case 15:
				if (param == "GachaSpritePath")
				{
					return elementInfo.Value.GachaSpritePath;
				}
				break;
			case 16:
				if (param == "SkillEffectColor")
				{
					return elementInfo.Value.SkillEffectColor;
				}
				break;
			case 17:
				if (param == "EffectTexturePath")
				{
					return elementInfo.Value.EffectTexturePath;
				}
				break;
			case 18:
			{
				char c = param[9];
				if (c <= 'L')
				{
					if (c != 'I')
					{
						if (c == 'L')
						{
							if (param == "SkillTreeLineColor")
							{
								return elementInfo.Value.SkillTreeLineColor;
							}
						}
					}
					else if (param == "SkillTreeIconColor")
					{
						return elementInfo.Value.SkillTreeIconColor;
					}
				}
				else if (c != 'f')
				{
					if (c == 'k')
					{
						if (param == "UltimateSkillColor")
						{
							return elementInfo.Value.UltimateSkillColor;
						}
					}
				}
				else if (param == "ElementEffectColor")
				{
					return elementInfo.Value.ElementEffectColor;
				}
				break;
			}
			case 20:
			{
				char c = param[0];
				if (c != 'E')
				{
					if (c == 'S')
					{
						if (param == "SkillTreeEffectColor")
						{
							return elementInfo.Value.SkillTreeEffectColor;
						}
					}
				}
				else if (param == "ElementChangeTexture")
				{
					return elementInfo.Value.ElementChangeTexture;
				}
				break;
			}
			case 21:
			{
				char c = param[0];
				if (c != 'E')
				{
					if (c == 'S')
					{
						if (param == "SkillButtonEffectPath")
						{
							return elementInfo.Value.SkillButtonEffectPath;
						}
					}
				}
				else if (param == "ElementBallEffectPath")
				{
					return elementInfo.Value.ElementBallEffectPath;
				}
				break;
			}
			case 24:
				if (param == "GachaElementBgSpritePath")
				{
					return elementInfo.Value.GachaElementBgSpritePath;
				}
				break;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiImageSetting;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "配置的表格字段查询到的资源路径不是字符串类型";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("配置的表格字段", tag);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600B5A2 RID: 46498 RVA: 0x0030566D File Offset: 0x0030386D
	public string GetElementInfoLocalName(string name)
	{
		return ConfigMultiTextLang.GetLocalTextNew(name, null);
	}

	// Token: 0x0600B5A3 RID: 46499 RVA: 0x00305678 File Offset: 0x00303878
	public string GetElementInfoNameByElementId(int elementId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.GetElementInfo(elementId).Value.Name, null);
	}
}
