using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Controller
{
	// Token: 0x02004AF1 RID: 19185
	public abstract class ExecutableUnitBase : IExecutableUnit
	{
		// Token: 0x17008567 RID: 34151
		// (get) Token: 0x06032045 RID: 204869 RVA: 0x00C83F7D File Offset: 0x00C8217D
		// (set) Token: 0x06032046 RID: 204870 RVA: 0x00C83F85 File Offset: 0x00C82185
		public bool IsExecute { get; private set; }

		// Token: 0x17008568 RID: 34152
		// (get) Token: 0x06032047 RID: 204871
		public abstract int Id { get; }

		// Token: 0x17008569 RID: 34153
		// (get) Token: 0x06032048 RID: 204872
		[Nullable(1)]
		public abstract Enum Type { [NullableContext(1)] get; }

		// Token: 0x06032049 RID: 204873 RVA: 0x00C83F8E File Offset: 0x00C8218E
		public bool Create()
		{
			return this.OnCreate();
		}

		// Token: 0x0603204A RID: 204874 RVA: 0x00C83F96 File Offset: 0x00C82196
		public void Destroy()
		{
			this.OnDestroy();
		}

		// Token: 0x0603204B RID: 204875 RVA: 0x00C83FA0 File Offset: 0x00C821A0
		public UniTask ExecuteAction()
		{
			ExecutableUnitBase.<ExecuteAction>d__11 <ExecuteAction>d__;
			<ExecuteAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAction>d__.<>4__this = this;
			<ExecuteAction>d__.<>1__state = -1;
			<ExecuteAction>d__.<>t__builder.Start<ExecutableUnitBase.<ExecuteAction>d__11>(ref <ExecuteAction>d__);
			return <ExecuteAction>d__.<>t__builder.Task;
		}

		// Token: 0x0603204C RID: 204876 RVA: 0x00C83FE3 File Offset: 0x00C821E3
		public void OnTick(float delta)
		{
		}

		// Token: 0x0603204D RID: 204877 RVA: 0x00C83FE5 File Offset: 0x00C821E5
		protected virtual bool OnCreate()
		{
			return true;
		}

		// Token: 0x0603204E RID: 204878 RVA: 0x00C83FE8 File Offset: 0x00C821E8
		protected virtual void OnDestroy()
		{
		}

		// Token: 0x0603204F RID: 204879
		protected abstract UniTask OnExecuteAction();

		// Token: 0x06032050 RID: 204880 RVA: 0x00C83FEA File Offset: 0x00C821EA
		protected virtual void OnBeforeExecuteAction()
		{
		}

		// Token: 0x06032051 RID: 204881 RVA: 0x00C83FEC File Offset: 0x00C821EC
		protected virtual void OnAfterExecuteAction()
		{
		}

		// Token: 0x06032052 RID: 204882 RVA: 0x00C83FEE File Offset: 0x00C821EE
		public virtual void OnRollbackRestore()
		{
		}

		// Token: 0x0401D40C RID: 119820
		public static readonly bool EnableTick;
	}
}
