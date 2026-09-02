using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001892 RID: 6290
public class ActiveGreenItem : UiPanelBase
{
	// Token: 0x0600B477 RID: 46199 RVA: 0x003017B5 File Offset: 0x002FF9B5
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600B478 RID: 46200 RVA: 0x003017EE File Offset: 0x002FF9EE
	[NullableContext(1)]
	public void SetText(string text)
	{
		UUIText text2 = base.GetText(1);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(text, true);
	}

	// Token: 0x02007C0C RID: 31756
	private enum EComponent
	{
		// Token: 0x0402A61B RID: 173595
		Sprite,
		// Token: 0x0402A61C RID: 173596
		Desc
	}
}
