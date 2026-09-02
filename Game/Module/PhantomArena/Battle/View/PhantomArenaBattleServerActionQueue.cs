using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.Guide;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View
{
	// Token: 0x020055B0 RID: 21936
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleServerActionQueue
	{
		// Token: 0x06037D6F RID: 228719 RVA: 0x00E2531C File Offset: 0x00E2351C
		public PhantomArenaBattleServerActionQueue(PhantomArenaBattleProxy proxy)
		{
			this.Proxy = proxy;
		}

		// Token: 0x06037D70 RID: 228720 RVA: 0x00E25338 File Offset: 0x00E23538
		public void PushFourTaskAction(PhantomBattleHandCardInfo data)
		{
			PhantomArenaBattleServerActionQueue.<>c__DisplayClass6_0 CS$<>8__locals1 = new PhantomArenaBattleServerActionQueue.<>c__DisplayClass6_0();
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.<>4__this = this;
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "服务器推送4c任务,推送到行为队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			TServerAction item = delegate()
			{
				PhantomArenaBattleServerActionQueue.<>c__DisplayClass6_0.<<PushFourTaskAction>b__0>d <<PushFourTaskAction>b__0>d;
				<<PushFourTaskAction>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<PushFourTaskAction>b__0>d.<>4__this = CS$<>8__locals1;
				<<PushFourTaskAction>b__0>d.<>1__state = -1;
				<<PushFourTaskAction>b__0>d.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<>c__DisplayClass6_0.<<PushFourTaskAction>b__0>d>(ref <<PushFourTaskAction>b__0>d);
				return <<PushFourTaskAction>b__0>d.<>t__builder.Task;
			};
			ServerAction serverAction = new ServerAction
			{
				ActionList = new List<TServerAction>
				{
					item
				},
				Type = EServerActionType.FourTask
			};
			this.AddActionQueue(serverAction);
		}

		// Token: 0x06037D71 RID: 228721 RVA: 0x00E253AC File Offset: 0x00E235AC
		public void PushChooseCardAction(PhantomBattleCardSelectEffectCtx data)
		{
			PhantomArenaBattleServerActionQueue.<>c__DisplayClass7_0 CS$<>8__locals1 = new PhantomArenaBattleServerActionQueue.<>c__DisplayClass7_0();
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.<>4__this = this;
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "服务器推送抽卡行为,推送到行为队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			TServerAction item = delegate()
			{
				PhantomArenaBattleServerActionQueue.<>c__DisplayClass7_0.<<PushChooseCardAction>b__0>d <<PushChooseCardAction>b__0>d;
				<<PushChooseCardAction>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<PushChooseCardAction>b__0>d.<>4__this = CS$<>8__locals1;
				<<PushChooseCardAction>b__0>d.<>1__state = -1;
				<<PushChooseCardAction>b__0>d.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<>c__DisplayClass7_0.<<PushChooseCardAction>b__0>d>(ref <<PushChooseCardAction>b__0>d);
				return <<PushChooseCardAction>b__0>d.<>t__builder.Task;
			};
			ServerAction serverAction = new ServerAction
			{
				ActionList = new List<TServerAction>
				{
					item
				},
				Type = EServerActionType.ChooseCard
			};
			this.AddActionQueue(serverAction);
		}

		// Token: 0x06037D72 RID: 228722 RVA: 0x00E25420 File Offset: 0x00E23620
		public void PushDiscardCardAction(PhantomBattleDiscardCardNotify data)
		{
			PhantomArenaBattleServerActionQueue.<>c__DisplayClass8_0 CS$<>8__locals1 = new PhantomArenaBattleServerActionQueue.<>c__DisplayClass8_0();
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.<>4__this = this;
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "服务器推送弃牌行为,推送到行为队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			TServerAction item = delegate()
			{
				PhantomArenaBattleServerActionQueue.<>c__DisplayClass8_0.<<PushDiscardCardAction>b__0>d <<PushDiscardCardAction>b__0>d;
				<<PushDiscardCardAction>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<PushDiscardCardAction>b__0>d.<>4__this = CS$<>8__locals1;
				<<PushDiscardCardAction>b__0>d.<>1__state = -1;
				<<PushDiscardCardAction>b__0>d.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<>c__DisplayClass8_0.<<PushDiscardCardAction>b__0>d>(ref <<PushDiscardCardAction>b__0>d);
				return <<PushDiscardCardAction>b__0>d.<>t__builder.Task;
			};
			ServerAction serverAction = new ServerAction
			{
				ActionList = new List<TServerAction>
				{
					item
				},
				Type = EServerActionType.DiscardCard
			};
			this.AddActionQueue(serverAction);
		}

		// Token: 0x06037D73 RID: 228723 RVA: 0x00E25494 File Offset: 0x00E23694
		public void PushReserveCardAction(PhantomBattleSelectReserveCardNotify data)
		{
			PhantomArenaBattleServerActionQueue.<>c__DisplayClass9_0 CS$<>8__locals1 = new PhantomArenaBattleServerActionQueue.<>c__DisplayClass9_0();
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.<>4__this = this;
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "服务器推送保留卡行为,推送到行为队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			TServerAction item = delegate()
			{
				PhantomArenaBattleServerActionQueue.<>c__DisplayClass9_0.<<PushReserveCardAction>b__0>d <<PushReserveCardAction>b__0>d;
				<<PushReserveCardAction>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<PushReserveCardAction>b__0>d.<>4__this = CS$<>8__locals1;
				<<PushReserveCardAction>b__0>d.<>1__state = -1;
				<<PushReserveCardAction>b__0>d.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<>c__DisplayClass9_0.<<PushReserveCardAction>b__0>d>(ref <<PushReserveCardAction>b__0>d);
				return <<PushReserveCardAction>b__0>d.<>t__builder.Task;
			};
			ServerAction serverAction = new ServerAction
			{
				ActionList = new List<TServerAction>
				{
					item
				},
				Type = EServerActionType.ReserveCard
			};
			this.AddActionQueue(serverAction);
		}

		// Token: 0x06037D74 RID: 228724 RVA: 0x00E25508 File Offset: 0x00E23708
		public void PushBattleCallCardAction(PhantomBattleCallCardNotify data)
		{
			PhantomArenaBattleServerActionQueue.<>c__DisplayClass10_0 CS$<>8__locals1 = new PhantomArenaBattleServerActionQueue.<>c__DisplayClass10_0();
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.<>4__this = this;
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "服务器推送召唤卡行为,推送到行为队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			TServerAction item = delegate()
			{
				PhantomArenaBattleServerActionQueue.<>c__DisplayClass10_0.<<PushBattleCallCardAction>b__0>d <<PushBattleCallCardAction>b__0>d;
				<<PushBattleCallCardAction>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<PushBattleCallCardAction>b__0>d.<>4__this = CS$<>8__locals1;
				<<PushBattleCallCardAction>b__0>d.<>1__state = -1;
				<<PushBattleCallCardAction>b__0>d.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<>c__DisplayClass10_0.<<PushBattleCallCardAction>b__0>d>(ref <<PushBattleCallCardAction>b__0>d);
				return <<PushBattleCallCardAction>b__0>d.<>t__builder.Task;
			};
			ServerAction serverAction = new ServerAction
			{
				ActionList = new List<TServerAction>
				{
					item
				},
				Type = EServerActionType.BattleCallCard
			};
			this.AddActionQueue(serverAction);
		}

		// Token: 0x06037D75 RID: 228725 RVA: 0x00E2557C File Offset: 0x00E2377C
		public void PushBattleCallCardShowAction(PhantomBattleSelectedCardFromType type, List<PhantomBattleFighterInfo> resultList)
		{
			PhantomArenaBattleServerActionQueue.<>c__DisplayClass11_0 CS$<>8__locals1 = new PhantomArenaBattleServerActionQueue.<>c__DisplayClass11_0();
			CS$<>8__locals1.type = type;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.resultList = resultList;
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "服务器推送召唤卡展示行为,推送到行为队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			CS$<>8__locals1.cardIdList = new List<int>();
			foreach (PhantomBattleFighterInfo phantomBattleFighterInfo in CS$<>8__locals1.resultList)
			{
				CS$<>8__locals1.cardIdList.Add(phantomBattleFighterInfo.UId);
			}
			ModelBase<PhantomArenaBattleModel>.Instance.AddWaitCallCardIdList(CS$<>8__locals1.cardIdList);
			TServerAction item = delegate()
			{
				PhantomArenaBattleServerActionQueue.<>c__DisplayClass11_0.<<PushBattleCallCardShowAction>b__0>d <<PushBattleCallCardShowAction>b__0>d;
				<<PushBattleCallCardShowAction>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<PushBattleCallCardShowAction>b__0>d.<>4__this = CS$<>8__locals1;
				<<PushBattleCallCardShowAction>b__0>d.<>1__state = -1;
				<<PushBattleCallCardShowAction>b__0>d.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<>c__DisplayClass11_0.<<PushBattleCallCardShowAction>b__0>d>(ref <<PushBattleCallCardShowAction>b__0>d);
				return <<PushBattleCallCardShowAction>b__0>d.<>t__builder.Task;
			};
			ServerAction serverAction = new ServerAction
			{
				ActionList = new List<TServerAction>
				{
					item
				},
				Type = EServerActionType.BattleCallCardShow
			};
			this.AddActionQueue(serverAction);
		}

		// Token: 0x06037D76 RID: 228726 RVA: 0x00E25664 File Offset: 0x00E23864
		public void PushReconstructCardAction(PhantomBattleReconstructCardNotify data)
		{
			PhantomArenaBattleServerActionQueue.<>c__DisplayClass12_0 CS$<>8__locals1 = new PhantomArenaBattleServerActionQueue.<>c__DisplayClass12_0();
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.<>4__this = this;
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "服务器推送重构卡牌行为,推送到行为队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			TServerAction item = delegate()
			{
				PhantomArenaBattleServerActionQueue.<>c__DisplayClass12_0.<<PushReconstructCardAction>b__0>d <<PushReconstructCardAction>b__0>d;
				<<PushReconstructCardAction>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<PushReconstructCardAction>b__0>d.<>4__this = CS$<>8__locals1;
				<<PushReconstructCardAction>b__0>d.<>1__state = -1;
				<<PushReconstructCardAction>b__0>d.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<>c__DisplayClass12_0.<<PushReconstructCardAction>b__0>d>(ref <<PushReconstructCardAction>b__0>d);
				return <<PushReconstructCardAction>b__0>d.<>t__builder.Task;
			};
			ServerAction serverAction = new ServerAction
			{
				ActionList = new List<TServerAction>
				{
					item
				},
				Type = EServerActionType.ReconstructCard
			};
			this.AddActionQueue(serverAction);
		}

		// Token: 0x06037D77 RID: 228727 RVA: 0x00E256D8 File Offset: 0x00E238D8
		public void PushTriggerPassiveSkillInteractAction(PhantomBattleSelectTargetEffectNotify data)
		{
			PhantomArenaBattleServerActionQueue.<>c__DisplayClass13_0 CS$<>8__locals1 = new PhantomArenaBattleServerActionQueue.<>c__DisplayClass13_0();
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.<>4__this = this;
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "服务器推送被动技能选择行为,推送到行为队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			TServerAction item = delegate()
			{
				PhantomArenaBattleServerActionQueue.<>c__DisplayClass13_0.<<PushTriggerPassiveSkillInteractAction>b__0>d <<PushTriggerPassiveSkillInteractAction>b__0>d;
				<<PushTriggerPassiveSkillInteractAction>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<PushTriggerPassiveSkillInteractAction>b__0>d.<>4__this = CS$<>8__locals1;
				<<PushTriggerPassiveSkillInteractAction>b__0>d.<>1__state = -1;
				<<PushTriggerPassiveSkillInteractAction>b__0>d.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<>c__DisplayClass13_0.<<PushTriggerPassiveSkillInteractAction>b__0>d>(ref <<PushTriggerPassiveSkillInteractAction>b__0>d);
				return <<PushTriggerPassiveSkillInteractAction>b__0>d.<>t__builder.Task;
			};
			ServerAction serverAction = new ServerAction
			{
				ActionList = new List<TServerAction>
				{
					item
				},
				Type = EServerActionType.TriggerPassiveSkillInteract
			};
			this.AddActionQueue(serverAction);
		}

		// Token: 0x06037D78 RID: 228728 RVA: 0x00E2574C File Offset: 0x00E2394C
		public void PushSkillEffectAction()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "服务器推送技能效果行为,推送到行为队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			TServerAction item = delegate()
			{
				PhantomArenaBattleServerActionQueue.<<PushSkillEffectAction>b__14_0>d <<PushSkillEffectAction>b__14_0>d;
				<<PushSkillEffectAction>b__14_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<PushSkillEffectAction>b__14_0>d.<>4__this = this;
				<<PushSkillEffectAction>b__14_0>d.<>1__state = -1;
				<<PushSkillEffectAction>b__14_0>d.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<<PushSkillEffectAction>b__14_0>d>(ref <<PushSkillEffectAction>b__14_0>d);
				return <<PushSkillEffectAction>b__14_0>d.<>t__builder.Task;
			};
			ServerAction serverAction = new ServerAction
			{
				ActionList = new List<TServerAction>
				{
					item
				},
				Type = EServerActionType.SkillEffect
			};
			this.AddActionQueue(serverAction);
		}

		// Token: 0x06037D79 RID: 228729 RVA: 0x00E257AC File Offset: 0x00E239AC
		public void PushFieldSkillEffectAction()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "推送领域技能效果行为,推送到行为队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			TServerAction item = delegate()
			{
				PhantomArenaBattleServerActionQueue.<<PushFieldSkillEffectAction>b__15_0>d <<PushFieldSkillEffectAction>b__15_0>d;
				<<PushFieldSkillEffectAction>b__15_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<PushFieldSkillEffectAction>b__15_0>d.<>4__this = this;
				<<PushFieldSkillEffectAction>b__15_0>d.<>1__state = -1;
				<<PushFieldSkillEffectAction>b__15_0>d.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<<PushFieldSkillEffectAction>b__15_0>d>(ref <<PushFieldSkillEffectAction>b__15_0>d);
				return <<PushFieldSkillEffectAction>b__15_0>d.<>t__builder.Task;
			};
			ServerAction serverAction = new ServerAction
			{
				ActionList = new List<TServerAction>
				{
					item
				},
				Type = EServerActionType.FieldSkillEffect
			};
			this.AddActionQueue(serverAction);
		}

		// Token: 0x06037D7A RID: 228730 RVA: 0x00E2580C File Offset: 0x00E23A0C
		public void PushCardDurableEmptyAction(PhantomBattleCardDurableEmptyNotify data)
		{
			PhantomArenaBattleServerActionQueue.<>c__DisplayClass16_0 CS$<>8__locals1 = new PhantomArenaBattleServerActionQueue.<>c__DisplayClass16_0();
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.<>4__this = this;
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "服务器推送卡牌耐久空通知,推送到行为队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelBase<PhantomArenaBattleModel>.Instance.AddWaitReconstructCardIdList(new List<int>
			{
				CS$<>8__locals1.data.CardUid
			});
			TServerAction item = delegate()
			{
				PhantomArenaBattleServerActionQueue.<>c__DisplayClass16_0.<<PushCardDurableEmptyAction>b__0>d <<PushCardDurableEmptyAction>b__0>d;
				<<PushCardDurableEmptyAction>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<PushCardDurableEmptyAction>b__0>d.<>4__this = CS$<>8__locals1;
				<<PushCardDurableEmptyAction>b__0>d.<>1__state = -1;
				<<PushCardDurableEmptyAction>b__0>d.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<>c__DisplayClass16_0.<<PushCardDurableEmptyAction>b__0>d>(ref <<PushCardDurableEmptyAction>b__0>d);
				return <<PushCardDurableEmptyAction>b__0>d.<>t__builder.Task;
			};
			ServerAction serverAction = new ServerAction
			{
				ActionList = new List<TServerAction>
				{
					item
				},
				Type = EServerActionType.CardDurableEmpty
			};
			this.AddActionQueue(serverAction);
		}

		// Token: 0x06037D7B RID: 228731 RVA: 0x00E258A0 File Offset: 0x00E23AA0
		public void PushCountSkillEffectAction(int cardId, int curEffectCount)
		{
			PhantomArenaBattleServerActionQueue.<>c__DisplayClass17_0 CS$<>8__locals1 = new PhantomArenaBattleServerActionQueue.<>c__DisplayClass17_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.cardId = cardId;
			CS$<>8__locals1.curEffectCount = curEffectCount;
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "服推送卡牌计数表现,推送到行为队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			TServerAction item = delegate()
			{
				PhantomArenaBattleServerActionQueue.<>c__DisplayClass17_0.<<PushCountSkillEffectAction>b__0>d <<PushCountSkillEffectAction>b__0>d;
				<<PushCountSkillEffectAction>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<PushCountSkillEffectAction>b__0>d.<>4__this = CS$<>8__locals1;
				<<PushCountSkillEffectAction>b__0>d.<>1__state = -1;
				<<PushCountSkillEffectAction>b__0>d.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<>c__DisplayClass17_0.<<PushCountSkillEffectAction>b__0>d>(ref <<PushCountSkillEffectAction>b__0>d);
				return <<PushCountSkillEffectAction>b__0>d.<>t__builder.Task;
			};
			if (this.ActionQueue.Size > 0)
			{
				IServerAction serverAction = this.ActionQueue.Pop();
				if (serverAction != null && serverAction.Type == EServerActionType.CountSkillEffect)
				{
					CountEffectServerActionList countEffectServerActionList = (CountEffectServerActionList)serverAction;
					if (countEffectServerActionList != null)
					{
						foreach (int num in countEffectServerActionList.CardIdList)
						{
							if (CS$<>8__locals1.cardId == num)
							{
								CountEffectServerActionList serverAction2 = new CountEffectServerActionList
								{
									ActionList = new List<TServerAction>
									{
										item
									},
									Type = EServerActionType.CountSkillEffect,
									CardIdList = new List<int>
									{
										CS$<>8__locals1.cardId
									}
								};
								this.AddActionQueue(serverAction2);
								return;
							}
						}
						countEffectServerActionList.ActionList.Add(item);
						Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "服务器卡牌计数表现插入到最尾部已存在的行为列表中", default(ReadOnlySpan<ValueTuple<string, object>>));
						return;
					}
				}
			}
			CountEffectServerActionList serverAction3 = new CountEffectServerActionList
			{
				ActionList = new List<TServerAction>
				{
					item
				},
				Type = EServerActionType.CountSkillEffect,
				CardIdList = new List<int>
				{
					CS$<>8__locals1.cardId
				}
			};
			this.AddActionQueue(serverAction3);
		}

		// Token: 0x06037D7C RID: 228732 RVA: 0x00E25A34 File Offset: 0x00E23C34
		public void PushBattleResultAction(PhantomBattleBoardSettleNotify data)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "服务器推送战斗结果行为,推送到行为队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
			TServerAction item = delegate()
			{
				Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "执行服务器战斗结果行为开始", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<PhantomArenaBattleController>.Instance.TriggerPhantomBattleResultShow(data);
				Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "执行服务器战斗结果行为完成", default(ReadOnlySpan<ValueTuple<string, object>>));
				return UniTask.CompletedTask;
			};
			ServerAction serverAction = new ServerAction
			{
				ActionList = new List<TServerAction>
				{
					item
				},
				Type = EServerActionType.BattleResult
			};
			this.AddActionQueue(serverAction);
		}

		// Token: 0x06037D7D RID: 228733 RVA: 0x00E25AA0 File Offset: 0x00E23CA0
		public void PauseAction()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "执行服务器行为暂停", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsInPause = true;
		}

		// Token: 0x06037D7E RID: 228734 RVA: 0x00E25AD4 File Offset: 0x00E23CD4
		public UniTask ResumeAction()
		{
			PhantomArenaBattleServerActionQueue.<ResumeAction>d__20 <ResumeAction>d__;
			<ResumeAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResumeAction>d__.<>4__this = this;
			<ResumeAction>d__.<>1__state = -1;
			<ResumeAction>d__.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<ResumeAction>d__20>(ref <ResumeAction>d__);
			return <ResumeAction>d__.<>t__builder.Task;
		}

		// Token: 0x06037D7F RID: 228735 RVA: 0x00E25B17 File Offset: 0x00E23D17
		public bool InAction()
		{
			return this.IsInAction;
		}

		// Token: 0x06037D80 RID: 228736 RVA: 0x00E25B20 File Offset: 0x00E23D20
		public UniTask WaitHandleFinish()
		{
			PhantomArenaBattleServerActionQueue.<WaitHandleFinish>d__22 <WaitHandleFinish>d__;
			<WaitHandleFinish>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitHandleFinish>d__.<>4__this = this;
			<WaitHandleFinish>d__.<>1__state = -1;
			<WaitHandleFinish>d__.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<WaitHandleFinish>d__22>(ref <WaitHandleFinish>d__);
			return <WaitHandleFinish>d__.<>t__builder.Task;
		}

		// Token: 0x06037D81 RID: 228737 RVA: 0x00E25B64 File Offset: 0x00E23D64
		protected UniTask HandleAction()
		{
			PhantomArenaBattleServerActionQueue.<HandleAction>d__23 <HandleAction>d__;
			<HandleAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleAction>d__.<>4__this = this;
			<HandleAction>d__.<>1__state = -1;
			<HandleAction>d__.<>t__builder.Start<PhantomArenaBattleServerActionQueue.<HandleAction>d__23>(ref <HandleAction>d__);
			return <HandleAction>d__.<>t__builder.Task;
		}

		// Token: 0x06037D82 RID: 228738 RVA: 0x00E25BA7 File Offset: 0x00E23DA7
		protected void AddActionQueue(IServerAction serverAction)
		{
			if (this.HandleActionPromise == null)
			{
				this.HandleActionPromise = new CustomPromise();
			}
			this.ActionQueue.Push(serverAction);
			this.HandleAction().Forget();
		}

		// Token: 0x06037D83 RID: 228739 RVA: 0x00E25BD4 File Offset: 0x00E23DD4
		protected void TryFinishGuide(int cardId, int? skillId = null)
		{
			PhantomArenaGuideCardSkillData phantomArenaGuideCardSkillData = new PhantomArenaGuideCardSkillData
			{
				CardId = cardId
			};
			this.Proxy.GuideManager.TryFinishGuideByType(EBvbPlayerOperationType.BvbUseItemCardSkill, new object[]
			{
				phantomArenaGuideCardSkillData
			});
			this.Proxy.GuideManager.TryFinishGuideByType(EBvbPlayerOperationType.BvbUseFieldCardSkill, new object[]
			{
				phantomArenaGuideCardSkillData
			});
		}

		// Token: 0x0401FF89 RID: 130953
		protected Queue<IServerAction> ActionQueue = new Queue<IServerAction>(4);

		// Token: 0x0401FF8A RID: 130954
		protected bool IsInAction;

		// Token: 0x0401FF8B RID: 130955
		protected bool IsInPause;

		// Token: 0x0401FF8C RID: 130956
		[Nullable(2)]
		protected CustomPromise HandleActionPromise;

		// Token: 0x0401FF8D RID: 130957
		protected PhantomArenaBattleProxy Proxy;
	}
}
