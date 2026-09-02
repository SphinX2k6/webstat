using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Compose;
using CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.RoleUi.RoleBreach;
using CSharpScript.Game.Module.RoleUi.RoleSkill;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028CB RID: 10443
[NullableContext(2)]
[Nullable(0)]
public class RoleSkillTreeInfoItem : UiPanelBase
{
	// Token: 0x06014B78 RID: 84856 RVA: 0x005BC6E8 File Offset: 0x005BA8E8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 48;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(36, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(37, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(38, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(39, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(40, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(41, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(42, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(43, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(44, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(45, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(46, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(47, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 9;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnIntroductionToggleClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnAttrDetailToggleClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(19, new Action<EToggleState>(this.OnRightPanelToggleClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(24, new Action(this.OnBtnCloseClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(25, new Action(this.OnNextLevelMaskBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(26, new Action(this.OnLockTipBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(29, new Action(this.OnRoleSkillMaskBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(30, new Action<EToggleState>(this.SkillModeToggleClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(37, new Action(this.ClickBranchDetailBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06014B79 RID: 84857 RVA: 0x005BCEC4 File Offset: 0x005BB0C4
	protected override UniTask OnBeforeStartAsync()
	{
		RoleSkillTreeInfoItem.<OnBeforeStartAsync>d__40 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleSkillTreeInfoItem.<OnBeforeStartAsync>d__40>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014B7A RID: 84858 RVA: 0x005BCF08 File Offset: 0x005BB108
	protected override void OnStart()
	{
		this.ConsumeItemScroll = new GenericScrollViewNew<CostMediumItemGrid, ISelectedData>(base.GetScrollViewWithScrollbar(11), new Func<CostMediumItemGrid>(this.InitCostItem), null, false, null);
		this.CurrentLevelAttrScrollView = new GenericScrollView<RoleSkillTreeAttributeItem>(base.GetScrollViewWithScrollbar(8), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<RoleSkillTreeAttributeItem>(this.InitAttrItem), null);
		this.CaptionItem = new PopupCaptionItem(base.GetItem(21));
		this.CaptionItem.SetCurrencyItemList(new int[]
		{
			2
		});
		this.CaptionItem.SetCurrencyItemVisible(true);
		this.ConfirmButtonItem = new ButtonItem(base.GetItem(14));
		this.ConfirmButtonItem.SetFunction(new Action<int>(this.OnLevelUpClick));
		base.GetItem(20).SetUIActive(false);
		base.SetItemIcon(base.GetTexture(12), 2, null, null);
		this.RefreshSkillModeToggle();
		RoleSkillTreeInfoViewData roleSkillTreeInfoViewData = this.OpenParam as RoleSkillTreeInfoViewData;
		if (roleSkillTreeInfoViewData != null)
		{
			this.RoleSkillTreeInfoItemData = new RoleSkillTreeInfoItemData
			{
				RoleId = roleSkillTreeInfoViewData.RoleId,
				SkillNodeId = roleSkillTreeInfoViewData.SkillNodeId
			};
		}
		this.CurSkillTabShowType = ESkillTabShowType.Introduction;
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlink(base.GetText(10), ETermExplanationViewType.Side, ETermExplanationReportType.RoleSkill, ETermExplanationViewAttachDirection.Right, null, null, null, ETermExplanationGroup.Default, 0, ETermExplanationViewStyle.Default);
		UUIItem item = base.GetItem(42);
		if (item == null)
		{
			return;
		}
		this.NumberSelectComponent = new NumberSelectComponent(item);
		this.NumberSelectComponent.EnableUseCustomMinValue(true);
		this.NumberSelectComponent.SetMaxBtnShowState(false);
		UUIItem item2 = base.GetItem(40);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x06014B7B RID: 84859 RVA: 0x005BD083 File Offset: 0x005BB283
	protected override void OnBeforeDestroy()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(10));
	}

	// Token: 0x06014B7C RID: 84860 RVA: 0x005BD098 File Offset: 0x005BB298
	private void RefreshSkillModeToggle()
	{
		this.SkillDescType = ModelBase<RoleModel>.Instance.GetRoleSkillDescType();
		if (this.SkillDescType == ERoleSkillDescType.MultiDesc)
		{
			EToggleState state = ModelBase<RoleModel>.Instance.IsShowMultiSkillDesc ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(30).SetToggleState(state, false, false, false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(33), "MultiplayerSkillDescription_text", Array.Empty<object>());
			return;
		}
		EToggleState state2 = ModelBase<RoleModel>.Instance.IsShowSkillResume ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(30).SetToggleState(state2, false, false, false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(33), "SkillBriefDescription_text", Array.Empty<object>());
	}

	// Token: 0x06014B7D RID: 84861 RVA: 0x005BD13D File Offset: 0x005BB33D
	public void OnCommonItemCountAnyChange()
	{
		if (this.IsLevelUpPending)
		{
			return;
		}
		this.Refresh();
	}

	// Token: 0x06014B7E RID: 84862 RVA: 0x005BD14E File Offset: 0x005BB34E
	public void OnSkillTreeNodeLevelUp()
	{
		this.IsLevelUpPending = false;
		this.Refresh();
	}

	// Token: 0x06014B7F RID: 84863 RVA: 0x005BD15D File Offset: 0x005BB35D
	private void OnBtnCloseClick()
	{
		Action onBackBtnCallBack = this.OnBackBtnCallBack;
		if (onBackBtnCallBack == null)
		{
			return;
		}
		onBackBtnCallBack();
	}

