using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.PreDownload
{
	// Token: 0x02004541 RID: 17729
	[NullableContext(1)]
	public interface IPreDownload
	{
		// Token: 0x0602EA94 RID: 191124
		bool IsPreDownloadEnabled();

		// Token: 0x0602EA95 RID: 191125
		void CheckEnabledWithTick();

		// Token: 0x0602EA96 RID: 191126
		void TryRemoveTick();

		// Token: 0x0602EA97 RID: 191127
		void AddEnabledEvent(Action cb);

		// Token: 0x0602EA98 RID: 191128
		void RemoveEnabledEvent(Action cb);

		// Token: 0x0602EA99 RID: 191129
		void AddCompleteEvent(Action cb);

		// Token: 0x0602EA9A RID: 191130
		void RemoveCompleteEvent(Action cb);

		// Token: 0x0602EA9B RID: 191131
		void SetView(IPreDownloadUiEvent ui);

		// Token: 0x0602EA9C RID: 191132
		void ClearView();

		// Token: 0x0602EA9D RID: 191133
		long GetDownloadSize();

		// Token: 0x0602EA9E RID: 191134
		long GetNeedSpace();

		// Token: 0x0602EA9F RID: 191135
		void Start(EPreDownloadMode mode);

		// Token: 0x0602EAA0 RID: 191136
		void Stop();

		// Token: 0x0602EAA1 RID: 191137
		void Resume();

		// Token: 0x0602EAA2 RID: 191138
		bool IsDownloading();

		// Token: 0x0602EAA3 RID: 191139
		bool IsComplete();

		// Token: 0x0602EAA4 RID: 191140
		EPreDownloadState GetState();
	}
}
