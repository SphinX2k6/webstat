using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x0200465F RID: 18015
	[NullableContext(1)]
	[Nullable(0)]
	public class HotPatchLog
	{
		// Token: 0x0401AC18 RID: 109592
		public string event_id = "2";

		// Token: 0x0401AC19 RID: 109593
		public string s_client_version = "";

		// Token: 0x0401AC1A RID: 109594
		public string event_time = "";

		// Token: 0x0401AC1B RID: 109595
		public string s_step_id = "";

		// Token: 0x0401AC1C RID: 109596
		[Nullable(2)]
		public string s_url_prefix;

		// Token: 0x0401AC1D RID: 109597
		[Nullable(2)]
		public string s_file_name;

		// Token: 0x0401AC1E RID: 109598
		[Nullable(2)]
		public string i_try_count;

		// Token: 0x0401AC1F RID: 109599
		[Nullable(2)]
		public string i_download_state;

		// Token: 0x0401AC20 RID: 109600
		[Nullable(2)]
		public string s_update_type;

		// Token: 0x0401AC21 RID: 109601
		[Nullable(2)]
		public string s_step_result;

		// Token: 0x0401AC22 RID: 109602
		public int? i_latest_time;

		// Token: 0x0401AC23 RID: 109603
		public int? i_out_date_time;

		// Token: 0x0401AC24 RID: 109604
		[Nullable(2)]
		public string s_download_speed;

		// Token: 0x0401AC25 RID: 109605
		public int? i_download_size;

		// Token: 0x0401AC26 RID: 109606
		public float? f_download_spend;

		// Token: 0x0401AC27 RID: 109607
		[Nullable(2)]
		public string device_id;

		// Token: 0x0401AC28 RID: 109608
		public string client_platform = "";

		// Token: 0x0401AC29 RID: 109609
		public string net_status = "";

		// Token: 0x0401AC2A RID: 109610
		public string s_version = "";

		// Token: 0x0401AC2B RID: 109611
		public string s_device_id = "";

		// Token: 0x0401AC2C RID: 109612
		public long? l_trigger_time;

		// Token: 0x0401AC2D RID: 109613
		public string unique_id = "";

		// Token: 0x0401AC2E RID: 109614
		public string player_id = "";
	}
}
