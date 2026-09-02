using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Model.Role
{
	// Token: 0x02004ADA RID: 19162
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class MoveMonsterRollbackCapture : RoleRollbackCapture<WuWaGoMoveMonster>
	{
		// Token: 0x06031F63 RID: 204643 RVA: 0x00C823D4 File Offset: 0x00C805D4
		public MoveMonsterRollbackCapture(WuWaGoMoveMonster monster) : base(monster)
		{
			this.FootprintIds = new List<int>();
			foreach (WuWaGoGrid wuWaGoGrid in monster.Footprints)
			{
				this.FootprintIds.Add(wuWaGoGrid.Id);
			}
			this.IsTracking = monster.IsTracking;
			this.LastSeenPlayerGridId = monster.LastSeenPlayerGridId;
			this.HasObservedPlayer = monster.HasObservedPlayer;
		}

		// Token: 0x06031F64 RID: 204644 RVA: 0x00C82464 File Offset: 0x00C80664
		public override void Restore()
		{
			base.Restore();
			base.Role.ClearFootprints();
			WuWaGoModel instance = ModelBase<WuWaGoModel>.Instance;
			foreach (int gridId in this.FootprintIds)
			{
				WuWaGoGrid wuWaGoGrid = (instance != null) ? instance.GetGridById(gridId) : null;
				if (wuWaGoGrid != null)
				{
					base.Role.PushFootprint(wuWaGoGrid);
				}
			}
			base.Role.SetIsTracking(this.IsTracking);
			base.Role.SetLastSeenPlayerGridId(this.LastSeenPlayerGridId);
			base.Role.SetHasObservedPlayer(this.HasObservedPlayer);
		}

		// Token: 0x0401D3C4 RID: 119748
		private readonly List<int> FootprintIds;

		// Token: 0x0401D3C5 RID: 119749
		private readonly bool IsTracking;

		// Token: 0x0401D3C6 RID: 119750
		private readonly int LastSeenPlayerGridId;

		// Token: 0x0401D3C7 RID: 119751
		private readonly bool HasObservedPlayer;
	}
}
