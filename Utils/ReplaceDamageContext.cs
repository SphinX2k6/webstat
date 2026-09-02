using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046C6 RID: 18118
	public class ReplaceDamageContext : BaseContext, IExpressionContext
	{
		// Token: 0x17008105 RID: 33029
		// (get) Token: 0x0602F1ED RID: 193005 RVA: 0x00B2A483 File Offset: 0x00B28683
		// (set) Token: 0x0602F1EE RID: 193006 RVA: 0x00B2A48B File Offset: 0x00B2868B
		public EContextType ContextType { get; set; }

		// Token: 0x0401AD80 RID: 109952
		[Nullable(1)]
		public Action<long> DamageCb;
	}
}
