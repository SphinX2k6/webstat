using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002920 RID: 10528
public class RouletteDefine : IStaticVariableResetter
{
	// Token: 0x06014E11 RID: 85521 RVA: 0x005C7A8F File Offset: 0x005C5C8F
	static RouletteDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RouletteDefine.CreateStaticDefaultValue), new Action(RouletteDefine.ResetStaticDefaultValue));
	}

	// Token: 0x06014E12 RID: 85522 RVA: 0x005C7AAE File Offset: 0x005C5CAE
	public static void CreateStaticDefaultValue()
	{
		RouletteDefine.rouletteTypeDefine = new Dictionary<ERouletteType, RouletteType>
		{
			{
				ERouletteType.Explore,
				RouletteType.Explore
			},
			{
				ERouletteType.Function,
				RouletteType.Function
			},
			{
				ERouletteType.Motor,
				RouletteType.Motorcycle
			}
		};
	}

	// Token: 0x06014E13 RID: 85523 RVA: 0x005C7AD2 File Offset: 0x005C5CD2
	public static void ResetStaticDefaultValue()
	{
		RouletteDefine.rouletteTypeDefine = null;
	}

	// Token: 0x0400A0FE RID: 41214
	[Nullable(2)]
	public static Dictionary<ERouletteType, RouletteType> rouletteTypeDefine;

	// Token: 0x0400A0FF RID: 41215
	[Nullable(1)]
	public const string ROULETTE_TEXT_EMPTY = "Text_ProbeToolFunctionNotice2_Text";

	// Token: 0x0400A100 RID: 41216
	public const int DEFAULT_ITEM_ROULETTE_GRID_INDEX = 7;

	// Token: 0x0400A101 RID: 41217
	public const int ROULETTE_NUM = 8;

	// Token: 0x0400A102 RID: 41218
	public const int ROULETTE_EXPLORE_IN_USE = 7;

	// Token: 0x0400A103 RID: 41219
	public const int ROULETTE_FUNCTION_IN_USE = 8;
}
