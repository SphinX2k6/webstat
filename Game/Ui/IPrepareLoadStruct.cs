using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A3D RID: 19005
	[NullableContext(1)]
	public interface IPrepareLoadStruct
	{
		// Token: 0x17008478 RID: 33912
		// (get) Token: 0x06031A78 RID: 203384
		string ResourceId { get; }

		// Token: 0x17008479 RID: 33913
		// (get) Token: 0x06031A79 RID: 203385
		Func<int> CacheCount { get; }
	}
}
