using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Model
{
	// Token: 0x02004ACF RID: 19151
	[RequiredMember]
	public class RollbackCapture : IRollbackCapture
	{
		// Token: 0x06031EC3 RID: 204483 RVA: 0x00C7ECEB File Offset: 0x00C7CEEB
		public void Restore()
		{
			this.RestoreAction();
		}

		// Token: 0x06031EC4 RID: 204484 RVA: 0x00C7ECF8 File Offset: 0x00C7CEF8
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public RollbackCapture()
		{
		}

		// Token: 0x0401D37B RID: 119675
		[Nullable(1)]
		[RequiredMember]
		public Action RestoreAction;
	}
}
