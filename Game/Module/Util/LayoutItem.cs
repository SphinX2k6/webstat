using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C65 RID: 19557
	[NullableContext(2)]
	[Nullable(0)]
	public class LayoutItem<TLayoutItemItem> : ILayoutItem<TLayoutItemItem>
	{
		// Token: 0x17008784 RID: 34692
		// (get) Token: 0x06032F73 RID: 208755 RVA: 0x00CC3E2B File Offset: 0x00CC202B
		// (set) Token: 0x06032F74 RID: 208756 RVA: 0x00CC3E33 File Offset: 0x00CC2033
		[Nullable(1)]
		public object Key { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17008785 RID: 34693
		// (get) Token: 0x06032F75 RID: 208757 RVA: 0x00CC3E3C File Offset: 0x00CC203C
		// (set) Token: 0x06032F76 RID: 208758 RVA: 0x00CC3E44 File Offset: 0x00CC2044
		public TLayoutItemItem Value { get; set; }
	}
}
