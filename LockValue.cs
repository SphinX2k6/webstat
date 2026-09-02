using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002F32 RID: 12082
[NullableContext(1)]
[Nullable(0)]
public class LockValue : BuffEffect
{
	// Token: 0x06018BBA RID: 101306 RVA: 0x006FCF68 File Offset: 0x006FB168
	public LockValue(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018BBB RID: 101307 RVA: 0x006FCF78 File Offset: 0x006FB178
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
		if (extraEffectParameters_.Length > 1)
		{
			this.Offset = float.Parse(extraEffectParameters_[1]);
		}
		this.Percent = 0f;
		if (extraEffectParameters_.Length > 2)
		{
			this.Percent = float.Parse(extraEffectParameters_[2]);
		}
	}

	// Token: 0x06018BBC RID: 101308 RVA: 0x006FCFD8 File Offset: 0x006FB1D8
	public override void OnCreated()
	{
		Entity ownerEntity = base.OwnerEntity;
		BaseAttributeComponent baseAttributeComponent = (ownerEntity != null) ? ownerEntity.CheckGetComponent<BaseAttributeComponent>() : null;
		if (baseAttributeComponent == null)
		{
			return;
		}
		if (CharacterAttributeTypes.stateAttributeIds.Contains(this.AttributeId))
		{
			baseAttributeComponent.AddStateAttributeLock(this.ActiveHandleId, this.AttributeId, this.Percent, this.Offset);
			return;
		}
		baseAttributeComponent.AddNonStateAttributeLock(this.ActiveHandleId, this.AttributeId, this.Offset);
	}

	// Token: 0x06018BBD RID: 101309 RVA: 0x006FD045 File Offset: 0x006FB245
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018BBE RID: 101310 RVA: 0x006FD048 File Offset: 0x006FB248
	public override void OnRemoved(bool bPremature)
	{
		Entity ownerEntity = base.OwnerEntity;
		BaseAttributeComponent baseAttributeComponent = (ownerEntity != null) ? ownerEntity.CheckGetComponent<BaseAttributeComponent>() : null;
		if (baseAttributeComponent == null)
		{
			return;
		}
		if (CharacterAttributeTypes.stateAttributeIds.Contains(this.AttributeId))
		{
			baseAttributeComponent.RemoveStateAttributeLock(this.ActiveHandleId, this.AttributeId);
			return;
		}
		baseAttributeComponent.RemoveNonStateAttributeLock(this.ActiveHandleId, this.AttributeId);
	}

	// Token: 0x06018BBF RID: 101311 RVA: 0x006FD0A4 File Offset: 0x006FB2A4
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (CharacterAttributeTypes.stateAttributeIds.Contains(this.AttributeId))
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 3);
			defaultInterpolatedStringHandler.AppendLiteral("锁定状态属性");
			defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(this.AttributeId);
			defaultInterpolatedStringHandler.AppendLiteral("为");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.Percent);
			defaultInterpolatedStringHandler.AppendLiteral("% + ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.Offset);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 2);
		defaultInterpolatedStringHandler.AppendLiteral("锁定非状态属性");
		defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(this.AttributeId);
		defaultInterpolatedStringHandler.AppendLiteral("为固定值");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Offset);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C0A1 RID: 49313
	protected EAttributeType AttributeId;

	// Token: 0x0400C0A2 RID: 49314
	protected float Offset;

	// Token: 0x0400C0A3 RID: 49315
	protected float Percent;
}
