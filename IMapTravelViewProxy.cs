using System;
using System.Runtime.CompilerServices;

// Token: 0x02001385 RID: 4997
[NullableContext(1)]
public interface IMapTravelViewProxy
{
	// Token: 0x17000B9F RID: 2975
	// (get) Token: 0x06008951 RID: 35153
	// (set) Token: 0x06008952 RID: 35154
	IMapTravelSubViewInterface UiProxy { get; set; }

	// Token: 0x17000BA0 RID: 2976
	// (get) Token: 0x06008953 RID: 35155
	// (set) Token: 0x06008954 RID: 35156
	EMapTravelSubType Type { get; set; }

	// Token: 0x17000BA1 RID: 2977
	// (get) Token: 0x06008955 RID: 35157
	// (set) Token: 0x06008956 RID: 35158
	string SpineSkinName { get; set; }
}
