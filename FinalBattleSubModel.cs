using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000F31 RID: 3889
[NullableContext(1)]
[Nullable(0)]
public class FinalBattleSubModel : KscSubModelBase
{
	// Token: 0x06006117 RID: 24855 RVA: 0x00184B76 File Offset: 0x00182D76
	public override string GetSkillDtPath()
	{
		return FinalBattleSubModel.SkillDtPath;
	}

	// Token: 0x06006118 RID: 24856 RVA: 0x00184B7D File Offset: 0x00182D7D
	public override string GetEntityDtPath()
	{
		return FinalBattleSubModel.EntityDtPath;
	}

	// Token: 0x06006119 RID: 24857 RVA: 0x00184B84 File Offset: 0x00182D84
	public string GetBulletDtPath()
	{
		return FinalBattleSubModel.BulletDtPath;
	}

	// Token: 0x0600611A RID: 24858 RVA: 0x00184B8C File Offset: 0x00182D8C
	[NullableContext(2)]
	public IFinalBattleCombatInfo GetEntity(int uid)
	{
		IFinalBattleCombatInfo result;
		if (!this.AllEntities.TryGetValue(uid, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600611B RID: 24859 RVA: 0x00184BAC File Offset: 0x00182DAC
	public void GetAllEntities(List<IFinalBattleCombatInfo> entities)
	{
		entities.Clear();
		foreach (IFinalBattleCombatInfo item in this.AllEntities.Values)
		{
			entities.Add(item);
		}
	}

	// Token: 0x0600611C RID: 24860 RVA: 0x00184C0C File Offset: 0x00182E0C
	[return: Nullable(2)]
	public string TryAddEntity(IFinalBattleCombatInfo entityModel)
	{
		if (entityModel == null || !entityModel.IsValid())
		{
			return "实体数据无效";
		}
		int uid = entityModel.Uid;
		if (this.AllEntities.ContainsKey(uid))
		{
			return "实体数据已存在";
		}
		this.AllEntities[uid] = entityModel;
		return null;
	}

	// Token: 0x0600611D RID: 24861 RVA: 0x00184C54 File Offset: 0x00182E54
	[NullableContext(2)]
	public IFinalBattleCombatInfo RemoveEntity(int uid)
	{
		IFinalBattleCombatInfo result;
		if (this.AllEntities.TryGetValue(uid, out result))
		{
			this.AllEntities.Remove(uid);
			return result;
		}
		return null;
	}

	// Token: 0x0600611E RID: 24862 RVA: 0x00184C81 File Offset: 0x00182E81
	protected override bool OnClear()
	{
		this.AllEntities.Clear();
		this.BulletDataTable = null;
		return true;
	}

	// Token: 0x0600611F RID: 24863 RVA: 0x00184C96 File Offset: 0x00182E96
	public override bool IsCreatureIdValid(int creatureId)
	{
		return this.AllEntities.ContainsKey(creatureId);
	}

	// Token: 0x04002E89 RID: 11913
	public static readonly string SkillDtPath = "";

	// Token: 0x04002E8A RID: 11914
	public static readonly string EntityDtPath = "";

	// Token: 0x04002E8B RID: 11915
	public static readonly string BulletDtPath = "/Game/Aki/Data/SimpleCombat/3_5FinalBattle/DT_KuroBulletData_FinalBattle.DT_KuroBulletData_FinalBattle";

	// Token: 0x04002E8C RID: 11916
	[Nullable(2)]
	public UDataTable BulletDataTable;

	// Token: 0x04002E8D RID: 11917
	private readonly Dictionary<int, IFinalBattleCombatInfo> AllEntities = new Dictionary<int, IFinalBattleCombatInfo>();
}
