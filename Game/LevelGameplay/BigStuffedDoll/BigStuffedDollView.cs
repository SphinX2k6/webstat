using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.BigStuffedDoll.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F5E RID: 28510
	[NullableContext(1)]
	[Nullable(0)]
	public class BigStuffedDollView : UiTickViewBase
	{
		// Token: 0x0604500D RID: 282637 RVA: 0x011F5CC8 File Offset: 0x011F3EC8
		public BigStuffedDollView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0604500E RID: 282638 RVA: 0x011F5D30 File Offset: 0x011F3F30
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBack));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickLeftBonusQte));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickRightBonusQte));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickCommonQte));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604500F RID: 282639 RVA: 0x011F5F28 File Offset: 0x011F4128
		protected override UniTask OnBeforeStartAsync()
		{
			BigStuffedDollView.<OnBeforeStartAsync>d__34 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BigStuffedDollView.<OnBeforeStartAsync>d__34>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06045010 RID: 282640 RVA: 0x011F5F6B File Offset: 0x011F416B
		protected override void OnStart()
		{
			base.OnStart();
		}

		// Token: 0x06045011 RID: 282641 RVA: 0x011F5F73 File Offset: 0x011F4173
		protected override void OnAfterShow()
		{
			base.OnAfterShow();
			ModelBase<BigStuffedDollModel>.Instance.EnterNextGameStage();
		}

		// Token: 0x06045012 RID: 282642 RVA: 0x011F5F88 File Offset: 0x011F4188
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer qteLeftBtnLevelSequence = this.QteLeftBtnLevelSequence;
			if (qteLeftBtnLevelSequence != null)
			{
				qteLeftBtnLevelSequence.Clear();
			}
			this.QteLeftBtnLevelSequence = null;
			LevelSequencePlayer qteRightBtnLevelSequence = this.QteRightBtnLevelSequence;
			if (qteRightBtnLevelSequence != null)
			{
				qteRightBtnLevelSequence.Clear();
			}
			this.QteRightBtnLevelSequence = null;
			this.QteLeftBtn = null;
			this.QteRightBtn = null;
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(this.EntityId, "CountDownStart");
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(this.EntityId, "CountDownOver");
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(this.EntityId, "GameOver");
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(this.EntityId, "PressFailCount");
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(this.EntityId, "PressCommonAreaSuccessCount");
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(this.EntityId, "PressPerfectAreaSuccessCount");
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(this.EntityId, "PressBonusAreaSuccessCount");
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(this.EntityId, "FinishSkillOver");
			Entity entity = Singleton<EntitySystem>.Instance.Get(this.EntityId);
			CharacterSkillComponent characterSkillComponent = (entity != null) ? entity.GetComponent<CharacterSkillComponent>() : null;
			if (characterSkillComponent != null)
			{
				int skillId = 0;
				OneOf<BrokenRockConfig, BrokenRockConfig> config = ModelBase<BigStuffedDollModel>.Instance.Config;
				if (config.HasValue)
				{
					if (config.IsT1)
					{
						skillId = config.AsT1.NormalSkill;
					}
					else if (config.IsT2)
					{
						skillId = config.AsT2.NormalSkill;
					}
				}
				characterSkillComponent.EndSkill(skillId, "BigStuffedDollView.OnBeforeDestroy");
			}
		}

		// Token: 0x06045013 RID: 282643 RVA: 0x011F60EE File Offset: 0x011F42EE
		protected override void OnAfterDestroy()
		{
			if (this.FinishCallback != null)
			{
				this.FinishCallback();
			}
		}

		// Token: 0x06045014 RID: 282644 RVA: 0x011F6104 File Offset: 0x011F4304
		protected override void OnTick(float delta)
		{
			this.ProgressItem.OnTick(delta);
			this.GameCountDownItem.OnTick(delta);
			foreach (KeyValuePair<int, BigStuffedRingItem> keyValuePair in this.RingItems)
			{
				BigStuffedRingItem value = keyValuePair.Value;
				value.OnTick(delta);
				int currentArrowStayCellIndex = value.GetCurrentArrowStayCellIndex();
				if (currentArrowStayCellIndex != 0)
				{
					ModelBase<BigStuffedDollModel>.Instance.GameInfo.CurrentArrowStayCellIndex = currentArrowStayCellIndex;
				}
			}
			bool? booleanValueByEntity = ModelBase<BlackboardModel>.Instance.GetBooleanValueByEntity(this.EntityId, "FinishSkillOver");
			EGameStage gameStage = ModelBase<BigStuffedDollModel>.Instance.GetGameStage();
			if (booleanValueByEntity != null && booleanValueByEntity.Value && gameStage == EGameStage.GameEndAnim && !this.IsExecutedFinish)
			{
				LevelGeneralCommons.PrechangeStateTag(ModelBase<BigStuffedDollModel>.Instance.BrokenRockEntityPbDataId, GameplayTagDefine.EGameplayTagId["关卡.打击机关.状态6"], "大个布偶坚固岩石玩法：终结一拳播放完毕");
				LevelGeneralNetworks.RequestEntitySendEvent(ModelBase<BigStuffedDollModel>.Instance.BrokenRockEntityCreatureDataId, "BrokenRockEventKey6");
				float valueOrDefault = ModelBase<BlackboardModel>.Instance.GetFloatValueByEntity(this.EntityId, "DelayFinishTime").GetValueOrDefault(0.02f);
				TimerSystem.Instance.Delay(delegate(float _)
				{
					this.GameSuccessItem.ShowTip();
				}, valueOrDefault * 1000f, null, null, true, 1f);
				this.IsExecutedFinish = true;
			}
		}

		// Token: 0x06045015 RID: 282645 RVA: 0x011F6268 File Offset: 0x011F4468
		private UniTask InitRings([Nullable(new byte[]
		{
			0,
			1
		})] OneOf<BrokenRockConfig, BrokenRockConfig>? config)
		{
			BigStuffedDollView.<InitRings>d__40 <InitRings>d__;
			<InitRings>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRings>d__.<>4__this = this;
			<InitRings>d__.config = config;
			<InitRings>d__.<>1__state = -1;
			<InitRings>d__.<>t__builder.Start<BigStuffedDollView.<InitRings>d__40>(ref <InitRings>d__);
			return <InitRings>d__.<>t__builder.Task;
		}

		// Token: 0x06045016 RID: 282646 RVA: 0x011F62B4 File Offset: 0x011F44B4
		private UniTask InitProgressItem([Nullable(new byte[]
		{
			0,
			1
		})] OneOf<BrokenRockConfig, BrokenRockConfig>? config)
		{
			BigStuffedDollView.<InitProgressItem>d__41 <InitProgressItem>d__;
			<InitProgressItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitProgressItem>d__.<>4__this = this;
			<InitProgressItem>d__.config = config;
			<InitProgressItem>d__.<>1__state = -1;
			<InitProgressItem>d__.<>t__builder.Start<BigStuffedDollView.<InitProgressItem>d__41>(ref <InitProgressItem>d__);
			return <InitProgressItem>d__.<>t__builder.Task;
		}

		// Token: 0x06045017 RID: 282647 RVA: 0x011F6300 File Offset: 0x011F4500
		private UniTask InitPrepareCountDownItem()
		{
			BigStuffedDollView.<InitPrepareCountDownItem>d__42 <InitPrepareCountDownItem>d__;
			<InitPrepareCountDownItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPrepareCountDownItem>d__.<>4__this = this;
			<InitPrepareCountDownItem>d__.<>1__state = -1;
			<InitPrepareCountDownItem>d__.<>t__builder.Start<BigStuffedDollView.<InitPrepareCountDownItem>d__42>(ref <InitPrepareCountDownItem>d__);
			return <InitPrepareCountDownItem>d__.<>t__builder.Task;
		}

		// Token: 0x06045018 RID: 282648 RVA: 0x011F6344 File Offset: 0x011F4544
		private UniTask InitGameCountDownItem()
		{
			BigStuffedDollView.<InitGameCountDownItem>d__43 <InitGameCountDownItem>d__;
			<InitGameCountDownItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitGameCountDownItem>d__.<>4__this = this;
			<InitGameCountDownItem>d__.<>1__state = -1;
			<InitGameCountDownItem>d__.<>t__builder.Start<BigStuffedDollView.<InitGameCountDownItem>d__43>(ref <InitGameCountDownItem>d__);
			return <InitGameCountDownItem>d__.<>t__builder.Task;
		}

		// Token: 0x06045019 RID: 282649 RVA: 0x011F6388 File Offset: 0x011F4588
		private UniTask InitSuccessItem()
		{
			BigStuffedDollView.<InitSuccessItem>d__44 <InitSuccessItem>d__;
			<InitSuccessItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSuccessItem>d__.<>4__this = this;
			<InitSuccessItem>d__.<>1__state = -1;
			<InitSuccessItem>d__.<>t__builder.Start<BigStuffedDollView.<InitSuccessItem>d__44>(ref <InitSuccessItem>d__);
			return <InitSuccessItem>d__.<>t__builder.Task;
		}

		// Token: 0x0604501A RID: 282650 RVA: 0x011F63CC File Offset: 0x011F45CC
		private UniTask InitFailItem()
		{
			BigStuffedDollView.<InitFailItem>d__45 <InitFailItem>d__;
			<InitFailItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFailItem>d__.<>4__this = this;
			<InitFailItem>d__.<>1__state = -1;
			<InitFailItem>d__.<>t__builder.Start<BigStuffedDollView.<InitFailItem>d__45>(ref <InitFailItem>d__);
			return <InitFailItem>d__.<>t__builder.Task;
		}

		// Token: 0x0604501B RID: 282651 RVA: 0x011F6410 File Offset: 0x011F4610
		private UniTask InitTipItem()
		{
			BigStuffedDollView.<InitTipItem>d__46 <InitTipItem>d__;
			<InitTipItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTipItem>d__.<>4__this = this;
			<InitTipItem>d__.<>1__state = -1;
			<InitTipItem>d__.<>t__builder.Start<BigStuffedDollView.<InitTipItem>d__46>(ref <InitTipItem>d__);
			return <InitTipItem>d__.<>t__builder.Task;
		}

		// Token: 0x0604501C RID: 282652 RVA: 0x011F6454 File Offset: 0x011F4654
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnBigStuffedDollGameStageUpdate, new Action<EGameStage>(this.OnGameStageUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.OnBigStuffedDollArrowStayAreaUpdate, new Action<int, int, int>(this.OnArrowStayAreaUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.OnBigStuffedDollRingItemSequencePlayStart, new Action<int, EAreaType, int>(this.RingItemSequenceStart));
		}

		// Token: 0x0604501D RID: 282653 RVA: 0x011F64B8 File Offset: 0x011F46B8
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBigStuffedDollGameStageUpdate, new Action<EGameStage>(this.OnGameStageUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBigStuffedDollArrowStayAreaUpdate, new Action<int, int, int>(this.OnArrowStayAreaUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBigStuffedDollRingItemSequencePlayStart, new Action<int, EAreaType, int>(this.RingItemSequenceStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreePrepareRollbackFinish, new Action<int>(this.OnRollbackFinish));
		}

		// Token: 0x0604501E RID: 282654 RVA: 0x011F6538 File Offset: 0x011F4738
		private void OnGameStageUpdate(EGameStage currentGameStage)
		{
			BigStuffedDollModel instance = ModelBase<BigStuffedDollModel>.Instance;
			SceneTeamModel instance2 = ModelBase<SceneTeamModel>.Instance;
			EntityHandle getCurrentEntity = instance2.GetCurrentEntity;
			if (instance2.IsPhantomTeam && instance2.IsTeamReady && getCurrentEntity != null && getCurrentEntity.Entity != null)
			{
				this.EntityId = getCurrentEntity.Entity.Id;
			}
			switch (currentGameStage)
			{
			case EGameStage.GameReady:
			{
				UUIButtonComponent button = base.GetButton(1);
				if (button != null)
				{
					button.SetSelfInteractive(false);
				}
				UUIButtonComponent button2 = base.GetButton(8);
				if (button2 != null)
				{
					button2.SetSelfInteractive(false);
				}
				ControllerBase<BigStuffedDollController>.Instance.SetBooleanValueThenSendEvent(this.EntityId, "CountDownStart", true);
				this.PrepareCountDownItem.StartCountDown();
				this.TipItem.ShowTips("TeddyBear_Intro", 3000);
				foreach (KeyValuePair<int, BigStuffedRingItem> keyValuePair in this.RingItems)
				{
					keyValuePair.Value.OnArrowExit();
				}
				instance.ArrowEnterNextValidArea();
				return;
			}
			case EGameStage.GamePlaying:
				if (instance.LastGameStage != EGameStage.GamePause)
				{
					this.PrepareCountDownItem.Hide(null);
					int globalTime = instance.GetGlobalTime();
					this.GameCountDownItem.StartCountDown((float)globalTime);
					UUIButtonComponent button3 = base.GetButton(8);
					if (button3 != null)
					{
						button3.SetSelfInteractive(true);
					}
					UUIButtonComponent button4 = base.GetButton(1);
					if (button4 != null)
					{
						button4.SetSelfInteractive(true);
					}
					if (this.EntityId != -1)
					{
						ControllerBase<BigStuffedDollController>.Instance.SetBooleanValueThenSendEvent(this.EntityId, "CountDownOver", true);
						CharacterSkillComponent component = getCurrentEntity.Entity.GetComponent<CharacterSkillComponent>();
						if (component != null)
						{
							OneOf<BrokenRockConfig, BrokenRockConfig> config = instance.Config;
							if (config.HasValue)
							{
								if (config.IsT1)
								{
									component.BeginSkill(config.AsT1.NormalSkill, null);
									return;
								}
								if (config.IsT2)
								{
									component.BeginSkill(config.AsT2.NormalSkill, null);
									return;
								}
							}
						}
					}
				}
				break;
			case EGameStage.GameEnd:
			{
				UUIButtonComponent button5 = base.GetButton(1);
				if (button5 != null)
				{
					button5.SetSelfInteractive(false);
				}
				this.OnGameEnd(instance.GameResult);
				return;
			}
			case EGameStage.GameEndAnim:
				break;
			case EGameStage.Destroy:
				base.CloseMe(null);
				break;
			default:
				return;
			}
		}

		// Token: 0x0604501F RID: 282655 RVA: 0x011F6758 File Offset: 0x011F4958
		private UniTask OnGameEnd(bool success)
		{
			BigStuffedDollView.<OnGameEnd>d__50 <OnGameEnd>d__;
			<OnGameEnd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnGameEnd>d__.<>4__this = this;
			<OnGameEnd>d__.success = success;
			<OnGameEnd>d__.<>1__state = -1;
			<OnGameEnd>d__.<>t__builder.Start<BigStuffedDollView.<OnGameEnd>d__50>(ref <OnGameEnd>d__);
			return <OnGameEnd>d__.<>t__builder.Task;
		}

		// Token: 0x06045020 RID: 282656 RVA: 0x011F67A3 File Offset: 0x011F49A3
		private void OnRollbackFinish(int treeConfigId)
		{
			if (treeConfigId != ModelBase<BigStuffedDollModel>.Instance.BehaviorTreeConfigId)
			{
				return;
			}
			this.GameFailed();
		}

		// Token: 0x06045021 RID: 282657 RVA: 0x011F67BC File Offset: 0x011F49BC
		private UniTask GameFailed()
		{
			BigStuffedDollView.<GameFailed>d__52 <GameFailed>d__;
			<GameFailed>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<GameFailed>d__.<>4__this = this;
			<GameFailed>d__.<>1__state = -1;
			<GameFailed>d__.<>t__builder.Start<BigStuffedDollView.<GameFailed>d__52>(ref <GameFailed>d__);
			return <GameFailed>d__.<>t__builder.Task;
		}

		// Token: 0x06045022 RID: 282658 RVA: 0x011F6800 File Offset: 0x011F4A00
		private void OnArrowStayAreaUpdate(int lastRingId, int ringId, int relativeValidAreaIndex)
		{
			foreach (KeyValuePair<int, BigStuffedRingItem> keyValuePair in this.RingItems)
			{
				BigStuffedRingItem value = keyValuePair.Value;
				if (lastRingId != ringId)
				{
					if (value.Id == lastRingId)
					{
						value.OnArrowExit();
					}
					if (value.Id == ringId)
					{
						value.OnArrowEnter();
					}
				}
				value.OnArrowStayAreaUpdate(relativeValidAreaIndex);
			}
		}

		// Token: 0x06045023 RID: 282659 RVA: 0x011F6880 File Offset: 0x011F4A80
		private void RingItemSequenceStart(int ringId, EAreaType areaType, int continuousIndex)
		{
			BigStuffedRingItem bigStuffedRingItem;
			if (!this.RingItems.TryGetValue(ringId, out bigStuffedRingItem))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "[BigStuffedDoll]RingItemAreaClick:找不到当前的RingItem";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ringId", ringId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			OneOf<BrokenRockRing, BrokenRockRingConfig> config = bigStuffedRingItem.Config;
			if (config == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SceneGameplay;
				ELogAuthor author2 = ELogAuthor.YSQ;
				string message2 = "[BigStuffedDoll]RingItemAreaClick:找不到当前的RingConfig";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ringId", ringId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			BigStuffedDollModel instance3 = ModelBase<BigStuffedDollModel>.Instance;
			switch (areaType)
			{
			case EAreaType.BlankArea:
				this.ProgressItem.AddScore((float)(-(float)instance3.GetScoreDown()), true);
				this.PressFailCount++;
				ControllerBase<BigStuffedDollController>.Instance.SetIntValueThenSendEvent(this.EntityId, "PressFailCount", this.PressFailCount);
				return;
			case EAreaType.GoodArea:
			{
				int num = 0;
				if (config.HasValue)
				{
					if (config.IsT1)
					{
						num = config.AsT1.GoodScore;
					}
					else if (config.IsT2)
					{
						num = config.AsT2.GoodScore;
					}
				}
				this.ProgressItem.AddScore((float)num, true);
				instance3.ArrowEnterNextValidArea();
				bigStuffedRingItem.SpawnContinuousArea(continuousIndex);
				this.PressCommonSuccessCount++;
				ControllerBase<BigStuffedDollController>.Instance.SetIntValueThenSendEvent(this.EntityId, "PressCommonAreaSuccessCount", this.PressCommonSuccessCount);
				return;
			}
			case EAreaType.PerfectArea:
			{
				int num2 = 0;
				if (config.HasValue)
				{
					if (config.IsT1)
					{
						num2 = config.AsT1.PerfectScore;
					}
					else if (config.IsT2)
					{
						num2 = config.AsT2.PerfectScore;
					}
				}
				this.ProgressItem.AddScore((float)num2, true);
				instance3.ArrowEnterNextValidArea();
				bigStuffedRingItem.SpawnContinuousArea(continuousIndex);
				this.PressCommonSuccessCount++;
				ControllerBase<BigStuffedDollController>.Instance.SetIntValueThenSendEvent(this.EntityId, "PressPerfectAreaSuccessCount", this.PressCommonSuccessCount);
				return;
			}
			case EAreaType.BonusArea:
			{
				int num3 = 0;
				if (config.HasValue)
				{
					if (config.IsT1)
					{
						num3 = config.AsT1.BonusScore;
					}
					else if (config.IsT2)
					{
						num3 = config.AsT2.BonusScore;
					}
				}
				this.ProgressItem.AddScore((float)num3, true);
				this.PressBonusSuccessCount++;
				ControllerBase<BigStuffedDollController>.Instance.SetIntValueThenSendEvent(this.EntityId, "PressBonusAreaSuccessCount", this.PressBonusSuccessCount);
				this.EnterBonusState();
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06045024 RID: 282660 RVA: 0x011F6AF4 File Offset: 0x011F4CF4
		private void EnterBonusState()
		{
			this.IsInBonusTime = true;
			this.TipItem.ShowTips("TeddyBear_Bonus", 3000);
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIButtonComponent button = base.GetButton(8);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			UUIButtonComponent qteLeftBtn = this.QteLeftBtn;
			if (qteLeftBtn != null)
			{
				qteLeftBtn.RootUIComp.Get().SetUIActive(true);
			}
			LevelSequencePlayer qteLeftBtnLevelSequence = this.QteLeftBtnLevelSequence;
			if (qteLeftBtnLevelSequence != null)
			{
				qteLeftBtnLevelSequence.PlayLevelSequenceByName("Start", false, null, false);
			}
			UUIButtonComponent qteRightBtn = this.QteRightBtn;
			if (qteRightBtn != null)
			{
				qteRightBtn.RootUIComp.Get().SetUIActive(true);
			}
			LevelSequencePlayer qteRightBtnLevelSequence = this.QteRightBtnLevelSequence;
			if (qteRightBtnLevelSequence == null)
			{
				return;
			}
			qteRightBtnLevelSequence.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x06045025 RID: 282661 RVA: 0x011F6BD0 File Offset: 0x011F4DD0
		private void OnClickBack()
		{
			BigStuffedDollModel model = ModelBase<BigStuffedDollModel>.Instance;
			model.SetGameStage(EGameStage.GamePause);
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BigStuffedBrokenRock);
			confirmBoxDataNew.FunctionMap[2] = new Action(this.OnConfirmExit);
			confirmBoxDataNew.SetCloseFunction(delegate
			{
				model.SetGameStage(model.LastGameStage);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06045026 RID: 282662 RVA: 0x011F6C3C File Offset: 0x011F4E3C
		private void OnConfirmExit()
		{
			ModelBase<BigStuffedDollModel>.Instance.GameResult = false;
			ModelBase<BigStuffedDollModel>.Instance.SetGameStage(EGameStage.GameEnd);
		}

		// Token: 0x06045027 RID: 282663 RVA: 0x011F6C54 File Offset: 0x011F4E54
		private void OnClickCommonQte()
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneGameplay, ELogAuthor.YSQ, "[BigStuffedDoll]QteButton Click", default(ReadOnlySpan<ValueTuple<string, object>>));
			BigStuffedGameInfo gameInfo = ModelBase<BigStuffedDollModel>.Instance.GameInfo;
			int currentArrowStayRingId = gameInfo.CurrentArrowStayRingId;
			BigStuffedRingInfo ringInfo = gameInfo.GetRingInfo(currentArrowStayRingId);
			if (ringInfo == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "[BigStuffedDoll]QteButtonClick:找不到当前所在的圆环";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ringId", gameInfo.CurrentArrowStayRingId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			int currentArrowStayCellIndex = gameInfo.CurrentArrowStayCellIndex;
			ContinuousArea continuousArea = this.CheckInArea(ringInfo.GetBonusAreas(), currentArrowStayCellIndex);
			if (continuousArea != null)
			{
				this.OnAreaClick(EAreaType.BonusArea, continuousArea);
				return;
			}
			ContinuousArea continuousArea2 = this.CheckInArea(ringInfo.GetPerfectAreas(), currentArrowStayCellIndex);
			if (continuousArea2 != null)
			{
				this.OnAreaClick(EAreaType.PerfectArea, continuousArea2);
				return;
			}
			ContinuousArea continuousArea3 = this.CheckInArea(ringInfo.GetGoodAreas(), currentArrowStayCellIndex);
			if (continuousArea3 != null)
			{
				this.OnAreaClick(EAreaType.GoodArea, continuousArea3);
				return;
			}
			this.OnAreaClick(EAreaType.BlankArea, null);
		}

		// Token: 0x06045028 RID: 282664 RVA: 0x011F6D33 File Offset: 0x011F4F33
		private void OnClickLeftBonusQte()
		{
			this.OnClickBonusBtn(BigStuffedDollView.EBonusBtnType.Left);
		}

		// Token: 0x06045029 RID: 282665 RVA: 0x011F6D3C File Offset: 0x011F4F3C
		private void OnClickRightBonusQte()
		{
			this.OnClickBonusBtn(BigStuffedDollView.EBonusBtnType.Right);
		}

		// Token: 0x0604502A RID: 282666 RVA: 0x011F6D48 File Offset: 0x011F4F48
		private void OnClickBonusBtn(BigStuffedDollView.EBonusBtnType buttonType)
		{
			if (!this.IsInBonusTime)
			{
				return;
			}
			int currentArrowStayRingId = ModelBase<BigStuffedDollModel>.Instance.GameInfo.CurrentArrowStayRingId;
			BigStuffedRingItem bigStuffedRingItem;
			this.RingItems.TryGetValue(currentArrowStayRingId, out bigStuffedRingItem);
			OneOf<BrokenRockRing, BrokenRockRingConfig>? oneOf = (bigStuffedRingItem != null) ? new OneOf<BrokenRockRing, BrokenRockRingConfig>?(bigStuffedRingItem.Config) : null;
			if (oneOf != null)
			{
				int num = 0;
				if (oneOf != null)
				{
					if (oneOf.Value.IsT1)
					{
						num = oneOf.Value.AsT1.BonusScore;
					}
					else if (oneOf.Value.IsT2)
					{
						num = oneOf.Value.AsT2.BonusScore;
					}
				}
				this.ProgressItem.AddScore((float)num, true);
			}
			if (buttonType != BigStuffedDollView.EBonusBtnType.Left)
			{
				if (buttonType != BigStuffedDollView.EBonusBtnType.Right)
				{
					return;
				}
				LevelSequencePlayer qteRightBtnLevelSequence = this.QteRightBtnLevelSequence;
				if (qteRightBtnLevelSequence != null)
				{
					qteRightBtnLevelSequence.StopCurrentSequence(false, true);
				}
				LevelSequencePlayer qteRightBtnLevelSequence2 = this.QteRightBtnLevelSequence;
				if (qteRightBtnLevelSequence2 == null)
				{
					return;
				}
				qteRightBtnLevelSequence2.PlayLevelSequenceByName("Press", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer qteLeftBtnLevelSequence = this.QteLeftBtnLevelSequence;
				if (qteLeftBtnLevelSequence != null)
				{
					qteLeftBtnLevelSequence.StopCurrentSequence(false, true);
				}
				LevelSequencePlayer qteLeftBtnLevelSequence2 = this.QteLeftBtnLevelSequence;
				if (qteLeftBtnLevelSequence2 == null)
				{
					return;
				}
				qteLeftBtnLevelSequence2.PlayLevelSequenceByName("Press", false, null, false);
				return;
			}
		}

		// Token: 0x0604502B RID: 282667 RVA: 0x011F6E84 File Offset: 0x011F5084
		[return: Nullable(2)]
		private ContinuousArea CheckInArea(Dictionary<int, ContinuousArea> areas, int currentArrowStayCellIndex)
		{
			foreach (KeyValuePair<int, ContinuousArea> keyValuePair in areas)
			{
				ContinuousArea value = keyValuePair.Value;
				int startCellIndex = value.StartCellIndex;
				int endCellIndex = value.EndCellIndex;
				if (endCellIndex >= startCellIndex)
				{
					if (currentArrowStayCellIndex >= startCellIndex && currentArrowStayCellIndex <= endCellIndex)
					{
						return value;
					}
				}
				else
				{
					bool flag = currentArrowStayCellIndex >= startCellIndex && currentArrowStayCellIndex <= 36;
					bool flag2 = currentArrowStayCellIndex >= 1 && currentArrowStayCellIndex <= endCellIndex;
					if (flag || flag2)
					{
						return value;
					}
				}
			}
			return null;
		}

		// Token: 0x0604502C RID: 282668 RVA: 0x011F6F2C File Offset: 0x011F512C
		[NullableContext(2)]
		private void OnAreaClick(EAreaType areaType, ContinuousArea area)
		{
			BigStuffedGameInfo gameInfo = ModelBase<BigStuffedDollModel>.Instance.GameInfo;
			int currentArrowStayRingId = gameInfo.CurrentArrowStayRingId;
			BigStuffedRingItem bigStuffedRingItem;
			if (!this.RingItems.TryGetValue(currentArrowStayRingId, out bigStuffedRingItem))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "[BigStuffedDoll]OnAreaClick:找不到当前的RingItem";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ringId", gameInfo.CurrentArrowStayRingId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			OneOf<BrokenRockRing, BrokenRockRingConfig> config = bigStuffedRingItem.Config;
			if (config == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SceneGameplay;
				ELogAuthor author2 = ELogAuthor.YSQ;
				string message2 = "[BigStuffedDoll]OnAreaClick:找不到当前的RingConfig";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ringId", gameInfo.CurrentArrowStayRingId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			int num = 0;
			if (config.HasValue)
			{
				if (config.IsT1)
				{
					num = config.AsT1.ColdTime;
				}
				else if (config.IsT2)
				{
					num = config.AsT2.ColdTime;
				}
			}
			if (Singleton<TimeUtil>.Instance.GetServerStopTimeStamp() - this.LastClickAreaTime <= (double)num)
			{
				return;
			}
			this.LastClickAreaTime = Singleton<TimeUtil>.Instance.GetServerStopTimeStamp();
			UUIButtonComponent button = base.GetButton(8);
			UUIButtonComponent button3 = button;
			if (button3 != null)
			{
				button3.SetSelfInteractive(false);
			}
			TimerSystem.Instance.Delay(delegate(float _)
			{
				UUIButtonComponent button2 = button;
				if (button2 == null)
				{
					return;
				}
				button2.SetSelfInteractive(true);
			}, (float)num, null, null, true, 1f);
			bigStuffedRingItem.OnAreaClick(areaType, area);
		}

		// Token: 0x0604502D RID: 282669 RVA: 0x011F708C File Offset: 0x011F528C
		private void OnQteLeftBtnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Start" || sequenceName == "Press")
			{
				this.QteLeftBtnLevelSequence.PlayLevelSequenceByName("Loop", false, null, false);
			}
		}

		// Token: 0x0604502E RID: 282670 RVA: 0x011F70D0 File Offset: 0x011F52D0
		private void OnQteRightBtnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Start" || sequenceName == "Press")
			{
				this.QteRightBtnLevelSequence.PlayLevelSequenceByName("Loop", false, null, false);
			}
		}

		// Token: 0x040267C0 RID: 157632
		private const int BONUS_TIME_TIPSTAYTIME = 3000;

		// Token: 0x040267C1 RID: 157633
		private const string COUNTDOWNSTART = "CountDownStart";

		// Token: 0x040267C2 RID: 157634
		private const string COUNTDOWNOVER = "CountDownOver";

		// Token: 0x040267C3 RID: 157635
		private const string GAMEOVER = "GameOver";

		// Token: 0x040267C4 RID: 157636
		private const string PRESS_FAIL_COUNT = "PressFailCount";

		// Token: 0x040267C5 RID: 157637
		private const string PRESS_COMMONAREA_SUCCESS_COUNT = "PressCommonAreaSuccessCount";

		// Token: 0x040267C6 RID: 157638
		private const string PRESS_PERFECTAREA_SUCCESS_COUNT = "PressPerfectAreaSuccessCount";

		// Token: 0x040267C7 RID: 157639
		private const string PRESS_BONUSAREA_SUCCESS_COUNT = "PressBonusAreaSuccessCount";

		// Token: 0x040267C8 RID: 157640
		private const string FINISH_SKILL_OVER = "FinishSkillOver";

		// Token: 0x040267C9 RID: 157641
		private const string DELAY_FINISH_TIME = "DelayFinishTime";

		// Token: 0x040267CA RID: 157642
		private const string QTE_ROCK_DESTORY_EVENT = "BrokenRockEventKey6";

		// Token: 0x040267CB RID: 157643
		private readonly Dictionary<int, BigStuffedRingItem> RingItems = new Dictionary<int, BigStuffedRingItem>();

		// Token: 0x040267CC RID: 157644
		private readonly BigStuffedDollProgressItem ProgressItem = new BigStuffedDollProgressItem();

		// Token: 0x040267CD RID: 157645
		private readonly PrepareCountDownItem PrepareCountDownItem = new PrepareCountDownItem();

		// Token: 0x040267CE RID: 157646
		private readonly GameCountDownItem GameCountDownItem = new GameCountDownItem();

		// Token: 0x040267CF RID: 157647
		private readonly BigStuffedDollTipItem TipItem = new BigStuffedDollTipItem();

		// Token: 0x040267D0 RID: 157648
		private readonly BigStuffedDollChallengeSuccessItem GameSuccessItem = new BigStuffedDollChallengeSuccessItem();

		// Token: 0x040267D1 RID: 157649
		private readonly BigStuffedDollChallengeFailItem GameFailItem = new BigStuffedDollChallengeFailItem();

		// Token: 0x040267D2 RID: 157650
		private double LastClickAreaTime;

		// Token: 0x040267D3 RID: 157651
		private bool IsInBonusTime;

		// Token: 0x040267D4 RID: 157652
		[Nullable(2)]
		private UUIButtonComponent QteLeftBtn;

		// Token: 0x040267D5 RID: 157653
		[Nullable(2)]
		private UUIButtonComponent QteRightBtn;

		// Token: 0x040267D6 RID: 157654
		[Nullable(2)]
		private LevelSequencePlayer QteLeftBtnLevelSequence;

		// Token: 0x040267D7 RID: 157655
		[Nullable(2)]
		private LevelSequencePlayer QteRightBtnLevelSequence;

		// Token: 0x040267D8 RID: 157656
		private int EntityId = -1;

		// Token: 0x040267D9 RID: 157657
		private int PressCommonSuccessCount;

		// Token: 0x040267DA RID: 157658
		private int PressBonusSuccessCount;

		// Token: 0x040267DB RID: 157659
		private int PressFailCount;

		// Token: 0x040267DC RID: 157660
		[Nullable(2)]
		private Action FinishCallback;

		// Token: 0x040267DD RID: 157661
		private bool IsExecutedFinish;

		// Token: 0x0200CBE7 RID: 52199
		[NullableContext(0)]
		private class EViewComponent
		{
			// Token: 0x0403E87A RID: 256122
			public const int GameUiRoot = 0;

			// Token: 0x0403E87B RID: 256123
			public const int BackBtn = 1;

			// Token: 0x0403E87C RID: 256124
			public const int ProgressItem = 2;

			// Token: 0x0403E87D RID: 256125
			public const int QteLeftBtn = 3;

			// Token: 0x0403E87E RID: 256126
			public const int QteRightBtn = 4;

			// Token: 0x0403E87F RID: 256127
			public const int RingItemRoot = 5;

			// Token: 0x0403E880 RID: 256128
			public const int RingItem = 6;

			// Token: 0x0403E881 RID: 256129
			public const int QteTipItem = 7;

			// Token: 0x0403E882 RID: 256130
			public const int BtnSingleQte = 8;
		}

		// Token: 0x0200CBE8 RID: 52200
		[NullableContext(0)]
		private enum EBonusBtnType
		{
			// Token: 0x0403E884 RID: 256132
			Left,
			// Token: 0x0403E885 RID: 256133
			Right
		}
	}
}
