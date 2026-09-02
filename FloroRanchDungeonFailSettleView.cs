using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C2C RID: 7212
public class FloroRanchDungeonFailSettleView : UiViewBase
{
	// Token: 0x0600D1C2 RID: 53698 RVA: 0x0037AE44 File Offset: 0x00379044
	[NullableContext(1)]
	public FloroRanchDungeonFailSettleView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D1C3 RID: 53699 RVA: 0x0037AE50 File Offset: 0x00379050
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickReChallengeButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickExitGameButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D1C4 RID: 53700 RVA: 0x0037AF3C File Offset: 0x0037913C
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchDungeonFailSettleView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchDungeonFailSettleView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1C5 RID: 53701 RVA: 0x0037AF7F File Offset: 0x0037917F
	private void OnClickReChallengeButton()
	{
		ModelBase<FloroRanchGamePlayModel>.Instance.ReStartGame();
	}

	// Token: 0x0600D1C6 RID: 53702 RVA: 0x0037AF8B File Offset: 0x0037918B
	private void OnClickExitGameButton()
	{
		ModelBase<FloroRanchGamePlayModel>.Instance.ExitGame(true);
	}

	// Token: 0x02007F0E RID: 32526
	private class EComponent
	{
		// Token: 0x0402B3B0 RID: 177072
		public const int DungeonSettleItem = 0;

		// Token: 0x0402B3B1 RID: 177073
		public const int ReChallengeButton = 1;

		// Token: 0x0402B3B2 RID: 177074
		public const int ExitGameButton = 2;
	}
}
