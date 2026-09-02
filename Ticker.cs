using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000BE7 RID: 3047
[NullableContext(1)]
[Nullable(0)]
public class Ticker
{
	// Token: 0x06003241 RID: 12865 RVA: 0x00021D5C File Offset: 0x0001FF5C
	public Ticker(int id, Action<float> handle, ETickingGroup group, int priority, string name, int tickIntervalMs = 0, bool tickEvenPaused = false, bool ignoreSelfCenterMode = false)
	{
		this.Id = id;
		this.Handle = handle;
		this.Group = group;
		this.Priority = priority;
		this.Name = name;
		this.TickIntervalMs = tickIntervalMs;
		this.TickEvenPaused = tickEvenPaused;
		this.IgnoreSelfCenterMode = ignoreSelfCenterMode;
		this.StatObj = Stat.CreateNoFlameGraph("In TickSystem." + this.Name, "", "");
	}

	// Token: 0x04000518 RID: 1304
	public int Count;

	// Token: 0x04000519 RID: 1305
	public float CoolDown;

	// Token: 0x0400051A RID: 1306
	public bool Pause;

	// Token: 0x0400051B RID: 1307
	[Nullable(2)]
	public readonly Stat StatObj;

	// Token: 0x0400051C RID: 1308
	public readonly int Id;

	// Token: 0x0400051D RID: 1309
	public readonly Action<float> Handle;

	// Token: 0x0400051E RID: 1310
	public readonly ETickingGroup Group;

	// Token: 0x0400051F RID: 1311
	public readonly int Priority;

	// Token: 0x04000520 RID: 1312
	public readonly string Name;

	// Token: 0x04000521 RID: 1313
	public int TickIntervalMs;

	// Token: 0x04000522 RID: 1314
	public bool TickEvenPaused;

	// Token: 0x04000523 RID: 1315
	public bool IgnoreSelfCenterMode;

	// Token: 0x04000524 RID: 1316
	public bool PendingRemove;
}
