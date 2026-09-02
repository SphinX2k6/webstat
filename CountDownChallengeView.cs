using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E04 RID: 7684
[NullableContext(2)]
[Nullable(0)]
public class CountDownChallengeView : UiViewBase
{
	// Token: 0x0600E2EA RID: 58090 RVA: 0x003D1B64 File Offset: 0x003CFD64
	[NullableContext(1)]
	public CountDownChallengeView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E2EB RID: 58091 RVA: 0x003D1B78 File Offset: 0x003CFD78
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIArtText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E2EC RID: 58092 RVA: 0x003D1C24 File Offset: 0x003CFE24
	protected override void OnStart()
	{
		ChallengeCountDownViewParams challengeCountDownViewParams = this.OpenParam as ChallengeCountDownViewParams;
		this.TimerEndTime = challengeCountDownViewParams.TimerEndTime;
		this.TitleKey = challengeCountDownViewParams.UiTitleKey;
		this.CountDownText = base.GetArtText(2);
		this.ChangeText = base.GetArtText(3);
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.YellowArtTextData = this.CountDownText.GetArtTextData();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("TextData_NumB1");
		Singleton<ResourceSystem>.Instance.LoadAsync<ULGUIArtTextData>(resourcePath, delegate([Nullable(2)] ULGUIArtTextData artTextData, string loadPath)
		{
			if (artTextData == null || !artTextData.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.UiImageSetting, ELogAuthor.YSQ, "CountDownChallengeView找不到artTextData：TextData_NumB1", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.RedArtTextData = artTextData;
		}, 100, this.MemoryTag);
	}

	// Token: 0x0600E2ED RID: 58093 RVA: 0x003D1CC1 File Offset: 0x003CFEC1
	protected override void OnAddEventListener()
	{
		base.OnAddEventListener();
		Singleton<EventSystem>.Instance.Add<double, double>(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.UpdateCountDown));
	}

	// Token: 0x0600E2EE RID: 58094 RVA: 0x003D1CE5 File Offset: 0x003CFEE5
	protected override void OnRemoveEventListener()
	{
		base.OnRemoveEventListener();
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.UpdateCountDown));
	}

	// Token: 0x0600E2EF RID: 58095 RVA: 0x003D1D0C File Offset: 0x003CFF0C
	private void UpdateCountDown(double remainTime, double timerEndTime)
	{
		this.LastRemainTime = this.RemainTime;
		this.RemainTime = remainTime;
		if (this.RemainTime <= 0.0)
		{
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
		bool flag = this.RemainTime >= 10.0;
		if (this.LastRemainTime >= 10.0 && !flag)
		{
			if (this.SequencePlayer.GetCurrentSequence() == "Switch")
			{
				this.SequencePlayer.StopCurrentSequence(false, true);
			}
			this.SequencePlayer.PlayLevelSequenceByName("Switch", false, null, false);
		}
		int num = (int)Math.Floor(this.RemainTime % Singleton<TimeUtil>.Instance.Hour / Singleton<TimeUtil>.Instance.Minute);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
		defaultInterpolatedStringHandler.AppendFormatted((num < 10) ? "0" : "");
		defaultInterpolatedStringHandler.AppendFormatted<int>(num);
		string value = defaultInterpolatedStringHandler.ToStringAndClear();
		int num2 = (int)Math.Floor(this.RemainTime % Singleton<TimeUtil>.Instance.Minute);
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
		defaultInterpolatedStringHandler.AppendFormatted((num2 < 10) ? "0" : "");
		defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
		string value2 = defaultInterpolatedStringHandler.ToStringAndClear();
		int num3 = (int)Math.Floor((this.RemainTime - Math.Floor(this.RemainTime)) * 100.0);
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
		defaultInterpolatedStringHandler.AppendFormatted((num3 < 10) ? "0" : "");
		defaultInterpolatedStringHandler.AppendFormatted<int>(num3);
		string value3 = defaultInterpolatedStringHandler.ToStringAndClear();
		UUIArtText countDownText = this.CountDownText;
		if (countDownText != null)
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral(":");
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			defaultInterpolatedStringHandler.AppendLiteral(":");
			defaultInterpolatedStringHandler.AppendFormatted(value3);
			countDownText.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		UUIArtText countDownText2 = this.CountDownText;
		if (countDownText2 != null)
		{
			countDownText2.SetArtTextData(flag ? this.YellowArtTextData : this.RedArtTextData);
		}
		if (timerEndTime != 0.0)
		{
			UUIArtText changeText = this.ChangeText;
			if (changeText != null)
			{
				changeText.SetArtTextData(flag ? this.YellowArtTextData : this.RedArtTextData);
			}
			int num4 = (int)Math.Round((timerEndTime - this.TimerEndTime) / 1000.0);
			this.TimerEndTime = timerEndTime;
			if (num4 != 0)
			{
				UUIArtText changeText2 = this.ChangeText;
				if (changeText2 != null)
				{
					string text;
					if (num4 <= 0)
					{
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
						defaultInterpolatedStringHandler.AppendFormatted<int>(num4);
						defaultInterpolatedStringHandler.AppendLiteral("s");
						text = defaultInterpolatedStringHandler.ToStringAndClear();
					}
					else
					{
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
						defaultInterpolatedStringHandler.AppendLiteral("+");
						defaultInterpolatedStringHandler.AppendFormatted<int>(num4);
						defaultInterpolatedStringHandler.AppendLiteral("s");
						text = defaultInterpolatedStringHandler.ToStringAndClear();
					}
					changeText2.SetText(text);
				}
				if (this.SequencePlayer.GetCurrentSequence() == "Add")
				{
					this.SequencePlayer.StopCurrentSequence(false, true);
				}
				this.SequencePlayer.PlayLevelSequenceByName("Add", false, null, false);
			}
		}
		string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(this.TitleKey);
		UUIText text2 = base.GetText(1);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(configTextByKey, true);
	}

	// Token: 0x04006D1D RID: 27933
	private const int ONE_HUNDRED = 100;

	// Token: 0x04006D1E RID: 27934
	[Nullable(1)]
	private const string SWITCH_ANIM = "Switch";

	// Token: 0x04006D1F RID: 27935
	[Nullable(1)]
	private const string ADD_ANIM = "Add";

	// Token: 0x04006D20 RID: 27936
	private double LastRemainTime;

	// Token: 0x04006D21 RID: 27937
	private double RemainTime;

	// Token: 0x04006D22 RID: 27938
	private double TimerEndTime;

	// Token: 0x04006D23 RID: 27939
	[Nullable(1)]
	private string TitleKey = "";

	// Token: 0x04006D24 RID: 27940
	private UUIArtText CountDownText;

	// Token: 0x04006D25 RID: 27941
	private UUIArtText ChangeText;

	// Token: 0x04006D26 RID: 27942
	private ULGUIArtTextData YellowArtTextData;

	// Token: 0x04006D27 RID: 27943
	private ULGUIArtTextData RedArtTextData;

	// Token: 0x04006D28 RID: 27944
	protected LevelSequencePlayer SequencePlayer;

	// Token: 0x02008170 RID: 33136
	[NullableContext(0)]
	private static class EViewComponent
	{
		// Token: 0x0402BF7B RID: 180091
		public const int BgTexture = 0;

		// Token: 0x0402BF7C RID: 180092
		public const int TipsText = 1;

		// Token: 0x0402BF7D RID: 180093
		public const int CountDownText = 2;

		// Token: 0x0402BF7E RID: 180094
		public const int ChangeText = 3;
	}
}
