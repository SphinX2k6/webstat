using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Input;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005411 RID: 21521
	public class FlowActionCameraLookAt : FlowActionLevelAsyncAction
	{
		// Token: 0x06036F1A RID: 225050 RVA: 0x00DF2384 File Offset: 0x00DF0584
		protected override void OnBackgroundExecute()
		{
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F1B RID: 225051 RVA: 0x00DF2390 File Offset: 0x00DF0590
		protected override void OnInterruptExecute()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[CameraLookAt] FlowActionCameraLookAt", default(ReadOnlySpan<ValueTuple<string, object>>));
			CharacterInputComponent component = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<CharacterInputComponent>();
			CameraLookAt cameraLookAt = this.ActionInfo.Params as CameraLookAt;
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ExitCameraGuide();
			if (cameraLookAt != null && cameraLookAt.BanInput.GetValueOrDefault())
			{
				ControllerBase<InputController>.Instance.AddInputHandler(component);
				ControllerBase<CameraController>.Instance.SetInputEnable(Global.BaseCharacter, true, "MainCamera");
			}
			base.OnInterruptExecute();
		}
	}
}
