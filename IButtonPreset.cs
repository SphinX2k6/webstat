using System;
using System.Runtime.CompilerServices;

// Token: 0x020021EB RID: 8683
[NullableContext(1)]
public interface IButtonPreset
{
	// Token: 0x17001430 RID: 5168
	// (get) Token: 0x06010603 RID: 67075
	string Title { get; }

	// Token: 0x17001431 RID: 5169
	// (get) Token: 0x06010604 RID: 67076
	Action ClickFunc { get; }
}
