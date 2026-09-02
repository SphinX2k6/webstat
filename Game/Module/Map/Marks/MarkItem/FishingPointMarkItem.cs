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
	// Token: 0x02005843 RID: 22595
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingPointMarkItem : ServerMarkItem
	{
		// Token: 0x17009290 RID: 37520
		// (get) Token: 0x06039710 RID: 235280 RVA: 0x00E95075 File Offset: 0x00E93275
		// (set) Token: 0x06039711 RID: 235281 RVA: 0x00E9507D File Offset: 0x00E9327D
		public MapMark MarkConfig
		{
			get
			{
				return this.MarkConfigInternal;
			}
			set
			{
				this.MarkConfigInternal = value;
			}
		}

		// Token: 0x17009291 RID: 37521
		// (get) Token: 0x06039712 RID: 235282 RVA: 0x00E95086 File Offset: 0x00E93286
		public override int MapId
		{
			get
			{
				return this.ServerMarkInfo.MapId;
			}
		}

		// Token: 0x17009292 RID: 37522
		// (get) Token: 0x06039713 RID: 235283 RVA: 0x00E95093 File Offset: 0x00E93293
		public override int? InstanceDungeonId
		{
			get
			{
				return this.ServerMarkInfo.InstanceDungeonId;
			}
		}

		// Token: 0x06039714 RID: 235284 RVA: 0x00E950A0 File Offset: 0x00E932A0
		public FishingPointMarkItem(FishingPointMarkCreateInfo markPointInfo, UUIItem parent, EMapType mapType, float markScale) : base(markPointInfo, parent, mapType, markScale)
		{
		}

		// Token: 0x06039715 RID: 235285 RVA: 0x00E950AD File Offset: 0x00E932AD
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.FishingPointMarkItemView;
		}

		// Token: 0x06039716 RID: 235286 RVA: 0x00E950B1 File Offset: 0x00E932B1
		protected override MarkItemView CreateView()
		{
			return new FishingPointMarkItemView(this);
		}

		// Token: 0x06039717 RID: 235287 RVA: 0x00E950BC File Offset: 0x00E932BC
		public override string GetTitleText()
		{
			int entityConfigId = base.EntityConfigId;
			string fishingPointNameLocalKey = ModelBase<FishingModel>.Instance.GetFishingPointNameLocalKey(entityConfigId);
			string multiText = ConfigBase<TextConfig>.Instance.GetMultiText(fishingPointNameLocalKey, Array.Empty<string>());
			return ConfigBase<TextConfig>.Instance.GetMultiText(this.MarkConfig.MarkTitle, new string[]
			{
				multiText
			});
		}

		// Token: 0x06039718 RID: 235288 RVA: 0x00E95110 File Offset: 0x00E93310
		protected override void OnInitialize()
		{
			base.OnInitialize();
			FishingPointMarkCreateInfo fishingPointMarkCreateInfo = this.ServerMarkInfo as FishingPointMarkCreateInfo;
			base.SetTrackData(fishingPointMarkCreateInfo.TrackTarget);
			MarkFishingPointComponent component = base.MarkItemEntity.GetComponent<MarkFishingPointComponent>(EMapComponent.MarkFishingPoint);
			component.FishingPointEntityId = (fishingPointMarkCreateInfo.TrackTarget as TTrackTarget_Int);
			component.Update();
			this.SetConfigId(fishingPointMarkCreateInfo.MarkConfigId);
			this.UpdateVisibleRelativeState();
		}

		// Token: 0x06039719 RID: 235289 RVA: 0x00E95175 File Offset: 0x00E93375
		public void SetConfigId(int configId)
		{
			this.OnSetConfigId(configId);
		}

		// Token: 0x0603971A RID: 235290 RVA: 0x00E95180 File Offset: 0x00E93380
		public void OnSetConfigId(int configId)
		{
			MapMark value = ConfigBase<MapConfig>.Instance.GetConfigMark(configId).Value;
			this.MarkConfigInternal = value;
			base.MarkItemEntity.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig).Config = value;
			this.OnAfterSetConfigId(new MarkItemData
			{
				ShowRange = value.ShowRange(),
				MarkPic = value.UnlockMarkPic,
				ShowPriority = new int?(value.ShowPriority),
				Scale = new float?(value.Scale),
				CornerScale = new float?(value.CornerScale)
			});
			this.UpdateIconPath();
		}

		// Token: 0x0603971B RID: 235291 RVA: 0x00E95224 File Offset: 0x00E93424
		public void UpdateIconPath()
		{
			if ((this.ServerMarkInfo as FishingPointMarkCreateInfo).FishPointDetectSourceType == EFishPointDetectSourceType.Entrust)
			{
				this.IconPath = ConfigBase<MapConfig>.Instance.GetTaskMarkConfig(20).Value.MarkPic;
				return;
			}
			int showItem = ConfigBase<FishingConfig>.Instance.GetFishingPointConfigByEntityId(base.EntityConfigId).Value.ShowItem;
			EFishItemType type = (EFishItemType)ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(showItem).Value.Type;
			if (type == EFishItemType.Fish)
			{
				this.IconPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_IconMap_Activity_Navigation_4_UI");
				return;
			}
			if (type != EFishItemType.Material)
			{
				this.IconPath = this.MarkConfig.UnlockMarkPic;
				return;
			}
			this.IconPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_IconMap_Activity_Navigation_6_UI");
		}

		// Token: 0x04020A4B RID: 133707
		private MapMark MarkConfigInternal;
	}
}
