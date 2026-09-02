using System;
using System.Runtime.CompilerServices;

// Token: 0x02002861 RID: 10337
[NullableContext(1)]
public interface IRoleLangCustomInfo
{
	// Token: 0x17001AB8 RID: 6840
	// (get) Token: 0x060147CD RID: 83917
	// (set) Token: 0x060147CE RID: 83918
	int RoleId { get; set; }

	// Token: 0x17001AB9 RID: 6841
	// (get) Token: 0x060147CF RID: 83919
	// (set) Token: 0x060147D0 RID: 83920
	int LangIndex { get; set; }

	// Token: 0x17001ABA RID: 6842
	// (get) Token: 0x060147D1 RID: 83921
	// (set) Token: 0x060147D2 RID: 83922
	string LangCode { get; set; }
}
