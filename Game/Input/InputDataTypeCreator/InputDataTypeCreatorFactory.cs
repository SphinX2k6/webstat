using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;

namespace CSharpScript.Game.Input.InputDataTypeCreator
{
	// Token: 0x02006FD6 RID: 28630
	[NullableContext(1)]
	[Nullable(0)]
	public class InputDataTypeCreatorFactory : IStaticVariableResetter
	{
		// Token: 0x06045465 RID: 283749 RVA: 0x01218583 File Offset: 0x01216783
		static InputDataTypeCreatorFactory()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(InputDataTypeCreatorFactory.CreateStaticDefaultValue), new Action(InputDataTypeCreatorFactory.ResetStaticDefaultValue));
		}

		// Token: 0x06045466 RID: 283750 RVA: 0x012185A4 File Offset: 0x012167A4
		public static void Initialize()
		{
			InputDataTypeCreatorFactory.InputDataCreatorMap[EDungeonSubType.TowerDefenseEvent] = new TrapDefenseInputDataTypeCreator();
			InputDataTypeCreatorFactory.InputDataCreatorMap[EDungeonSubType.Survivors] = new SurvivorsRogueInputDataTypeCreator();
			InputDataTypeCreatorFactory.InputDataCreatorMap[EDungeonSubType.PinballBattle] = new PinballBattleInputDataTypeCreator();
			InputDataTypeCreatorFactory.WorldInstanceInputDataCreatorMap[EWorldDungeonSubType.SpringManorWorld] = new SpringManorInputDataTypeCreator();
		}

		// Token: 0x06045467 RID: 283751 RVA: 0x012185F4 File Offset: 0x012167F4
		public static InputDataTypeCreator GetInputDataCreator(EDungeonSubType dungeonSubType, EWorldDungeonSubType worldDungeonSubType)
		{
			InputDataTypeCreator inputDataTypeCreator = null;
			InputDataTypeCreator inputDataTypeCreator3;
			if (dungeonSubType == EDungeonSubType.WorldInstance)
			{
				InputDataTypeCreator inputDataTypeCreator2;
				if (InputDataTypeCreatorFactory.WorldInstanceInputDataCreatorMap.TryGetValue(worldDungeonSubType, out inputDataTypeCreator2))
				{
					inputDataTypeCreator = inputDataTypeCreator2;
				}
			}
			else if (InputDataTypeCreatorFactory.InputDataCreatorMap.TryGetValue(dungeonSubType, out inputDataTypeCreator3))
			{
				inputDataTypeCreator = inputDataTypeCreator3;
			}
			if (inputDataTypeCreator != null)
			{
				return inputDataTypeCreator;
			}
			return InputDataTypeCreatorFactory.DefaultInputDataCreator;
		}

		// Token: 0x06045468 RID: 283752 RVA: 0x01218636 File Offset: 0x01216836
		public static void CreateStaticDefaultValue()
		{
			InputDataTypeCreatorFactory.InputDataCreatorMap = new Dictionary<EDungeonSubType, InputDataTypeCreator>();
			InputDataTypeCreatorFactory.WorldInstanceInputDataCreatorMap = new Dictionary<EWorldDungeonSubType, InputDataTypeCreator>();
			InputDataTypeCreatorFactory.DefaultInputDataCreator = new NormalWorldInputDataTypeCreator();
		}

		// Token: 0x06045469 RID: 283753 RVA: 0x01218656 File Offset: 0x01216856
		public static void ResetStaticDefaultValue()
		{
			InputDataTypeCreatorFactory.InputDataCreatorMap = null;
			InputDataTypeCreatorFactory.WorldInstanceInputDataCreatorMap = null;
			InputDataTypeCreatorFactory.DefaultInputDataCreator = null;
		}

		// Token: 0x04026A82 RID: 158338
		private static Dictionary<EDungeonSubType, InputDataTypeCreator> InputDataCreatorMap;

		// Token: 0x04026A83 RID: 158339
		private static Dictionary<EWorldDungeonSubType, InputDataTypeCreator> WorldInstanceInputDataCreatorMap;

		// Token: 0x04026A84 RID: 158340
		private static InputDataTypeCreator DefaultInputDataCreator;
	}
}
