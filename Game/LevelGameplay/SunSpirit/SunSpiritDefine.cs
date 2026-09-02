using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit
{
	// Token: 0x02006A9E RID: 27294
	public static class SunSpiritDefine
	{
		// Token: 0x06043801 RID: 276481 RVA: 0x01165464 File Offset: 0x01163664
		// Note: this type is marked as 'beforefieldinit'.
		static SunSpiritDefine()
		{
			Dictionary<ESunSpiritStateType, string> dictionary = new Dictionary<ESunSpiritStateType, string>();
			dictionary[ESunSpiritStateType.None] = "None";
			dictionary[ESunSpiritStateType.FlyingToGear] = "FlyingToGear";
			dictionary[ESunSpiritStateType.FlyingToPlayer] = "FlyingToPlayer";
			dictionary[ESunSpiritStateType.OccupiedByGear] = "OccupiedByGear";
			dictionary[ESunSpiritStateType.OccupiedByPlayer] = "OccupiedByPlayer";
			SunSpiritDefine.sunSpiritStateTypeToString = dictionary;
		}

		// Token: 0x04025B55 RID: 154453
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<ESunSpiritStateType, string> sunSpiritStateTypeToString;
	}
}
