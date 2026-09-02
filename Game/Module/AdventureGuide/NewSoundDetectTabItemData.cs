using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide.Views;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x02006197 RID: 24983
	[NullableContext(1)]
	[Nullable(0)]
	public class NewSoundDetectTabItemData
	{
		// Token: 0x0402368C RID: 145036
		public int Area;

		// Token: 0x0402368D RID: 145037
		public string TabTextId = "";

		// Token: 0x0402368E RID: 145038
		public string IconPath = "";

		// Token: 0x0402368F RID: 145039
		[Nullable(2)]
		public NewSoundDetectItemData Dungeon;

		// Token: 0x04023690 RID: 145040
		public int Sort;

		// Token: 0x04023691 RID: 145041
		public bool IsVisible = true;
	}
}
