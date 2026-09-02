using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B76 RID: 7030
[NullableContext(2)]
public interface IMapExploreStoryItemData
{
	// Token: 0x1700106F RID: 4207
	// (get) Token: 0x0600CC2D RID: 52269
	// (set) Token: 0x0600CC2E RID: 52270
	bool IsOpen { get; set; }

	// Token: 0x17001070 RID: 4208
	// (get) Token: 0x0600CC2F RID: 52271
	// (set) Token: 0x0600CC30 RID: 52272
	string StoryContent { get; set; }

	// Token: 0x17001071 RID: 4209
	// (get) Token: 0x0600CC31 RID: 52273
	// (set) Token: 0x0600CC32 RID: 52274
	string StoryTitle { get; set; }

	// Token: 0x17001072 RID: 4210
	// (get) Token: 0x0600CC33 RID: 52275
	// (set) Token: 0x0600CC34 RID: 52276
	string LockedDesc { get; set; }

	// Token: 0x17001073 RID: 4211
	// (get) Token: 0x0600CC35 RID: 52277
	// (set) Token: 0x0600CC36 RID: 52278
	bool? IsNewOpen { get; set; }
}
