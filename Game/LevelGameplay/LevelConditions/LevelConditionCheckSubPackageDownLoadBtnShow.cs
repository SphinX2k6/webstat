using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D53 RID: 27987
	public class LevelConditionCheckSubPackageDownLoadBtnShow : LevelConditionBase
	{
		// Token: 0x060444E5 RID: 279781 RVA: 0x011BF517 File Offset: 0x011BD717
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			SubPackageDownLoadModel instance = ModelBase<SubPackageDownLoadModel>.Instance;
			return instance != null && instance.NeedShowBattleViewButton();
		}
	}
}
