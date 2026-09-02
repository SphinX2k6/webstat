using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002B20 RID: 11040
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsLevelInfoItem : GridProxyAbstract<ISurvivorsLevelInfo>
{
	// Token: 0x060160BC RID: 90300 RVA: 0x0061E0AC File Offset: 0x0061C2AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
	}

	// Token: 0x060160BD RID: 90301 RVA: 0x0061E18A File Offset: 0x0061C38A
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		base.GetItem(7).SetUIActive(false);
	}

	// Token: 0x060160BE RID: 90302 RVA: 0x0061E1AC File Offset: 0x0061C3AC
	public override void Refresh(ISurvivorsLevelInfo data, bool isSelected, int gridIndex)
	{
		this.LevelInfo = data;
		SurvivorsLevel? survivorsLevel = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsLevel(data.LevelId);
		if (survivorsLevel == null)
		{
			return;
		}
		if (data.IsEndlessMode)
		{
			this.RefreshEndlessMode(survivorsLevel.Value);
		}
		else
		{
			this.RefreshNormalMode(survivorsLevel.Value);
		}
		string text;
		if (gridIndex >= 10)
		{
			text = gridIndex.ToString();
		}
		else
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("0");
			defaultInterpolatedStringHandler.AppendFormatted<int>(gridIndex);
			text = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		string newText = text;
		base.GetText(6).SetText(newText, true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), survivorsLevel.Value.Name, Array.Empty<object>());
		this.RefreshSpriteDiff(survivorsLevel.Value);
	}

	// Token: 0x060160BF RID: 90303 RVA: 0x0061E274 File Offset: 0x0061C474
	private void RefreshEndlessMode(SurvivorsLevel levelConfig)
	{
		ModeInfo info = this.LevelInfo.Info;
		this.IsTimeUnlock = ModelBase<SurvivorsRogueModel>.Instance.ActivityData.GetLevelTimeUnlockState(this.LevelInfo.LevelId);
		bool levelUnlockState = ModelBase<SurvivorsRogueModel>.Instance.ActivityData.GetLevelUnlockState(this.LevelInfo.LevelId, true);
		bool flag = info.KillMonsterCount > 0;
		UUISprite sprite = base.GetSprite(1);
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(4);
		item.SetUIActive(levelUnlockState && flag);
		item2.SetUIActive(false);
		if (levelUnlockState)
		{
			List<string> list = new List<string>();
			string textStringId = string.Empty;
			if (!flag)
			{
				textStringId = "SurvivorsLevelSelection_EndlessTips";
			}
			else
			{
				textStringId = "SurvivorsLevelSelection_KillNumberTips";
				list.Add(info.KillMonsterCount.ToString());
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), textStringId, list.ToArray());
		}
		else
		{
			this.RefreshLockState(true);
		}
		this.SetSpriteByPath(levelUnlockState ? "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_IconSurvivorLvItemBoss.SP_IconSurvivorLvItemBoss" : "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_IconSurvivorLvItemLock.SP_IconSurvivorLvItemLock", sprite, false, null, null);
	}

	// Token: 0x060160C0 RID: 90304 RVA: 0x0061E37C File Offset: 0x0061C57C
	private void RefreshNormalMode(SurvivorsLevel levelConfig)
	{
		ModeInfo info = this.LevelInfo.Info;
		this.IsTimeUnlock = ModelBase<SurvivorsRogueModel>.Instance.ActivityData.GetLevelTimeUnlockState(this.LevelInfo.LevelId);
		bool levelUnlockState = ModelBase<SurvivorsRogueModel>.Instance.ActivityData.GetLevelUnlockState(this.LevelInfo.LevelId, false);
		bool isFinish = info.IsFinish;
		UUISprite sprite = base.GetSprite(1);
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(4);
		item.SetUIActive(false);
		item2.SetUIActive(levelUnlockState && isFinish);
		if (levelUnlockState)
		{
			List<string> list = new List<string>();
			string textStringId = string.Empty;
			if (isFinish)
			{
				textStringId = "SurvivorsLevelSelection_CustomsClearanceTips";
			}
			else
			{
				int maxWaveNumByLevelId = ConfigBase<SurvivorsRogueConfig>.Instance.GetMaxWaveNumByLevelId(this.LevelInfo.LevelId);
				textStringId = "SurvivorsLevelSelection_ProgressTips";
				list.Add(info.WaveId.ToString());
				list.Add(maxWaveNumByLevelId.ToString());
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), textStringId, list.ToArray());
		}
		else
		{
			this.RefreshLockState(true);
		}
		this.SetSpriteByPath(levelUnlockState ? "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_IconSurvivorLvItemLv.SP_IconSurvivorLvItemLv" : "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_IconSurvivorLvItemLock.SP_IconSurvivorLvItemLock", sprite, false, null, null);
	}

	// Token: 0x060160C1 RID: 90305 RVA: 0x0061E4A4 File Offset: 0x0061C6A4
	private void RefreshSpriteDiff(SurvivorsLevel levelConfig)
	{
		string path = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_SurvivorLvItemBlur.SP_SurvivorLvItemBlur";
		switch (levelConfig.Diff)
		{
		case 0:
			path = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_SurvivorLvItemBlur.SP_SurvivorLvItemBlur";
			break;
		case 1:
			path = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_SurvivorLvItemPurple.SP_SurvivorLvItemPurple";
			break;
		case 2:
			path = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_SurvivorLvItemRed.SP_SurvivorLvItemRed";
			break;
		}
		this.SetSpriteByPath(path, base.GetSprite(0), false, null, null);
	}

	// Token: 0x060160C2 RID: 90306 RVA: 0x0061E504 File Offset: 0x0061C704
	private void RefreshLockState(bool isInit = true)
	{
		int levelId = this.LevelInfo.LevelId;
		string levelUnlockRemainTime = ModelBase<SurvivorsRogueModel>.Instance.ActivityData.GetLevelUnlockRemainTime(levelId);
		if (levelUnlockRemainTime != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "SurvivorsLevelSelection_UnlockTimeTips", new <>z__ReadOnlySingleElementList<object>(levelUnlockRemainTime));
			return;
		}
		if (isInit)
		{
			string textStringId = LevelGeneralCommons.GetConditionGroupHintText(this.LevelInfo.Info.ConditionGroupId) ?? string.Empty;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), textStringId, Array.Empty<object>());
		}
	}

	// Token: 0x060160C3 RID: 90307 RVA: 0x0061E588 File Offset: 0x0061C788
	public void SetSaveFile(SurvivorsActivityDefine.SurvivorsLevelInfo saveFile)
	{
		if (saveFile.LevelId == this.LevelInfo.LevelId)
		{
			base.GetItem(7).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "SurvivorsExitPopup_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				saveFile.Batch.ToString(),
				saveFile.MaxBatch.ToString()
			}));
			return;
		}
		base.GetItem(7).SetUIActive(false);
	}

	// Token: 0x060160C4 RID: 90308 RVA: 0x0061E600 File Offset: 0x0061C800
	public void OnTick(float deltaTime)
	{
		if (this.LevelInfo == null)
		{
			return;
		}
		if (this.IsTimeUnlock)
		{
			return;
		}
		this.RefreshLockState(false);
	}

	// Token: 0x060160C5 RID: 90309 RVA: 0x0061E61C File Offset: 0x0061C81C
	public void PlaySequenceByName(ESurvivorsLevelInfoSeqName seqName)
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName(seqName.ToString(), true, null, false);
	}

	// Token: 0x060160C6 RID: 90310 RVA: 0x0061E64C File Offset: 0x0061C84C
	public override object GetKey(ISurvivorsLevelInfo data, int displayIndex)
	{
		return data.LevelId;
	}

	// Token: 0x0400A989 RID: 43401
	private const string SPRITE_STATE_EASY = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_SurvivorLvItemBlur.SP_SurvivorLvItemBlur";

	// Token: 0x0400A98A RID: 43402
	private const string SPRITE_STATE_NORMAL = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_SurvivorLvItemPurple.SP_SurvivorLvItemPurple";

	// Token: 0x0400A98B RID: 43403
	private const string SPRITE_STATE_CHALLENGE = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_SurvivorLvItemRed.SP_SurvivorLvItemRed";

	// Token: 0x0400A98C RID: 43404
	private const string SPRITE_STATE_ICON_LOCK = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_IconSurvivorLvItemLock.SP_IconSurvivorLvItemLock";

	// Token: 0x0400A98D RID: 43405
	private const string SPRITE_STATE_ICON_NORMAL = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_IconSurvivorLvItemLv.SP_IconSurvivorLvItemLv";

	// Token: 0x0400A98E RID: 43406
	private const string SPRITE_STATE_ICON_ENDLESS = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Level1/SP_IconSurvivorLvItemBoss.SP_IconSurvivorLvItemBoss";

	// Token: 0x0400A98F RID: 43407
	private const string INFO_FINISHED = "SurvivorsLevelSelection_CustomsClearanceTips";

	// Token: 0x0400A990 RID: 43408
	private const string INFO_ENDLESS_OPEN = "SurvivorsLevelSelection_EndlessTips";

	// Token: 0x0400A991 RID: 43409
	private const string INFO_WAVE = "SurvivorsLevelSelection_ProgressTips";

	// Token: 0x0400A992 RID: 43410
	private const string INFO_LOCK_TIME = "SurvivorsLevelSelection_UnlockTimeTips";

	// Token: 0x0400A993 RID: 43411
	private const string INFO_KILL_COUNT = "SurvivorsLevelSelection_KillNumberTips";

	// Token: 0x0400A994 RID: 43412
	[Nullable(2)]
	protected ISurvivorsLevelInfo LevelInfo;

	// Token: 0x0400A995 RID: 43413
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400A996 RID: 43414
	private bool IsTimeUnlock;
}
