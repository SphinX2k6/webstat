using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002670 RID: 9840
public class QuestViewButton : UiPanelBase
{
	// Token: 0x0601364C RID: 79436 RVA: 0x0056842C File Offset: 0x0056662C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601364D RID: 79437 RVA: 0x005684D2 File Offset: 0x005666D2
	protected override void OnStart()
	{
		this.ButtonClickFunction = (this.OpenParam as Action);
	}

	// Token: 0x0601364E RID: 79438 RVA: 0x005684E8 File Offset: 0x005666E8
	[NullableContext(1)]
	public void SetButtonText(string textTableId, bool bCommonTextTable)
	{
		if (bCommonTextTable)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), textTableId, Array.Empty<object>());
			return;
		}
		string newText = ConfigMultiTextLang.GetLocalTextNew(textTableId, null) ?? textTableId;
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(newText, true);
	}

	// Token: 0x0601364F RID: 79439 RVA: 0x00568530 File Offset: 0x00566730
	private void OnButtonClick()
	{
		Action buttonClickFunction = this.ButtonClickFunction;
		if (buttonClickFunction == null)
		{
			return;
		}
		buttonClickFunction();
	}

	// Token: 0x04009754 RID: 38740
	[Nullable(2)]
	private Action ButtonClickFunction;

	// Token: 0x02008A0B RID: 35339
	private class EChildComponent
	{
		// Token: 0x0402E8FF RID: 190719
		public const int Button = 0;

		// Token: 0x0402E900 RID: 190720
		public const int ButtonText = 1;
	}
}
