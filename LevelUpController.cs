using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x020020C5 RID: 8389
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class LevelUpController : UiControllerBase<LevelUpController>
{
	// Token: 0x0601006D RID: 65645 RVA: 0x00466FCC File Offset: 0x004651CC
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
		Singleton<EventSystem>.Instance.Add<int, int, int>(EEventName.OnPlayerExpChanged, new Action<int, int, int>(this.OnPlayerExpChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.OnFinishLoadingState, new Action(this.OnShowLevelOnly));
	}

	// Token: 0x0601006E RID: 65646 RVA: 0x00467030 File Offset: 0x00465230
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerExpChanged, new Action<int, int, int>(this.OnPlayerExpChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFinishLoadingState, new Action(this.OnShowLevelOnly));
	}

	// Token: 0x0601006F RID: 65647 RVA: 0x00467094 File Offset: 0x00465294
	private void OnPlayerExpChanged(int currentExp, int lastExp, int maxExp)
	{
		int? playerLevel = ModelBase<FunctionModel>.Instance.GetPlayerLevel();
		int? hiddenLevelUpLevel = ConfigBase<LevelUpConfig>.Instance.GetHiddenLevelUpLevel();
		if (hiddenLevelUpLevel != null && playerLevel.GetValueOrDefault() < hiddenLevelUpLevel.Value)
		{
			return;
		}
		int differenceExp = ConfigBase<FunctionConfig>.Instance.GetDifferenceExp(playerLevel.Value, lastExp, playerLevel.Value, currentExp);
		ModelBase<LevelUpModel>.Instance.SetExpChange(playerLevel.Value, currentExp, lastExp, maxExp, differenceExp);
	}

	// Token: 0x06010070 RID: 65648 RVA: 0x00467104 File Offset: 0x00465304
	private void OnPlayerLevelChanged(int lastLevel, int currentLevel, int currentExp, int lastExp, int addExp, int currentMaxExp, int lastMaxExp)
	{
		Singleton<KuroSdkReport>.Instance.OnPlayerLevelChange(currentLevel);
		int? hiddenLevelUpLevel = ConfigBase<LevelUpConfig>.Instance.GetHiddenLevelUpLevel();
		if (hiddenLevelUpLevel != null && currentLevel < hiddenLevelUpLevel.Value)
		{
			return;
		}
		int differenceExp = ConfigBase<FunctionConfig>.Instance.GetDifferenceExp(lastLevel, lastExp, currentLevel, currentExp);
		ModelBase<LevelUpModel>.Instance.SetLevelUp(lastLevel, currentLevel, currentExp, lastExp, addExp, currentMaxExp, lastMaxExp, differenceExp);
	}

	// Token: 0x06010071 RID: 65649 RVA: 0x00467164 File Offset: 0x00465364
	private void OnShowLevelOnly()
	{
		int? playerLevel = ModelBase<FunctionModel>.Instance.GetPlayerLevel();
		int? hiddenLevelUpLevel = ConfigBase<LevelUpConfig>.Instance.GetHiddenLevelUpLevel();
		if (hiddenLevelUpLevel != null && playerLevel.GetValueOrDefault() < hiddenLevelUpLevel.Value)
		{
			return;
		}
		ModelBase<LevelUpModel>.Instance.SetShowLevelOnly(playerLevel.Value);
	}
}
