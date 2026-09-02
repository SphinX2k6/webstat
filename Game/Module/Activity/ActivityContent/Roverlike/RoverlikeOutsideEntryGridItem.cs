using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063E7 RID: 25575
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeOutsideEntryGridItem : MediumItemGrid, ISyncGridProxy<RoverlikeGainEntry>, ISyncGridProxy
	{
		// Token: 0x17009DC7 RID: 40391
		// (get) Token: 0x06040384 RID: 263044 RVA: 0x01075352 File Offset: 0x01073552
		// (set) Token: 0x06040385 RID: 263045 RVA: 0x0107535A File Offset: 0x0107355A
		public int GridIndex { get; set; }

		// Token: 0x06040386 RID: 263046 RVA: 0x01075363 File Offset: 0x01073563
		protected override void OnStart()
		{
			this.GetItemGridExtendToggle().bLockStateOnSelect = true;
			base.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnToggleStateChanged));
			base.SetUseFixedAsync(true);
		}

		// Token: 0x06040387 RID: 263047 RVA: 0x0107538C File Offset: 0x0107358C
		public void Refresh(RoverlikeGainEntry data)
		{
			this.CollectData = data;
			Func<RoverlikeGainEntry, int, bool> getLockState = this.GetLockState;
			bool value = getLockState != null && getLockState(data, this.GridIndex);
			PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
			{
				Data = data,
				IsLockVisible = new bool?(value),
				IsDisable = new bool?(value)
			};
			this.FillGridParams(propMediumItemGrid, data);
			base.Apply<PropMediumItemGrid>(propMediumItemGrid);
			Func<RoverlikeGainEntry, int, bool> isGridSelected = this.IsGridSelected;
			bool toggleStateInternal = isGridSelected != null && isGridSelected(data, this.GridIndex);
			this.SetToggleStateInternal(toggleStateInternal);
		}

		// Token: 0x06040388 RID: 263048 RVA: 0x0107540F File Offset: 0x0107360F
		void ISyncGridProxy.Refresh(object data)
		{
			this.Refresh((RoverlikeGainEntry)data);
		}

		// Token: 0x06040389 RID: 263049 RVA: 0x0107541D File Offset: 0x0107361D
		void ISyncGridProxy.CreateByActor(AActor actor)
		{
			base.CreateByActor(actor, null);
		}

		// Token: 0x0604038A RID: 263050 RVA: 0x01075427 File Offset: 0x01073627
		void ISyncGridProxy.CreateThenShowByActor(AActor actor)
		{
			base.CreateThenShowByActor(actor, null);
		}

		// Token: 0x0604038B RID: 263051 RVA: 0x01075431 File Offset: 0x01073631
		public void Clear()
		{
			this.CollectData = null;
		}

		// Token: 0x0604038C RID: 263052 RVA: 0x0107543C File Offset: 0x0107363C
		public void SetToggleStateInternal(bool selected)
		{
			EToggleState state = selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			this.GetItemGridExtendToggle().SetToggleState(state, false, false, false);
		}

		// Token: 0x0604038D RID: 263053 RVA: 0x01075464 File Offset: 0x01073664
		private void FillGridParams(PropMediumItemGrid params_, RoverlikeGainEntry data)
		{
			switch (data.Type)
			{
			case RoverRogueGainDataType.RoverRogueGainBless:
			{
				RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(data.ConfigId);
				if (blessConfig != null)
				{
					RoverRogueQuality? qualityConfig = ConfigBase<RoverlikeConfig>.Instance.GetQualityConfig(blessConfig.Value.Quality);
					if (qualityConfig != null)
					{
						params_.SpriteIconPath = blessConfig.Value.Icon;
						params_.BottomTextId = blessConfig.Value.Name;
						params_.QualityIcon = qualityConfig.Value.ItemGridSprite;
						return;
					}
				}
				break;
			}
			case RoverRogueGainDataType.RoverRogueGainRoleEnhance:
			{
				RoverRogueRoleEnhance? roleEnhanceConfig = ConfigBase<RoverlikeConfig>.Instance.GetRoleEnhanceConfig(data.ConfigId);
				if (roleEnhanceConfig != null)
				{
					params_.SpriteIconPath = roleEnhanceConfig.Value.Icon;
					params_.BottomTextId = roleEnhanceConfig.Value.Name;
					params_.IsQualityHidden = new bool?(true);
					return;
				}
				break;
			}
			case RoverRogueGainDataType.RoverRogueGainLootItem:
				break;
			case RoverRogueGainDataType.RoverRogueGainItem:
			{
				RoverRogueItem? itemConfig = ConfigBase<RoverlikeConfig>.Instance.GetItemConfig(data.ConfigId);
				if (itemConfig != null)
				{
					RoverRogueQuality? qualityConfig2 = ConfigBase<RoverlikeConfig>.Instance.GetQualityConfig(itemConfig.Value.Quality);
					if (qualityConfig2 != null)
					{
						params_.BottomTextId = itemConfig.Value.Name;
						params_.IconPath = itemConfig.Value.Icon;
						params_.QualityIcon = qualityConfig2.Value.ItemGridSprite;
					}
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0604038E RID: 263054 RVA: 0x010755EE File Offset: 0x010737EE
		private void OnToggleStateChanged(MediumItemGridExtendCallback parameters)
		{
			if (this.CollectData != null)
			{
				Action<RoverlikeGainEntry, int> onClickCb = this.OnClickCb;
				if (onClickCb == null)
				{
					return;
				}
				onClickCb(this.CollectData, this.GridIndex);
			}
		}

		// Token: 0x0402402C RID: 147500
		[Nullable(2)]
		public RoverlikeGainEntry CollectData;

		// Token: 0x0402402D RID: 147501
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<RoverlikeGainEntry, int> OnClickCb;

		// Token: 0x0402402E RID: 147502
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<RoverlikeGainEntry, int, bool> IsGridSelected;

		// Token: 0x0402402F RID: 147503
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<RoverlikeGainEntry, int, bool> GetLockState;
	}
}
