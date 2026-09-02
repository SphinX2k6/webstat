using System;
using System.Runtime.CompilerServices;

// Token: 0x02003222 RID: 12834
public class TagSwitchedTask : ITagTask
{
	// Token: 0x0601AB19 RID: 109337 RVA: 0x007F2639 File Offset: 0x007F0839
	[NullableContext(1)]
	public void StartTask(int tagId, BaseTagComponent.TTagSwitchedCallback callback, BaseTagComponent tagComponent, [Nullable(2)] Stat callbackStat = null)
	{
		this.TagId = tagId;
		this.Callback = callback;
		this.TagComponent = tagComponent;
		BaseTagComponent tagComponent2 = this.TagComponent;
		if (tagComponent2 == null)
		{
			return;
		}
		tagComponent2.AddTagAddOrRemoveListener(this.TagId, callback, callbackStat);
	}

	// Token: 0x0601AB1A RID: 109338 RVA: 0x007F2669 File Offset: 0x007F0869
	public void EndTask()
	{
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent == null)
		{
			return;
		}
		tagComponent.RemoveTagAddOrRemoveListener(this.TagId, this.Callback);
	}

	// Token: 0x0400D865 RID: 55397
	private int TagId;

	// Token: 0x0400D866 RID: 55398
	[Nullable(2)]
	private BaseTagComponent.TTagSwitchedCallback Callback;

	// Token: 0x0400D867 RID: 55399
	[Nullable(2)]
	private BaseTagComponent TagComponent;
}
