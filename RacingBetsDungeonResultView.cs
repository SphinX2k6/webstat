using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200273A RID: 10042
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsDungeonResultView : UiViewBase
{
	// Token: 0x06013CE6 RID: 81126 RVA: 0x005833CE File Offset: 0x005815CE
	public RacingBetsDungeonResultView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013CE7 RID: 81127 RVA: 0x005833D8 File Offset: 0x005815D8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClickCloseButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013CE8 RID: 81128 RVA: 0x005834E4 File Offset: 0x005816E4
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsDungeonResultView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsDungeonResultView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013CE9 RID: 81129 RVA: 0x00583527 File Offset: 0x00581727
	protected override void OnStart()
	{
		UUIInturnAnimController uuiinturnAnimController = base.GetVerticalLayout(1).GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
		if (uuiinturnAnimController == null)
		{
			return;
		}
		uuiinturnAnimController.Play("", -1, false);
	}

	// Token: 0x06013CEA RID: 81130 RVA: 0x0058355C File Offset: 0x0058175C
	protected override void OnBeforeDestroy()
	{
		this.Promise.SetResult(default(UniTaskVoid));
	}

	// Token: 0x06013CEB RID: 81131 RVA: 0x0058357D File Offset: 0x0058177D
	private RacingBetsLegMatchResultItem ResultItemProxyCreate()
	{
		return new RacingBetsLegMatchResultItem();
	}

	// Token: 0x06013CEC RID: 81132 RVA: 0x00583584 File Offset: 0x00581784
	private void OnClickCloseButton(EToggleState state)
	{
		base.CloseMe(null);
	}

	// Token: 0x04009A1F RID: 39455
	private GenericLayout<RacingBetsLegMatchResultItem, IRacingBetsLegMatchResultData> MatchResultLayout;

	// Token: 0x04009A20 RID: 39456
	private CustomPromise<UniTaskVoid> Promise;

	// Token: 0x02008AE9 RID: 35561
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402ED61 RID: 191841
		LegMatchName,
		// Token: 0x0402ED62 RID: 191842
		MatchResultLayout,
		// Token: 0x0402ED63 RID: 191843
		ResultItem,
		// Token: 0x0402ED64 RID: 191844
		TimeText,
		// Token: 0x0402ED65 RID: 191845
		CloseButton
	}
}
