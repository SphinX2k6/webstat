using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.MusicalInstrument;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F52 RID: 20306
	public class SkipToMusicalInstrumentView : SkipTask
	{
		// Token: 0x06034607 RID: 214535 RVA: 0x00D1BDD0 File Offset: 0x00D19FD0
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			int type = Convert.ToInt32(data[0]);
			base.Finish();
			ControllerBase<MusicalInstrumentController>.Instance.Enter(new MusicalInstrumentEnterParam
			{
				Type = (EInstrumentType)type
			}).Forget();
		}
	}
}
