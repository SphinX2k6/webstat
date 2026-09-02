using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049FF RID: 18943
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class InputDistributeSetup
	{
		// Token: 0x060318BC RID: 202940
		public abstract bool OnRefresh();

		// Token: 0x060318BD RID: 202941 RVA: 0x00C59397 File Offset: 0x00C57597
		protected void SetInputDistributeTag(string tagName)
		{
			ModelBase<InputDistributeModel>.Instance.SetInputDistributeTag(tagName);
		}

		// Token: 0x060318BE RID: 202942 RVA: 0x00C593A4 File Offset: 0x00C575A4
		protected void SetInputDistributeTags(IList<string> tagNames)
		{
			ModelBase<InputDistributeModel>.Instance.SetInputDistributeTags(tagNames);
		}

		// Token: 0x060318BF RID: 202943 RVA: 0x00C593B1 File Offset: 0x00C575B1
		protected void AddInputDistributeTag(string tagName)
		{
			ModelBase<InputDistributeModel>.Instance.AddInputDistributeTag(tagName);
		}

		// Token: 0x060318C0 RID: 202944 RVA: 0x00C593BE File Offset: 0x00C575BE
		protected void RemoveInputDistributeTag(string tagName, bool bRemoveChild = false)
		{
			ModelBase<InputDistributeModel>.Instance.RemoveInputDistributeTag(tagName, bRemoveChild);
		}
	}
}
