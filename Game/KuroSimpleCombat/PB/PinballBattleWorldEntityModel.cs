using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.KuroSimpleCombat.PB
{
	// Token: 0x02006FBE RID: 28606
	[NullableContext(2)]
	[Nullable(0)]
	internal class PinballBattleWorldEntityModel
	{
		// Token: 0x04026957 RID: 158039
		public int Uid;

		// Token: 0x04026958 RID: 158040
		public int CombatId;

		// Token: 0x04026959 RID: 158041
		public int PropertyId;

		// Token: 0x0402695A RID: 158042
		public string AssetPath;

		// Token: 0x0402695B RID: 158043
		public int? SplineId;

		// Token: 0x0402695C RID: 158044
		public Dictionary<int, int> BuffIdLayers;

		// Token: 0x0402695D RID: 158045
		public Dictionary<int, int> AttributeMap;
	}
}
