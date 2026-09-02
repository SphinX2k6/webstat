using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B77 RID: 7031
[NullableContext(2)]
[Nullable(0)]
public class MapExploreStoryItemData : IMapExploreStoryItemData
{
	// Token: 0x17001074 RID: 4212
	// (get) Token: 0x0600CC37 RID: 52279 RVA: 0x00366770 File Offset: 0x00364970
	// (set) Token: 0x0600CC38 RID: 52280 RVA: 0x00366778 File Offset: 0x00364978
	public bool IsOpen { get; set; }

	// Token: 0x17001075 RID: 4213
	// (get) Token: 0x0600CC39 RID: 52281 RVA: 0x00366781 File Offset: 0x00364981
	// (set) Token: 0x0600CC3A RID: 52282 RVA: 0x00366789 File Offset: 0x00364989
	public string StoryContent { get; set; }

	// Token: 0x17001076 RID: 4214
	// (get) Token: 0x0600CC3B RID: 52283 RVA: 0x00366792 File Offset: 0x00364992
	// (set) Token: 0x0600CC3C RID: 52284 RVA: 0x0036679A File Offset: 0x0036499A
	public string StoryTitle { get; set; }

	// Token: 0x17001077 RID: 4215
	// (get) Token: 0x0600CC3D RID: 52285 RVA: 0x003667A3 File Offset: 0x003649A3
	// (set) Token: 0x0600CC3E RID: 52286 RVA: 0x003667AB File Offset: 0x003649AB
	public string LockedDesc { get; set; }

	// Token: 0x17001078 RID: 4216
	// (get) Token: 0x0600CC3F RID: 52287 RVA: 0x003667B4 File Offset: 0x003649B4
	// (set) Token: 0x0600CC40 RID: 52288 RVA: 0x003667BC File Offset: 0x003649BC
	public bool? IsNewOpen { get; set; }
}
