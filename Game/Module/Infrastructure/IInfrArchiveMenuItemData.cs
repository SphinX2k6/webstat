using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C50 RID: 23632
	[NullableContext(1)]
	[Nullable(0)]
	public class IInfrArchiveMenuItemData
	{
		// Token: 0x170097E2 RID: 38882
		// (get) Token: 0x0603BB52 RID: 244562 RVA: 0x00F1FFA4 File Offset: 0x00F1E1A4
		// (set) Token: 0x0603BB53 RID: 244563 RVA: 0x00F1FFAC File Offset: 0x00F1E1AC
		public InfrastructureDefine.EInfrArchiveTabType CardType { get; set; }

		// Token: 0x170097E3 RID: 38883
		// (get) Token: 0x0603BB54 RID: 244564 RVA: 0x00F1FFB5 File Offset: 0x00F1E1B5
		// (set) Token: 0x0603BB55 RID: 244565 RVA: 0x00F1FFBD File Offset: 0x00F1E1BD
		public string DesText { get; set; }
	}
}
