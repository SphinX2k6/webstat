using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019C2 RID: 6594
public class MediumItemGridEmptySlotComponent : MediumItemGridVisibleComponent
{
	// Token: 0x0600BD4D RID: 48461 RVA: 0x00323D00 File Offset: 0x00321F00
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

	// Token: 0x0600BD4E RID: 48462 RVA: 0x00323D85 File Offset: 0x00321F85
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBtnAdd";
	}

	// Token: 0x0600BD4F RID: 48463 RVA: 0x00323D8C File Offset: 0x00321F8C
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x0600BD50 RID: 48464 RVA: 0x00323D8F File Offset: 0x00321F8F
	protected override void OnDeactivate()
	{
		this.OnClickedCallback = null;
	}

	// Token: 0x0600BD51 RID: 48465 RVA: 0x00323D98 File Offset: 0x00321F98
	[NullableContext(1)]
	public void BindEmptySlotButtonCallback(Action onClickedEmptySlotButton)
	{
		this.OnClickedCallback = onClickedEmptySlotButton;
	}

	// Token: 0x0600BD52 RID: 48466 RVA: 0x00323DA1 File Offset: 0x00321FA1
	public void UnBindEmptySlotButtonCallback()
	{
		this.OnClickedCallback = null;
	}

	// Token: 0x0600BD53 RID: 48467 RVA: 0x00323DAA File Offset: 0x00321FAA
	private void OnClickedEmptySlotButton()
	{
		Action onClickedCallback = this.OnClickedCallback;
		if (onClickedCallback == null)
		{
			return;
		}
		onClickedCallback();
	}

	// Token: 0x0400595B RID: 22875
	[Nullable(2)]
	private Action OnClickedCallback;

	// Token: 0x02007CC3 RID: 31939
	private class EChildType
	{
		// Token: 0x0402A96E RID: 174446
		public const int AddButton = 0;
	}
}
