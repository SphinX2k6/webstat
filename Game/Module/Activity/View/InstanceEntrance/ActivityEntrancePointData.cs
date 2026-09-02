using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061DD RID: 25053
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivityEntrancePointData
	{
		// Token: 0x0603F386 RID: 258950 RVA: 0x0103A3E4 File Offset: 0x010385E4
		public int GetCurrentPoint()
		{
			return this.CurrentPoint;
		}

		// Token: 0x0603F387 RID: 258951 RVA: 0x0103A3EC File Offset: 0x010385EC
		public ERedDotName? GetRedDotName()
		{
			return this.RedDotName;
		}

		// Token: 0x0603F388 RID: 258952 RVA: 0x0103A3F4 File Offset: 0x010385F4
		public int GetRedDotId()
		{
			return this.RedDotId;
		}

		// Token: 0x0603F389 RID: 258953 RVA: 0x0103A3FC File Offset: 0x010385FC
		public Action GetPointRewardBtnClickCallBack()
		{
			return this.PointRewardBtnClickCallBack;
		}

		// Token: 0x0603F38A RID: 258954 RVA: 0x0103A404 File Offset: 0x01038604
		public int GetLimitPoint()
		{
			return this.LimitPoint;
		}

		// Token: 0x0603F38B RID: 258955 RVA: 0x0103A40C File Offset: 0x0103860C
		public IActivityRewardViewData GetRewardData()
		{
			return this.RewardData;
		}

		// Token: 0x0603F38C RID: 258956 RVA: 0x0103A414 File Offset: 0x01038614
		[NullableContext(1)]
		public string GetScoreDesc()
		{
			if (this.GetScoreDescCallBack == null)
			{
				return string.Empty;
			}
			return this.GetScoreDescCallBack();
		}

		// Token: 0x0603F38D RID: 258957 RVA: 0x0103A42F File Offset: 0x0103862F
		[return: Nullable(1)]
		public static ActivityEntrancePointData Create(int currentPoint, int limitPoint, ERedDotName? redDotName, int redDotId, IActivityRewardViewData rewardData, [Nullable(new byte[]
		{
			2,
			1
		})] Func<string> getScoreDescCallBack, Action pointRewardBtnClickCallBack)
		{
			return new ActivityEntrancePointData
			{
				CurrentPoint = currentPoint,
				RedDotName = redDotName,
				RedDotId = redDotId,
				LimitPoint = limitPoint,
				RewardData = rewardData,
				GetScoreDescCallBack = getScoreDescCallBack,
				PointRewardBtnClickCallBack = pointRewardBtnClickCallBack
			};
		}

		// Token: 0x040237F8 RID: 145400
		private int CurrentPoint;

		// Token: 0x040237F9 RID: 145401
		private int LimitPoint;

		// Token: 0x040237FA RID: 145402
		private ERedDotName? RedDotName;

		// Token: 0x040237FB RID: 145403
		private int RedDotId;

		// Token: 0x040237FC RID: 145404
		private IActivityRewardViewData RewardData;

		// Token: 0x040237FD RID: 145405
		private Action PointRewardBtnClickCallBack;

		// Token: 0x040237FE RID: 145406
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<string> GetScoreDescCallBack;
	}
}
