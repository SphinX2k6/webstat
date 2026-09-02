using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200101F RID: 4127
public class DrinksQTEButton : UiPanelBase
{
	// Token: 0x06006B63 RID: 27491 RVA: 0x001C1E74 File Offset: 0x001C0074
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickedBtn))
		};
	}

	// Token: 0x06006B64 RID: 27492 RVA: 0x001C1EDB File Offset: 0x001C00DB
	protected override void OnStart()
	{
		this.SetSelfActive(true);
	}

	// Token: 0x06006B65 RID: 27493 RVA: 0x001C1EE4 File Offset: 0x001C00E4
	public void SetSelfActive(bool isActive)
	{
		UUISprite sprite = base.GetSprite(1);
		if (sprite != null)
		{
			sprite.SetFillAmount(isActive > false);
		}
		this.CanClick = isActive;
		UUIButtonComponent button = base.GetButton(0);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(isActive);
	}

	// Token: 0x06006B66 RID: 27494 RVA: 0x001C1F16 File Offset: 0x001C0116
	public void OnTick(float percent)
	{
		UUISprite sprite = base.GetSprite(1);
		if (sprite != null)
		{
			sprite.SetFillAmount(Math.Max(0f, percent));
		}
		if (percent <= 0f)
		{
			this.OnClickedBtn();
		}
	}

	// Token: 0x06006B67 RID: 27495 RVA: 0x001C1F43 File Offset: 0x001C0143
	public void OnClickedBtn()
	{
		if (this.OnClickedCb != null && this.CanClick)
		{
			this.CanClick = false;
			this.OnClickedCb();
		}
	}

	// Token: 0x04003307 RID: 13063
	[Nullable(2)]
	public Action OnClickedCb;

	// Token: 0x04003308 RID: 13064
	protected bool CanClick;

	// Token: 0x02007402 RID: 29698
	private static class EBtn
	{
		// Token: 0x040281FA RID: 164346
		public const int Btn = 0;

		// Token: 0x040281FB RID: 164347
		public const int SpriteBar = 1;
	}
}
