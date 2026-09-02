using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AAE RID: 19118
	[NullableContext(1)]
	public interface IExecutableUnit
	{
		// Token: 0x17008509 RID: 34057
		// (get) Token: 0x06031D91 RID: 204177
		bool IsExecute { get; }

		// Token: 0x1700850A RID: 34058
		// (get) Token: 0x06031D92 RID: 204178
		int Id { get; }

		// Token: 0x1700850B RID: 34059
		// (get) Token: 0x06031D93 RID: 204179
		Enum Type { get; }

		// Token: 0x06031D94 RID: 204180
		UniTask ExecuteAction();

		// Token: 0x06031D95 RID: 204181
		void OnTick(float delta);
	}
}
