using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.QuickTimeAction;
using AkiClient.Game.Aki.Data.QuickTimeAction.Customization;

namespace CSharpScript.Game.Module.QuickTimeAction.Context
{
	// Token: 0x020052B8 RID: 21176
	[NullableContext(2)]
	[Nullable(0)]
	public class QtaCustomizationBaseLogic
	{
		// Token: 0x06036217 RID: 221719 RVA: 0x00DA21D8 File Offset: 0x00DA03D8
		[NullableContext(1)]
		public virtual void OnSetConfig(QtaCustomizationContext qtaContext, SQta qtaConfig, BP_QtaCustomizationBase_C daConfig)
		{
		}

		// Token: 0x06036218 RID: 221720 RVA: 0x00DA21DA File Offset: 0x00DA03DA
		public virtual void OnQtaStart()
		{
		}

		// Token: 0x06036219 RID: 221721 RVA: 0x00DA21DC File Offset: 0x00DA03DC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public virtual List<string> OnGetActions()
		{
			return null;
		}

		// Token: 0x0603621A RID: 221722 RVA: 0x00DA21DF File Offset: 0x00DA03DF
		public virtual float GetProgress()
		{
			return 0f;
		}

		// Token: 0x0603621B RID: 221723 RVA: 0x00DA21E6 File Offset: 0x00DA03E6
		public virtual float GetBgProgress(int index = 0)
		{
			return 0f;
		}

		// Token: 0x0603621C RID: 221724 RVA: 0x00DA21ED File Offset: 0x00DA03ED
		public virtual void OnQtaResponse(bool press = true)
		{
		}

		// Token: 0x0603621D RID: 221725 RVA: 0x00DA21EF File Offset: 0x00DA03EF
		public virtual void OnUpdateTime(float delta)
		{
		}

		// Token: 0x0603621E RID: 221726 RVA: 0x00DA21F1 File Offset: 0x00DA03F1
		public virtual bool CheckQtaCanEnd()
		{
			return false;
		}

		// Token: 0x0603621F RID: 221727 RVA: 0x00DA21F4 File Offset: 0x00DA03F4
		protected virtual bool CheckIsValid()
		{
			return false;
		}

		// Token: 0x06036220 RID: 221728 RVA: 0x00DA21F8 File Offset: 0x00DA03F8
		public virtual void OnPreEndQta()
		{
			if (this.QtaContext == null)
			{
				return;
			}
			if (this.QtaContext.IsEnd())
			{
				return;
			}
			if (this.QtaContext.HasResult())
			{
				this.QtaContext.SetQtaResult(this.QtaContext.PendingResultType);
				return;
			}
			this.QtaContext.SetQtaResult(this.CheckIsValid() ? EQtaResult.Success : EQtaResult.Fail);
		}

		// Token: 0x06036221 RID: 221729 RVA: 0x00DA2257 File Offset: 0x00DA0457
		public virtual void OnQtaEnd(bool success = false)
		{
		}

		// Token: 0x0401F194 RID: 127380
		protected SQta QtaConfig;

		// Token: 0x0401F195 RID: 127381
		protected QtaCustomizationContext QtaContext;

		// Token: 0x0401F196 RID: 127382
		protected float PassTime;
	}
}
