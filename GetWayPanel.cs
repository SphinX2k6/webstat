using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024C4 RID: 9412
[NullableContext(1)]
[Nullable(0)]
internal class GetWayPanel : UiPanelBase
{
	// Token: 0x0601247C RID: 74876 RVA: 0x00506DCC File Offset: 0x00504FCC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClicked))
		};
	}

	// Token: 0x0601247D RID: 74877 RVA: 0x00506E49 File Offset: 0x00505049
	private void OnButtonClicked()
	{
		if (this.ButtonFunction != null)
		{
			this.ButtonFunction();
		}
	}

	// Token: 0x0601247E RID: 74878 RVA: 0x00506E5E File Offset: 0x0050505E
	public void SetButtonFunction(Action func)
	{
		this.ButtonFunction = func;
	}

	// Token: 0x0601247F RID: 74879 RVA: 0x00506E68 File Offset: 0x00505068
	public void SetText(string textId)
	{
		UUIText text = base.GetText(2);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textId, Array.Empty<object>());
	}

	// Token: 0x04008E99 RID: 36505
	[Nullable(2)]
	private Action ButtonFunction;
}
