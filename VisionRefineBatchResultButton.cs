using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001825 RID: 6181
internal class VisionRefineBatchResultButton : UiPanelBase
{
	// Token: 0x0600B00B RID: 45067 RVA: 0x002EECAC File Offset: 0x002ECEAC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClick))
		};
	}

	// Token: 0x0600B00C RID: 45068 RVA: 0x002EED29 File Offset: 0x002ECF29
	[NullableContext(1)]
	public void SetText(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, Array.Empty<object>());
	}

	// Token: 0x0600B00D RID: 45069 RVA: 0x002EED42 File Offset: 0x002ECF42
	private void OnClick()
	{
		if (this.OnClickCallback != null)
		{
			this.OnClickCallback();
		}
	}

	// Token: 0x04005379 RID: 21369
	[Nullable(2)]
	public Action OnClickCallback;
}
