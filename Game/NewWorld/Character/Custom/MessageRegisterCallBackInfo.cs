using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Custom
{
	// Token: 0x020048E3 RID: 18659
	[NullableContext(1)]
	[Nullable(0)]
	internal class MessageRegisterCallBackInfo
	{
		// Token: 0x06030AC3 RID: 199363 RVA: 0x00BFF3D8 File Offset: 0x00BFD5D8
		public MessageRegisterCallBackInfo()
		{
			this.EnterCallbacks = new List<TMessageRegisterCallback>();
			this.LeaveCallback = new List<TMessageRegisterCallback>();
			this.InitCallback = new List<TMessageRegisterCallback>();
		}

		// Token: 0x0401BFA0 RID: 114592
		public List<TMessageRegisterCallback> EnterCallbacks;

		// Token: 0x0401BFA1 RID: 114593
		public List<TMessageRegisterCallback> LeaveCallback;

		// Token: 0x0401BFA2 RID: 114594
		public List<TMessageRegisterCallback> InitCallback;
	}
}
