using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C93 RID: 27795
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemSpringFestivalPictureAlbumView : OpenSystemBase
	{
		// Token: 0x0604430B RID: 279307 RVA: 0x011B33C3 File Offset: 0x011B15C3
		public OpenSystemSpringFestivalPictureAlbumView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604430C RID: 279308 RVA: 0x011B33CC File Offset: 0x011B15CC
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemSpringFestivalPictureAlbumView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemSpringFestivalPictureAlbumView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604430D RID: 279309 RVA: 0x011B340F File Offset: 0x011B160F
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.SpringManorAlbumView);
		}
	}
}
