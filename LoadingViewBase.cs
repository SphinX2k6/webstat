using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Ui.HotFix;
using UnrealEngine;

// Token: 0x020020DD RID: 8413
[NullableContext(1)]
[Nullable(0)]
public abstract class LoadingViewBase : UiTickViewBase
{
	// Token: 0x06010134 RID: 65844 RVA: 0x00469924 File Offset: 0x00467B24
	protected LoadingViewBase(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010135 RID: 65845 RVA: 0x0046992D File Offset: 0x00467B2D
	protected override void OnBeforeCreate()
	{
		ModelBase<LoadingModel>.Instance.SetIsLoadingView(true);
	}

	// Token: 0x06010136 RID: 65846 RVA: 0x0046993A File Offset: 0x00467B3A
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.LevelSequencePlayerBandStateChange, new Action<bool>(this.HandleLevelSequencePlayerBandStateChange));
	}

	// Token: 0x06010137 RID: 65847 RVA: 0x00469955 File Offset: 0x00467B55
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.LevelSequencePlayerBandStateChange, new Action<bool>(this.HandleLevelSequencePlayerBandStateChange));
	}

	// Token: 0x06010138 RID: 65848 RVA: 0x00469970 File Offset: 0x00467B70
	[NullableContext(2)]
	public string GetGenderImage(int id)
	{
		PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
		EPlayerGender? eplayerGender = (instance != null) ? new EPlayerGender?(instance.GetPlayerGender()) : null;
		BroadcastImage? broadcastImageConfig = ConfigBase<LoadingConfig>.Instance.GetBroadcastImageConfig(id);
		if (broadcastImageConfig == null)
		{
			return null;
		}
		EPlayerGender? eplayerGender2 = eplayerGender;
		EPlayerGender eplayerGender3 = EPlayerGender.Female;
		if (!(eplayerGender2.GetValueOrDefault() == eplayerGender3 & eplayerGender2 != null))
		{
			return broadcastImageConfig.Value.ImageM;
		}
		return broadcastImageConfig.Value.ImageF;
	}

	// Token: 0x06010139 RID: 65849 RVA: 0x004699EC File Offset: 0x00467BEC
	private void InitShowData()
	{
		this.ShowData = new LoadingShowData();
		this.ShowData.Initialize();
		string text = this.GetGenderImage(this.ShowData.GetImageId());
		if (Singleton<BaseConfigController>.Instance.GetIosAuditFirstDownloadTip())
		{
			text = "/Game/Aki/UI/UIResources/Common/Image/BgCg/T_Bgloadin10_UI.T_Bgloadin10_UI";
		}
		if (!string.IsNullOrEmpty(ModelBase<LoadingModel>.Instance.LoadingTexturePathOverride))
		{
			text = ModelBase<LoadingModel>.Instance.LoadingTexturePathOverride;
		}
		if (text != null)
		{
			ModelBase<LoadingModel>.Instance.SetLoadingTexturePath(text);
			this.UpdateBgUi(text);
		}
	}

	// Token: 0x0601013A RID: 65850 RVA: 0x00469A64 File Offset: 0x00467C64
	protected virtual void UpdateBgUi(string path)
	{
	}

	// Token: 0x0601013B RID: 65851 RVA: 0x00469A68 File Offset: 0x00467C68
	protected override void OnStart()
	{
		HotFixSceneManager.StopHotPatchBgm();
		this.InitShowData();
		this.InitProgress();
		this.ChangeShowTips();
		if (ModelBase<LoginModel>.Instance.HasBackToGameData())
		{
			BackToGameData backToGameData = ModelBase<LoginModel>.Instance.GetBackToGameData();
			this.BackToGameLoadingViewData = new BackToGameLoadingViewData();
			this.BackToGameLoadingViewData.LoadingWidget = backToGameData.LoadingWidget;
			this.BackToGameLoadingViewData.RebootFinished();
			ModelBase<LoginModel>.Instance.RemoveBackToGameData();
		}
	}

	// Token: 0x0601013C RID: 65852 RVA: 0x00469AD8 File Offset: 0x00467CD8
	protected void ChangeShowTips()
	{
		this.TipTimeElapsed = 0.0;
		LoadingTipsText? nextTip = this.ShowData.GetNextTip();
		if (nextTip == null)
		{
			return;
		}
		ModelBase<LoadingModel>.Instance.SetLoadingTitle(nextTip.Value.Title);
		ModelBase<LoadingModel>.Instance.SetLoadingTips(nextTip.Value.TipsText);
		this.UpdateShowTipsUi(nextTip.Value.Title, nextTip.Value.TipsText);
	}

	// Token: 0x0601013D RID: 65853 RVA: 0x00469B60 File Offset: 0x00467D60
	protected virtual void UpdateShowTipsUi(string title, string tips)
	{
	}

	// Token: 0x0601013E RID: 65854 RVA: 0x00469B62 File Offset: 0x00467D62
	protected override void OnAfterShow()
	{
		if (this.BackToGameLoadingViewData != null)
		{
			base.GetRootItem().SetUIActive(false);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.LoadingViewOnAfterShow);
	}

	// Token: 0x0601013F RID: 65855 RVA: 0x00469B88 File Offset: 0x00467D88
	protected override void OnTick(float delta)
	{
		float num = delta / (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		this.LoadingTimeElapsed += (double)num;
		this.TickProgress(num);
		this.TipTimeElapsed += (double)num;
		if (this.TipTimeElapsed >= (double)ModelBase<LoadingModel>.Instance.TipTime)
		{
			this.ChangeShowTips();
		}
	}

	// Token: 0x06010140 RID: 65856 RVA: 0x00469BE4 File Offset: 0x00467DE4
	private void TickProgress(float delta)
	{
		if (this.Closing)
		{
			return;
		}
		LoadingModel instance = ModelBase<LoadingModel>.Instance;
		int num = 100;
		float num2 = Math.Min(instance.CurrentProgress + (float)(instance.Speed * instance.SpeedRate) * delta, (float)instance.NextProgress);
		float progressRate = num2 / (float)num;
		instance.CurrentProgress = num2;
		this.UpdateProgress(progressRate, num2);
		while (instance.ReachHandleQueue.Size > 0)
		{
			ValueTuple<int, Action> front = instance.ReachHandleQueue.Front;
			if ((float)front.Item1 > num2)
			{
				break;
			}
			instance.ReachHandleQueue.Pop();
			front.Item2();
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Loading;
			ELogAuthor author = ELogAuthor.TL;
			string message = "TickProgress";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("progress", num2);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		int duringTime = this.ShowData.GetDuringTime();
		if (!this.Closing && num2 >= (float)num && this.LoadingTimeElapsed >= (double)duringTime)
		{
			this.Closing = true;
			Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
			BackToGameLoadingViewData backToGameLoadingViewData = this.BackToGameLoadingViewData;
			if (backToGameLoadingViewData != null)
			{
				backToGameLoadingViewData.Close();
			}
			this.BackToGameLoadingViewData = null;
		}
	}

	// Token: 0x06010141 RID: 65857 RVA: 0x00469D04 File Offset: 0x00467F04
	private void InitProgress()
	{
		float currentProgress = ModelBase<LoadingModel>.Instance.CurrentProgress;
		float progressRate = currentProgress / 100f;
		this.UpdateProgress(progressRate, currentProgress);
	}

	// Token: 0x06010142 RID: 65858 RVA: 0x00469D2C File Offset: 0x00467F2C
	private void UpdateProgress(float progressRate, float progressValue)
	{
		BackToGameLoadingViewData backToGameLoadingViewData = this.BackToGameLoadingViewData;
		if (backToGameLoadingViewData != null)
		{
			backToGameLoadingViewData.SetProgress(progressRate);
		}
		this.UpdateProgressRate(progressRate);
		this.UpdateProgressValue(progressValue);
	}

	// Token: 0x06010143 RID: 65859 RVA: 0x00469D4E File Offset: 0x00467F4E
	private void HandleLevelSequencePlayerBandStateChange(bool state)
	{
		this.OnLevelSequencePlayerBandStateChange(state);
	}

	// Token: 0x06010144 RID: 65860 RVA: 0x00469D57 File Offset: 0x00467F57
	protected virtual void OnLevelSequencePlayerBandStateChange(bool state)
	{
	}

	// Token: 0x06010145 RID: 65861
	protected abstract void UpdateProgressRate(float rate);

	// Token: 0x06010146 RID: 65862
	protected abstract void UpdateProgressValue(float value);

	// Token: 0x06010147 RID: 65863 RVA: 0x00469D5C File Offset: 0x00467F5C
	protected override void OnBeforeDestroyImplement()
	{
		LoadingModel instance = ModelBase<LoadingModel>.Instance;
		instance.SetIsLoadingView(false);
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshCursor);
		while (instance.ReachHandleQueue.Size > 0)
		{
			instance.ReachHandleQueue.Pop().Item2();
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Loading;
			ELogAuthor author = ELogAuthor.TL;
			string message = "OnBeforeDestroyImplement";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("loadingModel.ReachHandleQueue.Size", instance.ReachHandleQueue.Size);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x06010148 RID: 65864 RVA: 0x00469DE1 File Offset: 0x00467FE1
	protected override void OnAfterDestroy()
	{
		BackToGameLoadingViewData backToGameLoadingViewData = this.BackToGameLoadingViewData;
		if (backToGameLoadingViewData == null)
		{
			return;
		}
		backToGameLoadingViewData.Close();
	}

	// Token: 0x06010149 RID: 65865 RVA: 0x00469DF4 File Offset: 0x00467FF4
	protected virtual void SetTextProgressValue(int textKey, float value, string suffix = "")
	{
		double value2 = Math.Round((double)value);
		UUIText text = base.GetText(textKey);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
		defaultInterpolatedStringHandler.AppendFormatted<double>(value2);
		defaultInterpolatedStringHandler.AppendFormatted(suffix);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0601014A RID: 65866 RVA: 0x00469E36 File Offset: 0x00468036
	protected void SetTextureProgressRate(int textureKey, float rate)
	{
		base.GetTexture(textureKey).SetFillAmount(rate);
	}

	// Token: 0x04007B3B RID: 31547
	private double TipTimeElapsed;

	// Token: 0x04007B3C RID: 31548
	private double LoadingTimeElapsed;

	// Token: 0x04007B3D RID: 31549
	[Nullable(2)]
	protected LoadingShowData ShowData;

	// Token: 0x04007B3E RID: 31550
	private bool Closing;

	// Token: 0x04007B3F RID: 31551
	[Nullable(2)]
	private BackToGameLoadingViewData BackToGameLoadingViewData;
}
