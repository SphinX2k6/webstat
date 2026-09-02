using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E13 RID: 7699
[NullableContext(2)]
[Nullable(0)]
public class GreatSwordCountDownView : UiViewBase
{
	// Token: 0x0600E34B RID: 58187 RVA: 0x003D31AF File Offset: 0x003D13AF
	[NullableContext(1)]
	public GreatSwordCountDownView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E34C RID: 58188 RVA: 0x003D31C0 File Offset: 0x003D13C0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIArtText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIArtText))
		};
	}

	// Token: 0x0600E34D RID: 58189 RVA: 0x003D3230 File Offset: 0x003D1430
	protected override void OnAddEventListener()
	{
		base.OnAddEventListener();
		Singleton<EventSystem>.Instance.Add(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.OnCountDownChanged));
	}

	// Token: 0x0600E34E RID: 58190 RVA: 0x003D3254 File Offset: 0x003D1454
	protected override void OnRemoveEventListener()
	{
		base.OnRemoveEventListener();
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.OnCountDownChanged));
	}

	// Token: 0x0600E34F RID: 58191 RVA: 0x003D3278 File Offset: 0x003D1478
	protected override void OnStart()
	{
		this.CountDownText = base.GetArtText(0);
		this.AdditionText = base.GetArtText(3);
		this.YellowArtTextData = this.CountDownText.GetArtTextData();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("TextData_NumB1");
		Singleton<ResourceSystem>.Instance.LoadAsync<ULGUIArtTextData>(resourcePath, delegate([Nullable(2)] ULGUIArtTextData artTextData, string path)
		{
			if (artTextData != null && artTextData.IsValid())
			{
				this.RedArtTextData = artTextData;
			}
		}, ResourceSystem.EResourceLoadPriority.Default, this.MemoryTag);
		this.TexTimeBg = base.GetTexture(2);
	}

	// Token: 0x0600E350 RID: 58192 RVA: 0x003D32ED File Offset: 0x003D14ED
	private void OnCountDownChanged(double remainTime, double timerEndTime)
	{
		this.LastRemainTime = this.RemainTime;
		this.RemainTime = remainTime;
		if (this.RemainTime <= 0.0)
		{
			this.HandleCountDownEnd();
			return;
		}
		this.UpdateTimeDisplay();
		this.TryPlayColorChangeSequence();
		this.HandleTimerEndTime(timerEndTime);
	}

	// Token: 0x0600E351 RID: 58193 RVA: 0x003D332D File Offset: 0x003D152D
	private void HandleCountDownEnd()
	{
		ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing = true;
		base.CloseMe(delegate(bool success)
		{
			if (success)
			{
				ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing = false;
			}
		});
	}

	// Token: 0x0600E352 RID: 58194 RVA: 0x003D3360 File Offset: 0x003D1560
	private void TryPlayColorChangeSequence()
	{
		bool flag = this.RemainTime >= (double)this.ColorChangeTime;
		bool flag2 = this.LastRemainTime >= (double)this.ColorChangeTime;
		if (!flag2 || flag)
		{
			if (!flag2 && flag)
			{
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence != null)
				{
					uiViewSequence.PlaySequence("ColorChange1", false, null);
				}
				UUIArtText countDownText = this.CountDownText;
				if (countDownText == null)
				{
					return;
				}
				countDownText.SetArtTextData(this.YellowArtTextData);
			}
			return;
		}
		UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
		if (uiViewSequence2 != null)
		{
			uiViewSequence2.PlaySequence("ColorChange", false, null);
		}
		UUIArtText countDownText2 = this.CountDownText;
		if (countDownText2 == null)
		{
			return;
		}
		countDownText2.SetArtTextData(this.RedArtTextData);
	}

	// Token: 0x0600E353 RID: 58195 RVA: 0x003D3410 File Offset: 0x003D1610
	private void HandleTimerEndTime(double timerEndTime)
	{
		if (this.TimerEndTime == 0.0)
		{
			this.TimerEndTime = timerEndTime;
			return;
		}
		int num = (int)Math.Round((timerEndTime - this.TimerEndTime) / 1000.0);
		this.TimerEndTime = timerEndTime;
		if (num != 0)
		{
			this.ShowAdditionTime(num);
		}
	}

	// Token: 0x0600E354 RID: 58196 RVA: 0x003D3464 File Offset: 0x003D1664
	private void ShowAdditionTime(int diff)
	{
		string value = (diff > 0) ? "+" : "-";
		UUIArtText additionText = this.AdditionText;
		if (additionText != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendFormatted<int>(Math.Abs(diff));
			defaultInterpolatedStringHandler.AppendLiteral("s");
			additionText.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		bool flag = diff < 0;
		UUIArtText additionText2 = this.AdditionText;
		if (additionText2 != null)
		{
			additionText2.SetArtTextData(flag ? this.RedArtTextData : this.YellowArtTextData);
		}
		this.SetBgTextureByTimeChange(flag);
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null && uiViewSequence.HasSequenceNameInPlaying("TimeIn"))
		{
			UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
			if (uiViewSequence2 != null)
			{
				uiViewSequence2.StopSequenceByKey("TimeIn", false, true);
			}
		}
		UiBehaviorLevelSequence uiViewSequence3 = this.UiViewSequence;
		if (uiViewSequence3 == null)
		{
			return;
		}
		uiViewSequence3.PlaySequence("TimeIn", false, null);
	}

	// Token: 0x0600E355 RID: 58197 RVA: 0x003D3544 File Offset: 0x003D1744
	private void UpdateTimeDisplay()
	{
		string remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat5(this.RemainTime);
		UUIArtText countDownText = this.CountDownText;
		if (countDownText == null)
		{
			return;
		}
		countDownText.SetText(remainTimeDataFormat);
	}

	// Token: 0x0600E356 RID: 58198 RVA: 0x003D3574 File Offset: 0x003D1774
	private void SetBgTextureByTimeChange(bool isReduce)
	{
		if (this.TexTimeBg == null)
		{
			return;
		}
		this.TexTimeBg.SetUIActive(false);
		string resourceId = isReduce ? "T_BlackBladeCountDownBgRed" : "T_BlackBladeCountDownBgGreen";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.SetTextureByPath(resourcePath, this.TexTimeBg, null, delegate(bool _)
		{
			UUITexture texTimeBg = this.TexTimeBg;
			if (texTimeBg == null)
			{
				return;
			}
			texTimeBg.SetUIActive(true);
		});
	}

	// Token: 0x04006D45 RID: 27973
	private double RemainTime;

	// Token: 0x04006D46 RID: 27974
	private double TimerEndTime;

	// Token: 0x04006D47 RID: 27975
	private double LastRemainTime;

	// Token: 0x04006D48 RID: 27976
	private readonly int ColorChangeTime = 10;

	// Token: 0x04006D49 RID: 27977
	private UUIArtText CountDownText;

	// Token: 0x04006D4A RID: 27978
	private UUIArtText AdditionText;

	// Token: 0x04006D4B RID: 27979
	private ULGUIArtTextData YellowArtTextData;

	// Token: 0x04006D4C RID: 27980
	private ULGUIArtTextData RedArtTextData;

	// Token: 0x04006D4D RID: 27981
	private UUITexture TexTimeBg;
}
