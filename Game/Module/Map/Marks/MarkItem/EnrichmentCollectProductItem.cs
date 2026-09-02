using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005841 RID: 22593
	[NullableContext(1)]
	[Nullable(0)]
	public class EnrichmentCollectProductItem : ServerMarkItem
	{
		// Token: 0x1700928E RID: 37518
		// (get) Token: 0x06039702 RID: 235266 RVA: 0x00E94EDB File Offset: 0x00E930DB
		public override EMarkType MarkType
		{
			get
			{
				return EMarkType.EnrichmentCollectProduct;
			}
		}

		// Token: 0x06039703 RID: 235267 RVA: 0x00E94EDF File Offset: 0x00E930DF
		public EnrichmentCollectProductItem(DynamicMarkCreateInfo markPointInfo, UUIItem parent, EMapType mapType, float markScale) : base(markPointInfo, parent, mapType, markScale)
		{
		}

		// Token: 0x06039704 RID: 235268 RVA: 0x00E94EEC File Offset: 0x00E930EC
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.EnrichmentCollectProductItemView;
		}

		// Token: 0x06039705 RID: 235269 RVA: 0x00E94EEF File Offset: 0x00E930EF
		protected override MarkItemView CreateView()
		{
			return new EnrichmentCollectProductItemView(this);
		}

		// Token: 0x06039706 RID: 235270 RVA: 0x00E94EF8 File Offset: 0x00E930F8
		protected override void OnInitialize()
		{
			base.OnInitialize();
			DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
			base.SetTrackData(serverMarkInfo.TrackTarget);
			int configId = 6;
			this.SetConfigId(configId);
			this.UpdateVisibleRelativeState();
		}

		// Token: 0x06039707 RID: 235271 RVA: 0x00E94F2D File Offset: 0x00E9312D
		public void SetConfigId(int configId)
		{
			this.OnSetConfigId(configId);
		}

		// Token: 0x06039708 RID: 235272 RVA: 0x00E94F38 File Offset: 0x00E93138
		public void OnSetConfigId(int configId)
		{
			MapMark value = ConfigBase<MapConfig>.Instance.GetConfigMark(configId).Value;
			this.OnAfterSetConfigId(new MarkItemData
			{
				ShowRange = value.ShowRange(),
				MarkPic = value.UnlockMarkPic,
				ShowPriority = new int?(value.ShowPriority),
				Scale = new float?(value.Scale),
				CornerScale = new float?(value.CornerScale)
			});
		}

		// Token: 0x06039709 RID: 235273 RVA: 0x00E94FB4 File Offset: 0x00E931B4
		public override bool GetInteractiveFlag()
		{
			return false;
		}
	}
}
