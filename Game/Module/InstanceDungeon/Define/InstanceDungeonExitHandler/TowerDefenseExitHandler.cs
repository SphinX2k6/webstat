using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.TowerDefence;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C45 RID: 23621
	public class TowerDefenseExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BAA0 RID: 244384 RVA: 0x00F1D65B File Offset: 0x00F1B85B
		public override bool Checker()
		{
			return ControllerBase<TowerDefenseController>.Instance.CheckInInstanceDungeon();
		}

		// Token: 0x0603BAA1 RID: 244385 RVA: 0x00F1D668 File Offset: 0x00F1B868
		[NullableContext(2)]
		public unsafe override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			bool flag = ControllerBase<TowerDefenseController>.Instance.CheckInBossRushInstance();
			TowerDefensePopupViewArgs towerDefensePopupViewArgs = new TowerDefensePopupViewArgs();
			towerDefensePopupViewArgs.TextTitle = "TowerDefence_ExitTitle";
			towerDefensePopupViewArgs.TextTips = (flag ? "TowerDefence_ExitTipsMulti" : "TowerDefence_ExitTipsSingle");
			List<object> textTipsArgs;
			if (!flag)
			{
				textTipsArgs = null;
			}
			else
			{
				int num = 1;
				List<object> list = new List<object>(num);
				CollectionsMarshal.SetCount<object>(list, num);
				textTipsArgs = list;
				Span<object> span = CollectionsMarshal.AsSpan<object>(list);
				int index = 0;
				*span[index] = ModelBase<BattleScoreModel>.Instance.GetCurScore();
			}
			towerDefensePopupViewArgs.TextTipsArgs = textTipsArgs;
			towerDefensePopupViewArgs.TextContent = "TowerDefence_ExitContent";
			towerDefensePopupViewArgs.ConfirmBack = delegate()
			{
				ControllerBase<TowerDefenseController>.Instance.RequestChallengeQuit();
			};
			TowerDefensePopupViewArgs param = towerDefensePopupViewArgs;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerDefensePopupView, param, null);
		}
	}
}
