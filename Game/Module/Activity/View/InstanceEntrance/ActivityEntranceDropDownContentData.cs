using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061E4 RID: 25060
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityEntranceDropDownContentData
	{
		// Token: 0x0603F3C6 RID: 259014 RVA: 0x0103AD42 File Offset: 0x01038F42
		public int GetDataIndex()
		{
			return this.DataIndex;
		}

		// Token: 0x0603F3C7 RID: 259015 RVA: 0x0103AD4A File Offset: 0x01038F4A
		public string GetTogOptionText()
		{
			if (this.GetTogOptionTextFunc == null)
			{
				return string.Empty;
			}
			return this.GetTogOptionTextFunc(this.DataIndex);
		}

		// Token: 0x0603F3C8 RID: 259016 RVA: 0x0103AD6B File Offset: 0x01038F6B
		public string GetDropDownText()
		{
			if (this.GetDropDownTextFunc == null)
			{
				return string.Empty;
			}
			return this.GetDropDownTextFunc(this.DataIndex);
		}

		// Token: 0x0603F3C9 RID: 259017 RVA: 0x0103AD8C File Offset: 0x01038F8C
		public int GetRecommendLevel()
		{
			if (this.GetRecommendLevelFunc == null)
			{
				return 0;
			}
			return this.GetRecommendLevelFunc(this.DataIndex);
		}

		// Token: 0x0603F3CA RID: 259018 RVA: 0x0103ADA9 File Offset: 0x01038FA9
		public Action<ActivityInstanceEntranceData, int> GetOnSelectCallBack()
		{
			return this.GetOnSelectCallBackFunc;
		}

		// Token: 0x0603F3CB RID: 259019 RVA: 0x0103ADB1 File Offset: 0x01038FB1
		public static ActivityEntranceDropDownContentData Create(int dataIndex, Func<int, string> getTogOptionTextFunc, Func<int, string> getDropDownTextFunc, Func<int, int> getRecommendLevelFunc, Action<ActivityInstanceEntranceData, int> getOnSelectCallBack)
		{
			return new ActivityEntranceDropDownContentData
			{
				DataIndex = dataIndex,
				GetTogOptionTextFunc = getTogOptionTextFunc,
				GetDropDownTextFunc = getDropDownTextFunc,
				GetRecommendLevelFunc = getRecommendLevelFunc,
				GetOnSelectCallBackFunc = getOnSelectCallBack
			};
		}

		// Token: 0x04023818 RID: 145432
		private int DataIndex;

		// Token: 0x04023819 RID: 145433
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<int, string> GetTogOptionTextFunc;

		// Token: 0x0402381A RID: 145434
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<int, string> GetDropDownTextFunc;

		// Token: 0x0402381B RID: 145435
		[Nullable(2)]
		private Func<int, int> GetRecommendLevelFunc;

		// Token: 0x0402381C RID: 145436
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<ActivityInstanceEntranceData, int> GetOnSelectCallBackFunc;
	}
}
