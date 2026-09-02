using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F5C RID: 28508
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class BigStuffedDollController : ControllerBase<BigStuffedDollController>
	{
		// Token: 0x06044FF9 RID: 282617 RVA: 0x011F5550 File Offset: 0x011F3750
		public void Open(int id, int treeConfigId, Action finishCallback)
		{
			BigStuffedDollModel instance = ModelBase<BigStuffedDollModel>.Instance;
			instance.GameplayStart(id, treeConfigId);
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(instance.BrokenRockEntityPbDataId);
			if (entityByPbDataId != null)
			{
				instance.BrokenRockEntityCreatureDataId = entityByPbDataId.CreatureDataId;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BigStuffedDollView, null, delegate(bool success, int viewId)
			{
				finishCallback();
			});
		}

		// Token: 0x06044FFA RID: 282618 RVA: 0x011F55B4 File Offset: 0x011F37B4
		public void SetBooleanValueThenSendEvent(int entityId, string key, bool value)
		{
			ModelBase<BlackboardModel>.Instance.SetBooleanValueByEntity(entityId, key, value);
			this.SendGameplayEvent(entityId);
		}

		// Token: 0x06044FFB RID: 282619 RVA: 0x011F55CA File Offset: 0x011F37CA
		public void SetIntValueThenSendEvent(int entityId, string key, int value)
		{
			ModelBase<BlackboardModel>.Instance.SetIntValueByEntity(entityId, key, value);
			this.SendGameplayEvent(entityId);
		}

		// Token: 0x06044FFC RID: 282620 RVA: 0x011F55E0 File Offset: 0x011F37E0
		private void SendGameplayEvent(int entityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null || !entity.Valid)
			{
				return;
			}
			CharacterAbilityComponent component = entity.GetComponent<CharacterAbilityComponent>();
			if (component == null || !component.Valid)
			{
				return;
			}
			FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(GameplayTagDefine.EGameplayTagId["关卡.大个布偶.坚固岩石玩法事件"]);
			if (gameplayTagById == null)
			{
				return;
			}
			component.SendGameplayEventToActor(gameplayTagById.Value, null);
		}
	}
}
