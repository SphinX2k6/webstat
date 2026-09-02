using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001EDB RID: 7899
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryMainQuestData : HonamiStoryQuestDataBase
{
	// Token: 0x0600EA0F RID: 59919 RVA: 0x003F706A File Offset: 0x003F526A
	public HonamiStoryMainQuestData()
	{
		this.TaskType = EHonamiStoryQuestType.Main;
		this.ActivityQuestId = this.ActivityData.ActivityQuestId;
	}

	// Token: 0x0600EA10 RID: 59920 RVA: 0x003F708C File Offset: 0x003F528C
	[NullableContext(2)]
	public override LevelPlayInfo GetLevelPlayInfo()
	{
		if (!base.IsInDungeon)
		{
			return null;
		}
		int curAreaId = ModelBase<HonamiStoryModel>.Instance.CurAreaId;
		HonamiStoryAreaData honamiStoryAreaData = this.ActivityData.GetHonamiStoryAreaData(curAreaId);
		if (honamiStoryAreaData == null)
		{
			return null;
		}
		return ModelBase<LevelPlayModel>.Instance.GetLevelPlayInfo(honamiStoryAreaData.LevelPlayId);
	}

	// Token: 0x0600EA11 RID: 59921 RVA: 0x003F70D0 File Offset: 0x003F52D0
	public override string GetNameKey()
	{
		if (base.IsInDungeon)
		{
			LevelPlayInfo levelPlayInfo = this.GetLevelPlayInfo();
			if (levelPlayInfo != null)
			{
				return levelPlayInfo.NameKey;
			}
		}
		Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.ActivityQuestId);
		if (quest == null)
		{
			return "";
		}
		return quest.NameKey;
	}

	// Token: 0x0600EA12 RID: 59922 RVA: 0x003F7118 File Offset: 0x003F5318
	public override string GetDesc()
	{
		if (base.IsInDungeon)
		{
			return "";
		}
		Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.ActivityQuestId);
		if (quest == null)
		{
			return "";
		}
		return quest.QuestDescribe;
	}

	// Token: 0x0600EA13 RID: 59923 RVA: 0x003F7154 File Offset: 0x003F5354
	public override int GetRewardId()
	{
		if (base.IsInDungeon)
		{
			LevelPlayInfo levelPlayInfo = this.GetLevelPlayInfo();
			if (levelPlayInfo != null)
			{
				return levelPlayInfo.RewardId;
			}
		}
		Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.ActivityQuestId);
		if (quest == null)
		{
			return 0;
		}
		return quest.RewardId.GetValueOrDefault();
	}

	// Token: 0x0600EA14 RID: 59924 RVA: 0x003F719E File Offset: 0x003F539E
	public override bool IsFinished()
	{
		return HonamiStoryUtil.CheckActivityQuestFinished();
	}

	// Token: 0x0600EA15 RID: 59925 RVA: 0x003F71A5 File Offset: 0x003F53A5
	public override bool CanMapTrack()
	{
		return false;
	}

	// Token: 0x0600EA16 RID: 59926 RVA: 0x003F71A8 File Offset: 0x003F53A8
	public override bool MapTrack(bool isTrack)
	{
		Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.LRC, "主线任务不能追踪", default(ReadOnlySpan<ValueTuple<string, object>>));
		return false;
	}

	// Token: 0x0600EA17 RID: 59927 RVA: 0x003F71D8 File Offset: 0x003F53D8
	[NullableContext(2)]
	public override BehaviorTreeViewShowData GetTreeShowData()
	{
		bool flag = HonamiStoryUtil.CheckInActivityQuest();
		if (!base.IsInDungeon && flag)
		{
			Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.ActivityQuestId);
			if (quest == null)
			{
				return null;
			}
			BaseBehaviorTree tree = quest.Tree;
			if (tree == null)
			{
				return null;
			}
			Blackboard blackBoard = tree.GetBlackBoard();
			if (blackBoard == null)
			{
				return null;
			}
			return blackBoard.CreateShowData(true);
		}
		else
		{
			LevelPlayInfo levelPlayInfo = this.GetLevelPlayInfo();
			if (levelPlayInfo == null)
			{
				return null;
			}
			BaseBehaviorTree tree2 = levelPlayInfo.Tree;
			if (tree2 == null)
			{
				return null;
			}
			Blackboard blackBoard2 = tree2.GetBlackBoard();
			if (blackBoard2 == null)
			{
				return null;
			}
			return blackBoard2.CreateShowData(true);
		}
	}

	// Token: 0x040070D5 RID: 28885
	private readonly int ActivityQuestId;
}
