using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Infrastructure;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F4C RID: 20300
	public class SkipToInfrastructureMainView : SkipTask
	{
		// Token: 0x060345FA RID: 214522 RVA: 0x00D1BB88 File Offset: 0x00D19D88
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			ControllerBase<InfrastructureController>.Instance.OpenInfrastructureMainView(null).Forget<int?>();
			base.Finish();
		}
	}
}
