using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Comic
{
	// Token: 0x02005E87 RID: 24199
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ComicController : UiControllerBase<ComicController>
	{
		// Token: 0x0603CDAE RID: 249262 RVA: 0x00F725E2 File Offset: 0x00F707E2
		[NullableContext(1)]
		public void OpenComicView(IComicViewOpenParam param)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonComicView, param, null);
		}

		// Token: 0x0603CDAF RID: 249263 RVA: 0x00F725F8 File Offset: 0x00F707F8
		public UniTask<bool> OpenComicViewAsync([Nullable(1)] IComicViewOpenParam param)
		{
			ComicController.<OpenComicViewAsync>d__2 <OpenComicViewAsync>d__;
			<OpenComicViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenComicViewAsync>d__.param = param;
			<OpenComicViewAsync>d__.<>1__state = -1;
			<OpenComicViewAsync>d__.<>t__builder.Start<ComicController.<OpenComicViewAsync>d__2>(ref <OpenComicViewAsync>d__);
			return <OpenComicViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CDB0 RID: 249264 RVA: 0x00F7263B File Offset: 0x00F7083B
		protected override bool OnClear()
		{
			this.IsFadeBeforeHide = false;
			return true;
		}

		// Token: 0x040222A0 RID: 139936
		public bool IsFadeBeforeHide;
	}
}
