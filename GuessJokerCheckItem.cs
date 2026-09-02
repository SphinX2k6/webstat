using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200112B RID: 4395
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerCheckItem : UiPanelBase
{
	// Token: 0x06007301 RID: 29441 RVA: 0x001E0F82 File Offset: 0x001DF182
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x06007302 RID: 29442 RVA: 0x001E0FA5 File Offset: 0x001DF1A5
	protected override void OnBeforeShow()
	{
		base.SetUiActive(false);
	}

	// Token: 0x06007303 RID: 29443 RVA: 0x001E0FAE File Offset: 0x001DF1AE
	protected override void OnStart()
	{
		this.Delegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.UpdateMoveProgress));
	}

	// Token: 0x06007304 RID: 29444 RVA: 0x001E0FC7 File Offset: 0x001DF1C7
	protected override void OnBeforeDestroy()
	{
		this.StopMove();
		if (this.Delegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.UpdateMoveProgress));
			this.Delegate = null;
		}
	}

	// Token: 0x06007305 RID: 29445 RVA: 0x001E0FF0 File Offset: 0x001DF1F0
	public void ShowAndMoveToCards(List<GuessJokerCardItem> cardItemList, [Nullable(2)] Action onComplete = null)
	{
		if (cardItemList.Count == 0)
		{
			Action onComplete2 = onComplete;
			if (onComplete2 == null)
			{
				return;
			}
			onComplete2();
			return;
		}
		else
		{
			this.StopMove();
			this.ClearStayTimer();
			GuessJokerCardItem guessJokerCardItem = cardItemList[0];
			if (guessJokerCardItem == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "第一张卡牌不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				Action onComplete3 = onComplete;
				if (onComplete3 == null)
				{
					return;
				}
				onComplete3();
				return;
			}
			else
			{
				FVector2D currentPosition = guessJokerCardItem.GetCurrentPosition();
				Vector2D vector2D = new Vector2D((double)currentPosition.X, (double)(currentPosition.Y + 200f));
				this.RootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
				base.SetUiActive(true);
				if (cardItemList.Count == 1)
				{
					this.StayAndComplete(cardItemList[0], onComplete);
					return;
				}
				this.StayAndMoveToNext(cardItemList, 1, delegate
				{
					Action onComplete4 = onComplete;
					if (onComplete4 == null)
					{
						return;
					}
					onComplete4();
				});
				return;
			}
		}
	}

	// Token: 0x06007306 RID: 29446 RVA: 0x001E10D8 File Offset: 0x001DF2D8
	private void StayAndMoveToNext(List<GuessJokerCardItem> cardItemList, int currentIndex, [Nullable(2)] Action onComplete = null)
	{
		this.ClearStayTimer();
		this.StayTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.MoveToNextCard(cardItemList, currentIndex, onComplete);
		}, (float)GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerCheckItemStayTime.ToString()), null, null, true, 1f);
	}

	// Token: 0x06007307 RID: 29447 RVA: 0x001E1148 File Offset: 0x001DF348
	private void MoveToNextCard(List<GuessJokerCardItem> cardItemList, int currentIndex, [Nullable(2)] Action onComplete = null)
	{
		if (currentIndex >= cardItemList.Count)
		{
			this.StayAndComplete(cardItemList[cardItemList.Count - 1], onComplete);
			return;
		}
		GuessJokerCardItem guessJokerCardItem = cardItemList[currentIndex];
		if (guessJokerCardItem == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
			defaultInterpolatedStringHandler.AppendLiteral("卡牌索引");
			defaultInterpolatedStringHandler.AppendFormatted<int>(currentIndex);
			defaultInterpolatedStringHandler.AppendLiteral("不存在");
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			this.StayAndComplete(cardItemList[cardItemList.Count - 1], onComplete);
			return;
		}
		FVector2D currentPosition = guessJokerCardItem.GetCurrentPosition();
		Vector2D targetPosition = new Vector2D((double)currentPosition.X, (double)(currentPosition.Y + 200f));
		this.SmoothMoveTo(targetPosition, delegate
		{
			this.StayAndMoveToNext(cardItemList, currentIndex + 1, onComplete);
		}, (float)GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerCheckItemMoveTime.ToString()));
	}

	// Token: 0x06007308 RID: 29448 RVA: 0x001E1284 File Offset: 0x001DF484
	private void SmoothMoveTo(Vector2D targetPosition, [Nullable(2)] Action onComplete = null, float duration = 0f)
	{
		if (duration == 0f)
		{
			duration = (float)GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerCheckItemMoveTime.ToString());
		}
		if (this.IsMoving)
		{
			this.StopMove();
		}
		this.MoveCompleteCallback = onComplete;
		this.IsMoving = true;
		FVector2D currentPosition = this.GetCurrentPosition();
		FVector2D fvector2D = targetPosition.ToUeVector2D(false);
		if (Math.Abs(currentPosition.X - fvector2D.X) < 0.01f && Math.Abs(currentPosition.Y - fvector2D.Y) < 0.01f)
		{
			this.OnMoveComplete();
			return;
		}
		this.StartPosition.X = currentPosition.X;
		this.StartPosition.Y = currentPosition.Y;
		this.TargetPosition.X = fvector2D.X;
		this.TargetPosition.Y = fvector2D.Y;
		this.CurrentTweener = ULTweenBPLibrary.FloatTo(GlobalData.World, this.Delegate, 0f, 1f, duration / 1000f, 0f, LTweenEase.InOutCubic);
		if (this.CurrentTweener != null)
		{
			this.CurrentTweener.OnCompleteCallBack.Bind(new Action(this.OnMoveComplete));
		}
	}

	// Token: 0x06007309 RID: 29449 RVA: 0x001E13AC File Offset: 0x001DF5AC
	private void UpdateMoveProgress(float progress)
	{
		if (this.RootItem != null)
		{
			float inX = this.StartPosition.X + (this.TargetPosition.X - this.StartPosition.X) * progress;
			float inY = this.StartPosition.Y + (this.TargetPosition.Y - this.StartPosition.Y) * progress;
			this.RootItem.SetAnchorOffset(new FVector2D(inX, inY));
		}
	}

	// Token: 0x0600730A RID: 29450 RVA: 0x001E1420 File Offset: 0x001DF620
	private void StayAndComplete(GuessJokerCardItem cardItem, [Nullable(2)] Action onComplete = null)
	{
		this.ClearStayTimer();
		FVector2D currentPosition = cardItem.GetCurrentPosition();
		Vector2D targetPos = new Vector2D((double)currentPosition.X, (double)currentPosition.Y);
		Action <>9__1;
		this.StayTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
		{
			GuessJokerCheckItem <>4__this = this;
			Vector2D targetPos = targetPos;
			Action onComplete2;
			if ((onComplete2 = <>9__1) == null)
			{
				onComplete2 = (<>9__1 = delegate()
				{
					Action onComplete3 = onComplete;
					if (onComplete3 != null)
					{
						onComplete3();
					}
					cardItem.SetCheckCardItem(true);
					this.HideItem();
				});
			}
			<>4__this.SmoothMoveTo(targetPos, onComplete2, 0f);
		}, (float)GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerCheckItemStayTime.ToString()), null, null, true, 1f);
	}

	// Token: 0x0600730B RID: 29451 RVA: 0x001E14AD File Offset: 0x001DF6AD
	private void OnMoveComplete()
	{
		this.IsMoving = false;
		Action moveCompleteCallback = this.MoveCompleteCallback;
		if (moveCompleteCallback == null)
		{
			return;
		}
		moveCompleteCallback();
	}

	// Token: 0x0600730C RID: 29452 RVA: 0x001E14C6 File Offset: 0x001DF6C6
	public void StopMove()
	{
		if (this.CurrentTweener != null)
		{
			this.CurrentTweener.Kill(false);
			this.CurrentTweener.OnCompleteCallBack.Unbind();
			this.CurrentTweener = null;
		}
		this.IsMoving = false;
		this.MoveCompleteCallback = null;
	}

	// Token: 0x0600730D RID: 29453 RVA: 0x001E1501 File Offset: 0x001DF701
	private FVector2D GetCurrentPosition()
	{
		if (this.RootItem != null)
		{
			return this.RootItem.GetAnchorOffset();
		}
		return new FVector2D(0f, 0f);
	}

	// Token: 0x0600730E RID: 29454 RVA: 0x001E1526 File Offset: 0x001DF726
	public void HideItem()
	{
		this.StopMove();
		this.ClearStayTimer();
		base.SetUiActive(false);
	}

	// Token: 0x0600730F RID: 29455 RVA: 0x001E153B File Offset: 0x001DF73B
	private void ClearStayTimer()
	{
		if (this.StayTimerHandle != null)
		{
			if (TimerSystem.Instance.Has(this.StayTimerHandle))
			{
				TimerSystem.Instance.Remove(this.StayTimerHandle);
			}
			this.StayTimerHandle = null;
		}
	}

	// Token: 0x04003788 RID: 14216
	[Nullable(2)]
	private ULTweener CurrentTweener;

	// Token: 0x04003789 RID: 14217
	[Nullable(2)]
	private TimerHandle StayTimerHandle;

	// Token: 0x0400378A RID: 14218
	private bool IsMoving;

	// Token: 0x0400378B RID: 14219
	[Nullable(2)]
	private Action MoveCompleteCallback;

	// Token: 0x0400378C RID: 14220
	[Nullable(2)]
	protected FLTweenFloatSetterDynamic Delegate;

	// Token: 0x0400378D RID: 14221
	private FVector2D StartPosition = new FVector2D();

	// Token: 0x0400378E RID: 14222
	private FVector2D TargetPosition = new FVector2D();
}
