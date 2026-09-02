using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200162B RID: 5675
[NullableContext(1)]
[Nullable(0)]
public class VersionPreheatVoteView : UiViewBase
{
	// Token: 0x06009FFA RID: 40954 RVA: 0x0029D1E9 File Offset: 0x0029B3E9
	public VersionPreheatVoteView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06009FFB RID: 40955 RVA: 0x0029D1F4 File Offset: 0x0029B3F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.HandleOnClickExit));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009FFC RID: 40956 RVA: 0x0029D384 File Offset: 0x0029B584
	protected override UniTask OnBeforeStartAsync()
	{
		VersionPreheatVoteView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VersionPreheatVoteView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009FFD RID: 40957 RVA: 0x0029D3C7 File Offset: 0x0029B5C7
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.VersionPreheatRewardResponse, new Action<int>(this.HandleVersionPreheatRewardResponse));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.VersionPreheatOnClickVote, new Action<bool>(this.HandleVersionPreheatOnClickVote));
	}

	// Token: 0x06009FFE RID: 40958 RVA: 0x0029D401 File Offset: 0x0029B601
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.VersionPreheatRewardResponse, new <>f__AnonymousDelegate2<int>(this.HandleVersionPreheatRewardResponse));
		Singleton<EventSystem>.Instance.Remove(EEventName.VersionPreheatOnClickVote, new Action<bool>(this.HandleVersionPreheatOnClickVote));
	}

	// Token: 0x06009FFF RID: 40959 RVA: 0x0029D43B File Offset: 0x0029B63B
	private void HandleOnClickExit()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600A000 RID: 40960 RVA: 0x0029D444 File Offset: 0x0029B644
	private void HandleVersionPreheatRewardResponse(int i = 0)
	{
		base.CloseMe(null);
	}

	// Token: 0x0600A001 RID: 40961 RVA: 0x0029D44D File Offset: 0x0029B64D
	private void HandleVersionPreheatOnClickVote(bool isLeft)
	{
		this.LeftToggle.RefreshToggle(isLeft);
		this.RightToggle.RefreshToggle(!isLeft);
	}

	// Token: 0x0600A002 RID: 40962 RVA: 0x0029D46A File Offset: 0x0029B66A
	private CommonItemSmallItemGrid GridProxyCreateFunction()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600A003 RID: 40963 RVA: 0x0029D474 File Offset: 0x0029B674
	public void RefreshExternal(VersionPreheatVoteData data)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.TitleTextId, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.ContentTextId, Array.Empty<object>());
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(data.CrestIndex == 0);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetUIActive(data.CrestIndex == 1);
		}
		this.LeftToggle.RefreshExternal(data.LeftToggleData);
		this.RightToggle.RefreshExternal(data.RightToggleData);
		this.ItemLayout.RefreshByData(data.ItemListData, null, false);
		if (data.IsLeftChosen == null)
		{
			this.LeftToggle.RefreshToggleDirectly(false);
			this.RightToggle.RefreshToggleDirectly(false);
			return;
		}
		this.HandleVersionPreheatOnClickVote(data.IsLeftChosen.Value);
	}

	// Token: 0x04004979 RID: 18809
	private VersionPreheatToggleItem LeftToggle;

	// Token: 0x0400497A RID: 18810
	private VersionPreheatToggleItem RightToggle;

	// Token: 0x0400497B RID: 18811
	private GenericLayout<CommonItemSmallItemGrid, TItem> ItemLayout;

	// Token: 0x020079E7 RID: 31207
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04029DA5 RID: 171429
		public const int Crest1Item = 0;

		// Token: 0x04029DA6 RID: 171430
		public const int Crest2Item = 1;

		// Token: 0x04029DA7 RID: 171431
		public const int TitleText = 2;

		// Token: 0x04029DA8 RID: 171432
		public const int ContentText = 3;

		// Token: 0x04029DA9 RID: 171433
		public const int LeftToggleItem = 4;

		// Token: 0x04029DAA RID: 171434
		public const int RightToggleItem = 5;

		// Token: 0x04029DAB RID: 171435
		public const int ItemLayout = 6;

		// Token: 0x04029DAC RID: 171436
		public const int ItemTemplateItem = 7;

		// Token: 0x04029DAD RID: 171437
		public const int ExitButton = 8;
	}
}
