using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B0E RID: 6926
internal class ProgressPanel : UiPanelBase
{
	// Token: 0x0600C785 RID: 51077 RVA: 0x0034C65C File Offset: 0x0034A85C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite))
		};
	}

	// Token: 0x0600C786 RID: 51078 RVA: 0x0034C6B8 File Offset: 0x0034A8B8
	[NullableContext(1)]
	public void Refresh(DangoAbyssActivityData data)
	{
		string abyssWorldProgressText = data.GetAbyssWorldProgressText();
		base.GetText(1).SetText(abyssWorldProgressText, true);
		float abyssWorldProgressPercentage = data.GetAbyssWorldProgressPercentage();
		base.GetSprite(2).SetFillAmount(abyssWorldProgressPercentage);
	}
}
