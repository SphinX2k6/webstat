using System;
using CSharpScript.Game.Module.Plot;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A04 RID: 18948
	public class PlotInputDistribute : InputDistributeSetup
	{
		// Token: 0x060318CB RID: 202955 RVA: 0x00C59A50 File Offset: 0x00C57C50
		public override bool OnRefresh()
		{
			PlotModel instance = ModelBase<PlotModel>.Instance;
			if (!ControllerBase<PlotController>.Instance.NeedInputRefresh())
			{
				return false;
			}
			if (instance.TimeLimitedOptionTag)
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.FZX, "[InputDistribute] 剧情限时选项仅允许移动输入", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTags(new string[]
				{
					"FightInputRoot.FightInput.AxisInput.CameraInput",
					"FightInputRoot.FightInput.AxisInput.MoveInput",
					"UiInputRoot.MouseInputTag"
				});
				return true;
			}
			if (instance.EntitySequenceInteractTag)
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.FZX, "[InputDistribute] 实体剧情输入分发", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTags(new string[]
				{
					"FightInputRoot.FightInput.AxisInput.CameraInput",
					"FightInputRoot.FightInput.AxisInput.MoveInput",
					"UiInputRoot.MouseInputTag",
					"UiInputRoot.Navigation",
					"UiInputRoot.ShortcutKeyTag"
				});
				return true;
			}
			if (instance.PlotConfig.DisableInput || ModelBase<PlotModel>.Instance.IsBlendProcessing)
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新剧情输入Tag时，除了视角旋转和鼠标输入,其他输入都会被禁止", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTags(new string[]
				{
					"UiInputRoot.MouseInputTag",
					"UiInputRoot.Navigation"
				});
				return true;
			}
			return false;
		}
	}
}
