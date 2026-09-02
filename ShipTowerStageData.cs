using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020029A2 RID: 10658
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerStageData
{
	// Token: 0x0601539D RID: 86941 RVA: 0x005E1500 File Offset: 0x005DF700
	public ShipTowerStageData()
	{
		this.OrderIndex = 1;
		this.StageType = EShipTowerStageType.OneTimeStage;
		this.InstIds = new List<int>();
		this.PreLevel = new List<int>();
		this.TitleKey = "";
		this.DescKey = "";
		this.TargetScoreList = new List<int>();
		this.ScoreStageList = new List<string>();
		this.PassRewardItems = new List<TItem>();
		this.TeamDataList = new List<ShipTowerTeamData>();
		this.TeamRecommendList = new List<ShipTowerTeamRecommendItemData>();
	}

	// Token: 0x0601539E RID: 86942 RVA: 0x005E1584 File Offset: 0x005DF784
	public void Init(SlashAndTowerCfg cfg)
	{
		this.Id = cfg.Id;
		this.Season = cfg.Season;
		this.IsEndLess = cfg.EndLess;
		this.InstIds = new List<int>(cfg.InstIds());
		this.PreLevel = new List<int>(cfg.PreLevel());
		this.PassScore = cfg.PassScore;
		this.PassReward = cfg.LevelPassReward;
		this.TitleKey = cfg.Title;
		this.DescKey = cfg.Desc;
		this.TargetScoreList = new List<int>(cfg.TargetScore());
		this.ScoreStageList = new List<string>(cfg.ScoreStage());
		this.BelongToSeason = cfg.Season;
		this.AfterInit();
	}

	// Token: 0x0601539F RID: 86943 RVA: 0x005E1648 File Offset: 0x005DF848
	private void AfterInit()
	{
		if (this.IsEndLess)
		{
			this.StageType = EShipTowerStageType.EndlessStage;
		}
		else if (this.Season == 0)
		{
			this.StageType = EShipTowerStageType.OneTimeStage;
		}
		else
		{
			this.StageType = EShipTowerStageType.RefreshStage;
		}
		for (int i = 0; i < this.InstIds.Count; i++)
		{
			int instId = this.InstIds[i];
			ShipTowerTeamData shipTowerTeamData = new ShipTowerTeamData();
			shipTowerTeamData.Init(instId, i, this.Id);
			this.TeamDataList.Add(shipTowerTeamData);
		}
	}

	// Token: 0x060153A0 RID: 86944 RVA: 0x005E16C4 File Offset: 0x005DF8C4
	public bool IsUnLocked()
	{
		if (this.IsHaveProtoData)
		{
			return this.ProtoIsUnLocked;
		}
		if (this.PreLevel.Count == 0)
		{
			return true;
		}
		foreach (int id in this.PreLevel)
		{
			if (!ModelBase<ShipTowerModel>.Instance.GetStageDataById(id).IsPassed())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060153A1 RID: 86945 RVA: 0x005E1748 File Offset: 0x005DF948
	public bool IsPassed()
	{
		if (this.IsHaveProtoData)
		{
			return this.ProtoIsPassed;
		}
		return this.CurrentIsPassed();
	}

	// Token: 0x060153A2 RID: 86946 RVA: 0x005E175F File Offset: 0x005DF95F
	public bool CurrentIsPassed()
	{
		return this.CurrentScore >= this.PassScore;
	}

	// Token: 0x060153A3 RID: 86947 RVA: 0x005E1772 File Offset: 0x005DF972
	public bool CanReset()
	{
		return this.IsTeamSetRoleFinish();
	}

	// Token: 0x060153A4 RID: 86948 RVA: 0x005E177C File Offset: 0x005DF97C
	public bool IsNewRecord(int? currentScore = null)
	{
		return (currentScore ?? this.CurrentScore) > this.LastScore;
	}

	// Token: 0x060153A5 RID: 86949 RVA: 0x005E17AB File Offset: 0x005DF9AB
	public bool IsNotChallenge()
	{
		return !this.IsTeamSetBuffFinish() || !this.IsTeamSetRoleFinish();
	}

	// Token: 0x060153A6 RID: 86950 RVA: 0x005E17C0 File Offset: 0x005DF9C0
	public void SetOrderIndex(int index)
	{
		this.OrderIndex = index;
	}

	// Token: 0x060153A7 RID: 86951 RVA: 0x005E17C9 File Offset: 0x005DF9C9
	public bool IsCurrent()
	{
		return this.IsUnLocked() && !this.IsPassed();
	}

	// Token: 0x060153A8 RID: 86952 RVA: 0x005E17E0 File Offset: 0x005DF9E0
	public void OpenViewStageDesc()
	{
		if (!this.IsUnLocked())
		{
			string text = "GhostShipLevelNotUnlock_Text";
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text, text);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(multiTextByKey);
			return;
		}
		ModelBase<ShipTowerModel>.Instance.OpenViewDesc(new ShipTowerDescViewParams
		{
			StageId = this.Id
		}, null);
	}

	// Token: 0x060153A9 RID: 86953 RVA: 0x005E1830 File Offset: 0x005DFA30
	public void OpenViewPassBuffShow()
	{
		ModelBase<ShipTowerModel>.Instance.OpenViewPassBuffShow(new ShipTowerPassBuffShowViewParams
		{
			StageData = this
		});
	}

	// Token: 0x060153AA RID: 86954 RVA: 0x005E1848 File Offset: 0x005DFA48
	public void OpenViewTeamRecommend()
	{
		ModelBase<ShipTowerModel>.Instance.OpenViewTeamRecommend(new ShipTowerTeamRecommendViewParams
		{
			StageData = this
		});
	}

	// Token: 0x060153AB RID: 86955 RVA: 0x005E1860 File Offset: 0x005DFA60
	public void OpenViewMonsterDesc(int? instId = null)
	{
		ModelBase<ShipTowerModel>.Instance.OpenViewMonsterDesc(new ShipTowerMonsterDescViewParams
		{
			StageData = this,
			InstId = instId
		});
	}

	// Token: 0x060153AC RID: 86956 RVA: 0x005E1880 File Offset: 0x005DFA80
	public List<ShipTowerScoreInfoData> GetTargetScoreInfoList()
	{
		List<ShipTowerScoreInfoData> list = new List<ShipTowerScoreInfoData>();
		ShipTowerScoreInfoData passTargetScoreInfo = this.GetPassTargetScoreInfo();
		if (passTargetScoreInfo != null)
		{
			list.Add(passTargetScoreInfo);
		}
		ShipTowerScoreInfoData challengeTargetScoreInfo = this.GetChallengeTargetScoreInfo();
		list.Add(challengeTargetScoreInfo);
		return list;
	}

	// Token: 0x060153AD RID: 86957 RVA: 0x005E18B4 File Offset: 0x005DFAB4
	[NullableContext(2)]
	private ShipTowerScoreInfoData GetPassTargetScoreInfo()
	{
		if (this.IsEndLess)
		{
			return null;
		}
		string text = "GhostShipLevelPass_Text";
		string text2 = "GhostShipLevelPoints_Text";
		return new ShipTowerScoreInfoData
		{
			Title = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text, text),
			TargetList = new List<ShipTowerScoreTargetData>
			{
				new ShipTowerScoreTargetData
				{
					Title = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text2, text2),
					ScoreTarget = this.PassScore,
					IsFinish = this.CurrentIsPassed()
				}
			}
		};
	}

	// Token: 0x060153AE RID: 86958 RVA: 0x005E1930 File Offset: 0x005DFB30
	private ShipTowerScoreInfoData GetChallengeTargetScoreInfo()
	{
		string text = "GhostShipLevelPoints_Text";
		string text2 = "GhostShipLevelChallenge_Text";
		List<ShipTowerScoreTargetData> list = new List<ShipTowerScoreTargetData>();
		ShipTowerScoreInfoData result = new ShipTowerScoreInfoData
		{
			Title = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text2, text2),
			TargetList = list
		};
		for (int i = 0; i < this.TargetScoreList.Count; i++)
		{
			int num = this.TargetScoreList[i];
			string stageGradeResId = ModelBase<ShipTowerModel>.Instance.GetStageGradeResId(this.ScoreStageList[i]);
			list.Add(new ShipTowerScoreTargetData
			{
				Title = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text, text),
				ScoreTarget = num,
				IsFinish = (this.CurrentScore >= num),
				ScoreGradeRes = stageGradeResId
			});
		}
		return result;
	}

	// Token: 0x060153AF RID: 86959 RVA: 0x005E19F1 File Offset: 0x005DFBF1
	[NullableContext(2)]
	public string GetStageGradeResIdByScore(int score)
	{
		return ModelBase<ShipTowerModel>.Instance.GetStageGradeResIdByScore(score, this.TargetScoreList.ToArray(), this.ScoreStageList.ToArray());
	}

	// Token: 0x060153B0 RID: 86960 RVA: 0x005E1A14 File Offset: 0x005DFC14
	[NullableContext(2)]
	public string GetShareStageGradeResIdByScore(int score)
	{
		return ModelBase<ShipTowerModel>.Instance.GetShareStageGradeResIdByScore(score, this.TargetScoreList.ToArray(), this.ScoreStageList.ToArray());
	}

	// Token: 0x060153B1 RID: 86961 RVA: 0x005E1A38 File Offset: 0x005DFC38
	public List<TItem> GetPassUnlockBuffList()
	{
		if (this.PassReward > 0 && this.PassRewardItems.Count == 0)
		{
			DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(this.PassReward);
			if (dropPackage != null)
			{
				foreach (DicIntInt dicIntInt in dropPackage.Value.DropPreviewIter())
				{
					int key = dicIntInt.Key;
					this.PassRewardItems.Add(new TItem(new InventoryDefine.GetItemData(key, 0), 0));
				}
			}
		}
		return this.PassRewardItems;
	}

	// Token: 0x060153B2 RID: 86962 RVA: 0x005E1AE0 File Offset: 0x005DFCE0
	public void UpdateCurSelectTeamIndex(int index)
	{
		if (this.CurSelectTeamIndex == index)
		{
			return;
		}
		this.CurSelectTeamIndex = index;
	}

	// Token: 0x060153B3 RID: 86963 RVA: 0x005E1AF4 File Offset: 0x005DFCF4
	public void UpdateOtherTeamRoleToModel(int index)
	{
		ModelBase<ShipTowerModel>.Instance.ClearOtherTeamRoleData();
		foreach (ShipTowerTeamData shipTowerTeamData in this.TeamDataList)
		{
			if (shipTowerTeamData.Index != index)
			{
				shipTowerTeamData.UpdateOtherTeamRoleToShipTowerModel();
				shipTowerTeamData.UpdateRoleIndexInAllTeam();
			}
		}
	}

	// Token: 0x060153B4 RID: 86964 RVA: 0x005E1B60 File Offset: 0x005DFD60
	public void UpdateAllTeamRoleToModel()
	{
		ModelBase<ShipTowerModel>.Instance.ClearAllTeamRoleData();
		foreach (ShipTowerTeamData shipTowerTeamData in this.TeamDataList)
		{
			shipTowerTeamData.UpdateAllTeamRoleToShipTowerModel();
		}
	}

	// Token: 0x060153B5 RID: 86965 RVA: 0x005E1BBC File Offset: 0x005DFDBC
	public bool UpdateOtherTeamRoleRepeat(int index, int? roleId = null)
	{
		ShipTowerTeamData indexTeamData = this.TeamDataList[index];
		bool flag = false;
		foreach (ShipTowerTeamData shipTowerTeamData in this.TeamDataList)
		{
			if (shipTowerTeamData.Index != index)
			{
				flag = (shipTowerTeamData.UpdateOtherTeamRoleRepeat(indexTeamData) || flag);
				shipTowerTeamData.RemoveRoleIdEdit(roleId);
			}
		}
		this.UpdateOtherTeamRoleToModel(index);
		return flag;
	}

	// Token: 0x060153B6 RID: 86966 RVA: 0x005E1C3C File Offset: 0x005DFE3C
	public void ExchangeTeamData()
	{
		bool flag = true;
		using (List<ShipTowerTeamData>.Enumerator enumerator = this.TeamDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.TeamIsEmpty())
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			return;
		}
		ShipTowerTeamData curSelectTeamData = this.GetCurSelectTeamData();
		ShipTowerTeamData shipTowerTeamData = null;
		foreach (ShipTowerTeamData shipTowerTeamData2 in this.TeamDataList)
		{
			if (shipTowerTeamData2 != curSelectTeamData)
			{
				shipTowerTeamData = shipTowerTeamData2;
				break;
			}
		}
		if (curSelectTeamData != null && shipTowerTeamData != null)
		{
			curSelectTeamData.ExChangeTeamData(shipTowerTeamData);
			this.UpdateOtherTeamRoleToModel(curSelectTeamData.Index);
			this.UpdateAllTeamRoleToModel();
		}
	}

	// Token: 0x060153B7 RID: 86967 RVA: 0x005E1D08 File Offset: 0x005DFF08
	public bool StartChallenge()
	{
		if (!this.IsTeamSetRoleFinishEdit())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("GhostShipConditionTeamError_Text", Array.Empty<object>());
			return false;
		}
		if (!this.IsTeamSetBuffFinishEdit())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("GhostShipConditionBuffError_Text2", Array.Empty<object>());
			return false;
		}
		ModelBase<ShipTowerModel>.Instance.StartChallenge(this);
		return true;
	}

	// Token: 0x060153B8 RID: 86968 RVA: 0x005E1D60 File Offset: 0x005DFF60
	public bool IsTeamSetRoleFinish()
	{
		using (List<ShipTowerTeamData>.Enumerator enumerator = this.TeamDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.IsSetRoleFinish())
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060153B9 RID: 86969 RVA: 0x005E1DBC File Offset: 0x005DFFBC
	public bool IsTeamSetRoleFinishEdit()
	{
		using (List<ShipTowerTeamData>.Enumerator enumerator = this.TeamDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.IsSetRoleFinishEdit())
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060153BA RID: 86970 RVA: 0x005E1E18 File Offset: 0x005E0018
	public bool IsTeamSetBuffFinish()
	{
		using (List<ShipTowerTeamData>.Enumerator enumerator = this.TeamDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.IsSetBuffFinish())
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060153BB RID: 86971 RVA: 0x005E1E74 File Offset: 0x005E0074
	public bool IsTeamSetBuffFinishEdit()
	{
		using (List<ShipTowerTeamData>.Enumerator enumerator = this.TeamDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.IsSetBuffFinishEdit())
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060153BC RID: 86972 RVA: 0x005E1ED0 File Offset: 0x005E00D0
	public List<int> GetAllTeamBuffIdList()
	{
		List<int> list = new List<int>();
		foreach (ShipTowerTeamData shipTowerTeamData in this.TeamDataList)
		{
			List<int> list2 = list;
			ShipTowerBuffData buffDataEdit = shipTowerTeamData.BuffDataEdit;
			list2.Add((buffDataEdit != null) ? buffDataEdit.Id : 0);
		}
		return list;
	}

	// Token: 0x060153BD RID: 86973 RVA: 0x005E1F3C File Offset: 0x005E013C
	public int GetChallengeInstId()
	{
		return this.InstIds[0];
	}

	// Token: 0x060153BE RID: 86974 RVA: 0x005E1F4C File Offset: 0x005E014C
	private void UpdateCurrentScore()
	{
		int num = 0;
		foreach (ShipTowerTeamData shipTowerTeamData in this.TeamDataList)
		{
			num += shipTowerTeamData.CurrentScore;
		}
		this.CurrentScore = num;
	}

	// Token: 0x060153BF RID: 86975 RVA: 0x005E1FAC File Offset: 0x005E01AC
	private void UpdateCurrentScoreAndSaveLast()
	{
		this.UpdateCurrentScore();
		this.SaveLastData();
	}

	// Token: 0x060153C0 RID: 86976 RVA: 0x005E1FBC File Offset: 0x005E01BC
	public void ProtoUpdateDataBase(SlashLevelPlayInfo data)
	{
		this.IsHaveProtoData = true;
		this.ProtoIsUnLocked = data.UnLock;
		this.ProtoIsPassed = data.LevelPass;
		ShipTowerTeamData shipTowerTeamData = this.TeamDataList[0];
		ShipTowerTeamData shipTowerTeamData2 = this.TeamDataList[1];
		this.IsQuickPass = data.IsEasyPass;
		int num = 0;
		for (;;)
		{
			int num2 = num;
			BattleFormation firstBattle = data.FirstBattle;
			int? num3 = (firstBattle != null) ? new int?(firstBattle.SelectRoles.Count) : null;
			if (!(num2 < num3.GetValueOrDefault() & num3 != null))
			{
				break;
			}
			int roleId = data.FirstBattle.SelectRoles[num];
			shipTowerTeamData.ProtoSetRole(roleId, num);
			BattleFormation firstBattle2 = data.FirstBattle;
			int skillBranchId = (((firstBattle2 != null) ? firstBattle2.SkillBranchIds : null) != null && num < data.FirstBattle.SkillBranchIds.Count) ? data.FirstBattle.SkillBranchIds[num] : 0;
			shipTowerTeamData.ProtoSetSkillBranch(skillBranchId, num);
			num++;
		}
		ShipTowerTeamData shipTowerTeamData3 = shipTowerTeamData;
		BattleFormation firstBattle3 = data.FirstBattle;
		shipTowerTeamData3.ProtoSetBuff((firstBattle3 != null) ? new int?(firstBattle3.BuffSelect) : null);
		shipTowerTeamData.UpdateCurrentScore(data.SlashFirstScore);
		int num4 = 0;
		for (;;)
		{
			int num5 = num4;
			BattleFormation secondBattle = data.SecondBattle;
			int? num3 = (secondBattle != null) ? new int?(secondBattle.SelectRoles.Count) : null;
			if (!(num5 < num3.GetValueOrDefault() & num3 != null))
			{
				break;
			}
			int roleId2 = data.SecondBattle.SelectRoles[num4];
			shipTowerTeamData2.ProtoSetRole(roleId2, num4);
			BattleFormation secondBattle2 = data.SecondBattle;
			int skillBranchId2 = (((secondBattle2 != null) ? secondBattle2.SkillBranchIds : null) != null && num4 < data.SecondBattle.SkillBranchIds.Count) ? data.SecondBattle.SkillBranchIds[num4] : 0;
			shipTowerTeamData2.ProtoSetSkillBranch(skillBranchId2, num4);
			num4++;
		}
		ShipTowerTeamData shipTowerTeamData4 = shipTowerTeamData2;
		BattleFormation secondBattle3 = data.SecondBattle;
		shipTowerTeamData4.ProtoSetBuff((secondBattle3 != null) ? new int?(secondBattle3.BuffSelect) : null);
		shipTowerTeamData2.UpdateCurrentScore(data.SlashSecondScore);
	}

	// Token: 0x060153C1 RID: 86977 RVA: 0x005E21C9 File Offset: 0x005E03C9
	public void ProtoNotifyInitData(SlashLevelPlayInfo data)
	{
		this.ProtoUpdateDataBase(data);
		this.UpdateCurrentScore();
		this.SaveLastData();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ShipTowerStageUpdate, this.Id);
	}

	// Token: 0x060153C2 RID: 86978 RVA: 0x005E21F4 File Offset: 0x005E03F4
	public void ProtoNotifyUpdateData(SlashLevelPlayInfo data)
	{
		this.ProtoUpdateDataBase(data);
		this.UpdateCurrentScore();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ShipTowerStageUpdate, this.Id);
	}

	// Token: 0x060153C3 RID: 86979 RVA: 0x005E2219 File Offset: 0x005E0419
	public void SaveLastData()
	{
		this.LastIsPass = this.IsPassed();
		this.LastScore = this.CurrentScore;
		this.IsNeedSureScore = (this.LastScore > 0);
	}

	// Token: 0x060153C4 RID: 86980 RVA: 0x005E2242 File Offset: 0x005E0442
	public bool CheckPass(int newScore = 0)
	{
		return newScore >= this.PassScore;
	}

	// Token: 0x060153C5 RID: 86981 RVA: 0x005E2250 File Offset: 0x005E0450
	public void SureResultFromInstance()
	{
		ModelBase<ShipTowerModel>.Instance.OpenViewMain(new ShipTowerViewParams
		{
			StageId = new int?(this.Id),
			IsOpenStageDesc = new bool?(true),
			IsOpenCover = new bool?(true),
			IsFromInstanceDungeon = new bool?(true)
		});
	}

	// Token: 0x060153C6 RID: 86982 RVA: 0x005E22A1 File Offset: 0x005E04A1
	public void GotoDescFromInstance()
	{
		ModelBase<ShipTowerModel>.Instance.OpenViewMain(new ShipTowerViewParams
		{
			StageId = new int?(this.Id),
			IsOpenStageDesc = new bool?(true),
			IsFromInstanceDungeon = new bool?(true)
		});
	}

	// Token: 0x060153C7 RID: 86983 RVA: 0x005E22DC File Offset: 0x005E04DC
	public void GotoNextDescFromInstance(ShipTowerStageData nextStageData)
	{
		ModelBase<ShipTowerModel>.Instance.OpenViewMain(new ShipTowerViewParams
		{
			StageId = new int?(nextStageData.Id),
			IsOpenStageDesc = new bool?(true),
			IsFromInstanceDungeon = new bool?(true),
			ApplyTeamEditStageId = this.Id
		});
	}

	// Token: 0x060153C8 RID: 86984 RVA: 0x005E2330 File Offset: 0x005E0530
	public UniTask SureResetStage()
	{
		ShipTowerStageData.<SureResetStage>d__70 <SureResetStage>d__;
		<SureResetStage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SureResetStage>d__.<>4__this = this;
		<SureResetStage>d__.<>1__state = -1;
		<SureResetStage>d__.<>t__builder.Start<ShipTowerStageData.<SureResetStage>d__70>(ref <SureResetStage>d__);
		return <SureResetStage>d__.<>t__builder.Task;
	}

	// Token: 0x060153C9 RID: 86985 RVA: 0x005E2374 File Offset: 0x005E0574
	public void ResetStage()
	{
		foreach (ShipTowerTeamData shipTowerTeamData in this.TeamDataList)
		{
			shipTowerTeamData.ResetStage();
		}
		this.ResetQuickPass();
		this.UpdateCurrentScoreAndSaveLast();
	}

	// Token: 0x060153CA RID: 86986 RVA: 0x005E23D0 File Offset: 0x005E05D0
	public UniTask SureCoverChallenge()
	{
		ShipTowerStageData.<SureCoverChallenge>d__72 <SureCoverChallenge>d__;
		<SureCoverChallenge>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SureCoverChallenge>d__.<>4__this = this;
		<SureCoverChallenge>d__.<>1__state = -1;
		<SureCoverChallenge>d__.<>t__builder.Start<ShipTowerStageData.<SureCoverChallenge>d__72>(ref <SureCoverChallenge>d__);
		return <SureCoverChallenge>d__.<>t__builder.Task;
	}

	// Token: 0x060153CB RID: 86987 RVA: 0x005E2414 File Offset: 0x005E0614
	public void CoverChallenge()
	{
		foreach (ShipTowerTeamData shipTowerTeamData in this.TeamDataList)
		{
			shipTowerTeamData.CoverChallenge();
		}
		this.ResetQuickPass();
		this.UpdateCurrentScoreAndSaveLast();
	}

	// Token: 0x060153CC RID: 86988 RVA: 0x005E2470 File Offset: 0x005E0670
	public void UpdateNewChallengeScore()
	{
		this.NewChallengeScore = 0;
		foreach (ShipTowerTeamData shipTowerTeamData in this.TeamDataList)
		{
			this.NewChallengeScore += shipTowerTeamData.NewChallengeScore;
		}
	}

	// Token: 0x060153CD RID: 86989 RVA: 0x005E24D8 File Offset: 0x005E06D8
	public void UpdateToEdit()
	{
		foreach (ShipTowerTeamData shipTowerTeamData in this.TeamDataList)
		{
			shipTowerTeamData.UpdateToEdit();
		}
	}

	// Token: 0x060153CE RID: 86990 RVA: 0x005E2528 File Offset: 0x005E0728
	public void CopyTeamRoleToEdit(int targetId)
	{
		ShipTowerStageData stageDataById = ModelBase<ShipTowerModel>.Instance.GetStageDataById(targetId);
		for (int i = 0; i < this.TeamDataList.Count; i++)
		{
			this.TeamDataList[i].CopyTeamRoleToEdit(stageDataById.TeamDataList[i]);
		}
	}

	// Token: 0x060153CF RID: 86991 RVA: 0x005E2574 File Offset: 0x005E0774
	public void ProtoTeamEditFromResult(SlashAndTowerResultNotify result)
	{
		ShipTowerTeamData shipTowerTeamData = this.TeamDataList[0];
		ShipTowerTeamData shipTowerTeamData2 = this.TeamDataList[1];
		shipTowerTeamData.ProtoTeamEditFromResult(result.FirstFormation);
		shipTowerTeamData2.ProtoTeamEditFromResult(result.SecondFormation);
		int score = result.FirstKillMonsterScore + result.FirstRoundScore;
		int score2 = result.SecondKillMonsterScore + result.SecondRoundScore;
		shipTowerTeamData.ProtoSetNewChallengeScore(score);
		shipTowerTeamData2.ProtoSetNewChallengeScore(score2);
		this.UpdateNewChallengeScore();
	}

	// Token: 0x060153D0 RID: 86992 RVA: 0x005E25E4 File Offset: 0x005E07E4
	public UniTask RequestTeamRecommendList()
	{
		ShipTowerStageData.<RequestTeamRecommendList>d__78 <RequestTeamRecommendList>d__;
		<RequestTeamRecommendList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestTeamRecommendList>d__.<>4__this = this;
		<RequestTeamRecommendList>d__.<>1__state = -1;
		<RequestTeamRecommendList>d__.<>t__builder.Start<ShipTowerStageData.<RequestTeamRecommendList>d__78>(ref <RequestTeamRecommendList>d__);
		return <RequestTeamRecommendList>d__.<>t__builder.Task;
	}

	// Token: 0x060153D1 RID: 86993 RVA: 0x005E2628 File Offset: 0x005E0828
	public void ProtoUpdateTeamRecommendList(SlashAndTowerRecommendResponse response)
	{
		this.TeamRecommendList.Clear();
		for (int i = 0; i < response.RecommendInfos.Count; i++)
		{
			SlashLevelRecommend slashLevelRecommend = response.RecommendInfos[i];
			List<ShipTowerMediumItemData> list = new List<ShipTowerMediumItemData>();
			List<ShipTowerMediumItemData> list2 = new List<ShipTowerMediumItemData>();
			BattleFormation formationFirst = slashLevelRecommend.FormationFirst;
			if (((formationFirst != null) ? formationFirst.SelectRoles : null) != null)
			{
				for (int j = 0; j < slashLevelRecommend.FormationFirst.SelectRoles.Count; j++)
				{
					int id = slashLevelRecommend.FormationFirst.SelectRoles[j];
					int skillBranchId = (slashLevelRecommend.FormationFirst.SkillBranchIds != null && j < slashLevelRecommend.FormationFirst.SkillBranchIds.Count) ? slashLevelRecommend.FormationFirst.SkillBranchIds[j] : 0;
					list.Add(new ShipTowerMediumItemData
					{
						Id = id,
						Count = 0,
						SkillBranchId = skillBranchId
					});
				}
			}
			BattleFormation formationSecond = slashLevelRecommend.FormationSecond;
			if (((formationSecond != null) ? formationSecond.SelectRoles : null) != null)
			{
				for (int k = 0; k < slashLevelRecommend.FormationSecond.SelectRoles.Count; k++)
				{
					int id2 = slashLevelRecommend.FormationSecond.SelectRoles[k];
					int skillBranchId2 = (slashLevelRecommend.FormationSecond.SkillBranchIds != null && k < slashLevelRecommend.FormationSecond.SkillBranchIds.Count) ? slashLevelRecommend.FormationSecond.SkillBranchIds[k] : 0;
					list2.Add(new ShipTowerMediumItemData
					{
						Id = id2,
						Count = 0,
						SkillBranchId = skillBranchId2
					});
				}
			}
			int num = 100;
			ShipTowerTeamRecommendItemData shipTowerTeamRecommendItemData = new ShipTowerTeamRecommendItemData();
			shipTowerTeamRecommendItemData.UseRate = slashLevelRecommend.Usage / num;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(i + 1);
			shipTowerTeamRecommendItemData.Name = defaultInterpolatedStringHandler.ToStringAndClear();
			shipTowerTeamRecommendItemData.RoleIdList1 = list;
			shipTowerTeamRecommendItemData.RoleIdList2 = list2;
			BattleFormation formationFirst2 = slashLevelRecommend.FormationFirst;
			shipTowerTeamRecommendItemData.Buff1 = ((formationFirst2 != null) ? formationFirst2.BuffSelect : 0);
			BattleFormation formationSecond2 = slashLevelRecommend.FormationSecond;
			shipTowerTeamRecommendItemData.Buff2 = ((formationSecond2 != null) ? formationSecond2.BuffSelect : 0);
			shipTowerTeamRecommendItemData.StageData = this;
			ShipTowerTeamRecommendItemData item = shipTowerTeamRecommendItemData;
			this.TeamRecommendList.Add(item);
		}
	}

	// Token: 0x060153D2 RID: 86994 RVA: 0x005E2850 File Offset: 0x005E0A50
	public bool UseTeamRecommend(ShipTowerTeamRecommendItemData data)
	{
		ShipTowerTeamData shipTowerTeamData = this.TeamDataList[0];
		ShipTowerTeamData shipTowerTeamData2 = this.TeamDataList[1];
		List<int> list = new List<int>();
		foreach (ShipTowerMediumItemData shipTowerMediumItemData in data.RoleIdList1)
		{
			list.Add(shipTowerMediumItemData.Id);
		}
		List<int> list2 = new List<int>();
		foreach (ShipTowerMediumItemData shipTowerMediumItemData2 in data.RoleIdList2)
		{
			list2.Add(shipTowerMediumItemData2.Id);
		}
		shipTowerTeamData.CopyIdsToEdit(list);
		shipTowerTeamData2.CopyIdsToEdit(list2);
		shipTowerTeamData.CopyBuffIdToEdit(data.Buff1, this.Id);
		shipTowerTeamData2.CopyBuffIdToEdit(data.Buff2, this.Id);
		foreach (ShipTowerMediumItemData shipTowerMediumItemData3 in data.RoleIdList1)
		{
			ModelBase<RoleModel>.Instance.SetRoleSkillBranchGamePlayCache(shipTowerMediumItemData3.Id, shipTowerMediumItemData3.SkillBranchId, ESkillBranchCacheType.ShipTower);
		}
		foreach (ShipTowerMediumItemData shipTowerMediumItemData4 in data.RoleIdList2)
		{
			ModelBase<RoleModel>.Instance.SetRoleSkillBranchGamePlayCache(shipTowerMediumItemData4.Id, shipTowerMediumItemData4.SkillBranchId, ESkillBranchCacheType.ShipTower);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ShipTowerTeamRecommendApplyFinish, this.Id);
		return true;
	}

	// Token: 0x060153D3 RID: 86995 RVA: 0x005E2A10 File Offset: 0x005E0C10
	public bool IsCanApplyTeamRecommend(ShipTowerTeamRecommendItemData data)
	{
		ShipTowerBuffData buffDataByBuffId = ModelBase<ShipTowerModel>.Instance.GetBuffDataByBuffId(data.Buff1);
		if (buffDataByBuffId != null && buffDataByBuffId.IsCanUse(new int?(this.Id)))
		{
			return true;
		}
		ShipTowerBuffData buffDataByBuffId2 = ModelBase<ShipTowerModel>.Instance.GetBuffDataByBuffId(data.Buff2);
		if (buffDataByBuffId2 != null && buffDataByBuffId2.IsCanUse(new int?(this.Id)))
		{
			return true;
		}
		foreach (ShipTowerMediumItemData shipTowerMediumItemData in data.RoleIdList1)
		{
			if (ModelBase<ShipTowerModel>.Instance.IsCanUseRole(shipTowerMediumItemData.Id))
			{
				return true;
			}
		}
		foreach (ShipTowerMediumItemData shipTowerMediumItemData2 in data.RoleIdList2)
		{
			if (ModelBase<ShipTowerModel>.Instance.IsCanUseRole(shipTowerMediumItemData2.Id))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060153D4 RID: 86996 RVA: 0x005E2B1C File Offset: 0x005E0D1C
	public void UpdateMainRoleToEdit()
	{
		foreach (ShipTowerTeamData shipTowerTeamData in this.TeamDataList)
		{
			shipTowerTeamData.UpdateMainRoleToEdit();
		}
	}

	// Token: 0x060153D5 RID: 86997 RVA: 0x005E2B6C File Offset: 0x005E0D6C
	public bool IsOldSeasonData()
	{
		if (this.IsTeamSetRoleFinish() && !this.IsTeamSetBuffFinish())
		{
			return true;
		}
		foreach (ShipTowerTeamData shipTowerTeamData in this.TeamDataList)
		{
			if (shipTowerTeamData.BuffData != null)
			{
				ShipTowerModel instance = ModelBase<ShipTowerModel>.Instance;
				if (instance != null && instance.IsOldSeason(shipTowerTeamData.BuffData.Season))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060153D6 RID: 86998 RVA: 0x005E2BF8 File Offset: 0x005E0DF8
	[NullableContext(2)]
	public ShipTowerTeamData GetCurrentTeamData()
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		int num = -1;
		for (int i = 0; i < this.TeamDataList.Count; i++)
		{
			if (this.TeamDataList[i].InstId == instanceId)
			{
				num = i;
				break;
			}
		}
		return this.TeamDataList[(num >= 0) ? num : 0];
	}

	// Token: 0x060153D7 RID: 86999 RVA: 0x005E2C53 File Offset: 0x005E0E53
	[NullableContext(2)]
	public ShipTowerTeamData GetCurSelectTeamData()
	{
		if (this.CurSelectTeamIndex < this.TeamDataList.Count)
		{
			return this.TeamDataList[this.CurSelectTeamIndex];
		}
		return null;
	}

	// Token: 0x060153D8 RID: 87000 RVA: 0x005E2C7B File Offset: 0x005E0E7B
	private void ResetQuickPass()
	{
		this.IsQuickPass = false;
	}

	// Token: 0x0400A3C1 RID: 41921
	public int Id;

	// Token: 0x0400A3C2 RID: 41922
	public int OrderIndex;

	// Token: 0x0400A3C3 RID: 41923
	public EShipTowerStageType StageType;

	// Token: 0x0400A3C4 RID: 41924
	public int Season;

	// Token: 0x0400A3C5 RID: 41925
	public bool IsEndLess;

	// Token: 0x0400A3C6 RID: 41926
	public bool IsQuickPass;

	// Token: 0x0400A3C7 RID: 41927
	public List<int> InstIds;

	// Token: 0x0400A3C8 RID: 41928
	public List<int> PreLevel;

	// Token: 0x0400A3C9 RID: 41929
	public string TitleKey;

	// Token: 0x0400A3CA RID: 41930
	public string DescKey;

	// Token: 0x0400A3CB RID: 41931
	public List<int> TargetScoreList;

	// Token: 0x0400A3CC RID: 41932
	public List<string> ScoreStageList;

	// Token: 0x0400A3CD RID: 41933
	public int CurrentScore;

	// Token: 0x0400A3CE RID: 41934
	public int PassScore;

	// Token: 0x0400A3CF RID: 41935
	public int PassReward;

	// Token: 0x0400A3D0 RID: 41936
	private readonly List<TItem> PassRewardItems;

	// Token: 0x0400A3D1 RID: 41937
	public readonly List<ShipTowerTeamData> TeamDataList;

	// Token: 0x0400A3D2 RID: 41938
	public bool ProtoIsUnLocked;

	// Token: 0x0400A3D3 RID: 41939
	public int NewChallengeScore;

	// Token: 0x0400A3D4 RID: 41940
	public bool IsHaveProtoData;

	// Token: 0x0400A3D5 RID: 41941
	public bool LastIsPass;

	// Token: 0x0400A3D6 RID: 41942
	public int LastScore;

	// Token: 0x0400A3D7 RID: 41943
	public bool IsNeedSureScore;

	// Token: 0x0400A3D8 RID: 41944
	public int BelongToSeason;

	// Token: 0x0400A3D9 RID: 41945
	public bool ProtoIsPassed;

	// Token: 0x0400A3DA RID: 41946
	public List<ShipTowerTeamRecommendItemData> TeamRecommendList;

	// Token: 0x0400A3DB RID: 41947
	public int CurSelectTeamIndex;
}
