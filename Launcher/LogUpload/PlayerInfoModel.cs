using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045F3 RID: 17907
	[NullableContext(1)]
	[Nullable(0)]
	public class PlayerInfoModel : IPlayerInfoModel
	{
		// Token: 0x17008092 RID: 32914
		// (get) Token: 0x0602EDC4 RID: 191940 RVA: 0x00B18EFB File Offset: 0x00B170FB
		// (set) Token: 0x0602EDC5 RID: 191941 RVA: 0x00B18F03 File Offset: 0x00B17103
		public Func<int?> GetId { get; set; }
	}
}
