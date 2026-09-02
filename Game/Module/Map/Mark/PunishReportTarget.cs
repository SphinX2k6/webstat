using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.Mark
{
	// Token: 0x02005815 RID: 22549
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class PunishReportTarget
	{
		// Token: 0x0603959B RID: 234907 RVA: 0x00E8E343 File Offset: 0x00E8C543
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public PunishReportTarget()
		{
		}

		// Token: 0x04020994 RID: 133524
		[RequiredMember]
		public List<EPunishReportTargetState> States;

		// Token: 0x04020995 RID: 133525
		[RequiredMember]
		public List<string> ConditionTxtIds;

		// Token: 0x04020996 RID: 133526
		[RequiredMember]
		public long GetBoxNum;
	}
}
