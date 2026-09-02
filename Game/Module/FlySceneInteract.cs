using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using UnrealEngine;

namespace CSharpScript.Game.Module
{
	// Token: 0x02004A83 RID: 19075
	[NullableContext(1)]
	[Nullable(0)]
	public class FlySceneInteract : IStaticVariableResetter
	{
		// Token: 0x06031C64 RID: 203876 RVA: 0x00C76F2C File Offset: 0x00C7512C
		public void Init()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRole));
			BP_SceneBattleInteract_C bp_SceneBattleInteract_C = Singleton<ResourceSystem>.Instance.Load<BP_SceneBattleInteract_C>("/Game/Aki/Data/Fight/DA_FlySceneInteract.DA_FlySceneInteract", "js_undefined");
			if (bp_SceneBattleInteract_C != null)
			{
				SceneBattleInteractEffect sceneBattleInteractEffect = ModelBase<SceneBattleInteractModel>.Instance.CreateSceneBattleInteract(bp_SceneBattleInteract_C, 0f, 0f);
				if (sceneBattleInteractEffect != null)
				{
					this.HandleId = sceneBattleInteractEffect.Id;
					sceneBattleInteractEffect.SetUpdateLocationFunc(new Action<global::Vector, FVectorDouble?>(this.UpdateLocation));
				}
			}
			this.AddEntityEvents();
		}

		// Token: 0x06031C65 RID: 203877 RVA: 0x00C76FAA File Offset: 0x00C751AA
		public void Destroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRole));
			this.RemoveEntityEvents();
			ModelBase<SceneBattleInteractModel>.Instance.DestroySceneBattleInteract(this.HandleId);
			this.HandleId = 0;
		}

		// Token: 0x06031C66 RID: 203878 RVA: 0x00C76FE5 File Offset: 0x00C751E5
		private void OnChangeRole(int newEntityId, int oldEntityId)
		{
			this.RemoveEntityEvents();
			this.AddEntityEvents();
		}

		// Token: 0x06031C67 RID: 203879 RVA: 0x00C76FF4 File Offset: 0x00C751F4
		private void AddEntityEvents()
		{
			BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
			BattleUiRoleData battleUiRoleData = (instance != null) ? instance.GetCurRoleData() : null;
			if (battleUiRoleData == null)
			{
				return;
			}
			this.CurrentEntity = battleUiRoleData.EntityHandle;
			EntityHandle currentEntity = this.CurrentEntity;
			BaseActorComponent actorComp;
			if (currentEntity == null)
			{
				actorComp = null;
			}
			else
			{
				WorldEntity entity = currentEntity.Entity;
				actorComp = ((entity != null) ? entity.GetComponent<BaseActorComponent>() : null);
			}
			this.ActorComp = actorComp;
			Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<ERemoveEntityType, EntityHandle>(this, this.CurrentEntity, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			BaseTagComponent gameplayTagComponent = battleUiRoleData.GameplayTagComponent;
			if (gameplayTagComponent == null)
			{
				return;
			}
			this.ListenForTagAddOrRemove(gameplayTagComponent, GameplayTagDefine.EGameplayTagId["行为状态.动作状态.XA"], new Action<int, bool>(this.OnFlyTagChanged), true);
		}

		// Token: 0x06031C68 RID: 203880 RVA: 0x00C77098 File Offset: 0x00C75298
		private void RemoveEntityEvents()
		{
			if (this.CurrentEntity == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.RemoveWithTargetUseKey<ERemoveEntityType, EntityHandle>(this, this.CurrentEntity, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			foreach (ITagTask tagTask in this.TagTaskList)
			{
				tagTask.EndTask();
			}
			this.TagTaskList.Clear();
			this.CurrentEntity = null;
			this.ActorComp = null;
		}

		// Token: 0x06031C69 RID: 203881 RVA: 0x00C77130 File Offset: 0x00C75330
		private void ListenForTagAddOrRemove(BaseTagComponent tagComponent, int tagId, Action<int, bool> callback, bool checkExistImmediately = false)
		{
			if (checkExistImmediately && tagComponent.HasTag(tagId))
			{
				callback(tagId, true);
			}
			ITagTask tagTask = tagComponent.ListenForTagAddOrRemove(new int?(tagId), new BaseTagComponent.TTagSwitchedCallback(callback.Invoke), FlySceneInteract.ListenTagStat);
			if (tagTask != null)
			{
				this.TagTaskList.Add(tagTask);
			}
		}

		// Token: 0x06031C6A RID: 203882 RVA: 0x00C7717F File Offset: 0x00C7537F
		private void OnFlyTagChanged(int tagId, bool tagExist)
		{
			this.Refresh(tagExist);
		}

		// Token: 0x06031C6B RID: 203883 RVA: 0x00C77188 File Offset: 0x00C75388
		private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
		{
			if (this.CurrentEntity != handle)
			{
				return;
			}
			this.RemoveEntityEvents();
		}

		// Token: 0x06031C6C RID: 203884 RVA: 0x00C7719C File Offset: 0x00C7539C
		private void Refresh(bool isFlying)
		{
			if (this.IsFlying == isFlying)
			{
				return;
			}
			this.IsFlying = isFlying;
			if (this.HandleId > 0)
			{
				SceneBattleInteractEffect sceneBattleInteract = ModelBase<SceneBattleInteractModel>.Instance.GetSceneBattleInteract(this.HandleId);
				if (sceneBattleInteract != null)
				{
					sceneBattleInteract.SetEnable(isFlying, 0f);
					if (this.ActorComp != null)
					{
						sceneBattleInteract.SetDownVector(this.ActorComp.ActorGravityDirectProxy);
					}
				}
			}
		}

		// Token: 0x06031C6D RID: 203885 RVA: 0x00C771FC File Offset: 0x00C753FC
		private void UpdateLocation(global::Vector @out, FVectorDouble? offset)
		{
			if (this.ActorComp == null)
			{
				return;
			}
			if (offset == null)
			{
				@out.FromUeVector(this.ActorComp.ActorLocationProxy);
				return;
			}
			global::Vector tmpVector = this.TmpVector;
			FVectorDouble value = offset.Value;
			tmpVector.FromUeVector(value);
			this.ActorComp.ActorQuatProxy.RotateVector(this.TmpVector, @out);
			@out.AdditionEqual(this.ActorComp.ActorLocationProxy);
		}

		// Token: 0x06031C6E RID: 203886 RVA: 0x00C7726B File Offset: 0x00C7546B
		static FlySceneInteract()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(FlySceneInteract.CreateStaticDefaultValue), new Action(FlySceneInteract.ResetStaticDefaultValue));
		}

		// Token: 0x06031C6F RID: 203887 RVA: 0x00C7728A File Offset: 0x00C7548A
		public static void CreateStaticDefaultValue()
		{
			FlySceneInteract.ListenTagStat = Stat.Create("[StrengthHandle]ListenTag", "", "");
		}

		// Token: 0x06031C70 RID: 203888 RVA: 0x00C772A5 File Offset: 0x00C754A5
		public static void ResetStaticDefaultValue()
		{
			FlySceneInteract.ListenTagStat = null;
		}

		// Token: 0x0401D24C RID: 119372
		[Nullable(2)]
		private static Stat ListenTagStat;

		// Token: 0x0401D24D RID: 119373
		private bool IsFlying;

		// Token: 0x0401D24E RID: 119374
		private int HandleId;

		// Token: 0x0401D24F RID: 119375
		private readonly global::Vector TmpVector = global::Vector.Create();

		// Token: 0x0401D250 RID: 119376
		[Nullable(2)]
		private EntityHandle CurrentEntity;

		// Token: 0x0401D251 RID: 119377
		[Nullable(2)]
		private BaseActorComponent ActorComp;

		// Token: 0x0401D252 RID: 119378
		private readonly List<ITagTask> TagTaskList = new List<ITagTask>();
	}
}
