using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;

// Token: 0x02002611 RID: 9745
[NullableContext(2)]
[Nullable(0)]
public class CommonQteDragContext : CommonQteContextBase
{
	// Token: 0x060131F5 RID: 78325 RVA: 0x0054D680 File Offset: 0x0054B880
	public CommonQteDragContext()
	{
		this.Type = new ECommonQteContextType?(ECommonQteContextType.SingleButtonDrag);
	}

	// Token: 0x060131F6 RID: 78326 RVA: 0x0054D6A4 File Offset: 0x0054B8A4
	[NullableContext(1)]
	protected override void OnSetConfig(SCommonQte config)
	{
		SCommonQte_Drag dragConfig = config.BaseConfig.DragConfig;
		this.IsCheckByRealInput = config.BaseConfig.DragConfig.CheckByRealTimeInput;
		this.Direction = (float)dragConfig.Direction * 0.017453292f;
		this.ToleranceAngle = dragConfig.ToleranceAngle * 0.017453292f + 1E-08f;
		float num = 0f;
		this.CacheProgress = 0f;
		if (dragConfig.ViewType == ECommonQteViewType_Drag.右半屏拖动界面)
		{
			num = dragConfig.DragLength;
		}
		else if (this.IsFullScreenSlideViewType(dragConfig.ViewType))
		{
			num = dragConfig.SlideLength;
		}
		else if (dragConfig.ViewType == ECommonQteViewType_Drag.穗穗左右滑界面)
		{
			this.Length = 0.5f;
			this.CacheProgress = 0.5f;
			num = (dragConfig.IsLeftSuccess ? dragConfig.LeftSlideLength : dragConfig.RightSlideLength);
		}
		if (num > 0f && dragConfig.LerpSpeed > 0f)
		{
			float num2 = (dragConfig.ViewType == ECommonQteViewType_Drag.穗穗左右滑界面) ? 0.5f : 1f;
			this.LerpSpeedInProgress = (double)(dragConfig.LerpSpeed * num2 / num / 1000f);
			return;
		}
		this.LerpSpeedInProgress = -1.0;
	}

	// Token: 0x060131F7 RID: 78327 RVA: 0x0054D7E3 File Offset: 0x0054B9E3
	private bool IsFullScreenSlideViewType(ECommonQteViewType_Drag viewType)
	{
		return viewType == ECommonQteViewType_Drag.全屏上拉界面 || viewType == ECommonQteViewType_Drag.全屏下拉界面 || viewType == ECommonQteViewType_Drag.穗穗右滑界面 || viewType == ECommonQteViewType_Drag.穗穗下滑界面;
	}

	// Token: 0x060131F8 RID: 78328 RVA: 0x0054D7F8 File Offset: 0x0054B9F8
	protected override string OnGetAction(int? index = null)
	{
		if (this.Config == null)
		{
			return null;
		}
		if (this.Config.BaseConfig.DragConfig.ViewType == ECommonQteViewType_Drag.滑动通用界面)
		{
			return "Ui右摇杆";
		}
		SCommonQteButton uiconfig = this.Config.BaseConfig.DragConfig.UIConfig;
		return CommonQteContextBase.GetQteActionNameByActionId((uiconfig.ActionId > 0) ? uiconfig.ActionId : ((int)uiconfig.Action), new int?(this.QteId));
	}

	// Token: 0x060131F9 RID: 78329 RVA: 0x0054D87F File Offset: 0x0054BA7F
	[PreserveBaseOverrides]
	protected new virtual SCommonQte_Drag OnGetUiConfig()
	{
		if (this.Config == null)
		{
			return null;
		}
		return this.Config.BaseConfig.DragConfig;
	}

	// Token: 0x060131FA RID: 78330 RVA: 0x0054D8A4 File Offset: 0x0054BAA4
	protected override void OnResponse()
	{
		if (this.Config == null)
		{
			return;
		}
		if (base.IsPending())
		{
			ControllerBase<CommonQteController>.Instance.PlayExtraEffect(this.HandleId);
			if (this.AudioHandle != 0)
			{
				ControllerBase<CommonQteController>.Instance.StopQteAudio(this.AudioHandle, null);
				this.AudioHandle = 0;
			}
			this.AudioHandle = ControllerBase<CommonQteController>.Instance.PlayQteAudio(this.Config.AudioConfig.AudioEventResponse, this.UiActor);
		}
	}

