using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x0200222B RID: 8747
public class MailDropDownTitle : TitleItemBase<MailFilter>
{
	// Token: 0x0601085D RID: 67677 RVA: 0x00484892 File Offset: 0x00482A92
	[NullableContext(1)]
	public MailDropDownTitle(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x0601085E RID: 67678 RVA: 0x0048489C File Offset: 0x00482A9C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601085F RID: 67679 RVA: 0x00484908 File Offset: 0x00482B08
	[NullableContext(1)]
	public override void ShowTemp(MailFilter data, DropDownItemBase<MailFilter> selectedItemObj)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Name, Array.Empty<object>());
		MailDropDownItem mailDropDownItem = selectedItemObj as MailDropDownItem;
		base.GetText(1).SetText(mailDropDownItem.GetTitleText(), true);
	}

	// Token: 0x0200850D RID: 34061
	private class EComponents
	{
		// Token: 0x0402D0CA RID: 184522
		public const int TxtName = 0;

		// Token: 0x0402D0CB RID: 184523
		public const int TxtCount = 1;
	}
}
