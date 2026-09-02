using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005351 RID: 21329
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PlotCameraTemplateConfig : ConfigBase<PlotCameraTemplateConfig>
	{
		// Token: 0x06036683 RID: 222851 RVA: 0x00DB8044 File Offset: 0x00DB6244
		public FlowTemplateData? GetCameraTemplateConfig(int id)
		{
			FlowTemplateData? config = ConfigFlowTemplateDataById.GetConfig(id, false);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "找不到相机模板配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CameraTemplate ID", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return new FlowTemplateData?(config.Value);
		}
	}
}
