using System;
using System.Runtime.CompilerServices;

// Token: 0x02001045 RID: 4165
[NullableContext(1)]
[Nullable(0)]
public class FurniturePresetViewOpenData : IFurniturePresetViewOpenData
{
	// Token: 0x17000878 RID: 2168
	// (get) Token: 0x06006C89 RID: 27785 RVA: 0x001C5C76 File Offset: 0x001C3E76
	// (set) Token: 0x06006C8A RID: 27786 RVA: 0x001C5C7E File Offset: 0x001C3E7E
	public FurnitureAreaData AreaData { get; set; }

	// Token: 0x17000879 RID: 2169
	// (get) Token: 0x06006C8B RID: 27787 RVA: 0x001C5C87 File Offset: 0x001C3E87
	// (set) Token: 0x06006C8C RID: 27788 RVA: 0x001C5C8F File Offset: 0x001C3E8F
	public Action<FurnitureAreaData> OnApplyDelegate { get; set; }
}
