using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F31 RID: 12081
[NullableContext(1)]
[Nullable(0)]
public class ShieldEffect : BuffEffect
{
	// Token: 0x06018BB6 RID: 101302 RVA: 0x006FCEB8 File Offset: 0x006FB0B8
	public ShieldEffect(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018BB7 RID: 101303 RVA: 0x006FCEC8 File Offset: 0x006FB0C8
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ != null && extraEffectParameters_.Length != 0)
		{
			this.ShieldTemplateId = int.Parse(extraEffectParameters_[0]);
		}
	}

	// Token: 0x06018BB8 RID: 101304 RVA: 0x006FCEF1 File Offset: 0x006FB0F1
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018BB9 RID: 101305 RVA: 0x006FCEF4 File Offset: 0x006FB0F4
	public override string GetDebugEffectString()
	{
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		BaseBuffComponent baseBuffComponent = (exactOwnerEntity != null) ? exactOwnerEntity.CheckGetComponent<BaseBuffComponent>() : null;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 2);
		defaultInterpolatedStringHandler.AppendFormatted((baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent()) ? "编队buff" : "非编队buff");
		defaultInterpolatedStringHandler.AppendLiteral("添加护盾");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.ShieldTemplateId);
		defaultInterpolatedStringHandler.AppendLiteral("(纯服务端逻辑)");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C0A0 RID: 49312
	protected int ShieldTemplateId;
}
