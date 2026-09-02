using System;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C20 RID: 23584
	public class InstanceDungeonEntranceFlowAdamSmasher : InstanceDungeonEntranceFlowBase
	{
		// Token: 0x0603BA04 RID: 244228 RVA: 0x00F1BC58 File Offset: 0x00F19E58
		protected override void OnCreate()
		{
			base.AddStep(delegate
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.AdamSmasherSelectView, null, null);
			});
		}
	}
}
