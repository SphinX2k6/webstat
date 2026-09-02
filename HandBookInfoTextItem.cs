using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E6E RID: 7790
public class HandBookInfoTextItem : UiPanelBase
{
	// Token: 0x0600E659 RID: 58969 RVA: 0x003E2909 File Offset: 0x003E0B09
	[NullableContext(1)]
	public HandBookInfoTextItem(string content, UUIItem uiItem)
	{
		this.Content = content;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600E65A RID: 58970 RVA: 0x003E2925 File Offset: 0x003E0B25
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x0600E65B RID: 58971 RVA: 0x003E2948 File Offset: 0x003E0B48
	protected override void OnStart()
	{
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.SetText(this.Content, true);
	}

	// Token: 0x04006F17 RID: 28439
	[Nullable(1)]
	public string Content;

	// Token: 0x020081BC RID: 33212
	private class EHandBookInfoTextItemDefine
	{
		// Token: 0x0402C06E RID: 180334
		public const int TitleText = 0;
	}
}
