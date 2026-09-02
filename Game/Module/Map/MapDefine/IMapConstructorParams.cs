using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058D2 RID: 22738
	public interface IMapConstructorParams
	{
		// Token: 0x17009374 RID: 37748
		// (get) Token: 0x06039B7D RID: 236413
		// (set) Token: 0x06039B7E RID: 236414
		int InstanceId { get; set; }

		// Token: 0x17009375 RID: 37749
		// (get) Token: 0x06039B7F RID: 236415
		// (set) Token: 0x06039B80 RID: 236416
		EMapType MapType { get; set; }

		// Token: 0x17009376 RID: 37750
		// (get) Token: 0x06039B81 RID: 236417
		// (set) Token: 0x06039B82 RID: 236418
		float MapDefaultScale { get; set; }

		// Token: 0x17009377 RID: 37751
		// (get) Token: 0x06039B83 RID: 236419
		// (set) Token: 0x06039B84 RID: 236420
		EMapGravityDirection? Gravity { get; set; }

		// Token: 0x17009378 RID: 37752
		// (get) Token: 0x06039B85 RID: 236421
		// (set) Token: 0x06039B86 RID: 236422
		float? MarkScale { get; set; }

		// Token: 0x17009379 RID: 37753
		// (get) Token: 0x06039B87 RID: 236423
		// (set) Token: 0x06039B88 RID: 236424
		float? ClickRange { get; set; }

		// Token: 0x1700937A RID: 37754
		// (get) Token: 0x06039B89 RID: 236425
		// (set) Token: 0x06039B8A RID: 236426
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		Dictionary<string, UTexture> PreloadTiles { [return: Nullable(new byte[]
		{
			2,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1
		})] set; }
	}
}
