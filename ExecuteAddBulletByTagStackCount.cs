using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002F7C RID: 12156
[NullableContext(1)]
[Nullable(0)]
public class ExecuteAddBulletByTagStackCount : PeriodExecution
{
	// Token: 0x06018D22 RID: 101666 RVA: 0x007055D7 File Offset: 0x007037D7
	public ExecuteAddBulletByTagStackCount(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D23 RID: 101667 RVA: 0x007055E0 File Offset: 0x007037E0
	protected unsafe override void InitParameters(ExtraEffectParameters parameters)
	{
		this.TargetType = EExecutionTargetType.Self;
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length < 2)
		{
			return;
		}
		this.BulletPosType = (EPassiveEffectTargetType)int.Parse(extraEffectParameters_[0]);
		this.TagIdGetStackCount = GameplayTagUtils.GetTagIdByName(extraEffectParameters_[1]);
		int num = extraEffectParameters_.Length - 2;
		if (num <= 0)
		{
			this.BulletCreateInfos = Array.Empty<string[]>();
			return;
		}
		this.BulletCreateInfos = new string[num][];
		for (int i = 2; i < extraEffectParameters_.Length; i++)
		{
			string[] array = extraEffectParameters_[i].Split('#', StringSplitOptions.None);
			string[] array2 = new string[array.Length];
			for (int j = 0; j < array.Length; j++)
			{
				array2[j] = array[j].Trim();
			}
			if (array2.Length < 3)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.BuffItem;
				ELogAuthor author = ELogAuthor.HCW;
				string message = "ExecuteAddBulletByTagStackCount的参数个数错误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BuffId", this.BuffId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("参数", extraEffectParameters_);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			else
			{
				this.BulletCreateInfos[i - 2] = array2;
			}
		}
	}

	// Token: 0x06018D24 RID: 101668 RVA: 0x00705704 File Offset: 0x00703904
	[return: Nullable(2)]
	public unsafe override object OnExecute(params object[] args)
	{
		Entity ownerEntity = base.OwnerEntity;
		BaseTagComponent baseTagComponent = (ownerEntity != null) ? ownerEntity.GetComponent<BaseTagComponent>() : null;
		int? num = (baseTagComponent != null) ? new int?(baseTagComponent.GetTagCount(this.TagIdGetStackCount)) : null;
		if (num != null)
		{
			int? num2 = num;
			int i = 0;
			if (!(num2.GetValueOrDefault() <= i & num2 != null))
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
				if (initialTransform == null || this.BulletCreateInfos == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.BuffItem;
					ELogAuthor author = ELogAuthor.HCW;
					string message = "ExecuteAddBulletByTagStackCount尝试执行添加子弹的额外效果时找不到对应的buff施加者或接收者";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BuffId", this.BuffId);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
					string item = "持有者";
					IActiveBuff buff = this.Buff;
					ptr = new ValueTuple<string, object>(item, (buff != null) ? buff.GetOwnerDebugName() : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("BulletCreateInfos", this.BulletCreateInfos);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					return null;
				}
				long? messageId = this.Buff.MessageId;
				foreach (string[] array in this.BulletCreateInfos)
				{
					float stackCountNeed = float.Parse(array[0]);
					string @operator = array[1];
					if (this.CompareStackCount(@operator, (float)num.Value, stackCountNeed))
					{
						for (int j = 2; j < array.Length; j++)
						{
							string bulletRowName = array[j];
							ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(base.OwnerEntity, bulletRowName, initialTransform, new BulletController.BulletCreateParams
							{
								SyncType = EBulletSyncType.SyncCreate,
								CreateOnAuthority = false
							}, messageId, EBulletCreateSource.Others);
						}
					}
				}
				return null;
			}
		}
		return null;
	}

	// Token: 0x06018D25 RID: 101669 RVA: 0x007058DC File Offset: 0x00703ADC
	protected unsafe bool CompareStackCount(string @operator, float stackCountByOwner, float stackCountNeed)
	{
		if (@operator == ">")
		{
			return stackCountByOwner > stackCountNeed;
		}
		if (@operator == ">=")
		{
			return stackCountByOwner >= stackCountNeed;
		}
		if (@operator == "<")
		{
			return stackCountByOwner < stackCountNeed;
		}
		if (@operator == "<=")
		{
			return stackCountByOwner <= stackCountNeed;
		}
		if (@operator == "==")
		{
			return stackCountByOwner == stackCountNeed;
		}
		if (!(@operator == "!="))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BuffItem;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "ExecuteAddBulletByTagStackCount的比较运算符错误";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", this.BuffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("operator", @operator);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		return stackCountByOwner != stackCountNeed;
	}

	// Token: 0x06018D26 RID: 101670 RVA: 0x007059C0 File Offset: 0x00703BC0
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

	// Token: 0x06018D27 RID: 101671 RVA: 0x00705A14 File Offset: 0x00703C14
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

	// Token: 0x0400C19E RID: 49566
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public string[][] BulletCreateInfos;

	// Token: 0x0400C19F RID: 49567
	public EPassiveEffectTargetType BulletPosType;

	// Token: 0x0400C1A0 RID: 49568
	public int TagIdGetStackCount;
}
