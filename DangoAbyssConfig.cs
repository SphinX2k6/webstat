using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02001AB5 RID: 6837
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class DangoAbyssConfig : ConfigBase<DangoAbyssConfig>
{
	// Token: 0x0600C41E RID: 50206 RVA: 0x0033C389 File Offset: 0x0033A589
	public AbyssInst? GetDangoAbyssInstById(int id)
	{
		return ConfigAbyssInstById.GetConfig(id, true);
	}

	// Token: 0x0600C41F RID: 50207 RVA: 0x0033C392 File Offset: 0x0033A592
	public AbyssInst? GetDangoAbyssInstByInstId(int id)
	{
		return ConfigAbyssInstByInstId.GetConfig(id, true);
	}

	// Token: 0x0600C420 RID: 50208 RVA: 0x0033C39B File Offset: 0x0033A59B
	public IReadOnlyList<AbyssInst> GetDangoAbyssInstListByActivityId(int activityId)
	{
		return ConfigAbyssInstByActivityId.GetConfigList(activityId, true);
	}

	// Token: 0x0600C421 RID: 50209 RVA: 0x0033C3A4 File Offset: 0x0033A5A4
	public AbyssReward? GetAbyssRewardById(int id)
	{
		return ConfigAbyssRewardById.GetConfig(id, true);
	}

	// Token: 0x0600C422 RID: 50210 RVA: 0x0033C3AD File Offset: 0x0033A5AD
	public IReadOnlyList<AbyssReward> GetAllAbyssReward()
	{
		return ConfigAbyssRewardAll.GetConfigList(true);
	}

	// Token: 0x0600C423 RID: 50211 RVA: 0x0033C3B5 File Offset: 0x0033A5B5
	public AbyssRewardType? GetAbyssRewardTypeById(int id)
	{
		return ConfigAbyssRewardTypeById.GetConfig(id, true);
	}

	// Token: 0x0600C424 RID: 50212 RVA: 0x0033C3BE File Offset: 0x0033A5BE
	public AbyssRoom? GetDangoAbyssRoomById(int id)
	{
		return ConfigAbyssRoomById.GetConfig(id, true);
	}

	// Token: 0x0600C425 RID: 50213 RVA: 0x0033C3C7 File Offset: 0x0033A5C7
	public AbyssLittleRole? GetDangoRoleById(int id)
	{
		return ConfigAbyssLittleRoleById.GetConfig(id, true);
	}

	// Token: 0x0600C426 RID: 50214 RVA: 0x0033C3D0 File Offset: 0x0033A5D0
	public IReadOnlyList<AbyssLittleRole> GetAllDangoRole()
	{
		return ConfigAbyssLittleRoleAll.GetConfigList(true);
	}

	// Token: 0x0600C427 RID: 50215 RVA: 0x0033C3D8 File Offset: 0x0033A5D8
	public AbyssRoleLevel? GetDangoLevelConfigByLevelAndGroupId(int level, int groupId)
	{
		return ConfigAbyssRoleLevelByLevelAndGroupId.GetConfig(level, groupId, true);
	}

	// Token: 0x0600C428 RID: 50216 RVA: 0x0033C3E2 File Offset: 0x0033A5E2
	public IReadOnlyList<AbyssRoleLevel> GetDangoLevelConfigByGroupId(int groupId)
	{
		return ConfigAbyssRoleLevelByGroupId.GetConfigList(groupId, true);
	}

	// Token: 0x0600C429 RID: 50217 RVA: 0x0033C3EC File Offset: 0x0033A5EC
	public AbyssItem? GetDangoItemById(int id)
	{
		if (id <= 0)
		{
			return null;
		}
		return ConfigAbyssItemById.GetConfig(id, true);
	}

	// Token: 0x0600C42A RID: 50218 RVA: 0x0033C410 File Offset: 0x0033A610
	public DangoAbyssDefine.ESlotType GetSlotTypeByIndex(int slotIndex)
	{
		AbyssRoleSlot? config = ConfigAbyssRoleSlotById.GetConfig(slotIndex, true);
		if (config != null)
		{
			return (DangoAbyssDefine.ESlotType)config.Value.SlotType;
		}
		return DangoAbyssDefine.ESlotType.Normal;
	}

	// Token: 0x0600C42B RID: 50219 RVA: 0x0033C43F File Offset: 0x0033A63F
	public AbyssCastDesc? GetDangoCastDescById(int id)
	{
		return ConfigAbyssCastDescById.GetConfig(id, true);
	}

	// Token: 0x0600C42C RID: 50220 RVA: 0x0033C448 File Offset: 0x0033A648
	public AbyssPluginPropDesc? GetDangoPluginPropDescById(int id)
	{
		return ConfigAbyssPluginPropDescById.GetConfig(id, true);
	}

	// Token: 0x0600C42D RID: 50221 RVA: 0x0033C451 File Offset: 0x0033A651
	public AbyssQuality? GetAbyssQualityById(int id)
	{
		return ConfigAbyssQualityById.GetConfig(id, true);
	}

	// Token: 0x0600C42E RID: 50222 RVA: 0x0033C45C File Offset: 0x0033A65C
	public AbyssQuality? GetAbyssQualityByPluginItemId(int itemId)
	{
		AbyssItem? dangoItemById = this.GetDangoItemById(itemId);
		if (dangoItemById == null)
		{
			return null;
		}
		return ConfigAbyssQualityById.GetConfig(dangoItemById.Value.QualityId, true);
	}

	// Token: 0x0600C42F RID: 50223 RVA: 0x0033C499 File Offset: 0x0033A699
	public int? GetWorldInstanceId()
	{
		return ConfigCommonParamById.GetIntConfig("DangoWorldInstanceId");
	}

	// Token: 0x0600C430 RID: 50224 RVA: 0x0033C4A5 File Offset: 0x0033A6A5
	public int? GetWorldInstanceEntranceId()
	{
		return ConfigCommonParamById.GetIntConfig("DangoWorldInstanceEntranceId");
	}

	// Token: 0x0600C431 RID: 50225 RVA: 0x0033C4B1 File Offset: 0x0033A6B1
	public int? GetWorldTeleportId()
	{
		return ConfigCommonParamById.GetIntConfig("DangoSmallWorldTeleportId");
	}

	// Token: 0x0600C432 RID: 50226 RVA: 0x0033C4BD File Offset: 0x0033A6BD
	public IReadOnlyList<int> GetSmallWorldInsIdList()
	{
		return ConfigCommonParamById.GetIntArrayConfig("DangoSmallWorldInsId");
	}

	// Token: 0x0600C433 RID: 50227 RVA: 0x0033C4C9 File Offset: 0x0033A6C9
	public int? GetAbyssKeyItemId()
	{
		return ConfigCommonParamById.GetIntConfig("AbyssKeyId");
	}

	// Token: 0x0600C434 RID: 50228 RVA: 0x0033C4D5 File Offset: 0x0033A6D5
	public string GetAbyssLimitRewardTexture()
	{
		return ConfigCommonParamById.GetStringConfig("DangoAbyssLimitRewardTexture");
	}

	// Token: 0x0600C435 RID: 50229 RVA: 0x0033C4E1 File Offset: 0x0033A6E1
	public int? GetAbyssLimitRewardRewardId()
	{
		return ConfigCommonParamById.GetIntConfig("DangoAbyssLimitRewardId");
	}

	// Token: 0x0600C436 RID: 50230 RVA: 0x0033C4ED File Offset: 0x0033A6ED
	public AbyssActivity? GetAbyssActivityData(int activityId)
	{
		return ConfigAbyssActivityByActivityId.GetConfig(activityId, true);
	}

	// Token: 0x0600C437 RID: 50231 RVA: 0x0033C4F8 File Offset: 0x0033A6F8
	public AbyssRoute? GetAbyssRouteByRouteIdAndFloorId(int routeId, int floorId)
	{
		IReadOnlyList<AbyssRoute> configList = ConfigAbyssRouteByRouterAndFloor.GetConfigList(routeId, floorId, true);
		if (configList == null || configList.Count <= 0)
		{
			return null;
		}
		return new AbyssRoute?(configList[0]);
	}

	// Token: 0x0600C438 RID: 50232 RVA: 0x0033C530 File Offset: 0x0033A730
	public AbyssRewardTab? GetAbyssRewardTabById(int id)
	{
		return ConfigAbyssRewardTabById.GetConfig(id, true);
	}

	// Token: 0x0600C439 RID: 50233 RVA: 0x0033C53C File Offset: 0x0033A73C
	public int GetAbyssMarkByActivityId(int id)
	{
		return ConfigAbyssActivityByActivityId.GetConfig(id, true).Value.MarkId;
	}

	// Token: 0x0600C43A RID: 50234 RVA: 0x0033C560 File Offset: 0x0033A760
	public AbyssSettle? GetAbyssSettleById(int id)
	{
		return ConfigAbyssSettleById.GetConfig(id, true);
	}

	// Token: 0x0600C43B RID: 50235 RVA: 0x0033C56C File Offset: 0x0033A76C
	public AbyssSynthesis? GetAbyssSynthesisByQualityId(int qualityId)
	{
		IReadOnlyList<AbyssSynthesis> configList = ConfigAbyssSynthesisAll.GetConfigList(true);
		if (configList == null)
		{
			return null;
		}
		foreach (AbyssSynthesis value in configList)
		{
			if (value.Quality == qualityId)
			{
				return new AbyssSynthesis?(value);
			}
		}
		return null;
	}

	// Token: 0x0600C43C RID: 50236 RVA: 0x0033C5E0 File Offset: 0x0033A7E0
	public int GetDangoShopAngryTime()
	{
		return ConfigCommonParamById.GetIntConfig("DangoShopAngryTime").GetValueOrDefault();
	}

	// Token: 0x0600C43D RID: 50237 RVA: 0x0033C600 File Offset: 0x0033A800
	public int GetDangoShopBuyTime()
	{
		return ConfigCommonParamById.GetIntConfig("DangoShopBuyTime").GetValueOrDefault();
	}

	// Token: 0x0600C43E RID: 50238 RVA: 0x0033C620 File Offset: 0x0033A820
	public int GetDangoShopClickTime()
	{
		return ConfigCommonParamById.GetIntConfig("DangoShopClickTime").GetValueOrDefault();
	}

	// Token: 0x0600C43F RID: 50239 RVA: 0x0033C640 File Offset: 0x0033A840
	public int GetBadDangoMeshId()
	{
		return ConfigCommonParamById.GetIntConfig("BadDangoMesh").GetValueOrDefault();
	}

	// Token: 0x0600C440 RID: 50240 RVA: 0x0033C65F File Offset: 0x0033A85F
	public string GetBadDangoStandAni()
	{
		return ConfigCommonParamById.GetStringConfig("BadDangoStandAnimation");
	}

	// Token: 0x0600C441 RID: 50241 RVA: 0x0033C66B File Offset: 0x0033A86B
	public string GetBadDangoBuyAni()
	{
		return ConfigCommonParamById.GetStringConfig("BadDangoBuyAnimation");
	}

	// Token: 0x0600C442 RID: 50242 RVA: 0x0033C677 File Offset: 0x0033A877
	public string GetBadDangoBadDangoPinkAni()
	{
		return ConfigCommonParamById.GetStringConfig("BadDangoPinkAnimation");
	}

	// Token: 0x0600C443 RID: 50243 RVA: 0x0033C683 File Offset: 0x0033A883
	public string GetBadDangoBadDangoPinkOverAni()
	{
		return ConfigCommonParamById.GetStringConfig("BadDangoPinkOverAnimation");
	}

	// Token: 0x0600C444 RID: 50244 RVA: 0x0033C690 File Offset: 0x0033A890
	public FTransform GetBadDangoTransform()
	{
		FRotator badDangoRotator = this.GetBadDangoRotator();
		FVector badDangoLocation = this.GetBadDangoLocation();
		FVector badDangoZoom = this.GetBadDangoZoom();
		return new FTransform(ref badDangoRotator, ref badDangoLocation, ref badDangoZoom);
	}

	// Token: 0x0600C445 RID: 50245 RVA: 0x0033C6C0 File Offset: 0x0033A8C0
	private FRotator GetBadDangoRotator()
	{
		IReadOnlyList<float> floatArrayConfig = ConfigCommonParamById.GetFloatArrayConfig("BadDangoRotator");
		FRotator result = new FRotator();
		if (floatArrayConfig.Count == 3)
		{
			result.Roll = floatArrayConfig[0];
			result.Pitch = floatArrayConfig[1];
			result.Yaw = floatArrayConfig[2];
		}
		return result;
	}

	// Token: 0x0600C446 RID: 50246 RVA: 0x0033C714 File Offset: 0x0033A914
	private FVector GetBadDangoZoom()
	{
		IReadOnlyList<float> floatArrayConfig = ConfigCommonParamById.GetFloatArrayConfig("BadDangoZoom");
		FVector result = new FVector();
		if (floatArrayConfig.Count == 3)
		{
			result.X = floatArrayConfig[0];
			result.Y = floatArrayConfig[1];
			result.Z = floatArrayConfig[2];
		}
		return result;
	}

	// Token: 0x0600C447 RID: 50247 RVA: 0x0033C768 File Offset: 0x0033A968
	private FVector GetBadDangoLocation()
	{
		IReadOnlyList<float> floatArrayConfig = ConfigCommonParamById.GetFloatArrayConfig("BadDangoLocation");
		FVector result = new FVector();
		if (floatArrayConfig.Count == 3)
		{
			result.X = floatArrayConfig[0];
			result.Y = floatArrayConfig[1];
			result.Z = floatArrayConfig[2];
		}
		return result;
	}

	// Token: 0x0600C448 RID: 50248 RVA: 0x0033C7BC File Offset: 0x0033A9BC
	public string GetItemBgDesc(int itemId)
	{
		AbyssItem? dangoItemById = this.GetDangoItemById(itemId);
		string bgDescription = dangoItemById.Value.BgDescription;
		if (bgDescription == "")
		{
			return "";
		}
		StringArray? stringArray = dangoItemById.Value.LevelDescStrArray(0);
		if (stringArray != null)
		{
			StringArray value = stringArray.Value;
			int arrayStringLength = value.ArrayStringLength;
			string[] array = new string[arrayStringLength];
			for (int i = 0; i < arrayStringLength; i++)
			{
				array[i] = value.ArrayString(i);
			}
			return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(bgDescription, null), array);
		}
		return "";
	}
}
