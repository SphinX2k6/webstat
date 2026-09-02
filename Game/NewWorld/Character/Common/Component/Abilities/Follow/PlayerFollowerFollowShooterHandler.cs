using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Utils.Command;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004981 RID: 18817
	[NullableContext(1)]
	[Nullable(0)]
	public class PlayerFollowerFollowShooterHandler : PlayerFollowerSwallowHandler, IPlayerFollowerFollowShooterHandler, IPlayerFollowerHandler
	{
		// Token: 0x060312CD RID: 201421 RVA: 0x00C3E824 File Offset: 0x00C3CA24
		public PlayerFollowerFollowShooterHandler(int playerId)
		{
			Comparison<PlayerFollowerInfo> compare;
			if ((compare = PlayerFollowerFollowShooterHandler.<>O.<0>__Compare) == null)
			{
				compare = (PlayerFollowerFollowShooterHandler.<>O.<0>__Compare = new Comparison<PlayerFollowerInfo>(PlayerFollowerInfo.Compare));
			}
			this.FollowShooters = new PriorityQueue<PlayerFollowerInfo>(compare);
			base..ctor();
			this.PlayerId = playerId;
			this.IsAutonomousProxy = new bool?(playerId == ModelBase<CreatureModel>.Instance.GetPlayerId());
		}

		// Token: 0x060312CE RID: 201422 RVA: 0x00C3E87C File Offset: 0x00C3CA7C
		public override IReceiver<ICommandTypeAddFollower> AddFollowerReceiver()
		{
			return new Receiver<ICommandTypeAddFollower>
			{
				ReceiveExecute = delegate(TCommandHandleParams<ICommandTypeAddFollower> @params)
				{
					TCommandHandleParamsAddFollower tcommandHandleParamsAddFollower = (TCommandHandleParamsAddFollower)@params;
					this.FollowShooters.Push(tcommandHandleParamsAddFollower.PlayerFollowerInfo);
				}
			};
		}

		// Token: 0x060312CF RID: 201423 RVA: 0x00C3E895 File Offset: 0x00C3CA95
		public override IReceiver<ICommandTypeFlushFollower> FlushFollowerReceiver()
		{
			return new Receiver<ICommandTypeFlushFollower>
			{
				ReceiveExecute = delegate(TCommandHandleParams<ICommandTypeFlushFollower> @params)
				{
					if (this.FollowShooters.Empty)
					{
						this.UnPossessFollower();
						return;
					}
					PlayerFollowerInfo top = this.FollowShooters.Top;
					if (top.CreatureDataId != this.CurrentFollowerCreatureDataId)
					{
						this.UnPossessFollower();
						this.WaitFollower(top.CreatureDataId);
					}
					this.FollowShooters.Clear();
				}
			};
		}

		// Token: 0x060312D0 RID: 201424 RVA: 0x00C3E8AE File Offset: 0x00C3CAAE
		public override bool HasFollower(long creatureDataId)
		{
			return this.CurrentFollowerCreatureDataId == creatureDataId;
		}

		// Token: 0x060312D1 RID: 201425 RVA: 0x00C3E8B9 File Offset: 0x00C3CAB9
		public override void OnClear()
		{
			this.UnPossessFollower();
			this.FollowShooters.Clear();
		}

		// Token: 0x060312D2 RID: 201426 RVA: 0x00C3E8CC File Offset: 0x00C3CACC
		private void WaitFollower(long creatureDataId)
		{
			WaitEntityTask waitEntityTask = this.WaitEntityTask;
			if (waitEntityTask != null)
			{
				waitEntityTask.Cancel();
			}
			this.WaitEntityTask = null;
			this.WaitEntityTask = WaitEntityTask.Create("PlayerFollowerFollowShooterHandler.WaitFollower", creatureDataId, delegate(bool? result)
			{
				this.WaitEntityTask = null;
				if (!result.GetValueOrDefault())
				{
					return;
				}
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
				if (entity == null || !entity.Valid || !FollowUtils.IsFollowShooter(entity))
				{
					return;
				}
				this.PossessFollower(creatureDataId, entity);
			}, 90000, false, true);
		}

		// Token: 0x060312D3 RID: 201427 RVA: 0x00C3E92E File Offset: 0x00C3CB2E
		private void PossessFollower(long creatureDataId, EntityHandle entityHandle)
		{
			this.CurrentFollowerCreatureDataId = creatureDataId;
			this.WaitFollowShooterEntityFinish(creatureDataId, entityHandle).Forget();
		}

		// Token: 0x060312D4 RID: 201428 RVA: 0x00C3E944 File Offset: 0x00C3CB44
		private UniTask WaitFollowShooterEntityFinish(long creatureDataId, EntityHandle entityHandle)
		{
			PlayerFollowerFollowShooterHandler.<WaitFollowShooterEntityFinish>d__14 <WaitFollowShooterEntityFinish>d__;
			<WaitFollowShooterEntityFinish>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitFollowShooterEntityFinish>d__.<>4__this = this;
			<WaitFollowShooterEntityFinish>d__.creatureDataId = creatureDataId;
			<WaitFollowShooterEntityFinish>d__.entityHandle = entityHandle;
			<WaitFollowShooterEntityFinish>d__.<>1__state = -1;
			<WaitFollowShooterEntityFinish>d__.<>t__builder.Start<PlayerFollowerFollowShooterHandler.<WaitFollowShooterEntityFinish>d__14>(ref <WaitFollowShooterEntityFinish>d__);
			return <WaitFollowShooterEntityFinish>d__.<>t__builder.Task;
		}

		// Token: 0x060312D5 RID: 201429 RVA: 0x00C3E998 File Offset: 0x00C3CB98
		private void UnPossessFollower()
		{
			WaitEntityTask waitEntityTask = this.WaitEntityTask;
			if (waitEntityTask != null)
			{
				waitEntityTask.Cancel();
			}
			this.WaitEntityTask = null;
			if (this.CurrentFollower != null && this.IsAutonomousProxy.GetValueOrDefault())
			{
				this.CurrentFollower.UnPossessed();
				Singleton<EventSystem>.Instance.Emit(EEventName.OnPlayerFollowerUnPossessed);
			}
			this.CurrentFollowerCreatureDataId = 0L;
			this.CurrentFollowerHandle = null;
			this.CurrentFollower = null;
		}

		// Token: 0x060312D6 RID: 201430 RVA: 0x00C3EA04 File Offset: 0x00C3CC04
		public unsafe bool SetFollowShooterEnable(bool enable, BPEEnableFollowShooter enableType, string reason = "")
		{
			if (this.CurrentFollower == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "SetFollowShooterEnable: CurrentFollower is undefined";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PlayerId", this.PlayerId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			return this.CurrentFollower.SetEnable(enable, enableType, reason);
		}

		// Token: 0x060312D7 RID: 201431 RVA: 0x00C3EA86 File Offset: 0x00C3CC86
		[NullableContext(2)]
		public EntityHandle GetFollowShooter()
		{
			return this.CurrentFollowerHandle;
		}

		// Token: 0x060312D8 RID: 201432 RVA: 0x00C3EA8E File Offset: 0x00C3CC8E
		public bool IsFollowShooterEnable()
		{
			IFollower currentFollower = this.CurrentFollower;
			return currentFollower != null && currentFollower.GetEnable();
		}

		// Token: 0x060312D9 RID: 201433 RVA: 0x00C3EAA1 File Offset: 0x00C3CCA1
		public void AddFollowShooterCustomEntityId(string customKey, int entityId)
		{
			ModelBase<BulletModel>.Instance.SetCustomBulletAttacker(customKey, entityId);
		}

		// Token: 0x060312DA RID: 201434 RVA: 0x00C3EAAF File Offset: 0x00C3CCAF
		public bool RemoveFollowShooterCustomEntityId(string customKey)
		{
			return ModelBase<BulletModel>.Instance.RemoveCustomBulletAttacker(customKey);
		}

		// Token: 0x060312DB RID: 201435 RVA: 0x00C3EABC File Offset: 0x00C3CCBC
		public int? GetFollowShooterCustomEntityId(string customKey)
		{
			return ModelBase<BulletModel>.Instance.GetCustomBulletAttacker(customKey);
		}

		// Token: 0x0401C4D7 RID: 115927
		private long CurrentFollowerCreatureDataId;

		// Token: 0x0401C4D8 RID: 115928
		private readonly bool? IsAutonomousProxy;

		// Token: 0x0401C4D9 RID: 115929
		private readonly int PlayerId;

		// Token: 0x0401C4DA RID: 115930
		[Nullable(2)]
		private EntityHandle CurrentFollowerHandle;

		// Token: 0x0401C4DB RID: 115931
		[Nullable(2)]
		private IFollower CurrentFollower;

		// Token: 0x0401C4DC RID: 115932
		[Nullable(2)]
		private WaitEntityTask WaitEntityTask;

		// Token: 0x0401C4DD RID: 115933
		private readonly PriorityQueue<PlayerFollowerInfo> FollowShooters;

		// Token: 0x0200A9E8 RID: 43496
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04034933 RID: 215347
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Comparison<PlayerFollowerInfo> <0>__Compare;
		}
	}
}
