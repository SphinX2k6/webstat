using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005232 RID: 21042
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleTokenGrid : LoopScrollMediumItemGrid<RogueResGainData>
	{
		// Token: 0x17008C9C RID: 35996
		// (get) Token: 0x06035E5C RID: 220764 RVA: 0x00D91082 File Offset: 0x00D8F282
		public new RogueResGainData Data
		{
			get
			{
				return this.Data as RogueResGainData;
			}
		}

		// Token: 0x06035E5D RID: 220765 RVA: 0x00D91090 File Offset: 0x00D8F290
		[NullableContext(1)]
		protected override void OnRefresh(RogueResGainData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			RogueResToken rogueResToken = data.RogueResToken;
			if (rogueResToken == null)
			{
				return;
			}
			RogueResBuffPool? rogueResBuffPoolById = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBuffPoolById(rogueResToken.ConfigId);
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
				BottomTextId = rogueResBuffPoolById.Value.BuffName
			};
			base.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x06035E5E RID: 220766 RVA: 0x00D9112E File Offset: 0x00D8F32E
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.OnSelected(true);
			}
		}

		// Token: 0x06035E5F RID: 220767 RVA: 0x00D9113B File Offset: 0x00D8F33B
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
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

		// Token: 0x06035E60 RID: 220768 RVA: 0x00D9116C File Offset: 0x00D8F36C
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x0401EF8E RID: 126862
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, RogueResGainData> SelectCallback;
	}
}
