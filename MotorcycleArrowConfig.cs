using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02000F4B RID: 3915
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class MotorcycleArrowConfig : ConfigBase<MotorcycleArrowConfig>
{
	// Token: 0x06006253 RID: 25171 RVA: 0x00189332 File Offset: 0x00187532
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x06006254 RID: 25172 RVA: 0x00189335 File Offset: 0x00187535
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x06006255 RID: 25173 RVA: 0x00189338 File Offset: 0x00187538
	public MotorFightMainLevel? GetLevelByInstId(int id)
	{
		return ConfigMotorFightMainLevelByInstId.GetConfig(id, true);
	}

	// Token: 0x06006256 RID: 25174 RVA: 0x00189341 File Offset: 0x00187541
	public MotorFightMainLevel? GetLevelByLevelId(int id)
	{
		return ConfigMotorFightMainLevelByLevelId.GetConfig(id, true);
	}

	// Token: 0x06006257 RID: 25175 RVA: 0x0018934A File Offset: 0x0018754A
	public MotorFightRole? GetMotorFightRoleById(int id)
	{
		return ConfigMotorFightRoleById.GetConfig(id, true);
	}

	// Token: 0x06006258 RID: 25176 RVA: 0x00189353 File Offset: 0x00187553
	public MotorFightSubLevel? GetSubLevelByInstId(int id)
	{
		return ConfigMotorFightSubLevelBySubLevelId.GetConfig(id, true);
	}

	// Token: 0x06006259 RID: 25177 RVA: 0x0018935C File Offset: 0x0018755C
	public MotorFightWaveGroup? GetMotorFightWaveGroupById(int id)
	{
		return ConfigMotorFightWaveGroupById.GetConfig(id, true);
	}

	// Token: 0x0600625A RID: 25178 RVA: 0x00189365 File Offset: 0x00187565
	public MotorFightWave? GetMotorFightWaveById(int id)
	{
		return ConfigMotorFightWaveByWaveId.GetConfig(id, true);
	}

	// Token: 0x0600625B RID: 25179 RVA: 0x0018936E File Offset: 0x0018756E
	public MotorFightMonsterRefresh? GetMonsterRefreshById(int id)
	{
		return ConfigMotorFightMonsterRefreshById.GetConfig(id, true);
	}

	// Token: 0x0600625C RID: 25180 RVA: 0x00189377 File Offset: 0x00187577
	public MotorFightBossRefresh? GetBossRefreshById(int id)
	{
		return ConfigMotorFightBossRefreshById.GetConfig(id, true);
	}

	// Token: 0x0600625D RID: 25181 RVA: 0x00189380 File Offset: 0x00187580
	public MotorMonster? GetMonsterConfigById(int id)
	{
		return ConfigMotorMonsterById.GetConfig(id, true);
	}

	// Token: 0x0600625E RID: 25182 RVA: 0x00189389 File Offset: 0x00187589
	public MotorFightBuffGateRefresh? GetBuffRefreshByRefreshId(int id)
	{
		return ConfigMotorFightBuffGateRefreshById.GetConfig(id, true);
	}

	// Token: 0x0600625F RID: 25183 RVA: 0x00189392 File Offset: 0x00187592
	public MotorFightBuffGate? GetBuffGateConfigById(int id)
	{
		return ConfigMotorFightBuffGateById.GetConfig(id, true);
	}

	// Token: 0x06006260 RID: 25184 RVA: 0x0018939C File Offset: 0x0018759C
	public MotorFightBuffGate? GetBuffGateByRefreshId(int id)
	{
		MotorFightBuffGateRefresh? buffRefreshByRefreshId = this.GetBuffRefreshByRefreshId(id);
		if (buffRefreshByRefreshId == null)
		{
			return null;
		}
		return this.GetBuffGateConfigById(buffRefreshByRefreshId.Value.BuffGateId);
	}

	// Token: 0x06006261 RID: 25185 RVA: 0x001893D9 File Offset: 0x001875D9
	public MotorFightBuffEffect? GetBuffEffectById(int id)
	{
		return ConfigMotorFightBuffEffectById.GetConfig(id, true);
	}

	// Token: 0x06006262 RID: 25186 RVA: 0x001893E2 File Offset: 0x001875E2
	public MotorFightItem? GetCollectionItemConfigById(int id)
	{
		return ConfigMotorFightItemById.GetConfig(id, true);
	}

	// Token: 0x06006263 RID: 25187 RVA: 0x001893EB File Offset: 0x001875EB
	public MotorFightItemType? GetCollectionTypeConfigById(int id)
	{
		return ConfigMotorFightItemTypeById.GetConfig(id, true);
	}

	// Token: 0x06006264 RID: 25188 RVA: 0x001893F4 File Offset: 0x001875F4
	public MotorFightQuality? GetMotorFightQuality(int id)
	{
		return ConfigMotorFightQualityById.GetConfig(id, true);
	}
}
