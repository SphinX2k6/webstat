using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B2F RID: 19247
	[NullableContext(1)]
	[Nullable(0)]
	public class LastBigSceneMiniMapInfo : ILastBigSceneMiniMapInfo
	{
		// Token: 0x17008602 RID: 34306
		// (get) Token: 0x06032391 RID: 205713 RVA: 0x00C8FAD1 File Offset: 0x00C8DCD1
		// (set) Token: 0x06032392 RID: 205714 RVA: 0x00C8FAD9 File Offset: 0x00C8DCD9
		public int InstanceDungeonId { get; set; }

		// Token: 0x17008603 RID: 34307
		// (get) Token: 0x06032393 RID: 205715 RVA: 0x00C8FAE2 File Offset: 0x00C8DCE2
		// (set) Token: 0x06032394 RID: 205716 RVA: 0x00C8FAEA File Offset: 0x00C8DCEA
		public Vector Position { get; set; }
	}
}
