using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002C20 RID: 11296
public class TutorialPageItem : UiPanelBase
{
	// Token: 0x060169C5 RID: 92613 RVA: 0x0064650C File Offset: 0x0064470C
	[NullableContext(1)]
	public TutorialPageItem(UUIItem UUIItem)
	{
		this.UUIItem = UUIItem;
	}

	// Token: 0x060169C6 RID: 92614 RVA: 0x0064651B File Offset: 0x0064471B
	public void Init()
	{
		base.CreateThenShowByActor(this.UUIItem.GetOwner(), null);
	}

	// Token: 0x060169C7 RID: 92615 RVA: 0x0064652F File Offset: 0x0064472F
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x060169C8 RID: 92616 RVA: 0x0064655D File Offset: 0x0064475D
	public void UpdateShow(bool isShow)
	{
		base.GetItem(0).SetUIActive(isShow);
	}

	// Token: 0x0400AE7F RID: 44671
	[Nullable(2)]
	private readonly UUIItem UUIItem;

	// Token: 0x02008F49 RID: 36681
	private enum EPagesDotComponents
	{
		// Token: 0x040301EB RID: 197099
		SprDot
	}
}
