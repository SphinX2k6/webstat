using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C5C RID: 7260
public class FloroRanchEntityDebugInfoItem : UiPanelBase
{
	// Token: 0x0600D3E6 RID: 54246 RVA: 0x00387B38 File Offset: 0x00385D38
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D3E7 RID: 54247 RVA: 0x00387B80 File Offset: 0x00385D80
	[NullableContext(2)]
	public void Refresh(FloroRanchEntityBase entity)
	{
		UUIText text = base.GetText(0);
		if (entity == null)
		{
			text.SetUIActive(false);
			return;
		}
		text.SetUIActive(true);
		text.SetText(entity.DebugUiShowInfo(), true);
	}

	// Token: 0x02007F70 RID: 32624
	private class EComponent
	{
		// Token: 0x0402B633 RID: 177715
		public const int InfoText = 0;
	}
}
