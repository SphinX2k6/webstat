using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001819 RID: 6169
public class VisionRefineInvalidTips : UiPanelBase
{
	// Token: 0x0600AFBA RID: 44986 RVA: 0x002ED908 File Offset: 0x002EBB08
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600AFBB RID: 44987 RVA: 0x002ED994 File Offset: 0x002EBB94
	[NullableContext(1)]
	public void RefreshExternalByData(VisionRefineInvalidTipsData data)
	{
		UUIText text = base.GetText(1);
		if (data.LockDescriptionTextId != null)
		{
			if (text != null)
			{
				text.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.LockDescriptionTextId, data.LockDescriptionTextArgs);
			return;
		}
		if (text != null)
		{
			text.SetUIActive(false);
		}
	}

	// Token: 0x02007B9F RID: 31647
	private enum EComponent
	{
		// Token: 0x0402A40E RID: 173070
		LockSprite,
		// Token: 0x0402A40F RID: 173071
		LockDescriptionText,
		// Token: 0x0402A410 RID: 173072
		FunctionButton
	}
}
