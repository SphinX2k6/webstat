using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E98 RID: 7832
internal class MonsterHandBookTitleItem : UiPanelBase
{
	// Token: 0x0600E78E RID: 59278 RVA: 0x003E87A8 File Offset: 0x003E69A8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x0600E78F RID: 59279 RVA: 0x003E87CB File Offset: 0x003E69CB
	[NullableContext(1)]
	public void Update(string titleText)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), titleText, Array.Empty<object>());
	}
}
