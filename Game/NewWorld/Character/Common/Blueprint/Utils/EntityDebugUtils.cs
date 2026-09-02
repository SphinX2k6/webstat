using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Character.NPC.Animal;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Blueprint.Utils
{
	// Token: 0x0200498E RID: 18830
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class EntityDebugUtils : Singleton<EntityDebugUtils>
	{
		// Token: 0x06031314 RID: 201492 RVA: 0x00C3F7E7 File Offset: 0x00C3D9E7
		protected override bool OnInit()
		{
			this.EntityNameList = new TArray<string>();
			this.EntityIdMap = new Dictionary<string, int>();
			this.EntityNameMap = new Dictionary<int, string>();
			return true;
		}

		// Token: 0x06031315 RID: 201493 RVA: 0x00C3F80B File Offset: 0x00C3DA0B
		public TArray<string> GetDebugEntityNameList()
		{
			this.FindEntities();
			return this.EntityNameList;
		}

		// Token: 0x06031316 RID: 201494 RVA: 0x00C3F81C File Offset: 0x00C3DA1C
		private void FindEntities()
		{
			this.EntityNameList.Empty(true);
			this.EntityIdMap.Clear();
			this.EntityNameMap.Clear();
			List<ValueTuple<Entity, double>> list = new List<ValueTuple<Entity, double>>();
			CharacterActorComponent characterActorComponent = Global.BaseCharacter.CharacterActorComponent;
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			if (instance == null || !instance.WorldDone)
			{
				return;
			}
			CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
			foreach (EntityHandle entityHandle in ((instance2 != null) ? instance2.GetAllEntities() : null))
			{
				if (entityHandle != null)
				{
					WorldEntity entity = entityHandle.Entity;
					if (entity != null && entity.Active && entityHandle.Entity != characterActorComponent.Entity)
					{
						CreatureDataComponent component = entityHandle.Entity.GetComponent<CreatureDataComponent>();
						EEntityType? eentityType = (component != null) ? new EEntityType?(component.GetEntityType()) : null;
						if (eentityType != null && eentityType != null)
						{
							switch (eentityType.GetValueOrDefault())
							{
							case EEntityType.Npc:
							case EEntityType.Monster:
							case EEntityType.SceneItem:
							case EEntityType.Custom:
							case EEntityType.Animal:
							case EEntityType.Vehicle:
							{
								global::Vector vector = global::Vector.Create();
								BaseActorComponent actorComponent = ControllerBase<CharacterController>.Instance.GetActorComponent(entityHandle);
								(((actorComponent != null) ? actorComponent.ActorLocationProxy : null) ?? global::Vector.Create(component.GetLocation())).Subtraction(characterActorComponent.ActorLocationProxy, vector);
								double item = vector.SizeSquared();
								list.Add(new ValueTuple<Entity, double>(entityHandle.Entity, item));
								break;
							}
							}
						}
					}
				}
			}
			list.Sort(([TupleElementNames(new string[]
			{
				"Entity",
				"Distance"
			})] [Nullable(new byte[]
			{
				0,
				1
			})] ValueTuple<Entity, double> a, [TupleElementNames(new string[]
			{
				"Entity",
				"Distance"
			})] [Nullable(new byte[]
			{
				0,
				1
			})] ValueTuple<Entity, double> b) => a.Item2.CompareTo(b.Item2));
			foreach (ValueTuple<Entity, double> valueTuple in list)
			{
				this.AddMatchEntity(valueTuple.Item1);
			}
		}

		// Token: 0x06031317 RID: 201495 RVA: 0x00C3FA4C File Offset: 0x00C3DC4C
		private void AddMatchEntity(Entity entity)
		{
			BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
			CreatureDataComponent component2 = entity.GetComponent<CreatureDataComponent>();
			int? num = (component2 != null) ? new int?(component2.GetPbDataId()) : null;
			string str = "[";
			string str2 = ((num != null) ? num.GetValueOrDefault().ToString() : null) ?? "?";
			string str3 = "] ";
			string text;
			if (component == null)
			{
				text = null;
			}
			else
			{
				AActor owner = component.Owner;
				text = ((owner != null) ? owner.GetName() : null);
			}
			string text2 = str + str2 + str3 + (text ?? "?");
			PawnInfoManageComponent component3 = entity.GetComponent<PawnInfoManageComponent>();
			string str4 = text2;
			string str5 = " (";
			string str6;
			if ((str6 = ((component3 != null) ? component3.PawnName : null)) == null)
			{
				string text3;
				if (component2 == null)
				{
					text3 = null;
				}
				else
				{
					BaseInfoComponent baseInfo = component2.GetBaseInfo();
					text3 = ((baseInfo != null) ? baseInfo.TidName : null);
				}
				str6 = (text3 ?? "无名字");
			}
			text2 = str4 + str5 + str6 + ")";
			this.EntityNameList.Add(text2);
			this.EntityIdMap[text2] = entity.Id;
			this.EntityNameMap[entity.Id] = text2;
		}

		// Token: 0x06031318 RID: 201496 RVA: 0x00C3FB54 File Offset: 0x00C3DD54
		public int GetSelectedEntityId(string label)
		{
			if (string.IsNullOrEmpty(label))
			{
				return 0;
			}
			if (this.EntityIdMap == null)
			{
				return 0;
			}
			int result;
			if (!this.EntityIdMap.TryGetValue(label, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x06031319 RID: 201497 RVA: 0x00C3FB88 File Offset: 0x00C3DD88
		public string GetDebugBaseInfo(int entityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return "无";
			}
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component == null)
			{
				return "无";
			}
			if (entity == null || !entity.IsInit)
			{
				return "实体尚未完成Init";
			}
			BaseActorComponent component2 = entity.GetComponent<BaseActorComponent>();
			PawnInfoManageComponent component3 = entity.GetComponent<PawnInfoManageComponent>();
			string str = (entity.GameBudgetManagedToken != 0U) ? UKuroGameBudgetAllocatorCSharpInterface.GetGameBudgetDebugString(entity.GameBudgetManagedToken) : "Null";
			long ownerIncId = component.GetOwnerIncId();
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			EntityHandle entityHandle = (instance != null) ? instance.GetEntity(ownerIncId) : null;
			int? num;
			if (entityHandle == null)
			{
				num = new int?(0);
			}
			else
			{
				CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
				num = ((instance2 != null) ? new int?(instance2.GetPbDataIdByEntity(entityHandle)) : null);
			}
			int? value = num;
			string text = "Name: " + (((component3 != null) ? component3.PawnName : null) ?? "无名字");
			text += "\t\t";
			string str2 = text;
			string str3 = "TidName: ";
			BaseInfoComponent baseInfo = component.GetBaseInfo();
			text = str2 + str3 + (((baseInfo != null) ? baseInfo.TidName : null) ?? "无名字");
			text += "\t\t";
			string str4 = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
			defaultInterpolatedStringHandler.AppendLiteral("EntityId: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(entityId);
			text = str4 + defaultInterpolatedStringHandler.ToStringAndClear();
			text += "\t\t";
			string str5 = text;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
			defaultInterpolatedStringHandler.AppendLiteral("PbDataId: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(component.GetPbDataId());
			text = str5 + defaultInterpolatedStringHandler.ToStringAndClear();
			text += "\t\t";
			string str6 = text;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CreatureDataId: ");
			defaultInterpolatedStringHandler.AppendFormatted<long>(component.GetCreatureDataId());
			text = str6 + defaultInterpolatedStringHandler.ToStringAndClear();
			text += "\t\t";
			string str7 = text;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ModelId: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(component.GetModelId());
			text = str7 + defaultInterpolatedStringHandler.ToStringAndClear();
			text += "\t\t";
			string str8 = text;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
			defaultInterpolatedStringHandler.AppendLiteral("OwnerPbDataId: ");
			defaultInterpolatedStringHandler.AppendFormatted<int?>(value);
			text = str8 + defaultInterpolatedStringHandler.ToStringAndClear();
			text += "\t\t";
			SceneItemActorComponent sceneItemActorComponent = component2 as SceneItemActorComponent;
			if (sceneItemActorComponent != null)
			{
				string str9 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
				defaultInterpolatedStringHandler.AppendLiteral("SceneInteractActorState: ");
				SceneInteractionActor sceneInteractionActor = sceneItemActorComponent.GetInteractionMainActor() as SceneInteractionActor;
				defaultInterpolatedStringHandler.AppendFormatted<EKuroSceneInteractionState?>((sceneInteractionActor != null) ? new EKuroSceneInteractionState?(sceneInteractionActor.GetCurrentState()) : null);
				text = str9 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			text += "\n\n";
			string str10 = text;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("GameBudgetToken: ");
			defaultInterpolatedStringHandler.AppendFormatted<uint>(entity.GameBudgetManagedToken);
			defaultInterpolatedStringHandler.AppendLiteral("\n");
			text = str10 + defaultInterpolatedStringHandler.ToStringAndClear();
			text = text + "GameBudgetInfo:\n" + str + " ";
			text += "\n\n";
			SceneItemPropertyComponent component4 = entity.GetComponent<SceneItemPropertyComponent>();
			if (component4 != null)
			{
				string str11 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
				defaultInterpolatedStringHandler.AppendLiteral("SceneItemAttributeId:\n");
				defaultInterpolatedStringHandler.AppendFormatted<HashSet<int>>(component4.AttributeIdSet);
				text = str11 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\n\n";
			}
			text += "EntityTag: \n";
			text += this.GetEntityCommonTagDebugString(entityId);
			text += "\n\n";
			if (entity.GetComponent<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>() != null)
			{
				text += "范围组件内实体(客户端)列表: \n";
				text += this.GetInRangeLocalEntityListDebugString(entityId);
				text += "\n\n";
				text += "范围组件内Actor(客户端)列表: \n";
				text += this.GetInRangeActorListDebugString(entityId);
				text += "\n\n";
				text += "范围组件内实体(服务端)列表: \n";
				text += this.GetInRangeOnlineEntityListDebugString(entityId);
				text += "\n\n";
			}
			PawnSensoryInfoComponent component5 = entity.GetComponent<PawnSensoryInfoComponent>();
			if (component5 != null)
			{
				string str12 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
				defaultInterpolatedStringHandler.AppendLiteral("进入逻辑范围: ");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(component5.IsInLogicRange);
				text = str12 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\t\t";
				string str13 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
				defaultInterpolatedStringHandler.AppendLiteral("LogicRange: ");
				defaultInterpolatedStringHandler.AppendFormatted<float>(component5.LogicRange);
				text = str13 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\t\t";
				string str14 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
				defaultInterpolatedStringHandler.AppendLiteral("PlayerDistance: ");
				defaultInterpolatedStringHandler.AppendFormatted<double>(component5.PlayerDist);
				text = str14 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\n\n";
			}
			SceneItemPropertyComponent component6 = entity.GetComponent<SceneItemPropertyComponent>();
			if (component6 != null)
			{
				text += "SceneItem属性:";
				text += "\t\t";
				string str15 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
				defaultInterpolatedStringHandler.AppendLiteral("IsLocked: ");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(component6.IsLocked);
				text = str15 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\t\t";
				string str16 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
				defaultInterpolatedStringHandler.AppendLiteral("IsMoving: ");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(component6.IsMoving);
				text = str16 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\n\n";
			}
			SceneItemManipulatableComponent component7 = entity.GetComponent<SceneItemManipulatableComponent>();
			if (component7 != null)
			{
				text += "SceneItemManipulable属性:";
				text += "\t\t";
				string str17 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
				defaultInterpolatedStringHandler.AppendLiteral("State: ");
				defaultInterpolatedStringHandler.AppendFormatted<SceneItemManipulatableComponent.EManipulatableState>(component7.GetState());
				text = str17 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\n\n";
			}
			PawnInteractNewComponent component8 = entity.GetComponent<PawnInteractNewComponent>();
			if (component8 != null)
			{
				string str18 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
				defaultInterpolatedStringHandler.AppendLiteral("启用交互: ");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(component8.DebugInteractOpened);
				text = str18 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\t\t";
				string str19 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
				defaultInterpolatedStringHandler.AppendLiteral("定时器开启: ");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(component8.DebugTimerRunning);
				text = str19 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\n\n";
			}
			DurabilityComponent component9 = entity.GetComponent<DurabilityComponent>();
			if (component9 != null)
			{
				string str20 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
				defaultInterpolatedStringHandler.AppendLiteral("启用销毁: ");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(component9.DeadActions != null);
				text = str20 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\t\t";
				string str21 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
				defaultInterpolatedStringHandler.AppendLiteral("耐久: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(component.GetDurabilityValue());
				text = str21 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\n\n";
			}
			AnimalStateMachineComponent component10 = entity.GetComponent<AnimalStateMachineComponent>();
			if (component10 != null)
			{
				EAnimalEcologicalState eanimalEcologicalState = component10.CurrentState();
				EAnimalPerformState tsState = AnimalStateMachineComponent.GetTsState(eanimalEcologicalState);
				string str22 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 2);
				defaultInterpolatedStringHandler.AppendLiteral("动物状态: ");
				defaultInterpolatedStringHandler.AppendFormatted<EAnimalEcologicalState>(eanimalEcologicalState);
				defaultInterpolatedStringHandler.AppendLiteral("-");
				defaultInterpolatedStringHandler.AppendFormatted(AnimalStateMachineComponent.GetStateName(tsState));
				text = str22 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\n\n";
			}
			Aki.Protocol.Vector initLocation = component.GetInitLocation();
			if (initLocation != null)
			{
				string str23 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 3);
				defaultInterpolatedStringHandler.AppendLiteral("初始位置: [");
				defaultInterpolatedStringHandler.AppendFormatted<float>(initLocation.X, "F2");
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted<float>(initLocation.Y, "F2");
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted<float>(initLocation.Z, "F2");
				defaultInterpolatedStringHandler.AppendLiteral("]");
				text = str23 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\n\n";
			}
			global::Vector vector = (component2 != null) ? component2.ActorLocationProxy : null;
			if (vector != null)
			{
				string str24 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 3);
				defaultInterpolatedStringHandler.AppendLiteral("当前位置: [");
				defaultInterpolatedStringHandler.AppendFormatted<double>(vector.X, "F2");
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted<double>(vector.Y, "F2");
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted<double>(vector.Z, "F2");
				defaultInterpolatedStringHandler.AppendLiteral("]");
				text = str24 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += "\n\n";
			}
			AActor aactor = (component2 != null) ? component2.Owner : null;
			if (aactor != null)
			{
				FVectorDouble fvectorDouble = aactor.D_GetVelocity();
				string str25 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 3);
				defaultInterpolatedStringHandler.AppendLiteral("Self Velocity: [");
				defaultInterpolatedStringHandler.AppendFormatted<double>(fvectorDouble.X, "F2");
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted<double>(fvectorDouble.Y, "F2");
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted<double>(fvectorDouble.Z, "F2");
				defaultInterpolatedStringHandler.AppendLiteral("]");
				text = str25 + defaultInterpolatedStringHandler.ToStringAndClear();
				text += this.GetChildActorVelocity(aactor, 1);
				text += "\n\n";
			}
			SceneItemMoveComponent component11 = entity.GetComponent<SceneItemMoveComponent>();
			if (component11 != null)
			{
				text += "SceneItemMove信息:\n";
				text += component11.GetDebugString();
				text += "\n\n";
			}
			SceneItemAiRacingMoveComponent component12 = entity.GetComponent<SceneItemAiRacingMoveComponent>();
			if (component12 != null)
			{
				text += "Ai追逐信息:\n";
				text += component12.GetDebugString();
				text += "\n\n";
			}
			PawnTimeScaleComponent component13 = entity.GetComponent<PawnTimeScaleComponent>();
			if (component13 != null)
			{
				text += "TimeScale信息:\n";
				text += component13.GetDebugString();
				text += "\n\n";
			}
			SceneItemSunSpiritGearComponent component14 = entity.GetComponent<SceneItemSunSpiritGearComponent>();
			if (component14 != null)
			{
				text += "日灵机关信息:\n";
				text += component14.GetDebugString();
				text += "\n\n";
			}
			return text;
		}

		// Token: 0x0603131A RID: 201498 RVA: 0x00C4062C File Offset: 0x00C3E82C
		private string GetChildActorVelocity(AActor actor, int tier = 1)
		{
			string text = "";
			TArray<AActor> tarray = new TArray<AActor>();
			actor.GetAttachedActors(ref tarray, true);
			for (int i = 0; i < tarray.Num(); i++)
			{
				AActor aactor = tarray.Get(i);
				FVectorDouble fvectorDouble = aactor.D_GetVelocity();
				text += "\n";
				int num = tier;
				while (num-- > 0)
				{
					text += "\t\t";
				}
				text = text + "[" + UKismetSystemLibrary.GetDisplayName(aactor) + "] Velocity: ";
				string str = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 3);
				defaultInterpolatedStringHandler.AppendLiteral("[");
				defaultInterpolatedStringHandler.AppendFormatted<double>(fvectorDouble.X);
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted<double>(fvectorDouble.Y);
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted<double>(fvectorDouble.Z);
				defaultInterpolatedStringHandler.AppendLiteral("]");
				text = str + defaultInterpolatedStringHandler.ToStringAndClear();
				text += this.GetChildActorVelocity(aactor, tier + 1);
			}
			return text;
		}

		// Token: 0x0603131B RID: 201499 RVA: 0x00C40738 File Offset: 0x00C3E938
		public string GetInteractionDebugInfos(int entityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return "无";
			}
			string text = "";
			PawnSensoryInfoComponent component = entity.GetComponent<PawnSensoryInfoComponent>();
			if (component != null)
			{
				text += component.GetDebugString();
			}
			PawnPerceptionComponent component2 = entity.GetComponent<PawnPerceptionComponent>();
			if (component2 != null)
			{
				text += component2.GetDebugString();
			}
			text += "\n";
			PawnInteractNewComponent component3 = entity.GetComponent<PawnInteractNewComponent>();
			if (component3 == null)
			{
				return text;
			}
			PawnInteractController interactController = component3.GetInteractController();
			if (interactController == null)
			{
				return text;
			}
			return text + interactController.GetInteractionDebugInfos();
		}

		// Token: 0x0603131C RID: 201500 RVA: 0x00C407C4 File Offset: 0x00C3E9C4
		public string GetEntityCommonTagDebugString(int entityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return "无";
			}
			BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
			string text;
			if (component == null)
			{
				text = null;
			}
			else
			{
				string tagDebugStrings = component.GetTagDebugStrings();
				text = ((tagDebugStrings != null) ? tagDebugStrings.Trim() : null);
			}
			string text2 = text;
			if (string.IsNullOrEmpty(text2))
			{
				text2 = "无";
			}
			return text2;
		}

		// Token: 0x0603131D RID: 201501 RVA: 0x00C40814 File Offset: 0x00C3EA14
		public string GetInRangeLocalEntityListDebugString(int entityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return "无";
			}
			CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent component = entity.GetComponent<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>();
			IReadOnlyDictionary<int, EntityHandle> readOnlyDictionary = (component != null) ? component.GetEntitiesInRangeLocal() : null;
			string text = "";
			if (readOnlyDictionary != null && readOnlyDictionary.Count > 0)
			{
				foreach (KeyValuePair<int, EntityHandle> keyValuePair in readOnlyDictionary)
				{
					WorldEntity entity2 = keyValuePair.Value.Entity;
					BaseActorComponent baseActorComponent = (entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null;
					WorldEntity entity3 = keyValuePair.Value.Entity;
					CreatureDataComponent creatureDataComponent = (entity3 != null) ? entity3.GetComponent<CreatureDataComponent>() : null;
					int? num = (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null;
					string str = "[";
					string str2 = ((num != null) ? num.GetValueOrDefault().ToString() : null) ?? "?";
					string str3 = "] ";
					string text2;
					if (baseActorComponent == null)
					{
						text2 = null;
					}
					else
					{
						AActor owner = baseActorComponent.Owner;
						text2 = ((owner != null) ? owner.GetName() : null);
					}
					string text3 = str + str2 + str3 + (text2 ?? "?");
					PawnInfoManageComponent component2 = entity.GetComponent<PawnInfoManageComponent>();
					string str4 = text3;
					string str5 = " (";
					string str6;
					if ((str6 = ((component2 != null) ? component2.PawnName : null)) == null)
					{
						string text4;
						if (creatureDataComponent == null)
						{
							text4 = null;
						}
						else
						{
							BaseInfoComponent baseInfo = creatureDataComponent.GetBaseInfo();
							text4 = ((baseInfo != null) ? baseInfo.TidName : null);
						}
						str6 = (text4 ?? "无名字");
					}
					text3 = str4 + str5 + str6 + ")";
					text = text + text3 + "\n";
				}
				text = text.TrimEnd();
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "无";
			}
			return text;
		}

		// Token: 0x0603131E RID: 201502 RVA: 0x00C409C8 File Offset: 0x00C3EBC8
		public string GetInRangeOnlineEntityListDebugString(int entityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return "无";
			}
			CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent component = entity.GetComponent<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>();
			IReadOnlyDictionary<int, EntityHandle> readOnlyDictionary = (component != null) ? component.GetEntitiesInRangeOnline() : null;
			string text = "";
			if (readOnlyDictionary != null && readOnlyDictionary.Count > 0)
			{
				foreach (KeyValuePair<int, EntityHandle> keyValuePair in readOnlyDictionary)
				{
					WorldEntity entity2 = keyValuePair.Value.Entity;
					BaseActorComponent baseActorComponent = (entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null;
					WorldEntity entity3 = keyValuePair.Value.Entity;
					CreatureDataComponent creatureDataComponent = (entity3 != null) ? entity3.GetComponent<CreatureDataComponent>() : null;
					int? num = (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null;
					string str = "[";
					string str2 = ((num != null) ? num.GetValueOrDefault().ToString() : null) ?? "?";
					string str3 = "] ";
					string text2;
					if (baseActorComponent == null)
					{
						text2 = null;
					}
					else
					{
						AActor owner = baseActorComponent.Owner;
						text2 = ((owner != null) ? owner.GetName() : null);
					}
					string text3 = str + str2 + str3 + (text2 ?? "?");
					PawnInfoManageComponent component2 = entity.GetComponent<PawnInfoManageComponent>();
					string str4 = text3;
					string str5 = " (";
					string str6;
					if ((str6 = ((component2 != null) ? component2.PawnName : null)) == null)
					{
						string text4;
						if (creatureDataComponent == null)
						{
							text4 = null;
						}
						else
						{
							BaseInfoComponent baseInfo = creatureDataComponent.GetBaseInfo();
							text4 = ((baseInfo != null) ? baseInfo.TidName : null);
						}
						str6 = (text4 ?? "无名字");
					}
					text3 = str4 + str5 + str6 + ")";
					text = text + text3 + "\n";
				}
				text = text.TrimEnd();
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "无";
			}
			return text;
		}

		// Token: 0x0603131F RID: 201503 RVA: 0x00C40B7C File Offset: 0x00C3ED7C
		public string GetInRangeActorListDebugString(int entityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return "无";
			}
			CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent component = entity.GetComponent<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>();
			IReadOnlyCollection<AActor> readOnlyCollection = (component != null) ? component.GetActorsInRangeLocal() : null;
			string text = "";
			if (readOnlyCollection != null && readOnlyCollection.Count > 0)
			{
				foreach (AActor aactor in readOnlyCollection)
				{
					if (aactor != null && aactor.IsValid())
					{
						text = text + UKismetSystemLibrary.GetDisplayName(aactor) + "\n";
					}
				}
				text = text.TrimEnd();
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "无";
			}
			return text;
		}

		// Token: 0x06031320 RID: 201504 RVA: 0x00C40C34 File Offset: 0x00C3EE34
		[NullableContext(2)]
		public AActor GetDebugEntityActor(int entityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return null;
			}
			BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
			if (component == null)
			{
				return null;
			}
			return component.Owner;
		}

		// Token: 0x06031321 RID: 201505 RVA: 0x00C40C64 File Offset: 0x00C3EE64
		[NullableContext(2)]
		public string GetDebugEntityName(int entityId)
		{
			if (this.EntityNameMap == null)
			{
				this.GetDebugEntityNameList();
			}
			string result;
			if (!this.EntityNameMap.TryGetValue(entityId, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x06031322 RID: 201506 RVA: 0x00C40C94 File Offset: 0x00C3EE94
		public int GetEntityPbDataId(int entityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return 0;
			}
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component == null)
			{
				return 0;
			}
			return component.GetPbDataId();
		}

		// Token: 0x06031323 RID: 201507 RVA: 0x00C40CC4 File Offset: 0x00C3EEC4
		public float GetEntityTimeScale(int entityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return -1f;
			}
			PawnTimeScaleComponent component = entity.GetComponent<PawnTimeScaleComponent>();
			if (component == null)
			{
				return -1f;
			}
			return component.CurrentTimeScale;
		}

		// Token: 0x06031324 RID: 201508 RVA: 0x00C40CFC File Offset: 0x00C3EEFC
		public void SetEntityTimeScale(int entityId, float timeScale)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return;
			}
			PawnTimeScaleComponent component = entity.GetComponent<PawnTimeScaleComponent>();
			if (component == null)
			{
				return;
			}
			int num;
			if (this.EntityTimeScaleHandleIdMap.TryGetValue(entityId, out num))
			{
				component.RemoveTimeScale(num);
				this.EntityTimeScaleHandleIdMap.Remove(entityId);
			}
			num = component.SetTimeScale(int.MaxValue, timeScale, null, float.PositiveInfinity, ETimeScaleSourceType.DefaultTimeScale, false, false);
			this.EntityTimeScaleHandleIdMap[entityId] = num;
		}

		// Token: 0x0401C4F1 RID: 115953
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> EntityNameList;

		// Token: 0x0401C4F2 RID: 115954
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<string, int> EntityIdMap;

		// Token: 0x0401C4F3 RID: 115955
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, string> EntityNameMap;

		// Token: 0x0401C4F4 RID: 115956
		private readonly Dictionary<int, int> EntityTimeScaleHandleIdMap = new Dictionary<int, int>();
	}
}
