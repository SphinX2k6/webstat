using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023A8 RID: 9128
internal class GetItemPanel : UiPanelBase
{
	// Token: 0x0601197F RID: 72063 RVA: 0x004D3248 File Offset: 0x004D1448
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnItemButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011980 RID: 72064 RVA: 0x004D330F File Offset: 0x004D150F
	protected override void OnStart()
	{
		base.GetTexture(1).SetUIActive(false);
	}

	// Token: 0x06011981 RID: 72065 RVA: 0x004D331E File Offset: 0x004D151E
	private void OnItemButtonClick()
	{
		if (this.ItemId == 0)
		{
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemId, true, null);
	}

	// Token: 0x06011982 RID: 72066 RVA: 0x004D333C File Offset: 0x004D153C
	public void Refresh(int itemId, int count)
	{
		this.ItemId = itemId;
		UUITexture textureIcon = base.GetTexture(1);
		base.SetItemIcon(textureIcon, itemId, null, delegate(bool _)
		{
			textureIcon.SetUIActive(true);
		});
		UUIText text = base.GetText(2);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Text_RoleCount_Text", new <>z__ReadOnlySingleElementList<object>(count.ToString()));
	}

	// Token: 0x0400899F RID: 35231
	private int ItemId;

	// Token: 0x020086BF RID: 34495
	private enum EGetItemPanelComponents
	{
		// Token: 0x0402D942 RID: 186690
		ButtonReward,
		// Token: 0x0402D943 RID: 186691
		TextureIcon,
		// Token: 0x0402D944 RID: 186692
		TextNum
	}
}
