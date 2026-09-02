using System;
using System.Runtime.CompilerServices;

// Token: 0x02001044 RID: 4164
[NullableContext(1)]
public interface IFurniturePresetViewOpenData
{
	// Token: 0x17000876 RID: 2166
	// (get) Token: 0x06006C87 RID: 27783
	FurnitureAreaData AreaData { get; }

	// Token: 0x17000877 RID: 2167
	// (get) Token: 0x06006C88 RID: 27784
	Action<FurnitureAreaData> OnApplyDelegate { get; }
}
