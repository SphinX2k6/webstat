using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Utils;

// Token: 0x02002E6A RID: 11882
[NullableContext(1)]
[Nullable(0)]
public class BaseGameplayCueComponent : EntityComponent
{
	// Token: 0x06018683 RID: 99971 RVA: 0x006D64A5 File Offset: 0x006D46A5
	protected override bool OnStart()
	{
		return true;
	}

	// Token: 0x06018684 RID: 99972 RVA: 0x006D64A8 File Offset: 0x006D46A8
	protected override bool OnEnd()
	{
		foreach (long cueHandleId in this.CueContainer.Keys.ToArray<long>())
		{
			this.RemoveCueByHandle(cueHandleId);
		}
		return true;
	}

	// Token: 0x06018685 RID: 99973 RVA: 0x006D64E0 File Offset: 0x006D46E0
	protected override void OnTick(float delta)
	{
		float delta2 = delta * (float)Singleton<TimeUtil>.Instance.Millisecond;
		foreach (GameplayCueBase gameplayCueBase in this.GetAllCurrentCueRef())
		{
			gameplayCueBase.Tick(delta2);
		}
	}

	// Token: 0x06018686 RID: 99974 RVA: 0x006D653C File Offset: 0x006D473C
	protected override void OnAfterTick(float delta)
	{
		float delta2 = delta * (float)Singleton<TimeUtil>.Instance.Millisecond;
		foreach (GameplayCueBase gameplayCueBase in this.GetAllCurrentCueRef())
		{
			gameplayCueBase.AfterTick(delta2);
		}
	}

	// Token: 0x06018687 RID: 99975 RVA: 0x006D6598 File Offset: 0x006D4798
	public int AddCue(long cueId, GameplayCueParam? cueParam = null)
	{
		GameplayCueBase gameplayCueBase = this.CreateGameplayCueInner(cueId, cueParam);
		if (gameplayCueBase == null)
		{
			return 0;
		}
		if (cueParam != null && cueParam.GetValueOrDefault().Instant)
		{
			return -1;
		}
		int num = GameplayCueController.GenerateHandle();
		GameplayCueBase gameplayCueBase2 = gameplayCueBase;
		long cueHandleId = (long)num;
		int? num2;
		if (cueParam == null)
		{
			num2 = null;
		}
		else
		{
			IActiveBuff buff = cueParam.GetValueOrDefault().Buff;
			num2 = ((buff != null) ? new int?(buff.Handle) : null);
		}
		int? num3 = num2;
		gameplayCueBase2.Add(cueHandleId, num3.GetValueOrDefault());
		this.CueContainer[(long)num] = gameplayCueBase;
		return num;
	}

	// Token: 0x06018688 RID: 99976 RVA: 0x006D6630 File Offset: 0x006D4830
	public void RemoveCue(long cueId)
	{
		foreach (long cueHandleId in this.GetCueHandlesByCueId(cueId))
		{
			this.RemoveCueByHandle(cueHandleId);
		}
	}

	// Token: 0x06018689 RID: 99977 RVA: 0x006D6684 File Offset: 0x006D4884
	public void RemoveCueByHandle(long cueHandleId)
	{
		GameplayCueBase gameplayCueBase;
		if (!this.CueContainer.TryGetValue(cueHandleId, out gameplayCueBase))
		{
			return;
		}
		gameplayCueBase.Remove(cueHandleId);
		if (gameplayCueBase.CueHandleIds.Count == 0)
		{
			gameplayCueBase.Destroy();
			this.RemoveFromPriorityGroup(gameplayCueBase);
		}
		this.CueContainer.Remove(cueHandleId);
	}

	// Token: 0x0601868A RID: 99978 RVA: 0x006D66D0 File Offset: 0x006D48D0
	public virtual void AddCueEffectToSet(int effectViewHandle, ETimeScaleType timeScaleType, ECueHideRule hideRule)
	{
	}

	// Token: 0x0601868B RID: 99979 RVA: 0x006D66D2 File Offset: 0x006D48D2
	[NullableContext(2)]
	protected virtual EntityHandle GetEntityHandle()
	{
		return null;
	}

	// Token: 0x0601868C RID: 99980 RVA: 0x006D66D5 File Offset: 0x006D48D5
	public IEnumerable<GameplayCueBase> GetAllCurrentCueRef()
	{
		BaseGameplayCueComponent.<GetAllCurrentCueRef>d__10 <GetAllCurrentCueRef>d__ = new BaseGameplayCueComponent.<GetAllCurrentCueRef>d__10(-2);
		<GetAllCurrentCueRef>d__.<>4__this = this;
		return <GetAllCurrentCueRef>d__;
	}

