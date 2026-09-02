using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200245B RID: 9307
public class PhantomBattleConfigDefine : IStaticVariableResetter
{
	// Token: 0x0601209D RID: 73885 RVA: 0x004F65D7 File Offset: 0x004F47D7
	static PhantomBattleConfigDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PhantomBattleConfigDefine.CreateStaticDefaultValue), new Action(PhantomBattleConfigDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0601209E RID: 73886 RVA: 0x004F65F6 File Offset: 0x004F47F6
	public static void ResetStaticDefaultValue()
	{
		PhantomBattleConfigDefine.COSTLIST = null;
	}

	// Token: 0x0601209F RID: 73887 RVA: 0x004F65FE File Offset: 0x004F47FE
	public static void CreateStaticDefaultValue()
	{
		PhantomBattleConfigDefine.COSTLIST = new List<int>
		{
			1,
			3,
			4
		};
	}

	// Token: 0x04008D03 RID: 36099
	public const int COST3 = 3;

	// Token: 0x04008D04 RID: 36100
	public const int COST1 = 1;

	// Token: 0x04008D05 RID: 36101
	[Nullable(2)]
	public static List<int> COSTLIST;
}
