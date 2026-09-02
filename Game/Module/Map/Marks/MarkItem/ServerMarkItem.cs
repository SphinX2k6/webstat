using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.WorldMap;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005855 RID: 22613
	[NullableContext(1)]
	[Nullable(0)]
	public class ServerMarkItem : MarkItem
	{
		// Token: 0x170092C8 RID: 37576
		// (get) Token: 0x0603982D RID: 235565 RVA: 0x00E97E64 File Offset: 0x00E96064
		// (set) Token: 0x0603982E RID: 235566 RVA: 0x00E97E93 File Offset: 0x00E96093
		public override int MarkId
		{
			get
			{
				DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
				return ((serverMarkInfo != null) ? serverMarkInfo.MarkId : null).GetValueOrDefault();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170092C9 RID: 37577
		// (get) Token: 0x0603982F RID: 235567 RVA: 0x00E97E9A File Offset: 0x00E9609A
		public override EMarkType MarkType
		{
			get
			{
				DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
				if (serverMarkInfo == null)
				{
					return EMarkType.None;
				}
				return serverMarkInfo.MarkType;
			}
		}

		// Token: 0x170092CA RID: 37578
		// (get) Token: 0x06039830 RID: 235568 RVA: 0x00E97EAD File Offset: 0x00E960AD
		public int ConfigId
		{
			get
			{
				return this.ServerMarkInfo.MarkConfigId;
			}
		}

		// Token: 0x170092CB RID: 37579
		// (get) Token: 0x06039831 RID: 235569 RVA: 0x00E97EBA File Offset: 0x00E960BA
		public TTrackTarget TrackPosition
		{
			get
			{
				if (!(this.ServerMarkInfo.TrackTarget is TTrackTarget_Vector) && !(this.ServerMarkInfo.TrackTarget is TTrackTarget_Vector2D))
				{
					return new TTrackTarget_Vector(new global::Vector());
				}
				return this.ServerMarkInfo.TrackTarget;
			}
		}

		// Token: 0x170092CC RID: 37580
		// (get) Token: 0x06039832 RID: 235570 RVA: 0x00E97EF8 File Offset: 0x00E960F8
		public int EntityConfigId
		{
			get
			{
				return this.ServerMarkInfo.EntityConfigId.GetValueOrDefault();
			}
		}

		// Token: 0x170092CD RID: 37581
		// (get) Token: 0x06039833 RID: 235571 RVA: 0x00E97F18 File Offset: 0x00E96118
		public int RawInstanceDungeonId
		{
			get
			{
				return this.ServerMarkInfo.InstanceDungeonId.GetValueOrDefault();
			}
		}

		// Token: 0x06039834 RID: 235572 RVA: 0x00E97F38 File Offset: 0x00E96138
		public override bool IsMultiMap()
		{
			return this.GetMultiMapId() != 0;
		}

		// Token: 0x170092CE RID: 37582
		// (get) Token: 0x06039835 RID: 235573 RVA: 0x00E97F43 File Offset: 0x00E96143
		public override int? TrackAreaId
		{
			get
			{
				if (this.EntityConfigId == 0)
				{
					return new int?(0);
				}
				return new int?(ModelBase<WorldMapModel>.Instance.GetEntityAreaId(this.EntityConfigId, new int?(this.MapId)));
			}
		}

		// Token: 0x06039836 RID: 235574 RVA: 0x00E97F74 File Offset: 0x00E96174
		public override int GetMultiMapId()
		{
			if (this.EntityConfigId == 0)
			{
				return 0;
			}
			return this.GetMultiMapIdSub();
		}

		// Token: 0x06039837 RID: 235575 RVA: 0x00E97F88 File Offset: 0x00E96188
		protected int GetMultiMapIdSub()
		{
			if (this.MultiMapIdInternal != null)
			{
				return this.MultiMapIdInternal.Value;
			}
			int valueOrDefault = this.TrackAreaId.GetValueOrDefault();
			int levelOneAreaId = ConfigBase<AreaConfig>.Instance.GetLevelOneAreaId(valueOrDefault);
			foreach (MultiMap multiMap in ConfigBase<MapConfig>.Instance.GetAllSubMapConfig())
			{
				if (multiMap.GetAreaBytes().Contains(levelOneAreaId) || multiMap.GetAreaBytes().Contains(valueOrDefault))
				{
					this.MultiMapIdInternal = new int?(multiMap.Id);
					break;
				}
			}
			if (this.MultiMapIdInternal == null)
			{
				this.MultiMapIdInternal = new int?(0);
			}
			return this.MultiMapIdInternal.Value;
		}

		// Token: 0x170092CF RID: 37583
		// (get) Token: 0x06039838 RID: 235576 RVA: 0x00E98064 File Offset: 0x00E96264
		public bool IsServerDisable
		{
			get
			{
				return this.ServerMarkInfo.ServerMarkState == MarkState.MarkDisable;
			}
		}

		// Token: 0x170092D0 RID: 37584
		// (get) Token: 0x06039839 RID: 235577 RVA: 0x00E98074 File Offset: 0x00E96274
		public override int MapId
		{
			get
			{
				return this.ServerMarkInfo.MapId;
			}
		}

		// Token: 0x170092D1 RID: 37585
		// (get) Token: 0x0603983A RID: 235578 RVA: 0x00E98081 File Offset: 0x00E96281
		public override int? InstanceDungeonId
		{
			get
			{
				return this.ServerMarkInfo.InstanceDungeonId;
			}
		}

		// Token: 0x0603983B RID: 235579 RVA: 0x00E98090 File Offset: 0x00E96290
		public ServerMarkItem(DynamicMarkCreateInfo markPointInfo, UUIItem parent, EMapType mapType, float markScale) : base(parent, mapType, markScale, markPointInfo.TrackSource.GetValueOrDefault(ETrackSource.MapMark))
		{
			this.ServerMarkInfo = markPointInfo;
			if (MapDefine.ServerMarkIgnoreReadConfigSet.Contains(markPointInfo.MarkType))
			{
				base.ShowPriority = 0;
				return;
			}
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markPointInfo.MarkConfigId);
			base.ShowPriority = ((configMark != null) ? configMark.GetValueOrDefault().ShowPriority : 0);
		}

		// Token: 0x0603983C RID: 235580 RVA: 0x00E98109 File Offset: 0x00E96309
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.ServerMarkItemView;
		}

		// Token: 0x0603983D RID: 235581 RVA: 0x00E9810D File Offset: 0x00E9630D
		protected override MarkItemView CreateView()
		{
			return new ServerMarkItemView(this);
		}

		// Token: 0x0603983E RID: 235582 RVA: 0x00E98118 File Offset: 0x00E96318
		protected bool CheckInShowRange(float scale)
		{
			return base.MapType != EMapType.WorldMap || base.IsIgnoreScaleShow || Math.Abs(this.MinShowScale - this.MaxShowScale) < 1E-08f || (this.MinShowScale < scale && this.MaxShowScale > scale);
		}

		// Token: 0x0603983F RID: 235583 RVA: 0x00E9816C File Offset: 0x00E9636C
		[NullableContext(2)]
		protected virtual void OnAfterSetConfigId(IMarkItemData markData)
		{
			if (markData != null)
			{
				int[] showRange = markData.ShowRange;
				if (showRange != null && showRange.Length >= 2)
				{
					this.MinShowScale = (float)showRange[0];
					this.MaxShowScale = (float)showRange[1];
				}
				this.IconPath = markData.MarkPic;
				MarkItemView view = base.View;
				if (view != null)
				{
					view.OnIconPathChanged(this.IconPath);
				}
				if (markData.ShowPriority != null && markData.ShowPriority.Value != 0)
				{
					base.ShowPriority = markData.ShowPriority.Value;
				}
				base.ConfigScale = markData.Scale.GetValueOrDefault(1f);
				base.CornerScale = markData.CornerScale.GetValueOrDefault(1f);
			}
		}

		// Token: 0x06039840 RID: 235584 RVA: 0x00E9822C File Offset: 0x00E9642C
		public override bool CheckCanShowView()
		{
			float currentMapShowScale = this.GetCurrentMapShowScale();
			bool flag = this.CheckInShowRange(currentMapShowScale) || base.IsTracked;
			if (base.IsCanShowViewIntermediately != flag)
			{
				base.NeedPlayShowOrHideSeq = (flag ? "ShowView" : "HideView");
			}
			return flag;
		}

		// Token: 0x06039841 RID: 235585 RVA: 0x00E98274 File Offset: 0x00E96474
		public string GetAreaText()
		{
			MapMark? mapMark;
			string[] array = ((ConfigBase<MapConfig>.Instance.GetConfigMark(this.ConfigId) != null) ? mapMark.GetValueOrDefault().AreaShowText() : null) ?? Array.Empty<string>();
			if (array.Length != 0)
			{
				return string.Join("-", from item in array
				select ConfigBase<MapConfig>.Instance.GetLocalText(item));
			}
			return ModelBase<MapModel>.Instance.GetMarkAreaText(this.MapId, this.EntityConfigId);
		}

		// Token: 0x04020A7C RID: 133756
		protected float MinShowScale;

		// Token: 0x04020A7D RID: 133757
		protected float MaxShowScale;

		// Token: 0x04020A7E RID: 133758
		protected readonly DynamicMarkCreateInfo ServerMarkInfo;

		// Token: 0x04020A7F RID: 133759
		private int? MultiMapIdInternal;
	}
}
