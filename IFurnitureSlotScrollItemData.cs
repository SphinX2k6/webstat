using System;

// Token: 0x0200103E RID: 4158
public interface IFurnitureSlotScrollItemData
{
	// Token: 0x17000852 RID: 2130
	// (get) Token: 0x06006C4E RID: 27726
	int SceneSlotEntityId { get; }

	// Token: 0x17000853 RID: 2131
	// (get) Token: 0x06006C4F RID: 27727
	int PlacedFurnitureId { get; }

	// Token: 0x17000854 RID: 2132
	// (get) Token: 0x06006C50 RID: 27728
	int SubSlotIndex { get; }

	// Token: 0x17000855 RID: 2133
	// (get) Token: 0x06006C51 RID: 27729
	EFurnitureSlotType SlotType { get; }

	// Token: 0x17000856 RID: 2134
	// (get) Token: 0x06006C52 RID: 27730
	int TagId { get; }

	// Token: 0x17000857 RID: 2135
	// (get) Token: 0x06006C53 RID: 27731
	int TagIndex { get; }

	// Token: 0x17000858 RID: 2136
	// (get) Token: 0x06006C54 RID: 27732
	bool ShowTagIndex { get; }

	// Token: 0x17000859 RID: 2137
	// (get) Token: 0x06006C55 RID: 27733
	bool IsSelected { get; }

	// Token: 0x1700085A RID: 2138
	// (get) Token: 0x06006C56 RID: 27734
	bool LineShowState { get; }

	// Token: 0x1700085B RID: 2139
	// (get) Token: 0x06006C57 RID: 27735
	bool RedDotShowState { get; }
}
