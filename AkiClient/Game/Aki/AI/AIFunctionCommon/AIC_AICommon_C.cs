using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Monster.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon
{
	// Token: 0x02004387 RID: 17287
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/AIC_AICommon.AIC_AICommon_C")]
	[UnrealStructLayout(2280, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2276)]
	public class AIC_AICommon_C : __TsAiController_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DD39 RID: 187705 RVA: 0x00ACD2DF File Offset: 0x00ACB4DF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (AIC_AICommon_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/AI/AIFunctionCommon/AIC_AICommon.AIC_AICommon_C");
			}
			return AIC_AICommon_C._ClassPtr;
		}

		// Token: 0x0602DD3A RID: 187706 RVA: 0x00ACD304 File Offset: 0x00ACB504
		public AIC_AICommon_C() : this(BuiltinUtils.AllocNativeUObject(AIC_AICommon_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DD3B RID: 187707 RVA: 0x00ACD32C File Offset: 0x00ACB52C
		public AIC_AICommon_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AIC_AICommon_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D9C RID: 32156
		// (get) Token: 0x0602DD3C RID: 187708 RVA: 0x00ACD360 File Offset: 0x00ACB560
		// (set) Token: 0x0602DD3D RID: 187709 RVA: 0x00ACD399 File Offset: 0x00ACB599
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007D9D RID: 32157
		// (get) Token: 0x0602DD3E RID: 187710 RVA: 0x00ACD3BA File Offset: 0x00ACB5BA
		// (set) Token: 0x0602DD3F RID: 187711 RVA: 0x00ACD3CE File Offset: 0x00ACB5CE
		[Nullable(2)]
		public unsafe TsBaseCharacter 怪物自身对象
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + AIC_AICommon_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + AIC_AICommon_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007D9E RID: 32158
		// (get) Token: 0x0602DD40 RID: 187712 RVA: 0x00ACD3E3 File Offset: 0x00ACB5E3
		// (set) Token: 0x0602DD41 RID: 187713 RVA: 0x00ACD3F7 File Offset: 0x00ACB5F7
		public unsafe FVectorDouble 出生位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007D9F RID: 32159
		// (get) Token: 0x0602DD42 RID: 187714 RVA: 0x00ACD40C File Offset: 0x00ACB60C
		// (set) Token: 0x0602DD43 RID: 187715 RVA: 0x00ACD445 File Offset: 0x00ACB645
		public SAiConditions 行为树运行前置条件
		{
			get
			{
				base.FastCheckIsValid();
				SAiConditions result;
				if ((result = this._行为树运行前置条件) == null)
				{
					result = (this._行为树运行前置条件 = new SAiConditions(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SAiConditions.StaticStruct(), base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007DA0 RID: 32160
		// (get) Token: 0x0602DD44 RID: 187716 RVA: 0x00ACD468 File Offset: 0x00ACB668
		// (set) Token: 0x0602DD45 RID: 187717 RVA: 0x00ACD4A1 File Offset: 0x00ACB6A1
		public SAiConditions 默认感知保底
		{
			get
			{
				base.FastCheckIsValid();
				SAiConditions result;
				if ((result = this._默认感知保底) == null)
				{
					result = (this._默认感知保底 = new SAiConditions(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SAiConditions.StaticStruct(), base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007DA1 RID: 32161
		// (get) Token: 0x0602DD46 RID: 187718 RVA: 0x00ACD4C4 File Offset: 0x00ACB6C4
		// (set) Token: 0x0602DD47 RID: 187719 RVA: 0x00ACD4FD File Offset: 0x00ACB6FD
		public SAiConditions 战斗行为树前置
		{
			get
			{
				base.FastCheckIsValid();
				SAiConditions result;
				if ((result = this._战斗行为树前置) == null)
				{
					result = (this._战斗行为树前置 = new SAiConditions(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SAiConditions.StaticStruct(), base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007DA2 RID: 32162
		// (get) Token: 0x0602DD48 RID: 187720 RVA: 0x00ACD520 File Offset: 0x00ACB720
		// (set) Token: 0x0602DD49 RID: 187721 RVA: 0x00ACD559 File Offset: 0x00ACB759
		public TArray<AActor> 仇恨添加对象数组
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._仇恨添加对象数组) == null)
				{
					result = (this._仇恨添加对象数组 = new TArray<AActor>(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.仇恨添加对象数组.CopyAssign(value);
			}
		}

		// Token: 0x17007DA3 RID: 32163
		// (get) Token: 0x0602DD4A RID: 187722 RVA: 0x00ACD568 File Offset: 0x00ACB768
		// (set) Token: 0x0602DD4B RID: 187723 RVA: 0x00ACD5A1 File Offset: 0x00ACB7A1
		public TArray<AActor> 仇恨删除对象数组
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._仇恨删除对象数组) == null)
				{
					result = (this._仇恨删除对象数组 = new TArray<AActor>(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.仇恨删除对象数组.CopyAssign(value);
			}
		}

		// Token: 0x17007DA4 RID: 32164
		// (get) Token: 0x0602DD4C RID: 187724 RVA: 0x00ACD5AF File Offset: 0x00ACB7AF
		// (set) Token: 0x0602DD4D RID: 187725 RVA: 0x00ACD5BF File Offset: 0x00ACB7BF
		public unsafe int 当前仇恨列表数量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007DA5 RID: 32165
		// (get) Token: 0x0602DD4E RID: 187726 RVA: 0x00ACD5D0 File Offset: 0x00ACB7D0
		// (set) Token: 0x0602DD4F RID: 187727 RVA: 0x00ACD609 File Offset: 0x00ACB809
		public TArray<AActor> 感知添加对象数组
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._感知添加对象数组) == null)
				{
					result = (this._感知添加对象数组 = new TArray<AActor>(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.感知添加对象数组.CopyAssign(value);
			}
		}

		// Token: 0x17007DA6 RID: 32166
		// (get) Token: 0x0602DD50 RID: 187728 RVA: 0x00ACD618 File Offset: 0x00ACB818
		// (set) Token: 0x0602DD51 RID: 187729 RVA: 0x00ACD651 File Offset: 0x00ACB851
		public TArray<AActor> 感知删除对象数组
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._感知删除对象数组) == null)
				{
					result = (this._感知删除对象数组 = new TArray<AActor>(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.感知删除对象数组.CopyAssign(value);
			}
		}

		// Token: 0x17007DA7 RID: 32167
		// (get) Token: 0x0602DD52 RID: 187730 RVA: 0x00ACD65F File Offset: 0x00ACB85F
		// (set) Token: 0x0602DD53 RID: 187731 RVA: 0x00ACD66F File Offset: 0x00ACB86F
		public unsafe int 当前感知列表数量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007DA8 RID: 32168
		// (get) Token: 0x0602DD54 RID: 187732 RVA: 0x00ACD680 File Offset: 0x00ACB880
		// (set) Token: 0x0602DD55 RID: 187733 RVA: 0x00ACD6B9 File Offset: 0x00ACB8B9
		public TArray<AActor> 仇恨外感知添加
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._仇恨外感知添加) == null)
				{
					result = (this._仇恨外感知添加 = new TArray<AActor>(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.仇恨外感知添加.CopyAssign(value);
			}
		}

		// Token: 0x17007DA9 RID: 32169
		// (get) Token: 0x0602DD56 RID: 187734 RVA: 0x00ACD6C8 File Offset: 0x00ACB8C8
		// (set) Token: 0x0602DD57 RID: 187735 RVA: 0x00ACD701 File Offset: 0x00ACB901
		public TArray<AActor> 仇恨外感知删除
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._仇恨外感知删除) == null)
				{
					result = (this._仇恨外感知删除 = new TArray<AActor>(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.仇恨外感知删除.CopyAssign(value);
			}
		}

		// Token: 0x17007DAA RID: 32170
		// (get) Token: 0x0602DD58 RID: 187736 RVA: 0x00ACD70F File Offset: 0x00ACB90F
		// (set) Token: 0x0602DD59 RID: 187737 RVA: 0x00ACD71F File Offset: 0x00ACB91F
		public unsafe int 仇恨外对象数组
		{
			get
			{
				return *(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007DAB RID: 32171
		// (get) Token: 0x0602DD5A RID: 187738 RVA: 0x00ACD730 File Offset: 0x00ACB930
		// (set) Token: 0x0602DD5B RID: 187739 RVA: 0x00ACD740 File Offset: 0x00ACB940
		public unsafe int 怪物类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007DAC RID: 32172
		// (get) Token: 0x0602DD5C RID: 187740 RVA: 0x00ACD754 File Offset: 0x00ACB954
		// (set) Token: 0x0602DD5D RID: 187741 RVA: 0x00ACD78D File Offset: 0x00ACB98D
		public SAiConditions 入战监听1
		{
			get
			{
				base.FastCheckIsValid();
				SAiConditions result;
				if ((result = this._入战监听1) == null)
				{
					result = (this._入战监听1 = new SAiConditions(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SAiConditions.StaticStruct(), base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007DAD RID: 32173
		// (get) Token: 0x0602DD5E RID: 187742 RVA: 0x00ACD7B0 File Offset: 0x00ACB9B0
		// (set) Token: 0x0602DD5F RID: 187743 RVA: 0x00ACD7E9 File Offset: 0x00ACB9E9
		public TArray<AActor> 区域监听对象数组
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._区域监听对象数组) == null)
				{
					result = (this._区域监听对象数组 = new TArray<AActor>(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				this.区域监听对象数组.CopyAssign(value);
			}
		}

		// Token: 0x17007DAE RID: 32174
		// (get) Token: 0x0602DD60 RID: 187744 RVA: 0x00ACD7F7 File Offset: 0x00ACB9F7
		// (set) Token: 0x0602DD61 RID: 187745 RVA: 0x00ACD80B File Offset: 0x00ACBA0B
		[Nullable(2)]
		public unsafe AActor 当前仇恨对象
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + AIC_AICommon_C.__PropertyOffset_18);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + AIC_AICommon_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17007DAF RID: 32175
		// (get) Token: 0x0602DD62 RID: 187746 RVA: 0x00ACD820 File Offset: 0x00ACBA20
		// (set) Token: 0x0602DD63 RID: 187747 RVA: 0x00ACD834 File Offset: 0x00ACBA34
		[Nullable(2)]
		public unsafe UKuroRegionDetectComponent 区域监听
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroRegionDetectComponent>(base.NativePtr / (IntPtr)sizeof(void*) + AIC_AICommon_C.__PropertyOffset_19);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + AIC_AICommon_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17007DB0 RID: 32176
		// (get) Token: 0x0602DD64 RID: 187748 RVA: 0x00ACD849 File Offset: 0x00ACBA49
		// (set) Token: 0x0602DD65 RID: 187749 RVA: 0x00ACD85D File Offset: 0x00ACBA5D
		public unsafe FName 碰撞通道名
		{
			get
			{
				return *(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)AIC_AICommon_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x0602DD66 RID: 187750 RVA: 0x00ACD872 File Offset: 0x00ACBA72
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 避开卡死的可集成函数()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__避开卡死的可集成函数_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD67 RID: 187751 RVA: 0x00ACD888 File Offset: 0x00ACBA88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 通用关卡变量切换监听(EAiLevelVarSource 关卡变量监听类型, string 关卡变量名称, int 关卡副本行为树id, [Nullable(2)] in FOnBooleanEventTrigger 事件)
		{
			AIC_AICommon_C.__通用关卡变量切换监听_FunctionParams* ptr = stackalloc AIC_AICommon_C.__通用关卡变量切换监听_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(AIC_AICommon_C.__通用关卡变量切换监听_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__通用关卡变量切换监听_NativeFunctionPtr, (void*)ptr, 1);
			ptr->关卡变量监听类型 = 关卡变量监听类型;
			FString.CopyFrom((void*)(&ptr->关卡变量名称), 关卡变量名称);
			ptr->关卡副本行为树id = 关卡副本行为树id;
			IntPtr dest = &ptr->事件;
			object obj = 事件;
			FScriptDelegate.NativeCopy(dest, (obj != null) ? obj.NativePtr : ((IntPtr)0));
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__通用关卡变量切换监听_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(AIC_AICommon_C.__通用关卡变量切换监听_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DD68 RID: 187752 RVA: 0x00ACD914 File Offset: 0x00ACBB14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 角色怪射线检测(ref bool 可以钩锁)
		{
			AIC_AICommon_C.__角色怪射线检测_FunctionParams* ptr = stackalloc AIC_AICommon_C.__角色怪射线检测_FunctionParams[(UIntPtr)439] + 15L / (long)sizeof(AIC_AICommon_C.__角色怪射线检测_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__角色怪射线检测_NativeFunctionPtr, (void*)ptr, 1);
			ptr->可以钩锁 = 可以钩锁;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__角色怪射线检测_NativeFunctionPtr, (void*)ptr);
			可以钩锁 = ptr->可以钩锁;
		}

		// Token: 0x0602DD69 RID: 187753 RVA: 0x00ACD968 File Offset: 0x00ACBB68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 区域监听事件函数(string 区域名称, [Nullable(2)] in FRegionEventTrigger 事件)
		{
			AIC_AICommon_C.__区域监听事件函数_FunctionParams* ptr = stackalloc AIC_AICommon_C.__区域监听事件函数_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(AIC_AICommon_C.__区域监听事件函数_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__区域监听事件函数_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->区域名称), 区域名称);
			IntPtr dest = &ptr->事件;
			object obj = 事件;
			FScriptDelegate.NativeCopy(dest, (obj != null) ? obj.NativePtr : ((IntPtr)0));
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__区域监听事件函数_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(AIC_AICommon_C.__区域监听事件函数_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DD6A RID: 187754 RVA: 0x00ACD9E0 File Offset: 0x00ACBBE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 设置区域监听对象()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__设置区域监听对象_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD6B RID: 187755 RVA: 0x00ACD9F4 File Offset: 0x00ACBBF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void 获取控制权时()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__获取控制权时_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD6C RID: 187756 RVA: 0x00ACDA08 File Offset: 0x00ACBC08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void 状态切换时(ECharacterState oldState, ECharacterState newState, bool isAutonomousProxy)
		{
			AIC_AICommon_C.__状态切换时_FunctionParams* ptr = stackalloc AIC_AICommon_C.__状态切换时_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(AIC_AICommon_C.__状态切换时_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__状态切换时_NativeFunctionPtr, (void*)ptr, 1);
			ptr->oldState = oldState;
			ptr->newState = newState;
			ptr->isAutonomousProxy = isAutonomousProxy;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__状态切换时_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DD6D RID: 187757 RVA: 0x00ACDA66 File Offset: 0x00ACBC66
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 感知到仇恨目标()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__感知到仇恨目标_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD6E RID: 187758 RVA: 0x00ACDA7C File Offset: 0x00ACBC7C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 状态切换函数(UObject 角色, ECharacterState 老状态, ECharacterState 新状态, bool 主控, ref UObject 角色返回, ref ECharacterState 老状态返回, ref ECharacterState 新状态返回, ref bool 主控返回)
		{
			AIC_AICommon_C.__状态切换函数_FunctionParams* ptr = stackalloc AIC_AICommon_C.__状态切换函数_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(AIC_AICommon_C.__状态切换函数_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__状态切换函数_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->老状态 = 老状态;
			ptr->新状态 = 新状态;
			ptr->主控 = 主控;
			ref AIC_AICommon_C.__状态切换函数_FunctionParams ptr2 = ref *ptr;
			UObject uobject = 角色返回;
			ptr2.角色返回 = ((uobject != null) ? uobject.NativePtr : IntPtr.Zero);
			ptr->老状态返回 = 老状态返回;
			ptr->新状态返回 = 新状态返回;
			ptr->主控返回 = 主控返回;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__状态切换函数_NativeFunctionPtr, (void*)ptr);
			角色返回 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(ptr->角色返回);
			老状态返回 = ptr->老状态返回;
			新状态返回 = ptr->新状态返回;
			主控返回 = ptr->主控返回;
		}

		// Token: 0x0602DD6F RID: 187759 RVA: 0x00ACDB64 File Offset: 0x00ACBD64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 通用战斗AI(bool bContent)
		{
			AIC_AICommon_C.__通用战斗AI_FunctionParams* ptr = stackalloc AIC_AICommon_C.__通用战斗AI_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(AIC_AICommon_C.__通用战斗AI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__通用战斗AI_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bContent = bContent;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__通用战斗AI_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DD70 RID: 187760 RVA: 0x00ACDBAC File Offset: 0x00ACBDAC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 仇恨监听([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<AActor> AddActor, [Nullable(new byte[]
		{
			2,
			1
		})] in TArray<AActor> RemoveActor, in TArray<int> RemoveActorIds, int Num)
		{
			AIC_AICommon_C.__仇恨监听_FunctionParams* ptr = stackalloc AIC_AICommon_C.__仇恨监听_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(AIC_AICommon_C.__仇恨监听_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__仇恨监听_NativeFunctionPtr, (void*)ptr, 1);
			object obj = AddActor;
			if (obj != null)
			{
				obj.MoveTo(&ptr->AddActor);
			}
			object obj2 = RemoveActor;
			if (obj2 != null)
			{
				obj2.MoveTo(&ptr->RemoveActor);
			}
			object obj3 = RemoveActorIds;
			if (obj3 != null)
			{
				obj3.MoveTo(&ptr->RemoveActorIds);
			}
			ptr->Num = Num;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__仇恨监听_NativeFunctionPtr, (void*)ptr);
			object obj4 = AddActor;
			if (obj4 != null)
			{
				obj4.MoveAssign(&ptr->AddActor);
			}
			object obj5 = RemoveActor;
			if (obj5 != null)
			{
				obj5.MoveAssign(&ptr->RemoveActor);
			}
			object obj6 = RemoveActorIds;
			if (obj6 != null)
			{
				obj6.MoveAssign(&ptr->RemoveActorIds);
			}
			UnrealReflectionUtils.DestroyStruct(AIC_AICommon_C.__仇恨监听_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DD71 RID: 187761 RVA: 0x00ACDC7C File Offset: 0x00ACBE7C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 感知监听([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<AActor> AddActor, [Nullable(new byte[]
		{
			2,
			1
		})] in TArray<AActor> RemoveActor, in TArray<int> RemoveActorIds, int Num)
		{
			AIC_AICommon_C.__感知监听_FunctionParams* ptr = stackalloc AIC_AICommon_C.__感知监听_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(AIC_AICommon_C.__感知监听_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__感知监听_NativeFunctionPtr, (void*)ptr, 1);
			object obj = AddActor;
			if (obj != null)
			{
				obj.MoveTo(&ptr->AddActor);
			}
			object obj2 = RemoveActor;
			if (obj2 != null)
			{
				obj2.MoveTo(&ptr->RemoveActor);
			}
			object obj3 = RemoveActorIds;
			if (obj3 != null)
			{
				obj3.MoveTo(&ptr->RemoveActorIds);
			}
			ptr->Num = Num;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__感知监听_NativeFunctionPtr, (void*)ptr);
			object obj4 = AddActor;
			if (obj4 != null)
			{
				obj4.MoveAssign(&ptr->AddActor);
			}
			object obj5 = RemoveActor;
			if (obj5 != null)
			{
				obj5.MoveAssign(&ptr->RemoveActor);
			}
			object obj6 = RemoveActorIds;
			if (obj6 != null)
			{
				obj6.MoveAssign(&ptr->RemoveActorIds);
			}
			UnrealReflectionUtils.DestroyStruct(AIC_AICommon_C.__感知监听_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DD72 RID: 187762 RVA: 0x00ACDD4C File Offset: 0x00ACBF4C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 仇恨外受击([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<AActor> AddActor, [Nullable(new byte[]
		{
			2,
			1
		})] in TArray<AActor> RemoveActor, in TArray<int> RemoveActorIds, int Num)
		{
			AIC_AICommon_C.__仇恨外受击_FunctionParams* ptr = stackalloc AIC_AICommon_C.__仇恨外受击_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(AIC_AICommon_C.__仇恨外受击_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__仇恨外受击_NativeFunctionPtr, (void*)ptr, 1);
			object obj = AddActor;
			if (obj != null)
			{
				obj.MoveTo(&ptr->AddActor);
			}
			object obj2 = RemoveActor;
			if (obj2 != null)
			{
				obj2.MoveTo(&ptr->RemoveActor);
			}
			object obj3 = RemoveActorIds;
			if (obj3 != null)
			{
				obj3.MoveTo(&ptr->RemoveActorIds);
			}
			ptr->Num = Num;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__仇恨外受击_NativeFunctionPtr, (void*)ptr);
			object obj4 = AddActor;
			if (obj4 != null)
			{
				obj4.MoveAssign(&ptr->AddActor);
			}
			object obj5 = RemoveActor;
			if (obj5 != null)
			{
				obj5.MoveAssign(&ptr->RemoveActor);
			}
			object obj6 = RemoveActorIds;
			if (obj6 != null)
			{
				obj6.MoveAssign(&ptr->RemoveActorIds);
			}
			UnrealReflectionUtils.DestroyStruct(AIC_AICommon_C.__仇恨外受击_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DD73 RID: 187763 RVA: 0x00ACDE1C File Offset: 0x00ACC01C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AicTriggerEvent(FName Name)
		{
			AIC_AICommon_C.__AicTriggerEvent_FunctionParams* ptr = stackalloc AIC_AICommon_C.__AicTriggerEvent_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(AIC_AICommon_C.__AicTriggerEvent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__AicTriggerEvent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Name = Name;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__AicTriggerEvent_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DD74 RID: 187764 RVA: 0x00ACDE64 File Offset: 0x00ACC064
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 默认感知保底事件(bool bContent)
		{
			AIC_AICommon_C.__默认感知保底事件_FunctionParams* ptr = stackalloc AIC_AICommon_C.__默认感知保底事件_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(AIC_AICommon_C.__默认感知保底事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__默认感知保底事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bContent = bContent;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__默认感知保底事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DD75 RID: 187765 RVA: 0x00ACDEAC File Offset: 0x00ACC0AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 入战监听(bool bContent)
		{
			AIC_AICommon_C.__入战监听_FunctionParams* ptr = stackalloc AIC_AICommon_C.__入战监听_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(AIC_AICommon_C.__入战监听_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__入战监听_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bContent = bContent;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__入战监听_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DD76 RID: 187766 RVA: 0x00ACDEF2 File Offset: 0x00ACC0F2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 区域监听事件()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__区域监听事件_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD77 RID: 187767 RVA: 0x00ACDF08 File Offset: 0x00ACC108
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 保底传送回调(bool bContent)
		{
			AIC_AICommon_C.__保底传送回调_FunctionParams* ptr = stackalloc AIC_AICommon_C.__保底传送回调_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(AIC_AICommon_C.__保底传送回调_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__保底传送回调_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bContent = bContent;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__保底传送回调_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DD78 RID: 187768 RVA: 0x00ACDF50 File Offset: 0x00ACC150
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 通用行为树条件(bool bContent)
		{
			AIC_AICommon_C.__通用行为树条件_FunctionParams* ptr = stackalloc AIC_AICommon_C.__通用行为树条件_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(AIC_AICommon_C.__通用行为树条件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__通用行为树条件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bContent = bContent;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__通用行为树条件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DD79 RID: 187769 RVA: 0x00ACDF96 File Offset: 0x00ACC196
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__OnStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD7A RID: 187770 RVA: 0x00ACDFAC File Offset: 0x00ACC1AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			AIC_AICommon_C.__ReceiveTick_FunctionParams* ptr = stackalloc AIC_AICommon_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(AIC_AICommon_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, AIC_AICommon_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DD7B RID: 187771 RVA: 0x00ACDFF4 File Offset: 0x00ACC1F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			AIC_AICommon_C.__ReceiveTick_FunctionParams* ptr = stackalloc AIC_AICommon_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(AIC_AICommon_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, AIC_AICommon_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DD7C RID: 187772 RVA: 0x00ACE03C File Offset: 0x00ACC23C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_AIC_AICommon(int EntryPoint)
		{
			AIC_AICommon_C.__ExecuteUbergraph_AIC_AICommon_FunctionParams* ptr = stackalloc AIC_AICommon_C.__ExecuteUbergraph_AIC_AICommon_FunctionParams[(UIntPtr)743] + 15L / (long)sizeof(AIC_AICommon_C.__ExecuteUbergraph_AIC_AICommon_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(AIC_AICommon_C.__ExecuteUbergraph_AIC_AICommon_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, AIC_AICommon_C.__ExecuteUbergraph_AIC_AICommon_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DD7D RID: 187773 RVA: 0x00ACE086 File Offset: 0x00ACC286
		protected AIC_AICommon_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019E02 RID: 105986
		public new const string __ObjectPath = "/Game/Aki/AI/AIFunctionCommon/AIC_AICommon.AIC_AICommon_C";

		// Token: 0x04019E03 RID: 105987
		private static IntPtr _ClassPtr;

		// Token: 0x04019E04 RID: 105988
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019E05 RID: 105989
		internal static int __PropertyOffset_0;

		// Token: 0x04019E06 RID: 105990
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019E07 RID: 105991
		internal static int __PropertyOffset_1;

		// Token: 0x04019E08 RID: 105992
		internal static int __PropertyOffset_2;

		// Token: 0x04019E09 RID: 105993
		internal static int __PropertyOffset_3;

		// Token: 0x04019E0A RID: 105994
		[Nullable(2)]
		private SAiConditions _行为树运行前置条件;

		// Token: 0x04019E0B RID: 105995
		internal static int __PropertyOffset_4;

		// Token: 0x04019E0C RID: 105996
		[Nullable(2)]
		private SAiConditions _默认感知保底;

		// Token: 0x04019E0D RID: 105997
		internal static int __PropertyOffset_5;

		// Token: 0x04019E0E RID: 105998
		[Nullable(2)]
		private SAiConditions _战斗行为树前置;

		// Token: 0x04019E0F RID: 105999
		internal static int __PropertyOffset_6;

		// Token: 0x04019E10 RID: 106000
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _仇恨添加对象数组;

		// Token: 0x04019E11 RID: 106001
		internal static int __PropertyOffset_7;

		// Token: 0x04019E12 RID: 106002
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _仇恨删除对象数组;

		// Token: 0x04019E13 RID: 106003
		internal static int __PropertyOffset_8;

		// Token: 0x04019E14 RID: 106004
		internal static int __PropertyOffset_9;

		// Token: 0x04019E15 RID: 106005
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _感知添加对象数组;

		// Token: 0x04019E16 RID: 106006
		internal static int __PropertyOffset_10;

		// Token: 0x04019E17 RID: 106007
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _感知删除对象数组;

		// Token: 0x04019E18 RID: 106008
		internal static int __PropertyOffset_11;

		// Token: 0x04019E19 RID: 106009
		internal static int __PropertyOffset_12;

		// Token: 0x04019E1A RID: 106010
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _仇恨外感知添加;

		// Token: 0x04019E1B RID: 106011
		internal static int __PropertyOffset_13;

		// Token: 0x04019E1C RID: 106012
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _仇恨外感知删除;

		// Token: 0x04019E1D RID: 106013
		internal static int __PropertyOffset_14;

		// Token: 0x04019E1E RID: 106014
		internal static int __PropertyOffset_15;

		// Token: 0x04019E1F RID: 106015
		internal static int __PropertyOffset_16;

		// Token: 0x04019E20 RID: 106016
		[Nullable(2)]
		private SAiConditions _入战监听1;

		// Token: 0x04019E21 RID: 106017
		internal static int __PropertyOffset_17;

		// Token: 0x04019E22 RID: 106018
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _区域监听对象数组;

		// Token: 0x04019E23 RID: 106019
		internal static int __PropertyOffset_18;

		// Token: 0x04019E24 RID: 106020
		internal static int __PropertyOffset_19;

		// Token: 0x04019E25 RID: 106021
		internal static int __PropertyOffset_20;

		// Token: 0x04019E26 RID: 106022
		private static IntPtr __避开卡死的可集成函数_NativeFunctionPtr;

		// Token: 0x04019E27 RID: 106023
		private static IntPtr __通用关卡变量切换监听_NativeFunctionPtr;

		// Token: 0x04019E28 RID: 106024
		private static IntPtr __角色怪射线检测_NativeFunctionPtr;

		// Token: 0x04019E29 RID: 106025
		private static IntPtr __区域监听事件函数_NativeFunctionPtr;

		// Token: 0x04019E2A RID: 106026
		private static IntPtr __设置区域监听对象_NativeFunctionPtr;

		// Token: 0x04019E2B RID: 106027
		private static IntPtr __获取控制权时_NativeFunctionPtr;

		// Token: 0x04019E2C RID: 106028
		private static IntPtr __状态切换时_NativeFunctionPtr;

		// Token: 0x04019E2D RID: 106029
		private static IntPtr __感知到仇恨目标_NativeFunctionPtr;

		// Token: 0x04019E2E RID: 106030
		private static IntPtr __状态切换函数_NativeFunctionPtr;

		// Token: 0x04019E2F RID: 106031
		private static IntPtr __通用战斗AI_NativeFunctionPtr;

		// Token: 0x04019E30 RID: 106032
		private static IntPtr __仇恨监听_NativeFunctionPtr;

		// Token: 0x04019E31 RID: 106033
		private static IntPtr __感知监听_NativeFunctionPtr;

		// Token: 0x04019E32 RID: 106034
		private static IntPtr __仇恨外受击_NativeFunctionPtr;

		// Token: 0x04019E33 RID: 106035
		private static IntPtr __AicTriggerEvent_NativeFunctionPtr;

		// Token: 0x04019E34 RID: 106036
		private static IntPtr __默认感知保底事件_NativeFunctionPtr;

		// Token: 0x04019E35 RID: 106037
		private static IntPtr __入战监听_NativeFunctionPtr;

		// Token: 0x04019E36 RID: 106038
		private static IntPtr __区域监听事件_NativeFunctionPtr;

		// Token: 0x04019E37 RID: 106039
		private static IntPtr __保底传送回调_NativeFunctionPtr;

		// Token: 0x04019E38 RID: 106040
		private static IntPtr __通用行为树条件_NativeFunctionPtr;

		// Token: 0x04019E39 RID: 106041
		private static IntPtr __OnStart_NativeFunctionPtr;

		// Token: 0x04019E3A RID: 106042
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04019E3B RID: 106043
		private static IntPtr __ExecuteUbergraph_AIC_AICommon_NativeFunctionPtr;

		// Token: 0x0200A5B1 RID: 42417
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __通用关卡变量切换监听_FunctionParams
		{
			// Token: 0x04033529 RID: 210217
			[FieldOffset(0)]
			public TEnumAsByte<EAiLevelVarSource> 关卡变量监听类型;

			// Token: 0x0403352A RID: 210218
			[FieldOffset(8)]
			public FString 关卡变量名称;

			// Token: 0x0403352B RID: 210219
			[FieldOffset(24)]
			public int 关卡副本行为树id;

			// Token: 0x0403352C RID: 210220
			[FieldOffset(32)]
			public byte 事件;
		}

		// Token: 0x0200A5B2 RID: 42418
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 424)]
		protected ref struct __角色怪射线检测_FunctionParams
		{
			// Token: 0x0403352D RID: 210221
			[FieldOffset(0)]
			public bool 可以钩锁;
		}

		// Token: 0x0200A5B3 RID: 42419
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __区域监听事件函数_FunctionParams
		{
			// Token: 0x0403352E RID: 210222
			[FieldOffset(0)]
			public FString 区域名称;

			// Token: 0x0403352F RID: 210223
			[FieldOffset(16)]
			public byte 事件;
		}

		// Token: 0x0200A5B4 RID: 42420
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected new ref struct __状态切换时_FunctionParams
		{
			// Token: 0x04033530 RID: 210224
			[FieldOffset(0)]
			public TEnumAsByte<ECharacterState> oldState;

			// Token: 0x04033531 RID: 210225
			[FieldOffset(1)]
			public TEnumAsByte<ECharacterState> newState;

			// Token: 0x04033532 RID: 210226
			[FieldOffset(2)]
			public bool isAutonomousProxy;
		}

		// Token: 0x0200A5B5 RID: 42421
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __状态切换函数_FunctionParams
		{
			// Token: 0x04033533 RID: 210227
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04033534 RID: 210228
			[FieldOffset(8)]
			public TEnumAsByte<ECharacterState> 老状态;

			// Token: 0x04033535 RID: 210229
			[FieldOffset(9)]
			public TEnumAsByte<ECharacterState> 新状态;

			// Token: 0x04033536 RID: 210230
			[FieldOffset(10)]
			public bool 主控;

			// Token: 0x04033537 RID: 210231
			[FieldOffset(16)]
			public IntPtr 角色返回;

			// Token: 0x04033538 RID: 210232
			[FieldOffset(24)]
			public TEnumAsByte<ECharacterState> 老状态返回;

			// Token: 0x04033539 RID: 210233
			[FieldOffset(25)]
			public TEnumAsByte<ECharacterState> 新状态返回;

			// Token: 0x0403353A RID: 210234
			[FieldOffset(26)]
			public bool 主控返回;
		}

		// Token: 0x0200A5B6 RID: 42422
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __通用战斗AI_FunctionParams
		{
			// Token: 0x0403353B RID: 210235
			[FieldOffset(0)]
			public bool bContent;
		}

		// Token: 0x0200A5B7 RID: 42423
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __仇恨监听_FunctionParams
		{
			// Token: 0x0403353C RID: 210236
			[FieldOffset(0)]
			public byte AddActor;

			// Token: 0x0403353D RID: 210237
			[FieldOffset(16)]
			public byte RemoveActor;

			// Token: 0x0403353E RID: 210238
			[FieldOffset(32)]
			public byte RemoveActorIds;

			// Token: 0x0403353F RID: 210239
			[FieldOffset(48)]
			public int Num;
		}

		// Token: 0x0200A5B8 RID: 42424
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __感知监听_FunctionParams
		{
			// Token: 0x04033540 RID: 210240
			[FieldOffset(0)]
			public byte AddActor;

			// Token: 0x04033541 RID: 210241
			[FieldOffset(16)]
			public byte RemoveActor;

			// Token: 0x04033542 RID: 210242
			[FieldOffset(32)]
			public byte RemoveActorIds;

			// Token: 0x04033543 RID: 210243
			[FieldOffset(48)]
			public int Num;
		}

		// Token: 0x0200A5B9 RID: 42425
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __仇恨外受击_FunctionParams
		{
			// Token: 0x04033544 RID: 210244
			[FieldOffset(0)]
			public byte AddActor;

			// Token: 0x04033545 RID: 210245
			[FieldOffset(16)]
			public byte RemoveActor;

			// Token: 0x04033546 RID: 210246
			[FieldOffset(32)]
			public byte RemoveActorIds;

			// Token: 0x04033547 RID: 210247
			[FieldOffset(48)]
			public int Num;
		}

		// Token: 0x0200A5BA RID: 42426
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __AicTriggerEvent_FunctionParams
		{
			// Token: 0x04033548 RID: 210248
			[FieldOffset(0)]
			public FName Name;
		}

		// Token: 0x0200A5BB RID: 42427
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __默认感知保底事件_FunctionParams
		{
			// Token: 0x04033549 RID: 210249
			[FieldOffset(0)]
			public bool bContent;
		}

		// Token: 0x0200A5BC RID: 42428
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __入战监听_FunctionParams
		{
			// Token: 0x0403354A RID: 210250
			[FieldOffset(0)]
			public bool bContent;
		}

		// Token: 0x0200A5BD RID: 42429
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __保底传送回调_FunctionParams
		{
			// Token: 0x0403354B RID: 210251
			[FieldOffset(0)]
			public bool bContent;
		}

		// Token: 0x0200A5BE RID: 42430
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __通用行为树条件_FunctionParams
		{
			// Token: 0x0403354C RID: 210252
			[FieldOffset(0)]
			public bool bContent;
		}

		// Token: 0x0200A5BF RID: 42431
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403354D RID: 210253
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A5C0 RID: 42432
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 728)]
		protected ref struct __ExecuteUbergraph_AIC_AICommon_FunctionParams
		{
			// Token: 0x0403354E RID: 210254
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
