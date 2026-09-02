using System;
using System.Runtime.CompilerServices;
using Aki.Protocol.Summon;

// Token: 0x02002F78 RID: 12152
[NullableContext(1)]
[Nullable(0)]
public class PhantomAssistExecution : InitExecution
{
	// Token: 0x06018D09 RID: 101641 RVA: 0x00704938 File Offset: 0x00702B38
	public PhantomAssistExecution(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D0A RID: 101642 RVA: 0x00704948 File Offset: 0x00702B48
	protected override bool CheckExecutable()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		return ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority();
	}

	// Token: 0x06018D0B RID: 101643 RVA: 0x0070495C File Offset: 0x00702B5C
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		this.SummonType = (ESummonType)((extraEffectParameters_ != null && extraEffectParameters_.Length != 0) ? int.Parse(extraEffectParameters_[0]) : 0);
		this.FollowIndex = ((extraEffectParameters_ != null && extraEffectParameters_.Length > 1) ? int.Parse(extraEffectParameters_[1]) : 0);
		this.SkillId = ((extraEffectParameters_ != null && extraEffectParameters_.Length > 2) ? int.Parse(extraEffectParameters_[2]) : 0);
		this.SkillTargetType = (ESkillTargetType)((extraEffectParameters_ != null && extraEffectParameters_.Length > 3) ? int.Parse(extraEffectParameters_[3]) : 2);
	}

	// Token: 0x06018D0C RID: 101644 RVA: 0x007049D8 File Offset: 0x00702BD8
	[return: Nullable(2)]
	public override object OnExecute(params object[] args)
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		Entity entity = (ownerBuffComponent != null) ? ownerBuffComponent.GetEntity() : null;
		EntityHandle entityHandle = (entity != null) ? PhantomUtil.GetSummonedEntity(entity, this.SummonType, this.FollowIndex) : null;
		if (((entityHandle != null) ? entityHandle.Entity : null) == null)
		{
			return null;
		}
		CharacterSkillComponent component = entityHandle.Entity.GetComponent<CharacterSkillComponent>();
		if (component == null)
		{
			return null;
		}
		BaseSkillComponent baseSkillComponent = component;
		int skillId = this.SkillId;
		SkillParam skillParam = new SkillParam();
		EntityHandle skillTarget = this.GetSkillTarget();
		skillParam.Target = ((skillTarget != null) ? skillTarget.Entity : null);
		skillParam.Reason = "PhantomAssistExecution.OnExecute";
		baseSkillComponent.BeginSkillAsync(skillId, skillParam);
		return null;
	}

	// Token: 0x06018D0D RID: 101645 RVA: 0x00704A68 File Offset: 0x00702C68
	[NullableContext(2)]
	private EntityHandle GetSkillTarget()
	{
		EntityHandle result = null;
		switch (this.SkillTargetType)
		{
		case ESkillTargetType.SkillTarget:
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			EntityHandle entityHandle;
			if (ownerBuffComponent == null)
			{
				entityHandle = null;
			}
			else
			{
				BaseSkillComponent skillComponent = ownerBuffComponent.GetSkillComponent();
				entityHandle = ((skillComponent != null) ? skillComponent.SkillTarget : null);
			}
			result = entityHandle;
			break;
		}
		case ESkillTargetType.LockOnTarget:
		{
			IBuffComponent ownerBuffComponent2 = this.OwnerBuffComponent;
			EntityHandle entityHandle2;
			if (ownerBuffComponent2 == null)
			{
				entityHandle2 = null;
			}
			else
			{
				Entity entity = ownerBuffComponent2.GetEntity();
				if (entity == null)
				{
					entityHandle2 = null;
				}
				else
				{
					CharacterLockOnComponent component = entity.GetComponent<CharacterLockOnComponent>();
					entityHandle2 = ((component != null) ? component.GetCurrentTarget() : null);
				}
			}
			result = entityHandle2;
			break;
		}
		case ESkillTargetType.Owner:
		{
			CharacterModel instance = ModelBase<CharacterModel>.Instance;
			IBuffComponent ownerBuffComponent3 = this.OwnerBuffComponent;
			result = instance.GetHandleByEntity((ownerBuffComponent3 != null) ? ownerBuffComponent3.GetEntity() : null);
			break;
		}
		}
		return result;
	}

	// Token: 0x0400C190 RID: 49552
	private ESummonType SummonType;

	// Token: 0x0400C191 RID: 49553
	private int FollowIndex;

	// Token: 0x0400C192 RID: 49554
	private int SkillId;

	// Token: 0x0400C193 RID: 49555
	private ESkillTargetType SkillTargetType = ESkillTargetType.Owner;
}
