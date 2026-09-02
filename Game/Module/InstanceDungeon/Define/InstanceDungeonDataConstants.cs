using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C09 RID: 23561
	public class InstanceDungeonDataConstants : IStaticVariableResetter
	{
		// Token: 0x0603B994 RID: 244116 RVA: 0x00F1B8C5 File Offset: 0x00F19AC5
		static InstanceDungeonDataConstants()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(InstanceDungeonDataConstants.CreateStaticDefaultValue), new Action(InstanceDungeonDataConstants.ResetStaticDefaultValue));
		}

		// Token: 0x0603B995 RID: 244117 RVA: 0x00F1B8E4 File Offset: 0x00F19AE4
		public static void CreateStaticDefaultValue()
		{
			InstanceDungeonDataConstants.InstanceLockColor = new FColor?(FColor.FromHex("ADADAD"));
		}

		// Token: 0x0603B996 RID: 244118 RVA: 0x00F1B8FA File Offset: 0x00F19AFA
		public static void ResetStaticDefaultValue()
		{
			InstanceDungeonDataConstants.InstanceLockColor = null;
		}

		// Token: 0x040218C6 RID: 137414
		[Nullable(1)]
		public const string INSTANCE_LOCK = "ADADAD";

		// Token: 0x040218C7 RID: 137415
		public static FColor? InstanceLockColor;
	}
}
