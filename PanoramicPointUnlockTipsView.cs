using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002367 RID: 9063
[NullableContext(1)]
[Nullable(0)]
public class PanoramicPointUnlockTipsView : UiTickViewBase
{
	// Token: 0x06011573 RID: 71027 RVA: 0x004C64FC File Offset: 0x004C46FC
	public PanoramicPointUnlockTipsView(UiViewInfo uiViewInfo) : base(uiViewInfo)
	{
	}

	// Token: 0x06011574 RID: 71028 RVA: 0x004C6534 File Offset: 0x004C4734
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011575 RID: 71029 RVA: 0x004C6640 File Offset: 0x004C4840
	protected override UniTask OnBeforeStartAsync()
	{
		PanoramicPointUnlockTipsView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PanoramicPointUnlockTipsView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011576 RID: 71030 RVA: 0x004C6684 File Offset: 0x004C4884
	protected override void OnStart()
	{
		this.StartTick = false;
		this.CountDownTime = 0f;
		string stringConfig = ConfigCommonParamById.GetStringConfig("PanoramicPointTipsTitle");
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), stringConfig, Array.Empty<object>());
		string stringConfig2 = ConfigCommonParamById.GetStringConfig("PanoramicPointTipsDescription");
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), stringConfig2, Array.Empty<object>());
		this.UiViewSequence.AddSequenceFinishEvent("StartTips", new Action<string>(this.OnStartSeqFinish), false);
		this.UiViewSequence.AddSequenceFinishEvent("CloseTips", new Action<string>(this.OnCloseSeqFinish), false);
	}

	// Token: 0x06011577 RID: 71031 RVA: 0x004C6724 File Offset: 0x004C4924
	protected override void OnAfterShow()
	{
		this.UiViewSequence.PlaySequence("StartTips", false, null);
	}

	// Token: 0x06011578 RID: 71032 RVA: 0x004C674C File Offset: 0x004C494C
	protected override void OnTick(float delta)
	{
		if (!this.StartTick)
		{
			return;
		}
		if (this.CountDownTime >= this.Duration)
		{
			this.UiViewSequence.PlaySequence("CloseTips", true, null);
			this.StartTick = false;
			return;
		}
		UUISprite sprite = base.GetSprite(3);
		this.CountDownTime += delta;
		float num = Math.Max(this.Duration - this.CountDownTime, 0f);
		if (sprite == null)
		{
			return;
		}
		sprite.SetFillAmount(num / this.Duration);
	}

	// Token: 0x06011579 RID: 71033 RVA: 0x004C67D4 File Offset: 0x004C49D4
	private void OnClick()
	{
		PanoramicPointUnlockTipsParam panoramicPointUnlockTipsParam = this.OpenParam as PanoramicPointUnlockTipsParam;
		if (panoramicPointUnlockTipsParam == null)
		{
			return;
		}
		GeographyHandBookViewParam param = new GeographyHandBookViewParam
		{
			SelectedId = panoramicPointUnlockTipsParam.ConfigId
		};
		HandBookEntranceViewParam param2 = new HandBookEntranceViewParam
		{
			SelectedTabType = EHandBookTabType.Geography
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HandBookEntranceView, param2, delegate(bool _, int _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.GeographyHandBookView, param, null);
		});
		this.UiViewSequence.PlaySequence("CloseTips", true, null);
	}

	// Token: 0x0601157A RID: 71034 RVA: 0x004C6854 File Offset: 0x004C4A54
	private void OnStartSeqFinish(string _)
	{
		this.UiViewSequence.PlaySequence("StartAtOnce", false, null);
		this.StartTick = true;
	}

	// Token: 0x0601157B RID: 71035 RVA: 0x004C6882 File Offset: 0x004C4A82
	private void OnCloseSeqFinish(string _)
	{
		this.StartTick = false;
		base.CloseMe(null);
	}

	// Token: 0x0400883F RID: 34879
	private float CountDownTime;

	// Token: 0x04008840 RID: 34880
	private bool StartTick;

	// Token: 0x04008841 RID: 34881
	private readonly float Duration = ConfigCommonParamById.GetFloatConfig("PanoramicPointTipsDuration").GetValueOrDefault() * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;

	// Token: 0x0200867B RID: 34427
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402D7EC RID: 186348
		public const int TextName = 0;

		// Token: 0x0402D7ED RID: 186349
		public const int SpriteIcon = 1;

		// Token: 0x0402D7EE RID: 186350
		public const int ButtonTips = 2;

		// Token: 0x0402D7EF RID: 186351
		public const int SpriteTimeBar = 3;

		// Token: 0x0402D7F0 RID: 186352
		public const int TextTitle = 4;
	}
}
