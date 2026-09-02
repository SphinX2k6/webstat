using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem.Jigsaw;

namespace CSharpScript.Game.LevelGamePlay.RollBlock
{
	// Token: 0x02006B17 RID: 27415
	[NullableContext(1)]
	[Nullable(0)]
	public class RbBaseComponent : EntityComponent
	{
		// Token: 0x06043BE8 RID: 277480 RVA: 0x0117B06C File Offset: 0x0117926C
		public virtual void RegisterToGameplay(int incId)
		{
			this.IncId = incId;
			this.OriginForward = ControllerBase<RollBlockController>.Instance.GetForwardVector(this.IncId);
			this.OriginRight = ControllerBase<RollBlockController>.Instance.GetRightVector(this.IncId);
		}

		// Token: 0x06043BE9 RID: 277481 RVA: 0x0117B0A1 File Offset: 0x011792A1
		public virtual bool IsMoving()
		{
			return false;
		}

		// Token: 0x06043BEA RID: 277482 RVA: 0x0117B0A4 File Offset: 0x011792A4
		public virtual void OnActualShow()
		{
		}

		// Token: 0x06043BEB RID: 277483 RVA: 0x0117B0A8 File Offset: 0x011792A8
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			RbBaseComponent rbBaseComponent = (RbBaseComponent)componentTemplate;
			if (base.CanResetComponentProperty("IncId"))
			{
				this.IncId = rbBaseComponent.IncId;
			}
			if (base.CanResetComponentProperty("OriginForward"))
			{
				if (rbBaseComponent.OriginForward == null)
				{
					this.OriginForward = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.OriginForward), "OriginForward"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("OriginRight"))
			{
				if (rbBaseComponent.OriginRight == null)
				{
					this.OriginRight = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.OriginRight), "OriginRight"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsMainController"))
			{
				this.IsMainController = rbBaseComponent.IsMainController;
			}
			if (base.CanResetComponentProperty("OccupiedCellIndex"))
			{
				if (rbBaseComponent.OccupiedCellIndex == null)
				{
					this.OccupiedCellIndex = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<JigsawIndex>>(this.OccupiedCellIndex), "OccupiedCellIndex"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04025DFD RID: 155133
		public int IncId;

		// Token: 0x04025DFE RID: 155134
		[Nullable(2)]
		public Vector OriginForward;

		// Token: 0x04025DFF RID: 155135
		[Nullable(2)]
		public Vector OriginRight;

		// Token: 0x04025E00 RID: 155136
		public bool IsMainController;

		// Token: 0x04025E01 RID: 155137
		public List<JigsawIndex> OccupiedCellIndex = new List<JigsawIndex>();
	}
}
