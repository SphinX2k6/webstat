using System;
using System.Runtime.CompilerServices;

// Token: 0x02000F92 RID: 3986
[NullableContext(1)]
[Nullable(0)]
public class TowerDefenseSubModel : KscSubModelBase
{
	// Token: 0x060065A6 RID: 26022 RVA: 0x00198B46 File Offset: 0x00196D46
	public override string GetSkillDtPath()
	{
		return TowerDefenseSubModel.SkillDtPath;
	}

	// Token: 0x060065A7 RID: 26023 RVA: 0x00198B4D File Offset: 0x00196D4D
	public override string GetEntityDtPath()
	{
		return TowerDefenseSubModel.EntityDtPath;
	}

	// Token: 0x04003059 RID: 12377
	public static readonly string SkillDtPath = "/Game/Aki/Data/SimpleCombat/2_6TaFang/Player/AssistMachine/SkillComp/DT_KscSkill_AssistMachine.DT_KscSkill_AssistMachine";

	// Token: 0x0400305A RID: 12378
	public static readonly string EntityDtPath = "/Game/Aki/Data/SimpleCombat/2_6TaFang/Player/DT_KscEntity.DT_KscEntity";
}
