using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D9C RID: 28060
	public class LevelConditionHideSettingInCloudGame : LevelConditionBase
	{
		// Token: 0x06044580 RID: 279936 RVA: 0x011C1A2C File Offset: 0x011BFC2C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return !Singleton<CloudGameManager>.Instance.IsCloudGame;
		}
	}
}
