using System;

// Token: 0x020034F8 RID: 13560
public static class EBpTypeNameExtensions
{
	// Token: 0x0601CA6C RID: 117356 RVA: 0x00898D9C File Offset: 0x00896F9C
	public static string ToEnumString(this EBpTypeName value)
	{
		string result;
		switch (value)
		{
		case EBpTypeName.DataTableUtil_C:
			result = "DataTableUtil_C";
			break;
		case EBpTypeName.BP_SequenceData_C:
			result = "BP_SequenceData_C";
			break;
		case EBpTypeName.BP_EventManager_C:
			result = "BP_EventManager_C";
			break;
		case EBpTypeName.BP_GlobalGI_C:
			result = "BP_GlobalGI_C";
			break;
		case EBpTypeName.NinjaLive_C:
			result = "NinjaLive_C";
			break;
		case EBpTypeName.SModelConfig:
			result = "SModelConfig";
			break;
		case EBpTypeName.BP_Fx_WayFinding_C:
			result = "BP_Fx_WayFinding_C";
			break;
		case EBpTypeName.BP_CloudFuBen_C:
			result = "BP_CloudFuBen_C";
			break;
		case EBpTypeName.BPL_BulletPreview:
			result = "BPL_BulletPreview_C";
			break;
		case EBpTypeName.BP_KuroDestructibleActor_Stone_C:
			result = "BP_KuroDestructibleActor_Stone_C";
			break;
		case EBpTypeName.BP_KuroTrackTargetWhileRotate_C:
			result = "BP_KuroTrackTargetWhileRotate_C";
			break;
		case EBpTypeName.BP_FollowShooterDeadEyeConfig_C:
			result = "BP_FollowShooterDeadEyeConfig_C";
			break;
		case EBpTypeName.BP_KuroMotorcycleFreezeWaterComponent_C:
			result = "BP_KuroMotorcycleFreezeWaterComponent_C";
			break;
		case EBpTypeName.BP_KuroMasterSeqEvent_C:
			result = "BP_KuroMasterSeqEvent_C";
			break;
		case EBpTypeName.EffectModelPostProcess_C:
			result = "EffectModelPostProcess_C";
			break;
		case EBpTypeName.PD_CharacterControllerData_C:
			result = "PD_CharacterControllerData_C";
			break;
		case EBpTypeName.Bp_Tetris_C:
			result = "Bp_Tetris_C";
			break;
		case EBpTypeName.BP_FindSunSpiritGlobalConfig_C:
			result = "BP_FindSunSpiritGlobalConfig_C";
			break;
		case EBpTypeName.BP_Fever_Bar_C:
			result = "BP_Fever_Bar_C";
			break;
		case EBpTypeName.MediaPlayForModel_Special_C:
			result = "MediaPlayForModel_Special_C";
			break;
		case EBpTypeName.BP_WuWaGo_C:
			result = "BP_WuWaGo_C";
			break;
		case EBpTypeName.BP_WuWaGo_LandBox_C:
			result = "BP_WuWaGo_LandBox_C";
			break;
		case EBpTypeName.BP_WuWaGo_WallBox_C:
			result = "BP_WuWaGo_WallBox_C";
			break;
		case EBpTypeName.BP_DollGrabMachineGlobalConfig_C:
			result = "BP_DollGrabMachineGlobalConfig_C";
			break;
		case EBpTypeName.BP_ZoneFollowCameraController_C:
			result = "BP_ZoneFollowCameraController_C";
			break;
		default:
			result = value.ToString();
			break;
		}
		return result;
	}

	// Token: 0x0601CA6D RID: 117357 RVA: 0x00898F10 File Offset: 0x00897110
	public static EBpTypeName FromString(string name)
	{
		EBpTypeName result;
		if (!EBpTypeNameExtensions.TryFromString(name, out result))
		{
			throw new InvalidCastException("从字符串转成枚举 EBpTypeName 失败, 字符串: " + name);
		}
		return result;
	}

