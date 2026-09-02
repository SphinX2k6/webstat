using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B78 RID: 27512
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelEventCheckBattleState : LevelEventBase
	{
		// Token: 0x06043EF5 RID: 278261 RVA: 0x01197F9B File Offset: 0x0119619B
		public LevelEventCheckBattleState(int id) : base(id)
		{
		}

		// Token: 0x06043EF6 RID: 278262 RVA: 0x01197FA4 File Offset: 0x011961A4
		[NullableContext(1)]
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043EF7 RID: 278263 RVA: 0x01197FB0 File Offset: 0x011961B0
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			this.GetResult = false;
			WaitBattleCondition waitBattleCondition = inParams as WaitBattleCondition;
			if (waitBattleCondition == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZS, "参数不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			this.StateOption = waitBattleCondition.StateOption;
			if (this.StateOption == null || this.StateOption.TagOption == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZS, "StateOption不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			this.BattleOption = this.StateOption.TagOption;
			base.CreateWaitEntityTask(this.StateOption.EntityId);
		}

		// Token: 0x06043EF8 RID: 278264 RVA: 0x01198060 File Offset: 0x01196260
		protected override void ExecuteWhenEntitiesReady()
		{
			this.MaxWaitTime = this.StateOption.MaxWaitTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.EntityHandle = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.StateOption.EntityId);
			this.CheckType = new EDetectBattleConditionType?(this.StateOption.Type);
		}

		// Token: 0x06043EF9 RID: 278265 RVA: 0x011980BC File Offset: 0x011962BC
		protected override void OnTick(float deltaTime)
		{
			float num = (this.BaseContext != null) ? (deltaTime * LevelGamePlayUtils.GetCustomTimeDilationByContext(this.BaseContext).GetValueOrDefault(1f)) : deltaTime;
			if (this.MaxWaitTime > 0f)
			{
				this.MaxWaitTime -= num;
				if (this.MaxWaitTime <= 0f)
				{
					base.FinishExecute(true, false, true);
				}
			}
			this.CurInterval++;
			if (this.CurInterval < 5)
			{
				return;
			}
			this.CurInterval = 0;
			if ((this.CheckType ?? ((EDetectBattleConditionType)1)) == EDetectBattleConditionType.DetectBattleTag)
			{
				this.GetResult = this.GetGameplayTag();
			}
			if (!this.GetResult)
			{
				return;
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043EFA RID: 278266 RVA: 0x01198178 File Offset: 0x01196378
		private bool GetGameplayTag()
		{
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle == null || !entityHandle.Valid)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.ZS;
				string message = "目标实体不存在，action视为执行成功";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", this.StateOption.EntityId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return true;
			}
			string tagName = this.BattleOption.Type.ToEnumString();
			BaseTagComponent component = this.EntityHandle.Entity.GetComponent<BaseTagComponent>();
			return component != null && component.HasTag(GameplayTagUtils.GetTagIdByName(tagName));
		}

		// Token: 0x06043EFB RID: 278267 RVA: 0x01198206 File Offset: 0x01196406
		public override void Release()
		{
			base.Release();
			this.EntityHandle = null;
		}

		// Token: 0x04025FE4 RID: 155620
		private bool GetResult;

		// Token: 0x04025FE5 RID: 155621
		private EntityHandle EntityHandle;

		// Token: 0x04025FE6 RID: 155622
		private IDetectBattleTag StateOption;

		// Token: 0x04025FE7 RID: 155623
		private EDetectBattleConditionType? CheckType;

		// Token: 0x04025FE8 RID: 155624
		private IDetectBattleMonsterOnGround BattleOption;

		// Token: 0x04025FE9 RID: 155625
		private const int CheckInterval = 5;

		// Token: 0x04025FEA RID: 155626
		private int CurInterval;

		// Token: 0x04025FEB RID: 155627
		private float MaxWaitTime;
	}
}
