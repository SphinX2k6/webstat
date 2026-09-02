using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001077 RID: 4215
public class FurnitureAreaFinishTipItem : UiPanelBase
{
	// Token: 0x06006DA9 RID: 28073 RVA: 0x001C8348 File Offset: 0x001C6548
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06006DAA RID: 28074 RVA: 0x001C8381 File Offset: 0x001C6581
	[NullableContext(1)]
	public void Refresh(string content)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), content, Array.Empty<object>());
	}
}
