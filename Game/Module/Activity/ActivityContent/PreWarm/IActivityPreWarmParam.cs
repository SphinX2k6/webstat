using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PreWarm
{
	// Token: 0x02006580 RID: 25984
	public class IActivityPreWarmParam
	{
		// Token: 0x17009EA1 RID: 40609
		// (get) Token: 0x06040E37 RID: 265783 RVA: 0x010A52DC File Offset: 0x010A34DC
		// (set) Token: 0x06040E38 RID: 265784 RVA: 0x010A52E4 File Offset: 0x010A34E4
		public int Id { get; set; }

		// Token: 0x17009EA2 RID: 40610
		// (get) Token: 0x06040E39 RID: 265785 RVA: 0x010A52ED File Offset: 0x010A34ED
		// (set) Token: 0x06040E3A RID: 265786 RVA: 0x010A52F5 File Offset: 0x010A34F5
		public bool IsParsing { get; set; }

		// Token: 0x17009EA3 RID: 40611
		// (get) Token: 0x06040E3B RID: 265787 RVA: 0x010A52FE File Offset: 0x010A34FE
		// (set) Token: 0x06040E3C RID: 265788 RVA: 0x010A5306 File Offset: 0x010A3506
		public int? ActivityId { get; set; }
	}
}
