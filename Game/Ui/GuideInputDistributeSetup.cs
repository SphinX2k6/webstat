using System;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049FE RID: 18942
	public class GuideInputDistributeSetup : InputDistributeSetup
	{
		// Token: 0x060318BA RID: 202938 RVA: 0x00C5934C File Offset: 0x00C5754C
		public override bool OnRefresh()
		{
			if (ModelBase<GuideModel>.Instance.IsGuideLockingInput)
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]引导遮罩中，则设置输入分发tag为 BlockAllInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTag("BlockAllInputTag");
				return true;
			}
			return false;
		}
	}
}
