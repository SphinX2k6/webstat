using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C2B RID: 7211
public class FloroRanchDungeonEndlessSettleView : UiViewBase
{
	// Token: 0x0600D1BD RID: 53693 RVA: 0x0037ACF2 File Offset: 0x00378EF2
	[NullableContext(1)]
	public FloroRanchDungeonEndlessSettleView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D1BE RID: 53694 RVA: 0x0037ACFC File Offset: 0x00378EFC
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
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnExitGameButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D1BF RID: 53695 RVA: 0x0037ADE8 File Offset: 0x00378FE8
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchDungeonEndlessSettleView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchDungeonEndlessSettleView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1C0 RID: 53696 RVA: 0x0037AE2B File Offset: 0x0037902B
	private void OnClickReChallengeButton()
	{
		ModelBase<FloroRanchGamePlayModel>.Instance.ReStartGame();
	}

	// Token: 0x0600D1C1 RID: 53697 RVA: 0x0037AE37 File Offset: 0x00379037
	private void OnExitGameButton()
	{
		ModelBase<FloroRanchGamePlayModel>.Instance.ExitGame(true);
	}

	// Token: 0x02007F0C RID: 32524
	private class EComponent
	{
		// Token: 0x0402B3A7 RID: 177063
		public const int DungeonSettleItem = 0;

		// Token: 0x0402B3A8 RID: 177064
		public const int ReChallengeButton = 1;

		// Token: 0x0402B3A9 RID: 177065
		public const int ExitGameButton = 2;
	}
}
