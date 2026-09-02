using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Plot.Sequence.Assistant
{
	// Token: 0x020053A5 RID: 21413
	[NullableContext(2)]
	[Nullable(0)]
	public class SeqBaseAssistant : ControllerAssistantBase
	{
		// Token: 0x060369B5 RID: 223669 RVA: 0x00DD1E0B File Offset: 0x00DD000B
		protected void DoCallback(bool result)
		{
			if (this.Callback != null)
			{
				Action<bool> callback = this.Callback;
				this.Callback = null;
				callback(result);
			}
		}

		// Token: 0x060369B6 RID: 223670 RVA: 0x00DD1E28 File Offset: 0x00DD0028
		public virtual void End()
		{
		}

		// Token: 0x060369B7 RID: 223671 RVA: 0x00DD1E2A File Offset: 0x00DD002A
		public virtual void Load(Action<bool> callback = null)
		{
		}

		// Token: 0x060369B8 RID: 223672 RVA: 0x00DD1E2C File Offset: 0x00DD002C
		[NullableContext(0)]
		public virtual UniTask<bool> LoadPromise()
		{
			SeqBaseAssistant.<LoadPromise>d__7 <LoadPromise>d__;
			<LoadPromise>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LoadPromise>d__.<>4__this = this;
			<LoadPromise>d__.<>1__state = -1;
			<LoadPromise>d__.<>t__builder.Start<SeqBaseAssistant.<LoadPromise>d__7>(ref <LoadPromise>d__);
			return <LoadPromise>d__.<>t__builder.Task;
		}

		// Token: 0x060369B9 RID: 223673 RVA: 0x00DD1E6F File Offset: 0x00DD006F
		public virtual void PreAllPlay(Action<bool> callback = null)
		{
		}

		// Token: 0x060369BA RID: 223674 RVA: 0x00DD1E74 File Offset: 0x00DD0074
		[NullableContext(0)]
		public virtual UniTask<bool> PreAllPlayPromise()
		{
			SeqBaseAssistant.<PreAllPlayPromise>d__9 <PreAllPlayPromise>d__;
			<PreAllPlayPromise>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PreAllPlayPromise>d__.<>4__this = this;
			<PreAllPlayPromise>d__.<>1__state = -1;
			<PreAllPlayPromise>d__.<>t__builder.Start<SeqBaseAssistant.<PreAllPlayPromise>d__9>(ref <PreAllPlayPromise>d__);
			return <PreAllPlayPromise>d__.<>t__builder.Task;
		}

		// Token: 0x060369BB RID: 223675 RVA: 0x00DD1EB7 File Offset: 0x00DD00B7
		public virtual void PreEachPlay()
		{
		}

		// Token: 0x060369BC RID: 223676 RVA: 0x00DD1EB9 File Offset: 0x00DD00B9
		public virtual void EachStop()
		{
		}

		// Token: 0x060369BD RID: 223677 RVA: 0x00DD1EBB File Offset: 0x00DD00BB
		public virtual void CmdShadowUpdate()
		{
		}

		// Token: 0x060369BE RID: 223678 RVA: 0x00DD1EBD File Offset: 0x00DD00BD
		public virtual void AllStop(Action<bool> callback = null)
		{
		}

		// Token: 0x060369BF RID: 223679 RVA: 0x00DD1EC0 File Offset: 0x00DD00C0
		[NullableContext(0)]
		public virtual UniTask<bool> AllStopPromise()
		{
			SeqBaseAssistant.<AllStopPromise>d__14 <AllStopPromise>d__;
			<AllStopPromise>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<AllStopPromise>d__.<>4__this = this;
			<AllStopPromise>d__.<>1__state = -1;
			<AllStopPromise>d__.<>t__builder.Start<SeqBaseAssistant.<AllStopPromise>d__14>(ref <AllStopPromise>d__);
			return <AllStopPromise>d__.<>t__builder.Task;
		}

		// Token: 0x060369C0 RID: 223680 RVA: 0x00DD1F03 File Offset: 0x00DD0103
		public virtual void LoadNecessaryData(Action callback = null)
		{
		}

		// Token: 0x060369C1 RID: 223681 RVA: 0x00DD1F05 File Offset: 0x00DD0105
		protected override void OnDestroy()
		{
		}

		// Token: 0x0401F73A RID: 128826
		[Nullable(1)]
		protected SequenceModel Model = ModelBase<SequenceModel>.Instance;

		// Token: 0x0401F73B RID: 128827
		protected bool IsRunning;

		// Token: 0x0401F73C RID: 128828
		protected Action<bool> Callback;

		// Token: 0x0401F73D RID: 128829
		protected CustomPromise<bool> Promise;
	}
}
