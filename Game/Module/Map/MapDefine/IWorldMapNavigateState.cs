using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058CF RID: 22735
	[NullableContext(1)]
	public interface IWorldMapNavigateState
	{
		// Token: 0x1700936E RID: 37742
		// (get) Token: 0x06039B72 RID: 236402
		int StateId { get; }

		// Token: 0x1700936F RID: 37743
		// (get) Token: 0x06039B73 RID: 236403
		int SortIndex { get; }

		// Token: 0x17009370 RID: 37744
		// (get) Token: 0x06039B74 RID: 236404
		List<IWorldMapNavigate> AreaNavigateList { get; }
	}
}
