using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AE9 RID: 19177
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoPressureTriggerEntity : WuWaGoGameplayEntityBase
	{
		// Token: 0x06032001 RID: 204801 RVA: 0x00C83A0A File Offset: 0x00C81C0A
		public WuWaGoPressureTriggerEntity(int pbDataId, Vector coordinate, Rotator rotator, IWuWaGoPressureTrigger config) : base(EWuWaGoEntityType.PressureTrigger, pbDataId, coordinate, rotator)
		{
		}

		// Token: 0x1700855B RID: 34139
		// (get) Token: 0x06032002 RID: 204802 RVA: 0x00C83A30 File Offset: 0x00C81C30
		// (set) Token: 0x06032003 RID: 204803 RVA: 0x00C83A38 File Offset: 0x00C81C38
		public int CurrentOccupantId { get; private set; }

		// Token: 0x1700855C RID: 34140
		// (get) Token: 0x06032004 RID: 204804 RVA: 0x00C83A41 File Offset: 0x00C81C41
		// (set) Token: 0x06032005 RID: 204805 RVA: 0x00C83A49 File Offset: 0x00C81C49
		public bool Dirty { get; private set; }

		// Token: 0x1700855D RID: 34141
		// (get) Token: 0x06032006 RID: 204806 RVA: 0x00C83A52 File Offset: 0x00C81C52
		public bool IsOccupied
		{
			get
			{
				return this.CurrentOccupantId != 0;
			}
		}

		// Token: 0x06032007 RID: 204807 RVA: 0x00C83A5D File Offset: 0x00C81C5D
		public override void Destroy()
		{
			this.CurrentOccupantId = 0;
			this.Dirty = false;
			base.Destroy();
		}

		// Token: 0x06032008 RID: 204808 RVA: 0x00C83A73 File Offset: 0x00C81C73
		public override IRollbackCapture CaptureRollback()
		{
			return new PressureTriggerRollbackCapture(this);
		}

		// Token: 0x06032009 RID: 204809 RVA: 0x00C83A7B File Offset: 0x00C81C7B
		public void RestoreOccupantStateForRollback(int occupantId, bool isDirty)
		{
			this.CurrentOccupantId = occupantId;
			this.Dirty = isDirty;
		}

		// Token: 0x0603200A RID: 204810 RVA: 0x00C83A8B File Offset: 0x00C81C8B
		public void SyncPresentationForRollback()
		{
			base.SwitchSceneItemStateByGameplayEntityState(base.State, false, true);
		}

		// Token: 0x0603200B RID: 204811 RVA: 0x00C83A9B File Offset: 0x00C81C9B
		[NullableContext(2)]
		protected override void OnBeforeStandGridChanged(WuWaGoGrid prevGrid, WuWaGoGrid nextGrid)
		{
			if (prevGrid != null)
			{
				prevGrid.RemoveOccupiedUnitChangedListener(new WuWaGoGridOccupiedUnitChangedListener(this.OnGridOccupiedUnitChanged));
			}
		}

		// Token: 0x0603200C RID: 204812 RVA: 0x00C83AB2 File Offset: 0x00C81CB2
		[NullableContext(2)]
		protected override void OnAfterStandGridChanged(WuWaGoGrid prevGrid, WuWaGoGrid nextGrid)
		{
			if (nextGrid == null)
			{
				return;
			}
			nextGrid.AddOccupiedUnitChangedListener(new WuWaGoGridOccupiedUnitChangedListener(this.OnGridOccupiedUnitChanged));
			this.UpdateOccupant(nextGrid.OccupiedUnitId);
		}

		// Token: 0x0603200D RID: 204813 RVA: 0x00C83AD6 File Offset: 0x00C81CD6
		private void OnGridOccupiedUnitChanged(WuWaGoGrid grid, int prevUnitId, int currentUnitId)
		{
			this.UpdateOccupant(currentUnitId);
		}

		// Token: 0x0603200E RID: 204814 RVA: 0x00C83ADF File Offset: 0x00C81CDF
		private void UpdateOccupant(int unitId)
		{
			if (this.CurrentOccupantId == unitId)
			{
				return;
			}
			base.MarkRollbackDirty();
			this.CurrentOccupantId = unitId;
			this.Dirty = true;
		}

		// Token: 0x0603200F RID: 204815 RVA: 0x00C83AFF File Offset: 0x00C81CFF
		public bool ConsumeDirtyFlag()
		{
			bool dirty = this.Dirty;
			if (dirty)
			{
				base.MarkRollbackDirty();
				this.Dirty = false;
			}
			return dirty;
		}

		// Token: 0x06032010 RID: 204816 RVA: 0x00C83B17 File Offset: 0x00C81D17
		public override void RestoreInitialStateForGameOver()
		{
			base.RestoreInitialStateWithStateChanged();
		}

		// Token: 0x06032011 RID: 204817 RVA: 0x00C83B1F File Offset: 0x00C81D1F
		protected override void OnStateChanged(EGameplayEntityState newState)
		{
			base.SwitchSceneItemStateByGameplayEntityState(newState, true, false);
		}

		// Token: 0x0401D3FB RID: 119803
		public readonly IReadOnlyList<ActionInfo> EnterActionList = config.EnterActionList;

		// Token: 0x0401D3FC RID: 119804
		public readonly IReadOnlyList<ActionInfo> ExitActionList = config.ExitActionList;
	}
}
