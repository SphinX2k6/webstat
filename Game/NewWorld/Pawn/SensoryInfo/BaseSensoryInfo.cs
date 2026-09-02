using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Controllers;

namespace CSharpScript.Game.NewWorld.Pawn.SensoryInfo
{
	// Token: 0x020048A1 RID: 18593
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class BaseSensoryInfo
	{
		// Token: 0x170082A0 RID: 33440
		// (get) Token: 0x0603071D RID: 198429 RVA: 0x00BE055E File Offset: 0x00BDE75E
		public virtual ERangePerceptionType RangePerceptionType
		{
			get
			{
				return ERangePerceptionType.Dynamic;
			}
		}

		// Token: 0x170082A1 RID: 33441
		// (get) Token: 0x0603071E RID: 198430 RVA: 0x00BE0561 File Offset: 0x00BDE761
		public virtual ESensoryInfoType SensoryInfoType
		{
			get
			{
				return ESensoryInfoType.EnterAndExit;
			}
		}

		// Token: 0x0603071F RID: 198431 RVA: 0x00BE0564 File Offset: 0x00BDE764
		public void Init(params object[] @params)
		{
			this.OnInit(@params);
		}

		// Token: 0x06030720 RID: 198432 RVA: 0x00BE056D File Offset: 0x00BDE76D
		public void Tick(float delta)
		{
			if ((this.SensoryInfoType & ESensoryInfoType.Tick) != (ESensoryInfoType)0)
			{
				this.OnTick(delta);
			}
		}

		// Token: 0x06030721 RID: 198433 RVA: 0x00BE0580 File Offset: 0x00BDE780
		public void Clear()
		{
			this.InRange = false;
			this.SensoryRange = 0.0;
			this.OnClear();
		}

		// Token: 0x06030722 RID: 198434
		protected abstract void OnInit(params object[] @params);

		// Token: 0x06030723 RID: 198435
		protected abstract void OnTick(float delta);

		// Token: 0x06030724 RID: 198436
		protected abstract void OnClear();

		// Token: 0x06030725 RID: 198437 RVA: 0x00BE059E File Offset: 0x00BDE79E
		public bool CheckInRange()
		{
			return this.InRange;
		}

		// Token: 0x06030726 RID: 198438 RVA: 0x00BE05A6 File Offset: 0x00BDE7A6
		public virtual void ClearCacheList()
		{
		}

		// Token: 0x06030727 RID: 198439
		public abstract bool CheckEntity(Entity entity);

		// Token: 0x06030728 RID: 198440
		public abstract void EnterRange(Entity entity);

		// Token: 0x06030729 RID: 198441
		public abstract void ExitRange();

		// Token: 0x0401BD45 RID: 113989
		public double SensoryRange;

		// Token: 0x0401BD46 RID: 113990
		protected bool InRange;
	}
}
