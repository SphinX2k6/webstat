using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023E3 RID: 9187
[NullableContext(1)]
[Nullable(0)]
public class PayShopRecommendSwitchItem : CommonTabItemBase, ITabViewRegister
{
	// Token: 0x06011C62 RID: 72802 RVA: 0x004E3760 File Offset: 0x004E1960
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnExtendToggleToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011C63 RID: 72803 RVA: 0x004E3848 File Offset: 0x004E1A48
	public override void Refresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		this.OnRefresh(data, isSelected, gridIndex);
		this.GetTabToggle().RootUIComp.Get().SetUIActive(false);
		this.GetTabToggle().RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x06011C64 RID: 72804 RVA: 0x004E3897 File Offset: 0x004E1A97
	protected override void OnStart()
	{
		base.OnStart();
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06011C65 RID: 72805 RVA: 0x004E38B0 File Offset: 0x004E1AB0
	protected override void OnBeforeHide()
	{
		this.UnBindRedDot();
	}

	// Token: 0x06011C66 RID: 72806 RVA: 0x004E38B8 File Offset: 0x004E1AB8
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}

	// Token: 0x06011C67 RID: 72807 RVA: 0x004E38C6 File Offset: 0x004E1AC6
	private void OnExtendToggleToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SelectedCallBack(base.GridIndex);
		}
	}

	// Token: 0x06011C68 RID: 72808 RVA: 0x004E38DF File Offset: 0x004E1ADF
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(1).SetToggleStateForce(state, bFire, false, false);
	}

	// Token: 0x06011C69 RID: 72809 RVA: 0x004E38F1 File Offset: 0x004E1AF1
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		if (data.Data != null)
		{
			base.UpdateTabIcon(data.Data.GetIcon());
		}
	}

	// Token: 0x06011C6A RID: 72810 RVA: 0x004E390C File Offset: 0x004E1B0C
	protected override void OnUpdateTabIcon(string iconPath)
	{
	}

	// Token: 0x06011C6B RID: 72811 RVA: 0x004E390E File Offset: 0x004E1B0E
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(1);
	}

	// Token: 0x06011C6C RID: 72812 RVA: 0x004E3918 File Offset: 0x004E1B18
	public void UpdateView(PayShopDefine.EPayShopTabType payShopId, int tabId)
	{
		PayShopTabData payShopTabDataByPayShopIdAndTabId = ModelBase<PayShopModel>.Instance.GetPayShopTabDataByPayShopIdAndTabId(payShopId, tabId);
		base.GetText(0).SetText((payShopTabDataByPayShopIdAndTabId != null) ? payShopTabDataByPayShopIdAndTabId.Name : "", true);
		this.RootItem.SetUIActive(payShopTabDataByPayShopIdAndTabId != null && payShopTabDataByPayShopIdAndTabId.Enable);
	}

	// Token: 0x06011C6D RID: 72813 RVA: 0x004E3966 File Offset: 0x004E1B66
	public void UpdateTitle(string title)
	{
		base.GetText(0).SetText(title, true);
	}

	// Token: 0x06011C6E RID: 72814 RVA: 0x004E3978 File Offset: 0x004E1B78
	public void UpdateTabImage(string tabImage)
	{
		base.SetTextureByPath(tabImage, base.GetTexture(3), null, null);
	}

	// Token: 0x06011C6F RID: 72815 RVA: 0x004E39A0 File Offset: 0x004E1BA0
	public void BindRedDot(ERedDotName redDotName, int tabId = 0)
	{
		this.UnBindRedDot();
		UUIItem item = base.GetItem(2);
		this.RedDotName = new ERedDotName?(redDotName);
		this.TabId = tabId;
		ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, tabId);
	}

	// Token: 0x06011C70 RID: 72816 RVA: 0x004E39DC File Offset: 0x004E1BDC
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(2), this.TabId);
			this.RedDotName = null;
			this.TabId = 0;
		}
	}

	// Token: 0x04008B2E RID: 35630
	private ERedDotName? RedDotName;

	// Token: 0x04008B2F RID: 35631
	private int TabId;

	// Token: 0x0200871C RID: 34588
	[NullableContext(0)]
	private class EPayShopSwitchItem
	{
		// Token: 0x0402DB3A RID: 187194
		public const int Name = 0;

		// Token: 0x0402DB3B RID: 187195
		public const int SwitchToggle = 1;

		// Token: 0x0402DB3C RID: 187196
		public const int RedDot = 2;

		// Token: 0x0402DB3D RID: 187197
		public const int TextureImage = 3;
	}
}
