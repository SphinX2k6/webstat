using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FC5 RID: 20421
	public static class SheriffShopDefine
	{
		// Token: 0x06034AA7 RID: 215719 RVA: 0x00D34BE4 File Offset: 0x00D32DE4
		// Note: this type is marked as 'beforefieldinit'.
		static SheriffShopDefine()
		{
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			dictionary[1] = "Sheriff_Shop_3";
			dictionary[2] = "Sheriff_Shop_4";
			dictionary[3] = "Sheriff_Shop_5";
			SheriffShopDefine.SheriffShopTabMenuName = dictionary;
		}

		// Token: 0x0401E5CE RID: 124366
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyDictionary<int, string> SheriffShopTabMenuName;
	}
}
