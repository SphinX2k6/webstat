using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200154C RID: 5452
[NullableContext(2)]
[Nullable(0)]
public class ActivityRegressRoleSubView : ActivityRegressMainSubViewBase
{
	// Token: 0x06009901 RID: 39169 RVA: 0x002810E4 File Offset: 0x0027F2E4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = ActivityRegressMainViewComponentsInfo.Value;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnPnlBtnClick))
		};
	}

	// Token: 0x06009902 RID: 39170 RVA: 0x00281114 File Offset: 0x0027F314
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressRoleSubView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressRoleSubView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009903 RID: 39171 RVA: 0x00281158 File Offset: 0x0027F358
	protected override void OnStart()
	{
		base.OnStart();
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(0);
		UUIItem item = base.GetItem(5);
		this.ActivityRecallTabGroupPanel = new ActivityRegressTabGroupPanel(horizontalLayout, item, new Action<int>(this.TabCallBack));
		this.ActivityRecallTabGroupPanel.Init();
		base.GetItem(3).SetUIActive(true);
	}

	// Token: 0x06009904 RID: 39172 RVA: 0x002811AC File Offset: 0x0027F3AC
	protected override void OnBeforeDestroy()
	{
		this.ActivityRecallTabGroupPanel.Destroy();
		this.ActivityRecallTabGroupPanel = null;
	}

	// Token: 0x06009905 RID: 39173 RVA: 0x002811C0 File Offset: 0x0027F3C0
	protected override void OnUpdate(int subTabIndex)
	{
		List<RegressBase?> sortedOpenRegressBaseConfigList = ConfigBase<ActivityRegressConfig>.Instance.GetSortedOpenRegressBaseConfigList();
		this.TabCommonDataList = new List<ActivityRegressTabSwitchItemCommonData>();
		foreach (RegressBase? config in sortedOpenRegressBaseConfigList)
		{
			RoleInfo? roleConfigByGachaId = ModelBase<ActivityRegressModel>.Instance.GetRoleConfigByGachaId(config.Value.GachaId);
			ActivityRegressTabSwitchItemCommonData item = new ActivityRegressTabSwitchItemCommonData
			{
				RecallEntryType = this.EntryType,
				Config = config,
				Title = (((roleConfigByGachaId != null) ? roleConfigByGachaId.GetValueOrDefault().Name : null) ?? "")
			};
			this.TabCommonDataList.Add(item);
		}
		base.GetItem(7).SetUIActive(this.TabCommonDataList.Count > 1);
		this.ActivityRecallTabGroupPanel.RefreshByData(this.TabCommonDataList, subTabIndex);
	}

	// Token: 0x06009906 RID: 39174 RVA: 0x002812B4 File Offset: 0x0027F4B4
	private void TabCallBack(int index)
	{
		ActivityRegressTabSwitchItemCommonData activityRegressTabSwitchItemCommonData = this.TabCommonDataList[index];
		RegressBase value = activityRegressTabSwitchItemCommonData.Config.Value;
		this.ActivityRecallRoleActivityInfoPanel.RefreshData(value);
		ProtoGachaInfo gachaInfo = ModelBase<GachaModel>.Instance.GetGachaInfo(value.GachaId);
		if (gachaInfo == null)
		{
			return;
		}
		int usePoolId = gachaInfo.UsePoolId;
		ProtoGachaPoolInfo protoGachaPoolInfo = (usePoolId > 0) ? gachaInfo.GetPoolInfo(usePoolId) : gachaInfo.GetFirstValidPool();
		if (protoGachaPoolInfo == null)
		{
			return;
		}
		this.UpdateGachaPoolItem(gachaInfo, protoGachaPoolInfo);
		this.Config = activityRegressTabSwitchItemCommonData.Config;
		int gachaRoleId = ModelBase<ActivityRegressModel>.Instance.GetGachaRoleId(value.GachaId);
		this.RoleDescPanel.Update(gachaRoleId);
		this.SequencePlayer.PlaySequence("Start", false, null);
	}

	// Token: 0x06009907 RID: 39175 RVA: 0x00281370 File Offset: 0x0027F570
	public override void OnParentShow()
	{
		base.OnParentShow();
		SpineRoleGachaPoolItem spineRoleGachaPoolItem = this.GachaPoolItem as SpineRoleGachaPoolItem;
		if (spineRoleGachaPoolItem != null)
		{
			spineRoleGachaPoolItem.PlayStartSeq();
			return;
		}
		UpRoleGachaPoolItem upRoleGachaPoolItem = this.GachaPoolItem as UpRoleGachaPoolItem;
		if (upRoleGachaPoolItem != null)
		{
			upRoleGachaPoolItem.PlayStartSeq();
		}
	}

	// Token: 0x06009908 RID: 39176 RVA: 0x002813B0 File Offset: 0x0027F5B0
	private unsafe void OnPnlBtnClick()
	{
		int gachaTrialRoleId = ModelBase<ActivityRegressModel>.Instance.GetGachaTrialRoleId(this.Config.Value.GachaId);
		RoleController instance = ControllerBase<RoleController>.Instance;
		ERoleAgentType agentType = ERoleAgentType.Preview;
		int selectRoleId = 0;
		int num = 1;
		List<int> list = new List<int>(num);
		CollectionsMarshal.SetCount<int>(list, num);
		Span<int> span = CollectionsMarshal.AsSpan<int>(list);
		int index = 0;
		*span[index] = gachaTrialRoleId;
		instance.OpenRoleMainView(agentType, selectRoleId, list, null, null);
	}

	// Token: 0x06009909 RID: 39177 RVA: 0x00281418 File Offset: 0x0027F618
	[NullableContext(1)]
	private UniTask UpdateGachaPoolItem(ProtoGachaInfo gachaInfo, ProtoGachaPoolInfo poolInfo)
	{
		ActivityRegressRoleSubView.<UpdateGachaPoolItem>d__17 <UpdateGachaPoolItem>d__;
		<UpdateGachaPoolItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateGachaPoolItem>d__.<>4__this = this;
		<UpdateGachaPoolItem>d__.gachaInfo = gachaInfo;
		<UpdateGachaPoolItem>d__.poolInfo = poolInfo;
		<UpdateGachaPoolItem>d__.<>1__state = -1;
		<UpdateGachaPoolItem>d__.<>t__builder.Start<ActivityRegressRoleSubView.<UpdateGachaPoolItem>d__17>(ref <UpdateGachaPoolItem>d__);
		return <UpdateGachaPoolItem>d__.<>t__builder.Task;
	}

	// Token: 0x040046B4 RID: 18100
	private ActivityRoleDescribeComponent RoleDescPanel;

	// Token: 0x040046B5 RID: 18101
	private ActivityRegressTabGroupPanel ActivityRecallTabGroupPanel;

	// Token: 0x040046B6 RID: 18102
	private ActivityRegressRoleActivityInfoPanel ActivityRecallRoleActivityInfoPanel;

	// Token: 0x040046B7 RID: 18103
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ActivityRegressTabSwitchItemCommonData> TabCommonDataList;

	// Token: 0x040046B8 RID: 18104
	private EActivityRegressEntranceType? EntryType;

	// Token: 0x040046B9 RID: 18105
	private RegressBase? Config;

	// Token: 0x040046BA RID: 18106
	private GachaPoolItem GachaPoolItem;

	// Token: 0x040046BB RID: 18107
	private ERecallRolePoolItemType? RolePoolItemType;

	// Token: 0x040046BC RID: 18108
	private float PoolItemAnchorOffsetX;
}
