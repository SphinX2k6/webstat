using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001103 RID: 4355
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class GuessJokerConfig : ConfigBase<GuessJokerConfig>
{
	// Token: 0x06007157 RID: 29015 RVA: 0x001D9FAC File Offset: 0x001D81AC
	public GuessJokerLevel? GetJokerLevelById(int levelId)
	{
		GuessJokerLevel? config = ConfigGuessJokerLevelById.GetConfig(levelId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GuessJokerLevel表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", levelId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06007158 RID: 29016 RVA: 0x001DA004 File Offset: 0x001D8204
	public IReadOnlyList<GuessJokerLevel> GetJokerLevelList()
	{
		IReadOnlyList<GuessJokerLevel> configList = ConfigGuessJokerLevelAll.GetConfigList(true);
		if (configList == null)
		{
			return new List<GuessJokerLevel>();
		}
		return configList;
	}

	// Token: 0x06007159 RID: 29017 RVA: 0x001DA024 File Offset: 0x001D8224
	public List<IGuessJokerNpcAndChairInfo> GetNpcAndChairMatchInfo()
	{
		if (this.NpcAndChairMatchInfo.Count > 0)
		{
			return this.NpcAndChairMatchInfo;
		}
		List<IGuessJokerNpcAndChairInfo> list = new List<IGuessJokerNpcAndChairInfo>();
		IReadOnlyList<GuessJokerAiConfig> configList = ConfigGuessJokerAiConfigAll.GetConfigList(true);
		if (configList == null)
		{
			return new List<IGuessJokerNpcAndChairInfo>();
		}
		foreach (GuessJokerAiConfig guessJokerAiConfig in configList)
		{
			list.Add(new GuessJokerNpcAndChairInfo
			{
				NpcId = guessJokerAiConfig.NpcId,
				ChairId = guessJokerAiConfig.ChairId
			});
		}
		this.NpcAndChairMatchInfo = list;
		return this.NpcAndChairMatchInfo;
	}

	// Token: 0x0600715A RID: 29018 RVA: 0x001DA0C4 File Offset: 0x001D82C4
	public JokerDeck? GetJokerDeck(int cardId)
	{
		JokerDeck? config = ConfigJokerDeckById.GetConfig(cardId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "JokerDeck表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", cardId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600715B RID: 29019 RVA: 0x001DA11C File Offset: 0x001D831C
	public GuessJokerLevel? GetJokerLevelByNpcId(int npcId)
	{
		IReadOnlyList<GuessJokerLevel> configList = ConfigGuessJokerLevelAll.GetConfigList(true);
		if (configList == null)
		{
			return null;
		}
		foreach (GuessJokerLevel value in configList)
		{
			int aiRole = value.AiRole;
			GuessJokerAiConfig? jokerAiConfigByRoleId = this.GetJokerAiConfigByRoleId(aiRole);
			if (jokerAiConfigByRoleId != null && jokerAiConfigByRoleId.GetValueOrDefault().NpcId == npcId)
			{
				return new GuessJokerLevel?(value);
			}
		}
		return null;
	}

	// Token: 0x0600715C RID: 29020 RVA: 0x001DA1BC File Offset: 0x001D83BC
	public JokerSkill? GetJokerSkill(int skillId)
	{
		JokerSkill? config = ConfigJokerSkillById.GetConfig(skillId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "JokerSkill表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", skillId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600715D RID: 29021 RVA: 0x001DA214 File Offset: 0x001D8414
	public GuessJokerAiConfig? GetJokerAiConfigByRoleId(int roleId)
	{
		GuessJokerAiConfig? config = ConfigGuessJokerAiConfigById.GetConfig(roleId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GuessJokerAiConfig表无效roleId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600715E RID: 29022 RVA: 0x001DA26C File Offset: 0x001D846C
	public GuessJokerAiConfig? GetJokerAiConfigByEntityId(int entityId)
	{
		GuessJokerAiConfig? config = ConfigGuessJokerAiConfigByNpcId.GetConfig(entityId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GuessJokerAiConfig表无效entityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600715F RID: 29023 RVA: 0x001DA2C4 File Offset: 0x001D84C4
	public GuessJokerAIPlotConfig? GetJokerAiPlotConfig(EGuessJokerPlayerType playerType, EGuessJokerPlotTiming timing, int extraParam = 0)
	{
		int num = (playerType == EGuessJokerPlayerType.Ai) ? ModelBase<GuessJokerGamePlayModel>.Instance.GetRoleId() : 0;
		IReadOnlyList<GuessJokerAIPlotConfig> configList = ConfigGuessJokerAIPlotConfigAll.GetConfigList(true);
		if (configList == null)
		{
			return null;
		}
		foreach (GuessJokerAIPlotConfig value in configList)
		{
			if (value.RoleId == num && value.State == (int)timing && value.ExtraParam == extraParam)
			{
				return new GuessJokerAIPlotConfig?(value);
			}
		}
		return null;
	}

	// Token: 0x06007160 RID: 29024 RVA: 0x001DA360 File Offset: 0x001D8560
	public GuessJokerPlotConfig? GetJokerPlotConfig(int plotId)
	{
		GuessJokerPlotConfig? config = ConfigGuessJokerPlotConfigById.GetConfig(plotId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GuessJokerPlotConfig表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", plotId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06007161 RID: 29025 RVA: 0x001DA3B8 File Offset: 0x001D85B8
	public GuessJokerParam? GetJokerParam(string key)
	{
		GuessJokerParam? config = ConfigGuessJokerParamByKey.GetConfig(key, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GuessJokerParam表无效key";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x04003676 RID: 13942
	private List<IGuessJokerNpcAndChairInfo> NpcAndChairMatchInfo = new List<IGuessJokerNpcAndChairInfo>();
}
