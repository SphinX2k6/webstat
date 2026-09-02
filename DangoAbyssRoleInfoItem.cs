using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Dango;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B02 RID: 6914
[NullableContext(2)]
[Nullable(0)]
public class DangoAbyssRoleInfoItem : UiPanelBase
{
	// Token: 0x0600C713 RID: 50963 RVA: 0x0034A95C File Offset: 0x00348B5C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnPluginToggleClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnAttributeToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C714 RID: 50964 RVA: 0x0034AB2F File Offset: 0x00348D2F
	private void OnDataUpdate(EPluginEquipViewData key)
	{
		switch (key)
		{
		case EPluginEquipViewData.DangoId:
			this.OnDangoIdUpdate();
			break;
		case EPluginEquipViewData.SlotIndex:
		case EPluginEquipViewData.PluginItem:
			break;
		default:
			return;
		}
	}

	// Token: 0x0600C715 RID: 50965 RVA: 0x0034AB4A File Offset: 0x00348D4A
	protected override void OnAfterDestroy()
	{
		this.ViewModel.UnBind(new TCallback<EPluginEquipViewData>(this.OnDataUpdate));
	}

	// Token: 0x0600C716 RID: 50966 RVA: 0x0034AB64 File Offset: 0x00348D64
	protected override UniTask OnBeforeStartAsync()
	{
		DangoAbyssRoleInfoItem.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssRoleInfoItem.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C717 RID: 50967 RVA: 0x0034ABA7 File Offset: 0x00348DA7
	protected override void OnBeforeShow()
	{
		this.ViewModel.Bind(new TCallback<EPluginEquipViewData>(this.OnDataUpdate));
		this.RefreshView();
	}

	// Token: 0x0600C718 RID: 50968 RVA: 0x0034ABC6 File Offset: 0x00348DC6
	private void OnAttributeToggleClick(EToggleState toggleState)
	{
		this.CurrentViewType = EViewType.Attribute;
		this.RefreshView();
	}

	// Token: 0x0600C719 RID: 50969 RVA: 0x0034ABD5 File Offset: 0x00348DD5
	private void OnPluginToggleClick(EToggleState toggleState)
	{
		this.CurrentViewType = EViewType.Plugin;
		this.RefreshView();
	}

	// Token: 0x0600C71A RID: 50970 RVA: 0x0034ABE4 File Offset: 0x00348DE4
	private void RefreshToggleStateByCurrentViewType()
	{
		EToggleState state = (this.CurrentViewType == EViewType.Plugin) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(1).SetToggleState(state, false, false, false);
		EToggleState state2 = (this.CurrentViewType == EViewType.Attribute) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(2).SetToggleState(state2, false, false, false);
	}

	// Token: 0x0600C71B RID: 50971 RVA: 0x0034AC33 File Offset: 0x00348E33
	public void OnDangoInfoUpdate()
	{
		this.RefreshView();
	}

	// Token: 0x0600C71C RID: 50972 RVA: 0x0034AC3B File Offset: 0x00348E3B
	private void OnDangoIdUpdate()
	{
		if (this.ViewModel.GetDangoId() == 0)
		{
			return;
		}
		this.RefreshView();
	}

	// Token: 0x0600C71D RID: 50973 RVA: 0x0034AC54 File Offset: 0x00348E54
	public void RefreshView()
	{
		int dangoId = this.ViewModel.GetDangoId();
		AbyssDangoRoleData dangoAbyssRoleData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(dangoId);
		this.RefreshName(dangoAbyssRoleData);
		this.RefreshEquipItem(dangoAbyssRoleData);
		this.RefreshInActiveRedItem(dangoAbyssRoleData);
		this.RefreshLevelUpItem(dangoAbyssRoleData);
		this.RefreshToggleStateByCurrentViewType();
		this.RefreshViewByViewType();
	}

	// Token: 0x0600C71E RID: 50974 RVA: 0x0034ACA4 File Offset: 0x00348EA4
	private void RefreshName(AbyssDangoRoleData data)
	{
		if (data == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.GetName(), Array.Empty<object>());
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(9), "Text_DangoLevel_Text", new <>z__ReadOnlyArray<object>(new object[]
		{
			data.GetLevel().ToString(),
			data.GetMaxLevel().ToString()
		}));
		base.GetText(9).SetUIActive(!data.GetIfLock());
	}

	// Token: 0x0600C71F RID: 50975 RVA: 0x0034AD2C File Offset: 0x00348F2C
	private void RefreshViewByViewType()
	{
		EViewType currentViewType = this.CurrentViewType;
		if (currentViewType == EViewType.Plugin)
		{
			this.RefreshPluginView();
			return;
		}
		if (currentViewType != EViewType.Attribute)
		{
			return;
		}
		this.RefreshAttributeView();
	}

	// Token: 0x0600C720 RID: 50976 RVA: 0x0034AD55 File Offset: 0x00348F55
	private void RefreshPluginView()
	{
		base.GetItem(4).SetUIActive(true);
		base.GetItem(3).SetUIActive(false);
		this.PluginPanelInstance.Refresh();
	}

	// Token: 0x0600C721 RID: 50977 RVA: 0x0034AD7C File Offset: 0x00348F7C
	private void RefreshAttributeView()
	{
		base.GetItem(4).SetUIActive(false);
		base.GetItem(3).SetUIActive(true);
		this.AttributePanelInstance.Refresh();
	}

