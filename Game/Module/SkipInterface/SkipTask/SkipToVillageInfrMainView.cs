using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.VillageInfr;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F59 RID: 20313
	public class SkipToVillageInfrMainView : SkipTask
	{
		// Token: 0x06034616 RID: 214550 RVA: 0x00D1C0A4 File Offset: 0x00D1A2A4
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string textId = (string)data[0];
			if (!ModelBase<FunctionModel>.Instance.IsOpen(10150))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(textId, Array.Empty<object>());
			}
			else
			{
				ControllerBase<VillageInfrController>.Instance.OpenVillageInfrMainView(null).Forget<int?>();
			}
			base.Finish();
		}
	}
}
