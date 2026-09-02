using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D76 RID: 28022
	public class LevelConditionCheckDangoAbyssHasItemByType : LevelConditionBase
	{
		// Token: 0x06044533 RID: 279859 RVA: 0x011C0D70 File Offset: 0x011BEF70
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("Type");
			int slotType;
			return limitParams != null && int.TryParse(limitParams, out slotType) && ModelBase<DangoAbyssModel>.Instance.GetPluginItemListByType((DangoAbyssDefine.ESlotType)slotType).Length != 0;
		}
	}
}
