using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200123F RID: 4671
[NullableContext(2)]
[Nullable(0)]
public class TogTabItemSubComponent : UiPanelBase
{
	// Token: 0x06007C76 RID: 31862 RVA: 0x0020BE60 File Offset: 0x0020A060
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007C77 RID: 31863 RVA: 0x0020BECC File Offset: 0x0020A0CC
	protected override void OnStart()
	{
		UUIExtendToggle tabToggle = this.GetTabToggle();
		if (tabToggle != null)
		{
			tabToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChangeHandler));
		}
		UUIText tabText = this.GetTabText();
		if (tabText != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(tabText, "BabelRanking_Anonymouskey", Array.Empty<object>());
		}
	}

	// Token: 0x06007C78 RID: 31864 RVA: 0x0020BF19 File Offset: 0x0020A119
	private void OnToggleStateChangeHandler(EToggleState state)
	{
		Action<EToggleState> onToggleStateChange = this.OnToggleStateChange;
		if (onToggleStateChange == null)
		{
			return;
		}
		onToggleStateChange(state);
	}

	// Token: 0x06007C79 RID: 31865 RVA: 0x0020BF2C File Offset: 0x0020A12C
	public UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x06007C7A RID: 31866 RVA: 0x0020BF35 File Offset: 0x0020A135
	public UUIText GetTabText()
	{
		return base.GetText(1);
	}

	// Token: 0x06007C7B RID: 31867 RVA: 0x0020BF40 File Offset: 0x0020A140
	public void SetToggleState(EToggleState state)
	{
		UUIExtendToggle tabToggle = this.GetTabToggle();
		if (tabToggle != null)
		{
			tabToggle.SetToggleState(state, false, false, false);
		}
	}

	// Token: 0x04003B90 RID: 15248
	public Action<EToggleState> OnToggleStateChange;

	// Token: 0x020075AE RID: 30126
	[NullableContext(0)]
	private class ETogTabItem
	{
		// Token: 0x04028997 RID: 166295
		public const int TogTabItem = 0;

		// Token: 0x04028998 RID: 166296
		public const int TogIText = 1;
	}
}
