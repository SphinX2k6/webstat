using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056E5 RID: 22245
	[NullableContext(2)]
	public interface IExitMovieModeParams
	{
		// Token: 0x170090EE RID: 37102
		// (get) Token: 0x060389EB RID: 231915
		// (set) Token: 0x060389EC RID: 231916
		float BlendTime { get; set; }

		// Token: 0x170090EF RID: 37103
		// (get) Token: 0x060389ED RID: 231917
		// (set) Token: 0x060389EE RID: 231918
		float? BlackFadeInTime { get; set; }

		// Token: 0x170090F0 RID: 37104
		// (get) Token: 0x060389EF RID: 231919
		// (set) Token: 0x060389F0 RID: 231920
		Func<UniTask> AfterBlackFadeInCallbackAsync { get; set; }
	}
}
