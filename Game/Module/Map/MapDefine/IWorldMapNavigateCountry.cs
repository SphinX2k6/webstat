using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058CB RID: 22731
	[NullableContext(1)]
	public interface IWorldMapNavigateCountry
	{
		// Token: 0x17009366 RID: 37734
		// (get) Token: 0x06039B61 RID: 236385
		// (set) Token: 0x06039B62 RID: 236386
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Dictionary<int, IWorldMapNavigateState> StateMap { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009367 RID: 37735
		// (get) Token: 0x06039B63 RID: 236387
		// (set) Token: 0x06039B64 RID: 236388
		List<IWorldMapNavigate> AreaNavigateList { get; set; }
	}
}
