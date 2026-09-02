using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046C4 RID: 18116
	[NullableContext(1)]
	[Nullable(0)]
	public class BuffDamageContext : BaseContext, IExpressionContext
	{
		// Token: 0x17008103 RID: 33027
		// (get) Token: 0x0602F1E7 RID: 192999 RVA: 0x00B2A451 File Offset: 0x00B28651
		// (set) Token: 0x0602F1E8 RID: 193000 RVA: 0x00B2A459 File Offset: 0x00B28659
		public EContextType ContextType { get; set; }

		// Token: 0x0401AD75 RID: 109941
		public IBuffDamageParam DamageParam;

		// Token: 0x0401AD76 RID: 109942
		public Partial_RequirementPayload Payload;

		// Token: 0x0401AD77 RID: 109943
		public long ContextId;

		// Token: 0x0401AD78 RID: 109944
		public BaseDamageComponent Victim;
	}
}
