using System;
using System.Runtime.CompilerServices;

// Token: 0x02001BDC RID: 7132
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchUnlockSkillData : FloroRanchUnlockDataBase
{
	// Token: 0x0600CF81 RID: 53121 RVA: 0x00371F9C File Offset: 0x0037019C
	public FloroRanchUnlockSkillData(int id, bool isUnLock, int conditionId) : base(id, isUnLock, conditionId, EFloroRanchCardType.Skill)
	{
	}

	// Token: 0x0600CF82 RID: 53122 RVA: 0x00371FA8 File Offset: 0x003701A8
	public void SetSkillData(FloroRanchSkillData skillData)
	{
		this.SkillData = skillData;
	}

	// Token: 0x0600CF83 RID: 53123 RVA: 0x00371FB1 File Offset: 0x003701B1
	public FloroRanchSkillData GetSkillData()
	{
		return this.SkillData;
	}

	// Token: 0x0600CF84 RID: 53124 RVA: 0x00371FB9 File Offset: 0x003701B9
	protected string GetConditionText()
	{
		return LevelGeneralCommons.GetConditionGroupHintText(this.ConditionId) ?? "";
	}

	// Token: 0x040062D3 RID: 25299
	private FloroRanchSkillData SkillData;
}
