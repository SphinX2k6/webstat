using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Comic
{
	// Token: 0x02005E8A RID: 24202
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class ComicPanelOpenParam : IComicPanelOpenParam
	{
		// Token: 0x17009970 RID: 39280
		// (get) Token: 0x0603CDBC RID: 249276 RVA: 0x00F7264D File Offset: 0x00F7084D
		// (set) Token: 0x0603CDBD RID: 249277 RVA: 0x00F72655 File Offset: 0x00F70855
		public int ComicConfigId { get; set; }

		// Token: 0x17009971 RID: 39281
		// (get) Token: 0x0603CDBE RID: 249278 RVA: 0x00F7265E File Offset: 0x00F7085E
		// (set) Token: 0x0603CDBF RID: 249279 RVA: 0x00F72666 File Offset: 0x00F70866
		[RequiredMember]
		public Action OnSkip { get; set; }

		// Token: 0x17009972 RID: 39282
		// (get) Token: 0x0603CDC0 RID: 249280 RVA: 0x00F7266F File Offset: 0x00F7086F
		// (set) Token: 0x0603CDC1 RID: 249281 RVA: 0x00F72677 File Offset: 0x00F70877
		[RequiredMember]
		public Action OnComplete { get; set; }

		// Token: 0x0603CDC2 RID: 249282 RVA: 0x00F72680 File Offset: 0x00F70880
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public ComicPanelOpenParam()
		{
		}
	}
}
