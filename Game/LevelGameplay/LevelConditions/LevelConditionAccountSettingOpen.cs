using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CB4 RID: 27828
	public class LevelConditionAccountSettingOpen : LevelConditionBase
	{
		// Token: 0x0604436A RID: 279402 RVA: 0x011B4324 File Offset: 0x011B2524
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Id");
			if (limitParams == null)
			{
				return false;
			}
			int type = int.Parse(limitParams);
			return ControllerBase<ChannelController>.Instance.CheckAccountSettingOpen((EChannelAccountSetting)type);
		}
	}
}
