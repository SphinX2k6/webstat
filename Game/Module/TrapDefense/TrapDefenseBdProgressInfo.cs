using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DE0 RID: 19936
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBdProgressInfo : ITrapDefenseBdProgressInfo
	{
		// Token: 0x17008874 RID: 34932
		// (get) Token: 0x0603394C RID: 211276 RVA: 0x00CE48DD File Offset: 0x00CE2ADD
		// (set) Token: 0x0603394D RID: 211277 RVA: 0x00CE48E5 File Offset: 0x00CE2AE5
		public TrapDefenseBdData BdData { get; set; }

		// Token: 0x17008875 RID: 34933
		// (get) Token: 0x0603394E RID: 211278 RVA: 0x00CE48EE File Offset: 0x00CE2AEE
		// (set) Token: 0x0603394F RID: 211279 RVA: 0x00CE48F6 File Offset: 0x00CE2AF6
		public bool IsActive { get; set; }

		// Token: 0x17008876 RID: 34934
		// (get) Token: 0x06033950 RID: 211280 RVA: 0x00CE48FF File Offset: 0x00CE2AFF
		// (set) Token: 0x06033951 RID: 211281 RVA: 0x00CE4907 File Offset: 0x00CE2B07
		public bool IsShowQualityArrow { get; set; }

		// Token: 0x17008877 RID: 34935
		// (get) Token: 0x06033952 RID: 211282 RVA: 0x00CE4910 File Offset: 0x00CE2B10
		// (set) Token: 0x06033953 RID: 211283 RVA: 0x00CE4918 File Offset: 0x00CE2B18
		public ETrapDefenseResKey QualityArrowRes { get; set; }
	}
}
