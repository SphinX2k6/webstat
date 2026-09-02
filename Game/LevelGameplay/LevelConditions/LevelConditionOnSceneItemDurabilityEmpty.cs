using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DC9 RID: 28105
	public class LevelConditionOnSceneItemDurabilityEmpty : LevelConditionBase
	{
		// Token: 0x060445DB RID: 280027 RVA: 0x011C2E08 File Offset: 0x011C1008
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("EntityTemplateId");
			if (limitParams == null)
			{
				return true;
			}
			int num;
			if (int.TryParse(limitParams, out num))
			{
				Entity entity = (Entity)eventArgs[0];
				int? num2;
				if (entity == null)
				{
					num2 = null;
				}
				else
				{
					CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
					num2 = ((component != null) ? new int?(component.GetTemplateId()) : null);
				}
				int? num3 = num2;
				int num4 = num;
				return num3.GetValueOrDefault() == num4 & num3 != null;
			}
			return false;
		}
	}
}
