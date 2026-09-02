using System;
using System.Runtime.CompilerServices;

// Token: 0x02003223 RID: 12835
public class TagChangedTask : ITagTask
{
	// Token: 0x0601AB1C RID: 109340 RVA: 0x007F268F File Offset: 0x007F088F
	[NullableContext(1)]
	public void StartTask(int tagId, BaseTagComponent.TTagChangedCallback callback, BaseTagComponent tagComponent, [Nullable(2)] Stat callbackStat = null)
	{
		this.TagId = tagId;
		this.Callback = callback;
		this.TagComponent = tagComponent;
		BaseTagComponent tagComponent2 = this.TagComponent;
		if (tagComponent2 == null)
		{
			return;
		}
		tagComponent2.AddTagChangedListener(this.TagId, this.Callback, callbackStat);
	}

	// Token: 0x0601AB1D RID: 109341 RVA: 0x007F26C4 File Offset: 0x007F08C4
	public void EndTask()
	{
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent == null)
		{
			return;
		}
		tagComponent.RemoveTagChangedListener(this.TagId, this.Callback);
	}

	// Token: 0x0400D868 RID: 55400
	private int TagId;

	// Token: 0x0400D869 RID: 55401
	[Nullable(2)]
	private BaseTagComponent.TTagChangedCallback Callback;

	// Token: 0x0400D86A RID: 55402
	[Nullable(2)]
	private BaseTagComponent TagComponent;
}
