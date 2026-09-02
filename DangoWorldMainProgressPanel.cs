using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B11 RID: 6929
internal class DangoWorldMainProgressPanel : UiPanelBase
{
	// Token: 0x0600C79C RID: 51100 RVA: 0x0034CB64 File Offset: 0x0034AD64
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x0600C79D RID: 51101 RVA: 0x0034CBC0 File Offset: 0x0034ADC0
	[NullableContext(1)]
	public void Refresh(DangoAbyssActivityData data)
	{
		string abyssWorldProgressText = data.GetAbyssWorldProgressText();
		base.GetText(1).SetText(abyssWorldProgressText, true);
		float abyssWorldProgressPercentage = data.GetAbyssWorldProgressPercentage();
		base.GetTexture(2).SetFillAmount(abyssWorldProgressPercentage);
	}
}
