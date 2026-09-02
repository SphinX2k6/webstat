using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018D1 RID: 6353
[NullableContext(2)]
[Nullable(0)]
public class ExpTweenComponent
{
	// Token: 0x0600B6BB RID: 46779 RVA: 0x00309700 File Offset: 0x00307900
	[NullableContext(1)]
	public ExpTweenComponent(UUISprite currentSprite, UUISprite addSprite, UUISprite nextSprite, [Nullable(2)] UUIItem parent, [Nullable(2)] Action tweenFinishFunction = null)
	{
		this.AddSprite = addSprite;
		this.CurrentSprite = currentSprite;
		this.NextSprite = nextSprite;
		this.TweenFinishFunction = tweenFinishFunction;
		this.Delegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.PlayFillAmount));
		this.PreviewDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.PlayPreviewFillAmount));
	}

	// Token: 0x0600B6BC RID: 46780 RVA: 0x0030977C File Offset: 0x0030797C
	protected void PlayTween(int currentCount, int targetCount, float time, float delay = 0f, LTweenEase ease = LTweenEase.Linear)
	{
		float startValue = (currentCount == 1) ? this.CurrentSprite.GetFillAmount() : 0f;
		float num = (currentCount == targetCount) ? this.FinalFillAmount : 1f;
		if (currentCount == targetCount)
		{
			this.AddSprite.SetFillAmount(num);
		}
		Singleton<UiLayer>.Instance.SetShowMaskLayer("ExpTweenComponent", true);
		this.ExpTweener = ULTweenBPLibrary.FloatTo(GlobalData.World, this.Delegate, startValue, num, time, delay, ease);
		this.ExpTweener.OnCompleteCallBack.Bind(delegate()
		{
			this.TweenCompleteCallBack(currentCount, targetCount, time, delay, ease);
		});
	}

	// Token: 0x0600B6BD RID: 46781 RVA: 0x00309864 File Offset: 0x00307A64
	protected void TweenCompleteCallBack(int currentCount, int targetCount, float time, float delay = 0f, LTweenEase ease = LTweenEase.Linear)
	{
		this.KillExpTweener();
		if (this.PlayCompleteCallBack != null)
		{
			this.PlayCompleteCallBack(currentCount == targetCount);
		}
		if (currentCount < targetCount)
		{
			this.PlayTween(currentCount + 1, targetCount, time, delay, ease);
			return;
		}
		Singleton<UiLayer>.Instance.SetShowMaskLayer("ExpTweenComponent", false);
		if (this.TweenFinishFunction != null)
		{
			this.TweenFinishFunction();
		}
	}

	// Token: 0x0600B6BE RID: 46782 RVA: 0x003098C5 File Offset: 0x00307AC5
	protected void PlayFillAmount(float value)
	{
		this.SetCurrentFillAmount(value);
	}

	// Token: 0x0600B6BF RID: 46783 RVA: 0x003098CE File Offset: 0x00307ACE
	protected void KillExpTweener()
	{
		if (this.ExpTweener != null)
		{
			this.ExpTweener.Kill(false);
			this.ExpTweener = null;
		}
	}

	// Token: 0x0600B6C0 RID: 46784 RVA: 0x003098EC File Offset: 0x00307AEC
	protected void PlayPreviewTween(float start, float end, float time, bool needAgain)
	{
		this.PreviewExpTweener = ULTweenBPLibrary.FloatTo(GlobalData.World, this.PreviewDelegate, start, end, time, 0f, LTweenEase.OutCubic);
		this.PreviewExpTweener.OnCompleteCallBack.Bind(delegate()
		{
			this.PreviewTweenCompleteCallBack(time, needAgain);
		});
	}

	// Token: 0x0600B6C1 RID: 46785 RVA: 0x00309955 File Offset: 0x00307B55
	protected void PreviewTweenCompleteCallBack(float playTime, bool needAgain)
	{
		this.KillPreviewExpTweener(false);
		if (needAgain)
		{
			this.PreviewTweenPlayAgainState(playTime);
			return;
		}
		this.PreviewTweenStopState();
	}

	// Token: 0x0600B6C2 RID: 46786 RVA: 0x00309970 File Offset: 0x00307B70
	protected void PreviewTweenStopState()
	{
		if (this.PreviewFinalFillAmount == 1f)
		{
			this.SetCurrentSpriteActive(false);
			this.SetNextSpriteActive(true);
			this.SetNextFillAmount(this.PreviewFinalFillAmount);
			return;
		}
		if (this.TargetLevel == this.CurrentLevel)
		{
			this.SetCurrentSpriteActive(true);
			this.SetAddFillAmount(this.PreviewFinalFillAmount);
			this.SetNextSpriteActive(false);
		}
	}

	// Token: 0x0600B6C3 RID: 46787 RVA: 0x003099D0 File Offset: 0x00307BD0
	protected void PreviewTweenPlayAgainState(float playTime)
	{
		if (this.ArrivedLevel > this.TargetLevel)
		{
			this.InCurrent = (this.TargetLevel == this.CurrentLevel);
			if (this.InCurrent)
			{
				this.SetCurrentSpriteActive(true);
				this.SetNextSpriteActive(false);
			}
			this.PlayPreviewTween(1f, this.PreviewFinalFillAmount, playTime, false);
			return;
		}
		if (this.ArrivedLevel < this.TargetLevel)
		{
			this.InCurrent = false;
			this.SetCurrentSpriteActive(false);
			this.SetNextSpriteActive(true);
			this.PlayPreviewTween(0f, this.PreviewFinalFillAmount, playTime, false);
		}
	}

	// Token: 0x0600B6C4 RID: 46788 RVA: 0x00309A5F File Offset: 0x00307C5F
	protected void PlayPreviewFillAmount(float value)
	{
		if (this.InCurrent)
		{
			this.SetAddFillAmount(value);
			return;
		}
		this.SetNextFillAmount(value);
		if (this.AddSprite.GetFillAmount() != 1f)
		{
			this.SetAddFillAmount(1f);
		}
	}

	// Token: 0x0600B6C5 RID: 46789 RVA: 0x00309A95 File Offset: 0x00307C95
	protected void KillPreviewExpTweener(bool callComplete = false)
	{
		ULTweener previewExpTweener = this.PreviewExpTweener;
		if (previewExpTweener != null)
		{
			previewExpTweener.Kill(false);
		}
		this.PreviewExpTweener = null;
		if (callComplete)
		{
			this.PreviewTweenStopState();
		}
	}

	// Token: 0x0600B6C6 RID: 46790 RVA: 0x00309AB9 File Offset: 0x00307CB9
	[NullableContext(1)]
	public void BindPlayCompleteCallBack(Action<bool> callback)
	{
		this.PlayCompleteCallBack = callback;
	}

	// Token: 0x0600B6C7 RID: 46791 RVA: 0x00309AC2 File Offset: 0x00307CC2
	[NullableContext(1)]
	public void BindPlayCurrentFillAmountCallback(Action<float> callback)
	{
		this.PlayCurrentFillAmountCallback = callback;
	}

	// Token: 0x0600B6C8 RID: 46792 RVA: 0x00309ACB File Offset: 0x00307CCB
	public void SetCurrentFillAmount(float fillAmount)
	{
		this.CurrentSprite.SetFillAmount(fillAmount);
		if (this.PlayCurrentFillAmountCallback != null)
		{
			this.PlayCurrentFillAmountCallback(fillAmount);
		}
	}

	// Token: 0x0600B6C9 RID: 46793 RVA: 0x00309AED File Offset: 0x00307CED
	public void SetNextFillAmount(float fillAmount)
	{
		this.NextSprite.SetFillAmount(fillAmount);
	}

	// Token: 0x0600B6CA RID: 46794 RVA: 0x00309AFB File Offset: 0x00307CFB
	public void SetAddFillAmount(float fillAmount)
	{
		this.AddSprite.SetFillAmount(fillAmount);
	}

	// Token: 0x0600B6CB RID: 46795 RVA: 0x00309B09 File Offset: 0x00307D09
	public void SetCurrentSpriteActive(bool bActive)
	{
		this.CurrentSprite.SetUIActive(bActive);
	}

	// Token: 0x0600B6CC RID: 46796 RVA: 0x00309B17 File Offset: 0x00307D17
	public void SetNextSpriteActive(bool bActive)
	{
		this.NextSprite.SetUIActive(bActive);
	}

	// Token: 0x0600B6CD RID: 46797 RVA: 0x00309B28 File Offset: 0x00307D28
	public void PlayExpTween(int targetCount, float finalFillAmount, float delay = 0f, LTweenEase ease = LTweenEase.Linear)
	{
		this.SetCurrentSpriteActive(true);
		this.SetNextSpriteActive(false);
		this.AddSprite.SetFillAmount(0f);
		this.FinalFillAmount = finalFillAmount;
		float time = this.TweenTime / (float)targetCount;
		this.PlayTween(this.StartCount, targetCount, time, delay, ease);
	}

	// Token: 0x0600B6CE RID: 46798 RVA: 0x00309B78 File Offset: 0x00307D78
	public void PlayPreviewExpTween(int currentLevel, int lastTimeArrivedLevel, int targetLevel, int currentMaxLevel, float targetFillAmount)
	{
		this.KillPreviewExpTweener(true);
		this.PreviewFinalFillAmount = targetFillAmount;
		float start = (lastTimeArrivedLevel != currentLevel) ? this.NextSprite.GetFillAmount() : this.AddSprite.GetFillAmount();
		float? num = null;
		if (lastTimeArrivedLevel > targetLevel && lastTimeArrivedLevel != currentMaxLevel)
		{
			num = new float?(0f);
		}
		else if (lastTimeArrivedLevel < targetLevel || targetLevel == currentMaxLevel)
		{
			num = new float?((float)1);
		}
		else
		{
			num = new float?(targetFillAmount);
		}
		this.InCurrent = (lastTimeArrivedLevel == currentLevel);
		this.CurrentLevel = currentLevel;
		this.ArrivedLevel = lastTimeArrivedLevel;
		this.TargetLevel = targetLevel;
		bool flag = this.ArrivedLevel != this.TargetLevel && this.ArrivedLevel != currentMaxLevel && this.TargetLevel != currentMaxLevel;
		float time = flag ? (this.PreviewTweenTime / 2f) : this.PreviewTweenTime;
		this.PlayPreviewTween(start, num.Value, time, flag);
	}

	// Token: 0x0600B6CF RID: 46799 RVA: 0x00309C60 File Offset: 0x00307E60
	public void Destroy()
	{
		Singleton<UiLayer>.Instance.SetShowMaskLayer("ExpTweenComponent", false);
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.PlayFillAmount));
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.PlayPreviewFillAmount));
		this.Delegate = null;
		this.PreviewDelegate = null;
		this.KillExpTweener();
		this.KillPreviewExpTweener(false);
		this.CurrentSprite = null;
		this.AddSprite = null;
		this.NextSprite = null;
	}

	// Token: 0x04005612 RID: 22034
	protected UUISprite AddSprite;

	// Token: 0x04005613 RID: 22035
	protected UUISprite CurrentSprite;

	// Token: 0x04005614 RID: 22036
	protected UUISprite NextSprite;

	// Token: 0x04005615 RID: 22037
	protected ULTweener ExpTweener;

	// Token: 0x04005616 RID: 22038
	protected float TweenTime = 1f;

	// Token: 0x04005617 RID: 22039
	protected int StartCount = 1;

	// Token: 0x04005618 RID: 22040
	protected float FinalFillAmount;

	// Token: 0x04005619 RID: 22041
	protected FLTweenFloatSetterDynamic Delegate;

	// Token: 0x0400561A RID: 22042
	protected ULTweener PreviewExpTweener;

	// Token: 0x0400561B RID: 22043
	protected float PreviewTweenTime = 0.5f;

	// Token: 0x0400561C RID: 22044
	protected float PreviewFinalFillAmount;

	// Token: 0x0400561D RID: 22045
	protected FLTweenFloatSetterDynamic PreviewDelegate;

	// Token: 0x0400561E RID: 22046
	protected int CurrentLevel;

	// Token: 0x0400561F RID: 22047
	protected int ArrivedLevel;

	// Token: 0x04005620 RID: 22048
	protected int TargetLevel;

	// Token: 0x04005621 RID: 22049
	protected bool InCurrent;

	// Token: 0x04005622 RID: 22050
	private Action<float> PlayCurrentFillAmountCallback;

	// Token: 0x04005623 RID: 22051
	private Action<bool> PlayCompleteCallBack;

	// Token: 0x04005624 RID: 22052
	protected Action TweenFinishFunction;
}
