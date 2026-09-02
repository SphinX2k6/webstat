using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed;
using CSharpScript.Game.Module.DeadRevive;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Module.InstanceDungeon;

// Token: 0x02001AC7 RID: 6855
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class DangoAbyssModel : ModelBase<DangoAbyssModel>
{
	// Token: 0x0600C4D9 RID: 50393 RVA: 0x0033F06E File Offset: 0x0033D26E
	protected override bool OnLeaveLevel()
	{
		this.ChallengeFinish = false;
		this.CurrentRoomId = 0;
		return true;
	}

	// Token: 0x0600C4DA RID: 50394 RVA: 0x0033F07F File Offset: 0x0033D27F
	public void OnAbyssChallengeResultNotify(AbyssChallengeResultNotify notify)
	{
		this.CurrentAbyssResultInfo = new AbyssChallengeResultData();
		this.CurrentAbyssResultInfo.Phrase(notify.Result);
		this.ChallengeFinish = true;
		this.SetLikeRecord(notify.Result.LikeRecord.ToList<AbyssLikeRecord>());
	}

	// Token: 0x0600C4DB RID: 50395 RVA: 0x0033F0BA File Offset: 0x0033D2BA
	public AbyssRankChallengeInfo GetChallengeRankInfo()
	{
		if (this.ChallengeRankInfo == null)
		{
			this.ChallengeRankInfo = new AbyssRankChallengeInfo();
		}
		return this.ChallengeRankInfo;
	}

	// Token: 0x0600C4DC RID: 50396 RVA: 0x0033F0D5 File Offset: 0x0033D2D5
	public void OnAnonymousNameStateChange(int challengeId, bool state)
	{
		this.GetChallengeRankInfo().SetIsOpenAnonymousName(challengeId, state);
	}

	// Token: 0x0600C4DD RID: 50397 RVA: 0x0033F0E4 File Offset: 0x0033D2E4
	public bool GetChallengeAnonymousNameState(int challengeId)
	{
		return this.GetChallengeRankInfo().GetAnonymousNameMode(challengeId);
	}

	// Token: 0x0600C4DE RID: 50398 RVA: 0x0033F0F4 File Offset: 0x0033D2F4
	public bool CheckPayShopRedDot()
	{
		using (List<PayShopGoods>.Enumerator enumerator = this.GetPayShopGoods().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetIfNeedRemind())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600C4DF RID: 50399 RVA: 0x0033F150 File Offset: 0x0033D350
	public List<PayShopGoods> GetPayShopGoods()
	{
		int openShopId = ModelBase<DangoAbyssModel>.Instance.GetOpenShopId();
		return ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)openShopId, 1, false);
	}

	// Token: 0x0600C4E0 RID: 50400 RVA: 0x0033F175 File Offset: 0x0033D375
	public void OnAbyssChallegenRankUpdate(AbyssRankListResponse notify)
	{
		this.GetChallengeRankInfo().OnChallengeRankInfoUpdate(notify);
	}

	// Token: 0x0600C4E1 RID: 50401 RVA: 0x0033F183 File Offset: 0x0033D383
	public void OnAbyssChallengeSelfRankUpdate(AbyssSelfPassResponse notify)
	{
		this.GetChallengeRankInfo().OnSelfRankInfoUpdate(notify);
	}

	// Token: 0x0600C4E2 RID: 50402 RVA: 0x0033F194 File Offset: 0x0033D394
	public void OnAbyssLikeNotify(AbyssLikeNotify notify)
	{
		if (this.CurrentAbyssResultInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.YZY, "没有结算数据但是收到了喜欢通知", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		global::AbyssChallengeResultPlayerInfo playerInfoByPlayerId = this.CurrentAbyssResultInfo.GetPlayerInfoByPlayerId(notify.PlayerId);
		if (playerInfoByPlayerId == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.YZY, "没有找到玩家数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		playerInfoByPlayerId.SetLikeCount(notify.LikeCount);
		this.SetLikeRecord(notify.LikeRecord.ToList<AbyssLikeRecord>());
	}

	// Token: 0x0600C4E3 RID: 50403 RVA: 0x0033F21C File Offset: 0x0033D41C
	public int GetPlayerLikeCount(int playerId)
	{
		if (this.CurrentAbyssResultInfo == null)
		{
			return 0;
		}
		global::AbyssChallengeResultPlayerInfo playerInfoByPlayerId = this.CurrentAbyssResultInfo.GetPlayerInfoByPlayerId(playerId);
		if (playerInfoByPlayerId == null)
		{
			return 0;
		}
		return playerInfoByPlayerId.GetLikeCount();
	}

	// Token: 0x0600C4E4 RID: 50404 RVA: 0x0033F24B File Offset: 0x0033D44B
	public void OnAbyssFormationRoleSelectUpdateNotify(AbyssRoleSelectUpdateNotify notify)
	{
		this.CurrentFormationSelectInfo = new AbyssFormationInfo();
		this.CurrentFormationSelectInfo.Phrase(notify);
	}

	// Token: 0x0600C4E5 RID: 50405 RVA: 0x0033F264 File Offset: 0x0033D464
	[NullableContext(2)]
	public DangoAbyssActivityData GetCurrentOpenAbyssActivityData()
	{
		foreach (KeyValuePair<int, ActivityBaseData> keyValuePair in ModelBase<ActivityModel>.Instance.GetAllActivityMap())
		{
			if (keyValuePair.Value.Type == ActivityType.Abyss)
			{
				return keyValuePair.Value as DangoAbyssActivityData;
			}
		}
		return null;
	}

	// Token: 0x0600C4E6 RID: 50406 RVA: 0x0033F2D8 File Offset: 0x0033D4D8
	[NullableContext(2)]
	public AbyssDangoRoleData GetDangoAbyssRoleData(int id)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return currentOpenAbyssActivityData.GetRoleDataById(id);
	}

	// Token: 0x0600C4E7 RID: 50407 RVA: 0x0033F318 File Offset: 0x0033D518
	public bool GetAbyssUnLockState(int id)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return currentOpenAbyssActivityData.GetAbyssChallengeDataById(id).GetIfUnlock();
	}

	// Token: 0x0600C4E8 RID: 50408 RVA: 0x0033F35C File Offset: 0x0033D55C
	public int GetAbyssMaxProgress(int id)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0;
		}
		return currentOpenAbyssActivityData.GetAbyssChallengeDataById(id).GetMaxProgress();
	}

	// Token: 0x0600C4E9 RID: 50409 RVA: 0x0033F3A0 File Offset: 0x0033D5A0
	public bool GetAbyssTimeLimitState(int id)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return currentOpenAbyssActivityData.GetAbyssChallengeDataById(id).GetOverUnlockTime();
	}

	// Token: 0x0600C4EA RID: 50410 RVA: 0x0033F3E4 File Offset: 0x0033D5E4
	public bool GetAbyssConditionFinishState(int id)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return currentOpenAbyssActivityData.GetAbyssChallengeDataById(id).GetConditionFinishState();
	}

	// Token: 0x0600C4EB RID: 50411 RVA: 0x0033F428 File Offset: 0x0033D628
	public string GetAbyssUnlockTimeText(int id)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return "";
		}
		return currentOpenAbyssActivityData.GetAbyssChallengeDataById(id).GetLeftTimeText();
	}

	// Token: 0x0600C4EC RID: 50412 RVA: 0x0033F470 File Offset: 0x0033D670
	public bool GetAbyssPreChallengeFinishState(int id)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return currentOpenAbyssActivityData.GetPreChallengeFinishState(id);
	}

	// Token: 0x0600C4ED RID: 50413 RVA: 0x0033F4B0 File Offset: 0x0033D6B0
	public bool CheckIsSelf(int playerId)
	{
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		return id.GetValueOrDefault() == playerId & id != null;
	}

	// Token: 0x0600C4EE RID: 50414 RVA: 0x0033F4DC File Offset: 0x0033D6DC
	public bool CheckInAbyss()
	{
		InstanceDungeon? instanceDungeon;
		return ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<CreatureModel>.Instance.GetInstanceId()) != null && instanceDungeon.GetValueOrDefault().InstSubType == 33 && ControllerBase<GameModeController>.Instance.IsInInstance();
	}

	// Token: 0x0600C4EF RID: 50415 RVA: 0x0033F52C File Offset: 0x0033D72C
	public bool CheckInAbyssEditFormationState()
	{
		InstanceDungeon? getCurrentDungeonConfig = ModelBase<EditBattleTeamModel>.Instance.GetCurrentDungeonConfig;
		return getCurrentDungeonConfig != null && getCurrentDungeonConfig.Value.InstSubType == 33;
	}

	// Token: 0x0600C4F0 RID: 50416 RVA: 0x0033F568 File Offset: 0x0033D768
	public bool CheckAllDangoReady()
	{
		EditBattleRoleSlotData[] getAllRoleSlotData = ModelBase<EditBattleTeamModel>.Instance.GetAllRoleSlotData;
		int num = getAllRoleSlotData.Length;
		for (int i = 0; i < num; i++)
		{
			EditBattleRoleData getRoleData = getAllRoleSlotData[i].GetRoleData;
			int? num2 = (getRoleData != null) ? new int?(getRoleData.PlayerId) : null;
			int? num3 = num2;
			int num4 = 0;
			if (!(num3.GetValueOrDefault() == num4 & num3 != null) && num2 != null)
			{
				num3 = num2;
				int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
				if (num3.GetValueOrDefault() == id.GetValueOrDefault() & num3 != null == (id != null))
				{
					int? getRoleConfigId = getAllRoleSlotData[i].GetRoleConfigId;
					AbyssDangoOwnerData roleOwnerData = this.GetRoleOwnerData(num2.Value, getRoleConfigId.Value);
					if (roleOwnerData == null || roleOwnerData.DangoId <= 0)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	// Token: 0x0600C4F1 RID: 50417 RVA: 0x0033F640 File Offset: 0x0033D840
	public bool CheckIsInMatch()
	{
		return ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() > EInstanceMatchState.Default;
	}

	// Token: 0x0600C4F2 RID: 50418 RVA: 0x0033F650 File Offset: 0x0033D850
	public void PhraseRoomInfo(AbyssChallengeRoomInfoNotify data)
	{
		this.CurrentLayer = data.CurFloor;
		this.MaxLayer = data.MaxFloor;
		this.MaxBoxCount = data.MaxBox;
		this.GainBoxCount = data.GainBox;
		this.CurrentRouteId = data.RouteId;
		this.CurrentChallengeId = data.ChallengeId;
		this.RoleSelectDangoMap = data.RoleEquipMap.ToDictionary<int, int>();
		this.MaxScore = data.MaxScore;
		this.CurrentScore = data.CurScore;
		bool currentRoomId = this.CurrentRoomId != 0;
		this.CurrentRoomId = data.RoomId;
		if (!currentRoomId && this.CurrentRoomId != 0)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAbyssFirstRoomEnter);
		}
		this.SetLikeRecord(data.LikeRecord.ToList<AbyssLikeRecord>());
	}

	// Token: 0x0600C4F3 RID: 50419 RVA: 0x0033F70B File Offset: 0x0033D90B
	public Dictionary<int, int> GetRoleSelectDangoMap()
	{
		return this.RoleSelectDangoMap ?? new Dictionary<int, int>();
	}

	// Token: 0x0600C4F4 RID: 50420 RVA: 0x0033F71C File Offset: 0x0033D91C
	public int GetAbyssLayer()
	{
		return this.CurrentLayer;
	}

	// Token: 0x0600C4F5 RID: 50421 RVA: 0x0033F724 File Offset: 0x0033D924
	public int GetMaxLayer()
	{
		return this.MaxLayer;
	}

	// Token: 0x0600C4F6 RID: 50422 RVA: 0x0033F72C File Offset: 0x0033D92C
	public float GetCurrentAbyssCompletePercentage()
	{
		return (float)this.CurrentLayer / (float)this.MaxLayer;
	}

	// Token: 0x0600C4F7 RID: 50423 RVA: 0x0033F73D File Offset: 0x0033D93D
	public int GetCurrentRoomId()
	{
		return this.CurrentRoomId;
	}

	// Token: 0x0600C4F8 RID: 50424 RVA: 0x0033F745 File Offset: 0x0033D945
	public int GetGainBoxCount()
	{
		return this.GainBoxCount;
	}

	// Token: 0x0600C4F9 RID: 50425 RVA: 0x0033F74D File Offset: 0x0033D94D
	public int GetMaxBoxCount()
	{
		return this.MaxBoxCount;
	}

	// Token: 0x0600C4FA RID: 50426 RVA: 0x0033F755 File Offset: 0x0033D955
	public bool GetInAbyssFlow()
	{
		return this.InAbyssFlowInternal;
	}

	// Token: 0x0600C4FB RID: 50427 RVA: 0x0033F75D File Offset: 0x0033D95D
	public void SetInAbyssFlow(bool value)
	{
		this.InAbyssFlowInternal = value;
	}

	// Token: 0x0600C4FC RID: 50428 RVA: 0x0033F768 File Offset: 0x0033D968
	public AttrListScrollData[] GetPluginShowAttributeList(int id)
	{
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		AbyssItem? dangoItemById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoItemById(id);
		if (dangoItemById == null)
		{
			return Array.Empty<AttrListScrollData>();
		}
		foreach (ConfigPropValue configPropValue in dangoItemById.Value.Prop())
		{
			list.Add(new AttrListScrollData(configPropValue.Id, (double)configPropValue.Value, 0.0, 0, configPropValue.IsRatio, CommonComponentDefine.EAttributeType.NormalType));
		}
		return list.ToArray();
	}

	// Token: 0x0600C4FD RID: 50429 RVA: 0x0033F7F4 File Offset: 0x0033D9F4
	public DangoAbyssDefine.DangoAbyssTagData[] GetPluginShowTagDataList(int itemId)
	{
		List<DangoAbyssDefine.DangoAbyssTagData> list = new List<DangoAbyssDefine.DangoAbyssTagData>();
		AbyssItem? dangoItemById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoItemById(itemId);
		if (dangoItemById == null)
		{
			return Array.Empty<DangoAbyssDefine.DangoAbyssTagData>();
		}
		foreach (KeyValuePair<int, int> keyValuePair in dangoItemById.Value.AddTag())
		{
			list.Add(new DangoAbyssDefine.DangoAbyssTagData
			{
				TagId = keyValuePair.Key,
				Value = keyValuePair.Value
			});
		}
		return list.ToArray();
	}

	// Token: 0x0600C4FE RID: 50430 RVA: 0x0033F89C File Offset: 0x0033DA9C
	public CSharpScript.Game.Module.Inventory.ItemConfig GetDangoItemConfig(int itemId)
	{
		return ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
	}

	// Token: 0x0600C4FF RID: 50431 RVA: 0x0033F8AC File Offset: 0x0033DAAC
	public int GetDangoItemBelongId(int incId)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		int? num;
		if (currentOpenAbyssActivityData == null)
		{
			num = null;
		}
		else
		{
			global::AbyssPluginItemInfo pluginItemInfoById = currentOpenAbyssActivityData.GetPluginItemInfoById(incId);
			num = ((pluginItemInfoById != null) ? new int?(pluginItemInfoById.GetBelongRole()) : null);
		}
		int? num2 = num;
		return num2.GetValueOrDefault();
	}

	// Token: 0x0600C500 RID: 50432 RVA: 0x0033F8F8 File Offset: 0x0033DAF8
	public int GetDangoBelongRoleId(int playerId, int id)
	{
		Dictionary<int, AbyssDangoOwnerData> playerOwnerDataMap = this.GetPlayerOwnerDataMap(playerId);
		int result = 0;
		foreach (KeyValuePair<int, AbyssDangoOwnerData> keyValuePair in playerOwnerDataMap)
		{
			if (keyValuePair.Value.DangoId == id)
			{
				result = keyValuePair.Key;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600C501 RID: 50433 RVA: 0x0033F964 File Offset: 0x0033DB64
	public bool GetDangoItemLockState(int incId)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			return false;
		}
		global::AbyssPluginItemInfo pluginItemInfoById = currentOpenAbyssActivityData.GetPluginItemInfoById(incId);
		return pluginItemInfoById != null && pluginItemInfoById.GetIsLock();
	}

	// Token: 0x0600C502 RID: 50434 RVA: 0x0033F98F File Offset: 0x0033DB8F
	private Dictionary<int, AbyssDangoOwnerData> GetPlayerOwnerDataMap(int playerId)
	{
		if (!this.DangoOwnerMap.ContainsKey(playerId))
		{
			this.DangoOwnerMap[playerId] = new Dictionary<int, AbyssDangoOwnerData>();
		}
		return this.DangoOwnerMap[playerId];
	}

	// Token: 0x0600C503 RID: 50435 RVA: 0x0033F9BC File Offset: 0x0033DBBC
	[NullableContext(2)]
	public AbyssDangoOwnerData GetPlayerRoleCfgOwnerData(int playerId, int roleCfgId)
	{
		if (roleCfgId == 0)
		{
			return null;
		}
		if (!this.DangoOwnerMap.ContainsKey(playerId))
		{
			this.DangoOwnerMap[playerId] = new Dictionary<int, AbyssDangoOwnerData>();
		}
		Dictionary<int, AbyssDangoOwnerData> dictionary = this.DangoOwnerMap[playerId];
		if (!dictionary.ContainsKey(roleCfgId))
		{
			dictionary[roleCfgId] = new AbyssDangoOwnerData();
		}
		return dictionary[roleCfgId];
	}

	// Token: 0x0600C504 RID: 50436 RVA: 0x0033FA18 File Offset: 0x0033DC18
	private void ResetDangoOwnerDataByRoleId(int playerId, int roleConfigId)
	{
		AbyssDangoOwnerData roleOwnerData = this.GetRoleOwnerData(playerId, roleConfigId);
		if (roleOwnerData == null)
		{
			return;
		}
		roleOwnerData.PlayerId = playerId;
		roleOwnerData.RoleCfgId = roleConfigId;
		roleOwnerData.DangoId = 0;
	}

	// Token: 0x0600C505 RID: 50437 RVA: 0x0033FA47 File Offset: 0x0033DC47
	[NullableContext(2)]
	public AbyssDangoOwnerData GetRoleOwnerData(int playerId, int roleConfigId)
	{
		return this.GetPlayerRoleCfgOwnerData(playerId, roleConfigId);
	}

	// Token: 0x0600C506 RID: 50438 RVA: 0x0033FA54 File Offset: 0x0033DC54
	[NullableContext(2)]
	public void RefreshOwnerListByMatchTeamInfo(MatchTeamInfo matchTeamInfo)
	{
		if (matchTeamInfo != null)
		{
			foreach (MatchPlayerInfo matchPlayerInfo in matchTeamInfo.PlayerInfos)
			{
				int playerId = matchPlayerInfo.PlayerId;
				foreach (MatchRoleInfo matchRoleInfo in matchPlayerInfo.RoleInfo)
				{
					this.ResetDangoOwnerDataByRoleId(playerId, matchRoleInfo.RoleId);
					AbyssDangoOwnerData roleOwnerData = this.GetRoleOwnerData(playerId, matchRoleInfo.RoleId);
					int roleId = matchRoleInfo.RoleId;
					if (roleOwnerData != null)
					{
						roleOwnerData.PlayerId = playerId;
						roleOwnerData.RoleCfgId = roleId;
						AbyssDangoOwnerData abyssDangoOwnerData = roleOwnerData;
						MatchRoleContext roleContext = matchRoleInfo.RoleContext;
						int? num;
						if (roleContext == null)
						{
							num = null;
						}
						else
						{
							AbyssMatchRoleContext abyssCtx = roleContext.AbyssCtx;
							if (abyssCtx == null)
							{
								num = null;
							}
							else
							{
								AbyssRoleInfo roleInfo = abyssCtx.RoleInfo;
								num = ((roleInfo != null) ? new int?(roleInfo.Id) : null);
							}
						}
						int? num2 = num;
						abyssDangoOwnerData.DangoId = num2.GetValueOrDefault();
						AbyssDangoOwnerData abyssDangoOwnerData2 = roleOwnerData;
						MatchRoleContext roleContext2 = matchRoleInfo.RoleContext;
						int? num3;
						if (roleContext2 == null)
						{
							num3 = null;
						}
						else
						{
							AbyssMatchRoleContext abyssCtx2 = roleContext2.AbyssCtx;
							if (abyssCtx2 == null)
							{
								num3 = null;
							}
							else
							{
								AbyssRoleInfo roleInfo2 = abyssCtx2.RoleInfo;
								num3 = ((roleInfo2 != null) ? new int?(roleInfo2.Level) : null);
							}
						}
						num2 = num3;
						abyssDangoOwnerData2.DangoLevel = num2.GetValueOrDefault();
						AbyssDangoOwnerData abyssDangoOwnerData3 = roleOwnerData;
						MatchRoleContext roleContext3 = matchRoleInfo.RoleContext;
						int[] array;
						if (roleContext3 == null)
						{
							array = null;
						}
						else
						{
							AbyssMatchRoleContext abyssCtx3 = roleContext3.AbyssCtx;
							if (abyssCtx3 == null)
							{
								array = null;
							}
							else
							{
								AbyssRoleInfo roleInfo3 = abyssCtx3.RoleInfo;
								array = ((roleInfo3 != null) ? roleInfo3.EquipItems.ToArray<int>() : null);
							}
						}
						abyssDangoOwnerData3.DangoEquipIds = (array ?? Array.Empty<int>());
					}
				}
			}
		}
	}

	// Token: 0x0600C507 RID: 50439 RVA: 0x0033FC30 File Offset: 0x0033DE30
	public Dictionary<int, int[]> CacheDangoSelect(int playerId, int roleConfigId, int dangoId)
	{
		Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
		Dictionary<int, AbyssDangoOwnerData> playerOwnerDataMap = this.GetPlayerOwnerDataMap(playerId);
		int num = 0;
		if (dangoId != 0)
		{
			AbyssDangoOwnerData roleOwnerData = this.GetRoleOwnerData(playerId, roleConfigId);
			int? num2 = (roleOwnerData != null) ? new int?(roleOwnerData.DangoId) : null;
			foreach (KeyValuePair<int, AbyssDangoOwnerData> keyValuePair in playerOwnerDataMap)
			{
				if (keyValuePair.Value.DangoId == dangoId && keyValuePair.Value.RoleCfgId != roleConfigId)
				{
					keyValuePair.Value.DangoId = 0;
					keyValuePair.Value.PlayerId = playerId;
					num = keyValuePair.Key;
					break;
				}
			}
			AbyssDangoOwnerData playerRoleCfgOwnerData = this.GetPlayerRoleCfgOwnerData(playerId, num);
			if (playerRoleCfgOwnerData != null)
			{
				playerRoleCfgOwnerData.DangoId = num2.GetValueOrDefault();
			}
		}
		AbyssDangoOwnerData playerRoleCfgOwnerData2 = this.GetPlayerRoleCfgOwnerData(playerId, roleConfigId);
		if (playerRoleCfgOwnerData2 != null)
		{
			playerRoleCfgOwnerData2.DangoId = dangoId;
			playerRoleCfgOwnerData2.PlayerId = playerId;
		}
		List<int> list = new List<int>();
		list.Add(roleConfigId);
		if (num != 0)
		{
			list.Add(num);
		}
		dictionary[playerId] = new int[]
		{
			roleConfigId,
			num
		};
		this.RefreshOwnDataAfterChange(playerId);
		return dictionary;
	}

	// Token: 0x0600C508 RID: 50440 RVA: 0x0033FD64 File Offset: 0x0033DF64
	public float GetInstanceProgress()
	{
		return Math.Min((float)this.CurrentScore / (float)this.MaxScore, 1f);
	}

	// Token: 0x0600C509 RID: 50441 RVA: 0x0033FD80 File Offset: 0x0033DF80
	public string GetInstanceReviveTipTips()
	{
		int currentShareReviveTimes = ModelBase<DeadReviveModel>.Instance.CurrentShareReviveTimes;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(currentShareReviveTimes);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600C50A RID: 50442 RVA: 0x0033FDB0 File Offset: 0x0033DFB0
	public string GetInstanceFloorProgressText()
	{
		float value = ModelBase<DangoAbyssModel>.Instance.GetCurrentAbyssCompletePercentage() * 100f;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendFormatted<float>(value, "F2");
		defaultInterpolatedStringHandler.AppendLiteral("%");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600C50B RID: 50443 RVA: 0x0033FDF8 File Offset: 0x0033DFF8
	public string GetInstanceFloorText()
	{
		int abyssLayer = this.GetAbyssLayer();
		int maxLayer = this.GetMaxLayer();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(abyssLayer);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(maxLayer);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600C50C RID: 50444 RVA: 0x0033FE3F File Offset: 0x0033E03F
	public string GetInstanceFloorDetailProgressText()
	{
		return this.GetInstanceFloorText();
	}

	// Token: 0x0600C50D RID: 50445 RVA: 0x0033FE47 File Offset: 0x0033E047
	public int GetCurrentChallengeId()
	{
		return this.CurrentChallengeId;
	}

	// Token: 0x0600C50E RID: 50446 RVA: 0x0033FE50 File Offset: 0x0033E050
	public int GetCurrentAbyssFullTime()
	{
		return ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstById(this.CurrentChallengeId).Value.TotalTime;
	}

	// Token: 0x0600C50F RID: 50447 RVA: 0x0033FE80 File Offset: 0x0033E080
	public int GetCurrentAbyssTotalScore()
	{
		return ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstById(this.CurrentChallengeId).Value.TotalScore;
	}

	// Token: 0x0600C510 RID: 50448 RVA: 0x0033FEB0 File Offset: 0x0033E0B0
	public Dictionary<int, int> GetCurrentAbyssTreasureMap()
	{
		return ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstById(this.CurrentChallengeId).Value.RewardTime();
	}

	// Token: 0x0600C511 RID: 50449 RVA: 0x0033FEE0 File Offset: 0x0033E0E0
	public bool IsPlanarDungeon()
	{
		return ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstByInstId(ModelBase<CreatureModel>.Instance.GetInstanceId()).Value.PlanarDungeon;
	}

	// Token: 0x0600C512 RID: 50450 RVA: 0x0033FF14 File Offset: 0x0033E114
	public string GetCurrentAbyssName()
	{
		if (this.CurrentChallengeId == 0)
		{
			return "";
		}
		string title = ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstById(this.CurrentChallengeId).Value.Title;
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("DangoInfoName", null);
		if (string.IsNullOrEmpty(localTextNew))
		{
			return "";
		}
		return StringUtils.Format(localTextNew, new string[]
		{
			ConfigMultiTextLang.GetLocalTextNew(title, null)
		});
	}

	// Token: 0x0600C513 RID: 50451 RVA: 0x0033FF80 File Offset: 0x0033E180
	public string GetCurrentRouteDesc()
	{
		if (this.CurrentRouteId == 0)
		{
			return "";
		}
		return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<DangoAbyssConfig>.Instance.GetAbyssRouteByRouteIdAndFloorId(this.CurrentRouteId, this.CurrentLayer).Value.Desc, null);
	}

	// Token: 0x0600C514 RID: 50452 RVA: 0x0033FFC8 File Offset: 0x0033E1C8
	public string GetInstanceRemainTimeText()
	{
		double challengeRemainTime = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonInfo().Tree.GetChallengeRemainTime(null);
		return Singleton<TimeUtil>.Instance.GetTimeDataFormat(Math.Ceiling(challengeRemainTime));
	}

	// Token: 0x0600C515 RID: 50453 RVA: 0x00340004 File Offset: 0x0033E204
	public int GetOpenShopId()
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		int num = (currentOpenAbyssActivityData != null) ? currentOpenAbyssActivityData.Id : 0;
		if (num > 0)
		{
			return ConfigBase<DangoAbyssConfig>.Instance.GetAbyssActivityData(num).Value.ShopId;
		}
		return 0;
	}

	// Token: 0x0600C516 RID: 50454 RVA: 0x00340048 File Offset: 0x0033E248
	public void RefreshOwnDataAfterChange(int playerId)
	{
		foreach (KeyValuePair<int, AbyssDangoOwnerData> keyValuePair in this.GetPlayerOwnerDataMap(playerId))
		{
			this.RefreshOwnData(keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x0600C517 RID: 50455 RVA: 0x003400AC File Offset: 0x0033E2AC
	private void RefreshOwnData(int roleId, AbyssDangoOwnerData data)
	{
		EditBattleRoleSlotData[] getAllRoleSlotData = ModelBase<EditBattleTeamModel>.Instance.GetAllRoleSlotData;
		int playerId = data.PlayerId;
		int? num = ModelBase<PlayerInfoModel>.Instance.GetId();
		if (playerId == num.GetValueOrDefault() & num != null)
		{
			AbyssDangoRoleData dangoAbyssRoleData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(data.DangoId);
			if (dangoAbyssRoleData != null)
			{
				bool flag = false;
				EditBattleRoleSlotData[] array = getAllRoleSlotData;
				for (int i = 0; i < array.Length; i++)
				{
					num = array[i].GetRoleConfigId;
					if (num.GetValueOrDefault() == roleId & num != null)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					this.GetPlayerOwnerDataMap(data.PlayerId).Remove(roleId);
					return;
				}
				data.DangoLevel = dangoAbyssRoleData.GetLevel();
				data.DangoEquipIds = dangoAbyssRoleData.GetEquipItemConfigIdList();
			}
		}
	}

	// Token: 0x0600C518 RID: 50456 RVA: 0x00340170 File Offset: 0x0033E370
	[return: Nullable(2)]
	public AbyssMatchChangeRoleContext GetMatchDangoRoleOwnData(int playerId, List<int> roleIdList)
	{
		AbyssMatchChangeRoleContext abyssMatchChangeRoleContext = AbyssMatchChangeRoleContext.Create();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (int num in roleIdList)
		{
			AbyssDangoOwnerData roleOwnerData = this.GetRoleOwnerData(playerId, num);
			dictionary[num] = ((roleOwnerData != null) ? roleOwnerData.DangoId : 0);
		}
		abyssMatchChangeRoleContext.RoleEquipMap.Add(dictionary);
		return abyssMatchChangeRoleContext;
	}

	// Token: 0x0600C519 RID: 50457 RVA: 0x003401F0 File Offset: 0x0033E3F0
	public AbyssDangoRoleData[] GetAllDangoList()
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			return Array.Empty<AbyssDangoRoleData>();
		}
		return currentOpenAbyssActivityData.GetAllDangoList();
	}

	// Token: 0x0600C51A RID: 50458 RVA: 0x00340214 File Offset: 0x0033E414
	[NullableContext(2)]
	public global::AbyssPluginItemInfo GetPluginItemInfoById(int incId)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			return null;
		}
		return currentOpenAbyssActivityData.GetPluginItemInfoById(incId);
	}

	// Token: 0x0600C51B RID: 50459 RVA: 0x00340234 File Offset: 0x0033E434
	public AbyssItem? GetPluginItemConfigByIncId(int incId)
	{
		global::AbyssPluginItemInfo pluginItemInfoById = this.GetPluginItemInfoById(incId);
		if (pluginItemInfoById == null)
		{
			return null;
		}
		return pluginItemInfoById.GetConfig().As<AbyssItem>();
	}

	// Token: 0x0600C51C RID: 50460 RVA: 0x00340260 File Offset: 0x0033E460
	public global::AbyssPluginItemInfo[] GetPluginItemListByType(DangoAbyssDefine.ESlotType slotType)
	{
		global::AbyssPluginItemInfo[] allPluginItemList = this.GetAllPluginItemList();
		List<global::AbyssPluginItemInfo> list = new List<global::AbyssPluginItemInfo>();
		foreach (global::AbyssPluginItemInfo abyssPluginItemInfo in allPluginItemList)
		{
			if (abyssPluginItemInfo.GetConfig().As<AbyssItem>().Value.SlotType == (int)slotType)
			{
				list.Add(abyssPluginItemInfo);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600C51D RID: 50461 RVA: 0x003402BC File Offset: 0x0033E4BC
	public global::AbyssPluginItemInfo[] GetAllPluginItemList()
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			return Array.Empty<global::AbyssPluginItemInfo>();
		}
		return currentOpenAbyssActivityData.GetPluginItemInfoAll();
	}

	// Token: 0x0600C51E RID: 50462 RVA: 0x003402E0 File Offset: 0x0033E4E0
	public void InitCacheDangoOwnerMap()
	{
		this.DangoOwnerMap.Clear();
		foreach (KeyValuePair<int, Dictionary<int, AbyssDangoOwnerData>> keyValuePair in this.GetCacheDangoOwnerMap())
		{
			foreach (KeyValuePair<int, AbyssDangoOwnerData> keyValuePair2 in keyValuePair.Value)
			{
				if (keyValuePair2.Value.DangoId != 0 && !this.GetDangoAbyssRoleData(keyValuePair2.Value.DangoId).GetIfLock())
				{
					this.DangoOwnerMap[keyValuePair.Key] = keyValuePair.Value;
				}
			}
		}
	}

	// Token: 0x0600C51F RID: 50463 RVA: 0x003403B8 File Offset: 0x0033E5B8
	public Dictionary<int, Dictionary<int, AbyssDangoOwnerData>> GetCacheDangoOwnerMap()
	{
		return LocalStorage.GetPlayer<Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>>(ELocalStoragePlayerKey.AbyssDangoFormationSelect, null) ?? new Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>();
	}

	// Token: 0x0600C520 RID: 50464 RVA: 0x003403CC File Offset: 0x0033E5CC
	public void SaveCacheDangoOwnerMap()
	{
		Dictionary<int, Dictionary<int, AbyssDangoOwnerData>> dictionary = new Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>();
		foreach (KeyValuePair<int, Dictionary<int, AbyssDangoOwnerData>> keyValuePair in this.DangoOwnerMap)
		{
			if (keyValuePair.Key == ModelBase<PlayerInfoModel>.Instance.GetId().Value)
			{
				Dictionary<int, AbyssDangoOwnerData> dictionary2 = new Dictionary<int, AbyssDangoOwnerData>();
				foreach (KeyValuePair<int, AbyssDangoOwnerData> keyValuePair2 in keyValuePair.Value)
				{
					dictionary2[keyValuePair2.Key] = keyValuePair2.Value;
				}
				dictionary[keyValuePair.Key] = dictionary2;
			}
		}
		LocalStorage.SetPlayer<Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>>(ELocalStoragePlayerKey.AbyssDangoFormationSelect, dictionary);
	}

	// Token: 0x0600C521 RID: 50465 RVA: 0x003404AC File Offset: 0x0033E6AC
	public bool CheckInDangoAbyssInstance()
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		if (instanceId == 0)
		{
			return false;
		}
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		return config != null && config.GetValueOrDefault().InstSubType == 33;
	}

	// Token: 0x0600C522 RID: 50466 RVA: 0x003404FC File Offset: 0x0033E6FC
	public bool CheckIfInSmallWorldInstance()
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		if (instanceId == 0)
		{
			return false;
		}
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		return config != null && config.GetValueOrDefault().InstSubType == 12 && (config != null && config.GetValueOrDefault().WorldDungeonSubType == 1);
	}

	// Token: 0x0600C523 RID: 50467 RVA: 0x0034056C File Offset: 0x0033E76C
	public DangoAbyssDefine.EAbyssItemTipsState GetDangoAbyssItemTipsConfirmState(DangoAbyssDefine.IAbyssItemTipsData data)
	{
		if (data.IncId == 0 || data.DangoId < 0 || data.SlotIndex < 0)
		{
			return DangoAbyssDefine.EAbyssItemTipsState.None;
		}
		AbyssItem value = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(data.IncId).GetConfig().As<AbyssItem>().Value;
		DangoAbyssDefine.ESlotType slotTypeByIndex = ConfigBase<DangoAbyssConfig>.Instance.GetSlotTypeByIndex(data.SlotIndex);
		if (value.SlotType != (int)slotTypeByIndex)
		{
			return DangoAbyssDefine.EAbyssItemTipsState.None;
		}
		int dangoItemBelongId = ModelBase<DangoAbyssModel>.Instance.GetDangoItemBelongId(data.IncId);
		if (dangoItemBelongId != 0 && data.DangoId != dangoItemBelongId && value.SlotType == 1)
		{
			return DangoAbyssDefine.EAbyssItemTipsState.ErrorDango;
		}
		if (this.CheckLimitPassiveSame(data))
		{
			return DangoAbyssDefine.EAbyssItemTipsState.Same;
		}
		if (this.CheckLimitPassiveRepeat(data))
		{
			return DangoAbyssDefine.EAbyssItemTipsState.Repeat;
		}
		return this.GetItemTipsAvailableConfirmState(data);
	}

	// Token: 0x0600C524 RID: 50468 RVA: 0x00340624 File Offset: 0x0033E824
	private bool CheckLimitPassiveSame(DangoAbyssDefine.IAbyssItemTipsData data)
	{
		global::AbyssPluginItemInfo pluginItemInfoById = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(data.IncId);
		AbyssItem value = pluginItemInfoById.GetConfig().As<AbyssItem>().Value;
		int belongRole = pluginItemInfoById.GetBelongRole();
		bool flag = value.SlotType == 2 && belongRole > 0;
		return belongRole == data.DangoId && flag;
	}

	// Token: 0x0600C525 RID: 50469 RVA: 0x00340680 File Offset: 0x0033E880
	private bool CheckLimitPassiveRepeat(DangoAbyssDefine.IAbyssItemTipsData data)
	{
		int roleId = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(data.IncId).GetRoleId();
		bool flag = roleId > 0 && roleId == data.DangoId;
		int[] equipItems = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(data.DangoId).GetEquipItems();
		ValueTuple<bool, int> valueTuple = this.CheckRepeatPassivePlugin(equipItems, data.IncId);
		return valueTuple.Item1 && valueTuple.Item2 != data.SlotIndex && !flag;
	}

	// Token: 0x0600C526 RID: 50470 RVA: 0x003406F4 File Offset: 0x0033E8F4
	private DangoAbyssDefine.EAbyssItemTipsState GetItemTipsAvailableConfirmState(DangoAbyssDefine.IAbyssItemTipsData data)
	{
		global::AbyssPluginItemInfo pluginItemInfoById = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(data.IncId);
		AbyssItem value = pluginItemInfoById.GetConfig().As<AbyssItem>().Value;
		int roleId = pluginItemInfoById.GetRoleId();
		int pluginItemIncIdBySlotIndex = this.GetPluginItemIncIdBySlotIndex(data.DangoId, data.SlotIndex);
		if (roleId > 0 && roleId != data.DangoId)
		{
			return DangoAbyssDefine.EAbyssItemTipsState.DiffDango;
		}
		if (roleId > 0 && roleId == data.DangoId)
		{
			if (pluginItemIncIdBySlotIndex > 0 && pluginItemIncIdBySlotIndex == data.IncId)
			{
				return DangoAbyssDefine.EAbyssItemTipsState.TakeOff;
			}
			if (pluginItemIncIdBySlotIndex > 0 && pluginItemIncIdBySlotIndex != data.IncId)
			{
				return DangoAbyssDefine.EAbyssItemTipsState.Switch;
			}
			return DangoAbyssDefine.EAbyssItemTipsState.Move;
		}
		else
		{
			int belongRole = pluginItemInfoById.GetBelongRole();
			if (value.SlotType == 2 && belongRole > 0)
			{
				return this.GetLimitPassiveItemTipsConfirmState(data);
			}
			if (roleId != 0)
			{
				return DangoAbyssDefine.EAbyssItemTipsState.None;
			}
			if (pluginItemIncIdBySlotIndex > 0)
			{
				return DangoAbyssDefine.EAbyssItemTipsState.Replace;
			}
			return DangoAbyssDefine.EAbyssItemTipsState.PutOn;
		}
	}

	// Token: 0x0600C527 RID: 50471 RVA: 0x003407B0 File Offset: 0x0033E9B0
	private DangoAbyssDefine.EAbyssItemTipsState GetLimitPassiveItemTipsConfirmState(DangoAbyssDefine.IAbyssItemTipsData data)
	{
		int pluginItemIncIdBySlotIndex = this.GetPluginItemIncIdBySlotIndex(data.DangoId, data.SlotIndex);
		if (ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(data.IncId).GetBelongRole() == data.DangoId)
		{
			return DangoAbyssDefine.EAbyssItemTipsState.Same;
		}
		int[] equipItems = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(data.DangoId).GetEquipItems();
		ValueTuple<bool, int> valueTuple = this.CheckRepeatPassivePlugin(equipItems, data.IncId);
		if (!valueTuple.Item1)
		{
			if (pluginItemIncIdBySlotIndex > 0)
			{
				return DangoAbyssDefine.EAbyssItemTipsState.Replace;
			}
			return DangoAbyssDefine.EAbyssItemTipsState.PutOn;
		}
		else
		{
			if (valueTuple.Item2 == data.SlotIndex)
			{
				return DangoAbyssDefine.EAbyssItemTipsState.Replace;
			}
			return DangoAbyssDefine.EAbyssItemTipsState.Repeat;
		}
	}

	// Token: 0x0600C528 RID: 50472 RVA: 0x00340838 File Offset: 0x0033EA38
	[NullableContext(0)]
	private ValueTuple<bool, int> CheckRepeatPassivePlugin([Nullable(1)] int[] incIdList, int newIncId)
	{
		int belongRole = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(newIncId).GetBelongRole();
		for (int i = 0; i < incIdList.Length; i++)
		{
			int num = incIdList[i];
			if (num > 0)
			{
				global::AbyssPluginItemInfo pluginItemInfoById = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(num);
				int belongRole2 = pluginItemInfoById.GetBelongRole();
				if (pluginItemInfoById.GetConfig().As<AbyssItem>().Value.SlotType == 2 && belongRole2 > 0 && belongRole2 == belongRole)
				{
					return new ValueTuple<bool, int>(true, i);
				}
			}
		}
		return new ValueTuple<bool, int>(false, -1);
	}

	// Token: 0x0600C529 RID: 50473 RVA: 0x003408B4 File Offset: 0x0033EAB4
	private int[] SwitchIndexWithValue(int[] list, int value, int newIndex)
	{
		int num = -1;
		int num2 = list[newIndex];
		for (int i = 0; i < list.Length; i++)
		{
			if (list[i] == value)
			{
				num = i;
			}
		}
		list[newIndex] = value;
		list[num] = num2;
		return list;
	}

	// Token: 0x0600C52A RID: 50474 RVA: 0x003408E8 File Offset: 0x0033EAE8
	public unsafe int[] GetDangoAbyssItemNewEquip(DangoAbyssDefine.IAbyssItemTipsData data, DangoAbyssDefine.EAbyssItemTipsState state)
	{
		List<int> list = new List<int>(ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(data.DangoId).GetEquipItems());
		int slotIndex = data.SlotIndex;
		if (state == DangoAbyssDefine.EAbyssItemTipsState.DiffDango || state == DangoAbyssDefine.EAbyssItemTipsState.Replace || state == DangoAbyssDefine.EAbyssItemTipsState.PutOn)
		{
			list[slotIndex] = data.IncId;
		}
		else if (state == DangoAbyssDefine.EAbyssItemTipsState.Switch || state == DangoAbyssDefine.EAbyssItemTipsState.Move)
		{
			list = new List<int>(this.SwitchIndexWithValue(list.ToArray(), data.IncId, slotIndex));
		}
		else if (state == DangoAbyssDefine.EAbyssItemTipsState.TakeOff)
		{
			list[slotIndex] = 0;
		}
		else
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.WDX;
			string message = "非法的插件装备状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("dangoId", data.DangoId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("state", (int)state);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return list.ToArray();
	}

	// Token: 0x0600C52B RID: 50475 RVA: 0x003409D1 File Offset: 0x0033EBD1
	public int GetPluginItemIncIdBySlotIndex(int roleId, int slotIndex)
	{
		AbyssDangoRoleSlotData pluginSlotData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(roleId).GetPluginSlotData(slotIndex);
		if (pluginSlotData == null)
		{
			return 0;
		}
		return pluginSlotData.GetIncId();
	}

	// Token: 0x0600C52C RID: 50476 RVA: 0x003409F0 File Offset: 0x0033EBF0
	public int GetSlotUnlockLevel(int dangoId, int slotIndex)
	{
		AbyssDangoRoleData dangoAbyssRoleData = this.GetDangoAbyssRoleData(dangoId);
		int slotUnlockCount = this.GetSlotUnlockCount(slotIndex);
		foreach (AbyssRoleLevel abyssRoleLevel in dangoAbyssRoleData.GetLevelGroupConfigs())
		{
			if (abyssRoleLevel.PluginNum == slotUnlockCount)
			{
				return abyssRoleLevel.Level;
			}
		}
		return -1;
	}

	// Token: 0x0600C52D RID: 50477 RVA: 0x00340A5C File Offset: 0x0033EC5C
	private int GetSlotUnlockCount(int slotIndex)
	{
		if (slotIndex == 0)
		{
			return 9;
		}
		return slotIndex;
	}

	// Token: 0x0600C52E RID: 50478 RVA: 0x00340A68 File Offset: 0x0033EC68
	public bool GetSlotLockState(int dangoId, int slotIndex)
	{
		AbyssDangoRoleData dangoAbyssRoleData = this.GetDangoAbyssRoleData(dangoId);
		if (dangoAbyssRoleData == null || dangoAbyssRoleData.GetIfLock())
		{
			return true;
		}
		AbyssRoleLevel? levelConfig = dangoAbyssRoleData.GetLevelConfig();
		int slotUnlockCount = this.GetSlotUnlockCount(slotIndex);
		return levelConfig.Value.PluginNum < slotUnlockCount;
	}

	// Token: 0x0600C52F RID: 50479 RVA: 0x00340AAC File Offset: 0x0033ECAC
	public string GetPluginItemQualityIcon(int itemId)
	{
		AbyssItem? dangoItemById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoItemById(itemId);
		if (dangoItemById == null)
		{
			return "";
		}
		AbyssQuality? abyssQualityById = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityById(dangoItemById.Value.QualityId);
		if (abyssQualityById == null)
		{
			return "";
		}
		string result = abyssQualityById.Value.AbyssItemBg;
		int slotType = dangoItemById.Value.SlotType;
		if (slotType != 1)
		{
			if (slotType == 2)
			{
				result = abyssQualityById.Value.AbyssPassiveItemBg;
			}
		}
		else
		{
			result = abyssQualityById.Value.AbyssCoreItemBg;
		}
		return result;
	}

	// Token: 0x0600C530 RID: 50480 RVA: 0x00340B50 File Offset: 0x0033ED50
	public bool IsPluginHasValidTag(int roleId, global::AbyssPluginItemInfo item)
	{
		Dictionary<int, int> dictionary = this.GetPluginItemConfigByIncId(item.GetUniqueId()).Value.AddTag();
		if (dictionary.Count > 0)
		{
			foreach (int tagId in dictionary.Keys)
			{
				if (this.IsTagTypeCorrect(roleId, tagId, DangoAbyssDefine.ETagDataGetType.Valid))
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x0600C531 RID: 50481 RVA: 0x00340BD8 File Offset: 0x0033EDD8
	private bool IsTagTypeCorrect(int roleId, int tagId, DangoAbyssDefine.ETagDataGetType getType)
	{
		AbyssPluginPropDesc? dangoPluginPropDescById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoPluginPropDescById(tagId);
		AbyssDangoRoleData dangoAbyssRoleData = this.GetDangoAbyssRoleData(roleId);
		if (dangoPluginPropDescById == null || dangoAbyssRoleData == null)
		{
			return false;
		}
		int addType = dangoPluginPropDescById.Value.AddType;
		int[] array = dangoAbyssRoleData.GetConfig().Value.TagList();
		if (addType == 5 || addType == 4)
		{
			return getType != DangoAbyssDefine.ETagDataGetType.InValid;
		}
		bool flag = false;
		int[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			if (array2[i] == tagId)
			{
				flag = true;
				break;
			}
		}
		return (flag && getType != DangoAbyssDefine.ETagDataGetType.InValid) || (!flag && getType == DangoAbyssDefine.ETagDataGetType.InValid);
	}

	// Token: 0x0600C532 RID: 50482 RVA: 0x00340C80 File Offset: 0x0033EE80
	private Dictionary<int, int> AddTagsToMap(Dictionary<int, int> map, Dictionary<int, int> tags)
	{
		foreach (KeyValuePair<int, int> keyValuePair in tags)
		{
			if (map.ContainsKey(keyValuePair.Key))
			{
				map[keyValuePair.Key] = map[keyValuePair.Key] + keyValuePair.Value;
			}
			else
			{
				map[keyValuePair.Key] = keyValuePair.Value;
			}
		}
		return map;
	}

	// Token: 0x0600C533 RID: 50483 RVA: 0x00340D10 File Offset: 0x0033EF10
	public DangoAbyssDefine.DangoAbyssTagData[] GetDangoTagData(int roleId, DangoAbyssDefine.ETagDataGetType getType)
	{
		AbyssDangoRoleData dangoAbyssRoleData = this.GetDangoAbyssRoleData(roleId);
		AbyssLittleRole? config = dangoAbyssRoleData.GetConfig();
		int[] equipItems = dangoAbyssRoleData.GetEquipItems();
		int[] array = config.Value.TagList();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		if (array.Length != 0 && getType != DangoAbyssDefine.ETagDataGetType.InValid)
		{
			foreach (int key in array)
			{
				dictionary[key] = 0;
			}
		}
		foreach (int num in equipItems)
		{
			if (num > 0)
			{
				Dictionary<int, int> dictionary2 = this.GetPluginItemConfigByIncId(num).Value.AddTag();
				if (dictionary2.Count > 0)
				{
					dictionary = this.AddTagsToMap(dictionary, dictionary2);
				}
			}
		}
		List<DangoAbyssDefine.DangoAbyssTagData> list = new List<DangoAbyssDefine.DangoAbyssTagData>();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			if (this.IsTagTypeCorrect(roleId, keyValuePair.Key, getType))
			{
				list.Add(new DangoAbyssDefine.DangoAbyssTagData
				{
					TagId = keyValuePair.Key,
					Value = keyValuePair.Value
				});
			}
		}
		list.Sort(delegate(DangoAbyssDefine.DangoAbyssTagData dataA, DangoAbyssDefine.DangoAbyssTagData dataB)
		{
			AbyssPluginPropDesc? dangoPluginPropDescById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoPluginPropDescById(dataA.TagId);
			return ConfigBase<DangoAbyssConfig>.Instance.GetDangoPluginPropDescById(dataB.TagId).Value.AddType - dangoPluginPropDescById.Value.AddType;
		});
		return list.ToArray();
	}

	// Token: 0x0600C534 RID: 50484 RVA: 0x00340E78 File Offset: 0x0033F078
	private bool CheckOverMaxValue(int value, int maxValue)
	{
		if (maxValue < 0)
		{
			return value < maxValue;
		}
		return value > maxValue;
	}

	// Token: 0x0600C535 RID: 50485 RVA: 0x00340E88 File Offset: 0x0033F088
	public string GetFormatAttributeValueByTagId(int value, int tagId, bool? hideMax = null)
	{
		AbyssPluginPropDesc? dangoPluginPropDescById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoPluginPropDescById(tagId);
		if (dangoPluginPropDescById == null)
		{
			return "";
		}
		if (dangoPluginPropDescById.Value.AddType == 5)
		{
			AbyssDangoRoleData dangoAbyssRoleData = this.GetDangoAbyssRoleData(value);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (dangoAbyssRoleData != null && dangoAbyssRoleData.GetConfig() != null)
			{
				string result;
				if ((result = ConfigMultiTextLang.GetLocalTextNew(dangoAbyssRoleData.GetConfig().Value.Name, null)) == null)
				{
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
					defaultInterpolatedStringHandler.AppendLiteral("id");
					defaultInterpolatedStringHandler.AppendFormatted<int>(value);
					result = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				return result;
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
			defaultInterpolatedStringHandler.AppendLiteral("id");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		else
		{
			string id = dangoPluginPropDescById.Value.TextFormat;
			if (hideMax.GetValueOrDefault() || dangoPluginPropDescById.Value.AddType == 4)
			{
				id = dangoPluginPropDescById.Value.NoMaxTextFormat;
			}
			else if (this.CheckOverMaxValue(value, dangoPluginPropDescById.Value.MaxValue))
			{
				id = dangoPluginPropDescById.Value.MaxTextFormat;
			}
			string text = value.ToString();
			string text2 = dangoPluginPropDescById.Value.MaxValue.ToString();
			if (dangoPluginPropDescById.Value.AddType == 1)
			{
				text = TipsDataTool.GetPropRatioValue((double)value, false).ToString();
				text2 = TipsDataTool.GetPropRatioValue((double)dangoPluginPropDescById.Value.MaxValue, false).ToString();
			}
			else if (dangoPluginPropDescById.Value.AddType == 2)
			{
				text = TipsDataTool.GetPropRatioValue((double)value, true).ToString();
				text2 = TipsDataTool.GetPropRatioValue((double)dangoPluginPropDescById.Value.MaxValue, true).ToString();
			}
			string result2 = "";
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(id, null);
			if (string.IsNullOrEmpty(localTextNew))
			{
				return result2;
			}
			if (hideMax.GetValueOrDefault())
			{
				result2 = StringUtils.Format(localTextNew, new string[]
				{
					text
				});
			}
			else
			{
				result2 = StringUtils.Format(localTextNew, new string[]
				{
					text,
					text2
				});
			}
			return result2;
		}
	}

	// Token: 0x0600C536 RID: 50486 RVA: 0x003410C0 File Offset: 0x0033F2C0
	[NullableContext(2)]
	public DangoAbyssDefine.ESlotSwitchType GetSlotSwitchTypeByData(AbyssDangoRoleSlotData oldData, AbyssDangoRoleSlotData newData)
	{
		if (newData == null || oldData == newData)
		{
			return DangoAbyssDefine.ESlotSwitchType.None;
		}
		int num = (oldData != null) ? oldData.GetIncId() : 0;
		int num2 = (newData != null) ? newData.GetIncId() : 0;
		if (num <= 0 && num2 > 0)
		{
			return DangoAbyssDefine.ESlotSwitchType.PutOn;
		}
		if (num > 0 && num2 <= 0)
		{
			return DangoAbyssDefine.ESlotSwitchType.TakeOff;
		}
		if (num > 0 && num2 > 0 && num != num2)
		{
			return DangoAbyssDefine.ESlotSwitchType.Replace;
		}
		return DangoAbyssDefine.ESlotSwitchType.None;
	}

	// Token: 0x0600C537 RID: 50487 RVA: 0x00341114 File Offset: 0x0033F314
	public ConfigPropValue[] GetDangoAddPropData(int roleId)
	{
		int[] equipItems = this.GetDangoAbyssRoleData(roleId).GetEquipItems();
		List<ConfigPropValue> list = new List<ConfigPropValue>();
		foreach (int num in equipItems)
		{
			if (num > 0)
			{
				foreach (ConfigPropValue item in this.GetPluginItemConfigByIncId(num).Value.Prop())
				{
					list.Add(item);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600C538 RID: 50488 RVA: 0x00341194 File Offset: 0x0033F394
	public ConfigPropValue[] GetDangoBaseProp(int roleId)
	{
		return this.GetDangoAbyssRoleData(roleId).GetLevelConfig().Value.Prop();
	}

	// Token: 0x0600C539 RID: 50489 RVA: 0x003411C0 File Offset: 0x0033F3C0
	public AttrListScrollData[] GetDangoShowAttributeList(int roleId)
	{
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		ConfigPropValue[] dangoBaseProp = this.GetDangoBaseProp(roleId);
		ConfigPropValue[] dangoAddPropData = this.GetDangoAddPropData(roleId);
		foreach (ConfigPropValue configPropValue in dangoBaseProp)
		{
			double propRatioValue = TipsDataTool.GetPropRatioValue((double)configPropValue.Value, configPropValue.IsRatio);
			list.Add(new RoleAttrListScrollData(configPropValue.Id, propRatioValue, 0.0, 0, configPropValue.IsRatio, CommonComponentDefine.EAttributeType.NormalType));
		}
		foreach (ConfigPropValue configPropValue2 in dangoAddPropData)
		{
			bool flag = false;
			double propRatioValue2 = TipsDataTool.GetPropRatioValue((double)configPropValue2.Value, configPropValue2.IsRatio);
			foreach (AttrListScrollData attrListScrollData in list)
			{
				if (attrListScrollData.Id == configPropValue2.Id && attrListScrollData.IsRatio == configPropValue2.IsRatio)
				{
					attrListScrollData.AddValue += propRatioValue2;
					flag = true;
				}
			}
			if (!flag)
			{
				list.Add(new RoleAttrListScrollData(configPropValue2.Id, 0.0, propRatioValue2, 0, configPropValue2.IsRatio, CommonComponentDefine.EAttributeType.NormalType));
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600C53A RID: 50490 RVA: 0x00341310 File Offset: 0x0033F510
	private AttrListScrollData[] GetEquipViewAttributeScrollData(int roleId)
	{
		ConfigPropValue[] dangoAddPropData = this.GetDangoAddPropData(roleId);
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		foreach (ConfigPropValue configPropValue in dangoAddPropData)
		{
			bool flag = false;
			foreach (AttrListScrollData attrListScrollData in list)
			{
				if (attrListScrollData.Id == configPropValue.Id && attrListScrollData.IsRatio == configPropValue.IsRatio)
				{
					attrListScrollData.AddValue += (double)configPropValue.Value;
					flag = true;
				}
			}
			if (!flag)
			{
				list.Add(new AttrListScrollData(configPropValue.Id, 0.0, (double)configPropValue.Value, 0, configPropValue.IsRatio, CommonComponentDefine.EAttributeType.NormalType));
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600C53B RID: 50491 RVA: 0x003413F8 File Offset: 0x0033F5F8
	public List<DangoAbyssDefine.EquipViewAttributeData> GetEquipViewAttributeDataById(int roleId)
	{
		DangoAbyssDefine.EquipViewAttributeData equipViewAttributeData = new DangoAbyssDefine.EquipViewAttributeData();
		equipViewAttributeData.IsValid = true;
		AttrListScrollData[] equipViewAttributeScrollData = this.GetEquipViewAttributeScrollData(roleId);
		DangoAbyssDefine.DangoAbyssTagData[] dangoTagData = this.GetDangoTagData(roleId, DangoAbyssDefine.ETagDataGetType.Valid);
		List<DangoAbyssDefine.EquipViewAttributeData> list = new List<DangoAbyssDefine.EquipViewAttributeData>();
		if (equipViewAttributeScrollData.Length + dangoTagData.Length > 0)
		{
			list = new List<DangoAbyssDefine.EquipViewAttributeData>
			{
				equipViewAttributeData
			};
			foreach (DangoAbyssDefine.DangoAbyssTagData tag in dangoTagData)
			{
				list.Add(new DangoAbyssDefine.EquipViewAttributeData
				{
					IsValid = true,
					Tag = tag
				});
			}
			foreach (AttrListScrollData attribute in equipViewAttributeScrollData)
			{
				list.Add(new DangoAbyssDefine.EquipViewAttributeData
				{
					IsValid = true,
					Attribute = attribute
				});
			}
		}
		DangoAbyssDefine.EquipViewAttributeData equipViewAttributeData2 = new DangoAbyssDefine.EquipViewAttributeData();
		equipViewAttributeData2.IsValid = false;
		DangoAbyssDefine.DangoAbyssTagData[] dangoTagData2 = this.GetDangoTagData(roleId, DangoAbyssDefine.ETagDataGetType.InValid);
		List<DangoAbyssDefine.EquipViewAttributeData> list2 = new List<DangoAbyssDefine.EquipViewAttributeData>();
		if (dangoTagData2.Length != 0)
		{
			list2 = new List<DangoAbyssDefine.EquipViewAttributeData>
			{
				equipViewAttributeData2
			};
			foreach (DangoAbyssDefine.DangoAbyssTagData tag2 in dangoTagData2)
			{
				list2.Add(new DangoAbyssDefine.EquipViewAttributeData
				{
					IsValid = false,
					Tag = tag2
				});
			}
		}
		List<DangoAbyssDefine.EquipViewAttributeData> list3 = new List<DangoAbyssDefine.EquipViewAttributeData>(list2);
		list3.AddRange(list);
		return list3;
	}

	// Token: 0x0600C53C RID: 50492 RVA: 0x00341540 File Offset: 0x0033F740
	private bool GetSameIdDataInList(List<DangoAbyssDefine.EquipViewAttributeData> dataList, int checkId, float checkValue, bool isTag)
	{
		foreach (DangoAbyssDefine.EquipViewAttributeData equipViewAttributeData in dataList)
		{
			DangoAbyssDefine.DangoAbyssTagData tag = equipViewAttributeData.Tag;
			int? num = (tag != null) ? new int?(tag.TagId) : null;
			AttrListScrollData attribute = equipViewAttributeData.Attribute;
			int? num2 = (attribute != null) ? new int?(attribute.Id) : null;
			if (!isTag)
			{
				int? num3 = num2;
				if (num3.GetValueOrDefault() == checkId & num3 != null)
				{
					AttrListScrollData attribute2 = equipViewAttributeData.Attribute;
					double? num4 = (attribute2 != null) ? new double?(attribute2.AddValue) : null;
					double num5 = (double)checkValue;
					return num4.GetValueOrDefault() == num5 & num4 != null;
				}
			}
			if (isTag)
			{
				int? num3 = num;
				if (num3.GetValueOrDefault() == checkId & num3 != null)
				{
					DangoAbyssDefine.DangoAbyssTagData tag2 = equipViewAttributeData.Tag;
					num3 = ((tag2 != null) ? new int?(tag2.Value) : null);
					float? num6 = (num3 != null) ? new float?((float)num3.GetValueOrDefault()) : null;
					return num6.GetValueOrDefault() == checkValue & num6 != null;
				}
			}
		}
		return false;
	}

	// Token: 0x0600C53D RID: 50493 RVA: 0x003416C0 File Offset: 0x0033F8C0
	public List<DangoAbyssDefine.EquipViewAttributeData> SetEquipViewAttributeType(List<DangoAbyssDefine.EquipViewAttributeData> oldList, List<DangoAbyssDefine.EquipViewAttributeData> newList)
	{
		foreach (DangoAbyssDefine.EquipViewAttributeData equipViewAttributeData in newList)
		{
			equipViewAttributeData.IsChange = false;
			if (equipViewAttributeData.Attribute != null || equipViewAttributeData.Tag != null)
			{
				int checkId = 0;
				bool isTag = false;
				float checkValue = 0f;
				if (equipViewAttributeData.Attribute != null)
				{
					checkId = equipViewAttributeData.Attribute.Id;
					isTag = false;
					checkValue = (float)equipViewAttributeData.Attribute.AddValue;
				}
				else if (equipViewAttributeData.Tag != null)
				{
					checkId = equipViewAttributeData.Tag.TagId;
					isTag = true;
					checkValue = (float)equipViewAttributeData.Tag.Value;
				}
				bool sameIdDataInList = this.GetSameIdDataInList(oldList, checkId, checkValue, isTag);
				equipViewAttributeData.IsChange = !sameIdDataInList;
			}
		}
		return newList;
	}

	// Token: 0x0600C53E RID: 50494 RVA: 0x00341794 File Offset: 0x0033F994
	[NullableContext(2)]
	public string GetSlotTypeTextIdBySlotIndex(int slotIndex)
	{
		DangoAbyssDefine.ESlotType slotTypeByIndex = ConfigBase<DangoAbyssConfig>.Instance.GetSlotTypeByIndex(slotIndex);
		string result;
		if (DangoAbyssDefine.textSlotType.TryGetValue(slotTypeByIndex, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600C53F RID: 50495 RVA: 0x003417C0 File Offset: 0x0033F9C0
	public global::AbyssPluginItemInfo[] GetPluginItemListBySlotIndex(int slotIndex)
	{
		DangoAbyssDefine.ESlotType slotTypeByIndex = ConfigBase<DangoAbyssConfig>.Instance.GetSlotTypeByIndex(slotIndex);
		return ModelBase<DangoAbyssModel>.Instance.GetPluginItemListByType(slotTypeByIndex);
	}

	// Token: 0x0600C540 RID: 50496 RVA: 0x003417E4 File Offset: 0x0033F9E4
	public bool GetIfSlotTypeChange(int slotIndexOld, int slotIndexNew)
	{
		if (slotIndexOld < 0)
		{
			return true;
		}
		DangoAbyssDefine.ESlotType slotTypeByIndex = ConfigBase<DangoAbyssConfig>.Instance.GetSlotTypeByIndex(slotIndexOld);
		DangoAbyssDefine.ESlotType slotTypeByIndex2 = ConfigBase<DangoAbyssConfig>.Instance.GetSlotTypeByIndex(slotIndexNew);
		return slotTypeByIndex != slotTypeByIndex2;
	}

	// Token: 0x0600C541 RID: 50497 RVA: 0x00341814 File Offset: 0x0033FA14
	public int GetPluginItemPackageCapacity()
	{
		InventoryDefine.EItemMainTypeId itemTypeId = InventoryDefine.EItemMainTypeId.DangoPluginItem;
		int packageId = ConfigBase<InventoryConfig>.Instance.GetItemMainTypeConfig((int)itemTypeId).Value.PackageId;
		return ConfigBase<InventoryConfig>.Instance.GetPackageConfig(packageId).Value.Capacity;
	}

	// Token: 0x0600C542 RID: 50498 RVA: 0x00341860 File Offset: 0x0033FA60
	public void SaveFormationSelectRole(int challengeId, List<int> roleId)
	{
		Dictionary<int, int[]> dictionary = LocalStorage.GetPlayer<Dictionary<int, int[]>>(ELocalStoragePlayerKey.AbyssSelectRole, null) ?? new Dictionary<int, int[]>();
		dictionary[challengeId] = roleId.ToArray();
		LocalStorage.SetPlayer<Dictionary<int, int[]>>(ELocalStoragePlayerKey.AbyssSelectRole, dictionary);
	}

	// Token: 0x0600C543 RID: 50499 RVA: 0x0034189C File Offset: 0x0033FA9C
	public int[] GetFormationSelectRoleList(int challengeId)
	{
		int[] result;
		if ((LocalStorage.GetPlayer<Dictionary<int, int[]>>(ELocalStoragePlayerKey.AbyssSelectRole, null) ?? new Dictionary<int, int[]>()).TryGetValue(challengeId, out result))
		{
			return result;
		}
		return Array.Empty<int>();
	}

	// Token: 0x0600C544 RID: 50500 RVA: 0x003418D0 File Offset: 0x0033FAD0
	public bool GetDangoIfLock(int roleId)
	{
		AbyssDangoRoleData dangoAbyssRoleData = this.GetDangoAbyssRoleData(roleId);
		return dangoAbyssRoleData == null || dangoAbyssRoleData.GetIfLock();
	}

	// Token: 0x0600C545 RID: 50501 RVA: 0x003418F0 File Offset: 0x0033FAF0
	public bool GetDangoDevelopRedDot()
	{
		return this.GetDangoNewRedDot() || this.GetDangoLevelUpRedDot(new bool?(true));
	}

	// Token: 0x0600C546 RID: 50502 RVA: 0x00341908 File Offset: 0x0033FB08
	public bool GetDangoRoleRedDot(int roleId)
	{
		return this.GetDangoNewRedDotById(roleId) || this.GetDangoLevelUpRedDotById(roleId, new bool?(true));
	}

	// Token: 0x0600C547 RID: 50503 RVA: 0x00341924 File Offset: 0x0033FB24
	public bool GetDangoFormationNewRedDot()
	{
		foreach (AbyssDangoRoleData abyssDangoRoleData in this.GetAllDangoList())
		{
			if (this.GetDangoFormationNewRoleRedDot(abyssDangoRoleData.GetId()))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600C548 RID: 50504 RVA: 0x0034195B File Offset: 0x0033FB5B
	public bool GetDangoFormationNewRoleRedDot(int roleId)
	{
		return this.GetDangoFormationNewRedDotById(roleId);
	}

	// Token: 0x0600C549 RID: 50505 RVA: 0x00341964 File Offset: 0x0033FB64
	public bool GetDangoNewRedDot()
	{
		foreach (AbyssDangoRoleData abyssDangoRoleData in this.GetAllDangoList())
		{
			if (this.GetDangoNewRedDotById(abyssDangoRoleData.GetId()))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600C54A RID: 50506 RVA: 0x0034199B File Offset: 0x0033FB9B
	public bool GetDangoNewRedDotById(int roleId)
	{
		return this.GetDangoAbyssRoleData(roleId) != null && this.GetDangoIfNew(roleId);
	}

	// Token: 0x0600C54B RID: 50507 RVA: 0x003419B2 File Offset: 0x0033FBB2
	public bool GetDangoFormationNewRedDotById(int roleId)
	{
		return this.GetDangoAbyssRoleData(roleId) != null && this.GetDangoFormationIfNew(roleId);
	}

	// Token: 0x0600C54C RID: 50508 RVA: 0x003419C9 File Offset: 0x0033FBC9
	public void SetDangoHasCheck(int roleId)
	{
		this.SetDangoIfNew(roleId, false);
		this.SetDangoLevelCheck(roleId);
	}

	// Token: 0x0600C54D RID: 50509 RVA: 0x003419DC File Offset: 0x0033FBDC
	public void SetDangoIfNew(int roleId, bool ifNew)
	{
		AbyssDangoRoleData dangoAbyssRoleData = this.GetDangoAbyssRoleData(roleId);
		if (dangoAbyssRoleData != null && !dangoAbyssRoleData.GetIfLock())
		{
			Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.AbyssDangoRoleNew, null) ?? new Dictionary<int, bool>();
			dictionary[roleId] = ifNew;
			LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.AbyssDangoRoleNew, dictionary);
		}
	}

	// Token: 0x0600C54E RID: 50510 RVA: 0x00341A28 File Offset: 0x0033FC28
	public bool GetDangoIfNew(int roleId)
	{
		AbyssDangoRoleData dangoAbyssRoleData = this.GetDangoAbyssRoleData(roleId);
		bool flag;
		return dangoAbyssRoleData != null && !dangoAbyssRoleData.GetIfLock() && (LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.AbyssDangoRoleNew, null) ?? new Dictionary<int, bool>()).TryGetValue(roleId, out flag) && flag;
	}

	// Token: 0x0600C54F RID: 50511 RVA: 0x00341A6B File Offset: 0x0033FC6B
	public bool GetAbyssDangoEnterNew()
	{
		return LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.AbyssDangoEnterNew, true);
	}

	// Token: 0x0600C550 RID: 50512 RVA: 0x00341A78 File Offset: 0x0033FC78
	public void SetAbyssDangoEnterNew(bool ifNew)
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.AbyssDangoEnterNew, ifNew);
	}

	// Token: 0x0600C551 RID: 50513 RVA: 0x00341A88 File Offset: 0x0033FC88
	public void SetDangoFormationIfNew(int dangoId, bool ifNew)
	{
		if (this.GetDangoAbyssRoleData(dangoId) != null)
		{
			Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.AbyssDangoFormationNew, null) ?? new Dictionary<int, bool>();
			dictionary[dangoId] = ifNew;
			LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.AbyssDangoFormationNew, dictionary);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshAbyssDangoRedDot, dangoId);
	}

	// Token: 0x0600C552 RID: 50514 RVA: 0x00341AD8 File Offset: 0x0033FCD8
	public bool GetDangoFormationIfNew(int dangoId)
	{
		bool flag;
		return this.GetDangoAbyssRoleData(dangoId) != null && (LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.AbyssDangoFormationNew, null) ?? new Dictionary<int, bool>()).TryGetValue(dangoId, out flag) && flag;
	}

	// Token: 0x0600C553 RID: 50515 RVA: 0x00341B14 File Offset: 0x0033FD14
	public void SetDangoLevelCheck(int roleId)
	{
		AbyssDangoRoleData dangoAbyssRoleData = this.GetDangoAbyssRoleData(roleId);
		bool dangoLevelUpRedDotById = this.GetDangoLevelUpRedDotById(roleId, new bool?(false));
		if (dangoAbyssRoleData == null || !dangoLevelUpRedDotById)
		{
			return;
		}
		int value = dangoAbyssRoleData.GetLevel() + 1;
		Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.AbyssDangoLevelCheck, null) ?? new Dictionary<int, int>();
		dictionary[roleId] = value;
		LocalStorage.SetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.AbyssDangoLevelCheck, dictionary);
	}

	// Token: 0x0600C554 RID: 50516 RVA: 0x00341B70 File Offset: 0x0033FD70
	public int GetDangoLastCheckLevel(int roleId)
	{
		int result;
		if ((LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.AbyssDangoLevelCheck, null) ?? new Dictionary<int, int>()).TryGetValue(roleId, out result))
		{
			return result;
		}
		return 1;
	}

	// Token: 0x0600C555 RID: 50517 RVA: 0x00341BA0 File Offset: 0x0033FDA0
	public bool GetDangoLevelUpRedDot(bool? needCheck = null)
	{
		foreach (AbyssDangoRoleData abyssDangoRoleData in this.GetAllDangoList())
		{
			if (this.GetDangoLevelUpRedDotById(abyssDangoRoleData.GetId(), needCheck))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600C556 RID: 50518 RVA: 0x00341BD8 File Offset: 0x0033FDD8
	public bool GetDangoLevelUpRedDotById(int roleId, bool? needCheck = null)
	{
		AbyssDangoRoleData dangoAbyssRoleData = this.GetDangoAbyssRoleData(roleId);
		if (dangoAbyssRoleData == null || dangoAbyssRoleData.GetIfLock())
		{
			return false;
		}
		bool ifCanLevelUp = dangoAbyssRoleData.GetIfCanLevelUp();
		bool ifLevelUpEnough = dangoAbyssRoleData.GetIfLevelUpEnough();
		return ifCanLevelUp && ifLevelUpEnough && (!needCheck.GetValueOrDefault() || this.GetDangoLastCheckLevel(roleId) < dangoAbyssRoleData.GetLevel() + 1);
	}

	// Token: 0x0600C557 RID: 50519 RVA: 0x00341C2C File Offset: 0x0033FE2C
	public Dictionary<int, int> GetRecoverySelectionCountMap(List<ISelectedData> dataList)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (ISelectedData selectedData in dataList)
		{
			AbyssItem? pluginItemConfigByIncId = this.GetPluginItemConfigByIncId(selectedData.IncId);
			if (pluginItemConfigByIncId != null)
			{
				int qualityId = pluginItemConfigByIncId.Value.QualityId;
				if (dictionary.ContainsKey(qualityId))
				{
					dictionary[qualityId]++;
				}
				else
				{
					dictionary[qualityId] = 1;
				}
			}
		}
		return dictionary;
	}

	// Token: 0x0600C558 RID: 50520 RVA: 0x00341CCC File Offset: 0x0033FECC
	public Dictionary<int, int> GetRecoveryTimesCountMap(Dictionary<int, int> qualityMap)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (KeyValuePair<int, int> keyValuePair in qualityMap)
		{
			double num = Math.Floor((double)keyValuePair.Value / 1.0);
			dictionary[keyValuePair.Key] = (int)num;
		}
		return dictionary;
	}

	// Token: 0x0600C559 RID: 50521 RVA: 0x00341D44 File Offset: 0x0033FF44
	public int GetRecoveryTimesCountAll(Dictionary<int, int> qualityMap)
	{
		int num = 0;
		foreach (KeyValuePair<int, int> keyValuePair in qualityMap)
		{
			num += (int)Math.Floor((double)keyValuePair.Value / 1.0);
		}
		return num;
	}

	// Token: 0x0600C55A RID: 50522 RVA: 0x00341DAC File Offset: 0x0033FFAC
	public Dictionary<int, int> GetRecoveryRewardItemMap(Dictionary<int, int> timesMap)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (KeyValuePair<int, int> keyValuePair in timesMap)
		{
			int value = keyValuePair.Value;
			int key = keyValuePair.Key;
			if (value > 0)
			{
				AbyssSynthesis? abyssSynthesisByQualityId = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssSynthesisByQualityId(key);
				if (abyssSynthesisByQualityId != null)
				{
					for (int i = 0; i < abyssSynthesisByQualityId.Value.DecomposeInfoLength; i++)
					{
						DicIntInt? dicIntInt = abyssSynthesisByQualityId.Value.DecomposeInfo(i);
						int key2 = dicIntInt.Value.Key;
						int value2 = dicIntInt.Value.Value;
						if (dictionary.ContainsKey(key2))
						{
							dictionary[key2] += value * value2;
						}
						else
						{
							dictionary[key2] = value * value2;
						}
					}
				}
			}
		}
		return dictionary;
	}

	// Token: 0x0600C55B RID: 50523 RVA: 0x00341EB8 File Offset: 0x003400B8
	public bool GetRecoveryAvailable()
	{
		int currentLastFinishChallengeId = this.GetCurrentOpenAbyssActivityData().GetCurrentLastFinishChallengeId();
		AbyssInst? dangoAbyssInstById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstById(currentLastFinishChallengeId);
		return dangoAbyssInstById != null && dangoAbyssInstById.Value.AbyssSynthesisEntr;
	}

	// Token: 0x0600C55C RID: 50524 RVA: 0x00341EF8 File Offset: 0x003400F8
	public bool GetRankOpen()
	{
		int currentLastFinishChallengeId = this.GetCurrentOpenAbyssActivityData().GetCurrentLastFinishChallengeId();
		AbyssInst? dangoAbyssInstById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstById(currentLastFinishChallengeId);
		return dangoAbyssInstById != null && dangoAbyssInstById.Value.AbyssRank;
	}

	// Token: 0x0600C55D RID: 50525 RVA: 0x00341F38 File Offset: 0x00340138
	public int GetMainHonorRank(List<IAbyssDescData> dataList, bool addRank = false)
	{
		if (dataList.Count == 0)
		{
			return 0;
		}
		int id = dataList[0].Id;
		int count = dataList[0].Count;
		Dictionary<int, string> dictionary = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssSettleById(id).Value.Title();
		int num = addRank ? -1 : 3;
		foreach (KeyValuePair<int, string> keyValuePair in dictionary)
		{
			if (count >= keyValuePair.Key)
			{
				if (addRank)
				{
					num++;
				}
				else
				{
					num--;
				}
			}
		}
		num = Math.Max(0, Math.Min(2, num));
		return num;
	}

	// Token: 0x0600C55E RID: 50526 RVA: 0x00341FF0 File Offset: 0x003401F0
	public ItemTipsParam GetPluginItemTipsData(int itemId, int incId, int? slotIndex = null, int? dangoId = null)
	{
		DangoExtraParam extraParam = new DangoExtraParam
		{
			DangoId = dangoId.GetValueOrDefault(-1),
			SlotIndex = slotIndex.GetValueOrDefault(-1)
		};
		return new ItemTipsParam
		{
			ItemId = itemId,
			ItemUid = incId,
			ExtraParam = extraParam
		};
	}

	// Token: 0x0600C55F RID: 50527 RVA: 0x0034203C File Offset: 0x0034023C
	public string GetSkillDescByDangoId(int dangoId)
	{
		AbyssLittleRole? dangoRoleById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoRoleById(dangoId);
		if (dangoRoleById == null)
		{
			return "";
		}
		int phantomItemId = dangoRoleById.Value.PhantomItemId;
		Aki.Config.PhantomItem? phantomItemById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(phantomItemId);
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillDescStringBySkillIdAndQuality(phantomItemById.Value.SkillId, 2);
	}

	// Token: 0x0600C560 RID: 50528 RVA: 0x0034209C File Offset: 0x0034029C
	public bool GetDangoUpAvailable()
	{
		int currentLastFinishChallengeId = this.GetCurrentOpenAbyssActivityData().GetCurrentLastFinishChallengeId();
		AbyssInst? dangoAbyssInstById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstById(currentLastFinishChallengeId);
		return dangoAbyssInstById != null && dangoAbyssInstById.Value.AbyssDevelopEntr;
	}

	// Token: 0x0600C561 RID: 50529 RVA: 0x003420DC File Offset: 0x003402DC
	public bool GetShopAvailable()
	{
		int currentLastFinishChallengeId = this.GetCurrentOpenAbyssActivityData().GetCurrentLastFinishChallengeId();
		AbyssInst? dangoAbyssInstById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstById(currentLastFinishChallengeId);
		return dangoAbyssInstById != null && dangoAbyssInstById.Value.AbyssStoreEntr;
	}

	// Token: 0x0600C562 RID: 50530 RVA: 0x0034211C File Offset: 0x0034031C
	[NullableContext(2)]
	public global::AbyssRewardInfo GetRewardInfoById(int rewardId)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			return null;
		}
		return currentOpenAbyssActivityData.GetRewardInfoById(rewardId);
	}

	// Token: 0x0600C563 RID: 50531 RVA: 0x0034213C File Offset: 0x0034033C
	public void SetLikeRecord(List<AbyssLikeRecord> data)
	{
		List<DangoAbyssDefine.IAbyssLikeRecord> list = new List<DangoAbyssDefine.IAbyssLikeRecord>();
		foreach (AbyssLikeRecord abyssLikeRecord in data)
		{
			DangoAbyssDefine.IAbyssLikeRecord item = new DangoAbyssDefine.IAbyssLikeRecord
			{
				PlayerId = abyssLikeRecord.PlayerId,
				LikedPlayerIdList = abyssLikeRecord.LikedPlayerId.ToList<int>()
			};
			list.Add(item);
		}
		this.AbyssLikedRecord = list.ToArray();
	}

	// Token: 0x0600C564 RID: 50532 RVA: 0x003421C0 File Offset: 0x003403C0
	public bool GetPlayerIfLikePlayer(int playerId, int targetPlayerId)
	{
		if (playerId == targetPlayerId)
		{
			return true;
		}
		foreach (DangoAbyssDefine.IAbyssLikeRecord abyssLikeRecord in this.AbyssLikedRecord)
		{
			if (abyssLikeRecord.PlayerId == targetPlayerId)
			{
				using (List<int>.Enumerator enumerator = abyssLikeRecord.LikedPlayerIdList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current == playerId)
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	// Token: 0x0600C565 RID: 50533 RVA: 0x00342240 File Offset: 0x00340440
	public bool IsChallengeFinish()
	{
		return this.ChallengeFinish;
	}

	// Token: 0x04005E8B RID: 24203
	public bool LeaveFromAbyssWorld;

	// Token: 0x04005E8C RID: 24204
	private bool InAbyssFlowInternal;

	// Token: 0x04005E8D RID: 24205
	public int CurrentSelectEntranceId;

	// Token: 0x04005E8E RID: 24206
	public int CurrentSelectChallengeId;

	// Token: 0x04005E8F RID: 24207
	private int CurrentLayer;

	// Token: 0x04005E90 RID: 24208
	private int MaxLayer;

	// Token: 0x04005E91 RID: 24209
	private int GainBoxCount;

	// Token: 0x04005E92 RID: 24210
	private int MaxBoxCount;

	// Token: 0x04005E93 RID: 24211
	private int CurrentRoomId;

	// Token: 0x04005E94 RID: 24212
	private int CurrentChallengeId = 1;

	// Token: 0x04005E95 RID: 24213
	private int CurrentRouteId;

	// Token: 0x04005E96 RID: 24214
	[Nullable(2)]
	private AbyssRankChallengeInfo ChallengeRankInfo;

	// Token: 0x04005E97 RID: 24215
	[Nullable(2)]
	private AbyssFormationInfo CurrentFormationSelectInfo;

	// Token: 0x04005E98 RID: 24216
	[Nullable(2)]
	private AbyssChallengeResultData CurrentAbyssResultInfo;

	// Token: 0x04005E99 RID: 24217
	public Dictionary<int, Dictionary<int, int>> FormationIndex2DangoIdMapCache = new Dictionary<int, Dictionary<int, int>>();

	// Token: 0x04005E9A RID: 24218
	[Nullable(2)]
	private Dictionary<int, int> RoleSelectDangoMap;

	// Token: 0x04005E9B RID: 24219
	private int MaxScore;

	// Token: 0x04005E9C RID: 24220
	private int CurrentScore;

	// Token: 0x04005E9D RID: 24221
	private readonly Dictionary<int, Dictionary<int, AbyssDangoOwnerData>> DangoOwnerMap = new Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>();

	// Token: 0x04005E9E RID: 24222
	private bool ChallengeFinish;

	// Token: 0x04005E9F RID: 24223
	private DangoAbyssDefine.IAbyssLikeRecord[] AbyssLikedRecord = Array.Empty<DangoAbyssDefine.IAbyssLikeRecord>();
}
