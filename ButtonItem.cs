using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001897 RID: 6295
[NullableContext(1)]
[Nullable(0)]
public class ButtonItem : UiPanelBase
{
	// Token: 0x0600B4A3 RID: 46243 RVA: 0x00301F14 File Offset: 0x00300114
	[NullableContext(2)]
	public ButtonItem(UUIItem uiItem = null)
	{
		if (uiItem != null)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}
	}

	// Token: 0x0600B4A4 RID: 46244 RVA: 0x00301F2C File Offset: 0x0030012C
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

	// Token: 0x0600B4A5 RID: 46245 RVA: 0x00301FF3 File Offset: 0x003001F3
	protected override void OnBeforeDestroy()
	{
		this.UnBindRedDot();
	}

	// Token: 0x0600B4A6 RID: 46246 RVA: 0x00301FFB File Offset: 0x003001FB
	private void ButtonClick()
	{
		if (this.ButtonFunction != null)
		{
			this.ButtonFunction(this.Data);
		}
	}

	// Token: 0x0600B4A7 RID: 46247 RVA: 0x00302018 File Offset: 0x00300218
	public void SetButtonAllowEventBubbleUp(bool value)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button != null)
		{
			button.AllowEventBubbleUp = value;
		}
	}

	// Token: 0x0600B4A8 RID: 46248 RVA: 0x00302038 File Offset: 0x00300238
	public void SetText(string text)
	{
		UUIText text2 = base.GetText(1);
		if (text2 != null)
		{
			text2.SetText(text, true);
		}
	}

	// Token: 0x0600B4A9 RID: 46249 RVA: 0x00302058 File Offset: 0x00300258
	public void SetLocalText(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), textId, args);
	}

	// Token: 0x0600B4AA RID: 46250 RVA: 0x0030206D File Offset: 0x0030026D
	public void SetLocalTextNew(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
	}

	// Token: 0x0600B4AB RID: 46251 RVA: 0x00302082 File Offset: 0x00300282
	public void TrySetLocalTextNew(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), textId, args);
	}

	// Token: 0x0600B4AC RID: 46252 RVA: 0x00302097 File Offset: 0x00300297
	public void SetShowText(string text)
	{
		UUIText text2 = base.GetText(1);
		if (text2 == null)
		{
			return;
		}
		text2.ShowTextNew(text);
	}

	// Token: 0x0600B4AD RID: 46253 RVA: 0x003020AB File Offset: 0x003002AB
	public void SetTextShowState(bool state)
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(state);
	}

	// Token: 0x0600B4AE RID: 46254 RVA: 0x003020BF File Offset: 0x003002BF
	public void SetData(int data)
	{
		this.Data = data;
	}

	// Token: 0x0600B4AF RID: 46255 RVA: 0x003020C8 File Offset: 0x003002C8
	public void SetEnableClick(bool state)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(state);
	}

	// Token: 0x0600B4B0 RID: 46256 RVA: 0x003020DC File Offset: 0x003002DC
	public void SetFunction(Action<int> buttonFunction)
	{
		this.ButtonFunction = buttonFunction;
	}

	// Token: 0x0600B4B1 RID: 46257 RVA: 0x003020E5 File Offset: 0x003002E5
	public void ExecuteButtonFunction()
	{
		if (this.ButtonFunction != null)
		{
			this.ButtonFunction(this.Data);
		}
	}

	// Token: 0x0600B4B2 RID: 46258 RVA: 0x00302100 File Offset: 0x00300300
	public void SetRedDotVisible(bool bVisible)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(bVisible);
	}

	// Token: 0x0600B4B3 RID: 46259 RVA: 0x00302114 File Offset: 0x00300314
	public void BindRedDot(ERedDotName redDotName, int uId = 0)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		this.UnBindRedDot();
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, uId);
		}
	}

	// Token: 0x0600B4B4 RID: 46260 RVA: 0x0030215C File Offset: 0x0030035C
	public void BindGivenUid(ERedDotName redDotName, int uId)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, uId);
		}
	}

	// Token: 0x0600B4B5 RID: 46261 RVA: 0x0030219C File Offset: 0x0030039C
	public void UnBindGivenUid(int uId)
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(2), uId);
		}
	}

	// Token: 0x0600B4B6 RID: 46262 RVA: 0x003021C8 File Offset: 0x003003C8
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
			this.RedDotName = null;
		}
	}

	// Token: 0x0600B4B7 RID: 46263 RVA: 0x003021F8 File Offset: 0x003003F8
	[NullableContext(2)]
	public UUIButtonComponent GetBtn()
	{
		return base.GetButton(0);
	}

	// Token: 0x04005555 RID: 21845
	private int Data;

	// Token: 0x04005556 RID: 21846
	private ERedDotName? RedDotName;

	// Token: 0x04005557 RID: 21847
	[Nullable(2)]
	private Action<int> ButtonFunction;

	// Token: 0x02007C12 RID: 31762
	[NullableContext(0)]
	private class EButtonItemDefine
	{
		// Token: 0x0402A630 RID: 173616
		public const int Button = 0;

		// Token: 0x0402A631 RID: 173617
		public const int ButtonText = 1;

		// Token: 0x0402A632 RID: 173618
		public const int RedDot = 2;
	}
}
