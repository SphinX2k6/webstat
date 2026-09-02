using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A10 RID: 18960
	[NullableContext(1)]
	public interface IUiProhibitRefreshData
	{
		// Token: 0x060318E9 RID: 202985
		bool CheckCondition();

		// Token: 0x060318EA RID: 202986
		string[] GetDistributeTags();
	}
}
