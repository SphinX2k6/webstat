using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E71 RID: 3697
[NullableContext(2)]
public interface IAudioInfo
{
	// Token: 0x17000658 RID: 1624
	// (get) Token: 0x060059ED RID: 23021
	// (set) Token: 0x060059EE RID: 23022
	bool Start { get; set; }

	// Token: 0x060059EF RID: 23023
	[NullableContext(1)]
	object GetCompare();

	// Token: 0x060059F0 RID: 23024
	string GetName();

	// Token: 0x060059F1 RID: 23025
	string GetAudioEvent();

	// Token: 0x060059F2 RID: 23026
	bool IsValid();

	// Token: 0x060059F3 RID: 23027
	bool IsAudioEventValid();
}
