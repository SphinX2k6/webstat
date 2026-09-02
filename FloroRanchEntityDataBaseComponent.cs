using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BE2 RID: 7138
[NullableContext(1)]
[Nullable(0)]
public abstract class FloroRanchEntityDataBaseComponent : FloroRanchEntityComponentBase
{
	// Token: 0x0600CFA1 RID: 53153
	public abstract void RefreshEntityData(FloroRanchPlayUnit entityData);

	// Token: 0x0600CFA2 RID: 53154
	public abstract string Info();

	// Token: 0x0600CFA3 RID: 53155
	public abstract string DebugInfo();
}
