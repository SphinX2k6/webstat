using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058CD RID: 22733
	[NullableContext(1)]
	public interface IWorldMapNavigateCountryData
	{
		// Token: 0x1700936A RID: 37738
		// (get) Token: 0x06039B6A RID: 236394
		int CountryId { get; }

		// Token: 0x1700936B RID: 37739
		// (get) Token: 0x06039B6B RID: 236395
		// (set) Token: 0x06039B6C RID: 236396
		IWorldMapNavigateCountry NavigateCountry { get; set; }
	}
}
