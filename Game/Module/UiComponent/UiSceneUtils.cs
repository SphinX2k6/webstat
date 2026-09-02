using System;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiComponent
{
	// Token: 0x02004D88 RID: 19848
	public class UiSceneUtils : IStaticVariableResetter
	{
		// Token: 0x06033644 RID: 210500 RVA: 0x00CDAAF7 File Offset: 0x00CD8CF7
		static UiSceneUtils()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(UiSceneUtils.CreateStaticDefaultValue), new Action(UiSceneUtils.ResetStaticDefaultValue));
		}

		// Token: 0x06033645 RID: 210501 RVA: 0x00CDAB16 File Offset: 0x00CD8D16
		public static void CreateStaticDefaultValue()
		{
			UiSceneUtils.SceneFloorReflection = true;
		}

		// Token: 0x06033646 RID: 210502 RVA: 0x00CDAB1E File Offset: 0x00CD8D1E
		public static void ResetStaticDefaultValue()
		{
			UiSceneUtils.SceneFloorReflection = true;
		}

		// Token: 0x06033647 RID: 210503 RVA: 0x00CDAB28 File Offset: 0x00CD8D28
		public static void SetSceneFloorReflection(bool isShow, bool isForce)
		{
			if (Singleton<GameSettingsDeviceRender>.Instance.IsQualcommGpu() && Singleton<Info>.Instance.IsPcPlatform())
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.EnablePlanarReflection 0", null);
				return;
			}
			if (UiSceneUtils.SceneFloorReflection == isShow && !isForce)
			{
				return;
			}
			UiSceneUtils.SceneFloorReflection = isShow;
			if (isShow)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.EnablePlanarReflection 1", null);
				return;
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.EnablePlanarReflection 0", null);
		}

		// Token: 0x0401DC8C RID: 121996
		private static bool SceneFloorReflection;
	}
}
