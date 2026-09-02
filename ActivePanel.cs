using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024C7 RID: 9415
internal class ActivePanel : UiPanelBase
{
	// Token: 0x06012485 RID: 74885 RVA: 0x00506FA3 File Offset: 0x005051A3
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06012486 RID: 74886 RVA: 0x00506FC6 File Offset: 0x005051C6
	[NullableContext(1)]
	public void SetText(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, Array.Empty<object>());
	}
}
