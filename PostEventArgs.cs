using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000031 RID: 49
[NullableContext(2)]
[Nullable(0)]
public struct PostEventArgs
{
	// Token: 0x040000AD RID: 173
	public ECallbackMask? CallbackMask;

	// Token: 0x040000AE RID: 174
	public Action<EAkCallbackType, UAkCallbackInfo> CallbackHandler;

	// Token: 0x040000AF RID: 175
	public string ExternalSourceName;

	// Token: 0x040000B0 RID: 176
	public string ExternalSourceMediaName;

	// Token: 0x040000B1 RID: 177
	public bool? StopWhenOwnerDestroyed;
}
