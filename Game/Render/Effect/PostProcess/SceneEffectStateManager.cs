using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scene;
using UnrealEngine;

namespace CSharpScript.Game.Render.Effect.PostProcess
{
	// Token: 0x02004799 RID: 18329
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SceneEffectStateManager : Singleton<SceneEffectStateManager>
	{
		// Token: 0x0602F90E RID: 194830 RVA: 0x00B55FD2 File Offset: 0x00B541D2
		public SceneEffectStatePostVolume_C GetPostProcessVolume()
		{
			if (this.PostProcessVolume == null)
			{
				this.PostProcessVolume = (Singleton<ActorSystem>.Instance.Get(SceneEffectStatePostVolume_C.StaticClass(), new FTransformDouble(), null, true) as SceneEffectStatePostVolume_C);
			}
			return this.PostProcessVolume;
		}

		// Token: 0x0602F90F RID: 194831 RVA: 0x00B56003 File Offset: 0x00B54203
		public void SetSceneEffectState(ESceneEffectStateType stateType, float value)
		{
			if (stateType == ESceneEffectStateType.AirWall)
			{
				this.SetAirWall(value);
				return;
			}
			if (stateType != ESceneEffectStateType.ToxicFog)
			{
				return;
			}
			this.SetToxicFog(value);
		}

		// Token: 0x0602F910 RID: 194832 RVA: 0x00B5601C File Offset: 0x00B5421C
		public void SetAirWall(float value)
		{
			SceneEffectStatePostVolume_C postProcessVolume = this.GetPostProcessVolume();
			if (postProcessVolume == null || !postProcessVolume.IsValid())
			{
				return;
			}
			this.GetPostProcessVolume().SetAirWall(value);
		}

		// Token: 0x0602F911 RID: 194833 RVA: 0x00B56042 File Offset: 0x00B54242
		public void SetToxicFog(float value)
		{
			SceneEffectStatePostVolume_C postProcessVolume = this.GetPostProcessVolume();
			if (postProcessVolume == null || !postProcessVolume.IsValid())
			{
				return;
			}
			this.GetPostProcessVolume().SetToxicFog(value);
		}

		// Token: 0x0401B33F RID: 111423
		[Nullable(2)]
		public SceneEffectStatePostVolume_C PostProcessVolume;
	}
}
