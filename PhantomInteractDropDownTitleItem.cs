using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020024CB RID: 9419
public class PhantomInteractDropDownTitleItem : TitleItemBase<int>
{
	// Token: 0x06012496 RID: 74902 RVA: 0x0050725A File Offset: 0x0050545A
	[NullableContext(1)]
	public PhantomInteractDropDownTitleItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x06012497 RID: 74903 RVA: 0x00507263 File Offset: 0x00505463
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x06012498 RID: 74904 RVA: 0x00507288 File Offset: 0x00505488
	[NullableContext(1)]
	public override void ShowTemp(int data, DropDownItemBase<int> selectedItemObj)
	{
		UUIText text = base.GetText(0);
		string textStringId = PhantomInteractDropDownItemOptionTextId.TextIds[data];
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
	}

	// Token: 0x020087DC RID: 34780
	private enum EComponent
	{
		// Token: 0x0402DE69 RID: 188009
		TxtOption
	}
}
