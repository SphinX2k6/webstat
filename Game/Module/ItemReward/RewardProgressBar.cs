using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B62 RID: 23394
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardProgressBar : UiPanelBase
	{
		// Token: 0x0603B2C6 RID: 242374 RVA: 0x00EF9052 File Offset: 0x00EF7252
		public RewardProgressBar(AActor rootActor)
		{
			base.CreateThenShowByActor(rootActor, null);
		}

		// Token: 0x0603B2C7 RID: 242375 RVA: 0x00EF9070 File Offset: 0x00EF7270
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603B2C8 RID: 242376 RVA: 0x00EF9105 File Offset: 0x00EF7305
		public void Clear()
		{
			this.AnimationRemainingTime = new float?(0f);
			this.ProgressBarAnimationQueue.Clear();
		}

		// Token: 0x0603B2C9 RID: 242377 RVA: 0x00EF9124 File Offset: 0x00EF7324
		public void Refresh(string titleTextId, List<IRewardProgress> progressQueue, float progressAnimationLength = 500f)
		{
			this.SetTitleText(titleTextId);
			if (progressQueue == null || progressQueue.Count == 0)
			{
				return;
			}
			if (progressAnimationLength > 0f)
			{
				this.PlayProgressAnimation(progressQueue, progressAnimationLength);
				return;
			}
			IRewardProgress rewardProgress = progressQueue[progressQueue.Count - 1];
			if (rewardProgress == null)
			{
				return;
			}
			int toProgress = rewardProgress.ToProgress;
			int maxProgress = rewardProgress.MaxProgress;
			this.SetProgressText((float)toProgress, (float)maxProgress);
			this.SetProgressBarPercent((float)toProgress, (float)maxProgress);
		}

		// Token: 0x0603B2CA RID: 242378 RVA: 0x00EF918C File Offset: 0x00EF738C
		public void PlayProgressAnimation(List<IRewardProgress> progressBarAnimationQueue, float progressAnimationLength = 500f)
		{
			this.ProgressBarAnimationQueue = progressBarAnimationQueue;
			IRewardProgress rewardProgress = (this.ProgressBarAnimationQueue.Count > 0) ? this.ProgressBarAnimationQueue[0] : null;
			if (rewardProgress != null)
			{
				this.ProgressBarAnimationQueue.RemoveAt(0);
			}
			if (rewardProgress == null)
			{
				return;
			}
			int fromProgress = rewardProgress.FromProgress;
			int toProgress = rewardProgress.ToProgress;
			int maxProgress = rewardProgress.MaxProgress;
			this.SetProgressText((float)fromProgress, (float)maxProgress);
			this.SetProgressBarPercent((float)fromProgress, (float)maxProgress);
			this.PlayProgressTo((float)fromProgress, (float)toProgress, (float)maxProgress, progressAnimationLength);
		}

		// Token: 0x0603B2CB RID: 242379 RVA: 0x00EF9208 File Offset: 0x00EF7408
		private void PlayProgressTo(float fromProgress, float toProgress, float maxProgress, float animationLength)
		{
			if (maxProgress < toProgress)
			{
				this.SetProgressText(toProgress, maxProgress);
				this.OnProgressBarFinished();
				this.SetProgressBarPercent(toProgress, maxProgress);
				return;
			}
			this.AnimationLength = animationLength;
			this.AnimationRemainingTime = new float?(animationLength);
			this.AnimationFromProgress = fromProgress;
			this.AnimationToProgress = toProgress;
			this.AnimationMaxProgress = maxProgress;
		}

		// Token: 0x0603B2CC RID: 242380 RVA: 0x00EF925C File Offset: 0x00EF745C
		public void Tick(float delta)
		{
			if (this.AnimationRemainingTime == null)
			{
				return;
			}
			float alpha = 1f - this.AnimationRemainingTime.Value / this.AnimationLength;
			float val = Singleton<MathUtils>.Instance.Lerp(this.AnimationFromProgress, this.AnimationToProgress, alpha);
			this.SetProgressText((float)((int)Math.Ceiling((double)Math.Min(val, this.AnimationToProgress))), this.AnimationMaxProgress);
			this.SetProgressBarPercent(Math.Min(val, this.AnimationToProgress), this.AnimationMaxProgress);
			if (this.AnimationRemainingTime.Value < 0f)
			{
				this.OnProgressBarFinished();
				return;
			}
			this.AnimationRemainingTime -= delta;
		}

		// Token: 0x0603B2CD RID: 242381 RVA: 0x00EF932B File Offset: 0x00EF752B
		private void OnProgressBarFinished()
		{
			this.AnimationRemainingTime = null;
			if (this.ProgressBarAnimationQueue.Count > 0)
			{
				this.PlayProgressAnimation(this.ProgressBarAnimationQueue, this.AnimationLength);
			}
		}

		// Token: 0x0603B2CE RID: 242382 RVA: 0x00EF935C File Offset: 0x00EF755C
		private void SetTitleText(string titleTextId)
		{
			UUIText text = base.GetText(0);
			if (StringUtils.IsEmpty(titleTextId))
			{
				text.SetUIActive(false);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, titleTextId, Array.Empty<object>());
			text.SetUIActive(true);
		}

		// Token: 0x0603B2CF RID: 242383 RVA: 0x00EF939C File Offset: 0x00EF759C
		private void SetProgressText(float currentProgress, float maxProgress)
		{
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<float>(Math.Min(maxProgress, currentProgress));
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<float>(maxProgress);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603B2D0 RID: 242384 RVA: 0x00EF93E8 File Offset: 0x00EF75E8
		private void SetProgressBarPercent(float currentProgress, float maxProgress)
		{
			base.GetSprite(2).SetFillAmount(currentProgress / maxProgress);
		}

		// Token: 0x040215A7 RID: 136615
		private const int ANIMATION_LENGTH = 500;

		// Token: 0x040215A8 RID: 136616
		private float AnimationFromProgress;

		// Token: 0x040215A9 RID: 136617
		private float AnimationToProgress;

		// Token: 0x040215AA RID: 136618
		private float AnimationMaxProgress;

		// Token: 0x040215AB RID: 136619
		private float AnimationLength;

		// Token: 0x040215AC RID: 136620
		private float? AnimationRemainingTime;

		// Token: 0x040215AD RID: 136621
		private List<IRewardProgress> ProgressBarAnimationQueue = new List<IRewardProgress>();

		// Token: 0x0200BB70 RID: 47984
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039D46 RID: 236870
			public const int TitleText = 0;

			// Token: 0x04039D47 RID: 236871
			public const int ProgressText = 1;

			// Token: 0x04039D48 RID: 236872
			public const int ProgressBarSprite = 2;
		}
	}
}
