using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058D3 RID: 22739
	public class MapConstructorParams : IMapConstructorParams
	{
		// Token: 0x1700937B RID: 37755
		// (get) Token: 0x06039B8B RID: 236427 RVA: 0x00EA02D2 File Offset: 0x00E9E4D2
		// (set) Token: 0x06039B8C RID: 236428 RVA: 0x00EA02DA File Offset: 0x00E9E4DA
		public int InstanceId { get; set; }

		// Token: 0x1700937C RID: 37756
		// (get) Token: 0x06039B8D RID: 236429 RVA: 0x00EA02E3 File Offset: 0x00E9E4E3
		// (set) Token: 0x06039B8E RID: 236430 RVA: 0x00EA02EB File Offset: 0x00E9E4EB
		public EMapType MapType { get; set; }

		// Token: 0x1700937D RID: 37757
		// (get) Token: 0x06039B8F RID: 236431 RVA: 0x00EA02F4 File Offset: 0x00E9E4F4
		// (set) Token: 0x06039B90 RID: 236432 RVA: 0x00EA02FC File Offset: 0x00E9E4FC
		public float MapDefaultScale { get; set; }

		// Token: 0x1700937E RID: 37758
		// (get) Token: 0x06039B91 RID: 236433 RVA: 0x00EA0305 File Offset: 0x00E9E505
		// (set) Token: 0x06039B92 RID: 236434 RVA: 0x00EA030D File Offset: 0x00E9E50D
		public EMapGravityDirection? Gravity { get; set; }

		// Token: 0x1700937F RID: 37759
		// (get) Token: 0x06039B93 RID: 236435 RVA: 0x00EA0316 File Offset: 0x00E9E516
		// (set) Token: 0x06039B94 RID: 236436 RVA: 0x00EA031E File Offset: 0x00E9E51E
		public float? MarkScale { get; set; }

		// Token: 0x17009380 RID: 37760
		// (get) Token: 0x06039B95 RID: 236437 RVA: 0x00EA0327 File Offset: 0x00E9E527
		// (set) Token: 0x06039B96 RID: 236438 RVA: 0x00EA032F File Offset: 0x00E9E52F
		public float? ClickRange { get; set; }

		// Token: 0x17009381 RID: 37761
		// (get) Token: 0x06039B97 RID: 236439 RVA: 0x00EA0338 File Offset: 0x00E9E538
		// (set) Token: 0x06039B98 RID: 236440 RVA: 0x00EA0340 File Offset: 0x00E9E540
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, UTexture> PreloadTiles { [return: Nullable(new byte[]
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
