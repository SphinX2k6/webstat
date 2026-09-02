using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CF4 RID: 23796
	public class SpringManorGameplayCloseNode : ChildQuestNodeBase
	{
		// Token: 0x0603BFCD RID: 245709 RVA: 0x00F364EF File Offset: 0x00F346EF
		public SpringManorGameplayCloseNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BFCE RID: 245710 RVA: 0x00F364F8 File Offset: 0x00F346F8
		[NullableContext(1)]
		protected override bool OnCreate(IBtNode nodeConfig)
		{
			IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return false;
			}
			if (!base.OnCreate(nodeConfig))
			{
				return false;
			}
			ICheckSpringFestivalGameplayCompleted checkSpringFestivalGameplayCompleted = childQuestBtNode.Condition as ICheckSpringFestivalGameplayCompleted;
			if (checkSpringFestivalGameplayCompleted == null)
			{
				return false;
			}
			this.GameplayType = new ESpringFestivalGameplayType?(checkSpringFestivalGameplayCompleted.GameplayType.Type);
			ICheckSpringFestivalGameplayType gameplayType = checkSpringFestivalGameplayCompleted.GameplayType;
			ICheckSpringFestivalMixDrinksCompleted checkSpringFestivalMixDrinksCompleted = gameplayType as ICheckSpringFestivalMixDrinksCompleted;
			if (checkSpringFestivalMixDrinksCompleted == null)
			{
				ICheckSpringFestivalGuessJokerCompleted checkSpringFestivalGuessJokerCompleted = gameplayType as ICheckSpringFestivalGuessJokerCompleted;
				if (checkSpringFestivalGuessJokerCompleted == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Quest;
					ELogAuthor author = ELogAuthor.LRX;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 1);
					defaultInterpolatedStringHandler.AppendLiteral("缺少的类型");
					defaultInterpolatedStringHandler.AppendFormatted<ICheckSpringFestivalGameplayType>(checkSpringFestivalGameplayCompleted.GameplayType);
					instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				else
				{
					this.LevelId = checkSpringFestivalGuessJokerCompleted.Id.GetValueOrDefault();
				}
			}
			else
			{
				this.LevelId = checkSpringFestivalMixDrinksCompleted.Id.GetValueOrDefault();
			}
			return true;
		}

		// Token: 0x0603BFCF RID: 245711 RVA: 0x00F365D3 File Offset: 0x00F347D3
		protected override void OnStart(ENodeStatusUpdateReason reason)
		{
		}

		// Token: 0x0603BFD0 RID: 245712 RVA: 0x00F365D5 File Offset: 0x00F347D5
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.GameplayType = null;
			this.LevelId = 0;
		}

		// Token: 0x0603BFD1 RID: 245713 RVA: 0x00F365F0 File Offset: 0x00F347F0
		protected override void AddEventsOnChildQuestStart()
		{
			base.AddEventsOnChildQuestStart();
			Singleton<EventSystem>.Instance.Add<ESpringFestivalGameplayType, int>(EEventName.OnSpringManorGameplayFinish, new Action<ESpringFestivalGameplayType, int>(this.OnGameplayFinish));
		}

		// Token: 0x0603BFD2 RID: 245714 RVA: 0x00F36614 File Offset: 0x00F34814
		protected override void RemoveEventsOnChildQuestEnd()
		{
			Singleton<EventSystem>.Instance.Remove<ESpringFestivalGameplayType, int>(EEventName.OnSpringManorGameplayFinish, new Action<ESpringFestivalGameplayType, int>(this.OnGameplayFinish));
			base.RemoveEventsOnChildQuestEnd();
		}

		// Token: 0x0603BFD3 RID: 245715 RVA: 0x00F36638 File Offset: 0x00F34838
		private void OnGameplayFinish(ESpringFestivalGameplayType type, int levelId)
		{
			if (this.GameplayType == null)
			{
				return;
			}
			ESpringFestivalGameplayType? gameplayType = this.GameplayType;
			if (!(gameplayType.GetValueOrDefault() == type & gameplayType != null))
			{
				return;
			}
			if (this.LevelId == 0 || levelId == this.LevelId)
			{
				this.SubmitNode(null);
			}
		}

		// Token: 0x0603BFD4 RID: 245716 RVA: 0x00F36689 File Offset: 0x00F34889
		protected override void OnAfterSubmit(bool submitSuccess)
		{
			base.OnAfterSubmit(submitSuccess);
			if (submitSuccess)
			{
				this.GameplayType = null;
				this.LevelId = 0;
			}
		}

		// Token: 0x04021B3E RID: 138046
		private ESpringFestivalGameplayType? GameplayType;

		// Token: 0x04021B3F RID: 138047
		private int LevelId;
	}
}
