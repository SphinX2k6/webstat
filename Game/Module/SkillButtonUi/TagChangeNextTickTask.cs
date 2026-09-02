using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F98 RID: 20376
	[NullableContext(1)]
	[Nullable(0)]
	public class TagChangeNextTickTask
	{
		// Token: 0x060349BA RID: 215482 RVA: 0x00D32804 File Offset: 0x00D30A04
		public void TagChangeWaitNextTick(int gameplayTagId, bool bTagExist, Action<Dictionary<int, bool>> callback)
		{
			this.TagChangeMap[gameplayTagId] = bTagExist;
			this.CallbackList.Add(callback);
			if (this.TagChangeWaitTimerId != null)
			{
				return;
			}
			this.TagChangeWaitTimerId = TimerSystem.Instance.Next(new TTimerAction(this.OnTagChangeWait), null, null);
		}

		// Token: 0x060349BB RID: 215483 RVA: 0x00D32854 File Offset: 0x00D30A54
		public void Clear()
		{
			if (this.TagChangeWaitTimerId != null && TimerSystem.Instance.Has(this.TagChangeWaitTimerId))
			{
				TimerSystem.Instance.Remove(this.TagChangeWaitTimerId);
			}
			this.TagChangeWaitTimerId = null;
			this.CallbackList.Clear();
			this.TagChangeMap.Clear();
			this.CallbackList = null;
		}

		// Token: 0x060349BC RID: 215484 RVA: 0x00D328B0 File Offset: 0x00D30AB0
		private void OnTagChangeWait(float _)
		{
			this.TagChangeWaitTimerId = null;
			if (this.CallbackList.Count > 0)
			{
				foreach (Action<Dictionary<int, bool>> action in this.CallbackList)
				{
					action(this.TagChangeMap);
				}
			}
			this.CallbackList.Clear();
			this.TagChangeMap.Clear();
		}

		// Token: 0x0401E543 RID: 124227
		private readonly Dictionary<int, bool> TagChangeMap = new Dictionary<int, bool>();

		// Token: 0x0401E544 RID: 124228
		[Nullable(2)]
		private TimerHandle TagChangeWaitTimerId;

		// Token: 0x0401E545 RID: 124229
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private List<Action<Dictionary<int, bool>>> CallbackList = new List<Action<Dictionary<int, bool>>>();
	}
}
