using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020016B7 RID: 5815
public class WheelTowerModeSettlementTitleItem : UiPanelBase
{
	// Token: 0x0600A1AD RID: 41389 RVA: 0x002A8164 File Offset: 0x002A6364
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A1AE RID: 41390 RVA: 0x002A8210 File Offset: 0x002A6410
	public void Refresh(bool isEndless)
	{
		base.GetTexture(0).SetUIActive(!isEndless);
		base.GetTexture(1).SetUIActive(isEndless);
		UUITexture texture = base.GetTexture(2);
		UUIText text = base.GetText(3);
		string textStringId = isEndless ? "WheelTowerModeTitle_Endless" : "WheelTowerModeTitle_Normal";
		if (texture != null)
		{
			UUIItem uuiitem = texture;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(isEndless, fcolor);
		}
		if (text != null)
		{
			UUIItem uuiitem2 = text;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem2.SetChangeColor(isEndless, fcolor);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
	}
}
