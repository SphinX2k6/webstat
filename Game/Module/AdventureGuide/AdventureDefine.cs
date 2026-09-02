using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x02006198 RID: 24984
	public class AdventureDefine : IStaticVariableResetter
	{
		// Token: 0x0603F1BE RID: 258494 RVA: 0x0102F5A0 File Offset: 0x0102D7A0
		static AdventureDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(AdventureDefine.CreateStaticDefaultValue), new Action(AdventureDefine.ResetStaticDefaultValue));
		}

		// Token: 0x0603F1BF RID: 258495 RVA: 0x0102F614 File Offset: 0x0102D814
		public static void CreateStaticDefaultValue()
		{
			AdventureDefine.checkDungeonTypeCanShowHandlerMap = new Dictionary<EDungeonType, CheckDungeonTypeCanShowHandlerBase>
			{
				{
					EDungeonType.WheelTower,
					new CheckWheelTowerCanShowHandler()
				}
			};
		}

		// Token: 0x0603F1C0 RID: 258496 RVA: 0x0102F62D File Offset: 0x0102D82D
		public static void ResetStaticDefaultValue()
		{
			AdventureDefine.checkDungeonTypeCanShowHandlerMap = null;
		}

		// Token: 0x04023692 RID: 145042
		public const int Monster062DetectConfID = 10010053;

		// Token: 0x04023693 RID: 145043
		public const int BigWorldID = 8;

		// Token: 0x04023694 RID: 145044
		public const int EDEFAULTCATEGORY = 16;

		// Token: 0x04023695 RID: 145045
		public const int WORLD_LEVEL_MIN = 1;

		// Token: 0x04023696 RID: 145046
		public const int WORLD_LEVEL_MAX = 8;

		// Token: 0x04023697 RID: 145047
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static IReadOnlyDictionary<EPeriodicityChallengeType, int> periodicityChallengeTypeToTarget = new Dictionary<EPeriodicityChallengeType, int>
		{
			{
				EPeriodicityChallengeType.None,
				0
			},
			{
				EPeriodicityChallengeType.TowerLow,
				1
			},
			{
				EPeriodicityChallengeType.TowerHigh,
				2
			},
			{
				EPeriodicityChallengeType.TowerVariation,
				3
			},
			{
				EPeriodicityChallengeType.TowerOverLoad,
				4
			},
			{
				EPeriodicityChallengeType.ShipTowerNormal,
				0
			},
			{
				EPeriodicityChallengeType.ShipTowerPeriodicity,
				0
			},
			{
				EPeriodicityChallengeType.WeeklyRogue,
				0
			}
		};

		// Token: 0x04023698 RID: 145048
		[Nullable(1)]
		public static Dictionary<EDungeonType, CheckDungeonTypeCanShowHandlerBase> checkDungeonTypeCanShowHandlerMap;
	}
}
