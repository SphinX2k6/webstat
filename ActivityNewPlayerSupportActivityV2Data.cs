using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02001464 RID: 5220
[NullableContext(2)]
[Nullable(0)]
public class ActivityNewPlayerSupportActivityV2Data : ActivityBaseData
{
	// Token: 0x17000C18 RID: 3096
	// (get) Token: 0x060091A1 RID: 37281 RVA: 0x00266B2E File Offset: 0x00264D2E
	public TrialRoleGroupData CurUseTrialRoleData
	{
		get
		{
			return ModelBase<TrialRoleModel>.Instance.GetCurUseTrialRole(ETrialRoleType.NewbieSupportTrialV2);
		}
	}

	// Token: 0x17000C19 RID: 3097
	// (get) Token: 0x060091A2 RID: 37282 RVA: 0x00266B3B File Offset: 0x00264D3B
	public long NbWeekCardEndShowTime
	{
		get
		{
			NewPlayerSupportActivityV2Pb v2Data = this.V2Data;
			if (v2Data == null)
			{
				return 0L;
			}
			return v2Data.NbWeekCardEndShowTime;
		}
	}

	// Token: 0x17000C1A RID: 3098
	// (get) Token: 0x060091A3 RID: 37283 RVA: 0x00266B4F File Offset: 0x00264D4F
	public long NbGiftPackEndShowTime
	{
		get
		{
			NewPlayerSupportActivityV2Pb v2Data = this.V2Data;
			if (v2Data == null)
			{
				return 0L;
			}
			return v2Data.NbGiftPackEndShowTime;
		}
	}

	// Token: 0x17000C1B RID: 3099
	// (get) Token: 0x060091A4 RID: 37284 RVA: 0x00266B63 File Offset: 0x00264D63
	public long NbGachaEndShowTime
	{
		get
		{
			NewPlayerSupportActivityV2Pb v2Data = this.V2Data;
			if (v2Data == null)
			{
				return 0L;
			}
			return v2Data.NbGachaEndShowTime;
		}
	}

	// Token: 0x17000C1C RID: 3100
	// (get) Token: 0x060091A5 RID: 37285 RVA: 0x00266B77 File Offset: 0x00264D77
	public long NbLivenessEndShowTime
	{
		get
		{
			NewPlayerSupportActivityV2Pb v2Data = this.V2Data;
			if (v2Data == null)
			{
				return 0L;
			}
			return v2Data.NbLivenessEndShowTime;
		}
	}

	// Token: 0x17000C1D RID: 3101
	// (get) Token: 0x060091A6 RID: 37286 RVA: 0x00266B8B File Offset: 0x00264D8B
	public int NewPlayerPoolFinalGachaRoleId
	{
		get
		{
			NewPlayerSupportActivityV2Pb v2Data = this.V2Data;
			if (v2Data == null)
			{
				return 0;
			}
			return v2Data.NewPlayerPoolFinalGachaRoleId;
		}
	}

	// Token: 0x060091A7 RID: 37287 RVA: 0x00266BA0 File Offset: 0x00264DA0
	[NullableContext(1)]
	protected override void PhraseEx(ActivityData data)
	{
		NewPlayerSupportActivityV2? config = ConfigNewPlayerSupportActivityV2ById.GetConfig(base.Id, true);
		NewPlayerSupportActivityV2? activityConfig;
		if (config == null)
		{
			IReadOnlyList<NewPlayerSupportActivityV2> configList = ConfigNewPlayerSupportActivityV2All.GetConfigList(true);
			activityConfig = ((configList != null) ? new NewPlayerSupportActivityV2?(configList.FirstOrDefault<NewPlayerSupportActivityV2>()) : null);
		}
		else
		{
			activityConfig = config;
		}
		this.ActivityConfig = activityConfig;
		this.InitTrialDisplayConfig();
		this.V2Data = data.NewPlayerSupportActivityV2Pb;
		if (this.V2Data == null)
		{
			return;
		}
		this.ParseTrialRoles(this.V2Data.TrialRoleInfoList);
		this.ParseCurUseTrialRole(this.V2Data.CurUseTrialRoleId, this.V2Data.CurUseRoleInfo);
	}

