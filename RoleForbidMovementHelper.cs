using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020031E2 RID: 12770
[NullableContext(1)]
[Nullable(0)]
public class RoleForbidMovementHelper
{
	// Token: 0x0601A793 RID: 108435 RVA: 0x007D1E28 File Offset: 0x007D0028
	public void RegisterMutuallyTags(List<int> mutuallyTags)
	{
		foreach (int key in mutuallyTags)
		{
			LimitTagHandler limitTagHandler;
			if (this.Handlers.TryGetValue(key, out limitTagHandler))
			{
				foreach (int num in mutuallyTags)
				{
					if (num != limitTagHandler.TagId)
					{
						limitTagHandler.MutuallyTags.Add(num);
					}
				}
			}
		}
	}

	// Token: 0x0601A794 RID: 108436 RVA: 0x007D1ED0 File Offset: 0x007D00D0
	public void Awake()
	{
		foreach (KeyValuePair<int, LimitTagHandler> keyValuePair in this.Handlers)
		{
			bool gameplayTagExist = this.TagComp.HasTag(keyValuePair.Key);
			this.TagCallback(keyValuePair.Key, gameplayTagExist);
		}
	}

	// Token: 0x0601A795 RID: 108437 RVA: 0x007D1F40 File Offset: 0x007D0140
	public void ActiveHandler(LimitTagHandler activeHandler, bool active)
	{
		activeHandler.Active = active;
		activeHandler.CallBack(active);
		if (active)
		{
			this.CurrentActiveHandlers.Add(activeHandler);
			return;
		}
		int num = this.CurrentActiveHandlers.IndexOf(activeHandler);
		if (num < 0)
		{
			return;
		}
		this.CurrentActiveHandlers.RemoveAt(num);
	}

	// Token: 0x0601A796 RID: 108438 RVA: 0x007D1F90 File Offset: 0x007D0190
	private void TagCallback(int addOrRemoveTagId, bool gameplayTagExist)
	{
		LimitTagHandler valueOrDefault = this.Handlers.GetValueOrDefault(addOrRemoveTagId);
		if (valueOrDefault == null)
		{
			return;
		}
		valueOrDefault.TagExist = gameplayTagExist;
		if (valueOrDefault != null && valueOrDefault.TagExist && valueOrDefault.Active)
		{
			return;
		}
		if (valueOrDefault != null && !valueOrDefault.TagExist && !valueOrDefault.Active)
		{
			return;
		}
		if (!gameplayTagExist)
		{
			this.ActiveHandler(valueOrDefault, false);
			LimitTagHandler limitTagHandler = null;
			foreach (int key in valueOrDefault.MutuallyTags)
			{
				LimitTagHandler valueOrDefault2 = this.Handlers.GetValueOrDefault(key);
				if (valueOrDefault2 != null && valueOrDefault2.Priority <= valueOrDefault.Priority && valueOrDefault2.TagExist)
				{
					limitTagHandler = valueOrDefault2;
					break;
				}
			}
			if (limitTagHandler != null)
			{
				this.ActiveHandler(limitTagHandler, true);
			}
			return;
		}
		LimitTagHandler limitTagHandler2 = null;
		LimitTagHandler limitTagHandler3 = null;
		foreach (int key2 in valueOrDefault.MutuallyTags)
		{
			LimitTagHandler valueOrDefault3 = this.Handlers.GetValueOrDefault(key2);
			if (valueOrDefault3 != null)
			{
				if (valueOrDefault3.Priority > valueOrDefault.Priority && valueOrDefault3.Active)
				{
					limitTagHandler2 = valueOrDefault3;
					break;
				}
				if (valueOrDefault3.Priority <= valueOrDefault.Priority && valueOrDefault3.Active)
				{
					limitTagHandler3 = valueOrDefault3;
					break;
				}
			}
		}
		if (limitTagHandler2 != null)
		{
			return;
		}
		if (limitTagHandler3 != null)
		{
			this.ActiveHandler(limitTagHandler3, false);
			this.ActiveHandler(valueOrDefault, true);
			return;
		}
		this.ActiveHandler(valueOrDefault, true);
	}

	// Token: 0x0601A797 RID: 108439 RVA: 0x007D211C File Offset: 0x007D031C
	public void CreateTagHandler(int tagId, int priority, Action<bool> callBack)
	{
		bool tagExist = this.TagComp.HasTag(tagId);
		this.Handlers[tagId] = new LimitTagHandler(tagId, priority, tagExist, callBack);
		this.TagListeners.Add(this.TagComp.ListenForTagAddOrRemove(new int?(tagId), new BaseTagComponent.TTagSwitchedCallback(this.TagCallback), null));
	}

	// Token: 0x0601A798 RID: 108440 RVA: 0x007D2174 File Offset: 0x007D0374
	public void Clear()
	{
		this.CurrentActiveHandlers.Clear();
		this.Handlers.Clear();
		foreach (ITagTask tagTask in this.TagListeners)
		{
			tagTask.EndTask();
		}
		this.TagListeners.Clear();
	}

	// Token: 0x0400D602 RID: 54786
	[Nullable(2)]
	public BaseTagComponent TagComp;

	// Token: 0x0400D603 RID: 54787
	private readonly List<ITagTask> TagListeners = new List<ITagTask>();

	// Token: 0x0400D604 RID: 54788
	public List<LimitTagHandler> CurrentActiveHandlers = new List<LimitTagHandler>();

	// Token: 0x0400D605 RID: 54789
	public Dictionary<int, LimitTagHandler> Handlers = new Dictionary<int, LimitTagHandler>();
}
