using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Skin
{
	// Token: 0x02004F5A RID: 20314
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class SkinConfig : ConfigBase<SkinConfig>
	{
		// Token: 0x06034618 RID: 214552 RVA: 0x00D1C0FC File Offset: 0x00D1A2FC
		public WeaponSkin GetWeaponSkinConfig(int id)
		{
			return ConfigWeaponSkinById.GetConfig(id, true).Value;
		}

		// Token: 0x06034619 RID: 214553 RVA: 0x00D1C118 File Offset: 0x00D1A318
		public IReadOnlyList<WeaponSkin> GetWeaponSkinConfigListByType(int type)
		{
			return ConfigWeaponSkinByType.GetConfigList(type, true);
		}

		// Token: 0x0603461A RID: 214554 RVA: 0x00D1C121 File Offset: 0x00D1A321
		public string GetDefaultWeaponSkinIconPath()
		{
			return ConfigCommonParamById.GetStringConfig("OriginalWeaponSkinIcon");
		}

		// Token: 0x0603461B RID: 214555 RVA: 0x00D1C12D File Offset: 0x00D1A32D
		public string GetDefaultWeaponSkinName()
		{
			return ConfigCommonParamById.GetStringConfig("OriginalWeaponSkinName");
		}

		// Token: 0x0603461C RID: 214556 RVA: 0x00D1C139 File Offset: 0x00D1A339
		public string GetDefaultWeaponSkinDescription()
		{
			return ConfigCommonParamById.GetStringConfig("OriginalWeaponSkinDescription");
		}

		// Token: 0x0603461D RID: 214557 RVA: 0x00D1C145 File Offset: 0x00D1A345
		public string GetDefaultFlySkinIconPath(EFlySkinType skinType)
		{
			if (skinType == EFlySkinType.Paragliding)
			{
				return ConfigCommonParamById.GetStringConfig("OriginalParaglidingSkinIcon");
			}
			if (skinType == EFlySkinType.SoarWing)
			{
				return ConfigCommonParamById.GetStringConfig("OriginalSoarWingIcon");
			}
			return "";
		}

		// Token: 0x0603461E RID: 214558 RVA: 0x00D1C169 File Offset: 0x00D1A369
		public string GetDefaultFlySkinName(EFlySkinType skinType)
		{
			if (skinType == EFlySkinType.Paragliding)
			{
				return ConfigCommonParamById.GetStringConfig("OriginalParaglidingSkinName");
			}
			if (skinType == EFlySkinType.SoarWing)
			{
				return ConfigCommonParamById.GetStringConfig("OriginalSoarWingSkinName");
			}
			return "";
		}

		// Token: 0x0603461F RID: 214559 RVA: 0x00D1C18D File Offset: 0x00D1A38D
		public string GetDefaultFlySkinDescription(EFlySkinType skinType)
		{
			if (skinType == EFlySkinType.Paragliding)
			{
				return ConfigCommonParamById.GetStringConfig("OriginalParaglidingSkinDescription");
			}
			if (skinType == EFlySkinType.SoarWing)
			{
				return ConfigCommonParamById.GetStringConfig("OriginalSoarWingSkinDescription");
			}
			return "";
		}

		// Token: 0x06034620 RID: 214560 RVA: 0x00D1C1B1 File Offset: 0x00D1A3B1
		public string GetDefaultFlySkinTypeDescription(EFlySkinType skinType)
		{
			if (skinType == EFlySkinType.Paragliding)
			{
				return ConfigCommonParamById.GetStringConfig("OriginalParaglidingSkinTypeDesc");
			}
			if (skinType == EFlySkinType.SoarWing)
			{
				return ConfigCommonParamById.GetStringConfig("OriginalSoarWingSkinTypeDesc");
			}
			return "";
		}

		// Token: 0x06034621 RID: 214561 RVA: 0x00D1C1D5 File Offset: 0x00D1A3D5
		public string GetDefaultFlySkinStandAnimPath(EFlySkinType skinType)
		{
			if (skinType == EFlySkinType.Paragliding)
			{
				return ConfigCommonParamById.GetStringConfig("OriginalParaglidingSkinStandAnim");
			}
			if (skinType == EFlySkinType.SoarWing)
			{
				return ConfigCommonParamById.GetStringConfig("OriginalSoarWingSkinStandAnim");
			}
			return "";
		}

		// Token: 0x06034622 RID: 214562 RVA: 0x00D1C1FC File Offset: 0x00D1A3FC
		public int GetDefaultFlySkinModelId(EFlySkinType skinType)
		{
			if (skinType == EFlySkinType.Paragliding)
			{
				return ConfigCommonParamById.GetIntConfig("OriginalParaglidingSkinModelId").Value;
			}
			if (skinType == EFlySkinType.SoarWing)
			{
				return ConfigCommonParamById.GetIntConfig("OriginalSoarWingSkinModelId").Value;
			}
			return 0;
		}

		// Token: 0x06034623 RID: 214563 RVA: 0x00D1C237 File Offset: 0x00D1A437
		[NullableContext(2)]
		public float[] GetFlySkinModelOffsetTransform(EFlySkinType skinType)
		{
			if (skinType == EFlySkinType.Paragliding)
			{
				return ConfigCommonParamById.GetFloatArrayConfig("ParaglidingSkinOffsetTransform").ToArray<float>();
			}
			if (skinType == EFlySkinType.SoarWing)
			{
				return ConfigCommonParamById.GetFloatArrayConfig("SoarWingSkinOffsetTransform").ToArray<float>();
			}
			return null;
		}

		// Token: 0x06034624 RID: 214564 RVA: 0x00D1C261 File Offset: 0x00D1A461
		public string GetFlySkinModelCameraId(EFlySkinType skinType)
		{
			if (skinType == EFlySkinType.Paragliding)
			{
				return ConfigCommonParamById.GetStringConfig("ParaglidingSkinCameraId");
			}
			if (skinType == EFlySkinType.SoarWing)
			{
				return ConfigCommonParamById.GetStringConfig("SoarWingSkinCameraId");
			}
			return "";
		}

		// Token: 0x06034625 RID: 214565 RVA: 0x00D1C285 File Offset: 0x00D1A485
		public string GetFlySkinTabName(EFlySkinType skinType)
		{
			if (skinType == EFlySkinType.Paragliding)
			{
				return "Text_ParaglidingSkinTab_Text";
			}
			if (skinType == EFlySkinType.SoarWing)
			{
				return "Text_SoarWingSkinTab_Text";
			}
			return "";
		}

		// Token: 0x06034626 RID: 214566 RVA: 0x00D1C29F File Offset: 0x00D1A49F
		public string GetFlySkinBottomIconResourceId(EFlySkinType skinType)
		{
			if (skinType == EFlySkinType.Paragliding)
			{
				return "T_IconParagliding";
			}
			if (skinType == EFlySkinType.SoarWing)
			{
				return "T_IconSoarWing";
			}
			return "";
		}

		// Token: 0x06034627 RID: 214567 RVA: 0x00D1C2B9 File Offset: 0x00D1A4B9
		public string GetFlySkinEquipBtnTextId(EFlySkinType skinType, bool canEquip)
		{
			if (skinType == EFlySkinType.Paragliding)
			{
				if (!canEquip)
				{
					return "GliderSkin_EquipmentStatus_IsEquipped";
				}
				return "GliderSkin_EquipmentStatus_Equip";
			}
			else
			{
				if (skinType != EFlySkinType.SoarWing)
				{
					return "";
				}
				if (!canEquip)
				{
					return "SoarWingSkin_EquipmentStatus_IsEquipped";
				}
				return "SoarWingSkin_EquipmentStatus_Equip";
			}
		}

		// Token: 0x06034628 RID: 214568 RVA: 0x00D1C2E5 File Offset: 0x00D1A4E5
		public string GetFlySkinSpawnEffectId(EFlySkinType skinType)
		{
			if (skinType == EFlySkinType.Paragliding)
			{
				return "GliderEffect";
			}
			if (skinType == EFlySkinType.SoarWing)
			{
				return "SoarWingEffect";
			}
			return "";
		}

		// Token: 0x06034629 RID: 214569 RVA: 0x00D1C2FF File Offset: 0x00D1A4FF
		public string GetFlySkinSpawnMaterialController(EFlySkinType skinType)
		{
			if (skinType == EFlySkinType.Paragliding)
			{
				return "GliderMaterialController";
			}
			if (skinType == EFlySkinType.SoarWing)
			{
				return "SoarWingMaterialController";
			}
			return "";
		}

		// Token: 0x0603462A RID: 214570 RVA: 0x00D1C319 File Offset: 0x00D1A519
		public RoleSkin? GetRoleSkinConfig(int itemId)
		{
			return ConfigRoleSkinById.GetConfig(itemId, true);
		}

		// Token: 0x0603462B RID: 214571 RVA: 0x00D1C324 File Offset: 0x00D1A524
		[NullableContext(2)]
		public string GetRoleSkinConfigValueByParam(int itemId, string param, [Nullable(1)] string tag)
		{
			RoleSkin? roleSkinConfig = this.GetRoleSkinConfig(itemId);
			if (roleSkinConfig == null || string.IsNullOrEmpty(param))
			{
				return null;
			}
			if (param != null)
			{
				int length = param.Length;
				if (length != 4)
				{
					if (length != 9)
					{
						switch (length)
						{
						case 12:
							if (param == "RoleHeadIcon")
							{
								return roleSkinConfig.Value.RoleHeadIcon;
							}
							break;
						case 15:
							if (param == "RoleHeadIconBig")
							{
								return roleSkinConfig.Value.RoleHeadIconBig;
							}
							break;
						case 17:
						{
							char c = param[0];
							if (c != 'F')
							{
								if (c == 'R')
								{
									if (param == "RoleHeadIconLarge")
									{
										return roleSkinConfig.Value.RoleHeadIconLarge;
									}
								}
							}
							else if (param == "FormationRoleCard")
							{
								return roleSkinConfig.Value.FormationRoleCard;
							}
							break;
						}
						case 18:
							if (param == "RoleHeadIconCircle")
							{
								return roleSkinConfig.Value.RoleHeadIconCircle;
							}
							break;
						}
					}
					else if (param == "RoleStand")
					{
						return roleSkinConfig.Value.RoleStand;
					}
				}
				else if (param == "Card")
				{
					return roleSkinConfig.Value.Card;
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

		// Token: 0x0603462C RID: 214572 RVA: 0x00D1C4C6 File Offset: 0x00D1A6C6
		[NullableContext(2)]
		public IReadOnlyList<RoleSkin> GetRoleSkinConfigList(int roleId)
		{
			return ConfigRoleSkinByRoleId.GetConfigList(roleId, true);
		}

		// Token: 0x0603462D RID: 214573 RVA: 0x00D1C4D0 File Offset: 0x00D1A6D0
		public int GetSkinDetailButtonGap()
		{
			return ConfigCommonParamById.GetIntConfig("SkinDetailButtonGap").Value;
		}

		// Token: 0x0603462E RID: 214574 RVA: 0x00D1C4F0 File Offset: 0x00D1A6F0
		public int GetSkinDetailButtonSwitchGap()
		{
			return ConfigCommonParamById.GetIntConfig("SkinDetailButtonSwitchGap").Value;
		}

		// Token: 0x0603462F RID: 214575 RVA: 0x00D1C50F File Offset: 0x00D1A70F
		public RoleSkin? GetSkinConfigByRoleIdAndGroupId(int roleId, int groupId)
		{
			return ConfigRoleSkinByRoleIdAndGroupId.GetConfig(roleId, groupId, true);
		}

		// Token: 0x06034630 RID: 214576 RVA: 0x00D1C519 File Offset: 0x00D1A719
		public FlySkinConfig? GetFlySkinConfig(int itemId)
		{
			return ConfigFlySkinConfigById.GetConfig(itemId, true);
		}

		// Token: 0x06034631 RID: 214577 RVA: 0x00D1C522 File Offset: 0x00D1A722
		public IReadOnlyList<FlySkinConfig> GetFlySkinConfigListByType(EFlySkinType type)
		{
			return ConfigFlySkinConfigByType.GetConfigList((int)type, true);
		}

		// Token: 0x06034632 RID: 214578 RVA: 0x00D1C52B File Offset: 0x00D1A72B
		[NullableContext(2)]
		public IReadOnlyList<RoleSkin> GetSkinGroupList(int skinGroupId)
		{
			return ConfigRoleSkinByGroupId.GetConfigList(skinGroupId, true);
		}

		// Token: 0x06034633 RID: 214579 RVA: 0x00D1C534 File Offset: 0x00D1A734
		public CalabashSkin GetCalabashSkinConfig(int itemId)
		{
			return ConfigCalabashSkinById.GetConfig(itemId, true).Value;
		}

		// Token: 0x06034634 RID: 214580 RVA: 0x00D1C550 File Offset: 0x00D1A750
		public IReadOnlyList<CalabashSkin> GetCalabashSkinConfigList()
		{
			return ConfigCalabashSkinAll.GetConfigList(true);
		}

		// Token: 0x06034635 RID: 214581 RVA: 0x00D1C558 File Offset: 0x00D1A758
		public string GetDefaultCalabashSkinIconPath()
		{
			return ConfigCommonParamById.GetStringConfig("OriginalCalabashSkinIcon");
		}

		// Token: 0x06034636 RID: 214582 RVA: 0x00D1C564 File Offset: 0x00D1A764
		public string GetDefaultCalabashSkinName()
		{
			return ConfigCommonParamById.GetStringConfig("OriginalCalabashSkinName");
		}

		// Token: 0x06034637 RID: 214583 RVA: 0x00D1C570 File Offset: 0x00D1A770
		public string GetDefaultCalabashSkinDescription()
		{
			return ConfigCommonParamById.GetStringConfig("OriginalCalabashSkinDescription");
		}

		// Token: 0x06034638 RID: 214584 RVA: 0x00D1C57C File Offset: 0x00D1A77C
		public CalabashTransform GetCalabashTransformById(int transformId)
		{
			return ConfigCalabashTransformById.GetConfig(transformId, true).Value;
		}

		// Token: 0x06034639 RID: 214585 RVA: 0x00D1C598 File Offset: 0x00D1A798
		public int GetCalabashSkinFailRequestCd()
		{
			return ConfigCommonParamById.GetIntConfig("CalabashSkinFailRequestCd").Value;
		}

		// Token: 0x0603463A RID: 214586 RVA: 0x00D1C5B8 File Offset: 0x00D1A7B8
		public bool GetCalabashSkinNeedStopRotate()
		{
			return ConfigCommonParamById.GetBoolConfig("CalabashSkinNeedStopRotate").Value;
		}

		// Token: 0x0603463B RID: 214587 RVA: 0x00D1C5D7 File Offset: 0x00D1A7D7
		public MotorSkinShow? GetMotorSkinShowConfig(int id)
		{
			return ConfigMotorSkinShowById.GetConfig(id, true);
		}

		// Token: 0x0603463C RID: 214588 RVA: 0x00D1C5E0 File Offset: 0x00D1A7E0
		public MotorGiftQuality? GetMotorSkinGiftQualityConfig(int qualityId)
		{
			return ConfigMotorGiftQualityByQualityId.GetConfig(qualityId, true);
		}
	}
}
