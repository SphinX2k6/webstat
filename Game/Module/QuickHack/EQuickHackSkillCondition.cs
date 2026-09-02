using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052E6 RID: 21222
	[EnumExtensions]
	public enum EQuickHackSkillCondition
	{
		// Token: 0x0401F23D RID: 127549
		CheckTargetTypeMatch,
		// Token: 0x0401F23E RID: 127550
		CheckRamEnough,
		// Token: 0x0401F23F RID: 127551
		CheckUsageCountEnough,
		// Token: 0x0401F240 RID: 127552
		CheckAnyMonsterTypeMatch,
		// Token: 0x0401F241 RID: 127553
		CheckAnySceneItemCanHack,
		// Token: 0x0401F242 RID: 127554
		CheckAnyTargetNotBeenUsedSkill
	}
}
