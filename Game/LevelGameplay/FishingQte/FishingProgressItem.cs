using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E98 RID: 28312
	[NullableContext(2)]
	[Nullable(0)]
	public class FishingProgressItem : UiPanelBase
	{
		// Token: 0x06044A8F RID: 281231 RVA: 0x011D8900 File Offset: 0x011D6B00
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044A90 RID: 281232 RVA: 0x011D89CC File Offset: 0x011D6BCC
		[NullableContext(1)]
		public void Init(IFishingQteConfig config, FishingQteGameInfo gameInfo)
		{
			this.GameInfo = gameInfo;
			this.GameConfig = config;
			this.AnimTime = Math.Max((float)config.HitColdTime, 100f);
		}

		// Token: 0x06044A91 RID: 281233 RVA: 0x011D89F3 File Offset: 0x011D6BF3
		protected override void OnStart()
		{
			this.PanelProgressItem = base.GetItem(1);
			this.PanelProgressFrameItem = base.GetItem(3);
			this.PanelProgressFrameItem2 = base.GetItem(4);
			this.PanelProgressAnimItem = base.GetItem(2);
		}

		// Token: 0x06044A92 RID: 281234 RVA: 0x011D8A29 File Offset: 0x011D6C29
		protected override void OnBeforeDestroy()
		{
			this.PanelProgressItem = null;
			this.PanelProgressFrameItem = null;
			this.PanelProgressAnimItem = null;
		}

		// Token: 0x06044A93 RID: 281235 RVA: 0x011D8A40 File Offset: 0x011D6C40
		public void OnTick(float delta)
		{
			float currentProgress = this.GetCurrentProgress();
			this.RefreshAnimProgress(currentProgress, delta);
			this.RefreshProgress(currentProgress);
		}

		// Token: 0x06044A94 RID: 281236 RVA: 0x011D8A64 File Offset: 0x011D6C64
		private void RefreshProgress(float progress)
		{
			double value = Math.Ceiling((double)(progress * 100f));
			UUIText text = base.GetText(0);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<double>(value);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			this.CurrentRotator.Yaw = Singleton<MathUtils>.Instance.Lerp(-77f, 0f, progress);
			UUIItem panelProgressItem = this.PanelProgressItem;
			FRotator frotator;
			if (panelProgressItem != null)
			{
				frotator = this.CurrentRotator.ToUeRotator();
				panelProgressItem.SetUIRelativeRotation(frotator);
			}
			UUIItem panelProgressFrameItem = this.PanelProgressFrameItem;
			if (panelProgressFrameItem != null)
			{
				frotator = this.CurrentRotator.ToUeRotator();
				panelProgressFrameItem.SetUIRelativeRotation(frotator);
			}
			UUIItem panelProgressFrameItem2 = this.PanelProgressFrameItem2;
			if (panelProgressFrameItem2 == null)
			{
				return;
			}
			frotator = this.CurrentRotator.ToUeRotator();
			panelProgressFrameItem2.SetUIRelativeRotation(frotator);
		}

		// Token: 0x06044A95 RID: 281237 RVA: 0x011D8B2C File Offset: 0x011D6D2C
		private void RefreshAnimProgress(float currentProgress, float delta)
		{
			float alpha = currentProgress;
			if (this.InAnim)
			{
				this.CurrentAnimTime += delta;
				if (0f < this.CurrentAnimTime && this.CurrentAnimTime <= 0f + this.AnimTime)
				{
					float alpha2 = (this.CurrentAnimTime - 0f) / this.AnimTime;
					alpha = Singleton<MathUtils>.Instance.Lerp(this.AnimStartProgress, currentProgress, alpha2);
				}
				else
				{
					this.InAnim = false;
					alpha = currentProgress;
				}
			}
			this.AnimRotator.Yaw = Singleton<MathUtils>.Instance.Lerp(-77f, 0f, alpha);
			UUIItem panelProgressAnimItem = this.PanelProgressAnimItem;
			if (panelProgressAnimItem == null)
			{
				return;
			}
			FRotator frotator = this.AnimRotator.ToUeRotator();
			panelProgressAnimItem.SetUIRelativeRotation(frotator);
		}

		// Token: 0x06044A96 RID: 281238 RVA: 0x011D8BE4 File Offset: 0x011D6DE4
		private float GetCurrentProgress()
		{
			float currentScore = this.GameInfo.CurrentScore;
			int maxScore = this.GameConfig.MaxScore;
			return Singleton<MathUtils>.Instance.Clamp(currentScore / (float)maxScore, 0f, 1f);
		}

		// Token: 0x06044A97 RID: 281239 RVA: 0x011D8C21 File Offset: 0x011D6E21
		public void StartAnimProgress()
		{
			this.AnimStartProgress = this.GetCurrentProgress();
			this.CurrentAnimTime = 0f;
			this.InAnim = true;
		}

		// Token: 0x06044A98 RID: 281240 RVA: 0x011D8C41 File Offset: 0x011D6E41
		public void EnterNextRound()
		{
			this.AnimStartProgress = 0f;
		}

		// Token: 0x0402638D RID: 156557
		private const float PROGRESS_START_ANGLE = -77f;

		// Token: 0x0402638E RID: 156558
		private const float PROGRESS_END_ANGLE = 0f;

		// Token: 0x0402638F RID: 156559
		private const float PAUSE_TIME = 0f;

		// Token: 0x04026390 RID: 156560
		private const float MIN_ANIM_TIME = 100f;

		// Token: 0x04026391 RID: 156561
		protected IFishingQteConfig GameConfig;

		// Token: 0x04026392 RID: 156562
		protected FishingQteGameInfo GameInfo;

		// Token: 0x04026393 RID: 156563
		[Nullable(1)]
		private Rotator CurrentRotator = Rotator.Create();

		// Token: 0x04026394 RID: 156564
		[Nullable(1)]
		private Rotator AnimRotator = Rotator.Create();

		// Token: 0x04026395 RID: 156565
		private UUIItem PanelProgressItem;

		// Token: 0x04026396 RID: 156566
		private UUIItem PanelProgressFrameItem;

		// Token: 0x04026397 RID: 156567
		private UUIItem PanelProgressFrameItem2;

		// Token: 0x04026398 RID: 156568
		private UUIItem PanelProgressAnimItem;

		// Token: 0x04026399 RID: 156569
		private bool InAnim;

		// Token: 0x0402639A RID: 156570
		private float CurrentAnimTime;

		// Token: 0x0402639B RID: 156571
		private float AnimStartProgress;

		// Token: 0x0402639C RID: 156572
		private float AnimTime;

		// Token: 0x0200CB63 RID: 52067
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403E6B7 RID: 255671
			public const int TxtProgress = 0;

			// Token: 0x0403E6B8 RID: 255672
			public const int PanelProgress = 1;

			// Token: 0x0403E6B9 RID: 255673
			public const int PanelProgressAnim = 2;

			// Token: 0x0403E6BA RID: 255674
			public const int PanelProgressFrame = 3;

			// Token: 0x0403E6BB RID: 255675
			public const int PanelProgressFrame2 = 4;
		}
	}
}
