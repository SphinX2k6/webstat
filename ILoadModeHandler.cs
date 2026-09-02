using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000BD2 RID: 3026
[NullableContext(1)]
public interface ILoadModeHandler
{
	// Token: 0x060031B9 RID: 12729
	void EnterMode(UObject worldContext);

	// Token: 0x060031BA RID: 12730
	void ExitMode(UObject worldContext);
}