	// Token: 0x0601868D RID: 99981 RVA: 0x006D66E5 File Offset: 0x006D48E5
	[NullableContext(2)]
	public GameplayCueBase GetCueByHandle(long cueHandleId)
	{
		return this.CueContainer.GetValueOrDefault(cueHandleId);
	}

	// Token: 0x0601868E RID: 99982 RVA: 0x006D66F4 File Offset: 0x006D48F4
	[NullableContext(2)]
	public GameplayCueBase GetCueByCueId(long cueId)
	{
		foreach (GameplayCueBase gameplayCueBase in this.CueContainer.Values)
		{
			if (gameplayCueBase.CueConfig.Id == cueId)
			{
				return gameplayCueBase;
			}
		}
		return null;
	}

	// Token: 0x0601868F RID: 99983 RVA: 0x006D675C File Offset: 0x006D495C
	public void ChangeBuffHandle(long cueHandleId, IActiveBuff newBuff)
	{
		GameplayCueBase gameplayCueBase;
		if (this.CueContainer.TryGetValue(cueHandleId, out gameplayCueBase))
		{
			gameplayCueBase.ChangeBuffHandle(newBuff.Handle);
		}
	}

	// Token: 0x06018690 RID: 99984 RVA: 0x006D6788 File Offset: 0x006D4988
	private void GameplayCueRequest(long cueId)
	{
		GameplayCuePush gameplayCuePush = GameplayCuePush.Create();
		gameplayCuePush.CueConfigId = cueId;
		Singleton<CombatNet>.Instance.Send(EPushMessageId.GameplayCuePush, this.GetEntityHandle().Entity, gameplayCuePush, null, null, null);
	}

