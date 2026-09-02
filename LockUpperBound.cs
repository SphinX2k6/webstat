using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002F33 RID: 12083
[NullableContext(1)]
[Nullable(0)]
public class LockUpperBound : BuffEffect
{
	// Token: 0x06018BC0 RID: 101312 RVA: 0x006FD163 File Offset: 0x006FB363
	public LockUpperBound(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018BC1 RID: 101313 RVA: 0x006FD174 File Offset: 0x006FB374
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null)
		{
			return;
		}
		if (extraEffectParameters_.Length != 0)
		{
			this.AttributeId = (EAttributeType)int.Parse(extraEffectParameters_[0]);
		}
		this.Percent = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters1, this.Level, 0f);
		this.Offset = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters2, this.Level, 0f);
		if (extraEffectParameters_.Length > 2)
		{
			this.Percent = float.Parse(extraEffectParameters_[2]);
		}
	}

	// Token: 0x06018BC2 RID: 101314 RVA: 0x006FD1EC File Offset: 0x006FB3EC
	public override void OnCreated()
	{
		Entity ownerEntity = base.OwnerEntity;
		if (ownerEntity == null)
		{
			return;
		}
		BaseAttributeComponent baseAttributeComponent = ownerEntity.CheckGetComponent<BaseAttributeComponent>();
		if (baseAttributeComponent == null)
		{
			return;
		}
		baseAttributeComponent.AddIntervalLock(EAttributeIntervalLockType.UpperBoundLock, this.ActiveHandleId, this.AttributeId, this.Percent, this.Offset);
	}

	// Token: 0x06018BC3 RID: 101315 RVA: 0x006FD221 File Offset: 0x006FB421
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018BC4 RID: 101316 RVA: 0x006FD224 File Offset: 0x006FB424
	public override void OnRemoved(bool bPremature)
	{
		Entity ownerEntity = base.OwnerEntity;
		if (ownerEntity == null)
		{
			return;
		}
		BaseAttributeComponent baseAttributeComponent = ownerEntity.CheckGetComponent<BaseAttributeComponent>();
		if (baseAttributeComponent == null)
		{
			return;
		}
		baseAttributeComponent.RemoveIntervalLock(EAttributeIntervalLockType.UpperBoundLock, this.ActiveHandleId, this.AttributeId);
	}

	// Token: 0x06018BC5 RID: 101317 RVA: 0x006FD250 File Offset: 0x006FB450
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 3);
		defaultInterpolatedStringHandler.AppendLiteral("锁定属性");
		defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(this.AttributeId);
		defaultInterpolatedStringHandler.AppendLiteral("的上限为");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Percent / 100f, "F1");
		defaultInterpolatedStringHandler.AppendLiteral("% + ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Offset);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C0A4 RID: 49316
	protected EAttributeType AttributeId;

	// Token: 0x0400C0A5 RID: 49317
	protected float Offset;

	// Token: 0x0400C0A6 RID: 49318
	protected float Percent;
}
