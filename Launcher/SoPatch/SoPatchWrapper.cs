using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.SoPatch
{
	// Token: 0x02004536 RID: 17718
	public class SoPatchWrapper
	{
		// Token: 0x0602EA6C RID: 191084 RVA: 0x00B0DB20 File Offset: 0x00B0BD20
		[NullableContext(1)]
		[return: TupleElementNames(new string[]
		{
			"IsSuccess",
			"Message"
		})]
		[return: Nullable(new byte[]
		{
			0,
			0,
			1
		})]
		public static UniTask<ValueTuple<bool, string>> LoadPatch(string patch)
		{
			SoPatchWrapper.<LoadPatch>d__0 <LoadPatch>d__;
			<LoadPatch>d__.<>t__builder = AsyncUniTaskMethodBuilder<ValueTuple<bool, string>>.Create();
			<LoadPatch>d__.patch = patch;
			<LoadPatch>d__.<>1__state = -1;
			<LoadPatch>d__.<>t__builder.Start<SoPatchWrapper.<LoadPatch>d__0>(ref <LoadPatch>d__);
			return <LoadPatch>d__.<>t__builder.Task;
		}
	}
}
