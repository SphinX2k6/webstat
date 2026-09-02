using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B64 RID: 7012
public class ExploreLevelRewardView : UiViewBase
{
	// Token: 0x0600CB1D RID: 51997 RVA: 0x00362ABE File Offset: 0x00360CBE
	[NullableContext(1)]
	public ExploreLevelRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600CB1E RID: 51998 RVA: 0x00362AC8 File Offset: 0x00360CC8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickCloseButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CB1F RID: 51999 RVA: 0x00362BF4 File Offset: 0x00360DF4
	protected override UniTask OnBeforeStartAsync()
	{
		ExploreLevelRewardView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ExploreLevelRewardView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600CB20 RID: 52000 RVA: 0x00362C37 File Offset: 0x00360E37
	protected override void OnBeforeDestroy()
	{
		this.RewardItemList = null;
	}

	// Token: 0x0600CB21 RID: 52001 RVA: 0x00362C40 File Offset: 0x00360E40
	protected override void OnAfterDestroy()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnExploreRewardShowEnd);
	}

	// Token: 0x0600CB22 RID: 52002 RVA: 0x00362C52 File Offset: 0x00360E52
	private void OnClickCloseButton()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreLevelRewardView, null);
	}

	// Token: 0x0400611E RID: 24862
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private RewardData<IExploreLevelRewardInfo> RewardData;

	// Token: 0x0400611F RID: 24863
	[Nullable(2)]
	private RewardItemList RewardItemList;

	// Token: 0x02007E50 RID: 32336
	private enum EChildType
	{
		// Token: 0x0402B080 RID: 176256
		ExploreLevelTexture,
		// Token: 0x0402B081 RID: 176257
		ExploreLevelNameText,
		// Token: 0x0402B082 RID: 176258
		RewardListItem,
		// Token: 0x0402B083 RID: 176259
		CloseButton,
		// Token: 0x0402B084 RID: 176260
		CurrentLevelText,
		// Token: 0x0402B085 RID: 176261
		TargetLevelText
	}
}
