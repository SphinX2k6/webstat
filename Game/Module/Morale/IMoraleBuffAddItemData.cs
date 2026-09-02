using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x0200570A RID: 22282
	[NullableContext(1)]
	public interface IMoraleBuffAddItemData
	{
		// Token: 0x1700911A RID: 37146
		// (get) Token: 0x06038B76 RID: 232310
		string IconPath { get; }

		// Token: 0x1700911B RID: 37147
		// (get) Token: 0x06038B77 RID: 232311
		string NameKey { get; }

		// Token: 0x1700911C RID: 37148
		// (get) Token: 0x06038B78 RID: 232312
		string Value { get; }
	}
}
