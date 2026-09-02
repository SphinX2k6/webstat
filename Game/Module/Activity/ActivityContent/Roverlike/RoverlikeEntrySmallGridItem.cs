using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063FE RID: 25598
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeEntrySmallGridItem : LoopScrollSmallItemGrid<IRoverlikeEntrySmallGridData>
	{
		// Token: 0x06040457 RID: 263255 RVA: 0x01078CF7 File Offset: 0x01076EF7
		public void BindOnItemClick(Action<IRoverlikeEntrySmallGridData, int> callback)
		{
			this.OnItemClick = callback;
		}

		// Token: 0x06040458 RID: 263256 RVA: 0x01078D00 File Offset: 0x01076F00
		protected override void OnStart()
		{
		}

		// Token: 0x06040459 RID: 263257 RVA: 0x01078D04 File Offset: 0x01076F04
		protected override void OnRefresh(IRoverlikeEntrySmallGridData data, bool isSelected, int gridIndex)
		{
			PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid
			{
				Data = data
			};
			this.FillGridParams(propSmallItemGrid, data);
			base.Apply<PropSmallItemGrid>(propSmallItemGrid);
		}

		// Token: 0x0604045A RID: 263258 RVA: 0x01078D30 File Offset: 0x01076F30
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			IRoverlikeEntrySmallGridData roverlikeEntrySmallGridData = this.Data as IRoverlikeEntrySmallGridData;
			if (roverlikeEntrySmallGridData != null)
			{
				Action<IRoverlikeEntrySmallGridData, int> onItemClick = this.OnItemClick;
				if (onItemClick == null)
				{
					return;
				}
				onItemClick(roverlikeEntrySmallGridData, base.GridIndex);
			}
		}

		// Token: 0x0604045B RID: 263259 RVA: 0x01078D63 File Offset: 0x01076F63
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, true);
		}

		// Token: 0x0604045C RID: 263260 RVA: 0x01078D6D File Offset: 0x01076F6D
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, true);
		}

		// Token: 0x0604045D RID: 263261 RVA: 0x01078D78 File Offset: 0x01076F78
		private void FillGridParams(PropSmallItemGrid params_, IRoverlikeEntrySmallGridData data)
		{
			RoverRogueGainDataType type = data.Type;
			if (type != RoverRogueGainDataType.RoverRogueGainRoleEnhance)
			{
				if (type == RoverRogueGainDataType.RoverRogueGainItem)
				{
					RoverRogueItem? itemConfig = ConfigBase<RoverlikeConfig>.Instance.GetItemConfig(data.ConfigId);
					if (itemConfig != null)
					{
						RoverRogueQuality? qualityConfig = ConfigBase<RoverlikeConfig>.Instance.GetQualityConfig(itemConfig.Value.Quality);
						if (qualityConfig != null)
						{
							params_.IconPath = itemConfig.Value.Icon;
							params_.QualityIcon = qualityConfig.Value.ItemGridSprite;
							return;
						}
					}
				}
			}
			else
			{
				RoverRogueRoleEnhance? roleEnhanceConfig = ConfigBase<RoverlikeConfig>.Instance.GetRoleEnhanceConfig(data.ConfigId);
				if (roleEnhanceConfig != null)
				{
					params_.SpriteIconPath = roleEnhanceConfig.Value.Icon;
					params_.IsQualityHidden = new bool?(true);
				}
			}
		}

		// Token: 0x04024085 RID: 147589
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IRoverlikeEntrySmallGridData, int> OnItemClick;
	}
}