	// Token: 0x060091A8 RID: 37288 RVA: 0x00266C33 File Offset: 0x00264E33
	public void UpdateCurUseTrialRole(int trialRoleId, roleInfo trialRoleInfo)
	{
		ModelBase<TrialRoleModel>.Instance.SetCurUseTrialRole(trialRoleId, trialRoleInfo);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x060091A9 RID: 37289 RVA: 0x00266C57 File Offset: 0x00264E57
	public void UpdateActivatedTrialRole(int trialRoleId, roleInfo trialRoleInfo)
	{
		ModelBase<TrialRoleModel>.Instance.SaveTrialRoleUnlockRedDotById(trialRoleId, true);
		ModelBase<TrialRoleModel>.Instance.SetGroupTrialRoleId(trialRoleId, trialRoleInfo);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x060091AA RID: 37290 RVA: 0x00266C88 File Offset: 0x00264E88
	[NullableContext(1)]
	public void UpdateDeduplicateGachaRoleIds(int[] roleIds)
	{
		if (this.V2Data == null)
		{
			return;
		}
		this.V2Data.DeduplicateGachaRoleIds.Clear();
		this.V2Data.DeduplicateGachaRoleIds.AddRange(roleIds);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x060091AB RID: 37291 RVA: 0x00266CD5 File Offset: 0x00264ED5
	public void MarkWeekCardEntranceClicked()
	{
		this.SaveEntranceClicked(1);
	}

	// Token: 0x060091AC RID: 37292 RVA: 0x00266CDE File Offset: 0x00264EDE
	public void MarkGiftPackEntranceClicked()
	{
		this.SaveEntranceClicked(2);
	}

	// Token: 0x060091AD RID: 37293 RVA: 0x00266CE7 File Offset: 0x00264EE7
	public void MarkGachaEntranceClicked()
	{
		this.SaveEntranceClicked(3);
	}

	// Token: 0x060091AE RID: 37294 RVA: 0x00266CF0 File Offset: 0x00264EF0
	public void MarkLivenessEntranceClicked()
	{
		this.SaveEntranceClicked(4);
	}

	// Token: 0x060091AF RID: 37295 RVA: 0x00266CF9 File Offset: 0x00264EF9
	public long GetDisplayRemainEndTime()
	{
		return Math.Max(Math.Max(Math.Max(this.NbWeekCardEndShowTime, this.NbGiftPackEndShowTime), Math.Max(this.NbGachaEndShowTime, this.NbLivenessEndShowTime)), base.EndShowTime);
	}

	// Token: 0x060091B0 RID: 37296 RVA: 0x00266D30 File Offset: 0x00264F30
	[NullableContext(1)]
	public int[] GetConfiguredGachaIds()
	{
		return ((this.ActivityConfig != null) ? this.ActivityConfig.GetValueOrDefault().GetGachaIdsArray() : null) ?? Array.Empty<int>();
	}

	// Token: 0x060091B1 RID: 37297 RVA: 0x00266D68 File Offset: 0x00264F68
	public int? GetGachaOpenTabIdOrDefault()
	{
		int[] configuredGachaIds = this.GetConfiguredGachaIds();
		if (configuredGachaIds.Length == 0)
		{
			return null;
		}
		if (configuredGachaIds.Length >= 2)
		{
			int num = configuredGachaIds[0];
			int num2 = configuredGachaIds[1];
			bool flag = ModelBase<GachaModel>.Instance.GetGachaInfo(num) != null;
			bool flag2 = ModelBase<GachaModel>.Instance.GetGachaInfo(num2) != null;
			if (flag)
			{
				return new int?(num);
			}
			if (flag2)
			{
				return new int?(num2);
			}
		}
		return new int?(configuredGachaIds[0]);
	}

	// Token: 0x060091B2 RID: 37298 RVA: 0x00266DD4 File Offset: 0x00264FD4
	[return: TupleElementNames(new string[]
	{
		"RolePathResourceId",
		"BgPathResourceId"
	})]
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public ValueTuple<string, string>? GetCurrentTrialRoleDisplayResourceIds()
	{
		TrialRoleGroupData curUseTrialRoleData = this.CurUseTrialRoleData;
		bool flag = curUseTrialRoleData != null && curUseTrialRoleData.TrialRoleId != 0;
		TrialRoleGroupData curUseTrialRoleData2 = this.CurUseTrialRoleData;
		int num = (curUseTrialRoleData2 != null) ? curUseTrialRoleData2.TrialRoleGroupId : 0;
		if (!flag || num == 0)
		{
			return null;
		}
		NewPlayerSupV2Trial newPlayerSupV2Trial;
		if (!this.TrialDisplayConfigMap.TryGetValue(num, out newPlayerSupV2Trial))
		{
			return null;
		}
		return new ValueTuple<string, string>?(new ValueTuple<string, string>(newPlayerSupV2Trial.RolePathMale ?? string.Empty, newPlayerSupV2Trial.RoleBgPathMale ?? string.Empty));
	}

	// Token: 0x060091B3 RID: 37299 RVA: 0x00266E59 File Offset: 0x00265059
	public bool GetTrialRoleEntranceRedDotState()
	{
		return this.IsTrialRoleEntranceRedDot();
	}

	// Token: 0x060091B4 RID: 37300 RVA: 0x00266E61 File Offset: 0x00265061
	public bool GetWeekCardEntranceRedDotState()
	{
		return this.IsWeekCardEntranceRedDot();
	}

	// Token: 0x060091B5 RID: 37301 RVA: 0x00266E69 File Offset: 0x00265069
	public bool GetGiftPackEntranceRedDotState()
	{
		return this.IsGiftPackEntranceRedDot();
	}

	// Token: 0x060091B6 RID: 37302 RVA: 0x00266E71 File Offset: 0x00265071
	public bool GetGachaEntranceRedDotState()
	{
		return this.IsGachaEntranceRedDot();
	}

	// Token: 0x060091B7 RID: 37303 RVA: 0x00266E79 File Offset: 0x00265079
	public bool GetLivenessEntranceRedDotState()
	{
		return this.IsLivenessEntranceRedDot();
	}

	// Token: 0x060091B8 RID: 37304 RVA: 0x00266E81 File Offset: 0x00265081
	public override bool GetExDataRedPointShowState()
	{
		return this.IsTrialRoleEntranceRedDot();
	}

	// Token: 0x060091B9 RID: 37305 RVA: 0x00266E89 File Offset: 0x00265089
	protected override bool GetExDataFinishShowState()
	{
		return false;
	}

	// Token: 0x060091BA RID: 37306 RVA: 0x00266E8C File Offset: 0x0026508C
	private void ParseCurUseTrialRole(int trialRoleId, roleInfo trialRoleInfo)
	{
		if (!RoleUtils.IsTrialRole(trialRoleId))
		{
			return;
		}
		ModelBase<TrialRoleModel>.Instance.SetCurUseTrialRole(trialRoleId, trialRoleInfo);
	}

	// Token: 0x060091BB RID: 37307 RVA: 0x00266EA4 File Offset: 0x002650A4
	[NullableContext(1)]
	private void ParseTrialRoles(IEnumerable<NewTrialRoleInfo> roleList)
	{
		List<ITrialRoleCreateData> list = new List<ITrialRoleCreateData>();
		HashSet<int> hashSet = new HashSet<int>();
		foreach (NewTrialRoleInfo newTrialRoleInfo in roleList)
		{
			list.Add(new TrialRoleCreateData
			{
				TrialRoleId = newTrialRoleInfo.TrialRoleId,
				IsUnlocked = true
			});
			TrialRoleConfig instance = ConfigBase<TrialRoleConfig>.Instance;
			int? num = (instance != null) ? instance.GetTrialRoleGroupId(newTrialRoleInfo.TrialRoleId) : null;
			if (num != null)
			{
				hashSet.Add(num.Value);
			}
		}
		TrialRoleConfig instance2 = ConfigBase<TrialRoleConfig>.Instance;
		Dictionary<int, List<TrialRoleInfo>> dictionary = (instance2 != null) ? instance2.GetTrialRoleAllConfigByType(ETrialRoleType.NewbieSupportTrialV2) : null;
		if (dictionary != null)
		{
			foreach (KeyValuePair<int, List<TrialRoleInfo>> keyValuePair in dictionary)
			{
				int key = keyValuePair.Key;
				List<TrialRoleInfo> value = keyValuePair.Value;
				if (!hashSet.Contains(key) && value.Count > 0)
				{
					list.Add(new TrialRoleCreateData
					{
						TrialRoleId = value[0].Id,
						IsUnlocked = false
					});
				}
			}
		}
		ModelBase<TrialRoleModel>.Instance.AddTrialRoles(list);
	}

	// Token: 0x060091BC RID: 37308 RVA: 0x00266FF4 File Offset: 0x002651F4
	private bool IsTrialRoleEntranceRedDot()
	{
		return ModelBase<TrialRoleModel>.Instance.GetDataListByType(ETrialRoleType.NewbieSupportTrialV2).Exists((TrialRoleGroupData role) => ModelBase<TrialRoleModel>.Instance.GetTrialRoleUnlockRedDotById(role.TrialRoleGroupId));
	}

	// Token: 0x060091BD RID: 37309 RVA: 0x00267025 File Offset: 0x00265225
	private bool IsLivenessEntranceRedDot()
	{
		return this.IsLivenessEntranceUnlocked() && !this.IsEntranceClicked(4);
	}

	// Token: 0x060091BE RID: 37310 RVA: 0x0026703B File Offset: 0x0026523B
	private bool IsLivenessEntranceUnlocked()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10023005);
	}

	// Token: 0x060091BF RID: 37311 RVA: 0x0026704C File Offset: 0x0026524C
	private bool IsWeekCardEntranceRedDot()
	{
		return this.IsEntranceAvailable((this.ActivityConfig != null) ? new int?(this.ActivityConfig.GetValueOrDefault().WeekCardContinueDays) : null, (this.ActivityConfig != null) ? this.ActivityConfig.GetValueOrDefault().GetWeekCardIdsArray() : null, this.NbWeekCardEndShowTime > 0L) && !this.IsEntranceClicked(1);
	}

	// Token: 0x060091C0 RID: 37312 RVA: 0x002670C4 File Offset: 0x002652C4
	private bool IsGiftPackEntranceRedDot()
	{
		return this.IsEntranceAvailable((this.ActivityConfig != null) ? new int?(this.ActivityConfig.GetValueOrDefault().PayGiftsContinueDays) : null, (this.ActivityConfig != null) ? this.ActivityConfig.GetValueOrDefault().GetPayGiftsArray() : null, this.NbGiftPackEndShowTime > 0L) && !this.IsEntranceClicked(2);
	}

	// Token: 0x060091C1 RID: 37313 RVA: 0x0026713C File Offset: 0x0026533C
	private bool IsGachaEntranceRedDot()
	{
		return this.IsEntranceAvailable((this.ActivityConfig != null) ? new int?(this.ActivityConfig.GetValueOrDefault().GachaContinueDays) : null, (this.ActivityConfig != null) ? this.ActivityConfig.GetValueOrDefault().GetGachaIdsArray() : null, this.NbGachaEndShowTime > 0L) && !this.IsEntranceClicked(3);
	}

	// Token: 0x060091C2 RID: 37314 RVA: 0x002671B2 File Offset: 0x002653B2
	private void SaveEntranceClicked(int cacheKey)
	{
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, cacheKey, 0, 0, 1);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x060091C3 RID: 37315 RVA: 0x002671DE File Offset: 0x002653DE
	private bool IsEntranceClicked(int cacheKey)
	{
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, cacheKey, 0, 0) == 1;
	}

