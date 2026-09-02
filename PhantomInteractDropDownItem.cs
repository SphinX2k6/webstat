using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020024CA RID: 9418
public class PhantomInteractDropDownItem : DropDownItemBase<int>
{
	// Token: 0x06012492 RID: 74898 RVA: 0x005071E0 File Offset: 0x005053E0
	[NullableContext(1)]
	public PhantomInteractDropDownItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x06012493 RID: 74899 RVA: 0x005071E9 File Offset: 0x005053E9
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06012494 RID: 74900 RVA: 0x00507222 File Offset: 0x00505422
	[NullableContext(2)]
	protected override UUIExtendToggle GetDropDownToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x06012495 RID: 74901 RVA: 0x0050722C File Offset: 0x0050542C
	protected override void OnShowDropDownItemBase(int data)
	{
		UUIText text = base.GetText(1);
		string textStringId = PhantomInteractDropDownItemOptionTextId.TextIds[data];
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
	}

	// Token: 0x020087DB RID: 34779
	private enum EComponent
	{
		// Token: 0x0402DE66 RID: 188006
		TogOption,
		// Token: 0x0402DE67 RID: 188007
		TxtOption
	}
}
