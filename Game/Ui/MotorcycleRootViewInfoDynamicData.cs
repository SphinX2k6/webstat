using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049BD RID: 18877
	public class MotorcycleRootViewInfoDynamicData : ViewInfoDynamicData, IViewInfoDynamicSceneData
	{
		// Token: 0x060315E2 RID: 202210 RVA: 0x00C492E8 File Offset: 0x00C474E8
		[NullableContext(2)]
		public string GetSceneId()
		{
			int currentSceneId = ModelBase<MotorcycleDiyModel>.Instance.GetCurrentSceneId();
			MotorScene? motorSceneConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorSceneConfig(currentSceneId);
			if (motorSceneConfig != null)
			{
				return motorSceneConfig.Value.SceneId;
			}
			return null;
		}
	}
}
