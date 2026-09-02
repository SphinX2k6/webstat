using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005BA0 RID: 23456
	public abstract class InteractConfirmBoxActionBase : InteractConfirmActionBase
	{
		// Token: 0x0603B53A RID: 243002 RVA: 0x00F062E4 File Offset: 0x00F044E4
		[NullableContext(1)]
		protected override bool OnExecute(InteractSecondConfirmContext context)
		{
			CommonInteractOption option = context.Option;
			if (((option != null) ? option.ConfirmBox : null) == null)
			{
				return false;
			}
			ConfirmBoxDataNew confirmBoxDataNew = this.ConfigConfirmBoxData();
			if (confirmBoxDataNew != null)
			{
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return true;
			}
			return false;
		}

		// Token: 0x0603B53B RID: 243003 RVA: 0x00F06320 File Offset: 0x00F04520
		protected override void OnCancel()
		{
			if (ControllerBase<ConfirmBoxController>.Instance.CheckIsConfirmBoxOpen())
			{
				ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
			}
			base.ExecuteFinish(false);
		}

		// Token: 0x0603B53C RID: 243004
		[NullableContext(2)]
		protected abstract ConfirmBoxDataNew ConfigConfirmBoxData();
	}
}
