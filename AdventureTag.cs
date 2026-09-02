using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020014EF RID: 5359
internal class AdventureTag : UiPanelBase
{
	// Token: 0x060095F6 RID: 38390 RVA: 0x0027241C File Offset: 0x0027061C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x060095F7 RID: 38391 RVA: 0x00272458 File Offset: 0x00270658
	public void RefreshItem(bool isActivity)
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(isActivity ? "SP_TagFrameBgOrange" : "SP_TagFrameBgYellow");
		this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), isActivity ? "Regress_Adventure_Tag_Activity" : "Regress_Adventure_Tag_PreOpen", Array.Empty<object>());
	}
}
