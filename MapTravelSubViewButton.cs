using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200138E RID: 5006
[NullableContext(1)]
[Nullable(0)]
public class MapTravelSubViewButton : UiPanelBase
{
	// Token: 0x060089A0 RID: 35232 RVA: 0x002432FC File Offset: 0x002414FC
	public MapTravelSubViewButton(EMapTravelSubType type)
	{
		this.Type = type;
	}

	// Token: 0x060089A1 RID: 35233 RVA: 0x0024330C File Offset: 0x0024150C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060089A2 RID: 35234 RVA: 0x00243457 File Offset: 0x00241657
	public void SetNameTextId(string textId)
	{
		base.GetText(1).ShowTextNew(textId);
	}

	// Token: 0x060089A3 RID: 35235 RVA: 0x00243466 File Offset: 0x00241666
	public void SetItemDone(bool bVisible)
	{
		base.GetItem(7).SetUIActive(bVisible);
	}

	// Token: 0x060089A4 RID: 35236 RVA: 0x00243475 File Offset: 0x00241675
	public void SetItemNew(bool bVisible)
	{
		base.GetItem(8).SetUIActive(bVisible);
	}

	// Token: 0x060089A5 RID: 35237 RVA: 0x00243484 File Offset: 0x00241684
	public void SetProgressText(string text)
	{
		base.GetText(2).SetText(text, true);
	}

	// Token: 0x060089A6 RID: 35238 RVA: 0x00243494 File Offset: 0x00241694
	public void SetProgressTextChangeColor(bool bChange)
	{
		UUIText text = base.GetText(2);
		UUIItem uuiitem = text;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bChange, fcolor);
	}

	// Token: 0x060089A7 RID: 35239 RVA: 0x002434BE File Offset: 0x002416BE
	public void RefreshRedDot(bool bVisible)
	{
		base.GetItem(6).SetUIActive(bVisible);
	}

	// Token: 0x060089A8 RID: 35240 RVA: 0x002434CD File Offset: 0x002416CD
	public UUIItem GetIconItem()
	{
		return base.GetItem(4);
	}

	// Token: 0x060089A9 RID: 35241 RVA: 0x002434D6 File Offset: 0x002416D6
	public void SetFunction(Action<EMapTravelSubType> func)
	{
		this.ClickedFunc = func;
	}

	// Token: 0x060089AA RID: 35242 RVA: 0x002434DF File Offset: 0x002416DF
	private void OnClickedButton()
	{
		Action<EMapTravelSubType> clickedFunc = this.ClickedFunc;
		if (clickedFunc == null)
		{
			return;
		}
		clickedFunc(this.Type);
	}

	// Token: 0x0400407C RID: 16508
	[Nullable(2)]
	private Action<EMapTravelSubType> ClickedFunc;

	// Token: 0x0400407D RID: 16509
	private EMapTravelSubType Type;

	// Token: 0x0200772B RID: 30507
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402908A RID: 168074
		public const int Button = 0;

		// Token: 0x0402908B RID: 168075
		public const int TxtName = 1;

		// Token: 0x0402908C RID: 168076
		public const int TxtProgress = 2;

		// Token: 0x0402908D RID: 168077
		public const int TexBg = 3;

		// Token: 0x0402908E RID: 168078
		public const int TexIcon1 = 4;

		// Token: 0x0402908F RID: 168079
		public const int TexIcon2 = 5;

		// Token: 0x04029090 RID: 168080
		public const int RedDot = 6;

		// Token: 0x04029091 RID: 168081
		public const int ItemDone = 7;

		// Token: 0x04029092 RID: 168082
		public const int ItemNew = 8;
	}
}
