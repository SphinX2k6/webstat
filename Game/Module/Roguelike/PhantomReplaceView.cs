using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005166 RID: 20838
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomReplaceView : PhantomSelectView
	{
		// Token: 0x06035A01 RID: 219649 RVA: 0x00D78578 File Offset: 0x00D76778
		public PhantomReplaceView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035A02 RID: 219650 RVA: 0x00D78584 File Offset: 0x00D76784
		protected override void ConfirmBtn(int _)
		{
			RogueGainEntry rogueGainEntry = (this.RoguelikeChooseData.RogueGainEntryList.Count > 0) ? this.RoguelikeChooseData.RogueGainEntryList[0] : null;
			if (rogueGainEntry == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Roguelike, ELogAuthor.ZJC, "当前没有选中的声骸", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = rogueGainEntry;
			ControllerBase<RoguelikeController>.Instance.RogueChooseDataResultRequest(EPerkType.Phantom);
		}

		// Token: 0x06035A03 RID: 219651 RVA: 0x00D785F1 File Offset: 0x00D767F1
		protected void GiveUpBtn()
		{
			ControllerBase<RoguelikeController>.Instance.RoguelikeGiveUpGainRequest(this.RoguelikeChooseData.Index).Forget();
		}

		// Token: 0x06035A04 RID: 219652 RVA: 0x00D7860D File Offset: 0x00D7680D
		protected override void OnStart()
		{
			base.OnStart();
			this.IsShowChooseTips = true;
		}

		// Token: 0x06035A05 RID: 219653 RVA: 0x00D7861C File Offset: 0x00D7681C
		protected override void RefreshTopPanel()
		{
			this.TopPanel.RefreshTitle("RoguelikeView_1_Text");
			RogueGainEntry[] rogueGainEntryList = this.GetRogueGainEntryList();
			RoguePokemon? roguePhantomConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguePhantomConfig(rogueGainEntryList[0].ConfigId);
			RoguePokemon? roguePhantomConfig2 = ConfigBase<RoguelikeConfig>.Instance.GetRoguePhantomConfig(rogueGainEntryList[1].ConfigId);
			this.TopPanel.RefreshSelectTipsText("RoguelikeView_2_Text", true, new object[]
			{
				new TableTextArgNew((roguePhantomConfig != null) ? roguePhantomConfig.GetValueOrDefault().PokemonName : null, Array.Empty<object>()),
				new TableTextArgNew((roguePhantomConfig2 != null) ? roguePhantomConfig2.GetValueOrDefault().PokemonName : null, Array.Empty<object>()),
				true
			});
		}

		// Token: 0x06035A06 RID: 219654 RVA: 0x00D786D6 File Offset: 0x00D768D6
		protected override void RefreshBtnEnableClick()
		{
		}

		// Token: 0x06035A07 RID: 219655 RVA: 0x00D786D8 File Offset: 0x00D768D8
		private RogueGainEntry[] GetRogueGainEntryList()
		{
			List<RogueGainEntry> list = new List<RogueGainEntry>();
			RogueGainEntry phantomEntry = ModelBase<RoguelikeModel>.Instance.RogueInfo.PhantomEntry;
			if (phantomEntry != null)
			{
				list.Add(phantomEntry);
			}
			if (this.RoguelikeChooseData.RogueGainEntryList.Count > 0)
			{
				list.Add(this.RoguelikeChooseData.RogueGainEntryList[0]);
			}
			return list.ToArray();
		}
	}
}
