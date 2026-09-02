using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020023BD RID: 9149
[NullableContext(1)]
[Nullable(0)]
public class PayShopRecommendTabItem : CommonTabItemBase
{
	// Token: 0x06011A66 RID: 72294 RVA: 0x004D831F File Offset: 0x004D651F
	public PayShopRecommendTabItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner());
	}

	// Token: 0x06011A67 RID: 72295 RVA: 0x004D8334 File Offset: 0x004D6534
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleEvent));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011A68 RID: 72296 RVA: 0x004D83DA File Offset: 0x004D65DA
	protected override void OnStart()
	{
		base.OnStart();
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06011A69 RID: 72297 RVA: 0x004D83F3 File Offset: 0x004D65F3
	protected void ToggleEvent(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SelectedCallBack(base.GridIndex);
		}
	}

	// Token: 0x06011A6A RID: 72298 RVA: 0x004D840C File Offset: 0x004D660C
	protected override void OnUpdateTabIcon(string iconPath)
	{
	}

	// Token: 0x06011A6B RID: 72299 RVA: 0x004D840E File Offset: 0x004D660E
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(0).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x06011A6C RID: 72300 RVA: 0x004D8421 File Offset: 0x004D6621
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x020086DE RID: 34526
	[NullableContext(0)]
	private enum EPayShopRecommondTabItemDefine
	{
		// Token: 0x0402D9C3 RID: 186819
		Toggle,
		// Token: 0x0402D9C4 RID: 186820
		Name
	}
}
