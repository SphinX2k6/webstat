using System;
using System.Runtime.CompilerServices;

// Token: 0x02001BD8 RID: 7128
[NullableContext(1)]
public interface IFloroRanchCardOrToyData
{
	// Token: 0x170010F5 RID: 4341
	// (get) Token: 0x0600CF71 RID: 53105
	int Id { get; }

	// Token: 0x0600CF72 RID: 53106
	string GetName();

	// Token: 0x170010F6 RID: 4342
	// (get) Token: 0x0600CF73 RID: 53107
	string Name { get; }

	// Token: 0x170010F7 RID: 4343
	// (get) Token: 0x0600CF74 RID: 53108
	string Desc { get; }

	// Token: 0x0600CF75 RID: 53109
	int GetRarity();

	// Token: 0x0600CF76 RID: 53110
	string GetIcon();
}
