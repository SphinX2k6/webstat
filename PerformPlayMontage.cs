using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x020030F8 RID: 12536
[NullableContext(2)]
[Nullable(0)]
public class PerformPlayMontage : PerformActionBase
{
	// Token: 0x06019ED1 RID: 106193 RVA: 0x007947CB File Offset: 0x007929CB
	public PerformPlayMontage() : base(EPerformAction.PlayMontage)
	{
	}

	// Token: 0x06019ED2 RID: 106194 RVA: 0x007947D4 File Offset: 0x007929D4
	protected override void OnExecute()
	{
		BaseAnimationComponent component = this.PerformComp.Entity.GetComponent<BaseAnimationComponent>();
		if (component == null)
		{
			base.FinishExecute();
			return;
		}
		IPlayMontageParam playMontageParam = this.Param as IPlayMontageParam;
		if (playMontageParam.EndActionOnBlendOut.GetValueOrDefault())
		{
			this.OriginOnBlendOut = playMontageParam.OnBlendOutCallback;
			playMontageParam.OnBlendOutCallback = new Action<UAnimMontage, bool>(this.OnBlendOutForFinish);
		}
		this.MontageId = component.GetMontageManager(base.Group).PlayMontage(playMontageParam);
		if (this.MontageId > 0)
		{
			this.EntityHandle = ModelBase<CreatureModel>.Instance.GetEntityById(this.PerformComp.Entity.Id);
			if (this.EntityHandle != null)
			{
				Singleton<EventSystem>.Instance.AddWithTarget(this.EntityHandle, EEventName.PerformMontageStop, new Action<int>(this.OnMontageStop));
				return;
			}
		}
		else
		{
			base.FinishExecute();
		}
	}

	// Token: 0x06019ED3 RID: 106195 RVA: 0x007948A8 File Offset: 0x00792AA8
	private void OnBlendOutForFinish(UAnimMontage montage, bool bInterrupted)
	{
		Action<UAnimMontage, bool> originOnBlendOut = this.OriginOnBlendOut;
		if (originOnBlendOut != null)
		{
			originOnBlendOut(montage, bInterrupted);
		}
		BasePerformComponent performComp = this.PerformComp;
		BaseAnimationComponent baseAnimationComponent = (performComp != null) ? performComp.Entity.GetComponent<BaseAnimationComponent>() : null;
		if (baseAnimationComponent == null)
		{
			return;
		}
		baseAnimationComponent.GetMontageManager(base.Group).DetachWithoutStop(bInterrupted);
	}

	// Token: 0x06019ED4 RID: 106196 RVA: 0x007948F8 File Offset: 0x00792AF8
	private void OnMontageStop(int id)
	{
		if (this.EntityHandle != null && Singleton<EventSystem>.Instance.HasWithTarget(this.EntityHandle, EEventName.PerformMontageStop, new Action<int>(this.OnMontageStop)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle, EEventName.PerformMontageStop, new Action<int>(this.OnMontageStop));
		}
		if (this.MontageId == id)
		{
			base.FinishExecute();
		}
	}

	// Token: 0x06019ED5 RID: 106197 RVA: 0x00794964 File Offset: 0x00792B64
	protected override void OnInterrupt()
	{
		float remainDuration = this.PerformComp.Entity.GetComponent<BaseAnimationComponent>().GetMontageManager(base.Group).GetRemainDuration(this.MontageId);
		((IPlayMontageParam)this.Param).Duration = new float?(remainDuration);
		this.MontageId = 0;
		if (Singleton<EventSystem>.Instance.HasWithTarget(this.EntityHandle, EEventName.PerformMontageStop, new Action<int>(this.OnMontageStop)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle, EEventName.PerformMontageStop, new Action<int>(this.OnMontageStop));
		}
	}

	// Token: 0x06019ED6 RID: 106198 RVA: 0x007949FC File Offset: 0x00792BFC
	protected override void OnReset()
	{
		if (this.EntityHandle != null && Singleton<EventSystem>.Instance.HasWithTarget(this.EntityHandle, EEventName.PerformMontageStop, new Action<int>(this.OnMontageStop)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle, EEventName.PerformMontageStop, new Action<int>(this.OnMontageStop));
		}
		this.MontageId = 0;
		this.EntityHandle = null;
		this.OriginOnBlendOut = null;
	}

	// Token: 0x0400CFD6 RID: 53206
	private int MontageId;

	// Token: 0x0400CFD7 RID: 53207
	private EntityHandle EntityHandle;

	// Token: 0x0400CFD8 RID: 53208
	private Action<UAnimMontage, bool> OriginOnBlendOut;
}
