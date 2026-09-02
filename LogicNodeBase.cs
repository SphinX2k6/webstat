using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.FirstPersonTurret;
using CSharpScript.Game.World.Controller;
using UnrealEngine;

// Token: 0x02001DCA RID: 7626
[NullableContext(2)]
[Nullable(0)]
public abstract class LogicNodeBase : BehaviorNodeBase
{
	// Token: 0x0600E1C0 RID: 57792 RVA: 0x003CCA5F File Offset: 0x003CAC5F
	protected LogicNodeBase(int nodeId) : base(nodeId)
	{
	}

	// Token: 0x170011A5 RID: 4517
	// (get) Token: 0x0600E1C1 RID: 57793 RVA: 0x003CCA68 File Offset: 0x003CAC68
	public IQuestScheduleConfig CustomUiConfig
	{
		get
		{
			ILogicBtNode config = this.Config;
			if (config == null)
			{
				return null;
			}
			return config.UIConfig;
		}
	}

	// Token: 0x170011A6 RID: 4518
	// (get) Token: 0x0600E1C2 RID: 57794 RVA: 0x003CCA7B File Offset: 0x003CAC7B
	public IInformationViewType SilentAreaInfoViewConfig
	{
		get
		{
			ILogicBtNode config = this.Config;
			if (config == null)
			{
				return null;
			}
			IInformationViewConfig informationView = config.InformationView;
			if (informationView == null)
			{
				return null;
			}
			return informationView.InformationView;
		}
	}

	// Token: 0x170011A7 RID: 4519
	// (get) Token: 0x0600E1C3 RID: 57795 RVA: 0x003CCA99 File Offset: 0x003CAC99
	public ITrackAreaText ModifyTrackAreaTextConfig
	{
		get
		{
			ILogicBtNode config = this.Config;
			if (config == null)
			{
				return null;
			}
			return config.ModifyTrackAreaText;
		}
	}

	// Token: 0x170011A8 RID: 4520
	// (get) Token: 0x0600E1C4 RID: 57796 RVA: 0x003CCAAC File Offset: 0x003CACAC
	public ITrackCustomBoardOnBtLogicNode TrackCustomBoard
	{
		get
		{
			ILogicBtNode config = this.Config;
			if (config == null)
			{
				return null;
			}
			return config.TrackCustomBoard;
		}
	}

	// Token: 0x170011A9 RID: 4521
	// (get) Token: 0x0600E1C5 RID: 57797 RVA: 0x003CCABF File Offset: 0x003CACBF
	public ITrackLevelPlay TrackLevelPlay
	{
		get
		{
			ITrackTarget trackTarget = this.TrackTarget;
			return ((trackTarget != null) ? trackTarget.TrackType : null) as ITrackLevelPlay;
		}
	}

	// Token: 0x0600E1C6 RID: 57798 RVA: 0x003CCAD8 File Offset: 0x003CACD8
	[NullableContext(1)]
	protected override bool OnCreate(IBtNode nodeConfig)
	{
		this.Config = (nodeConfig as ILogicBtNode);
		ILogicBtNode config = this.Config;
		ITrackTarget trackTarget;
		if (config == null)
		{
			trackTarget = null;
		}
		else
		{
			IQuestScheduleConfig uiconfig = config.UIConfig;
			trackTarget = ((uiconfig != null) ? uiconfig.TrackTarget : null);
		}
		this.TrackTarget = trackTarget;
		return true;
	}

