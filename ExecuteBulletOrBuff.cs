using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002F79 RID: 12153
[NullableContext(1)]
[Nullable(0)]
public class ExecuteBulletOrBuff : PeriodExecution
{
	// Token: 0x06018D0E RID: 101646 RVA: 0x00704AFE File Offset: 0x00702CFE
	public ExecuteBulletOrBuff(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D0F RID: 101647 RVA: 0x00704B14 File Offset: 0x00702D14
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length < 2)
		{
			return;
		}
		this.TargetType = EExecutionTargetType.Self;
		this.GoalType = (EPassiveEffectGoalType)int.Parse(extraEffectParameters_[0]);
		IEnumerable<string> source = extraEffectParameters_[1].Split('#', StringSplitOptions.None);
		Func<string, long> selector;
		if ((selector = ExecuteBulletOrBuff.<>O.<0>__Parse) == null)
		{
			selector = (ExecuteBulletOrBuff.<>O.<0>__Parse = new Func<string, long>(long.Parse));
		}
		this.Ids = source.Select(selector).ToArray<long>();
		double[] times;
		if (extraEffectParameters_.Length <= 2 || string.IsNullOrEmpty(extraEffectParameters_[2]))
		{
			times = Array.Empty<double>();
		}
		else
		{
			IEnumerable<string> source2 = extraEffectParameters_[2].Split('#', StringSplitOptions.None);
			Func<string, double> selector2;
			if ((selector2 = ExecuteBulletOrBuff.<>O.<1>__Parse) == null)
			{
				selector2 = (ExecuteBulletOrBuff.<>O.<1>__Parse = new Func<string, double>(double.Parse));
			}
			times = source2.Select(selector2).ToArray<double>();
		}
		this.Times = times;
		this.UseCustomTimes = (extraEffectParameters_.Length > 3 && !string.IsNullOrEmpty(extraEffectParameters_[3]) && int.Parse(extraEffectParameters_[3]) == 1);
		this.BulletPosType = (EPassiveEffectTargetType)int.Parse((extraEffectParameters_.Length > 4 && !string.IsNullOrEmpty(extraEffectParameters_[4])) ? extraEffectParameters_[4] : 0.ToString());
		if (this.UseCustomTimes)
		{
			this.CustomTimesConfigs = CustomTimesConfigParser.ParseConfigs(parameters.ExtraEffectGrowParameters3, this.BuffId);
		}
	}

	// Token: 0x06018D10 RID: 101648 RVA: 0x00704C38 File Offset: 0x00702E38
	[return: Nullable(2)]
	public override object OnExecute(params object[] args)
	{
		switch (this.GoalType)
		{
		case EPassiveEffectGoalType.Buff:
			this.ExecutePerId(new Action<long, float, IBuffComponent>(this.ProcessBuffId));
			break;
		case EPassiveEffectGoalType.Bullet:
			this.ExecutePerId(new Action<long, float, IBuffComponent>(this.ProcessBulletId));
			break;
		case EPassiveEffectGoalType.RemoveBuff:
			this.ExecutePerId(new Action<long, float, IBuffComponent>(this.ProcessBuffRemoveId));
			break;
		}
		return null;
	}

	// Token: 0x06018D11 RID: 101649 RVA: 0x00704C9C File Offset: 0x00702E9C
	[NullableContext(2)]
	protected IBuffComponent GetBulletTarget()
	{
		IBuffComponent result;
		switch (this.BulletPosType)
		{
		case EPassiveEffectTargetType.ForSelf:
			result = this.OwnerBuffComponent;
			break;
		case EPassiveEffectTargetType.ForTarget:
			result = base.OpponentBuffComponent;
			break;
		case EPassiveEffectTargetType.ForBuffInstigator:
			result = base.InstigatorBuffComponent;
			break;
		case EPassiveEffectTargetType.ForBuffHolderTarget:
			result = this.GetBuffHolderSkillTarget();
			break;
		default:
			result = null;
			break;
		}
		return result;
	}

	// Token: 0x06018D12 RID: 101650 RVA: 0x00704CF0 File Offset: 0x00702EF0
	[NullableContext(2)]
	protected IBuffComponent GetBuffHolderSkillTarget()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		EntityHandle entityHandle;
		if (ownerBuffComponent == null)
		{
			entityHandle = null;
		}
		else
		{
			Entity entity = ownerBuffComponent.GetEntity();
			if (entity == null)
			{
				entityHandle = null;
			}
			else
			{
				CharacterSkillComponent characterSkillComponent = entity.CheckGetComponent<CharacterSkillComponent>();
				entityHandle = ((characterSkillComponent != null) ? characterSkillComponent.SkillTarget : null);
			}
		}
		EntityHandle entityHandle2 = entityHandle;
		if (entityHandle2 == null)
		{
			return this.OwnerBuffComponent;
		}
		WorldEntity entity2 = entityHandle2.Entity;
		if (entity2 == null)
		{
			return null;
		}
		return entity2.CheckGetComponent<BaseBuffComponent>();
	}

	// Token: 0x06018D13 RID: 101651 RVA: 0x00704D44 File Offset: 0x00702F44
	protected void ExecutePerId(Action<long, float, IBuffComponent> execFunction)
	{
		for (int i = 0; i < this.Ids.Length; i++)
		{
			IBuffComponent buffComponent = base.GetEffectTarget();
			PlayerBuffComponent playerBuffComponent = buffComponent as PlayerBuffComponent;
			if (playerBuffComponent != null)
			{
				buffComponent = playerBuffComponent.GetCurrentBuffComponent();
			}
			if (buffComponent != null)
			{
				float times = this.GetTimes(i);
				if (!this.UseCustomTimes || times != 0f)
				{
					execFunction(this.Ids[i], times, buffComponent);
				}
			}
		}
	}

	// Token: 0x06018D14 RID: 101652 RVA: 0x00704DA8 File Offset: 0x00702FA8
	protected unsafe void ProcessBulletId(long id, float times, IBuffComponent target)
	{
		IBuffComponent bulletTarget = this.GetBulletTarget();
		FTransformDouble? ftransformDouble;
		if (bulletTarget == null)
		{
			ftransformDouble = null;
		}
		else
		{
			BaseActorComponent actorComponent = bulletTarget.GetActorComponent();
			ftransformDouble = ((actorComponent != null) ? new FTransformDouble?(actorComponent.ActorTransform) : null);
		}
		FTransformDouble? initialTransform = ftransformDouble;
		EntityHandle instigatorEntity = base.InstigatorEntity;
		TsBaseCharacter tsBaseCharacter;
		if (instigatorEntity == null)
		{
			tsBaseCharacter = null;
		}
		else
		{
			WorldEntity entity = instigatorEntity.Entity;
			if (entity == null)
			{
				tsBaseCharacter = null;
			}
			else
			{
				CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
				tsBaseCharacter = ((component != null) ? component.Actor : null);
			}
		}
		TsBaseCharacter tsBaseCharacter2 = tsBaseCharacter;
		if (tsBaseCharacter2 == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "尝试执行添加子弹的额外效果时找不到对应的buff施加者";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", this.BuffId);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "持有者";
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			ptr = new ValueTuple<string, object>(item, (ownerBuffComponent != null) ? ownerBuffComponent.GetDebugName() : null);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (initialTransform == null)
		{
			return;
		}
		long? messageId = this.Buff.MessageId;
		int num = 0;
		while ((float)num < times)
		{
			ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(tsBaseCharacter2, id.ToString(), initialTransform, new BulletController.BulletCreateParams
			{
				SyncType = EBulletSyncType.SyncCreate,
				CreateOnAuthority = false
			}, messageId, EBulletCreateSource.Others);
			num++;
		}
	}

	// Token: 0x06018D15 RID: 101653 RVA: 0x00704ED8 File Offset: 0x007030D8
	private void ProcessBuffId(long id, float stackNum, IBuffComponent target)
	{
		IActiveBuff buff = this.Buff;
		int? stackCount = new int?((int)stackNum);
		bool isIterable = true;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
		defaultInterpolatedStringHandler.AppendLiteral("瞬间型额外效果迭代添加（前置buff Id=");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
		defaultInterpolatedStringHandler.AppendLiteral("）");
		target.AddIterativeBuff(id, buff, stackCount, isIterable, defaultInterpolatedStringHandler.ToStringAndClear(), null, null);
	}

	// Token: 0x06018D16 RID: 101654 RVA: 0x00704F3C File Offset: 0x0070313C
	private void ProcessBuffRemoveId(long id, float stackNum, IBuffComponent target)
	{
		int stackCount = (int)stackNum;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
		defaultInterpolatedStringHandler.AppendLiteral("瞬间型额外效果移除（前置buff Id=");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
		defaultInterpolatedStringHandler.AppendLiteral("）");
		string reason = defaultInterpolatedStringHandler.ToStringAndClear();
		long? preMessageId = null;
		bool? isServerRequest = null;
		IActiveBuff buff = this.Buff;
		target.RemoveBuff(id, stackCount, reason, preMessageId, isServerRequest, (buff != null) ? buff.InstigatorId : null);
	}

	// Token: 0x06018D17 RID: 101655 RVA: 0x00704FB4 File Offset: 0x007031B4
	private float GetTimes(int index)
	{
		if (this.UseCustomTimes)
		{
			float? customTimes = this.GetCustomTimes();
			if (customTimes != null)
			{
				return customTimes.Value;
			}
		}
		float result;
		switch (this.GoalType)
		{
		case EPassiveEffectGoalType.Buff:
			result = (float)AbilityUtils.GetArrayValue(this.Times, index, 0.0);
			break;
		case EPassiveEffectGoalType.Bullet:
			result = (float)AbilityUtils.GetArrayValue(this.Times, index, 1.0);
			break;
		case EPassiveEffectGoalType.RemoveBuff:
			result = (float)AbilityUtils.GetArrayValue(this.Times, index, -1.0);
			break;
		default:
			result = 0f;
			break;
		}
		return result;
	}

	// Token: 0x06018D18 RID: 101656 RVA: 0x00705050 File Offset: 0x00703250
	private float? GetCustomTimes()
	{
		CustomTimesConfig customTimesConfig = Array.Find<CustomTimesConfig>(this.CustomTimesConfigs ?? Array.Empty<CustomTimesConfig>(), (CustomTimesConfig v) => v != null && v.CalcType == ECustomTimesCalcType.DependAttribute);
		if (customTimesConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.GHY;
			string message = "自定义Times已开启(UseCustomTimes)，但未找到有效的依赖属性(DependAttribute)配置，将回退到默认Times";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("buffId", this.BuffId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		BaseAttributeComponent customTimesAttributeComponent = this.GetCustomTimesAttributeComponent(customTimesConfig.ValueTarget);
		if (customTimesAttributeComponent == null)
		{
			return null;
		}
		return new float?(CustomTimesConfigParser.CalcCustomTimes(customTimesConfig, customTimesAttributeComponent));
	}

	// Token: 0x06018D19 RID: 101657 RVA: 0x007050F8 File Offset: 0x007032F8
	[NullableContext(2)]
	private BaseAttributeComponent GetCustomTimesAttributeComponent(ECustomTimesValueTarget valueTarget)
	{
		BaseAttributeComponent result;
		if (valueTarget != ECustomTimesValueTarget.Owner)
		{
			if (valueTarget != ECustomTimesValueTarget.Instigator)
			{
				result = null;
			}
			else
			{
				CharacterBuffComponent instigatorBuffComponent = base.InstigatorBuffComponent;
				result = ((instigatorBuffComponent != null) ? instigatorBuffComponent.GetAttributeComponent() : null);
			}
		}
		else
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			result = ((ownerBuffComponent != null) ? ownerBuffComponent.GetAttributeComponent() : null);
		}
		return result;
	}

	// Token: 0x0400C194 RID: 49556
	public EPassiveEffectGoalType GoalType;

	// Token: 0x0400C195 RID: 49557
	public long[] Ids = Array.Empty<long>();

	// Token: 0x0400C196 RID: 49558
	[Nullable(2)]
	public double[] Times;

	// Token: 0x0400C197 RID: 49559
	public bool UseCustomTimes;

	// Token: 0x0400C198 RID: 49560
	[Nullable(2)]
	private CustomTimesConfig[] CustomTimesConfigs;

	// Token: 0x0400C199 RID: 49561
	public EPassiveEffectTargetType BulletPosType;

	// Token: 0x0400C19A RID: 49562
	private const int DEFAULT_PASSIVE_BUFF_REMOVE_TIMES = -1;

	// Token: 0x02009335 RID: 37685
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0403102D RID: 200749
		[Nullable(0)]
		public static Func<string, long> <0>__Parse;

		// Token: 0x0403102E RID: 200750
		[Nullable(0)]
		public static Func<string, double> <1>__Parse;
	}
}
