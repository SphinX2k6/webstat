using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.DiffPatch.Procedure
{
	// Token: 0x02004635 RID: 17973
	[NullableContext(1)]
	[Nullable(0)]
	public class AndroidDiffPatchProcedure : MobileDiffPatchProcedure
	{
		// Token: 0x0602EF22 RID: 192290 RVA: 0x00B1F5BA File Offset: 0x00B1D7BA
		public AndroidDiffPatchProcedure(AppPathMisc pathMisc, HotFixManager viewMgr) : base(pathMisc, viewMgr)
		{
		}

		// Token: 0x0602EF23 RID: 192291 RVA: 0x00B1F5C4 File Offset: 0x00B1D7C4
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private UniTask<List<string>> RequestAndroidPermissions(TArray<string> permissions)
		{
			AndroidDiffPatchProcedure.<RequestAndroidPermissions>d__1 <RequestAndroidPermissions>d__;
			<RequestAndroidPermissions>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<string>>.Create();
			<RequestAndroidPermissions>d__.permissions = permissions;
			<RequestAndroidPermissions>d__.<>1__state = -1;
			<RequestAndroidPermissions>d__.<>t__builder.Start<AndroidDiffPatchProcedure.<RequestAndroidPermissions>d__1>(ref <RequestAndroidPermissions>d__);
			return <RequestAndroidPermissions>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF24 RID: 192292 RVA: 0x00B1F608 File Offset: 0x00B1D808
		public UniTask RequestPermission()
		{
			AndroidDiffPatchProcedure.<RequestPermission>d__2 <RequestPermission>d__;
			<RequestPermission>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestPermission>d__.<>4__this = this;
			<RequestPermission>d__.<>1__state = -1;
			<RequestPermission>d__.<>t__builder.Start<AndroidDiffPatchProcedure.<RequestPermission>d__2>(ref <RequestPermission>d__);
			return <RequestPermission>d__.<>t__builder.Task;
		}
	}
}
