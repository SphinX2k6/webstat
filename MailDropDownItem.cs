using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x0200222A RID: 8746
[NullableContext(1)]
[Nullable(0)]
public abstract class MailDropDownItem : DropDownItemBase<MailFilter>
{
	// Token: 0x06010857 RID: 67671 RVA: 0x004847D9 File Offset: 0x004829D9
	public MailDropDownItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x06010858 RID: 67672 RVA: 0x004847E4 File Offset: 0x004829E4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x06010859 RID: 67673 RVA: 0x00484879 File Offset: 0x00482A79
	[NullableContext(2)]
	protected override UUIExtendToggle GetDropDownToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x0601085A RID: 67674 RVA: 0x00484882 File Offset: 0x00482A82
	protected void SetMailCount(string count)
	{
		base.GetText(2).SetText(count, true);
	}

	// Token: 0x0601085B RID: 67675
	public abstract string GetTitleText();

	// Token: 0x0601085C RID: 67676
	public abstract MailData[] GetFilteredMailList();
}
