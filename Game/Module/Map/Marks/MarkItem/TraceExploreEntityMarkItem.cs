using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200585D RID: 22621
	[NullableContext(1)]
	[Nullable(0)]
	public class TraceExploreEntityMarkItem : ServerMarkItem
	{
		// Token: 0x170092E9 RID: 37609
		// (get) Token: 0x060398A5 RID: 235685 RVA: 0x00E99D17 File Offset: 0x00E97F17
		// (set) Token: 0x060398A6 RID: 235686 RVA: 0x00E99D24 File Offset: 0x00E97F24
		public MapMark MarkConfig
		{
			get
			{
				return this.MarkConfigInternal.Value;
			}
			set
			{
				this.MarkConfigInternal = new MapMark?(value);
			}
		}

		// Token: 0x170092EA RID: 37610
		// (get) Token: 0x060398A7 RID: 235687 RVA: 0x00E99D32 File Offset: 0x00E97F32
		public override int MapId
		{
			get
			{
				return this.ServerMarkInfo.MapId;
			}
		}

		// Token: 0x170092EB RID: 37611
		// (get) Token: 0x060398A8 RID: 235688 RVA: 0x00E99D3F File Offset: 0x00E97F3F
		public override int? InstanceDungeonId
		{
			get
			{
				return this.ServerMarkInfo.InstanceDungeonId;
			}
		}

		// Token: 0x060398A9 RID: 235689 RVA: 0x00E99D4C File Offset: 0x00E97F4C
		public TraceExploreEntityMarkItem(DynamicMarkCreateInfo markPointInfo, UUIItem parent, EMapType mapType, float markScale) : base(markPointInfo, parent, mapType, markScale)
		{
		}

		// Token: 0x060398AA RID: 235690 RVA: 0x00E99D5C File Offset: 0x00E97F5C
		protected override void OnInitialize()
		{
			base.OnInitialize();
			DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
			base.SetTrackData(serverMarkInfo.TrackTarget);
			this.SetConfigId(serverMarkInfo.MarkConfigId);
			this.UpdateVisibleRelativeState();
		}

		// Token: 0x060398AB RID: 235691 RVA: 0x00E99D94 File Offset: 0x00E97F94
		public void SetConfigId(int configId)
		{
			this.ServerMarkInfo.MarkConfigId = configId;
			this.OnSetConfigId(configId);
		}

		// Token: 0x060398AC RID: 235692 RVA: 0x00E99DAC File Offset: 0x00E97FAC
		public void OnSetConfigId(int configId)
		{
			MapMark value = ConfigBase<MapConfig>.Instance.GetConfigMark(configId).Value;
			this.MarkConfigInternal = new MapMark?(value);
			base.MarkItemEntity.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig).Config = value;
			this.OnAfterSetConfigId(new MarkItemData
			{
				ShowRange = value.ShowRange(),
				MarkPic = value.UnlockMarkPic,
				ShowPriority = new int?(value.ShowPriority),
				Scale = new float?(value.Scale),
				CornerScale = new float?(value.CornerScale)
			});
		}

		// Token: 0x060398AD RID: 235693 RVA: 0x00E99E4C File Offset: 0x00E9804C
		public override bool CheckCanShowView()
		{
			if (!this.CanConditionShowView())
			{
				return base.IsTracked;
			}
			float currentMapShowScale = this.GetCurrentMapShowScale();
			bool flag = base.CheckInShowRange(currentMapShowScale) || base.IsTracked;
			if (base.MapType == EMapType.WorldMap)
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

		// Token: 0x060398AE RID: 235694 RVA: 0x00E99EBC File Offset: 0x00E980BC
		public bool CanConditionShowView()
		{
			HashSet<int> pendingAddTempMapMarkList = ModelBase<MapModel>.Instance.GetPendingAddTempMapMarkList();
			base.MarkItemEntity.IsTempMapMark = pendingAddTempMapMarkList.Contains(this.MarkId);
			return base.MarkItemEntity.IsTempMapMark && base.IsTempMapMarkShow();
		}

		// Token: 0x060398AF RID: 235695 RVA: 0x00E99F04 File Offset: 0x00E98104
		public override string GetTitleText()
		{
			return ConfigBase<MapConfig>.Instance.GetLocalText(this.MarkConfig.MarkTitle);
		}

		// Token: 0x04020AAC RID: 133804
		private MapMark? MarkConfigInternal;
	}
}
