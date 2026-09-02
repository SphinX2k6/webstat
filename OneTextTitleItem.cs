using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020018CD RID: 6349
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class OneTextTitleItem : TitleItemBase<TableTextArgNew>
{
	// Token: 0x0600B684 RID: 46724 RVA: 0x0030868D File Offset: 0x0030688D
	public OneTextTitleItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x0600B685 RID: 46725 RVA: 0x00308698 File Offset: 0x00306898
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600B686 RID: 46726 RVA: 0x003086E0 File Offset: 0x003068E0
	public override void ShowTemp(TableTextArgNew data, DropDownItemBase<TableTextArgNew> selectedItemObj)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.TextKey, data.Params);
	}

	// Token: 0x02007C47 RID: 31815
	[NullableContext(0)]
	private class ECompDefine
	{
		// Token: 0x0402A71E RID: 173854
		public const int Title = 0;
	}
}
