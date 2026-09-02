using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move.AssistedWalk;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BEA RID: 27626
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventSetNpcGroupPerform : LevelEventBase
	{
		// Token: 0x060440E1 RID: 278753 RVA: 0x011A9F07 File Offset: 0x011A8107
		public LevelEventSetNpcGroupPerform(int id) : base(id)
		{
		}

		// Token: 0x060440E2 RID: 278754 RVA: 0x011A9F1C File Offset: 0x011A811C
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			this.Params = (inParams as SetNpcGroupPerform);
			this.Context = context;
			ISetNpcGroupPerformType performType = this.Params.PerformType;
			ENpcGroupPerformType type = this.Params.PerformType.Type;
			if (type == ENpcGroupPerformType.HandInHand)
			{
				base.FinishExecute(this.EnterHandInHand(performType as ISetNpcHandInHandPerform), false, true);
				return;
			}
			if (type == ENpcGroupPerformType.TwoPersonPerformance)
			{
				this.EnterGroupPerform(performType as ISetNpcTwoPersonPerform);
				return;
			}
			if (type != ENpcGroupPerformType.SupportedWalking)
			{
				return;
			}
			base.FinishExecute(this.EnterAssistedWalkGroupPerform(performType as ISetNpcSupportedWalkingPerform), false, true);
		}

		// Token: 0x060440E3 RID: 278755 RVA: 0x011A9F9C File Offset: 0x011A819C
		protected override void ExecuteWhenEntitiesReady()
		{
			SetNpcGroupPerform @params = this.Params;
			GeneralContext context = this.Context;
			if (@params == null || context == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			ISetNpcGroupPerformType performType = @params.PerformType;
			ENpcGroupPerformType type = performType.Type;
			if (type != ENpcGroupPerformType.HandInHand)
			{
				if (type != ENpcGroupPerformType.TwoPersonPerformance)
				{
					if (type != ENpcGroupPerformType.SupportedWalking)
					{
						return;
					}
					bool value = this.ExecuteNpcAssistedWalkPerform(@params, context);
					base.FinishExecute(value, false, true);
				}
				else
				{
					ISetNpcTwoPersonPerform setNpcTwoPersonPerform = performType as ISetNpcTwoPersonPerform;
					if (!this.ExecuteNpcGroupPerform(setNpcTwoPersonPerform, setNpcTwoPersonPerform.GroupPerformMark))
					{
						base.FinishExecute(false, false, true);
						return;
					}
				}
				return;
			}
			bool value2 = this.ExecuteNpcHandInHandPerform(@params, context);
			base.FinishExecute(value2, false, true);
		}

		// Token: 0x060440E4 RID: 278756 RVA: 0x011AA02F File Offset: 0x011A822F
		private bool EnterGroupPerform(ISetNpcTwoPersonPerform perform)
		{
			if (perform == null || perform.Target == 0)
			{
				return false;
			}
			base.CreateWaitEntityTask(perform.Target);
			return true;
		}

		// Token: 0x060440E5 RID: 278757 RVA: 0x011AA04C File Offset: 0x011A824C
		private unsafe NpcGroupPerformConfig? GetGroupPerformConfig(ISetNpcTwoPersonPerform perform, string mark)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			int? num = (characterActorComponent != null) ? new int?(characterActorComponent.CreatureData.GetPbDataId()) : null;
			bool flag = characterActorComponent == null;
			if (!flag)
			{
				bool flag2 = (num ?? 0) == 0;
				flag = flag2;
			}
			if (flag)
			{
				return null;
			}
			int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(num.Value);
			IReadOnlyList<NpcGroupPerformConfig> configList = ConfigNpcGroupPerformConfigByRoleIdAndNpcPerformMark.GetConfigList(mark, baseRoleId, perform.NpcType.ToEnumString(), true);
			if (ModelBase<RoleModel>.Instance.IsMainRole(baseRoleId) && (configList == null || configList.Count == 0))
			{
				foreach (MainRoleConfig mainRoleConfig in ConfigBase<RoleConfig>.Instance.GetAllMainRoleConfig())
				{
					if (mainRoleConfig.Id != baseRoleId)
					{
						configList = ConfigNpcGroupPerformConfigByRoleIdAndNpcPerformMark.GetConfigList(mark, mainRoleConfig.Id, perform.NpcType.ToEnumString(), true);
						if (configList != null && configList.Count > 0)
						{
							break;
						}
					}
				}
			}
			if (configList == null || configList.Count == 0)
			{
				return null;
			}
			if (configList.Count > 1)
			{
				string text = "";
				foreach (NpcGroupPerformConfig npcGroupPerformConfig in configList)
				{
					text = text + "[Id: " + npcGroupPerformConfig.Id.ToString() + "]";
				}
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[LevelEventSetNpcGroupPerform] 进行NPC组合表演时无法唯一确定一条选项，默认选择第一条匹配项";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PerformType", mark);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RoleId", baseRoleId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("NpcType", perform.NpcType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("configList", text);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
			NpcGroupPerformConfig value = configList[0];
			if (value.RelativeOffsetLength < 3)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Character;
				ELogAuthor author2 = ELogAuthor.CWZ;
				string message2 = "[LevelEventSetNpcGroupPerform] NPC组合表演配置项RelativeOffset异常";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("configId", value.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PerformType", mark);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("RoleId", baseRoleId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("GroupPerformMark", perform.GroupPerformMark);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("RelativeOffset", value.GetRelativeOffsetArray());
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 5));
				return null;
			}
			return new NpcGroupPerformConfig?(value);
		}

		// Token: 0x060440E6 RID: 278758 RVA: 0x011AA368 File Offset: 0x011A8568
		private bool ExecuteNpcGroupPerform(ISetNpcTwoPersonPerform perform, string mark)
		{
			LevelEventSetNpcGroupPerform.<>c__DisplayClass8_0 CS$<>8__locals1 = new LevelEventSetNpcGroupPerform.<>c__DisplayClass8_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.perform = perform;
			if (CS$<>8__locals1.perform == null || CS$<>8__locals1.perform.Target == 0)
			{
				return false;
			}
			if (CS$<>8__locals1.perform.Initiator.Type != ENpcGroupPerformInitiatorType.Player)
			{
				return false;
			}
			CS$<>8__locals1.config = this.GetGroupPerformConfig(CS$<>8__locals1.perform, mark);
			if (CS$<>8__locals1.config == null)
			{
				return false;
			}
			this.CacheVector.Set((double)CS$<>8__locals1.config.Value.RelativeOffset(0), (double)CS$<>8__locals1.config.Value.RelativeOffset(1), (double)CS$<>8__locals1.config.Value.RelativeOffset(2));
			CS$<>8__locals1.npc = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(CS$<>8__locals1.perform.Target);
			LevelEventSetNpcGroupPerform.<>c__DisplayClass8_0 CS$<>8__locals2 = CS$<>8__locals1;
			EntityHandle npc = CS$<>8__locals1.npc;
			BaseActorComponent npcActor;
			if (npc == null)
			{
				npcActor = null;
			}
			else
			{
				WorldEntity entity = npc.Entity;
				npcActor = ((entity != null) ? entity.GetComponent<BaseActorComponent>() : null);
			}
			CS$<>8__locals2.npcActor = npcActor;
			EntityHandle npc2 = CS$<>8__locals1.npc;
			PawnInteractNewComponent pawnInteractNewComponent;
			if (npc2 == null)
			{
				pawnInteractNewComponent = null;
			}
			else
			{
				WorldEntity entity2 = npc2.Entity;
				pawnInteractNewComponent = ((entity2 != null) ? entity2.GetComponent<PawnInteractNewComponent>() : null);
			}
			PawnInteractNewComponent pawnInteractNewComponent2 = pawnInteractNewComponent;
			if (CS$<>8__locals1.npc == null || CS$<>8__locals1.npcActor == null || pawnInteractNewComponent2 == null)
			{
				return false;
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget<ERemoveEntityType, EntityHandle>(CS$<>8__locals1.npc, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(CS$<>8__locals1.npc, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			object obj;
			if (baseCharacter == null)
			{
				obj = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				obj = ((characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<CharacterCustomActionComponent>() : null);
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				obj2.AddCustomSetCollision(CS$<>8__locals1.npcActor, true, null);
			}
			pawnInteractNewComponent2.AddWaitNpcTurnCompleteCallback(delegate
			{
				CS$<>8__locals1.<>4__this.MoveToGroupPerformLocation(CS$<>8__locals1.npc, CS$<>8__locals1.npcActor, CS$<>8__locals1.config.Value, CS$<>8__locals1.perform.WaitInteractNpcType);
			});
			return true;
		}

		// Token: 0x060440E7 RID: 278759 RVA: 0x011AA520 File Offset: 0x011A8720
		private unsafe void MoveToGroupPerformLocation(EntityHandle npc, BaseActorComponent npcActor, NpcGroupPerformConfig config, EWaitInteractNpcMontageWaitType? interactType = null)
		{
			LevelEventSetNpcGroupPerform.<>c__DisplayClass9_0 CS$<>8__locals1 = new LevelEventSetNpcGroupPerform.<>c__DisplayClass9_0();
			CS$<>8__locals1.config = config;
			CS$<>8__locals1.npcActor = npcActor;
			CS$<>8__locals1.interactType = interactType;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.npc = npc;
			LevelEventSetNpcGroupPerform.<>c__DisplayClass9_0 CS$<>8__locals2 = CS$<>8__locals1;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CS$<>8__locals2.playerActor = ((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null);
			CharacterActorComponent playerActor = CS$<>8__locals1.playerActor;
			if (playerActor == null || !playerActor.Valid || !CS$<>8__locals1.npcActor.Valid)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(CS$<>8__locals1.playerActor.CreatureData.GetPbDataId());
			CS$<>8__locals1.actComp = CS$<>8__locals1.playerActor.Entity.GetComponent<CharacterCustomActionComponent>();
			CS$<>8__locals1.npcActComp = CS$<>8__locals1.npcActor.Entity.GetComponent<CharacterCustomActionComponent>();
			if (CS$<>8__locals1.actComp == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			FTransformDouble actorTransform = CS$<>8__locals1.npcActor.ActorTransform;
			FVectorDouble fvectorDouble = this.CacheVector.ToUeVector(false);
			FVectorDouble fvectorDouble2 = actorTransform.TransformVector(fvectorDouble);
			this.CacheVector.DeepCopy(fvectorDouble2);
			this.CacheVector.AdditionEqual(CS$<>8__locals1.npcActor.ActorLocationProxy);
			bool flag = ModelBase<RoleModel>.Instance.IsMainRole(baseRoleId);
			if (!flag && baseRoleId != CS$<>8__locals1.config.RoleId)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[LevelEventSetNpcGroupPerform] 当前角色ID与配置表ID不符";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("currentId", baseRoleId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("configId", CS$<>8__locals1.config.RoleId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				base.FinishExecute(false, false, true);
				return;
			}
			CS$<>8__locals1.roleMontage = ((flag && ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? CS$<>8__locals1.config.MaleVariantMontage : CS$<>8__locals1.config.RoleMontage);
			if (CS$<>8__locals1.roleMontage == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			CharacterCustomActionComponent actComp = CS$<>8__locals1.actComp;
			if (actComp != null)
			{
				actComp.AddCustomSetPlayerControl(true, null);
			}
			CharacterCustomActionComponent actComp2 = CS$<>8__locals1.actComp;
			if (actComp2 == null)
			{
				return;
			}
			actComp2.AddCustomMoveToLocation(this.CacheVector, delegate
			{
				double num = Math.Atan2((double)(-(double)CS$<>8__locals1.config.RelativeOffset(1)), (double)(1f + CS$<>8__locals1.config.RelativeOffset(0))) * 57.295780181884766;
				CharacterCustomActionComponent npcActComp = CS$<>8__locals1.npcActComp;
				if (npcActComp == null)
				{
					return;
				}
				BaseActorComponent playerActor2 = CS$<>8__locals1.playerActor;
				double angle = num;
				ECustomSetRotationType type = ECustomSetRotationType.FaceToTarget;
				Action callback;
				if ((callback = CS$<>8__locals1.<>9__1) == null)
				{
					callback = (CS$<>8__locals1.<>9__1 = delegate()
					{
						CharacterCustomActionComponent actComp3 = CS$<>8__locals1.actComp;
						if (actComp3 == null)
						{
							return;
						}
						BaseActorComponent npcActor2 = CS$<>8__locals1.npcActor;
						double angle2 = (double)CS$<>8__locals1.config.RelativeZRotation;
						ECustomSetRotationType type2 = ECustomSetRotationType.TargetForward;
						Action callback2;
						if ((callback2 = CS$<>8__locals1.<>9__2) == null)
						{
							callback2 = (CS$<>8__locals1.<>9__2 = delegate()
							{
								CharacterCustomActionComponent npcActComp2 = CS$<>8__locals1.npcActComp;
								if (npcActComp2 == null)
								{
									return;
								}
								EWaitInteractNpcMontageWaitType? interactType2 = CS$<>8__locals1.interactType;
								EWaitInteractNpcMontageWaitType ewaitInteractNpcMontageWaitType = EWaitInteractNpcMontageWaitType.WaitForMontage;
								bool waitEnd = interactType2.GetValueOrDefault() == ewaitInteractNpcMontageWaitType & interactType2 != null;
								bool waitLoop = CS$<>8__locals1.interactType.GetValueOrDefault() == EWaitInteractNpcMontageWaitType.WaitForMontageLoop;
								Action callback3;
								if ((callback3 = CS$<>8__locals1.<>9__3) == null)
								{
									callback3 = (CS$<>8__locals1.<>9__3 = delegate()
									{
										CharacterCustomActionComponent npcActComp3 = CS$<>8__locals1.npcActComp;
										if (npcActComp3 == null)
										{
											return;
										}
										string npcMontage = CS$<>8__locals1.config.NpcMontage;
										int? montageId = new int?(CS$<>8__locals1.config.NpcAbpMontageId);
										Action onPlayMontage;
										if ((onPlayMontage = CS$<>8__locals1.<>9__4) == null)
										{
											onPlayMontage = (CS$<>8__locals1.<>9__4 = delegate()
											{
												CharacterCustomActionComponent actComp4 = CS$<>8__locals1.actComp;
												if (actComp4 == null)
												{
													return;
												}
												actComp4.AddCustomPlayMontage(CS$<>8__locals1.roleMontage, null, null, null, null);
											});
										}
										Action onStopMontage;
										if ((onStopMontage = CS$<>8__locals1.<>9__5) == null)
										{
											onStopMontage = (CS$<>8__locals1.<>9__5 = delegate()
											{
												CS$<>8__locals1.<>4__this.OnGroupPerformFinish(CS$<>8__locals1.npc);
											});
										}
										npcActComp3.AddCustomPlayMontage(npcMontage, montageId, onPlayMontage, onStopMontage, null);
									});
								}
								npcActComp2.AddCustomWaitMontageEnd(waitEnd, waitLoop, callback3);
							});
						}
						actComp3.AddCustomSetTurnToTarget(npcActor2, angle2, type2, callback2, null);
					});
				}
				npcActComp.AddCustomSetTurnToTarget(playerActor2, angle, type, callback, null);
			}, null);
		}

		// Token: 0x060440E8 RID: 278760 RVA: 0x011AA744 File Offset: 0x011A8944
		[NullableContext(2)]
		private void OnGroupPerformFinish(EntityHandle npc)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterCustomActionComponent characterCustomActionComponent;
			if (baseCharacter == null)
			{
				characterCustomActionComponent = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				characterCustomActionComponent = ((characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<CharacterCustomActionComponent>() : null);
			}
			CharacterCustomActionComponent characterCustomActionComponent2 = characterCustomActionComponent;
			BaseActorComponent baseActorComponent;
			if (npc == null)
			{
				baseActorComponent = null;
			}
			else
			{
				WorldEntity entity = npc.Entity;
				baseActorComponent = ((entity != null) ? entity.GetComponent<BaseActorComponent>() : null);
			}
			BaseActorComponent baseActorComponent2 = baseActorComponent;
			if (baseActorComponent2 != null && characterCustomActionComponent2 != null)
			{
				characterCustomActionComponent2.AddCustomSetCollision(baseActorComponent2, false, null);
			}
			if (characterCustomActionComponent2 != null)
			{
				characterCustomActionComponent2.AddCustomSetPlayerControl(false, null);
			}
			if (npc != null && Singleton<EventSystem>.Instance.HasWithTarget<ERemoveEntityType, EntityHandle>(npc, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<ERemoveEntityType, EntityHandle>(npc, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x060440E9 RID: 278761 RVA: 0x011AA7EE File Offset: 0x011A89EE
		private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
		{
			this.OnGroupPerformFinish(handle);
		}

		// Token: 0x060440EA RID: 278762 RVA: 0x011AA7F8 File Offset: 0x011A89F8
		private bool EnterHandInHand(ISetNpcHandInHandPerform perform)
		{
			if (perform == null || perform.Follower == 0)
			{
				return false;
			}
			IHandInHandInitiatorType initiator = perform.Initiator.Initiator;
			EHandInHandInitiatorType type = initiator.Type;
			if (type == EHandInHandInitiatorType.Player)
			{
				base.CreateWaitEntityTask(perform.Follower);
				return true;
			}
			if (type != EHandInHandInitiatorType.Entity)
			{
				return false;
			}
			IEntityHandInHandInitiator entityHandInHandInitiator = initiator as IEntityHandInHandInitiator;
			if (entityHandInHandInitiator.EntityId == 0)
			{
				return false;
			}
			base.CreateWaitEntityTask(new List<int>
			{
				perform.Follower,
				entityHandInHandInitiator.EntityId
			});
			return true;
		}

		// Token: 0x060440EB RID: 278763 RVA: 0x011AA874 File Offset: 0x011A8A74
		private bool ExecuteNpcHandInHandPerform(SetNpcGroupPerform params_, GeneralContext context)
		{
			ISetNpcHandInHandPerform setNpcHandInHandPerform = params_.PerformType as ISetNpcHandInHandPerform;
			EntityHandle initiatorEntityHandle = this.GetInitiatorEntityHandle(setNpcHandInHandPerform.Initiator.Initiator);
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(setNpcHandInHandPerform.Follower);
			if (initiatorEntityHandle == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Character, ELogAuthor.LJF, "[LevelEventSetNpcGroupPerform] 无法获取牵手发起者", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (entityByPbDataId == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Character, ELogAuthor.LJF, "[LevelEventSetNpcGroupPerform] 无法获取牵手目标", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			int handType = (int)setNpcHandInHandPerform.Initiator.HandType;
			bool? isWaitActionFinish = params_.IsWaitActionFinish;
			ControllerBase<HoldingHandsController>.Instance.RequestHoldHands(params_.Key, initiatorEntityHandle, entityByPbDataId, (global::EHandType)handType, isWaitActionFinish, true, "关卡行为");
			return true;
		}

		// Token: 0x060440EC RID: 278764 RVA: 0x011AA924 File Offset: 0x011A8B24
		[return: Nullable(2)]
		private EntityHandle GetInitiatorEntityHandle(IHandInHandInitiatorType target)
		{
			EHandInHandInitiatorType type = target.Type;
			if (type == EHandInHandInitiatorType.Player)
			{
				return ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			}
			if (type == EHandInHandInitiatorType.Entity)
			{
				return ModelBase<CreatureModel>.Instance.GetEntityByPbDataId((target as IEntityHandInHandInitiator).EntityId);
			}
			return null;
		}

		// Token: 0x060440ED RID: 278765 RVA: 0x011AA961 File Offset: 0x011A8B61
		private bool EnterAssistedWalkGroupPerform(ISetNpcSupportedWalkingPerform perform)
		{
			if (perform == null || perform.Target == 0)
			{
				return false;
			}
			base.CreateWaitEntityTask(perform.Target);
			return true;
		}

		// Token: 0x060440EE RID: 278766 RVA: 0x011AA980 File Offset: 0x011A8B80
		private unsafe bool ExecuteNpcAssistedWalkPerform(SetNpcGroupPerform params_, GeneralContext context)
		{
			ISetNpcSupportedWalkingPerform setNpcSupportedWalkingPerform = params_.PerformType as ISetNpcSupportedWalkingPerform;
			if (setNpcSupportedWalkingPerform.Initiator.Type != ENpcGroupPerformInitiatorType.Player)
			{
				return false;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(setNpcSupportedWalkingPerform.Target);
			if (getCurrentEntity == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Character, ELogAuthor.CWZ, "[LevelEventSetNpcGroupPerform] 无法获取搀扶发起者", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (entityByPbDataId == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Character, ELogAuthor.CWZ, "[LevelEventSetNpcGroupPerform] 无法获取搀扶目标", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			bool? isWaitActionFinish = params_.IsWaitActionFinish;
			WorldEntity entity = getCurrentEntity.Entity;
			CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
			WorldEntity entity2 = entityByPbDataId.Entity;
			BaseActorComponent baseActorComponent = (entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null;
			WorldEntity entity3 = entityByPbDataId.Entity;
			BaseMoveComponent baseMoveComponent = (entity3 != null) ? entity3.GetComponent<BaseMoveComponent>() : null;
			if (characterActorComponent != null && characterActorComponent.Valid && baseActorComponent != null && baseActorComponent.Valid && baseMoveComponent != null)
			{
				Singleton<AssistedWalkUtils>.Instance.RequestStartAssistedWalk(params_.Key, characterActorComponent, baseActorComponent, baseMoveComponent, "/Game/Aki/Data/Level/AssistedWalk/DA_DefaultAssistedWalkConfig.DA_DefaultAssistedWalkConfig", isWaitActionFinish.GetValueOrDefault(), "关卡行为", global::EHandType.Right);
				return true;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[LevelEventSetNpcGroupPerform] 搀扶前置编排失败：Leader / Follower 组件无效";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LeaderValid", (characterActorComponent != null) ? new bool?(characterActorComponent.Valid) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FollowerValid", (baseActorComponent != null) ? new bool?(baseActorComponent.Valid) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FollowerMoveComp", baseMoveComponent != null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}

		// Token: 0x04026074 RID: 155764
		private readonly global::Vector CacheVector = global::Vector.Create();

		// Token: 0x04026075 RID: 155765
		[Nullable(2)]
		private SetNpcGroupPerform Params;

		// Token: 0x04026076 RID: 155766
		[Nullable(2)]
		private GeneralContext Context;
	}
}
