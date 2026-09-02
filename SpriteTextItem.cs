using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001AE2 RID: 6882
[NullableContext(1)]
[Nullable(0)]
internal class SpriteTextItem : UiPanelBase
{
	// Token: 0x0600C60B RID: 50699 RVA: 0x00344DF0 File Offset: 0x00342FF0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600C60C RID: 50700 RVA: 0x00344E4A File Offset: 0x0034304A
	public void SetTitle(string title)
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(title, true);
	}

	// Token: 0x0600C60D RID: 50701 RVA: 0x00344E5F File Offset: 0x0034305F
	public void SetDesc(string desc)
	{
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText(desc, true);
	}
}
