using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200206F RID: 8303
public class RewardExploreDescription : UiPanelBase
{
	// Token: 0x0600FD38 RID: 64824 RVA: 0x004577DC File Offset: 0x004559DC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x0600FD39 RID: 64825 RVA: 0x00457830 File Offset: 0x00455A30
	[NullableContext(1)]
	public void Refresh(string descriptionTextId)
	{
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, descriptionTextId, Array.Empty<object>());
	}

	// Token: 0x02008403 RID: 33795
	private class EChildType
	{
		// Token: 0x0402CBEE RID: 183278
		public const int DescriptionText = 0;
	}
}
