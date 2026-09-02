using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061E1 RID: 25057
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivityEntranceSelectItemBaseData
	{
		// Token: 0x0603F3AD RID: 258989 RVA: 0x0103AACB File Offset: 0x01038CCB
		public bool GetSelectState()
		{
			return this.SelectState;
		}

		// Token: 0x0603F3AE RID: 258990 RVA: 0x0103AAD3 File Offset: 0x01038CD3
		public void SetSelectState(bool selectState)
		{
			this.SelectState = selectState;
		}

		// Token: 0x0603F3AF RID: 258991 RVA: 0x0103AADC File Offset: 0x01038CDC
		public int GetUiLogicIndex()
		{
			return this.UiLogicIndex;
		}

		// Token: 0x0603F3B0 RID: 258992 RVA: 0x0103AAE4 File Offset: 0x01038CE4
		[NullableContext(1)]
		public ActivityEntranceSelectItemSubData[] GetSubDataList()
		{
			return this.SubDataList;
		}

		// Token: 0x0603F3B1 RID: 258993 RVA: 0x0103AAEC File Offset: 0x01038CEC
		public int GetDataIndex()
		{
			return this.DataIndex;
		}

		// Token: 0x0603F3B2 RID: 258994 RVA: 0x0103AAF4 File Offset: 0x01038CF4
		[NullableContext(1)]
		public string GetName()
		{
			if (this.GetNameFunc == null)
			{
				return string.Empty;
			}
			return this.GetNameFunc(this.DataIndex);
		}

		// Token: 0x0603F3B3 RID: 258995 RVA: 0x0103AB15 File Offset: 0x01038D15
		[NullableContext(1)]
		public string GetDesc()
		{
			if (this.GetDescFunc == null)
			{
				return string.Empty;
			}
			return this.GetDescFunc(this.DataIndex);
		}

		// Token: 0x0603F3B4 RID: 258996 RVA: 0x0103AB36 File Offset: 0x01038D36
		public bool GetLockState()
		{
			return this.GetLockStateFunc != null && this.GetLockStateFunc(this.DataIndex);
		}

		// Token: 0x0603F3B5 RID: 258997 RVA: 0x0103AB53 File Offset: 0x01038D53
		public int GetInstanceDungeonId()
		{
			if (this.GetInstanceDungeonIdFunc == null)
			{
				return 0;
			}
			return this.GetInstanceDungeonIdFunc(this.DataIndex);
		}

		// Token: 0x0603F3B6 RID: 258998 RVA: 0x0103AB70 File Offset: 0x01038D70
		[NullableContext(1)]
		public string GetUnlockDesc()
		{
			if (this.GetUnlockDescFunc == null)
			{
				return string.Empty;
			}
			return this.GetUnlockDescFunc(this.DataIndex);
		}

		// Token: 0x0603F3B7 RID: 258999 RVA: 0x0103AB91 File Offset: 0x01038D91
		public int GetRecommendLevel()
		{
			if (this.GetRecommendLevelFunc == null)
			{
				return 0;
			}
			return this.GetRecommendLevelFunc(this.DataIndex);
		}

		// Token: 0x0603F3B8 RID: 259000 RVA: 0x0103ABAE File Offset: 0x01038DAE
		public bool GetFinishState()
		{
			return this.GetFinishStateFunc != null && this.GetFinishStateFunc(this.DataIndex);
		}

		// Token: 0x0603F3B9 RID: 259001 RVA: 0x0103ABCB File Offset: 0x01038DCB
		public bool GetRedDotState()
		{
			return this.GetRedDotStateFunc != null && this.GetRedDotStateFunc(this.DataIndex);
		}

		// Token: 0x0603F3BA RID: 259002 RVA: 0x0103ABE8 File Offset: 0x01038DE8
		public Action<int> GetClickCallBack()
		{
			return this.ClickCallBack;
		}

		// Token: 0x0603F3BB RID: 259003 RVA: 0x0103ABF0 File Offset: 0x01038DF0
		[NullableContext(1)]
		public string GetSubTitle()
		{
			if (this.GetSubTitleFunc == null)
			{
				return string.Empty;
			}
			return this.GetSubTitleFunc(this.DataIndex);
		}

		// Token: 0x0603F3BC RID: 259004 RVA: 0x0103AC11 File Offset: 0x01038E11
		public int GetDefaultDifficultIndex()
		{
			if (this.GetDefaultDifficultIndexFunc == null)
			{
				return 0;
			}
			return this.GetDefaultDifficultIndexFunc(this.DataIndex);
		}

		// Token: 0x0603F3BD RID: 259005 RVA: 0x0103AC2E File Offset: 0x01038E2E
		[NullableContext(1)]
		public string GetBgPath()
		{
			if (this.GetBgPathFunc == null)
			{
				return string.Empty;
			}
			return this.GetBgPathFunc(this.DataIndex);
		}

		// Token: 0x0603F3BE RID: 259006 RVA: 0x0103AC50 File Offset: 0x01038E50
		[return: Nullable(1)]
		public static ActivityEntranceSelectItemBaseData Create(int dataIndex, int uiLogicIndex, [Nullable(new byte[]
		{
			2,
			1
		})] ActivityEntranceSelectItemSubData[] subData, [Nullable(new byte[]
		{
			2,
			1
		})] Func<int, string> getNameFunc, [Nullable(new byte[]
		{
			2,
			1
		})] Func<int, string> getDescFunc, [Nullable(new byte[]
		{
			2,
			1
		})] Func<int, string> getSubTitleFunc, Func<int, bool> getLockStateFunc, Func<int, int> getInstanceDungeonIdFunc, [Nullable(new byte[]
		{
			2,
			1
		})] Func<int, string> getUnlockDescFunc, Func<int, bool> getFinishStateFunc, Func<int, int> getRecommendLevelFunc, Func<int, int> getDefaultDifficultIndex, [Nullable(new byte[]
		{
			2,
			1
		})] Func<int, string> getBgPathFunc, Action<int> clickCallBack, Func<int, bool> getRedDotStateFunc)
		{
			return new ActivityEntranceSelectItemBaseData
			{
				SelectState = false,
				DataIndex = dataIndex,
				UiLogicIndex = uiLogicIndex,
				GetNameFunc = getNameFunc,
				GetDescFunc = getDescFunc,
				GetSubTitleFunc = getSubTitleFunc,
				GetLockStateFunc = getLockStateFunc,
				GetInstanceDungeonIdFunc = getInstanceDungeonIdFunc,
				GetUnlockDescFunc = getUnlockDescFunc,
				GetFinishStateFunc = getFinishStateFunc,
				GetRedDotStateFunc = getRedDotStateFunc,
				GetDefaultDifficultIndexFunc = getDefaultDifficultIndex,
				GetRecommendLevelFunc = getRecommendLevelFunc,
				GetBgPathFunc = getBgPathFunc,
				ClickCallBack = clickCallBack,
				SubDataList = (subData ?? Array.Empty<ActivityEntranceSelectItemSubData>())
			};
		}

		// Token: 0x04023806 RID: 145414
		private bool SelectState;

		// Token: 0x04023807 RID: 145415
		private int DataIndex;

		// Token: 0x04023808 RID: 145416
		private int UiLogicIndex;

		// Token: 0x04023809 RID: 145417
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<int, string> GetNameFunc;

		// Token: 0x0402380A RID: 145418
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<int, string> GetDescFunc;

		// Token: 0x0402380B RID: 145419
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<int, string> GetSubTitleFunc;

		// Token: 0x0402380C RID: 145420
		private Func<int, bool> GetLockStateFunc;

		// Token: 0x0402380D RID: 145421
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<int, string> GetUnlockDescFunc;

		// Token: 0x0402380E RID: 145422
		private Func<int, int> GetInstanceDungeonIdFunc;

		// Token: 0x0402380F RID: 145423
		private Func<int, bool> GetFinishStateFunc;

		// Token: 0x04023810 RID: 145424
		private Func<int, int> GetRecommendLevelFunc;

		// Token: 0x04023811 RID: 145425
		private Func<int, bool> GetRedDotStateFunc;

		// Token: 0x04023812 RID: 145426
		private Func<int, int> GetDefaultDifficultIndexFunc;

		// Token: 0x04023813 RID: 145427
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<int, string> GetBgPathFunc;

		// Token: 0x04023814 RID: 145428
		private Action<int> ClickCallBack;

		// Token: 0x04023815 RID: 145429
		[Nullable(1)]
		private ActivityEntranceSelectItemSubData[] SubDataList = Array.Empty<ActivityEntranceSelectItemSubData>();
	}
}
