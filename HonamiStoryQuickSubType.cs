using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001EDE RID: 7902
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryQuickSubType : IHonamiStoryQuickSubType
{
	// Token: 0x1700120C RID: 4620
	// (get) Token: 0x0600EA27 RID: 59943 RVA: 0x003F753E File Offset: 0x003F573E
	// (set) Token: 0x0600EA28 RID: 59944 RVA: 0x003F7546 File Offset: 0x003F5746
	public int SubType { get; set; }

	// Token: 0x1700120D RID: 4621
	// (get) Token: 0x0600EA29 RID: 59945 RVA: 0x003F754F File Offset: 0x003F574F
	// (set) Token: 0x0600EA2A RID: 59946 RVA: 0x003F7557 File Offset: 0x003F5757
	public List<HonamiStoryEquipItemData> ItemList { get; set; } = new List<HonamiStoryEquipItemData>();
}
