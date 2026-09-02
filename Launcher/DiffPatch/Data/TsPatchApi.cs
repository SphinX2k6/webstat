using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004657 RID: 18007
	[NullableContext(1)]
	[Nullable(0)]
	public class TsPatchApi
	{
		// Token: 0x0602EFB6 RID: 192438 RVA: 0x00B217A5 File Offset: 0x00B1F9A5
		public TsPatchApi()
		{
			this.Patcher = new UKuroBinPatch();
		}

		// Token: 0x0602EFB7 RID: 192439 RVA: 0x00B217B8 File Offset: 0x00B1F9B8
		[return: Nullable(new byte[]
		{
			0,
			0,
			1,
			1
		})]
		public UniTask<ValueTuple<int, HashSet<string>>> Patch(string diffFile, string oldDir, string newDir, Action<long> progress)
		{
			TsPatchApi.<Patch>d__2 <Patch>d__;
			<Patch>d__.<>t__builder = AsyncUniTaskMethodBuilder<ValueTuple<int, HashSet<string>>>.Create();
			<Patch>d__.<>4__this = this;
			<Patch>d__.diffFile = diffFile;
			<Patch>d__.oldDir = oldDir;
			<Patch>d__.newDir = newDir;
			<Patch>d__.progress = progress;
			<Patch>d__.<>1__state = -1;
			<Patch>d__.<>t__builder.Start<TsPatchApi.<Patch>d__2>(ref <Patch>d__);
			return <Patch>d__.<>t__builder.Task;
		}

		// Token: 0x0401ABF6 RID: 109558
		private readonly UKuroBinPatch Patcher;
	}
}
