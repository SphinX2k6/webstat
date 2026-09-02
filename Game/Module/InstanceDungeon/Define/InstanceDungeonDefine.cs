using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C1B RID: 23579
	public class InstanceDungeonDefine : IStaticVariableResetter
	{
		// Token: 0x0603B9E6 RID: 244198 RVA: 0x00F1BA16 File Offset: 0x00F19C16
		static InstanceDungeonDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(InstanceDungeonDefine.CreateStaticDefaultValue), new Action(InstanceDungeonDefine.ResetStaticDefaultValue));
		}

		// Token: 0x0603B9E7 RID: 244199 RVA: 0x00F1BA35 File Offset: 0x00F19C35
		public static void CreateStaticDefaultValue()
		{
			InstanceDungeonDefine.TrialRoleSkipCheckInstanceType = new EDungeonSubType[]
			{
				EDungeonSubType.RhythmShip,
				EDungeonSubType.PinballBattle
			};
		}

		// Token: 0x0603B9E8 RID: 244200 RVA: 0x00F1BA4C File Offset: 0x00F19C4C
		public static void ResetStaticDefaultValue()
		{
			InstanceDungeonDefine.TrialRoleSkipCheckInstanceType = null;
		}

		// Token: 0x040218D8 RID: 137432
		public const int DUNGEON_ARCHIVE_HELP_ID = 242;

		// Token: 0x040218D9 RID: 137433
		[Nullable(2)]
		public static EDungeonSubType[] TrialRoleSkipCheckInstanceType;
	}
}