	// Token: 0x060131FB RID: 78331 RVA: 0x0054D928 File Offset: 0x0054BB28
	protected override void OnResponseEnd()
	{
		if (this.Config == null)
		{
			return;
		}
		ControllerBase<CommonQteController>.Instance.StopExtraEffect(this.HandleId);
		if (this.AudioHandle != 0)
		{
			ControllerBase<CommonQteController>.Instance.StopQteAudio(this.AudioHandle, null);
			this.AudioHandle = 0;
		}
		if (base.IsPending())
		{
			this.AudioHandle = ControllerBase<CommonQteController>.Instance.PlayQteAudio(this.Config.AudioConfig.AudioEventResponseEnd, this.UiActor);
		}
	}

	// Token: 0x060131FC RID: 78332 RVA: 0x0054D9AC File Offset: 0x0054BBAC
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
		float progress = this.GetProgress();
		if (base.IsPending())
		{
			Singleton<AudioSystem>.Instance.SetRtpcValue("perform_qte_progress_default", this.GetProgress(), new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = this.UiActor
			}));
			if (progress > this.CacheProgress)
			{
				if (this.RegressAudioHandle != 0)
				{
					ControllerBase<CommonQteController>.Instance.StopQteAudio(this.RegressAudioHandle, null);
					this.RegressAudioHandle = 0;
				}
				if (this.ProgressAudioHandle == 0 && this.Config.AudioConfig.AudioEventProgress != null)
				{
					this.ProgressAudioHandle = ControllerBase<CommonQteController>.Instance.PlayQteAudio(this.Config.AudioConfig.AudioEventProgress, this.UiActor);
					ControllerBase<CommonQteController>.Instance.SeekAudio(progress, this.Config.AudioConfig.AudioEventProgress, this.UiActor, new int?(this.ProgressAudioHandle));
				}
			}
			else if (progress < this.CacheProgress)
			{
				if (this.ProgressAudioHandle != 0)
				{
					ControllerBase<CommonQteController>.Instance.StopQteAudio(this.ProgressAudioHandle, null);
					this.ProgressAudioHandle = 0;
				}
				if (this.RegressAudioHandle == 0 && this.Config.AudioConfig.AudioEventRegress != null)
				{
					this.RegressAudioHandle = ControllerBase<CommonQteController>.Instance.PlayQteAudio(this.Config.AudioConfig.AudioEventRegress, this.UiActor);
					ControllerBase<CommonQteController>.Instance.SeekAudio(progress, this.Config.AudioConfig.AudioEventRegress, this.UiActor, new int?(this.RegressAudioHandle));
				}
				if (progress == 0f)
				{
					ControllerBase<CommonQteController>.Instance.PlayQteAudio(this.Config.AudioConfig.AudioEventReset, this.UiActor);
				}
			}
		}
		this.CacheProgress = progress;
		if (!this.IsPermanent && this.PassTime > this.Duration)
		{
			base.QteFail();
		}
	}

	// Token: 0x060131FD RID: 78333 RVA: 0x0054DC04 File Offset: 0x0054BE04
	public override bool CheckQteConditionMatch()
	{
		return this.PreResult.GetValueOrDefault() || this.CheckDragComplete(this.Length, this.Angle);
	}

	// Token: 0x060131FE RID: 78334 RVA: 0x0054DC27 File Offset: 0x0054BE27
	public void SetPreResult(bool isSuccess)
	{
		this.PreResult = new bool?(isSuccess);
	}

	// Token: 0x060131FF RID: 78335 RVA: 0x0054DC35 File Offset: 0x0054BE35
	protected override void OnQteSuccess()
	{
		this.StopQteAudio();
	}

	// Token: 0x06013200 RID: 78336 RVA: 0x0054DC3D File Offset: 0x0054BE3D
	protected override void OnQteFail()
	{
		this.StopQteAudio();
	}

	// Token: 0x06013201 RID: 78337 RVA: 0x0054DC45 File Offset: 0x0054BE45
	public void StopMoveAudioAndSyncProgress()
	{
		this.StopQteAudio();
		this.CacheProgress = this.GetProgress();
	}

	// Token: 0x06013202 RID: 78338 RVA: 0x0054DC5C File Offset: 0x0054BE5C
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

	// Token: 0x06013203 RID: 78339 RVA: 0x0054DCD4 File Offset: 0x0054BED4
	public bool CheckDragComplete(float length, float angle)
	{
		SCommonQte config = this.Config;
		SCommonQte_Drag scommonQte_Drag = (config != null) ? config.BaseConfig.DragConfig : null;
		if (scommonQte_Drag == null)
		{
			return false;
		}
		if (scommonQte_Drag.ViewType == ECommonQteViewType_Drag.滑动通用界面)
		{
			if (length >= scommonQte_Drag.SlideLength && Math.Abs(angle - this.Direction) <= this.ToleranceAngle)
			{
				return true;
			}
		}
		else if (scommonQte_Drag.ViewType == ECommonQteViewType_Drag.全屏上拉界面)
		{
			if (length >= scommonQte_Drag.SlideLength && Math.Abs(angle - 1.5707964f) <= this.ToleranceAngle)
			{
				return true;
			}
		}
		else if (scommonQte_Drag.ViewType == ECommonQteViewType_Drag.全屏下拉界面 || scommonQte_Drag.ViewType == ECommonQteViewType_Drag.穗穗下滑界面)
		{
			if (length >= scommonQte_Drag.SlideLength && Math.Abs(angle - -1.5707964f) <= this.ToleranceAngle)
			{
				return true;
			}
		}
		else if (scommonQte_Drag.ViewType == ECommonQteViewType_Drag.穗穗右滑界面)
		{
			if (length >= scommonQte_Drag.SlideLength && Math.Abs(angle) <= this.ToleranceAngle)
			{
				return true;
			}
		}
		else if (scommonQte_Drag.ViewType == ECommonQteViewType_Drag.罗盘旋转界面)
		{
			if (Math.Abs(angle - 1.5707964f) <= this.ToleranceAngle)
			{
				return true;
			}
		}
		else if (scommonQte_Drag.ViewType == ECommonQteViewType_Drag.右半屏拖动界面)
		{
			if (length >= 1f)
			{
				return true;
			}
		}
		else if (scommonQte_Drag.ViewType == ECommonQteViewType_Drag.穗穗左右滑界面)
		{
			if (scommonQte_Drag.IsLeftSuccess)
			{
				return scommonQte_Drag.LeftSlideLength > 0f && length <= 0f;
			}
			return scommonQte_Drag.RightSlideLength > 0f && length >= 1f;
		}
		return false;
	}

	// Token: 0x06013204 RID: 78340 RVA: 0x0054DE8C File Offset: 0x0054C08C
	public bool CheckDragFail(float progress)
	{
		SCommonQte config = this.Config;
		SCommonQte_Drag scommonQte_Drag = (config != null) ? config.BaseConfig.DragConfig : null;
		if (scommonQte_Drag == null || scommonQte_Drag.ViewType != ECommonQteViewType_Drag.穗穗左右滑界面)
		{
			return false;
		}
		if (scommonQte_Drag.IsLeftSuccess)
		{
			return scommonQte_Drag.RightSlideLength > 0f && progress >= 1f;
		}
		return scommonQte_Drag.LeftSlideLength > 0f && progress <= 0f;
	}

	// Token: 0x06013205 RID: 78341 RVA: 0x0054DF0C File Offset: 0x0054C10C
	public float GetSequenceResultProgress(bool isSuccess)
	{
		SCommonQte config = this.Config;
		SCommonQte_Drag scommonQte_Drag = (config != null) ? config.BaseConfig.DragConfig : null;
		if (!(scommonQte_Drag != null) || !(scommonQte_Drag.ViewType == ECommonQteViewType_Drag.穗穗左右滑界面))
		{
			return 1f;
		}
		if (!(isSuccess ? scommonQte_Drag.IsLeftSuccess : (!scommonQte_Drag.IsLeftSuccess)))
		{
			return 1f;
		}
		return 0f;
	}

	// Token: 0x06013206 RID: 78342 RVA: 0x0054DF74 File Offset: 0x0054C174
	public double GetSequenceResultLerpSpeedInProgress(bool isSuccess)
	{
		SCommonQte config = this.Config;
		SCommonQte_Drag scommonQte_Drag = (config != null) ? config.BaseConfig.DragConfig : null;
		if (scommonQte_Drag == null || scommonQte_Drag.ViewType != ECommonQteViewType_Drag.穗穗左右滑界面)
		{
			return this.LerpSpeedInProgress;
		}
		float num = (isSuccess ? scommonQte_Drag.IsLeftSuccess : (!scommonQte_Drag.IsLeftSuccess)) ? scommonQte_Drag.LeftSlideLength : scommonQte_Drag.RightSlideLength;
		if (num > 0f && scommonQte_Drag.LerpSpeed > 0f)
		{
			return (double)(scommonQte_Drag.LerpSpeed * 0.5f / num / 1000f);
		}
		return -1.0;
	}

	// Token: 0x06013207 RID: 78343 RVA: 0x0054E018 File Offset: 0x0054C218
	public override float GetProgress()
	{
		SCommonQte config = this.Config;
		SCommonQte_Drag scommonQte_Drag = (config != null) ? config.BaseConfig.DragConfig : null;
		if (scommonQte_Drag == null)
		{
			return 0f;
		}
		if (this.IsFullScreenSlideViewType(scommonQte_Drag.ViewType))
		{
			return this.Length / scommonQte_Drag.SlideLength;
		}
		if (scommonQte_Drag.ViewType == ECommonQteViewType_Drag.罗盘旋转界面)
		{
			return this.Angle / 1.5707964f;
		}
		if (scommonQte_Drag.ViewType == ECommonQteViewType_Drag.右半屏拖动界面)
		{
			return this.Length;
		}
		if (scommonQte_Drag.ViewType == ECommonQteViewType_Drag.穗穗左右滑界面)
		{
			return this.Length;
		}
		return 0f;
	}

	// Token: 0x06013208 RID: 78344 RVA: 0x0054E0C6 File Offset: 0x0054C2C6
	public void SetDraggingInfo(float length, float angle)
	{
		this.Length = length;
		this.Angle = angle;
		this.CheckQteConditionAndDoSuccess();
	}

	// Token: 0x06013209 RID: 78345 RVA: 0x0054E0DD File Offset: 0x0054C2DD
	public override bool IsAttachToActor()
	{
		SCommonQte config = this.Config;
		return config != null && config.BaseConfig.DragConfig.IsAttachToActor;
	}

	// Token: 0x0601320A RID: 78346 RVA: 0x0054E0FC File Offset: 0x0054C2FC
	public override SCommonQte_Attach? GetAttachConfig()
	{
		SCommonQte config = this.Config;
		if (config == null)
		{
			return null;
		}
		return new SCommonQte_Attach?(config.BaseConfig.DragConfig.AttachConfig);
	}

	// Token: 0x04009539 RID: 38201
	private float Length;

	// Token: 0x0400953A RID: 38202
	private float Angle;

	// Token: 0x0400953B RID: 38203
	private float Direction;

	// Token: 0x0400953C RID: 38204
	private float ToleranceAngle;

	// Token: 0x0400953D RID: 38205
	private float CacheProgress;

	// Token: 0x0400953E RID: 38206
	public bool? PreResult;

	// Token: 0x0400953F RID: 38207
	public bool IsCheckByRealInput;

	// Token: 0x04009540 RID: 38208
	public double LerpSpeedInProgress = -1.0;

	// Token: 0x04009541 RID: 38209
	private const float DEGREE_90_RAD = 1.5707964f;

	// Token: 0x04009542 RID: 38210
	private const float DEGREE_270_RAD = -1.5707964f;

	// Token: 0x04009543 RID: 38211
	private const float SUISUI_LEFT_PROGRESS = 0f;

	// Token: 0x04009544 RID: 38212
	private const float SUISUI_CENTER_PROGRESS = 0.5f;

	// Token: 0x04009545 RID: 38213
	private const float SUISUI_RIGHT_PROGRESS = 1f;

	// Token: 0x04009546 RID: 38214
	public int ProgressAudioHandle;

	// Token: 0x04009547 RID: 38215
	public int RegressAudioHandle;
}
