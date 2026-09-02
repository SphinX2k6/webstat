using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006EFD RID: 28413
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class DollDescriptionItemData : IDollDescriptionItemData
	{
		// Token: 0x1700A43C RID: 42044
		// (get) Token: 0x06044D97 RID: 282007 RVA: 0x011EA39D File Offset: 0x011E859D
		// (set) Token: 0x06044D98 RID: 282008 RVA: 0x011EA3A5 File Offset: 0x011E85A5
		[RequiredMember]
		public string IconPath { get; set; }

		// Token: 0x1700A43D RID: 42045
		// (get) Token: 0x06044D99 RID: 282009 RVA: 0x011EA3AE File Offset: 0x011E85AE
		// (set) Token: 0x06044D9A RID: 282010 RVA: 0x011EA3B6 File Offset: 0x011E85B6
		[RequiredMember]
		public string TextTitle { get; set; }

		// Token: 0x1700A43E RID: 42046
		// (get) Token: 0x06044D9B RID: 282011 RVA: 0x011EA3BF File Offset: 0x011E85BF
		// (set) Token: 0x06044D9C RID: 282012 RVA: 0x011EA3C7 File Offset: 0x011E85C7
		[RequiredMember]
		public string TextContent { get; set; }

		// Token: 0x06044D9D RID: 282013 RVA: 0x011EA3D0 File Offset: 0x011E85D0
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public DollDescriptionItemData()
		{
		}
	}
}
