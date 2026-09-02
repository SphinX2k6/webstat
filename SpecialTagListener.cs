using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003069 RID: 12393
[NullableContext(1)]
[Nullable(0)]
public class SpecialTagListener
{
	// Token: 0x06019783 RID: 104323 RVA: 0x0075D4A0 File Offset: 0x0075B6A0
	public void InitTagListener(BaseTagComponent tagComp, int tag, List<int> forbid, List<int> target, [Nullable(2)] Func<double, bool> check = null)
	{
		this.TagComp = tagComp;
		this.ListenerTag = tag;
		this.TargetTagList = target;
		this.ForbidTagList = forbid;
		this.CheckCondition = check;
		if (this.TagComp == null)
		{
			return;
		}
		this.TagComp.AddTagAddOrRemoveListener(this.ListenerTag, new BaseTagComponent.TTagSwitchedCallback(this.TagListenerStateChange), null);
		foreach (int tagId in this.ForbidTagList)
		{
			this.TagComp.AddTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.ForbidTagListenerStateChange), null);
		}
	}

	// Token: 0x06019784 RID: 104324 RVA: 0x0075D554 File Offset: 0x0075B754
	public void ClearTagListener()
	{
		if (this.TagComp == null)
		{
			return;
		}
		this.TagComp.RemoveTagAddOrRemoveListener(this.ListenerTag, new BaseTagComponent.TTagSwitchedCallback(this.TagListenerStateChange));
		foreach (int tagId in this.ForbidTagList)
		{
			this.TagComp.RemoveTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.ForbidTagListenerStateChange));
		}
	}

	// Token: 0x06019785 RID: 104325 RVA: 0x0075D5E0 File Offset: 0x0075B7E0
	private void TagListenerStateChange(int tagId, bool tagExist)
	{
		this.HasListenerTag = tagExist;
		this.RefreshCondition(0.0);
		this.UpdateTargetTagList();
	}

	// Token: 0x06019786 RID: 104326 RVA: 0x0075D600 File Offset: 0x0075B800
	private void ForbidTagListenerStateChange(int tagId, bool tagExist)
	{
		if (tagExist)
		{
			if (!this.ForbidTagSet.Contains(tagId))
			{
				this.ForbidTagSet.Add(tagId);
			}
		}
		else if (this.ForbidTagSet.Contains(tagId))
		{
			this.ForbidTagSet.Remove(tagId);
		}
		this.RefreshCondition(0.0);
		this.UpdateTargetTagList();
	}

	// Token: 0x06019787 RID: 104327 RVA: 0x0075D660 File Offset: 0x0075B860
	private void UpdateTargetTagList()
	{
		if (this.TagComp == null)
		{
			return;
		}
		bool flag = this.ForbidTagSet.Count > 0 || !this.HasListenerTag || !this.Condition;
		foreach (int num in this.TargetTagList)
		{
			if (!flag && !this.TagComp.HasTag(num))
			{
				this.TagComp.AddTag(new int?(num));
			}
			if (flag && this.TagComp.HasTag(num))
			{
				this.TagComp.RemoveTag(new int?(num));
			}
		}
	}

	// Token: 0x06019788 RID: 104328 RVA: 0x0075D720 File Offset: 0x0075B920
	private bool RefreshCondition(double delta)
	{
		if (this.CheckCondition == null)
		{
			return false;
		}
		bool flag = this.CheckCondition(delta);
		if (this.Condition != flag)
		{
			this.Condition = flag;
			return true;
		}
		return false;
	}

	// Token: 0x06019789 RID: 104329 RVA: 0x0075D757 File Offset: 0x0075B957
	public void UpdateCondition(double delta)
	{
		if (this.RefreshCondition(delta))
		{
			this.UpdateTargetTagList();
		}
	}

	// Token: 0x0400C9DC RID: 51676
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400C9DD RID: 51677
	private int ListenerTag;

	// Token: 0x0400C9DE RID: 51678
	private bool Condition = true;

	// Token: 0x0400C9DF RID: 51679
	private bool HasListenerTag;

	// Token: 0x0400C9E0 RID: 51680
	private List<int> ForbidTagList = new List<int>();

	// Token: 0x0400C9E1 RID: 51681
	private List<int> TargetTagList = new List<int>();

	// Token: 0x0400C9E2 RID: 51682
	private HashSet<int> ForbidTagSet = new HashSet<int>();

	// Token: 0x0400C9E3 RID: 51683
	[Nullable(2)]
	private Func<double, bool> CheckCondition;
}
