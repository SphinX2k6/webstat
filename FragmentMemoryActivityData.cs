using System;

// Token: 0x02001C7F RID: 7295
public class FragmentMemoryActivityData : ActivityBaseData
{
	// Token: 0x0600D527 RID: 54567 RVA: 0x0038E12A File Offset: 0x0038C32A
	public override bool GetExDataRedPointShowState()
	{
		return this.EntranceRedDot();
	}

	// Token: 0x0600D528 RID: 54568 RVA: 0x0038E134 File Offset: 0x0038C334
	protected override bool GetExDataFinishShowState()
	{
		int topicId = ConfigBase<FragmentMemoryConfig>.Instance.GetPhotoMemoryActivityById(base.Id).Value.TopicId;
		FragmentMemoryTopicData topicDataById = ModelBase<FragmentMemoryModel>.Instance.GetTopicDataById(topicId);
		return topicDataById != null && topicDataById.GetCollectRewardDoneState();
	}

	// Token: 0x0600D529 RID: 54569 RVA: 0x0038E17C File Offset: 0x0038C37C
	public bool EntranceRedDot()
	{
		return ModelBase<FragmentMemoryModel>.Instance.GetRedDotState();
	}

	// Token: 0x0600D52A RID: 54570 RVA: 0x0038E188 File Offset: 0x0038C388
	public int GetCurrentTopicId()
	{
		return ConfigBase<FragmentMemoryConfig>.Instance.GetPhotoMemoryActivityById(base.Id).Value.TopicId;
	}
}
