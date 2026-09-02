using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Model.Role
{
	// Token: 0x02004ADD RID: 19165
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleRollbackCapture<[Nullable(0)] TRole> : ActorWorldRollbackCapture<TRole> where TRole : WuWaGoRole
	{
		// Token: 0x06031F7A RID: 204666 RVA: 0x00C82628 File Offset: 0x00C80828
		public RoleRollbackCapture(TRole role) : base(role)
		{
			this.Hp = role.Hp;
			this.StandGridId = role.StandGridId;
			this.Coordinate = Vector.Create();
			this.Coordinate.DeepCopy(role.Coordinate);
			this.Rotator = Rotator.Create();
			this.Rotator.DeepCopy(role.Rotator);
			this.IsClimbing = role.IsClimbing;
		}

		// Token: 0x17008540 RID: 34112
		// (get) Token: 0x06031F7B RID: 204667 RVA: 0x00C826B1 File Offset: 0x00C808B1
		protected TRole Role
		{
			get
			{
				return this.Unit;
			}
		}

		// Token: 0x06031F7C RID: 204668 RVA: 0x00C826BC File Offset: 0x00C808BC
		public override void Restore()
		{
			this.Role.SetHp(this.Hp);
			this.Role.SetRotator(this.Rotator);
			this.Role.SetIsClimbing(this.IsClimbing);
			WuWaGoGrid wuWaGoGrid = (this.StandGridId == 0) ? null : ModelBase<WuWaGoModel>.Instance.GetGridById(this.StandGridId);
			this.Role.SetStandGrid(wuWaGoGrid, null);
			if (wuWaGoGrid == null)
			{
				this.Role.SetCoordinate(this.Coordinate);
			}
			base.RestoreActorWorldTransform();
			this.Role.ClearMaterialHandles();
		}

		// Token: 0x0401D3CC RID: 119756
		private readonly int Hp;

		// Token: 0x0401D3CD RID: 119757
		private readonly int StandGridId;

		// Token: 0x0401D3CE RID: 119758
		private readonly Vector Coordinate;

		// Token: 0x0401D3CF RID: 119759
		private readonly Rotator Rotator;

		// Token: 0x0401D3D0 RID: 119760
		private readonly bool IsClimbing;
	}
}
