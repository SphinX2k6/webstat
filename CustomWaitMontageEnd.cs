using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002EAB RID: 11947
[NullableContext(2)]
[Nullable(0)]
public class CustomWaitMontageEnd : CustomActionBase
{
	// Token: 0x06018840 RID: 100416 RVA: 0x006E01AA File Offset: 0x006DE3AA
	public CustomWaitMontageEnd(BasePerformComponent performComp, [Nullable(1)] CharacterAnimationComponent animComp, bool waitForMontage = false, bool waitForMontageLoop = false, Action callback = null)
	{
		this.PerformComp = performComp;
		this.AnimComp = animComp;
		this.WaitForMontage = waitForMontage;
		this.WaitForMontageLoop = waitForMontageLoop;
		this.Callback = callback;
	}

	// Token: 0x06018841 RID: 100417 RVA: 0x006E01D8 File Offset: 0x006DE3D8
	protected override void OnRunAction()
	{
		if (this.AnimComp == null || this.PerformComp == null)
		{
			base.Finish(false);
			return;
		}
		if (!this.WaitForMontageLoop && !this.WaitForMontage)
		{
			base.Finish(true);
			return;
		}
		if (this.CheckInSection(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION))
		{
			if (this.WaitForMontage)
			{
				if (!this.WaitMontageEnd())
				{
					base.Finish(true);
				}
				return;
			}
			if (this.WaitForMontageLoop)
			{
				if (!this.WaitMontageLoopFinish())
				{
					base.Finish(true);
				}
				return;
			}
		}
		if (!this.WaitDefaultMontageEnd())
		{
			base.Finish(true);
		}
	}

	// Token: 0x06018842 RID: 100418 RVA: 0x006E0266 File Offset: 0x006DE466
	protected override void OnCheckFinish(float deltaTime)
	{
		if (this.IsFinish)
		{
			return;
		}
		this.CheckLoopSection();
	}

	// Token: 0x06018843 RID: 100419 RVA: 0x006E0277 File Offset: 0x006DE477
	protected override void OnFinish(bool success)
	{
		this.WaitLoopSectionFinish = false;
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp == null)
		{
			return;
		}
		UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
		if (mainAnimInstance == null)
		{
			return;
		}
		mainAnimInstance.OnMontageEnded.Clear();
	}

	// Token: 0x06018844 RID: 100420 RVA: 0x006E02A0 File Offset: 0x006DE4A0
	private bool WaitDefaultMontageEnd()
	{
		Action<UAnimMontage, bool> callback = delegate(UAnimMontage montage, bool bInterrupt)
		{
			base.Finish(true);
		};
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.OnMontageEnded.Add(callback);
			}
		}
		BasePerformComponent performComp = this.PerformComp;
		return ((performComp != null) ? performComp.StopPerformMontage(EPerformMode.Action, new IStopMontageParam
		{
			Method = new EStopMethod?(EStopMethod.WaitNextEndSection)
		}, null, null) : 0) > 0;
	}

	// Token: 0x06018845 RID: 100421 RVA: 0x006E0308 File Offset: 0x006DE508
	private bool WaitMontageEnd()
	{
		Action<UAnimMontage, bool> callback = delegate(UAnimMontage montage, bool bInterrupt)
		{
			base.Finish(true);
		};
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.OnMontageEnded.Add(callback);
			}
		}
		BasePerformComponent performComp = this.PerformComp;
		return ((performComp != null) ? performComp.StopPerformMontage(EPerformMode.Action, new IStopMontageParam
		{
			Method = new EStopMethod?(EStopMethod.WaitLoopToEnd)
		}, null, null) : 0) > 0;
	}

	// Token: 0x06018846 RID: 100422 RVA: 0x006E036D File Offset: 0x006DE56D
	private bool WaitMontageLoopFinish()
	{
		BasePerformComponent performComp = this.PerformComp;
		if (((performComp != null) ? performComp.StopPerformMontage(EPerformMode.Action, new IStopMontageParam
		{
			Method = new EStopMethod?(EStopMethod.WaitLoopToEnd)
		}, null, null) : 0) <= 0)
		{
			return false;
		}
		this.WaitLoopSectionFinish = true;
		return true;
	}

	// Token: 0x06018847 RID: 100423 RVA: 0x006E03A4 File Offset: 0x006DE5A4
	private void CheckLoopSection()
	{
		if (!this.WaitLoopSectionFinish)
		{
			return;
		}
		CharacterAnimationComponent animComp = this.AnimComp;
		UAnimInstance uanimInstance = (animComp != null) ? animComp.MainAnimInstance : null;
		if (uanimInstance == null)
		{
			base.Finish(true);
			return;
		}
		UAnimMontage currentActiveMontage = uanimInstance.GetCurrentActiveMontage();
		if (currentActiveMontage == null || !uanimInstance.Montage_IsPlaying(currentActiveMontage))
		{
			base.Finish(true);
			return;
		}
		FName a = uanimInstance.Montage_GetCurrentSection(currentActiveMontage);
		if (!(a != null) || !a.Equals(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION))
		{
			base.Finish(true);
		}
	}

	// Token: 0x06018848 RID: 100424 RVA: 0x006E0428 File Offset: 0x006DE628
	private bool CheckInSection(FName name)
	{
		CharacterAnimationComponent animComp = this.AnimComp;
		UAnimInstance uanimInstance = (animComp != null) ? animComp.MainAnimInstance : null;
		if (uanimInstance == null)
		{
			return false;
		}
		UAnimMontage currentActiveMontage = uanimInstance.GetCurrentActiveMontage();
		if (currentActiveMontage == null)
		{
			return false;
		}
		FName a = uanimInstance.Montage_GetCurrentSection(currentActiveMontage);
		return a != null && a.Equals(name);
	}

	// Token: 0x0400BD42 RID: 48450
	private bool WaitLoopSectionFinish;

	// Token: 0x0400BD43 RID: 48451
	private readonly BasePerformComponent PerformComp;

	// Token: 0x0400BD44 RID: 48452
	[Nullable(1)]
	private readonly CharacterAnimationComponent AnimComp;

	// Token: 0x0400BD45 RID: 48453
	private readonly bool WaitForMontage;

	// Token: 0x0400BD46 RID: 48454
	private readonly bool WaitForMontageLoop;
}
