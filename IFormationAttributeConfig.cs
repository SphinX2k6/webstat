using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02000FC2 RID: 4034
[NullableContext(1)]
public interface IFormationAttributeConfig
{
	// Token: 0x17000821 RID: 2081
	// (get) Token: 0x06006770 RID: 26480
	// (set) Token: 0x06006771 RID: 26481
	FormationProperty? RawConfig { get; set; }

	// Token: 0x17000822 RID: 2082
	// (get) Token: 0x06006772 RID: 26482
	// (set) Token: 0x06006773 RID: 26483
	int?[] ForbidIncreaseTags { get; set; }

	// Token: 0x17000823 RID: 2083
	// (get) Token: 0x06006774 RID: 26484
	// (set) Token: 0x06006775 RID: 26485
	int?[] ForbidDecreaseTags { get; set; }
}
