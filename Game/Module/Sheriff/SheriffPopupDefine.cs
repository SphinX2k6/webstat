using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FC6 RID: 20422
	public static class SheriffPopupDefine
	{
		// Token: 0x06034AA8 RID: 215720 RVA: 0x00D34C14 File Offset: 0x00D32E14
		// Note: this type is marked as 'beforefieldinit'.
		static SheriffPopupDefine()
		{
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			dictionary[0] = "Sheriff_HudDesc_4";
			dictionary[1] = "Sheriff_HudDesc_5";
			SheriffPopupDefine.SheriffCriminalIdentityTxt = dictionary;
		}

		// Token: 0x0401E5CF RID: 124367
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyDictionary<int, string> SheriffCriminalIdentityTxt;
	}
}
