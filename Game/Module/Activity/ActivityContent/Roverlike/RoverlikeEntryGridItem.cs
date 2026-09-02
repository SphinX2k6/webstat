using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063FC RID: 25596
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeEntryGridItem : MediumItemGrid, ISyncGridProxy<RoverlikeGainEntry>, ISyncGridProxy
	{
		// Token: 0x17009DD1 RID: 40401
		// (get) Token: 0x06040440 RID: 263232 RVA: 0x01078832 File Offset: 0x01076A32
		// (set) Token: 0x06040441 RID: 263233 RVA: 0x0107883A File Offset: 0x01076A3A
		public int GridIndex { get; set; }

		// Token: 0x06040442 RID: 263234 RVA: 0x01078843 File Offset: 0x01076A43
		protected override void OnStart()
		{
			this.GetItemGridExtendToggle().bLockStateOnSelect = true;
			base.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnToggleStateChanged));
			base.SetUseFixedAsync(true);
		}

		// Token: 0x06040443 RID: 263235 RVA: 0x0107886C File Offset: 0x01076A6C
		public void Refresh(RoverlikeGainEntry data)
		{
			this.CollectData = data;
			if (this.IsEmptyEntry(data))
			{
				PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
				{
					Data = data,
					IsQualityHidden = new bool?(true)
				};
				this.FillEmptyGridParams(propMediumItemGrid);
				base.Apply<PropMediumItemGrid>(propMediumItemGrid);
			}
			else
			{
				PropMediumItemGrid propMediumItemGrid2 = new PropMediumItemGrid
				{
					Data = data
				};
				this.FillGridParams(propMediumItemGrid2, data);
				base.Apply<PropMediumItemGrid>(propMediumItemGrid2);
			}
			Func<RoverlikeGainEntry, int, bool> isGridSelected = this.IsGridSelected;
			bool toggleStateInternal = isGridSelected != null && isGridSelected(data, this.GridIndex);
			this.SetToggleStateInternal(toggleStateInternal);
		}

		// Token: 0x06040444 RID: 263236 RVA: 0x010788EF File Offset: 0x01076AEF
		void ISyncGridProxy.Refresh(object data)
		{
			this.Refresh((RoverlikeGainEntry)data);
		}

		// Token: 0x06040445 RID: 263237 RVA: 0x010788FD File Offset: 0x01076AFD
		void ISyncGridProxy.CreateByActor(AActor actor)
		{
			base.CreateByActor(actor, null);
		}

		// Token: 0x06040446 RID: 263238 RVA: 0x01078907 File Offset: 0x01076B07
		void ISyncGridProxy.CreateThenShowByActor(AActor actor)
		{
			base.CreateThenShowByActor(actor, null);
		}

		// Token: 0x06040447 RID: 263239 RVA: 0x01078911 File Offset: 0x01076B11
		public void Clear()
		{
			this.CollectData = null;
		}

		// Token: 0x06040448 RID: 263240 RVA: 0x0107891C File Offset: 0x01076B1C
		public void SetToggleStateInternal(bool selected)
		{
			EToggleState state = selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			this.GetItemGridExtendToggle().SetToggleState(state, false, false, false);
		}

		// Token: 0x06040449 RID: 263241 RVA: 0x01078941 File Offset: 0x01076B41
		private bool IsEmptyEntry(RoverlikeGainEntry data)
		{
			return data.ConfigId <= 0;
		}

		// Token: 0x0604044A RID: 263242 RVA: 0x01078950 File Offset: 0x01076B50
		private void FillEmptyGridParams(PropMediumItemGrid params_)
		{
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverRogueActivity? roverRogueActivity;
			if (instance == null)
			{
				roverRogueActivity = null;
			}
			else
			{
				RoverlikeActivityData currentActivityData = instance.GetCurrentActivityData();
				roverRogueActivity = ((currentActivityData != null) ? currentActivityData.GetParamConfig() : null);
			}
			RoverRogueActivity? roverRogueActivity2 = roverRogueActivity;
			if (roverRogueActivity2 == null)
			{
				return;
			}
			RoverRogueActivity value = roverRogueActivity2.Value;
			Func<int, int> getSlotId = this.GetSlotId;
			int num = (getSlotId != null) ? getSlotId(this.GridIndex) : 0;
			if (num == 0)
			{
				return;
			}
			string slotName = this.GetSlotName(value, num);
			if (!string.IsNullOrEmpty(slotName))
			{
				params_.BottomTextId = slotName;
			}
			string slotEmptyIconPath = this.GetSlotEmptyIconPath(value, num);
			if (string.IsNullOrEmpty(slotEmptyIconPath))
			{
				return;
			}
			if (slotEmptyIconPath.Contains("Atlas"))
			{
				params_.SpriteIconPath = slotEmptyIconPath;
				return;
			}
			params_.IconPath = slotEmptyIconPath;
		}

		// Token: 0x0604044B RID: 263243 RVA: 0x01078A08 File Offset: 0x01076C08
		[NullableContext(2)]
		private string GetSlotName(RoverRogueActivity activityConfig, int slotId)
		{
			for (int i = 0; i < activityConfig.SlotNameLength; i++)
			{
				DicIntString? dicIntString = activityConfig.SlotName(i);
				if (dicIntString != null && dicIntString.GetValueOrDefault().Key == slotId)
				{
					return dicIntString.Value.Value;
				}
			}
			return null;
		}

		// Token: 0x0604044C RID: 263244 RVA: 0x01078A64 File Offset: 0x01076C64
		[NullableContext(2)]
		private string GetSlotEmptyIconPath(RoverRogueActivity activityConfig, int slotId)
		{
			for (int i = 0; i < activityConfig.SlotEmptyIconLength; i++)
			{
				DicIntString? dicIntString = activityConfig.SlotEmptyIcon(i);
				if (dicIntString != null && dicIntString.GetValueOrDefault().Key == slotId)
				{
					return dicIntString.Value.Value;
				}
			}
			return null;
		}

		// Token: 0x0604044D RID: 263245 RVA: 0x01078AC0 File Offset: 0x01076CC0
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
						params_.RoundCount = new int?(data.ItemRemainingRooms);
						params_.IsDisable = new bool?(data.ItemRemainingRooms == 0);
					}
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0604044E RID: 263246 RVA: 0x01078C72 File Offset: 0x01076E72
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

		// Token: 0x0402407C RID: 147580
		[Nullable(2)]
		public RoverlikeGainEntry CollectData;

		// Token: 0x0402407D RID: 147581
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<RoverlikeGainEntry, int> OnClickCb;

		// Token: 0x0402407E RID: 147582
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<RoverlikeGainEntry, int, bool> IsGridSelected;

		// Token: 0x0402407F RID: 147583
		[Nullable(2)]
		public Func<int, int> GetSlotId;
	}
}
