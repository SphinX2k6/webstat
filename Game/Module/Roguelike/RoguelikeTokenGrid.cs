using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051AE RID: 20910
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikeTokenGrid : LoopScrollMediumItemGrid<RogueTokenData>
	{
		// Token: 0x17008C90 RID: 35984
		// (get) Token: 0x06035C33 RID: 220211 RVA: 0x00D855EF File Offset: 0x00D837EF
		// (set) Token: 0x06035C34 RID: 220212 RVA: 0x00D855F7 File Offset: 0x00D837F7
		public new RogueTokenData Data { get; set; }

		// Token: 0x06035C35 RID: 220213 RVA: 0x00D85600 File Offset: 0x00D83800
		protected override void OnStart()
		{
			base.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClicked));
		}

		// Token: 0x06035C36 RID: 220214 RVA: 0x00D85614 File Offset: 0x00D83814
		[NullableContext(1)]
		protected void OnClicked(MediumItemGridExtendCallback _)
		{
			base.ScrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, true);
		}

		// Token: 0x06035C37 RID: 220215 RVA: 0x00D85630 File Offset: 0x00D83830
		[NullableContext(1)]
		protected override void OnRefresh(RogueTokenData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			RogueBuffPool? rogueBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueBuffConfig(data.Config.Value.Token);
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = data,
				IconPath = rogueBuffConfig.Value.BuffIcon,
				QualityId = new int?(rogueBuffConfig.Value.Quality),
				BottomTextId = rogueBuffConfig.Value.BuffName,
				QualityType = new CommonDefine.EQualityIconType?(CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath),
				IsProhibit = new bool?(data.IsReceive == null)
			};
			base.Apply<PropMediumItemGrid>(parameters);
			this.SetSelected(isSelected, false);
			if (isSelected)
			{
				this.OnSelected(true);
			}
		}

		// Token: 0x06035C38 RID: 220216 RVA: 0x00D856F1 File Offset: 0x00D838F1
		public override void OnSelected(bool fireEvent)
		{
			if (fireEvent)
			{
				Singleton<EventSystem>.Instance.Emit<RoguelikeTokenGrid>(EEventName.RoguelikeSelectToken, this);
			}
		}
	}
}
