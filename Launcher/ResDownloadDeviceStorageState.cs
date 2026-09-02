using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher
{
	// Token: 0x02004488 RID: 17544
	[NullableContext(1)]
	[Nullable(0)]
	public class ResDownloadDeviceStorageState : HotPatchLogData
	{
		// Token: 0x0602E4EE RID: 189678 RVA: 0x00ADE238 File Offset: 0x00ADC438
		public ResDownloadDeviceStorageState(int downloadType, bool ifStorageAlert, int requiredSpace, int remainingSpace, string uniqueId, string traceId, int chooseByUser, [Nullable(2)] string playerId = null) : base("1702", uniqueId, playerId)
		{
			this.i_download_type = downloadType;
			this.b_if_storage_alert = ifStorageAlert;
			if (ifStorageAlert)
			{
				this.i_required_space = requiredSpace;
				this.i_remaining_space = remainingSpace;
			}
			else
			{
				this.i_required_space = 0;
				this.i_remaining_space = 0;
			}
			this.s_trace_id = traceId;
			this.i_type = chooseByUser;
		}

		// Token: 0x0401A490 RID: 107664
		public int i_download_type;

		// Token: 0x0401A491 RID: 107665
		public bool b_if_storage_alert;

		// Token: 0x0401A492 RID: 107666
		public int i_required_space;

		// Token: 0x0401A493 RID: 107667
		public int i_remaining_space;

		// Token: 0x0401A494 RID: 107668
		public string s_trace_id = "";

		// Token: 0x0401A495 RID: 107669
		public int i_type;
	}
}
