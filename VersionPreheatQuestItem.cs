using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001623 RID: 5667
[NullableContext(1)]
[Nullable(0)]
internal class VersionPreheatQuestItem : UiPanelBase
{
	// Token: 0x06009FC9 RID: 40905 RVA: 0x0029BBB4 File Offset: 0x00299DB4
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

	// Token: 0x06009FCA RID: 40906 RVA: 0x0029BD00 File Offset: 0x00299F00
	protected override UniTask OnBeforeStartAsync()
	{
		VersionPreheatQuestItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VersionPreheatQuestItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009FCB RID: 40907 RVA: 0x0029BD44 File Offset: 0x00299F44
	public UniTask RefreshExternalAsync(VersionPreheatQuestData data)
	{
		VersionPreheatQuestItem.<RefreshExternalAsync>d__5 <RefreshExternalAsync>d__;
		<RefreshExternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshExternalAsync>d__.<>4__this = this;
		<RefreshExternalAsync>d__.data = data;
		<RefreshExternalAsync>d__.<>1__state = -1;
		<RefreshExternalAsync>d__.<>t__builder.Start<VersionPreheatQuestItem.<RefreshExternalAsync>d__5>(ref <RefreshExternalAsync>d__);
		return <RefreshExternalAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009FCC RID: 40908 RVA: 0x0029BD90 File Offset: 0x00299F90
	private void RefreshWhenUnlock(VersionPreheatQuestData data)
	{
		UUIItem item = base.GetItem(6);
		if (item != null)
		{
			item.SetUIActive(!ModelBase<VersionPreheatModel>.Instance.IsQuestClickedById(data.Id));
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 != null)
		{
			item2.SetUIActive(true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.NumberTextId, new <>z__ReadOnlySingleElementList<object>(data.NumberTextArg));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), data.TitleTextId, Array.Empty<object>());
		UUIItem item3 = base.GetItem(5);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(data.State == EVersionPreheatQuestState.QuestCompleted);
	}

	// Token: 0x06009FCD RID: 40909 RVA: 0x0029BE2D File Offset: 0x0029A02D
	private void HandleOnClick()
	{
		this.HandleOnClickInternalAsync();
	}

	// Token: 0x06009FCE RID: 40910 RVA: 0x0029BE38 File Offset: 0x0029A038
	private UniTask HandleOnClickInternalAsync()
	{
		VersionPreheatQuestItem.<HandleOnClickInternalAsync>d__8 <HandleOnClickInternalAsync>d__;
		<HandleOnClickInternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HandleOnClickInternalAsync>d__.<>4__this = this;
		<HandleOnClickInternalAsync>d__.<>1__state = -1;
		<HandleOnClickInternalAsync>d__.<>t__builder.Start<VersionPreheatQuestItem.<HandleOnClickInternalAsync>d__8>(ref <HandleOnClickInternalAsync>d__);
		return <HandleOnClickInternalAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0400496A RID: 18794
	private VersionPreheatQuestData PassData;

	// Token: 0x0400496B RID: 18795
	private UiSequencePlayer Player;

	// Token: 0x020079D9 RID: 31193
	[NullableContext(0)]
	internal class EItemComponent
	{
		// Token: 0x04029D42 RID: 171330
		public const int Root = 0;

		// Token: 0x04029D43 RID: 171331
		public const int LockItem = 1;

		// Token: 0x04029D44 RID: 171332
		public const int ContentRoot = 2;

		// Token: 0x04029D45 RID: 171333
		public const int ContentNumText = 3;

		// Token: 0x04029D46 RID: 171334
		public const int ContentTitleText = 4;

		// Token: 0x04029D47 RID: 171335
		public const int ContentDoneMarkItem = 5;

		// Token: 0x04029D48 RID: 171336
		public const int RedDotItem = 6;
	}
}
