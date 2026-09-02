using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CB3 RID: 23731
	[NullableContext(1)]
	[Nullable(0)]
	public class CountDownFloatTips : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE2A RID: 245290 RVA: 0x00F2D4B0 File Offset: 0x00F2B6B0
		public CountDownFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE2B RID: 245291 RVA: 0x00F2D4DC File Offset: 0x00F2B6DC
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUINiagara)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(3, typeof(UUINiagara)));
			this.WhiteColor = new FColor?(FColor.FromHex("FFFFFFFF"));
		}

		// Token: 0x0603BE2C RID: 245292 RVA: 0x00F2D53A File Offset: 0x00F2B73A
		protected override void OnStart()
		{
			base.OnStart();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603BE2D RID: 245293 RVA: 0x00F2D553 File Offset: 0x00F2B753
		protected override void OnAddEventListener()
		{
			base.OnAddEventListener();
			Singleton<EventSystem>.Instance.Add<double, double>(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.UpdateCountDown));
		}

		// Token: 0x0603BE2E RID: 245294 RVA: 0x00F2D577 File Offset: 0x00F2B777
		protected override void OnRemoveEventListener()
		{
			base.OnRemoveEventListener();
			Singleton<EventSystem>.Instance.Remove(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.UpdateCountDown));
		}

		// Token: 0x0603BE2F RID: 245295 RVA: 0x00F2D59C File Offset: 0x00F2B79C
		protected override void OnTick(float delta)
		{
			if (this.MinuteText == "" || this.SecondText == "" || this.Millisecond == "")
			{
				return;
			}
			if (this.CdRemainTime <= 10.0)
			{
				if (this.LevelSequencePlayer.GetCurrentSequence() != "Loop")
				{
					this.LevelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
				}
			}
			else
			{
				if (this.LevelSequencePlayer.GetCurrentSequence() == "Loop")
				{
					this.LevelSequencePlayer.StopCurrentSequence(false, false);
				}
				base.MainText.SetColor(this.WhiteColor.Value);
				base.ExtraText.SetColor(this.WhiteColor.Value);
				base.MainText.SetUIItemScale(Vector.OneVector);
				base.ExtraText.SetUIItemScale(Vector.OneVector);
			}
			if (this.CdRemainTime == 0.0)
			{
				this.Millisecond = "00";
			}
			this.SetExtraText(new <>z__ReadOnlyArray<object>(new object[]
			{
				this.MinuteText,
				this.SecondText,
				this.Millisecond
			}));
		}

		// Token: 0x0603BE30 RID: 245296 RVA: 0x00F2D6E0 File Offset: 0x00F2B8E0
		private void UpdateCountDown(double cdRemainTime, double d)
		{
			this.CdRemainTime = cdRemainTime;
			if (cdRemainTime <= 0.0)
			{
				base.GetUiNiagara(2).SetUIActive(false);
				base.GetUiNiagara(3).SetUIActive(false);
				ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing = true;
				base.CloseMe(delegate(bool success)
				{
					if (success)
					{
						ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing = false;
					}
				});
				return;
			}
			base.GetUiNiagara(2).SetUIActive(cdRemainTime <= 10.0);
			base.GetUiNiagara(3).SetUIActive(cdRemainTime > 10.0);
			double num = Math.Floor(cdRemainTime % Singleton<TimeUtil>.Instance.Hour / Singleton<TimeUtil>.Instance.Minute);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted((num < 10.0) ? "0" : "");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num);
			this.MinuteText = defaultInterpolatedStringHandler.ToStringAndClear();
			double num2 = Math.Floor(cdRemainTime % Singleton<TimeUtil>.Instance.Minute);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted((num2 < 10.0) ? "0" : "");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num2);
			this.SecondText = defaultInterpolatedStringHandler.ToStringAndClear();
			double num3 = Math.Floor((cdRemainTime - Math.Floor(cdRemainTime)) * 100.0);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted((num3 < 10.0) ? "0" : "");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num3);
			this.Millisecond = defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x04021AA9 RID: 137897
		private const int ONE_HUNDRED = 100;

		// Token: 0x04021AAA RID: 137898
		private double CdRemainTime;

		// Token: 0x04021AAB RID: 137899
		private string Millisecond = "";

		// Token: 0x04021AAC RID: 137900
		private string MinuteText = "";

		// Token: 0x04021AAD RID: 137901
		private string SecondText = "";

		// Token: 0x04021AAE RID: 137902
		private FColor? WhiteColor;

		// Token: 0x04021AAF RID: 137903
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200BD42 RID: 48450
		[NullableContext(0)]
		private class ECountDownFloatTips
		{
			// Token: 0x0403A51C RID: 238876
			public const int RedBar = 2;

			// Token: 0x0403A51D RID: 238877
			public const int BlueBar = 3;
		}
	}
}
