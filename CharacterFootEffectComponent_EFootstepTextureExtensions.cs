using System;

// Token: 0x02003500 RID: 13568
public static class CharacterFootEffectComponent_EFootstepTextureExtensions
{
	// Token: 0x0601CA90 RID: 117392 RVA: 0x0089A02C File Offset: 0x0089822C
	public static string ToEnumString(this CharacterFootEffectComponent.EFootstepTexture value)
	{
		string result;
		switch (value)
		{
		case CharacterFootEffectComponent.EFootstepTexture.DirtSurface:
			result = "DirtSurface";
			break;
		case CharacterFootEffectComponent.EFootstepTexture.ConcreteSurface:
			result = "ConcreteSurface";
			break;
		case CharacterFootEffectComponent.EFootstepTexture.GrassSurface:
			result = "GrassSurface";
			break;
		case CharacterFootEffectComponent.EFootstepTexture.MetalSheetSurface:
			result = "MetalSheetSurface";
			break;
		case CharacterFootEffectComponent.EFootstepTexture.MetalHardSurface:
			result = "MetalHardSurface";
			break;
		case CharacterFootEffectComponent.EFootstepTexture.WoodFloorSurface:
			result = "WoodFloorSurface";
			break;
		case CharacterFootEffectComponent.EFootstepTexture.WaterSurface:
			result = "WaterSurface";
			break;
		case CharacterFootEffectComponent.EFootstepTexture.FabricSurface:
			result = "FabricSurface";
			break;
		case CharacterFootEffectComponent.EFootstepTexture.SandSurface:
			result = "SandSurface";
			break;
		case CharacterFootEffectComponent.EFootstepTexture.IceSurface:
			result = "IceSurface";
			break;
		case CharacterFootEffectComponent.EFootstepTexture.SnowSurface:
			result = "SnowSurface";
			break;
		case CharacterFootEffectComponent.EFootstepTexture.VoicelessSurface:
			result = "VoicelessSurface";
			break;
		default:
			result = value.ToString();
			break;
		}
		return result;
	}

	// Token: 0x0601CA91 RID: 117393 RVA: 0x0089A0E0 File Offset: 0x008982E0
	public static CharacterFootEffectComponent.EFootstepTexture FromString(string name)
	{
		CharacterFootEffectComponent.EFootstepTexture result;
		if (!CharacterFootEffectComponent_EFootstepTextureExtensions.TryFromString(name, out result))
		{
			throw new InvalidCastException("从字符串转成枚举 CharacterFootEffectComponent.EFootstepTexture 失败, 字符串: " + name);
		}
		return result;
	}

	// Token: 0x0601CA92 RID: 117394 RVA: 0x0089A10C File Offset: 0x0089830C
	public static bool TryFromString(string name, out CharacterFootEffectComponent.EFootstepTexture value)
	{
		if (string.IsNullOrEmpty(name))
		{
			value = CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
			return false;
		}
		if (name != null)
		{
			switch (name.Length)
			{
			case 10:
				if (name == "IceSurface")
				{
					value = CharacterFootEffectComponent.EFootstepTexture.IceSurface;
					return true;
				}
				break;
			case 11:
			{
				char c = name[1];
				if (c != 'a')
				{
					if (c != 'i')
					{
						if (c == 'n')
						{
							if (name == "SnowSurface")
							{
								value = CharacterFootEffectComponent.EFootstepTexture.SnowSurface;
								return true;
							}
						}
					}
					else if (name == "DirtSurface")
					{
						value = CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
						return true;
					}
				}
				else if (name == "SandSurface")
				{
					value = CharacterFootEffectComponent.EFootstepTexture.SandSurface;
					return true;
				}
				break;
			}
			case 12:
			{
				char c = name[0];
				if (c != 'G')
				{
					if (c == 'W')
					{
						if (name == "WaterSurface")
						{
							value = CharacterFootEffectComponent.EFootstepTexture.WaterSurface;
							return true;
						}
					}
				}
				else if (name == "GrassSurface")
				{
					value = CharacterFootEffectComponent.EFootstepTexture.GrassSurface;
					return true;
				}
				break;
			}
			case 13:
				if (name == "FabricSurface")
				{
					value = CharacterFootEffectComponent.EFootstepTexture.FabricSurface;
					return true;
				}
				break;
			case 15:
				if (name == "ConcreteSurface")
				{
					value = CharacterFootEffectComponent.EFootstepTexture.ConcreteSurface;
					return true;
				}
				break;
			case 16:
			{
				char c = name[0];
				if (c != 'M')
				{
					if (c != 'V')
					{
						if (c == 'W')
						{
							if (name == "WoodFloorSurface")
							{
								value = CharacterFootEffectComponent.EFootstepTexture.WoodFloorSurface;
								return true;
							}
						}
					}
					else if (name == "VoicelessSurface")
					{
						value = CharacterFootEffectComponent.EFootstepTexture.VoicelessSurface;
						return true;
					}
				}
				else if (name == "MetalHardSurface")
				{
					value = CharacterFootEffectComponent.EFootstepTexture.MetalHardSurface;
					return true;
				}
				break;
			}
			case 17:
				if (name == "MetalSheetSurface")
				{
					value = CharacterFootEffectComponent.EFootstepTexture.MetalSheetSurface;
					return true;
				}
				break;
			}
		}
		value = CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
		return false;
	}

	// Token: 0x0601CA93 RID: 117395 RVA: 0x0089A2E0 File Offset: 0x008984E0
	public static string[] GetStringValues()
	{
		return new string[]
		{
			"DirtSurface",
			"ConcreteSurface",
			"GrassSurface",
			"MetalSheetSurface",
			"MetalHardSurface",
			"WoodFloorSurface",
			"WaterSurface",
			"FabricSurface",
			"SandSurface",
			"IceSurface",
			"SnowSurface",
			"VoicelessSurface"
		};
	}

	// Token: 0x0601CA94 RID: 117396 RVA: 0x0089A357 File Offset: 0x00898557
	public static CharacterFootEffectComponent.EFootstepTexture[] GetValues()
	{
		return new CharacterFootEffectComponent.EFootstepTexture[]
		{
			CharacterFootEffectComponent.EFootstepTexture.DirtSurface,
			CharacterFootEffectComponent.EFootstepTexture.ConcreteSurface,
			CharacterFootEffectComponent.EFootstepTexture.GrassSurface,
			CharacterFootEffectComponent.EFootstepTexture.MetalSheetSurface,
			CharacterFootEffectComponent.EFootstepTexture.MetalHardSurface,
			CharacterFootEffectComponent.EFootstepTexture.WoodFloorSurface,
			CharacterFootEffectComponent.EFootstepTexture.WaterSurface,
			CharacterFootEffectComponent.EFootstepTexture.FabricSurface,
			CharacterFootEffectComponent.EFootstepTexture.SandSurface,
			CharacterFootEffectComponent.EFootstepTexture.IceSurface,
			CharacterFootEffectComponent.EFootstepTexture.SnowSurface,
			CharacterFootEffectComponent.EFootstepTexture.VoicelessSurface
		};
	}

	// Token: 0x0601CA95 RID: 117397 RVA: 0x0089A36C File Offset: 0x0089856C
	public static string[] GetNames()
	{
		return new string[]
		{
			"DirtSurface",
			"ConcreteSurface",
			"GrassSurface",
			"MetalSheetSurface",
			"MetalHardSurface",
			"WoodFloorSurface",
			"WaterSurface",
			"FabricSurface",
			"SandSurface",
			"IceSurface",
			"SnowSurface",
			"VoicelessSurface"
		};
	}
}
