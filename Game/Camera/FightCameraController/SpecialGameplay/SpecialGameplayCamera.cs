using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Camera.FightCameraController.SpecialGameplay
{
	// Token: 0x020070C6 RID: 28870
	public class SpecialGameplayCamera : IStaticVariableResetter
	{
		// Token: 0x06045FDF RID: 286687 RVA: 0x0125D49E File Offset: 0x0125B69E
		static SpecialGameplayCamera()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SpecialGameplayCamera.CreateStaticDefaultValue), new Action(SpecialGameplayCamera.ResetStaticDefaultValue));
		}

		// Token: 0x06045FE0 RID: 286688 RVA: 0x0125D4C0 File Offset: 0x0125B6C0
		public static void CreateStaticDefaultValue()
		{
			SpecialGameplayCamera.GameplayMap = new Dictionary<int, Func<ISpecialGameplayCamera>>();
			SpecialGameplayCamera.GameplayMap.Add(0, () => new AiShengGuYangCamera());
			SpecialGameplayCamera.GameplayMap.Add(1, () => new PilotThrowCamera());
			SpecialGameplayCamera.GameplayMap.Add(2, () => new RhythmGameCamera());
			SpecialGameplayCamera.GameplayMap.Add(3, () => new ZoneFollowCamera());
		}

		// Token: 0x06045FE1 RID: 286689 RVA: 0x0125D57F File Offset: 0x0125B77F
		public static void ResetStaticDefaultValue()
		{
			SpecialGameplayCamera.GameplayMap = null;
		}

		// Token: 0x040273E4 RID: 160740
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public static Dictionary<int, Func<ISpecialGameplayCamera>> GameplayMap;
	}
}
