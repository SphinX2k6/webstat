using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001898 RID: 6296
public class ButtonSpriteItem : UiPanelBase
{
	// Token: 0x0600B4B8 RID: 46264 RVA: 0x00302204 File Offset: 0x00300404
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
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

	// Token: 0x0600B4B9 RID: 46265 RVA: 0x003022CB File Offset: 0x003004CB
	protected override void OnBeforeDestroy()
	{
		this.UnBindRedDot();
	}

	// Token: 0x0600B4BA RID: 46266 RVA: 0x003022D3 File Offset: 0x003004D3
	private void ButtonClick()
	{
		if (this.ButtonFunction != null)
		{
			this.ButtonFunction();
		}
	}

	// Token: 0x0600B4BB RID: 46267 RVA: 0x003022E8 File Offset: 0x003004E8
	[NullableContext(2)]
	public UUIButtonComponent GetBtn()
	{
		return base.GetButton(0);
	}

	// Token: 0x0600B4BC RID: 46268 RVA: 0x003022F4 File Offset: 0x003004F4
	public void SetButtonAllowEventBubbleUp(bool value)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button != null)
		{
			button.AllowEventBubbleUp = value;
		}
	}

	// Token: 0x0600B4BD RID: 46269 RVA: 0x00302314 File Offset: 0x00300514
	public void SetEnableClick(bool state)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button != null)
		{
			button.SetSelfInteractive(state);
		}
	}

	// Token: 0x0600B4BE RID: 46270 RVA: 0x00302333 File Offset: 0x00300533
	[NullableContext(1)]
	public void SetFunction(Action buttonFunction)
	{
		this.ButtonFunction = buttonFunction;
	}

	// Token: 0x0600B4BF RID: 46271 RVA: 0x0030233C File Offset: 0x0030053C
	public void SetSpriteVisible(bool bVisible)
	{
		base.GetSprite(1).SetUIActive(bVisible);
	}

	// Token: 0x0600B4C0 RID: 46272 RVA: 0x0030234C File Offset: 0x0030054C
	[NullableContext(1)]
	public void SetSprite(string path)
	{
		UUISprite sprite = base.GetSprite(1);
		sprite.SetUIActive(false);
		this.SetSpriteByPath(path, sprite, false, null, delegate(bool success)
		{
			sprite.SetUIActive(success);
		});
	}

	// Token: 0x0600B4C1 RID: 46273 RVA: 0x0030239B File Offset: 0x0030059B
	public void SetRedDotVisible(bool bVisible)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(bVisible);
	}

	// Token: 0x0600B4C2 RID: 46274 RVA: 0x003023B0 File Offset: 0x003005B0
	public void BindRedDot(ERedDotName redDotName, int uId = 0)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		this.UnBindRedDot();
		this.RedDotName = new ERedDotName?(redDotName);
		this.RedDotUid = uId;
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, uId);
		}
	}

	// Token: 0x0600B4C3 RID: 46275 RVA: 0x00302400 File Offset: 0x00300600
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			UUIItem item = base.GetItem(2);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, item, this.RedDotUid);
			this.RedDotName = null;
			this.RedDotUid = 0;
		}
	}

	// Token: 0x04005558 RID: 21848
	private ERedDotName? RedDotName;

	// Token: 0x04005559 RID: 21849
	private int RedDotUid;

	// Token: 0x0400555A RID: 21850
	[Nullable(2)]
	private Action ButtonFunction;

	// Token: 0x02007C13 RID: 31763
	private class EButtonItemDefine
	{
		// Token: 0x0402A633 RID: 173619
		public const int Button = 0;

		// Token: 0x0402A634 RID: 173620
		public const int Sprite = 1;

		// Token: 0x0402A635 RID: 173621
		public const int RedDot = 2;
	}
}