	// Token: 0x0601CA6E RID: 117358 RVA: 0x00898F3C File Offset: 0x0089713C
	public static bool TryFromString(string name, out EBpTypeName value)
	{
		if (string.IsNullOrEmpty(name))
		{
			value = EBpTypeName.DataTableUtil_C;
			return false;
		}
		if (name != null)
		{
			switch (name.Length)
			{
			case 11:
			{
				char c = name[1];
				if (c != 'P')
				{
					if (c != 'i')
					{
						if (c == 'p')
						{
							if (name == "Bp_Tetris_C")
							{
								value = EBpTypeName.Bp_Tetris_C;
								return true;
							}
						}
					}
					else if (name == "NinjaLive_C")
					{
						value = EBpTypeName.NinjaLive_C;
						return true;
					}
				}
				else if (name == "BP_WuWaGo_C")
				{
					value = EBpTypeName.BP_WuWaGo_C;
					return true;
				}
				break;
			}
			case 12:
				if (name == "SModelConfig")
				{
					value = EBpTypeName.SModelConfig;
					return true;
				}
				break;
			case 13:
				if (name == "BP_GlobalGI_C")
				{
					value = EBpTypeName.BP_GlobalGI_C;
					return true;
				}
				break;
			case 14:
				if (name == "BP_Fever_Bar_C")
				{
					value = EBpTypeName.BP_Fever_Bar_C;
					return true;
				}
				break;
			case 15:
			{
				char c = name[0];
				if (c != 'B')
				{
					if (c == 'D')
					{
						if (name == "DataTableUtil_C")
						{
							value = EBpTypeName.DataTableUtil_C;
							return true;
						}
					}
				}
				else if (name == "BP_CloudFuBen_C")
				{
					value = EBpTypeName.BP_CloudFuBen_C;
					return true;
				}
				break;
			}
			case 17:
			{
				char c = name[3];
				if (c != 'E')
				{
					if (c == 'S')
					{
						if (name == "BP_SequenceData_C")
						{
							value = EBpTypeName.BP_SequenceData_C;
							return true;
						}
					}
				}
				else if (name == "BP_EventManager_C")
				{
					value = EBpTypeName.BP_EventManager_C;
					return true;
				}
				break;
			}
			case 18:
				if (name == "BP_Fx_WayFinding_C")
				{
					value = EBpTypeName.BP_Fx_WayFinding_C;
					return true;
				}
				break;
			case 19:
			{
				char c = name[10];
				if (c != 'L')
				{
					if (c != 'P')
					{
						if (c == 'W')
						{
							if (name == "BP_WuWaGo_WallBox_C")
							{
								value = EBpTypeName.BP_WuWaGo_WallBox_C;
								return true;
							}
						}
					}
					else if (name == "BPL_BulletPreview_C")
					{
						value = EBpTypeName.BPL_BulletPreview;
						return true;
					}
				}
				else if (name == "BP_WuWaGo_LandBox_C")
				{
					value = EBpTypeName.BP_WuWaGo_LandBox_C;
					return true;
				}
				break;
			}
			case 23:
				if (name == "BP_KuroMasterSeqEvent_C")
				{
					value = EBpTypeName.BP_KuroMasterSeqEvent_C;
					return true;
				}
				break;
			case 24:
				if (name == "EffectModelPostProcess_C")
				{
					value = EBpTypeName.EffectModelPostProcess_C;
					return true;
				}
				break;
			case 27:
				if (name == "MediaPlayForModel_Special_C")
				{
					value = EBpTypeName.MediaPlayForModel_Special_C;
					return true;
				}
				break;
			case 28:
				if (name == "PD_CharacterControllerData_C")
				{
					value = EBpTypeName.PD_CharacterControllerData_C;
					return true;
				}
				break;
			case 30:
				if (name == "BP_FindSunSpiritGlobalConfig_C")
				{
					value = EBpTypeName.BP_FindSunSpiritGlobalConfig_C;
					return true;
				}
				break;
			case 31:
			{
				char c = name[3];
				if (c != 'F')
				{
					if (c != 'K')
					{
						if (c == 'Z')
						{
							if (name == "BP_ZoneFollowCameraController_C")
							{
								value = EBpTypeName.BP_ZoneFollowCameraController_C;
								return true;
							}
						}
					}
					else if (name == "BP_KuroTrackTargetWhileRotate_C")
					{
						value = EBpTypeName.BP_KuroTrackTargetWhileRotate_C;
						return true;
					}
				}
				else if (name == "BP_FollowShooterDeadEyeConfig_C")
				{
					value = EBpTypeName.BP_FollowShooterDeadEyeConfig_C;
					return true;
				}
				break;
			}
			case 32:
			{
				char c = name[3];
				if (c != 'D')
				{
					if (c == 'K')
					{
						if (name == "BP_KuroDestructibleActor_Stone_C")
						{
							value = EBpTypeName.BP_KuroDestructibleActor_Stone_C;
							return true;
						}
					}
				}
				else if (name == "BP_DollGrabMachineGlobalConfig_C")
				{
					value = EBpTypeName.BP_DollGrabMachineGlobalConfig_C;
					return true;
				}
				break;
			}
			case 39:
				if (name == "BP_KuroMotorcycleFreezeWaterComponent_C")
				{
					value = EBpTypeName.BP_KuroMotorcycleFreezeWaterComponent_C;
					return true;
				}
				break;
			}
		}
		value = EBpTypeName.DataTableUtil_C;
		return false;
	}

