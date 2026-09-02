using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001764 RID: 5988
public class PeriodicityChallengeItemTopTips : UiPanelBase
{
	// Token: 0x0600A844 RID: 43076 RVA: 0x002CCE38 File Offset: 0x002CB038
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

	// Token: 0x0600A845 RID: 43077 RVA: 0x002CCEA1 File Offset: 0x002CB0A1
	[NullableContext(1)]
	public void Refresh(IPeriodicityChallengeTopTips data)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.TitleTips, data.Args);
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(data.TxtNum, true);
	}

	// Token: 0x02007AC6 RID: 31430
	private enum ETipsDefine
	{
		// Token: 0x0402A0DE RID: 172254
		TxtTitle,
		// Token: 0x0402A0DF RID: 172255
		TxtNum
	}
}
