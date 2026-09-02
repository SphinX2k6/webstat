using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using CSharpScript.Game.NewWorld.Pawn.SensoryInfo;

namespace CSharpScript.Game.NewWorld.Pawn.Component
{
	// Token: 0x020048B0 RID: 18608
	[NullableContext(1)]
	[Nullable(0)]
	public class PawnSensoryComponent : EntityComponent
	{
		// Token: 0x0603083B RID: 198715 RVA: 0x00BE93EC File Offset: 0x00BE75EC
		protected override bool OnInit()
		{
			this.LastSensoryRange = 0.0;
			this.IntervalTime = 0f;
			this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
			this.LastLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
			this.SensoryInfoController = new SensoryInfoController();
			return true;
		}

		// Token: 0x0603083C RID: 198716 RVA: 0x00BE9446 File Offset: 0x00BE7646
		public int AddSensoryInfo(BaseSensoryInfo sensoryParam)
		{
			if (this.ActorComp == null)
			{
				this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
			}
			int result = this.SensoryInfoController.AddSensoryInfo(sensoryParam);
			this.SetSensoryRange();
			return result;
		}

		// Token: 0x0603083D RID: 198717 RVA: 0x00BE9473 File Offset: 0x00BE7673
		public void RemoveSensoryInfo(int key)
		{
			this.SensoryInfoController.RemoveSensoryInfo(key);
			this.SetSensoryRange();
		}

		// Token: 0x0603083E RID: 198718 RVA: 0x00BE9488 File Offset: 0x00BE7688
		private void SetSensoryRange()
		{
			double maxSensoryRange = this.SensoryInfoController.MaxSensoryRange;
			if (this.LastSensoryRange != maxSensoryRange)
			{
				this.LastSensoryRange = maxSensoryRange;
			}
		}

		// Token: 0x0603083F RID: 198719 RVA: 0x00BE94B4 File Offset: 0x00BE76B4
		protected override void OnTick(float delta)
		{
			if (this.ActorComp == null || this.SensoryInfoController == null || this.SensoryInfoController.SensoryInfoType == 0)
			{
				return;
			}
			this.SensoryInfoController.Tick(delta);
			this.IntervalTime += delta;
			if (this.IntervalTime < 1000f)
			{
				return;
			}
			this.IntervalTime = 0f;
			if (this.TmpHandles != null)
			{
				if (!this.LastLocation.Equals(this.ActorComp.ActorLocationProxy, 9.999999747378752E-05))
				{
					this.LastLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
				}
				ModelBase<CreatureModel>.Instance.GetEntitiesInRangeWithLocation(this.ActorComp.ActorLocationProxy, (float)this.LastSensoryRange, EEntityTypeQuery.SceneItemOrCharacter, this.TmpHandles, true);
				this.SensoryInfoController.HandleEntities(this.TmpHandles.ToArray(), this.ActorComp.ActorLocationProxy, base.Entity.Id);
			}
		}

		// Token: 0x06030840 RID: 198720 RVA: 0x00BE95A8 File Offset: 0x00BE77A8
		protected override bool OnClear()
		{
			this.TmpHandles.Clear();
			SensoryInfoController sensoryInfoController = this.SensoryInfoController;
			if (sensoryInfoController != null)
			{
				sensoryInfoController.Clear();
			}
			return true;
		}

		// Token: 0x06030841 RID: 198721 RVA: 0x00BE95C8 File Offset: 0x00BE77C8
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			PawnSensoryComponent pawnSensoryComponent = (PawnSensoryComponent)componentTemplate;
			if (base.CanResetComponentProperty("LastSensoryRange"))
			{
				this.LastSensoryRange = pawnSensoryComponent.LastSensoryRange;
			}
			if (base.CanResetComponentProperty("SensoryInfoController"))
			{
				if (pawnSensoryComponent.SensoryInfoController == null)
				{
					this.SensoryInfoController = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SensoryInfoController>(this.SensoryInfoController), "SensoryInfoController"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IntervalTime"))
			{
				this.IntervalTime = pawnSensoryComponent.IntervalTime;
			}
			if (base.CanResetComponentProperty("TmpHandles") && pawnSensoryComponent.TmpHandles != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<EntityHandle>>(this.TmpHandles), "TmpHandles"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (pawnSensoryComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			return !base.CanResetComponentProperty("LastLocation") || pawnSensoryComponent.LastLocation == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.LastLocation), "LastLocation");
		}

		// Token: 0x0401BDF6 RID: 114166
		private const float TICK_INTERVAL_TIME = 1000f;

		// Token: 0x0401BDF7 RID: 114167
		private double LastSensoryRange;

		// Token: 0x0401BDF8 RID: 114168
		[Nullable(2)]
		private SensoryInfoController SensoryInfoController;

		// Token: 0x0401BDF9 RID: 114169
		private float IntervalTime;

		// Token: 0x0401BDFA RID: 114170
		private readonly List<EntityHandle> TmpHandles = new List<EntityHandle>();

		// Token: 0x0401BDFB RID: 114171
		[Nullable(2)]
		private BaseActorComponent ActorComp;

		// Token: 0x0401BDFC RID: 114172
		private readonly Vector LastLocation = Vector.Create();
	}
}
