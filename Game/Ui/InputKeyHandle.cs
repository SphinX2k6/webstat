using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A0A RID: 18954
	[NullableContext(1)]
	[Nullable(0)]
	public class InputKeyHandle : InputDistributeHandle<InputDistributeDefine.EActionType>
	{
		// Token: 0x060318DB RID: 202971 RVA: 0x00C59EC9 File Offset: 0x00C580C9
		public InputKeyHandle(string inputDistributeTag, string name) : base(inputDistributeTag, name)
		{
		}

		// Token: 0x060318DC RID: 202972 RVA: 0x00C59ED3 File Offset: 0x00C580D3
		public void BindAction(TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			base.Bind(actionCallback);
		}

		// Token: 0x060318DD RID: 202973 RVA: 0x00C59EDC File Offset: 0x00C580DC
		public void UnBindAction(TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			base.UnBind(actionCallback);
		}

		// Token: 0x060318DE RID: 202974 RVA: 0x00C59EE5 File Offset: 0x00C580E5
		public void InputKey(bool bPress)
		{
			if (bPress)
			{
				base.Call(InputDistributeDefine.EActionType.Press);
				return;
			}
			base.Call(InputDistributeDefine.EActionType.Release);
		}
	}
}
