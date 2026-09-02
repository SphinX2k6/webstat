using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;

// Token: 0x02002613 RID: 9747
[NullableContext(2)]
[Nullable(0)]
public class CommonQteLongPressContext : CommonQteContextBase
{
	// Token: 0x06013214 RID: 78356 RVA: 0x0054E394 File Offset: 0x0054C594
	public CommonQteLongPressContext()
	{
		this.Type = new ECommonQteContextType?(ECommonQteContextType.SingleButtonLongPress);
	}

	// Token: 0x06013215 RID: 78357 RVA: 0x0054E3A8 File Offset: 0x0054C5A8
	[NullableContext(1)]
	protected override void OnSetConfig(SCommonQte config)
	{
		SCommonQte_LongPress longPressConfig = config.BaseConfig.LongPressConfig;
		this.InitProgress = longPressConfig.InitProgress;
		this.MaxProgress = longPressConfig.MaxProgress;
		this.TargetProgress = longPressConfig.TargetProgress;
		this.IncreaseSpeed = longPressConfig.IncreaseSpeed * (float)Singleton<TimeUtil>.Instance.Millisecond;
		this.DecreaseSpeed = longPressConfig.DecreaseSpeed * (float)Singleton<TimeUtil>.Instance.Millisecond;
		this.CheckInResponseEnd = longPressConfig.IsCheckOnRelease;
		this.CurrentProgress = this.InitProgress;
	}

	// Token: 0x06013216 RID: 78358 RVA: 0x0054E430 File Offset: 0x0054C630
	protected override void OnResponse()
	{
		if (this.Config == null)
		{
			return;
		}
		if (!base.IsPending() && !base.IsPendingSuccess())
		{
			return;
		}
		if (base.IsPending())
		{
			this.IsPressing = true;
			ControllerBase<CommonQteController>.Instance.PlayExtraEffect(this.HandleId);
			this.AudioHandle = ControllerBase<CommonQteController>.Instance.PlayQteAudio(this.Config.AudioConfig.AudioEventResponse, this.UiActor);
		}
		this.CheckQteConditionAndDoSuccess();
	}

	// Token: 0x06013217 RID: 78359 RVA: 0x0054E4AC File Offset: 0x0054C6AC
	protected override void OnResponseEnd()
	{
		this.IsPressing = false;
		ControllerBase<CommonQteController>.Instance.StopExtraEffect(this.HandleId);
		if (this.AudioHandle != 0)
		{
			ControllerBase<CommonQteController>.Instance.StopQteAudio(this.AudioHandle, null);
			this.AudioHandle = 0;
		}
		if (this.CheckInResponseEnd)
		{
			this.IsInResponseEnd = true;
			this.CheckQteConditionAndDoSuccess();
			this.IsInResponseEnd = false;
		}
	}

