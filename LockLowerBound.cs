using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002F34 RID: 12084
[NullableContext(1)]
[Nullable(0)]
public class LockLowerBound : BuffEffect
{
	// Token: 0x06018BC6 RID: 101318 RVA: 0x006FD2C4 File Offset: 0x006FB4C4
	public LockLowerBound(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018BC7 RID: 101319 RVA: 0x006FD2D4 File Offset: 0x006FB4D4
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

	// Token: 0x06018BC8 RID: 101320 RVA: 0x006FD34C File Offset: 0x006FB54C
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
		baseAttributeComponent.AddIntervalLock(EAttributeIntervalLockType.LowerBoundLock, this.ActiveHandleId, this.AttributeId, this.Percent, this.Offset);
	}

	// Token: 0x06018BC9 RID: 101321 RVA: 0x006FD381 File Offset: 0x006FB581
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018BCA RID: 101322 RVA: 0x006FD384 File Offset: 0x006FB584
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
		baseAttributeComponent.RemoveIntervalLock(EAttributeIntervalLockType.LowerBoundLock, this.ActiveHandleId, this.AttributeId);
	}

	// Token: 0x06018BCB RID: 101323 RVA: 0x006FD3B0 File Offset: 0x006FB5B0
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 3);
		defaultInterpolatedStringHandler.AppendLiteral("锁定属性");
		defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(this.AttributeId);
		defaultInterpolatedStringHandler.AppendLiteral("的下限为");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Percent / 100f, "F1");
		defaultInterpolatedStringHandler.AppendLiteral("% + ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Offset);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C0A7 RID: 49319
	protected EAttributeType AttributeId;

	// Token: 0x0400C0A8 RID: 49320
	protected float Offset;

	// Token: 0x0400C0A9 RID: 49321
	protected float Percent;
}
