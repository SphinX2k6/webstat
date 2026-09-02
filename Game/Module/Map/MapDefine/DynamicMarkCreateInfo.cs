using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058B2 RID: 22706
	[NullableContext(1)]
	[Nullable(0)]
	public class DynamicMarkCreateInfo : MarkCreateInfo
	{
		// Token: 0x17009323 RID: 37667
		// (get) Token: 0x06039AE0 RID: 236256 RVA: 0x00E9FC47 File Offset: 0x00E9DE47
		// (set) Token: 0x06039AE1 RID: 236257 RVA: 0x00E9FC54 File Offset: 0x00E9DE54
		public TTrackTarget TrackTarget
		{
			get
			{
				return this.CreateParams.TrackTarget;
			}
			set
			{
				this.CreateParams.TrackTarget = value;
			}
		}

		// Token: 0x17009324 RID: 37668
		// (get) Token: 0x06039AE2 RID: 236258 RVA: 0x00E9FC62 File Offset: 0x00E9DE62
		// (set) Token: 0x06039AE3 RID: 236259 RVA: 0x00E9FC6F File Offset: 0x00E9DE6F
		public int MarkConfigId
		{
			get
			{
				return this.CreateParams.MarkConfigId;
			}
			set
			{
				this.CreateParams.MarkConfigId = value;
			}
		}

		// Token: 0x17009325 RID: 37669
		// (get) Token: 0x06039AE4 RID: 236260 RVA: 0x00E9FC7D File Offset: 0x00E9DE7D
		public EMarkType MarkType
		{
			get
			{
				return this.CreateParams.MarkType;
			}
		}

		// Token: 0x17009326 RID: 37670
		// (get) Token: 0x06039AE5 RID: 236261 RVA: 0x00E9FC8A File Offset: 0x00E9DE8A
		// (set) Token: 0x06039AE6 RID: 236262 RVA: 0x00E9FC97 File Offset: 0x00E9DE97
		public int? MarkId
		{
			get
			{
				return this.CreateParams.MarkId;
			}
			set
			{
				this.CreateParams.MarkId = value;
			}
		}

		// Token: 0x17009327 RID: 37671
		// (get) Token: 0x06039AE7 RID: 236263 RVA: 0x00E9FCA5 File Offset: 0x00E9DEA5
		public ETrackSource? TrackSource
		{
			get
			{
				return this.CreateParams.TrackSource;
			}
		}

		// Token: 0x17009328 RID: 37672
		// (get) Token: 0x06039AE8 RID: 236264 RVA: 0x00E9FCB4 File Offset: 0x00E9DEB4
		public bool DestroyOnUnTrack
		{
			get
			{
				return this.CreateParams.DestroyOnUnTrack.GetValueOrDefault();
			}
		}

		// Token: 0x17009329 RID: 37673
		// (get) Token: 0x06039AE9 RID: 236265 RVA: 0x00E9FCD4 File Offset: 0x00E9DED4
		// (set) Token: 0x06039AEA RID: 236266 RVA: 0x00E9FCE1 File Offset: 0x00E9DEE1
		public int? TeleportId
		{
			get
			{
				return this.CreateParams.TeleportId;
			}
			set
			{
				this.CreateParams.TeleportId = value;
			}
		}

		// Token: 0x1700932A RID: 37674
		// (get) Token: 0x06039AEB RID: 236267 RVA: 0x00E9FCEF File Offset: 0x00E9DEEF
		public int? EntityConfigId
		{
			get
			{
				return this.CreateParams.EntityConfigId;
			}
		}

		// Token: 0x1700932B RID: 37675
		// (get) Token: 0x06039AEC RID: 236268 RVA: 0x00E9FCFC File Offset: 0x00E9DEFC
		// (set) Token: 0x06039AED RID: 236269 RVA: 0x00E9FD09 File Offset: 0x00E9DF09
		public int? AreaId
		{
			get
			{
				return this.CreateParams.AreaId;
			}
			set
			{
				this.CreateParams.AreaId = value;
			}
		}

		// Token: 0x1700932C RID: 37676
		// (get) Token: 0x06039AEE RID: 236270 RVA: 0x00E9FD18 File Offset: 0x00E9DF18
		// (set) Token: 0x06039AEF RID: 236271 RVA: 0x00E9FD38 File Offset: 0x00E9DF38
		public MarkState ServerMarkState
		{
			get
			{
				return this.CreateParams.ServerMarkState.GetValueOrDefault();
			}
			set
			{
				this.CreateParams.ServerMarkState = new MarkState?(value);
			}
		}

		// Token: 0x1700932D RID: 37677
		// (get) Token: 0x06039AF0 RID: 236272 RVA: 0x00E9FD4B File Offset: 0x00E9DF4B
		public int MapId { get; }

		// Token: 0x1700932E RID: 37678
		// (get) Token: 0x06039AF1 RID: 236273 RVA: 0x00E9FD53 File Offset: 0x00E9DF53
		public int? InstanceDungeonId { get; }

		// Token: 0x1700932F RID: 37679
		// (get) Token: 0x06039AF2 RID: 236274 RVA: 0x00E9FD5B File Offset: 0x00E9DF5B
		public EMapGravityDirection MapGravity
		{
			get
			{
				if (this._cachedMapGravity != null)
				{
					return this._cachedMapGravity.Value;
				}
				this._cachedMapGravity = new EMapGravityDirection?(this.CalculateMapGravity());
				return this._cachedMapGravity.Value;
			}
		}

		// Token: 0x06039AF3 RID: 236275 RVA: 0x00E9FD94 File Offset: 0x00E9DF94
		private EMapGravityDirection CalculateMapGravity()
		{
			if (this.CreateParams.Gravity != null)
			{
				return this.CreateParams.Gravity.Value;
			}
			if (this.EntityConfigId != null)
			{
				EMapGravityDirection entityGravityDirection = ConfigBase<WorldMapConfig>.Instance.GetEntityGravityDirection(this.MapId, this.EntityConfigId.Value);
				if (entityGravityDirection != EMapGravityDirection.All)
				{
					return entityGravityDirection;
				}
			}
			EMarkType markType = this.MarkType;
			if (markType == EMarkType.Custom || markType == EMarkType.TemporaryTeleport || markType == EMarkType.TreasureBoxDetector)
			{
				return EMapGravityDirection.All;
			}
			if (!ModelBase<WorldMapModel>.Instance.IsGravityMap(this.MapId))
			{
				return EMapGravityDirection.All;
			}
			return EMapGravityDirection.Down;
		}

		// Token: 0x06039AF4 RID: 236276 RVA: 0x00E9FE2C File Offset: 0x00E9E02C
		public DynamicMarkCreateInfo(IDynamicMarkCreateParams @params) : base(EMarkCreateType.DynamicMark)
		{
			this.CreateParams = @params;
			if (this.CreateParams.MapAndDungeonInfo == null)
			{
				this.CreateParams.MapAndDungeonInfo = new MapAndDungeonInfo
				{
					MapConfigId = new int?(8)
				};
			}
			if (@params.MarkType == EMarkType.Quest)
			{
				int? dungeonId = this.CreateParams.MapAndDungeonInfo.DungeonId;
				if (dungeonId != null)
				{
					this.CreateParams.MapAndDungeonInfo.MapConfigId = dungeonId;
				}
			}
			int? mapConfigId = this.CreateParams.MapAndDungeonInfo.MapConfigId;
			if ((mapConfigId ?? 1) == 0)
			{
				mapConfigId = new int?(8);
			}
			if (mapConfigId != null)
			{
				this.CreateParams.MapAndDungeonInfo.MapConfigId = mapConfigId;
			}
			else
			{
				OneOf<MapMark, DynamicMapMark>? oneOf = ConfigBase<MapConfig>.Instance.SearchMapConfigByType(this.CreateParams.MarkConfigId, @params.MarkType);
				this.CreateParams.MapAndDungeonInfo.MapConfigId = new int?(oneOf.Value.IsT1 ? oneOf.Value.AsT1.MapId : oneOf.Value.AsT2.MapId);
			}
			MapAndDungeonInfo mapAndDungeonInfo = this.CreateParams.MapAndDungeonInfo;
			int? dungeonId2 = mapAndDungeonInfo.DungeonId;
			if (dungeonId2 == null)
			{
				mapAndDungeonInfo.DungeonId = ConfigBase<MapConfig>.Instance.SearchMarkInstanceDungeonId(this.CreateParams.MarkConfigId, @params.MarkType);
			}
			this.MapId = this.CreateParams.MapAndDungeonInfo.MapConfigId.Value;
			this.InstanceDungeonId = this.CreateParams.MapAndDungeonInfo.DungeonId;
		}

		// Token: 0x04020B06 RID: 133894
		protected IDynamicMarkCreateParams CreateParams;

		// Token: 0x04020B07 RID: 133895
		private EMapGravityDirection? _cachedMapGravity;
	}
}
