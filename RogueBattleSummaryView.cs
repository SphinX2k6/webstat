using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200277C RID: 10108
[NullableContext(1)]
[Nullable(0)]
public class RogueBattleSummaryView : UiViewBase
{
	// Token: 0x06013EEE RID: 81646 RVA: 0x0058E41F File Offset: 0x0058C61F
	public RogueBattleSummaryView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013EEF RID: 81647 RVA: 0x0058E434 File Offset: 0x0058C634
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x06013EF0 RID: 81648 RVA: 0x0058E4E8 File Offset: 0x0058C6E8
	protected override UniTask OnBeforeStartAsync()
	{
		RogueBattleSummaryView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleSummaryView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013EF1 RID: 81649 RVA: 0x0058E524 File Offset: 0x0058C724
	protected override void OnStart()
	{
		this.TsUiSceneRoleActor = Singleton<UiSceneManager>.Instance.InitRoleSystemRoleActor(EUiModelUseWay.RoleInRoleView);
		TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
		object obj;
		if (tsUiSceneRoleActor == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = tsUiSceneRoleActor.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiModelDataComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.SetVisible(false);
		}
		TsUiSceneRoleActor tsUiSceneRoleActor2 = this.TsUiSceneRoleActor;
		object obj3;
		if (tsUiSceneRoleActor2 == null)
		{
			obj3 = null;
		}
		else
		{
			UiModelBase model2 = tsUiSceneRoleActor2.Model;
			obj3 = ((model2 != null) ? model2.CheckGetComponent<UiModelLoadingIconComponent>() : null);
		}
		object obj4 = obj3;
		if (obj4 != null)
		{
			obj4.SetLoadingOpen(false);
		}
		this.InitTabComponent();
		this.InitExtendToggle();
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		ModelBase<RogueBattleModel>.Instance.CurrentMapSummaryBond = 0;
	}

	// Token: 0x06013EF2 RID: 81650 RVA: 0x0058E5C1 File Offset: 0x0058C7C1
	protected override void OnBeforeShow()
	{
		this.RefreshTabListAsync().Forget();
	}

	// Token: 0x06013EF3 RID: 81651 RVA: 0x0058E5CE File Offset: 0x0058C7CE
	protected override void OnBeforeDestroy()
	{
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
	}

	// Token: 0x06013EF4 RID: 81652 RVA: 0x0058E5EB File Offset: 0x0058C7EB
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RogueResMapSummaryTeamToBondUpdate, new Action(this.OnJumpToBondTab));
	}

	// Token: 0x06013EF5 RID: 81653 RVA: 0x0058E609 File Offset: 0x0058C809
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RogueResMapSummaryTeamToBondUpdate, new Action(this.OnJumpToBondTab));
	}

	// Token: 0x06013EF6 RID: 81654 RVA: 0x0058E628 File Offset: 0x0058C828
	protected override void OnHandleLoadScene()
	{
		if (this.TsUiSceneRoleActor == null)
		{
			this.TsUiSceneRoleActor = Singleton<UiSceneManager>.Instance.InitRoleSystemRoleActor(EUiModelUseWay.RoleInRoleView);
		}
		UiModelBase model = this.TsUiSceneRoleActor.Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		if (uiModelActorComponent != null)
		{
			uiModelActorComponent.SetTransformByTag("RoleCase");
		}
		if (this.CurSelectTabView == EUiTabViewName.RogueBattleSummaryTeamTabView)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.RogueResMapSummaryTeamShowAgain);
		}
	}

	// Token: 0x06013EF7 RID: 81655 RVA: 0x0058E6AD File Offset: 0x0058C8AD
	protected override void OnHandleReleaseScene()
	{
		Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.TsUiSceneRoleActor);
		this.TsUiSceneRoleActor = null;
	}

	// Token: 0x06013EF8 RID: 81656 RVA: 0x0058E6C7 File Offset: 0x0058C8C7
	private void OnCloseClicked()
	{
		base.CloseMe(null);
	}

	// Token: 0x06013EF9 RID: 81657 RVA: 0x0058E6D0 File Offset: 0x0058C8D0
	protected void InitTabComponent()
	{
		CommonTabComponentData<CommonTabItem> data = new CommonTabComponentData<CommonTabItem>(new Func<UUIItem, int?, CommonTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
		this.TabComponent = new TabComponentWithCaptionItem<CommonTabItem>(base.GetItem(0), data, new Action(this.OnCloseClicked), false);
		this.LastClickTime = null;
		this.TabComponent.SetCanChange(new Func<int, bool?, bool>(this.CanToggleChange));
		this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(1), EKeyMode.Default);
	}

	// Token: 0x06013EFA RID: 81658 RVA: 0x0058E760 File Offset: 0x0058C960
	protected void InitExtendToggle()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(4);
		EToggleState state = (ModelBase<RogueBattleModel>.Instance.DescMode == EDescModel.DETAIL) ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(state, false, false, false);
		}
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnExtendToggleStateChange));
	}

	// Token: 0x06013EFB RID: 81659 RVA: 0x0058E7B4 File Offset: 0x0058C9B4
	private UniTask RefreshTabListAsync()
	{
		RogueBattleSummaryView.<RefreshTabListAsync>d__19 <RefreshTabListAsync>d__;
		<RefreshTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabListAsync>d__.<>4__this = this;
		<RefreshTabListAsync>d__.<>1__state = -1;
		<RefreshTabListAsync>d__.<>t__builder.Start<RogueBattleSummaryView.<RefreshTabListAsync>d__19>(ref <RefreshTabListAsync>d__);
		return <RefreshTabListAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013EFC RID: 81660 RVA: 0x0058E7F8 File Offset: 0x0058C9F8
	private CommonTabData GetCommonData(int index)
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[index];
		return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
	}

	// Token: 0x06013EFD RID: 81661 RVA: 0x0058E830 File Offset: 0x0058CA30
	protected bool CanToggleChange(int index, bool? _)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			return true;
		}
		int? intConfig = ConfigCommonParamById.GetIntConfig("panel_interval_time");
		if (this.LastClickTime != null)
		{
			double num = Singleton<Time>.Instance.Now - this.LastClickTime.Value;
			int? num2 = intConfig;
			double? num3 = (num2 != null) ? new double?((double)num2.GetValueOrDefault()) : null;
			if (!(num >= num3.GetValueOrDefault() & num3 != null))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06013EFE RID: 81662 RVA: 0x0058E8B6 File Offset: 0x0058CAB6
	private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new CommonTabItem();
	}

	// Token: 0x06013EFF RID: 81663 RVA: 0x0058E8C0 File Offset: 0x0058CAC0
	private void ToggleCallBack(int index)
	{
		this.LastClickTime = new double?(Singleton<Time>.Instance.Now);
		UiDynamicTab data = this.TabDataList[index];
		EUiTabViewName euiTabViewName = (EUiTabViewName)data.ChildViewName;
		this.OnTeamTabShow(euiTabViewName == EUiTabViewName.RogueBattleSummaryTeamTabView);
		this.OnTokenTabShow(euiTabViewName == EUiTabViewName.RogueBattleSummaryTokenTabView);
		CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
		this.TabViewComponent.ToggleCallBack(data, euiTabViewName, tabItemByIndex, null, null);
		this.CurSelectTabView = new EUiTabViewName?(euiTabViewName);
		this.RefreshTabHelpId(euiTabViewName);
		this.RefreshElementInfo(euiTabViewName);
	}

	// Token: 0x06013F00 RID: 81664 RVA: 0x0058E960 File Offset: 0x0058CB60
	private void OnTeamTabShow(bool isVisible)
	{
		TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
		object obj;
		if (tsUiSceneRoleActor == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = tsUiSceneRoleActor.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiModelDataComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.SetVisible(isVisible);
		}
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(!isVisible);
	}

	// Token: 0x06013F01 RID: 81665 RVA: 0x0058E9B0 File Offset: 0x0058CBB0
	private void OnTokenTabShow(bool isOpen)
	{
		if (!isOpen)
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
			return;
		}
		else
		{
			bool flag = ModelBase<RogueBattleModel>.Instance.GetTokenData().Count == 0;
			UUIItem item3 = base.GetItem(2);
			if (item3 != null)
			{
				item3.SetUIActive(flag);
			}
			UUIItem item4 = base.GetItem(6);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(!flag);
			return;
		}
	}

	// Token: 0x06013F02 RID: 81666 RVA: 0x0058EA21 File Offset: 0x0058CC21
	private void OnExtendToggleStateChange(EToggleState newState)
	{
		ModelBase<RogueBattleModel>.Instance.ChangeDescMode();
	}

	// Token: 0x06013F03 RID: 81667 RVA: 0x0058EA30 File Offset: 0x0058CC30
	private void OnJumpToBondTab()
	{
		for (int i = 0; i < this.TabDataList.Count; i++)
		{
			if ((EUiTabViewName)this.TabDataList[i].ChildViewName == EUiTabViewName.RogueBattleMapSummaryFettersTabView)
			{
				this.TabComponent.SelectToggleByIndex(i, false);
				return;
			}
		}
	}

	// Token: 0x06013F04 RID: 81668 RVA: 0x0058EA86 File Offset: 0x0058CC86
	private void RefreshElementInfo(EUiTabViewName viewName)
	{
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x06013F05 RID: 81669 RVA: 0x0058EA9A File Offset: 0x0058CC9A
	private void RefreshTabHelpId(EUiTabViewName viewName)
	{
		this.TabComponent.SetHelpButtonShowState(false);
	}

	// Token: 0x04009B34 RID: 39732
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponentWithCaptionItem<CommonTabItem> TabComponent;

	// Token: 0x04009B35 RID: 39733
	[Nullable(2)]
	protected TabViewComponent<UiDynamicTab> TabViewComponent;

	// Token: 0x04009B36 RID: 39734
	private double? LastClickTime;

	// Token: 0x04009B37 RID: 39735
	protected List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

	// Token: 0x04009B38 RID: 39736
	private EUiTabViewName? CurSelectTabView;

	// Token: 0x04009B39 RID: 39737
	[Nullable(2)]
	private TsUiSceneRoleActor TsUiSceneRoleActor;
}
