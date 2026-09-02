using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200585F RID: 22623
	[NullableContext(1)]
	[Nullable(0)]
	public class TreasureBoxMarkItem : ServerMarkItem
	{
		// Token: 0x170092EE RID: 37614
		// (get) Token: 0x060398BB RID: 235707 RVA: 0x00E9A0A3 File Offset: 0x00E982A3
		public override EMarkType MarkType
		{
			get
			{
				return EMarkType.TreasureBox;
			}
		}

		// Token: 0x170092EF RID: 37615
		// (get) Token: 0x060398BC RID: 235708 RVA: 0x00E9A0A7 File Offset: 0x00E982A7
		public bool IsNewCustomMarkItem
		{
			get
			{
				return this.IsNew;
			}
		}

		// Token: 0x060398BD RID: 235709 RVA: 0x00E9A0AF File Offset: 0x00E982AF
		public TreasureBoxMarkItem(DynamicMarkCreateInfo markPointInfo, UUIItem parent, EMapType mapType, float markScale) : base(markPointInfo, parent, mapType, markScale)
		{
		}

		// Token: 0x060398BE RID: 235710 RVA: 0x00E9A0BC File Offset: 0x00E982BC
		protected override void OnInitialize()
		{
			base.OnInitialize();
			DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
			base.SetTrackData(serverMarkInfo.TrackTarget);
			this.SetConfigId(base.ConfigId);
			this.UpdateVisibleRelativeState();
		}

		// Token: 0x060398BF RID: 235711 RVA: 0x00E9A0F4 File Offset: 0x00E982F4
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.TreasureBoxMarkItemView;
		}

		// Token: 0x060398C0 RID: 235712 RVA: 0x00E9A0F8 File Offset: 0x00E982F8
		[PreserveBaseOverrides]
		protected new virtual TreasureBoxMarkItemView CreateView()
		{
			return new TreasureBoxMarkItemView(this);
		}

		// Token: 0x060398C1 RID: 235713 RVA: 0x00E9A100 File Offset: 0x00E98300
		public void SetConfigId(int configId)
		{
			this.ServerMarkInfo.MarkConfigId = configId;
			this.OnSetConfigId(configId);
		}

		// Token: 0x060398C2 RID: 235714 RVA: 0x00E9A118 File Offset: 0x00E98318
		public void OnSetConfigId(int configId)
		{
			TreasureBoxMark? treasureBoxMarkConfig = ConfigBase<MapConfig>.Instance.GetTreasureBoxMarkConfig(configId);
			this.OnAfterSetConfigId(new MarkItemData
			{
				MarkPic = treasureBoxMarkConfig.Value.MarkPic,
				Scale = new float?(treasureBoxMarkConfig.Value.Scale),
				ShowPriority = new int?(treasureBoxMarkConfig.Value.ShowPriority),
				ShowRange = treasureBoxMarkConfig.Value.ShowRange()
			});
		}

		// Token: 0x060398C3 RID: 235715 RVA: 0x00E9A19A File Offset: 0x00E9839A
		public void SetIsNew(bool isNew)
		{
			this.IsNew = isNew;
		}

		// Token: 0x060398C4 RID: 235716 RVA: 0x00E9A1A4 File Offset: 0x00E983A4
		[NullableContext(2)]
		public override string GetTitleText()
		{
			return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<MapConfig>.Instance.GetTreasureBoxMarkConfig(base.ConfigId).Value.MarkTitle, null);
		}

		// Token: 0x060398C5 RID: 235717 RVA: 0x00E9A1D8 File Offset: 0x00E983D8
		[NullableContext(2)]
		public string GetDescText()
		{
			return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<MapConfig>.Instance.GetTreasureBoxMarkConfig(base.ConfigId).Value.MarkDesc, null);
		}

		// Token: 0x060398C6 RID: 235718 RVA: 0x00E9A20B File Offset: 0x00E9840B
		public override bool GetInteractiveFlag()
		{
			return false;
		}

		// Token: 0x04020AAF RID: 133807
		public int DetectorId;

		// Token: 0x04020AB0 RID: 133808
		private bool IsNew;
	}
}
