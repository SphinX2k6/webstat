using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.SeamlessTravel;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C16 RID: 27670
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventTeleportDungeon : LevelEventBase
	{
		// Token: 0x0604418C RID: 278924 RVA: 0x011AE8DB File Offset: 0x011ACADB
		public LevelEventTeleportDungeon(int id) : base(id)
		{
		}

		// Token: 0x0604418D RID: 278925 RVA: 0x011AE8E4 File Offset: 0x011ACAE4
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.InstanceDungeon, ELogAuthor.WLJ, "[LevelEventTeleportDungeon]ExecuteInGm", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.FinishExecute(true, false, true);
		}

		// Token: 0x0604418E RID: 278926 RVA: 0x011AE918 File Offset: 0x011ACB18
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			SundryModel instance = ModelBase<SundryModel>.Instance;
			if (instance != null && instance.IsBlockTpDungeon())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText("TeleportDungeon被GM屏蔽，跳过执行");
				base.FinishExecute(true, false, true);
				return;
			}
			LoadingModel instance2 = ModelBase<LoadingModel>.Instance;
			if (instance2 != null && instance2.IsLoading)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			TeleportDungeon @params = inParams as TeleportDungeon;
			if (@params == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			int dungeonId = @params.DungeonId;
			if (ControllerBase<InstanceDungeonController>.Instance.IsForbidDungeon(dungeonId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomFormationEnterInstanceTip", Array.Empty<object>());
				base.FinishExecute(false, false, true);
				return;
			}
			if (ControllerBase<ConfirmBoxController>.Instance.CheckIsConfirmBoxOpen())
			{
				base.FinishExecute(true, false, true);
				return;
			}
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			if (config == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			int instType = config.Value.InstType;
			if (@params.IsNeedSecondaryConfirmation.GetValueOrDefault())
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TeleportDungeonConfirm);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					int dungeonId2 = @params.DungeonId;
					ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId = dungeonId2;
				};
				confirmBoxDataNew.FunctionMap[1] = delegate()
				{
					ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
					this.RequestFinish();
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			ITeleportTransitionType transitionOption = @params.TransitionOption;
			if (transitionOption != null && transitionOption.Type == ETeleportTransitionType.Seamless)
			{
				List<EKeepMovementState> keepMovementStates = (@params.TransitionOption as ITeleportTransitionInSeamlessType).KeepMovementStates;
				if (keepMovementStates != null && keepMovementStates.Contains(EKeepMovementState.Kite))
				{
					SeamlessTravelContext seamlessTravelContext = new SeamlessTravelContext();
					seamlessTravelContext.ParseParamsByProto(TeleportTransitionHelper.ParseTeleportTransitionOptionToPb(@params.TransitionOption).TransitionInSeamless);
					ControllerBase<SeamlessTravelController>.Instance.EnableSeamlessTravel(seamlessTravelContext, true).ContinueWith(delegate(bool task)
					{
						this.TeleportDungeon(@params);
					});
					return;
				}
			}
			this.TeleportDungeon(@params);
		}

		// Token: 0x0604418F RID: 278927 RVA: 0x011AEB14 File Offset: 0x011ACD14
		private void TeleportDungeon(TeleportDungeon @params)
		{
			int dungeonId = @params.DungeonId;
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			TransitionOptionPb transitionOption = this.ParseTransitionOptionParamToPb(@params);
			ModelBase<InstanceDungeonEntranceModel>.Instance.TransitionOption = transitionOption;
			ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId = dungeonId;
			bool flag = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(dungeonId).Value.InstType == 1;
			if (config.Value.InstType == 1)
			{
				if (flag)
				{
					this.RequestFinish();
					return;
				}
				this.EnterDungeon(@params.IsRegroup, dungeonId, @params.LocationEntityId);
				return;
			}
			else
			{
				if (flag)
				{
					this.RequestFinish();
					return;
				}
				this.EnterDungeon(@params.IsRegroup, dungeonId, @params.LocationEntityId);
				return;
			}
		}

		// Token: 0x06044190 RID: 278928 RVA: 0x011AEBD0 File Offset: 0x011ACDD0
		private void EnterDungeon(bool isRegroup, int dungeonId, int? posEntityId = null)
		{
			if (isRegroup)
			{
				Singleton<EventSystem>.Instance.Add(EEventName.EnterInstanceDungeon, new Action(this.RequestFinish));
				ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(dungeonId, false, false, false, null);
				return;
			}
			this.RequestFinish();
		}

		// Token: 0x06044191 RID: 278929 RVA: 0x011AEC1A File Offset: 0x011ACE1A
		private void RequestFinish()
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06044192 RID: 278930 RVA: 0x011AEC25 File Offset: 0x011ACE25
		protected override void OnReset()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.EnterInstanceDungeon, new Action(this.RequestFinish)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.EnterInstanceDungeon, new Action(this.RequestFinish));
			}
		}

		// Token: 0x06044193 RID: 278931 RVA: 0x011AEC60 File Offset: 0x011ACE60
		[NullableContext(2)]
		private TransitionOptionPb ParseTransitionOptionParamToPb(TeleportDungeon @params)
		{
			ITeleportTransitionType transitionOption = @params.TransitionOption;
			TransitionOptionPb result = TeleportTransitionHelper.ParseTeleportTransitionOptionToPb(transitionOption);
			if (transitionOption != null && transitionOption.Type == ETeleportTransitionType.PlayMp4 && (transitionOption as ITeleportTransitionWithMp4).IsFadeInScreenAfterTeleport.GetValueOrDefault())
			{
				ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.Common, ELoadingPerform.CameraFade, "FadeInScreenAfterTeleport", null, new object[]
				{
					1f
				});
			}
			return result;
		}
	}
}
