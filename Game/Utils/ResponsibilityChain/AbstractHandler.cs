using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.ResponsibilityChain
{
	// Token: 0x02004702 RID: 18178
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class AbstractHandler<[Nullable(0)] T> : IParameterHandler<T> where T : IParameterContext
	{
		// Token: 0x0602F41C RID: 193564 RVA: 0x00B34EAA File Offset: 0x00B330AA
		public IParameterHandler<T> SetNext(IParameterHandler<T> handler)
		{
			this.NextHandler = handler;
			return handler;
		}

		// Token: 0x0602F41D RID: 193565 RVA: 0x00B34EB4 File Offset: 0x00B330B4
		public unsafe bool Handle(T context)
		{
			if (this.CanHandle(context))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ResponsibilityChain;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "AbstractHandler ExecuteProcessing";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Current Handler:", base.GetType().Name);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "NextHandler:";
				IParameterHandler<T> nextHandler = this.NextHandler;
				ptr = new ValueTuple<string, object>(item, (nextHandler != null) ? nextHandler.GetType().Name : null);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.ExecuteProcessing(context);
				return true;
			}
			IParameterHandler<T> nextHandler2 = this.NextHandler;
			return nextHandler2 != null && nextHandler2.Handle(context);
		}

		// Token: 0x0602F41E RID: 193566 RVA: 0x00B34F5C File Offset: 0x00B3315C
		public unsafe bool Stop(T context)
		{
			if (this.ShouldStop(context))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ResponsibilityChain;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "AbstractHandler ExecuteStopping";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Current Handler:", base.GetType().Name);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "NextHandler:";
				IParameterHandler<T> nextHandler = this.NextHandler;
				ptr = new ValueTuple<string, object>(item, (nextHandler != null) ? nextHandler.GetType().Name : null);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.ExecuteStopping(context);
				return true;
			}
			IParameterHandler<T> nextHandler2 = this.NextHandler;
			return nextHandler2 != null && nextHandler2.Stop(context);
		}

		// Token: 0x0602F41F RID: 193567
		protected abstract bool CanHandle(T context);

		// Token: 0x0602F420 RID: 193568
		protected abstract bool ShouldStop(T context);

		// Token: 0x0602F421 RID: 193569
		protected abstract void ExecuteProcessing(T context);

		// Token: 0x0602F422 RID: 193570
		protected abstract void ExecuteStopping(T context);

		// Token: 0x0401AEC2 RID: 110274
		private const bool ENABLE_RESPONSIBILITY_CHAIN_LOG = true;

		// Token: 0x0401AEC3 RID: 110275
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private IParameterHandler<T> NextHandler;
	}
}
