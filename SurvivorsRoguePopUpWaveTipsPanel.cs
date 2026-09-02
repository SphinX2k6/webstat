using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D85 RID: 7557
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRoguePopUpWaveTipsPanel : UiPanelBase
{
	// Token: 0x0600DE79 RID: 56953 RVA: 0x003BDCF8 File Offset: 0x003BBEF8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600DE7A RID: 56954 RVA: 0x003BDD54 File Offset: 0x003BBF54
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRoguePopUpWaveTipsPanel.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRoguePopUpWaveTipsPanel.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DE7B RID: 56955 RVA: 0x003BDD97 File Offset: 0x003BBF97
	protected override void OnStart()
	{
		base.OnStart();
		this.WaveNumText = base.GetText(2);
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.SequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				this.SequencePlayer.PlayOrReplaySequenceByName("Close", false, null);
				return;
			}
			if (sequenceName == "Close")
			{
				this.WavePointItems[6].PlayResetSequence();
				ControllerBase<SurvivorsRogueController>.Instance.RequestEnterStep(ESurvivorsStepType.Prepare);
			}
		}, false);
	}

	// Token: 0x0600DE7C RID: 56956 RVA: 0x003BDDD5 File Offset: 0x003BBFD5
	protected override void OnBeforeShow()
	{
		this.OnAddEventListener();
		this.TickEnabled = true;
	}

	// Token: 0x0600DE7D RID: 56957 RVA: 0x003BDDE4 File Offset: 0x003BBFE4
	protected override void OnBeforeHide()
	{
		this.OnRemoveEventListener();
		this.TickEnabled = false;
	}

	// Token: 0x0600DE7E RID: 56958 RVA: 0x003BDDF4 File Offset: 0x003BBFF4
	protected void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600DE7F RID: 56959 RVA: 0x003BDE50 File Offset: 0x003BC050
	protected void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600DE80 RID: 56960 RVA: 0x003BDEAC File Offset: 0x003BC0AC
	public void ShowWaveTips()
	{
		base.Show(null);
		this.InitWavePointItem();
		this.WaveNumText.SetText(ModelBase<SurvivorsRogueModel>.Instance.CurWaveNum.ToString(), true);
		this.SequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x0600DE81 RID: 56961 RVA: 0x003BDF00 File Offset: 0x003BC100
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "TipsShow")
		{
			if (ModelBase<SurvivorsRogueModel>.Instance.IsEndlessWave)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.SurvivorsRogueShowEndlessWaveTips);
			}
			if (ModelBase<SurvivorsRogueModel>.Instance.IsBonusWave)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.SurvivorsRogueShowBonusWaveTips);
				return;
			}
		}
		else if (param == "MoveLeft")
		{
			this.NeedTick = true;
			this.MoveLengthRecord = this.WavePointWidth;
		}
	}

	// Token: 0x0600DE82 RID: 56962 RVA: 0x003BDF73 File Offset: 0x003BC173
	private void OnOpenView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.SurvivorsRogueExitView)
		{
			this.SequencePlayer.PauseSequence();
		}
	}

	// Token: 0x0600DE83 RID: 56963 RVA: 0x003BDF8D File Offset: 0x003BC18D
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.SurvivorsRogueExitView)
		{
			this.SequencePlayer.ResumeSequence();
		}
	}

	// Token: 0x0600DE84 RID: 56964 RVA: 0x003BDFA8 File Offset: 0x003BC1A8
	public void InitWavePointItem()
	{
		int num = ModelBase<SurvivorsRogueModel>.Instance.CurWaveNum - 1;
		int num2 = Math.Max(0, 6 - num);
		int num3 = 0;
		for (int i = 0; i < 12; i++)
		{
			SurvivorsRogueWavePointItem survivorsRogueWavePointItem = this.WavePointItems[i];
			if (i < num2)
			{
				survivorsRogueWavePointItem.Hide(null);
			}
			else
			{
				int num4 = num + num3 - (6 - num2);
				if (num4 >= ModelBase<SurvivorsRogueModel>.Instance.MaxWaveNum)
				{
					survivorsRogueWavePointItem.Hide(null);
				}
				else
				{
					survivorsRogueWavePointItem.SetState((EWaveType)ModelBase<SurvivorsRogueModel>.Instance.WaveTypeArray[num4]);
				}
				survivorsRogueWavePointItem.GetRootItem().SetAnchorOffsetX(this.WavePointWidth * (float)(num2 - 6 + num3 + 1));
				num3++;
			}
		}
	}

	// Token: 0x0600DE85 RID: 56965 RVA: 0x003BE048 File Offset: 0x003BC248
	public void OnTick(float delta)
	{
		if (!this.TickEnabled || !this.NeedTick)
		{
			return;
		}
		float num = 0.25f * delta;
		if (this.MoveLengthRecord - num < 0f)
		{
			num = this.MoveLengthRecord;
		}
		this.MoveLengthRecord -= num;
		if (this.MoveLengthRecord <= 0f)
		{
			this.NeedTick = false;
			this.WavePointItems[6].PlayBubbleSequence();
		}
		for (int i = 0; i < 12; i++)
		{
			SurvivorsRogueWavePointItem survivorsRogueWavePointItem = this.WavePointItems[i];
			survivorsRogueWavePointItem.GetRootItem().SetAnchorOffsetX(survivorsRogueWavePointItem.GetRootItem().GetAnchorOffsetX() - num);
		}
	}

	// Token: 0x04006AF6 RID: 27382
	private const int WAVE_POINT_COUNT = 12;

	// Token: 0x04006AF7 RID: 27383
	private const int WAVE_POINT_START_INDEX = 6;

	// Token: 0x04006AF8 RID: 27384
	private const float WAVE_POINT_MOVE_SPEED = 0.25f;

	// Token: 0x04006AF9 RID: 27385
	private UUIText WaveNumText;

	// Token: 0x04006AFA RID: 27386
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x04006AFB RID: 27387
	private readonly SurvivorsRogueWavePointItem[] WavePointItems = new SurvivorsRogueWavePointItem[12];

	// Token: 0x04006AFC RID: 27388
	private bool NeedTick;

	// Token: 0x04006AFD RID: 27389
	private float MoveLengthRecord;

	// Token: 0x04006AFE RID: 27390
	private float WavePointWidth;

	// Token: 0x04006AFF RID: 27391
	private bool TickEnabled;

	// Token: 0x0200810D RID: 33037
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BE05 RID: 179717
		public const int WavePointRoot = 0;

		// Token: 0x0402BE06 RID: 179718
		public const int WavePointTemplate = 1;

		// Token: 0x0402BE07 RID: 179719
		public const int WaveNum = 2;
	}
}
