using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005B9C RID: 23452
	public class CommonConfirmBoxAction : InteractConfirmBoxActionBase
	{
		// Token: 0x0603B523 RID: 242979 RVA: 0x00F05FAC File Offset: 0x00F041AC
		[NullableContext(2)]
		protected override ConfirmBoxDataNew ConfigConfirmBoxData()
		{
			ICommonConfirmBox commonConfirmBox = this.Context.Option.ConfirmBox.Type as ICommonConfirmBox;
			if (commonConfirmBox == null)
			{
				return null;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew((EConfirmBoxConfigId)commonConfirmBox.Id);
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				base.ExecuteFinish(false);
			};
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				base.ExecuteFinish(true);
			};
			return confirmBoxDataNew;
		}
	}
}
