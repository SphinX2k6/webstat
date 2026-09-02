using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020015D7 RID: 5591
internal class TowerGuideProgress : UiPanelBase
{
	// Token: 0x06009D64 RID: 40292 RVA: 0x002938EA File Offset: 0x00291AEA
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06009D65 RID: 40293 RVA: 0x00293923 File Offset: 0x00291B23
	public void Refresh(int currentProgress, int totalProgress)
	{
		base.GetText(0).SetText(currentProgress.ToString(), true);
		base.GetText(1).SetText("/" + totalProgress.ToString(), true);
	}
}
