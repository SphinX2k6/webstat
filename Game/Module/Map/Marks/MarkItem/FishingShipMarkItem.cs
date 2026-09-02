using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005844 RID: 22596
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingShipMarkItem : ServerMarkItem
	{
		// Token: 0x17009293 RID: 37523
		// (get) Token: 0x0603971C RID: 235292 RVA: 0x00E952F4 File Offset: 0x00E934F4
		// (set) Token: 0x0603971D RID: 235293 RVA: 0x00E95301 File Offset: 0x00E93501
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

		// Token: 0x17009294 RID: 37524
		// (get) Token: 0x0603971E RID: 235294 RVA: 0x00E9530F File Offset: 0x00E9350F
		public override int MapId
		{
			get
			{
				return this.ServerMarkInfo.MapId;
			}
		}

		// Token: 0x17009295 RID: 37525
		// (get) Token: 0x0603971F RID: 235295 RVA: 0x00E9531C File Offset: 0x00E9351C
		public override int? InstanceDungeonId
		{
			get
			{
				return this.ServerMarkInfo.InstanceDungeonId;
			}
		}

		// Token: 0x06039720 RID: 235296 RVA: 0x00E95329 File Offset: 0x00E93529
		public override int GetMultiMapId()
		{
			return 0;
		}

		// Token: 0x06039721 RID: 235297 RVA: 0x00E9532C File Offset: 0x00E9352C
		public FishingShipMarkItem(FishingShipMarkCreateInfo markPointInfo, UUIItem parent, EMapType mapType, float markScale) : base(markPointInfo, parent, mapType, markScale)
		{
		}

		// Token: 0x06039722 RID: 235298 RVA: 0x00E9533C File Offset: 0x00E9353C
		public override string GetTitleText()
		{
			return ConfigBase<TextConfig>.Instance.GetMultiText(this.MarkConfig.MarkTitle, Array.Empty<string>());
		}

		// Token: 0x06039723 RID: 235299 RVA: 0x00E95366 File Offset: 0x00E93566
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.FishingShipMarkItemView;
		}

		// Token: 0x06039724 RID: 235300 RVA: 0x00E9536A File Offset: 0x00E9356A
		[PreserveBaseOverrides]
		protected new virtual FishingShipMarkItemView CreateView()
		{
			return new FishingShipMarkItemView(this);
		}

		// Token: 0x06039725 RID: 235301 RVA: 0x00E95374 File Offset: 0x00E93574
		protected override void OnInitialize()
		{
			base.OnInitialize();
			this.EnableCachePosition = false;
			FishingShipMarkCreateInfo fishingShipMarkCreateInfo = this.ServerMarkInfo as FishingShipMarkCreateInfo;
			base.SetTrackData(fishingShipMarkCreateInfo.TrackTarget);
			this.SetConfigId(fishingShipMarkCreateInfo.MarkConfigId);
			this.UpdateVisibleRelativeState();
		}

		// Token: 0x06039726 RID: 235302 RVA: 0x00E953B8 File Offset: 0x00E935B8
		public void SetConfigId(int configId)
		{
			this.OnSetConfigId(configId);
		}

		// Token: 0x06039727 RID: 235303 RVA: 0x00E953C4 File Offset: 0x00E935C4
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

		// Token: 0x06039728 RID: 235304 RVA: 0x00E95464 File Offset: 0x00E93664
		public override bool CheckCanShowView()
		{
			bool flag = ModelBase<FishingModel>.Instance.IsOnShipVehicle();
			return base.CheckCanShowView() && !flag;
		}

		// Token: 0x04020A4C RID: 133708
		private MapMark? MarkConfigInternal;
	}
}
