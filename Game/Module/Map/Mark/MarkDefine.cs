using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.Map.Mark
{
	// Token: 0x0200581E RID: 22558
	[NullableContext(1)]
	[Nullable(0)]
	[StaticVariableRuleIgnore]
	public class MarkDefine
	{
		// Token: 0x040209E5 RID: 133605
		public static readonly HashSet<EMarkType> PermanentUpdateTypeSet = new HashSet<EMarkType>
		{
			EMarkType.OtherPlayers,
			EMarkType.EnrichmentArea,
			EMarkType.TreasureBoxDetector,
			EMarkType.FishingShip
		};

		// Token: 0x040209E6 RID: 133606
		public static readonly HashSet<EMarkType> CanOutOfBoundUpdateTypeSet = new HashSet<EMarkType>
		{
			EMarkType.OtherPlayers
		};

		// Token: 0x040209E7 RID: 133607
		public static readonly HashSet<EMarkType> PermanentShowInGravityLayerTypeSet = new HashSet<EMarkType>
		{
			EMarkType.OtherPlayers,
			EMarkType.EnrichmentArea,
			EMarkType.EnrichmentCollectProduct,
			EMarkType.TreasureBoxDetector,
			EMarkType.TreasureBox,
			EMarkType.SoundBox,
			EMarkType.CalmingWindBell
		};

		// Token: 0x040209E8 RID: 133608
		public static readonly HashSet<EMarkType> AllFloorShowMarkTypeSet = new HashSet<EMarkType>
		{
			EMarkType.Custom,
			EMarkType.SoundBox,
			EMarkType.TreasureBoxDetector
		};

		// Token: 0x040209E9 RID: 133609
		public const int HONAMI_SCAN_MARK_ITEM_ID = 157012;

		// Token: 0x0200B898 RID: 47256
		[NullableContext(0)]
		[RequiredMember]
		public class FishingShipMarkCacheInfo
		{
			// Token: 0x0604D430 RID: 316464 RVA: 0x01550272 File Offset: 0x0154E472
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public FishingShipMarkCacheInfo()
			{
			}

			// Token: 0x0403913D RID: 233789
			[RequiredMember]
			public int InstanceId;

			// Token: 0x0403913E RID: 233790
			[RequiredMember]
			public int TemplateId;

			// Token: 0x0403913F RID: 233791
			[RequiredMember]
			public double PositionX;

			// Token: 0x04039140 RID: 233792
			[RequiredMember]
			public double PositionY;

			// Token: 0x04039141 RID: 233793
			[RequiredMember]
			public double PositionZ;
		}

		// Token: 0x0200B899 RID: 47257
		[NullableContext(0)]
		public class EMarkLockShowState
		{
			// Token: 0x04039142 RID: 233794
			public const int Hide = 0;

			// Token: 0x04039143 RID: 233795
			public const int Show = 1;
		}
	}
}
