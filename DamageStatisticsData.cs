using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

// Token: 0x02002ED1 RID: 11985
[NullableContext(1)]
[Nullable(0)]
public class DamageStatisticsData
{
	// Token: 0x060189A4 RID: 100772 RVA: 0x006EDD3A File Offset: 0x006EBF3A
	public DamageStatisticsData(int roleId, string roleName, string damageType, bool isHeal)
	{
		this.RoleId = roleId;
		this.RoleName = roleName;
		this.DamageType = damageType;
		this.IsHeal = isHeal;
	}

	// Token: 0x060189A5 RID: 100773 RVA: 0x006EDD6C File Offset: 0x006EBF6C
	public void AddDamageValue(int targetId, int damage)
	{
		TargetDamageStatistics targetDamageStatistics;
		if (!this.TargetTotalDamage.TryGetValue(targetId, out targetDamageStatistics))
		{
			targetDamageStatistics = new TargetDamageStatistics(targetId);
			if (!targetDamageStatistics.IsValid)
			{
				return;
			}
			this.TargetTotalDamage[targetId] = targetDamageStatistics;
		}
		targetDamageStatistics.AddDamageValue(damage);
	}

	// Token: 0x060189A6 RID: 100774 RVA: 0x006EDDAD File Offset: 0x006EBFAD
	public int GetTargetCount()
	{
		return this.TargetTotalDamage.Count;
	}

	// Token: 0x060189A7 RID: 100775 RVA: 0x006EDDBC File Offset: 0x006EBFBC
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (TargetDamageStatistics targetDamageStatistics in this.TargetTotalDamage.Values)
		{
			stringBuilder.Append(targetDamageStatistics.ToString());
		}
		return StringUtils.Format("{0},{1},{2},{3}{4}\n", new string[]
		{
			this.RoleId.ToString(),
			this.RoleName,
			this.IsHeal ? "治疗" : "伤害",
			this.DamageType,
			stringBuilder.ToString()
		});
	}

	// Token: 0x0400BE6D RID: 48749
	private readonly Dictionary<int, TargetDamageStatistics> TargetTotalDamage = new Dictionary<int, TargetDamageStatistics>();

	// Token: 0x0400BE6E RID: 48750
	public readonly int RoleId;

	// Token: 0x0400BE6F RID: 48751
	public readonly string RoleName;

	// Token: 0x0400BE70 RID: 48752
	public readonly string DamageType;

	// Token: 0x0400BE71 RID: 48753
	public readonly bool IsHeal;
}
