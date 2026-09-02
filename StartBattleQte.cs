using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F83 RID: 12163
[NullableContext(1)]
[Nullable(0)]
public class StartBattleQte : PeriodExecution
{
	// Token: 0x06018D3A RID: 101690 RVA: 0x00706BCF File Offset: 0x00704DCF
	public StartBattleQte(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D3B RID: 101691 RVA: 0x00706BD8 File Offset: 0x00704DD8
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ != null && extraEffectParameters_.Length != 0)
		{
			this.BattleQteId = new int?(int.Parse(extraEffectParameters_[0]));
		}
	}

	// Token: 0x06018D3C RID: 101692 RVA: 0x00706C08 File Offset: 0x00704E08
	[return: Nullable(2)]
	public override object OnExecute(params object[] args)
	{
		if (this.BattleQteId == null)
		{
			return null;
		}
		IActiveBuff buff = this.Buff;
		Entity entity = (buff != null) ? buff.GetOwner() : null;
		bool flag;
		if (entity == null)
		{
			flag = true;
		}
		else
		{
			CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
			flag = !((component != null) ? new bool?(component.IsAutonomousProxy) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return null;
		}
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		IActiveBuff buff2 = this.Buff;
		EntityHandle handleByEntity = instance.GetHandleByEntity((buff2 != null) ? buff2.GetInstigator() : null);
		IActiveBuff buff3 = this.Buff;
		long? num = (buff3 != null) ? buff3.MessageId : null;
		if (handleByEntity != null && num != null)
		{
			ControllerBase<BattleQteController>.Instance.StartBattleQte(this.BattleQteId.Value, num.Value, handleByEntity, EBattleQteSource.Buff);
		}
		return null;
	}

	// Token: 0x06018D3D RID: 101693 RVA: 0x00706CD0 File Offset: 0x00704ED0
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 2);
		defaultInterpolatedStringHandler.AppendLiteral("buff");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
		defaultInterpolatedStringHandler.AppendLiteral(" 触发战斗QTE");
		defaultInterpolatedStringHandler.AppendFormatted<int?>(this.BattleQteId);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C1BB RID: 49595
	protected int? BattleQteId;
}
