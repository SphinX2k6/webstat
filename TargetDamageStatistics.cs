using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02002ED0 RID: 11984
[NullableContext(1)]
[Nullable(0)]
public class TargetDamageStatistics
{
	// Token: 0x060189A1 RID: 100769 RVA: 0x006EDBB0 File Offset: 0x006EBDB0
	public TargetDamageStatistics(int inTargetId)
	{
		this.TargetId = inTargetId;
		CreatureDataComponent component = Singleton<EntitySystem>.Instance.Get(this.TargetId).GetComponent<CreatureDataComponent>();
		EEntityType entityType = component.GetEntityType();
		this.IsMonster = (entityType == EEntityType.Monster);
		this.IsRole = (entityType == EEntityType.Player);
		this.ConfigId = 0;
		this.TargetName = "";
		if (this.IsMonster)
		{
			this.ConfigId = component.GetPbDataId();
			this.TargetName = Singleton<PublicUtil>.Instance.GetConfigTextByKey(component.GetEntityTidName() ?? "");
			return;
		}
		if (this.IsRole)
		{
			int id = component.Valid ? component.GetRoleId() : 0;
			int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(id);
			if (baseRoleId != 0)
			{
				this.ConfigId = baseRoleId;
				RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.ConfigId).Value;
				this.TargetName = ConfigBase<RoleConfig>.Instance.GetRoleName(value.Name);
				return;
			}
			this.IsValid = false;
		}
	}

	// Token: 0x060189A2 RID: 100770 RVA: 0x006EDCB2 File Offset: 0x006EBEB2
	public void AddDamageValue(int damage)
	{
		this.DamageTotal += damage;
	}

	// Token: 0x060189A3 RID: 100771 RVA: 0x006EDCC4 File Offset: 0x006EBEC4
	public override string ToString()
	{
		return StringUtils.Format(",{0},{1},{2},{3},{4}", new string[]
		{
			this.IsMonster ? "怪物" : (this.IsRole ? "角色" : "出错？？"),
			this.TargetName,
			this.ConfigId.ToString(),
			this.TargetId.ToString(),
			this.DamageTotal.ToString()
		});
	}

	// Token: 0x0400BE66 RID: 48742
	private int DamageTotal;

	// Token: 0x0400BE67 RID: 48743
	private readonly bool IsMonster;

	// Token: 0x0400BE68 RID: 48744
	private readonly bool IsRole;

	// Token: 0x0400BE69 RID: 48745
	private readonly int ConfigId;

	// Token: 0x0400BE6A RID: 48746
	public readonly int TargetId;

	// Token: 0x0400BE6B RID: 48747
	private readonly string TargetName;

	// Token: 0x0400BE6C RID: 48748
	public bool IsValid = true;
}
