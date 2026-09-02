using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001EDD RID: 7901
[NullableContext(1)]
public interface IHonamiStoryQuickSubType
{
	// Token: 0x1700120A RID: 4618
	// (get) Token: 0x0600EA23 RID: 59939
	// (set) Token: 0x0600EA24 RID: 59940
	int SubType { get; set; }

	// Token: 0x1700120B RID: 4619
	// (get) Token: 0x0600EA25 RID: 59941
	// (set) Token: 0x0600EA26 RID: 59942
	List<HonamiStoryEquipItemData> ItemList { get; set; }
}
