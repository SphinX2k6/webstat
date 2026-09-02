using System;
using System.Runtime.CompilerServices;

// Token: 0x02002476 RID: 9334
public class PhantomBattleDefine : IStaticVariableResetter
{
	// Token: 0x0601213F RID: 74047 RVA: 0x004F7F3B File Offset: 0x004F613B
	static PhantomBattleDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PhantomBattleDefine.CreateStaticDefaultValue), new Action(PhantomBattleDefine.ResetStaticDefaultValue));
	}

	// Token: 0x06012140 RID: 74048 RVA: 0x004F7F5A File Offset: 0x004F615A
	public static void ResetStaticDefaultValue()
	{
		PhantomBattleDefine.costListRecommendHighLevel = null;
		PhantomBattleDefine.costListRecommendLowLevel = null;
	}

	// Token: 0x06012141 RID: 74049 RVA: 0x004F7F68 File Offset: 0x004F6168
	public static void CreateStaticDefaultValue()
	{
		PhantomBattleDefine.costListRecommendHighLevel = new int[]
		{
			4,
			3,
			3,
			1,
			1
		};
		PhantomBattleDefine.costListRecommendLowLevel = new int[]
		{
			4,
			3,
			1,
			1,
			1
		};
	}

	// Token: 0x04008D3F RID: 36159
	public const int MINEXP = 20;

	// Token: 0x04008D40 RID: 36160
	public const int PROPOFFSET = 10000;

	// Token: 0x04008D41 RID: 36161
	public const int BLACKSTONEIDNUM = 2;

	// Token: 0x04008D42 RID: 36162
	public const int MAX_EQUIP_COUNT = 5;

	// Token: 0x04008D43 RID: 36163
	[Nullable(1)]
	public static int[] costListRecommendHighLevel;

	// Token: 0x04008D44 RID: 36164
	[Nullable(1)]
	public static int[] costListRecommendLowLevel;

	// Token: 0x02008791 RID: 34705
	public enum ETipsType
	{
		// Token: 0x0402DD53 RID: 187731
		Preview,
		// Token: 0x0402DD54 RID: 187732
		Equip
	}
}
