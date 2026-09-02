using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F4B RID: 16203
	[UnrealObjectPath("/Game/Aki/Core/Fight/BPL_Fight.BPL_Fight_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BPL_Fight_C : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060287CA RID: 165834 RVA: 0x00A0C94B File Offset: 0x00A0AB4B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BPL_Fight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/Fight/BPL_Fight.BPL_Fight_C");
			}
			return BPL_Fight_C._ClassPtr;
		}

		// Token: 0x060287CB RID: 165835 RVA: 0x00A0C970 File Offset: 0x00A0AB70
		public BPL_Fight_C() : this(BuiltinUtils.AllocNativeUObject(BPL_Fight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060287CC RID: 165836 RVA: 0x00A0C998 File Offset: 0x00A0AB98
		[NullableContext(1)]
		public BPL_Fight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BPL_Fight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060287CD RID: 165837 RVA: 0x00A0C9CC File Offset: 0x00A0ABCC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void 反应伤害倍率计算(float 角色1反应精通, float 角色2反应精通, UObject __WorldContext, ref float Result)
		{
			BPL_Fight_C.StaticClass();
			BPL_Fight_C.__反应伤害倍率计算_FunctionParams* ptr = stackalloc BPL_Fight_C.__反应伤害倍率计算_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BPL_Fight_C.__反应伤害倍率计算_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__反应伤害倍率计算_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色1反应精通 = 角色1反应精通;
			ptr->角色2反应精通 = 角色2反应精通;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Fight_C._ClassDefaultObjectPtr, BPL_Fight_C.__反应伤害倍率计算_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x060287CE RID: 165838 RVA: 0x00A0CA44 File Offset: 0x00A0AC44
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void 删除材质效果(TsBaseCharacter 设置对象_, int Handle_, bool PlayWithEnd, UObject __WorldContext)
		{
			BPL_Fight_C.StaticClass();
			BPL_Fight_C.__删除材质效果_FunctionParams* ptr = stackalloc BPL_Fight_C.__删除材质效果_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BPL_Fight_C.__删除材质效果_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__删除材质效果_NativeFunctionPtr, (void*)ptr, 1);
			ptr->设置对象_ = ((设置对象_ != null) ? 设置对象_.NativePtr : IntPtr.Zero);
			ptr->Handle_ = Handle_;
			ptr->PlayWithEnd = PlayWithEnd;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Fight_C._ClassDefaultObjectPtr, BPL_Fight_C.__删除材质效果_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060287CF RID: 165839 RVA: 0x00A0CAC4 File Offset: 0x00A0ACC4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void 设置材质效果(TsBaseCharacter 设置对象, PD_CharacterControllerData_C 材质配置, UObject __WorldContext, ref int Handle)
		{
			BPL_Fight_C.StaticClass();
			BPL_Fight_C.__设置材质效果_FunctionParams* ptr = stackalloc BPL_Fight_C.__设置材质效果_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BPL_Fight_C.__设置材质效果_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__设置材质效果_NativeFunctionPtr, (void*)ptr, 1);
			ptr->设置对象 = ((设置对象 != null) ? 设置对象.NativePtr : IntPtr.Zero);
			ptr->材质配置 = ((材质配置 != null) ? 材质配置.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Handle = Handle;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Fight_C._ClassDefaultObjectPtr, BPL_Fight_C.__设置材质效果_NativeFunctionPtr, (void*)ptr);
			Handle = ptr->Handle;
		}

		// Token: 0x060287D0 RID: 165840 RVA: 0x00A0CB5C File Offset: 0x00A0AD5C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 使用GE(TsBaseCharacter 使用者, TsBaseCharacter 目标, int GE的等级, FGameplayTagContainer 添加AssetTags, FGameplayTagContainer 添加GrantedTags, int 层数, float Duration, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UGameplayEffect> GE的类型, FKuroGameplayParameterContainer GE的参数, UObject __WorldContext, ref FActiveGameplayEffectHandle ActiveHandle)
		{
			BPL_Fight_C.__使用GE_FunctionParams* ptr = stackalloc BPL_Fight_C.__使用GE_FunctionParams[(UIntPtr)479] + 15L / (long)sizeof(BPL_Fight_C.__使用GE_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__使用GE_NativeFunctionPtr, (void*)ptr, 1);
			ptr->使用者 = ((使用者 != null) ? 使用者.NativePtr : IntPtr.Zero);
			ptr->目标 = ((目标 != null) ? 目标.NativePtr : IntPtr.Zero);
			ptr->GE的等级 = GE的等级;
			if (添加AssetTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->添加AssetTags, 添加AssetTags.NativePtr, 1, false);
			}
			if (添加GrantedTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->添加GrantedTags, 添加GrantedTags.NativePtr, 1, false);
			}
			ptr->层数 = 层数;
			ptr->Duration = Duration;
			ptr->GE的类型 = GE的类型;
			if (GE的参数 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroGameplayParameterContainer.StaticStruct(), &ptr->GE的参数, GE的参数.NativePtr, 1, false);
			}
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (ActiveHandle != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FActiveGameplayEffectHandle.StaticStruct(), &ptr->ActiveHandle, ActiveHandle.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BPL_Fight_C.__使用GE_NativeFunctionPtr, (void*)ptr);
			if (ActiveHandle != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FActiveGameplayEffectHandle.StaticStruct(), ActiveHandle.NativePtr, &ptr->ActiveHandle, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_Fight_C.__使用GE_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060287D1 RID: 165841 RVA: 0x00A0CCCC File Offset: 0x00A0AECC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void 获取目标周围坐标点(FRotator 目标旋转, FVectorDouble 目标坐标, float 旋转, float 仰角, float 长度, UObject __WorldContext, ref FVectorDouble 坐标点)
		{
			BPL_Fight_C.StaticClass();
			BPL_Fight_C.__获取目标周围坐标点_FunctionParams* ptr = stackalloc BPL_Fight_C.__获取目标周围坐标点_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(BPL_Fight_C.__获取目标周围坐标点_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__获取目标周围坐标点_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标旋转 = 目标旋转;
			ptr->目标坐标 = 目标坐标;
			ptr->旋转 = 旋转;
			ptr->仰角 = 仰角;
			ptr->长度 = 长度;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->坐标点 = 坐标点;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Fight_C._ClassDefaultObjectPtr, BPL_Fight_C.__获取目标周围坐标点_NativeFunctionPtr, (void*)ptr);
			坐标点 = ptr->坐标点;
		}

		// Token: 0x060287D2 RID: 165842 RVA: 0x00A0CD6C File Offset: 0x00A0AF6C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void 计算向量曲线值(float 已经经过时间, float 总时间, UCurveVector 向量曲线, UObject __WorldContext, ref FVector 向量值)
		{
			BPL_Fight_C.StaticClass();
			BPL_Fight_C.__计算向量曲线值_FunctionParams* ptr = stackalloc BPL_Fight_C.__计算向量曲线值_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BPL_Fight_C.__计算向量曲线值_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__计算向量曲线值_NativeFunctionPtr, (void*)ptr, 1);
			ptr->已经经过时间 = 已经经过时间;
			ptr->总时间 = 总时间;
			ptr->向量曲线 = ((向量曲线 != null) ? 向量曲线.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->向量值 = 向量值;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Fight_C._ClassDefaultObjectPtr, BPL_Fight_C.__计算向量曲线值_NativeFunctionPtr, (void*)ptr);
			向量值 = ptr->向量值;
		}

		// Token: 0x060287D3 RID: 165843 RVA: 0x00A0CE04 File Offset: 0x00A0B004
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void 计算曲线值(float 已经过时间, float 总时间, UCurveFloat 曲线, UObject __WorldContext, ref float 百分比)
		{
			BPL_Fight_C.StaticClass();
			BPL_Fight_C.__计算曲线值_FunctionParams* ptr = stackalloc BPL_Fight_C.__计算曲线值_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BPL_Fight_C.__计算曲线值_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__计算曲线值_NativeFunctionPtr, (void*)ptr, 1);
			ptr->已经过时间 = 已经过时间;
			ptr->总时间 = 总时间;
			ptr->曲线 = ((曲线 != null) ? 曲线.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->百分比 = 百分比;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Fight_C._ClassDefaultObjectPtr, BPL_Fight_C.__计算曲线值_NativeFunctionPtr, (void*)ptr);
			百分比 = ptr->百分比;
		}

		// Token: 0x060287D4 RID: 165844 RVA: 0x00A0CE94 File Offset: 0x00A0B094
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void 角度转化(float Input, UObject __WorldContext, ref float Output)
		{
			BPL_Fight_C.StaticClass();
			BPL_Fight_C.__角度转化_FunctionParams* ptr = stackalloc BPL_Fight_C.__角度转化_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BPL_Fight_C.__角度转化_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__角度转化_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Input = Input;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Output = Output;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Fight_C._ClassDefaultObjectPtr, BPL_Fight_C.__角度转化_NativeFunctionPtr, (void*)ptr);
			Output = ptr->Output;
		}

		// Token: 0x060287D5 RID: 165845 RVA: 0x00A0CF08 File Offset: 0x00A0B108
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool 射线检测(UObject Context, FVectorDouble Start, FVectorDouble End, ETraceTypeQuery TraceChannel, bool bTraceComplex, EDrawDebugTrace DrawDebugType, bool bIgnoreSelf, FLinearColor TraceColor, FLinearColor TraceHitColor, float DrawTime, UObject __WorldContext, ref FHitResult OutHit)
		{
			BPL_Fight_C.StaticClass();
			BPL_Fight_C.__射线检测_FunctionParams* ptr = stackalloc BPL_Fight_C.__射线检测_FunctionParams[(UIntPtr)439] + 15L / (long)sizeof(BPL_Fight_C.__射线检测_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__射线检测_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Context = ((Context != null) ? Context.NativePtr : IntPtr.Zero);
			ptr->Start = Start;
			ptr->End = End;
			ptr->TraceChannel = TraceChannel;
			ptr->bTraceComplex = bTraceComplex;
			ptr->DrawDebugType = DrawDebugType;
			ptr->bIgnoreSelf = bIgnoreSelf;
			ptr->TraceColor = TraceColor;
			ptr->TraceHitColor = TraceHitColor;
			ptr->DrawTime = DrawTime;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (OutHit != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->OutHit, OutHit.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Fight_C._ClassDefaultObjectPtr, BPL_Fight_C.__射线检测_NativeFunctionPtr, (void*)ptr);
			if (OutHit != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), OutHit.NativePtr, &ptr->OutHit, 1, false);
			}
			return ptr->__Result;
		}

		// Token: 0x060287D6 RID: 165846 RVA: 0x00A0D020 File Offset: 0x00A0B220
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void 获取Actor周围坐标点(AActor Actor, float 旋转, float 仰角, float 长度, UObject __WorldContext, ref FVectorDouble 坐标点)
		{
			BPL_Fight_C.StaticClass();
			BPL_Fight_C.__获取Actor周围坐标点_FunctionParams* ptr = stackalloc BPL_Fight_C.__获取Actor周围坐标点_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(BPL_Fight_C.__获取Actor周围坐标点_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__获取Actor周围坐标点_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Actor = ((Actor != null) ? Actor.NativePtr : IntPtr.Zero);
			ptr->旋转 = 旋转;
			ptr->仰角 = 仰角;
			ptr->长度 = 长度;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->坐标点 = 坐标点;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Fight_C._ClassDefaultObjectPtr, BPL_Fight_C.__获取Actor周围坐标点_NativeFunctionPtr, (void*)ptr);
			坐标点 = ptr->坐标点;
		}

		// Token: 0x060287D7 RID: 165847 RVA: 0x00A0D0C4 File Offset: 0x00A0B2C4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void 获取游戏实例(UObject __WorldContext, ref BP_MainGameInstance_C AsBP_Main_Game_Instance)
		{
			BPL_Fight_C.StaticClass();
			BPL_Fight_C.__获取游戏实例_FunctionParams* ptr = stackalloc BPL_Fight_C.__获取游戏实例_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BPL_Fight_C.__获取游戏实例_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__获取游戏实例_NativeFunctionPtr, (void*)ptr, 1);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ref BPL_Fight_C.__获取游戏实例_FunctionParams ptr2 = ref *ptr;
			BP_MainGameInstance_C bp_MainGameInstance_C = AsBP_Main_Game_Instance;
			ptr2.AsBP_Main_Game_Instance = ((bp_MainGameInstance_C != null) ? bp_MainGameInstance_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Fight_C._ClassDefaultObjectPtr, BPL_Fight_C.__获取游戏实例_NativeFunctionPtr, (void*)ptr);
			AsBP_Main_Game_Instance = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_MainGameInstance_C>(ptr->AsBP_Main_Game_Instance);
		}

		// Token: 0x060287D8 RID: 165848 RVA: 0x00A0D144 File Offset: 0x00A0B344
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool 是否有标签(TsBaseCharacter 角色, FGameplayTag 标签, UObject __WorldContext)
		{
			BPL_Fight_C.StaticClass();
			BPL_Fight_C.__是否有标签_FunctionParams* ptr = stackalloc BPL_Fight_C.__是否有标签_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BPL_Fight_C.__是否有标签_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__是否有标签_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->标签 = 标签;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Fight_C._ClassDefaultObjectPtr, BPL_Fight_C.__是否有标签_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x060287D9 RID: 165849 RVA: 0x00A0D1C4 File Offset: 0x00A0B3C4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void 清除标签(TsBaseCharacter 角色, FGameplayTag 标签, UObject __WorldContext)
		{
			BPL_Fight_C.StaticClass();
			BPL_Fight_C.__清除标签_FunctionParams* ptr = stackalloc BPL_Fight_C.__清除标签_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BPL_Fight_C.__清除标签_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__清除标签_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->标签 = 标签;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Fight_C._ClassDefaultObjectPtr, BPL_Fight_C.__清除标签_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060287DA RID: 165850 RVA: 0x00A0D23C File Offset: 0x00A0B43C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void 添加标签(TsBaseCharacter 角色, FGameplayTag 标签, UObject __WorldContext)
		{
			BPL_Fight_C.StaticClass();
			BPL_Fight_C.__添加标签_FunctionParams* ptr = stackalloc BPL_Fight_C.__添加标签_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BPL_Fight_C.__添加标签_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_Fight_C.__添加标签_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->标签 = 标签;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BPL_Fight_C._ClassDefaultObjectPtr, BPL_Fight_C.__添加标签_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060287DB RID: 165851 RVA: 0x00A0D2B3 File Offset: 0x00A0B4B3
		protected BPL_Fight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040154DF RID: 87263
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/Fight/BPL_Fight.BPL_Fight_C";

		// Token: 0x040154E0 RID: 87264
		private static IntPtr _ClassPtr;

		// Token: 0x040154E1 RID: 87265
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040154E2 RID: 87266
		private static IntPtr __反应伤害倍率计算_NativeFunctionPtr;

		// Token: 0x040154E3 RID: 87267
		private static IntPtr __删除材质效果_NativeFunctionPtr;

		// Token: 0x040154E4 RID: 87268
		private static IntPtr __设置材质效果_NativeFunctionPtr;

		// Token: 0x040154E5 RID: 87269
		private static IntPtr __使用GE_NativeFunctionPtr;

		// Token: 0x040154E6 RID: 87270
		private static IntPtr __获取目标周围坐标点_NativeFunctionPtr;

		// Token: 0x040154E7 RID: 87271
		private static IntPtr __计算向量曲线值_NativeFunctionPtr;

		// Token: 0x040154E8 RID: 87272
		private static IntPtr __计算曲线值_NativeFunctionPtr;

		// Token: 0x040154E9 RID: 87273
		private static IntPtr __角度转化_NativeFunctionPtr;

		// Token: 0x040154EA RID: 87274
		private static IntPtr __射线检测_NativeFunctionPtr;

		// Token: 0x040154EB RID: 87275
		private static IntPtr __获取Actor周围坐标点_NativeFunctionPtr;

		// Token: 0x040154EC RID: 87276
		private static IntPtr __获取游戏实例_NativeFunctionPtr;

		// Token: 0x040154ED RID: 87277
		private static IntPtr __是否有标签_NativeFunctionPtr;

		// Token: 0x040154EE RID: 87278
		private static IntPtr __清除标签_NativeFunctionPtr;

		// Token: 0x040154EF RID: 87279
		private static IntPtr __添加标签_NativeFunctionPtr;

		// Token: 0x0200A10D RID: 41229
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __反应伤害倍率计算_FunctionParams
		{
			// Token: 0x04032DF5 RID: 208373
			[FieldOffset(0)]
			public float 角色1反应精通;

			// Token: 0x04032DF6 RID: 208374
			[FieldOffset(4)]
			public float 角色2反应精通;

			// Token: 0x04032DF7 RID: 208375
			[FieldOffset(8)]
			public IntPtr __WorldContext;

			// Token: 0x04032DF8 RID: 208376
			[FieldOffset(16)]
			public float Result;
		}

		// Token: 0x0200A10E RID: 41230
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __删除材质效果_FunctionParams
		{
			// Token: 0x04032DF9 RID: 208377
			[FieldOffset(0)]
			public IntPtr 设置对象_;

			// Token: 0x04032DFA RID: 208378
			[FieldOffset(8)]
			public int Handle_;

			// Token: 0x04032DFB RID: 208379
			[FieldOffset(12)]
			public bool PlayWithEnd;

			// Token: 0x04032DFC RID: 208380
			[FieldOffset(16)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A10F RID: 41231
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __设置材质效果_FunctionParams
		{
			// Token: 0x04032DFD RID: 208381
			[FieldOffset(0)]
			public IntPtr 设置对象;

			// Token: 0x04032DFE RID: 208382
			[FieldOffset(8)]
			public IntPtr 材质配置;

			// Token: 0x04032DFF RID: 208383
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032E00 RID: 208384
			[FieldOffset(24)]
			public int Handle;
		}

		// Token: 0x0200A110 RID: 41232
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 464)]
		protected ref struct __使用GE_FunctionParams
		{
			// Token: 0x04032E01 RID: 208385
			[FieldOffset(0)]
			public IntPtr 使用者;

			// Token: 0x04032E02 RID: 208386
			[FieldOffset(8)]
			public IntPtr 目标;

			// Token: 0x04032E03 RID: 208387
			[FieldOffset(16)]
			public int GE的等级;

			// Token: 0x04032E04 RID: 208388
			[FieldOffset(24)]
			public byte 添加AssetTags;

			// Token: 0x04032E05 RID: 208389
			[FieldOffset(56)]
			public byte 添加GrantedTags;

			// Token: 0x04032E06 RID: 208390
			[FieldOffset(88)]
			public int 层数;

			// Token: 0x04032E07 RID: 208391
			[FieldOffset(92)]
			public float Duration;

			// Token: 0x04032E08 RID: 208392
			[Nullable(new byte[]
			{
				0,
				1
			})]
			[FieldOffset(96)]
			public TSubclassOf<UGameplayEffect> GE的类型;

			// Token: 0x04032E09 RID: 208393
			[FieldOffset(104)]
			public byte GE的参数;

			// Token: 0x04032E0A RID: 208394
			[FieldOffset(120)]
			public IntPtr __WorldContext;

			// Token: 0x04032E0B RID: 208395
			[FieldOffset(128)]
			public byte ActiveHandle;
		}

		// Token: 0x0200A111 RID: 41233
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __获取目标周围坐标点_FunctionParams
		{
			// Token: 0x04032E0C RID: 208396
			[FieldOffset(0)]
			public FRotator 目标旋转;

			// Token: 0x04032E0D RID: 208397
			[FieldOffset(16)]
			public FVectorDouble 目标坐标;

			// Token: 0x04032E0E RID: 208398
			[FieldOffset(40)]
			public float 旋转;

			// Token: 0x04032E0F RID: 208399
			[FieldOffset(44)]
			public float 仰角;

			// Token: 0x04032E10 RID: 208400
			[FieldOffset(48)]
			public float 长度;

			// Token: 0x04032E11 RID: 208401
			[FieldOffset(56)]
			public IntPtr __WorldContext;

			// Token: 0x04032E12 RID: 208402
			[FieldOffset(64)]
			public FVectorDouble 坐标点;
		}

		// Token: 0x0200A112 RID: 41234
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __计算向量曲线值_FunctionParams
		{
			// Token: 0x04032E13 RID: 208403
			[FieldOffset(0)]
			public float 已经经过时间;

			// Token: 0x04032E14 RID: 208404
			[FieldOffset(4)]
			public float 总时间;

			// Token: 0x04032E15 RID: 208405
			[FieldOffset(8)]
			public IntPtr 向量曲线;

			// Token: 0x04032E16 RID: 208406
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032E17 RID: 208407
			[FieldOffset(24)]
			public FVector 向量值;
		}

		// Token: 0x0200A113 RID: 41235
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __计算曲线值_FunctionParams
		{
			// Token: 0x04032E18 RID: 208408
			[FieldOffset(0)]
			public float 已经过时间;

			// Token: 0x04032E19 RID: 208409
			[FieldOffset(4)]
			public float 总时间;

			// Token: 0x04032E1A RID: 208410
			[FieldOffset(8)]
			public IntPtr 曲线;

			// Token: 0x04032E1B RID: 208411
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032E1C RID: 208412
			[FieldOffset(24)]
			public float 百分比;
		}

		// Token: 0x0200A114 RID: 41236
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __角度转化_FunctionParams
		{
			// Token: 0x04032E1D RID: 208413
			[FieldOffset(0)]
			public float Input;

			// Token: 0x04032E1E RID: 208414
			[FieldOffset(8)]
			public IntPtr __WorldContext;

			// Token: 0x04032E1F RID: 208415
			[FieldOffset(16)]
			public float Output;
		}

		// Token: 0x0200A115 RID: 41237
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 424)]
		protected ref struct __射线检测_FunctionParams
		{
			// Token: 0x04032E20 RID: 208416
			[FieldOffset(0)]
			public IntPtr Context;

			// Token: 0x04032E21 RID: 208417
			[FieldOffset(8)]
			public FVectorDouble Start;

			// Token: 0x04032E22 RID: 208418
			[FieldOffset(32)]
			public FVectorDouble End;

			// Token: 0x04032E23 RID: 208419
			[FieldOffset(56)]
			public TEnumAsByte<ETraceTypeQuery> TraceChannel;

			// Token: 0x04032E24 RID: 208420
			[FieldOffset(57)]
			public bool bTraceComplex;

			// Token: 0x04032E25 RID: 208421
			[FieldOffset(58)]
			public TEnumAsByte<EDrawDebugTrace> DrawDebugType;

			// Token: 0x04032E26 RID: 208422
			[FieldOffset(59)]
			public bool bIgnoreSelf;

			// Token: 0x04032E27 RID: 208423
			[FieldOffset(60)]
			public FLinearColor TraceColor;

			// Token: 0x04032E28 RID: 208424
			[FieldOffset(76)]
			public FLinearColor TraceHitColor;

			// Token: 0x04032E29 RID: 208425
			[FieldOffset(92)]
			public float DrawTime;

			// Token: 0x04032E2A RID: 208426
			[FieldOffset(96)]
			public IntPtr __WorldContext;

			// Token: 0x04032E2B RID: 208427
			[FieldOffset(104)]
			public byte OutHit;

			// Token: 0x04032E2C RID: 208428
			[FieldOffset(252)]
			public bool __Result;
		}

		// Token: 0x0200A116 RID: 41238
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __获取Actor周围坐标点_FunctionParams
		{
			// Token: 0x04032E2D RID: 208429
			[FieldOffset(0)]
			public IntPtr Actor;

			// Token: 0x04032E2E RID: 208430
			[FieldOffset(8)]
			public float 旋转;

			// Token: 0x04032E2F RID: 208431
			[FieldOffset(12)]
			public float 仰角;

			// Token: 0x04032E30 RID: 208432
			[FieldOffset(16)]
			public float 长度;

			// Token: 0x04032E31 RID: 208433
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x04032E32 RID: 208434
			[FieldOffset(32)]
			public FVectorDouble 坐标点;
		}

		// Token: 0x0200A117 RID: 41239
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __获取游戏实例_FunctionParams
		{
			// Token: 0x04032E33 RID: 208435
			[FieldOffset(0)]
			public IntPtr __WorldContext;

			// Token: 0x04032E34 RID: 208436
			[FieldOffset(8)]
			public IntPtr AsBP_Main_Game_Instance;
		}

		// Token: 0x0200A118 RID: 41240
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __是否有标签_FunctionParams
		{
			// Token: 0x04032E35 RID: 208437
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04032E36 RID: 208438
			[FieldOffset(8)]
			public FGameplayTag 标签;

			// Token: 0x04032E37 RID: 208439
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x04032E38 RID: 208440
			[FieldOffset(32)]
			public bool __Result;
		}

		// Token: 0x0200A119 RID: 41241
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __清除标签_FunctionParams
		{
			// Token: 0x04032E39 RID: 208441
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04032E3A RID: 208442
			[FieldOffset(8)]
			public FGameplayTag 标签;

			// Token: 0x04032E3B RID: 208443
			[FieldOffset(24)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A11A RID: 41242
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __添加标签_FunctionParams
		{
			// Token: 0x04032E3C RID: 208444
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04032E3D RID: 208445
			[FieldOffset(8)]
			public FGameplayTag 标签;

			// Token: 0x04032E3E RID: 208446
			[FieldOffset(24)]
			public IntPtr __WorldContext;
		}
	}
}
