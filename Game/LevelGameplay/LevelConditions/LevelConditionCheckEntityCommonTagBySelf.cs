using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.CreatureTools;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CED RID: 27885
	public class LevelConditionCheckEntityCommonTagBySelf : LevelConditionBase
	{
		// Token: 0x0604440C RID: 279564 RVA: 0x011BA210 File Offset: 0x011B8410
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			ConditionExParamsCheckEntityCommonTagBySelf conditionExParamsCheckEntityCommonTagBySelf = Singleton<LevelConditionCenter>.Instance.GetConditionExParams(inConditionInfo.Id) as ConditionExParamsCheckEntityCommonTagBySelf;
			if (conditionExParamsCheckEntityCommonTagBySelf == null)
			{
				if (inConditionInfo.LimitParamsLength == 0)
				{
					return false;
				}
				string limitParams = inConditionInfo.GetLimitParams("EntityCommonTag");
				if (limitParams == null)
				{
					return false;
				}
				string[] array = limitParams.Split('-', StringSplitOptions.None);
				conditionExParamsCheckEntityCommonTagBySelf = new ConditionExParamsCheckEntityCommonTagBySelf();
				conditionExParamsCheckEntityCommonTagBySelf.TagIds = new List<int>();
				foreach (string tagName in array)
				{
					int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
					conditionExParamsCheckEntityCommonTagBySelf.TagIds.Add(tagIdByName);
				}
				Singleton<LevelConditionCenter>.Instance.SetConditionExParams(inConditionInfo.Id, conditionExParamsCheckEntityCommonTagBySelf);
			}
			if (conditionExParamsCheckEntityCommonTagBySelf.TagIds != null && conditionExParamsCheckEntityCommonTagBySelf.TagIds.Count > 0)
			{
				IBPI_CreatureInterface_C ibpi_CreatureInterface_C = inTrigger as IBPI_CreatureInterface_C;
				if (ibpi_CreatureInterface_C == null)
				{
					return false;
				}
				Entity entity = Singleton<EntitySystem>.Instance.Get(ibpi_CreatureInterface_C.GetEntityId());
				if (entity == null)
				{
					return false;
				}
				LevelTagComponent component = entity.GetComponent<LevelTagComponent>();
				if (component == null)
				{
					return false;
				}
				foreach (int tagId in conditionExParamsCheckEntityCommonTagBySelf.TagIds)
				{
					if (!component.HasTag(tagId))
					{
						return false;
					}
				}
				return true;
			}
			return true;
		}
	}
}
