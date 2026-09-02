using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F38 RID: 20280
	public class SkipTaskVisionIntensifyView : SkipTask
	{
		// Token: 0x060345D2 RID: 214482 RVA: 0x00D1AF3C File Offset: 0x00D1913C
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			int uniqueId = (int)data[0];
			VisionIntensifyViewPassData visionIntensifyViewPassData = new VisionIntensifyViewPassData();
			visionIntensifyViewPassData.UniqueId = uniqueId;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionIntensifyView, visionIntensifyViewPassData, null);
			base.Finish();
		}
	}
}
