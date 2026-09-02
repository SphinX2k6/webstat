using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.WorldMap;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200583E RID: 22590
	[NullableContext(1)]
	[Nullable(0)]
	public class DynamicConfigMarkItem : MarkItem
	{
		// Token: 0x17009281 RID: 37505
		// (get) Token: 0x060396D8 RID: 235224 RVA: 0x00E94558 File Offset: 0x00E92758
		public bool IsFogUnlock
		{
			get
			{
				DynamicMapMark value = this.MarkConfig.Value;
				return value.FogShow == 1 || ModelBase<MapModel>.Instance.CheckFogUnlocked(value.FogHide, null);
			}
		}

		// Token: 0x17009282 RID: 37506
		// (get) Token: 0x060396D9 RID: 235225 RVA: 0x00E94597 File Offset: 0x00E92797
		// (set) Token: 0x060396DA RID: 235226 RVA: 0x00E9459F File Offset: 0x00E9279F
		public override int MarkId { get; set; }

		// Token: 0x17009283 RID: 37507
		// (get) Token: 0x060396DB RID: 235227 RVA: 0x00E945A8 File Offset: 0x00E927A8
		public int MarkConfigId
		{
			get
			{
				return this.MarkConfig.Value.MarkId;
			}
		}

		// Token: 0x17009284 RID: 37508
		// (get) Token: 0x060396DC RID: 235228 RVA: 0x00E945C8 File Offset: 0x00E927C8
		public override EMarkType MarkType
		{
			get
			{
				return (EMarkType)this.MarkConfig.Value.ObjectType;
			}
		}

		// Token: 0x17009285 RID: 37509
		// (get) Token: 0x060396DE RID: 235230 RVA: 0x00E945F1 File Offset: 0x00E927F1
		// (set) Token: 0x060396DD RID: 235229 RVA: 0x00E945E8 File Offset: 0x00E927E8
		public int? OverrideMapId { get; set; }

		// Token: 0x17009286 RID: 37510
		// (get) Token: 0x060396DF RID: 235231 RVA: 0x00E945FC File Offset: 0x00E927FC
		public override int MapId
		{
			get
			{
				int? overrideMapId = this.OverrideMapId;
				if (overrideMapId == null)
				{
					return this.MarkConfig.Value.MapId;
				}
				return overrideMapId.GetValueOrDefault();
			}
		}

		// Token: 0x17009287 RID: 37511
		// (get) Token: 0x060396E0 RID: 235232 RVA: 0x00E94634 File Offset: 0x00E92834
		public override int? InstanceDungeonId
		{
			get
			{
				return new int?(this.MarkConfig.Value.InstanceDungeonId);
			}
		}

		// Token: 0x060396E1 RID: 235233 RVA: 0x00E9465C File Offset: 0x00E9285C
		public DynamicConfigMarkItem(int markId, DynamicMapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(parent, mapType, markScale, trackSource)
		{
			this.MarkId = markId;
			base.ShowPriority = markConfig.ShowPriority;
			this.MarkConfig = new DynamicMapMark?(markConfig);
			this.IconPath = this.MarkConfig.Value.LockMarkPic;
		}

		// Token: 0x060396E2 RID: 235234 RVA: 0x00E946B8 File Offset: 0x00E928B8
		protected override void OnInitialize()
		{
			if (this.MarkConfig != null && this.MarkConfig.Value.Scale != 0f)
			{
				base.SetConfigScale(this.MarkConfig.Value.Scale);
			}
			this.InitPosition(this.MarkConfig.Value);
			this.InitShowCondition();
		}

		// Token: 0x060396E3 RID: 235235 RVA: 0x00E9471C File Offset: 0x00E9291C
		protected void InitPosition(DynamicMapMark markConfig)
		{
			if (markConfig.EntityConfigId > 0)
			{
				base.SetTrackData(markConfig.EntityConfigId);
				this.UpdateVisibleRelativeState();
				return;
			}
			if (markConfig.MarkVector != null)
			{
				base.SetTrackData(global::Vector.Create((double)markConfig.MarkVector.Value.X, (double)markConfig.MarkVector.Value.Y, (double)markConfig.MarkVector.Value.Z));
				this.UpdateVisibleRelativeState();
			}
		}

		// Token: 0x060396E4 RID: 235236 RVA: 0x00E947BB File Offset: 0x00E929BB
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.DynamicConfigMarkItemView;
		}

		// Token: 0x060396E5 RID: 235237 RVA: 0x00E947BE File Offset: 0x00E929BE
		[PreserveBaseOverrides]
		protected new virtual DynamicConfigMarkItemView CreateView()
		{
			return new DynamicConfigMarkItemView(this);
		}

		// Token: 0x060396E6 RID: 235238 RVA: 0x00E947C8 File Offset: 0x00E929C8
		public override string GetLocaleDesc()
		{
			return this.MarkConfig.Value.MarkDesc;
		}

		// Token: 0x060396E7 RID: 235239 RVA: 0x00E947E8 File Offset: 0x00E929E8
		public override string GetTitleText()
		{
			return ConfigBase<MapConfig>.Instance.GetLocalText(this.MarkConfig.Value.MarkTitle);
		}

		// Token: 0x17009288 RID: 37512
		// (get) Token: 0x060396E8 RID: 235240 RVA: 0x00E94814 File Offset: 0x00E92A14
		public override int? TrackAreaId
		{
			get
			{
				TTrackTarget_Int ttrackTarget_Int = base.TrackTarget as TTrackTarget_Int;
				if (ttrackTarget_Int == null || ttrackTarget_Int == 0)
				{
					return null;
				}
				return new int?(ModelBase<WorldMapModel>.Instance.GetEntityAreaId(ttrackTarget_Int, new int?(this.MapId)));
			}
		}

		// Token: 0x060396E9 RID: 235241 RVA: 0x00E94864 File Offset: 0x00E92A64
		[NullableContext(2)]
		public string GetAreaText()
		{
			if (!(base.TrackTarget is TTrackTarget_Int))
			{
				return null;
			}
			if (this.TrackAreaId != null)
			{
				return ModelBase<MapModel>.Instance.GetMarkAreaTextByAreaId(this.TrackAreaId.Value);
			}
			MapMark? mapMark;
			string[] array = (ConfigBase<MapConfig>.Instance.GetConfigMark(this.MarkConfigId) != null) ? mapMark.GetValueOrDefault().AreaShowText() : null;
			if (array != null && array.Length != 0)
			{
				return string.Join("-", from item in array
				select ConfigBase<MapConfig>.Instance.GetLocalText(item));
			}
			return ModelBase<MapModel>.Instance.GetMarkAreaText(this.MapId, base.TrackTarget as TTrackTarget_Int);
		}

		// Token: 0x060396EA RID: 235242 RVA: 0x00E94930 File Offset: 0x00E92B30
		private bool CheckInShowRange(float scale)
		{
			DynamicMapMark value = this.MarkConfig.Value;
			return (float)value.ShowRange(0) < scale && (float)value.ShowRange(1) > scale;
		}

		// Token: 0x060396EB RID: 235243 RVA: 0x00E94963 File Offset: 0x00E92B63
		protected void InitShowCondition()
		{
			this.ConditionShouldShow = true;
		}

		// Token: 0x060396EC RID: 235244 RVA: 0x00E9496C File Offset: 0x00E92B6C
		public override bool CheckCanShowView()
		{
			EMapType mapType = base.MapType;
			int mapShow = this.MarkConfig.Value.MapShow;
			if ((mapShow == 1 && mapType != EMapType.MiniMap) || (mapShow == 2 && mapType == EMapType.MiniMap))
			{
				return false;
			}
			if (!this.ConditionShouldShow)
			{
				return false;
			}
			if (!this.IsFogUnlock)
			{
				return false;
			}
			float currentMapShowScale = this.GetCurrentMapShowScale();
			bool flag = this.CheckInShowRange(currentMapShowScale) || base.IsTracked;
			if (mapType == EMapType.WorldMap)
			{
				bool isCanShowViewIntermediately = base.IsCanShowViewIntermediately;
				bool flag2 = flag || base.IsIgnoreScaleShow;
				if (isCanShowViewIntermediately != flag2)
				{
					base.NeedPlayShowOrHideSeq = (flag2 ? "ShowView" : "HideView");
				}
				return flag2;
			}
			return true;
		}

		// Token: 0x060396ED RID: 235245 RVA: 0x00E94A0C File Offset: 0x00E92C0C
		public override float GetShowScale()
		{
			return (float)(this.MarkConfig.Value.ShowRange(0) + this.MarkConfig.Value.ShowRange(1) / 2);
		}

		// Token: 0x04020A45 RID: 133701
		public readonly DynamicMapMark? MarkConfig;

		// Token: 0x04020A48 RID: 133704
		protected bool ConditionShouldShow = true;
	}
}
