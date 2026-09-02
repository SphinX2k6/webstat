using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001CB2 RID: 7346
public class LevelFuncFlagDefine : IStaticVariableResetter
{
	// Token: 0x0600D7A7 RID: 55207 RVA: 0x0039AD3A File Offset: 0x00398F3A
	static LevelFuncFlagDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(LevelFuncFlagDefine.CreateStaticDefaultValue), new Action(LevelFuncFlagDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600D7A8 RID: 55208 RVA: 0x0039AD59 File Offset: 0x00398F59
	public static void CreateStaticDefaultValue()
	{
		LevelFuncFlagDefine.levelFuncFlagDefaultVal = new Dictionary<ELevelFuncFlagId, bool>
		{
			{
				ELevelFuncFlagId.TempTeleporterPlacement,
				true
			},
			{
				ELevelFuncFlagId.ExploreSkillRoulette,
				true
			}
		};
	}

	// Token: 0x0600D7A9 RID: 55209 RVA: 0x0039AD75 File Offset: 0x00398F75
	public static void ResetStaticDefaultValue()
	{
		LevelFuncFlagDefine.levelFuncFlagDefaultVal = null;
	}

	// Token: 0x040066B1 RID: 26289
	[Nullable(2)]
	public static Dictionary<ELevelFuncFlagId, bool> levelFuncFlagDefaultVal;
}
