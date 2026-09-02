using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.InputView.Controller;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using FilterDefine;
using UnrealEngine;

// Token: 0x020024E8 RID: 9448
[NullableContext(1)]
[Nullable(0)]
public class VisionAssembleView : UiViewBase
{
	// Token: 0x06012578 RID: 75128 RVA: 0x0050ABAC File Offset: 0x00508DAC
	public VisionAssembleView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012579 RID: 75129 RVA: 0x0050ABE0 File Offset: 0x00508DE0
	protected unsafe override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem))
		};
		int num = 3;
		List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
		Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Delegate>(13, new Action<EToggleState>(this.OnCompareToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickToTopBtn));
		num2++;
		*span[num2] = new ValueTuple<int, Delegate>(12, new Action(this.OnClickDeleteBtn));
		this.BtnBindInfo = list;
	}

	// Token: 0x0601257A RID: 75130 RVA: 0x0050AE44 File Offset: 0x00509044
	protected override UniTask OnCreateAsync()
	{
		VisionAssembleView.<OnCreateAsync>d__25 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<VisionAssembleView.<OnCreateAsync>d__25>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601257B RID: 75131 RVA: 0x0050AE80 File Offset: 0x00509080
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnVisionGroupDataAdd, new Action(this.OnVisionGroupDataAdd));
		Singleton<EventSystem>.Instance.Add(EEventName.OnVisionGroupDataDelete, new Action(this.OnVisionGroupDataDelete));
		Singleton<EventSystem>.Instance.Add(EEventName.OnVisionGroupDataToTop, new Action(this.OnVisionGroupDataToTop));
		Singleton<EventSystem>.Instance.Add(EEventName.OnVisionGroupDataChangeName, new Action(this.OnVisionGroupDataChangeName));
		Singleton<EventSystem>.Instance.Add(EEventName.PhantomEquip, new Action(this.OnPhantomEquip));
	}

	// Token: 0x0601257C RID: 75132 RVA: 0x0050AF1C File Offset: 0x0050911C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionGroupDataAdd, new Action(this.OnVisionGroupDataAdd));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionGroupDataDelete, new Action(this.OnVisionGroupDataDelete));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionGroupDataToTop, new Action(this.OnVisionGroupDataToTop));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionGroupDataChangeName, new Action(this.OnVisionGroupDataChangeName));
		Singleton<EventSystem>.Instance.Remove(EEventName.PhantomEquip, new Action(this.OnPhantomEquip));
	}

	// Token: 0x0601257D RID: 75133 RVA: 0x0050AFB8 File Offset: 0x005091B8
	protected override UniTask OnBeforeStartAsync()
	{
		VisionAssembleView.<OnBeforeStartAsync>d__28 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionAssembleView.<OnBeforeStartAsync>d__28>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601257E RID: 75134 RVA: 0x0050AFFC File Offset: 0x005091FC
	private UniTask InitDropDown()
	{
		VisionAssembleView.<InitDropDown>d__29 <InitDropDown>d__;
		<InitDropDown>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitDropDown>d__.<>4__this = this;
		<InitDropDown>d__.<>1__state = -1;
		<InitDropDown>d__.<>t__builder.Start<VisionAssembleView.<InitDropDown>d__29>(ref <InitDropDown>d__);
		return <InitDropDown>d__.<>t__builder.Task;
	}

	// Token: 0x0601257F RID: 75135 RVA: 0x0050B03F File Offset: 0x0050923F
	private void OnPhantomEquip()
	{
		this.RefreshCurrentSelectDataInfo();
		this.RefreshStaticItemSelectState();
		this.RefreshOperationFunctionState();
		this.RefreshFunctionButtonState();
		this.RefreshCompareTopData();
		this.RefreshCurrentSuitInfo();
		this.RefreshScroller(true, false);
	}

	// Token: 0x06012580 RID: 75136 RVA: 0x0050B070 File Offset: 0x00509270
	private void OnVisionGroupDataAdd()
	{
		this.UpdateFilterComponent();
		this.ClearFilter();
		this.CancelCompareMode();
		int count = ModelBase<VisionEquipGroupModel>.Instance.GetVisionEquipGroupList().Count;
		this.CurrentSelectedIndex = count - 1;
		this.RefreshScroller(false, false);
		this.RefreshAttributeScroller(false, null);
		this.RefreshSaveText();
		this.RefreshOperationFunctionState();
		this.RefreshFunctionButtonState();
		this.RefreshCompareTopData();
		this.RefreshCompareToggleState();
	}

	// Token: 0x06012581 RID: 75137 RVA: 0x0050B0D8 File Offset: 0x005092D8
	private void OnVisionGroupDataDelete()
	{
		if (ModelBase<VisionEquipGroupModel>.Instance.GetVisionEquipGroupList().Count > 0)
		{
			this.CurrentSelectedIndex = 0;
		}
		else
		{
			this.CurrentSelectedIndex = -1;
		}
		this.RefreshViewAfterChangeGroupData();
	}

	// Token: 0x06012582 RID: 75138 RVA: 0x0050B102 File Offset: 0x00509302
	private void OnVisionGroupDataToTop()
	{
		if (ModelBase<VisionEquipGroupModel>.Instance.GetVisionEquipGroupList().Count > 0)
		{
			this.CurrentSelectedIndex = 0;
		}
		else
		{
			this.CurrentSelectedIndex = -1;
		}
		this.RefreshViewAfterChangeGroupData();
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnVisionAssembleNavigationRefresh, false);
	}

	// Token: 0x06012583 RID: 75139 RVA: 0x0050B13D File Offset: 0x0050933D
	private void OnVisionGroupDataChangeName()
	{
		this.RefreshCompareTopData();
		this.RefreshCurrentSelectDataInfo();
		this.RefreshScroller(true, false);
	}

	// Token: 0x06012584 RID: 75140 RVA: 0x0050B153 File Offset: 0x00509353
	private void RefreshViewAfterChangeGroupData()
	{
		this.RefreshScroller(false, false);
		this.RefreshAttributeScroller(false, null);
		this.RefreshSaveText();
		this.RefreshOperationFunctionState();
		this.RefreshFunctionButtonState();
		this.RefreshCompareTopData();
		this.UpdateFilterComponent();
	}

	// Token: 0x06012585 RID: 75141 RVA: 0x0050B183 File Offset: 0x00509383
	private int GetDropDownTextId(int data)
	{
		return data;
	}

	// Token: 0x06012586 RID: 75142 RVA: 0x0050B186 File Offset: 0x00509386
	private void OnDropDownSelectCall(int index, int data)
	{
		this.CurrentSelectSuitIndex = index;
		this.UpdateFilterComponent();
	}

	// Token: 0x06012587 RID: 75143 RVA: 0x0050B195 File Offset: 0x00509395
	private VisionAssembleDropDownItem CreateDropDownItem(UUIItem uiItem, int data)
	{
		return new VisionAssembleDropDownItem(uiItem);
	}

	// Token: 0x06012588 RID: 75144 RVA: 0x0050B19D File Offset: 0x0050939D
	private VisionEquipmentDropDownTitleItem CreateTitleItem(UUIItem uiItem)
	{
		return new VisionEquipmentDropDownTitleItem(uiItem);
	}

	// Token: 0x06012589 RID: 75145 RVA: 0x0050B1A8 File Offset: 0x005093A8
	private void OnCompareToggle(EToggleState toggleState)
	{
		this.CompareMode = !this.CompareMode;
		bool compareMode = this.CompareMode;
		this.RefreshAttributeScroller(compareMode, null);
		this.RefreshFunctionButtonState();
		this.RefreshStaticItemSelectState();
		ModelBase<UiNavigationModel>.Instance.TrySetCursorActive(false);
		if (this.CompareMode)
		{
			this.RefreshCurrentSelectDataInfo();
			base.PlaySequence("Start_B", delegate
			{
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnVisionAssembleNavigationRefresh, true);
			}, true);
		}
		else
		{
			this.RefreshCurrentSelectDataInfo();
			base.PlaySequence("Close_B", delegate
			{
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnVisionAssembleNavigationRefresh, true);
			}, true);
		}
		this.AssembleScrollToSelectIndex(false);
	}

	// Token: 0x0601258A RID: 75146 RVA: 0x0050B260 File Offset: 0x00509460
	private void AssembleScrollToSelectIndex(bool playGridAnim = false)
	{
		if (this.CurrentSelectedIndex == -1)
		{
			return;
		}
		if (this.ShowList == null || this.ShowList.Count == 0)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < this.ShowList.Count; i++)
		{
			if (this.ShowList[i].CurrentSelectState)
			{
				num = i;
				break;
			}
		}
		int gridIndex = (num >= 0) ? num : 0;
		LoopScrollView<VisionAssembleScrollItem, VisionAssembleScrollItemData> assembleListLayout = this.AssembleListLayout;
		if (assembleListLayout == null)
		{
			return;
		}
		assembleListLayout.ScrollToGridIndex(gridIndex, playGridAnim);
	}

	// Token: 0x0601258B RID: 75147 RVA: 0x0050B2D7 File Offset: 0x005094D7
	private bool CancelCompareMode()
	{
		if (!this.CompareMode)
		{
			return false;
		}
		this.OnCompareToggle(EToggleState.ETT_Checked);
		return true;
	}

	// Token: 0x0601258C RID: 75148 RVA: 0x0050B2EC File Offset: 0x005094EC
	private bool ClearFilter()
	{
		bool result = false;
		if (this.CurrentSelectSuitIndex != 0)
		{
			this.CommonDropDown.SetSelectedIndex(0, true);
			result = true;
		}
		if (this.FilterEntrance.TryClearData())
		{
			result = true;
		}
		return result;
	}

	// Token: 0x0601258D RID: 75149 RVA: 0x0050B322 File Offset: 0x00509522
	private void OnClickStaticItem()
	{
		if (this.CurrentSelectedIndex == -1)
		{
			this.CurrentSelectedIndex = 999;
		}
		else
		{
			this.CurrentSelectedIndex = -1;
		}
		this.OnChangeSelectIndex(true);
		this.RefreshFunctionButtonState();
		this.RefreshOperationFunctionState();
		this.RefreshAttributeScroller(false, null);
		this.RefreshCompareToggleState();
	}

	// Token: 0x0601258E RID: 75150 RVA: 0x0050B364 File Offset: 0x00509564
	private void OnClickConfirmButton(int _)
	{
		VisionAssembleView.EOperation currentOperationState = this.GetCurrentOperationState();
		if (currentOperationState == VisionAssembleView.EOperation.Use)
		{
			this.ApplyCurrentIndexGroup();
			this.CancelCompareMode();
			return;
		}
		if (currentOperationState == VisionAssembleView.EOperation.Save)
		{
			this.SaveCurrentIndexGroup();
			return;
		}
		if (currentOperationState == VisionAssembleView.EOperation.HasUsing)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("VisionAssembleHasUseTips", Array.Empty<object>());
		}
	}

	// Token: 0x0601258F RID: 75151 RVA: 0x0050B3B0 File Offset: 0x005095B0
	private void SaveCurrentIndexGroup()
	{
		List<int> incrIdList = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.CurrentRoleId).GetPhantomData().GetIncrIdList();
		bool flag = true;
		using (List<int>.Enumerator enumerator = incrIdList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current != 0)
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("VisionAssembleSaveNone", Array.Empty<object>());
			return;
		}
		int phantomEquipGroupCountMax = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomEquipGroupCountMax();
		int count = ModelBase<VisionEquipGroupModel>.Instance.GetVisionEquipGroupList().Count;
		if (count >= phantomEquipGroupCountMax)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.VisionGroupMax);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		Func<string, UniTask<Aki.Protocol.ErrorCode>> callBack = delegate([Nullable(1)] string input)
		{
			VisionAssembleView.<<SaveCurrentIndexGroup>b__46_0>d <<SaveCurrentIndexGroup>b__46_0>d;
			<<SaveCurrentIndexGroup>b__46_0>d.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
			<<SaveCurrentIndexGroup>b__46_0>d.<>4__this = this;
			<<SaveCurrentIndexGroup>b__46_0>d.input = input;
			<<SaveCurrentIndexGroup>b__46_0>d.<>1__state = -1;
			<<SaveCurrentIndexGroup>b__46_0>d.<>t__builder.Start<VisionAssembleView.<<SaveCurrentIndexGroup>b__46_0>d>(ref <<SaveCurrentIndexGroup>b__46_0>d);
			return <<SaveCurrentIndexGroup>b__46_0>d.<>t__builder.Task;
		};
		string bottomText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("VisionAssembleCurrentIndex", null), new string[]
		{
			(count + 1).ToString()
		});
		ControllerBase<CommonInputViewController>.Instance.OpenSetVisionEquipGroupName(bottomText, callBack, "");
	}

	// Token: 0x06012590 RID: 75152 RVA: 0x0050B4B0 File Offset: 0x005096B0
	private void ApplyCurrentIndexGroup()
	{
		int[] visionUniqueIdList = ModelBase<VisionEquipGroupModel>.Instance.GetVisionEquipGroupDataByIndex(this.CurrentSelectedIndex).GetVisionUniqueIdList();
		bool flag = false;
		foreach (int uniqueId in visionUniqueIdList)
		{
			int? phantomEquipOnRoleId = ModelBase<PhantomBattleModel>.Instance.GetPhantomEquipOnRoleId(uniqueId);
			if (phantomEquipOnRoleId != null && phantomEquipOnRoleId.Value != this.CurrentRoleId)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.VisionGroupOtherRoleUse);
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				ControllerBase<VisionEquipGroupController>.Instance.RequestApplyVisionGroup(this.CurrentSelectedIndex, this.CurrentRoleId);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		ControllerBase<VisionEquipGroupController>.Instance.RequestApplyVisionGroup(this.CurrentSelectedIndex, this.CurrentRoleId);
	}

	// Token: 0x06012591 RID: 75153 RVA: 0x0050B55C File Offset: 0x0050975C
	private void OnClickReNameBtn()
	{
		Func<string, UniTask<Aki.Protocol.ErrorCode>> callBack = delegate([Nullable(1)] string input)
		{
			VisionAssembleView.<<OnClickReNameBtn>b__48_0>d <<OnClickReNameBtn>b__48_0>d;
			<<OnClickReNameBtn>b__48_0>d.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
			<<OnClickReNameBtn>b__48_0>d.<>4__this = this;
			<<OnClickReNameBtn>b__48_0>d.input = input;
			<<OnClickReNameBtn>b__48_0>d.<>1__state = -1;
			<<OnClickReNameBtn>b__48_0>d.<>t__builder.Start<VisionAssembleView.<<OnClickReNameBtn>b__48_0>d>(ref <<OnClickReNameBtn>b__48_0>d);
			return <<OnClickReNameBtn>b__48_0>d.<>t__builder.Task;
		};
		string bottomText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("VisionAssembleCurrentIndex", null), new string[]
		{
			(this.CurrentSelectedIndex + 1).ToString()
		});
		VisionEquipGroupData visionEquipGroupDataByIndex = ModelBase<VisionEquipGroupModel>.Instance.GetVisionEquipGroupDataByIndex(this.CurrentSelectedIndex);
		string text = (visionEquipGroupDataByIndex != null) ? visionEquipGroupDataByIndex.GetName() : null;
		ControllerBase<CommonInputViewController>.Instance.OpenSetVisionEquipGroupName(bottomText, callBack, text ?? "");
	}

	// Token: 0x06012592 RID: 75154 RVA: 0x0050B5D4 File Offset: 0x005097D4
	private void OnClickToTopBtn()
	{
		if (!ModelBase<VisionEquipGroupModel>.Instance.GetLocalTipsState())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.VisionGroupToTop);
			confirmBoxDataNew.HasToggle = true;
			confirmBoxDataNew.ToggleText = ConfigMultiTextLang.GetLocalTextNew("VisionAssembleTopNeverTips", null);
			confirmBoxDataNew.SetToggleFunction(new Action<bool>(this.OnClickedNotShowConfirm));
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				ControllerBase<VisionEquipGroupController>.Instance.RequestPutVisionGroupToTop(this.CurrentSelectedIndex);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		ControllerBase<VisionEquipGroupController>.Instance.RequestPutVisionGroupToTop(this.CurrentSelectedIndex);
	}

	// Token: 0x06012593 RID: 75155 RVA: 0x0050B657 File Offset: 0x00509857
	private void OnClickedNotShowConfirm(bool toggleState)
	{
		ModelBase<VisionEquipGroupModel>.Instance.SaveLocalTopTipState(toggleState);
	}

	// Token: 0x06012594 RID: 75156 RVA: 0x0050B664 File Offset: 0x00509864
	private void OnClickDeleteBtn()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.VisionGroupDelete);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			ControllerBase<VisionEquipGroupController>.Instance.RequestDeleteVisionEquipGroup(this.CurrentSelectedIndex);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06012595 RID: 75157 RVA: 0x0050B6A0 File Offset: 0x005098A0
	private void UpdateFilterComponent()
	{
		List<VisionEquipGroupData> visionEquipGroupList = ModelBase<VisionEquipGroupModel>.Instance.GetVisionEquipGroupList();
		List<int> list = new List<int>();
		foreach (VisionEquipGroupData visionEquipGroupData in visionEquipGroupList)
		{
			list.Add(visionEquipGroupData.GetIndex());
		}
		this.FilterEntrance.UpdateData(this.UseWayId, list, new object[]
		{
			this.CurrentRoleId
		});
	}

	// Token: 0x06012596 RID: 75158 RVA: 0x0050B728 File Offset: 0x00509928
	private VisionAssembleScrollItem InitAssembleItem()
	{
		return new VisionAssembleScrollItem();
	}

	// Token: 0x06012597 RID: 75159 RVA: 0x0050B72F File Offset: 0x0050992F
	private VisionAssembleAttrScrollItem InitItem()
	{
		return new VisionAssembleAttrScrollItem();
	}

	// Token: 0x06012598 RID: 75160 RVA: 0x0050B738 File Offset: 0x00509938
	private void OnFilterRefresh(List<int> list, bool ifOutSideChange, EFilterSortType type)
	{
		this.CurrentShowingGroupList = list;
		List<VisionEquipGroupData> filterDataList = this.GetFilterDataList();
		if (filterDataList.Count == 0)
		{
			this.CurrentSelectedIndex = -1;
		}
		else
		{
			this.CurrentSelectedIndex = filterDataList[0].GetIndex();
		}
		this.OnChangeSelectIndex(false);
		this.RefreshMiddleEmptyItem();
		this.CancelCompareMode();
	}

	// Token: 0x06012599 RID: 75161 RVA: 0x0050B78A File Offset: 0x0050998A
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0601259A RID: 75162 RVA: 0x0050B794 File Offset: 0x00509994
	protected override void OnBeforeShow()
	{
		this.UpdateFilterComponent();
		this.CurrentSelectedIndex = -1;
		this.RefreshScroller(false, true);
		this.InitCurrentShowingGroupList();
		this.RefreshCurrentSuitInfo();
		this.RefreshCurrentSelectDataInfo();
		this.RefreshAttributeScroller(false, delegate
		{
			GenericScrollViewNew<VisionAssembleAttrScrollItem, VisionAssembleAttrData> attributeLayout = this.AttributeLayout;
			List<VisionAssembleAttrScrollItem> list = (attributeLayout != null) ? attributeLayout.GetScrollItemList() : null;
			if (list != null)
			{
				foreach (VisionAssembleAttrScrollItem visionAssembleAttrScrollItem in list)
				{
					visionAssembleAttrScrollItem.SetRightItemAlpha(0f);
				}
			}
			UUIInturnAnimController attributeTurnAniComponentR = this.AttributeTurnAniComponentR;
			if (attributeTurnAniComponentR == null)
			{
				return;
			}
			attributeTurnAniComponentR.Play("", -1, false);
		});
		this.RefreshSaveText();
		this.RefreshStaticItemSelectState();
		this.RefreshOperationFunctionState();
		this.RefreshFunctionButtonState();
		this.RefreshCompareTopData();
		this.RefreshCompareToggleState();
		this.RefreshMiddleEmptyItem();
		this.TryPlayInfoSequence();
	}

	// Token: 0x0601259B RID: 75163 RVA: 0x0050B80C File Offset: 0x00509A0C
	private void InitCurrentShowingGroupList()
	{
		List<VisionEquipGroupData> visionEquipGroupList = ModelBase<VisionEquipGroupModel>.Instance.GetVisionEquipGroupList();
		int count = visionEquipGroupList.Count;
		this.CurrentShowingGroupList = new List<int>();
		for (int i = 0; i < count; i++)
		{
			VisionEquipGroupData visionEquipGroupData = visionEquipGroupList[i];
			this.CurrentShowingGroupList.Add(visionEquipGroupData.GetIndex());
		}
	}

	// Token: 0x0601259C RID: 75164 RVA: 0x0050B85B File Offset: 0x00509A5B
	private void RefreshCurrentSuitInfo()
	{
		VisionAssembleStaticItem staticItem = this.StaticItem;
		if (staticItem == null)
		{
			return;
		}
		staticItem.Refresh(this.CurrentRoleId);
	}

	// Token: 0x0601259D RID: 75165 RVA: 0x0050B874 File Offset: 0x00509A74
	private List<VisionEquipGroupData> GetFilterDataList()
	{
		List<VisionEquipGroupData> visionEquipGroupList = ModelBase<VisionEquipGroupModel>.Instance.GetVisionEquipGroupList();
		List<VisionEquipGroupData> list = new List<VisionEquipGroupData>();
		int num = (this.CurrentSelectSuitIndex > 0) ? this.FetterSuitFilterArray[this.CurrentSelectSuitIndex] : 0;
		int count = visionEquipGroupList.Count;
		bool filterIfHaveSelect = this.GetFilterIfHaveSelect();
		for (int i = 0; i < count; i++)
		{
			VisionEquipGroupData visionEquipGroupData = visionEquipGroupList[i];
			bool flag = false;
			if (num > 0)
			{
				List<VisionFetterData> visionFetterDataByIncIdList = ModelBase<VisionEquipGroupModel>.Instance.GetVisionFetterDataByIncIdList(new List<int>(visionEquipGroupData.GetVisionUniqueIdList()));
				bool flag2 = false;
				using (List<VisionFetterData>.Enumerator enumerator = visionFetterDataByIncIdList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.FetterGroupId == num)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (flag2)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			bool flag3 = !filterIfHaveSelect;
			if (this.CurrentShowingGroupList.Count > 0)
			{
				flag3 = this.CurrentShowingGroupList.Contains(visionEquipGroupData.GetIndex());
			}
			else if (!filterIfHaveSelect)
			{
				flag3 = true;
			}
			if (flag && flag3)
			{
				list.Add(visionEquipGroupData);
			}
		}
		return list;
	}

	// Token: 0x0601259E RID: 75166 RVA: 0x0050B994 File Offset: 0x00509B94
	private void RefreshScroller(bool keepPosition = false, bool needAnimation = false)
	{
		bool flag = this.GetFilterIfHaveSelect() || this.CurrentSelectSuitIndex > 0;
		List<VisionEquipGroupData> filterDataList = this.GetFilterDataList();
		int count = filterDataList.Count;
		ModelBase<VisionEquipGroupModel>.Instance.FilterDataLength = count;
		int num = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomEquipGroupCountMax();
		List<VisionAssembleScrollItemData> list = new List<VisionAssembleScrollItemData>();
		num = (flag ? filterDataList.Count : num);
		for (int i = 0; i < num; i++)
		{
			VisionAssembleScrollItemData visionAssembleScrollItemData = new VisionAssembleScrollItemData();
			VisionEquipGroupData visionEquipGroupData = (i < count) ? filterDataList[i] : null;
			visionAssembleScrollItemData.GroupIndex = i;
			visionAssembleScrollItemData.ClickCallback = new Action<VisionEquipGroupData>(this.OnClickScrollItem);
			VisionAssembleScrollItemData visionAssembleScrollItemData2 = visionAssembleScrollItemData;
			int? num2 = (visionEquipGroupData != null) ? new int?(visionEquipGroupData.GetIndex()) : null;
			int currentSelectedIndex = this.CurrentSelectedIndex;
			visionAssembleScrollItemData2.CurrentSelectState = (num2.GetValueOrDefault() == currentSelectedIndex & num2 != null);
			visionAssembleScrollItemData.VisionEquipGroupData = visionEquipGroupData;
			visionAssembleScrollItemData.CheckIfCanSelect = new Func<bool>(this.CheckIfCanSelect);
			list.Add(visionAssembleScrollItemData);
		}
		this.ShowList = list;
		LoopScrollView<VisionAssembleScrollItem, VisionAssembleScrollItemData> assembleListLayout = this.AssembleListLayout;
		if (assembleListLayout == null)
		{
			return;
		}
		assembleListLayout.RefreshByData(list, keepPosition, delegate
		{
			if (!keepPosition)
			{
				this.AssembleScrollToSelectIndex(needAnimation);
				return;
			}
			if (needAnimation)
			{
				LoopScrollView<VisionAssembleScrollItem, VisionAssembleScrollItemData> assembleListLayout2 = this.AssembleListLayout;
				if (assembleListLayout2 == null)
				{
					return;
				}
				UUIInturnAnimController uiAnimController = assembleListLayout2.GetUiAnimController();
				if (uiAnimController == null)
				{
					return;
				}
				uiAnimController.Play("", -1, false);
			}
		}, false);
	}

	// Token: 0x0601259F RID: 75167 RVA: 0x0050BAE4 File Offset: 0x00509CE4
	private bool CheckIfCanSelect()
	{
		return true;
	}

	// Token: 0x060125A0 RID: 75168 RVA: 0x0050BAE7 File Offset: 0x00509CE7
	private void RefreshStaticItemSelectState()
	{
		VisionAssembleStaticItem staticItem = this.StaticItem;
		if (staticItem == null)
		{
			return;
		}
		staticItem.RefreshSelectState(this.CurrentSelectedIndex == -1, this.CompareMode);
	}

	// Token: 0x060125A1 RID: 75169 RVA: 0x0050BB08 File Offset: 0x00509D08
	private void OnClickScrollItem(VisionEquipGroupData data)
	{
		int index = data.GetIndex();
		if (index == this.CurrentSelectedIndex)
		{
			this.CurrentSelectedIndex = 999;
			this.CompareMode = false;
		}
		else
		{
			this.CurrentSelectedIndex = index;
		}
		this.OnChangeSelectIndex(true);
		this.RefreshCompareToggleState();
		this.RefreshCurrentSelectDataInfo();
	}

	// Token: 0x060125A2 RID: 75170 RVA: 0x0050BB53 File Offset: 0x00509D53
	private void OnChangeSelectIndex(bool keepPosition = true)
	{
		this.RefreshScroller(keepPosition, false);
		this.RefreshStaticItemSelectState();
		this.RefreshCompareTopData();
		this.RefreshOperationFunctionState();
		this.RefreshFunctionButtonState();
		this.RefreshCompareToggleState();
		this.RefreshAttributeScroller(false, delegate
		{
			GenericScrollViewNew<VisionAssembleAttrScrollItem, VisionAssembleAttrData> attributeLayout = this.AttributeLayout;
			List<VisionAssembleAttrScrollItem> list = (attributeLayout != null) ? attributeLayout.GetScrollItemList() : null;
			if (list != null)
			{
				foreach (VisionAssembleAttrScrollItem visionAssembleAttrScrollItem in list)
				{
					visionAssembleAttrScrollItem.SetRightItemAlpha(0f);
				}
			}
			UUIInturnAnimController attributeTurnAniComponentR = this.AttributeTurnAniComponentR;
			if (attributeTurnAniComponentR == null)
			{
				return;
			}
			attributeTurnAniComponentR.Play("", -1, false);
		});
	}

	// Token: 0x060125A3 RID: 75171 RVA: 0x0050BB90 File Offset: 0x00509D90
	private void RefreshOperationFunctionState()
	{
		VisionAssembleView.EOperation currentOperationState = this.GetCurrentOperationState();
		this.RefreshUseButtonByOperationState(currentOperationState);
	}

	// Token: 0x060125A4 RID: 75172 RVA: 0x0050BBAC File Offset: 0x00509DAC
	private void RefreshUseButtonByOperationState(VisionAssembleView.EOperation state)
	{
		bool flag = state == VisionAssembleView.EOperation.Use || state == VisionAssembleView.EOperation.Save || state == VisionAssembleView.EOperation.HasUsing;
		this.ConfirmButtonItem.SetActive(flag);
		if (flag)
		{
			string showText;
			if (state == VisionAssembleView.EOperation.Use)
			{
				showText = "VisionAssembleUse";
			}
			else if (state == VisionAssembleView.EOperation.HasUsing)
			{
				showText = "VisionAssembleUse";
			}
			else
			{
				showText = "VisionAssembleSave";
			}
			ButtonItem confirmButtonItem = this.ConfirmButtonItem;
			if (confirmButtonItem == null)
			{
				return;
			}
			confirmButtonItem.SetShowText(showText);
		}
	}

	// Token: 0x060125A5 RID: 75173 RVA: 0x0050BC10 File Offset: 0x00509E10
	private VisionAssembleView.EOperation GetCurrentOperationState()
	{
		if (this.CurrentSelectedIndex == 999)
		{
			return VisionAssembleView.EOperation.Empty;
		}
		if (this.CurrentSelectedIndex == -1)
		{
			return VisionAssembleView.EOperation.Save;
		}
		int[] visionUniqueIdList = ModelBase<VisionEquipGroupModel>.Instance.GetVisionEquipGroupDataByIndex(this.CurrentSelectedIndex).GetVisionUniqueIdList();
		List<int> incrIdList = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.CurrentRoleId).GetPhantomData().GetIncrIdList();
		bool flag = true;
		int[] array = visionUniqueIdList;
		List<int> list = incrIdList;
		int num = (array.Length < list.Count) ? array.Length : list.Count;
		for (int i = 0; i < num; i++)
		{
			if (array[i] != list[i])
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			return VisionAssembleView.EOperation.HasUsing;
		}
		return VisionAssembleView.EOperation.Use;
	}

	// Token: 0x060125A6 RID: 75174 RVA: 0x0050BCB0 File Offset: 0x00509EB0
	private void RefreshFunctionButtonState()
	{
		bool state = !this.CompareMode && this.CurrentSelectedIndex != -1 && this.CurrentSelectedIndex != 999;
		this.RefreshDeleteButtonState(state);
		this.RefreshTopButtonState(state);
	}

	// Token: 0x060125A7 RID: 75175 RVA: 0x0050BCF0 File Offset: 0x00509EF0
	private void RefreshDeleteButtonState(bool state)
	{
		base.GetButton(12).RootUIComp.Get().SetUIActive(state);
	}

	// Token: 0x060125A8 RID: 75176 RVA: 0x0050BD18 File Offset: 0x00509F18
	private void RefreshTopButtonState(bool state)
	{
		base.GetButton(11).RootUIComp.Get().SetUIActive(state);
	}

	// Token: 0x060125A9 RID: 75177 RVA: 0x0050BD40 File Offset: 0x00509F40
	private void RefreshCurrentSelectDataInfo()
	{
		bool compareMode = this.CompareMode;
		VisionAssembleTopItem currentTopItem = this.CurrentTopItem;
		if (currentTopItem != null)
		{
			currentTopItem.SetActive(compareMode);
		}
		if (compareMode)
		{
			VisionAssembleTopItem currentTopItem2 = this.CurrentTopItem;
			if (currentTopItem2 == null)
			{
				return;
			}
			currentTopItem2.Refresh(this.GetCurrentTopData());
		}
	}

	// Token: 0x060125AA RID: 75178 RVA: 0x0050BD80 File Offset: 0x00509F80
	[NullableContext(2)]
	private FilterResultData GetFilterData()
	{
		int uniqueIdByGroupId = this.FilterEntrance.GetUniqueIdByGroupId(this.UseWayId);
		return ModelBase<FilterModel>.Instance.GetFilterResultData(uniqueIdByGroupId);
	}

	// Token: 0x060125AB RID: 75179 RVA: 0x0050BDAC File Offset: 0x00509FAC
	private bool GetFilterIfHaveSelect()
	{
		FilterResultData filterData = this.GetFilterData();
		if (filterData != null)
		{
			using (Dictionary<FilterDefine.EFilterType, Dictionary<int, string>>.ValueCollection.Enumerator enumerator = filterData.GetSelectRuleData().Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Count > 0)
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x060125AC RID: 75180 RVA: 0x0050BE18 File Offset: 0x0050A018
	private void RefreshMiddleEmptyItem()
	{
		bool uiactive = (this.GetFilterIfHaveSelect() && this.GetFilterDataList().Count == 0) || (this.CurrentSelectSuitIndex > 0 && this.GetFilterDataList().Count == 0);
		base.GetItem(18).SetUIActive(uiactive);
	}

	// Token: 0x060125AD RID: 75181 RVA: 0x0050BE68 File Offset: 0x0050A068
	[NullableContext(2)]
	private void RefreshAttributeScroller(bool needAnimation = false, Action finishCall = null)
	{
		if (this.CurrentSelectedIndex == 999)
		{
			base.GetScrollViewWithScrollbar(10).RootUIComp.Get().SetUIActive(false);
			base.GetItem(14).SetUIActive(true);
			return;
		}
		bool compareIncIdListIfEmpty = this.GetCompareIncIdListIfEmpty();
		base.GetScrollViewWithScrollbar(10).RootUIComp.Get().SetUIActive(!compareIncIdListIfEmpty);
		base.GetItem(14).SetUIActive(compareIncIdListIfEmpty);
		List<VisionAssembleAttrData> dataList = ModelBase<VisionEquipGroupModel>.Instance.GetVisionAssembleViewAttrData(this.CurrentSelectedIndex, this.CompareMode, this.CurrentRoleId);
		GenericScrollViewNew<VisionAssembleAttrScrollItem, VisionAssembleAttrData> attributeLayout = this.AttributeLayout;
		if (attributeLayout == null)
		{
			return;
		}
		attributeLayout.RefreshByData(dataList, delegate
		{
			if (dataList.Count > 0)
			{
				GenericScrollViewNew<VisionAssembleAttrScrollItem, VisionAssembleAttrData> attributeLayout2 = this.AttributeLayout;
				if (attributeLayout2 != null)
				{
					attributeLayout2.ScrollToTop(0);
				}
			}
			Action finishCall2 = finishCall;
			if (finishCall2 != null)
			{
				finishCall2();
			}
			if (needAnimation)
			{
				GenericScrollViewNew<VisionAssembleAttrScrollItem, VisionAssembleAttrData> attributeLayout3 = this.AttributeLayout;
				List<VisionAssembleAttrScrollItem> list = (attributeLayout3 != null) ? attributeLayout3.GetScrollItemList() : null;
				if (list != null)
				{
					foreach (VisionAssembleAttrScrollItem visionAssembleAttrScrollItem in list)
					{
						visionAssembleAttrScrollItem.SetLeftItemAlpha(0f);
					}
				}
				UUIInturnAnimController attributeTurnAniComponentL = this.AttributeTurnAniComponentL;
				if (attributeTurnAniComponentL == null)
				{
					return;
				}
				attributeTurnAniComponentL.Play("", -1, false);
			}
		}, false);
	}

	// Token: 0x060125AE RID: 75182 RVA: 0x0050BF40 File Offset: 0x0050A140
	private void RefreshSaveText()
	{
		int count = ModelBase<VisionEquipGroupModel>.Instance.GetVisionEquipGroupList().Count;
		int phantomEquipGroupCountMax = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomEquipGroupCountMax();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "VisionAssembleHasSave", new <>z__ReadOnlyArray<object>(new object[]
		{
			count,
			phantomEquipGroupCountMax
		}));
	}

	// Token: 0x060125AF RID: 75183 RVA: 0x0050BF9C File Offset: 0x0050A19C
	private void TryPlayInfoSequence()
	{
		if (true)
		{
			base.PlaySequence("Start_InfR", null, true);
			UUIInturnAnimController attributeTurnAniComponentR = this.AttributeTurnAniComponentR;
			if (attributeTurnAniComponentR != null)
			{
				attributeTurnAniComponentR.OnFinish.Bind(delegate()
				{
					UUIInturnAnimController attributeTurnAniComponentR3 = this.AttributeTurnAniComponentR;
					if (attributeTurnAniComponentR3 == null)
					{
						return;
					}
					attributeTurnAniComponentR3.SetItemDefaultAlphaZero(false);
				});
			}
			UUIInturnAnimController attributeTurnAniComponentR2 = this.AttributeTurnAniComponentR;
			if (attributeTurnAniComponentR2 == null)
			{
				return;
			}
			attributeTurnAniComponentR2.Play("Start_R", -1, false);
		}
	}

	// Token: 0x060125B0 RID: 75184 RVA: 0x0050BFF4 File Offset: 0x0050A1F4
	private void RefreshCompareTopData()
	{
		VisionAssembleTopItem compareTopItem = this.CompareTopItem;
		bool? flag = (compareTopItem != null) ? new bool?(compareTopItem.GetActive()) : null;
		bool showState = true;
		VisionAssembleTopItem compareTopItem2 = this.CompareTopItem;
		if (compareTopItem2 != null)
		{
			compareTopItem2.Refresh(this.GetCompareTopData());
		}
		bool? flag2 = flag;
		bool showState2 = showState;
		if (!(flag2.GetValueOrDefault() == showState2 & flag2 != null))
		{
			if (showState)
			{
				VisionAssembleTopItem compareTopItem3 = this.CompareTopItem;
				if (compareTopItem3 != null)
				{
					compareTopItem3.SetActive(showState);
				}
				this.RefreshAttributeScroller(false, null);
				base.PlaySequence("Start_InfR", null, true);
				return;
			}
			base.PlaySequence("Close_InfR", delegate
			{
				VisionAssembleTopItem compareTopItem4 = this.CompareTopItem;
				if (compareTopItem4 != null)
				{
					compareTopItem4.SetActive(showState);
				}
				this.RefreshAttributeScroller(false, null);
			}, true);
		}
	}

	// Token: 0x060125B1 RID: 75185 RVA: 0x0050C0B4 File Offset: 0x0050A2B4
	private void RefreshCompareToggleState()
	{
		bool uiactive = this.CurrentSelectedIndex != 999 && this.CurrentSelectedIndex != -1;
		UUIExtendToggle extendToggle = base.GetExtendToggle(13);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x060125B2 RID: 75186 RVA: 0x0050C100 File Offset: 0x0050A300
	private bool GetCompareIncIdListIfEmpty()
	{
		if (this.CurrentSelectedIndex == 999)
		{
			return true;
		}
		if (this.CurrentSelectedIndex == -1)
		{
			using (List<int>.Enumerator enumerator = ModelBase<RoleModel>.Instance.GetRoleDataById(this.CurrentRoleId, true).GetPhantomData().GetIncrIdList().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current != 0)
					{
						return false;
					}
				}
				return true;
			}
		}
		int[] visionUniqueIdList = ModelBase<VisionEquipGroupModel>.Instance.GetVisionEquipGroupDataByIndex(this.CurrentSelectedIndex).GetVisionUniqueIdList();
		for (int i = 0; i < visionUniqueIdList.Length; i++)
		{
			if (visionUniqueIdList[i] != 0)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060125B3 RID: 75187 RVA: 0x0050C1AC File Offset: 0x0050A3AC
	[NullableContext(2)]
	private VisionAssembleTopData GetCompareTopData()
	{
		if (this.CurrentSelectedIndex == 999)
		{
			return null;
		}
		List<int> list = new List<int>();
		VisionAssembleTopData visionAssembleTopData = new VisionAssembleTopData();
		if (this.CurrentSelectedIndex == -1)
		{
			visionAssembleTopData.Name = ConfigMultiTextLang.GetLocalTextNew("VisionAssembleCurrentEquip", null);
			list = new List<int>(ModelBase<RoleModel>.Instance.GetRoleDataById(this.CurrentRoleId, true).GetPhantomData().GetIncrIdList());
		}
		else
		{
			VisionEquipGroupData visionEquipGroupDataByIndex = ModelBase<VisionEquipGroupModel>.Instance.GetVisionEquipGroupDataByIndex(this.CurrentSelectedIndex);
			visionAssembleTopData.Name = visionEquipGroupDataByIndex.GetName();
			list = new List<int>(visionEquipGroupDataByIndex.GetVisionUniqueIdList());
		}
		visionAssembleTopData.Index = ((this.CurrentSelectedIndex == -1) ? -1 : this.CurrentSelectedIndex);
		int num = 0;
		List<VisionFetterData> list2 = this.FilterSameFetterData(ModelBase<VisionEquipGroupModel>.Instance.GetVisionFetterDataByIncIdList(list));
		foreach (int uniqueId in list)
		{
			PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(uniqueId);
			if (phantomDataBase != null)
			{
				num += phantomDataBase.GetCost();
			}
		}
		visionAssembleTopData.Cost = num;
		List<VisionAssembleSuitItemData> list3 = new List<VisionAssembleSuitItemData>();
		foreach (VisionFetterData data in list2)
		{
			VisionAssembleSuitItemData visionAssembleSuitItemData = new VisionAssembleSuitItemData();
			visionAssembleSuitItemData.Phrase(data);
			list3.Add(visionAssembleSuitItemData);
		}
		visionAssembleTopData.SuitList = list3;
		return visionAssembleTopData;
	}

	// Token: 0x060125B4 RID: 75188 RVA: 0x0050C32C File Offset: 0x0050A52C
	private VisionAssembleTopData GetCurrentTopData()
	{
		VisionAssembleTopData visionAssembleTopData = new VisionAssembleTopData();
		visionAssembleTopData.Name = ConfigMultiTextLang.GetLocalTextNew("VisionAssembleCurrentEquip", null);
		visionAssembleTopData.Index = -1;
		int num = 0;
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(this.CurrentRoleId, true);
		foreach (KeyValuePair<int, PhantomDataBase> keyValuePair in roleDataById.GetPhantomData().GetDataMap())
		{
			PhantomDataBase value = keyValuePair.Value;
			if (value != null)
			{
				num += value.GetCost();
			}
		}
		visionAssembleTopData.Cost = num;
		List<int> incrIdList = roleDataById.GetPhantomData().GetIncrIdList();
		List<VisionFetterData> list = this.FilterSameFetterData(ModelBase<VisionEquipGroupModel>.Instance.GetVisionFetterDataByIncIdList(new List<int>(incrIdList)));
		List<VisionAssembleSuitItemData> list2 = new List<VisionAssembleSuitItemData>();
		foreach (VisionFetterData data in list)
		{
			VisionAssembleSuitItemData visionAssembleSuitItemData = new VisionAssembleSuitItemData();
			visionAssembleSuitItemData.Phrase(data);
			list2.Add(visionAssembleSuitItemData);
		}
		visionAssembleTopData.SuitList = list2;
		return visionAssembleTopData;
	}

	// Token: 0x060125B5 RID: 75189 RVA: 0x0050C454 File Offset: 0x0050A654
	private List<VisionFetterData> FilterSameFetterData(List<VisionFetterData> dataList)
	{
		List<VisionFetterData> list = new List<VisionFetterData>();
		Dictionary<int, VisionFetterData> dictionary = new Dictionary<int, VisionFetterData>();
		foreach (VisionFetterData visionFetterData in dataList)
		{
			dictionary[visionFetterData.FetterGroupId] = visionFetterData;
		}
		foreach (VisionFetterData item in dictionary.Values)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x04008F08 RID: 36616
	private const int EMPTYSELECTINDEX = 999;

	// Token: 0x04008F09 RID: 36617
	private const int STATICINDEX = -1;

	// Token: 0x04008F0A RID: 36618
	private readonly EFilterSortGroupId UseWayId = EFilterSortGroupId.VisionAssemble;

	// Token: 0x04008F0B RID: 36619
	private List<int> CurrentShowingGroupList = new List<int>();

	// Token: 0x04008F0C RID: 36620
	private int CurrentRoleId;

	// Token: 0x04008F0D RID: 36621
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04008F0E RID: 36622
	[Nullable(2)]
	private VisionAssembleStaticItem StaticItem;

	// Token: 0x04008F0F RID: 36623
	[Nullable(2)]
	private VisionAssembleTopItem CompareTopItem;

	// Token: 0x04008F10 RID: 36624
	[Nullable(2)]
	private VisionAssembleTopItem CurrentTopItem;

	// Token: 0x04008F11 RID: 36625
	[Nullable(2)]
	private FilterEntrance<int> FilterEntrance;

	// Token: 0x04008F12 RID: 36626
	private readonly List<int> FetterSuitFilterArray = new List<int>();

	// Token: 0x04008F13 RID: 36627
	private int CurrentSelectSuitIndex;

	// Token: 0x04008F14 RID: 36628
	[Nullable(2)]
	private CommonDropDown<int, int> CommonDropDown;

	// Token: 0x04008F15 RID: 36629
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<VisionAssembleAttrScrollItem, VisionAssembleAttrData> AttributeLayout;

	// Token: 0x04008F16 RID: 36630
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<VisionAssembleScrollItem, VisionAssembleScrollItemData> AssembleListLayout;

	// Token: 0x04008F17 RID: 36631
	[Nullable(2)]
	private ButtonItem ConfirmButtonItem;

	// Token: 0x04008F18 RID: 36632
	private int CurrentSelectedIndex = 999;

	// Token: 0x04008F19 RID: 36633
	private bool CompareMode;

	// Token: 0x04008F1A RID: 36634
	[Nullable(2)]
	private UUIInturnAnimController AttributeTurnAniComponentR;

	// Token: 0x04008F1B RID: 36635
	[Nullable(2)]
	private UUIInturnAnimController AttributeTurnAniComponentL;

	// Token: 0x04008F1C RID: 36636
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<VisionAssembleScrollItemData> ShowList;

	// Token: 0x020087FA RID: 34810
	[NullableContext(0)]
	private enum EOperation
	{
		// Token: 0x0402DF04 RID: 188164
		Empty,
		// Token: 0x0402DF05 RID: 188165
		Save,
		// Token: 0x0402DF06 RID: 188166
		Use,
		// Token: 0x0402DF07 RID: 188167
		HasUsing
	}

	// Token: 0x020087FB RID: 34811
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DF09 RID: 188169
		CaptionItem,
		// Token: 0x0402DF0A RID: 188170
		CurrentSuitItem,
		// Token: 0x0402DF0B RID: 188171
		SuitScroller,
		// Token: 0x0402DF0C RID: 188172
		SuitItem,
		// Token: 0x0402DF0D RID: 188173
		LeftDownItem,
		// Token: 0x0402DF0E RID: 188174
		FilterItem,
		// Token: 0x0402DF0F RID: 188175
		SuitFilterItem,
		// Token: 0x0402DF10 RID: 188176
		CurrentSaveText,
		// Token: 0x0402DF11 RID: 188177
		CurrentInfoItem,
		// Token: 0x0402DF12 RID: 188178
		CompareInfoItem,
		// Token: 0x0402DF13 RID: 188179
		AttributeScroller,
		// Token: 0x0402DF14 RID: 188180
		ToTopBtn,
		// Token: 0x0402DF15 RID: 188181
		DeleteBtn,
		// Token: 0x0402DF16 RID: 188182
		CompareToggle,
		// Token: 0x0402DF17 RID: 188183
		EmptyItem,
		// Token: 0x0402DF18 RID: 188184
		ConfirmButtonItem,
		// Token: 0x0402DF19 RID: 188185
		TextureMaskItem,
		// Token: 0x0402DF1A RID: 188186
		CompareMask,
		// Token: 0x0402DF1B RID: 188187
		MiddleEmptyItem,
		// Token: 0x0402DF1C RID: 188188
		TurnAnimationItem
	}
}