	// Token: 0x060091C4 RID: 37316 RVA: 0x002671F7 File Offset: 0x002653F7
	private bool IsEntranceAvailable(int? continueDays, int[] ids, bool serverUnlocked)
	{
		return this.CheckIfInShowTime() && (serverUnlocked || (continueDays != null && ids != null && ids.Length != 0 && this.GetOpenedDays() >= Math.Max(continueDays.Value, 1)));
	}

	// Token: 0x060091C5 RID: 37317 RVA: 0x00267232 File Offset: 0x00265432
	private int GetOpenedDays()
	{
		if (base.BeginShowTime <= 0L)
		{
			return 0;
		}
		return (int)(Math.Max(Singleton<TimeUtil>.Instance.GetServerTime() - (double)base.BeginShowTime, 0.0) / (double)Singleton<TimeUtil>.Instance.OneDaySeconds) + 1;
	}

	// Token: 0x060091C6 RID: 37318 RVA: 0x00267270 File Offset: 0x00265470
	private void InitTrialDisplayConfig()
	{
		this.TrialDisplayConfigMap.Clear();
		foreach (NewPlayerSupV2Trial value in (ConfigNewPlayerSupV2TrialByActivityId.GetConfigList(base.Id, true) ?? Array.Empty<NewPlayerSupV2Trial>()))
		{
			this.TrialDisplayConfigMap[value.TrialRoleGroupId] = value;
		}
	}

	// Token: 0x0400439B RID: 17307
	private const int CacheKeyWeekCardClicked = 1;

	// Token: 0x0400439C RID: 17308
	private const int CacheKeyGiftPackClicked = 2;

	// Token: 0x0400439D RID: 17309
	private const int CacheKeyGachaClicked = 3;

	// Token: 0x0400439E RID: 17310
	private const int CacheKeyLivenessClicked = 4;

	// Token: 0x0400439F RID: 17311
	private NewPlayerSupportActivityV2? ActivityConfig;

	// Token: 0x040043A0 RID: 17312
	private NewPlayerSupportActivityV2Pb V2Data;

	// Token: 0x040043A1 RID: 17313
	[Nullable(1)]
	private readonly Dictionary<int, NewPlayerSupV2Trial> TrialDisplayConfigMap = new Dictionary<int, NewPlayerSupV2Trial>();
}
