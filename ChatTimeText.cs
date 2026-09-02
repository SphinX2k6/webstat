using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001856 RID: 6230
public class ChatTimeText : UiPanelBase
{
	// Token: 0x0600B22F RID: 45615 RVA: 0x002F8BE4 File Offset: 0x002F6DE4
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

	// Token: 0x0600B230 RID: 45616 RVA: 0x002F8C2C File Offset: 0x002F6E2C
	public void Refresh(Number timeStamp)
	{
		UUIText text = base.GetText(0);
		string newText = Singleton<TimeUtil>.Instance.DateFormatString(timeStamp);
		text.SetText(newText, true);
	}

	// Token: 0x02007BF6 RID: 31734
	private class EChildType
	{
		// Token: 0x0402A5AA RID: 173482
		public const int TimeText = 0;
	}
}
