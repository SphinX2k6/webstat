using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020011DA RID: 4570
public class BabelTowerBuffStarItem : UiPanelBase
{
	// Token: 0x0600789E RID: 30878 RVA: 0x001F9AEC File Offset: 0x001F7CEC
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

	// Token: 0x0600789F RID: 30879 RVA: 0x001F9B34 File Offset: 0x001F7D34
	[NullableContext(1)]
	public void SetText(string text)
	{
		base.GetText(0).SetText(text, true);
	}

	// Token: 0x02007536 RID: 30006
	private class EComponents
	{
		// Token: 0x04028752 RID: 165714
		public const int StarNumText = 0;
	}
}
