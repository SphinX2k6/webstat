using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002FFA RID: 12282
[NullableContext(1)]
public interface IDynamicConditionSwitch
{
	// Token: 0x0601907D RID: 102525
	void Init(CharacterActorComponent actor, EntityAudioConfig config);

	// Token: 0x0601907E RID: 102526
	void Do(CharacterActorComponent actor);

	// Token: 0x0601907F RID: 102527
	void Clear();
}
