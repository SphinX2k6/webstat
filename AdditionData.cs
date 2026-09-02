using System;
using System.Runtime.CompilerServices;

// Token: 0x020013AA RID: 5034
[NullableContext(1)]
[Nullable(0)]
public class AdditionData : IAdditionData
{
	// Token: 0x17000BC7 RID: 3015
	// (get) Token: 0x06008AB4 RID: 35508 RVA: 0x00248884 File Offset: 0x00246A84
	public string TextId { get; }

	// Token: 0x17000BC8 RID: 3016
	// (get) Token: 0x06008AB5 RID: 35509 RVA: 0x0024888C File Offset: 0x00246A8C
	public string ValueText { get; }

	// Token: 0x06008AB6 RID: 35510 RVA: 0x00248894 File Offset: 0x00246A94
	public AdditionData(string textId, string valueText)
	{
		this.TextId = textId;
		this.ValueText = valueText;
	}
}
