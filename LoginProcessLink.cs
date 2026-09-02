using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200212B RID: 8491
[NullableContext(1)]
[Nullable(0)]
public class LoginProcessLink : CommonLogData
{
	// Token: 0x17001387 RID: 4999
	// (get) Token: 0x06010383 RID: 66435 RVA: 0x004753F0 File Offset: 0x004735F0
	// (set) Token: 0x06010384 RID: 66436 RVA: 0x004753F8 File Offset: 0x004735F8
	public override string event_id { get; set; } = "18000";

	// Token: 0x04007D64 RID: 32100
	public string s_trace_id = "";

	// Token: 0x04007D65 RID: 32101
	public string s_user_id = "";

	// Token: 0x04007D66 RID: 32102
	public string s_user_name = "";

	// Token: 0x04007D67 RID: 32103
	public string s_login_step = "";

	// Token: 0x04007D68 RID: 32104
	public string s_app_version = "";

	// Token: 0x04007D69 RID: 32105
	public string s_launcher_version = "";

	// Token: 0x04007D6A RID: 32106
	public string s_resource_version = "";

	// Token: 0x04007D6B RID: 32107
	public string s_client_version = "";

	// Token: 0x04007D6C RID: 32108
	public int i_error_code;

	// Token: 0x04007D6D RID: 32109
	public string s_cpu_info = "";

	// Token: 0x04007D6E RID: 32110
	public string s_device_info = "";

	// Token: 0x04007D6F RID: 32111
	public string s_driver_date = "";

	// Token: 0x04007D70 RID: 32112
	public string s_device_id = "";

	// Token: 0x04007D71 RID: 32113
	public string s_command_line = "";

	// Token: 0x04007D72 RID: 32114
	public string s_os = "";

	// Token: 0x04007D73 RID: 32115
	public string s_os_version = "";

	// Token: 0x04007D74 RID: 32116
	public List<KuroConfigMonitorData> o_ini_info;

	// Token: 0x04007D75 RID: 32117
	public string s_selected_udp_host = "";

	// Token: 0x04007D76 RID: 32118
	public bool b_udp_host_pick_by_detection;

	// Token: 0x04007D77 RID: 32119
	public int i_connect_family;

	// Token: 0x04007D78 RID: 32120
	public int i_udp_port;

	// Token: 0x04007D79 RID: 32121
	public string s_resolved_ip = "";

	// Token: 0x04007D7A RID: 32122
	public string s_ping_results = "";
}
