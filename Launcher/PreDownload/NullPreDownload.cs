using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.PreDownload
{
	// Token: 0x02004542 RID: 17730
	[NullableContext(1)]
	[Nullable(0)]
	public class NullPreDownload : IPreDownload
	{
		// Token: 0x0602EAA5 RID: 191141 RVA: 0x00B0EC46 File Offset: 0x00B0CE46
		public bool IsPreDownloadEnabled()
		{
			return false;
		}

		// Token: 0x0602EAA6 RID: 191142 RVA: 0x00B0EC49 File Offset: 0x00B0CE49
		public void CheckEnabledWithTick()
		{
		}

		// Token: 0x0602EAA7 RID: 191143 RVA: 0x00B0EC4B File Offset: 0x00B0CE4B
		public void TryRemoveTick()
		{
		}

		// Token: 0x0602EAA8 RID: 191144 RVA: 0x00B0EC4D File Offset: 0x00B0CE4D
		public void AddEnabledEvent(Action cb)
		{
		}

		// Token: 0x0602EAA9 RID: 191145 RVA: 0x00B0EC4F File Offset: 0x00B0CE4F
		public void RemoveEnabledEvent(Action cb)
		{
		}

		// Token: 0x0602EAAA RID: 191146 RVA: 0x00B0EC51 File Offset: 0x00B0CE51
		public void AddCompleteEvent(Action cb)
		{
		}

		// Token: 0x0602EAAB RID: 191147 RVA: 0x00B0EC53 File Offset: 0x00B0CE53
		public void RemoveCompleteEvent(Action cb)
		{
		}

		// Token: 0x0602EAAC RID: 191148 RVA: 0x00B0EC55 File Offset: 0x00B0CE55
		public void SetView(IPreDownloadUiEvent ui)
		{
		}

		// Token: 0x0602EAAD RID: 191149 RVA: 0x00B0EC57 File Offset: 0x00B0CE57
		public void ClearView()
		{
		}

		// Token: 0x0602EAAE RID: 191150 RVA: 0x00B0EC59 File Offset: 0x00B0CE59
		public long GetDownloadSize()
		{
			return 0L;
		}

		// Token: 0x0602EAAF RID: 191151 RVA: 0x00B0EC5D File Offset: 0x00B0CE5D
		public long GetNeedSpace()
		{
			return 0L;
		}

		// Token: 0x0602EAB0 RID: 191152 RVA: 0x00B0EC61 File Offset: 0x00B0CE61
		public void Start(EPreDownloadMode mode)
		{
		}

		// Token: 0x0602EAB1 RID: 191153 RVA: 0x00B0EC63 File Offset: 0x00B0CE63
		public void Stop()
		{
		}

		// Token: 0x0602EAB2 RID: 191154 RVA: 0x00B0EC65 File Offset: 0x00B0CE65
		public void Resume()
		{
		}

		// Token: 0x0602EAB3 RID: 191155 RVA: 0x00B0EC67 File Offset: 0x00B0CE67
		public bool IsDownloading()
		{
			return false;
		}

		// Token: 0x0602EAB4 RID: 191156 RVA: 0x00B0EC6A File Offset: 0x00B0CE6A
		public bool IsComplete()
		{
			return false;
		}

		// Token: 0x0602EAB5 RID: 191157 RVA: 0x00B0EC6D File Offset: 0x00B0CE6D
		public EPreDownloadState GetState()
		{
			return EPreDownloadState.Disabled;
		}
	}
}
