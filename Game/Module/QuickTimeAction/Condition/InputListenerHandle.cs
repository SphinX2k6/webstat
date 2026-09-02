using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.QuickTimeAction.Condition
{
	// Token: 0x020052C3 RID: 21187
	[NullableContext(1)]
	[Nullable(0)]
	public class InputListenerHandle
	{
		// Token: 0x0603629A RID: 221850 RVA: 0x00DA3F72 File Offset: 0x00DA2172
		public InputListenerHandle(string actionName, TInputHandle<InputDistributeDefine.EActionType> callback)
		{
			this.ActionName = actionName;
			this.Callback = callback;
		}

		// Token: 0x0401F1D9 RID: 127449
		public string ActionName;

		// Token: 0x0401F1DA RID: 127450
		public TInputHandle<InputDistributeDefine.EActionType> Callback;
	}
}
