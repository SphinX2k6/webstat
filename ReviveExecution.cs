using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F6E RID: 12142
[NullableContext(1)]
[Nullable(0)]
public class ReviveExecution : PeriodExecution
{
	// Token: 0x06018CF3 RID: 101619 RVA: 0x00703B23 File Offset: 0x00701D23
	public ReviveExecution(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018CF4 RID: 101620 RVA: 0x00703B2C File Offset: 0x00701D2C
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		this.HealRate = ((extraEffectParameters_ != null && extraEffectParameters_.Length != 0) ? (float.Parse(extraEffectParameters_[0]) * 0.0001f) : 0f);
		this.HealValue = ((extraEffectParameters_ != null && extraEffectParameters_.Length > 1) ? float.Parse(extraEffectParameters_[1]) : 0f);
	}

	// Token: 0x06018CF5 RID: 101621 RVA: 0x00703B80 File Offset: 0x00701D80
	[return: Nullable(2)]
	public override object OnExecute(params object[] args)
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		Entity entity = (ownerBuffComponent != null) ? ownerBuffComponent.GetEntity() : null;
		int? num;
		if (entity == null)
		{
			num = null;
		}
		else
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			num = ((component != null) ? new int?(component.GetPlayerId()) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		if (ModelBase<SceneTeamModel>.Instance.GetCurrentGroupLivingState(valueOrDefault) == ETeamLivingState.Dead)
		{
			return null;
		}
		RoleDeathComponent roleDeathComponent = (entity != null) ? entity.CheckGetComponent<RoleDeathComponent>() : null;
		if (roleDeathComponent != null)
		{
			roleDeathComponent.ExecuteRevive();
		}
		return null;
	}

	// Token: 0x0400C172 RID: 49522
	public float HealRate;

	// Token: 0x0400C173 RID: 49523
	public float HealValue;
}
