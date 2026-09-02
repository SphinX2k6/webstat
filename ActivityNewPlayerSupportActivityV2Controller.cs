using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;

// Token: 0x02001463 RID: 5219
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityNewPlayerSupportActivityV2Controller : ActivityControllerBase<ActivityNewPlayerSupportActivityV2Controller>
{
	// Token: 0x17000C17 RID: 3095
	// (get) Token: 0x06009183 RID: 37251 RVA: 0x00266239 File Offset: 0x00264439
	[Nullable(2)]
	public ActivityNewPlayerSupportActivityV2Data ActivityData
	{
		[NullableContext(2)]
		get
		{
			return this.ActivityDataInternal;
		}
	}

	// Token: 0x06009184 RID: 37252 RVA: 0x00266244 File Offset: 0x00264444
	public static void ReportEntranceClick(ENewPlayerSupportEntrance entrance)
	{
		NewPlayerSupportEntranceClickLogEvent newPlayerSupportEntranceClickLogEvent = new NewPlayerSupportEntranceClickLogEvent();
		newPlayerSupportEntranceClickLogEvent.i_entrance_id = (int)entrance;
		ControllerBase<LogReportController>.Instance.LogReport(newPlayerSupportEntranceClickLogEvent);
	}

	// Token: 0x06009185 RID: 37253 RVA: 0x0026626C File Offset: 0x0026446C
	public static PayShopJumpParam ResolveWeekCardShopJumpParam()
	{
		List<int> payShopTabIdList = ModelBase<PayShopModel>.Instance.GetPayShopTabIdList(PayShopDefine.EPayShopTabType.NewPlayerShop, true);
		if (payShopTabIdList.Count == 0)
		{
			return new PayShopJumpParam
			{
				PayShopId = PayShopDefine.EPayShopTabType.Recommend,
				SwitchId = 0
			};
		}
		return new PayShopJumpParam
		{
			PayShopId = PayShopDefine.EPayShopTabType.NewPlayerShop,
			SwitchId = ((payShopTabIdList.Count > 0) ? payShopTabIdList[0] : 1)
		};
	}

	// Token: 0x06009186 RID: 37254 RVA: 0x002662C7 File Offset: 0x002644C7
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<NewPlayerSupportActivityTrialRoleUpdateV2Notify>(ENotifyMessageId.NewPlayerSupportActivityTrialRoleUpdateV2Notify, new Action<NewPlayerSupportActivityTrialRoleUpdateV2Notify, Net.CallbackStatus>(this.OnTrialRoleUpdateNotify));
		Singleton<Net>.Instance.Register<NewPlayerSupportV2GachaRoleUpdateNotify>(ENotifyMessageId.NewPlayerSupportV2GachaRoleUpdateNotify, new Action<NewPlayerSupportV2GachaRoleUpdateNotify, Net.CallbackStatus>(this.OnGachaRoleUpdateNotify));
	}

	// Token: 0x06009187 RID: 37255 RVA: 0x00266301 File Offset: 0x00264501
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewPlayerSupportActivityTrialRoleUpdateV2Notify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewPlayerSupportV2GachaRoleUpdateNotify);
	}

	// Token: 0x06009188 RID: 37256 RVA: 0x00266323 File Offset: 0x00264523
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009189 RID: 37257 RVA: 0x00266325 File Offset: 0x00264525
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_NewcomerPrivilege";
	}

	// Token: 0x0600918A RID: 37258 RVA: 0x0026632C File Offset: 0x0026452C
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewNewPlayerSupportActivityV2();
	}

	// Token: 0x0600918B RID: 37259 RVA: 0x00266333 File Offset: 0x00264533
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.ActivityDataInternal = new ActivityNewPlayerSupportActivityV2Data();
		return this.ActivityDataInternal;
	}

	// Token: 0x0600918C RID: 37260 RVA: 0x00266346 File Offset: 0x00264546
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityNewPlayerSupportTrialRoleView);
	}

	// Token: 0x0600918D RID: 37261 RVA: 0x00266358 File Offset: 0x00264558
	public void RequestTrialRoleLvUp(int trialRoleId)
	{
		NewPlayerSupportTrialRoleLvUpV2Request newPlayerSupportTrialRoleLvUpV2Request = NewPlayerSupportTrialRoleLvUpV2Request.Create();
		newPlayerSupportTrialRoleLvUpV2Request.TrialRoleId = trialRoleId;
		Singleton<Net>.Instance.Call<NewPlayerSupportTrialRoleLvUpV2Response>(ERequestMessageId.NewPlayerSupportTrialRoleLvUpV2Request, newPlayerSupportTrialRoleLvUpV2Request, delegate(NewPlayerSupportTrialRoleLvUpV2Response response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.Code != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 18822, null, true, true);
				return;
			}
			ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
			if (activityData == null)
			{
				return;
			}
			activityData.UpdateActivatedTrialRole(response.RoleId, response.CurUseRoleInfo);
		}, 0);
	}

	// Token: 0x0600918E RID: 37262 RVA: 0x00266390 File Offset: 0x00264590
	public void RequestSetCurUseTrialRole(int trialRoleId, Action<int> callback)
	{
		NewPlayerSupportSetCurUseTrialRoleV2Request newPlayerSupportSetCurUseTrialRoleV2Request = NewPlayerSupportSetCurUseTrialRoleV2Request.Create();
		newPlayerSupportSetCurUseTrialRoleV2Request.TrialRoleId = trialRoleId;
		Singleton<Net>.Instance.Call<NewPlayerSupportSetCurUseTrialRoleV2Response>(ERequestMessageId.NewPlayerSupportSetCurUseTrialRoleV2Request, newPlayerSupportSetCurUseTrialRoleV2Request, delegate(NewPlayerSupportSetCurUseTrialRoleV2Response response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.Code != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 16455, null, true, true);
				return;
			}
			ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
			if (activityData != null)
			{
				activityData.UpdateCurUseTrialRole(response.RoleId, response.CurUseRoleInfo);
			}
			callback(response.RoleId);
		}, 0);
	}

	// Token: 0x0600918F RID: 37263 RVA: 0x002663DC File Offset: 0x002645DC
	public void OpenTrialRoleView(int? selectedGroupId = null)
	{
		NewPlayerSupportTrialRoleViewModel newPlayerSupportTrialRoleViewModel = new NewPlayerSupportTrialRoleViewModel(ETrialRoleType.NewbieSupportTrialV2, ConfigCommonParamById.GetStringConfig("NewPlayerSupportTrialRoleIcon") ?? "", ConfigCommonParamById.GetStringConfig("NewPlayerSupportTrialRoleTitle") ?? "", 465, selectedGroupId);
		newPlayerSupportTrialRoleViewModel.SetRequestTrialRoleLvUpFunc(new Action<int>(this.RequestTrialRoleLvUp));
		newPlayerSupportTrialRoleViewModel.SetRequestSetCurUseTrialRoleFunc(new Action<int, Action<int>>(this.RequestSetCurUseTrialRole));
		newPlayerSupportTrialRoleViewModel.SetTrialRoleGroupUnlockDesc(this.GetTrialRoleUnlockDesc());
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityNewPlayerSupportTrialRoleView, newPlayerSupportTrialRoleViewModel, null);
	}

	// Token: 0x06009190 RID: 37264 RVA: 0x00266460 File Offset: 0x00264660
	public void OpenAdventureV2View()
	{
		INewPlayerAdventureV2ViewOpenData param = new INewPlayerAdventureV2ViewOpenData
		{
			RoleIdList = this.CollectAdventureV2RoleIds()
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.NewPlayerAdventureV2View, param, null);
	}

	// Token: 0x06009191 RID: 37265 RVA: 0x00266490 File Offset: 0x00264690
	private List<int> CollectAdventureV2RoleIds()
	{
		HashSet<int> hashSet = new HashSet<int>();
		List<int> list = new List<int>();
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		int[] array;
		if (instance == null)
		{
			array = null;
		}
		else
		{
			EditFormationData getCurrentFormationData = instance.GetCurrentFormationData;
			array = ((getCurrentFormationData != null) ? getCurrentFormationData.GetRoleIdList : null);
		}
		int[] sourceRoleIds = array ?? Array.Empty<int>();
		this.AppendUniqueAdventureRoleIds(sourceRoleIds, list, hashSet);
		List<int> list2 = new List<int>();
		this.AppendUniqueAdventureRoleIds(this.GetGachaPoolUpRole(), list2, hashSet);
		List<int> list3 = new List<int>();
		RoleModel instance2 = ModelBase<RoleModel>.Instance;
		RoleInstance[] array2 = ((instance2 != null) ? instance2.GetRoleListWithoutMainRole() : null) ?? Array.Empty<RoleInstance>();
		for (int i = 0; i < array2.Length; i++)
		{
			int roleId = array2[i].GetRoleId();
			if (!this.IsInvalidAdventureRoleId(roleId) && !hashSet.Contains(roleId))
			{
				hashSet.Add(roleId);
				list3.Add(roleId);
			}
		}
		list3.Sort(new Comparison<int>(this.SortByLevelQualityId));
		List<int> list4 = new List<int>();
		list4.AddRange(list2);
		list4.AddRange(list);
		list4.AddRange(list3);
		return list4;
	}

	// Token: 0x06009192 RID: 37266 RVA: 0x00266584 File Offset: 0x00264784
	private void AppendUniqueAdventureRoleIds(IEnumerable<int> sourceRoleIds, List<int> targetBucket, HashSet<int> seenRoleIds)
	{
		foreach (int num in sourceRoleIds)
		{
			if (!this.IsInvalidAdventureRoleId(num) && !seenRoleIds.Contains(num))
			{
				seenRoleIds.Add(num);
				targetBucket.Add(num);
			}
		}
	}

	// Token: 0x06009193 RID: 37267 RVA: 0x002665E8 File Offset: 0x002647E8
	private bool IsInvalidAdventureRoleId(int roleId)
	{
		if (roleId <= 0)
		{
			return true;
		}
		RoleModel instance = ModelBase<RoleModel>.Instance;
		return (instance != null && instance.IsMainRole(roleId)) || RoleUtils.IsTrialRole(roleId);
	}

	// Token: 0x06009194 RID: 37268 RVA: 0x0026660C File Offset: 0x0026480C
	private int SortByLevelQualityId(int roleIdA, int roleIdB)
	{
		int adventureRoleLevel = this.GetAdventureRoleLevel(roleIdA);
		int adventureRoleLevel2 = this.GetAdventureRoleLevel(roleIdB);
		if (adventureRoleLevel != adventureRoleLevel2)
		{
			return adventureRoleLevel2 - adventureRoleLevel;
		}
		int adventureRoleQualityId = this.GetAdventureRoleQualityId(roleIdA);
		int adventureRoleQualityId2 = this.GetAdventureRoleQualityId(roleIdB);
		if (adventureRoleQualityId != adventureRoleQualityId2)
		{
			return adventureRoleQualityId2 - adventureRoleQualityId;
		}
		return roleIdA - roleIdB;
	}

	// Token: 0x06009195 RID: 37269 RVA: 0x0026664C File Offset: 0x0026484C
	private int GetAdventureRoleLevel(int roleId)
	{
		RoleModel instance = ModelBase<RoleModel>.Instance;
		RoleDataBase roleDataBase = (instance != null) ? instance.GetRoleDataById(roleId, true) : null;
		if (roleDataBase == null)
		{
			return 0;
		}
		return roleDataBase.GetLevelData().GetLevel();
	}

	// Token: 0x06009196 RID: 37270 RVA: 0x00266680 File Offset: 0x00264880
	private int GetAdventureRoleQualityId(int roleId)
	{
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		if (roleConfig == null)
		{
			return 0;
		}
		return roleConfig.Value.QualityId;
	}

	// Token: 0x06009197 RID: 37271 RVA: 0x002666B4 File Offset: 0x002648B4
	private List<int> GetGachaPoolUpRole()
	{
		Dictionary<GachaDefine.EGachaViewType, List<int>> dictionary = this.CreateGachaPoolUpRoleBucketMap();
		ProtoGachaInfo[] gachaInfoArray = ModelBase<GachaModel>.Instance.GachaInfoArray;
		if (gachaInfoArray == null || gachaInfoArray.Length == 0)
		{
			return new List<int>();
		}
		ProtoGachaInfo[] array = gachaInfoArray;
		for (int i = 0; i < array.Length; i++)
		{
			foreach (ProtoGachaPoolInfo protoGachaPoolInfo in array[i].GetValidPoolList() ?? Array.Empty<ProtoGachaPoolInfo>())
			{
				this.TryCollectGachaPoolUpRole(protoGachaPoolInfo.Id, dictionary);
			}
		}
		ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
		int num = (activityData != null) ? activityData.NewPlayerPoolFinalGachaRoleId : 0;
		List<int> list;
		if (num > 0 && dictionary.TryGetValue(GachaDefine.EGachaViewType.NewPlayerCustom, out list))
		{
			list.Add(num);
		}
		return this.GetSortedGachaPoolUpRoleList(dictionary);
	}

	// Token: 0x06009198 RID: 37272 RVA: 0x00266764 File Offset: 0x00264964
	private Dictionary<GachaDefine.EGachaViewType, List<int>> CreateGachaPoolUpRoleBucketMap()
	{
		Dictionary<GachaDefine.EGachaViewType, List<int>> dictionary = new Dictionary<GachaDefine.EGachaViewType, List<int>>();
		foreach (GachaDefine.EGachaViewType key in ActivityNewPlayerSupportActivityV2Controller.GachaPoolUpRoleCollectViewTypeList)
		{
			dictionary[key] = new List<int>();
		}
		return dictionary;
	}

	// Token: 0x06009199 RID: 37273 RVA: 0x0026679C File Offset: 0x0026499C
	private void TryCollectGachaPoolUpRole(int poolId, Dictionary<GachaDefine.EGachaViewType, List<int>> roleBucketMap)
	{
		GachaViewInfo? gachaViewInfo = ConfigBase<GachaConfig>.Instance.GetGachaViewInfo(poolId);
		if (gachaViewInfo == null)
		{
			return;
		}
		GachaDefine.EGachaViewType type = (GachaDefine.EGachaViewType)gachaViewInfo.Value.Type;
		List<int> list;
		if (!roleBucketMap.TryGetValue(type, out list))
		{
			return;
		}
		GachaPool? gachaPoolConfig = ConfigBase<GachaConfig>.Instance.GetGachaPoolConfig(poolId);
		if (gachaPoolConfig == null)
		{
			return;
		}
		ProtoGachaPoolInfo validGachaPool = ModelBase<ActivityRegressModel>.Instance.GetValidGachaPool(gachaPoolConfig.Value.GachaId);
		int num = (((validGachaPool != null) ? validGachaPool.PreviewIdList.Length : 0) > 0) ? validGachaPool.PreviewIdList[0] : 0;
		if (num <= 0)
		{
			return;
		}
		list.Add(num);
	}

	// Token: 0x0600919A RID: 37274 RVA: 0x00266840 File Offset: 0x00264A40
	private List<int> GetSortedGachaPoolUpRoleList(Dictionary<GachaDefine.EGachaViewType, List<int>> roleBucketMap)
	{
		List<int> list = new List<int>();
		HashSet<int> seenRoleIds = new HashSet<int>();
		foreach (GachaDefine.EGachaViewType key in ActivityNewPlayerSupportActivityV2Controller.GachaPoolUpRoleCollectViewTypeList)
		{
			List<int> list2;
			if (roleBucketMap.TryGetValue(key, out list2) && list2.Count > 0)
			{
				list2.Sort(new Comparison<int>(this.SortByLevelQualityId));
				this.AppendUniqueAdventureRoleIds(list2, list, seenRoleIds);
			}
		}
		return list;
	}

	// Token: 0x0600919B RID: 37275 RVA: 0x002668A8 File Offset: 0x00264AA8
	private Dictionary<int, string> GetTrialRoleUnlockDesc()
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
		int num = (activityData != null) ? activityData.Id : 0;
		if (num > 0)
		{
			foreach (NewPlayerSupV2Trial newPlayerSupV2Trial in (ConfigNewPlayerSupV2TrialByActivityId.GetConfigList(num, true) ?? Array.Empty<NewPlayerSupV2Trial>()))
			{
				ConditionGroup? conditionGroup;
				string value = (ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(newPlayerSupV2Trial.ConditionGroup) != null) ? conditionGroup.GetValueOrDefault().HintText : null;
				if (!string.IsNullOrEmpty(value))
				{
					dictionary[newPlayerSupV2Trial.TrialRoleGroupId] = value;
				}
			}
		}
		if (dictionary.Count <= 0)
		{
			return ConfigBase<ActivityNewPlayerSupportConfig>.Instance.GetTrialRoleUnlockDesc();
		}
		return dictionary;
	}

	// Token: 0x0600919C RID: 37276 RVA: 0x00266974 File Offset: 0x00264B74
	private void OnTrialRoleUpdateNotify(NewPlayerSupportActivityTrialRoleUpdateV2Notify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		int activityId = notify.ActivityId;
		ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
		int? num = (activityData != null) ? new int?(activityData.Id) : null;
		if (!(activityId == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		foreach (int num2 in notify.TrialRoleId)
		{
			if (notify.CurUseRoleInfo != null && notify.CurUseRoleInfo.RoleId == num2)
			{
				ActivityNewPlayerSupportActivityV2Data activityData2 = this.ActivityData;
				if (activityData2 != null)
				{
					activityData2.UpdateActivatedTrialRole(num2, notify.CurUseRoleInfo);
				}
			}
			else
			{
				ActivityNewPlayerSupportActivityV2Data activityData3 = this.ActivityData;
				if (activityData3 != null)
				{
					activityData3.UpdateActivatedTrialRole(num2, null);
				}
			}
		}
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.RefreshCommonActivityRedDot;
		ActivityNewPlayerSupportActivityV2Data activityData4 = this.ActivityData;
		instance.Emit<int>(name, (activityData4 != null) ? activityData4.Id : 0);
	}

	// Token: 0x0600919D RID: 37277 RVA: 0x00266A5C File Offset: 0x00264C5C
	private void OnGachaRoleUpdateNotify(NewPlayerSupportV2GachaRoleUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		int activityId = notify.ActivityId;
		ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
		int? num = (activityData != null) ? new int?(activityData.Id) : null;
		if (!(activityId == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		ActivityNewPlayerSupportActivityV2Data activityData2 = this.ActivityData;
		if (activityData2 == null)
		{
			return;
		}
		activityData2.UpdateDeduplicateGachaRoleIds(notify.DeduplicateGachaRoleIds.ToArray<int>());
	}

	// Token: 0x04004398 RID: 17304
	private const int TrialRoleHelpId = 465;

	// Token: 0x04004399 RID: 17305
	[Nullable(2)]
	private ActivityNewPlayerSupportActivityV2Data ActivityDataInternal;

	// Token: 0x0400439A RID: 17306
	[StaticVariableRuleIgnore]
	private static readonly GachaDefine.EGachaViewType[] GachaPoolUpRoleCollectViewTypeList = new GachaDefine.EGachaViewType[]
	{
		GachaDefine.EGachaViewType.RoleUp,
		GachaDefine.EGachaViewType.CarnivalRole,
		GachaDefine.EGachaViewType.CyberRole,
		GachaDefine.EGachaViewType.OldCarnivalRole
	};
}
