using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll.View
{
	// Token: 0x02006F61 RID: 28513
	[NullableContext(1)]
	[Nullable(0)]
	public class BigStuffedDollProgressItem : UiPanelBase
	{
		// Token: 0x0604503B RID: 282683 RVA: 0x011F7338 File Offset: 0x011F5538
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604503C RID: 282684 RVA: 0x011F73E4 File Offset: 0x011F55E4
		protected override void OnStart()
		{
			base.OnStart();
			UUIItem item = base.GetItem(1);
			this.ProgressBarWidth = item.GetWidth();
			item.SetStretchLeft(0f);
			item.SetStretchRight(this.ProgressBarWidth);
			item.SetUIActive(true);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.CurrentPerformanceScore = 0f;
		}

		// Token: 0x0604503D RID: 282685 RVA: 0x011F7448 File Offset: 0x011F5648
		public void Init(BrokenRockConfig config)
		{
			this.ScoreMax = (float)((config.ScoreMax != 0) ? config.ScoreMax : 100);
			this.AutoIncreaseScore = (float)config.ScoreUp;
			LevelGeneralNetworks.RequestEntitySendEvent(ModelBase<BigStuffedDollModel>.Instance.BrokenRockEntityCreatureDataId, "BrokenRockEventKey1");
			this.UpdateProgressText();
			base.GetSprite(0).SetFillAmount(0f);
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetAnchorOffsetX(this.ProgressBarWidth * -0.5f);
		}

		// Token: 0x0604503E RID: 282686 RVA: 0x011F74C8 File Offset: 0x011F56C8
		public void Init(BrokenRockConfig config)
		{
			this.ScoreMax = (float)((config.ScoreMax != 0) ? config.ScoreMax : 100);
			this.AutoIncreaseScore = (float)config.ScoreUp;
			LevelGeneralNetworks.RequestEntitySendEvent(ModelBase<BigStuffedDollModel>.Instance.BrokenRockEntityCreatureDataId, "BrokenRockEventKey1");
			this.UpdateProgressText();
			base.GetSprite(0).SetFillAmount(0f);
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetAnchorOffsetX(this.ProgressBarWidth * -0.5f);
		}

		// Token: 0x0604503F RID: 282687 RVA: 0x011F7544 File Offset: 0x011F5744
		public void OnTick(float delta)
		{
			if (ModelBase<BigStuffedDollModel>.Instance.GetGameStage() != EGameStage.GamePlaying)
			{
				return;
			}
			float num = delta / 1000f;
			if (this.AutoIncreaseScore != 0f)
			{
				this.AddScore(num * this.AutoIncreaseScore, false);
			}
			this.UpdateAddItem(num);
			this.ProcessProgressEvent();
		}

		// Token: 0x06045040 RID: 282688 RVA: 0x011F7590 File Offset: 0x011F5790
		public void AddScore(float score, bool playAnim = true)
		{
			BigStuffedDollModel instance = ModelBase<BigStuffedDollModel>.Instance;
			if (playAnim)
			{
				this.CurrentPerformanceScore = instance.CurrentScore;
			}
			instance.CurrentScore = MathCommon.Clamp(instance.CurrentScore + score, 0f, this.ScoreMax);
			float num = this.UpdateProgressText();
			if (playAnim)
			{
				UUIItem item = base.GetItem(1);
				float progress = this.GetProgress(this.CurrentPerformanceScore);
				item.SetStretchLeft(this.ProgressBarWidth * progress);
				item.SetStretchRight(this.ProgressBarWidth * (1f - num));
				this.LevelSequencePlayer.StopCurrentSequence(true, true);
				this.LevelSequencePlayer.PlayLevelSequenceByName((score >= 0f) ? "Add" : "Subtract", false, null, false);
				return;
			}
			base.GetSprite(0).SetFillAmount(num);
		}

		// Token: 0x06045041 RID: 282689 RVA: 0x011F7654 File Offset: 0x011F5854
		private void UpdateAddItem(float deltaSecond)
		{
			float currentProgress = this.GetCurrentProgress();
			this.CurrentPerformanceScore = MathCommon.Clamp(this.CurrentPerformanceScore + deltaSecond * 10f, 0f, ModelBase<BigStuffedDollModel>.Instance.CurrentScore);
			float progress = this.GetProgress(this.CurrentPerformanceScore);
			base.GetSprite(0).SetFillAmount(progress);
			UUIItem item = base.GetItem(1);
			item.SetStretchLeft(this.ProgressBarWidth * progress);
			item.SetStretchRight(this.ProgressBarWidth * (1f - currentProgress));
			UUIItem item2 = base.GetItem(3);
			if (item2 == null)
			{
				return;
			}
			item2.SetAnchorOffsetX(this.ProgressBarWidth * (progress - 0.5f));
		}

		// Token: 0x06045042 RID: 282690 RVA: 0x011F76F4 File Offset: 0x011F58F4
		private void ProcessProgressEvent()
		{
			BigStuffedDollModel instance = ModelBase<BigStuffedDollModel>.Instance;
			float currentProgress = this.GetCurrentProgress();
			if (currentProgress > 0.2f && this.LastProgress <= 0.2f)
			{
				LevelGeneralNetworks.RequestEntitySendEvent(instance.BrokenRockEntityCreatureDataId, "BrokenRockEventKey2");
			}
			else if (currentProgress > 0.4f && this.LastProgress <= 0.4f)
			{
				LevelGeneralNetworks.RequestEntitySendEvent(instance.BrokenRockEntityCreatureDataId, "BrokenRockEventKey3");
			}
			else if (currentProgress > 0.6f && this.LastProgress <= 0.6f)
			{
				LevelGeneralNetworks.RequestEntitySendEvent(instance.BrokenRockEntityCreatureDataId, "BrokenRockEventKey4");
			}
			else if (currentProgress > 0.8f && this.LastProgress <= 0.8f)
			{
				LevelGeneralNetworks.RequestEntitySendEvent(instance.BrokenRockEntityCreatureDataId, "BrokenRockEventKey5");
			}
			if (currentProgress >= 1f)
			{
				instance.GameResult = true;
				instance.EnterNextGameStage();
			}
			this.LastProgress = currentProgress;
		}

		// Token: 0x06045043 RID: 282691 RVA: 0x011F77C4 File Offset: 0x011F59C4
		private float UpdateProgressText()
		{
			UUIText text = base.GetText(2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "TeddyBear_Progress", Array.Empty<object>());
			string text2 = text.GetText();
			float currentProgress = this.GetCurrentProgress();
			int currentProgressPercent = this.GetCurrentProgressPercent();
			UUIText uuitext = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
			defaultInterpolatedStringHandler.AppendFormatted(text2);
			defaultInterpolatedStringHandler.AppendLiteral(":");
			defaultInterpolatedStringHandler.AppendFormatted<int>(currentProgressPercent);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			return currentProgress;
		}

		// Token: 0x06045044 RID: 282692 RVA: 0x011F7841 File Offset: 0x011F5A41
		public float GetCurrentProgress()
		{
			if (this.ScoreMax == 0f)
			{
				return 1f;
			}
			return this.GetProgress(ModelBase<BigStuffedDollModel>.Instance.CurrentScore);
		}

		// Token: 0x06045045 RID: 282693 RVA: 0x011F7866 File Offset: 0x011F5A66
		public int GetCurrentProgressPercent()
		{
			if (this.ScoreMax == 0f)
			{
				return 100;
			}
			return Math.Min(100, (int)Math.Floor((double)(this.GetCurrentProgress() * 100f)));
		}

		// Token: 0x06045046 RID: 282694 RVA: 0x011F7892 File Offset: 0x011F5A92
		private float GetProgress(float score)
		{
			if (this.ScoreMax == 0f)
			{
				return 1f;
			}
			return score / this.ScoreMax;
		}

		// Token: 0x040267E0 RID: 157664
		private const string ADD_SCORE_ANIMNAME = "Add";

		// Token: 0x040267E1 RID: 157665
		private const string SUB_SCORE_ANIMNAME = "Subtract";

		// Token: 0x040267E2 RID: 157666
		private const string QTE_EVENTKEY1 = "BrokenRockEventKey1";

		// Token: 0x040267E3 RID: 157667
		private const string QTE_EVENTKEY2 = "BrokenRockEventKey2";

		// Token: 0x040267E4 RID: 157668
		private const string QTE_EVENTKEY3 = "BrokenRockEventKey3";

		// Token: 0x040267E5 RID: 157669
		private const string QTE_EVENTKEY4 = "BrokenRockEventKey4";

		// Token: 0x040267E6 RID: 157670
		private const string QTE_EVENTKEY5 = "BrokenRockEventKey5";

		// Token: 0x040267E7 RID: 157671
		private const float QTE_EVENTKEY_PROGRESS2 = 0.2f;

		// Token: 0x040267E8 RID: 157672
		private const float QTE_EVENTKEY_PROGRESS3 = 0.4f;

		// Token: 0x040267E9 RID: 157673
		private const float QTE_EVENTKEY_PROGRESS4 = 0.6f;

		// Token: 0x040267EA RID: 157674
		private const float QTE_EVENTKEY_PROGRESS5 = 0.8f;

		// Token: 0x040267EB RID: 157675
		private float ProgressBarWidth;

		// Token: 0x040267EC RID: 157676
		private float CurrentPerformanceScore;

		// Token: 0x040267ED RID: 157677
		public float ScoreMax;

		// Token: 0x040267EE RID: 157678
		public float AutoIncreaseScore;

		// Token: 0x040267EF RID: 157679
		private float LastProgress;

		// Token: 0x040267F0 RID: 157680
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200CBF7 RID: 52215
		[NullableContext(0)]
		private class EViewComponent
		{
			// Token: 0x0403E8BD RID: 256189
			public const int ProgressSprite = 0;

			// Token: 0x0403E8BE RID: 256190
			public const int AdditionItem = 1;

			// Token: 0x0403E8BF RID: 256191
			public const int ProgressText = 2;

			// Token: 0x0403E8C0 RID: 256192
			public const int Effect = 3;
		}
	}
}
