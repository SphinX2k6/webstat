using System;
using System.Runtime.CompilerServices;

// Token: 0x02002C29 RID: 11305
[NullableContext(2)]
[Nullable(0)]
public class TutorialItemData
{
	// Token: 0x0400AE94 RID: 44692
	public bool IsTypeTitle;

	// Token: 0x0400AE95 RID: 44693
	public string TextId;

	// Token: 0x0400AE96 RID: 44694
	public string Text;

	// Token: 0x0400AE97 RID: 44695
	public TutorialSaveData SavedData;

	// Token: 0x0400AE98 RID: 44696
	public bool? Selected = new bool?(false);

	// Token: 0x0400AE99 RID: 44697
	public ETutorialType? OwnerType;
}
