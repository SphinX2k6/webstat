using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.WuwaGo.Model.Role
{
	// Token: 0x02004ADB RID: 19163
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoMoveMonster : WuWaGoRole
	{
		// Token: 0x06031F65 RID: 204645 RVA: 0x00C82518 File Offset: 0x00C80718
		public WuWaGoMoveMonster(Vector coordinate, Rotator rotator) : base(EWuWaGoRoleType.DiffractionEnemy, coordinate, rotator)
		{
		}

		// Token: 0x1700853A RID: 34106
		// (get) Token: 0x06031F66 RID: 204646 RVA: 0x00C8252E File Offset: 0x00C8072E
		public override bool Actionable
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700853B RID: 34107
		// (get) Token: 0x06031F67 RID: 204647 RVA: 0x00C82531 File Offset: 0x00C80731
		public override bool MoveAbility
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700853C RID: 34108
		// (get) Token: 0x06031F68 RID: 204648 RVA: 0x00C82534 File Offset: 0x00C80734
		public IReadOnlyList<WuWaGoGrid> Footprints
		{
			get
			{
				return this.FootprintsInner;
			}
		}

		// Token: 0x1700853D RID: 34109
		// (get) Token: 0x06031F69 RID: 204649 RVA: 0x00C8253C File Offset: 0x00C8073C
		// (set) Token: 0x06031F6A RID: 204650 RVA: 0x00C82544 File Offset: 0x00C80744
		public bool IsTracking { get; private set; }

		// Token: 0x1700853E RID: 34110
		// (get) Token: 0x06031F6B RID: 204651 RVA: 0x00C8254D File Offset: 0x00C8074D
		// (set) Token: 0x06031F6C RID: 204652 RVA: 0x00C82555 File Offset: 0x00C80755
		public int LastSeenPlayerGridId { get; private set; }

		// Token: 0x1700853F RID: 34111
		// (get) Token: 0x06031F6D RID: 204653 RVA: 0x00C8255E File Offset: 0x00C8075E
		// (set) Token: 0x06031F6E RID: 204654 RVA: 0x00C82566 File Offset: 0x00C80766
		public bool HasObservedPlayer { get; private set; }

		// Token: 0x06031F6F RID: 204655 RVA: 0x00C8256F File Offset: 0x00C8076F
		public void PushFootprint(WuWaGoGrid grid)
		{
			base.MarkRollbackDirty();
			this.FootprintsInner.Add(grid);
		}

		// Token: 0x06031F70 RID: 204656 RVA: 0x00C82583 File Offset: 0x00C80783
		public void ClearFootprints()
		{
			if (this.FootprintsInner.Count == 0)
			{
				return;
			}
			base.MarkRollbackDirty();
			this.FootprintsInner.Clear();
		}

		// Token: 0x06031F71 RID: 204657 RVA: 0x00C825A4 File Offset: 0x00C807A4
		[NullableContext(2)]
		public WuWaGoGrid ShiftFootprint()
		{
			if (this.FootprintsInner.Count == 0)
			{
				return null;
			}
			base.MarkRollbackDirty();
			WuWaGoGrid result = this.FootprintsInner[0];
			this.FootprintsInner.RemoveAt(0);
			return result;
		}

		// Token: 0x06031F72 RID: 204658 RVA: 0x00C825D3 File Offset: 0x00C807D3
		public void SetIsTracking(bool value)
		{
			if (this.IsTracking == value)
			{
				return;
			}
			base.MarkRollbackDirty();
			this.IsTracking = value;
		}

		// Token: 0x06031F73 RID: 204659 RVA: 0x00C825EC File Offset: 0x00C807EC
		public void SetLastSeenPlayerGridId(int value)
		{
			if (this.LastSeenPlayerGridId == value)
			{
				return;
			}
			base.MarkRollbackDirty();
			this.LastSeenPlayerGridId = value;
		}

		// Token: 0x06031F74 RID: 204660 RVA: 0x00C82605 File Offset: 0x00C80805
		public void SetHasObservedPlayer(bool value)
		{
			if (this.HasObservedPlayer == value)
			{
				return;
			}
			base.MarkRollbackDirty();
			this.HasObservedPlayer = value;
		}

		// Token: 0x06031F75 RID: 204661 RVA: 0x00C8261E File Offset: 0x00C8081E
		public override IRollbackCapture CaptureRollback()
		{
			return new MoveMonsterRollbackCapture(this);
		}

		// Token: 0x0401D3C8 RID: 119752
		private readonly List<WuWaGoGrid> FootprintsInner = new List<WuWaGoGrid>();
	}
}
