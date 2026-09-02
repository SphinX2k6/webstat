using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.SceneGameplayPanel
{
	// Token: 0x02004B8D RID: 19341
	public class SceneGameplayTipGridMonster : SceneGameplayTipGrid
	{
		// Token: 0x06032843 RID: 206915 RVA: 0x00CA4EAC File Offset: 0x00CA30AC
		[NullableContext(1)]
		protected override void OnRefreshItemGrid(CommonItemSmallItemGrid grid, int itemId, int itemCount, bool showGet = false)
		{
			PhantomItem? phantomItemById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(itemId);
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = itemId,
				IconPath = phantomItemById.Value.Icon
			};
			grid.ApplyPropSmallItemGrid(parameters);
			grid.SetAllowClickBack(false);
			UUIExtendToggle itemGridExtendToggle = grid.GetItemGridExtendToggle();
			if (itemGridExtendToggle == null)
			{
				return;
			}
			itemGridExtendToggle.SetToggleStateForce(EToggleState.ETT_UnDetermined, false, false, false);
		}
	}
}
