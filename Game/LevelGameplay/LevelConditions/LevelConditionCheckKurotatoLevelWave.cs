using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Kurotato;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D25 RID: 27941
	public class LevelConditionCheckKurotatoLevelWave : LevelConditionBase
	{
		// Token: 0x06044485 RID: 279685 RVA: 0x011BD120 File Offset: 0x011BB320
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("LevelId");
			string limitParams2 = inConditionInfo.GetLimitParams("Wave");
			if (limitParams == null || limitParams2 == null)
			{
				return false;
			}
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			return instance.GetCurLevelId() == int.Parse(limitParams) && instance.CurWaveNum == int.Parse(limitParams2);
		}
	}
}
