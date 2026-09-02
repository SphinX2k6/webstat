using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.TuningStand
{
	// Token: 0x02006A73 RID: 27251
	[NullableContext(1)]
	[Nullable(0)]
	public class TuningGridData
	{
		// Token: 0x1700A25A RID: 41562
		// (get) Token: 0x0604367F RID: 276095 RVA: 0x0115D360 File Offset: 0x0115B560
		// (set) Token: 0x0604367E RID: 276094 RVA: 0x0115D32B File Offset: 0x0115B52B
		public int Index
		{
			get
			{
				return this.IndexInner;
			}
			set
			{
				this.IndexInner = value;
				this.GridLoc[0] = (int)Math.Floor((double)((float)this.Index / 7f));
				this.GridLoc[1] = this.Index % 7;
			}
		}

		// Token: 0x06043680 RID: 276096 RVA: 0x0115D368 File Offset: 0x0115B568
		public ITuningStateData GetCurGridState()
		{
			if (!this.IsStatic)
			{
				return this.DynamicState;
			}
			return this.StaticState;
		}

		// Token: 0x06043681 RID: 276097 RVA: 0x0115D37F File Offset: 0x0115B57F
		public double GetCenterDistance()
		{
			return (double)(Math.Abs(this.GridLoc[0] - (int)Math.Floor(2.5)) + Math.Abs(this.GridLoc[1] - (int)Math.Floor(3.5)));
		}

		// Token: 0x04025A30 RID: 154160
		private int IndexInner;

		// Token: 0x04025A31 RID: 154161
		public bool IsStatic = true;

		// Token: 0x04025A32 RID: 154162
		public int[] GridLoc = new int[]
		{
			-1,
			-1
		};

		// Token: 0x04025A33 RID: 154163
		public ETuningStandGridType GridType;

		// Token: 0x04025A34 RID: 154164
		public EGridMainType GridMainType;

		// Token: 0x04025A35 RID: 154165
		public int GridValue;

		// Token: 0x04025A36 RID: 154166
		public ITuningStateData StaticState = new TuningStateData
		{
			State = EGridBelongType.Empty
		};

		// Token: 0x04025A37 RID: 154167
		public ITuningStateData DynamicState = new TuningStateData
		{
			State = EGridBelongType.Empty
		};
	}
}
