using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip;
using UnrealEngine;

// Token: 0x02001147 RID: 4423
public class RhythmGameUtil
{
	// Token: 0x06007495 RID: 29845 RVA: 0x001E8F70 File Offset: 0x001E7170
	[NullableContext(1)]
	public static TArray<FKuroRhythmSkillEffectParam> GetRhythmGameSkillEffectParam(int roleId)
	{
		TArray<FKuroRhythmSkillEffectParam> tarray = new TArray<FKuroRhythmSkillEffectParam>();
		RhythmRole? rhythmRoleById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmRoleById(roleId);
		if (rhythmRoleById == null)
		{
			return tarray;
		}
		foreach (int id in rhythmRoleById.Value.SkillEffectListIter())
		{
			RhythmEffect? rhythmRoleEffectById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmRoleEffectById(id);
			if (rhythmRoleEffectById != null)
			{
				FKuroRhythmSkillEffectParam fkuroRhythmSkillEffectParam = new FKuroRhythmSkillEffectParam();
				fkuroRhythmSkillEffectParam.EffectType = rhythmRoleEffectById.Value.Type;
				TArray<string> tarray2 = new TArray<string>();
				if (rhythmRoleEffectById.Value.Param1 != "")
				{
					tarray2.Add(rhythmRoleEffectById.Value.Param1);
				}
				if (rhythmRoleEffectById.Value.Param2 != "")
				{
					tarray2.Add(rhythmRoleEffectById.Value.Param2);
				}
				if (rhythmRoleEffectById.Value.Param3 != "")
				{
					tarray2.Add(rhythmRoleEffectById.Value.Param3);
				}
				fkuroRhythmSkillEffectParam.EffectParams = tarray2;
				tarray.Add(fkuroRhythmSkillEffectParam);
			}
		}
		return tarray;
	}
}
