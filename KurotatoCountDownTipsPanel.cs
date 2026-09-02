using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D1E RID: 7454
public class KurotatoCountDownTipsPanel : UiPanelBase
{
	// Token: 0x0600DB0C RID: 56076 RVA: 0x003AD508 File Offset: 0x003AB708
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x0600DB0D RID: 56077 RVA: 0x003AD578 File Offset: 0x003AB778
	protected override void OnStart()
	{
		this.SeqPlayer = new LevelSequencePlayer(base.GetRootItem());
		this.SeqPlayer.BindSequenceCloseEvent(delegate(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				base.Hide(null);
			}
		}, false);
	}

	// Token: 0x0600DB0E RID: 56078 RVA: 0x003AD5A3 File Offset: 0x003AB7A3
	protected override void OnBeforeShow()
	{
		this.TickEnabled = true;
	}

	// Token: 0x0600DB0F RID: 56079 RVA: 0x003AD5AC File Offset: 0x003AB7AC
	protected override void OnBeforeHide()
	{
		this.TickEnabled = false;
	}

	// Token: 0x0600DB10 RID: 56080 RVA: 0x003AD5B8 File Offset: 0x003AB7B8
	public void ShowTips()
	{
		base.Show(null);
		this.SeqPlayer.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x0600DB11 RID: 56081 RVA: 0x003AD5E8 File Offset: 0x003AB7E8
	public void HideTips()
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem == null || !rootItem.IsUIActiveSelf())
		{
			return;
		}
		this.SeqPlayer.PlayOrReplaySequenceByName("Close", false, null);
	}

	// Token: 0x0600DB12 RID: 56082 RVA: 0x003AD628 File Offset: 0x003AB828
	public void InitCountDown(float remainTime)
	{
		this.TotalTime = remainTime;
		this.RemainTime = remainTime;
		this.NeedTick = true;
		this.IsLowTime = false;
		base.GetText(3).SetText(Math.Ceiling((double)this.RemainTime).ToString(), true);
	}

	// Token: 0x0600DB13 RID: 56083 RVA: 0x003AD674 File Offset: 0x003AB874
	public void OnTick(float delta)
	{
		if (!this.TickEnabled || !this.NeedTick)
		{
			return;
		}
		if (Singleton<TickSystem>.Instance.IsPaused)
		{
			return;
		}
		float num = Math.Max(this.RemainTime - delta * (float)Singleton<TimeUtil>.Instance.Millisecond, 0f);
		this.RemainTime = num;
		base.GetText(3).SetText(Math.Ceiling((double)this.RemainTime).ToString(), true);
		if (!this.IsLowTime && num <= this.TotalTime * 0.1f)
		{
			this.IsLowTime = true;
			this.SeqPlayer.PlayOrReplaySequenceByName("Switch", false, null);
		}
		if (num <= 0f)
		{
			this.NeedTick = false;
			Singleton<EventSystem>.Instance.Emit(EEventName.KurotatoOnWaveCountDownFinish);
		}
	}

	// Token: 0x0400689B RID: 26779
	private const float LOW_TIME_RATIO = 0.1f;

	// Token: 0x0400689C RID: 26780
	private float TotalTime;

	// Token: 0x0400689D RID: 26781
	private float RemainTime;

	// Token: 0x0400689E RID: 26782
	private bool NeedTick;

	// Token: 0x0400689F RID: 26783
	private bool TickEnabled;

	// Token: 0x040068A0 RID: 26784
	private bool IsLowTime;

	// Token: 0x040068A1 RID: 26785
	[Nullable(1)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x02008097 RID: 32919
	private static class EComponentDefine
	{
		// Token: 0x0402BBB6 RID: 179126
		public const int PanelRed = 0;

		// Token: 0x0402BBB7 RID: 179127
		public const int TextureLight1 = 1;

		// Token: 0x0402BBB8 RID: 179128
		public const int TextureLight2 = 2;

		// Token: 0x0402BBB9 RID: 179129
		public const int TextNum = 3;
	}
}
