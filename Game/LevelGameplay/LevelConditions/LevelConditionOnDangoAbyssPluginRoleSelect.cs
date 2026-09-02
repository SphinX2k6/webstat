using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D74 RID: 28020
	public class LevelConditionOnDangoAbyssPluginRoleSelect : LevelConditionBase
	{
		// Token: 0x0604452F RID: 279855 RVA: 0x011C0D10 File Offset: 0x011BEF10
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int num = (int)eventArgs[0];
			string limitParams = inConditionInfo.GetLimitParams("Index");
			int slotIndex;
			return limitParams != null && int.TryParse(limitParams, out slotIndex) && num != 0 && !ModelBase<DangoAbyssModel>.Instance.GetSlotLockState(num, slotIndex);
		}
	}
}
