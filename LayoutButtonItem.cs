using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200189C RID: 6300
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class LayoutButtonItem : GridProxyAbstract<ButtonItemData>
{
	// Token: 0x0600B4CE RID: 46286 RVA: 0x003025CC File Offset: 0x003007CC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B4CF RID: 46287 RVA: 0x00302693 File Offset: 0x00300893
	private void ButtonClick()
	{
		if (this.CurrentData != null)
		{
			this.CurrentData.OnClickCallback(this.CurrentData.Index);
		}
	}

	// Token: 0x0600B4D0 RID: 46288 RVA: 0x003026B8 File Offset: 0x003008B8
	public override void Refresh(ButtonItemData data, bool isSelected, int gridIndex)
	{
		if (this.CurrentData != null && this.CurrentData.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.CurrentData.RedDotName.Value, base.GetItem(2), 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(data.RedDotName.Value, base.GetItem(2), null, 0);
		}
		this.CurrentData = data;
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew(data.ButtonText);
	}

	// Token: 0x0600B4D1 RID: 46289 RVA: 0x0030273D File Offset: 0x0030093D
	protected override void OnBeforeDestroy()
	{
		if (this.CurrentData != null && this.CurrentData.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.CurrentData.RedDotName.Value, base.GetItem(2), 0);
		}
	}

	// Token: 0x0600B4D2 RID: 46290 RVA: 0x0030277B File Offset: 0x0030097B
	public void SetEnableClick(bool state)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(state);
	}

	// Token: 0x0600B4D3 RID: 46291 RVA: 0x0030278F File Offset: 0x0030098F
	public void SetShowText(string text)
	{
		UUIText text2 = base.GetText(1);
		if (text2 == null)
		{
			return;
		}
		text2.ShowTextNew(text);
	}

	// Token: 0x0600B4D4 RID: 46292 RVA: 0x003027A3 File Offset: 0x003009A3
	public void SetLocalText(string textId, [Nullable(new byte[]
	{
		2,
		1
	})] string[] textParams = null)
	{
		if (textParams != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), textId, textParams);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), textId, Array.Empty<object>());
	}

	// Token: 0x0600B4D5 RID: 46293 RVA: 0x003027D3 File Offset: 0x003009D3
	public void SetRedDotVisible(bool bVisible)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(bVisible);
	}

	// Token: 0x04005560 RID: 21856
	[Nullable(2)]
	private ButtonItemData CurrentData;

	// Token: 0x02007C18 RID: 31768
	[NullableContext(0)]
	private class EButtonItemDefine
	{
		// Token: 0x0402A63B RID: 173627
		public const int Button = 0;

		// Token: 0x0402A63C RID: 173628
		public const int ButtonText = 1;

		// Token: 0x0402A63D RID: 173629
		public const int RedDot = 2;
	}
}
