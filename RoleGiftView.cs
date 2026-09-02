using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200156F RID: 5487
[NullableContext(2)]
[Nullable(0)]
public class RoleGiftView : ActivitySubViewBase
{
	// Token: 0x06009A09 RID: 39433 RVA: 0x00285504 File Offset: 0x00283704
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x06009A0A RID: 39434 RVA: 0x002855DB File Offset: 0x002837DB
	protected override void OnSetData()
	{
		this.RoleGiftDataField = (this.ActivityBaseData as RoleGiftData);
	}

	// Token: 0x06009A0B RID: 39435 RVA: 0x002855F0 File Offset: 0x002837F0
	protected override UniTask OnBeforeStartAsync()
	{
		RoleGiftView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleGiftView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009A0C RID: 39436 RVA: 0x00285633 File Offset: 0x00283833
	protected override void OnStart()
	{
		base.RefreshView();
	}

	// Token: 0x06009A0D RID: 39437 RVA: 0x0028563B File Offset: 0x0028383B
	protected override void OnRefreshView()
	{
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			commonInfoPanel.OnRefreshView();
		}
		this.Refresh();
	}

	// Token: 0x06009A0E RID: 39438 RVA: 0x00285654 File Offset: 0x00283854
	private void Refresh()
	{
		RoleGiftData roleGiftDataField = this.RoleGiftDataField;
		if (roleGiftDataField == null)
		{
			return;
		}
		bool flag = roleGiftDataField.IsUnLock();
		base.GetItem(3).SetUIActive(!flag);
		bool flag2 = flag && !roleGiftDataField.GetRewardHadGet();
		ButtonItem rewardBtnItem = this.RewardBtnItem;
		if (rewardBtnItem != null)
		{
			rewardBtnItem.SetUiActive(flag2);
		}
		ButtonItem rewardBtnItem2 = this.RewardBtnItem;
		if (rewardBtnItem2 != null)
		{
			rewardBtnItem2.SetEnableClick(flag2);
		}
		ButtonItem rewardBtnItem3 = this.RewardBtnItem;
		if (rewardBtnItem3 != null)
		{
			rewardBtnItem3.SetRedDotVisible(flag2);
		}
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			ActivityFunctionalTypeA functional = commonInfoPanel.GetFunctional();
			if (functional != null)
			{
				functional.SetFunctionRedDotVisible(flag2);
			}
		}
		base.GetItem(4).SetUIActive(roleGiftDataField.GetRewardHadGet());
		ActivitySubViewGeneralInfo commonInfoPanel2 = this.CommonInfoPanel;
		if (commonInfoPanel2 != null)
		{
			ActivityFunctionalTypeA functional2 = commonInfoPanel2.GetFunctional();
			if (functional2 != null)
			{
				functional2.SetUiActive(false);
			}
		}
		int roleId = roleGiftDataField.GetRoleId();
		if (roleId > 0)
		{
			RoleDescribeComponent descComponent = this.DescComponent;
			if (descComponent == null)
			{
				return;
			}
			descComponent.Update(roleId, false);
		}
	}

	// Token: 0x06009A0F RID: 39439 RVA: 0x00285734 File Offset: 0x00283934
	private unsafe void OnBtnCheckDetailClick()
	{
		RoleGiftData roleGiftDataField = this.RoleGiftDataField;
		if (roleGiftDataField == null)
		{
			string message = "OnBtnCheckDetailClick";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", "no_gift_data");
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "activityId";
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			ptr = new ValueTuple<string, object>(item, (activityBaseData != null) ? new int?(activityBaseData.Id) : null);
			RoleGiftUtil.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		int roleTrialId = roleGiftDataField.GetRoleTrialId();
		if (roleTrialId == 0)
		{
			string message2 = "OnBtnCheckDetailClick";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("reason", "no_role_trial_id");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("activityId", roleGiftDataField.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("roleId", roleGiftDataField.GetRoleId());
			RoleGiftUtil.Debug(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return;
		}
		string message3 = "OnBtnCheckDetailClick";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("reason", "open_preview");
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("roleTrialId", roleTrialId);
		RoleGiftUtil.Debug(message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
		RoleController instance = ControllerBase<RoleController>.Instance;
		ERoleAgentType agentType = ERoleAgentType.Preview;
		int selectRoleId = 0;
		int num = 1;
		List<int> list = new List<int>(num);
		CollectionsMarshal.SetCount<int>(list, num);
		Span<int> span = CollectionsMarshal.AsSpan<int>(list);
		int index = 0;
		*span[index] = roleTrialId;
		instance.OpenRoleMainView(agentType, selectRoleId, list, null, null);
	}

	// Token: 0x06009A10 RID: 39440 RVA: 0x002858D8 File Offset: 0x00283AD8
	private void OnBtnGetRewardClick()
	{
		if (this.ActivityBaseData == null)
		{
			return;
		}
		int id = this.ActivityBaseData.Id;
		string message = "点击领奖";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", id);
		RoleGiftUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ControllerBase<RoleGiftController>.Instance.RequestRoleGiftReward(id).Forget();
	}

	// Token: 0x0400470D RID: 18189
	public RoleGiftData RoleGiftDataField;

	// Token: 0x0400470E RID: 18190
	private ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x0400470F RID: 18191
	private RoleDescribeComponent DescComponent;

	// Token: 0x04004710 RID: 18192
	private FunctionalPanelConditionLock LockPanel;

	// Token: 0x04004711 RID: 18193
	private ButtonItem RewardBtnItem;

	// Token: 0x02007934 RID: 31028
	[NullableContext(0)]
	private enum ENode
	{
		// Token: 0x04029A4F RID: 170575
		ItemCommonInfo,
		// Token: 0x04029A50 RID: 170576
		ItemRoleDesc,
		// Token: 0x04029A51 RID: 170577
		BtnGetReward,
		// Token: 0x04029A52 RID: 170578
		ItemLock,
		// Token: 0x04029A53 RID: 170579
		ItemRewarded
	}
}
