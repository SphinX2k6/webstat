using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C44 RID: 19524
	public class MoveCheckInfo
	{
		// Token: 0x06032E05 RID: 208389 RVA: 0x00CBE914 File Offset: 0x00CBCB14
		public void Reset()
		{
			this.BeforeMoveCheckResult = EMoveCheckResult.None;
			this.AfterMoveCheckResult = EMoveCheckResult.None;
			this.AfterMoveCheckInfo.Result = EMoveCheckResult.None;
			this.AfterMoveCheckInfo.AfterAdjustDistance = float.MaxValue;
		}

		// Token: 0x06032E06 RID: 208390 RVA: 0x00CBE940 File Offset: 0x00CBCB40
		public void TryUpdateAdjustDistance(EMoveCheckResult checkResult, float afterAdjustDistance)
		{
			if (afterAdjustDistance < this.AfterMoveCheckInfo.AfterAdjustDistance)
			{
				this.AfterMoveCheckInfo.Result = checkResult;
				this.AfterMoveCheckInfo.AfterAdjustDistance = afterAdjustDistance;
			}
		}

		// Token: 0x0401D9E2 RID: 121314
		public EMoveCheckResult BeforeMoveCheckResult;

		// Token: 0x0401D9E3 RID: 121315
		public EMoveCheckResult AfterMoveCheckResult;

		// Token: 0x0401D9E4 RID: 121316
		[Nullable(1)]
		public IMoveCheckResultAndDistance AfterMoveCheckInfo = new MoveCheckResultAndDistance
		{
			Result = EMoveCheckResult.None,
			AfterAdjustDistance = float.MaxValue
		};

		// Token: 0x0401D9E5 RID: 121317
		public float BrakingDistance;
	}
}
