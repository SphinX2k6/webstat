using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000F8A RID: 3978
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueSubModel : KscSubModelBase
{
	// Token: 0x06006527 RID: 25895 RVA: 0x001950B8 File Offset: 0x001932B8
	public override string GetSkillDtPath()
	{
		return SurvivorsRogueSubModel.SkillDtPath;
	}

	// Token: 0x06006528 RID: 25896 RVA: 0x001950BF File Offset: 0x001932BF
	public override string GetEntityDtPath()
	{
		return SurvivorsRogueSubModel.EntityDtPath;
	}

	// Token: 0x06006529 RID: 25897 RVA: 0x001950C8 File Offset: 0x001932C8
	[NullableContext(2)]
	public ISurvivorsRogueCombatInfo GetEntity(long uid)
	{
		ISurvivorsRogueCombatInfo result;
		if (!this.AllEntities.TryGetValue(uid, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600652A RID: 25898 RVA: 0x001950E8 File Offset: 0x001932E8
	public void GetAllEntities(List<ISurvivorsRogueCombatInfo> entities)
	{
		entities.Clear();
		foreach (ISurvivorsRogueCombatInfo item in this.AllEntities.Values)
		{
			entities.Add(item);
		}
	}

	// Token: 0x0600652B RID: 25899 RVA: 0x00195148 File Offset: 0x00193348
	[return: Nullable(2)]
	public string TryAddEntity(ISurvivorsRogueCombatInfo entityModel)
	{
		if (entityModel == null || !entityModel.IsValid())
		{
			return "实体数据无效";
		}
		int uid = entityModel.Uid;
		if (this.AllEntities.ContainsKey((long)uid))
		{
			return "实体数据已存在";
		}
		this.AllEntities[(long)uid] = entityModel;
		return null;
	}

	// Token: 0x0600652C RID: 25900 RVA: 0x00195194 File Offset: 0x00193394
	[NullableContext(2)]
	public ISurvivorsRogueCombatInfo RemoveEntity(int uid)
	{
		ISurvivorsRogueCombatInfo result;
		if (this.AllEntities.TryGetValue((long)uid, out result))
		{
			this.AllEntities.Remove((long)uid);
			return result;
		}
		return null;
	}

	// Token: 0x0600652D RID: 25901 RVA: 0x001951C3 File Offset: 0x001933C3
	protected override bool OnClear()
	{
		this.AllEntities.Clear();
		this.WeaponKscEntities.Clear();
		this.GoldNum = 0;
		this.KillComboStage = 0;
		return true;
	}

	// Token: 0x04003030 RID: 12336
	public static readonly string SkillDtPath = "/Game/Aki/Data/SimpleCombat/2_7XingCunZhe/Player/DT_KscSkill.DT_KscSkill";

	// Token: 0x04003031 RID: 12337
	public static readonly string EntityDtPath = "/Game/Aki/Data/SimpleCombat/2_7XingCunZhe/Player/DT_KscEntity.DT_KscEntity";

	// Token: 0x04003032 RID: 12338
	public static readonly string BulletDtPath = "/Game/Aki/Data/SimpleCombat/2_7XingCunZhe/CDT_KuroBulletData_XCZ_New.CDT_KuroBulletData_XCZ_New";

	// Token: 0x04003033 RID: 12339
	[Nullable(2)]
	public UDataTable BulletDataTable;

	// Token: 0x04003034 RID: 12340
	private readonly Dictionary<long, ISurvivorsRogueCombatInfo> AllEntities = new Dictionary<long, ISurvivorsRogueCombatInfo>();

	// Token: 0x04003035 RID: 12341
	public List<AKSC_Entity> WeaponKscEntities = new List<AKSC_Entity>();

	// Token: 0x04003036 RID: 12342
	public int GoldNum;

	// Token: 0x04003037 RID: 12343
	public int KillComboStage;
}
