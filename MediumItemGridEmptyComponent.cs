using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019C1 RID: 6593
public class MediumItemGridEmptyComponent : MediumItemGridVisibleComponent
{
	// Token: 0x0600BD44 RID: 48452 RVA: 0x00323C14 File Offset: 0x00321E14
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600BD45 RID: 48453 RVA: 0x00323C99 File Offset: 0x00321E99
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBtnEmpty";
	}

	// Token: 0x0600BD46 RID: 48454 RVA: 0x00323CA0 File Offset: 0x00321EA0
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x0600BD47 RID: 48455 RVA: 0x00323CA3 File Offset: 0x00321EA3
	protected override void OnDeactivate()
	{
		this.OnClickedCallback = null;
	}

	// Token: 0x0600BD48 RID: 48456 RVA: 0x00323CAC File Offset: 0x00321EAC
	private void OnBtnClick()
	{
		Action onClickedCallback = this.OnClickedCallback;
		if (onClickedCallback == null)
		{
			return;
		}
		onClickedCallback();
	}

	// Token: 0x0600BD49 RID: 48457 RVA: 0x00323CBE File Offset: 0x00321EBE
	public void SetClickable(bool isClickable)
	{
		this.IsClickable = isClickable;
		this.UpdateClickable();
	}

	// Token: 0x0600BD4A RID: 48458 RVA: 0x00323CCD File Offset: 0x00321ECD
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		base.OnRefresh(data);
		this.UpdateClickable();
	}

	// Token: 0x0600BD4B RID: 48459 RVA: 0x00323CDC File Offset: 0x00321EDC
	private void UpdateClickable()
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(this.IsClickable);
	}

	// Token: 0x04005959 RID: 22873
	[Nullable(2)]
	public Action OnClickedCallback;

	// Token: 0x0400595A RID: 22874
	private bool IsClickable;

	// Token: 0x02007CC2 RID: 31938
	private class EChildType
	{
		// Token: 0x0402A96D RID: 174445
		public const int BtnRoot = 0;
	}
}
