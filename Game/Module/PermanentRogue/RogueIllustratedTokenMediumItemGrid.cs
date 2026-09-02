using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005683 RID: 22147
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueIllustratedTokenMediumItemGrid : LoopScrollMediumItemGrid<RogueTokenViewData>
	{
		// Token: 0x060386CD RID: 231117 RVA: 0x00E4A8B0 File Offset: 0x00E48AB0
		protected override void OnRefresh(RogueTokenViewData data, bool isSelected, int gridIndex)
		{
			this.TokenViewData = data;
			RogueResBuffPool? config = ConfigRogueResBuffPoolById.GetConfig(data.GetConfigId(), true);
			RogueResCollection? config2 = ConfigRogueResCollectionByIdKey.GetConfig(data.GetCollectionIndex(), true);
			SignState collectItemState = ModelBase<ActivityPermanentRogueModel>.Instance.GetCollectItemState(config2.Value.IdKey);
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = data,
				QualityId = ((config != null) ? new int?(config.GetValueOrDefault().Quality) : null),
				QualityType = new CommonDefine.EQualityIconType?(CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath),
				BottomTextId = ((config != null) ? config.GetValueOrDefault().BuffName : null),
				IsLockVisible = new bool?(collectItemState == SignState.Lock),
				IsRedDotVisible = new bool?(collectItemState == SignState.Unlock),
				IconPath = ((config != null) ? config.GetValueOrDefault().BuffIcon : null),
				IsDisable = new bool?(collectItemState == SignState.Lock)
			};
			base.Apply<PropMediumItemGrid>(parameters);
			this.SetSelected(isSelected, false);
		}

		// Token: 0x060386CE RID: 231118 RVA: 0x00E4A9C2 File Offset: 0x00E48BC2
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
		}

		// Token: 0x060386CF RID: 231119 RVA: 0x00E4A9CC File Offset: 0x00E48BCC
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x060386D0 RID: 231120 RVA: 0x00E4A9D6 File Offset: 0x00E48BD6
		public void BindOnItemButtonClickedCallback(Action<RogueTokenViewData> onItemButtonClicked)
		{
			this.OnItemButtonClickedCallback = onItemButtonClicked;
		}

		// Token: 0x060386D1 RID: 231121 RVA: 0x00E4A9DF File Offset: 0x00E48BDF
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			if (this.OnItemButtonClickedCallback != null)
			{
				this.OnItemButtonClickedCallback(this.TokenViewData);
			}
		}

		// Token: 0x04020329 RID: 131881
		[Nullable(2)]
		private RogueTokenViewData TokenViewData;

		// Token: 0x0402032A RID: 131882
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<RogueTokenViewData> OnItemButtonClickedCallback;
	}
}
