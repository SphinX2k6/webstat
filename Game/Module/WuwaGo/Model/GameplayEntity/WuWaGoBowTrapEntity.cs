using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AE1 RID: 19169
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoBowTrapEntity : WuWaGoGameplayEntityBase
	{
		// Token: 0x06031FA3 RID: 204707 RVA: 0x00C82CF3 File Offset: 0x00C80EF3
		public WuWaGoBowTrapEntity(int pbDataId, Vector coordinate, Rotator rotator, IWuWaGoBowTrap config) : base(EWuWaGoEntityType.BowTrap, pbDataId, coordinate, rotator)
		{
		}

		// Token: 0x1700854A RID: 34122
		// (get) Token: 0x06031FA4 RID: 204708 RVA: 0x00C82D1A File Offset: 0x00C80F1A
		public IWuWaGoBowTrap Config { get; } = config;

		// Token: 0x1700854B RID: 34123
		// (get) Token: 0x06031FA5 RID: 204709 RVA: 0x00C82D22 File Offset: 0x00C80F22
		public Vector Direction { get; } = WuWaGoBowTrapEntity.CalcShootDirection(rotator);

		// Token: 0x06031FA6 RID: 204710 RVA: 0x00C82D2C File Offset: 0x00C80F2C
		private static Vector CalcShootDirection(Rotator rotator)
		{
			Vector vector = Vector.Create();
			rotator.Quaternion(null).RotateVector(Vector.RightVectorProxy, vector);
			vector.Set(Math.Round(vector.X), Math.Round(vector.Y), Math.Round(vector.Z));
			return vector;
		}

		// Token: 0x06031FA7 RID: 204711 RVA: 0x00C82D79 File Offset: 0x00C80F79
		public bool CanShootInRound(int round)
		{
			return base.State == EGameplayEntityState.Activated && this.LastShootRound != round;
		}

		// Token: 0x06031FA8 RID: 204712 RVA: 0x00C82D92 File Offset: 0x00C80F92
		public void MarkShotInRound(int round)
		{
			if (this.LastShootRound == round)
			{
				return;
			}
			base.MarkRollbackDirty();
			this.LastShootRound = round;
		}

		// Token: 0x06031FA9 RID: 204713 RVA: 0x00C82DAB File Offset: 0x00C80FAB
		public int PeekLastShootRound()
		{
			return this.LastShootRound;
		}

		// Token: 0x06031FAA RID: 204714 RVA: 0x00C82DB3 File Offset: 0x00C80FB3
		public override void Destroy()
		{
			this.LastShootRound = -1;
			base.Destroy();
		}

		// Token: 0x06031FAB RID: 204715 RVA: 0x00C82DC2 File Offset: 0x00C80FC2
		public override IRollbackCapture CaptureRollback()
		{
			return new BowTrapRollbackCapture(this);
		}

		// Token: 0x06031FAC RID: 204716 RVA: 0x00C82DCA File Offset: 0x00C80FCA
		public override void RestoreInitialStateForGameOver()
		{
			this.LastShootRound = -1;
			base.RestoreInitialStateWithStateChanged();
		}

		// Token: 0x06031FAD RID: 204717 RVA: 0x00C82DD9 File Offset: 0x00C80FD9
		protected override void OnStateChanged(EGameplayEntityState newState)
		{
			base.SwitchSceneItemStateByGameplayEntityState(newState, true, false);
		}

		// Token: 0x0401D3DB RID: 119771
		private int LastShootRound = -1;
	}
}
