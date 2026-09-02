using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Character.Item;
using AkiClient.Game.Aki.Data.Gameplay.WuWaGo;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.LevelGameplay.SplineConstrainedDrag.Capability;
using CSharpScript.Game.Module.WuwaGo.Controller.GameMode;
using CSharpScript.Game.Module.WuwaGo.Controller.Role.Capability;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.Role
{
	// Token: 0x02004AF5 RID: 19189
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class MainControlRoleController : WuWaGoRoleController<WuWaGoRole>
	{
		// Token: 0x0603208A RID: 204938 RVA: 0x00C84CD8 File Offset: 0x00C82ED8
		public MainControlRoleController(WuWaGoRole role, WuWaGoGameData gameData, WuWaGoGameModeBase gameMode) : base(role, gameData, gameMode)
		{
			this.MoveCapability = new MoveCapability(role);
			this.ClimbCapability = new ClimbCapability(role);
			this.ScreenTrace = new ScreenPositionTraceCapability(null);
			this.ScreenTrace.GetLineTrace(false, KuroTraceTypeQuery.AcrossBlock);
			this.ScreenTrace.Activate();
		}

		// Token: 0x0603208B RID: 204939 RVA: 0x00C84D92 File Offset: 0x00C82F92
		protected override bool OnCreate()
		{
			if (!base.OnCreate())
			{
				return false;
			}
			this.Role.AddStandGridChangedListener(new WuWaGoRoleStandGridChangedListener(this.HandleStandGridChanged));
			return true;
		}

		// Token: 0x0603208C RID: 204940 RVA: 0x00C84DB8 File Offset: 0x00C82FB8
		protected override void OnDestroy()
		{
			this.Role.RemoveStandGridChangedListener(new WuWaGoRoleStandGridChangedListener(this.HandleStandGridChanged));
			this.SetInputAccepting(false);
			ScreenPositionTraceCapability screenTrace = this.ScreenTrace;
			if (screenTrace != null)
			{
				screenTrace.Deactivate();
			}
			this.ScreenTrace = null;
			this.ClearAllHoverEffects(true);
			this.StopPullRodInteractMontage("Destroy");
			this.ClimbCapability.ExitClimbIdle();
			CustomPromise<UniTaskVoid> waitActionFinishPromise = this.WaitActionFinishPromise;
			if (waitActionFinishPromise != null)
			{
				waitActionFinishPromise.SetResult(default(UniTaskVoid));
			}
			this.WaitActionFinishPromise = null;
			this.LinkGrids = null;
			foreach (AActor aactor in this.CanMoveTipsApplique)
			{
				if (aactor.IsValid())
				{
					WuWaGoFactory.DestroyApplique(aactor);
				}
			}
			this.CanMoveTipsApplique.Clear();
			base.OnDestroy();
		}

		// Token: 0x0603208D RID: 204941 RVA: 0x00C84EA0 File Offset: 0x00C830A0
		protected override UniTask OnExecuteAction()
		{
			MainControlRoleController.<OnExecuteAction>d__29 <OnExecuteAction>d__;
			<OnExecuteAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnExecuteAction>d__.<>4__this = this;
			<OnExecuteAction>d__.<>1__state = -1;
			<OnExecuteAction>d__.<>t__builder.Start<MainControlRoleController.<OnExecuteAction>d__29>(ref <OnExecuteAction>d__);
			return <OnExecuteAction>d__.<>t__builder.Task;
		}

		// Token: 0x0603208E RID: 204942 RVA: 0x00C84EE4 File Offset: 0x00C830E4
		protected override UniTask OnBeforeAttack(WuWaGoGrid targetGrid)
		{
			MainControlRoleController.<OnBeforeAttack>d__30 <OnBeforeAttack>d__;
			<OnBeforeAttack>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeAttack>d__.<>4__this = this;
			<OnBeforeAttack>d__.targetGrid = targetGrid;
			<OnBeforeAttack>d__.<>1__state = -1;
			<OnBeforeAttack>d__.<>t__builder.Start<MainControlRoleController.<OnBeforeAttack>d__30>(ref <OnBeforeAttack>d__);
			return <OnBeforeAttack>d__.<>t__builder.Task;
		}

		// Token: 0x0603208F RID: 204943 RVA: 0x00C84F30 File Offset: 0x00C83130
		private void FinishExecuteAction()
		{
			CustomPromise<UniTaskVoid> waitActionFinishPromise = this.WaitActionFinishPromise;
			if (waitActionFinishPromise == null)
			{
				return;
			}
			waitActionFinishPromise.SetResult(default(UniTaskVoid));
		}

		// Token: 0x06032090 RID: 204944 RVA: 0x00C84F56 File Offset: 0x00C83156
		[NullableContext(2)]
		private void HandleStandGridChanged([Nullable(1)] WuWaGoRole role, WuWaGoGrid prevGrid, WuWaGoGrid currentGrid)
		{
			this.RefreshProgress(currentGrid);
			this.CheckArriveEndPoint(currentGrid);
		}

		// Token: 0x06032091 RID: 204945 RVA: 0x00C84F68 File Offset: 0x00C83168
		[NullableContext(2)]
		private void RefreshProgress(WuWaGoGrid currentGrid)
		{
			if (this.GameMode.IsCinematicPlaying)
			{
				return;
			}
			WuWaGoGameData gameData = ModelBase<WuWaGoModel>.Instance.GameData;
			int progressTotalGridCount = gameData.ProgressTotalGridCount;
			EWuWaGoEntityType? ewuWaGoEntityType = (currentGrid != null) ? currentGrid.EntityType : null;
			if (currentGrid != null && (ewuWaGoEntityType.GetValueOrDefault() == EWuWaGoEntityType.SaveGrid || ewuWaGoEntityType.GetValueOrDefault() == EWuWaGoEntityType.EndGrid))
			{
				bool flag = !gameData.VisitedProgressGridIds.Contains(currentGrid.Id);
				gameData.VisitedProgressGridIds.Add(currentGrid.Id);
				if (flag)
				{
					ControllerBase<WuWaGoController>.Instance.NotifyArrivedSavePoint(currentGrid);
				}
			}
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnWuWaGoProgressUpdate, gameData.VisitedProgressGridIds.Count, progressTotalGridCount);
		}

		// Token: 0x06032092 RID: 204946 RVA: 0x00C85010 File Offset: 0x00C83210
		[NullableContext(2)]
		private void CheckArriveEndPoint(WuWaGoGrid currentGrid)
		{
			if (currentGrid == null || currentGrid.EntityType.GetValueOrDefault() != EWuWaGoEntityType.EndGrid)
			{
				return;
			}
			ControllerBase<WuWaGoController>.Instance.EndGameplay(true);
		}

		// Token: 0x06032093 RID: 204947 RVA: 0x00C85048 File Offset: 0x00C83248
		private void SetInputAccepting(bool accept)
		{
			if (this.IsAcceptingInput == accept)
			{
				return;
			}
			this.IsAcceptingInput = accept;
			(this.Role as WuWaGoMainControlRole).IsAcceptingInput = accept;
			this.GameMode.NotifyMainControlInputAcceptingChanged(accept);
			if (accept)
			{
				Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnWuWaGoUserPickScreen, new Action<int, int>(this.OnUserPickScreen));
				Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnWuWaGoUserPreviewScreen, new Action<int, int>(this.OnUserPreviewScreen));
				Singleton<EventSystem>.Instance.Add<double, double>(EEventName.OnWuWaGoUserPickDirection, new Action<double, double>(this.OnUserPickDirection));
				Singleton<EventSystem>.Instance.Add(EEventName.OnWuWaGoUserUseInteraction, new Action(this.OnUserUseInteraction));
			}
			else
			{
				Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnWuWaGoUserPickScreen, new Action<int, int>(this.OnUserPickScreen));
				Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnWuWaGoUserPreviewScreen, new Action<int, int>(this.OnUserPreviewScreen));
				Singleton<EventSystem>.Instance.Remove<double, double>(EEventName.OnWuWaGoUserPickDirection, new Action<double, double>(this.OnUserPickDirection));
				Singleton<EventSystem>.Instance.Remove(EEventName.OnWuWaGoUserUseInteraction, new Action(this.OnUserUseInteraction));
			}
			this.RefreshInteractionAvailable();
		}

		// Token: 0x06032094 RID: 204948 RVA: 0x00C8516E File Offset: 0x00C8336E
		public void SetInputAcceptingFromExternal(bool accept)
		{
			this.SetInputAccepting(accept);
		}

		// Token: 0x06032095 RID: 204949 RVA: 0x00C85178 File Offset: 0x00C83378
		private void OnUserPickScreen(int screenX, int screenY)
		{
			if (this.GameMode.IsRollbackRestoring)
			{
				return;
			}
			WuWaGoGrid wuWaGoGrid = this.RaycastToLinkGrid(screenX, screenY);
			if (wuWaGoGrid == null)
			{
				return;
			}
			this.ExecuteOnGrid(wuWaGoGrid);
		}

		// Token: 0x06032096 RID: 204950 RVA: 0x00C851A8 File Offset: 0x00C833A8
		private void OnUserPreviewScreen(int screenX, int screenY)
		{
			if (this.GameMode.IsRollbackRestoring)
			{
				return;
			}
			WuWaGoGrid wuWaGoGrid = this.RaycastToLinkGrid(screenX, screenY);
			WuWaGoGrid grid = (wuWaGoGrid != null && wuWaGoGrid.Id == 0) ? null : wuWaGoGrid;
			this.UpdateGridHoverEffect(grid);
			this.UpdateRedArrowHoverEffect(grid);
		}

		// Token: 0x06032097 RID: 204951 RVA: 0x00C851EC File Offset: 0x00C833EC
		private void OnUserPickDirection(double dx, double dy)
		{
			if (this.GameMode.IsRollbackRestoring)
			{
				return;
			}
			WuWaGoGrid gridById = ModelBase<WuWaGoModel>.Instance.GetGridById(this.Role.StandGridId);
			bool flag = gridById == null;
			if (!flag)
			{
				List<WuWaGoGrid> linkGrids = this.LinkGrids;
				bool flag2 = (((linkGrids != null) ? new int?(linkGrids.Count) : null) ?? 0) == 0;
				flag = flag2;
			}
			if (flag)
			{
				return;
			}
			WuWaGoGrid wuWaGoGrid = this.FindLinkGridByDirection(dx, dy, gridById);
			if (wuWaGoGrid == null)
			{
				return;
			}
			this.ExecuteOnGrid(wuWaGoGrid);
		}

		// Token: 0x06032098 RID: 204952 RVA: 0x00C85280 File Offset: 0x00C83480
		private void OnUserUseInteraction()
		{
			if (this.GameMode.IsRollbackRestoring)
			{
				return;
			}
			WuWaGoGrid gridById = ModelBase<WuWaGoModel>.Instance.GetGridById(this.Role.StandGridId);
			if (gridById == null || !this.IsPullRodGrid(gridById))
			{
				return;
			}
			this.RunInteraction(gridById);
		}

		// Token: 0x06032099 RID: 204953 RVA: 0x00C852C8 File Offset: 0x00C834C8
		private UniTask ExecuteOnGrid(WuWaGoGrid grid)
		{
			MainControlRoleController.<ExecuteOnGrid>d__41 <ExecuteOnGrid>d__;
			<ExecuteOnGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteOnGrid>d__.<>4__this = this;
			<ExecuteOnGrid>d__.grid = grid;
			<ExecuteOnGrid>d__.<>1__state = -1;
			<ExecuteOnGrid>d__.<>t__builder.Start<MainControlRoleController.<ExecuteOnGrid>d__41>(ref <ExecuteOnGrid>d__);
			return <ExecuteOnGrid>d__.<>t__builder.Task;
		}

		// Token: 0x0603209A RID: 204954 RVA: 0x00C85314 File Offset: 0x00C83514
		private UniTask RunPlayerInputAction([Nullable(new byte[]
		{
			1,
			0
		})] Func<UniTask<EPlayerInputActionResult>> action)
		{
			MainControlRoleController.<RunPlayerInputAction>d__42 <RunPlayerInputAction>d__;
			<RunPlayerInputAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunPlayerInputAction>d__.<>4__this = this;
			<RunPlayerInputAction>d__.action = action;
			<RunPlayerInputAction>d__.<>1__state = -1;
			<RunPlayerInputAction>d__.<>t__builder.Start<MainControlRoleController.<RunPlayerInputAction>d__42>(ref <RunPlayerInputAction>d__);
			return <RunPlayerInputAction>d__.<>t__builder.Task;
		}

		// Token: 0x0603209B RID: 204955 RVA: 0x00C85360 File Offset: 0x00C83560
		[NullableContext(0)]
		private UniTask<EPlayerInputActionResult> ExecuteActionImp([Nullable(1)] WuWaGoGrid hitGrid)
		{
			MainControlRoleController.<ExecuteActionImp>d__43 <ExecuteActionImp>d__;
			<ExecuteActionImp>d__.<>t__builder = AsyncUniTaskMethodBuilder<EPlayerInputActionResult>.Create();
			<ExecuteActionImp>d__.<>4__this = this;
			<ExecuteActionImp>d__.hitGrid = hitGrid;
			<ExecuteActionImp>d__.<>1__state = -1;
			<ExecuteActionImp>d__.<>t__builder.Start<MainControlRoleController.<ExecuteActionImp>d__43>(ref <ExecuteActionImp>d__);
			return <ExecuteActionImp>d__.<>t__builder.Task;
		}

		// Token: 0x0603209C RID: 204956 RVA: 0x00C853AC File Offset: 0x00C835AC
		[NullableContext(0)]
		private UniTask<bool> TryHandleClimb([Nullable(1)] WuWaGoGrid hitGrid)
		{
			MainControlRoleController.<TryHandleClimb>d__44 <TryHandleClimb>d__;
			<TryHandleClimb>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TryHandleClimb>d__.<>4__this = this;
			<TryHandleClimb>d__.hitGrid = hitGrid;
			<TryHandleClimb>d__.<>1__state = -1;
			<TryHandleClimb>d__.<>t__builder.Start<MainControlRoleController.<TryHandleClimb>d__44>(ref <TryHandleClimb>d__);
			return <TryHandleClimb>d__.<>t__builder.Task;
		}

		// Token: 0x0603209D RID: 204957 RVA: 0x00C853F8 File Offset: 0x00C835F8
		private UniTask RunInteraction(WuWaGoGrid grid)
		{
			MainControlRoleController.<RunInteraction>d__45 <RunInteraction>d__;
			<RunInteraction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunInteraction>d__.<>4__this = this;
			<RunInteraction>d__.grid = grid;
			<RunInteraction>d__.<>1__state = -1;
			<RunInteraction>d__.<>t__builder.Start<MainControlRoleController.<RunInteraction>d__45>(ref <RunInteraction>d__);
			return <RunInteraction>d__.<>t__builder.Task;
		}

		// Token: 0x0603209E RID: 204958 RVA: 0x00C85444 File Offset: 0x00C83644
		public UniTask PlayHintMoveAsync(Vector targetCoordinate)
		{
			MainControlRoleController.<PlayHintMoveAsync>d__46 <PlayHintMoveAsync>d__;
			<PlayHintMoveAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayHintMoveAsync>d__.<>4__this = this;
			<PlayHintMoveAsync>d__.targetCoordinate = targetCoordinate;
			<PlayHintMoveAsync>d__.<>1__state = -1;
			<PlayHintMoveAsync>d__.<>t__builder.Start<MainControlRoleController.<PlayHintMoveAsync>d__46>(ref <PlayHintMoveAsync>d__);
			return <PlayHintMoveAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603209F RID: 204959 RVA: 0x00C85490 File Offset: 0x00C83690
		public UniTask PlayHintInteractAsync()
		{
			MainControlRoleController.<PlayHintInteractAsync>d__47 <PlayHintInteractAsync>d__;
			<PlayHintInteractAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayHintInteractAsync>d__.<>4__this = this;
			<PlayHintInteractAsync>d__.<>1__state = -1;
			<PlayHintInteractAsync>d__.<>t__builder.Start<MainControlRoleController.<PlayHintInteractAsync>d__47>(ref <PlayHintInteractAsync>d__);
			return <PlayHintInteractAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060320A0 RID: 204960 RVA: 0x00C854D4 File Offset: 0x00C836D4
		private UniTask PlayPullRodInteractMontage(WuWaGoPullRodEntity pullRodEntity)
		{
			MainControlRoleController.<PlayPullRodInteractMontage>d__48 <PlayPullRodInteractMontage>d__;
			<PlayPullRodInteractMontage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayPullRodInteractMontage>d__.<>4__this = this;
			<PlayPullRodInteractMontage>d__.pullRodEntity = pullRodEntity;
			<PlayPullRodInteractMontage>d__.<>1__state = -1;
			<PlayPullRodInteractMontage>d__.<>t__builder.Start<MainControlRoleController.<PlayPullRodInteractMontage>d__48>(ref <PlayPullRodInteractMontage>d__);
			return <PlayPullRodInteractMontage>d__.<>t__builder.Task;
		}

		// Token: 0x060320A1 RID: 204961 RVA: 0x00C85520 File Offset: 0x00C83720
		private void StopPullRodInteractMontage(string reason)
		{
			UAnimMontage playingPullRodMontage = this.PlayingPullRodMontage;
			if (playingPullRodMontage == null)
			{
				return;
			}
			UAnimInstance actorAnimInstance = WuWaGoUtil.GetActorAnimInstance(this.Role, "StopPullRodInteractMontage");
			this.PlayingPullRodMontage = null;
			if (actorAnimInstance == null)
			{
				return;
			}
			if (actorAnimInstance.GetCurrentActiveMontage() != playingPullRodMontage && !actorAnimInstance.Montage_IsPlaying(playingPullRodMontage))
			{
				return;
			}
			actorAnimInstance.Montage_Stop(MainControlRoleController.PullRodMontageBlendOutTime, playingPullRodMontage);
		}

		// Token: 0x060320A2 RID: 204962 RVA: 0x00C85574 File Offset: 0x00C83774
		private void RefreshInteractionAvailable()
		{
			bool flag = this.ComputeInteractionAvailable();
			if (flag == this.LastEmittedInteractionAvailable)
			{
				return;
			}
			this.LastEmittedInteractionAvailable = flag;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnWuWaGoInteractionAvailable, flag);
		}

		// Token: 0x060320A3 RID: 204963 RVA: 0x00C855AC File Offset: 0x00C837AC
		private bool ComputeInteractionAvailable()
		{
			if (!this.IsAcceptingInput)
			{
				return false;
			}
			WuWaGoGrid gridById = ModelBase<WuWaGoModel>.Instance.GetGridById(this.Role.StandGridId);
			return gridById != null && this.IsPullRodGrid(gridById);
		}

		// Token: 0x060320A4 RID: 204964 RVA: 0x00C855E8 File Offset: 0x00C837E8
		[NullableContext(2)]
		private WuWaGoGrid RaycastToLinkGrid(int screenX, int screenY)
		{
			bool flag = this.ScreenTrace == null;
			if (!flag)
			{
				List<WuWaGoGrid> linkGrids = this.LinkGrids;
				bool flag2 = (((linkGrids != null) ? new int?(linkGrids.Count) : null) ?? 0) == 0;
				flag = flag2;
			}
			if (flag)
			{
				return null;
			}
			Transform originTransform = ModelBase<WuWaGoModel>.Instance.GameData.OriginTransform;
			if (originTransform == null)
			{
				return null;
			}
			this.ScratchScreenPos.Set((double)screenX, (double)screenY, 0.0);
			if (!this.ScreenTrace.GetHitResultAtScreenPosition(this.ScratchScreenPos, ref this.KuroHitResult, "WuWaGo.Raycast"))
			{
				return null;
			}
			UKuroHitResult kuroHitResult = this.KuroHitResult;
			int num = kuroHitResult.Actors.Num();
			for (int i = 0; i < num; i++)
			{
				AActor aactor = kuroHitResult.Actors.Get(i).Get();
				if (aactor != null && aactor.IsValid() && (aactor is BP_WuWaGo_LandBox_C || aactor is BP_WuWaGo_WallBox_C || this.IsGameplayEntityActor(aactor)))
				{
					WuWaGoUtil.ConvertWorldPositionToCoordinate(originTransform, Vector.Create(aactor.D_K2_GetActorLocation()), this.HitActorCoordinate);
					WuWaGoUtil.SnapVectorToHalf(this.HitActorCoordinate);
					WuWaGoGrid wuWaGoGrid = this.LinkGrids.Find((WuWaGoGrid grid) => grid.Coordinate.Equals(this.HitActorCoordinate, 9.999999747378752E-05));
					if (wuWaGoGrid != null)
					{
						return wuWaGoGrid;
					}
				}
			}
			return null;
		}

		// Token: 0x060320A5 RID: 204965 RVA: 0x00C85750 File Offset: 0x00C83950
		[return: Nullable(2)]
		private WuWaGoGrid FindLinkGridByDirection(double dx, double dy, WuWaGoGrid standGrid)
		{
			List<WuWaGoGrid> linkGrids = this.LinkGrids;
			bool flag = (((linkGrids != null) ? new int?(linkGrids.Count) : null) ?? 0) == 0;
			if (flag)
			{
				return null;
			}
			double num = Math.Sqrt(dx * dx + dy * dy);
			if (num < 0.001)
			{
				return null;
			}
			Transform originTransform = ModelBase<WuWaGoModel>.Instance.GameData.OriginTransform;
			if (originTransform == null)
			{
				return null;
			}
			double num2 = dx / num;
			double num3 = dy / num;
			ValueTuple<float, float>? valueTuple = this.ProjectGridToScreen(standGrid, originTransform);
			if (valueTuple == null)
			{
				return null;
			}
			WuWaGoGrid result = null;
			double num4 = 0.0;
			foreach (WuWaGoGrid wuWaGoGrid in this.LinkGrids)
			{
				if (wuWaGoGrid.Id != standGrid.Id)
				{
					ValueTuple<float, float>? valueTuple2 = this.ProjectGridToScreen(wuWaGoGrid, originTransform);
					if (valueTuple2 != null)
					{
						float num5 = valueTuple2.Value.Item1 - valueTuple.Value.Item1;
						float num6 = valueTuple2.Value.Item2 - valueTuple.Value.Item2;
						double num7 = Math.Sqrt((double)(num5 * num5 + num6 * num6));
						if (num7 >= 1.0)
						{
							double num8 = ((double)num5 * num2 + (double)num6 * num3) / num7;
							if (num8 > num4)
							{
								num4 = num8;
								result = wuWaGoGrid;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060320A6 RID: 204966 RVA: 0x00C858E0 File Offset: 0x00C83AE0
		[return: TupleElementNames(new string[]
		{
			"X",
			"Y"
		})]
		[return: Nullable(0)]
		private ValueTuple<float, float>? ProjectGridToScreen(WuWaGoGrid grid, Transform originTransform)
		{
			APlayerController playerController = Global.PlayerController;
			if (playerController == null)
			{
				return null;
			}
			FVectorDouble fvectorDouble = WuWaGoUtil.GetWorldPositionByCoordinate(originTransform, grid.Coordinate, null).ToUeVector(false);
			FVector2D fvector2D = new FVector2D();
			if (!UGameplayStatics.D_ProjectWorldToScreen(playerController, fvectorDouble, ref fvector2D, false))
			{
				return null;
			}
			return new ValueTuple<float, float>?(new ValueTuple<float, float>(fvector2D.X, fvector2D.Y));
		}

		// Token: 0x060320A7 RID: 204967 RVA: 0x00C85948 File Offset: 0x00C83B48
		[NullableContext(2)]
		private AActor GetGameplayEntityRootActor(AActor actor)
		{
			if (actor == null || !actor.IsValid())
			{
				return null;
			}
			AActor attachParentActor = actor.GetAttachParentActor();
			if (attachParentActor == null)
			{
				return null;
			}
			attachParentActor = attachParentActor.GetAttachParentActor();
			if (!(attachParentActor is BP_BaseItem_C))
			{
				return null;
			}
			return attachParentActor;
		}

		// Token: 0x060320A8 RID: 204968 RVA: 0x00C85986 File Offset: 0x00C83B86
		private bool IsGameplayEntityActor(AActor actor)
		{
			return this.GetGameplayEntityRootActor(actor) != null;
		}

		// Token: 0x060320A9 RID: 204969 RVA: 0x00C85992 File Offset: 0x00C83B92
		[NullableContext(2)]
		private void UpdateGridHoverEffect(WuWaGoGrid grid)
		{
			if (grid == this.HoverGrid)
			{
				return;
			}
			this.ClearGridHoverEffect(true);
			if (grid == null)
			{
				return;
			}
			this.HoverGrid = grid;
			this.PlayGridHoverEffect(grid);
		}

		// Token: 0x060320AA RID: 204970 RVA: 0x00C859B8 File Offset: 0x00C83BB8
		private UniTask PlayGridHoverEffect(WuWaGoGrid grid)
		{
			MainControlRoleController.<PlayGridHoverEffect>d__58 <PlayGridHoverEffect>d__;
			<PlayGridHoverEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayGridHoverEffect>d__.<>4__this = this;
			<PlayGridHoverEffect>d__.grid = grid;
			<PlayGridHoverEffect>d__.<>1__state = -1;
			<PlayGridHoverEffect>d__.<>t__builder.Start<MainControlRoleController.<PlayGridHoverEffect>d__58>(ref <PlayGridHoverEffect>d__);
			return <PlayGridHoverEffect>d__.<>t__builder.Task;
		}

		// Token: 0x060320AB RID: 204971 RVA: 0x00C85A04 File Offset: 0x00C83C04
		private void ClearGridHoverEffect(bool immediately)
		{
			this.HoverEffectRequestSeq++;
			if (Singleton<EffectSystem>.Instance.IsValid(this.HoverEffectHandle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.HoverEffectHandle, "WuWaGo.Hover.Clear", immediately, null);
			}
			this.HoverEffectHandle = 0;
			this.HoverGrid = null;
		}

		// Token: 0x060320AC RID: 204972 RVA: 0x00C85A60 File Offset: 0x00C83C60
		[NullableContext(2)]
		private void UpdateRedArrowHoverEffect(WuWaGoGrid grid)
		{
			WuWaGoRole canAttackMonsterOnGrid = this.GetCanAttackMonsterOnGrid(grid);
			if (canAttackMonsterOnGrid == this.RedArrowHoverMonster)
			{
				return;
			}
			this.ClearRedArrowEffect(true);
			if (canAttackMonsterOnGrid == null)
			{
				return;
			}
			this.RedArrowHoverMonster = canAttackMonsterOnGrid;
			this.PlayRedArrowEffect(canAttackMonsterOnGrid);
		}

		// Token: 0x060320AD RID: 204973 RVA: 0x00C85A9C File Offset: 0x00C83C9C
		private UniTask PlayRedArrowEffect(WuWaGoRole monster)
		{
			MainControlRoleController.<PlayRedArrowEffect>d__61 <PlayRedArrowEffect>d__;
			<PlayRedArrowEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayRedArrowEffect>d__.<>4__this = this;
			<PlayRedArrowEffect>d__.monster = monster;
			<PlayRedArrowEffect>d__.<>1__state = -1;
			<PlayRedArrowEffect>d__.<>t__builder.Start<MainControlRoleController.<PlayRedArrowEffect>d__61>(ref <PlayRedArrowEffect>d__);
			return <PlayRedArrowEffect>d__.<>t__builder.Task;
		}

		// Token: 0x060320AE RID: 204974 RVA: 0x00C85AE8 File Offset: 0x00C83CE8
		private void ClearRedArrowEffect(bool immediately)
		{
			this.RedArrowEffectRequestSeq++;
			if (Singleton<EffectSystem>.Instance.IsValid(this.RedArrowEffectHandle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.RedArrowEffectHandle, "WuWaGo.RedArrow.Clear", immediately, null);
			}
			this.RedArrowEffectHandle = 0;
			this.RedArrowHoverMonster = null;
		}

		// Token: 0x060320AF RID: 204975 RVA: 0x00C85B43 File Offset: 0x00C83D43
		private void ClearAllHoverEffects(bool immediately)
		{
			this.ClearGridHoverEffect(immediately);
			this.ClearRedArrowEffect(immediately);
		}

		// Token: 0x060320B0 RID: 204976 RVA: 0x00C85B54 File Offset: 0x00C83D54
		[NullableContext(2)]
		private WuWaGoRole GetCanAttackMonsterOnGrid(WuWaGoGrid grid)
		{
			if (grid == null)
			{
				return null;
			}
			WuWaGoRole hostileRoleOnGrid = base.GetHostileRoleOnGrid(grid);
			if (hostileRoleOnGrid == null || !hostileRoleOnGrid.IsMonster)
			{
				return null;
			}
			if (!base.CanAttackTarget(hostileRoleOnGrid))
			{
				return null;
			}
			return hostileRoleOnGrid;
		}

		// Token: 0x060320B1 RID: 204977 RVA: 0x00C85B88 File Offset: 0x00C83D88
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private List<WuWaGoGrid> FindLinkGrid()
		{
			WuWaGoModel instance = ModelBase<WuWaGoModel>.Instance;
			WuWaGoGrid gridById = instance.GetGridById(this.Role.StandGridId);
			if (gridById == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.WuWaGo;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "FindLinkGrid：当前所在的Grid不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("StandGridId", this.Role.StandGridId);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			List<WuWaGoGrid> list = new List<WuWaGoGrid>();
			Vector vector = Vector.Create();
			foreach (Vector inB in gridById.LinkedDirections)
			{
				gridById.Coordinate.Addition(inB, vector);
				WuWaGoGrid grid = instance.GetGrid(vector);
				if (grid != null && grid.IsBidirectionalLinkedTo(gridById))
				{
					list.Add(grid);
				}
			}
			return list;
		}

		// Token: 0x060320B2 RID: 204978 RVA: 0x00C85C68 File Offset: 0x00C83E68
		private UniTask ShowLinkGrids()
		{
			MainControlRoleController.<ShowLinkGrids>d__66 <ShowLinkGrids>d__;
			<ShowLinkGrids>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowLinkGrids>d__.<>4__this = this;
			<ShowLinkGrids>d__.<>1__state = -1;
			<ShowLinkGrids>d__.<>t__builder.Start<MainControlRoleController.<ShowLinkGrids>d__66>(ref <ShowLinkGrids>d__);
			return <ShowLinkGrids>d__.<>t__builder.Task;
		}

		// Token: 0x060320B3 RID: 204979 RVA: 0x00C85CAC File Offset: 0x00C83EAC
		private void HideAllLinkGrid()
		{
			foreach (AActor aactor in this.CanMoveTipsApplique)
			{
				if (aactor.IsValid())
				{
					aactor.SetActorHiddenInGame(true);
				}
			}
		}

		// Token: 0x060320B4 RID: 204980 RVA: 0x00C85D08 File Offset: 0x00C83F08
		private Rotator CalcCanMoveTipsAppliqueWorldRotator(WuWaGoGrid grid, WuWaGoGrid curStandGrid, Transform originTransform, Rotator @out)
		{
			WuWaGoUtil.GetWorldPositionByCoordinate(originTransform, grid.Coordinate, this.TipsTargetWorldTemp);
			WuWaGoUtil.GetWorldPositionByCoordinate(originTransform, curStandGrid.Coordinate, this.TipsSelfWorldTemp);
			this.TipsSelfWorldTemp.Subtraction(this.TipsTargetWorldTemp, this.TipsForwardTemp);
			if (grid.GridShape == EGridShape.Horizontal)
			{
				Vector tipsNormalLocalTemp = this.TipsNormalLocalTemp;
				FVectorDouble fvectorDouble = Vector.UpVector;
				tipsNormalLocalTemp.DeepCopy(fvectorDouble);
			}
			else
			{
				IWallFrame wallFrame = grid.WallFrame;
				if (wallFrame == null)
				{
					return WuWaGoUtil.GetWorldRotator(originTransform, grid.GetLinkRotator(), @out);
				}
				this.TipsNormalLocalTemp.Set((double)(-(double)wallFrame.WallNormalX * wallFrame.OwnerSign), (double)(-(double)wallFrame.WallNormalY * wallFrame.OwnerSign), 0.0);
			}
			originTransform.GetRotation().RotateVector(this.TipsNormalLocalTemp, this.TipsNormalWorldTemp);
			double num = this.TipsForwardTemp.DotProduct(this.TipsNormalWorldTemp);
			this.TipsForwardTemp.X -= this.TipsNormalWorldTemp.X * num;
			this.TipsForwardTemp.Y -= this.TipsNormalWorldTemp.Y * num;
			this.TipsForwardTemp.Z -= this.TipsNormalWorldTemp.Z * num;
			if (this.TipsForwardTemp.IsNearlyZero(9.999999747378752E-05))
			{
				return WuWaGoUtil.GetWorldRotator(originTransform, grid.GetLinkRotator(), @out);
			}
			this.TipsForwardTemp.Normalize(9.99999993922529E-09);
			FVector fvector = this.TipsForwardTemp.ToUeVectorOld();
			FVector fvector2 = this.TipsNormalWorldTemp.ToUeVectorOld();
			FRotator frotator = UKismetMathLibrary.MakeRotFromXZ(fvector, fvector2);
			@out.Set(frotator.Pitch, frotator.Yaw, frotator.Roll);
			return @out;
		}

		// Token: 0x060320B5 RID: 204981 RVA: 0x00C85EC0 File Offset: 0x00C840C0
		public override void OnRollbackRestore()
		{
			base.OnRollbackRestore();
			this.SetInputAccepting(false);
			this.ClearAllHoverEffects(true);
			this.HideAllLinkGrid();
			if (this.Role.IsClimbing)
			{
				this.ClimbCapability.EnterClimbIdle();
			}
			else
			{
				this.ClimbCapability.ExitClimbIdle();
			}
			this.LinkGrids = null;
			CustomPromise<UniTaskVoid> waitActionFinishPromise = this.WaitActionFinishPromise;
			if (waitActionFinishPromise != null)
			{
				waitActionFinishPromise.SetResult(default(UniTaskVoid));
			}
			this.WaitActionFinishPromise = null;
		}

		// Token: 0x060320B6 RID: 204982 RVA: 0x00C85F34 File Offset: 0x00C84134
		[return: Nullable(2)]
		private WuWaGoPullRodEntity FindPullRodEntity(WuWaGoGrid grid)
		{
			WuWaGoPullRodEntity wuWaGoPullRodEntity = ModelBase<WuWaGoModel>.Instance.GameData.GetGameplayEntityByGrid(grid, EWuWaGoEntityType.PullRod) as WuWaGoPullRodEntity;
			if (wuWaGoPullRodEntity == null)
			{
				return null;
			}
			return wuWaGoPullRodEntity;
		}

		// Token: 0x060320B7 RID: 204983 RVA: 0x00C85F5E File Offset: 0x00C8415E
		private bool IsPullRodGrid(WuWaGoGrid grid)
		{
			return ModelBase<WuWaGoModel>.Instance.GameData.GetGameplayEntityByGrid(grid, EWuWaGoEntityType.PullRod) is WuWaGoPullRodEntity;
		}

		// Token: 0x0401D421 RID: 119841
		private readonly MoveCapability MoveCapability;

		// Token: 0x0401D422 RID: 119842
		private readonly ClimbCapability ClimbCapability;

		// Token: 0x0401D423 RID: 119843
		[Nullable(2)]
		private CustomPromise<UniTaskVoid> WaitActionFinishPromise;

		// Token: 0x0401D424 RID: 119844
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<WuWaGoGrid> LinkGrids;

		// Token: 0x0401D425 RID: 119845
		private bool IsAcceptingInput;

		// Token: 0x0401D426 RID: 119846
		private bool LastEmittedInteractionAvailable;

		// Token: 0x0401D427 RID: 119847
		[Nullable(2)]
		private ScreenPositionTraceCapability ScreenTrace;

		// Token: 0x0401D428 RID: 119848
		private UKuroHitResult KuroHitResult = new UKuroHitResult();

		// Token: 0x0401D429 RID: 119849
		private readonly Vector ScratchScreenPos = Vector.Create();

		// Token: 0x0401D42A RID: 119850
		private readonly Vector HitActorCoordinate = Vector.Create();

		// Token: 0x0401D42B RID: 119851
		[StaticVariableRuleIgnore]
		private static readonly Rotator WorldRotationTemp = Rotator.Create();

		// Token: 0x0401D42C RID: 119852
		[StaticVariableRuleIgnore]
		private static readonly Rotator LocalRotationTemp = Rotator.Create();

		// Token: 0x0401D42D RID: 119853
		[Nullable(2)]
		private WuWaGoGrid HoverGrid;

		// Token: 0x0401D42E RID: 119854
		private int HoverEffectHandle;

		// Token: 0x0401D42F RID: 119855
		private int HoverEffectRequestSeq;

		// Token: 0x0401D430 RID: 119856
		[Nullable(2)]
		private WuWaGoRole RedArrowHoverMonster;

		// Token: 0x0401D431 RID: 119857
		private int RedArrowEffectHandle;

		// Token: 0x0401D432 RID: 119858
		private int RedArrowEffectRequestSeq;

		// Token: 0x0401D433 RID: 119859
		private readonly List<AActor> CanMoveTipsApplique = new List<AActor>();

		// Token: 0x0401D434 RID: 119860
		private readonly Vector TipsForwardTemp = Vector.Create();

		// Token: 0x0401D435 RID: 119861
		private readonly Vector TipsNormalLocalTemp = Vector.Create();

		// Token: 0x0401D436 RID: 119862
		private readonly Vector TipsNormalWorldTemp = Vector.Create();

		// Token: 0x0401D437 RID: 119863
		private readonly Vector TipsTargetWorldTemp = Vector.Create();

		// Token: 0x0401D438 RID: 119864
		private readonly Vector TipsSelfWorldTemp = Vector.Create();

		// Token: 0x0401D439 RID: 119865
		private static readonly float PullRodMontageBlendOutTime = 0.1f;

		// Token: 0x0401D43A RID: 119866
		[Nullable(2)]
		private UAnimMontage PlayingPullRodMontage;
	}
}
