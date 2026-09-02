using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Guide.StepInfo;

// Token: 0x02001E28 RID: 7720
public class TutorialListInfo
{
	// Token: 0x0600E420 RID: 58400 RVA: 0x003D6E0E File Offset: 0x003D500E
	[NullableContext(1)]
	public TutorialListInfo(GuideStepInfo stepInfo)
	{
		this.OwnerStep = stepInfo;
	}

	// Token: 0x0600E421 RID: 58401 RVA: 0x003D6E20 File Offset: 0x003D5020
	public void Init()
	{
		this.GuideId = this.OwnerStep.Id;
		GuideTutorial? guideTutorial = ConfigBase<GuideConfig>.Instance.GetGuideTutorial(this.OwnerStep.Id);
		if (guideTutorial != null && guideTutorial.GetValueOrDefault().TutorialTip)
		{
			this.TipState = ETutorialListType.Tip;
			this.TutorialTip = true;
			this.Duration = (float)this.OwnerStep.Config.Duration;
			return;
		}
		this.TipState = ETutorialListType.Pop;
		this.TutorialTip = false;
	}

	// Token: 0x0600E422 RID: 58402 RVA: 0x003D6EA8 File Offset: 0x003D50A8
	public void StopGuide()
	{
		if (this.OwnerStep != null)
		{
			this.OwnerStep.SwitchState(EGuideStepState.Finish);
			this.OwnerStep = null;
		}
	}

	// Token: 0x0600E423 RID: 58403 RVA: 0x003D6EC5 File Offset: 0x003D50C5
	public bool Tick(float delta)
	{
		if (this.TipState == ETutorialListType.Timing)
		{
			this.Duration -= delta;
			if (this.Duration <= 0f)
			{
				this.StopGuide();
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600E424 RID: 58404 RVA: 0x003D6EF4 File Offset: 0x003D50F4
	public void ClickToPopState()
	{
		if (this.TipState != ETutorialListType.Pop && this.Duration > 0f)
		{
			this.TipState = ETutorialListType.Pop;
			this.StopGuide();
			ModelBase<GuideModel>.Instance.TryPauseTimer();
		}
	}

	// Token: 0x04006DAE RID: 28078
	[Nullable(2)]
	public GuideStepInfo OwnerStep;

	// Token: 0x04006DAF RID: 28079
	public int GuideId;

	// Token: 0x04006DB0 RID: 28080
	public ETutorialListType TipState;

	// Token: 0x04006DB1 RID: 28081
	public float Duration;

	// Token: 0x04006DB2 RID: 28082
	public bool TutorialTip;

	// Token: 0x04006DB3 RID: 28083
	public readonly bool IsOverrideGuideTutorialView;
}
