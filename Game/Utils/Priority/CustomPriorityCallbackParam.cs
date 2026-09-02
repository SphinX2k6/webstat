using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Priority
{
	// Token: 0x02004704 RID: 18180
	[RequiredMember]
	public class CustomPriorityCallbackParam : ICustomPriorityCallbackParam
	{
		// Token: 0x17008162 RID: 33122
		// (get) Token: 0x0602F428 RID: 193576 RVA: 0x00B3500B File Offset: 0x00B3320B
		// (set) Token: 0x0602F429 RID: 193577 RVA: 0x00B35013 File Offset: 0x00B33213
		public bool? IsReentrant { get; set; }

		// Token: 0x17008163 RID: 33123
		// (get) Token: 0x0602F42A RID: 193578 RVA: 0x00B3501C File Offset: 0x00B3321C
		// (set) Token: 0x0602F42B RID: 193579 RVA: 0x00B35024 File Offset: 0x00B33224
		[RequiredMember]
		public bool IsForce { get; set; }

		// Token: 0x0602F42C RID: 193580 RVA: 0x00B3502D File Offset: 0x00B3322D
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CustomPriorityCallbackParam()
		{
		}
	}
}
