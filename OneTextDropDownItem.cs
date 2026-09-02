using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020018CC RID: 6348
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class OneTextDropDownItem : DropDownItemBase<TableTextArgNew>
{
	// Token: 0x0600B680 RID: 46720 RVA: 0x003085F1 File Offset: 0x003067F1
	public OneTextDropDownItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x0600B681 RID: 46721 RVA: 0x003085FC File Offset: 0x003067FC
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
	}

	// Token: 0x0600B682 RID: 46722 RVA: 0x00308665 File Offset: 0x00306865
	[NullableContext(2)]
	protected override UUIExtendToggle GetDropDownToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x0600B683 RID: 46723 RVA: 0x0030866E File Offset: 0x0030686E
	protected override void OnShowDropDownItemBase(TableTextArgNew tableText)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), tableText.TextKey, tableText.Params);
	}

	// Token: 0x02007C46 RID: 31814
	[NullableContext(0)]
	private class ECompDefine
	{
		// Token: 0x0402A71C RID: 173852
		public const int Toggle = 0;

		// Token: 0x0402A71D RID: 173853
		public const int Content = 1;
	}
}
