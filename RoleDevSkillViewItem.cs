using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200282B RID: 10283
[NullableContext(1)]
[Nullable(0)]
public class RoleDevSkillViewItem : UiPanelBase
{
	// Token: 0x0601458F RID: 83343 RVA: 0x005A888C File Offset: 0x005A6A8C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickSwitchState))
		};
	}

	// Token: 0x06014590 RID: 83344 RVA: 0x005A8A48 File Offset: 0x005A6C48
	protected override UniTask OnBeforeStartAsync()
	{
		RoleDevSkillViewItem.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevSkillViewItem.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014591 RID: 83345 RVA: 0x005A8A8B File Offset: 0x005A6C8B
	protected override void OnBeforeCreateImplement()
	{
		this.UiViewSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiViewSequence);
	}

	// Token: 0x06014592 RID: 83346 RVA: 0x005A8AA5 File Offset: 0x005A6CA5
	public void Refresh(RoleDevSkillViewItemDataBase data)
	{
		this.Data = data;
		this.RefreshSkillSlots(data);
		this.HandlePerfectPlan(data);
		this.RefreshDetailItems(data);
		this.RefreshButtonStates(data);
	}

	// Token: 0x06014593 RID: 83347 RVA: 0x005A8ACC File Offset: 0x005A6CCC
	private void HandlePerfectPlan(RoleDevSkillViewItemDataBase data)
	{
		bool flag = RoleDevUtils.GetRoleTypeTagByRoleId(data.RoleId) == global::ERoleTypeTag.Forecast;
		string textStringId = (data.IsPerfectPlan || data.ShouldForcePerfectPlan) ? "RoleProject_SkillUpgradePrefect" : "RoleProject_SkillUpgradeBasic";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), textStringId, Array.Empty<object>());
		if (flag)
		{
			UUIButtonComponent button = base.GetButton(1);
			UUIText text = base.GetText(0);
			if (button != null && text != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
				text.SetUIActive(false);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "RoleProject_SkillUpgradePrefect", Array.Empty<object>());
			return;
		}
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(data.RoleId);
		bool flag2 = cultivateProject != null && cultivateProject.Value.PrefectSkillLevel() != null && cultivateProject.Value.PrefectSkillLevel().Length != 0;
		UUIButtonComponent button2 = base.GetButton(1);
		UUIText text2 = base.GetText(0);
		if (button2 == null || text2 == null)
		{
			return;
		}
		bool flag3 = flag2 && !data.ShouldForcePerfectPlan;
		button2.RootUIComp.Get().SetUIActive(flag3);
		text2.SetUIActive(flag3);
		if (flag3)
		{
			string textStringId2 = data.IsPerfectPlan ? "RoleProject_Button_SkillUpgradeBasic" : "RoleProject_Button_SkillUpgradePrefect";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, textStringId2, Array.Empty<object>());
		}
	}

	// Token: 0x06014594 RID: 83348 RVA: 0x005A8C28 File Offset: 0x005A6E28
	private void RefreshDetailItems(RoleDevSkillViewItemDataBase data)
	{
		List<global::IRoleDevDetailItemData> list = (RoleDevUtils.GetRoleTypeTagByRoleId(data.RoleId) == global::ERoleTypeTag.Forecast || data.IsPerfectPlan || data.ShouldForcePerfectPlan) ? data.PerfectDetailItems : data.NormalDetailItems;
		GenericLayout<RoleDevDetailItem, global::IRoleDevDetailItemData> detailVerticalLayout = this.DetailVerticalLayout;
		if (detailVerticalLayout != null)
		{
			detailVerticalLayout.RefreshByData(list, null, false);
		}
		base.GetItem(16).SetUIActive(list.Count != 0);
	}

	// Token: 0x06014595 RID: 83349 RVA: 0x005A8C94 File Offset: 0x005A6E94
	private void RefreshButtonStates(RoleDevSkillViewItemDataBase data)
	{
		base.GetVerticalLayout(12).RootUIComp.Get().SetUIActive(true);
		int num = (RoleDevUtils.GetRoleTypeTagByRoleId(data.RoleId) == global::ERoleTypeTag.Forecast) ? 1 : 0;
		bool isRoleOwned = data.IsRoleOwned;
		bool flag = num == 0 && isRoleOwned;
		base.GetItem(7).SetUIActive(flag);
		base.GetItem(11).SetUIActive(!flag);
		if (!isRoleOwned)
		{
			ButtonItem normalButtonItem = this.NormalButtonItem;
			if (normalButtonItem != null)
			{
				normalButtonItem.SetUiActive(false);
			}
			ButtonItem highLightButtonItem = this.HighLightButtonItem;
			if (highLightButtonItem != null)
			{
				highLightButtonItem.SetUiActive(false);
			}
			base.GetItem(9).SetUIActive(false);
			return;
		}
		bool uiActive;
		bool uiActive2;
		string textId;
		bool flag2;
		if (data.CurrentPlanFinished)
		{
			bool isBreakthroughLevelLow = data.IsBreakthroughLevelLow;
			uiActive = true;
			uiActive2 = false;
			textId = "RoleProject_Button02";
			flag2 = isBreakthroughLevelLow;
		}
		else
		{
			bool currentPlanMaterialEnough = data.CurrentPlanMaterialEnough;
			uiActive = !currentPlanMaterialEnough;
			uiActive2 = currentPlanMaterialEnough;
			textId = "RoleProject_Button01";
			flag2 = false;
		}
		ButtonItem normalButtonItem2 = this.NormalButtonItem;
		if (normalButtonItem2 != null)
		{
			normalButtonItem2.SetLocalTextNew(textId, Array.Empty<object>());
		}
		ButtonItem highLightButtonItem2 = this.HighLightButtonItem;
		if (highLightButtonItem2 != null)
		{
			highLightButtonItem2.SetLocalTextNew(textId, Array.Empty<object>());
		}
		ButtonItem normalButtonItem3 = this.NormalButtonItem;
		if (normalButtonItem3 != null)
		{
			normalButtonItem3.SetUiActive(uiActive);
		}
		ButtonItem highLightButtonItem3 = this.HighLightButtonItem;
		if (highLightButtonItem3 != null)
		{
			highLightButtonItem3.SetUiActive(uiActive2);
		}
		base.GetItem(9).SetUIActive(flag2);
		if (flag2)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "RoleProject_Tips05", Array.Empty<object>());
		}
	}

	// Token: 0x06014596 RID: 83350 RVA: 0x005A8DF4 File Offset: 0x005A6FF4
	private UniTask InitializeSkillSlots()
	{
		RoleDevSkillViewItem.<InitializeSkillSlots>d__18 <InitializeSkillSlots>d__;
		<InitializeSkillSlots>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeSkillSlots>d__.<>4__this = this;
		<InitializeSkillSlots>d__.<>1__state = -1;
		<InitializeSkillSlots>d__.<>t__builder.Start<RoleDevSkillViewItem.<InitializeSkillSlots>d__18>(ref <InitializeSkillSlots>d__);
		return <InitializeSkillSlots>d__.<>t__builder.Task;
	}

	// Token: 0x06014597 RID: 83351 RVA: 0x005A8E38 File Offset: 0x005A7038
	private UniTask InitializeButtons()
	{
		RoleDevSkillViewItem.<InitializeButtons>d__19 <InitializeButtons>d__;
		<InitializeButtons>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeButtons>d__.<>4__this = this;
		<InitializeButtons>d__.<>1__state = -1;
		<InitializeButtons>d__.<>t__builder.Start<RoleDevSkillViewItem.<InitializeButtons>d__19>(ref <InitializeButtons>d__);
		return <InitializeButtons>d__.<>t__builder.Task;
	}

	// Token: 0x06014598 RID: 83352 RVA: 0x005A8E7C File Offset: 0x005A707C
	private void RefreshSkillSlots(RoleDevSkillViewItemDataBase data)
	{
		List<global::ISkillSlotExtendData> skillSlots = data.SkillSlots;
		for (int i = 0; i < this.SkillSlotItems.Count; i++)
		{
			RoleDevSkillSlotItem roleDevSkillSlotItem = this.SkillSlotItems[i];
			global::ISkillSlotExtendData data2 = (i < skillSlots.Count) ? skillSlots[i] : null;
			roleDevSkillSlotItem.SetIsPerfectPlan(data.IsPerfectPlan || data.ShouldForcePerfectPlan);
			roleDevSkillSlotItem.Refresh(data2);
		}
	}

	// Token: 0x06014599 RID: 83353 RVA: 0x005A8EE3 File Offset: 0x005A70E3
	private RoleDevDetailItem CreateDetailItem()
	{
		return new RoleDevDetailItem();
	}

	// Token: 0x0601459A RID: 83354 RVA: 0x005A8EEC File Offset: 0x005A70EC
	private void OnClickSwitchState()
	{
		if (this.Data != null)
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.StopSequenceByKey("Switch", false, true);
			}
			UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
			if (uiViewSequence2 != null)
			{
				uiViewSequence2.PlaySequence("Switch", false, null);
			}
			this.Data.SwitchPlan();
			Action<RoleDevSkillViewItemDataBase> onPlanChangeCallback = this.OnPlanChangeCallback;
			if (onPlanChangeCallback != null)
			{
				onPlanChangeCallback(this.Data);
			}
			ControllerBase<RoleDevController>.Instance.LogRoleDevSubPageClick(this.Data.RoleId, ERoleDevMainPage.Skill, ERoleDevSubPageButton.SkillSwitchToPlan);
			this.Refresh(this.Data);
		}
	}

	// Token: 0x0601459B RID: 83355 RVA: 0x005A8F80 File Offset: 0x005A7180
	private void OnClickBtnJump(int _)
	{
		RoleDevSkillViewItemDataBase data = this.Data;
		if (data != null && data.IsRoleOwned)
		{
			RoleDevSkillMergeViewParams roleDevSkillMergeViewParams = new RoleDevSkillMergeViewParams();
			RoleDevSkillViewItemDataBase data2 = this.Data;
			roleDevSkillMergeViewParams.RoleId = ((data2 != null) ? data2.RoleId : 0);
			roleDevSkillMergeViewParams.SkillNodeIndex = ConfigBase<RoleDevConfig>.Instance.GetDefaultSkillNodeIndex();
			RoleDevSkillMergeViewParams param = roleDevSkillMergeViewParams;
			bool currentPlanFinished = this.Data.CurrentPlanFinished;
			ControllerBase<RoleDevController>.Instance.LogRoleDevSubPageClick(this.Data.RoleId, ERoleDevMainPage.Skill, currentPlanFinished ? ERoleDevSubPageButton.SkillGoToView : ERoleDevSubPageButton.SkillGoToCultivation);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleSkillMergeView, param, null);
		}
	}

	// Token: 0x0601459C RID: 83356 RVA: 0x005A900C File Offset: 0x005A720C
	private void OnSkillSlotClick(int index)
	{
		RoleDevSkillViewItemDataBase data = this.Data;
		List<global::ISkillSlotExtendData> list = ((data != null) ? data.SkillSlots : null) ?? new List<global::ISkillSlotExtendData>();
		global::ISkillSlotExtendData skillSlotExtendData = (index < list.Count) ? list[index] : null;
		if (skillSlotExtendData != null)
		{
			SkillTree? skillTreeNode = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(skillSlotExtendData.SkillNodeId);
			RoleDevSkillMergeViewParams roleDevSkillMergeViewParams = new RoleDevSkillMergeViewParams();
			RoleDevSkillViewItemDataBase data2 = this.Data;
			roleDevSkillMergeViewParams.RoleId = ((data2 != null) ? data2.RoleId : 0);
			roleDevSkillMergeViewParams.SkillNodeIndex = ((skillTreeNode != null) ? skillTreeNode.GetValueOrDefault().NodeIndex : ConfigBase<RoleDevConfig>.Instance.GetDefaultSkillNodeIndex());
			RoleDevSkillMergeViewParams param = roleDevSkillMergeViewParams;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleSkillMergeView, param, null);
		}
	}

	// Token: 0x04009DCB RID: 40395
	private readonly List<RoleDevSkillSlotItem> SkillSlotItems = new List<RoleDevSkillSlotItem>();

	// Token: 0x04009DCC RID: 40396
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleDevDetailItem, global::IRoleDevDetailItemData> DetailVerticalLayout;

	// Token: 0x04009DCD RID: 40397
	[Nullable(2)]
	private RoleDevSkillViewItemDataBase Data;

	// Token: 0x04009DCE RID: 40398
	[Nullable(2)]
	private ButtonItem NormalButtonItem;

	// Token: 0x04009DCF RID: 40399
	[Nullable(2)]
	private ButtonItem HighLightButtonItem;

	// Token: 0x04009DD0 RID: 40400
	[Nullable(2)]
	public Action<int> OnClickToggleCallBack;

	// Token: 0x04009DD1 RID: 40401
	[Nullable(2)]
	public Func<int, bool> CanClickCallBack;

	// Token: 0x04009DD2 RID: 40402
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<RoleDevSkillViewItemDataBase> OnConfirmCallback;

	// Token: 0x04009DD3 RID: 40403
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<RoleDevSkillViewItemDataBase> OnPlanChangeCallback;

	// Token: 0x04009DD4 RID: 40404
	[Nullable(2)]
	public UiBehaviorLevelSequence UiViewSequence;

	// Token: 0x02008BB3 RID: 35763
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F129 RID: 192809
		TxtSwitchState,
		// Token: 0x0402F12A RID: 192810
		BtnSwitchState,
		// Token: 0x0402F12B RID: 192811
		PanelSkillSlot0,
		// Token: 0x0402F12C RID: 192812
		PanelSkillSlot1,
		// Token: 0x0402F12D RID: 192813
		PanelSkillSlot2,
		// Token: 0x0402F12E RID: 192814
		PanelSkillSlot3,
		// Token: 0x0402F12F RID: 192815
		PanelSkillSlot4,
		// Token: 0x0402F130 RID: 192816
		PanelItemRight,
		// Token: 0x0402F131 RID: 192817
		BtnItemJump,
		// Token: 0x0402F132 RID: 192818
		PanelTxtOffset,
		// Token: 0x0402F133 RID: 192819
		BtnItemPerfectJump,
		// Token: 0x0402F134 RID: 192820
		PanelItemRightLine,
		// Token: 0x0402F135 RID: 192821
		PanelItemDetailLayout,
		// Token: 0x0402F136 RID: 192822
		PanelItemList,
		// Token: 0x0402F137 RID: 192823
		PanelSwitch,
		// Token: 0x0402F138 RID: 192824
		TxtTitle,
		// Token: 0x0402F139 RID: 192825
		PanelItemDescription
	}
}
