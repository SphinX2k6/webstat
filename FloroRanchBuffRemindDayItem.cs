using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C4B RID: 7243
public class FloroRanchBuffRemindDayItem : UiPanelBase
{
	// Token: 0x0600D347 RID: 54087 RVA: 0x00384B70 File Offset: 0x00382D70
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIArtText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D348 RID: 54088 RVA: 0x00384BB8 File Offset: 0x00382DB8
	[NullableContext(2)]
	public void Refresh(FloroRanchBuffData buffData)
	{
		if (buffData == null)
		{
			base.GetRootItem().SetUIActive(false);
			return;
		}
		base.GetArtText(0).SetText(buffData.RemindDay.ToString());
		base.GetRootItem().SetUIActive(true);
	}

	// Token: 0x02007F5C RID: 32604
	private class EComponent
	{
		// Token: 0x0402B5B3 RID: 177587
		public const int RemindTimeText = 0;
	}
}
