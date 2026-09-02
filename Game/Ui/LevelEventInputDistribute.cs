using System;
using CSharpScript.Core.Common;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A01 RID: 18945
	public class LevelEventInputDistribute : InputDistributeSetup
	{
		// Token: 0x060318C4 RID: 202948 RVA: 0x00C59858 File Offset: 0x00C57A58
		public override bool OnRefresh()
		{
			if (Singleton<LevelEventLockInputState>.Instance.IsLockInput())
			{
				if (Singleton<InputManager>.Instance.IsAltPress && Singleton<Info>.Instance.IsInKeyBoard() && Singleton<LevelEventLockInputState>.Instance.IsInputTagHasUiInputRoot)
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新关卡事件输入Tag时，处于键鼠设备并且通过Alt显示鼠标，设置输入分发Tag为 UiInputRootTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("UiInputRoot");
				}
				else
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Input;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "[InputDistribute]刷新关卡事件输入Tag时";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("输入TAG", Singleton<LevelEventLockInputState>.Instance.InputTagNames);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					base.SetInputDistributeTags(Singleton<LevelEventLockInputState>.Instance.InputTagNames);
				}
				return true;
			}
			return false;
		}
	}
}
