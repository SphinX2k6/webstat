using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046C5 RID: 18117
	[NullableContext(1)]
	[Nullable(0)]
	public class BuffShareDamageContext : BaseContext, IExpressionContext
	{
		// Token: 0x17008104 RID: 33028
		// (get) Token: 0x0602F1EA RID: 193002 RVA: 0x00B2A46A File Offset: 0x00B2866A
		// (set) Token: 0x0602F1EB RID: 193003 RVA: 0x00B2A472 File Offset: 0x00B28672
		public EContextType ContextType { get; set; }

		// Token: 0x0401AD7A RID: 109946
		public IBuffDamageParam DamageParam;

		// Token: 0x0401AD7B RID: 109947
		public Partial_RequirementPayload Payload;

		// Token: 0x0401AD7C RID: 109948
		public float ExtraRate;

		// Token: 0x0401AD7D RID: 109949
		public long ContextId;

		// Token: 0x0401AD7E RID: 109950
		public BaseDamageComponent Victim;
	}
}