	// Token: 0x0601CA6F RID: 117359 RVA: 0x00899344 File Offset: 0x00897544
	public static string[] GetStringValues()
	{
		return new string[]
		{
			"DataTableUtil_C",
			"BP_SequenceData_C",
			"BP_EventManager_C",
			"BP_GlobalGI_C",
			"NinjaLive_C",
			"SModelConfig",
			"BP_Fx_WayFinding_C",
			"BP_CloudFuBen_C",
			"BPL_BulletPreview_C",
			"BP_KuroDestructibleActor_Stone_C",
			"BP_KuroTrackTargetWhileRotate_C",
			"BP_FollowShooterDeadEyeConfig_C",
			"BP_KuroMotorcycleFreezeWaterComponent_C",
			"BP_KuroMasterSeqEvent_C",
			"EffectModelPostProcess_C",
			"PD_CharacterControllerData_C",
			"Bp_Tetris_C",
			"BP_FindSunSpiritGlobalConfig_C",
			"BP_Fever_Bar_C",
			"MediaPlayForModel_Special_C",
			"BP_WuWaGo_C",
			"BP_WuWaGo_LandBox_C",
			"BP_WuWaGo_WallBox_C",
			"BP_DollGrabMachineGlobalConfig_C",
			"BP_ZoneFollowCameraController_C"
		};
	}

	// Token: 0x0601CA70 RID: 117360 RVA: 0x00899430 File Offset: 0x00897630
	public static EBpTypeName[] GetValues()
	{
		return new EBpTypeName[]
		{
			EBpTypeName.DataTableUtil_C,
			EBpTypeName.BP_SequenceData_C,
			EBpTypeName.BP_EventManager_C,
			EBpTypeName.BP_GlobalGI_C,
			EBpTypeName.NinjaLive_C,
			EBpTypeName.SModelConfig,
			EBpTypeName.BP_Fx_WayFinding_C,
			EBpTypeName.BP_CloudFuBen_C,
			EBpTypeName.BPL_BulletPreview,
			EBpTypeName.BP_KuroDestructibleActor_Stone_C,
			EBpTypeName.BP_KuroTrackTargetWhileRotate_C,
			EBpTypeName.BP_FollowShooterDeadEyeConfig_C,
			EBpTypeName.BP_KuroMotorcycleFreezeWaterComponent_C,
			EBpTypeName.BP_KuroMasterSeqEvent_C,
			EBpTypeName.EffectModelPostProcess_C,
			EBpTypeName.PD_CharacterControllerData_C,
			EBpTypeName.Bp_Tetris_C,
			EBpTypeName.BP_FindSunSpiritGlobalConfig_C,
			EBpTypeName.BP_Fever_Bar_C,
			EBpTypeName.MediaPlayForModel_Special_C,
			EBpTypeName.BP_WuWaGo_C,
			EBpTypeName.BP_WuWaGo_LandBox_C,
			EBpTypeName.BP_WuWaGo_WallBox_C,
			EBpTypeName.BP_DollGrabMachineGlobalConfig_C,
			EBpTypeName.BP_ZoneFollowCameraController_C
		};
	}

	// Token: 0x0601CA71 RID: 117361 RVA: 0x00899444 File Offset: 0x00897644
	public static string[] GetNames()
	{
		return new string[]
		{
			"DataTableUtil_C",
			"BP_SequenceData_C",
			"BP_EventManager_C",
			"BP_GlobalGI_C",
			"NinjaLive_C",
			"SModelConfig",
			"BP_Fx_WayFinding_C",
			"BP_CloudFuBen_C",
			"BPL_BulletPreview",
			"BP_KuroDestructibleActor_Stone_C",
			"BP_KuroTrackTargetWhileRotate_C",
			"BP_FollowShooterDeadEyeConfig_C",
			"BP_KuroMotorcycleFreezeWaterComponent_C",
			"BP_KuroMasterSeqEvent_C",
			"EffectModelPostProcess_C",
			"PD_CharacterControllerData_C",
			"Bp_Tetris_C",
			"BP_FindSunSpiritGlobalConfig_C",
			"BP_Fever_Bar_C",
			"MediaPlayForModel_Special_C",
			"BP_WuWaGo_C",
			"BP_WuWaGo_LandBox_C",
			"BP_WuWaGo_WallBox_C",
			"BP_DollGrabMachineGlobalConfig_C",
			"BP_ZoneFollowCameraController_C"
		};
	}
}
