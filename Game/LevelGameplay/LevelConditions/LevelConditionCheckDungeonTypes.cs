using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CE6 RID: 27878
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelConditionCheckDungeonTypes : LevelConditionBase, IStaticVariableResetter
	{
		// Token: 0x060443FA RID: 279546 RVA: 0x011B9868 File Offset: 0x011B7A68
		static LevelConditionCheckDungeonTypes()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LevelConditionCheckDungeonTypes.CreateStaticDefaultValue), new Action(LevelConditionCheckDungeonTypes.ResetStaticDefaultValue));
		}

		// Token: 0x060443FB RID: 279547 RVA: 0x011B9968 File Offset: 0x011B7B68
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			LevelConditionCheckDungeonTypes.typeSet.Clear();
			LevelConditionCheckDungeonTypes.subTypeSet.Clear();
			foreach (string[] array2 in LevelConditionCheckDungeonTypes.paramList)
			{
				string limitParams = inConditionInfo.GetLimitParams(array2[0]);
				if (limitParams != null)
				{
					break;
				}
				string limitParams2 = inConditionInfo.GetLimitParams(array2[1]);
				if (limitParams2 != null)
				{
					break;
				}
				int item = 0;
				int item2 = 0;
				bool flag = int.TryParse(limitParams, out item);
				bool flag2 = int.TryParse(limitParams2, out item2);
				if (flag && flag2)
				{
					LevelConditionCheckDungeonTypes.typeSet.Add(item);
					LevelConditionCheckDungeonTypes.subTypeSet.Add(item2);
				}
			}
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
			InstanceDungeon? instanceDungeon = (instance != null) ? instance.GetConfig(instanceId) : null;
			return instanceDungeon != null && LevelConditionCheckDungeonTypes.typeSet.Contains(instanceDungeon.Value.InstType) && LevelConditionCheckDungeonTypes.subTypeSet.Contains(instanceDungeon.Value.InstSubType);
		}

		// Token: 0x060443FC RID: 279548 RVA: 0x011B9A6C File Offset: 0x011B7C6C
		public static void CreateStaticDefaultValue()
		{
			LevelConditionCheckDungeonTypes.typeSet = new HashSet<int>();
			LevelConditionCheckDungeonTypes.subTypeSet = new HashSet<int>();
		}

		// Token: 0x060443FD RID: 279549 RVA: 0x011B9A82 File Offset: 0x011B7C82
		public static void ResetStaticDefaultValue()
		{
			LevelConditionCheckDungeonTypes.typeSet = null;
			LevelConditionCheckDungeonTypes.subTypeSet = null;
		}

		// Token: 0x040260D7 RID: 155863
		[StaticVariableRuleIgnore]
		private static readonly string[][] paramList = new string[][]
		{
			new string[]
			{
				"Type1",
				"SubType1"
			},
			new string[]
			{
				"Type2",
				"SubType2"
			},
			new string[]
			{
				"Type3",
				"SubType3"
			},
			new string[]
			{
				"Type4",
				"SubType4"
			},
			new string[]
			{
				"Type5",
				"SubType5"
			},
			new string[]
			{
				"Type6",
				"SubType6"
			},
			new string[]
			{
				"Type7",
				"SubType7"
			},
			new string[]
			{
				"Type8",
				"SubType8"
			}
		};

		// Token: 0x040260D8 RID: 155864
		private static HashSet<int> typeSet;

		// Token: 0x040260D9 RID: 155865
		private static HashSet<int> subTypeSet;
	}
}
