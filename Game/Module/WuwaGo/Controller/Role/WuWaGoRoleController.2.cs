using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Module.WuwaGo.Controller.GameMode;
using CSharpScript.Game.Module.WuwaGo.Controller.Role.Capability;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.Role
{
	// Token: 0x02004AFB RID: 19195
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class WuWaGoRoleController<[Nullable(0)] TRole> : WuWaGoRoleController where TRole : WuWaGoRole
	{
		// Token: 0x060320ED RID: 205037 RVA: 0x00C868E8 File Offset: 0x00C84AE8
		protected WuWaGoRoleController(TRole role, WuWaGoGameData gameData, WuWaGoGameModeBase gameMode)
		{
		}

		// Token: 0x1700856F RID: 34159
		// (get) Token: 0x060320EE RID: 205038 RVA: 0x00C86948 File Offset: 0x00C84B48
		public override int Id
		{
			get
			{
				return this.Role.Id;
			}
		}

		// Token: 0x17008570 RID: 34160
		// (get) Token: 0x060320EF RID: 205039 RVA: 0x00C8695A File Offset: 0x00C84B5A
		public override Enum Type
		{
			get
			{
				return this.Role.Type;
			}
		}

		// Token: 0x17008571 RID: 34161
		// (get) Token: 0x060320F0 RID: 205040 RVA: 0x00C86971 File Offset: 0x00C84B71
		public override WuWaGoRole BaseRole
		{
			get
			{
				return this.Role;
			}
		}

		// Token: 0x17008572 RID: 34162
		// (get) Token: 0x060320F1 RID: 205041 RVA: 0x00C8697E File Offset: 0x00C84B7E
		public override EWuWaGoRoleType RoleType
		{
			get
			{
				return this.Role.Type;
			}
		}

		// Token: 0x060320F2 RID: 205042 RVA: 0x00C86990 File Offset: 0x00C84B90
		[NullableContext(2)]
		public override UniTask TakeAttack(bool playBeHitAnim, UAnimMontage deathMontage = null)
		{
			WuWaGoRoleController<TRole>.<TakeAttack>d__18 <TakeAttack>d__;
			<TakeAttack>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TakeAttack>d__.<>4__this = this;
			<TakeAttack>d__.playBeHitAnim = playBeHitAnim;
			<TakeAttack>d__.deathMontage = deathMontage;
			<TakeAttack>d__.<>1__state = -1;
			<TakeAttack>d__.<>t__builder.Start<WuWaGoRoleController<TRole>.<TakeAttack>d__18>(ref <TakeAttack>d__);
			return <TakeAttack>d__.<>t__builder.Task;
		}

		// Token: 0x060320F3 RID: 205043 RVA: 0x00C869E3 File Offset: 0x00C84BE3
		public override void SyncRuntimePresentationAfterCoordinateChanged()
		{
		}

		// Token: 0x060320F4 RID: 205044 RVA: 0x00C869E5 File Offset: 0x00C84BE5
		public override void HideAttackRangeEffect(string reason)
		{
		}

		// Token: 0x060320F5 RID: 205045 RVA: 0x00C869E7 File Offset: 0x00C84BE7
		public override void ShowAttackRangeEffect(string reason)
		{
		}

		// Token: 0x060320F6 RID: 205046 RVA: 0x00C869E9 File Offset: 0x00C84BE9
		public override void OnRollbackRestore()
		{
			WuWaGoUtil.ResetRoleRootMotionState(this.Role, "RoleController.RollbackRestore");
		}

		// Token: 0x060320F7 RID: 205047 RVA: 0x00C86A00 File Offset: 0x00C84C00
		protected override bool OnCreate()
		{
			this.Role.AddStandGridChangedListener(new WuWaGoRoleStandGridChangedListener(this.OnRoleStandGridChanged));
			this.RefreshRoleGridMoveParticipant(null, null);
			return true;
		}

		// Token: 0x060320F8 RID: 205048 RVA: 0x00C86A27 File Offset: 0x00C84C27
		protected override void OnDestroy()
		{
			this.Role.RemoveStandGridChangedListener(new WuWaGoRoleStandGridChangedListener(this.OnRoleStandGridChanged));
			this.UnregisterRoleGridMoveParticipant();
		}

		// Token: 0x060320F9 RID: 205049 RVA: 0x00C86A4C File Offset: 0x00C84C4C
		protected bool ShouldInterrupt()
		{
			WuWaGoMainControlRole mainControlRole = ModelBase<WuWaGoModel>.Instance.GameData.MainControlRole;
			return mainControlRole == null || mainControlRole.IsDead;
		}

		// Token: 0x060320FA RID: 205050 RVA: 0x00C86A74 File Offset: 0x00C84C74
		[NullableContext(0)]
		protected UniTask<bool> TryAttackForward()
		{
			WuWaGoRoleController<TRole>.<TryAttackForward>d__26 <TryAttackForward>d__;
			<TryAttackForward>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TryAttackForward>d__.<>4__this = this;
			<TryAttackForward>d__.<>1__state = -1;
			<TryAttackForward>d__.<>t__builder.Start<WuWaGoRoleController<TRole>.<TryAttackForward>d__26>(ref <TryAttackForward>d__);
			return <TryAttackForward>d__.<>t__builder.Task;
		}

		// Token: 0x060320FB RID: 205051 RVA: 0x00C86AB8 File Offset: 0x00C84CB8
		[NullableContext(0)]
		protected UniTask<bool> TryAttackOnGrid([Nullable(2)] WuWaGoGrid grid, bool requireGridLink = true)
		{
			WuWaGoRoleController<TRole>.<TryAttackOnGrid>d__27 <TryAttackOnGrid>d__;
			<TryAttackOnGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TryAttackOnGrid>d__.<>4__this = this;
			<TryAttackOnGrid>d__.grid = grid;
			<TryAttackOnGrid>d__.requireGridLink = requireGridLink;
			<TryAttackOnGrid>d__.<>1__state = -1;
			<TryAttackOnGrid>d__.<>t__builder.Start<WuWaGoRoleController<TRole>.<TryAttackOnGrid>d__27>(ref <TryAttackOnGrid>d__);
			return <TryAttackOnGrid>d__.<>t__builder.Task;
		}

		// Token: 0x060320FC RID: 205052 RVA: 0x00C86B0C File Offset: 0x00C84D0C
		protected virtual UniTask OnBeforeAttack(WuWaGoGrid targetGrid)
		{
			WuWaGoRoleController<TRole>.<OnBeforeAttack>d__28 <OnBeforeAttack>d__;
			<OnBeforeAttack>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeAttack>d__.targetGrid = targetGrid;
			<OnBeforeAttack>d__.<>1__state = -1;
			<OnBeforeAttack>d__.<>t__builder.Start<WuWaGoRoleController<TRole>.<OnBeforeAttack>d__28>(ref <OnBeforeAttack>d__);
			return <OnBeforeAttack>d__.<>t__builder.Task;
		}

		// Token: 0x060320FD RID: 205053 RVA: 0x00C86B50 File Offset: 0x00C84D50
		[NullableContext(2)]
		protected WuWaGoRole GetHostileRoleOnGrid(WuWaGoGrid grid)
		{
			if (grid == null || !grid.IsOccupied)
			{
				return null;
			}
			WuWaGoRole wuWaGoRole = ModelBase<WuWaGoModel>.Instance.GetUnitById(grid.OccupiedUnitId) as WuWaGoRole;
			if (wuWaGoRole == null || wuWaGoRole == this.Role || wuWaGoRole.IsDead)
			{
				return null;
			}
			if (this.Role.IsMonster == wuWaGoRole.IsMonster)
			{
				return null;
			}
			return wuWaGoRole;
		}

		// Token: 0x060320FE RID: 205054 RVA: 0x00C86BB8 File Offset: 0x00C84DB8
		[NullableContext(2)]
		private WuWaGoGrid FindHostileForwardGridIgnoringLinks()
		{
			WuWaGoGrid wuWaGoGrid = this.FindForwardGridIgnoringLinks();
			if (this.GetHostileRoleOnGrid(wuWaGoGrid) == null)
			{
				return null;
			}
			return wuWaGoGrid;
		}

		// Token: 0x060320FF RID: 205055 RVA: 0x00C86BD8 File Offset: 0x00C84DD8
		[NullableContext(2)]
		private WuWaGoGrid FindForwardGridIgnoringLinks()
		{
			WuWaGoModel instance = ModelBase<WuWaGoModel>.Instance;
			WuWaGoGrid gridById = instance.GetGridById(this.Role.StandGridId);
			if (gridById == null)
			{
				return null;
			}
			this.Role.Rotator.Quaternion(null).RotateVector(Vector.ForwardVectorProxy, this.TempForwardDir);
			WuWaGoUtil.RoundIfNotInteger(this.TempForwardDir);
			if (this.TempForwardDir.IsNearlyZero(9.999999747378752E-05))
			{
				return null;
			}
			gridById.Coordinate.Addition(this.TempForwardDir, this.TempStepCoordinate);
			return instance.GetGrid(this.TempStepCoordinate);
		}

		// Token: 0x06032100 RID: 205056 RVA: 0x00C86C78 File Offset: 0x00C84E78
		protected bool CanAttackTarget(WuWaGoRole target)
		{
			if (!target.IsMonster)
			{
				return true;
			}
			WuWaGoGrid wuWaGoGrid = this.FindRoleFrontGrid(target, 1);
			return wuWaGoGrid == null || wuWaGoGrid.Id != this.Role.StandGridId;
		}

		// Token: 0x06032101 RID: 205057 RVA: 0x00C86CB8 File Offset: 0x00C84EB8
		[return: Nullable(2)]
		protected WuWaGoGrid FindRoleFrontGrid(WuWaGoRole role, int step = 1)
		{
			if (step < 1)
			{
				return null;
			}
			WuWaGoModel instance = ModelBase<WuWaGoModel>.Instance;
			WuWaGoGrid gridById = instance.GetGridById(role.StandGridId);
			if (gridById == null || gridById.LinkedDirections.Count == 0)
			{
				return null;
			}
			role.Rotator.Quaternion(null).RotateVector(Vector.ForwardVectorProxy, this.TempForwardDir);
			WuWaGoGrid wuWaGoGrid = gridById;
			for (int i = 0; i < step; i++)
			{
				Vector vector = this.PickForwardLinkDelta(wuWaGoGrid);
				if (vector == null)
				{
					return null;
				}
				wuWaGoGrid.Coordinate.Addition(vector, this.TempStepCoordinate);
				WuWaGoGrid grid = instance.GetGrid(this.TempStepCoordinate);
				if (grid == null || !wuWaGoGrid.IsBidirectionalLinkedTo(grid))
				{
					return null;
				}
				wuWaGoGrid = grid;
			}
			return wuWaGoGrid;
		}

		// Token: 0x06032102 RID: 205058 RVA: 0x00C86D60 File Offset: 0x00C84F60
		[return: Nullable(2)]
		private Vector PickForwardLinkDelta(WuWaGoGrid grid)
		{
			Vector tempForwardDir = this.TempForwardDir;
			Vector result = null;
			double num = WuWaGoRoleController.ForwardAlignThresholdSquared;
			foreach (Vector vector in grid.LinkedDirections)
			{
				double num2 = tempForwardDir.DotProduct(vector);
				if (num2 > 0.0)
				{
					double num3 = vector.SizeSquared();
					if (num3 > 0.0)
					{
						double num4 = num2 * num2 / num3;
						if (num4 > num)
						{
							num = num4;
							result = vector;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06032103 RID: 205059 RVA: 0x00C86DFC File Offset: 0x00C84FFC
		[return: Nullable(2)]
		private IWuWaGoWorldMoveTarget CreateRoleWorldMoveTarget(IWuWaGoGridRelocationContext context)
		{
			if (!this.Role.IsActorValid())
			{
				return null;
			}
			return new WuWaGoWorldMoveTarget
			{
				Unit = this.Role
			};
		}

		// Token: 0x06032104 RID: 205060 RVA: 0x00C86E28 File Offset: 0x00C85028
		private void OnBeforeRoleGridMove(IWuWaGoGridRelocationContext context)
		{
			this.HideAttackRangeEffect("WuWaGo.AttackRange.MovableFloor");
		}

		// Token: 0x06032105 RID: 205061 RVA: 0x00C86E35 File Offset: 0x00C85035
		private void OnCommitRoleGridMove(IWuWaGoGridRelocationContext context)
		{
			this.Role.SetCoordinate(context.TargetCoordinate);
		}

		// Token: 0x06032106 RID: 205062 RVA: 0x00C86E50 File Offset: 0x00C85050
		private UniTask OnAfterRoleGridMove(IWuWaGoGridRelocationContext context)
		{
			WuWaGoRoleController<TRole>.<OnAfterRoleGridMove>d__38 <OnAfterRoleGridMove>d__;
			<OnAfterRoleGridMove>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnAfterRoleGridMove>d__.<>4__this = this;
			<OnAfterRoleGridMove>d__.context = context;
			<OnAfterRoleGridMove>d__.<>1__state = -1;
			<OnAfterRoleGridMove>d__.<>t__builder.Start<WuWaGoRoleController<TRole>.<OnAfterRoleGridMove>d__38>(ref <OnAfterRoleGridMove>d__);
			return <OnAfterRoleGridMove>d__.<>t__builder.Task;
		}

		// Token: 0x06032107 RID: 205063 RVA: 0x00C86E9B File Offset: 0x00C8509B
		[NullableContext(2)]
		private void OnRoleStandGridChanged([Nullable(1)] WuWaGoRole role, WuWaGoGrid prevGrid, WuWaGoGrid currentGrid)
		{
			this.RefreshRoleGridMoveParticipant(currentGrid, prevGrid);
		}

		// Token: 0x06032108 RID: 205064 RVA: 0x00C86EA8 File Offset: 0x00C850A8
		[NullableContext(2)]
		private void RefreshRoleGridMoveParticipant(WuWaGoGrid currentGrid = null, WuWaGoGrid prevGrid = null)
		{
			WuWaGoGrid wuWaGoGrid = currentGrid ?? ModelBase<WuWaGoModel>.Instance.GetGridById(this.Role.StandGridId);
			if (this.RegisteredMoveGrid == wuWaGoGrid)
			{
				return;
			}
			IWuWaGoGridMoveParticipant roleGridMoveParticipant = this.GetRoleGridMoveParticipant();
			WuWaGoGrid wuWaGoGrid2 = prevGrid ?? this.RegisteredMoveGrid;
			if (wuWaGoGrid2 != null)
			{
				wuWaGoGrid2.UnregisterMoveParticipant(roleGridMoveParticipant);
			}
			this.RegisteredMoveGrid = wuWaGoGrid;
			WuWaGoGrid registeredMoveGrid = this.RegisteredMoveGrid;
			if (registeredMoveGrid == null)
			{
				return;
			}
			registeredMoveGrid.RegisterMoveParticipant(roleGridMoveParticipant);
		}

		// Token: 0x06032109 RID: 205065 RVA: 0x00C86F15 File Offset: 0x00C85115
		private void UnregisterRoleGridMoveParticipant()
		{
			WuWaGoGrid registeredMoveGrid = this.RegisteredMoveGrid;
			if (registeredMoveGrid != null)
			{
				registeredMoveGrid.UnregisterMoveParticipant(this.GetRoleGridMoveParticipant());
			}
			this.RegisteredMoveGrid = null;
		}

		// Token: 0x0603210A RID: 205066 RVA: 0x00C86F38 File Offset: 0x00C85138
		private IWuWaGoGridMoveParticipant GetRoleGridMoveParticipant()
		{
			if (this.RoleGridMoveParticipantInner == null)
			{
				WuWaGoGridMoveParticipant wuWaGoGridMoveParticipant = new WuWaGoGridMoveParticipant();
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Role:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Role.Id);
				wuWaGoGridMoveParticipant.ParticipantKey = defaultInterpolatedStringHandler.ToStringAndClear();
				wuWaGoGridMoveParticipant.MovedRoleId = new int?(this.Role.Id);
				wuWaGoGridMoveParticipant.CreateWorldMoveTarget = new Func<IWuWaGoGridRelocationContext, IWuWaGoWorldMoveTarget>(this.CreateRoleWorldMoveTarget);
				wuWaGoGridMoveParticipant.BeforeGridMove = new Action<IWuWaGoGridRelocationContext>(this.OnBeforeRoleGridMove);
				wuWaGoGridMoveParticipant.CommitGridMove = new Action<IWuWaGoGridRelocationContext>(this.OnCommitRoleGridMove);
				wuWaGoGridMoveParticipant.AfterGridMove = delegate(IWuWaGoGridRelocationContext context)
				{
					WuWaGoRoleController<TRole>.<<GetRoleGridMoveParticipant>b__42_0>d <<GetRoleGridMoveParticipant>b__42_0>d;
					<<GetRoleGridMoveParticipant>b__42_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
					<<GetRoleGridMoveParticipant>b__42_0>d.<>4__this = this;
					<<GetRoleGridMoveParticipant>b__42_0>d.context = context;
					<<GetRoleGridMoveParticipant>b__42_0>d.<>1__state = -1;
					<<GetRoleGridMoveParticipant>b__42_0>d.<>t__builder.Start<WuWaGoRoleController<TRole>.<<GetRoleGridMoveParticipant>b__42_0>d>(ref <<GetRoleGridMoveParticipant>b__42_0>d);
					return <<GetRoleGridMoveParticipant>b__42_0>d.<>t__builder.Task;
				};
				this.RoleGridMoveParticipantInner = wuWaGoGridMoveParticipant;
			}
			return this.RoleGridMoveParticipantInner;
		}

		// Token: 0x0401D444 RID: 119876
		public readonly AttackCapability Attack = new AttackCapability(role);

		// Token: 0x0401D445 RID: 119877
		public readonly HurtCapability Hurt = new HurtCapability(role);

		// Token: 0x0401D446 RID: 119878
		private readonly Vector TempForwardDir = Vector.Create();

		// Token: 0x0401D447 RID: 119879
		private readonly Vector TempStepCoordinate = Vector.Create();

		// Token: 0x0401D448 RID: 119880
		[Nullable(2)]
		private WuWaGoGrid RegisteredMoveGrid;

		// Token: 0x0401D449 RID: 119881
		[Nullable(2)]
		private IWuWaGoGridMoveParticipant RoleGridMoveParticipantInner;

		// Token: 0x0401D44A RID: 119882
		public readonly TRole Role = role;

		// Token: 0x0401D44B RID: 119883
		public readonly WuWaGoGameData GameData = gameData;

		// Token: 0x0401D44C RID: 119884
		protected readonly WuWaGoGameModeBase GameMode = gameMode;
	}
}
