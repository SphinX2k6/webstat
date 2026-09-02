using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Core.Define.TdConfigExtensions
{
	// Token: 0x02007138 RID: 28984
	[NullableContext(2)]
	[Nullable(0)]
	public static class RpcUniTaskHelper
	{
		// Token: 0x060462DD RID: 287453 RVA: 0x0126E9D8 File Offset: 0x0126CBD8
		public static bool IsPending(object result)
		{
			bool flag = result is UniTask || result is UniTask<object>;
			if (flag)
			{
				return true;
			}
			if (result == null)
			{
				return false;
			}
			Type type = result.GetType();
			return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(UniTask<>);
		}

		// Token: 0x060462DE RID: 287454 RVA: 0x0126EA2C File Offset: 0x0126CC2C
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public static UniTask<object> Await(object result)
		{
			RpcUniTaskHelper.<Await>d__2 <Await>d__;
			<Await>d__.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
			<Await>d__.result = result;
			<Await>d__.<>1__state = -1;
			<Await>d__.<>t__builder.Start<RpcUniTaskHelper.<Await>d__2>(ref <Await>d__);
			return <Await>d__.<>t__builder.Task;
		}

		// Token: 0x060462DF RID: 287455 RVA: 0x0126EA70 File Offset: 0x0126CC70
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private static UniTask<object> AwaitGeneric(object uniTask)
		{
			Type type = uniTask.GetType().GetGenericArguments()[0];
			return (UniTask<object>)RpcUniTaskHelper.AwaitGenericMethod.MakeGenericMethod(new Type[]
			{
				type
			}).Invoke(null, new object[]
			{
				uniTask
			});
		}

		// Token: 0x060462E0 RID: 287456 RVA: 0x0126EAB4 File Offset: 0x0126CCB4
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private static UniTask<object> AwaitGenericImpl<T>([Nullable(new byte[]
		{
			0,
			1
		})] UniTask<T> task)
		{
			RpcUniTaskHelper.<AwaitGenericImpl>d__4<T> <AwaitGenericImpl>d__;
			<AwaitGenericImpl>d__.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
			<AwaitGenericImpl>d__.task = task;
			<AwaitGenericImpl>d__.<>1__state = -1;
			<AwaitGenericImpl>d__.<>t__builder.Start<RpcUniTaskHelper.<AwaitGenericImpl>d__4<T>>(ref <AwaitGenericImpl>d__);
			return <AwaitGenericImpl>d__.<>t__builder.Task;
		}

		// Token: 0x0402759B RID: 161179
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly MethodInfo AwaitGenericMethod = typeof(RpcUniTaskHelper).GetMethod("AwaitGenericImpl", BindingFlags.Static | BindingFlags.NonPublic);
	}
}
