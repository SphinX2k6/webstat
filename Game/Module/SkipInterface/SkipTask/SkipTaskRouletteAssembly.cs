using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F36 RID: 20278
	public class SkipTaskRouletteAssembly : SkipTask
	{
		// Token: 0x060345CD RID: 214477 RVA: 0x00D1AD3C File Offset: 0x00D18F3C
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			string text = (string)data[1];
			string text2 = (string)data[2];
			int num = int.Parse(s);
			int? selectGridId = (text != null) ? new int?(int.Parse(text)) : null;
			if (ConfigBase<RouletteConfig>.Instance.GetExploreRouletteTypeById(num) == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SkipInterface;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "探索工具界面跳转失败,轮盘类型不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.Finish();
				return;
			}
			ControllerBase<RouletteController>.Instance.OpenAssemblyView((ERouletteType)num, null, null, selectGridId);
			base.Finish();
		}
	}
}
