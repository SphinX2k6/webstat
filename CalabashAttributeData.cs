using System;
using System.Runtime.CompilerServices;

// Token: 0x020017F9 RID: 6137
[NullableContext(2)]
[Nullable(0)]
internal class CalabashAttributeData
{
	// Token: 0x040052A8 RID: 21160
	public ECalabashAttributeDataType Type = ECalabashAttributeDataType.Default;

	// Token: 0x040052A9 RID: 21161
	public string Name;

	// Token: 0x040052AA RID: 21162
	public TableTextArgNew Value;

	// Token: 0x040052AB RID: 21163
	public bool IsUp;

	// Token: 0x040052AC RID: 21164
	public bool IsCost;

	// Token: 0x040052AD RID: 21165
	public int CostCount;

	// Token: 0x040052AE RID: 21166
	public bool CurrentSelect;

	// Token: 0x040052AF RID: 21167
	public int CurrentSelectLevel;

	// Token: 0x040052B0 RID: 21168
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<CalabashAttributeData> ClickCallBack;

	// Token: 0x040052B1 RID: 21169
	public bool IsToggleRaycast;
}
