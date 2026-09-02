using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Controller;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F46 RID: 20294
	public class SkipToEnrichmentArea : SkipTask
	{
		// Token: 0x060345EE RID: 214510 RVA: 0x00D1B95C File Offset: 0x00D19B5C
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			int num = (data.Length > 3 && data[3] != null) ? ((int)data[3]) : 0;
			if (num == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SkipInterface;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "跳转富集区失败,道具Id为空->";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId:", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ControllerBase<MapController>.Instance.RequestTrackEnrichmentArea(new int?(num));
		}
	}
}
