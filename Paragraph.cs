using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EBB RID: 7867
public class Paragraph : UiPanelBase
{
	// Token: 0x0600E894 RID: 59540 RVA: 0x003EE48C File Offset: 0x003EC68C
	[NullableContext(2)]
	public Paragraph(AActor commonItemActor = null)
	{
		if (commonItemActor != null)
		{
			base.CreateThenShowByActor(commonItemActor, null);
		}
	}

	// Token: 0x0600E895 RID: 59541 RVA: 0x003EE4A0 File Offset: 0x003EC6A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E896 RID: 59542 RVA: 0x003EE50C File Offset: 0x003EC70C
	public void Refresh(HelpText helpTextConfig)
	{
		if (helpTextConfig.Picture == string.Empty)
		{
			base.GetTexture(0).SetUIActive(false);
		}
		else
		{
			base.SetTextureByPath(helpTextConfig.Picture, base.GetTexture(0), null, null);
		}
		if (string.IsNullOrEmpty(helpTextConfig.Content))
		{
			base.GetText(1).SetUIActive(false);
			return;
		}
		base.GetText(1).ShowTextNew(helpTextConfig.Content);
	}

	// Token: 0x020081FE RID: 33278
	private enum EParagraphComponents
	{
		// Token: 0x0402C18C RID: 180620
		Image,
		// Token: 0x0402C18D RID: 180621
		Text
	}
}
