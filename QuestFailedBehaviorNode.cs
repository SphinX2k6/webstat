using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;

// Token: 0x02001DD1 RID: 7633
[NullableContext(1)]
[Nullable(0)]
public class QuestFailedBehaviorNode : BehaviorNodeBase, IStaticVariableResetter
{
	// Token: 0x0600E1E4 RID: 57828 RVA: 0x003CDA47 File Offset: 0x003CBC47
	public QuestFailedBehaviorNode(int NodeId) : base(NodeId)
	{
	}

	// Token: 0x0600E1E5 RID: 57829 RVA: 0x003CDA5B File Offset: 0x003CBC5B
	static QuestFailedBehaviorNode()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(QuestFailedBehaviorNode.CreateStaticDefaultValue), new Action(QuestFailedBehaviorNode.ResetStaticDefaultValue));
	}

	// Token: 0x170011AC RID: 4524
	// (get) Token: 0x0600E1E6 RID: 57830 RVA: 0x003CDA7A File Offset: 0x003CBC7A
	public override EBtNode NodeType
	{
		get
		{
			return EBtNode.QuestFailed;
		}
	}

	// Token: 0x170011AD RID: 4525
	// (get) Token: 0x0600E1E7 RID: 57831 RVA: 0x003CDA7D File Offset: 0x003CBC7D
	public bool? NeedSecondaryConfirm
	{
		get
		{
			return this.NeedConfirm;
		}
	}

	// Token: 0x170011AE RID: 4526
	// (get) Token: 0x0600E1E8 RID: 57832 RVA: 0x003CDA85 File Offset: 0x003CBC85
	public ETeleportTransitionType? NowTransitionType
	{
		get
		{
			return this.TransitionType;
		}
	}

	// Token: 0x170011AF RID: 4527
	// (get) Token: 0x0600E1E9 RID: 57833 RVA: 0x003CDA90 File Offset: 0x003CBC90
	public RangeFailedEffectHandler RangeFailedEffectChain
	{
		get
		{
			if (QuestFailedBehaviorNode.RangeFailedEffectChainInternal == null)
			{
				RangeFailedEffectRangeEntitiesHandler rangeFailedEffectRangeEntitiesHandler = new RangeFailedEffectRangeEntitiesHandler();
				RangeFailedEffectFixedPointHandler next = new RangeFailedEffectFixedPointHandler();
				rangeFailedEffectRangeEntitiesHandler.SetNext(next);
				QuestFailedBehaviorNode.RangeFailedEffectChainInternal = rangeFailedEffectRangeEntitiesHandler;
			}
			return QuestFailedBehaviorNode.RangeFailedEffectChainInternal;
		}
	}

	// Token: 0x0600E1EA RID: 57834 RVA: 0x003CDAC4 File Offset: 0x003CBCC4
	protected override bool OnCreate(IBtNode config)
	{
		if (config == null || config.Type != EBtNode.QuestFailed)
		{
			return false;
		}
		IQuestFailedCondition failedCondition = (config as IQuestFailedBtNode).FailedCondition;
		bool? needConfirm;
		if (failedCondition == null)
		{
			needConfirm = null;
		}
		else
		{
			IFailedTeleport failedTeleport = failedCondition.FailedTeleport;
			needConfirm = ((failedTeleport != null) ? new bool?(failedTeleport.IsConfirm) : null);
		}
		this.NeedConfirm = needConfirm;
		IQuestFailedCondition failedCondition2 = (config as IQuestFailedBtNode).FailedCondition;
		ETeleportTransitionType? transitionType;
		if (failedCondition2 == null)
		{
			transitionType = null;
		}
		else
		{
			IFailedTeleport failedTeleport2 = failedCondition2.FailedTeleport;
			if (failedTeleport2 == null)
			{
				transitionType = null;
			}
			else
			{
				ITeleportTransitionType transitionOption = failedTeleport2.TransitionOption;
				transitionType = ((transitionOption != null) ? new ETeleportTransitionType?(transitionOption.Type) : null);
			}
		}
		this.TransitionType = transitionType;
		IQuestFailedCondition failedCondition3 = (config as IQuestFailedBtNode).FailedCondition;
		ITimerUiConfig timerUiConfig;
		if (failedCondition3 == null)
		{
			timerUiConfig = null;
		}
		else
		{
			ITimerConfig timer = failedCondition3.Timer;
			timerUiConfig = ((timer != null) ? timer.UiConfig : null);
		}
		this.TimerUiConfig = timerUiConfig;
		IQuestFailedCondition failedCondition4 = (config as IQuestFailedBtNode).FailedCondition;
		IRangeLimitingCondition rangeLimitingCondition = (failedCondition4 != null) ? failedCondition4.RangeLimiting : null;
		if (rangeLimitingCondition != null)
		{
			this.RangeFailedParameterContext = new RangeFailedParameterContext(rangeLimitingCondition);
		}
		IQuestFailedCondition failedCondition5 = (config as IQuestFailedBtNode).FailedCondition;
		bool? flag;
		if (failedCondition5 == null)
		{
			flag = null;
		}
		else
		{
			IRangeLimitingCondition rangeLimiting = failedCondition5.RangeLimiting;
			flag = ((rangeLimiting != null) ? rangeLimiting.RequiresSecondConfirmation : null);
		}
		bool? flag2 = flag;
		this.NeedRequiresSecondConfirmation = flag2.GetValueOrDefault();
		IQuestFailedCondition failedCondition6 = (config as IQuestFailedBtNode).FailedCondition;
		if (((failedCondition6 != null) ? failedCondition6.SneakPlayCondition : null) != null)
		{
			this.AddSneakEvent();
		}
		IQuestFailedCondition failedCondition7 = (config as IQuestFailedBtNode).FailedCondition;
		bool flag3;
		if (failedCondition7 == null)
		{
			flag3 = (null != null);
		}
		else
		{
			IQuestFailedConditionEntityAlert entityAlert = failedCondition7.EntityAlert;
			flag3 = (((entityAlert != null) ? entityAlert.EntityIds : null) != null);
		}
		if (flag3 && (config as IQuestFailedBtNode).FailedCondition.EntityAlert.EntityIds.Count > 0)
		{
			this.EntitiesMonitorStalkAlert = (config as IQuestFailedBtNode).FailedCondition.EntityAlert.EntityIds;
			this.AddStalkEvent();
		}
		IQuestFailedCondition failedCondition8 = (config as IQuestFailedBtNode).FailedCondition;
		this.CanGiveUp = ((failedCondition8 != null) ? failedCondition8.CanGiveUp : null);
		IQuestFailedCondition failedCondition9 = (config as IQuestFailedBtNode).FailedCondition;
		this.GiveUpText = ((failedCondition9 != null) ? failedCondition9.TidGiveUpText : null);
		return true;
	}

	// Token: 0x0600E1EB RID: 57835 RVA: 0x003CDCC5 File Offset: 0x003CBEC5
	protected override void OnNodeActive()
	{
		if (this.RangeFailedParameterContext != null)
		{
			this.RangeFailedEffectChain.Handle(this.RangeFailedParameterContext);
		}
	}

	// Token: 0x0600E1EC RID: 57836 RVA: 0x003CDCE4 File Offset: 0x003CBEE4
	protected override void OnNodeDeActive(bool success)
	{
		this.StopFailRangeEffect();
		if (this.RegisterSneakyNotify)
		{
			this.AddOrRemoveSneakBuff(false);
		}
		this.RemoveSneakEvent();
		this.RemoveStalkEvent();
		if (this.RangeFailedParameterContext != null)
		{
			this.RangeFailedParameterContext.Clear();
			this.RangeFailedParameterContext = null;
		}
		base.OnNodeDeActive(success);
		if (ControllerBase<QuestNewController>.Instance.QuestRangeFailWarningTreeId == base.TreeIncId)
		{
			ControllerBase<QuestNewController>.Instance.HideCancelRangeFailWaringEffect();
		}
	}

	// Token: 0x0600E1ED RID: 57837 RVA: 0x003CDD50 File Offset: 0x003CBF50
	private void AddSneakEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		this.AddOrRemoveSneakBuff(true);
		this.RegisterSneakyNotify = true;
		Singleton<Net>.Instance.Register<SneakNotify>(ENotifyMessageId.SneakNotify, delegate(SneakNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			long num = Singleton<MathUtils>.Instance.LongToBigInt(response.EndTime);
			this.SneakState = new bool?(num != 0L);
			Singleton<EventSystem>.Instance.Emit<bool, long>(EEventName.OnSneakFoundChange, this.SneakState.Value, num);
		});
		if (this.BtType == BtType.Invalid)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SneakStart);
		int? behaviorTreeOwnerId = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTreeOwnerId(new long?(base.TreeIncId));
		SneakTimeRequest sneakTimeRequest = SneakTimeRequest.Create();
		sneakTimeRequest.TreeOwnerId = behaviorTreeOwnerId.Value;
		sneakTimeRequest.TreeIncId = Singleton<MathUtils>.Instance.BigIntToLong(base.TreeIncId);
		Singleton<Net>.Instance.Call<SneakTimeResponse>(ERequestMessageId.SneakTimeRequest, sneakTimeRequest, delegate(SneakTimeResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorId != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 27574, null, true, true);
			}
		}, 0);
	}

	// Token: 0x0600E1EE RID: 57838 RVA: 0x003CDE2C File Offset: 0x003CC02C
	private void RemoveSneakEvent()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.SneakEnd);
		if (Singleton<EventSystem>.Instance.Has(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		}
		if (this.RegisterSneakyNotify)
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SneakNotify);
			this.RegisterSneakyNotify = false;
		}
	}

	// Token: 0x0600E1EF RID: 57839 RVA: 0x003CDEA4 File Offset: 0x003CC0A4
	private void OnBattleStateChanged(bool isInBattleState)
	{
		this.AddOrRemoveSneakBuff(!isInBattleState);
		bool? sneakState = this.SneakState;
		if (isInBattleState == sneakState.GetValueOrDefault() & sneakState != null)
		{
			return;
		}
		if (this.BtType == BtType.Invalid)
		{
			return;
		}
		this.SneakState = new bool?(isInBattleState);
		if (!isInBattleState)
		{
			Singleton<EventSystem>.Instance.Emit<bool, long>(EEventName.OnSneakFoundChange, this.SneakState.Value, 0L);
		}
		int? behaviorTreeOwnerId = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTreeOwnerId(new long?(base.TreeIncId));
		SneakRequest sneakRequest = SneakRequest.Create();
		sneakRequest.TreeOwnerId = behaviorTreeOwnerId.Value;
		sneakRequest.TreeIncId = Singleton<MathUtils>.Instance.BigIntToLong(base.TreeIncId);
		sneakRequest.NodeId = base.NodeId;
		sneakRequest.IsStart = isInBattleState;
		Singleton<Net>.Instance.Call<SneakResponse>(ERequestMessageId.SneakRequest, sneakRequest, delegate(SneakResponse response, Net.CallbackStatus _)
		{
			int errorId = (int)response.ErrorId;
			if (errorId != 0 && errorId != 600067 && errorId != 1000054)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 16559, null, true, true);
			}
		}, 0);
	}

	// Token: 0x0600E1F0 RID: 57840 RVA: 0x003CDF8E File Offset: 0x003CC18E
	private void AddStalkEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnStalkFound, new Action<int>(this.OnStalkFound));
	}

	// Token: 0x0600E1F1 RID: 57841 RVA: 0x003CDFAC File Offset: 0x003CC1AC
	private void RemoveStalkEvent()
	{
		if (Singleton<EventSystem>.Instance.Has(EEventName.OnStalkFound, new Action<int>(this.OnStalkFound)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnStalkFound, new Action<int>(this.OnStalkFound));
		}
	}

	// Token: 0x0600E1F2 RID: 57842 RVA: 0x003CDFE8 File Offset: 0x003CC1E8
	private void OnStalkFound(int id)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		if (entity == null || !entity.Valid)
		{
			return;
		}
		int pbDataId = entity.GetComponent<CreatureDataComponent>().GetPbDataId();
		if (!this.EntitiesMonitorStalkAlert.Contains(pbDataId))
		{
			return;
		}
		TimerSystem.Instance.Delay(delegate(float _)
		{
			if (this.IsRequesting)
			{
				return;
			}
			this.IsRequesting = true;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnStalkFailed);
			this.RequestStalkFailed();
		}, 1000f, null, null, true, 1f);
	}

	// Token: 0x0600E1F3 RID: 57843 RVA: 0x003CE04C File Offset: 0x003CC24C
	private void RequestStalkFailed()
	{
		int? behaviorTreeOwnerId = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTreeOwnerId(new long?(base.TreeIncId));
		NpcTraceFailedRequest npcTraceFailedRequest = NpcTraceFailedRequest.Create();
		npcTraceFailedRequest.TreeOwnerId = behaviorTreeOwnerId.Value;
		npcTraceFailedRequest.TreeIncId = Singleton<MathUtils>.Instance.BigIntToLong(base.TreeIncId);
		npcTraceFailedRequest.NodeId = base.NodeId;
		Singleton<Net>.Instance.Call<NpcTraceFailedResponse>(ERequestMessageId.NpcTraceFailedRequest, npcTraceFailedRequest, delegate(NpcTraceFailedResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorId != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 22648, null, true, true);
			}
		}, 0);
	}

	// Token: 0x0600E1F4 RID: 57844 RVA: 0x003CE0D4 File Offset: 0x003CC2D4
	private void AddOrRemoveSneakBuff(bool isAdd)
	{
		CharacterBuffComponent component = Global.BaseCharacter.GetEntityNoBlueprint().GetComponent<CharacterBuffComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		if (isAdd)
		{
			component.AddBuff(70000049L, new AddBuffParam
			{
				InstigatorId = component.CreatureDataId,
				Reason = "QuestFailedBehaviorNode"
			});
			return;
		}
		component.RemoveBuff(70000049L, -1, "QuestFailedBehaviorNode", null, null, null);
	}

	// Token: 0x0600E1F5 RID: 57845 RVA: 0x003CE156 File Offset: 0x003CC356
	public bool IsFadeInScreen()
	{
		return this.TransitionType.GetValueOrDefault() == ETeleportTransitionType.FadeInScreen;
	}

	// Token: 0x0600E1F6 RID: 57846 RVA: 0x003CE166 File Offset: 0x003CC366
	private void StopFailRangeEffect()
	{
		if (this.RangeFailedParameterContext != null)
		{
			this.RangeFailedEffectChain.Stop(this.RangeFailedParameterContext);
		}
	}

	// Token: 0x0600E1F7 RID: 57847 RVA: 0x003CE184 File Offset: 0x003CC384
	public bool IsOutFailRange(global::Vector itemPosition)
	{
		if (this.RangeFailedParameterContext != null)
		{
			if (this.RangeFailedParameterContext.FailRangeCheck != null)
			{
				return this.RangeFailedParameterContext.FailRangeCheck.MapCheckReachedPosition(itemPosition) == null;
			}
			if (this.RangeFailedParameterContext.RangeFailedEffectCenterPos != null)
			{
				float rangeFailedEffectRadius = this.RangeFailedParameterContext.RangeFailedEffectRadius;
				return global::Vector.DistXY(this.RangeFailedParameterContext.RangeFailedEffectCenterPos, itemPosition) > (double)this.RangeFailedParameterContext.RangeFailedEffectRadius;
			}
		}
		return true;
	}

	// Token: 0x0600E1F8 RID: 57848 RVA: 0x003CE1FF File Offset: 0x003CC3FF
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x0600E1F9 RID: 57849 RVA: 0x003CE201 File Offset: 0x003CC401
	public static void ResetStaticDefaultValue()
	{
		QuestFailedBehaviorNode.RangeFailedEffectChainInternal = null;
	}

	// Token: 0x04006C40 RID: 27712
	public const int STALK_FAILED_DELAY_TIME = 1000;

	// Token: 0x04006C41 RID: 27713
	[Nullable(2)]
	public ITimerUiConfig TimerUiConfig;

	// Token: 0x04006C42 RID: 27714
	public bool? CanGiveUp;

	// Token: 0x04006C43 RID: 27715
	private bool? SneakState;

	// Token: 0x04006C44 RID: 27716
	private bool RegisterSneakyNotify;

	// Token: 0x04006C45 RID: 27717
	private bool? NeedConfirm;

	// Token: 0x04006C46 RID: 27718
	private ETeleportTransitionType? TransitionType;

	// Token: 0x04006C47 RID: 27719
	[Nullable(2)]
	public string GiveUpText;

	// Token: 0x04006C48 RID: 27720
	private List<int> EntitiesMonitorStalkAlert = new List<int>();

	// Token: 0x04006C49 RID: 27721
	private bool IsRequesting;

	// Token: 0x04006C4A RID: 27722
	public bool NeedRequiresSecondConfirmation;

	// Token: 0x04006C4B RID: 27723
	[Nullable(2)]
	private RangeFailedParameterContext RangeFailedParameterContext;

	// Token: 0x04006C4C RID: 27724
	[Nullable(2)]
	private static RangeFailedEffectHandler RangeFailedEffectChainInternal;
}
