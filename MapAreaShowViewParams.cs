using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B93 RID: 7059
[RequiredMember]
public class MapAreaShowViewParams
{
	// Token: 0x0600CD37 RID: 52535 RVA: 0x00369F93 File Offset: 0x00368193
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public MapAreaShowViewParams()
	{
	}

	// Token: 0x0400620E RID: 25102
	public int? CountryId;

	// Token: 0x0400620F RID: 25103
	public int? AreaId;

	// Token: 0x04006210 RID: 25104
	[Nullable(1)]
	[RequiredMember]
	public Action<int> OnClickArea;
}
