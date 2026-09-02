using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CC5 RID: 27845
	public class LevelConditionCheckBuff : LevelConditionBase
	{
		// Token: 0x0604439A RID: 279450 RVA: 0x011B73C0 File Offset: 0x011B55C0
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			int pbDataId = UKismetStringLibrary.Conv_StringToInt(inConditionInfo.GetLimitParams("PbDataId"));
			bool flag = UKismetStringLibrary.Conv_StringToInt(inConditionInfo.GetLimitParams("IsPlayer")) != 0;
			long buffId = UKismetStringLibrary.Conv_StringToInt64(inConditionInfo.GetLimitParams("BuffId"));
			if (flag)
			{
				int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
				Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
				CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
				return (characterBuffComponent != null && characterBuffComponent.GetBuffTotalStackById(buffId, false) > 0) > false;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
			object obj;
			if (entityByPbDataId == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity2 = entityByPbDataId.Entity;
				obj = ((entity2 != null) ? entity2.GetComponent<CharacterBuffComponent>() : null);
			}
			object obj2 = obj;
			return (obj2 != null && obj2.GetBuffTotalStackById(buffId, false) > 0) > false;
		}
	}
}
