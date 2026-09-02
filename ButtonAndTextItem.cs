using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001896 RID: 6294
[NullableContext(1)]
[Nullable(0)]
public class ButtonAndTextItem : UiPanelBase
{
	// Token: 0x0600B49A RID: 46234 RVA: 0x00301DC9 File Offset: 0x002FFFC9
	public ButtonAndTextItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B49B RID: 46235 RVA: 0x00301DE0 File Offset: 0x002FFFE0
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B49C RID: 46236 RVA: 0x00301E86 File Offset: 0x00300086
	public void RefreshText(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), textId, args);
	}

	// Token: 0x0600B49D RID: 46237 RVA: 0x00301E9B File Offset: 0x0030009B
	public void RefreshTextNew(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
	}

	// Token: 0x0600B49E RID: 46238 RVA: 0x00301EB0 File Offset: 0x003000B0
	public void SetText(string content)
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(content, true);
	}

	// Token: 0x0600B49F RID: 46239 RVA: 0x00301EC5 File Offset: 0x003000C5
	public void SetTextColor(FColor newColor)
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetColor(newColor);
	}

	// Token: 0x0600B4A0 RID: 46240 RVA: 0x00301ED9 File Offset: 0x003000D9
	public void RefreshEnable(bool isEnable)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(isEnable);
	}

	// Token: 0x0600B4A1 RID: 46241 RVA: 0x00301EED File Offset: 0x003000ED
	public void BindCallback(Action onCallback)
	{
		if (this.OnCallback != null)
		{
			return;
		}
		this.OnCallback = onCallback;
	}

	// Token: 0x0600B4A2 RID: 46242 RVA: 0x00301EFF File Offset: 0x003000FF
	private void OnClick()
	{
		if (this.OnCallback != null)
		{
			this.OnCallback();
		}
	}

	// Token: 0x04005554 RID: 21844
	[Nullable(2)]
	private Action OnCallback;

	// Token: 0x02007C11 RID: 31761
	[NullableContext(0)]
	private class EButtonItemDefine
	{
		// Token: 0x0402A62E RID: 173614
		public const int Button = 0;

		// Token: 0x0402A62F RID: 173615
		public const int Text = 1;
	}
}
