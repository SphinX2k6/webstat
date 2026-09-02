using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.AI.StateMachine
{
	// Token: 0x020070D2 RID: 28882
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AiStateMachineModel : ModelBase<AiStateMachineModel>
	{
		// Token: 0x0604606F RID: 286831 RVA: 0x01263A61 File Offset: 0x01261C61
		protected override bool OnInit()
		{
			this.AiStateMachineFactory = new AiStateMachineFactory();
			return true;
		}

		// Token: 0x04027483 RID: 160899
		public AiStateMachineFactory AiStateMachineFactory;
	}
}
