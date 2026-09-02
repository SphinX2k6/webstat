using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002025 RID: 8229
public class AccessPathPcView : UiViewBase
{
	// Token: 0x0600FA2B RID: 64043 RVA: 0x0044849D File Offset: 0x0044669D
	[NullableContext(1)]
	public AccessPathPcView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FA2C RID: 64044 RVA: 0x004484B4 File Offset: 0x004466B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 19;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickedCheckButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickedLeaveButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600FA2D RID: 64045 RVA: 0x004487B9 File Offset: 0x004469B9
	protected override void OnStart()
	{
		this.RefreshShortcutKey();
		this.RefreshAccessPathButtons();
		this.AddEvents();
	}

	// Token: 0x0600FA2E RID: 64046 RVA: 0x004487D0 File Offset: 0x004469D0
	protected override void OnBeforeDestroy()
	{
		foreach (AccessPathPcButton accessPathPcButton in this.AccessPathButtonList)
		{
			accessPathPcButton.Destroy(null);
		}
		this.AccessPathButtonList.Clear();
		this.RemoveEvents();
	}

	// Token: 0x0600FA2F RID: 64047 RVA: 0x00448834 File Offset: 0x00446A34
	public void AddEvents()
	{
	}

	// Token: 0x0600FA30 RID: 64048 RVA: 0x00448836 File Offset: 0x00446A36
	public void RemoveEvents()
	{
	}

	// Token: 0x0600FA31 RID: 64049 RVA: 0x00448838 File Offset: 0x00446A38
	private void OnClickedCheckButton()
	{
	}

	// Token: 0x0600FA32 RID: 64050 RVA: 0x0044883A File Offset: 0x00446A3A
	private void OnClickedLeaveButton()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.AccessPathPcView, null);
	}

	// Token: 0x0600FA33 RID: 64051 RVA: 0x0044884C File Offset: 0x00446A4C
	private unsafe void RefreshAccessPathButtons()
	{
		Span<int> itemAccess = ModelBase<InventoryModel>.Instance.GetSelectedItemData().GetItemDataBase().GetItemAccess();
		UUIItem item = base.GetItem(0);
		Span<int> span = itemAccess;
		for (int i = 0; i < span.Length; i++)
		{
			int accessPathId = *span[i];
			AccessPathPcButton item2 = new AccessPathPcButton(item, accessPathId);
			this.AccessPathButtonList.Add(item2);
		}
	}

	// Token: 0x0600FA34 RID: 64052 RVA: 0x004488A8 File Offset: 0x00446AA8
	private void RefreshShortcutKey()
	{
		bool shortcutKeyDisplay = Singleton<Info>.Instance.IsInKeyBoard();
		this.SetShortcutKeyDisplay(shortcutKeyDisplay);
	}

	// Token: 0x0600FA35 RID: 64053 RVA: 0x004488C8 File Offset: 0x00446AC8
	private void SetShortcutKeyDisplay(bool bPc)
	{
		UUISprite sprite = base.GetSprite(3);
		UUIItem item = base.GetItem(4);
		UUISprite sprite2 = base.GetSprite(5);
		UUIItem item2 = base.GetItem(6);
		UUISprite sprite3 = base.GetSprite(7);
		UUIItem item3 = base.GetItem(8);
		UUISprite sprite4 = base.GetSprite(9);
		UUIItem item4 = base.GetItem(10);
		UUISprite sprite5 = base.GetSprite(11);
		UUIItem item5 = base.GetItem(12);
		UUISprite sprite6 = base.GetSprite(13);
		UUIItem item6 = base.GetItem(14);
		UUISprite sprite7 = base.GetSprite(15);
		UUIItem item7 = base.GetItem(16);
		UUISprite sprite8 = base.GetSprite(17);
		UUIItem item8 = base.GetItem(18);
		sprite.SetUIActive(bPc);
		item.SetUIActive(!bPc);
		sprite2.SetUIActive(bPc);
		item2.SetUIActive(!bPc);
		sprite3.SetUIActive(bPc);
		item3.SetUIActive(!bPc);
		sprite4.SetUIActive(bPc);
		item4.SetUIActive(!bPc);
		sprite5.SetUIActive(bPc);
		item5.SetUIActive(!bPc);
		sprite6.SetUIActive(bPc);
		item6.SetUIActive(!bPc);
		sprite7.SetUIActive(bPc);
		item7.SetUIActive(!bPc);
		sprite8.SetUIActive(bPc);
		item8.SetUIActive(!bPc);
	}

	// Token: 0x04007822 RID: 30754
	[Nullable(1)]
	private readonly List<AccessPathPcButton> AccessPathButtonList = new List<AccessPathPcButton>();

	// Token: 0x020083CB RID: 33739
	private enum EChildComponentType
	{
		// Token: 0x0402CADD RID: 183005
		AccessPathButtonItem,
		// Token: 0x0402CADE RID: 183006
		CheckButton,
		// Token: 0x0402CADF RID: 183007
		LeaveButton,
		// Token: 0x0402CAE0 RID: 183008
		CheckButtonDisJs,
		// Token: 0x0402CAE1 RID: 183009
		CheckButtonDisSb,
		// Token: 0x0402CAE2 RID: 183010
		CheckButtonHlJs,
		// Token: 0x0402CAE3 RID: 183011
		CheckButtonHlSb,
		// Token: 0x0402CAE4 RID: 183012
		CheckButtonNorJs,
		// Token: 0x0402CAE5 RID: 183013
		CheckButtonNorSb,
		// Token: 0x0402CAE6 RID: 183014
		CheckButtonPreJs,
		// Token: 0x0402CAE7 RID: 183015
		CheckButtonPreSb,
		// Token: 0x0402CAE8 RID: 183016
		LeaveButtonDisJs,
		// Token: 0x0402CAE9 RID: 183017
		LeaveButtonDisSb,
		// Token: 0x0402CAEA RID: 183018
		LeaveButtonHlJs,
		// Token: 0x0402CAEB RID: 183019
		LeaveButtonHlSb,
		// Token: 0x0402CAEC RID: 183020
		LeaveButtonNorJs,
		// Token: 0x0402CAED RID: 183021
		LeaveButtonNorSb,
		// Token: 0x0402CAEE RID: 183022
		LeaveButtonPreJs,
		// Token: 0x0402CAEF RID: 183023
		LeaveButtonPreSb
	}
}
