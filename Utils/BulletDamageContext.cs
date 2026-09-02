using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046C3 RID: 18115
	[NullableContext(1)]
	[Nullable(0)]
	public class BulletDamageContext : BaseContext, IExpressionContext
	{
		// Token: 0x17008102 RID: 33026
		// (get) Token: 0x0602F1E4 RID: 192996 RVA: 0x00B2A438 File Offset: 0x00B28638
		// (set) Token: 0x0602F1E5 RID: 192997 RVA: 0x00B2A440 File Offset: 0x00B28640
		public EContextType ContextType { get; set; }

		// Token: 0x0401AD6F RID: 109935
		public IBulletDamageParam DamageParam;

		// Token: 0x0401AD70 RID: 109936
		public int BulletEntityId;

		// Token: 0x0401AD71 RID: 109937
		public long ContextId;

		// Token: 0x0401AD72 RID: 109938
		public BulletDamageResult Result;

		// Token: 0x0401AD73 RID: 109939
		public BaseDamageComponent Victim;
	}
}