	// Token: 0x06013218 RID: 78360 RVA: 0x0054E518 File Offset: 0x0054C718
	protected override void OnUpdateTime(float delta)
	{
		if (this.Config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CommonQte;
			ELogAuthor author = ELogAuthor.WWJ;
			string message = "Context中获取不到Config";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("QteId", this.QteId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<CommonQteController>.Instance.StopCurrentQte();
			return;
		}
		this.PassTime += delta;
		float currentProgress = this.CurrentProgress;
		if (this.IsPressing)
		{
			this.CurrentProgress = Math.Min(this.MaxProgress, this.CurrentProgress + this.IncreaseSpeed * delta);
		}
		else
		{
			this.CurrentProgress = Math.Max(0f, this.CurrentProgress - this.DecreaseSpeed * delta);
		}
		bool flag = currentProgress != this.CurrentProgress;
		if (this.CheckQteConditionAndDoSuccess())
		{
			return;
		}
		if (!this.IsPermanent && this.PassTime > this.Duration)
		{
			base.QteFail();
		}
		if (base.IsPending() && flag)
		{
			Singleton<AudioSystem>.Instance.SetRtpcValue("perform_qte_progress_default", this.GetProgress(), new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = this.UiActor
			}));
			if (this.CurrentProgress > currentProgress)
			{
				if (this.RegressAudioHandle != 0)
				{
					ControllerBase<CommonQteController>.Instance.StopQteAudio(this.RegressAudioHandle, null);
					this.RegressAudioHandle = 0;
				}
				if (this.ProgressAudioHandle == 0 && this.Config.AudioConfig.AudioEventProgress != null)
				{
					this.ProgressAudioHandle = ControllerBase<CommonQteController>.Instance.PlayQteAudio(this.Config.AudioConfig.AudioEventProgress, this.UiActor);
					ControllerBase<CommonQteController>.Instance.SeekAudio((this.CurrentProgress - this.InitProgress) / this.IncreaseSpeed, this.Config.AudioConfig.AudioEventProgress, this.UiActor, new int?(this.ProgressAudioHandle));
					return;
				}
			}
			else if (this.CurrentProgress < currentProgress)
			{
				if (this.ProgressAudioHandle != 0)
				{
					ControllerBase<CommonQteController>.Instance.StopQteAudio(this.ProgressAudioHandle, null);
					this.ProgressAudioHandle = 0;
				}
				if (this.RegressAudioHandle == 0 && this.Config.AudioConfig.AudioEventRegress != null)
				{
					this.RegressAudioHandle = ControllerBase<CommonQteController>.Instance.PlayQteAudio(this.Config.AudioConfig.AudioEventRegress, this.UiActor);
					ControllerBase<CommonQteController>.Instance.SeekAudio((this.TargetProgress - this.CurrentProgress) / this.DecreaseSpeed, this.Config.AudioConfig.AudioEventRegress, this.UiActor, new int?(this.RegressAudioHandle));
				}
			}
		}
	}

	// Token: 0x06013219 RID: 78361 RVA: 0x0054E7C8 File Offset: 0x0054C9C8
	protected override void OnQteFail()
	{
		this.StopQteAudio();
	}

	// Token: 0x0601321A RID: 78362 RVA: 0x0054E7D0 File Offset: 0x0054C9D0
	protected override void OnQteSuccess()
	{
		this.StopQteAudio();
	}

	// Token: 0x0601321B RID: 78363 RVA: 0x0054E7D8 File Offset: 0x0054C9D8
	protected void StopQteAudio()
	{
		if (this.ProgressAudioHandle != 0)
		{
			ControllerBase<CommonQteController>.Instance.StopQteAudio(this.ProgressAudioHandle, new float?(this.Config.AudioConfig.AudioEventProgressFadeOutTime));
			this.ProgressAudioHandle = 0;
		}
		if (this.RegressAudioHandle != 0)
		{
			ControllerBase<CommonQteController>.Instance.StopQteAudio(this.RegressAudioHandle, new float?(this.Config.AudioConfig.AudioEventRegressFadeOutTime));
			this.RegressAudioHandle = 0;
		}
	}

	// Token: 0x0601321C RID: 78364 RVA: 0x0054E850 File Offset: 0x0054CA50
	protected override string OnGetAction(int? index = null)
	{
		if (this.Config == null)
		{
			return null;
		}
		SCommonQteButton uiconfig = this.Config.BaseConfig.LongPressConfig.UIConfig;
		return CommonQteContextBase.GetQteActionNameByActionId((uiconfig.ActionId > 0) ? uiconfig.ActionId : ((int)uiconfig.Action), new int?(this.QteId));
	}

	// Token: 0x0601321D RID: 78365 RVA: 0x0054E8AF File Offset: 0x0054CAAF
	[PreserveBaseOverrides]
	protected new virtual SCommonQte_LongPress OnGetUiConfig()
	{
		if (this.Config == null)
		{
			return null;
		}
		return this.Config.BaseConfig.LongPressConfig;
	}

	// Token: 0x0601321E RID: 78366 RVA: 0x0054E8D1 File Offset: 0x0054CAD1
	public override bool CheckQteConditionMatch()
	{
		if (this.CheckInResponseEnd)
		{
			return this.IsInResponseEnd && this.CheckProgressCondition();
		}
		return this.CheckProgressCondition();
	}

	// Token: 0x0601321F RID: 78367 RVA: 0x0054E8F2 File Offset: 0x0054CAF2
	private bool CheckProgressCondition()
	{
		return this.CurrentProgress >= this.TargetProgress;
	}

	// Token: 0x06013220 RID: 78368 RVA: 0x0054E905 File Offset: 0x0054CB05
	public override float GetProgress()
	{
		return this.CurrentProgress * 0.01f;
	}

	// Token: 0x06013221 RID: 78369 RVA: 0x0054E913 File Offset: 0x0054CB13
	public override bool IsAttachToActor()
	{
		SCommonQte config = this.Config;
		return config != null && config.BaseConfig.LongPressConfig.IsAttachToActor;
	}

	// Token: 0x06013222 RID: 78370 RVA: 0x0054E930 File Offset: 0x0054CB30
	public override SCommonQte_Attach? GetAttachConfig()
	{
		SCommonQte config = this.Config;
		if (config == null)
		{
			return null;
		}
		return new SCommonQte_Attach?(config.BaseConfig.LongPressConfig.AttachConfig);
	}

	// Token: 0x0400954A RID: 38218
	public float InitProgress;

	// Token: 0x0400954B RID: 38219
	public float MaxProgress;

	// Token: 0x0400954C RID: 38220
	public float TargetProgress;

	// Token: 0x0400954D RID: 38221
	public float IncreaseSpeed;

	// Token: 0x0400954E RID: 38222
	public float DecreaseSpeed;

	// Token: 0x0400954F RID: 38223
	public float CurrentProgress;

	// Token: 0x04009550 RID: 38224
	public int ProgressAudioHandle;

	// Token: 0x04009551 RID: 38225
	public int RegressAudioHandle;

	// Token: 0x04009552 RID: 38226
	private bool IsPressing;

	// Token: 0x04009553 RID: 38227
	private bool CheckInResponseEnd;

	// Token: 0x04009554 RID: 38228
	private bool IsInResponseEnd;
}
