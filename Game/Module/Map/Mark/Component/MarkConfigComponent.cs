using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.Base;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.Map.Mark.Component
{
	// Token: 0x02005828 RID: 22568
	public class MarkConfigComponent : MapComponent
	{
		// Token: 0x060395E4 RID: 234980 RVA: 0x00E90584 File Offset: 0x00E8E784
		public MarkConfigComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x17009238 RID: 37432
		// (get) Token: 0x060395E5 RID: 234981 RVA: 0x00E9058D File Offset: 0x00E8E78D
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.MarkConfig;
			}
		}

		// Token: 0x17009239 RID: 37433
		// (get) Token: 0x060395E6 RID: 234982 RVA: 0x00E90594 File Offset: 0x00E8E794
		public int? RelativeId
		{
			get
			{
				if (!this.Config.HasValue)
				{
					return null;
				}
				if (this.Config.IsT1)
				{
					return new int?(this.Config.AsT1.RelativeId);
				}
				if (this.Config.IsT2)
				{
					return new int?(this.Config.AsT2.RelativeId);
				}
				return null;
			}
		}

		// Token: 0x1700923A RID: 37434
		// (get) Token: 0x060395E7 RID: 234983 RVA: 0x00E90610 File Offset: 0x00E8E810
		public EMarkRelativeSubType? RelativeSubType
		{
			get
			{
				if (!this.Config.HasValue)
				{
					return null;
				}
				if (this.Config.IsT1)
				{
					return new EMarkRelativeSubType?((EMarkRelativeSubType)this.Config.AsT1.RelativeSubType);
				}
				if (this.Config.IsT2)
				{
					return new EMarkRelativeSubType?((EMarkRelativeSubType)this.Config.AsT2.RelativeSubType);
				}
				return null;
			}
		}

		// Token: 0x1700923B RID: 37435
		// (get) Token: 0x060395E8 RID: 234984 RVA: 0x00E9068C File Offset: 0x00E8E88C
		public int? MarkId
		{
			get
			{
				if (!this.Config.HasValue)
				{
					return null;
				}
				if (this.Config.IsT1)
				{
					return new int?(this.Config.AsT1.MarkId);
				}
				if (this.Config.IsT2)
				{
					return new int?(this.Config.AsT2.MarkId);
				}
				if (this.Config.IsT3)
				{
					return new int?(this.Config.AsT3.MarkId);
				}
				return null;
			}
		}

		// Token: 0x1700923C RID: 37436
		// (get) Token: 0x060395E9 RID: 234985 RVA: 0x00E9072C File Offset: 0x00E8E92C
		public EMarkRelativeType? RelativeType
		{
			get
			{
				if (!this.Config.HasValue)
				{
					return null;
				}
				if (this.Config.IsT1)
				{
					return new EMarkRelativeType?((EMarkRelativeType)this.Config.AsT1.RelativeType);
				}
				if (this.Config.IsT2)
				{
					return new EMarkRelativeType?((EMarkRelativeType)this.Config.AsT2.RelativeType);
				}
				return null;
			}
		}

		// Token: 0x1700923D RID: 37437
		// (get) Token: 0x060395EA RID: 234986 RVA: 0x00E907A8 File Offset: 0x00E8E9A8
		public int? RelativeDungeonId
		{
			get
			{
				if (!this.Config.HasValue)
				{
					return null;
				}
				if (this.Config.IsT1)
				{
					return new int?(this.Config.AsT1.RelativeDungeonId);
				}
				if (this.Config.IsT2)
				{
					return new int?(this.Config.AsT2.RelativeDungeonId);
				}
				return null;
			}
		}

		// Token: 0x1700923E RID: 37438
		// (get) Token: 0x060395EB RID: 234987 RVA: 0x00E90824 File Offset: 0x00E8EA24
		public int? FogHide
		{
			get
			{
				if (!this.Config.HasValue)
				{
					return null;
				}
				if (this.Config.IsT1)
				{
					return new int?(this.Config.AsT1.FogHide);
				}
				if (this.Config.IsT2)
				{
					return new int?(this.Config.AsT2.FogHide);
				}
				return null;
			}
		}

		// Token: 0x04020A21 RID: 133665
		public OneOf<MapMark, DynamicMapMark, TreasureBoxDetectorMark> Config;
	}
}
