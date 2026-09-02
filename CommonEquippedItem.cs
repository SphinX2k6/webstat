using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018A1 RID: 6305
public class CommonEquippedItem : UiPanelBase
{
	// Token: 0x0600B516 RID: 46358 RVA: 0x0030392C File Offset: 0x00301B2C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600B517 RID: 46359 RVA: 0x003039B8 File Offset: 0x00301BB8
	[NullableContext(1)]
	public void SetEquipIcon(string path)
	{
		base.SetTextureByPath(path, base.GetTexture(1), null, null);
	}

	// Token: 0x0600B518 RID: 46360 RVA: 0x003039DD File Offset: 0x00301BDD
	[NullableContext(1)]
	public void SetEquipText(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), textId, args);
	}

	// Token: 0x0600B519 RID: 46361 RVA: 0x003039F2 File Offset: 0x00301BF2
	public void SetCurrentEquippedState(bool state)
	{
		base.GetItem(0).SetUIActive(state);
	}

	// Token: 0x0600B51A RID: 46362 RVA: 0x00303A01 File Offset: 0x00301C01
	public void SetIconRootItemState(bool state)
	{
		this.RootItem.SetUIActive(state);
	}

	// Token: 0x02007C25 RID: 31781
	private class ECommonEquippedItem
	{
		// Token: 0x0402A675 RID: 173685
		public const int CurrentEquippedItem = 0;

		// Token: 0x0402A676 RID: 173686
		public const int Icon = 1;

		// Token: 0x0402A677 RID: 173687
		public const int Text = 2;
	}
}
