using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001AE6 RID: 6886
[NullableContext(1)]
[Nullable(0)]
internal class DescItem : UiPanelBase
{
	// Token: 0x0600C616 RID: 50710 RVA: 0x00344FB0 File Offset: 0x003431B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x0600C617 RID: 50711 RVA: 0x00345020 File Offset: 0x00343220
	protected override void OnStart()
	{
	}

	// Token: 0x0600C618 RID: 50712 RVA: 0x00345022 File Offset: 0x00343222
	public void SetTitle(string title)
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(title, true);
	}

	// Token: 0x0600C619 RID: 50713 RVA: 0x00345037 File Offset: 0x00343237
	public void SetDesc(string desc)
	{
		UUIText text = base.GetText(3);
		if (text == null)
		{
			return;
		}
		text.SetText(desc, true);
	}
}
