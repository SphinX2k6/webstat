using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001079 RID: 4217
public class FurnitureAreaLockTipItem : UiPanelBase
{
	// Token: 0x06006DAC RID: 28076 RVA: 0x001C83A4 File Offset: 0x001C65A4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnJumpButtonClick))
		};
	}

	// Token: 0x06006DAD RID: 28077 RVA: 0x001C8421 File Offset: 0x001C6621
	[NullableContext(1)]
	public void Refresh(string content, Action jumpCallback)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), content, Array.Empty<object>());
		this.JumpCallback = jumpCallback;
	}

	// Token: 0x06006DAE RID: 28078 RVA: 0x001C8441 File Offset: 0x001C6641
	private void OnJumpButtonClick()
	{
		Action jumpCallback = this.JumpCallback;
		if (jumpCallback == null)
		{
			return;
		}
		jumpCallback();
	}

	// Token: 0x04003406 RID: 13318
	[Nullable(2)]
	private Action JumpCallback;
}