	// Token: 0x06014B80 RID: 84864 RVA: 0x005BD170 File Offset: 0x005BB370
	private void OnRightPanelToggleClick(EToggleState toggleState)
	{
		this.IsShowRightPanel = (toggleState == EToggleState.ETT_Checked);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRoleSkillInputPanelVisible, this.IsShowRightPanel);
		if (toggleState == EToggleState.ETT_Checked)
		{
			this.CurSkillTabShowType = ESkillTabShowType.Detail;
			this.ShowLeftPanelByTabType(this.CurSkillTabShowType);
		}
		else
		{
			this.ShowRightPanel(this.CurSkillTabShowType, false);
		}
		this.PlayRightPanelSequence(toggleState == EToggleState.ETT_Checked);
	}

	// Token: 0x06014B81 RID: 84865 RVA: 0x005BD1CD File Offset: 0x005BB3CD
	private void SkillModeToggleClick(EToggleState toggleState)
	{
		if (this.SkillDescType == ERoleSkillDescType.MultiDesc)
		{
			ModelBase<RoleModel>.Instance.IsShowMultiSkillDesc = (toggleState == EToggleState.ETT_Checked);
		}
		else
		{
			ModelBase<RoleModel>.Instance.IsShowSkillResume = (toggleState == EToggleState.ETT_Checked);
		}
		this.Update(this.RoleSkillTreeInfoItemData);
	}

	// Token: 0x06014B82 RID: 84866 RVA: 0x005BD202 File Offset: 0x005BB402
	private void OnNextLevelMaskBtnClick()
	{
		this.IsShowRightPanel = false;
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRoleSkillInputPanelVisible, this.IsShowRightPanel);
		base.GetExtendToggle(19).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.HideNextLevelItem();
		this.PlayRightPanelSequence(false);
	}

	// Token: 0x06014B83 RID: 84867 RVA: 0x005BD240 File Offset: 0x005BB440
	private void OnRoleSkillMaskBtnClick()
	{
		this.IsShowRightPanel = false;
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRoleSkillInputPanelVisible, this.IsShowRightPanel);
		base.GetExtendToggle(19).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.HideRoleSkillInputPanel();
		this.PlayRightPanelSequence(false);
	}

	// Token: 0x06014B84 RID: 84868 RVA: 0x005BD27E File Offset: 0x005BB47E
	private void OnIntroductionToggleClick(EToggleState toggleState)
	{
		this.CurSkillTabShowType = ESkillTabShowType.Introduction;
		this.ShowLeftPanelByTabType(this.CurSkillTabShowType);
	}

	// Token: 0x06014B85 RID: 84869 RVA: 0x005BD293 File Offset: 0x005BB493
	private void OnAttrDetailToggleClick(EToggleState toggleState)
	{
		this.CurSkillTabShowType = ESkillTabShowType.Detail;
		this.ShowLeftPanelByTabType(this.CurSkillTabShowType);
	}

	// Token: 0x06014B86 RID: 84870 RVA: 0x005BD2A8 File Offset: 0x005BB4A8
	private void OnLevelUpClick(int _)
	{
		int? num = (this.SkillTreeConfig != null) ? new int?(this.SkillTreeConfig.GetValueOrDefault().NodeType) : null;
		if ((num.GetValueOrDefault() == 2 || num.GetValueOrDefault() == 1) && this.TargetLevel > this.CurrentSkillLevel + 1)
		{
			this.OnQuickLevelUpClick();
			return;
		}
		this.OnNormalLevelUpClick();
	}

	// Token: 0x06014B87 RID: 84871 RVA: 0x005BD320 File Offset: 0x005BB520
	private void OnNormalLevelUpClick()
	{
		int skillNodeLevel = this.SkillData.GetSkillNodeLevel(this.SkillTreeConfig.Value);
		IEnumerable<DicIntInt?> roleSkillTreeConsume = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillTreeConsume(this.RoleSkillTreeInfoItemData.SkillNodeId, skillNodeLevel + 1);
		if (roleSkillTreeConsume != null)
		{
			foreach (DicIntInt? dicIntInt in roleSkillTreeConsume)
			{
				int key = dicIntInt.Value.Key;
				int value = dicIntInt.Value.Value;
				if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key, 0) < value)
				{
					List<ISelectedData> selectedDataList = this.GetSelectedDataList();
					ComposePopupViewData param = new ComposePopupViewData
					{
						SelectedItemList = selectedDataList,
						BeforeCompose = delegate
						{
							this.IsLevelUpPending = true;
						},
						ClickConfirm = new Action(this.LevelUpRequest),
						BelongView = new EUiViewName?(EUiViewName.RoleSkillTreeInfoView)
					};
					Singleton<UiManager>.Instance.OpenView(EUiViewName.SynthesisTipsInfoView, param, delegate(bool isSuccess, int viewId)
					{
						if (isSuccess)
						{
							if (this.ParentView == null)
							{
								return;
							}
							this.ParentView.AddChildViewById(viewId);
						}
					});
					return;
				}
			}
		}
		this.LevelUpRequest();
	}

	// Token: 0x06014B88 RID: 84872 RVA: 0x005BD444 File Offset: 0x005BB644
	private void OnQuickLevelUpClick()
	{
		int targetLevel = this.TargetLevel;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = this.CurrentSkillLevel + 1; i <= targetLevel; i++)
		{
			IEnumerable<DicIntInt?> roleSkillTreeConsume = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillTreeConsume(this.RoleSkillTreeInfoItemData.SkillNodeId, i);
			if (roleSkillTreeConsume != null)
			{
				foreach (DicIntInt? dicIntInt in roleSkillTreeConsume)
				{
					int key = dicIntInt.Value.Key;
					int value = dicIntInt.Value.Value;
					int num;
					if (!dictionary.TryGetValue(key, out num))
					{
						num = 0;
					}
					dictionary[key] = num + value;
				}
			}
		}
		Action <>9__1;
		Action <>9__2;
		TOpenViewCallBack <>9__0;
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int key2 = keyValuePair.Key;
			int value2 = keyValuePair.Value;
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key2, 0) < value2)
			{
				List<ISelectedData> selectedDataList = this.GetSelectedDataList();
				ComposePopupViewData composePopupViewData = new ComposePopupViewData();
				composePopupViewData.SelectedItemList = selectedDataList;
				Action beforeCompose;
				if ((beforeCompose = <>9__1) == null)
				{
					beforeCompose = (<>9__1 = delegate()
					{
						this.IsLevelUpPending = true;
					});
				}
				composePopupViewData.BeforeCompose = beforeCompose;
				Action clickConfirm;
				if ((clickConfirm = <>9__2) == null)
				{
					clickConfirm = (<>9__2 = delegate()
					{
						this.QuickLevelUpRequest(targetLevel);
					});
				}
				composePopupViewData.ClickConfirm = clickConfirm;
				composePopupViewData.BelongView = new EUiViewName?(EUiViewName.RoleSkillTreeInfoView);
				ComposePopupViewData composePopupViewData2 = composePopupViewData;
				UiManager instance = Singleton<UiManager>.Instance;
				EUiViewName synthesisTipsInfoView = EUiViewName.SynthesisTipsInfoView;
				object param = composePopupViewData2;
				TOpenViewCallBack finishCallback;
				if ((finishCallback = <>9__0) == null)
				{
					finishCallback = (<>9__0 = delegate(bool isSuccess, int viewId)
					{
						if (isSuccess)
						{
							if (this.ParentView == null)
							{
								return;
							}
							this.ParentView.AddChildViewById(viewId);
						}
					});
				}
				instance.OpenView(synthesisTipsInfoView, param, finishCallback);
				return;
			}
		}
		this.QuickLevelUpRequest(targetLevel);
	}

	// Token: 0x06014B89 RID: 84873 RVA: 0x005BD63C File Offset: 0x005BB83C
	private void LevelUpRequest()
	{
		this.IsLevelUpPending = true;
		int nodeType = this.SkillTreeConfig.Value.NodeType;
		if (nodeType == 1 || nodeType == 2)
		{
			ControllerBase<RoleController>.Instance.SendPbUpLevelSkillRequest(this.RoleSkillTreeInfoItemData.RoleId, this.RoleSkillTreeInfoItemData.SkillNodeId);
			return;
		}
		ControllerBase<RoleController>.Instance.SendRoleActivateSkillRequest(this.RoleSkillTreeInfoItemData.RoleId, this.RoleSkillTreeInfoItemData.SkillNodeId);
	}

	// Token: 0x06014B8A RID: 84874 RVA: 0x005BD6AD File Offset: 0x005BB8AD
	private void QuickLevelUpRequest(int targetLevel)
	{
		this.IsLevelUpPending = true;
		RoleController.SendRoleSkillQuickLevelUpRequest(this.RoleSkillTreeInfoItemData.RoleId, this.RoleSkillTreeInfoItemData.SkillNodeId, targetLevel);
	}

	// Token: 0x06014B8B RID: 84875 RVA: 0x005BD6D2 File Offset: 0x005BB8D2
	[NullableContext(1)]
	private List<ISelectedData> GetSelectedDataList()
	{
		return this.SortConsumeList(this.CachedConsumeList ?? new List<ISelectedData>());
	}

	// Token: 0x06014B8C RID: 84876 RVA: 0x005BD6EC File Offset: 0x005BB8EC
	private void OnLockTipBtnClick()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleSkillLevelUpTip);
		int roleId = this.RoleSkillTreeInfoItemData.RoleId;
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			UiViewBase parentView = this.ParentView;
			EUiViewName? euiViewName = (parentView != null) ? new EUiViewName?(parentView.ViewInfo.Name) : null;
			if (euiViewName != null)
			{
				Singleton<UiManager>.Instance.CloseView(euiViewName.Value, null);
			}
			if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.RoleRootView) != null)
			{
				Singleton<UiManager>.Instance.NormalResetToView(EUiViewName.RoleRootView, null, true);
				Singleton<EventSystem>.Instance.Emit<EUiTabViewName, int>(EEventName.SelectRoleTabOutside, EUiTabViewName.RoleAttributeTabView, roleId);
				return;
			}
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, roleId, new List<int>(), new EUiTabViewName?(EUiTabViewName.RoleAttributeTabView), null);
		});
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06014B8D RID: 84877 RVA: 0x005BD750 File Offset: 0x005BB950
	[NullableContext(1)]
	private CostMediumItemGrid InitCostItem()
	{
		CostMediumItemGrid costMediumItemGrid = new CostMediumItemGrid();
		costMediumItemGrid.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback callbackParameter)
		{
			ISelectedData selectedData = callbackParameter.Data as ISelectedData;
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(selectedData.ItemId, true, null);
			ModelBase<ComposeModel>.Instance.ComposeSelectItem = selectedData;
			ModelBase<ComposeModel>.Instance.ComposeSkipSourceView = new EUiViewName?(EUiViewName.RoleSkillTreeInfoView);
			ModelBase<InventoryModel>.Instance.SetItemNeedCount(new int?(selectedData.Count - selectedData.SelectedCount));
		});
		costMediumItemGrid.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
		return costMediumItemGrid;
	}

	// Token: 0x06014B8E RID: 84878 RVA: 0x005BD7AC File Offset: 0x005BB9AC
	[NullableContext(1)]
	private ILayoutItem<RoleSkillTreeAttributeItem> InitAttrItem(object data, UUIItem uiItem, int index)
	{
		RoleSkillTreeAttributeItem roleSkillTreeAttributeItem = new RoleSkillTreeAttributeItem(uiItem);
		CommonAttributeData curData = this.CurAttributeDataList[index];
		CommonAttributeData nextData = (index < this.NextAttributeDataList.Count) ? this.NextAttributeDataList[index] : null;
		roleSkillTreeAttributeItem.Refresh(curData, nextData);
		roleSkillTreeAttributeItem.SetNextLevelItem(this.IsShowRightPanel);
		return new LayoutItem<RoleSkillTreeAttributeItem>
		{
			Key = index,
			Value = roleSkillTreeAttributeItem
		};
	}

	// Token: 0x06014B8F RID: 84879 RVA: 0x005BD818 File Offset: 0x005BBA18
	[NullableContext(1)]
	public void Update(IRoleSkillTreeInfoItemData data)
	{
		this.IsLevelUpPending = false;
		this.RoleSkillTreeInfoItemData = data;
		this.SkillTreeConfig = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(this.RoleSkillTreeInfoItemData.SkillNodeId);
		this.SkillId = this.SkillTreeConfig.Value.SkillId;
		this.UpgradeSkillId = ModelBase<RoleModel>.Instance.GetUpgradeSkillIdIfUpgraded(this.SkillId, this.RoleSkillTreeInfoItemData.RoleId);
		this.ShowSkillId = ((this.UpgradeSkillId > 0) ? this.UpgradeSkillId : this.SkillId);
		this.SkillConfig = ((this.SkillId > 0) ? ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(this.SkillId) : null);
		this.ShowSkillConfig = ((this.ShowSkillId > 0) ? ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(this.ShowSkillId) : null);
		RoleDataBase roleDataBase = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleSkillTreeInfoItemData.RoleId);
		if (roleDataBase == null)
		{
			roleDataBase = ModelBase<RoleModel>.Instance.GetRoleDataById(this.RoleSkillTreeInfoItemData.RoleId, true);
		}
		this.SkillData = roleDataBase.GetSkillData();
		RoleSkillInputPanel roleSkillInputPanel = this.RoleSkillInputPanel;
		if (roleSkillInputPanel != null)
		{
			roleSkillInputPanel.Refresh(roleDataBase.GetRoleId(), roleDataBase.IsTrialRole(), true);
		}
		this.Refresh();
		if (roleDataBase.IsTrialRole())
		{
			this.RefreshTrial();
		}
		this.RefreshSkillBranch();
	}

	// Token: 0x06014B90 RID: 84880 RVA: 0x005BD970 File Offset: 0x005BBB70
	public void Refresh()
	{
		switch (ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(this.RoleSkillTreeInfoItemData.SkillNodeId).Value.NodeType)
		{
		case 1:
			this.RefreshByInnerPassiveSkill();
			break;
		case 2:
			this.RefreshByInnerSkill();
			break;
		case 3:
			this.RefreshByOuterPassiveSkill();
			break;
		case 4:
			this.RefreshByOuterAttribute();
			break;
		}
		this.RefreshRoleBackgroundMusicSwitchItem();
	}

	// Token: 0x06014B91 RID: 84881 RVA: 0x005BD9E4 File Offset: 0x005BBBE4
	private void RefreshTrial()
	{
		base.GetItem(22).SetUIActive(false);
		base.GetItem(17).SetUIActive(false);
		base.GetItem(15).SetUIActive(false);
		this.ConfirmButtonItem.SetActive(false);
		base.GetExtendToggle(19).RootUIComp.Get().SetUIActive(false);
		this.CaptionItem.SetCurrencyItemVisible(false);
	}

	// Token: 0x06014B92 RID: 84882 RVA: 0x005BDA50 File Offset: 0x005BBC50
	private void RefreshByOuterAttribute()
	{
		this.UseTexture = true;
		this.CurSkillTabShowType = ESkillTabShowType.Introduction;
		base.GetText(3).SetUIActive(false);
		base.GetItem(6).SetUIActive(false);
		base.GetExtendToggle(19).RootUIComp.Get().SetUIActive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "SkillType_AttributeNode_TypeName", Array.Empty<object>());
		SkillTree value = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(this.RoleSkillTreeInfoItemData.SkillNodeId).Value;
		object[] array = new object[value.PropertyNodeParamLength];
		for (int i = 0; i < value.PropertyNodeParamLength; i++)
		{
			array[i] = value.PropertyNodeParam(i);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), value.PropertyNodeTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), value.PropertyNodeDescribe, array);
		base.GetText(10).bBestFit = false;
		this.RefreshNoLevelNodeState();
		this.RefreshSkillIcon();
	}

	// Token: 0x06014B93 RID: 84883 RVA: 0x005BDB5C File Offset: 0x005BBD5C
	private void RefreshByOuterPassiveSkill()
	{
		this.UseTexture = false;
		this.CurSkillTabShowType = ESkillTabShowType.Introduction;
		base.GetText(3).SetUIActive(false);
		base.GetItem(6).SetUIActive(false);
		base.GetExtendToggle(19).RootUIComp.Get().SetUIActive(false);
		this.RefreshSkillInfo();
		this.RefreshNoLevelNodeState();
		this.RefreshSkillIcon();
	}

	// Token: 0x06014B94 RID: 84884 RVA: 0x005BDBBE File Offset: 0x005BBDBE
	private void RefreshByInnerPassiveSkill()
	{
		this.UseTexture = false;
		this.RefreshByCanLevelUpSkill();
		this.RefreshSkillIcon();
	}

	// Token: 0x06014B95 RID: 84885 RVA: 0x005BDBD3 File Offset: 0x005BBDD3
	private void RefreshByInnerSkill()
	{
		this.UseTexture = false;
		this.RefreshByCanLevelUpSkill();
		this.RefreshSkillIcon();
	}

	// Token: 0x06014B96 RID: 84886 RVA: 0x005BDBE8 File Offset: 0x005BBDE8
	private void RefreshByCanLevelUpSkill()
	{
		base.GetText(3).SetUIActive(true);
		base.GetItem(6).SetUIActive(true);
		int roleSkillTreeNodeLevel = ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeLevel(this.RoleSkillTreeInfoItemData.RoleId, this.RoleSkillTreeInfoItemData.SkillNodeId);
		int maxSkillLevel = this.SkillConfig.Value.MaxSkillLevel;
		this.CurrentSkillLevel = roleSkillTreeNodeLevel;
		this.MaxSkillLevel = maxSkillLevel;
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "RoleResonanceLevel", new <>z__ReadOnlySingleElementList<object>(roleSkillTreeNodeLevel));
		this.RefreshSkillInfo();
		this.RefreshHasLevelNodeState();
		this.RefreshNextLevelText();
	}

	// Token: 0x06014B97 RID: 84887 RVA: 0x005BDC88 File Offset: 0x005BBE88
	private void RefreshSkillInfo()
	{
		if (this.ShowSkillConfig != null)
		{
			Aki.Config.Skill value = this.ShowSkillConfig.Value;
			string skillTypeNameLocalText = ConfigBase<RoleSkillConfig>.Instance.GetSkillTypeNameLocalText(value.SkillType);
			if (!string.IsNullOrEmpty(skillTypeNameLocalText))
			{
				base.GetText(2).SetText(skillTypeNameLocalText, true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), value.SkillName, Array.Empty<object>());
			UUIText text = base.GetText(10);
			if (this.SkillDescType == ERoleSkillDescType.MultiDesc)
			{
				if (ModelBase<RoleModel>.Instance.IsShowMultiSkillDesc)
				{
					object[] array = new object[value.MultiSkillDetailNumLength];
					for (int i = 0; i < value.MultiSkillDetailNumLength; i++)
					{
						array[i] = value.MultiSkillDetailNum(i);
					}
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, value.MultiSkillDescribe, array);
				}
				else
				{
					object[] array2 = new object[value.SkillDetailNumLength];
					for (int j = 0; j < value.SkillDetailNumLength; j++)
					{
						array2[j] = value.SkillDetailNum(j);
					}
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, value.SkillDescribe, array2);
				}
			}
			else if (ModelBase<RoleModel>.Instance.IsShowSkillResume)
			{
				object[] array3 = new object[value.SkillResumeNumLength];
				for (int k = 0; k < value.SkillResumeNumLength; k++)
				{
					array3[k] = value.SkillResumeNum(k);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, value.SkillResume, array3);
			}
			else
			{
				object[] array4 = new object[value.SkillDetailNumLength];
				for (int l = 0; l < value.SkillDetailNumLength; l++)
				{
					array4[l] = value.SkillDetailNum(l);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, value.SkillDescribe, array4);
			}
			text.bBestFit = false;
		}
	}

	// Token: 0x06014B98 RID: 84888 RVA: 0x005BDE4C File Offset: 0x005BC04C
	private void RefreshSkillIcon()
	{
		string path;
		if (this.ShowSkillConfig != null)
		{
			path = this.ShowSkillConfig.Value.Icon;
		}
		else
		{
			path = this.SkillTreeConfig.Value.PropertyNodeIcon;
		}
		UUITexture texture = base.GetTexture(1);
		UUISprite sprite = base.GetSprite(0);
		if (this.UseTexture)
		{
			texture.SetUIActive(true);
			sprite.SetUIActive(false);
			base.SetTextureByPath(path, texture, null, null);
			return;
		}
		texture.SetUIActive(false);
		sprite.SetUIActive(true);
		this.SetSpriteByPath(path, sprite, false, null, null);
	}

	// Token: 0x06014B99 RID: 84889 RVA: 0x005BDEF0 File Offset: 0x005BC0F0
	private void RefreshConsume(int nextLevel = 1)
	{
		IEnumerable<DicIntInt?> roleSkillTreeConsume = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillTreeConsume(this.RoleSkillTreeInfoItemData.SkillNodeId, nextLevel);
		if (roleSkillTreeConsume == null || roleSkillTreeConsume.Count<DicIntInt?>() == 0)
		{
			base.GetItem(22).SetUIActive(false);
			base.GetItem(23).SetUIActive(false);
			return;
		}
		base.GetItem(22).SetUIActive(true);
		base.GetItem(23).SetUIActive(true);
		List<ISelectedData> list = new List<ISelectedData>();
		int num = 0;
		foreach (DicIntInt? dicIntInt in roleSkillTreeConsume)
		{
			int key = dicIntInt.Value.Key;
			int value = dicIntInt.Value.Value;
			if (key == 2)
			{
				num = value;
			}
			else
			{
				SelectedData item2 = new SelectedData
				{
					ItemId = key,
					IncId = 0,
					Count = value,
					SelectedCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(key, 0)
				};
				list.Add(item2);
			}
		}
		this.CachedConsumeList = (from item in list
		select new SelectedData
		{
			ItemId = item.ItemId,
			IncId = item.IncId,
			Count = item.Count,
			SelectedCount = item.SelectedCount
		}).ToList<ISelectedData>();
		this.ItemListLength = list.Count;
		if (num > 0)
		{
			this.CachedConsumeList.Add(new SelectedData
			{
				ItemId = 2,
				IncId = 0,
				Count = num,
				SelectedCount = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(2, 0)
			});
		}
		UUIText text = base.GetText(13);
		text.SetText(num.ToString(), true);
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(2, 0);
		UUIItem uuiitem = text;
		bool bUseChangeColor = itemCountByConfigId < num;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		this.ConsumeItemScroll.RefreshByData(this.SortConsumeList(list), null, false);
	}

	// Token: 0x06014B9A RID: 84890 RVA: 0x005BE0CC File Offset: 0x005BC2CC
	[NullableContext(1)]
	private List<ISelectedData> SortConsumeList(List<ISelectedData> consumeList)
	{
		return (from a in consumeList
		orderby (a.SelectedCount >= a.Count) ? 1 : 0
		select a).ThenByDescending(delegate(ISelectedData a)
		{
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(a.ItemId);
			if (itemConfigData == null)
			{
				return 0;
			}
			return itemConfigData.QualityId;
		}).ToList<ISelectedData>();
	}

	// Token: 0x06014B9B RID: 84891 RVA: 0x005BE128 File Offset: 0x005BC328
	[NullableContext(1)]
	private void RefreshCostItemButton(string passButtonTextId)
	{
		int skillNodeLevel = this.SkillData.GetSkillNodeLevel(this.SkillTreeConfig.Value);
		IEnumerable<DicIntInt?> roleSkillTreeConsume = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillTreeConsume(this.RoleSkillTreeInfoItemData.SkillNodeId, skillNodeLevel + 1);
		if (roleSkillTreeConsume != null)
		{
			foreach (DicIntInt? dicIntInt in roleSkillTreeConsume)
			{
				int key = dicIntInt.Value.Key;
				int value = dicIntInt.Value.Value;
				if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key, 0) < value)
				{
					bool flag = ModelBase<ComposePopupModel>.Instance.CheckOpenResult(this.GetSelectedDataList());
					if (flag)
					{
						ButtonItem confirmButtonItem = this.ConfirmButtonItem;
						if (confirmButtonItem != null)
						{
							confirmButtonItem.SetShowText("AutoSynthesis_MaterialReplenishBtn_Text");
						}
					}
					else
					{
						ButtonItem confirmButtonItem2 = this.ConfirmButtonItem;
						if (confirmButtonItem2 != null)
						{
							confirmButtonItem2.SetShowText("AutoSynthesis_MaterialMissingBtn_Text");
						}
					}
					ButtonItem confirmButtonItem3 = this.ConfirmButtonItem;
					if (confirmButtonItem3 == null)
					{
						return;
					}
					confirmButtonItem3.SetEnableClick(flag);
					return;
				}
			}
		}
		ButtonItem confirmButtonItem4 = this.ConfirmButtonItem;
		if (confirmButtonItem4 != null)
		{
			confirmButtonItem4.SetLocalText(passButtonTextId, Array.Empty<object>());
		}
		ButtonItem confirmButtonItem5 = this.ConfirmButtonItem;
		if (confirmButtonItem5 == null)
		{
			return;
		}
		confirmButtonItem5.SetEnableClick(true);
	}

	// Token: 0x06014B9C RID: 84892 RVA: 0x005BE25C File Offset: 0x005BC45C
	private void RefreshNoLevelNodeState()
	{
		ESkillTreeNodeState skillTreeNodeState = this.SkillData.GetSkillTreeNodeState(this.SkillTreeConfig.Value, this.RoleSkillTreeInfoItemData.RoleId);
		this.ConfirmButtonItem.SetActive(skillTreeNodeState == ESkillTreeNodeState.Inactive);
		base.GetItem(22).SetUIActive(skillTreeNodeState == ESkillTreeNodeState.Inactive);
		base.GetItem(23).SetUIActive(skillTreeNodeState == ESkillTreeNodeState.Inactive);
		base.GetItem(17).SetUIActive(skillTreeNodeState == ESkillTreeNodeState.Lock);
		base.GetItem(15).SetUIActive(skillTreeNodeState == ESkillTreeNodeState.Active);
		if (skillTreeNodeState == ESkillTreeNodeState.Active)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(16), "Actived", Array.Empty<object>());
		}
		else
		{
			this.RefreshConsume(1);
			if (skillTreeNodeState == ESkillTreeNodeState.Inactive)
			{
				this.RefreshCostItemButton("RoleResonActive");
			}
			else if (skillTreeNodeState == ESkillTreeNodeState.Lock)
			{
				string unlockConditionTextId = this.SkillData.GetUnlockConditionTextId(this.SkillTreeConfig.Value);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(18), unlockConditionTextId, Array.Empty<object>());
			}
			SkillCondition? skillTreeUnsatisfiedCondition = this.SkillData.GetSkillTreeUnsatisfiedCondition(this.SkillTreeConfig.Value);
			base.GetButton(26).RootUIComp.Get().SetUIActive(skillTreeUnsatisfiedCondition == null || skillTreeUnsatisfiedCondition.GetValueOrDefault().ConditionType != 2);
		}
		UUIItem item = base.GetItem(40);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.TargetLevel = 0;
		this.CurrentSkillLevel = 0;
		this.MaxSkillLevel = 0;
		this.LastInitSnapshotSkillNodeId = 0;
		this.LastInitSnapshotCurrentLevel = -1;
		this.LastInitSnapshotItemCounts = null;
		this.SetBoxPanelVisibility(false);
	}

	// Token: 0x06014B9D RID: 84893 RVA: 0x005BE3E8 File Offset: 0x005BC5E8
	private void RefreshHasLevelNodeState()
	{
		ESkillTreeNodeState skillTreeNodeState = this.SkillData.GetSkillTreeNodeState(this.SkillTreeConfig.Value, this.RoleSkillTreeInfoItemData.RoleId);
		this.ConfirmButtonItem.SetActive(skillTreeNodeState == ESkillTreeNodeState.Inactive);
		base.GetItem(22).SetUIActive(skillTreeNodeState != ESkillTreeNodeState.Active);
		base.GetItem(23).SetUIActive(skillTreeNodeState != ESkillTreeNodeState.Active);
		base.GetItem(17).SetUIActive(skillTreeNodeState == ESkillTreeNodeState.Lock);
		base.GetItem(15).SetUIActive(skillTreeNodeState == ESkillTreeNodeState.Active);
		base.GetExtendToggle(19).RootUIComp.Get().SetUIActive(true);
		this.RefreshCurrentLevelAttribute();
		if (skillTreeNodeState == ESkillTreeNodeState.Active)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(16), "RoleAlreadyMax", Array.Empty<object>());
		}
		else
		{
			int skillNodeLevel = this.SkillData.GetSkillNodeLevel(this.SkillTreeConfig.Value);
			this.RefreshConsume(skillNodeLevel + 1);
			if (skillTreeNodeState == ESkillTreeNodeState.Inactive)
			{
				this.RefreshCostItemButton("RoleLevelUp");
			}
			else if (skillTreeNodeState == ESkillTreeNodeState.Lock)
			{
				string unlockConditionTextId = this.SkillData.GetUnlockConditionTextId(this.SkillTreeConfig.Value);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(18), unlockConditionTextId, Array.Empty<object>());
			}
			SkillCondition? skillTreeUnsatisfiedCondition = this.SkillData.GetSkillTreeUnsatisfiedCondition(this.SkillTreeConfig.Value);
			base.GetButton(26).RootUIComp.Get().SetUIActive(skillTreeUnsatisfiedCondition == null || skillTreeUnsatisfiedCondition.GetValueOrDefault().ConditionType != 2);
		}
		this.InitQuickLevelUpPanel(skillTreeNodeState);
		this.RefreshBoxPanelVisibility();
	}

	// Token: 0x06014B9E RID: 84894 RVA: 0x005BE580 File Offset: 0x005BC780
	[NullableContext(1)]
	private CommonAttributeData CreateAttributeData(OneSkillEffect effect)
	{
		CommonAttributeData commonAttributeData = new CommonAttributeData();
		string skillAttributeNameByOneSkillEffect = ModelBase<RoleModel>.Instance.GetSkillAttributeNameByOneSkillEffect(effect);
		commonAttributeData.AttrNameText = (ConfigMultiTextLang.GetLocalTextNew(skillAttributeNameByOneSkillEffect, null) ?? "");
		commonAttributeData.AttrBaseValue = ModelBase<RoleModel>.Instance.GetSkillAttributeDescriptionByOneSkillEffect(effect);
		return commonAttributeData;
	}

	// Token: 0x06014B9F RID: 84895 RVA: 0x005BE5C8 File Offset: 0x005BC7C8
	private void RefreshNextLevelText()
	{
		UUIText text = base.GetText(32);
		UUIItem item = base.GetItem(43);
		if (text == null)
		{
			return;
		}
		if (this.CurrentSkillLevel >= this.MaxSkillLevel)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PrefabTextItem_3463157315_Text", Array.Empty<object>());
			if (item != null)
			{
				item.SetUIActive(true);
			}
			return;
		}
		if (this.MaxTargetLevel <= this.CurrentSkillLevel)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PrefabTextItem_SkillNext_Text", Array.Empty<object>());
			if (item != null)
			{
				item.SetUIActive(false);
			}
			return;
		}
		int num = (this.TargetLevel > 0) ? this.TargetLevel : (this.CurrentSkillLevel + 1);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Text_LevelText_Text", new object[]
		{
			num
		});
		if (item != null)
		{
			item.SetUIActive(num >= this.MaxSkillLevel);
		}
	}

	// Token: 0x06014BA0 RID: 84896 RVA: 0x005BE698 File Offset: 0x005BC898
	private void InitQuickLevelUpPanel(ESkillTreeNodeState state)
	{
		UUIItem item = base.GetItem(40);
		if (item == null)
		{
			return;
		}
		if (state == ESkillTreeNodeState.Lock || state == ESkillTreeNodeState.Active)
		{
			item.SetUIActive(false);
			this.LastInitSnapshotSkillNodeId = 0;
			this.LastInitSnapshotCurrentLevel = -1;
			this.LastInitSnapshotItemCounts = null;
			return;
		}
		this.CalcMaxTargetLevel();
		bool flag = this.MaxTargetLevel > this.CurrentSkillLevel;
		item.SetUIActive(true);
		int num = flag ? (this.CurrentSkillLevel + 1) : this.CurrentSkillLevel;
		int num2 = flag ? this.MaxTargetLevel : (this.CurrentSkillLevel + 1);
		Dictionary<int, int> dictionary = this.CalcQuickLevelUpItemCountSnapshot();
		bool flag2 = flag && this.LastInitSnapshotSkillNodeId == this.RoleSkillTreeInfoItemData.SkillNodeId && this.LastInitSnapshotCurrentLevel == this.CurrentSkillLevel && this.IsItemCountSnapshotEqual(this.LastInitSnapshotItemCounts, dictionary);
		int targetLevel = this.TargetLevel;
		INumberSelectData data = new INumberSelectData
		{
			MaxNumber = num2,
			ValueChangeFunction = new Action<int>(this.OnTargetLevelChange)
		};
		int minValue = (flag && num != num2) ? num : (num - 1);
		NumberSelectComponent numberSelectComponent = this.NumberSelectComponent;
		if (numberSelectComponent != null)
		{
			numberSelectComponent.Init(data);
		}
		NumberSelectComponent numberSelectComponent2 = this.NumberSelectComponent;
		if (numberSelectComponent2 != null)
		{
			numberSelectComponent2.SetMinValue(minValue);
		}
		NumberSelectComponent numberSelectComponent3 = this.NumberSelectComponent;
		if (numberSelectComponent3 != null)
		{
			numberSelectComponent3.Refresh(num2);
		}
		if (flag)
		{
			bool flag3 = num == num2;
			NumberSelectComponent numberSelectComponent4 = this.NumberSelectComponent;
			if (numberSelectComponent4 != null)
			{
				numberSelectComponent4.SetMinTextShowState(!flag3);
			}
			int num3 = flag2 ? Math.Min(Math.Max(targetLevel, num), num2) : num;
			this.TargetLevel = num3;
			NumberSelectComponent numberSelectComponent5 = this.NumberSelectComponent;
			if (numberSelectComponent5 != null)
			{
				numberSelectComponent5.ChangeValue(num3, false);
			}
			if (flag3)
			{
				NumberSelectComponent numberSelectComponent6 = this.NumberSelectComponent;
				if (numberSelectComponent6 != null)
				{
					numberSelectComponent6.SelectMax();
				}
				NumberSelectComponent numberSelectComponent7 = this.NumberSelectComponent;
				if (numberSelectComponent7 != null)
				{
					numberSelectComponent7.SetSliderAndButtonInteractive(false);
				}
			}
			this.RefreshConsumeForTargetLevel();
		}
		else
		{
			NumberSelectComponent numberSelectComponent8 = this.NumberSelectComponent;
			if (numberSelectComponent8 != null)
			{
				numberSelectComponent8.SetMinTextShowState(false);
			}
			NumberSelectComponent numberSelectComponent9 = this.NumberSelectComponent;
			if (numberSelectComponent9 != null)
			{
				numberSelectComponent9.SelectMax();
			}
			NumberSelectComponent numberSelectComponent10 = this.NumberSelectComponent;
			if (numberSelectComponent10 != null)
			{
				numberSelectComponent10.SetSliderAndButtonInteractive(false);
			}
			this.TargetLevel = num;
		}
		this.RefreshNextLevelText();
		this.LastInitSnapshotSkillNodeId = this.RoleSkillTreeInfoItemData.SkillNodeId;
		this.LastInitSnapshotCurrentLevel = this.CurrentSkillLevel;
		this.LastInitSnapshotItemCounts = dictionary;
	}

	// Token: 0x06014BA1 RID: 84897 RVA: 0x005BE8AC File Offset: 0x005BCAAC
	[NullableContext(1)]
	private Dictionary<int, int> CalcQuickLevelUpItemCountSnapshot()
	{
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = this.CurrentSkillLevel + 1; i <= this.MaxSkillLevel; i++)
		{
			IEnumerable<DicIntInt?> roleSkillTreeConsume = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillTreeConsume(this.RoleSkillTreeInfoItemData.SkillNodeId, i);
			if (roleSkillTreeConsume != null)
			{
				foreach (DicIntInt? dicIntInt in roleSkillTreeConsume)
				{
					hashSet.Add(dicIntInt.Value.Key);
				}
			}
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (int num in hashSet)
		{
			dictionary[num] = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(num, 0);
		}
		return dictionary;
	}

	// Token: 0x06014BA2 RID: 84898 RVA: 0x005BE998 File Offset: 0x005BCB98
	private bool IsItemCountSnapshotEqual(Dictionary<int, int> a, Dictionary<int, int> b)
	{
		if (a == null || b == null)
		{
			return false;
		}
		if (a.Count != b.Count)
		{
			return false;
		}
		foreach (KeyValuePair<int, int> keyValuePair in a)
		{
			int num;
			if (!b.TryGetValue(keyValuePair.Key, out num) || num != keyValuePair.Value)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06014BA3 RID: 84899 RVA: 0x005BEA1C File Offset: 0x005BCC1C
	private void CalcMaxTargetLevel()
	{
		int maxSkillLevel = this.MaxSkillLevel;
		int maxTargetLevel = this.CurrentSkillLevel;
		int num = this.CurrentSkillLevel + 1;
		while (num <= maxSkillLevel && this.CanLevelUpToTarget(num))
		{
			maxTargetLevel = num;
			num++;
		}
		this.MaxTargetLevel = maxTargetLevel;
	}

	// Token: 0x06014BA4 RID: 84900 RVA: 0x005BEA5C File Offset: 0x005BCC5C
	private bool CanUpgradeToLevel(int targetLevel)
	{
		int skillId = this.SkillTreeConfig.Value.SkillId;
		if (skillId == 0)
		{
			return false;
		}
		Aki.Config.Skill? skillConfigById = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillId);
		if (skillConfigById == null)
		{
			return false;
		}
		SkillLevel? skillLevelConfigByGroupIdAndLevel = ConfigBase<RoleSkillConfig>.Instance.GetSkillLevelConfigByGroupIdAndLevel(skillConfigById.Value.SkillLevelGroupId, targetLevel);
		if (skillLevelConfigByGroupIdAndLevel == null)
		{
			return false;
		}
		int condition = skillLevelConfigByGroupIdAndLevel.Value.Condition;
		return condition <= 0 || ControllerBase<LevelGeneralController>.Instance.CheckCondition(condition.ToString(), null, true, new object[]
		{
			this.RoleSkillTreeInfoItemData.RoleId
		});
	}

	// Token: 0x06014BA5 RID: 84901 RVA: 0x005BEB08 File Offset: 0x005BCD08
	private bool CanLevelUpToTarget(int targetLevel)
	{
		if (!this.CanUpgradeToLevel(targetLevel))
		{
			return false;
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = this.CurrentSkillLevel + 1; i <= targetLevel; i++)
		{
			IEnumerable<DicIntInt?> roleSkillTreeConsume = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillTreeConsume(this.RoleSkillTreeInfoItemData.SkillNodeId, i);
			if (roleSkillTreeConsume != null)
			{
				foreach (DicIntInt? dicIntInt in roleSkillTreeConsume)
				{
					int key = dicIntInt.Value.Key;
					int value = dicIntInt.Value.Value;
					int num;
					if (!dictionary.TryGetValue(key, out num))
					{
						num = 0;
					}
					dictionary[key] = num + value;
				}
			}
		}
		List<ISelectedData> list = new List<ISelectedData>();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int key2 = keyValuePair.Key;
			int value2 = keyValuePair.Value;
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key2, 0);
			SelectedData item = new SelectedData
			{
				ItemId = key2,
				IncId = 0,
				Count = value2,
				SelectedCount = itemCountByConfigId
			};
			list.Add(item);
		}
		list.Sort(delegate(ISelectedData a, ISelectedData b)
		{
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(a.ItemId);
			int num2 = (itemConfigData != null) ? itemConfigData.QualityId : 0;
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(b.ItemId);
			int num3 = (itemConfigData2 != null) ? itemConfigData2.QualityId : 0;
			return num2 - num3;
		});
		using (List<IComposePopupGridItemData>.Enumerator enumerator3 = ModelBase<ComposePopupModel>.Instance.CheckComposeResult(list, true, false).Item2.GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				if (enumerator3.Current.State == EGridState.NotEnough)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06014BA6 RID: 84902 RVA: 0x005BECE0 File Offset: 0x005BCEE0
	private void OnTargetLevelChange(int value)
	{
		this.TargetLevel = value;
		this.RefreshConsumeForTargetLevel();
		this.RefreshCostItemButtonForQuickLevelUp();
		this.RefreshBoxPanelVisibility();
		this.RefreshCurrentLevelAttributeForTargetLevel();
		this.RefreshNextLevelText();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(41), "QuickUpgrade_TargetLevel", new object[]
		{
			value
		});
	}

	// Token: 0x06014BA7 RID: 84903 RVA: 0x005BED38 File Offset: 0x005BCF38
	private void RefreshConsumeForTargetLevel()
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = this.CurrentSkillLevel + 1; i <= this.TargetLevel; i++)
		{
			IEnumerable<DicIntInt?> roleSkillTreeConsume = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillTreeConsume(this.RoleSkillTreeInfoItemData.SkillNodeId, i);
			if (roleSkillTreeConsume != null)
			{
				foreach (DicIntInt? dicIntInt in roleSkillTreeConsume)
				{
					int key = dicIntInt.Value.Key;
					int value = dicIntInt.Value.Value;
					int num;
					if (!dictionary.TryGetValue(key, out num))
					{
						num = 0;
					}
					dictionary[key] = num + value;
				}
			}
		}
		if (dictionary.Count == 0)
		{
			base.GetItem(22).SetUIActive(false);
			base.GetItem(23).SetUIActive(false);
			return;
		}
		base.GetItem(22).SetUIActive(true);
		base.GetItem(23).SetUIActive(true);
		List<ISelectedData> list = new List<ISelectedData>();
		int num2 = 0;
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int key2 = keyValuePair.Key;
			int value2 = keyValuePair.Value;
			if (key2 == 2)
			{
				num2 = value2;
			}
			else
			{
				SelectedData item2 = new SelectedData
				{
					ItemId = key2,
					IncId = 0,
					Count = value2,
					SelectedCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(key2, 0)
				};
				list.Add(item2);
			}
		}
		this.CachedConsumeList = (from item in list
		select new SelectedData
		{
			ItemId = item.ItemId,
			IncId = item.IncId,
			Count = item.Count,
			SelectedCount = item.SelectedCount
		}).ToList<ISelectedData>();
		this.ItemListLength = list.Count;
		if (num2 > 0)
		{
			this.CachedConsumeList.Add(new SelectedData
			{
				ItemId = 2,
				IncId = 0,
				Count = num2,
				SelectedCount = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(2, 0)
			});
		}
		UUIText text = base.GetText(13);
		text.SetText(num2.ToString(), true);
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(2, 0);
		UUIItem uuiitem = text;
		bool bUseChangeColor = itemCountByConfigId < num2;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		this.ConsumeItemScroll.RefreshByData(this.SortConsumeList(list), null, false);
	}

	// Token: 0x06014BA8 RID: 84904 RVA: 0x005BEFA8 File Offset: 0x005BD1A8
	private void RefreshCostItemButtonForQuickLevelUp()
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = this.CurrentSkillLevel + 1; i <= this.TargetLevel; i++)
		{
			IEnumerable<DicIntInt?> roleSkillTreeConsume = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillTreeConsume(this.RoleSkillTreeInfoItemData.SkillNodeId, i);
			if (roleSkillTreeConsume != null)
			{
				foreach (DicIntInt? dicIntInt in roleSkillTreeConsume)
				{
					int key = dicIntInt.Value.Key;
					int value = dicIntInt.Value.Value;
					int num;
					if (!dictionary.TryGetValue(key, out num))
					{
						num = 0;
					}
					dictionary[key] = num + value;
				}
			}
		}
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int key2 = keyValuePair.Key;
			int value2 = keyValuePair.Value;
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key2, 0) < value2)
			{
				List<ISelectedData> selectedDataList = this.GetSelectedDataList();
				bool flag = ModelBase<ComposePopupModel>.Instance.CheckOpenResult(selectedDataList);
				if (flag)
				{
					ButtonItem confirmButtonItem = this.ConfirmButtonItem;
					if (confirmButtonItem != null)
					{
						confirmButtonItem.SetShowText("AutoSynthesis_MaterialReplenishBtn_Text");
					}
				}
				else
				{
					ButtonItem confirmButtonItem2 = this.ConfirmButtonItem;
					if (confirmButtonItem2 != null)
					{
						confirmButtonItem2.SetShowText("AutoSynthesis_MaterialMissingBtn_Text");
					}
				}
				ButtonItem confirmButtonItem3 = this.ConfirmButtonItem;
				if (confirmButtonItem3 == null)
				{
					return;
				}
				confirmButtonItem3.SetEnableClick(flag);
				return;
			}
		}
		ButtonItem confirmButtonItem4 = this.ConfirmButtonItem;
		if (confirmButtonItem4 != null)
		{
			confirmButtonItem4.SetLocalText("RoleLevelUp", Array.Empty<object>());
		}
		ButtonItem confirmButtonItem5 = this.ConfirmButtonItem;
		if (confirmButtonItem5 == null)
		{
			return;
		}
		confirmButtonItem5.SetEnableClick(true);
	}

	// Token: 0x06014BA9 RID: 84905 RVA: 0x005BF154 File Offset: 0x005BD354
	private void RefreshBoxPanelVisibility()
	{
		if (base.GetItem(39) == null)
		{
			return;
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = this.CurrentSkillLevel + 1; i <= this.TargetLevel; i++)
		{
			IEnumerable<DicIntInt?> roleSkillTreeConsume = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillTreeConsume(this.RoleSkillTreeInfoItemData.SkillNodeId, i);
			if (roleSkillTreeConsume != null)
			{
				foreach (DicIntInt? dicIntInt in roleSkillTreeConsume)
				{
					int key = dicIntInt.Value.Key;
					int value = dicIntInt.Value.Value;
					int num;
					dictionary[key] = (dictionary.TryGetValue(key, out num) ? num : 0) + value;
				}
			}
		}
		List<ISelectedData> list = new List<ISelectedData>();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int key2 = keyValuePair.Key;
			int value2 = keyValuePair.Value;
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key2, 0);
			list.Add(new SelectedData
			{
				ItemId = key2,
				IncId = 0,
				Count = value2,
				SelectedCount = Math.Min(itemCountByConfigId, value2)
			});
		}
		bool boxPanelVisibility = list.Count > 0 && ModelBase<ComposePopupModel>.Instance.IsComposeGiftShouldShow(list);
		this.SetBoxPanelVisibility(boxPanelVisibility);
	}

	// Token: 0x06014BAA RID: 84906 RVA: 0x005BF2D8 File Offset: 0x005BD4D8
	private void SetBoxPanelVisibility(bool visible)
	{
		UUIItem item = base.GetItem(39);
		if (item == null)
		{
			return;
		}
		bool flag = item.IsUIActiveSelf();
		item.SetUIActive(visible);
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(11);
		UUIItem item2 = base.GetItem(45);
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(44);
		float num;
		if (visible)
		{
			num = base.GetItem(22).GetWidth() - item.GetWidth();
		}
		else
		{
			num = base.GetItem(22).GetWidth();
		}
		float spacing = horizontalLayout.GetSpacing();
		float num2 = horizontalLayout.GetPadding().Left + horizontalLayout.GetPadding().Right;
		float x = item2.D_GetRelativeTransform().GetScale3D().X;
		float num3 = (item2.GetWidth() * x + spacing) * (float)this.ItemListLength - spacing + num2;
		if (num3 < num)
		{
			num = num3;
		}
		if (scrollViewWithScrollbar != null)
		{
			UUIItem uuiitem = scrollViewWithScrollbar.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetWidth(num);
			}
		}
		LevelSequencePlayer consumeLevelSequencePlayer = this.ConsumeLevelSequencePlayer;
		if (consumeLevelSequencePlayer != null)
		{
			consumeLevelSequencePlayer.StopCurrentSequence(false, false);
		}
		if (visible)
		{
			if (flag == visible)
			{
				LevelSequencePlayer consumeLevelSequencePlayer2 = this.ConsumeLevelSequencePlayer;
				if (consumeLevelSequencePlayer2 == null)
				{
					return;
				}
				consumeLevelSequencePlayer2.PlayLevelSequenceByName("BoxStart", false, null, true);
				return;
			}
			else
			{
				LevelSequencePlayer consumeLevelSequencePlayer3 = this.ConsumeLevelSequencePlayer;
				if (consumeLevelSequencePlayer3 == null)
				{
					return;
				}
				consumeLevelSequencePlayer3.PlayLevelSequenceByName("BoxStart", false, null, false);
			}
		}
	}

	// Token: 0x06014BAB RID: 84907 RVA: 0x005BF420 File Offset: 0x005BD620
	private void RefreshCurrentLevelAttributeForTargetLevel()
	{
		this.CurAttributeDataList.Clear();
		this.NextAttributeDataList.Clear();
		SkillEffect skillEffectByLevel = this.GetSkillEffectByLevel(this.CurrentSkillLevel);
		List<OneSkillEffect> list = ((skillEffectByLevel != null) ? skillEffectByLevel.EffectDescList : null) ?? new List<OneSkillEffect>();
		SkillEffect skillEffectByLevel2 = this.GetSkillEffectByLevel(this.TargetLevel);
		List<OneSkillEffect> list2 = ((skillEffectByLevel2 != null) ? skillEffectByLevel2.EffectDescList : null) ?? new List<OneSkillEffect>();
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			this.CurAttributeDataList.Add(this.CreateAttributeData(list[i]));
			if (i < list2.Count)
			{
				this.NextAttributeDataList.Add(this.CreateAttributeData(list2[i]));
			}
		}
		this.CurrentLevelAttrScrollView.RefreshByData<CommonAttributeData>(this.CurAttributeDataList, null);
	}

	// Token: 0x06014BAC RID: 84908 RVA: 0x005BF4F0 File Offset: 0x005BD6F0
	private SkillEffect GetSkillEffectByLevel(int level)
	{
		int skillId = this.SkillTreeConfig.Value.SkillId;
		if (skillId == 0)
		{
			return null;
		}
		return ModelBase<RoleModel>.Instance.GetRoleSkillEffect(skillId, level);
	}

	// Token: 0x06014BAD RID: 84909 RVA: 0x005BF524 File Offset: 0x005BD724
	private void RefreshCurrentLevelAttribute()
	{
		this.CurAttributeDataList.Clear();
		this.NextAttributeDataList.Clear();
		List<OneSkillEffect> effectDescList = ModelBase<RoleModel>.Instance.RoleSkillResponseData.GetSkillEffect().EffectDescList;
		int count = effectDescList.Count;
		SkillEffect nextLevelSkillEffect = ModelBase<RoleModel>.Instance.RoleSkillResponseData.GetNextLevelSkillEffect();
		List<OneSkillEffect> list = (nextLevelSkillEffect != null) ? nextLevelSkillEffect.EffectDescList : null;
		for (int i = 0; i < count; i++)
		{
			this.CurAttributeDataList.Add(this.CreateAttributeData(effectDescList[i]));
			if (list != null)
			{
				this.NextAttributeDataList.Add(this.CreateAttributeData(list[i]));
			}
		}
		this.CurrentLevelAttrScrollView.RefreshByData<CommonAttributeData>(this.CurAttributeDataList, null);
	}

	// Token: 0x06014BAE RID: 84910 RVA: 0x005BF5D9 File Offset: 0x005BD7D9
	public void ShowLeftPanelByTabType(ESkillTabShowType tabShowType)
	{
		if (tabShowType == ESkillTabShowType.Introduction)
		{
			this.ShowToIntroductionItem(true);
			return;
		}
		this.ShowToAttrDetailItem();
	}

	// Token: 0x06014BAF RID: 84911 RVA: 0x005BF5F0 File Offset: 0x005BD7F0
	private void ShowToIntroductionItem(bool isPlaySequence = true)
	{
		base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		base.GetItem(7).SetUIActive(true);
		base.GetScrollViewWithScrollbar(8).GetRootComponent().SetUIActive(false);
		this.HideNextLevelItem();
		this.ShowRightPanel(this.CurSkillTabShowType, this.IsShowRightPanel);
		this.ShowSkillBranchItem(true);
	}

	// Token: 0x06014BB0 RID: 84912 RVA: 0x005BF660 File Offset: 0x005BD860
	private void ShowToAttrDetailItem()
	{
		base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		base.GetItem(7).SetUIActive(false);
		base.GetScrollViewWithScrollbar(8).GetRootComponent().SetUIActive(true);
		this.HideRoleSkillInputPanel();
		this.ShowRightPanel(this.CurSkillTabShowType, this.IsShowRightPanel);
		this.ShowSkillBranchItem(false);
	}

	// Token: 0x06014BB1 RID: 84913 RVA: 0x005BF6CD File Offset: 0x005BD8CD
	private void ShowRightPanel(ESkillTabShowType showType, bool isActive)
	{
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRoleSkillInputPanelVisible, isActive);
		if (this.CurSkillTabShowType == ESkillTabShowType.Detail)
		{
			if (isActive)
			{
				this.ShowNextLevelItem();
				return;
			}
			this.HideNextLevelItem();
			return;
		}
		else
		{
			if (isActive)
			{
				this.ShowRoleSkillInputPanel();
				return;
			}
			this.HideRoleSkillInputPanel();
			return;
		}
	}

	// Token: 0x06014BB2 RID: 84914 RVA: 0x005BF70A File Offset: 0x005BD90A
	private void ShowRoleSkillInputPanel()
	{
		base.GetItem(27).SetUIActive(true);
	}

	// Token: 0x06014BB3 RID: 84915 RVA: 0x005BF71A File Offset: 0x005BD91A
	private void HideRoleSkillInputPanel()
	{
		base.GetItem(27).SetUIActive(false);
	}

	// Token: 0x06014BB4 RID: 84916 RVA: 0x005BF72C File Offset: 0x005BD92C
	private void ShowNextLevelItem()
	{
		base.GetItem(20).SetUIActive(true);
		foreach (RoleSkillTreeAttributeItem roleSkillTreeAttributeItem in this.CurrentLevelAttrScrollView.GetScrollItemList())
		{
			roleSkillTreeAttributeItem.SetNextLevelItem(true);
		}
	}

	// Token: 0x06014BB5 RID: 84917 RVA: 0x005BF790 File Offset: 0x005BD990
	private void HideNextLevelItem()
	{
		base.GetItem(20).SetUIActive(false);
		foreach (RoleSkillTreeAttributeItem roleSkillTreeAttributeItem in this.CurrentLevelAttrScrollView.GetScrollItemList())
		{
			roleSkillTreeAttributeItem.SetNextLevelItem(false);
		}
	}

	// Token: 0x06014BB6 RID: 84918 RVA: 0x005BF7F4 File Offset: 0x005BD9F4
	private void PlayRightPanelSequence(bool showState)
	{
		if (showState)
		{
			this.LevelSequencePlayer.PlayOrReplaySequenceByName("ViewShow", false, null);
			return;
		}
		this.LevelSequencePlayer.PlayOrReplaySequenceByName("ViewHide", false, null);
	}

	// Token: 0x06014BB7 RID: 84919 RVA: 0x005BF83C File Offset: 0x005BDA3C
	[NullableContext(1)]
	public void PlayItemSequence(string seq)
	{
		this.LevelSequencePlayer.PlayOrReplaySequenceByName(seq, false, null);
	}

	// Token: 0x06014BB8 RID: 84920 RVA: 0x005BF860 File Offset: 0x005BDA60
	[NullableContext(1)]
	public UniTask PlayItemSequenceAsync(string seq)
	{
		RoleSkillTreeInfoItem.<PlayItemSequenceAsync>d__103 <PlayItemSequenceAsync>d__;
		<PlayItemSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayItemSequenceAsync>d__.<>4__this = this;
		<PlayItemSequenceAsync>d__.seq = seq;
		<PlayItemSequenceAsync>d__.<>1__state = -1;
		<PlayItemSequenceAsync>d__.<>t__builder.Start<RoleSkillTreeInfoItem.<PlayItemSequenceAsync>d__103>(ref <PlayItemSequenceAsync>d__);
		return <PlayItemSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014BB9 RID: 84921 RVA: 0x005BF8AC File Offset: 0x005BDAAC
	public void RefreshRoleBackgroundMusicSwitchItem()
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleSkillTreeInfoItemData.RoleId);
		if (roleInstanceById == null || roleInstanceById.IsTrialRole() || !roleInstanceById.GetRoleConfig().EnableOperateSelfBgm)
		{
			base.GetItem(34).SetUIActive(false);
			return;
		}
		base.GetItem(34).SetUIActive(true);
		RoleBackgroundMusicSwitchItem roleBackgroundMusicSwitchItem = this.RoleBackgroundMusicSwitchItem;
		if (roleBackgroundMusicSwitchItem == null)
		{
			return;
		}
		roleBackgroundMusicSwitchItem.RefreshByRoleData(roleInstanceById);
	}

	// Token: 0x06014BBA RID: 84922 RVA: 0x005BF918 File Offset: 0x005BDB18
	protected override void OnHide()
	{
		this.IsShowRightPanel = false;
		this.CurSkillTabShowType = ESkillTabShowType.Introduction;
		this.ShowLeftPanelByTabType(this.CurSkillTabShowType);
	}

	// Token: 0x06014BBB RID: 84923 RVA: 0x005BF934 File Offset: 0x005BDB34
	public ESkillTabShowType GetCurSkillTabShowType()
	{
		return this.CurSkillTabShowType;
	}

	// Token: 0x06014BBC RID: 84924 RVA: 0x005BF93C File Offset: 0x005BDB3C
	private void RefreshSkillBranch()
	{
		int skillNodeId = this.RoleSkillTreeInfoItemData.SkillNodeId;
		if (!ModelBase<RoleModel>.Instance.IsSkillNodeHasBranch(skillNodeId))
		{
			this.IsShowSkillBranch = false;
			return;
		}
		this.IsShowSkillBranch = true;
		int roleId = this.RoleSkillTreeInfoItemData.RoleId;
		int skillNodeCurrentBranchId = ModelBase<RoleModel>.Instance.GetSkillNodeCurrentBranchId(roleId, skillNodeId);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<RoleConfig>.Instance.GetSkillBranchConfigById(skillNodeCurrentBranchId).Value.Name, null);
		string skillBranchActivatedDescKey = ConfigBase<RoleConfig>.Instance.GetSkillBranchActivatedDescKey();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(36), skillBranchActivatedDescKey, new <>z__ReadOnlySingleElementList<object>(localTextNew));
		SkillTree? skillTreeNode = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(skillNodeId);
		bool flag = ((skillTreeNode != null) ? skillTreeNode.GetValueOrDefault().SkillBranchDescListLength : 0) > 0;
		base.GetButton(37).RootUIComp.Get().SetUIActive(flag);
		if (flag)
		{
			int roleCurrentBranchIndex = ModelBase<RoleModel>.Instance.GetRoleCurrentBranchIndex(roleId);
			int num = (skillTreeNode != null) ? skillTreeNode.GetValueOrDefault().SkillBranchDescListLength : 0;
			if (roleCurrentBranchIndex >= num)
			{
				return;
			}
			string text = (skillTreeNode != null) ? skillTreeNode.GetValueOrDefault().SkillBranchDescList(ModelBase<RoleModel>.Instance.GetRoleCurrentBranchIndex(roleId)) : null;
			RoleSkillTreeInfoItem.RoleSkillBranchDetailItem branchDetailItem = this.BranchDetailItem;
			if (branchDetailItem == null)
			{
				return;
			}
			branchDetailItem.Refresh(text ?? "");
		}
	}

	// Token: 0x06014BBD RID: 84925 RVA: 0x005BFA96 File Offset: 0x005BDC96
	private void ClickBranchDetailBtn()
	{
		if (this.BranchDetailItem == null)
		{
			return;
		}
		if (this.BranchDetailItem.IsShowOrShowing)
		{
			this.BranchDetailItem.Hide(null);
			return;
		}
		this.BranchDetailItem.Show(null);
	}

	// Token: 0x06014BBE RID: 84926 RVA: 0x005BFAC7 File Offset: 0x005BDCC7
	private void ShowSkillBranchItem(bool isActive)
	{
		base.GetItem(35).SetUIActive(this.IsSkillBranchEnable && this.IsShowSkillBranch && isActive);
	}

	// Token: 0x06014BBF RID: 84927 RVA: 0x005BFAE9 File Offset: 0x005BDCE9
	public void OnRoleSkillBranchChanged()
	{
		this.RefreshSkillBranch();
		this.Refresh();
	}

	// Token: 0x06014BC0 RID: 84928 RVA: 0x005BFAF7 File Offset: 0x005BDCF7
	public void SetSkillBranchEnable(bool isEnable)
	{
		this.IsSkillBranchEnable = isEnable;
	}

	// Token: 0x06014BC1 RID: 84929 RVA: 0x005BFB00 File Offset: 0x005BDD00
	public void SetParentView(UiViewBase view)
	{
		this.ParentView = view;
	}

	// Token: 0x04009FB4 RID: 40884
	[Nullable(1)]
	private IRoleSkillTreeInfoItemData RoleSkillTreeInfoItemData = new RoleSkillTreeInfoItemData();

	// Token: 0x04009FB5 RID: 40885
	private RoleSkillData SkillData;

	// Token: 0x04009FB6 RID: 40886
	private SkillTree? SkillTreeConfig;

	// Token: 0x04009FB7 RID: 40887
	private int SkillId;

	// Token: 0x04009FB8 RID: 40888
	private int UpgradeSkillId;

	// Token: 0x04009FB9 RID: 40889
	private int ShowSkillId;

	// Token: 0x04009FBA RID: 40890
	private Aki.Config.Skill? SkillConfig;

	// Token: 0x04009FBB RID: 40891
	private Aki.Config.Skill? ShowSkillConfig;

	// Token: 0x04009FBC RID: 40892
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<CostMediumItemGrid, ISelectedData> ConsumeItemScroll;

	// Token: 0x04009FBD RID: 40893
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<RoleSkillTreeAttributeItem> CurrentLevelAttrScrollView;

	// Token: 0x04009FBE RID: 40894
	private PopupCaptionItem CaptionItem;

	// Token: 0x04009FBF RID: 40895
	private ButtonItem ConfirmButtonItem;

	// Token: 0x04009FC0 RID: 40896
	private bool IsLevelUpPending;

	// Token: 0x04009FC1 RID: 40897
	private RoleSkillInputPanel RoleSkillInputPanel;

	// Token: 0x04009FC2 RID: 40898
	protected RoleBackgroundMusicSwitchItem RoleBackgroundMusicSwitchItem;

	// Token: 0x04009FC3 RID: 40899
	private bool UseTexture;

	// Token: 0x04009FC4 RID: 40900
	private bool IsShowRightPanel;

	// Token: 0x04009FC5 RID: 40901
	private ESkillTabShowType CurSkillTabShowType = ESkillTabShowType.Introduction;

	// Token: 0x04009FC6 RID: 40902
	[Nullable(1)]
	private readonly List<CommonAttributeData> CurAttributeDataList = new List<CommonAttributeData>();

	// Token: 0x04009FC7 RID: 40903
	[Nullable(1)]
	private readonly List<CommonAttributeData> NextAttributeDataList = new List<CommonAttributeData>();

	// Token: 0x04009FC8 RID: 40904
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04009FC9 RID: 40905
	private LevelSequencePlayer ConsumeLevelSequencePlayer;

	// Token: 0x04009FCA RID: 40906
	public Action OnBackBtnCallBack;

	// Token: 0x04009FCB RID: 40907
	private ERoleSkillDescType SkillDescType;

	// Token: 0x04009FCC RID: 40908
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ISelectedData> CachedConsumeList;

	// Token: 0x04009FCD RID: 40909
	private int ItemListLength;

	// Token: 0x04009FCE RID: 40910
	private bool IsShowSkillBranch;

	// Token: 0x04009FCF RID: 40911
	private bool IsSkillBranchEnable;

	// Token: 0x04009FD0 RID: 40912
	private UiViewBase ParentView;

	// Token: 0x04009FD1 RID: 40913
	private RoleSkillTreeInfoItem.RoleSkillBranchDetailItem BranchDetailItem;

	// Token: 0x04009FD2 RID: 40914
	private NumberSelectComponent NumberSelectComponent;

	// Token: 0x04009FD3 RID: 40915
	private int TargetLevel;

	// Token: 0x04009FD4 RID: 40916
	private int MaxTargetLevel;

	// Token: 0x04009FD5 RID: 40917
	private int CurrentSkillLevel;

	// Token: 0x04009FD6 RID: 40918
	private int MaxSkillLevel;

	// Token: 0x04009FD7 RID: 40919
	private int LastInitSnapshotSkillNodeId;

	// Token: 0x04009FD8 RID: 40920
	private int LastInitSnapshotCurrentLevel = -1;

	// Token: 0x04009FD9 RID: 40921
	private Dictionary<int, int> LastInitSnapshotItemCounts;

	// Token: 0x02008C15 RID: 35861
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F2FE RID: 193278
		IconSprite,
		// Token: 0x0402F2FF RID: 193279
		IconTexture,
		// Token: 0x0402F300 RID: 193280
		SkillTypeText,
		// Token: 0x0402F301 RID: 193281
		LevelText,
		// Token: 0x0402F302 RID: 193282
		IntroductionToggle,
		// Token: 0x0402F303 RID: 193283
		AttrDetailToggle,
		// Token: 0x0402F304 RID: 193284
		TogglesItem,
		// Token: 0x0402F305 RID: 193285
		IntroductionItem,
		// Token: 0x0402F306 RID: 193286
		AttrDetailScrollView,
		// Token: 0x0402F307 RID: 193287
		SkillNameText,
		// Token: 0x0402F308 RID: 193288
		SkillDescText,
		// Token: 0x0402F309 RID: 193289
		ConsumeItemScroll,
		// Token: 0x0402F30A RID: 193290
		MoneyTexture,
		// Token: 0x0402F30B RID: 193291
		MoneyText,
		// Token: 0x0402F30C RID: 193292
		ConfirmButtonItem,
		// Token: 0x0402F30D RID: 193293
		ActivatedItem,
		// Token: 0x0402F30E RID: 193294
		ActivatedText,
		// Token: 0x0402F30F RID: 193295
		LockItem,
		// Token: 0x0402F310 RID: 193296
		ConditionText,
		// Token: 0x0402F311 RID: 193297
		RightPanelToggle,
		// Token: 0x0402F312 RID: 193298
		NextLevelItem,
		// Token: 0x0402F313 RID: 193299
		CaptionItem,
		// Token: 0x0402F314 RID: 193300
		ConsumeItem,
		// Token: 0x0402F315 RID: 193301
		ConsumeTextItem,
		// Token: 0x0402F316 RID: 193302
		BackButton,
		// Token: 0x0402F317 RID: 193303
		NextLevelMaskButton,
		// Token: 0x0402F318 RID: 193304
		LockTipBtn,
		// Token: 0x0402F319 RID: 193305
		RoleSkillInputRoot,
		// Token: 0x0402F31A RID: 193306
		RoleSkillInputPanel,
		// Token: 0x0402F31B RID: 193307
		RoleSkillMaskButton,
		// Token: 0x0402F31C RID: 193308
		SkillModeToggle,
		// Token: 0x0402F31D RID: 193309
		SkillModeItem,
		// Token: 0x0402F31E RID: 193310
		NextLevelText,
		// Token: 0x0402F31F RID: 193311
		SkillModeText,
		// Token: 0x0402F320 RID: 193312
		RoleBGMSwitchItem,
		// Token: 0x0402F321 RID: 193313
		BranchItem,
		// Token: 0x0402F322 RID: 193314
		BranchText,
		// Token: 0x0402F323 RID: 193315
		BtnBranchDetail,
		// Token: 0x0402F324 RID: 193316
		ItemBranchDetailRoot,
		// Token: 0x0402F325 RID: 193317
		BoxPanel,
		// Token: 0x0402F326 RID: 193318
		FullLevelPanel,
		// Token: 0x0402F327 RID: 193319
		SlideAmountText,
		// Token: 0x0402F328 RID: 193320
		NumControlItem,
		// Token: 0x0402F329 RID: 193321
		NextLevelMaxSprite,
		// Token: 0x0402F32A RID: 193322
		ConsumeItemContent,
		// Token: 0x0402F32B RID: 193323
		ConsumeItemGrid,
		// Token: 0x0402F32C RID: 193324
		BoxText,
		// Token: 0x0402F32D RID: 193325
		ConsumePanelItem
	}

	// Token: 0x02008C16 RID: 35862
	[NullableContext(0)]
	public class RoleSkillBranchDetailItem : UiPanelBase
	{
		// Token: 0x06049761 RID: 300897 RVA: 0x013DBC84 File Offset: 0x013D9E84
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnCloseBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06049762 RID: 300898 RVA: 0x013DBD6C File Offset: 0x013D9F6C
		[NullableContext(1)]
		public void Refresh(string desc)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), desc, Array.Empty<object>());
		}

		// Token: 0x06049763 RID: 300899 RVA: 0x013DBD85 File Offset: 0x013D9F85
		private void OnCloseBtnClick()
		{
			base.Hide(null);
		}

		// Token: 0x0200CDF7 RID: 52727
		private enum EComponent
		{
			// Token: 0x0403F80C RID: 260108
			ItemSelf,
			// Token: 0x0403F80D RID: 260109
			TextTitle,
			// Token: 0x0403F80E RID: 260110
			TextDesc,
			// Token: 0x0403F80F RID: 260111
			BtnClose
		}
	}
}
