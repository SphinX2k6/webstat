using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FEA RID: 28650
	public static class InputBindingDefine
	{
		// Token: 0x04026AB9 RID: 158393
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly EInputBindingType[] inputBindingTypesArray = new EInputBindingType[]
		{
			EInputBindingType.Original,
			EInputBindingType.Motor
		};
	}
}
