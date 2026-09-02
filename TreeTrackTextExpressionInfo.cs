using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.BattleUi.Views;

// Token: 0x02001DEB RID: 7659
[NullableContext(1)]
[Nullable(0)]
public class TreeTrackTextExpressionInfo
{
	// Token: 0x0600E223 RID: 57891 RVA: 0x003CE59B File Offset: 0x003CC79B
	public void Clear()
	{
		this.MainTitle = null;
		this.ClearSubTitle();
	}

	// Token: 0x0600E224 RID: 57892 RVA: 0x003CE5AC File Offset: 0x003CC7AC
	[NullableContext(2)]
	public void SetMainTitle(IQuestScheduleMainTitle mainTitle)
	{
		if (mainTitle == null)
		{
			this.MainTitle = null;
			return;
		}
		this.MainTitle = new BehaviorTreeStepTextInfo(mainTitle.TidTitle, mainTitle.QuestScheduleType, null, null, null, null, null);
	}

	// Token: 0x0600E225 RID: 57893 RVA: 0x003CE5E8 File Offset: 0x003CC7E8
	[NullableContext(2)]
	public void SetMainTitle(BehaviorTreeStepTextInfo mainTitle)
	{
		if (mainTitle == null)
		{
			this.MainTitle = null;
			return;
		}
		this.MainTitle = new BehaviorTreeStepTextInfo(mainTitle.TidTitle, mainTitle.QuestScheduleType, null, null, null, null, null);
	}

	// Token: 0x0600E226 RID: 57894 RVA: 0x003CE624 File Offset: 0x003CC824
	public void AddSubTitle(IQuestScheduleSubTitle subTitle)
	{
		this.SubTitles.Add(new BehaviorTreeStepTextInfo(subTitle.TidTitle, subTitle.QuestScheduleType, subTitle.ShowConditions, subTitle.ConditionText, subTitle.ProgressBar, subTitle.BlankTitleStillShow, subTitle.CustomPlaceholderBindingProgressList));
	}

	// Token: 0x0600E227 RID: 57895 RVA: 0x003CE660 File Offset: 0x003CC860
	public void AddSubTitle(BehaviorTreeStepTextInfo subTitle)
	{
		this.SubTitles.Add(new BehaviorTreeStepTextInfo(subTitle.TidTitle, subTitle.QuestScheduleType, subTitle.ShowConditions, subTitle.ConditionText, subTitle.ProgressBar, subTitle.BlankTitleStillShow, subTitle.CustomPlaceholderBindingProgressList));
	}

	// Token: 0x0600E228 RID: 57896 RVA: 0x003CE69C File Offset: 0x003CC89C
	public void ClearSubTitle()
	{
		this.SubTitles.Clear();
	}

	// Token: 0x0600E229 RID: 57897 RVA: 0x003CE6AC File Offset: 0x003CC8AC
	public void CopyConfig(IQuestScheduleConfig config)
	{
		this.SetMainTitle(config.MainTitle);
		this.ClearSubTitle();
		foreach (IQuestScheduleSubTitle subTitle in config.SubTitles)
		{
			this.AddSubTitle(subTitle);
		}
	}

	// Token: 0x0600E22A RID: 57898 RVA: 0x003CE714 File Offset: 0x003CC914
	public void CopyConfig(TreeTrackTextExpressionInfo config)
	{
		this.SetMainTitle(config.MainTitle);
		this.ClearSubTitle();
		foreach (BehaviorTreeStepTextInfo subTitle in config.SubTitles)
		{
			this.AddSubTitle(subTitle);
		}
	}

	// Token: 0x0600E22B RID: 57899 RVA: 0x003CE77C File Offset: 0x003CC97C
	public bool IsSubTitle(int nodeId)
	{
		if (this.SubTitles.Count == 0)
		{
			return false;
		}
		foreach (BehaviorTreeStepTextInfo behaviorTreeStepTextInfo in this.SubTitles)
		{
			IQuestScheduleChildQuestCompleted questScheduleChildQuestCompleted = behaviorTreeStepTextInfo.QuestScheduleType as IQuestScheduleChildQuestCompleted;
			if (questScheduleChildQuestCompleted != null && questScheduleChildQuestCompleted.ChildQuestId == nodeId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04006CBA RID: 27834
	[Nullable(2)]
	public BehaviorTreeStepTextInfo MainTitle;

	// Token: 0x04006CBB RID: 27835
	public List<BehaviorTreeStepTextInfo> SubTitles = new List<BehaviorTreeStepTextInfo>();
}
