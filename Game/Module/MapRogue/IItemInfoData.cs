using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200598D RID: 22925
	[NullableContext(1)]
	public interface IItemInfoData
	{
		// Token: 0x17009478 RID: 38008
		// (get) Token: 0x0603A0F8 RID: 237816
		// (set) Token: 0x0603A0F9 RID: 237817
		string TitleId { get; set; }

		// Token: 0x17009479 RID: 38009
		// (get) Token: 0x0603A0FA RID: 237818
		// (set) Token: 0x0603A0FB RID: 237819
		string Value { get; set; }

		// Token: 0x1700947A RID: 38010
		// (get) Token: 0x0603A0FC RID: 237820
		// (set) Token: 0x0603A0FD RID: 237821
		bool ValueChangeColor { get; set; }
	}
}
