using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049FC RID: 18940
	public class ExploreInputDistribute : InputDistributeSetup
	{
		// Token: 0x060318B5 RID: 202933 RVA: 0x00C590CC File Offset: 0x00C572CC
		public unsafe override bool OnRefresh()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomExploreView))
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]PhantomExploreView轮盘界面打开,Input输入检测，刷新战斗输入时设置输入分发Tag为 MoveInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
				int num = 2;
				List<string> list = new List<string>(num);
				CollectionsMarshal.SetCount<string>(list, num);
				Span<string> span = CollectionsMarshal.AsSpan<string>(list);
				int num2 = 0;
				*span[num2] = "FightInputRoot.FightInput.AxisInput.MoveInput";
				num2++;
				*span[num2] = "UiInputRoot";
				base.SetInputDistributeTags(list);
				return true;
			}
			return false;
		}
	}
}
