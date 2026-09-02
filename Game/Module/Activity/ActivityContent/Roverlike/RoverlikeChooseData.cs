using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200639F RID: 25503
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeChooseData
	{
		// Token: 0x060400A1 RID: 262305 RVA: 0x01069EEC File Offset: 0x010680EC
		public RoverlikeChooseData(RoverRogueChooseData proto)
		{
			this.BindId = proto.BindId;
			this.Type = proto.Type;
			this.Layer = proto.Layer;
			this.IsSelect = proto.IsSelect;
			this.MaxTime = proto.MaxTime;
			this.UseTime = proto.UseTime;
			this.RefreshCost = proto.RefreshCost;
			this.Entries = new List<RoverlikeGainEntry>();
			if (proto.Entries != null)
			{
				foreach (RoverRogueGainEntry proto2 in proto.Entries)
				{
					this.Entries.Add(new RoverlikeGainEntry(proto2));
				}
			}
		}

		// Token: 0x060400A2 RID: 262306 RVA: 0x01069FBC File Offset: 0x010681BC
		public bool EnableRefresh()
		{
			return this.MaxTime > 0;
		}

		// Token: 0x060400A3 RID: 262307 RVA: 0x01069FC7 File Offset: 0x010681C7
		public bool HasRefreshTime()
		{
			return this.UseTime < this.MaxTime;
		}

		// Token: 0x060400A4 RID: 262308 RVA: 0x01069FD7 File Offset: 0x010681D7
		public bool HasRefreshCost()
		{
			return ModelBase<RoverlikeModel>.Instance.Gold >= this.RefreshCost;
		}

		// Token: 0x060400A5 RID: 262309 RVA: 0x01069FEE File Offset: 0x010681EE
		public bool CanRefresh()
		{
			return this.EnableRefresh() && this.UseTime < this.MaxTime && ModelBase<RoverlikeModel>.Instance.Gold >= this.RefreshCost;
		}

		// Token: 0x04023F3D RID: 147261
		public int BindId;

		// Token: 0x04023F3E RID: 147262
		public int SubViewIncId;

		// Token: 0x04023F3F RID: 147263
		public RoverRogueGainOperateType Type;

		// Token: 0x04023F40 RID: 147264
		public int Layer;

		// Token: 0x04023F41 RID: 147265
		public bool IsSelect;

		// Token: 0x04023F42 RID: 147266
		public int MaxTime;

		// Token: 0x04023F43 RID: 147267
		public int UseTime;

		// Token: 0x04023F44 RID: 147268
		public int RefreshCost;

		// Token: 0x04023F45 RID: 147269
		public List<RoverlikeGainEntry> Entries = new List<RoverlikeGainEntry>();
	}
}
