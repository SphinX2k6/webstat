using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029AC RID: 10668
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerCountDownView : UiViewBase
{
	// Token: 0x0601544E RID: 87118 RVA: 0x005E5031 File Offset: 0x005E3231
	public ShipTowerCountDownView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601544F RID: 87119 RVA: 0x005E5048 File Offset: 0x005E3248
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06015450 RID: 87120 RVA: 0x005E50A2 File Offset: 0x005E32A2
	private void InitDataParam()
	{
	}

	// Token: 0x06015451 RID: 87121 RVA: 0x005E50A4 File Offset: 0x005E32A4
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerCountDownView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerCountDownView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015452 RID: 87122 RVA: 0x005E50E7 File Offset: 0x005E32E7
	protected override void OnStart()
	{
		this.HideWave();
	}

	// Token: 0x06015453 RID: 87123 RVA: 0x005E50EF File Offset: 0x005E32EF
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<double, double>(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.EventUpdateCountDown));
		Singleton<EventSystem>.Instance.Add<string>(EEventName.ShipTowerBattleTip, new Action<string>(this.EventShipTowerBattleTip));
	}

	// Token: 0x06015454 RID: 87124 RVA: 0x005E5129 File Offset: 0x005E3329
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.EventUpdateCountDown));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShipTowerBattleTip, new Action<string>(this.EventShipTowerBattleTip));
	}

	// Token: 0x06015455 RID: 87125 RVA: 0x005E5163 File Offset: 0x005E3363
	protected override void OnBeforeDestroy()
	{
		this.ClearWaveTimer();
	}

	// Token: 0x06015456 RID: 87126 RVA: 0x005E516B File Offset: 0x005E336B
	private string FormatTimeUnit(int value)
	{
		return ((value < 10) ? "0" : "") + value.ToString();
	}

	// Token: 0x06015457 RID: 87127 RVA: 0x005E518C File Offset: 0x005E338C
	private void EventUpdateCountDown(double remainTime, double timerEndTime)
	{
		int value = (int)Math.Floor(remainTime % Singleton<TimeUtil>.Instance.Hour / Singleton<TimeUtil>.Instance.Minute);
		int value2 = (int)Math.Floor(remainTime % Singleton<TimeUtil>.Instance.Minute);
		int value3 = (int)Math.Floor((remainTime - Math.Floor(remainTime)) * 100.0);
		string text = this.FormatTimeUnit(value);
		string text2 = this.FormatTimeUnit(value2);
		string text3 = this.FormatTimeUnit(value3);
		UUIText text4 = base.GetText(0);
		if (text4 == null)
		{
			return;
		}
		text4.SetText(string.Concat(new string[]
		{
			text,
			":",
			text2,
			":",
			text3
		}), true);
	}

	// Token: 0x06015458 RID: 87128 RVA: 0x005E5238 File Offset: 0x005E3438
	private void EventShipTowerBattleTip(string text)
	{
		this.TipQueue.Add(text);
		this.TryShowNextTip();
	}

	// Token: 0x06015459 RID: 87129 RVA: 0x005E524C File Offset: 0x005E344C
	private void TryShowNextTip()
	{
		if (this.IsTipShowing || this.TipQueue.Count == 0)
		{
			return;
		}
		string key = this.TipQueue[0];
		this.TipQueue.RemoveAt(0);
		this.IsTipShowing = true;
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.ShowTextNew(key);
		}
		this.ClearWaveTimer();
		int num = 3000;
		this.WaveTimer = TimerSystem.Instance.Delay(new TTimerAction(this.HideWaveCallback), (float)num, null, null, true, 1f);
		base.PlaySequence("WaveIn", null, false);
	}

	// Token: 0x0601545A RID: 87130 RVA: 0x005E52F4 File Offset: 0x005E34F4
	private void HideWave()
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.IsTipShowing = false;
		this.TryShowNextTip();
	}

	// Token: 0x0601545B RID: 87131 RVA: 0x005E5316 File Offset: 0x005E3516
	private void HideWaveCallback(float _)
	{
		this.HideWaveAsync().Forget();
	}

	// Token: 0x0601545C RID: 87132 RVA: 0x005E5324 File Offset: 0x005E3524
	private UniTask HideWaveAsync()
	{
		ShipTowerCountDownView.<HideWaveAsync>d__19 <HideWaveAsync>d__;
		<HideWaveAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HideWaveAsync>d__.<>4__this = this;
		<HideWaveAsync>d__.<>1__state = -1;
		<HideWaveAsync>d__.<>t__builder.Start<ShipTowerCountDownView.<HideWaveAsync>d__19>(ref <HideWaveAsync>d__);
		return <HideWaveAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601545D RID: 87133 RVA: 0x005E5367 File Offset: 0x005E3567
	private void ClearWaveTimer()
	{
		if (this.WaveTimer != null)
		{
			TimerSystem.Instance.Remove(this.WaveTimer);
		}
		this.WaveTimer = null;
	}

	// Token: 0x0400A404 RID: 41988
	[Nullable(2)]
	private TimerHandle WaveTimer;

	// Token: 0x0400A405 RID: 41989
	private readonly List<string> TipQueue = new List<string>();

	// Token: 0x0400A406 RID: 41990
	private bool IsTipShowing;

	// Token: 0x02008CF9 RID: 36089
	[NullableContext(0)]
	public class Params
	{
		// Token: 0x0402F6C2 RID: 194242
		public double EndTime;
	}

	// Token: 0x02008CFA RID: 36090
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F6C3 RID: 194243
		public const int TxtCountDown = 0;

		// Token: 0x0402F6C4 RID: 194244
		public const int ItemWaveRoot = 1;

		// Token: 0x0402F6C5 RID: 194245
		public const int TxtWave = 2;
	}
}