	// Token: 0x0600E1C7 RID: 57799 RVA: 0x003CCB0C File Offset: 0x003CAD0C
	protected override void OnNodeActive()
	{
		ILogicBtNode config = this.Config;
		int valueOrDefault = config.DungeonId.GetValueOrDefault();
		if (valueOrDefault != 0)
		{
			this.Blackboard.DungeonId = valueOrDefault;
			this.Blackboard.ChangeDungeonIdNodeId = this.InnerNodeId;
		}
		if (config.DisableOnline.GetValueOrDefault())
		{
			this.DisableOnline(true);
		}
		if (config.DisableTrackAnim != null && ControllerBase<LevelGeneralController>.Instance.CheckConditionNew(config.DisableTrackAnim.Condition, null, this.Context, null))
		{
			Blackboard blackboard = this.Blackboard;
			if (blackboard != null)
			{
				blackboard.AddTag(EBehaviorTreeTag.SkipMissionPanelAnim, base.NodeId.ToString());
			}
		}
		if (config.DisableSkeletalAnimationCheck.GetValueOrDefault())
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "a.Animation.AnimSeqSkeletonCheck false", null);
		}
		if (this.Config.LogicProgramSpecialProcess != null)
		{
			this.ClientSpecialProcess(true);
		}
		if (this.CustomUiConfig != null)
		{
			this.AddTag(EBehaviorTreeTag.CanShow, "");
		}
		IInformationViewType silentAreaInfoViewConfig = this.SilentAreaInfoViewConfig;
		if (silentAreaInfoViewConfig != null)
		{
			Blackboard blackboard2 = this.Blackboard;
			if (blackboard2 != null)
			{
				blackboard2.AddSilentShowInfo(base.NodeId, silentAreaInfoViewConfig);
			}
		}
		ITrackAreaText modifyTrackAreaTextConfig = this.ModifyTrackAreaTextConfig;
		if (modifyTrackAreaTextConfig != null)
		{
			Blackboard blackboard3 = this.Blackboard;
			if (blackboard3 != null)
			{
				blackboard3.AddModifyTrackAreaConfig(base.NodeId, modifyTrackAreaTextConfig);
			}
		}
		if (config.CompositeTrackViewMode != null)
		{
			this.Blackboard.TrackViewModel = config.CompositeTrackViewMode.Value;
			this.AddTrackViewMode = true;
		}
		if (this.BtType == BtType.Quest)
		{
			QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
			if (!string.IsNullOrEmpty(config.TidQuestAliasName) && !string.IsNullOrEmpty(Singleton<PublicUtil>.Instance.GetConfigTextByKey(config.TidQuestAliasName)))
			{
				instance.SetQuestStageName(base.TreeConfigId, config.TidQuestAliasName);
			}
			if (!string.IsNullOrEmpty(config.TidQuestAliasDesc) && !string.IsNullOrEmpty(Singleton<PublicUtil>.Instance.GetConfigTextByKey(config.TidQuestAliasDesc)))
			{
				instance.SetQuestStageDesc(base.TreeConfigId, config.TidQuestAliasDesc);
			}
			IQuestRewardConfig rewardConfig = config.RewardConfig;
			int num = (rewardConfig != null) ? rewardConfig.RewardId : 0;
			if (num != 0)
			{
				instance.SetQuestStageReward(base.TreeConfigId, num);
			}
		}
		ILogicBtNode config2 = this.Config;
		if (((config2 != null) ? config2.SpecialGamePlayConfig : null) != null)
		{
			ESpecialGamePlayConfigType type = this.Config.SpecialGamePlayConfig.Type;
			switch (type)
			{
			case ESpecialGamePlayConfigType.Stalking:
				ControllerBase<SneakController>.Instance.StartSneaking();
				break;
			case ESpecialGamePlayConfigType.FreezeOnSight:
				ControllerBase<FreezeOnSightController>.Instance.OpenFreezeOnSightGameplay();
				break;
			case ESpecialGamePlayConfigType.FirstPersonTurret:
				ControllerBase<FirstPersonTurretController>.Instance.Start(this.Context);
				break;
			default:
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.CH;
				string message = "未知特殊玩法类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", type);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				break;
			}
			}
		}
		ILogicBtNode config3 = this.Config;
		if (((config3 != null) ? config3.SaveConfig : null) != null)
		{
			this.Blackboard.RollbackPoint = base.NodeId;
		}
		ITrackLevelPlay trackLevelPlay = this.TrackLevelPlay;
		if (trackLevelPlay != null)
		{
			ModelBase<GeneralLogicTreeModel>.Instance.AddLevelPlayTrackBinding(base.NodeId, base.TreeIncId, trackLevelPlay.LevelPlayId);
			Blackboard blackboard4 = this.Blackboard;
			if (blackboard4 != null)
			{
				blackboard4.AddTag(EBehaviorTreeTag.BindingLevelPlayTrack, base.NodeId.ToString());
			}
		}
		ILogicBtNode config4 = this.Config;
		if (((config4 != null) ? config4.DisableSystemPrompt : null) != null && this.Config.DisableSystemPrompt.Count != 0)
		{
			this.HandleDisableSystemPrompt(true);
		}
	}

	// Token: 0x0600E1C8 RID: 57800 RVA: 0x003CCE50 File Offset: 0x003CB050
	protected override void OnNodeDeActive(bool success)
	{
		this.RemoveTag(EBehaviorTreeTag.CanShow, "");
		Blackboard blackboard = this.Blackboard;
		if (blackboard != null)
		{
			blackboard.RemoveTag(EBehaviorTreeTag.SkipMissionPanelAnim, base.NodeId.ToString());
		}
		if (this.SilentAreaInfoViewConfig != null)
		{
			Blackboard blackboard2 = this.Blackboard;
			if (blackboard2 != null)
			{
				blackboard2.RemoveSilentShowInfo(base.NodeId);
			}
		}
		if (this.ModifyTrackAreaTextConfig != null)
		{
			Blackboard blackboard3 = this.Blackboard;
			if (blackboard3 != null)
			{
				blackboard3.RemoveModifyTrackAreaConfig(base.NodeId);
			}
		}
		if (this.BtType == BtType.Quest)
		{
			QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
			if (!string.IsNullOrEmpty(this.Config.TidQuestAliasName) && !string.IsNullOrEmpty(Singleton<PublicUtil>.Instance.GetConfigTextByKey(this.Config.TidQuestAliasName)))
			{
				instance.SetQuestStageName(base.TreeConfigId, "");
			}
			if (!string.IsNullOrEmpty(this.Config.TidQuestAliasDesc) && !string.IsNullOrEmpty(Singleton<PublicUtil>.Instance.GetConfigTextByKey(this.Config.TidQuestAliasDesc)))
			{
				instance.SetQuestStageDesc(base.TreeConfigId, "");
			}
			IQuestRewardConfig rewardConfig = this.Config.RewardConfig;
			if (rewardConfig != null && rewardConfig.RewardId != 0)
			{
				instance.SetQuestStageReward(base.TreeConfigId, 0);
			}
		}
		if (this.AddTrackViewMode)
		{
			this.Blackboard.TrackViewModel = ETrackViewMode.All;
		}
		if (this.Config.DungeonId.GetValueOrDefault() != 0)
		{
			if (this.Blackboard.ChangeDungeonIdNodeId != 0)
			{
				if (this.Blackboard.ChangeDungeonIdNodeId == this.InnerNodeId)
				{
					this.Blackboard.DungeonId = 0;
					this.Blackboard.ChangeDungeonIdNodeId = 0;
				}
			}
			else
			{
				this.Blackboard.DungeonId = 0;
			}
		}
		ILogicBtNode config = this.Config;
		if (((config != null) ? config.SpecialGamePlayConfig : null) != null)
		{
			ESpecialGamePlayConfigType type = this.Config.SpecialGamePlayConfig.Type;
			switch (type)
			{
			case ESpecialGamePlayConfigType.Stalking:
				ControllerBase<SneakController>.Instance.EndSneaking();
				break;
			case ESpecialGamePlayConfigType.FreezeOnSight:
				ControllerBase<FreezeOnSightController>.Instance.CloseFreezeOnSightGameplay();
				break;
			case ESpecialGamePlayConfigType.FirstPersonTurret:
				ControllerBase<FirstPersonTurretController>.Instance.End();
				break;
			default:
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.CH;
				string message = "未知特殊玩法类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", type);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				break;
			}
			}
		}
		if (this.Config.DisableOnline.GetValueOrDefault())
		{
			this.DisableOnline(false);
		}
		if (this.Config.DisableSkeletalAnimationCheck.GetValueOrDefault())
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "a.Animation.AnimSeqSkeletonCheck true", null);
		}
		if (this.Config.LogicProgramSpecialProcess != null)
		{
			this.ClientSpecialProcess(false);
		}
		ITrackLevelPlay trackLevelPlay = this.TrackLevelPlay;
		if (trackLevelPlay != null)
		{
			ModelBase<GeneralLogicTreeModel>.Instance.RemoveLevelPlayTrackBinding(base.TreeIncId, trackLevelPlay.LevelPlayId);
			Blackboard blackboard4 = this.Blackboard;
			if (blackboard4 != null)
			{
				blackboard4.RemoveTag(EBehaviorTreeTag.BindingLevelPlayTrack, base.NodeId.ToString());
			}
		}
		ILogicBtNode config2 = this.Config;
		if (((config2 != null) ? config2.DisableSystemPrompt : null) != null && this.Config.DisableSystemPrompt.Count != 0)
		{
			this.HandleDisableSystemPrompt(false);
		}
		base.OnNodeDeActive(success);
	}

	// Token: 0x0600E1C9 RID: 57801 RVA: 0x003CD148 File Offset: 0x003CB348
	private void ClientSpecialProcess(bool isFromActive)
	{
		foreach (IDisableUro disableUro in this.Config.LogicProgramSpecialProcess.SpecialProcessList)
		{
			if (disableUro != null)
			{
				IDisableUro disableUro2 = disableUro;
				foreach (int pbDataId in disableUro2.EntityIds)
				{
					EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
					WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
					if (worldEntity == null || !worldEntity.Valid)
					{
						if (isFromActive)
						{
							ControllerBase<AnimController>.Instance.CacheForceDisableAnimOptimization(pbDataId);
						}
					}
					else
					{
						BaseAnimationComponent component = worldEntity.GetComponent<BaseAnimationComponent>();
						if (isFromActive)
						{
							if (component != null)
							{
								component.StartForceDisableAnimOptimization(EForceDisableAnimOptimization.Plot, false);
							}
						}
						else if (component != null)
						{
							component.CancelForceDisableAnimOptimization(EForceDisableAnimOptimization.Plot);
						}
					}
				}
			}
		}
		if (!isFromActive)
		{
			ControllerBase<AnimController>.Instance.ClearForceDisableAnimOptimizationCache();
		}
	}

	// Token: 0x0600E1CA RID: 57802 RVA: 0x003CD25C File Offset: 0x003CB45C
	private void DisableOnline(bool disable)
	{
		BtType btType = this.BtType;
		if (btType == BtType.Quest)
		{
			ModelBase<OnlineModel>.Instance.DisableOnline(EDisableOnlineType.NonOnlineQuest, disable, base.TreeConfigId, base.NodeId);
			return;
		}
		if (btType != BtType.LevelPlay)
		{
			return;
		}
		ModelBase<OnlineModel>.Instance.DisableOnline(EDisableOnlineType.NonOnlinePlay, disable, base.TreeConfigId, base.NodeId);
	}

	// Token: 0x0600E1CB RID: 57803 RVA: 0x003CD2AC File Offset: 0x003CB4AC
	private void HandleDisableSystemPrompt(bool isDisable)
	{
		using (List<IAreaNameSystemPrompt>.Enumerator enumerator = this.Config.DisableSystemPrompt.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Type == ESystemPromptType.AreaName)
				{
					ModelBase<AreaModel>.Instance.SetEnableAreaNamePrompt(isDisable);
				}
			}
		}
	}

	// Token: 0x04006C38 RID: 27704
	protected ILogicBtNode Config;

	// Token: 0x04006C39 RID: 27705
	public bool AddTrackViewMode;
}