	// Token: 0x06018691 RID: 99985 RVA: 0x006D67DC File Offset: 0x006D49DC
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.GameplayCueNotify, true, false)]
	public static void GameplayCueNotify(Entity entity, [Nullable(1)] GameplayCueNotify data, CombatCommon combatCommon = null)
	{
		object obj = (entity != null) ? entity.GetComponent<CharacterGameplayCueComponent>() : null;
		long cueConfigId = data.CueConfigId;
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		obj2.AddCue(cueConfigId, new GameplayCueParam?(new GameplayCueParam
		{
			Instant = true
		}));
	}

	// Token: 0x06018692 RID: 99986 RVA: 0x006D6820 File Offset: 0x006D4A20
	private List<long> GetCueHandlesByCueId(long cueId)
	{
		List<long> list = new List<long>();
		foreach (KeyValuePair<long, GameplayCueBase> keyValuePair in this.CueContainer)
		{
			long num;
			GameplayCueBase gameplayCueBase;
			keyValuePair.Deconstruct(out num, out gameplayCueBase);
			long item = num;
			if (gameplayCueBase.CueConfig.Id == cueId)
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06018693 RID: 99987 RVA: 0x006D6898 File Offset: 0x006D4A98
	[NullableContext(2)]
	private unsafe GameplayCueBase CreateGameplayCueInner(long cueId, GameplayCueParam? cueParam = null)
	{
		GameplayCue? configById = GameplayCueController.GetConfigById(cueId);
		if (configById == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Cue;
			Entity entity = base.Entity;
			string message = "Cue特效表不存在CueId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CueId", cueId);
			instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		GameplayCue valueOrDefault = configById.GetValueOrDefault();
		if (!this.IsPriorityGroupSatisfied(valueOrDefault))
		{
			return null;
		}
		IActiveBuff buff = (cueParam != null) ? cueParam.GetValueOrDefault().Buff : null;
		bool flag2 = cueParam != null && cueParam.GetValueOrDefault().Instant;
		ValueTuple<Func<GameplayCueBase>, bool>? gameplayCueClass = BaseGameplayCueComponent.GetGameplayCueClass(valueOrDefault, flag2);
		if (gameplayCueClass != null)
		{
			ValueTuple<Func<GameplayCueBase>, bool> valueOrDefault2 = gameplayCueClass.GetValueOrDefault();
			GameplayCueBase gameplayCueBase = this.GetCueByCueId(cueId);
			if (gameplayCueBase == null || !valueOrDefault2.Item2)
			{
				Func<GameplayCueBase> item = valueOrDefault2.Item1;
				GameplayCueParam gameplayCueParam = default(GameplayCueParam);
				gameplayCueParam.CueConfig = valueOrDefault;
				gameplayCueParam.EntityHandle = this.GetEntityHandle();
				gameplayCueParam.CueComp = this;
				gameplayCueParam.Buff = buff;
				gameplayCueParam.Instant = flag2;
				gameplayCueParam.BeginCallback = ((cueParam != null) ? cueParam.GetValueOrDefault().BeginCallback : null);
				gameplayCueParam.EndCallback = ((cueParam != null) ? cueParam.GetValueOrDefault().EndCallback : null);
				gameplayCueParam.Instigator = ((cueParam != null) ? cueParam.GetValueOrDefault().Instigator : null);
				gameplayCueParam.SocketNameOverride = ((cueParam != null) ? cueParam.GetValueOrDefault().SocketNameOverride : null);
				gameplayCueParam.RelativePositionOverride = ((cueParam != null) ? cueParam.GetValueOrDefault().RelativePositionOverride : null);
				gameplayCueParam.RelativeRotationOverride = ((cueParam != null) ? cueParam.GetValueOrDefault().RelativeRotationOverride : null);
				gameplayCueParam.ScaleOverride = ((cueParam != null) ? cueParam.GetValueOrDefault().ScaleOverride : null);
				gameplayCueBase = GameplayCueBase.Spawn(item, gameplayCueParam);
				this.AddToPriorityGroup(valueOrDefault);
			}
			bool flag3;
			if (cueParam == null)
			{
				flag3 = false;
			}
			else
			{
				GameplayCueParam gameplayCueParam = cueParam.GetValueOrDefault();
				flag3 = gameplayCueParam.Sync.GetValueOrDefault();
			}
			if (flag3)
			{
				this.GameplayCueRequest(cueId);
			}
			return gameplayCueBase;
		}
		CombatLog instance2 = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag4 = CombatLog.EDebugModule.Cue;
		Entity entity2 = base.Entity;
		string message2 = "不存在这种Cue特效类型";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CueId", cueId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Cue类型", valueOrDefault.CueType);
		instance2.Error(flag4, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return null;
	}

	// Token: 0x06018694 RID: 99988 RVA: 0x006D6B38 File Offset: 0x006D4D38
	private bool IsPriorityGroupSatisfied(GameplayCue cueConfig)
	{
		if (cueConfig.Group <= 0)
		{
			return true;
		}
		long cueId;
		if (!this.CuePriorityGroup.TryGetValue(cueConfig.Group, out cueId))
		{
			return true;
		}
		GameplayCueBase cueByCueId = this.GetCueByCueId(cueId);
		return cueByCueId == null || cueByCueId.CueConfig.Priority <= cueConfig.Priority;
	}

	// Token: 0x06018695 RID: 99989 RVA: 0x006D6B90 File Offset: 0x006D4D90
	private void AddToPriorityGroup(GameplayCue cueConfig)
	{
		if (cueConfig.Group <= 0)
		{
			return;
		}
		long num;
		if (this.CuePriorityGroup.TryGetValue(cueConfig.Group, out num))
		{
			if (num == cueConfig.Id)
			{
				return;
			}
			GameplayCueBase cueByCueId = this.GetCueByCueId(num);
			if (cueByCueId != null && cueByCueId.CueConfig.Priority > cueConfig.Priority)
			{
				return;
			}
			this.RemoveCue(num);
		}
		this.CuePriorityGroup[cueConfig.Group] = cueConfig.Id;
	}

	// Token: 0x06018696 RID: 99990 RVA: 0x006D6C09 File Offset: 0x006D4E09
	[NullableContext(2)]
	private void RemoveFromPriorityGroup(GameplayCueBase cueRef = null)
	{
		if (cueRef != null && cueRef.CueConfig.Group > 0)
		{
			this.CuePriorityGroup.Remove(cueRef.CueConfig.Group);
		}
	}

	// Token: 0x06018697 RID: 99991 RVA: 0x006D6C34 File Offset: 0x006D4E34
	[return: TupleElementNames(new string[]
	{
		"SpawnArgs",
		"IsSingleInstance"
	})]
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	private static ValueTuple<Func<GameplayCueBase>, bool>? GetGameplayCueClass(in GameplayCue cueConfig, bool isInstant)
	{
		GameplayCue gameplayCue = cueConfig;
		switch (gameplayCue.CueType)
		{
		case 0:
			gameplayCue = cueConfig;
			if (gameplayCue.BSoftFollow)
			{
				return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueFollow(), GameplayCueBase.IsSingleInstance()));
			}
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueEffect(), GameplayCueBase.IsSingleInstance()));
		case 1:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueMaterial(), GameplayCueBase.IsSingleInstance()));
		case 2:
		case 4:
		case 14:
		case 20:
		case 22:
		case 24:
		case 37:
		case 38:
		case 39:
			if (!isInstant)
			{
				return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueUIEffect(), GameplayCueUIEffect.IsSingleInstance()));
			}
			return null;
		case 3:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueMoveSpline(), GameplayCueBase.IsSingleInstance()));
		case 5:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueUIEffect(), GameplayCueUIEffect.IsSingleInstance()));
		case 6:
			if (!isInstant)
			{
				return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueBeam(), GameplayCueBeam.IsSingleInstance()));
			}
			return null;
		case 7:
			if (!isInstant)
			{
				return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueHookUp(), GameplayCueBase.IsSingleInstance()));
			}
			return null;
		case 8:
			if (!isInstant)
			{
				return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueFixHook(), GameplayCueBase.IsSingleInstance()));
			}
			return null;
		case 9:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueCameraEffect(), GameplayCueBase.IsSingleInstance()));
		case 10:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueFromSummoned(), GameplayCueBase.IsSingleInstance()));
		case 11:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueHideMesh(), GameplayCueBase.IsSingleInstance()));
		case 12:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueHideBone(), GameplayCueBase.IsSingleInstance()));
		case 13:
			if (!isInstant)
			{
				return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueManipulateInteract(), GameplayCueBase.IsSingleInstance()));
			}
			return null;
		case 15:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueHitEffect(), GameplayCueBase.IsSingleInstance()));
		case 16:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueSkillTargetBeam(), GameplayCueBase.IsSingleInstance()));
		case 17:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueAnimBeam(), GameplayCueBase.IsSingleInstance()));
		case 18:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueTraceRay(), GameplayCueBase.IsSingleInstance()));
		case 19:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueSkinDamage(), GameplayCueBase.IsSingleInstance()));
		case 21:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueAudioEvent(), GameplayCueBase.IsSingleInstance()));
		case 23:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GamePlayCueEffectNiagara(), GameplayCueBase.IsSingleInstance()));
		case 25:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueCharacterAudioEvent(), GameplayCueBase.IsSingleInstance()));
		case 26:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueGhost(), GameplayCueBase.IsSingleInstance()));
		case 27:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueReference(), GameplayCueBase.IsSingleInstance()));
		case 28:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueRtpc(), GameplayCueBase.IsSingleInstance()));
		case 29:
			if (!isInstant)
			{
				return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueMotorcycleFixHook(), GameplayCueBase.IsSingleInstance()));
			}
			return null;
		case 30:
			if (!isInstant)
			{
				return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueMotorcyclePullCollection(), GameplayCueBase.IsSingleInstance()));
			}
			return null;
		case 31:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueAdjacent(), GameplayCueBase.IsSingleInstance()));
		case 32:
			if (!isInstant)
			{
				return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueRopeVerletPhysics(), GameplayCueRopeVerletPhysics.IsSingleInstance()));
			}
			return null;
		case 33:
			if (!isInstant)
			{
				return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueRopeEffectComponent(), GameplayCueRopeEffectComponent.IsSingleInstance()));
			}
			return null;
		case 34:
			if (!isInstant)
			{
				return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueMonsterBeam(), GameplayCueBeam.IsSingleInstance()));
			}
			return null;
		case 35:
			if (!isInstant)
			{
				return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueMotorcycleAssemble(), GameplayCueBase.IsSingleInstance()));
			}
			return null;
		case 36:
			return new ValueTuple<Func<GameplayCueBase>, bool>?(new ValueTuple<Func<GameplayCueBase>, bool>(() => new GameplayCueTargetEffect(), GameplayCueBase.IsSingleInstance()));
		default:
			return null;
		}
	}

	// Token: 0x06018698 RID: 99992 RVA: 0x006D73B4 File Offset: 0x006D55B4
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseGameplayCueComponent baseGameplayCueComponent = (BaseGameplayCueComponent)componentTemplate;
		return (!base.CanResetComponentProperty("CueContainer") || baseGameplayCueComponent.CueContainer == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, GameplayCueBase>>(this.CueContainer), "CueContainer")) && (!base.CanResetComponentProperty("CuePriorityGroup") || baseGameplayCueComponent.CuePriorityGroup == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, long>>(this.CuePriorityGroup), "CuePriorityGroup"));
	}

	// Token: 0x0400BBA3 RID: 48035
	private readonly Dictionary<long, GameplayCueBase> CueContainer = new Dictionary<long, GameplayCueBase>();

	// Token: 0x0400BBA4 RID: 48036
	private readonly Dictionary<int, long> CuePriorityGroup = new Dictionary<int, long>();
}
