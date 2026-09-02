using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A0F RID: 18959
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InputTouchHandle : InputDistributeHandle<InputDistributeDefine.ITouchData>
	{
		// Token: 0x060318E5 RID: 202981 RVA: 0x00C59F49 File Offset: 0x00C58149
		public InputTouchHandle(string inputDistributeTag, string name) : base(inputDistributeTag, name)
		{
		}

		// Token: 0x060318E6 RID: 202982 RVA: 0x00C59F53 File Offset: 0x00C58153
		public void BindTouch(TInputHandle<InputDistributeDefine.ITouchData> touchBeginCallback)
		{
			base.Bind(touchBeginCallback);
		}

		// Token: 0x060318E7 RID: 202983 RVA: 0x00C59F5C File Offset: 0x00C5815C
		public void UnBindTouch(TInputHandle<InputDistributeDefine.ITouchData> touchBeginCallback)
		{
			base.UnBind(touchBeginCallback);
		}

		// Token: 0x060318E8 RID: 202984 RVA: 0x00C59F65 File Offset: 0x00C58165
		public void InputTouch(InputDistributeDefine.ITouchData touchData)
		{
			base.Call(touchData);
		}
	}
}
