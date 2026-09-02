using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.WuWaGo;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.WuwaGo.Controller.GameMode;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity;
using CSharpScript.Game.Module.WuwaGo.Movement;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B10 RID: 19216
	[NullableContext(1)]
	[Nullable(0)]
	[Controller(0)]
	public class MovableFloorController : GameplayEntityControllerBase
	{
		// Token: 0x060321DE RID: 205278 RVA: 0x00C8AAAB File Offset: 0x00C88CAB
		public MovableFloorController(WuWaGoGameplayEntityBase entity, WuWaGoGameData gameData, WuWaGoGameModeBase gameMode) : base(entity, gameData, gameMode)
		{
		}

		// Token: 0x1700858F RID: 34191
		// (get) Token: 0x060321DF RID: 205279 RVA: 0x00C8AAC1 File Offset: 0x00C88CC1
		private WuWaGoMovableFloorEntity MovableFloor
		{
			get
			{
				return this.Entity as WuWaGoMovableFloorEntity;
			}
		}

		// Token: 0x060321E0 RID: 205280 RVA: 0x00C8AACE File Offset: 0x00C88CCE
		protected override bool OnCreate()
		{
			if (!base.OnCreate())
			{
				return false;
			}
			base.ResetActorToEntityConfigInitialTransform();
			base.RegisterAttachedGridMoveParticipant();
			return true;
		}

		// Token: 0x060321E1 RID: 205281 RVA: 0x00C8AAE8 File Offset: 0x00C88CE8
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.StopMoveSmokeEffect(true);
			this.RestoreInitialPosition();
			base.UnregisterAttachedGridMoveParticipant();
		}

		// Token: 0x060321E2 RID: 205282 RVA: 0x00C8AB04 File Offset: 0x00C88D04
		protected override UniTask OnExecuteAction()
		{
			MovableFloorController.<OnExecuteAction>d__6 <OnExecuteAction>d__;
			<OnExecuteAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnExecuteAction>d__.<>1__state = -1;
			<OnExecuteAction>d__.<>t__builder.Start<MovableFloorController.<OnExecuteAction>d__6>(ref <OnExecuteAction>d__);
			return <OnExecuteAction>d__.<>t__builder.Task;
		}

		// Token: 0x060321E3 RID: 205283 RVA: 0x00C8AB40 File Offset: 0x00C88D40
		[NullableContext(2)]
		public IMovableFloorMoveRequest CreateMoveRequest()
		{
			if (!this.MovableFloor.NeedMove)
			{
				return null;
			}
			WuWaGoGridController gridControllerById = this.GameMode.GetGridControllerById(this.Entity.StandGridId);
			if (gridControllerById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.WuWaGo;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "移动板关联GridController不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", this.Entity.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.MovableFloor.CancelPendingMove();
				return null;
			}
			Vector targetCoordinate = this.MovableFloor.GetTargetCoordinate();
			if (targetCoordinate == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.WuWaGo;
				ELogAuthor author2 = ELogAuthor.YSQ;
				string message2 = "移动板目标坐标不存在";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", this.Entity.Id);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				this.MovableFloor.CancelPendingMove();
				return null;
			}
			return new MovableFloorMoveRequest
			{
				Controller = this,
				RelocationRequest = gridControllerById.CreateRelocationRequest(targetCoordinate)
			};
		}

		// Token: 0x060321E4 RID: 205284 RVA: 0x00C8AC2A File Offset: 0x00C88E2A
		public void FinishMoveRequest()
		{
			this.MovableFloor.FinishMove();
		}

		// Token: 0x060321E5 RID: 205285 RVA: 0x00C8AC37 File Offset: 0x00C88E37
		public void CancelPendingMove()
		{
			this.MovableFloor.CancelPendingMove();
		}

		// Token: 0x060321E6 RID: 205286 RVA: 0x00C8AC44 File Offset: 0x00C88E44
		public void PlayMoveAudio()
		{
			base.PostAudioEventOnEntity(EWuWaGoAudioEventIndex.MovableFloorMove);
			this.PlayMoveSmokeEffect();
		}

		// Token: 0x060321E7 RID: 205287 RVA: 0x00C8AC54 File Offset: 0x00C88E54
		public void StopMoveSmokeEffect(bool immediately)
		{
			foreach (int handle in this.MoveSmokeEffectHandles.ToList<int>())
			{
				this.StopMoveSmokeEffectByHandle(handle, "WuWaGo.MovableFloor.MoveSmoke.Stop", immediately);
			}
			this.MoveSmokeEffectHandles.Clear();
		}

		// Token: 0x060321E8 RID: 205288 RVA: 0x00C8ACC0 File Offset: 0x00C88EC0
		private void PlayMoveSmokeEffect()
		{
			MovableFloorController.<>c__DisplayClass12_0 CS$<>8__locals1 = new MovableFloorController.<>c__DisplayClass12_0();
			CS$<>8__locals1.<>4__this = this;
			BP_WuWaGo_C setting = WuWaGoGlobal.Setting;
			string text = (setting != null) ? setting.MoveFloorFx.ToAssetPathName() : null;
			if (text == null || StringUtils.IsBlank(text))
			{
				return;
			}
			AActor aactor = this.Entity.GetActorAsObject() as AActor;
			if (aactor == null || !aactor.IsValid())
			{
				return;
			}
			MovableFloorController.<>c__DisplayClass12_0 CS$<>8__locals2 = CS$<>8__locals1;
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(aactor.D_GetTransform());
			CS$<>8__locals2.handle = instance.SpawnEffect(world, ftransformDouble, text, "WuWaGo.MovableFloor.MoveSmoke", new EffectContext(null, aactor, false), EEffectType.Scene, null, null, null, false, false);
			if (!Singleton<EffectSystem>.Instance.IsValid(CS$<>8__locals1.handle))
			{
				return;
			}
			this.MoveSmokeEffectHandles.Add(CS$<>8__locals1.handle);
			OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(CS$<>8__locals1.handle);
			AActor parent = aactor;
			FName? fname = null;
			effectActor.K2_AttachToActor(parent, fname, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.KeepWorld, false);
			Singleton<EffectSystem>.Instance.AddFinishCallback(CS$<>8__locals1.handle, delegate(int _)
			{
				CS$<>8__locals1.<>4__this.CleanupMoveSmokeEffectHandle(CS$<>8__locals1.handle);
			});
		}

		// Token: 0x060321E9 RID: 205289 RVA: 0x00C8ADC0 File Offset: 0x00C88FC0
		private void StopMoveSmokeEffectByHandle(int handle, string reason, bool immediately)
		{
			this.MoveSmokeEffectHandles.Remove(handle);
			if (Singleton<EffectSystem>.Instance.IsValid(handle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(handle, reason, immediately, null);
			}
		}

		// Token: 0x060321EA RID: 205290 RVA: 0x00C8ADFE File Offset: 0x00C88FFE
		private void CleanupMoveSmokeEffectHandle(int handle)
		{
			this.MoveSmokeEffectHandles.Remove(handle);
		}

		// Token: 0x060321EB RID: 205291 RVA: 0x00C8AE10 File Offset: 0x00C89010
		private void RestoreInitialPosition()
		{
			Vector initialCoordinate = this.MovableFloor.GetInitialCoordinate();
			if (initialCoordinate == null)
			{
				return;
			}
			WuWaGoGameData gameData = this.GameData;
			WuWaGoGridController gridControllerById = this.GameMode.GetGridControllerById(this.Entity.StandGridId);
			if (gridControllerById == null)
			{
				this.MovableFloor.ResetToInitialState();
				return;
			}
			WuWaGoGrid grid = gridControllerById.Grid;
			if (!grid.Coordinate.Equals(initialCoordinate, 9.999999747378752E-05))
			{
				IWuWaGoGridRelocationRequest wuWaGoGridRelocationRequest = gridControllerById.CreateRelocationRequest(initialCoordinate);
				Transform originTransform = gameData.OriginTransform;
				if (originTransform != null)
				{
					this.MovableFloor.SetActorWorldLocation(WuWaGoUtil.GetWorldPositionByCoordinate(originTransform, initialCoordinate, null), false);
				}
				gameData.RelocateGridKey(grid, initialCoordinate);
				foreach (IWuWaGoGridMoveParticipant wuWaGoGridMoveParticipant in wuWaGoGridRelocationRequest.Participants)
				{
					Action<IWuWaGoGridRelocationContext> commitGridMove = wuWaGoGridMoveParticipant.CommitGridMove;
					if (commitGridMove != null)
					{
						commitGridMove(wuWaGoGridRelocationRequest);
					}
				}
				gameData.RebuildAllGridLinks();
			}
			this.MovableFloor.ResetToInitialState();
		}

		// Token: 0x0401D4BE RID: 119998
		private readonly HashSet<int> MoveSmokeEffectHandles = new HashSet<int>();
	}
}
