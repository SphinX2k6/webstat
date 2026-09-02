using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005767 RID: 22375
	[NullableContext(1)]
	[Nullable(0)]
	public static class MenuDefineInstSettings
	{
		// Token: 0x06038EFB RID: 233211 RVA: 0x00E6C984 File Offset: 0x00E6AB84
		// Note: this type is marked as 'beforefieldinit'.
		static MenuDefineInstSettings()
		{
			Dictionary<EWorldDungeonSubType, EFunction[]> dictionary = new Dictionary<EWorldDungeonSubType, EFunction[]>();
			dictionary[EWorldDungeonSubType.SpringManorWorld] = new EFunction[]
			{
				EFunction.MobileButtonCustom,
				EFunction.MotorMobileButtonCustom
			};
			MenuDefineInstSettings.disableSettingsWorldInstMap = dictionary;
		}

		// Token: 0x040206C7 RID: 132807
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<EDungeonSubType, EFunction[]> disableSettingsInstMap = new Dictionary<EDungeonSubType, EFunction[]>();

		// Token: 0x040206C8 RID: 132808
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<EWorldDungeonSubType, EFunction[]> disableSettingsWorldInstMap;
	}
}
