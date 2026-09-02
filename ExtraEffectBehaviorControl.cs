using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002F15 RID: 12053
[NullableContext(1)]
[Nullable(0)]
public class ExtraEffectBehaviorControl : BuffEffect
{
	// Token: 0x06018B17 RID: 101143 RVA: 0x006F87FF File Offset: 0x006F69FF
	public ExtraEffectBehaviorControl(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B18 RID: 101144 RVA: 0x006F8810 File Offset: 0x006F6A10
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		int controlType = (extraEffectParameters_ != null && extraEffectParameters_.Length != 0) ? int.Parse(extraEffectParameters_[0] ?? "0") : 0;
		this.ControlType = (EControlType)controlType;
	}

	// Token: 0x06018B19 RID: 101145 RVA: 0x006F8848 File Offset: 0x006F6A48
	public override void OnCreated()
	{
		if (!base.TryExecute(new Partial_RequirementPayload(), this.OwnerBuffComponent, Array.Empty<object>()))
		{
			this.IsActive = false;
			this.OwnerBuffComponent.RemoveBuffByHandle(this.ActiveHandleId, -1, "怪物类型不满足条件，移除自身", null, null, null);
		}
	}

	// Token: 0x06018B1A RID: 101146 RVA: 0x006F88A7 File Offset: 0x006F6AA7
	public override void OnRemoved(bool bPremature)
	{
		if (!this.IsActive)
		{
			return;
		}
		this.ApplyTaunt(false);
		if (this.ControlType == EControlType.Tempt)
		{
			this.ApplyTemptation(false);
		}
	}

	// Token: 0x06018B1B RID: 101147 RVA: 0x006F88CC File Offset: 0x006F6ACC
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		this.IsActive = true;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
		defaultInterpolatedStringHandler.AppendLiteral("被嘲讽buff ");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
		defaultInterpolatedStringHandler.AppendLiteral("覆盖");
		string reason = defaultInterpolatedStringHandler.ToStringAndClear();
		foreach (ExtraEffectBehaviorControl extraEffectBehaviorControl in base.OwnerEffectManager.FilterById<ExtraEffectBehaviorControl>(EExtraEffectId.Control, null))
		{
			if (extraEffectBehaviorControl != this)
			{
				this.OwnerBuffComponent.RemoveBuffByHandle(extraEffectBehaviorControl.ActiveHandleId, -1, reason, null, null, null);
			}
		}
		this.ApplyTaunt(true);
		if (this.ControlType == EControlType.Tempt)
		{
			this.ApplyTemptation(true);
		}
		return null;
	}

	// Token: 0x06018B1C RID: 101148 RVA: 0x006F89A8 File Offset: 0x006F6BA8
	private void ApplyTaunt(bool addOrRemove)
	{
		Singleton<EventSystem>.Instance.EmitWithTarget<bool, int, int>(base.OwnerEntity, EEventName.AiTauntAddOrRemove, addOrRemove, this.InstigatorEntityId, this.ActiveHandleId);
	}

	// Token: 0x06018B1D RID: 101149 RVA: 0x006F89D0 File Offset: 0x006F6BD0
	private void ApplyTemptation(bool addOrRemove)
	{
		if (addOrRemove)
		{
			ControllerBase<BlackboardController>.Instance.SetEntityIdByEntity(base.OwnerEntity.Id, "TemptTarget", this.InstigatorEntityId);
			return;
		}
		if (ControllerBase<BlackboardController>.Instance.HasValueByEntity(base.OwnerEntity.Id, "TemptTarget"))
		{
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(base.OwnerEntity.Id, "TemptTarget");
		}
	}

	// Token: 0x0400C03D RID: 49213
	private EControlType ControlType;

	// Token: 0x0400C03E RID: 49214
	private bool IsActive;
}
