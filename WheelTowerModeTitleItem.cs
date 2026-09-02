using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020016B6 RID: 5814
public class WheelTowerModeTitleItem : UiPanelBase
{
	// Token: 0x0600A1AA RID: 41386 RVA: 0x002A8064 File Offset: 0x002A6264
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A1AB RID: 41387 RVA: 0x002A80F0 File Offset: 0x002A62F0
	public void Refresh(bool isEndless)
	{
		base.GetTexture(0).SetUIActive(!isEndless);
		base.GetTexture(1).SetUIActive(isEndless);
		UUIText text = base.GetText(2);
		string textStringId = isEndless ? "WheelTowerModeTitle_Endless" : "WheelTowerModeTitle_Normal";
		if (text != null)
		{
			UUIItem uuiitem = text;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(isEndless, fcolor);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
	}
}
