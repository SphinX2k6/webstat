using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Functional;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F4B RID: 20299
	public class SkipToGachaView : SkipToMoonChasingBase
	{
		// Token: 0x060345F8 RID: 214520 RVA: 0x00D1BB6F File Offset: 0x00D19D6F
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.Gacha);
		}
	}
}
