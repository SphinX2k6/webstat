using System;
using Aki.Protocol;
using Aki.Protocol.Summon;

// Token: 0x02002D92 RID: 11666
public class BulletActionSummonEntity : BulletActionBase
{
	// Token: 0x06017865 RID: 96357 RVA: 0x0068A304 File Offset: 0x00688504
	public BulletActionSummonEntity(EBulletAction type) : base(type)
	{
	}

	// Token: 0x06017866 RID: 96358 RVA: 0x0068A310 File Offset: 0x00688510
	protected override void OnExecute()
	{
		Entity attacker = this.BulletInfo.Attacker;
		CreatureDataComponent attackerCreatureDataComp = this.BulletInfo.AttackerCreatureDataComp;
		int num = 0;
		EEntityType entityType = attackerCreatureDataComp.GetEntityType();
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			if ((entityType == EEntityType.Player || entityType == EEntityType.Vision) && !this.BulletInfo.AttackerActorComp.IsAutonomousProxy)
			{
				return;
			}
			if (entityType == EEntityType.Monster)
			{
				num = attackerCreatureDataComp.GetSummonsVersion();
				if (num == 0)
				{
					EntityComponentPb entityComponentPb;
					if (attackerCreatureDataComp.ComponentDataMap.TryGetValue("SummonsComponentPb", out entityComponentPb))
					{
						SummonsComponentPb summonsComponentPb = entityComponentPb.SummonsComponentPb;
						num = ((summonsComponentPb != null) ? summonsComponentPb.Version : 1);
					}
					else
					{
						num = 1;
					}
				}
			}
		}
		this.BulletInfo.SummonAttackerId = attacker.Id;
		long? num2 = ControllerBase<CreatureController>.Instance.SummonRequest(this.BulletInfo.BulletInitParams.SkillId, true, this.BulletInfo.ActorComponent.ActorTransform, this.BulletInfo.SummonAttackerId, this.BulletInfo.BulletDataMain.Summon.EntityId, num);
		if (num2 != null)
		{
			this.BulletInfo.SummonServerEntityId = num2.Value;
			ModelBase<BulletModel>.Instance.SummonerSummon(attacker.Id, num2.Value);
		}
		if (num > 0)
		{
			attackerCreatureDataComp.SetSummonsVersion(num + 1);
		}
	}
}
