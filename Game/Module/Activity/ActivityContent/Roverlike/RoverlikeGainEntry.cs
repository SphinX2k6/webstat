using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063A0 RID: 25504
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeGainEntry
	{
		// Token: 0x17009D69 RID: 40297
		// (get) Token: 0x060400A6 RID: 262310 RVA: 0x0106A01F File Offset: 0x0106821F
		public int ItemRemainingRooms
		{
			get
			{
				if (this.Type == RoverRogueGainDataType.RoverRogueGainItem)
				{
					return this.ItemRemainingRoomsInternal;
				}
				return 0;
			}
		}

		// Token: 0x060400A7 RID: 262311 RVA: 0x0106A032 File Offset: 0x01068232
		public RoverlikeGainEntry()
		{
		}

		// Token: 0x060400A8 RID: 262312 RVA: 0x0106A03A File Offset: 0x0106823A
		public RoverlikeGainEntry(RoverRogueGainEntry proto)
		{
			this.Type = proto.Type;
			this.ConfigId = proto.ConfigId;
			this.IncId = proto.IncId;
			this.ItemRemainingRoomsInternal = proto.ItemRemainingRooms;
		}

		// Token: 0x060400A9 RID: 262313 RVA: 0x0106A072 File Offset: 0x01068272
		public static RoverlikeGainEntry Create(RoverRogueGainDataType type, int configId)
		{
			return new RoverlikeGainEntry
			{
				Type = type,
				ConfigId = configId
			};
		}

		// Token: 0x04023F46 RID: 147270
		public RoverRogueGainDataType Type;

		// Token: 0x04023F47 RID: 147271
		public int ConfigId;

		// Token: 0x04023F48 RID: 147272
		public int IncId;

		// Token: 0x04023F49 RID: 147273
		protected int ItemRemainingRoomsInternal;
	}
}
