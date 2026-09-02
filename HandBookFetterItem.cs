using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using UnrealEngine;

// Token: 0x02001E6D RID: 7789
[NullableContext(1)]
[Nullable(0)]
public class HandBookFetterItem : GridProxyAbstract<PhantomFetter>
{
	// Token: 0x0600E64C RID: 58956 RVA: 0x003E2640 File Offset: 0x003E0840
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnFetterToggleClicked))
		};
	}

	// Token: 0x0600E64D RID: 58957 RVA: 0x003E2718 File Offset: 0x003E0918
	public override void Refresh(PhantomFetter phantomFetter, bool isSelected, int gridIndex)
	{
		this.PhantomFetter = new PhantomFetter?(phantomFetter);
		this.GirdIndex = gridIndex;
		base.GetTexture(1).SetUIActive(false);
		base.GetItem(2).SetUIActive(false);
		base.GetText(3).SetUIActive(false);
		base.GetSprite(5).SetUIActive(false);
		base.GetText(4).ShowTextNew(this.PhantomFetter.Value.Name);
		if (this.ContentGenericLayout != null)
		{
			this.ContentGenericLayout.ClearChildren();
		}
		this.ContentGenericLayout = new GenericLayoutNew<HandBookCommonItem>(base.GetHorizontalLayout(6), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<HandBookCommonItem>(this.InitContentItem), null);
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		this.ContentGenericLayout.RebuildLayoutByDataNew<HandBookCommonItemData>(this.HandBookCommonItemDataList, null);
		this.SetSelected(isSelected);
	}

	// Token: 0x0600E64E RID: 58958 RVA: 0x003E27E9 File Offset: 0x003E09E9
	public int GetGirdIndex()
	{
		return this.GirdIndex;
	}

	// Token: 0x0600E64F RID: 58959 RVA: 0x003E27F1 File Offset: 0x003E09F1
	public void BindFetterToggleCallback(TFetterToggleFunction fetterToggleFunction)
	{
		this.FetterToggleFunction = fetterToggleFunction;
	}

	// Token: 0x0600E650 RID: 58960 RVA: 0x003E27FA File Offset: 0x003E09FA
	private void OnFetterToggleClicked(EToggleState state)
	{
		if (this.FetterToggleFunction != null && state == EToggleState.ETT_Checked)
		{
			this.FetterToggleFunction(this);
		}
	}

	// Token: 0x0600E651 RID: 58961 RVA: 0x003E2814 File Offset: 0x003E0A14
	public PhantomFetter? GetPhantomFetter()
	{
		return this.PhantomFetter;
	}

	// Token: 0x0600E652 RID: 58962 RVA: 0x003E281C File Offset: 0x003E0A1C
	private ILayoutItem<HandBookCommonItem> InitContentItem(object data, UUIItem uiItem, int index)
	{
		HandBookCommonItem handBookCommonItem = new HandBookCommonItem();
		handBookCommonItem.Initialize(uiItem.GetOwner());
		handBookCommonItem.Refresh((HandBookCommonItemData)data, false, 0);
		handBookCommonItem.SetToggleInteractive(false);
		return new LayoutItem<HandBookCommonItem>
		{
			Key = index,
			Value = handBookCommonItem
		};
	}

	// Token: 0x0600E653 RID: 58963 RVA: 0x003E2868 File Offset: 0x003E0A68
	private void SetSelected(bool bSelected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (bSelected)
		{
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600E654 RID: 58964 RVA: 0x003E2897 File Offset: 0x003E0A97
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false);
	}

	// Token: 0x0600E655 RID: 58965 RVA: 0x003E28A0 File Offset: 0x003E0AA0
	public void SetToggleStateForce(EToggleState state, bool bFire = false)
	{
		base.GetExtendToggle(0).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x0600E656 RID: 58966 RVA: 0x003E28B3 File Offset: 0x003E0AB3
	public override void OnSelected(bool fireEvent)
	{
		if (fireEvent)
		{
			this.SetToggleStateForce(EToggleState.ETT_Checked, false);
			this.OnFetterToggleClicked(EToggleState.ETT_Checked);
		}
	}

	// Token: 0x0600E657 RID: 58967 RVA: 0x003E28C7 File Offset: 0x003E0AC7
	protected override void OnBeforeDestroy()
	{
		this.PhantomFetter = null;
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		if (this.ContentGenericLayout != null)
		{
			this.ContentGenericLayout.ClearChildren();
			this.ContentGenericLayout = null;
		}
		this.FetterToggleFunction = null;
	}

	// Token: 0x04006F12 RID: 28434
	protected PhantomFetter? PhantomFetter;

	// Token: 0x04006F13 RID: 28435
	protected List<HandBookCommonItemData> HandBookCommonItemDataList;

	// Token: 0x04006F14 RID: 28436
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public GenericLayoutNew<HandBookCommonItem> ContentGenericLayout;

	// Token: 0x04006F15 RID: 28437
	private int GirdIndex;

	// Token: 0x04006F16 RID: 28438
	[Nullable(2)]
	protected TFetterToggleFunction FetterToggleFunction;
}
