using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelListeners
{
	// Token: 0x02006B5D RID: 27485
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelListenerBase
	{
		// Token: 0x1700A331 RID: 41777
		// (get) Token: 0x06043E5A RID: 278106 RVA: 0x0118EA0A File Offset: 0x0118CC0A
		public bool IsListening
		{
			get
			{
				return this.IsListeningInternal;
			}
		}

		// Token: 0x06043E5B RID: 278107 RVA: 0x0118EA12 File Offset: 0x0118CC12
		[NullableContext(1)]
		public void Listen(object listeningInfo, TListenerCallbackFunc callback, GeneralContext context, params object[] otherParams)
		{
			if (this.IsListeningInternal)
			{
				return;
			}
			this.IsListeningInternal = true;
			this.ListeningInfo = listeningInfo;
			this.Callback = callback;
			this.Context = context;
			this.OnListen(listeningInfo, callback, context, otherParams);
		}

		// Token: 0x06043E5C RID: 278108 RVA: 0x0118EA44 File Offset: 0x0118CC44
		[NullableContext(1)]
		protected virtual void OnListen(object listeningInfo, TListenerCallbackFunc callback, [Nullable(2)] GeneralContext context = null, params object[] otherParams)
		{
		}

		// Token: 0x06043E5D RID: 278109 RVA: 0x0118EA46 File Offset: 0x0118CC46
		public void UnListen()
		{
			if (!this.IsListeningInternal)
			{
				return;
			}
			this.OnUnListen();
			this.IsListeningInternal = false;
			this.ListeningInfo = null;
			this.Callback = null;
			this.Context = null;
		}

		// Token: 0x06043E5E RID: 278110 RVA: 0x0118EA73 File Offset: 0x0118CC73
		protected virtual void OnUnListen()
		{
		}

		// Token: 0x04025F94 RID: 155540
		protected object ListeningInfo;

		// Token: 0x04025F95 RID: 155541
		protected TListenerCallbackFunc Callback;

		// Token: 0x04025F96 RID: 155542
		protected GeneralContext Context;

		// Token: 0x04025F97 RID: 155543
		protected bool IsListeningInternal;
	}
}
