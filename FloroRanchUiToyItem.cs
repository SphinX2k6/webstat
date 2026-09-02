using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C7A RID: 7290
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchUiToyItem : FloroRanchUiItemBase
{
	// Token: 0x0600D4F9 RID: 54521 RVA: 0x0038D67C File Offset: 0x0038B87C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 17;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D4FA RID: 54522 RVA: 0x0038D91A File Offset: 0x0038BB1A
	protected override void OnBeforeCreate()
	{
		this.UiLevelSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiLevelSequence);
	}

	// Token: 0x0600D4FB RID: 54523 RVA: 0x0038D934 File Offset: 0x0038BB34
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchUiToyItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchUiToyItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4FC RID: 54524 RVA: 0x0038D978 File Offset: 0x0038BB78
	public override UniTask RefreshItem()
	{
		FloroRanchUiToyItem.<RefreshItem>d__8 <RefreshItem>d__;
		<RefreshItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshItem>d__.<>4__this = this;
		<RefreshItem>d__.<>1__state = -1;
		<RefreshItem>d__.<>t__builder.Start<FloroRanchUiToyItem.<RefreshItem>d__8>(ref <RefreshItem>d__);
		return <RefreshItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4FD RID: 54525 RVA: 0x0038D9BB File Offset: 0x0038BBBB
	public override FTransform? GetRewardPopTransform()
	{
		return new FTransform?(base.GetRootActor().GetTransform());
	}

	// Token: 0x0600D4FE RID: 54526 RVA: 0x0038D9D0 File Offset: 0x0038BBD0
	public override UniTask PlayShowAnim()
	{
		FloroRanchUiToyItem.<PlayShowAnim>d__10 <PlayShowAnim>d__;
		<PlayShowAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayShowAnim>d__.<>4__this = this;
		<PlayShowAnim>d__.<>1__state = -1;
		<PlayShowAnim>d__.<>t__builder.Start<FloroRanchUiToyItem.<PlayShowAnim>d__10>(ref <PlayShowAnim>d__);
		return <PlayShowAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4FF RID: 54527 RVA: 0x0038DA14 File Offset: 0x0038BC14
	public override UniTask PlayHideAnim()
	{
		FloroRanchUiToyItem.<PlayHideAnim>d__11 <PlayHideAnim>d__;
		<PlayHideAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayHideAnim>d__.<>4__this = this;
		<PlayHideAnim>d__.<>1__state = -1;
		<PlayHideAnim>d__.<>t__builder.Start<FloroRanchUiToyItem.<PlayHideAnim>d__11>(ref <PlayHideAnim>d__);
		return <PlayHideAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D500 RID: 54528 RVA: 0x0038DA58 File Offset: 0x0038BC58
	public override UniTask PlayNormalAnim()
	{
		FloroRanchUiToyItem.<PlayNormalAnim>d__12 <PlayNormalAnim>d__;
		<PlayNormalAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayNormalAnim>d__.<>4__this = this;
		<PlayNormalAnim>d__.<>1__state = -1;
		<PlayNormalAnim>d__.<>t__builder.Start<FloroRanchUiToyItem.<PlayNormalAnim>d__12>(ref <PlayNormalAnim>d__);
		return <PlayNormalAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D501 RID: 54529 RVA: 0x0038DA9C File Offset: 0x0038BC9C
	public UniTask PlayToyLevelUpAnim()
	{
		FloroRanchUiToyItem.<PlayToyLevelUpAnim>d__13 <PlayToyLevelUpAnim>d__;
		<PlayToyLevelUpAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayToyLevelUpAnim>d__.<>4__this = this;
		<PlayToyLevelUpAnim>d__.<>1__state = -1;
		<PlayToyLevelUpAnim>d__.<>t__builder.Start<FloroRanchUiToyItem.<PlayToyLevelUpAnim>d__13>(ref <PlayToyLevelUpAnim>d__);
		return <PlayToyLevelUpAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D502 RID: 54530 RVA: 0x0038DADF File Offset: 0x0038BCDF
	public void SetSelectState(bool isSelect)
	{
		base.GetExtendToggle(0).SetToggleState(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600D503 RID: 54531 RVA: 0x0038DAF8 File Offset: 0x0038BCF8
	private void OnToggleClick(EToggleState toggleState)
	{
		Action onClickCallback = this.OnClickCallback;
		if (onClickCallback == null)
		{
			return;
		}
		onClickCallback();
	}

	// Token: 0x0600D504 RID: 54532 RVA: 0x0038DB0A File Offset: 0x0038BD0A
	public void BindClickCallback(Action callback)
	{
		this.OnClickCallback = callback;
	}

	// Token: 0x04006539 RID: 25913
	private FloroRanchEntityDebugInfoItem DebugInfoItem;

	// Token: 0x0400653A RID: 25914
	public UiBehaviorLevelSequence UiLevelSequence;

	// Token: 0x0400653B RID: 25915
	public FloroRanchToyLevelItem ToyLevelItem;

	// Token: 0x0400653C RID: 25916
	private Action OnClickCallback = delegate()
	{
	};

	// Token: 0x02007FC3 RID: 32707
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402B7BF RID: 178111
		public const int Toggle = 0;

		// Token: 0x0402B7C0 RID: 178112
		public const int QualitySprite = 1;

		// Token: 0x0402B7C1 RID: 178113
		public const int IconTexture = 2;

		// Token: 0x0402B7C2 RID: 178114
		public const int CountDownPanel = 3;

		// Token: 0x0402B7C3 RID: 178115
		public const int CountdownText = 4;

		// Token: 0x0402B7C4 RID: 178116
		public const int NumPanel = 5;

		// Token: 0x0402B7C5 RID: 178117
		public const int NumText = 6;

		// Token: 0x0402B7C6 RID: 178118
		public const int LockSprite = 7;

		// Token: 0x0402B7C7 RID: 178119
		public const int InfoPanel = 8;

		// Token: 0x0402B7C8 RID: 178120
		public const int BgSprite = 9;

		// Token: 0x0402B7C9 RID: 178121
		public const int IconMaskTexture = 10;

		// Token: 0x0402B7CA RID: 178122
		public const int UnknownPanel = 11;

		// Token: 0x0402B7CB RID: 178123
		public const int ItemPhantomIcon = 12;

		// Token: 0x0402B7CC RID: 178124
		public const int ItemNew = 13;

		// Token: 0x0402B7CD RID: 178125
		public const int ToyRaceItem = 14;

		// Token: 0x0402B7CE RID: 178126
		public const int ToyRaceIcon = 15;

		// Token: 0x0402B7CF RID: 178127
		public const int ToyLevelItem = 16;
	}
}
