using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001894 RID: 6292
[NullableContext(1)]
[Nullable(0)]
public class ButtonAndCostItem : UiPanelBase
{
	// Token: 0x0600B47E RID: 46206 RVA: 0x003018E0 File Offset: 0x002FFAE0
	public UniTask Init(UUIItem uiItem)
	{
		ButtonAndCostItem.<Init>d__4 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.uiItem = uiItem;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ButtonAndCostItem.<Init>d__4>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600B47F RID: 46207 RVA: 0x0030192C File Offset: 0x002FFB2C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B480 RID: 46208 RVA: 0x00301A35 File Offset: 0x002FFC35
	protected override void OnBeforeDestroy()
	{
		this.UnBindRedDot();
	}

	// Token: 0x0600B481 RID: 46209 RVA: 0x00301A3D File Offset: 0x002FFC3D
	private void ButtonClick()
	{
		Action<int> buttonFunction = this.ButtonFunction;
		if (buttonFunction == null)
		{
			return;
		}
		buttonFunction(this.Data);
	}

	// Token: 0x0600B482 RID: 46210 RVA: 0x00301A58 File Offset: 0x002FFC58
	public void SetButtonAllowEventBubbleUp(bool value)
	{
		UUIButtonComponent btn = this.GetBtn();
		if (btn != null)
		{
			btn.AllowEventBubbleUp = value;
		}
	}

	// Token: 0x0600B483 RID: 46211 RVA: 0x00301A76 File Offset: 0x002FFC76
	public void SetText(string text)
	{
		UUIText text2 = base.GetText(1);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(text, true);
	}

	// Token: 0x0600B484 RID: 46212 RVA: 0x00301A8B File Offset: 0x002FFC8B
	public void SetLocalTextNew(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
	}

	// Token: 0x0600B485 RID: 46213 RVA: 0x00301AA0 File Offset: 0x002FFCA0
	public void SetShowText(string text)
	{
		UUIText text2 = base.GetText(1);
		if (text2 == null)
		{
			return;
		}
		text2.ShowTextNew(text);
	}

	// Token: 0x0600B486 RID: 46214 RVA: 0x00301AB4 File Offset: 0x002FFCB4
	public void SetData(int data)
	{
		this.Data = data;
	}

	// Token: 0x0600B487 RID: 46215 RVA: 0x00301ABD File Offset: 0x002FFCBD
	public void SetEnableClick(bool state)
	{
		UUIButtonComponent btn = this.GetBtn();
		if (btn == null)
		{
			return;
		}
		btn.SetSelfInteractive(state);
	}

	// Token: 0x0600B488 RID: 46216 RVA: 0x00301AD0 File Offset: 0x002FFCD0
	public void SetFunction(Action<int> buttonFunction)
	{
		this.ButtonFunction = buttonFunction;
	}

	// Token: 0x0600B489 RID: 46217 RVA: 0x00301AD9 File Offset: 0x002FFCD9
	public void SetRedDotVisible(bool bVisible)
	{
		base.GetItem(2).SetUIActive(bVisible);
	}

	// Token: 0x0600B48A RID: 46218 RVA: 0x00301AE8 File Offset: 0x002FFCE8
	public void BindRedDot(ERedDotName redDotName, int uId = 0)
	{
		this.UnBindRedDot();
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			UUIItem item = base.GetItem(2);
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, uId);
		}
	}

	// Token: 0x0600B48B RID: 46219 RVA: 0x00301B2C File Offset: 0x002FFD2C
	public void BindGivenUid(ERedDotName redDotName, int uId)
	{
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			UUIItem item = base.GetItem(2);
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, uId);
		}
	}

	// Token: 0x0600B48C RID: 46220 RVA: 0x00301B68 File Offset: 0x002FFD68
	public void UnBindGivenUid(int uId)
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(2), uId);
		}
	}

	// Token: 0x0600B48D RID: 46221 RVA: 0x00301B94 File Offset: 0x002FFD94
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
			this.RedDotName = null;
		}
	}

	// Token: 0x0600B48E RID: 46222 RVA: 0x00301BC4 File Offset: 0x002FFDC4
	[NullableContext(2)]
	public UUIButtonComponent GetBtn()
	{
		return base.GetButton(0);
	}

	// Token: 0x0600B48F RID: 46223 RVA: 0x00301BD0 File Offset: 0x002FFDD0
	public void UpdateCostIcon(string path)
	{
		UUITexture texture = base.GetTexture(3);
		base.SetTextureByPath(path, texture, null, null);
	}

	// Token: 0x0600B490 RID: 46224 RVA: 0x00301BF7 File Offset: 0x002FFDF7
	public void UpdateCostNum(int num)
	{
		UUIText text = base.GetText(4);
		if (text == null)
		{
			return;
		}
		text.SetText(num.ToString(), true);
	}

	// Token: 0x0600B491 RID: 46225 RVA: 0x00301C14 File Offset: 0x002FFE14
	public void UpdateCostColor(bool useChangeColor)
	{
		UUIText text = base.GetText(4);
		if (text != null)
		{
			UUIItem uuiitem = text;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(useChangeColor, fcolor);
		}
	}

	// Token: 0x04005550 RID: 21840
	private int Data;

	// Token: 0x04005551 RID: 21841
	private ERedDotName? RedDotName;

	// Token: 0x04005552 RID: 21842
	[Nullable(2)]
	private Action<int> ButtonFunction;

	// Token: 0x02007C0E RID: 31758
	[NullableContext(0)]
	private class EButtonItemDefine
	{
		// Token: 0x0402A621 RID: 173601
		public const int Button = 0;

		// Token: 0x0402A622 RID: 173602
		public const int ButtonText = 1;

		// Token: 0x0402A623 RID: 173603
		public const int RedDot = 2;

		// Token: 0x0402A624 RID: 173604
		public const int TextureCost = 3;

		// Token: 0x0402A625 RID: 173605
		public const int TextCost = 4;
	}
}
