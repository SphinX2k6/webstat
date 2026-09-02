using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001A52 RID: 6738
public class SmallItemGridDefine : IStaticVariableResetter
{
	// Token: 0x0600C0A5 RID: 49317 RVA: 0x0032D5B8 File Offset: 0x0032B7B8
	static SmallItemGridDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SmallItemGridDefine.CreateStaticDefaultValue), new Action(SmallItemGridDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600C0A6 RID: 49318 RVA: 0x0032D5D8 File Offset: 0x0032B7D8
	public static void CreateStaticDefaultValue()
	{
		SmallItemGridDefine.NormalResIdBySlot = new Dictionary<EMultiPlayerSlot, string>
		{
			{
				EMultiPlayerSlot.P1,
				"SP_MapFollowing1"
			},
			{
				EMultiPlayerSlot.P2,
				"SP_MapFollowing2"
			},
			{
				EMultiPlayerSlot.P3,
				"SP_MapFollowing3"
			}
		};
		SmallItemGridDefine.SelfResIdBySlot = new Dictionary<EMultiPlayerSlot, string>
		{
			{
				EMultiPlayerSlot.P1,
				"SP_Online1PIcon_Self"
			},
			{
				EMultiPlayerSlot.P2,
				"SP_Online2PIcon_Self"
			},
			{
				EMultiPlayerSlot.P3,
				"SP_Online3PIcon"
			}
		};
	}

	// Token: 0x0600C0A7 RID: 49319 RVA: 0x0032D641 File Offset: 0x0032B841
	public static void ResetStaticDefaultValue()
	{
		SmallItemGridDefine.NormalResIdBySlot = null;
		SmallItemGridDefine.SelfResIdBySlot = null;
	}

	// Token: 0x04005A50 RID: 23120
	[Nullable(1)]
	public static Dictionary<EMultiPlayerSlot, string> NormalResIdBySlot;

	// Token: 0x04005A51 RID: 23121
	[Nullable(1)]
	public static Dictionary<EMultiPlayerSlot, string> SelfResIdBySlot;
}
