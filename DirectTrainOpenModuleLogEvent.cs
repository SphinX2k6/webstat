using System;
using System.Runtime.CompilerServices;

// Token: 0x020021D6 RID: 8662
[NullableContext(1)]
[Nullable(0)]
public class DirectTrainOpenModuleLogEvent : PlayerCommonLogData
{
	// Token: 0x17001427 RID: 5159
	// (get) Token: 0x06010571 RID: 66929 RVA: 0x0047722D File Offset: 0x0047542D
	// (set) Token: 0x06010572 RID: 66930 RVA: 0x00477235 File Offset: 0x00475435
	public override string event_id { get; set; } = "1112";

	// Token: 0x040080C6 RID: 32966
	public int i_activity_id;

	// Token: 0x040080C7 RID: 32967
	public int i_id;

	// Token: 0x040080C8 RID: 32968
	public int i_quest_id;

	// Token: 0x040080C9 RID: 32969
	public int i_if_finish;

	// Token: 0x040080CA RID: 32970
	public int i_unlock;
}
