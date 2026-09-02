using System;
using System.Runtime.CompilerServices;

// Token: 0x0200181E RID: 6174
[NullableContext(2)]
[Nullable(0)]
public class VisionRefineRefineTabData
{
	// Token: 0x04005357 RID: 21335
	public bool IsChosen;

	// Token: 0x04005358 RID: 21336
	public EVisionRefineRefineType RefineType;

	// Token: 0x04005359 RID: 21337
	public string TabTextId;

	// Token: 0x0400535A RID: 21338
	public Action OnClick;

	// Token: 0x0400535B RID: 21339
	public Func<EVisionRefineRefineType, bool> CanChangeExecute;
}
