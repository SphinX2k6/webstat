using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x02004807 RID: 18439
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemProceduralMaterialComponent : EntityComponent
	{
		// Token: 0x0602FF59 RID: 196441 RVA: 0x00B97573 File Offset: 0x00B95773
		public bool HasCustomType(SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType type)
		{
			return this.CustomPrimitiveDataConfigs.ContainsKey(type);
		}

		// Token: 0x0602FF5A RID: 196442 RVA: 0x00B97584 File Offset: 0x00B95784
		protected override bool OnInitData(IEntityArgs args = null)
		{
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			ProceduralMaterialComponent proceduralMaterialComponent = args.GetP1<CreateEntityData>().GetParam<SceneItemProceduralMaterialComponent>() as ProceduralMaterialComponent;
			if (proceduralMaterialComponent == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.FJH;
				string message = "[ProceduralMaterialComp] 组件配置缺失";
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			this.Config = proceduralMaterialComponent;
			return true;
		}

		// Token: 0x0602FF5B RID: 196443 RVA: 0x00B9760C File Offset: 0x00B9580C
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			if (!this.ActorComp.GetIsSceneInteractionLoadCompleted())
			{
				Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneInteractionShowCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			}
			else
			{
				this.OnSceneInteractionLoadCompleted();
			}
			return true;
		}

		// Token: 0x0602FF5C RID: 196444 RVA: 0x00B97664 File Offset: 0x00B95864
		protected override bool OnEnd()
		{
			if (this.ChildEntityWaitTask != null)
			{
				this.ChildEntityWaitTask.Cancel();
			}
			this.ChildEntityWaitTask = null;
			if (this.MainEntityHandle != null && Singleton<EventSystem>.Instance.HasWithTarget<ERemoveEntityType, EntityHandle>(this.MainEntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnMainEntityRemove)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<ERemoveEntityType, EntityHandle>(this.MainEntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnMainEntityRemove));
			}
			this.MainEntityHandle = null;
			this.CustomPrimitiveDataConfigs.Clear();
			return true;
		}

		// Token: 0x0602FF5D RID: 196445 RVA: 0x00B976EC File Offset: 0x00B958EC
		private void OnSceneInteractionLoadCompleted()
		{
			SceneInteractionActor sceneInteractionActor = this.ActorComp.GetInteractionMainActor() as SceneInteractionActor;
			if (sceneInteractionActor == null)
			{
				return;
			}
			TMap<string, AActor> allActor = sceneInteractionActor.GetAllActor();
			if (allActor == null || allActor.Num() == 0)
			{
				return;
			}
			foreach (ICustomPrimitiveDataConfig customPrimitiveDataConfig in this.Config.ProceduralMaterialConfigs)
			{
				if (customPrimitiveDataConfig.Type == EProceduralMaterialType.CustomPrimitiveData)
				{
					ICustomPrimitiveDataConfig primitiveDataConfig = customPrimitiveDataConfig;
					this.ConstructCustomPrimitiveDataConfig(primitiveDataConfig, allActor, false);
				}
			}
		}

		// Token: 0x0602FF5E RID: 196446 RVA: 0x00B9777C File Offset: 0x00B9597C
		[NullableContext(1)]
		private unsafe void ConstructCustomPrimitiveDataConfig(ICustomPrimitiveDataConfig primitiveDataConfig, TMap<string, AActor> allRefActors, bool fromOutside = false)
		{
			foreach (ICustomPrimitiveMapping customPrimitiveMapping in primitiveDataConfig.PrimitiveConfigs)
			{
				SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType? ecustomPrimitiveDataSceneItemType = null;
				if (customPrimitiveMapping.KeyPrefix == SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType.Chair.ToEnumString())
				{
					ecustomPrimitiveDataSceneItemType = new SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType?(SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType.Chair);
				}
				if (ecustomPrimitiveDataSceneItemType == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.FJH;
					string message = "[ProceduralMaterialComp] 不存在的交互物类型，请检查配置";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
					string item = "PbDataId";
					CreatureDataComponent creatureDataComp = this.CreatureDataComp;
					ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("KeyPrefix", customPrimitiveMapping.KeyPrefix);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else
				{
					if (!this.CustomPrimitiveDataConfigs.ContainsKey(ecustomPrimitiveDataSceneItemType.Value))
					{
						this.CustomPrimitiveDataConfigs[ecustomPrimitiveDataSceneItemType.Value] = new SceneItemProceduralMaterialComponent.CustomPrimitiveDataConfig(ecustomPrimitiveDataSceneItemType.Value);
					}
					SceneItemProceduralMaterialComponent.CustomPrimitiveDataConfig customPrimitiveDataConfig = this.CustomPrimitiveDataConfigs[ecustomPrimitiveDataSceneItemType.Value];
					if (!customPrimitiveDataConfig.IndexList.Contains(customPrimitiveMapping.Index))
					{
						customPrimitiveDataConfig.IndexList.Add(customPrimitiveMapping.Index);
					}
					foreach (KeyValuePair<string, AActor> keyValuePair in allRefActors)
					{
						string text;
						AActor aactor;
						keyValuePair.Deconstruct(out text, out aactor);
						string text2 = text;
						AActor aactor2 = aactor;
						if (aactor2 != null && text2.StartsWith(customPrimitiveMapping.KeyPrefix) && !customPrimitiveDataConfig.ReferenceActors.Contains(aactor2))
						{
							customPrimitiveDataConfig.ReferenceActors.Add(aactor2);
						}
					}
				}
			}
			if (primitiveDataConfig.IsChildEffective.GetValueOrDefault() && !fromOutside)
			{
				this.ConnectChildEntity();
			}
		}

		// Token: 0x0602FF5F RID: 196447 RVA: 0x00B97998 File Offset: 0x00B95B98
		private void ConnectChildEntity()
		{
			SceneItemProceduralMaterialComponent.<>c__DisplayClass14_0 CS$<>8__locals1 = new SceneItemProceduralMaterialComponent.<>c__DisplayClass14_0();
			CS$<>8__locals1.<>4__this = this;
			SceneItemProceduralMaterialComponent.<>c__DisplayClass14_0 CS$<>8__locals2 = CS$<>8__locals1;
			CreatureDataComponent creatureDataComp = this.CreatureDataComp;
			List<int> childEntityIds;
			if (creatureDataComp == null)
			{
				childEntityIds = null;
			}
			else
			{
				BaseInfoComponent baseInfo = creatureDataComp.GetBaseInfo();
				childEntityIds = ((baseInfo != null) ? baseInfo.ChildEntityIds : null);
			}
			CS$<>8__locals2.childEntityIds = childEntityIds;
			if (CS$<>8__locals1.childEntityIds == null)
			{
				return;
			}
			if (this.ChildEntityWaitTask != null)
			{
				this.ChildEntityWaitTask.Cancel();
				this.ChildEntityWaitTask = null;
			}
			this.ChildEntityWaitTask = WaitEntityTask.CreateWithPbDataId("LevelConditionListenerCheckEntityHasSceneItemAttributeTag", CS$<>8__locals1.childEntityIds, delegate(bool? result)
			{
				if (!result.GetValueOrDefault())
				{
					return;
				}
				CS$<>8__locals1.<>4__this.ChildEntityWaitTask = null;
				foreach (int pbDataId in CS$<>8__locals1.childEntityIds)
				{
					EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
					if (entityByPbDataId == null || entityByPbDataId.Entity == null)
					{
						break;
					}
					SceneItemProceduralMaterialComponent component = entityByPbDataId.Entity.GetComponent<SceneItemProceduralMaterialComponent>();
					if (component == null)
					{
						break;
					}
					component.ConstructCustomPrimitiveDataConfigByMainEntity(CS$<>8__locals1.<>4__this.CreatureDataComp.GetPbDataId());
				}
			}, 60000, true, false);
		}

		// Token: 0x0602FF60 RID: 196448 RVA: 0x00B97A24 File Offset: 0x00B95C24
		public void SetCustomPrimitiveData(SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType type, float value)
		{
			SceneItemProceduralMaterialComponent.CustomPrimitiveDataConfig customPrimitiveDataConfig;
			this.CustomPrimitiveDataConfigs.TryGetValue(type, out customPrimitiveDataConfig);
			if (customPrimitiveDataConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.FJH;
				string message = "[ProceduralMaterialComp] 没有记录该类型交互物的数据，请检查配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			foreach (AActor aactor in customPrimitiveDataConfig.ReferenceActors)
			{
				if (aactor != null && aactor.IsValid())
				{
					TArray<UActorComponent> tarray = aactor.K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
					if (tarray.Num() != 0)
					{
						for (int i = 0; i < tarray.Num(); i++)
						{
							UStaticMeshComponent ustaticMeshComponent = tarray.Get(i) as UStaticMeshComponent;
							if (ustaticMeshComponent != null)
							{
								foreach (int dataIndex in customPrimitiveDataConfig.IndexList)
								{
									ustaticMeshComponent.SetDefaultCustomPrimitiveDataFloat(dataIndex, value);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0602FF61 RID: 196449 RVA: 0x00B97B54 File Offset: 0x00B95D54
		public void ConstructCustomPrimitiveDataConfigByMainEntity(int mainEntityId)
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(mainEntityId);
			if (entityByPbDataId == null || entityByPbDataId.Entity == null)
			{
				return;
			}
			this.MainEntityHandle = entityByPbDataId;
			SceneItemActorComponent component = entityByPbDataId.Entity.GetComponent<SceneItemActorComponent>();
			if (component == null)
			{
				return;
			}
			SceneInteractionActor sceneInteractionActor = component.GetInteractionMainActor() as SceneInteractionActor;
			if (sceneInteractionActor == null)
			{
				return;
			}
			TMap<string, AActor> allActor = sceneInteractionActor.GetAllActor();
			if (allActor == null)
			{
				return;
			}
			foreach (ICustomPrimitiveDataConfig customPrimitiveDataConfig in this.Config.ProceduralMaterialConfigs)
			{
				if (customPrimitiveDataConfig.Type == EProceduralMaterialType.CustomPrimitiveData)
				{
					ICustomPrimitiveDataConfig primitiveDataConfig = customPrimitiveDataConfig;
					this.ConstructCustomPrimitiveDataConfig(primitiveDataConfig, allActor, false);
				}
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget<ERemoveEntityType, EntityHandle>(entityByPbDataId, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnMainEntityRemove)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(entityByPbDataId, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnMainEntityRemove));
			}
		}

		// Token: 0x0602FF62 RID: 196450 RVA: 0x00B97C44 File Offset: 0x00B95E44
		[NullableContext(1)]
		private void OnMainEntityRemove(ERemoveEntityType removeType, EntityHandle handle)
		{
			if (handle != this.MainEntityHandle)
			{
				return;
			}
			this.MainEntityHandle = null;
			this.CustomPrimitiveDataConfigs.Clear();
			Singleton<EventSystem>.Instance.RemoveWithTarget<ERemoveEntityType, EntityHandle>(handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnMainEntityRemove));
		}

		// Token: 0x0602FF63 RID: 196451 RVA: 0x00B97C80 File Offset: 0x00B95E80
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemProceduralMaterialComponent sceneItemProceduralMaterialComponent = (SceneItemProceduralMaterialComponent)componentTemplate;
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (sceneItemProceduralMaterialComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemProceduralMaterialComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("Config"))
			{
				if (sceneItemProceduralMaterialComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ProceduralMaterialComponent>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ChildEntityWaitTask"))
			{
				if (sceneItemProceduralMaterialComponent.ChildEntityWaitTask == null)
				{
					this.ChildEntityWaitTask = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<WaitEntityTask>(this.ChildEntityWaitTask), "ChildEntityWaitTask"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MainEntityHandle"))
			{
				if (sceneItemProceduralMaterialComponent.MainEntityHandle == null)
				{
					this.MainEntityHandle = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<EntityHandle>(this.MainEntityHandle), "MainEntityHandle"))
				{
					return false;
				}
			}
			return !base.CanResetComponentProperty("CustomPrimitiveDataConfigs") || sceneItemProceduralMaterialComponent.CustomPrimitiveDataConfigs == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType, SceneItemProceduralMaterialComponent.CustomPrimitiveDataConfig>>(this.CustomPrimitiveDataConfigs), "CustomPrimitiveDataConfigs");
		}

		// Token: 0x0401B863 RID: 112739
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x0401B864 RID: 112740
		private SceneItemActorComponent ActorComp;

		// Token: 0x0401B865 RID: 112741
		private ProceduralMaterialComponent Config;

		// Token: 0x0401B866 RID: 112742
		private WaitEntityTask ChildEntityWaitTask;

		// Token: 0x0401B867 RID: 112743
		private EntityHandle MainEntityHandle;

		// Token: 0x0401B868 RID: 112744
		[Nullable(1)]
		private readonly Dictionary<SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType, SceneItemProceduralMaterialComponent.CustomPrimitiveDataConfig> CustomPrimitiveDataConfigs = new Dictionary<SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType, SceneItemProceduralMaterialComponent.CustomPrimitiveDataConfig>();

		// Token: 0x0200A8E7 RID: 43239
		[NullableContext(0)]
		[EnumExtensions]
		public enum ECustomPrimitiveDataSceneItemType
		{
			// Token: 0x04034619 RID: 214553
			Chair
		}

		// Token: 0x0200A8E8 RID: 43240
		[NullableContext(1)]
		[Nullable(0)]
		private class CustomPrimitiveDataConfig
		{
			// Token: 0x0604B079 RID: 307321 RVA: 0x0146BDF1 File Offset: 0x01469FF1
			public CustomPrimitiveDataConfig(SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType type)
			{
				this.Type = type;
			}

			// Token: 0x0403461A RID: 214554
			public SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType Type;

			// Token: 0x0403461B RID: 214555
			public List<int> IndexList = new List<int>();

			// Token: 0x0403461C RID: 214556
			public List<AActor> ReferenceActors = new List<AActor>();
		}
	}
}
