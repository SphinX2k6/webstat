using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D92 RID: 7570
public class TrapDefenseRecyclePriceItem : UiPanelBase
{
	// Token: 0x0600DF20 RID: 57120 RVA: 0x003C0911 File Offset: 0x003BEB11
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600DF21 RID: 57121 RVA: 0x003C094C File Offset: 0x003BEB4C
	public void UpdatePrice(int recyclePrice)
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("+");
		defaultInterpolatedStringHandler.AppendFormatted<int>(recyclePrice);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x02008126 RID: 33062
	private static class EDefine
	{
		// Token: 0x0402BE7C RID: 179836
		public const int Icon = 0;

		// Token: 0x0402BE7D RID: 179837
		public const int Value = 1;
	}
}
