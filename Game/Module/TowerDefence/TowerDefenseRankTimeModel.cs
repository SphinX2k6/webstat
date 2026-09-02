using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonComponentModel;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EA0 RID: 20128
	public class TowerDefenseRankTimeModel : RankTimeItemModelBase
	{
		// Token: 0x0603401D RID: 213021 RVA: 0x00D02964 File Offset: 0x00D00B64
		protected override void OnButtonClick()
		{
			TowerDefenseRankViewModelV2 towerDefenseRankViewModelV = new TowerDefenseRankViewModelV2();
			towerDefenseRankViewModelV.InstanceId = this.InstanceId;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerDefenseRankViewV2, towerDefenseRankViewModelV, null);
		}

		// Token: 0x0603401E RID: 213022 RVA: 0x00D02994 File Offset: 0x00D00B94
		[NullableContext(1)]
		protected override TableTextArgNew OnGetContent()
		{
			if (ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.IsPassedInstance(this.InstanceId))
			{
				string bestRecordText = ModelBase<TowerDefenseModel>.Instance.RankData.GetBestRecordText(this.InstanceId);
				return new TableTextArgNew("ChallengeOL_Bestrecord", new <>z__ReadOnlySingleElementList<object>(bestRecordText));
			}
			return new TableTextArgNew("ChallengeOL_Norecord", Array.Empty<object>());
		}
	}
}
