using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001605 RID: 5637
[NullableContext(1)]
[Nullable(0)]
public class FunctionalPanelConditionActivate : UiPanelBase
{
	// Token: 0x06009F26 RID: 40742 RVA: 0x002998E4 File Offset: 0x00297AE4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009F27 RID: 40743 RVA: 0x0029994D File Offset: 0x00297B4D
	public void SetTextByTextId(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
	}

	// Token: 0x06009F28 RID: 40744 RVA: 0x00299962 File Offset: 0x00297B62
	public void SetTextByText(string text)
	{
		base.GetText(1).SetText(text, true);
	}

	// Token: 0x06009F29 RID: 40745 RVA: 0x00299972 File Offset: 0x00297B72
	public UUISprite GetIconSprite()
	{
		return base.GetSprite(0);
	}

	// Token: 0x06009F2A RID: 40746 RVA: 0x0029997B File Offset: 0x00297B7B
	public void SetSpriteVisible(bool bVisible)
	{
		base.GetSprite(0).SetUIActive(bVisible);
	}

	// Token: 0x020079D0 RID: 31184
	[NullableContext(0)]
	private class ERedComponents
	{
		// Token: 0x04029D0E RID: 171278
		public const int Sprite = 0;

		// Token: 0x04029D0F RID: 171279
		public const int Txt = 1;
	}
}
