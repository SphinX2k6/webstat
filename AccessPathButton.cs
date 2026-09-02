using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002023 RID: 8227
public class AccessPathButton : UiPanelBase
{
	// Token: 0x0600FA22 RID: 64034 RVA: 0x004481A6 File Offset: 0x004463A6
	[NullableContext(1)]
	public AccessPathButton(AActor rootActor, int getWayId)
	{
		this.GetWayId = getWayId;
		base.CreateThenShowByActor(rootActor, null);
	}

	// Token: 0x0600FA23 RID: 64035 RVA: 0x004481C0 File Offset: 0x004463C0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIToggleComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnGetWayButtonClicked));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600FA24 RID: 64036 RVA: 0x0044830C File Offset: 0x0044650C
	protected override void OnStart()
	{
		AccessPath? accessPathConfig = ConfigBase<InventoryConfig>.Instance.GetAccessPathConfig(this.GetWayId);
		if (accessPathConfig == null)
		{
			return;
		}
		UUIText text = base.GetText(0);
		UUIText text2 = base.GetText(1);
		UUIText text3 = base.GetText(2);
		UUIText text4 = base.GetText(3);
		UUIText text5 = base.GetText(4);
		UUIText text6 = base.GetText(5);
		if (text == null || text2 == null || text3 == null || text4 == null || text5 == null || text6 == null)
		{
			return;
		}
		string description = accessPathConfig.Value.Description;
		text.ShowTextNew(description);
		text2.ShowTextNew(description);
		text3.ShowTextNew(description);
		text4.ShowTextNew(description);
		text5.ShowTextNew(description);
		text6.ShowTextNew(description);
	}

	// Token: 0x0600FA25 RID: 64037 RVA: 0x004483C2 File Offset: 0x004465C2
	protected override void OnBeforeDestroy()
	{
		this.OnAccessPathButtonClickedCallback = null;
	}

	// Token: 0x0600FA26 RID: 64038 RVA: 0x004483CB File Offset: 0x004465CB
	[NullableContext(1)]
	public void BindOnGetWayButtonClickedCallback(Action<int> onAccessPathButtonClickedCallback)
	{
		this.OnAccessPathButtonClickedCallback = onAccessPathButtonClickedCallback;
	}

	// Token: 0x0600FA27 RID: 64039 RVA: 0x004483D4 File Offset: 0x004465D4
	private void OnGetWayButtonClicked()
	{
		if (this.OnAccessPathButtonClickedCallback != null)
		{
			this.OnAccessPathButtonClickedCallback(this.GetWayId);
		}
	}

	// Token: 0x0400781F RID: 30751
	[Nullable(2)]
	private Action<int> OnAccessPathButtonClickedCallback;

	// Token: 0x04007820 RID: 30752
	private readonly int GetWayId;

	// Token: 0x020083C9 RID: 33737
	private enum EChildComponentType
	{
		// Token: 0x0402CAD3 RID: 182995
		Text1,
		// Token: 0x0402CAD4 RID: 182996
		Text2,
		// Token: 0x0402CAD5 RID: 182997
		Text3,
		// Token: 0x0402CAD6 RID: 182998
		Text4,
		// Token: 0x0402CAD7 RID: 182999
		Text5,
		// Token: 0x0402CAD8 RID: 183000
		Text6,
		// Token: 0x0402CAD9 RID: 183001
		Button
	}
}
