using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061E5 RID: 25061
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityEntranceMonsterPreviewData
	{
		// Token: 0x0603F3CD RID: 259021 RVA: 0x0103ADE4 File Offset: 0x01038FE4
		public string GetMonsterTips(int dataIndex)
		{
			if (this.GetMonsterTipsFunc == null)
			{
				return string.Empty;
			}
			return this.GetMonsterTipsFunc(dataIndex);
		}

		// Token: 0x0603F3CE RID: 259022 RVA: 0x0103AE00 File Offset: 0x01039000
		public bool GetMonsterPreviewState(int dataIndex)
		{
			return this.GetMonsterPreviewStateFunc != null && this.GetMonsterPreviewStateFunc(dataIndex);
		}

		// Token: 0x0603F3CF RID: 259023 RVA: 0x0103AE18 File Offset: 0x01039018
		public int GetInstanceDungeonId(int dataIndex)
		{
			if (this.GetInstanceDungeonIdFunc == null)
			{
				return 0;
			}
			return this.GetInstanceDungeonIdFunc(dataIndex);
		}

		// Token: 0x0603F3D0 RID: 259024 RVA: 0x0103AE30 File Offset: 0x01039030
		public Action<int> GetPreviewCallBack()
		{
			return this.GetClickPreviewCallBack;
		}

		// Token: 0x0603F3D1 RID: 259025 RVA: 0x0103AE38 File Offset: 0x01039038
		public static ActivityEntranceMonsterPreviewData Create(Func<int, string> getMonsterTipsFunc, Func<int, bool> getMonsterPreviewStateFunc, Func<int, int> getInstanceDungeonIdFunc, Action<int> getPreviewCallBack)
		{
			return new ActivityEntranceMonsterPreviewData
			{
				GetMonsterTipsFunc = getMonsterTipsFunc,
				GetMonsterPreviewStateFunc = getMonsterPreviewStateFunc,
				GetInstanceDungeonIdFunc = getInstanceDungeonIdFunc,
				GetClickPreviewCallBack = getPreviewCallBack
			};
		}

		// Token: 0x0402381D RID: 145437
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<int, string> GetMonsterTipsFunc;

		// Token: 0x0402381E RID: 145438
		[Nullable(2)]
		private Func<int, bool> GetMonsterPreviewStateFunc;

		// Token: 0x0402381F RID: 145439
		[Nullable(2)]
		private Func<int, int> GetInstanceDungeonIdFunc;

		// Token: 0x04023820 RID: 145440
		[Nullable(2)]
		private Action<int> GetClickPreviewCallBack;
	}
}
