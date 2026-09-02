using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058CC RID: 22732
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapNavigateCountryImpl : IWorldMapNavigateCountry
	{
		// Token: 0x17009368 RID: 37736
		// (get) Token: 0x06039B65 RID: 236389 RVA: 0x00EA0225 File Offset: 0x00E9E425
		// (set) Token: 0x06039B66 RID: 236390 RVA: 0x00EA022D File Offset: 0x00E9E42D
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, IWorldMapNavigateState> StateMap { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009369 RID: 37737
		// (get) Token: 0x06039B67 RID: 236391 RVA: 0x00EA0236 File Offset: 0x00E9E436
		// (set) Token: 0x06039B68 RID: 236392 RVA: 0x00EA023E File Offset: 0x00E9E43E
		public List<IWorldMapNavigate> AreaNavigateList { get; set; } = new List<IWorldMapNavigate>();
	}
}
