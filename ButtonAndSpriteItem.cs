using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001895 RID: 6293
[NullableContext(1)]
[Nullable(0)]
public class ButtonAndSpriteItem : UiPanelBase
{
	// Token: 0x0600B493 RID: 46227 RVA: 0x00301C49 File Offset: 0x002FFE49
	public ButtonAndSpriteItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B494 RID: 46228 RVA: 0x00301C60 File Offset: 0x002FFE60
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISpriteTransition));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B495 RID: 46229 RVA: 0x00301D28 File Offset: 0x002FFF28
	public void RefreshSprite(string spritePath)
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(spritePath);
		this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, new Action<bool>(this.RefreshAllTransitionSprite));
	}

	// Token: 0x0600B496 RID: 46230 RVA: 0x00301D68 File Offset: 0x002FFF68
	public void RefreshAllTransitionSprite(bool arg)
	{
		UUISpriteTransition uiSpriteTransition = base.GetUiSpriteTransition(2);
		if (uiSpriteTransition != null)
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				uiSpriteTransition.SetAllTransitionSprite(sprite.GetSprite());
			}
		}
	}

	// Token: 0x0600B497 RID: 46231 RVA: 0x00301D97 File Offset: 0x002FFF97
	public void RefreshEnable(bool isEnable)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(isEnable);
	}

	// Token: 0x0600B498 RID: 46232 RVA: 0x00301DAB File Offset: 0x002FFFAB
	public void BindCallback(Action onCallback)
	{
		this.OnCallback = onCallback;
	}

	// Token: 0x0600B499 RID: 46233 RVA: 0x00301DB4 File Offset: 0x002FFFB4
	private void OnClick()
	{
		if (this.OnCallback != null)
		{
			this.OnCallback();
		}
	}

	// Token: 0x04005553 RID: 21843
	[Nullable(2)]
	private Action OnCallback;

	// Token: 0x02007C10 RID: 31760
	[NullableContext(0)]
	private class EButtonItemDefine
	{
		// Token: 0x0402A62B RID: 173611
		public const int Button = 0;

		// Token: 0x0402A62C RID: 173612
		public const int Sprite = 1;

		// Token: 0x0402A62D RID: 173613
		public const int SpriteTransition = 2;
	}
}
