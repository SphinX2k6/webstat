using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058D8 RID: 22744
	[NullableContext(1)]
	[Nullable(0)]
	[StaticVariableRuleIgnore]
	public static class MapDefine
	{
		// Token: 0x04020BA9 RID: 134057
		public const float FLOAT_0_01 = 0.01f;

		// Token: 0x04020BAA RID: 134058
		public static readonly global::Vector world2UiUnit = global::Vector.Create(0.009999999776482582, -0.009999999776482582, 0.009999999776482582);

		// Token: 0x04020BAB RID: 134059
		public static readonly Vector2D worldToScreenScale = Vector2D.Create(0.009999999776482582, -0.009999999776482582);

		// Token: 0x04020BAC RID: 134060
		public const int DETAIL_TILE_REALSIZE = 850;

		// Token: 0x04020BAD RID: 134061
		public const int MINI_MAP_RADIUS = 200;

		// Token: 0x04020BAE RID: 134062
		public const int MINI_MAP_UPDATE_GAP = 20;

		// Token: 0x04020BAF RID: 134063
		public const int MINI_MAP_DEFAULT_SCALE = 150;

		// Token: 0x04020BB0 RID: 134064
		public const int UNIT = 100;

		// Token: 0x04020BB1 RID: 134065
		public const int MARK_SCOPE = 50;

		// Token: 0x04020BB2 RID: 134066
		public const int MARK_HASH_XY_PANDING = 100000;

		// Token: 0x04020BB3 RID: 134067
		public const float MARK_WORLD_TO_HASH_SCALE = 0.01f;

		// Token: 0x04020BB4 RID: 134068
		public const int BIG_WORLD_MAP_ID = 8;

		// Token: 0x04020BB5 RID: 134069
		public const int HHA_BIG_WORLD_MAP_ID = 900;

		// Token: 0x04020BB6 RID: 134070
		public const int DETAIL_TILE_SPACE = 850;

		// Token: 0x04020BB7 RID: 134071
		public const int DEFAULT_MAP_BORDER_ID = 1;

		// Token: 0x04020BB8 RID: 134072
		public const float WORLD_MAP_MAX_SCALE = 2.5f;

		// Token: 0x04020BB9 RID: 134073
		public const int HONAMI_MAP_ID = 907;

		// Token: 0x04020BBA RID: 134074
		public const int FISHING_SHIP_MARK_ID = 8;

		// Token: 0x04020BBB RID: 134075
		public static readonly HashSet<EMarkType> HasSingleComponentMarkType = new HashSet<EMarkType>
		{
			EMarkType.TreasureBoxDetector,
			EMarkType.Quest,
			EMarkType.EnrichmentArea
		};

		// Token: 0x04020BBC RID: 134076
		public static readonly HashSet<EMarkType> CanDisableGameplayFinishMarkType = new HashSet<EMarkType>
		{
			EMarkType.CommonGamePlay
		};

		// Token: 0x04020BBD RID: 134077
		public static readonly HashSet<EMarkType> ServerMarkIgnoreReadConfigSet = new HashSet<EMarkType>
		{
			EMarkType.Quest,
			EMarkType.Custom,
			EMarkType.EnrichmentArea,
			EMarkType.EnrichmentCollectProduct
		};

		// Token: 0x04020BBE RID: 134078
		public static readonly HashSet<EMarkType> MapLoadDirectlyConfigMarkSet = new HashSet<EMarkType>
		{
			EMarkType.FloatLightForest
		};

		// Token: 0x04020BBF RID: 134079
		public static readonly HashSet<PbMapMarkType.Types.ENUMS> AddMarkFilterInTeamModeSet = new HashSet<PbMapMarkType.Types.ENUMS>
		{
			PbMapMarkType.Types.ENUMS.TreasureBoxPoint,
			PbMapMarkType.Types.ENUMS.SoundBox,
			PbMapMarkType.Types.ENUMS.HookLockSoundBox,
			PbMapMarkType.Types.ENUMS.CalmingWindBell
		};
	}
}
