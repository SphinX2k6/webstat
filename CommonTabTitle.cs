using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A5C RID: 6748
public class CommonTabTitle : UiPanelBase
{
	// Token: 0x0600C0E3 RID: 49379 RVA: 0x0032DC8C File Offset: 0x0032BE8C
	[NullableContext(1)]
	public CommonTabTitle(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600C0E4 RID: 49380 RVA: 0x0032DCA1 File Offset: 0x0032BEA1
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600C0E5 RID: 49381 RVA: 0x0032DCDC File Offset: 0x0032BEDC
	[NullableContext(1)]
	public void UpdateIcon(string iconPath)
	{
		this.SetSpriteByPath(iconPath, base.GetSprite(0), false, null, null);
	}

	// Token: 0x0600C0E6 RID: 49382 RVA: 0x0032DD04 File Offset: 0x0032BF04
	[NullableContext(2)]
	public void UpdateTitle(CommonTabTitleData titleData)
	{
		UUIText text = base.GetText(1);
		if (titleData != null)
		{
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, titleData.TextId, titleData.Args);
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x02007D0D RID: 32013
	private class ECommonTabTitle
	{
		// Token: 0x0402AA3F RID: 174655
		public const int Icon = 0;

		// Token: 0x0402AA40 RID: 174656
		public const int Title = 1;
	}
}
