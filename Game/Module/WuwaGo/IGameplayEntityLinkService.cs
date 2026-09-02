using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004A9E RID: 19102
	[NullableContext(1)]
	public interface IGameplayEntityLinkService
	{
		// Token: 0x06031D0C RID: 204044
		IReadOnlyList<int> GetLinkedGroupPbDataIds(int sourcePbDataId);

		// Token: 0x06031D0D RID: 204045
		int GetLinkedGroupRootPbDataId(int sourcePbDataId);

		// Token: 0x06031D0E RID: 204046
		IReadOnlyList<ActionInfo> FilterLinkedActionList(int sourcePbDataId, IReadOnlyList<ActionInfo> actionList);

		// Token: 0x06031D0F RID: 204047
		void SyncLinkedEntityState(int sourcePbDataId, EGameplayEntityState targetState);

		// Token: 0x06031D10 RID: 204048
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		ValueTuple<bool, IReadOnlyList<ActionInfo>>? ConsumePressureTriggerGroupChange(int sourcePbDataId);

		// Token: 0x06031D11 RID: 204049
		void OnRollbackRestore();
	}
}
