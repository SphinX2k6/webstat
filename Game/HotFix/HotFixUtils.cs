using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.HotFix
{
	// Token: 0x0200701B RID: 28699
	public class HotFixUtils
	{
		// Token: 0x060457BE RID: 284606 RVA: 0x01229E9C File Offset: 0x0122809C
		[NullableContext(1)]
		public static void EvalScript(string script)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Game;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "该功能暂时不支持";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("script", script);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}
}
