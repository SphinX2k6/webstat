using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F44 RID: 20292
	public class SkipToDetectionMaterial : SkipTask
	{
		// Token: 0x060345EA RID: 214506 RVA: 0x00D1B710 File Offset: 0x00D19910
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string text = (string)data[0];
			int confId = (text != null) ? int.Parse(text) : 0;
			ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
			ControllerBase<AdventureGuideController>.Instance.RequestForDetection(DetectionType.Material, Array.Empty<int>(), confId);
		}
	}
}
