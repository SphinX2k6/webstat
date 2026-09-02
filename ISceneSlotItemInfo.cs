using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200106F RID: 4207
[NullableContext(1)]
public interface ISceneSlotItemInfo
{
	// Token: 0x170008CE RID: 2254
	// (get) Token: 0x06006D79 RID: 28025
	// (set) Token: 0x06006D7A RID: 28026
	int SlotEntityId { get; set; }

	// Token: 0x170008CF RID: 2255
	// (get) Token: 0x06006D7B RID: 28027
	// (set) Token: 0x06006D7C RID: 28028
	[Nullable(2)]
	FurnitureSceneItemBase RootFurnitureSceneItem { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170008D0 RID: 2256
	// (get) Token: 0x06006D7D RID: 28029
	// (set) Token: 0x06006D7E RID: 28030
	Dictionary<int, FurnitureSceneItemBase> SubFurnitureSceneItemMap { get; set; }
}
