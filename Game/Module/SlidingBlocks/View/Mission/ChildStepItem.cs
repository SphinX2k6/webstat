using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View.Mission
{
	// Token: 0x02004F17 RID: 20247
	[NullableContext(2)]
	[Nullable(0)]
	public class ChildStepItem : UiPanelBase
	{
		// Token: 0x06034539 RID: 214329 RVA: 0x00D18204 File Offset: 0x00D16404
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603453A RID: 214330 RVA: 0x00D18334 File Offset: 0x00D16534
		protected override UniTask OnBeforeStartAsync()
		{
			ChildStepItem.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ChildStepItem.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603453B RID: 214331 RVA: 0x00D18378 File Offset: 0x00D16578
		protected override void OnBeforeShow()
		{
			UUIText text = base.GetText(0);
			if (string.IsNullOrEmpty(this.TextKey) || StringUtils.IsBlank(this.TextKey))
			{
				text.SetUIActive(false);
				return;
			}
			text.SetUIActive(true);
			text.ShowTextNew(this.TextKey);
		}

		// Token: 0x0603453C RID: 214332 RVA: 0x00D183C4 File Offset: 0x00D165C4
		protected override void OnAfterShow()
		{
			SlidingBlocksGameData gameData = ModelBase<SlidingBlocksModel>.Instance.GameData;
			if (gameData.PlayMode != ETetrisPlayMode.Endless)
			{
				return;
			}
			if (gameData.ServerData.HistoryReceivedRewardIds.IndexOf(this.RewardId) >= 0)
			{
				this.PlaySuccessAnim().Forget();
			}
		}

		// Token: 0x0603453D RID: 214333 RVA: 0x00D1840A File Offset: 0x00D1660A
		public void OnTick(float delta)
		{
			this.CheckScoreAndPlaySuccessAnim();
		}

		// Token: 0x0603453E RID: 214334 RVA: 0x00D18412 File Offset: 0x00D16612
		public void InitByOpenParam(ITargetDescribeAndScore target)
		{
			if (target == null)
			{
				return;
			}
			this.SetTextKey(target.DescribeTextKey);
			this.TargetScore = target.Score;
			this.RewardId = target.RewardId;
		}

		// Token: 0x0603453F RID: 214335 RVA: 0x00D1843C File Offset: 0x00D1663C
		[NullableContext(1)]
		public void SetTextKey(string textKey)
		{
			this.TextKey = textKey;
		}

		// Token: 0x06034540 RID: 214336 RVA: 0x00D18448 File Offset: 0x00D16648
		private UniTask PlaySuccessAnim()
		{
			ChildStepItem.<PlaySuccessAnim>d__17 <PlaySuccessAnim>d__;
			<PlaySuccessAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySuccessAnim>d__.<>4__this = this;
			<PlaySuccessAnim>d__.<>1__state = -1;
			<PlaySuccessAnim>d__.<>t__builder.Start<ChildStepItem.<PlaySuccessAnim>d__17>(ref <PlaySuccessAnim>d__);
			return <PlaySuccessAnim>d__.<>t__builder.Task;
		}

		// Token: 0x06034541 RID: 214337 RVA: 0x00D1848C File Offset: 0x00D1668C
		private void CheckScoreAndPlaySuccessAnim()
		{
			CustomPromise<bool> currentStopPromise = this.LevelSequencePlayer.GetCurrentStopPromise("Success");
			if (this.IsComplete || (currentStopPromise != null && currentStopPromise.IsPending))
			{
				return;
			}
			SlidingBlocksGameData gameData = ModelBase<SlidingBlocksModel>.Instance.GameData;
			ETetrisPlayMode playMode = gameData.PlayMode;
			if (playMode != ETetrisPlayMode.Normal)
			{
				if (playMode != ETetrisPlayMode.Endless)
				{
					return;
				}
				double score = gameData.Score;
				if (score >= (double)this.TargetScore && this.LastScore < (double)this.TargetScore)
				{
					this.PlaySuccessAnim().Forget();
				}
				this.LastScore = score;
			}
			else if (gameData.Time <= 0.0)
			{
				this.PlaySuccessAnim().Forget();
				return;
			}
		}

		// Token: 0x0401E2E7 RID: 123623
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401E2E8 RID: 123624
		private string TextKey;

		// Token: 0x0401E2E9 RID: 123625
		private int RewardId;

		// Token: 0x0401E2EA RID: 123626
		private readonly FColor WhiteColor = FColor.FromHex("ECE5D8FF");

		// Token: 0x0401E2EB RID: 123627
		private readonly FColor GreenColor = FColor.FromHex("C9F797FF");

		// Token: 0x0401E2EC RID: 123628
		private bool IsPlaySuccessAnim;

		// Token: 0x0401E2ED RID: 123629
		private bool IsComplete;

		// Token: 0x0401E2EE RID: 123630
		private int TargetScore;

		// Token: 0x0401E2EF RID: 123631
		private double LastScore;

		// Token: 0x0200AF57 RID: 44887
		[NullableContext(0)]
		private enum EChildComponent
		{
			// Token: 0x0403669A RID: 222874
			StepDescribeText,
			// Token: 0x0403669B RID: 222875
			StepDistanceText,
			// Token: 0x0403669C RID: 222876
			StepSuccess,
			// Token: 0x0403669D RID: 222877
			StepLose,
			// Token: 0x0403669E RID: 222878
			StepStatusNode,
			// Token: 0x0403669F RID: 222879
			Root,
			// Token: 0x040366A0 RID: 222880
			LockIcon,
			// Token: 0x040366A1 RID: 222881
			ProgressBar
		}
	}
}
