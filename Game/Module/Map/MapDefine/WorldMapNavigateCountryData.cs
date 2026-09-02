using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058CE RID: 22734
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapNavigateCountryData : IWorldMapNavigateCountryData
	{
		// Token: 0x1700936C RID: 37740
		// (get) Token: 0x06039B6D RID: 236397 RVA: 0x00EA025A File Offset: 0x00E9E45A
		// (set) Token: 0x06039B6E RID: 236398 RVA: 0x00EA0262 File Offset: 0x00E9E462
		public int CountryId { get; set; }

		// Token: 0x1700936D RID: 37741
		// (get) Token: 0x06039B6F RID: 236399 RVA: 0x00EA026B File Offset: 0x00E9E46B
		// (set) Token: 0x06039B70 RID: 236400 RVA: 0x00EA0273 File Offset: 0x00E9E473
		public IWorldMapNavigateCountry NavigateCountry { get; set; }
	}
}
