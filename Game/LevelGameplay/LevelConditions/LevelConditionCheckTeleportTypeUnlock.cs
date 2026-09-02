using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D5B RID: 27995
	public class LevelConditionCheckTeleportTypeUnlock : LevelConditionBase
	{
		// Token: 0x060444FC RID: 279804 RVA: 0x011BFD38 File Offset: 0x011BDF38
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
				int worldOwner = ModelBase<CreatureModel>.Instance.GetWorldOwner();
				if (!(id.GetValueOrDefault() == worldOwner & id != null))
				{
					return false;
				}
			}
			string limitParams = inConditionInfo.GetLimitParams("TeleportType");
			Teleporter? config = ConfigTeleporterById.GetConfig((int)eventArgs[0], true);
			int num;
			return config != null && int.TryParse(limitParams, out num) && config.Value.Type == num;
		}
	}
}
