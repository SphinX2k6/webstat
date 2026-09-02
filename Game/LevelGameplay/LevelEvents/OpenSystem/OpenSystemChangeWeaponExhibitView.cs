using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C3F RID: 27711
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemChangeWeaponExhibitView : OpenSystemBase
	{
		// Token: 0x0604420F RID: 279055 RVA: 0x011B11DB File Offset: 0x011AF3DB
		public OpenSystemChangeWeaponExhibitView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044210 RID: 279056 RVA: 0x011B11E4 File Offset: 0x011AF3E4
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemChangeWeaponExhibitView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemChangeWeaponExhibitView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044211 RID: 279057 RVA: 0x011B1227 File Offset: 0x011AF427
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.SpringManorWeaponExhibitView);
		}
	}
}
