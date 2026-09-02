using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001343 RID: 4931
public class InviteNewbieRewardItem : UiPanelBase
{
	// Token: 0x060086B3 RID: 34483 RVA: 0x002378C0 File Offset: 0x00235AC0
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickRewardButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060086B4 RID: 34484 RVA: 0x00237987 File Offset: 0x00235B87
	[NullableContext(1)]
	public void SetActivityData(InviteNewbieProtocolContext data)
	{
		this.CurrentData = data;
	}

	// Token: 0x060086B5 RID: 34485 RVA: 0x00237990 File Offset: 0x00235B90
	private void OnClickRewardButton()
	{
		ControllerBase<ActivityInviteNewbieController>.Instance.HandleOnRewardClick(this.CurrentData);
	}

	// Token: 0x060086B6 RID: 34486 RVA: 0x002379A2 File Offset: 0x00235BA2
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x060086B7 RID: 34487 RVA: 0x002379B6 File Offset: 0x00235BB6
	[NullableContext(1)]
	public void RefreshByDataExternal(string textId, string score)
	{
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), textId, new <>z__ReadOnlySingleElementList<object>(score));
	}

	// Token: 0x04003FA2 RID: 16290
	[Nullable(2)]
	private InviteNewbieProtocolContext CurrentData;

	// Token: 0x020076E6 RID: 30438
	private class EComponent
	{
		// Token: 0x04028F2E RID: 167726
		public const int ConfirmButton = 0;

		// Token: 0x04028F2F RID: 167727
		public const int ScoreText = 1;

		// Token: 0x04028F30 RID: 167728
		public const int RedDotItem = 2;
	}
}
