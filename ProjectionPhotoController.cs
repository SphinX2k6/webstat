using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;

// Token: 0x02000FA2 RID: 4002
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ProjectionPhotoController : ControllerBase<ProjectionPhotoController>
{
	// Token: 0x0600666B RID: 26219 RVA: 0x0019C8BC File Offset: 0x0019AABC
	public void StartProjectionPhotoGameplay(long entityId, int pbDataId, IProjectionMachine config, Action<bool> finishCallback)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ProjectionPhotoView, new ProjectionPhotoViewParams
		{
			EntityId = entityId,
			PbDataId = pbDataId,
			Config = config,
			FinishCallback = finishCallback
		}, null);
	}
}
