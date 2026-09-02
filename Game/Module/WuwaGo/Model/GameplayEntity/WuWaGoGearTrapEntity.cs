using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AE5 RID: 19173
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoGearTrapEntity : WuWaGoGameplayEntityBase
	{
		// Token: 0x17008554 RID: 34132
		// (get) Token: 0x06031FCC RID: 204748 RVA: 0x00C8316C File Offset: 0x00C8136C
		public IReadOnlyList<int> TrackEntityIds
		{
			get
			{
				return this.TrackGridEntityIds;
			}
		}

		// Token: 0x17008555 RID: 34133
		// (get) Token: 0x06031FCD RID: 204749 RVA: 0x00C83174 File Offset: 0x00C81374
		public Vector MoveDirection { get; } = Vector.Create();

		// Token: 0x17008556 RID: 34134
		// (get) Token: 0x06031FCE RID: 204750 RVA: 0x00C8317C File Offset: 0x00C8137C
		public Vector Position { get; } = Vector.Create();

		// Token: 0x17008557 RID: 34135
		// (get) Token: 0x06031FCF RID: 204751 RVA: 0x00C83184 File Offset: 0x00C81384
		public Vector InitialCoordinate { get; } = Vector.Create();

		// Token: 0x06031FD0 RID: 204752 RVA: 0x00C8318C File Offset: 0x00C8138C
		public WuWaGoGearTrapEntity(int pbDataId, Vector coordinate, Rotator rotator, IWuWaGoGear config) : base(EWuWaGoEntityType.Gear, pbDataId, coordinate, rotator)
		{
			this.TrackGridEntityIds = new List<int>(config.GridEntityIds);
			this.InitialCoordinate.DeepCopy(coordinate);
			this.InitialRotator.DeepCopy(rotator);
			this.Position.DeepCopy(coordinate);
		}

		// Token: 0x06031FD1 RID: 204753 RVA: 0x00C83205 File Offset: 0x00C81405
		public override void Destroy()
		{
			this.PendingAttackTargetUnitId = null;
			this.ResetToInitialPosition();
			base.Destroy();
		}

		// Token: 0x06031FD2 RID: 204754 RVA: 0x00C8321F File Offset: 0x00C8141F
		public override IRollbackCapture CaptureRollback()
		{
			return new GearTrapRollbackCapture(this);
		}

		// Token: 0x06031FD3 RID: 204755 RVA: 0x00C83227 File Offset: 0x00C81427
		public void SetMoveDirection(Vector direction)
		{
			base.MarkRollbackDirty();
			this.MoveDirection.DeepCopy(direction);
		}

		// Token: 0x06031FD4 RID: 204756 RVA: 0x00C8323B File Offset: 0x00C8143B
		public void UpdateRotator(Rotator rotator)
		{
			base.SetRotator(rotator);
		}

		// Token: 0x06031FD5 RID: 204757 RVA: 0x00C83244 File Offset: 0x00C81444
		public void ReverseMoveDirection()
		{
			base.MarkRollbackDirty();
			this.MoveDirection.Set(-this.MoveDirection.X, -this.MoveDirection.Y, -this.MoveDirection.Z);
		}

		// Token: 0x06031FD6 RID: 204758 RVA: 0x00C8327B File Offset: 0x00C8147B
		public bool HasMoveDirection()
		{
			return !this.MoveDirection.IsNearlyZero(9.999999747378752E-05);
		}

		// Token: 0x06031FD7 RID: 204759 RVA: 0x00C83294 File Offset: 0x00C81494
		public unsafe void LogStay()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WuWaGo;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "齿轮轨道中断，保持原地";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("coordinate", this.Position);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("direction", this.MoveDirection);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06031FD8 RID: 204760 RVA: 0x00C83304 File Offset: 0x00C81504
		public unsafe void LogMove()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WuWaGo;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "齿轮移动";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("coordinate", this.Position);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("direction", this.MoveDirection);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06031FD9 RID: 204761 RVA: 0x00C83371 File Offset: 0x00C81571
		public void UpdatePosition(Vector newCoordinate)
		{
			base.MarkRollbackDirty();
			this.Position.DeepCopy(newCoordinate);
			base.SetCoordinate(newCoordinate);
		}

		// Token: 0x06031FDA RID: 204762 RVA: 0x00C8338C File Offset: 0x00C8158C
		public int? ConsumePendingAttackTargetUnitId()
		{
			int? pendingAttackTargetUnitId = this.PendingAttackTargetUnitId;
			base.MarkRollbackDirty();
			this.PendingAttackTargetUnitId = null;
			return pendingAttackTargetUnitId;
		}

		// Token: 0x06031FDB RID: 204763 RVA: 0x00C833A6 File Offset: 0x00C815A6
		public int? PeekPendingAttackTargetUnitId()
		{
			return this.PendingAttackTargetUnitId;
		}

		// Token: 0x06031FDC RID: 204764 RVA: 0x00C833AE File Offset: 0x00C815AE
		public void SetPendingAttackTargetUnitIdForRollback(int? id)
		{
			this.PendingAttackTargetUnitId = id;
		}

		// Token: 0x06031FDD RID: 204765 RVA: 0x00C833B7 File Offset: 0x00C815B7
		public void ResetToInitialPosition()
		{
			this.UpdatePosition(this.InitialCoordinate);
			base.SetRotator(this.InitialRotator);
			this.MoveDirection.Set(0.0, 0.0, 0.0);
		}

		// Token: 0x06031FDE RID: 204766 RVA: 0x00C833F7 File Offset: 0x00C815F7
		public override void RestoreInitialStateForGameOver()
		{
			base.RestoreInitialStateWithStateChanged();
		}

		// Token: 0x06031FDF RID: 204767 RVA: 0x00C833FF File Offset: 0x00C815FF
		[NullableContext(2)]
		protected override void OnBeforeStandGridChanged(WuWaGoGrid prevGrid, WuWaGoGrid nextGrid)
		{
			if (prevGrid != null)
			{
				prevGrid.RemoveOccupiedUnitChangedListener(new WuWaGoGridOccupiedUnitChangedListener(this.OnGridOccupiedUnitChanged));
			}
		}

		// Token: 0x06031FE0 RID: 204768 RVA: 0x00C83416 File Offset: 0x00C81616
		[NullableContext(2)]
		protected override void OnAfterStandGridChanged(WuWaGoGrid prevGrid, WuWaGoGrid nextGrid)
		{
			if (nextGrid == null)
			{
				return;
			}
			nextGrid.AddOccupiedUnitChangedListener(new WuWaGoGridOccupiedUnitChangedListener(this.OnGridOccupiedUnitChanged));
			this.QueueOccupantAttack(nextGrid.OccupiedUnitId);
		}

		// Token: 0x06031FE1 RID: 204769 RVA: 0x00C8343A File Offset: 0x00C8163A
		protected override void OnStateChanged(EGameplayEntityState newState)
		{
			base.SwitchSceneItemStateByGameplayEntityState(newState, true, false);
		}

		// Token: 0x06031FE2 RID: 204770 RVA: 0x00C83445 File Offset: 0x00C81645
		private void OnGridOccupiedUnitChanged(WuWaGoGrid grid, int prevUnitId, int currentUnitId)
		{
			this.QueueOccupantAttack(currentUnitId);
		}

		// Token: 0x06031FE3 RID: 204771 RVA: 0x00C83450 File Offset: 0x00C81650
		private void QueueOccupantAttack(int unitId)
		{
			int? num = (unitId == 0) ? null : new int?(unitId);
			int? pendingAttackTargetUnitId = this.PendingAttackTargetUnitId;
			int? num2 = num;
			if (pendingAttackTargetUnitId.GetValueOrDefault() == num2.GetValueOrDefault() & pendingAttackTargetUnitId != null == (num2 != null))
			{
				return;
			}
			base.MarkRollbackDirty();
			this.PendingAttackTargetUnitId = num;
		}

		// Token: 0x0401D3EB RID: 119787
		private readonly List<int> TrackGridEntityIds;

		// Token: 0x0401D3EC RID: 119788
		private readonly Rotator InitialRotator = Rotator.Create();

		// Token: 0x0401D3ED RID: 119789
		private int? PendingAttackTargetUnitId;
	}
}
