using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001624 RID: 5668
[NullableContext(1)]
[Nullable(0)]
internal class VersionPreheatBonusItem : UiPanelBase
{
	// Token: 0x06009FD0 RID: 40912 RVA: 0x0029BE84 File Offset: 0x0029A084
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.HandleOnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009FD1 RID: 40913 RVA: 0x0029BFD0 File Offset: 0x0029A1D0
	protected override UniTask OnBeforeStartAsync()
	{
		VersionPreheatBonusItem.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VersionPreheatBonusItem.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009FD2 RID: 40914 RVA: 0x0029C014 File Offset: 0x0029A214
	public UniTask RefreshExternalAsync(VersionPreheatBonusData data)
	{
		VersionPreheatBonusItem.<RefreshExternalAsync>d__3 <RefreshExternalAsync>d__;
		<RefreshExternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshExternalAsync>d__.<>4__this = this;
		<RefreshExternalAsync>d__.<>1__state = -1;
		<RefreshExternalAsync>d__.<>t__builder.Start<VersionPreheatBonusItem.<RefreshExternalAsync>d__3>(ref <RefreshExternalAsync>d__);
		return <RefreshExternalAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009FD3 RID: 40915 RVA: 0x0029C058 File Offset: 0x0029A258
	private void RefreshWhenActive()
	{
		base.GetRootItem().SetUIActive(true);
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		UUIText text2 = base.GetText(4);
		if (text2 != null)
		{
			text2.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 != null)
		{
			item2.SetUIActive(ModelBase<VersionPreheatModel>.Instance.IsBonusClicked());
		}
		UUIItem item3 = base.GetItem(6);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(!ModelBase<VersionPreheatModel>.Instance.IsBonusClicked());
	}

	// Token: 0x06009FD4 RID: 40916 RVA: 0x0029C0E4 File Offset: 0x0029A2E4
	private void HandleOnClick()
	{
		ModelBase<VersionPreheatModel>.Instance.SetBonusClicked();
		ControllerBase<ActivityVersionPreheatController>.Instance.OpenTargetViewAsyncById(null, false);
		ControllerBase<ActivityVersionPreheatController>.Instance.SendDetailClickLogData(null);
	}

	// Token: 0x0400496C RID: 18796
	private UiSequencePlayer Player;
}
