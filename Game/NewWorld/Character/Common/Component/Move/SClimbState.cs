using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004916 RID: 18710
	[NullableContext(1)]
	[Nullable(0)]
	public class SClimbState
	{
		// Token: 0x06030E4A RID: 200266 RVA: 0x00C1D8A1 File Offset: 0x00C1BAA1
		public SClimbState(EClimbState? 攀爬状态 = null, EEnterClimb? 进入攀爬类型 = null, EExitClimb? 退出攀爬类型 = null)
		{
			this.攀爬状态 = 攀爬状态.GetValueOrDefault();
			this.进入攀爬类型 = 进入攀爬类型.GetValueOrDefault();
			this.退出攀爬类型 = 退出攀爬类型.GetValueOrDefault();
		}

		// Token: 0x06030E4B RID: 200267 RVA: 0x00C1D8D0 File Offset: 0x00C1BAD0
		[NullableContext(2)]
		public bool Equals(SClimbState inB)
		{
			return inB != null && this.攀爬状态 == inB.攀爬状态 && this.进入攀爬类型 == inB.进入攀爬类型 && this.退出攀爬类型 == inB.退出攀爬类型;
		}

		// Token: 0x06030E4C RID: 200268 RVA: 0x00C1D901 File Offset: 0x00C1BB01
		public void DeepCopy(SClimbState other)
		{
			this.攀爬状态 = other.攀爬状态;
			this.进入攀爬类型 = other.进入攀爬类型;
			this.退出攀爬类型 = other.退出攀爬类型;
		}

		// Token: 0x06030E4D RID: 200269 RVA: 0x00C1D927 File Offset: 0x00C1BB27
		public SClimbState Copy()
		{
			return new SClimbState(new EClimbState?(this.攀爬状态), new EEnterClimb?(this.进入攀爬类型), new EExitClimb?(this.退出攀爬类型));
		}

		// Token: 0x0401C1AB RID: 115115
		public EClimbState 攀爬状态;

		// Token: 0x0401C1AC RID: 115116
		public EEnterClimb 进入攀爬类型;

		// Token: 0x0401C1AD RID: 115117
		public EExitClimb 退出攀爬类型;
	}
}
