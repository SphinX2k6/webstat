using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher
{
	// Token: 0x02004487 RID: 17543
	[NullableContext(1)]
	[Nullable(0)]
	public class InitialResDownloadStateLog : HotPatchLogData
	{
		// Token: 0x0602E4ED RID: 189677 RVA: 0x00ADE1DC File Offset: 0x00ADC3DC
		public InitialResDownloadStateLog(int downloadType, int downloadTime, int downloadStatus, string uniqueId, string traceId, int chooseByUser, int remainingSpace, int requiredSpace, [Nullable(2)] string playerId = null) : base("1700", uniqueId, playerId)
		{
			this.i_download_type = downloadType;
			this.i_download_time = downloadTime;
			this.i_download_status = downloadStatus;
			this.s_trace_id = traceId;
			this.i_type = chooseByUser;
			this.i_remaining_space = remainingSpace;
			this.i_required_space = requiredSpace;
		}

		// Token: 0x0401A489 RID: 107657
		public int i_download_type;

		// Token: 0x0401A48A RID: 107658
		public int i_download_time;

		// Token: 0x0401A48B RID: 107659
		public int i_download_status;

		// Token: 0x0401A48C RID: 107660
		public string s_trace_id = "";

		// Token: 0x0401A48D RID: 107661
		public int i_type;

		// Token: 0x0401A48E RID: 107662
		public int i_remaining_space;

		// Token: 0x0401A48F RID: 107663
		public int i_required_space;
	}
}
