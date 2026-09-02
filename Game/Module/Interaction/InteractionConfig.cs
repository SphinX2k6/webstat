using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005B92 RID: 23442
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class InteractionConfig : ConfigBase<InteractionConfig>
	{
		// Token: 0x0603B487 RID: 242823 RVA: 0x00F02890 File Offset: 0x00F00A90
		public InteractData? GetInteractionConfig(string guid)
		{
			InteractData? config = ConfigInteractDataByGuid.GetConfig(guid, false);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Interaction;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "找不到交互配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Interact GUID", guid);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}
	}
}
