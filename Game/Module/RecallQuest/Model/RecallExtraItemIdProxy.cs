using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RecallQuest.Model
{
	// Token: 0x02005294 RID: 21140
	public class RecallExtraItemIdProxy : IExtraItemIdProxy
	{
		// Token: 0x060360C9 RID: 221385 RVA: 0x00D9B7A9 File Offset: 0x00D999A9
		public RecallExtraItemIdProxy(int initialItemId)
		{
			this.CurrentItemId = initialItemId;
		}

		// Token: 0x060360CA RID: 221386 RVA: 0x00D9B7B8 File Offset: 0x00D999B8
		public int GetExtraItemId()
		{
			return this.CurrentItemId;
		}

		// Token: 0x060360CB RID: 221387 RVA: 0x00D9B7C0 File Offset: 0x00D999C0
		[NullableContext(2)]
		public void SetExtraItemId(int itemId, Action<bool> callback = null)
		{
			bool flag = this.CurrentItemId != itemId;
			this.CurrentItemId = itemId;
			if (flag)
			{
				ControllerBase<RecallQuestController>.Instance.SendRecallExploreSkillRouletteSet(itemId, callback);
			}
		}

		// Token: 0x060360CC RID: 221388 RVA: 0x00D9B7E3 File Offset: 0x00D999E3
		public void ApplyServerSnapshot(int itemId)
		{
			this.CurrentItemId = itemId;
		}

		// Token: 0x0401F103 RID: 127235
		private int CurrentItemId;
	}
}
