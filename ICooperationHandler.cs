using System;
using System.Runtime.CompilerServices;

// Token: 0x020017AE RID: 6062
[NullableContext(1)]
public interface ICooperationHandler
{
	// Token: 0x0600AB1C RID: 43804
	bool Trigger(SceneTeamItem goDownRole, SceneTeamItem goBattleRole);

	// Token: 0x0600AB1D RID: 43805
	void Clear();
}
