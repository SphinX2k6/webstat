using System;
using System.Runtime.CompilerServices;

// Token: 0x020000A4 RID: 164
[NullableContext(1)]
public interface IEventArgs
{
	// Token: 0x0600044B RID: 1099
	bool Invoke(Enum name, Delegate handle);

	// Token: 0x0600044C RID: 1100
	bool Invoke(long name, Delegate handle);
}
