using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.LevelLoading
{
	// Token: 0x02005A13 RID: 23059
	[NullableContext(1)]
	[Nullable(0)]
	public class PendingProcess<[Nullable(2)] T>
	{
		// Token: 0x0603A633 RID: 239155 RVA: 0x00ECDE68 File Offset: 0x00ECC068
		public PendingProcess(T processType)
		{
			this.ProcessId = ++PendingProcessDefine.Id;
			this.ProcessType = processType;
		}

		// Token: 0x170094C9 RID: 38089
		// (get) Token: 0x0603A634 RID: 239156 RVA: 0x00ECDE8A File Offset: 0x00ECC08A
		public T ProcessType { get; }

		// Token: 0x04021104 RID: 135428
		public int ProcessId;
	}
}
