using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005257 RID: 21079
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleDefine : IStaticVariableResetter
	{
		// Token: 0x06035F4D RID: 221005 RVA: 0x00D9225E File Offset: 0x00D9045E
		static RogueBattleDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RogueBattleDefine.CreateStaticDefaultValue), new Action(RogueBattleDefine.ResetStaticDefaultValue));
		}

		// Token: 0x06035F4E RID: 221006 RVA: 0x00D9227D File Offset: 0x00D9047D
		public static void CreateStaticDefaultValue()
		{
			RogueBattleDefine.FetterTypeIconMap = new Dictionary<ERogueResBondEffectType, string>
			{
				{
					ERogueResBondEffectType.Battle,
					"T_RogueFetters_03"
				},
				{
					ERogueResBondEffectType.Explore,
					"T_RogueFetters_02"
				},
				{
					ERogueResBondEffectType.Link,
					"T_RogueFetters_01"
				}
			};
		}

		// Token: 0x06035F4F RID: 221007 RVA: 0x00D922AD File Offset: 0x00D904AD
		public static void ResetStaticDefaultValue()
		{
			RogueBattleDefine.FetterTypeIconMap = null;
		}

		// Token: 0x06035F50 RID: 221008 RVA: 0x00D922B8 File Offset: 0x00D904B8
		public static int SortRogueBattleRoleBondInfo(RoleBondInfo aBondInfo, RoleBondInfo bBondInfo)
		{
			if (aBondInfo.Level != bBondInfo.Level)
			{
				return bBondInfo.Level - aBondInfo.Level;
			}
			if (aBondInfo.CurStar == bBondInfo.CurStar)
			{
				return aBondInfo.ConfigId - bBondInfo.ConfigId;
			}
			return bBondInfo.CurStar - aBondInfo.CurStar;
		}

		// Token: 0x06035F51 RID: 221009 RVA: 0x00D9230C File Offset: 0x00D9050C
		public static int SortRogueBattleRoleBondUpdateInfo(IRogueBattleRoleBondUpdateInfo a, IRogueBattleRoleBondUpdateInfo b)
		{
			RoleBondInfo newRoleBondInfo = a.NewRoleBondInfo;
			RoleBondInfo newRoleBondInfo2 = b.NewRoleBondInfo;
			if (newRoleBondInfo.Level != newRoleBondInfo2.Level)
			{
				return newRoleBondInfo2.Level - newRoleBondInfo.Level;
			}
			if (newRoleBondInfo.CurStar == newRoleBondInfo2.CurStar)
			{
				return newRoleBondInfo.ConfigId - newRoleBondInfo2.ConfigId;
			}
			return newRoleBondInfo2.CurStar - newRoleBondInfo.CurStar;
		}

		// Token: 0x0401EFE8 RID: 126952
		public static Dictionary<ERogueResBondEffectType, string> FetterTypeIconMap;

		// Token: 0x0401EFE9 RID: 126953
		public const int ROLELEVEL_EFFECTSHOW_TAG = 34;

		// Token: 0x0401EFEA RID: 126954
		public const int SKILLLEVEL_EFFECTSHOW_TAG = 33;

		// Token: 0x0401EFEB RID: 126955
		public const int WEAPONLEVEL_EFFECTSHOW_TAG = 32;
	}
}