	// Token: 0x0600C722 RID: 50978 RVA: 0x0034ADA4 File Offset: 0x00348FA4
	private void RefreshEquipItem(AbyssDangoRoleData data)
	{
		if (data == null)
		{
			ButtonItem equipItem = this.EquipItem;
			if (equipItem == null)
			{
				return;
			}
			equipItem.SetActive(false);
			return;
		}
		else
		{
			bool ifLock = data.GetIfLock();
			this.EquipItem.SetActive(!ifLock);
			ButtonItem equipItem2 = this.EquipItem;
			if (equipItem2 == null)
			{
				return;
			}
			equipItem2.SetRedDotVisible(false);
			return;
		}
	}

	// Token: 0x0600C723 RID: 50979 RVA: 0x0034ADF0 File Offset: 0x00348FF0
	private void RefreshInActiveRedItem(AbyssDangoRoleData data)
	{
		if (data == null)
		{
			InActiveRedItem inActiveRedItem = this.InActiveRedItem;
			if (inActiveRedItem == null)
			{
				return;
			}
			inActiveRedItem.SetActive(false);
			return;
		}
		else
		{
			AbyssLittleRole value = data.GetConfig().Value;
			bool ifLock = data.GetIfLock();
			InActiveRedItem inActiveRedItem2 = this.InActiveRedItem;
			if (inActiveRedItem2 != null)
			{
				inActiveRedItem2.SetActive(ifLock);
			}
			InActiveRedItem inActiveRedItem3 = this.InActiveRedItem;
			if (inActiveRedItem3 != null)
			{
				inActiveRedItem3.SetDetailButtonVisible(false);
			}
			InActiveRedItem inActiveRedItem4 = this.InActiveRedItem;
			if (inActiveRedItem4 == null)
			{
				return;
			}
			inActiveRedItem4.SetText(value.UnlockDesc, Array.Empty<object>());
			return;
		}
	}

	// Token: 0x0600C724 RID: 50980 RVA: 0x0034AE68 File Offset: 0x00349068
	private void RefreshLevelUpItem(AbyssDangoRoleData data)
	{
		if (data == null)
		{
			ButtonItem levelUpItem = this.LevelUpItem;
			if (levelUpItem == null)
			{
				return;
			}
			levelUpItem.SetActive(false);
			return;
		}
		else
		{
			bool ifCanLevelUp = data.GetIfCanLevelUp();
			bool ifLock = data.GetIfLock();
			ButtonItem levelUpItem2 = this.LevelUpItem;
			if (levelUpItem2 != null)
			{
				levelUpItem2.SetActive(!ifLock);
			}
			bool dangoLevelUpRedDotById = ModelBase<DangoAbyssModel>.Instance.GetDangoLevelUpRedDotById(data.GetId(), new bool?(false));
			ButtonItem levelUpItem3 = this.LevelUpItem;
			if (levelUpItem3 == null)
			{
				return;
			}
			levelUpItem3.SetRedDotVisible(ifCanLevelUp && dangoLevelUpRedDotById);
			return;
		}
	}

	// Token: 0x0600C725 RID: 50981 RVA: 0x0034AED8 File Offset: 0x003490D8
	private void OnClickLevelUp(int _)
	{
		int dangoId = this.ViewModel.GetDangoId();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssLevelUpView, dangoId, null);
	}

	// Token: 0x0600C726 RID: 50982 RVA: 0x0034AF07 File Offset: 0x00349107
	private void OnClickEquip(int _)
	{
		this.ViewModel.SetSlotIndex(1, false);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssPluginEquipView, this.ViewModel, null);
	}

	// Token: 0x04005F5F RID: 24415
	private EViewType CurrentViewType;

	// Token: 0x04005F60 RID: 24416
	public PluginEquipViewModel ViewModel;

	// Token: 0x04005F61 RID: 24417
	private AttributePanel AttributePanelInstance;

	// Token: 0x04005F62 RID: 24418
	private AttributePanel.DangoRolePluginPanel PluginPanelInstance;

	// Token: 0x04005F63 RID: 24419
	private ButtonItem LevelUpItem;

	// Token: 0x04005F64 RID: 24420
	private ButtonItem EquipItem;

	// Token: 0x04005F65 RID: 24421
	private InActiveRedItem InActiveRedItem;

	// Token: 0x02007DD8 RID: 32216
	[NullableContext(0)]
	private class EInfoPanelComponent
	{
		// Token: 0x0402ADDC RID: 175580
		public const int NameText = 0;

		// Token: 0x0402ADDD RID: 175581
		public const int PluginToggle = 1;

		// Token: 0x0402ADDE RID: 175582
		public const int AttributeToggle = 2;

		// Token: 0x0402ADDF RID: 175583
		public const int AttributePanel = 3;

		// Token: 0x0402ADE0 RID: 175584
		public const int PluginPanel = 4;

		// Token: 0x0402ADE1 RID: 175585
		public const int CostItem = 5;

		// Token: 0x0402ADE2 RID: 175586
		public const int EquipItem = 6;

		// Token: 0x0402ADE3 RID: 175587
		public const int InActiveRedItem = 7;

		// Token: 0x0402ADE4 RID: 175588
		public const int LevelUpItem = 8;

		// Token: 0x0402ADE5 RID: 175589
		public const int LevelText = 9;
	}
}
