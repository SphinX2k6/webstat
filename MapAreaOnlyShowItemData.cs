using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B79 RID: 7033
[NullableContext(1)]
[Nullable(0)]
public class MapAreaOnlyShowItemData : IMapAreaOnlyShowItemData
{
	// Token: 0x1700107C RID: 4220
	// (get) Token: 0x0600CC48 RID: 52296 RVA: 0x003667CD File Offset: 0x003649CD
	// (set) Token: 0x0600CC49 RID: 52297 RVA: 0x003667D5 File Offset: 0x003649D5
	public string IconPath { get; set; }

	// Token: 0x1700107D RID: 4221
	// (get) Token: 0x0600CC4A RID: 52298 RVA: 0x003667DE File Offset: 0x003649DE
	// (set) Token: 0x0600CC4B RID: 52299 RVA: 0x003667E6 File Offset: 0x003649E6
	public int OpenCount { get; set; }

	// Token: 0x1700107E RID: 4222
	// (get) Token: 0x0600CC4C RID: 52300 RVA: 0x003667EF File Offset: 0x003649EF
	// (set) Token: 0x0600CC4D RID: 52301 RVA: 0x003667F7 File Offset: 0x003649F7
	public int NewOpenCount { get; set; }
}
