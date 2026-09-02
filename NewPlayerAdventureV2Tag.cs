using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001485 RID: 5253
internal class NewPlayerAdventureV2Tag : UiPanelBase
{
	// Token: 0x06009303 RID: 37635 RVA: 0x0026CE38 File Offset: 0x0026B038
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06009304 RID: 37636 RVA: 0x0026CE74 File Offset: 0x0026B074
	public void RefreshItem(bool isActivity)
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(isActivity ? "SP_TagFrameBgOrange" : "SP_TagFrameBgYellow");
		this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), isActivity ? "Regress_Adventure_Tag_Activity" : "Regress_Adventure_Tag_PreOpen", Array.Empty<object>());
	}
}
