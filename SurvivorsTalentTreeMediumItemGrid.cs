using System;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B56 RID: 11094
public class SurvivorsTalentTreeMediumItemGrid : LoopScrollMediumItemGrid<int>
{
	// Token: 0x060161FE RID: 90622 RVA: 0x00623DA4 File Offset: 0x00621FA4
	protected override void OnRefresh(int itemId, bool isSelected, int gridIndex)
	{
		SurvivorsItem? itemConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsItem(itemId);
		if (itemConfig == null)
		{
			return;
		}
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			BottomTextId = itemConfig.Value.Name,
			IconPath = itemConfig.Value.Icon,
			QualityId = new int?(itemConfig.Value.Quality)
		};
		base.Apply<PropMediumItemGrid>(parameters);
		base.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback callbackParameter)
		{
			SurvivorsRogueItemCard param = new SurvivorsRogueItemCard
			{
				Type = ESurvivorsRogueItemType.Normal,
				Id = itemId,
				Index = gridIndex,
				QualityId = itemConfig.Value.Quality,
				TitleId = itemConfig.Value.Name,
				DescId = itemConfig.Value.Desc,
				UseToggle = new bool?(false),
				IsLevelUp = new bool?(false)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsCardTips, param, null);
		});
		base.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
	}
}
