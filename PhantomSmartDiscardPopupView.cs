using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002043 RID: 8259
[NullableContext(1)]
[Nullable(0)]
public class PhantomSmartDiscardPopupView : UiViewBase
{
	// Token: 0x0600FB98 RID: 64408 RVA: 0x00450F0F File Offset: 0x0044F10F
	public PhantomSmartDiscardPopupView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FB99 RID: 64409 RVA: 0x00450F3C File Offset: 0x0044F13C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 5;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickHelpBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickChoose));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnToggleUserFilter));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnToggleRecommendFilter));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickConfirmBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600FB9A RID: 64410 RVA: 0x00451114 File Offset: 0x0044F314
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomSmartDiscardPopupView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomSmartDiscardPopupView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FB9B RID: 64411 RVA: 0x00451157 File Offset: 0x0044F357
	protected override void OnBeforeShow()
	{
		this.InitPlanList();
		this.UpdateUserFilterToggleInteractive();
		this.UpdateDiscardFilter();
	}

	// Token: 0x0600FB9C RID: 64412 RVA: 0x0045116C File Offset: 0x0044F36C
	private void UpdateDiscardFilter()
	{
		this.DiscardPhantomList = this.CalculateDiscardList();
		int count = this.DiscardPhantomList.Count;
		UUIText text = base.GetText(5);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PrefabTextItem_1413403477_Text", new <>z__ReadOnlySingleElementList<object>(this.DiscardPhantomList.Count));
		base.GetButton(6).SetSelfInteractive(count > 0);
	}

	// Token: 0x0600FB9D RID: 64413 RVA: 0x004511CE File Offset: 0x0044F3CE
	private void InitPlanList()
	{
		this.DiscardPhantomRecommendList = this.ConfigData.GetPhantomSmartDiscardRecommendPlan();
		this.DiscardPhantomUserPlanList = this.ConfigData.GetPhantomSmartDiscardUserPlan();
	}

	// Token: 0x0600FB9E RID: 64414 RVA: 0x004511F4 File Offset: 0x0044F3F4
	private void UpdateUserFilterToggleInteractive()
	{
		Dictionary<int, bool> isUsingMap = this.ConfigData.IsUsingMap;
		bool flag = false;
		foreach (KeyValuePair<int, bool> keyValuePair in isUsingMap)
		{
			if (keyValuePair.Value)
			{
				flag = true;
				break;
			}
		}
		this.HasUserOnPlan = flag;
		this.ActivatePanel.SetUiActive(!flag);
		if (!flag)
		{
			this.UseUserFilter = false;
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x0600FB9F RID: 64415 RVA: 0x0045128C File Offset: 0x0044F48C
	private List<PhantomItemData> CalculateDiscardList()
	{
		HashSet<PhantomItemData> hashSet = new HashSet<PhantomItemData>();
		if (this.UseRecommendFilter)
		{
			foreach (PhantomItemData item in this.DiscardPhantomRecommendList)
			{
				hashSet.Add(item);
			}
		}
		if (this.UseUserFilter)
		{
			foreach (PhantomItemData item2 in this.DiscardPhantomUserPlanList)
			{
				hashSet.Add(item2);
			}
		}
		List<PhantomItemData> list = new List<PhantomItemData>();
		foreach (PhantomItemData item3 in hashSet)
		{
			list.Add(item3);
		}
		return list;
	}

	// Token: 0x0600FBA0 RID: 64416 RVA: 0x00451384 File Offset: 0x0044F584
	private void OnClickHelpBtn()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(532);
	}

	// Token: 0x0600FBA1 RID: 64417 RVA: 0x00451398 File Offset: 0x0044F598
	private void OnClickChoose()
	{
		HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.PhantomDiscardPlanRecycleSet, null);
		if (player == null || !player.Contains(2))
		{
			HashSet<int> hashSet = player ?? new HashSet<int>();
			hashSet.Add(2);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.PhantomDiscardPlanRecycleSet, hashSet);
			PhantomDiscardPlanSmartDiscardReport phantomDiscardPlanSmartDiscardReport = new PhantomDiscardPlanSmartDiscardReport();
			phantomDiscardPlanSmartDiscardReport.i_type = 2;
			ControllerBase<LogReportController>.Instance.LogReport(phantomDiscardPlanSmartDiscardReport);
		}
		ControllerBase<InventoryController>.Instance.OpenManageConfigNewView();
	}

	// Token: 0x0600FBA2 RID: 64418 RVA: 0x00451400 File Offset: 0x0044F600
	private void OnToggleUserFilter(EToggleState state)
	{
		bool flag = ModelBase<FunctionModel>.Instance.IsOpen(10096);
		if (!flag || !this.HasUserOnPlan)
		{
			string textId = flag ? "PrefabTextItem_18455432_Text" : "PhantomManagementLocked_Tips";
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(textId, Array.Empty<object>());
			return;
		}
		this.UseUserFilter = (state == EToggleState.ETT_Checked);
		this.UpdateDiscardFilter();
		HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.PhantomDiscardPlanRecycleSet, null);
		if (player == null || !player.Contains(3))
		{
			HashSet<int> hashSet = player ?? new HashSet<int>();
			hashSet.Add(3);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.PhantomDiscardPlanRecycleSet, hashSet);
			PhantomDiscardPlanSmartDiscardReport phantomDiscardPlanSmartDiscardReport = new PhantomDiscardPlanSmartDiscardReport();
			phantomDiscardPlanSmartDiscardReport.i_type = 3;
			ControllerBase<LogReportController>.Instance.LogReport(phantomDiscardPlanSmartDiscardReport);
		}
	}

	// Token: 0x0600FBA3 RID: 64419 RVA: 0x004514C4 File Offset: 0x0044F6C4
	private void OnToggleRecommendFilter(EToggleState state)
	{
		HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.PhantomDiscardPlanRecycleSet, null);
		if (player == null || !player.Contains(1))
		{
			HashSet<int> hashSet = player ?? new HashSet<int>();
			hashSet.Add(1);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.PhantomDiscardPlanRecycleSet, hashSet);
			PhantomDiscardPlanSmartDiscardReport phantomDiscardPlanSmartDiscardReport = new PhantomDiscardPlanSmartDiscardReport();
			phantomDiscardPlanSmartDiscardReport.i_type = 1;
			ControllerBase<LogReportController>.Instance.LogReport(phantomDiscardPlanSmartDiscardReport);
		}
		this.UseRecommendFilter = (state == EToggleState.ETT_Checked);
		this.UpdateDiscardFilter();
	}

	// Token: 0x0600FBA4 RID: 64420 RVA: 0x00451530 File Offset: 0x0044F730
	private void OnClickConfirmBtn()
	{
		if (this.DiscardPhantomList.Count == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("NoPhantomDiscarded_Tips", Array.Empty<object>());
			return;
		}
		this.ShowConfirmPopup();
	}

	// Token: 0x0600FBA5 RID: 64421 RVA: 0x0045155C File Offset: 0x0044F75C
	private void ShowConfirmPopup()
	{
		PhantomDiscardPlanSmartDiscardConfirmReport logData = new PhantomDiscardPlanSmartDiscardConfirmReport();
		List<int> list = new List<int>();
		foreach (PhantomItemData phantomItemData in this.DiscardPhantomList)
		{
			list.Add(phantomItemData.GetUniqueId());
		}
		Action<bool> <>9__2;
		PhantomConfirmPopupViewData param = new PhantomConfirmPopupViewData
		{
			Title = "PhantomFilterDiscardConfirmTitle",
			SubTitle = "PhantomFilterDiscardDisplayTips",
			PhantomUniqueIdList = list,
			OnMiddle = delegate
			{
				logData.i_type = 1;
				ControllerBase<LogReportController>.Instance.LogReport(logData);
				this.ExecuteBatchDiscard();
			},
			OnRight = delegate
			{
				logData.i_type = 2;
				ControllerBase<LogReportController>.Instance.LogReport(logData);
				List<int> list2 = new List<int>();
				foreach (PhantomItemData phantomItemData2 in this.DiscardPhantomList)
				{
					list2.Add(phantomItemData2.GetUniqueId());
				}
				UniTask<bool> task = ControllerBase<InventoryController>.Instance.ShowPhantomDiscardFusionTip(list2.ToArray());
				Action<bool> continuationFunction;
				if ((continuationFunction = <>9__2) == null)
				{
					continuationFunction = (<>9__2 = delegate(bool value)
					{
						if (value)
						{
							ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_Warning07", Array.Empty<object>());
							this.CloseMe(null);
						}
					});
				}
				task.ContinueWith(continuationFunction);
			},
			MiddleTxtKey = "PhantomFilterButtonText_Confirm",
			RightTxtKey = "PhantomFilterButtonText_Merge"
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomBatchConfirmPopupView, param, null);
	}

	// Token: 0x0600FBA6 RID: 64422 RVA: 0x00451644 File Offset: 0x0044F844
	private UniTask ExecuteBatchDiscard()
	{
		PhantomSmartDiscardPopupView.<ExecuteBatchDiscard>d__25 <ExecuteBatchDiscard>d__;
		<ExecuteBatchDiscard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExecuteBatchDiscard>d__.<>4__this = this;
		<ExecuteBatchDiscard>d__.<>1__state = -1;
		<ExecuteBatchDiscard>d__.<>t__builder.Start<PhantomSmartDiscardPopupView.<ExecuteBatchDiscard>d__25>(ref <ExecuteBatchDiscard>d__);
		return <ExecuteBatchDiscard>d__.<>t__builder.Task;
	}

	// Token: 0x040078C7 RID: 30919
	private const int HELP_ID = 532;

	// Token: 0x040078C8 RID: 30920
	[Nullable(2)]
	private IPhantomSmartDiscardViewData ViewData;

	// Token: 0x040078C9 RID: 30921
	protected PhantomManagerConfigData ConfigData;

	// Token: 0x040078CA RID: 30922
	private bool UseUserFilter;

	// Token: 0x040078CB RID: 30923
	private bool UseRecommendFilter;

	// Token: 0x040078CC RID: 30924
	private List<PhantomItemData> DiscardPhantomRecommendList = new List<PhantomItemData>();

	// Token: 0x040078CD RID: 30925
	private List<PhantomItemData> DiscardPhantomUserPlanList = new List<PhantomItemData>();

	// Token: 0x040078CE RID: 30926
	private List<PhantomItemData> DiscardPhantomList = new List<PhantomItemData>();

	// Token: 0x040078CF RID: 30927
	private bool HasUserOnPlan;

	// Token: 0x040078D0 RID: 30928
	private PhantomSmartDiscardPopupActivatePanel ActivatePanel;

	// Token: 0x020083E8 RID: 33768
	[NullableContext(0)]
	private enum EPhantomSmartDiscardComp
	{
		// Token: 0x0402CB74 RID: 183156
		BtnHelpInfo,
		// Token: 0x0402CB75 RID: 183157
		TogRecommendFilter,
		// Token: 0x0402CB76 RID: 183158
		BtnChoose,
		// Token: 0x0402CB77 RID: 183159
		TogUserFilter,
		// Token: 0x0402CB78 RID: 183160
		PanelEmptyTips,
		// Token: 0x0402CB79 RID: 183161
		TxtDiscardNumber,
		// Token: 0x0402CB7A RID: 183162
		BtnConfirmA
	}
}
