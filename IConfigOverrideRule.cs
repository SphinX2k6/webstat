using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E8E RID: 11918
[NullableContext(1)]
public interface IConfigOverrideRule
{
	// Token: 0x17002105 RID: 8453
	// (get) Token: 0x06018781 RID: 100225
	// (set) Token: 0x06018782 RID: 100226
	long OverrideConfigId { get; set; }

	// Token: 0x17002106 RID: 8454
	// (get) Token: 0x06018783 RID: 100227
	// (set) Token: 0x06018784 RID: 100228
	EConfigOverrideConditionType ConditionType { get; set; }

	// Token: 0x17002107 RID: 8455
	// (get) Token: 0x06018785 RID: 100229
	// (set) Token: 0x06018786 RID: 100230
	string ConditionString { get; set; }
}
