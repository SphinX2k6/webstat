using System;
using System.Runtime.CompilerServices;

// Token: 0x02001284 RID: 4740
[NullableContext(1)]
public interface IChessAgent
{
	// Token: 0x06007EEF RID: 32495
	void Move(Vector location, Rotator rotator, bool performIsForward, Action finishCallback);

	// Token: 0x06007EF0 RID: 32496
	void Teleport(Vector location, Rotator rotator);

	// Token: 0x06007EF1 RID: 32497
	void Perform(int type, [Nullable(2)] Vector pointLocation, Action finishCallback);

	// Token: 0x06007EF2 RID: 32498
	[NullableContext(2)]
	Vector GetLocation();
}
