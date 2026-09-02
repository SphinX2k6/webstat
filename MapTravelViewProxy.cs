using System;
using System.Runtime.CompilerServices;

// Token: 0x02001386 RID: 4998
[NullableContext(1)]
[Nullable(0)]
public class MapTravelViewProxy : IMapTravelViewProxy
{
	// Token: 0x17000BA2 RID: 2978
	// (get) Token: 0x06008957 RID: 35159 RVA: 0x00242DC3 File Offset: 0x00240FC3
	// (set) Token: 0x06008958 RID: 35160 RVA: 0x00242DCB File Offset: 0x00240FCB
	public IMapTravelSubViewInterface UiProxy { get; set; }

	// Token: 0x17000BA3 RID: 2979
	// (get) Token: 0x06008959 RID: 35161 RVA: 0x00242DD4 File Offset: 0x00240FD4
	// (set) Token: 0x0600895A RID: 35162 RVA: 0x00242DDC File Offset: 0x00240FDC
	public EMapTravelSubType Type { get; set; }

	// Token: 0x17000BA4 RID: 2980
	// (get) Token: 0x0600895B RID: 35163 RVA: 0x00242DE5 File Offset: 0x00240FE5
	// (set) Token: 0x0600895C RID: 35164 RVA: 0x00242DED File Offset: 0x00240FED
	public string SpineSkinName { get; set; }
}
