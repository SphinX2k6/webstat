using System;
using System.Runtime.CompilerServices;

// Token: 0x0200107D RID: 4221
[NullableContext(1)]
public interface IFurnitureAreaSelectItemData
{
	// Token: 0x170008D4 RID: 2260
	// (get) Token: 0x06006DB4 RID: 28084
	// (set) Token: 0x06006DB5 RID: 28085
	int AreaId { get; set; }

	// Token: 0x170008D5 RID: 2261
	// (get) Token: 0x06006DB6 RID: 28086
	// (set) Token: 0x06006DB7 RID: 28087
	int FloorId { get; set; }

	// Token: 0x170008D6 RID: 2262
	// (get) Token: 0x06006DB8 RID: 28088
	// (set) Token: 0x06006DB9 RID: 28089
	string AreaName { get; set; }

	// Token: 0x170008D7 RID: 2263
	// (get) Token: 0x06006DBA RID: 28090
	// (set) Token: 0x06006DBB RID: 28091
	string LockAreaIcon { get; set; }

	// Token: 0x170008D8 RID: 2264
	// (get) Token: 0x06006DBC RID: 28092
	// (set) Token: 0x06006DBD RID: 28093
	string UnlockAreaIcon { get; set; }

	// Token: 0x170008D9 RID: 2265
	// (get) Token: 0x06006DBE RID: 28094
	// (set) Token: 0x06006DBF RID: 28095
	bool IsSelected { get; set; }

	// Token: 0x170008DA RID: 2266
	// (get) Token: 0x06006DC0 RID: 28096
	// (set) Token: 0x06006DC1 RID: 28097
	bool IsUnlock { get; set; }

	// Token: 0x170008DB RID: 2267
	// (get) Token: 0x06006DC2 RID: 28098
	// (set) Token: 0x06006DC3 RID: 28099
	int PlacedSlotCount { get; set; }

	// Token: 0x170008DC RID: 2268
	// (get) Token: 0x06006DC4 RID: 28100
	// (set) Token: 0x06006DC5 RID: 28101
	int MaxSlotCount { get; set; }

	// Token: 0x170008DD RID: 2269
	// (get) Token: 0x06006DC6 RID: 28102
	// (set) Token: 0x06006DC7 RID: 28103
	bool RedDotShowState { get; set; }

	// Token: 0x170008DE RID: 2270
	// (get) Token: 0x06006DC8 RID: 28104
	// (set) Token: 0x06006DC9 RID: 28105
	Action<int> OnSelected { get; set; }
}
