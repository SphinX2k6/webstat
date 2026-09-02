using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052ED RID: 21229
	[NullableContext(2)]
	[Nullable(0)]
	public class QuickHackUtil
	{
		// Token: 0x06036341 RID: 222017 RVA: 0x00DA8D04 File Offset: 0x00DA6F04
		[NullableContext(1)]
		public static string GetFailTextIdByCondition(EQuickHackSkillCondition? condition)
		{
			string result = "QuickHack_Prohibit_1";
			if (condition == null)
			{
				return result;
			}
			if (condition != null)
			{
				switch (condition.GetValueOrDefault())
				{
				case EQuickHackSkillCondition.CheckTargetTypeMatch:
					return "QuickHack_Prohibit_2";
				case EQuickHackSkillCondition.CheckRamEnough:
					return "QuickHack_Prohibit_3";
				case EQuickHackSkillCondition.CheckUsageCountEnough:
					return "QuickHack_Prohibit_4";
				case EQuickHackSkillCondition.CheckAnyMonsterTypeMatch:
					return "QuickHack_Prohibit_5";
				case EQuickHackSkillCondition.CheckAnySceneItemCanHack:
				case EQuickHackSkillCondition.CheckAnyTargetNotBeenUsedSkill:
					return "QuickHack_Prohibit_6";
				}
			}
			return result;
		}

		// Token: 0x06036342 RID: 222018 RVA: 0x00DA8D72 File Offset: 0x00DA6F72
		public static QuickHackRamManager CreateRamManager(EQuickHackRamManagerType type)
		{
			if (type == EQuickHackRamManagerType.Fix)
			{
				return new QuickHackFixRamManager();
			}
			if (type != EQuickHackRamManagerType.FormationAttribute)
			{
				return null;
			}
			return new QuickHackFormationAttributeRamManager();
		}

		// Token: 0x06036343 RID: 222019 RVA: 0x00DA8D8A File Offset: 0x00DA6F8A
		public static QuickHackTargetSelector CreateTargetSelector(EQuickHackTargetSelectorType type)
		{
			switch (type)
			{
			case EQuickHackTargetSelectorType.EnemyMonsterOnScreen:
				return new QuickHackMonsterOnScreenTargetSelector();
			case EQuickHackTargetSelectorType.Aim:
				return new QuickHackAimTargetSelector();
			case EQuickHackTargetSelectorType.SceneItemOnScreen:
				return new QuickHackSceneItemOnScreenTargetSelector();
			default:
				return null;
			}
		}

		// Token: 0x06036344 RID: 222020 RVA: 0x00DA8DB3 File Offset: 0x00DA6FB3
		public static IQuickHackTimeScaleManager CreateTimeScaleManager(EQuickHackTimeScaleMode type)
		{
			if (type == EQuickHackTimeScaleMode.WorldTimeDilation)
			{
				return new QuickHackWorldTimeDilationManager();
			}
			if (type != EQuickHackTimeScaleMode.AbsoluteTimeStop)
			{
				return null;
			}
			return new QuickHackAbsoluteTimeStopManager();
		}
	}
}
