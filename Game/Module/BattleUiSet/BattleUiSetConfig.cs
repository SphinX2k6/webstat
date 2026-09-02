using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.BattleUiSet
{
	// Token: 0x02006133 RID: 24883
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BattleUiSetConfig : ConfigBase<BattleUiSetConfig>
	{
		// Token: 0x0603ED9A RID: 257434 RVA: 0x0101A67E File Offset: 0x0101887E
		public static IReadOnlyList<MobileBattleUiSet> GetMobileBattleUiSetConfigList(int panelIndex)
		{
			return ConfigMobileBattleUiSetByPanelIndex.GetConfigList(panelIndex, true);
		}
	}
}
