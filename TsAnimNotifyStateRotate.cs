using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D70 RID: 3440
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotate.TsAnimNotifyStateRotate_C")]
public class TsAnimNotifyStateRotate : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000438 RID: 1080
	// (get) Token: 0x06004A73 RID: 19059 RVA: 0x000A27A4 File Offset: 0x000A09A4
	// (set) Token: 0x06004A74 RID: 19060 RVA: 0x000A27B4 File Offset: 0x000A09B4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 旋转速度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_旋转速度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_旋转速度) = value;
		}
	}

	// Token: 0x17000439 RID: 1081
	// (get) Token: 0x06004A75 RID: 19061 RVA: 0x000A27C5 File Offset: 0x000A09C5
	// (set) Token: 0x06004A76 RID: 19062 RVA: 0x000A27D5 File Offset: 0x000A09D5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否自动朝向目标
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_是否自动朝向目标) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_是否自动朝向目标) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700043A RID: 1082
	// (get) Token: 0x06004A77 RID: 19063 RVA: 0x000A27E6 File Offset: 0x000A09E6
	// (set) Token: 0x06004A78 RID: 19064 RVA: 0x000A27F6 File Offset: 0x000A09F6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否平滑旋转
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_是否平滑旋转) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_是否平滑旋转) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700043B RID: 1083
	// (get) Token: 0x06004A79 RID: 19065 RVA: 0x000A2807 File Offset: 0x000A0A07
	// (set) Token: 0x06004A7A RID: 19066 RVA: 0x000A281B File Offset: 0x000A0A1B
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat Curve
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateRotate.__PropertyOffset_Curve);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateRotate.__PropertyOffset_Curve, value);
		}
	}

	// Token: 0x1700043C RID: 1084
	// (get) Token: 0x06004A7B RID: 19067 RVA: 0x000A2830 File Offset: 0x000A0A30
	// (set) Token: 0x06004A7C RID: 19068 RVA: 0x000A2840 File Offset: 0x000A0A40
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否应用旋转偏移
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_是否应用旋转偏移) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_是否应用旋转偏移) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700043D RID: 1085
	// (get) Token: 0x06004A7D RID: 19069 RVA: 0x000A2851 File Offset: 0x000A0A51
	// (set) Token: 0x06004A7E RID: 19070 RVA: 0x000A2861 File Offset: 0x000A0A61
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 旋转偏移
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_旋转偏移);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_旋转偏移) = value;
		}
	}

	// Token: 0x1700043E RID: 1086
	// (get) Token: 0x06004A7F RID: 19071 RVA: 0x000A2872 File Offset: 0x000A0A72
	// (set) Token: 0x06004A80 RID: 19072 RVA: 0x000A2882 File Offset: 0x000A0A82
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 设置为朝向黑板目标
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_设置为朝向黑板目标) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_设置为朝向黑板目标) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700043F RID: 1087
	// (get) Token: 0x06004A81 RID: 19073 RVA: 0x000A2893 File Offset: 0x000A0A93
	// (set) Token: 0x06004A82 RID: 19074 RVA: 0x000A28A3 File Offset: 0x000A0AA3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EAnsRotateBlackboardType 黑板类型
	{
		get
		{
			return (EAnsRotateBlackboardType)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_黑板类型));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_黑板类型) = (byte)value;
		}
	}

	// Token: 0x17000440 RID: 1088
	// (get) Token: 0x06004A83 RID: 19075 RVA: 0x000A28B4 File Offset: 0x000A0AB4
	// (set) Token: 0x06004A84 RID: 19076 RVA: 0x000A28C8 File Offset: 0x000A0AC8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string 朝向黑板目标名
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_朝向黑板目标名)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_朝向黑板目标名)), value);
		}
	}

	// Token: 0x17000441 RID: 1089
	// (get) Token: 0x06004A85 RID: 19077 RVA: 0x000A28DD File Offset: 0x000A0ADD
	// (set) Token: 0x06004A86 RID: 19078 RVA: 0x000A28ED File Offset: 0x000A0AED
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 停止旋转阈值
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_停止旋转阈值);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_停止旋转阈值) = value;
		}
	}

	// Token: 0x17000442 RID: 1090
	// (get) Token: 0x06004A87 RID: 19079 RVA: 0x000A28FE File Offset: 0x000A0AFE
	// (set) Token: 0x06004A88 RID: 19080 RVA: 0x000A290E File Offset: 0x000A0B0E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 继续旋转阈值
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_继续旋转阈值);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_继续旋转阈值) = value;
		}
	}

	// Token: 0x17000443 RID: 1091
	// (get) Token: 0x06004A89 RID: 19081 RVA: 0x000A291F File Offset: 0x000A0B1F
	// (set) Token: 0x06004A8A RID: 19082 RVA: 0x000A292F File Offset: 0x000A0B2F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 在横板模式中禁用
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_在横板模式中禁用) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_在横板模式中禁用) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000444 RID: 1092
	// (get) Token: 0x06004A8B RID: 19083 RVA: 0x000A2940 File Offset: 0x000A0B40
	// (set) Token: 0x06004A8C RID: 19084 RVA: 0x000A2950 File Offset: 0x000A0B50
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 只在横板模式中生效
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_只在横板模式中生效) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_只在横板模式中生效) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000445 RID: 1093
	// (get) Token: 0x06004A8D RID: 19085 RVA: 0x000A2961 File Offset: 0x000A0B61
	// (set) Token: 0x06004A8E RID: 19086 RVA: 0x000A2971 File Offset: 0x000A0B71
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 定向旋转功能
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_定向旋转功能) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_定向旋转功能) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000446 RID: 1094
	// (get) Token: 0x06004A8F RID: 19087 RVA: 0x000A2982 File Offset: 0x000A0B82
	// (set) Token: 0x06004A90 RID: 19088 RVA: 0x000A2992 File Offset: 0x000A0B92
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 定向旋转阈值最小值
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_定向旋转阈值最小值);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_定向旋转阈值最小值) = value;
		}
	}

	// Token: 0x17000447 RID: 1095
	// (get) Token: 0x06004A91 RID: 19089 RVA: 0x000A29A3 File Offset: 0x000A0BA3
	// (set) Token: 0x06004A92 RID: 19090 RVA: 0x000A29B3 File Offset: 0x000A0BB3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 定向旋转阈值最大值
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_定向旋转阈值最大值);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_定向旋转阈值最大值) = value;
		}
	}

	// Token: 0x17000448 RID: 1096
	// (get) Token: 0x06004A93 RID: 19091 RVA: 0x000A29C4 File Offset: 0x000A0BC4
	// (set) Token: 0x06004A94 RID: 19092 RVA: 0x000A29D4 File Offset: 0x000A0BD4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EAnsRotateDetectionType 定向旋转方式
	{
		get
		{
			return (EAnsRotateDetectionType)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_定向旋转方式));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_定向旋转方式) = (byte)value;
		}
	}

	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x06004A95 RID: 19093 RVA: 0x000A29E5 File Offset: 0x000A0BE5
	// (set) Token: 0x06004A96 RID: 19094 RVA: 0x000A29F5 File Offset: 0x000A0BF5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 调试定向旋转范围
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_调试定向旋转范围) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_调试定向旋转范围) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x06004A97 RID: 19095 RVA: 0x000A2A08 File Offset: 0x000A0C08
	// (set) Token: 0x06004A98 RID: 19096 RVA: 0x000A2A41 File Offset: 0x000A0C41
	[UProperty(EPropertyFlags.CPF_None)]
	public FGameplayTagContainer 屏蔽标签列表
	{
		get
		{
			base.FastCheckIsValid();
			FGameplayTagContainer result;
			if ((result = this._屏蔽标签列表) == null)
			{
				result = (this._屏蔽标签列表 = new FGameplayTagContainer(base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_屏蔽标签列表, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateRotate.__PropertyOffset_屏蔽标签列表, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x06004A99 RID: 19097 RVA: 0x000A2A6C File Offset: 0x000A0C6C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004A9A RID: 19098 RVA: 0x000A2B14 File Offset: 0x000A0D14
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		this.Initialize();
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			UBaseAbilitySystemComponent abilitySystemComponent = tsBaseCharacter.AbilitySystemComponent;
			bool flag;
			if (abilitySystemComponent == null)
			{
				flag = true;
			}
			else
			{
				FGameplayTagContainer 屏蔽标签列表 = this.屏蔽标签列表;
				flag = !abilitySystemComponent.HasAnyGameplayTag(屏蔽标签列表);
			}
			if (flag)
			{
				CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
				Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
				if (entity == null || !entity.Valid)
				{
					return false;
				}
				if (!this.ParamsMap.ContainsKey(entity.Id))
				{
					this.ParamsMap.Add(entity.Id, new AnsRotateParam(totalDuration));
				}
				else
				{
					this.ParamsMap[entity.Id].Update(0f, totalDuration);
				}
				if (this.在横板模式中禁用)
				{
					CharacterSplineMoveComponent component = entity.GetComponent<CharacterSplineMoveComponent>();
					if (component != null && component.Active)
					{
						return false;
					}
				}
				else if (this.只在横板模式中生效)
				{
					CharacterSplineMoveComponent component2 = entity.GetComponent<CharacterSplineMoveComponent>();
					if (component2 == null || !component2.Active)
					{
						return false;
					}
				}
				CharacterSkillComponent component3 = entity.GetComponent<CharacterSkillComponent>();
				if (component3 == null || !component3.Valid)
				{
					return false;
				}
				AnsRotateParam ansRotateParam = this.ParamsMap[entity.Id];
				if (this.定向旋转功能)
				{
					this.UpdateAnsBlackBoardTargetType(ansRotateParam);
					this.UpdateContinueDetection(ansRotateParam, component3, tsBaseCharacter.CharacterActorComponent);
				}
				else
				{
					this.UpdateBlackBoardTargetType(component3);
				}
				component3.SetSkillCanRotate(true);
				component3.SetSkillRotateToTarget(this.是否自动朝向目标 || this.设置为朝向黑板目标, this.是否应用旋转偏移, this.旋转偏移, this.停止旋转阈值, this.继续旋转阈值);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06004A9B RID: 19099 RVA: 0x000A2C98 File Offset: 0x000A0E98
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004A9C RID: 19100 RVA: 0x000A2D40 File Offset: 0x000A0F40
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null || !entity.Valid)
		{
			return false;
		}
		AnsRotateParam valueOrDefault = this.ParamsMap.GetValueOrDefault(entity.Id);
		if (valueOrDefault == null)
		{
			return false;
		}
		float nowTime = valueOrDefault.NowTime;
		valueOrDefault.NowTime += frameDeltaTime;
		if (this.在横板模式中禁用)
		{
			CharacterSplineMoveComponent component = entity.GetComponent<CharacterSplineMoveComponent>();
			if (component != null && component.Active)
			{
				return false;
			}
		}
		else if (this.只在横板模式中生效)
		{
			CharacterSplineMoveComponent component2 = entity.GetComponent<CharacterSplineMoveComponent>();
			if (component2 == null || !component2.Active)
			{
				return false;
			}
		}
		CharacterSkillComponent component3 = entity.GetComponent<CharacterSkillComponent>();
		if (component3 == null || !component3.Valid)
		{
			return false;
		}
		if (this.定向旋转功能)
		{
			this.UpdateContinueDetection(valueOrDefault, component3, tsBaseCharacter.CharacterActorComponent);
			this.DebugDraw(valueOrDefault, tsBaseCharacter.CharacterActorComponent);
		}
		float num = this.旋转速度;
		if (this.是否平滑旋转)
		{
			float num2 = nowTime * valueOrDefault.TotalDurationReciprocal;
			float num3 = valueOrDefault.NowTime * valueOrDefault.TotalDurationReciprocal;
			if (this.Curve != null)
			{
				num2 = this.Curve.GetFloatValue(Singleton<MathUtils>.Instance.Clamp(num2, 0f, 1f));
				num3 = this.Curve.GetFloatValue(Singleton<MathUtils>.Instance.Clamp(num3, 0f, 1f));
			}
			float num4 = Math.Abs(this.GetSkillRotateAngle(tsBaseCharacter.CharacterActorComponent, component3));
			float num5 = Singleton<MathUtils>.Instance.Clamp((num3 - num2) / (1f - num2), 0f, 1f);
			float currentValue = num4 * num5 / frameDeltaTime;
			num = Singleton<MathUtils>.Instance.Clamp(currentValue, 0f, num);
		}
		component3.SetSkillRotateSpeed(num);
		return true;
	}

	// Token: 0x06004A9D RID: 19101 RVA: 0x000A2F0C File Offset: 0x000A110C
	private float GetSkillRotateAngle(CharacterActorComponent actorComp, CharacterSkillComponent skillComp)
	{
		Vector actorForwardProxy = actorComp.ActorForwardProxy;
		Vector skillRotateDirect = skillComp.GetSkillRotateDirect();
		if (actorForwardProxy.IsNearlyZero(9.999999747378752E-05) || skillRotateDirect.IsNearlyZero(9.999999747378752E-05))
		{
			return 180f;
		}
		return Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityAbsForActor(actorComp, actorForwardProxy, skillRotateDirect);
	}

	// Token: 0x06004A9E RID: 19102 RVA: 0x000A2F5C File Offset: 0x000A115C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004A9F RID: 19103 RVA: 0x000A2FFC File Offset: 0x000A11FC
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			Dictionary<int, AnsRotateParam> paramsMap = this.ParamsMap;
			if (paramsMap != null)
			{
				CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
				paramsMap.Remove((characterActorComponent != null) ? characterActorComponent.Entity.Id : 0);
			}
			CharacterActorComponent characterActorComponent2 = tsBaseCharacter.CharacterActorComponent;
			CharacterSkillComponent characterSkillComponent;
			if (characterActorComponent2 == null)
			{
				characterSkillComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent2.Entity;
				characterSkillComponent = ((entity != null) ? entity.GetComponent<CharacterSkillComponent>() : null);
			}
			CharacterSkillComponent characterSkillComponent2 = characterSkillComponent;
			if (characterSkillComponent2 != null && characterSkillComponent2.Valid)
			{
				characterSkillComponent2.SetSkillCanRotate(false);
				characterSkillComponent2.SetRotateTarget(null, ESkillRotateType.None);
			}
		}
		return false;
	}

	// Token: 0x06004AA0 RID: 19104 RVA: 0x000A307B File Offset: 0x000A127B
	private void Initialize()
	{
		if (this.IsInitialize)
		{
			return;
		}
		this.IsInitialize = true;
		this.ParamsMap = new Dictionary<int, AnsRotateParam>();
	}

	// Token: 0x06004AA1 RID: 19105 RVA: 0x000A3098 File Offset: 0x000A1298
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x06004AA2 RID: 19106 RVA: 0x000A3113 File Offset: 0x000A1313
	protected override string GetNotifyName_Implementation()
	{
		return "旋转到黑板目标或技能目标或输入方向";
	}

	// Token: 0x06004AA3 RID: 19107 RVA: 0x000A311C File Offset: 0x000A131C
	private void UpdateBlackBoardTargetType(BaseSkillComponent skillComp)
	{
		if (this.设置为朝向黑板目标)
		{
			switch (this.黑板类型)
			{
			case EAnsRotateBlackboardType.EntityId:
				skillComp.SetRotateTarget(this.朝向黑板目标名, ESkillRotateType.BlackBoardEntityId);
				return;
			case EAnsRotateBlackboardType.Location:
				skillComp.SetRotateTarget(this.朝向黑板目标名, ESkillRotateType.BlackBoardLocation);
				return;
			case EAnsRotateBlackboardType.Direct:
				skillComp.SetRotateTarget(this.朝向黑板目标名, ESkillRotateType.BlackBoardDirect);
				return;
			case EAnsRotateBlackboardType.Int:
				skillComp.SetRotateTarget(this.朝向黑板目标名, ESkillRotateType.BlackBoardInt);
				return;
			default:
				skillComp.SetRotateTarget(null, ESkillRotateType.None);
				break;
			}
		}
	}

	// Token: 0x06004AA4 RID: 19108 RVA: 0x000A3190 File Offset: 0x000A1390
	private void UpdateAnsBlackBoardTargetType(AnsRotateParam ansRotateParam)
	{
		if (this.设置为朝向黑板目标)
		{
			switch (this.黑板类型)
			{
			case EAnsRotateBlackboardType.EntityId:
				ansRotateParam.SetRotateTarget(this.朝向黑板目标名, ESkillRotateType.BlackBoardEntityId);
				return;
			case EAnsRotateBlackboardType.Location:
				ansRotateParam.SetRotateTarget(this.朝向黑板目标名, ESkillRotateType.BlackBoardLocation);
				return;
			case EAnsRotateBlackboardType.Direct:
				ansRotateParam.SetRotateTarget(this.朝向黑板目标名, ESkillRotateType.BlackBoardDirect);
				return;
			case EAnsRotateBlackboardType.Int:
				ansRotateParam.SetRotateTarget(this.朝向黑板目标名, ESkillRotateType.BlackBoardInt);
				return;
			default:
				ansRotateParam.SetRotateTarget(null, ESkillRotateType.None);
				break;
			}
		}
	}

	// Token: 0x06004AA5 RID: 19109 RVA: 0x000A3204 File Offset: 0x000A1404
	private bool IsInContinueDetectionAngle(float angle)
	{
		float num = (this.定向旋转阈值最大值 - this.定向旋转阈值最小值) % 360f;
		if (!Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.定向旋转阈值最大值, (double)this.定向旋转阈值最小值, null) && (Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null) || Singleton<MathUtils>.Instance.IsNearlyEqual((double)num, 360.0, null)))
		{
			return true;
		}
		float num2 = 180f + this.定向旋转阈值最小值;
		float num3 = Singleton<MathUtils>.Instance.WrapAngle(angle - num2);
		float num4 = Singleton<MathUtils>.Instance.WrapAngle(this.定向旋转阈值最大值 - num2);
		return -180f <= num3 && num3 <= num4;
	}

	// Token: 0x06004AA6 RID: 19110 RVA: 0x000A32C4 File Offset: 0x000A14C4
	private void UpdateContinueDetection(AnsRotateParam ansRotateParam, BaseSkillComponent skillComp, CharacterActorComponent actorComp)
	{
		Vector tmpVector = this.TmpVector;
		SkillUtils.GetSkillRotateDirect(ModelBase<CharacterModel>.Instance.GetHandleByEntity(actorComp.Entity), ansRotateParam.SkillRotateTarget, null, tmpVector);
		if (tmpVector.IsNearlyZero(9.999999747378752E-05))
		{
			ansRotateParam.RotateDetectionType = EAnsRotateDetectionTypeLocal.None;
			return;
		}
		float angleOffsetInGravityForActor = Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityForActor(actorComp, actorComp.ActorForwardProxy, tmpVector);
		switch (this.定向旋转方式)
		{
		case EAnsRotateDetectionType.持续旋转:
			if (ansRotateParam.RotateDetectionType != EAnsRotateDetectionTypeLocal.持续旋转)
			{
				if (!this.IsInContinueDetectionAngle(angleOffsetInGravityForActor))
				{
					skillComp.SetRotateTarget(null, ESkillRotateType.StandBy);
					return;
				}
				ansRotateParam.RotateDetectionType = EAnsRotateDetectionTypeLocal.持续旋转;
				this.UpdateBlackBoardTargetType(skillComp);
				return;
			}
			break;
		case EAnsRotateDetectionType.单次旋转:
			if (ansRotateParam.RotateDetectionType != EAnsRotateDetectionTypeLocal.单次旋转)
			{
				ansRotateParam.RotateDetectionType = EAnsRotateDetectionTypeLocal.单次旋转;
				if (!this.IsInContinueDetectionAngle(angleOffsetInGravityForActor))
				{
					skillComp.SetRotateTarget(null, ESkillRotateType.StandBy);
					return;
				}
				skillComp.SetRotateTarget(Vector.Create(tmpVector), ESkillRotateType.Direct);
				return;
			}
			break;
		case EAnsRotateDetectionType.动态单次旋转:
			if (ansRotateParam.RotateDetectionType != EAnsRotateDetectionTypeLocal.动态单次旋转)
			{
				if (!this.IsInContinueDetectionAngle(angleOffsetInGravityForActor))
				{
					skillComp.SetRotateTarget(null, ESkillRotateType.StandBy);
					return;
				}
				ansRotateParam.RotateDetectionType = EAnsRotateDetectionTypeLocal.动态单次旋转;
				skillComp.SetRotateTarget(Vector.Create(tmpVector), ESkillRotateType.Direct);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06004AA7 RID: 19111 RVA: 0x000A33C8 File Offset: 0x000A15C8
	private void DebugDraw(AnsRotateParam ansRotateParam, CharacterActorComponent actorComp)
	{
		if (!this.调试定向旋转范围 || !this.定向旋转功能)
		{
			return;
		}
		Vector tmpVector = this.TmpVector;
		SkillUtils.GetSkillRotateDirect(ModelBase<CharacterModel>.Instance.GetHandleByEntity(actorComp.Entity), ansRotateParam.SkillRotateTarget, null, tmpVector);
		bool flag = false;
		if (!tmpVector.IsNearlyZero(9.999999747378752E-05))
		{
			float angleOffsetInGravityForActor = Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityForActor(actorComp, actorComp.ActorForwardProxy, tmpVector);
			if (this.IsInContinueDetectionAngle(angleOffsetInGravityForActor))
			{
				flag = true;
			}
		}
		Rotator actorRotationProxy = actorComp.ActorRotationProxy;
		Rotator rotator = new Rotator(0f, MathCommon.Warp(this.定向旋转阈值最大值 - this.定向旋转阈值最小值, 0f, 360.001f) / 2f + this.定向旋转阈值最小值 + actorRotationProxy.Yaw, 0f);
		Singleton<GravityUtils>.Instance.GetBaseQuatInGravityForActor(actorComp, this.TmpQuat);
		Singleton<GravityUtils>.Instance.GetRotatorInNormal(rotator, this.TmpQuat, rotator);
		Vector tmpVector2 = this.TmpVector;
		rotator.Vector(tmpVector2);
		Vector tmpVector3 = this.TmpVector1;
		Vector vector = tmpVector3;
		FVectorDouble socketLocation = actorComp.GetSocketLocation(Singleton<CharacterNameDefines>.Instance.ROOT);
		vector.DeepCopy(socketLocation);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actorComp, tmpVector3, 10.0);
		UKismetSystemLibrary.D_DrawDebugCone(GlobalData.World, tmpVector3.ToUeVector(false), tmpVector2.ToUeVector(false), 500f, MathCommon.Warp(this.定向旋转阈值最大值 - this.定向旋转阈值最小值, 0f, 360.001f) * 0.017453292f / 2f, 0f, 100, flag ? ColorUtils.LinearYellow : ColorUtils.LinearCyan, 0f, 1f);
	}

	// Token: 0x06004AA8 RID: 19112 RVA: 0x000A3558 File Offset: 0x000A1758
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateRotate._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotate.TsAnimNotifyStateRotate_C");
		}
		return TsAnimNotifyStateRotate._ClassPtr;
	}

	// Token: 0x06004AA9 RID: 19113 RVA: 0x000A357C File Offset: 0x000A177C
	public TsAnimNotifyStateRotate() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRotate.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004AAA RID: 19114 RVA: 0x000A35A4 File Offset: 0x000A17A4
	public TsAnimNotifyStateRotate(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRotate.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004AAB RID: 19115 RVA: 0x000A35D7 File Offset: 0x000A17D7
	protected TsAnimNotifyStateRotate(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004AAC RID: 19116 RVA: 0x000A3618 File Offset: 0x000A1818
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004AAD RID: 19117 RVA: 0x000A3654 File Offset: 0x000A1854
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004AAE RID: 19118 RVA: 0x000A3690 File Offset: 0x000A1890
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004AAF RID: 19119 RVA: 0x000A36C3 File Offset: 0x000A18C3
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400151D RID: 5405
	private const int DEBUG_DRAW_LENGTH = 500;

	// Token: 0x0400151E RID: 5406
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, AnsRotateParam> ParamsMap;

	// Token: 0x0400151F RID: 5407
	private bool IsInitialize;

	// Token: 0x04001520 RID: 5408
	private readonly Vector TmpVector = Vector.Create();

	// Token: 0x04001521 RID: 5409
	private readonly Vector TmpVector1 = Vector.Create();

	// Token: 0x04001522 RID: 5410
	public readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001523 RID: 5411
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotate.TsAnimNotifyStateRotate_C";

	// Token: 0x04001524 RID: 5412
	private static IntPtr _ClassPtr;

	// Token: 0x04001525 RID: 5413
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001526 RID: 5414
	private static int __PropertyOffset_旋转速度;

	// Token: 0x04001527 RID: 5415
	private static int __PropertyOffset_是否自动朝向目标;

	// Token: 0x04001528 RID: 5416
	private static int __PropertyOffset_是否平滑旋转;

	// Token: 0x04001529 RID: 5417
	private static int __PropertyOffset_Curve;

	// Token: 0x0400152A RID: 5418
	private static int __PropertyOffset_是否应用旋转偏移;

	// Token: 0x0400152B RID: 5419
	private static int __PropertyOffset_旋转偏移;

	// Token: 0x0400152C RID: 5420
	private static int __PropertyOffset_设置为朝向黑板目标;

	// Token: 0x0400152D RID: 5421
	private static int __PropertyOffset_黑板类型;

	// Token: 0x0400152E RID: 5422
	private static int __PropertyOffset_朝向黑板目标名;

	// Token: 0x0400152F RID: 5423
	private static int __PropertyOffset_停止旋转阈值;

	// Token: 0x04001530 RID: 5424
	private static int __PropertyOffset_继续旋转阈值;

	// Token: 0x04001531 RID: 5425
	private static int __PropertyOffset_在横板模式中禁用;

	// Token: 0x04001532 RID: 5426
	private static int __PropertyOffset_只在横板模式中生效;

	// Token: 0x04001533 RID: 5427
	private static int __PropertyOffset_定向旋转功能;

	// Token: 0x04001534 RID: 5428
	private static int __PropertyOffset_定向旋转阈值最小值;

	// Token: 0x04001535 RID: 5429
	private static int __PropertyOffset_定向旋转阈值最大值;

	// Token: 0x04001536 RID: 5430
	private static int __PropertyOffset_定向旋转方式;

	// Token: 0x04001537 RID: 5431
	private static int __PropertyOffset_调试定向旋转范围;

	// Token: 0x04001538 RID: 5432
	private static int __PropertyOffset_屏蔽标签列表;

	// Token: 0x04001539 RID: 5433
	[Nullable(2)]
	private FGameplayTagContainer _屏蔽标签列表;
}
