using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x0200505C RID: 20572
	[NullableContext(2)]
	[Nullable(0)]
	internal class OperationParam
	{
		// Token: 0x06034F4A RID: 216906 RVA: 0x00D477CB File Offset: 0x00D459CB
		public OperationParam(EOperationType operationType, object param = null)
		{
			this.OperationType = operationType;
			this.Param = param;
		}

		// Token: 0x0401E859 RID: 125017
		public EOperationType OperationType;

		// Token: 0x0401E85A RID: 125018
		public object Param;
	}
}
