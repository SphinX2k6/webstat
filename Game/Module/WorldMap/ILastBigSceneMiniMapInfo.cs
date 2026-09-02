using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B2E RID: 19246
	[NullableContext(1)]
	public interface ILastBigSceneMiniMapInfo
	{
		// Token: 0x17008600 RID: 34304
		// (get) Token: 0x0603238D RID: 205709
		// (set) Token: 0x0603238E RID: 205710
		int InstanceDungeonId { get; set; }

		// Token: 0x17008601 RID: 34305
		// (get) Token: 0x0603238F RID: 205711
		// (set) Token: 0x06032390 RID: 205712
		Vector Position { get; set; }
	}
}
