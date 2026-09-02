using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001629 RID: 5673
public class VersionPreheatButton : UiPanelBase
{
	// Token: 0x06009FF3 RID: 40947 RVA: 0x0029CF88 File Offset: 0x0029B188
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.HandleOnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009FF4 RID: 40948 RVA: 0x0029D04F File Offset: 0x0029B24F
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_RoleQuestGoto_Text", Array.Empty<object>());
	}

	// Token: 0x06009FF5 RID: 40949 RVA: 0x0029D07F File Offset: 0x0029B27F
	private void HandleOnClick()
	{
		if (this.ClickRewardFunc != null && this.ClickRewardPassData != null)
		{
			this.ClickRewardFunc(this.ClickRewardPassData.Value);
		}
	}

	// Token: 0x04004977 RID: 18807
	[Nullable(1)]
	public TVersionPreheatQuestDetailClickFunc ClickRewardFunc;

	// Token: 0x04004978 RID: 18808
	public int? ClickRewardPassData;

	// Token: 0x020079E5 RID: 31205
	private class EButtonComponent
	{
		// Token: 0x04029D9E RID: 171422
		public const int RootButton = 0;

		// Token: 0x04029D9F RID: 171423
		public const int ConfirmText = 1;

		// Token: 0x04029DA0 RID: 171424
		public const int RedDotItem = 2;
	}
}
