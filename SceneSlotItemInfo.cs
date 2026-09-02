using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001070 RID: 4208
[NullableContext(1)]
[Nullable(0)]
public class SceneSlotItemInfo : ISceneSlotItemInfo
{
	// Token: 0x170008D1 RID: 2257
	// (get) Token: 0x06006D7F RID: 28031 RVA: 0x001C7B96 File Offset: 0x001C5D96
	// (set) Token: 0x06006D80 RID: 28032 RVA: 0x001C7B9E File Offset: 0x001C5D9E
	public int SlotEntityId { get; set; }

	// Token: 0x170008D2 RID: 2258
	// (get) Token: 0x06006D81 RID: 28033 RVA: 0x001C7BA7 File Offset: 0x001C5DA7
	// (set) Token: 0x06006D82 RID: 28034 RVA: 0x001C7BAF File Offset: 0x001C5DAF
	[Nullable(2)]
	public FurnitureSceneItemBase RootFurnitureSceneItem { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170008D3 RID: 2259
	// (get) Token: 0x06006D83 RID: 28035 RVA: 0x001C7BB8 File Offset: 0x001C5DB8
	// (set) Token: 0x06006D84 RID: 28036 RVA: 0x001C7BC0 File Offset: 0x001C5DC0
	public Dictionary<int, FurnitureSceneItemBase> SubFurnitureSceneItemMap { get; set; } = new Dictionary<int, FurnitureSceneItemBase>();
}
