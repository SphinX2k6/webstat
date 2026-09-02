using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013DD RID: 5085
[NullableContext(2)]
[Nullable(0)]
public class RewardItem : UiPanelBase
{
	// Token: 0x06008C91 RID: 35985 RVA: 0x0024F2BA File Offset: 0x0024D4BA
	public RewardItem(int itemId)
	{
		this.ItemId = itemId;
	}

	// Token: 0x17000BE4 RID: 3044
	// (get) Token: 0x06008C92 RID: 35986 RVA: 0x0024F2C9 File Offset: 0x0024D4C9
	protected int ItemId { get; }

	// Token: 0x06008C93 RID: 35987 RVA: 0x0024F2D4 File Offset: 0x0024D4D4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
	}

	// Token: 0x06008C94 RID: 35988 RVA: 0x0024F370 File Offset: 0x0024D570
	protected override UniTask OnBeforeStartAsync()
	{
		RewardItem.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RewardItem.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008C95 RID: 35989 RVA: 0x0024F3B4 File Offset: 0x0024D5B4
	protected override void OnStart()
	{
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetUIActive(true);
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetUIActive(false);
		}
		UUIText text3 = base.GetText(3);
		if (text3 != null)
		{
			text3.SetUIActive(false);
		}
		this.ShowRatio(false);
		this.CurrentValueDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenIntSetterDynamic>(new Action<int>(this.PlayCurrentValueAmount));
	}

	// Token: 0x06008C96 RID: 35990 RVA: 0x0024F418 File Offset: 0x0024D618
	protected override void OnBeforeDestroy()
	{
		this.KillExpTweener();
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(this.PlayCurrentValueAmount));
		this.CurrentValueDelegate = null;
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.Clear();
	}

	// Token: 0x06008C97 RID: 35991 RVA: 0x0024F448 File Offset: 0x0024D648
	protected void KillExpTweener()
	{
		if (this.ExpTweener != null)
		{
			this.ExpTweener.Kill(false);
			this.ExpTweener = null;
		}
	}

	// Token: 0x06008C98 RID: 35992 RVA: 0x0024F465 File Offset: 0x0024D665
	private void ShowLastValue()
	{
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetText(this.LastValue.ToString(), true);
		}
		UUIText text2 = base.GetText(3);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(this.CurrentValue.ToString(), true);
	}

	// Token: 0x06008C99 RID: 35993 RVA: 0x0024F4A4 File Offset: 0x0024D6A4
	public UniTask ShowAddValue()
	{
		RewardItem.<ShowAddValue>d__18 <ShowAddValue>d__;
		<ShowAddValue>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowAddValue>d__.<>4__this = this;
		<ShowAddValue>d__.<>1__state = -1;
		<ShowAddValue>d__.<>t__builder.Start<RewardItem.<ShowAddValue>d__18>(ref <ShowAddValue>d__);
		return <ShowAddValue>d__.<>t__builder.Task;
	}

	// Token: 0x06008C9A RID: 35994 RVA: 0x0024F4E8 File Offset: 0x0024D6E8
	private UniTask PlayAddAnimAndTween()
	{
		RewardItem.<PlayAddAnimAndTween>d__19 <PlayAddAnimAndTween>d__;
		<PlayAddAnimAndTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayAddAnimAndTween>d__.<>4__this = this;
		<PlayAddAnimAndTween>d__.<>1__state = -1;
		<PlayAddAnimAndTween>d__.<>t__builder.Start<RewardItem.<PlayAddAnimAndTween>d__19>(ref <PlayAddAnimAndTween>d__);
		return <PlayAddAnimAndTween>d__.<>t__builder.Task;
	}

	// Token: 0x06008C9B RID: 35995 RVA: 0x0024F52C File Offset: 0x0024D72C
	private void ShowRatio(bool isNeedRatio)
	{
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(isNeedRatio);
		}
		if (isNeedRatio)
		{
			DelegationResultData resultData = ModelBase<MoonChasingBusinessModel>.Instance.GetResultData();
			UUIText text = base.GetText(5);
			if (text == null)
			{
				return;
			}
			text.SetText(resultData.Ratio.ToString() + "%", true);
		}
	}

	// Token: 0x06008C9C RID: 35996 RVA: 0x0024F581 File Offset: 0x0024D781
	private void PlayCurrentValueAmount(int value)
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(value.ToString(), true);
	}

	// Token: 0x06008C9D RID: 35997 RVA: 0x0024F59C File Offset: 0x0024D79C
	private void PlaySecondTween()
	{
		this.KillExpTweener();
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_figure_up_2");
		this.SequencePlayer.PlaySequenceAsync("Add", new CustomPromise<bool>(), false, false, null, false).ContinueWith(delegate()
		{
			if (base.IsDestroyOrDestroying)
			{
				return;
			}
			this.ExpTweener = ULTweenBPLibrary.IntTo(GlobalData.World, this.CurrentValueDelegate, this.BaseValue, this.CurrentValue, 1f, 0f, LTweenEase.OutCubic);
			this.ExpTweener.OnCompleteCallBack.Bind(new Action(this.FinishCurrentValueAmount));
		}).Forget();
	}

	// Token: 0x06008C9E RID: 35998 RVA: 0x0024F5F8 File Offset: 0x0024D7F8
	private void FinishCurrentValueAmount()
	{
		this.KillExpTweener();
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetUIActive(true);
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetUIActive(false);
		}
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.PlayLevelSequenceByName("Addition02", false, null, false);
	}

	// Token: 0x06008C9F RID: 35999 RVA: 0x0024F651 File Offset: 0x0024D851
	public void UpdateItem(int addValue, int baseValue, bool isNeedRatio)
	{
		this.CurrentValue = addValue;
		this.BaseValue = baseValue;
		this.ShowLastValue();
		this.ShowRatio(isNeedRatio);
	}

	// Token: 0x0400417E RID: 16766
	private readonly int LastValue;

	// Token: 0x0400417F RID: 16767
	private int BaseValue;

	// Token: 0x04004180 RID: 16768
	private int CurrentValue;

	// Token: 0x04004181 RID: 16769
	protected FLTweenIntSetterDynamic CurrentValueDelegate;

	// Token: 0x04004182 RID: 16770
	protected ULTweener ExpTweener;

	// Token: 0x04004183 RID: 16771
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x04004184 RID: 16772
	private const int TWEEN_TIME = 1;

	// Token: 0x020077BA RID: 30650
	[NullableContext(0)]
	private static class ERewardItem
	{
		// Token: 0x0402933D RID: 168765
		public const int Icon = 0;

		// Token: 0x0402933E RID: 168766
		public const int LastValue = 1;

		// Token: 0x0402933F RID: 168767
		public const int ChangeValue = 2;

		// Token: 0x04029340 RID: 168768
		public const int CurrentValue = 3;

		// Token: 0x04029341 RID: 168769
		public const int RatioItem = 4;

		// Token: 0x04029342 RID: 168770
		public const int Ratio = 5;
	}
}
