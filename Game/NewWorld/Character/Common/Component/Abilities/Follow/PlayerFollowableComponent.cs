using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Data.Fight.Enum;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Utils.Command;
using CSharpScript.Game.Utils.ResponsibilityChain;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x0200497F RID: 18815
	[NullableContext(2)]
	[Nullable(0)]
	public class PlayerFollowableComponent : EntityComponent, IFollowable, IStaticVariableResetter
	{
		// Token: 0x060312B7 RID: 201399 RVA: 0x00C3DF44 File Offset: 0x00C3C144
		static PlayerFollowableComponent()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PlayerFollowableComponent.CreateStaticDefaultValue), new Action(PlayerFollowableComponent.ResetStaticDefaultValue));
		}

		// Token: 0x060312B8 RID: 201400 RVA: 0x00C3DF9C File Offset: 0x00C3C19C
		public static void CreateStaticDefaultValue()
		{
			PlayerFollowableComponent.getHandlerTypeChain = new RegardAsFollowShooterHandler();
			PlayerFollowableComponent.getHandlerTypeChain.SetNext(new RegardAsVehicleHandler());
			PlayerFollowableComponent.FollowerHandlerFactory = new Dictionary<EPlayerFollowerHandlerType, OneOf<PlayerFollowerFollowShooterHandlerFactory, PlayerFollowerVehicleHandlerFactory>>
			{
				{
					EPlayerFollowerHandlerType.FollowShooter,
					new PlayerFollowerFollowShooterHandlerFactory()
				},
				{
					EPlayerFollowerHandlerType.Vehicle,
					new PlayerFollowerVehicleHandlerFactory()
				}
			};
		}

		// Token: 0x060312B9 RID: 201401 RVA: 0x00C3DFEF File Offset: 0x00C3C1EF
		public static void ResetStaticDefaultValue()
		{
			PlayerFollowableComponent.getHandlerTypeChain = null;
			PlayerFollowableComponent.FollowerHandlerFactory = null;
		}

		// Token: 0x060312BA RID: 201402 RVA: 0x00C3E000 File Offset: 0x00C3C200
		public IPlayerFollowerHandler GetOrCreateHandlerByCreatureDataId(long creatureDataId)
		{
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
			if (entity == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "[PlayerFollowableComponent] UpdatePlayerFollowers 无实体Handle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			EntityHandleParameterContext entityHandleParameterContext = new EntityHandleParameterContext(entity);
			PlayerFollowableComponent.getHandlerTypeChain.Handle(entityHandleParameterContext);
			if (entityHandleParameterContext.OutPlayerFollowerHandlerType == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Entity;
				ELogAuthor author2 = ELogAuthor.XDW;
				string message2 = "[PlayerFollowableComponent] UpdatePlayerFollowers 无handler类型";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			return this.GetOrCreateHandler(entityHandleParameterContext.OutPlayerFollowerHandlerType.Value);
		}

		// Token: 0x060312BB RID: 201403 RVA: 0x00C3E0AC File Offset: 0x00C3C2AC
		[NullableContext(1)]
		[return: Nullable(2)]
		public T GetOrCreateHandler<T>() where T : class, IPlayerFollowerHandler
		{
			EPlayerFollowerHandlerType handlerType;
			if (PlayerFollowableComponent.PlayerFollowerHandlerTypeNameToEnum.TryGetValue(typeof(T), out handlerType))
			{
				return this.GetOrCreateHandler(handlerType) as T;
			}
			return default(T);
		}

		// Token: 0x060312BC RID: 201404 RVA: 0x00C3E0EC File Offset: 0x00C3C2EC
		public IPlayerFollowerHandler GetOrCreateHandler(EPlayerFollowerHandlerType handlerType)
		{
			Dictionary<EPlayerFollowerHandlerType, IPlayerFollowerHandler> followerHandlesMap = this.FollowerHandlesMap;
			if (followerHandlesMap != null && followerHandlesMap.ContainsKey(handlerType))
			{
				return this.FollowerHandlesMap.GetValueOrDefault(handlerType);
			}
			OneOf<PlayerFollowerFollowShooterHandlerFactory, PlayerFollowerVehicleHandlerFactory>? valueOrNull = PlayerFollowableComponent.FollowerHandlerFactory.GetValueOrNull(handlerType);
			if (valueOrNull == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "[PlayerFollowableComponent] UpdatePlayerFollowers handler工厂旷工";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("HandlerType", handlerType);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			IPlayerFollowerHandler playerFollowerHandler2;
			if (!valueOrNull.Value.IsT1)
			{
				IPlayerFollowerHandler playerFollowerHandler = valueOrNull.Value.AsT2.Create(this.PlayerId);
				playerFollowerHandler2 = playerFollowerHandler;
			}
			else
			{
				IPlayerFollowerHandler playerFollowerHandler = valueOrNull.Value.AsT1.Create(this.PlayerId);
				playerFollowerHandler2 = playerFollowerHandler;
			}
			IPlayerFollowerHandler playerFollowerHandler3 = playerFollowerHandler2;
			if (playerFollowerHandler3 == null)
			{
				return null;
			}
			if (this.FollowerHandlesMap != null)
			{
				this.FollowerHandlesMap[handlerType] = playerFollowerHandler3;
			}
			return playerFollowerHandler3;
		}

		// Token: 0x060312BD RID: 201405 RVA: 0x00C3E1CC File Offset: 0x00C3C3CC
		protected override bool OnInitData(IEntityArgs args = null)
		{
			base.OnInitData(args);
			this.FollowersMap = new Dictionary<int, long>();
			this.FollowerHandlesMap = new Dictionary<EPlayerFollowerHandlerType, IPlayerFollowerHandler>();
			this.CommandInvoker = new CommandInvoker();
			CreatureDataComponent creatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
			this.PlayerId = ((creatureDataComponent != null) ? creatureDataComponent.GetPlayerId() : 0);
			foreach (EPlayerFollowerHandlerType handlerType in PlayerFollowableComponent.FollowerHandlerFactory.Keys)
			{
				this.GetOrCreateHandler(handlerType);
			}
			RepeatedField<PlayerFollowerPb> repeatedField;
			if (creatureDataComponent == null)
			{
				repeatedField = null;
			}
			else
			{
				PlayerFollowersComponentPb playerFollowersInfo = creatureDataComponent.PlayerFollowersInfo;
				repeatedField = ((playerFollowersInfo != null) ? playerFollowersInfo.ListPlayerFollowerPb : null);
			}
			RepeatedField<PlayerFollowerPb> repeatedField2 = repeatedField;
			if (repeatedField2 != null)
			{
				List<PlayerFollowerItemInfo> list = new List<PlayerFollowerItemInfo>();
				foreach (PlayerFollowerPb playerFollowerPb in repeatedField2)
				{
					if (playerFollowerPb != null)
					{
						list.Add(new PlayerFollowerItemInfo
						{
							Type = (int)playerFollowerPb.Type,
							EntityId = playerFollowerPb.EntityId
						});
					}
				}
				this.UpdatePlayerFollowers(list);
			}
			return true;
		}

		// Token: 0x060312BE RID: 201406 RVA: 0x00C3E2F8 File Offset: 0x00C3C4F8
		protected override bool OnClear()
		{
			Dictionary<int, long> followersMap = this.FollowersMap;
			if (followersMap != null)
			{
				followersMap.Clear();
			}
			this.FollowersMap = null;
			if (this.FollowerHandlesMap != null)
			{
				foreach (IPlayerFollowerHandler playerFollowerHandler in this.FollowerHandlesMap.Values)
				{
					playerFollowerHandler.OnClear();
				}
			}
			CommandInvoker commandInvoker = this.CommandInvoker;
			if (commandInvoker != null)
			{
				commandInvoker.ClearAllCommand();
			}
			this.CommandInvoker = null;
			Dictionary<EPlayerFollowerHandlerType, IPlayerFollowerHandler> followerHandlesMap = this.FollowerHandlesMap;
			if (followerHandlesMap != null)
			{
				followerHandlesMap.Clear();
			}
			this.FollowerHandlesMap = null;
			return base.OnClear();
		}

		// Token: 0x060312BF RID: 201407 RVA: 0x00C3E3A4 File Offset: 0x00C3C5A4
		[NullableContext(1)]
		public void UpdatePlayerFollowers(IEnumerable<IPlayerFollowerItemInfo> followers)
		{
			if (this.FollowersMap == null || this.FollowerHandlesMap == null)
			{
				return;
			}
			CommandInvoker commandInvoker = this.CommandInvoker;
			if (commandInvoker != null)
			{
				commandInvoker.ClearAllCommand();
			}
			foreach (IPlayerFollowerItemInfo playerFollowerItemInfo in followers)
			{
				long num = Singleton<MathUtils>.Instance.LongToNumber(playerFollowerItemInfo.EntityId);
				if (num <= 0L)
				{
					if (this.FollowersMap.ContainsKey(playerFollowerItemInfo.Type))
					{
						long valueOrDefault = this.FollowersMap.GetValueOrDefault(playerFollowerItemInfo.Type, 0L);
						this.FollowersMap.Remove(playerFollowerItemInfo.Type);
						IGameCommandWithReceivers<ICommandTypeRemoveFollower> gameCommandWithReceivers = GameCommandFactory.CreateGameCommandWithReceivers<ICommandTypeRemoveFollower>(new TCommandHandleParamsRemoveFollower
						{
							CreatureDataId = valueOrDefault
						});
						foreach (IPlayerFollowerHandler playerFollowerHandler in this.FollowerHandlesMap.Values)
						{
							gameCommandWithReceivers.AddReceiver(playerFollowerHandler.RemoveFollowerReceiver());
						}
						CommandInvoker commandInvoker2 = this.CommandInvoker;
						if (commandInvoker2 != null)
						{
							commandInvoker2.SubmitCommand<ICommandTypeRemoveFollower>(gameCommandWithReceivers, false);
						}
					}
				}
				else
				{
					this.FollowersMap[playerFollowerItemInfo.Type] = num;
				}
			}
			foreach (KeyValuePair<int, long> keyValuePair in this.FollowersMap)
			{
				int num2;
				long num3;
				keyValuePair.Deconstruct(out num2, out num3);
				int key = num2;
				long creatureDataId = num3;
				int? valueOrNull = FollowDefine.PlayerFollowerPriority.GetValueOrNull(key);
				IGameCommandWithReceivers<ICommandTypeAddFollower> gameCommandWithReceivers2 = GameCommandFactory.CreateGameCommandWithReceivers<ICommandTypeAddFollower>(new TCommandHandleParamsAddFollower
				{
					PlayerFollowerInfo = new PlayerFollowerInfo(creatureDataId, valueOrNull)
				});
				foreach (IPlayerFollowerHandler playerFollowerHandler2 in this.FollowerHandlesMap.Values)
				{
					gameCommandWithReceivers2.AddReceiver(playerFollowerHandler2.AddFollowerReceiver());
				}
				CommandInvoker commandInvoker3 = this.CommandInvoker;
				if (commandInvoker3 != null)
				{
					commandInvoker3.SubmitCommand<ICommandTypeAddFollower>(gameCommandWithReceivers2, false);
				}
			}
			IGameCommandWithReceivers<ICommandTypeFlushFollower> gameCommandWithReceivers3 = GameCommandFactory.CreateGameCommandWithReceivers<ICommandTypeFlushFollower>(new TCommandHandleParamsFlushFollower());
			foreach (IPlayerFollowerHandler playerFollowerHandler3 in this.FollowerHandlesMap.Values)
			{
				gameCommandWithReceivers3.AddReceiver(playerFollowerHandler3.FlushFollowerReceiver());
			}
			CommandInvoker commandInvoker4 = this.CommandInvoker;
			if (commandInvoker4 != null)
			{
				commandInvoker4.SubmitCommand<ICommandTypeFlushFollower>(gameCommandWithReceivers3, false);
			}
			CommandInvoker commandInvoker5 = this.CommandInvoker;
			if (commandInvoker5 == null)
			{
				return;
			}
			commandInvoker5.ExecuteAllCommand();
		}

		// Token: 0x060312C0 RID: 201408 RVA: 0x00C3E650 File Offset: 0x00C3C850
		public long GetFollowerCreatureDataId(EClientPlayerFollower type)
		{
			Dictionary<int, long> followersMap = this.FollowersMap;
			return ((followersMap != null) ? followersMap.GetValueOrNull((int)type) : null).GetValueOrDefault();
		}

		// Token: 0x060312C1 RID: 201409 RVA: 0x00C3E680 File Offset: 0x00C3C880
		public long GetFollowerCreatureDataId(EPlayerFollower type)
		{
			Dictionary<int, long> followersMap = this.FollowersMap;
			return ((followersMap != null) ? followersMap.GetValueOrNull((int)type) : null).GetValueOrDefault();
		}

		// Token: 0x060312C2 RID: 201410 RVA: 0x00C3E6B0 File Offset: 0x00C3C8B0
		public long GetFollowerCreatureDataId(int type)
		{
			Dictionary<int, long> followersMap = this.FollowersMap;
			return ((followersMap != null) ? followersMap.GetValueOrNull(type) : null).GetValueOrDefault();
		}

		// Token: 0x060312C3 RID: 201411 RVA: 0x00C3E6E0 File Offset: 0x00C3C8E0
		[Obsolete]
		public EntityHandle GetFollower()
		{
			return FollowUtils.GetPlayerFollowShooter(this.PlayerId);
		}

		// Token: 0x060312C4 RID: 201412 RVA: 0x00C3E6ED File Offset: 0x00C3C8ED
		[Obsolete]
		public bool IsFollowerEnable()
		{
			return FollowUtils.IsFollowShooterEnable(this.PlayerId);
		}

		// Token: 0x060312C5 RID: 201413 RVA: 0x00C3E6FA File Offset: 0x00C3C8FA
		[Obsolete]
		public void SetFollowerEnable(bool enable)
		{
			FollowUtils.SetPlayerFollowShooterEnable(this.PlayerId, enable, BPEEnableFollowShooter.GameAbility, "");
		}

		// Token: 0x060312C6 RID: 201414 RVA: 0x00C3E710 File Offset: 0x00C3C910
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			PlayerFollowableComponent playerFollowableComponent = (PlayerFollowableComponent)componentTemplate;
			if (base.CanResetComponentProperty("FollowersMap"))
			{
				if (playerFollowableComponent.FollowersMap == null)
				{
					this.FollowersMap = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, long>>(this.FollowersMap), "FollowersMap"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FollowerHandlesMap"))
			{
				if (playerFollowableComponent.FollowerHandlesMap == null)
				{
					this.FollowerHandlesMap = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EPlayerFollowerHandlerType, IPlayerFollowerHandler>>(this.FollowerHandlesMap), "FollowerHandlesMap"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PlayerId"))
			{
				this.PlayerId = playerFollowableComponent.PlayerId;
			}
			if (base.CanResetComponentProperty("CommandInvoker"))
			{
				if (playerFollowableComponent.CommandInvoker == null)
				{
					this.CommandInvoker = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CommandInvoker>(this.CommandInvoker), "CommandInvoker"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401C4D0 RID: 115920
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static IParameterHandler<EntityHandleParameterContext> getHandlerTypeChain;

		// Token: 0x0401C4D1 RID: 115921
		private Dictionary<int, long> FollowersMap;

		// Token: 0x0401C4D2 RID: 115922
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<EPlayerFollowerHandlerType, IPlayerFollowerHandler> FollowerHandlesMap;

		// Token: 0x0401C4D3 RID: 115923
		private int PlayerId;

		// Token: 0x0401C4D4 RID: 115924
		public CommandInvoker CommandInvoker;

		// Token: 0x0401C4D5 RID: 115925
		[Nullable(new byte[]
		{
			2,
			0,
			1,
			1
		})]
		private static Dictionary<EPlayerFollowerHandlerType, OneOf<PlayerFollowerFollowShooterHandlerFactory, PlayerFollowerVehicleHandlerFactory>> FollowerHandlerFactory;

		// Token: 0x0401C4D6 RID: 115926
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<Type, EPlayerFollowerHandlerType> PlayerFollowerHandlerTypeNameToEnum = new Dictionary<Type, EPlayerFollowerHandlerType>
		{
			{
				typeof(IPlayerFollowerFollowShooterHandler),
				EPlayerFollowerHandlerType.FollowShooter
			},
			{
				typeof(IPlayerFollowerVehicleHandler),
				EPlayerFollowerHandlerType.Vehicle
			}
		};
	}
}
