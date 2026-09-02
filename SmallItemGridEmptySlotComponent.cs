using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001A23 RID: 6691
public class SmallItemGridEmptySlotComponent : SmallItemGridVisibleComponent
{
	// Token: 0x0600BFF6 RID: 49142 RVA: 0x0032C3C0 File Offset: 0x0032A5C0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedEmptySlotButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600BFF7 RID: 49143 RVA: 0x0032C445 File Offset: 0x0032A645
	[NullableContext(2)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBStateAdd";
	}

	// Token: 0x0600BFF8 RID: 49144 RVA: 0x0032C44C File Offset: 0x0032A64C
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x0600BFF9 RID: 49145 RVA: 0x0032C44F File Offset: 0x0032A64F
	protected override void OnDeactivate()
	{
		this.OnClickedCallback = null;
	}

	// Token: 0x0600BFFA RID: 49146 RVA: 0x0032C458 File Offset: 0x0032A658
	[NullableContext(1)]
	public void BindEmptySlotButtonCallback(Action onClickedEmptySlotButton)
	{
		this.OnClickedCallback = onClickedEmptySlotButton;
	}

	// Token: 0x0600BFFB RID: 49147 RVA: 0x0032C461 File Offset: 0x0032A661
	public void UnBindEmptySlotButtonCallback()
	{
		this.OnClickedCallback = null;
	}

	// Token: 0x0600BFFC RID: 49148 RVA: 0x0032C46A File Offset: 0x0032A66A
	private void OnClickedEmptySlotButton()
	{
		if (this.OnClickedCallback != null)
		{
			this.OnClickedCallback();
		}
	}

	// Token: 0x040059EF RID: 23023
	[Nullable(2)]
	private Action OnClickedCallback;

	// Token: 0x02007CFB RID: 31995
	private enum EChildType
	{
		// Token: 0x0402AA13 RID: 174611
		AddButton
	}
}
