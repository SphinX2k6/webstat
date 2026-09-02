using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001EDA RID: 7898
[NullableContext(1)]
[Nullable(0)]
public abstract class HonamiStoryQuestDataBase : IStaticVariableResetter
{
	// Token: 0x0600EA01 RID: 59905 RVA: 0x003F6FEE File Offset: 0x003F51EE
	static HonamiStoryQuestDataBase()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(HonamiStoryQuestDataBase.CreateStaticDefaultValue), new Action(HonamiStoryQuestDataBase.ResetStaticDefaultValue));
	}

	// Token: 0x0600EA02 RID: 59906 RVA: 0x003F700D File Offset: 0x003F520D
	public static void CreateStaticDefaultValue()
	{
		HonamiStoryQuestDataBase.IdInternal = 0;
	}

	// Token: 0x0600EA03 RID: 59907 RVA: 0x003F7015 File Offset: 0x003F5215
	public static void ResetStaticDefaultValue()
	{
		HonamiStoryQuestDataBase.IdInternal = 0;
	}

	// Token: 0x0600EA04 RID: 59908 RVA: 0x003F701D File Offset: 0x003F521D
	public HonamiStoryQuestDataBase()
	{
		this.ActivityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		this.Id = HonamiStoryQuestDataBase.IdInternal++;
	}

	// Token: 0x17001208 RID: 4616
	// (get) Token: 0x0600EA05 RID: 59909 RVA: 0x003F7050 File Offset: 0x003F5250
	public bool IsInDungeon
	{
		get
		{
			return HonamiStoryUtil.CheckInHonamiStoryDungeon();
		}
	}

	// Token: 0x0600EA06 RID: 59910 RVA: 0x003F7057 File Offset: 0x003F5257
	public bool DoMapTrack(bool isTrack)
	{
		return this.CanMapTrack() && this.MapTrack(isTrack);
	}

	// Token: 0x0600EA07 RID: 59911
	public abstract string GetNameKey();

	// Token: 0x0600EA08 RID: 59912
	public abstract string GetDesc();

	// Token: 0x0600EA09 RID: 59913
	public abstract int GetRewardId();

	// Token: 0x0600EA0A RID: 59914
	public abstract bool IsFinished();

	// Token: 0x0600EA0B RID: 59915
	[NullableContext(2)]
	public abstract LevelPlayInfo GetLevelPlayInfo();

	// Token: 0x0600EA0C RID: 59916
	[NullableContext(2)]
	public abstract BehaviorTreeViewShowData GetTreeShowData();

	// Token: 0x0600EA0D RID: 59917
	public abstract bool CanMapTrack();

	// Token: 0x0600EA0E RID: 59918
	public abstract bool MapTrack(bool isTrack);

	// Token: 0x040070D1 RID: 28881
	public HonamiStoryActivityData ActivityData;

	// Token: 0x040070D2 RID: 28882
	public EHonamiStoryQuestType TaskType = EHonamiStoryQuestType.Main;

	// Token: 0x040070D3 RID: 28883
	private static int IdInternal;

	// Token: 0x040070D4 RID: 28884
	public int Id;
}
