using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200175C RID: 5980
public class NewSoundTypeTagItem : UiPanelBase
{
	// Token: 0x0600A812 RID: 43026 RVA: 0x002CC2C8 File Offset: 0x002CA4C8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A813 RID: 43027 RVA: 0x002CC334 File Offset: 0x002CA534
	public void RefreshItem(bool isActivity)
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(isActivity ? "SP_TagFrameBgOrange" : "SP_TagFrameBgYellow");
		this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
		base.GetText(1).SetColor(FColor.FromHex(isActivity ? "#312844" : "#232F2C"));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), isActivity ? "MaterialAcitivityTag" : "PrefabTextItem_4042540642_Text", Array.Empty<object>());
	}

	// Token: 0x02007AC1 RID: 31425
	private enum ENodeDefine
	{
		// Token: 0x0402A0C4 RID: 172228
		BgSprite,
		// Token: 0x0402A0C5 RID: 172229
		Text
	}
}
