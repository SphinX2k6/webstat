using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002310 RID: 8976
public class MotorcycleMusicPlayerDefine : IStaticVariableResetter
{
	// Token: 0x060110E6 RID: 69862 RVA: 0x004AF19A File Offset: 0x004AD39A
	static MotorcycleMusicPlayerDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(MotorcycleMusicPlayerDefine.CreateStaticDefaultValue), new Action(MotorcycleMusicPlayerDefine.ResetStaticDefaultValue));
	}

	// Token: 0x060110E7 RID: 69863 RVA: 0x004AF1BC File Offset: 0x004AD3BC
	public static void CreateStaticDefaultValue()
	{
		MotorcycleMusicPlayerDefine.motorMusicPlayModeIcon = new Dictionary<EMotorMusicPlayMode, string>
		{
			{
				EMotorMusicPlayMode.Order,
				"SP_BtnPlayerFuncSequential"
			},
			{
				EMotorMusicPlayMode.Random,
				"SP_BtnPlayerFuncRandom"
			},
			{
				EMotorMusicPlayMode.Repeat,
				"SP_BtnPlayerFuncSingle"
			}
		};
		MotorcycleMusicPlayerDefine.motorPlayModeName = new Dictionary<EMotorMusicPlayMode, string>
		{
			{
				EMotorMusicPlayMode.Order,
				"MotorMusicTips04"
			},
			{
				EMotorMusicPlayMode.Random,
				"MotorMusicTips03"
			},
			{
				EMotorMusicPlayMode.Repeat,
				"MotorMusicTips02"
			}
		};
	}

	// Token: 0x060110E8 RID: 69864 RVA: 0x004AF225 File Offset: 0x004AD425
	public static void ResetStaticDefaultValue()
	{
		MotorcycleMusicPlayerDefine.motorMusicPlayModeIcon = null;
		MotorcycleMusicPlayerDefine.motorPlayModeName = null;
	}

	// Token: 0x04008624 RID: 34340
	[Nullable(1)]
	public static Dictionary<EMotorMusicPlayMode, string> motorMusicPlayModeIcon;

	// Token: 0x04008625 RID: 34341
	[Nullable(1)]
	public static Dictionary<EMotorMusicPlayMode, string> motorPlayModeName;
}
