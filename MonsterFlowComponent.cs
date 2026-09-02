using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x02003175 RID: 12661
[NullableContext(2)]
[Nullable(0)]
public class MonsterFlowComponent : CharacterFlowComponent
{
	// Token: 0x0601A3D4 RID: 107476 RVA: 0x007B6A65 File Offset: 0x007B4C65
	protected override bool OnStart()
	{
		this.UnifiedStateComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.SensoryComp = base.Entity.GetComponent<PawnSensoryInfoComponent>();
		base.OnStart();
		return true;
	}

	// Token: 0x0601A3D5 RID: 107477 RVA: 0x007B6A91 File Offset: 0x007B4C91
	protected override bool InitFlowLogicRange(float? enterRange, float? leaveRange, IBubbleRangeCylinderConfig config)
	{
		if (!base.InitFlowLogicRange(enterRange, leaveRange, config))
		{
			return false;
		}
		PawnSensoryInfoComponent sensoryComp = this.SensoryComp;
		if (sensoryComp != null)
		{
			sensoryComp.SetLogicRange(leaveRange.GetValueOrDefault(1500f));
		}
		return true;
	}

	// Token: 0x0601A3D6 RID: 107478 RVA: 0x007B6AC0 File Offset: 0x007B4CC0
	protected override bool CheckCondition()
	{
		if (!base.CheckCondition())
		{
			return false;
		}
		if (this.SensoryComp == null)
		{
			return false;
		}
		if (!this.SensoryComp.IsInLogicRange)
		{
			base.ForceStopFlow();
			return false;
		}
		if (this.UnifiedStateComp.IsInFightState())
		{
			base.ForceStopFlow();
			return false;
		}
		return true;
	}

	// Token: 0x0601A3D7 RID: 107479 RVA: 0x007B6B0C File Offset: 0x007B4D0C
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		MonsterFlowComponent monsterFlowComponent = (MonsterFlowComponent)componentTemplate;
		if (base.CanResetComponentProperty("SensoryComp"))
		{
			if (monsterFlowComponent.SensoryComp == null)
			{
				this.SensoryComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnSensoryInfoComponent>(this.SensoryComp), "SensoryComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedStateComp"))
		{
			if (monsterFlowComponent.UnifiedStateComp == null)
			{
				this.UnifiedStateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedStateComp), "UnifiedStateComp"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D345 RID: 54085
	private PawnSensoryInfoComponent SensoryComp;

	// Token: 0x0400D346 RID: 54086
	private CharacterUnifiedStateComponent UnifiedStateComp;
}
