using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200521B RID: 21019
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleShopGrid : LoopScrollMediumItemGrid<RogueResGainData>
	{
		// Token: 0x17008C9B RID: 35995
		// (get) Token: 0x06035E03 RID: 220675 RVA: 0x00D8F6C1 File Offset: 0x00D8D8C1
		public new RogueResGainData Data
		{
			get
			{
				return this.Data as RogueResGainData;
			}
		}

		// Token: 0x06035E04 RID: 220676 RVA: 0x00D8F6D0 File Offset: 0x00D8D8D0
		[NullableContext(1)]
		protected override void OnRefresh(RogueResGainData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			RogueResShopToken rogueResShopToken = data.RogueResShopToken;
			if (rogueResShopToken == null)
			{
				return;
			}
			RogueResBuffPool? rogueResBuffPoolById = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBuffPoolById(rogueResShopToken.ConfigId);
			if (rogueResBuffPoolById == null)
			{
				return;
			}
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = data,
				IconPath = rogueResBuffPoolById.Value.BuffIcon,
				QualityId = new int?(rogueResBuffPoolById.Value.Quality),
				QualityType = new CommonDefine.EQualityIconType?(CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath),
				IsDisable = new bool?(rogueResShopToken.IsSell)
			};
			base.Apply<PropMediumItemGrid>(parameters);
			ItemGridComponent component = base.RefreshComponent(typeof(RogueBattleDiscountTagComponent), new bool?(true), data);
			bool bVisible = rogueResShopToken.CurPrice != rogueResShopToken.SourcePrice;
			base.SetComponentVisible(component, bVisible);
			ItemGridComponent component2 = base.RefreshComponent(typeof(RogueBattleShopDiscount), new bool?(true), data);
			base.SetComponentVisible(component2, true);
			ItemGridComponent component3 = base.RefreshComponent(typeof(RogueBattleGridElementComponent), new bool?(true), data);
			base.SetComponentVisible(component3, true);
		}

		// Token: 0x06035E05 RID: 220677 RVA: 0x00D8F7E4 File Offset: 0x00D8D9E4
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.OnSelected(true);
			}
		}

		// Token: 0x06035E06 RID: 220678 RVA: 0x00D8F7F4 File Offset: 0x00D8D9F4
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
			ModelBase<RogueBattleModel>.Instance.SelectGainData = this.Data;
			if (fireEvent && this.Data != null)
			{
				Action<int, RogueResGainData> selectCallback = this.SelectCallback;
				if (selectCallback == null)
				{
					return;
				}
				selectCallback(base.GridIndex, this.Data);
			}
		}

		// Token: 0x06035E07 RID: 220679 RVA: 0x00D8F840 File Offset: 0x00D8DA40
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
			ModelBase<RogueBattleModel>.Instance.SelectGainData = null;
		}

		// Token: 0x0401EF3E RID: 126782
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, RogueResGainData> SelectCallback;
	}
}
