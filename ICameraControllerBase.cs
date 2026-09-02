using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000E09 RID: 3593
[NullableContext(1)]
public interface ICameraControllerBase
{
	// Token: 0x06005487 RID: 21639
	void OnStart();

	// Token: 0x06005488 RID: 21640
	void OnEnd();

	// Token: 0x06005489 RID: 21641
	void Update(float deltaTime);

	// Token: 0x0600548A RID: 21642
	string Name();

	// Token: 0x0600548B RID: 21643
	[return: Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})]
	IEnumerable<ValueTuple<string, object>> MemberIter();
}
