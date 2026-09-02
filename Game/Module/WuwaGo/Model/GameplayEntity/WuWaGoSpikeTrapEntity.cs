using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AEF RID: 19183
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoSpikeTrapEntity : WuWaGoGameplayEntityBase
	{
		// Token: 0x17008564 RID: 34148
		// (get) Token: 0x0603202C RID: 204844 RVA: 0x00C83D63 File Offset: 0x00C81F63
		public bool IsCompleted
		{
			get
			{
				return base.State == EGameplayEntityState.Completed;
			}
		}

		// Token: 0x17008565 RID: 34149
		// (get) Token: 0x0603202D RID: 204845 RVA: 0x00C83D6E File Offset: 0x00C81F6E
		public int CurrentStepCount
		{
			get
			{
				return this.StepCount;
			}
		}

		// Token: 0x0603202E RID: 204846 RVA: 0x00C83D76 File Offset: 0x00C81F76
		public WuWaGoSpikeTrapEntity(int pbDataId, Vector coordinate, Rotator rotator, IWuWaGoSpikeTrap config) : base(EWuWaGoEntityType.SpikeTrap, pbDataId, coordinate, rotator)
		{
		}

		// Token: 0x0603202F RID: 204847 RVA: 0x00C83D82 File Offset: 0x00C81F82
		public override void Destroy()
		{
			this.StepCount = 0;
			this.OccupantId = 0;
			this.PrevOccupantId = 0;
			this.IsDirty = false;
			base.Destroy();
		}

		// Token: 0x06032030 RID: 204848 RVA: 0x00C83DA6 File Offset: 0x00C81FA6
		public override IRollbackCapture CaptureRollback()
		{
			return new SpikeTrapRollbackCapture(this);
		}

		// Token: 0x06032031 RID: 204849 RVA: 0x00C83DAE File Offset: 0x00C81FAE
		public int PeekOccupantId()
		{
			return this.OccupantId;
		}

		// Token: 0x06032032 RID: 204850 RVA: 0x00C83DB6 File Offset: 0x00C81FB6
		public int PeekPrevOccupantId()
		{
			return this.PrevOccupantId;
		}

		// Token: 0x06032033 RID: 204851 RVA: 0x00C83DBE File Offset: 0x00C81FBE
		public bool PeekIsDirty()
		{
			return this.IsDirty;
		}

		// Token: 0x06032034 RID: 204852 RVA: 0x00C83DC6 File Offset: 0x00C81FC6
		public void RestoreOccupantTrackingForRollback(int stepCount, int occupantId, int prevOccupantId, bool isDirty)
		{
			this.StepCount = stepCount;
			this.OccupantId = occupantId;
			this.PrevOccupantId = prevOccupantId;
			this.IsDirty = isDirty;
			this.SyncPresentationForRollback();
		}

		// Token: 0x06032035 RID: 204853 RVA: 0x00C83DEB File Offset: 0x00C81FEB
		public void SyncPresentationForRollback()
		{
			base.SwitchSceneItemStateByGameplayEntityState(base.State, false, true);
		}

		// Token: 0x06032036 RID: 204854 RVA: 0x00C83DFB File Offset: 0x00C81FFB
		[NullableContext(2)]
		protected override void OnBeforeStandGridChanged(WuWaGoGrid prevGrid, WuWaGoGrid nextGrid)
		{
			if (prevGrid != null)
			{
				prevGrid.RemoveOccupiedUnitChangedListener(new WuWaGoGridOccupiedUnitChangedListener(this.OnGridOccupiedUnitChanged));
			}
		}

		// Token: 0x06032037 RID: 204855 RVA: 0x00C83E12 File Offset: 0x00C82012
		[NullableContext(2)]
		protected override void OnAfterStandGridChanged(WuWaGoGrid prevGrid, WuWaGoGrid nextGrid)
		{
			if (nextGrid == null)
			{
				return;
			}
			nextGrid.AddOccupiedUnitChangedListener(new WuWaGoGridOccupiedUnitChangedListener(this.OnGridOccupiedUnitChanged));
		}

		// Token: 0x06032038 RID: 204856 RVA: 0x00C83E2A File Offset: 0x00C8202A
		private void OnGridOccupiedUnitChanged(WuWaGoGrid grid, int prevUnitId, int currentUnitId)
		{
			this.UpdateOccupant(currentUnitId);
		}

		// Token: 0x06032039 RID: 204857 RVA: 0x00C83E33 File Offset: 0x00C82033
		private void UpdateOccupant(int unitId)
		{
			if (this.OccupantId == unitId)
			{
				return;
			}
			base.MarkRollbackDirty();
			this.PrevOccupantId = this.OccupantId;
			this.OccupantId = unitId;
			this.IsDirty = true;
		}

		// Token: 0x0603203A RID: 204858 RVA: 0x00C83E5F File Offset: 0x00C8205F
		public void ResetOccupantTrackingBaseline(int unitId)
		{
			this.OccupantId = unitId;
			this.PrevOccupantId = unitId;
			this.IsDirty = false;
		}

		// Token: 0x0603203B RID: 204859 RVA: 0x00C83E78 File Offset: 0x00C82078
		public int? ConsumeEnterOccupantId()
		{
			if (!this.IsDirty)
			{
				return null;
			}
			base.MarkRollbackDirty();
			this.IsDirty = false;
			int num = (this.PrevOccupantId != 0) ? 1 : 0;
			bool flag = this.OccupantId != 0;
			if (num == 0 && flag)
			{
				return new int?(this.OccupantId);
			}
			return null;
		}

		// Token: 0x0603203C RID: 204860 RVA: 0x00C83ED3 File Offset: 0x00C820D3
		public bool OnStepped()
		{
			if (base.State == EGameplayEntityState.Completed)
			{
				return true;
			}
			base.MarkRollbackDirty();
			this.StepCount++;
			if (this.StepCount == 1)
			{
				this.SetState(EGameplayEntityState.Activated);
				return false;
			}
			this.SetState(EGameplayEntityState.Completed);
			return true;
		}

		// Token: 0x0603203D RID: 204861 RVA: 0x00C83F10 File Offset: 0x00C82110
		public override void RestoreInitialStateForGameOver()
		{
			base.RestoreInitialStateWithStateChanged();
		}

		// Token: 0x0603203E RID: 204862 RVA: 0x00C83F18 File Offset: 0x00C82118
		protected override void OnStateChanged(EGameplayEntityState newState)
		{
			base.SwitchSceneItemStateByGameplayEntityState(newState, true, false);
		}

		// Token: 0x0401D407 RID: 119815
		private int StepCount;

		// Token: 0x0401D408 RID: 119816
		private int OccupantId;

		// Token: 0x0401D409 RID: 119817
		private int PrevOccupantId;

		// Token: 0x0401D40A RID: 119818
		private bool IsDirty;
	}
}
