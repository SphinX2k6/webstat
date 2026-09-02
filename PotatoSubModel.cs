using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000F77 RID: 3959
[NullableContext(1)]
[Nullable(0)]
public class PotatoSubModel : KscSubModelBase
{
	// Token: 0x06006469 RID: 25705 RVA: 0x00192C34 File Offset: 0x00190E34
	public override string GetSkillDtPath()
	{
		return string.Empty;
	}

	// Token: 0x0600646A RID: 25706 RVA: 0x00192C3B File Offset: 0x00190E3B
	public override string GetEntityDtPath()
	{
		return string.Empty;
	}

	// Token: 0x0600646B RID: 25707 RVA: 0x00192C44 File Offset: 0x00190E44
	[NullableContext(2)]
	public IPotatoCombatInfo GetEntity(long uid)
	{
		IPotatoCombatInfo result;
		if (!this.AllEntities.TryGetValue(uid, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600646C RID: 25708 RVA: 0x00192C64 File Offset: 0x00190E64
	public void GetAllEntities(List<IPotatoCombatInfo> entities)
	{
		entities.Clear();
		foreach (IPotatoCombatInfo item in this.AllEntities.Values)
		{
			entities.Add(item);
		}
	}

	// Token: 0x0600646D RID: 25709 RVA: 0x00192CC4 File Offset: 0x00190EC4
	[return: Nullable(2)]
	public string TryAddEntity(IPotatoCombatInfo entityModel)
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

	// Token: 0x0600646E RID: 25710 RVA: 0x00192D10 File Offset: 0x00190F10
	[NullableContext(2)]
	public IPotatoCombatInfo RemoveEntity(long uid)
	{
		IPotatoCombatInfo result;
		if (this.AllEntities.TryGetValue(uid, out result))
		{
			this.AllEntities.Remove(uid);
			return result;
		}
		return null;
	}

	// Token: 0x0600646F RID: 25711 RVA: 0x00192D3D File Offset: 0x00190F3D
	protected override bool OnClear()
	{
		this.AllEntities.Clear();
		this.WeaponKscEntityMap.Clear();
		this.DamageMap.Clear();
		this.GoldNum = 0;
		return true;
	}

	// Token: 0x04002FEB RID: 12267
	public static readonly string HitContextTextDaPath = "/Game/Aki/Data/SimpleCombat/3_4Potato/KSC_DA_HitContextText_PTT.KSC_DA_HitContextText_PTT";

	// Token: 0x04002FEC RID: 12268
	public static readonly string BulletDtPath = "/Game/Aki/Data/SimpleCombat/3_4Potato/CDT_KuroBulletData_PTT.CDT_KuroBulletData_PTT";

	// Token: 0x04002FED RID: 12269
	[Nullable(2)]
	public UDataTable BulletDataTable;

	// Token: 0x04002FEE RID: 12270
	private readonly Dictionary<long, IPotatoCombatInfo> AllEntities = new Dictionary<long, IPotatoCombatInfo>();

	// Token: 0x04002FEF RID: 12271
	public Dictionary<int, AKSC_Entity> WeaponKscEntityMap = new Dictionary<int, AKSC_Entity>();

	// Token: 0x04002FF0 RID: 12272
	public Dictionary<long, int> DamageMap = new Dictionary<long, int>();

	// Token: 0x04002FF1 RID: 12273
	public int GoldNum;
}
