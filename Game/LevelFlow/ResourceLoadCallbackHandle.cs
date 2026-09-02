using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelFlow
{
	// Token: 0x02006F7A RID: 28538
	[NullableContext(1)]
	[Nullable(0)]
	public class ResourceLoadCallbackHandle
	{
		// Token: 0x06045106 RID: 282886 RVA: 0x011FD290 File Offset: 0x011FB490
		public ResourceLoadCallbackHandle(string path, [Nullable(new byte[]
		{
			1,
			2
		})] Action<UObject> callback)
		{
			this.Path = path;
			this.Callback = delegate([Nullable(2)] UObject asset, string p)
			{
				callback(asset);
			};
		}

		// Token: 0x04026886 RID: 157830
		public string Path;

		// Token: 0x04026887 RID: 157831
		[Nullable(new byte[]
		{
			1,
			2,
			1
		})]
		public Action<UObject, string> Callback;

		// Token: 0x04026888 RID: 157832
		public int ResourceSystemId = -1;

		// Token: 0x04026889 RID: 157833
		[Nullable(2)]
		public UObject Asset;

		// Token: 0x0402688A RID: 157834
		public bool LoadAsyncFinished;
	}
}
