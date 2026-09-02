using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D87 RID: 28039
	public class LevelConditionCheckFightPhotoHasTarget : LevelConditionBase
	{
		// Token: 0x06044555 RID: 279893 RVA: 0x011C11C4 File Offset: 0x011BF3C4
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return ControllerBase<PhotographController>.Instance.CurrentBtNode != null;
		}
	}
}
