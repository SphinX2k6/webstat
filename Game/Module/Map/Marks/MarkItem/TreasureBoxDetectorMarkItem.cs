using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200585E RID: 22622
	[NullableContext(1)]
	[Nullable(0)]
	public class TreasureBoxDetectorMarkItem : ServerMarkItem
	{
		// Token: 0x170092EC RID: 37612
		// (get) Token: 0x060398B0 RID: 235696 RVA: 0x00E99F29 File Offset: 0x00E98129
		public override EMarkType MarkType
		{
			get
			{
				return EMarkType.TreasureBoxDetector;
			}
		}

		// Token: 0x170092ED RID: 37613
		// (get) Token: 0x060398B1 RID: 235697 RVA: 0x00E99F2D File Offset: 0x00E9812D
		public bool IsNewCustomMarkItem
		{
			get
			{
				return this.IsNew;
			}
		}

		// Token: 0x060398B2 RID: 235698 RVA: 0x00E99F35 File Offset: 0x00E98135
		public TreasureBoxDetectorMarkItem(DynamicMarkCreateInfo markPointInfo, UUIItem parent, EMapType mapType, float markScale) : base(markPointInfo, parent, mapType, markScale)
		{
		}

		// Token: 0x060398B3 RID: 235699 RVA: 0x00E99F44 File Offset: 0x00E98144
		protected override void OnInitialize()
		{
			base.OnInitialize();
			DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
			base.SetTrackData(serverMarkInfo.TrackTarget);
			this.SetConfigId(base.ConfigId);
			base.MarkItemEntity.ViewLifeCircle.EnableVerticalPointer = false;
			this.UpdateVisibleRelativeState();
		}

		// Token: 0x060398B4 RID: 235700 RVA: 0x00E99F8D File Offset: 0x00E9818D
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.TreasureBoxDetectorMarkItemView;
		}

		// Token: 0x060398B5 RID: 235701 RVA: 0x00E99F91 File Offset: 0x00E98191
		[PreserveBaseOverrides]
		protected new virtual TreasureBoxDetectorMarkItemView CreateView()
		{
			return new TreasureBoxDetectorMarkItemView(this);
		}

		// Token: 0x060398B6 RID: 235702 RVA: 0x00E99F99 File Offset: 0x00E98199
		public void SetConfigId(int configId)
		{
			this.ServerMarkInfo.MarkConfigId = configId;
			this.OnSetConfigId(configId);
		}

		// Token: 0x060398B7 RID: 235703 RVA: 0x00E99FB0 File Offset: 0x00E981B0
		public void OnSetConfigId(int configId)
		{
			TreasureBoxDetectorMark value = ConfigBase<MapConfig>.Instance.GetTreasureBoxDetectorMarkConfig(configId).Value;
			base.MarkItemEntity.GetOrAddComponent<MarkConfigComponent>(EMapComponent.MarkConfig).Config = value;
			this.OnAfterSetConfigId(new MarkItemData
			{
				MarkPic = value.MarkPic,
				Scale = new float?(value.Scale),
				ShowPriority = new int?(value.ShowPriority),
				ShowRange = value.ShowRange()
			});
		}

		// Token: 0x060398B8 RID: 235704 RVA: 0x00E9A032 File Offset: 0x00E98232
		public void SetIsNew(bool isNew)
		{
			this.IsNew = isNew;
		}

		// Token: 0x060398B9 RID: 235705 RVA: 0x00E9A03C File Offset: 0x00E9823C
		[NullableContext(2)]
		public override string GetTitleText()
		{
			return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<MapConfig>.Instance.GetTreasureBoxDetectorMarkConfig(base.ConfigId).Value.MarkTitle, null);
		}

		// Token: 0x060398BA RID: 235706 RVA: 0x00E9A070 File Offset: 0x00E98270
		[NullableContext(2)]
		public string GetDescText()
		{
			return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<MapConfig>.Instance.GetTreasureBoxDetectorMarkConfig(base.ConfigId).Value.MarkDesc, null);
		}

		// Token: 0x04020AAD RID: 133805
		public int TeleportId;

		// Token: 0x04020AAE RID: 133806
		private bool IsNew;
	}
}
