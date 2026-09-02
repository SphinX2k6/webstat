using System;
using System.Runtime.CompilerServices;

// Token: 0x02002D5C RID: 11612
[NullableContext(1)]
[Nullable(0)]
public class WeeklyRogueRoleGroupTitleInfo : IWeeklyRogueRoleGroupTitleInfo
{
	// Token: 0x17001EDB RID: 7899
	// (get) Token: 0x06017711 RID: 96017 RVA: 0x00680123 File Offset: 0x0067E323
	// (set) Token: 0x06017712 RID: 96018 RVA: 0x0068012B File Offset: 0x0067E32B
	public string TitleId { get; set; }

	// Token: 0x17001EDC RID: 7900
	// (get) Token: 0x06017713 RID: 96019 RVA: 0x00680134 File Offset: 0x0067E334
	// (set) Token: 0x06017714 RID: 96020 RVA: 0x0068013C File Offset: 0x0067E33C
	public bool IsUp { get; set; }

	// Token: 0x17001EDD RID: 7901
	// (get) Token: 0x06017715 RID: 96021 RVA: 0x00680145 File Offset: 0x0067E345
	// (set) Token: 0x06017716 RID: 96022 RVA: 0x0068014D File Offset: 0x0067E34D
	public int? ScoreRate { get; set; }

	// Token: 0x17001EDE RID: 7902
	// (get) Token: 0x06017717 RID: 96023 RVA: 0x00680156 File Offset: 0x0067E356
	// (set) Token: 0x06017718 RID: 96024 RVA: 0x0068015E File Offset: 0x0067E35E
	public bool IsEmpty { get; set; }
}
