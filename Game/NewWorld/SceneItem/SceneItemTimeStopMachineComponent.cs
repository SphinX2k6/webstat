using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x02004813 RID: 18451
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemTimeStopMachineComponent : EntityComponent
	{
		// Token: 0x06030031 RID: 196657 RVA: 0x00BA0048 File Offset: 0x00B9E248
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			TimeStopComponent config = args.GetP1<CreateEntityData>().GetParam<SceneItemTimeStopMachineComponent>() as TimeStopComponent;
			this.Config = config;
			this.TargetState = new int?(GameplayTagUtils.GetTagIdByName(this.Config.ActiveState));
			return true;
		}

		// Token: 0x06030032 RID: 196658 RVA: 0x00BA0089 File Offset: 0x00B9E289
		protected override bool OnStart()
		{
			this.CreatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
			this.AddEventListener();
			this.CurrentAffectedEntity.Clear();
			this.WaitAddEntitiesSet.Clear();
			return true;
		}

		// Token: 0x06030033 RID: 196659 RVA: 0x00BA00B9 File Offset: 0x00B9E2B9
		protected override bool OnEnd()
		{
			this.RemoveEventListener();
			this.CurrentAffectedEntity.Clear();
			this.WaitAddEntitiesSet.Clear();
			return true;
		}

		// Token: 0x06030034 RID: 196660 RVA: 0x00BA00D8 File Offset: 0x00B9E2D8
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange));
		}

		// Token: 0x06030035 RID: 196661 RVA: 0x00BA00FC File Offset: 0x00B9E2FC
		private void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange));
			Singleton<EventSystem>.Instance.RemoveAllTargetUseKey(this);
			if (Singleton<EventSystem>.Instance.Has<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.WaitCreateEntity)))
			{
				Singleton<EventSystem>.Instance.Remove<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.WaitCreateEntity));
			}
		}

		// Token: 0x06030036 RID: 196662 RVA: 0x00BA0170 File Offset: 0x00B9E370
		private void OnSceneItemStateChange(int stateId, bool isReady)
		{
			int? targetState = this.TargetState;
			if (!(stateId == targetState.GetValueOrDefault() & targetState != null) && this.IsStopping)
			{
				this.IsStopping = false;
				this.EndTimeStop();
				return;
			}
			targetState = this.TargetState;
			if ((stateId == targetState.GetValueOrDefault() & targetState != null) && !this.IsStopping)
			{
				this.IsStopping = true;
				this.StartTimeStop();
			}
		}

		// Token: 0x06030037 RID: 196663 RVA: 0x00BA01E0 File Offset: 0x00B9E3E0
		private void OnEntityRemove(ERemoveEntityType removeType, EntityHandle handle)
		{
			if (this.CurrentAffectedEntity.ContainsKey(handle))
			{
				this.EndTimeStopInternal(handle);
				this.CurrentAffectedEntity.Remove(handle);
				Singleton<EventSystem>.Instance.RemoveWithTargetUseKey(this, handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnEntityRemove));
			}
		}

		// Token: 0x06030038 RID: 196664 RVA: 0x00BA0230 File Offset: 0x00B9E430
		private void StartTimeStop()
		{
			TimeStopComponent config = this.Config;
			List<int> list = (config != null) ? config.Target.EntityIds : null;
			if (list != null)
			{
				foreach (int num in list)
				{
					EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num);
					if (entityByPbDataId != null && entityByPbDataId.Valid)
					{
						this.StartTimeStopInternal(entityByPbDataId);
					}
					else
					{
						this.WaitAddEntitiesSet.Add(num);
						this.TryListenAddEntityEvent();
					}
				}
			}
		}

		// Token: 0x06030039 RID: 196665 RVA: 0x00BA02C8 File Offset: 0x00B9E4C8
		private void StartTimeStopInternal(EntityHandle entityHandle)
		{
			WorldEntity entity = entityHandle.Entity;
			PawnTimeScaleComponent pawnTimeScaleComponent = (entity != null) ? entity.GetComponent<PawnTimeScaleComponent>() : null;
			if (pawnTimeScaleComponent != null)
			{
				int timeScaleId = pawnTimeScaleComponent.SetTimeScale(1, 0f, null, (float)(this.Config.StopTime + 3), ETimeScaleSourceType.TimeStopMachine, false, false);
				EEntityType entityType = entityHandle.Entity.GetComponent<CreatureDataComponent>().GetEntityType();
				if (entityType == EEntityType.SceneItem)
				{
					LevelTagComponent component = entityHandle.Entity.GetComponent<LevelTagComponent>();
					if (component != null)
					{
						component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.时停中"]));
					}
				}
				else
				{
					BaseBuffComponent component2 = entityHandle.Entity.GetComponent<BaseBuffComponent>();
					if (component2 != null)
					{
						component2.AddBuff(600000009L, new AddBuffParam
						{
							InstigatorId = this.CreatureDataComponent.GetCreatureDataId(),
							Level = new int?(1),
							Reason = "TimeStopMachine"
						});
					}
				}
				Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<ERemoveEntityType, EntityHandle>(this, entityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnEntityRemove));
				this.CurrentAffectedEntity[entityHandle] = new TimeStopData(pawnTimeScaleComponent, timeScaleId, entityType == EEntityType.SceneItem);
			}
		}

		// Token: 0x0603003A RID: 196666 RVA: 0x00BA03CC File Offset: 0x00B9E5CC
		private void EndTimeStop()
		{
			foreach (KeyValuePair<EntityHandle, TimeStopData> keyValuePair in this.CurrentAffectedEntity)
			{
				this.EndTimeStopInternal(keyValuePair.Key);
			}
			this.CurrentAffectedEntity.Clear();
			if (Singleton<EventSystem>.Instance.Has<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.WaitCreateEntity)))
			{
				Singleton<EventSystem>.Instance.Remove<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.WaitCreateEntity));
				this.WaitAddEntitiesSet.Clear();
			}
		}

		// Token: 0x0603003B RID: 196667 RVA: 0x00BA0474 File Offset: 0x00B9E674
		private void EndTimeStopInternal(EntityHandle entityHandle)
		{
			TimeStopData timeStopData;
			if (this.CurrentAffectedEntity.TryGetValue(entityHandle, out timeStopData))
			{
				timeStopData.TimeScaleComponent.RemoveTimeScale(timeStopData.TimeScaleId.Value);
				if (timeStopData.IsSceneItem)
				{
					LevelTagComponent component = entityHandle.Entity.GetComponent<LevelTagComponent>();
					if (component == null)
					{
						return;
					}
					component.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.时停中"]));
					return;
				}
				else
				{
					BaseBuffComponent component2 = entityHandle.Entity.GetComponent<BaseBuffComponent>();
					if (component2 == null)
					{
						return;
					}
					component2.RemoveBuff(600000009L, -1, "TimeStopMachine", null, null, null);
				}
			}
		}

		// Token: 0x0603003C RID: 196668 RVA: 0x00BA0519 File Offset: 0x00B9E719
		private void TryListenAddEntityEvent()
		{
			if (!Singleton<EventSystem>.Instance.Has<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.WaitCreateEntity)))
			{
				Singleton<EventSystem>.Instance.Add<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.WaitCreateEntity));
			}
		}

		// Token: 0x0603003D RID: 196669 RVA: 0x00BA0554 File Offset: 0x00B9E754
		private void WaitCreateEntity(EAddEntityType addType, EntityHandle handle, [Nullable(2)] AActor actor)
		{
			int pbDataId = handle.Entity.GetComponent<CreatureDataComponent>().GetPbDataId();
			if (this.WaitAddEntitiesSet.Contains(pbDataId))
			{
				this.WaitAddEntitiesSet.Remove(pbDataId);
				this.StartTimeStopInternal(handle);
				if (this.WaitAddEntitiesSet.Count == 0)
				{
					Singleton<EventSystem>.Instance.Remove<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.WaitCreateEntity));
				}
			}
		}

		// Token: 0x0603003E RID: 196670 RVA: 0x00BA05C0 File Offset: 0x00B9E7C0
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemTimeStopMachineComponent sceneItemTimeStopMachineComponent = (SceneItemTimeStopMachineComponent)componentTemplate;
			if (base.CanResetComponentProperty("Config"))
			{
				if (sceneItemTimeStopMachineComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimeStopComponent>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TargetState"))
			{
				this.TargetState = sceneItemTimeStopMachineComponent.TargetState;
			}
			if (base.CanResetComponentProperty("CreatureDataComponent"))
			{
				if (sceneItemTimeStopMachineComponent.CreatureDataComponent == null)
				{
					this.CreatureDataComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurrentAffectedEntity") && sceneItemTimeStopMachineComponent.CurrentAffectedEntity != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EntityHandle, TimeStopData>>(this.CurrentAffectedEntity), "CurrentAffectedEntity"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("WaitAddEntitiesSet") && sceneItemTimeStopMachineComponent.WaitAddEntitiesSet != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.WaitAddEntitiesSet), "WaitAddEntitiesSet"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("IsStopping"))
			{
				this.IsStopping = sceneItemTimeStopMachineComponent.IsStopping;
			}
			return true;
		}

		// Token: 0x0401B8F0 RID: 112880
		private const int TOLERANCE_TIME = 3;

		// Token: 0x0401B8F1 RID: 112881
		private const int TIME_STOP_BUFF_ID = 600000009;

		// Token: 0x0401B8F2 RID: 112882
		[Nullable(2)]
		private TimeStopComponent Config;

		// Token: 0x0401B8F3 RID: 112883
		private int? TargetState;

		// Token: 0x0401B8F4 RID: 112884
		[Nullable(2)]
		private CreatureDataComponent CreatureDataComponent;

		// Token: 0x0401B8F5 RID: 112885
		private readonly Dictionary<EntityHandle, TimeStopData> CurrentAffectedEntity = new Dictionary<EntityHandle, TimeStopData>();

		// Token: 0x0401B8F6 RID: 112886
		private readonly HashSet<int> WaitAddEntitiesSet = new HashSet<int>();

		// Token: 0x0401B8F7 RID: 112887
		private bool IsStopping;
	}
}
