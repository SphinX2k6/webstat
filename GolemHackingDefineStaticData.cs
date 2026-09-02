using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020010BC RID: 4284
public class GolemHackingDefineStaticData : IStaticVariableResetter
{
	// Token: 0x06006F6F RID: 28527 RVA: 0x001CFAEF File Offset: 0x001CDCEF
	static GolemHackingDefineStaticData()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GolemHackingDefineStaticData.CreateStaticDefaultValue), new Action(GolemHackingDefineStaticData.ResetStaticDefaultValue));
	}

	// Token: 0x06006F70 RID: 28528 RVA: 0x001CFB10 File Offset: 0x001CDD10
	public static void CreateStaticDefaultValue()
	{
		GolemHackingDefineStaticData.GolemHackingTexResourceMap = new Dictionary<EGolemHackingGroupState, string[]>
		{
			{
				EGolemHackingGroupState.Locked,
				new string[]
				{
					"T_LevelCardBlackNor",
					"T_LevelCardBlackHold",
					"T_LevelCardBlackPress"
				}
			},
			{
				EGolemHackingGroupState.Normal,
				new string[]
				{
					"T_LevelCardBlueNor",
					"T_LevelCardBlueHold",
					"T_LevelCardBluePress"
				}
			},
			{
				EGolemHackingGroupState.Clear,
				new string[]
				{
					"T_LevelCardGreenNor",
					"T_LevelCardGreenHold",
					"T_LevelCardGreenPress"
				}
			},
			{
				EGolemHackingGroupState.Bonus,
				new string[]
				{
					"T_LevelCardPurpleNor",
					"T_LevelCardPurpleHold",
					"T_LevelCardPurplePress"
				}
			}
		};
	}

	// Token: 0x06006F71 RID: 28529 RVA: 0x001CFBBD File Offset: 0x001CDDBD
	public static void ResetStaticDefaultValue()
	{
		GolemHackingDefineStaticData.GolemHackingTexResourceMap = null;
	}

	// Token: 0x04003578 RID: 13688
	[Nullable(1)]
	public static Dictionary<EGolemHackingGroupState, string[]> GolemHackingTexResourceMap;
}
