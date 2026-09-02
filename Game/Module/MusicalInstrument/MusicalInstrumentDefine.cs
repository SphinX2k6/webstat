using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056DC RID: 22236
	public static class MusicalInstrumentDefine
	{
		// Token: 0x04020492 RID: 132242
		public const int GUQIN_ITEM_ID = 80700051;

		// Token: 0x04020493 RID: 132243
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyDictionary<EInstrumentType, Func<MusicalInstrumentSubController>> MusicalInstrumentSubControllerCreators = new Dictionary<EInstrumentType, Func<MusicalInstrumentSubController>>
		{
			{
				EInstrumentType.ChineseZither,
				() => new GuqinSubController()
			}
		};
	}
}
