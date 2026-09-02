using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.CreatureTools;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using AkiClient.Game.Aki.UI.Manager;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA
{
	// Token: 0x02004374 RID: 17268
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GA/GA_Base.GA_Base_C")]
	[UnrealStructLayout(1472, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1468)]
	public class GA_Base_C : UBaseGameplayAbility, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB40 RID: 187200 RVA: 0x00AC7A32 File Offset: 0x00AC5C32
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Base_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GA/GA_Base.GA_Base_C");
			}
			return GA_Base_C._ClassPtr;
		}

		// Token: 0x0602DB41 RID: 187201 RVA: 0x00AC7A58 File Offset: 0x00AC5C58
		public GA_Base_C() : this(BuiltinUtils.AllocNativeUObject(GA_Base_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB42 RID: 187202 RVA: 0x00AC7A80 File Offset: 0x00AC5C80
		[NullableContext(1)]
		public GA_Base_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Base_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D24 RID: 32036
		// (get) Token: 0x0602DB43 RID: 187203 RVA: 0x00AC7AB4 File Offset: 0x00AC5CB4
		// (set) Token: 0x0602DB44 RID: 187204 RVA: 0x00AC7AED File Offset: 0x00AC5CED
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Base_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Base_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007D25 RID: 32037
		// (get) Token: 0x0602DB45 RID: 187205 RVA: 0x00AC7B10 File Offset: 0x00AC5D10
		// (set) Token: 0x0602DB46 RID: 187206 RVA: 0x00AC7B49 File Offset: 0x00AC5D49
		[Nullable(1)]
		public SSkillInfo 当前技能数据
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SSkillInfo result;
				if ((result = this._当前技能数据) == null)
				{
					result = (this._当前技能数据 = new SSkillInfo(base.NativePtr + (IntPtr)GA_Base_C.__PropertyOffset_1, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSkillInfo.StaticStruct(), base.NativePtr + (IntPtr)GA_Base_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007D26 RID: 32038
		// (get) Token: 0x0602DB47 RID: 187207 RVA: 0x00AC7B6A File Offset: 0x00AC5D6A
		// (set) Token: 0x0602DB48 RID: 187208 RVA: 0x00AC7B7E File Offset: 0x00AC5D7E
		[Nullable(1)]
		public unsafe string 当前技能数据名
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)GA_Base_C.__PropertyOffset_2)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)GA_Base_C.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17007D27 RID: 32039
		// (get) Token: 0x0602DB49 RID: 187209 RVA: 0x00AC7B93 File Offset: 0x00AC5D93
		// (set) Token: 0x0602DB4A RID: 187210 RVA: 0x00AC7BA3 File Offset: 0x00AC5DA3
		public unsafe int SkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Base_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Base_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602DB4B RID: 187211 RVA: 0x00AC7BB4 File Offset: 0x00AC5DB4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 异步使用技能(TsBaseCharacter 释放者, FName 技能ID, AActor 技能目标, FName Socket)
		{
			GA_Base_C.__异步使用技能_FunctionParams* ptr = stackalloc GA_Base_C.__异步使用技能_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Base_C.__异步使用技能_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__异步使用技能_NativeFunctionPtr, (void*)ptr, 1);
			ptr->释放者 = ((释放者 != null) ? 释放者.NativePtr : IntPtr.Zero);
			ptr->技能ID = 技能ID;
			ptr->技能目标 = ((技能目标 != null) ? 技能目标.NativePtr : IntPtr.Zero);
			ptr->Socket = Socket;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__异步使用技能_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB4C RID: 187212 RVA: 0x00AC7C30 File Offset: 0x00AC5E30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取随机召唤物(int 召唤者, int Index, ref int 实体Id)
		{
			GA_Base_C.__获取随机召唤物_FunctionParams* ptr = stackalloc GA_Base_C.__获取随机召唤物_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Base_C.__获取随机召唤物_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取随机召唤物_NativeFunctionPtr, (void*)ptr, 1);
			ptr->召唤者 = 召唤者;
			ptr->Index = Index;
			ptr->实体Id = 实体Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取随机召唤物_NativeFunctionPtr, (void*)ptr);
			实体Id = ptr->实体Id;
		}

		// Token: 0x0602DB4D RID: 187213 RVA: 0x00AC7C90 File Offset: 0x00AC5E90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 随机召唤(int 召唤者Id, int Index, FTransformDouble Transform, int SkillId, bool IsVisivle)
		{
			GA_Base_C.__随机召唤_FunctionParams* ptr = stackalloc GA_Base_C.__随机召唤_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(GA_Base_C.__随机召唤_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__随机召唤_NativeFunctionPtr, (void*)ptr, 1);
			ptr->召唤者Id = 召唤者Id;
			ptr->Index = Index;
			ptr->Transform = Transform;
			ptr->SkillId = SkillId;
			ptr->IsVisivle = IsVisivle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__随机召唤_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB4E RID: 187214 RVA: 0x00AC7CF4 File Offset: 0x00AC5EF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Apply_Buff_with_Level(long buffId)
		{
			GA_Base_C.__Apply_Buff_with_Level_FunctionParams* ptr = stackalloc GA_Base_C.__Apply_Buff_with_Level_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(GA_Base_C.__Apply_Buff_with_Level_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__Apply_Buff_with_Level_NativeFunctionPtr, (void*)ptr, 1);
			ptr->buffId = buffId;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__Apply_Buff_with_Level_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB4F RID: 187215 RVA: 0x00AC7D3C File Offset: 0x00AC5F3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddTag(FGameplayTag tag)
		{
			GA_Base_C.__AddTag_FunctionParams* ptr = stackalloc GA_Base_C.__AddTag_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Base_C.__AddTag_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__AddTag_NativeFunctionPtr, (void*)ptr, 1);
			ptr->tag = tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__AddTag_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB50 RID: 187216 RVA: 0x00AC7D84 File Offset: 0x00AC5F84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RemoveTag(FGameplayTag tag)
		{
			GA_Base_C.__RemoveTag_FunctionParams* ptr = stackalloc GA_Base_C.__RemoveTag_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Base_C.__RemoveTag_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__RemoveTag_NativeFunctionPtr, (void*)ptr, 1);
			ptr->tag = tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__RemoveTag_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB51 RID: 187217 RVA: 0x00AC7DCC File Offset: 0x00AC5FCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RemoveBuff(long buffId)
		{
			GA_Base_C.__RemoveBuff_FunctionParams* ptr = stackalloc GA_Base_C.__RemoveBuff_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Base_C.__RemoveBuff_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__RemoveBuff_NativeFunctionPtr, (void*)ptr, 1);
			ptr->buffId = buffId;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__RemoveBuff_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB52 RID: 187218 RVA: 0x00AC7E14 File Offset: 0x00AC6014
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 伴生物获取召唤者对象(ref TsBaseCharacter 对象, ref bool 是否找到对象)
		{
			GA_Base_C.__伴生物获取召唤者对象_FunctionParams* ptr = stackalloc GA_Base_C.__伴生物获取召唤者对象_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Base_C.__伴生物获取召唤者对象_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__伴生物获取召唤者对象_NativeFunctionPtr, (void*)ptr, 1);
			ref GA_Base_C.__伴生物获取召唤者对象_FunctionParams ptr2 = ref *ptr;
			TsBaseCharacter tsBaseCharacter = 对象;
			ptr2.对象 = ((tsBaseCharacter != null) ? tsBaseCharacter.NativePtr : IntPtr.Zero);
			ptr->是否找到对象 = 是否找到对象;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__伴生物获取召唤者对象_NativeFunctionPtr, (void*)ptr);
			对象 = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(ptr->对象);
			是否找到对象 = ptr->是否找到对象;
		}

		// Token: 0x0602DB53 RID: 187219 RVA: 0x00AC7E88 File Offset: 0x00AC6088
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置角色地面移动([Nullable(2)] TsBaseCharacter 角色, FVector Velocity, float DeltaSeconds, string context)
		{
			GA_Base_C.__设置角色地面移动_FunctionParams* ptr = stackalloc GA_Base_C.__设置角色地面移动_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Base_C.__设置角色地面移动_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置角色地面移动_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->Velocity = Velocity;
			ptr->DeltaSeconds = DeltaSeconds;
			FString.CopyFrom((void*)(&ptr->context), context);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置角色地面移动_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__设置角色地面移动_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB54 RID: 187220 RVA: 0x00AC7F0C File Offset: 0x00AC610C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置角色传送([Nullable(2)] TsBaseCharacter 角色, FVectorDouble location, FRotator Rotator, string context)
		{
			GA_Base_C.__设置角色传送_FunctionParams* ptr = stackalloc GA_Base_C.__设置角色传送_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(GA_Base_C.__设置角色传送_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置角色传送_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->location = location;
			ptr->Rotator = Rotator;
			FString.CopyFrom((void*)(&ptr->context), context);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置角色传送_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__设置角色传送_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB55 RID: 187221 RVA: 0x00AC7F90 File Offset: 0x00AC6190
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 叠加角色世界位置([Nullable(2)] TsBaseCharacter 角色, FVectorDouble location, bool sweep, bool teleport, string context)
		{
			GA_Base_C.__叠加角色世界位置_FunctionParams* ptr = stackalloc GA_Base_C.__叠加角色世界位置_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(GA_Base_C.__叠加角色世界位置_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__叠加角色世界位置_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->location = location;
			ptr->sweep = sweep;
			ptr->teleport = teleport;
			FString.CopyFrom((void*)(&ptr->context), context);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__叠加角色世界位置_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__叠加角色世界位置_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB56 RID: 187222 RVA: 0x00AC801C File Offset: 0x00AC621C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 叠加角色世界旋转([Nullable(2)] TsBaseCharacter 角色, FRotator rotation, bool sweep, bool teleport, string context)
		{
			GA_Base_C.__叠加角色世界旋转_FunctionParams* ptr = stackalloc GA_Base_C.__叠加角色世界旋转_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(GA_Base_C.__叠加角色世界旋转_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__叠加角色世界旋转_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->rotation = rotation;
			ptr->sweep = sweep;
			ptr->teleport = teleport;
			FString.CopyFrom((void*)(&ptr->context), context);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__叠加角色世界旋转_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__叠加角色世界旋转_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB57 RID: 187223 RVA: 0x00AC80A8 File Offset: 0x00AC62A8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置角色位置和旋转([Nullable(2)] TsBaseCharacter 角色, FVectorDouble location, FRotator rotation, bool sweep, string context)
		{
			GA_Base_C.__设置角色位置和旋转_FunctionParams* ptr = stackalloc GA_Base_C.__设置角色位置和旋转_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(GA_Base_C.__设置角色位置和旋转_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置角色位置和旋转_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->location = location;
			ptr->rotation = rotation;
			ptr->sweep = sweep;
			FString.CopyFrom((void*)(&ptr->context), context);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置角色位置和旋转_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__设置角色位置和旋转_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB58 RID: 187224 RVA: 0x00AC8134 File Offset: 0x00AC6334
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置角色变换([Nullable(2)] TsBaseCharacter 角色, FTransformDouble Transform, bool sweep, string context)
		{
			GA_Base_C.__设置角色变换_FunctionParams* ptr = stackalloc GA_Base_C.__设置角色变换_FunctionParams[(UIntPtr)559] + 15L / (long)sizeof(GA_Base_C.__设置角色变换_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置角色变换_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->Transform = Transform;
			ptr->sweep = sweep;
			FString.CopyFrom((void*)(&ptr->context), context);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置角色变换_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__设置角色变换_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB59 RID: 187225 RVA: 0x00AC81BC File Offset: 0x00AC63BC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool 设置角色旋转([Nullable(2)] TsBaseCharacter 角色, FRotator rotation, bool sweep, string context)
		{
			GA_Base_C.__设置角色旋转_FunctionParams* ptr = stackalloc GA_Base_C.__设置角色旋转_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Base_C.__设置角色旋转_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置角色旋转_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->rotation = rotation;
			ptr->sweep = sweep;
			FString.CopyFrom((void*)(&ptr->context), context);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置角色旋转_NativeFunctionPtr, (void*)ptr);
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__设置角色旋转_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DB5A RID: 187226 RVA: 0x00AC8244 File Offset: 0x00AC6444
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool 设置角色位置([Nullable(2)] TsBaseCharacter 角色, FVectorDouble location, bool sweep, bool teleport, string context)
		{
			GA_Base_C.__设置角色位置_FunctionParams* ptr = stackalloc GA_Base_C.__设置角色位置_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(GA_Base_C.__设置角色位置_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置角色位置_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->location = location;
			ptr->sweep = sweep;
			ptr->teleport = teleport;
			FString.CopyFrom((void*)(&ptr->context), context);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置角色位置_NativeFunctionPtr, (void*)ptr);
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__设置角色位置_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DB5B RID: 187227 RVA: 0x00AC82D8 File Offset: 0x00AC64D8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置角色Pawn通道碰撞响应(TsBaseCharacter 角色, EPawnChannel pawnChannel, ECollisionResponse newResponse)
		{
			GA_Base_C.__设置角色Pawn通道碰撞响应_FunctionParams* ptr = stackalloc GA_Base_C.__设置角色Pawn通道碰撞响应_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Base_C.__设置角色Pawn通道碰撞响应_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置角色Pawn通道碰撞响应_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			ptr->pawnChannel = pawnChannel;
			ptr->newResponse = newResponse;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置角色Pawn通道碰撞响应_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB5C RID: 187228 RVA: 0x00AC8348 File Offset: 0x00AC6548
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 给对象移除标签(TsBaseCharacter Target, FGameplayTag tag)
		{
			GA_Base_C.__给对象移除标签_FunctionParams* ptr = stackalloc GA_Base_C.__给对象移除标签_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Base_C.__给对象移除标签_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__给对象移除标签_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Target = ((Target != null) ? Target.NativePtr : IntPtr.Zero);
			ptr->tag = tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__给对象移除标签_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB5D RID: 187229 RVA: 0x00AC83A4 File Offset: 0x00AC65A4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 给对象添加标签(TsBaseCharacter Target, FGameplayTag tag)
		{
			GA_Base_C.__给对象添加标签_FunctionParams* ptr = stackalloc GA_Base_C.__给对象添加标签_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Base_C.__给对象添加标签_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__给对象添加标签_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Target = ((Target != null) ? Target.NativePtr : IntPtr.Zero);
			ptr->tag = tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__给对象添加标签_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB5E RID: 187230 RVA: 0x00AC8400 File Offset: 0x00AC6600
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置子弹目标([Nullable(2)] TsBaseCharacter Attacker, string Key, int TargetId)
		{
			GA_Base_C.__设置子弹目标_FunctionParams* ptr = stackalloc GA_Base_C.__设置子弹目标_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(GA_Base_C.__设置子弹目标_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置子弹目标_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Attacker = ((Attacker != null) ? Attacker.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->Key), Key);
			ptr->TargetId = TargetId;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置子弹目标_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__设置子弹目标_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB5F RID: 187231 RVA: 0x00AC847A File Offset: 0x00AC667A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 生成特效()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__生成特效_NativeFunctionPtr, null);
		}

		// Token: 0x0602DB60 RID: 187232 RVA: 0x00AC8490 File Offset: 0x00AC6690
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 修改材质效果(IBPI_CreatureInterface_C Entity, bool IsGroup, UObject 材质效果)
		{
			GA_Base_C.__修改材质效果_FunctionParams* ptr = stackalloc GA_Base_C.__修改材质效果_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(GA_Base_C.__修改材质效果_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__修改材质效果_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Entity = new FScriptInterface(Entity, (Entity != null) ? Entity.InterfaceOffset() : 0);
			ptr->IsGroup = IsGroup;
			ptr->材质效果 = ((材质效果 != null) ? 材质效果.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__修改材质效果_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB61 RID: 187233 RVA: 0x00AC8504 File Offset: 0x00AC6704
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置黑板Rotator([Nullable(2)] TsBaseCharacter 角色, string key, FRotator 值)
		{
			GA_Base_C.__设置黑板Rotator_FunctionParams* ptr = stackalloc GA_Base_C.__设置黑板Rotator_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(GA_Base_C.__设置黑板Rotator_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置黑板Rotator_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->key), key);
			ptr->值 = 值;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置黑板Rotator_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__设置黑板Rotator_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB62 RID: 187234 RVA: 0x00AC857E File Offset: 0x00AC677E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 退出瞄准模式()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__退出瞄准模式_NativeFunctionPtr, null);
		}

		// Token: 0x0602DB63 RID: 187235 RVA: 0x00AC8594 File Offset: 0x00AC6794
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 进入瞄准模式(bool 瞄准键进入, EAimViewState 瞄准镜头类型, bool isWalk)
		{
			GA_Base_C.__进入瞄准模式_FunctionParams* ptr = stackalloc GA_Base_C.__进入瞄准模式_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Base_C.__进入瞄准模式_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__进入瞄准模式_NativeFunctionPtr, (void*)ptr, 1);
			ptr->瞄准键进入 = 瞄准键进入;
			ptr->瞄准镜头类型 = 瞄准镜头类型;
			ptr->isWalk = isWalk;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__进入瞄准模式_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB64 RID: 187236 RVA: 0x00AC85F0 File Offset: 0x00AC67F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 对圆柱体类型的合法点检测(float 施法者半高, float 施法者半径, float 目标半高, float 目标半径, FVectorDouble 起点, FVectorDouble 终点, ref FVectorDouble 合法点)
		{
			GA_Base_C.__对圆柱体类型的合法点检测_FunctionParams* ptr = stackalloc GA_Base_C.__对圆柱体类型的合法点检测_FunctionParams[(UIntPtr)1815] + 15L / (long)sizeof(GA_Base_C.__对圆柱体类型的合法点检测_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__对圆柱体类型的合法点检测_NativeFunctionPtr, (void*)ptr, 1);
			ptr->施法者半高 = 施法者半高;
			ptr->施法者半径 = 施法者半径;
			ptr->目标半高 = 目标半高;
			ptr->目标半径 = 目标半径;
			ptr->起点 = 起点;
			ptr->终点 = 终点;
			ptr->合法点 = 合法点;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__对圆柱体类型的合法点检测_NativeFunctionPtr, (void*)ptr);
			合法点 = ptr->合法点;
		}

		// Token: 0x0602DB65 RID: 187237 RVA: 0x00AC867C File Offset: 0x00AC687C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取目标正后方的合法点(AActor 目标Actor, float 向后距离, ref FVectorDouble 合法点, ref bool 碰撞挤压)
		{
			GA_Base_C.__获取目标正后方的合法点_FunctionParams* ptr = stackalloc GA_Base_C.__获取目标正后方的合法点_FunctionParams[(UIntPtr)391] + 15L / (long)sizeof(GA_Base_C.__获取目标正后方的合法点_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取目标正后方的合法点_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标Actor = ((目标Actor != null) ? 目标Actor.NativePtr : IntPtr.Zero);
			ptr->向后距离 = 向后距离;
			ptr->合法点 = 合法点;
			ptr->碰撞挤压 = 碰撞挤压;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取目标正后方的合法点_NativeFunctionPtr, (void*)ptr);
			合法点 = ptr->合法点;
			碰撞挤压 = ptr->碰撞挤压;
		}

		// Token: 0x0602DB66 RID: 187238 RVA: 0x00AC8708 File Offset: 0x00AC6908
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取目标到终点的合法点(TsBaseCharacter 目标Actor, FVectorDouble 终点, ref FVectorDouble 合法点, ref bool 碰撞挤压)
		{
			GA_Base_C.__获取目标到终点的合法点_FunctionParams* ptr = stackalloc GA_Base_C.__获取目标到终点的合法点_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(GA_Base_C.__获取目标到终点的合法点_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取目标到终点的合法点_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标Actor = ((目标Actor != null) ? 目标Actor.NativePtr : IntPtr.Zero);
			ptr->终点 = 终点;
			ptr->合法点 = 合法点;
			ptr->碰撞挤压 = 碰撞挤压;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取目标到终点的合法点_NativeFunctionPtr, (void*)ptr);
			合法点 = ptr->合法点;
			碰撞挤压 = ptr->碰撞挤压;
		}

		// Token: 0x0602DB67 RID: 187239 RVA: 0x00AC8794 File Offset: 0x00AC6994
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 通过角度获取目标附近的合法点(AActor 目标Actor, float 旋转, float 仰角, float 长度, ref FVectorDouble 合法点, ref bool 碰撞挤压)
		{
			GA_Base_C.__通过角度获取目标附近的合法点_FunctionParams* ptr = stackalloc GA_Base_C.__通过角度获取目标附近的合法点_FunctionParams[(UIntPtr)311] + 15L / (long)sizeof(GA_Base_C.__通过角度获取目标附近的合法点_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__通过角度获取目标附近的合法点_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标Actor = ((目标Actor != null) ? 目标Actor.NativePtr : IntPtr.Zero);
			ptr->旋转 = 旋转;
			ptr->仰角 = 仰角;
			ptr->长度 = 长度;
			ptr->合法点 = 合法点;
			ptr->碰撞挤压 = 碰撞挤压;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__通过角度获取目标附近的合法点_NativeFunctionPtr, (void*)ptr);
			合法点 = ptr->合法点;
			碰撞挤压 = ptr->碰撞挤压;
		}

		// Token: 0x0602DB68 RID: 187240 RVA: 0x00AC8830 File Offset: 0x00AC6A30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置接收同打断等级打断(bool skillAcceptInput)
		{
			GA_Base_C.__设置接收同打断等级打断_FunctionParams* ptr = stackalloc GA_Base_C.__设置接收同打断等级打断_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Base_C.__设置接收同打断等级打断_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置接收同打断等级打断_NativeFunctionPtr, (void*)ptr, 1);
			ptr->skillAcceptInput = skillAcceptInput;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置接收同打断等级打断_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB69 RID: 187241 RVA: 0x00AC8878 File Offset: 0x00AC6A78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 修改当前技能打断等级(float priority)
		{
			GA_Base_C.__修改当前技能打断等级_FunctionParams* ptr = stackalloc GA_Base_C.__修改当前技能打断等级_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Base_C.__修改当前技能打断等级_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__修改当前技能打断等级_NativeFunctionPtr, (void*)ptr, 1);
			ptr->priority = priority;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__修改当前技能打断等级_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB6A RID: 187242 RVA: 0x00AC88C0 File Offset: 0x00AC6AC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 移除召唤物(int 召唤者ID, int 移除召唤物ID)
		{
			GA_Base_C.__移除召唤物_FunctionParams* ptr = stackalloc GA_Base_C.__移除召唤物_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Base_C.__移除召唤物_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__移除召唤物_NativeFunctionPtr, (void*)ptr, 1);
			ptr->召唤者ID = 召唤者ID;
			ptr->移除召唤物ID = 移除召唤物ID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__移除召唤物_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB6B RID: 187243 RVA: 0x00AC8910 File Offset: 0x00AC6B10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 根据子弹实体ID销毁子弹(int 子弹ID, bool isSummonChildBullet)
		{
			GA_Base_C.__根据子弹实体ID销毁子弹_FunctionParams* ptr = stackalloc GA_Base_C.__根据子弹实体ID销毁子弹_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(GA_Base_C.__根据子弹实体ID销毁子弹_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__根据子弹实体ID销毁子弹_NativeFunctionPtr, (void*)ptr, 1);
			ptr->子弹ID = 子弹ID;
			ptr->isSummonChildBullet = isSummonChildBullet;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__根据子弹实体ID销毁子弹_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB6C RID: 187244 RVA: 0x00AC8960 File Offset: 0x00AC6B60
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取角色ID(TsBaseCharacter 目标, ref float RoleID)
		{
			GA_Base_C.__获取角色ID_FunctionParams* ptr = stackalloc GA_Base_C.__获取角色ID_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Base_C.__获取角色ID_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取角色ID_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标 = ((目标 != null) ? 目标.NativePtr : IntPtr.Zero);
			ptr->RoleID = RoleID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取角色ID_NativeFunctionPtr, (void*)ptr);
			RoleID = ptr->RoleID;
		}

		// Token: 0x0602DB6D RID: 187245 RVA: 0x00AC89C8 File Offset: 0x00AC6BC8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取游戏事件管理器(ref BP_EventManager_C 事件管理器)
		{
			GA_Base_C.__获取游戏事件管理器_FunctionParams* ptr = stackalloc GA_Base_C.__获取游戏事件管理器_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Base_C.__获取游戏事件管理器_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取游戏事件管理器_NativeFunctionPtr, (void*)ptr, 1);
			ref GA_Base_C.__获取游戏事件管理器_FunctionParams ptr2 = ref *ptr;
			BP_EventManager_C bp_EventManager_C = 事件管理器;
			ptr2.事件管理器 = ((bp_EventManager_C != null) ? bp_EventManager_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取游戏事件管理器_NativeFunctionPtr, (void*)ptr);
			事件管理器 = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_EventManager_C>(ptr->事件管理器);
		}

		// Token: 0x0602DB6E RID: 187246 RVA: 0x00AC8A2C File Offset: 0x00AC6C2C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取黑板String([Nullable(2)] TsBaseCharacter 角色, string Key, ref string String)
		{
			GA_Base_C.__获取黑板String_FunctionParams* ptr = stackalloc GA_Base_C.__获取黑板String_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(GA_Base_C.__获取黑板String_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取黑板String_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->Key), Key);
			FString.CopyFrom((void*)(&ptr->String), String);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取黑板String_NativeFunctionPtr, (void*)ptr);
			String = FString.ToString((void*)(&ptr->String));
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__获取黑板String_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB6F RID: 187247 RVA: 0x00AC8ABC File Offset: 0x00AC6CBC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置黑板String([Nullable(2)] TsBaseCharacter 角色, string Key, string 值)
		{
			GA_Base_C.__设置黑板String_FunctionParams* ptr = stackalloc GA_Base_C.__设置黑板String_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(GA_Base_C.__设置黑板String_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置黑板String_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->Key), Key);
			FString.CopyFrom((void*)(&ptr->值), 值);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置黑板String_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__设置黑板String_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB70 RID: 187248 RVA: 0x00AC8B3C File Offset: 0x00AC6D3C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 子弹冻结(string 子弹Id, float 冻结时间)
		{
			GA_Base_C.__子弹冻结_FunctionParams* ptr = stackalloc GA_Base_C.__子弹冻结_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Base_C.__子弹冻结_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__子弹冻结_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->子弹Id), 子弹Id);
			ptr->冻结时间 = 冻结时间;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__子弹冻结_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__子弹冻结_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB71 RID: 187249 RVA: 0x00AC8BA0 File Offset: 0x00AC6DA0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取当前GA的技能数据名(ref string 当前技能数据名)
		{
			GA_Base_C.__获取当前GA的技能数据名_FunctionParams* ptr = stackalloc GA_Base_C.__获取当前GA的技能数据名_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Base_C.__获取当前GA的技能数据名_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取当前GA的技能数据名_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->当前技能数据名), 当前技能数据名);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取当前GA的技能数据名_NativeFunctionPtr, (void*)ptr);
			当前技能数据名 = FString.ToString((void*)(&ptr->当前技能数据名));
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__获取当前GA的技能数据名_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB72 RID: 187250 RVA: 0x00AC8C0C File Offset: 0x00AC6E0C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取当前操作角色Actor(ref TsBaseCharacter 当前角色)
		{
			GA_Base_C.__获取当前操作角色Actor_FunctionParams* ptr = stackalloc GA_Base_C.__获取当前操作角色Actor_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Base_C.__获取当前操作角色Actor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取当前操作角色Actor_NativeFunctionPtr, (void*)ptr, 1);
			ref GA_Base_C.__获取当前操作角色Actor_FunctionParams ptr2 = ref *ptr;
			TsBaseCharacter tsBaseCharacter = 当前角色;
			ptr2.当前角色 = ((tsBaseCharacter != null) ? tsBaseCharacter.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取当前操作角色Actor_NativeFunctionPtr, (void*)ptr);
			当前角色 = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(ptr->当前角色);
		}

		// Token: 0x0602DB73 RID: 187251 RVA: 0x00AC8C70 File Offset: 0x00AC6E70
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置黑板Vector([Nullable(2)] TsBaseCharacter 角色, string key, FVectorDouble 值)
		{
			GA_Base_C.__设置黑板Vector_FunctionParams* ptr = stackalloc GA_Base_C.__设置黑板Vector_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(GA_Base_C.__设置黑板Vector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置黑板Vector_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->key), key);
			ptr->值 = 值;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置黑板Vector_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__设置黑板Vector_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB74 RID: 187252 RVA: 0x00AC8CEC File Offset: 0x00AC6EEC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取黑板Vector([Nullable(2)] TsBaseCharacter 角色, string key, ref FVectorDouble 值)
		{
			GA_Base_C.__获取黑板Vector_FunctionParams* ptr = stackalloc GA_Base_C.__获取黑板Vector_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(GA_Base_C.__获取黑板Vector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取黑板Vector_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->key), key);
			ptr->值 = 值;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取黑板Vector_NativeFunctionPtr, (void*)ptr);
			值 = ptr->值;
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__获取黑板Vector_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB75 RID: 187253 RVA: 0x00AC8D78 File Offset: 0x00AC6F78
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置黑板EntityId([Nullable(2)] TsBaseCharacter 角色, string key, int 值)
		{
			GA_Base_C.__设置黑板EntityId_FunctionParams* ptr = stackalloc GA_Base_C.__设置黑板EntityId_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(GA_Base_C.__设置黑板EntityId_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置黑板EntityId_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->key), key);
			ptr->值 = 值;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置黑板EntityId_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__设置黑板EntityId_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB76 RID: 187254 RVA: 0x00AC8DF4 File Offset: 0x00AC6FF4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取黑板EntityId([Nullable(2)] TsBaseCharacter 角色, string key, ref int 值)
		{
			GA_Base_C.__获取黑板EntityId_FunctionParams* ptr = stackalloc GA_Base_C.__获取黑板EntityId_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(GA_Base_C.__获取黑板EntityId_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取黑板EntityId_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->key), key);
			ptr->值 = 值;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取黑板EntityId_NativeFunctionPtr, (void*)ptr);
			值 = ptr->值;
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__获取黑板EntityId_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB77 RID: 187255 RVA: 0x00AC8E78 File Offset: 0x00AC7078
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 查询特定子弹数量(FName 子弹名字, ref int 子弹数量)
		{
			GA_Base_C.__查询特定子弹数量_FunctionParams* ptr = stackalloc GA_Base_C.__查询特定子弹数量_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(GA_Base_C.__查询特定子弹数量_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__查询特定子弹数量_NativeFunctionPtr, (void*)ptr, 1);
			ptr->子弹名字 = 子弹名字;
			ptr->子弹数量 = 子弹数量;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__查询特定子弹数量_NativeFunctionPtr, (void*)ptr);
			子弹数量 = ptr->子弹数量;
		}

		// Token: 0x0602DB78 RID: 187256 RVA: 0x00AC8ED4 File Offset: 0x00AC70D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取当前技能攻速(ref float SpeedRatio)
		{
			GA_Base_C.__获取当前技能攻速_FunctionParams* ptr = stackalloc GA_Base_C.__获取当前技能攻速_FunctionParams[(UIntPtr)519] + 15L / (long)sizeof(GA_Base_C.__获取当前技能攻速_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取当前技能攻速_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SpeedRatio = SpeedRatio;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取当前技能攻速_NativeFunctionPtr, (void*)ptr);
			SpeedRatio = ptr->SpeedRatio;
		}

		// Token: 0x0602DB79 RID: 187257 RVA: 0x00AC8F28 File Offset: 0x00AC7128
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 通过ID获取对象Buff层数(long buffId, bool enforceOnGoingCheck, ref int 层数)
		{
			GA_Base_C.__通过ID获取对象Buff层数_FunctionParams* ptr = stackalloc GA_Base_C.__通过ID获取对象Buff层数_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Base_C.__通过ID获取对象Buff层数_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__通过ID获取对象Buff层数_NativeFunctionPtr, (void*)ptr, 1);
			ptr->buffId = buffId;
			ptr->enforceOnGoingCheck = enforceOnGoingCheck;
			ptr->层数 = 层数;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__通过ID获取对象Buff层数_NativeFunctionPtr, (void*)ptr);
			层数 = ptr->层数;
		}

		// Token: 0x0602DB7A RID: 187258 RVA: 0x00AC8F88 File Offset: 0x00AC7188
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 施法者移除标签(FGameplayTag tag)
		{
			GA_Base_C.__施法者移除标签_FunctionParams* ptr = stackalloc GA_Base_C.__施法者移除标签_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Base_C.__施法者移除标签_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__施法者移除标签_NativeFunctionPtr, (void*)ptr, 1);
			ptr->tag = tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__施法者移除标签_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB7B RID: 187259 RVA: 0x00AC8FD0 File Offset: 0x00AC71D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 施法者添加标签(FGameplayTag Tag)
		{
			GA_Base_C.__施法者添加标签_FunctionParams* ptr = stackalloc GA_Base_C.__施法者添加标签_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Base_C.__施法者添加标签_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__施法者添加标签_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__施法者添加标签_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB7C RID: 187260 RVA: 0x00AC9018 File Offset: 0x00AC7218
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int 创建并播放特效(UObject DA文件名, FTransformDouble transform, bool AttachToCharacter)
		{
			GA_Base_C.__创建并播放特效_FunctionParams* ptr = stackalloc GA_Base_C.__创建并播放特效_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(GA_Base_C.__创建并播放特效_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__创建并播放特效_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DA文件名 = ((DA文件名 != null) ? DA文件名.NativePtr : IntPtr.Zero);
			ptr->transform = transform;
			ptr->AttachToCharacter = AttachToCharacter;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__创建并播放特效_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602DB7D RID: 187261 RVA: 0x00AC9084 File Offset: 0x00AC7284
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual float 获取两者距离(AActor 目标A, AActor 目标B)
		{
			GA_Base_C.__获取两者距离_FunctionParams* ptr = stackalloc GA_Base_C.__获取两者距离_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(GA_Base_C.__获取两者距离_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取两者距离_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标A = ((目标A != null) ? 目标A.NativePtr : IntPtr.Zero);
			ptr->目标B = ((目标B != null) ? 目标B.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取两者距离_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602DB7E RID: 187262 RVA: 0x00AC90F8 File Offset: 0x00AC72F8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 发送事件(AActor 发送目标, FGameplayTag 事件Tag)
		{
			GA_Base_C.__发送事件_FunctionParams* ptr = stackalloc GA_Base_C.__发送事件_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Base_C.__发送事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__发送事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->发送目标 = ((发送目标 != null) ? 发送目标.NativePtr : IntPtr.Zero);
			ptr->事件Tag = 事件Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__发送事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB7F RID: 187263 RVA: 0x00AC9154 File Offset: 0x00AC7354
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 结束异步任务(UGameplayTask 任务, ref bool 有效)
		{
			GA_Base_C.__结束异步任务_FunctionParams* ptr = stackalloc GA_Base_C.__结束异步任务_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Base_C.__结束异步任务_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__结束异步任务_NativeFunctionPtr, (void*)ptr, 1);
			ptr->任务 = ((任务 != null) ? 任务.NativePtr : IntPtr.Zero);
			ptr->有效 = 有效;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__结束异步任务_NativeFunctionPtr, (void*)ptr);
			有效 = ptr->有效;
		}

		// Token: 0x0602DB80 RID: 187264 RVA: 0x00AC91BC File Offset: 0x00AC73BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置当前技能打断等级(int 打断等级)
		{
			GA_Base_C.__设置当前技能打断等级_FunctionParams* ptr = stackalloc GA_Base_C.__设置当前技能打断等级_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Base_C.__设置当前技能打断等级_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置当前技能打断等级_NativeFunctionPtr, (void*)ptr, 1);
			ptr->打断等级 = 打断等级;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置当前技能打断等级_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB81 RID: 187265 RVA: 0x00AC9204 File Offset: 0x00AC7404
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取地面坐标点(FVectorDouble 指定点, float 深度, ref FVectorDouble 地面坐标, ref bool 是否存在)
		{
			GA_Base_C.__获取地面坐标点_FunctionParams* ptr = stackalloc GA_Base_C.__获取地面坐标点_FunctionParams[(UIntPtr)463] + 15L / (long)sizeof(GA_Base_C.__获取地面坐标点_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取地面坐标点_NativeFunctionPtr, (void*)ptr, 1);
			ptr->指定点 = 指定点;
			ptr->深度 = 深度;
			ptr->地面坐标 = 地面坐标;
			ptr->是否存在 = 是否存在;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取地面坐标点_NativeFunctionPtr, (void*)ptr);
			地面坐标 = ptr->地面坐标;
			是否存在 = ptr->是否存在;
		}

		// Token: 0x0602DB82 RID: 187266 RVA: 0x00AC9280 File Offset: 0x00AC7480
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取目标Tag层数(TsBaseCharacter 目标, FGameplayTag Tag, ref int 层数)
		{
			GA_Base_C.__获取目标Tag层数_FunctionParams* ptr = stackalloc GA_Base_C.__获取目标Tag层数_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Base_C.__获取目标Tag层数_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取目标Tag层数_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标 = ((目标 != null) ? 目标.NativePtr : IntPtr.Zero);
			ptr->Tag = Tag;
			ptr->层数 = 层数;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取目标Tag层数_NativeFunctionPtr, (void*)ptr);
			层数 = ptr->层数;
		}

		// Token: 0x0602DB83 RID: 187267 RVA: 0x00AC92EC File Offset: 0x00AC74EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 销毁特定子弹(FName 子弹名字, bool 是否召唤子子弹)
		{
			GA_Base_C.__销毁特定子弹_FunctionParams* ptr = stackalloc GA_Base_C.__销毁特定子弹_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(GA_Base_C.__销毁特定子弹_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__销毁特定子弹_NativeFunctionPtr, (void*)ptr, 1);
			ptr->子弹名字 = 子弹名字;
			ptr->是否召唤子子弹 = 是否召唤子子弹;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__销毁特定子弹_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB84 RID: 187268 RVA: 0x00AC933C File Offset: 0x00AC753C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 面向目标(TsBaseCharacter 目标, AActor 面向目标)
		{
			GA_Base_C.__面向目标_FunctionParams* ptr = stackalloc GA_Base_C.__面向目标_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(GA_Base_C.__面向目标_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__面向目标_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标 = ((目标 != null) ? 目标.NativePtr : IntPtr.Zero);
			ptr->面向目标 = ((面向目标 != null) ? 面向目标.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__面向目标_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB85 RID: 187269 RVA: 0x00AC93AC File Offset: 0x00AC75AC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置技能目标(AActor SkillTarget)
		{
			GA_Base_C.__设置技能目标_FunctionParams* ptr = stackalloc GA_Base_C.__设置技能目标_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Base_C.__设置技能目标_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置技能目标_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SkillTarget = ((SkillTarget != null) ? SkillTarget.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置技能目标_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB86 RID: 187270 RVA: 0x00AC9404 File Offset: 0x00AC7604
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取黑板指定Key值关联对象(TsBaseCharacter 角色, [Nullable(1)] string key, ref TsBaseCharacter 对象, ref bool 是否找到对象)
		{
			GA_Base_C.__获取黑板指定Key值关联对象_FunctionParams* ptr = stackalloc GA_Base_C.__获取黑板指定Key值关联对象_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(GA_Base_C.__获取黑板指定Key值关联对象_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取黑板指定Key值关联对象_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->key), key);
			ref GA_Base_C.__获取黑板指定Key值关联对象_FunctionParams ptr2 = ref *ptr;
			TsBaseCharacter tsBaseCharacter = 对象;
			ptr2.对象 = ((tsBaseCharacter != null) ? tsBaseCharacter.NativePtr : IntPtr.Zero);
			ptr->是否找到对象 = 是否找到对象;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取黑板指定Key值关联对象_NativeFunctionPtr, (void*)ptr);
			对象 = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(ptr->对象);
			是否找到对象 = ptr->是否找到对象;
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__获取黑板指定Key值关联对象_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB87 RID: 187271 RVA: 0x00AC94B0 File Offset: 0x00AC76B0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 根据实体ID获取对象(int 实体ID, ref TsBaseCharacter 对象, ref bool 是否找到对象)
		{
			GA_Base_C.__根据实体ID获取对象_FunctionParams* ptr = stackalloc GA_Base_C.__根据实体ID获取对象_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Base_C.__根据实体ID获取对象_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__根据实体ID获取对象_NativeFunctionPtr, (void*)ptr, 1);
			ptr->实体ID = 实体ID;
			ref GA_Base_C.__根据实体ID获取对象_FunctionParams ptr2 = ref *ptr;
			TsBaseCharacter tsBaseCharacter = 对象;
			ptr2.对象 = ((tsBaseCharacter != null) ? tsBaseCharacter.NativePtr : IntPtr.Zero);
			ptr->是否找到对象 = 是否找到对象;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__根据实体ID获取对象_NativeFunctionPtr, (void*)ptr);
			对象 = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(ptr->对象);
			是否找到对象 = ptr->是否找到对象;
		}

		// Token: 0x0602DB88 RID: 187272 RVA: 0x00AC952C File Offset: 0x00AC772C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取实体ID(TsBaseCharacter 对象, ref int 实体ID)
		{
			GA_Base_C.__获取实体ID_FunctionParams* ptr = stackalloc GA_Base_C.__获取实体ID_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(GA_Base_C.__获取实体ID_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取实体ID_NativeFunctionPtr, (void*)ptr, 1);
			ptr->对象 = ((对象 != null) ? 对象.NativePtr : IntPtr.Zero);
			ptr->实体ID = 实体ID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取实体ID_NativeFunctionPtr, (void*)ptr);
			实体ID = ptr->实体ID;
		}

		// Token: 0x0602DB89 RID: 187273 RVA: 0x00AC9594 File Offset: 0x00AC7794
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置黑板Long([Nullable(2)] TsBaseCharacter 角色, string key, long 值)
		{
			GA_Base_C.__设置黑板Long_FunctionParams* ptr = stackalloc GA_Base_C.__设置黑板Long_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(GA_Base_C.__设置黑板Long_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置黑板Long_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->key), key);
			ptr->值 = 值;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置黑板Long_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__设置黑板Long_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB8A RID: 187274 RVA: 0x00AC9610 File Offset: 0x00AC7810
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取黑板Long([Nullable(2)] TsBaseCharacter 角色, string key, ref long 值)
		{
			GA_Base_C.__获取黑板Long_FunctionParams* ptr = stackalloc GA_Base_C.__获取黑板Long_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(GA_Base_C.__获取黑板Long_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取黑板Long_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->key), key);
			ptr->值 = 值;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取黑板Long_NativeFunctionPtr, (void*)ptr);
			值 = ptr->值;
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__获取黑板Long_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB8B RID: 187275 RVA: 0x00AC9694 File Offset: 0x00AC7894
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置黑板Int([Nullable(2)] TsBaseCharacter 角色, string key, int 值)
		{
			GA_Base_C.__设置黑板Int_FunctionParams* ptr = stackalloc GA_Base_C.__设置黑板Int_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(GA_Base_C.__设置黑板Int_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置黑板Int_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->key), key);
			ptr->值 = 值;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置黑板Int_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__设置黑板Int_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB8C RID: 187276 RVA: 0x00AC9710 File Offset: 0x00AC7910
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取黑板_Int([Nullable(2)] TsBaseCharacter 角色, string key, ref int 值)
		{
			GA_Base_C.__获取黑板_Int_FunctionParams* ptr = stackalloc GA_Base_C.__获取黑板_Int_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(GA_Base_C.__获取黑板_Int_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取黑板_Int_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角色 = ((角色 != null) ? 角色.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->key), key);
			ptr->值 = 值;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取黑板_Int_NativeFunctionPtr, (void*)ptr);
			值 = ptr->值;
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__获取黑板_Int_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB8D RID: 187277 RVA: 0x00AC9794 File Offset: 0x00AC7994
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 是否联网(ref bool 联网)
		{
			GA_Base_C.__是否联网_FunctionParams* ptr = stackalloc GA_Base_C.__是否联网_FunctionParams[(UIntPtr)18] + 15L / (long)sizeof(GA_Base_C.__是否联网_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__是否联网_NativeFunctionPtr, (void*)ptr, 1);
			ptr->联网 = 联网;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__是否联网_NativeFunctionPtr, (void*)ptr);
			联网 = ptr->联网;
		}

		// Token: 0x0602DB8E RID: 187278 RVA: 0x00AC97E4 File Offset: 0x00AC79E4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 召唤(int 配置表ID, FTransformDouble 出生位置, ref bool 是否成功, ref TsBaseCharacter 召唤物, ref int 实体ID)
		{
			GA_Base_C.__召唤_FunctionParams* ptr = stackalloc GA_Base_C.__召唤_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(GA_Base_C.__召唤_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__召唤_NativeFunctionPtr, (void*)ptr, 1);
			ptr->配置表ID = 配置表ID;
			ptr->出生位置 = 出生位置;
			ptr->是否成功 = 是否成功;
			ref GA_Base_C.__召唤_FunctionParams ptr2 = ref *ptr;
			TsBaseCharacter tsBaseCharacter = 召唤物;
			ptr2.召唤物 = ((tsBaseCharacter != null) ? tsBaseCharacter.NativePtr : IntPtr.Zero);
			ptr->实体ID = 实体ID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__召唤_NativeFunctionPtr, (void*)ptr);
			是否成功 = ptr->是否成功;
			召唤物 = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(ptr->召唤物);
			实体ID = ptr->实体ID;
		}

		// Token: 0x0602DB8F RID: 187279 RVA: 0x00AC9880 File Offset: 0x00AC7A80
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 使用技能(TsBaseCharacter 释放者, FName 技能ID, AActor 技能目标, FName Socket, ref bool 是否成功释放)
		{
			GA_Base_C.__使用技能_FunctionParams* ptr = stackalloc GA_Base_C.__使用技能_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Base_C.__使用技能_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__使用技能_NativeFunctionPtr, (void*)ptr, 1);
			ptr->释放者 = ((释放者 != null) ? 释放者.NativePtr : IntPtr.Zero);
			ptr->技能ID = 技能ID;
			ptr->技能目标 = ((技能目标 != null) ? 技能目标.NativePtr : IntPtr.Zero);
			ptr->Socket = Socket;
			ptr->是否成功释放 = 是否成功释放;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__使用技能_NativeFunctionPtr, (void*)ptr);
			是否成功释放 = ptr->是否成功释放;
		}

		// Token: 0x0602DB90 RID: 187280 RVA: 0x00AC990C File Offset: 0x00AC7B0C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 创建子弹([Nullable(2)] TsBaseCharacter 施法者, string 子弹ID, FTransformDouble 初始变换, FVectorDouble 目标点, ref int 子弹)
		{
			GA_Base_C.__创建子弹_FunctionParams* ptr = stackalloc GA_Base_C.__创建子弹_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(GA_Base_C.__创建子弹_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__创建子弹_NativeFunctionPtr, (void*)ptr, 1);
			ptr->施法者 = ((施法者 != null) ? 施法者.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->子弹ID), 子弹ID);
			ptr->初始变换 = 初始变换;
			ptr->目标点 = 目标点;
			ptr->子弹 = 子弹;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__创建子弹_NativeFunctionPtr, (void*)ptr);
			子弹 = ptr->子弹;
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__创建子弹_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB91 RID: 187281 RVA: 0x00AC99A4 File Offset: 0x00AC7BA4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置材质效果(TsBaseCharacter 设置对象, PD_CharacterControllerData_C 材质配置, ref int Handle)
		{
			GA_Base_C.__设置材质效果_FunctionParams* ptr = stackalloc GA_Base_C.__设置材质效果_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Base_C.__设置材质效果_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置材质效果_NativeFunctionPtr, (void*)ptr, 1);
			ptr->设置对象 = ((设置对象 != null) ? 设置对象.NativePtr : IntPtr.Zero);
			ptr->材质配置 = ((材质配置 != null) ? 材质配置.NativePtr : IntPtr.Zero);
			ptr->Handle = Handle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置材质效果_NativeFunctionPtr, (void*)ptr);
			Handle = ptr->Handle;
		}

		// Token: 0x0602DB92 RID: 187282 RVA: 0x00AC9A20 File Offset: 0x00AC7C20
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 通过_ID移除目标Buff(long BuffId, int 移除层数, TsBaseCharacter 目标)
		{
			GA_Base_C.__通过_ID移除目标Buff_FunctionParams* ptr = stackalloc GA_Base_C.__通过_ID移除目标Buff_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(GA_Base_C.__通过_ID移除目标Buff_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__通过_ID移除目标Buff_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BuffId = BuffId;
			ptr->移除层数 = 移除层数;
			ptr->目标 = ((目标 != null) ? 目标.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__通过_ID移除目标Buff_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB93 RID: 187283 RVA: 0x00AC9A84 File Offset: 0x00AC7C84
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取Current属性值(TsBaseCharacter 目标, int 属性id, ref float 属性值)
		{
			GA_Base_C.__获取Current属性值_FunctionParams* ptr = stackalloc GA_Base_C.__获取Current属性值_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Base_C.__获取Current属性值_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取Current属性值_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标 = ((目标 != null) ? 目标.NativePtr : IntPtr.Zero);
			ptr->属性id = 属性id;
			ptr->属性值 = 属性值;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取Current属性值_NativeFunctionPtr, (void*)ptr);
			属性值 = ptr->属性值;
		}

		// Token: 0x0602DB94 RID: 187284 RVA: 0x00AC9AF0 File Offset: 0x00AC7CF0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取Base属性值(TsBaseCharacter 目标, int 属性id, ref float 属性值)
		{
			GA_Base_C.__获取Base属性值_FunctionParams* ptr = stackalloc GA_Base_C.__获取Base属性值_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Base_C.__获取Base属性值_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取Base属性值_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标 = ((目标 != null) ? 目标.NativePtr : IntPtr.Zero);
			ptr->属性id = 属性id;
			ptr->属性值 = 属性值;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取Base属性值_NativeFunctionPtr, (void*)ptr);
			属性值 = ptr->属性值;
		}

		// Token: 0x0602DB95 RID: 187285 RVA: 0x00AC9B5C File Offset: 0x00AC7D5C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 通过_ID给对象添加Buff(TsBaseCharacter Buff对象, long BuffId, int Buff层数)
		{
			GA_Base_C.__通过_ID给对象添加Buff_FunctionParams* ptr = stackalloc GA_Base_C.__通过_ID给对象添加Buff_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Base_C.__通过_ID给对象添加Buff_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__通过_ID给对象添加Buff_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Buff对象 = ((Buff对象 != null) ? Buff对象.NativePtr : IntPtr.Zero);
			ptr->BuffId = BuffId;
			ptr->Buff层数 = Buff层数;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__通过_ID给对象添加Buff_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB96 RID: 187286 RVA: 0x00AC9BC0 File Offset: 0x00AC7DC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 通过Tag移除自身Buff(FGameplayTag tag)
		{
			GA_Base_C.__通过Tag移除自身Buff_FunctionParams* ptr = stackalloc GA_Base_C.__通过Tag移除自身Buff_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Base_C.__通过Tag移除自身Buff_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__通过Tag移除自身Buff_NativeFunctionPtr, (void*)ptr, 1);
			ptr->tag = tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__通过Tag移除自身Buff_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB97 RID: 187287 RVA: 0x00AC9C08 File Offset: 0x00AC7E08
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置通道的碰撞响应(UPrimitiveComponent 目标, ECollisionChannel Channel, ECollisionResponse NewResponse)
		{
			GA_Base_C.__设置通道的碰撞响应_FunctionParams* ptr = stackalloc GA_Base_C.__设置通道的碰撞响应_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Base_C.__设置通道的碰撞响应_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置通道的碰撞响应_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标 = ((目标 != null) ? 目标.NativePtr : IntPtr.Zero);
			ptr->Channel = Channel;
			ptr->NewResponse = NewResponse;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置通道的碰撞响应_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB98 RID: 187288 RVA: 0x00AC9C78 File Offset: 0x00AC7E78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置强制速度(FVectorDouble 速度)
		{
			GA_Base_C.__设置强制速度_FunctionParams* ptr = stackalloc GA_Base_C.__设置强制速度_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Base_C.__设置强制速度_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__设置强制速度_NativeFunctionPtr, (void*)ptr, 1);
			ptr->速度 = 速度;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__设置强制速度_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DB99 RID: 187289 RVA: 0x00AC9CC0 File Offset: 0x00AC7EC0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 是否拥有任意标签(TsBaseCharacter 目标, FGameplayTagContainer 标签, ref bool 是否存在)
		{
			GA_Base_C.__是否拥有任意标签_FunctionParams* ptr = stackalloc GA_Base_C.__是否拥有任意标签_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(GA_Base_C.__是否拥有任意标签_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__是否拥有任意标签_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标 = ((目标 != null) ? 目标.NativePtr : IntPtr.Zero);
			if (标签 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->标签, 标签.NativePtr, 1, false);
			}
			ptr->是否存在 = 是否存在;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__是否拥有任意标签_NativeFunctionPtr, (void*)ptr);
			是否存在 = ptr->是否存在;
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__是否拥有任意标签_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DB9A RID: 187290 RVA: 0x00AC9D58 File Offset: 0x00AC7F58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取技能目标距离(bool 平面2D, ref float 距离)
		{
			GA_Base_C.__获取技能目标距离_FunctionParams* ptr = stackalloc GA_Base_C.__获取技能目标距离_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(GA_Base_C.__获取技能目标距离_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取技能目标距离_NativeFunctionPtr, (void*)ptr, 1);
			ptr->平面2D = 平面2D;
			ptr->距离 = 距离;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取技能目标距离_NativeFunctionPtr, (void*)ptr);
			距离 = ptr->距离;
		}

		// Token: 0x0602DB9B RID: 187291 RVA: 0x00AC9DB0 File Offset: 0x00AC7FB0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取技能目标(TsBaseCharacter 目标, ref AActor 技能目标)
		{
			GA_Base_C.__获取技能目标_FunctionParams* ptr = stackalloc GA_Base_C.__获取技能目标_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Base_C.__获取技能目标_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取技能目标_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标 = ((目标 != null) ? 目标.NativePtr : IntPtr.Zero);
			ref GA_Base_C.__获取技能目标_FunctionParams ptr2 = ref *ptr;
			AActor aactor = 技能目标;
			ptr2.技能目标 = ((aactor != null) ? aactor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取技能目标_NativeFunctionPtr, (void*)ptr);
			技能目标 = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr->技能目标);
		}

		// Token: 0x0602DB9C RID: 187292 RVA: 0x00AC9E2C File Offset: 0x00AC802C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取AbilitySystemComponent(ref UBaseAbilitySystemComponent AbilitySystemComponent)
		{
			GA_Base_C.__获取AbilitySystemComponent_FunctionParams* ptr = stackalloc GA_Base_C.__获取AbilitySystemComponent_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Base_C.__获取AbilitySystemComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取AbilitySystemComponent_NativeFunctionPtr, (void*)ptr, 1);
			ref GA_Base_C.__获取AbilitySystemComponent_FunctionParams ptr2 = ref *ptr;
			UBaseAbilitySystemComponent ubaseAbilitySystemComponent = AbilitySystemComponent;
			ptr2.AbilitySystemComponent = ((ubaseAbilitySystemComponent != null) ? ubaseAbilitySystemComponent.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取AbilitySystemComponent_NativeFunctionPtr, (void*)ptr);
			AbilitySystemComponent = BuiltinUtils.GetOrCreateUObjectByNativePointer<UBaseAbilitySystemComponent>(ptr->AbilitySystemComponent);
		}

		// Token: 0x0602DB9D RID: 187293 RVA: 0x00AC9E90 File Offset: 0x00AC8090
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_CanActivateAbility(FGameplayAbilityActorInfo ActorInfo, ref FGameplayTagContainer RelevantTags)
		{
			GA_Base_C.__K2_CanActivateAbility_FunctionParams* ptr = stackalloc GA_Base_C.__K2_CanActivateAbility_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(GA_Base_C.__K2_CanActivateAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			if (ActorInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAbilityActorInfo.StaticStruct(), &ptr->ActorInfo, ActorInfo.NativePtr, 1, false);
			}
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->RelevantTags, RelevantTags.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr);
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), RelevantTags.NativePtr, &ptr->RelevantTags, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DB9E RID: 187294 RVA: 0x00AC9F54 File Offset: 0x00AC8154
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool K2_CanActivateAbility_Implementation(FGameplayAbilityActorInfo ActorInfo, ref FGameplayTagContainer RelevantTags)
		{
			GA_Base_C.__K2_CanActivateAbility_FunctionParams* ptr = stackalloc GA_Base_C.__K2_CanActivateAbility_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(GA_Base_C.__K2_CanActivateAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			if (ActorInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAbilityActorInfo.StaticStruct(), &ptr->ActorInfo, ActorInfo.NativePtr, 1, false);
			}
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->RelevantTags, RelevantTags.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Base_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 0);
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), RelevantTags.NativePtr, &ptr->RelevantTags, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DB9F RID: 187295 RVA: 0x00ACA018 File Offset: 0x00AC8218
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取技能标签(ref TArray<FGameplayTag> 技能标签)
		{
			GA_Base_C.__获取技能标签_FunctionParams* ptr = stackalloc GA_Base_C.__获取技能标签_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(GA_Base_C.__获取技能标签_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取技能标签_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FGameplayTag> tarray = 技能标签;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->技能标签);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取技能标签_NativeFunctionPtr, (void*)ptr);
			TArray<FGameplayTag> tarray2 = 技能标签;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->技能标签);
			}
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__获取技能标签_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DBA0 RID: 187296 RVA: 0x00ACA094 File Offset: 0x00AC8294
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取技能所有动画([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UAnimMontage> 技能动画数组)
		{
			GA_Base_C.__获取技能所有动画_FunctionParams* ptr = stackalloc GA_Base_C.__获取技能所有动画_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(GA_Base_C.__获取技能所有动画_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取技能所有动画_NativeFunctionPtr, (void*)ptr, 1);
			TArray<UAnimMontage> tarray = 技能动画数组;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->技能动画数组);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取技能所有动画_NativeFunctionPtr, (void*)ptr);
			TArray<UAnimMontage> tarray2 = 技能动画数组;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->技能动画数组);
			}
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__获取技能所有动画_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DBA1 RID: 187297 RVA: 0x00ACA10C File Offset: 0x00AC830C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取技能动画(int 编号, ref UAnimMontage 动画)
		{
			GA_Base_C.__获取技能动画_FunctionParams* ptr = stackalloc GA_Base_C.__获取技能动画_FunctionParams[(UIntPtr)983] + 15L / (long)sizeof(GA_Base_C.__获取技能动画_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取技能动画_NativeFunctionPtr, (void*)ptr, 1);
			ptr->编号 = 编号;
			ref GA_Base_C.__获取技能动画_FunctionParams ptr2 = ref *ptr;
			UAnimMontage uanimMontage = 动画;
			ptr2.动画 = ((uanimMontage != null) ? uanimMontage.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取技能动画_NativeFunctionPtr, (void*)ptr);
			动画 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimMontage>(ptr->动画);
		}

		// Token: 0x0602DBA2 RID: 187298 RVA: 0x00ACA17C File Offset: 0x00AC837C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取当前技能配置(ref SSkillInfo 当前技能数据)
		{
			GA_Base_C.__获取当前技能配置_FunctionParams* ptr = stackalloc GA_Base_C.__获取当前技能配置_FunctionParams[(UIntPtr)479] + 15L / (long)sizeof(GA_Base_C.__获取当前技能配置_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取当前技能配置_NativeFunctionPtr, (void*)ptr, 1);
			if (当前技能数据 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SSkillInfo.StaticStruct(), &ptr->当前技能数据, 当前技能数据.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取当前技能配置_NativeFunctionPtr, (void*)ptr);
			if (当前技能数据 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SSkillInfo.StaticStruct(), 当前技能数据.NativePtr, &ptr->当前技能数据, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__获取当前技能配置_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DBA3 RID: 187299 RVA: 0x00ACA218 File Offset: 0x00AC8418
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取当前技能配置Id(ref string 当前技能数据名)
		{
			GA_Base_C.__获取当前技能配置Id_FunctionParams* ptr = stackalloc GA_Base_C.__获取当前技能配置Id_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Base_C.__获取当前技能配置Id_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取当前技能配置Id_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->当前技能数据名), 当前技能数据名);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取当前技能配置Id_NativeFunctionPtr, (void*)ptr);
			当前技能数据名 = FString.ToString((void*)(&ptr->当前技能数据名));
			UnrealReflectionUtils.DestroyStruct(GA_Base_C.__获取当前技能配置Id_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DBA4 RID: 187300 RVA: 0x00ACA284 File Offset: 0x00AC8484
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取施法单位EntityId(ref int EntityId)
		{
			GA_Base_C.__获取施法单位EntityId_FunctionParams* ptr = stackalloc GA_Base_C.__获取施法单位EntityId_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(GA_Base_C.__获取施法单位EntityId_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取施法单位EntityId_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntityId = EntityId;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取施法单位EntityId_NativeFunctionPtr, (void*)ptr);
			EntityId = ptr->EntityId;
		}

		// Token: 0x0602DBA5 RID: 187301 RVA: 0x00ACA2D4 File Offset: 0x00AC84D4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取施法载具(ref TsBaseVehicle 施法载具)
		{
			GA_Base_C.__获取施法载具_FunctionParams* ptr = stackalloc GA_Base_C.__获取施法载具_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Base_C.__获取施法载具_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取施法载具_NativeFunctionPtr, (void*)ptr, 1);
			ref GA_Base_C.__获取施法载具_FunctionParams ptr2 = ref *ptr;
			TsBaseVehicle tsBaseVehicle = 施法载具;
			ptr2.施法载具 = ((tsBaseVehicle != null) ? tsBaseVehicle.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取施法载具_NativeFunctionPtr, (void*)ptr);
			施法载具 = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseVehicle>(ptr->施法载具);
		}

		// Token: 0x0602DBA6 RID: 187302 RVA: 0x00ACA338 File Offset: 0x00AC8538
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取施法者(ref TsBaseCharacter 施法者)
		{
			GA_Base_C.__获取施法者_FunctionParams* ptr = stackalloc GA_Base_C.__获取施法者_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Base_C.__获取施法者_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__获取施法者_NativeFunctionPtr, (void*)ptr, 1);
			ref GA_Base_C.__获取施法者_FunctionParams ptr2 = ref *ptr;
			TsBaseCharacter tsBaseCharacter = 施法者;
			ptr2.施法者 = ((tsBaseCharacter != null) ? tsBaseCharacter.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__获取施法者_NativeFunctionPtr, (void*)ptr);
			施法者 = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(ptr->施法者);
		}

		// Token: 0x0602DBA7 RID: 187303 RVA: 0x00ACA39C File Offset: 0x00AC859C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602DBA8 RID: 187304 RVA: 0x00ACA3B0 File Offset: 0x00AC85B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Base_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DBA9 RID: 187305 RVA: 0x00ACA3C8 File Offset: 0x00AC85C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Base_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Base_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Base_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Base_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DBAA RID: 187306 RVA: 0x00ACA410 File Offset: 0x00AC8610
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Base_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Base_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Base_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Base_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DBAB RID: 187307 RVA: 0x00ACA458 File Offset: 0x00AC8658
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Base(int EntryPoint)
		{
			GA_Base_C.__ExecuteUbergraph_GA_Base_FunctionParams* ptr = stackalloc GA_Base_C.__ExecuteUbergraph_GA_Base_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Base_C.__ExecuteUbergraph_GA_Base_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Base_C.__ExecuteUbergraph_GA_Base_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Base_C.__ExecuteUbergraph_GA_Base_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DBAC RID: 187308 RVA: 0x00ACA49F File Offset: 0x00AC869F
		protected GA_Base_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C7A RID: 105594
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GA/GA_Base.GA_Base_C";

		// Token: 0x04019C7B RID: 105595
		private static IntPtr _ClassPtr;

		// Token: 0x04019C7C RID: 105596
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019C7D RID: 105597
		internal static int __PropertyOffset_0;

		// Token: 0x04019C7E RID: 105598
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019C7F RID: 105599
		internal static int __PropertyOffset_1;

		// Token: 0x04019C80 RID: 105600
		[Nullable(2)]
		private SSkillInfo _当前技能数据;

		// Token: 0x04019C81 RID: 105601
		internal static int __PropertyOffset_2;

		// Token: 0x04019C82 RID: 105602
		internal static int __PropertyOffset_3;

		// Token: 0x04019C83 RID: 105603
		private static IntPtr __异步使用技能_NativeFunctionPtr;

		// Token: 0x04019C84 RID: 105604
		private static IntPtr __获取随机召唤物_NativeFunctionPtr;

		// Token: 0x04019C85 RID: 105605
		private static IntPtr __随机召唤_NativeFunctionPtr;

		// Token: 0x04019C86 RID: 105606
		private static IntPtr __Apply_Buff_with_Level_NativeFunctionPtr;

		// Token: 0x04019C87 RID: 105607
		private static IntPtr __AddTag_NativeFunctionPtr;

		// Token: 0x04019C88 RID: 105608
		private static IntPtr __RemoveTag_NativeFunctionPtr;

		// Token: 0x04019C89 RID: 105609
		private static IntPtr __RemoveBuff_NativeFunctionPtr;

		// Token: 0x04019C8A RID: 105610
		private static IntPtr __伴生物获取召唤者对象_NativeFunctionPtr;

		// Token: 0x04019C8B RID: 105611
		private static IntPtr __设置角色地面移动_NativeFunctionPtr;

		// Token: 0x04019C8C RID: 105612
		private static IntPtr __设置角色传送_NativeFunctionPtr;

		// Token: 0x04019C8D RID: 105613
		private static IntPtr __叠加角色世界位置_NativeFunctionPtr;

		// Token: 0x04019C8E RID: 105614
		private static IntPtr __叠加角色世界旋转_NativeFunctionPtr;

		// Token: 0x04019C8F RID: 105615
		private static IntPtr __设置角色位置和旋转_NativeFunctionPtr;

		// Token: 0x04019C90 RID: 105616
		private static IntPtr __设置角色变换_NativeFunctionPtr;

		// Token: 0x04019C91 RID: 105617
		private static IntPtr __设置角色旋转_NativeFunctionPtr;

		// Token: 0x04019C92 RID: 105618
		private static IntPtr __设置角色位置_NativeFunctionPtr;

		// Token: 0x04019C93 RID: 105619
		private static IntPtr __设置角色Pawn通道碰撞响应_NativeFunctionPtr;

		// Token: 0x04019C94 RID: 105620
		private static IntPtr __给对象移除标签_NativeFunctionPtr;

		// Token: 0x04019C95 RID: 105621
		private static IntPtr __给对象添加标签_NativeFunctionPtr;

		// Token: 0x04019C96 RID: 105622
		private static IntPtr __设置子弹目标_NativeFunctionPtr;

		// Token: 0x04019C97 RID: 105623
		private static IntPtr __生成特效_NativeFunctionPtr;

		// Token: 0x04019C98 RID: 105624
		private static IntPtr __修改材质效果_NativeFunctionPtr;

		// Token: 0x04019C99 RID: 105625
		private static IntPtr __设置黑板Rotator_NativeFunctionPtr;

		// Token: 0x04019C9A RID: 105626
		private static IntPtr __退出瞄准模式_NativeFunctionPtr;

		// Token: 0x04019C9B RID: 105627
		private static IntPtr __进入瞄准模式_NativeFunctionPtr;

		// Token: 0x04019C9C RID: 105628
		private static IntPtr __对圆柱体类型的合法点检测_NativeFunctionPtr;

		// Token: 0x04019C9D RID: 105629
		private static IntPtr __获取目标正后方的合法点_NativeFunctionPtr;

		// Token: 0x04019C9E RID: 105630
		private static IntPtr __获取目标到终点的合法点_NativeFunctionPtr;

		// Token: 0x04019C9F RID: 105631
		private static IntPtr __通过角度获取目标附近的合法点_NativeFunctionPtr;

		// Token: 0x04019CA0 RID: 105632
		private static IntPtr __设置接收同打断等级打断_NativeFunctionPtr;

		// Token: 0x04019CA1 RID: 105633
		private static IntPtr __修改当前技能打断等级_NativeFunctionPtr;

		// Token: 0x04019CA2 RID: 105634
		private static IntPtr __移除召唤物_NativeFunctionPtr;

		// Token: 0x04019CA3 RID: 105635
		private static IntPtr __根据子弹实体ID销毁子弹_NativeFunctionPtr;

		// Token: 0x04019CA4 RID: 105636
		private static IntPtr __获取角色ID_NativeFunctionPtr;

		// Token: 0x04019CA5 RID: 105637
		private static IntPtr __获取游戏事件管理器_NativeFunctionPtr;

		// Token: 0x04019CA6 RID: 105638
		private static IntPtr __获取黑板String_NativeFunctionPtr;

		// Token: 0x04019CA7 RID: 105639
		private static IntPtr __设置黑板String_NativeFunctionPtr;

		// Token: 0x04019CA8 RID: 105640
		private static IntPtr __子弹冻结_NativeFunctionPtr;

		// Token: 0x04019CA9 RID: 105641
		private static IntPtr __获取当前GA的技能数据名_NativeFunctionPtr;

		// Token: 0x04019CAA RID: 105642
		private static IntPtr __获取当前操作角色Actor_NativeFunctionPtr;

		// Token: 0x04019CAB RID: 105643
		private static IntPtr __设置黑板Vector_NativeFunctionPtr;

		// Token: 0x04019CAC RID: 105644
		private static IntPtr __获取黑板Vector_NativeFunctionPtr;

		// Token: 0x04019CAD RID: 105645
		private static IntPtr __设置黑板EntityId_NativeFunctionPtr;

		// Token: 0x04019CAE RID: 105646
		private static IntPtr __获取黑板EntityId_NativeFunctionPtr;

		// Token: 0x04019CAF RID: 105647
		private static IntPtr __查询特定子弹数量_NativeFunctionPtr;

		// Token: 0x04019CB0 RID: 105648
		private static IntPtr __获取当前技能攻速_NativeFunctionPtr;

		// Token: 0x04019CB1 RID: 105649
		private static IntPtr __通过ID获取对象Buff层数_NativeFunctionPtr;

		// Token: 0x04019CB2 RID: 105650
		private static IntPtr __施法者移除标签_NativeFunctionPtr;

		// Token: 0x04019CB3 RID: 105651
		private static IntPtr __施法者添加标签_NativeFunctionPtr;

		// Token: 0x04019CB4 RID: 105652
		private static IntPtr __创建并播放特效_NativeFunctionPtr;

		// Token: 0x04019CB5 RID: 105653
		private static IntPtr __获取两者距离_NativeFunctionPtr;

		// Token: 0x04019CB6 RID: 105654
		private static IntPtr __发送事件_NativeFunctionPtr;

		// Token: 0x04019CB7 RID: 105655
		private static IntPtr __结束异步任务_NativeFunctionPtr;

		// Token: 0x04019CB8 RID: 105656
		private static IntPtr __设置当前技能打断等级_NativeFunctionPtr;

		// Token: 0x04019CB9 RID: 105657
		private static IntPtr __获取地面坐标点_NativeFunctionPtr;

		// Token: 0x04019CBA RID: 105658
		private static IntPtr __获取目标Tag层数_NativeFunctionPtr;

		// Token: 0x04019CBB RID: 105659
		private static IntPtr __销毁特定子弹_NativeFunctionPtr;

		// Token: 0x04019CBC RID: 105660
		private static IntPtr __面向目标_NativeFunctionPtr;

		// Token: 0x04019CBD RID: 105661
		private static IntPtr __设置技能目标_NativeFunctionPtr;

		// Token: 0x04019CBE RID: 105662
		private static IntPtr __获取黑板指定Key值关联对象_NativeFunctionPtr;

		// Token: 0x04019CBF RID: 105663
		private static IntPtr __根据实体ID获取对象_NativeFunctionPtr;

		// Token: 0x04019CC0 RID: 105664
		private static IntPtr __获取实体ID_NativeFunctionPtr;

		// Token: 0x04019CC1 RID: 105665
		private static IntPtr __设置黑板Long_NativeFunctionPtr;

		// Token: 0x04019CC2 RID: 105666
		private static IntPtr __获取黑板Long_NativeFunctionPtr;

		// Token: 0x04019CC3 RID: 105667
		private static IntPtr __设置黑板Int_NativeFunctionPtr;

		// Token: 0x04019CC4 RID: 105668
		private static IntPtr __获取黑板_Int_NativeFunctionPtr;

		// Token: 0x04019CC5 RID: 105669
		private static IntPtr __是否联网_NativeFunctionPtr;

		// Token: 0x04019CC6 RID: 105670
		private static IntPtr __召唤_NativeFunctionPtr;

		// Token: 0x04019CC7 RID: 105671
		private static IntPtr __使用技能_NativeFunctionPtr;

		// Token: 0x04019CC8 RID: 105672
		private static IntPtr __创建子弹_NativeFunctionPtr;

		// Token: 0x04019CC9 RID: 105673
		private static IntPtr __设置材质效果_NativeFunctionPtr;

		// Token: 0x04019CCA RID: 105674
		private static IntPtr __通过_ID移除目标Buff_NativeFunctionPtr;

		// Token: 0x04019CCB RID: 105675
		private static IntPtr __获取Current属性值_NativeFunctionPtr;

		// Token: 0x04019CCC RID: 105676
		private static IntPtr __获取Base属性值_NativeFunctionPtr;

		// Token: 0x04019CCD RID: 105677
		private static IntPtr __通过_ID给对象添加Buff_NativeFunctionPtr;

		// Token: 0x04019CCE RID: 105678
		private static IntPtr __通过Tag移除自身Buff_NativeFunctionPtr;

		// Token: 0x04019CCF RID: 105679
		private static IntPtr __设置通道的碰撞响应_NativeFunctionPtr;

		// Token: 0x04019CD0 RID: 105680
		private static IntPtr __设置强制速度_NativeFunctionPtr;

		// Token: 0x04019CD1 RID: 105681
		private static IntPtr __是否拥有任意标签_NativeFunctionPtr;

		// Token: 0x04019CD2 RID: 105682
		private static IntPtr __获取技能目标距离_NativeFunctionPtr;

		// Token: 0x04019CD3 RID: 105683
		private static IntPtr __获取技能目标_NativeFunctionPtr;

		// Token: 0x04019CD4 RID: 105684
		private static IntPtr __获取AbilitySystemComponent_NativeFunctionPtr;

		// Token: 0x04019CD5 RID: 105685
		private static IntPtr __K2_CanActivateAbility_NativeFunctionPtr;

		// Token: 0x04019CD6 RID: 105686
		private static IntPtr __获取技能标签_NativeFunctionPtr;

		// Token: 0x04019CD7 RID: 105687
		private static IntPtr __获取技能所有动画_NativeFunctionPtr;

		// Token: 0x04019CD8 RID: 105688
		private static IntPtr __获取技能动画_NativeFunctionPtr;

		// Token: 0x04019CD9 RID: 105689
		private static IntPtr __获取当前技能配置_NativeFunctionPtr;

		// Token: 0x04019CDA RID: 105690
		private static IntPtr __获取当前技能配置Id_NativeFunctionPtr;

		// Token: 0x04019CDB RID: 105691
		private static IntPtr __获取施法单位EntityId_NativeFunctionPtr;

		// Token: 0x04019CDC RID: 105692
		private static IntPtr __获取施法载具_NativeFunctionPtr;

		// Token: 0x04019CDD RID: 105693
		private static IntPtr __获取施法者_NativeFunctionPtr;

		// Token: 0x04019CDE RID: 105694
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04019CDF RID: 105695
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04019CE0 RID: 105696
		private static IntPtr __ExecuteUbergraph_GA_Base_NativeFunctionPtr;

		// Token: 0x0200A535 RID: 42293
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __异步使用技能_FunctionParams
		{
			// Token: 0x040333F5 RID: 209909
			[FieldOffset(0)]
			public IntPtr 释放者;

			// Token: 0x040333F6 RID: 209910
			[FieldOffset(8)]
			public FName 技能ID;

			// Token: 0x040333F7 RID: 209911
			[FieldOffset(24)]
			public IntPtr 技能目标;

			// Token: 0x040333F8 RID: 209912
			[FieldOffset(32)]
			public FName Socket;
		}

		// Token: 0x0200A536 RID: 42294
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __获取随机召唤物_FunctionParams
		{
			// Token: 0x040333F9 RID: 209913
			[FieldOffset(0)]
			public int 召唤者;

			// Token: 0x040333FA RID: 209914
			[FieldOffset(4)]
			public int Index;

			// Token: 0x040333FB RID: 209915
			[FieldOffset(8)]
			public int 实体Id;
		}

		// Token: 0x0200A537 RID: 42295
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __随机召唤_FunctionParams
		{
			// Token: 0x040333FC RID: 209916
			[FieldOffset(0)]
			public int 召唤者Id;

			// Token: 0x040333FD RID: 209917
			[FieldOffset(4)]
			public int Index;

			// Token: 0x040333FE RID: 209918
			[FieldOffset(16)]
			public FTransformDouble Transform;

			// Token: 0x040333FF RID: 209919
			[FieldOffset(80)]
			public int SkillId;

			// Token: 0x04033400 RID: 209920
			[FieldOffset(84)]
			public bool IsVisivle;
		}

		// Token: 0x0200A538 RID: 42296
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __Apply_Buff_with_Level_FunctionParams
		{
			// Token: 0x04033401 RID: 209921
			[FieldOffset(0)]
			public long buffId;
		}

		// Token: 0x0200A539 RID: 42297
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AddTag_FunctionParams
		{
			// Token: 0x04033402 RID: 209922
			[FieldOffset(0)]
			public FGameplayTag tag;
		}

		// Token: 0x0200A53A RID: 42298
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __RemoveTag_FunctionParams
		{
			// Token: 0x04033403 RID: 209923
			[FieldOffset(0)]
			public FGameplayTag tag;
		}

		// Token: 0x0200A53B RID: 42299
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __RemoveBuff_FunctionParams
		{
			// Token: 0x04033404 RID: 209924
			[FieldOffset(0)]
			public long buffId;
		}

		// Token: 0x0200A53C RID: 42300
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __伴生物获取召唤者对象_FunctionParams
		{
			// Token: 0x04033405 RID: 209925
			[FieldOffset(0)]
			public IntPtr 对象;

			// Token: 0x04033406 RID: 209926
			[FieldOffset(8)]
			public bool 是否找到对象;
		}

		// Token: 0x0200A53D RID: 42301
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __设置角色地面移动_FunctionParams
		{
			// Token: 0x04033407 RID: 209927
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04033408 RID: 209928
			[FieldOffset(8)]
			public FVector Velocity;

			// Token: 0x04033409 RID: 209929
			[FieldOffset(20)]
			public float DeltaSeconds;

			// Token: 0x0403340A RID: 209930
			[FieldOffset(24)]
			public FString context;
		}

		// Token: 0x0200A53E RID: 42302
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __设置角色传送_FunctionParams
		{
			// Token: 0x0403340B RID: 209931
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x0403340C RID: 209932
			[FieldOffset(8)]
			public FVectorDouble location;

			// Token: 0x0403340D RID: 209933
			[FieldOffset(32)]
			public FRotator Rotator;

			// Token: 0x0403340E RID: 209934
			[FieldOffset(48)]
			public FString context;
		}

		// Token: 0x0200A53F RID: 42303
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __叠加角色世界位置_FunctionParams
		{
			// Token: 0x0403340F RID: 209935
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04033410 RID: 209936
			[FieldOffset(8)]
			public FVectorDouble location;

			// Token: 0x04033411 RID: 209937
			[FieldOffset(32)]
			public bool sweep;

			// Token: 0x04033412 RID: 209938
			[FieldOffset(33)]
			public bool teleport;

			// Token: 0x04033413 RID: 209939
			[FieldOffset(40)]
			public FString context;
		}

		// Token: 0x0200A540 RID: 42304
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __叠加角色世界旋转_FunctionParams
		{
			// Token: 0x04033414 RID: 209940
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04033415 RID: 209941
			[FieldOffset(8)]
			public FRotator rotation;

			// Token: 0x04033416 RID: 209942
			[FieldOffset(20)]
			public bool sweep;

			// Token: 0x04033417 RID: 209943
			[FieldOffset(21)]
			public bool teleport;

			// Token: 0x04033418 RID: 209944
			[FieldOffset(24)]
			public FString context;
		}

		// Token: 0x0200A541 RID: 42305
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __设置角色位置和旋转_FunctionParams
		{
			// Token: 0x04033419 RID: 209945
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x0403341A RID: 209946
			[FieldOffset(8)]
			public FVectorDouble location;

			// Token: 0x0403341B RID: 209947
			[FieldOffset(32)]
			public FRotator rotation;

			// Token: 0x0403341C RID: 209948
			[FieldOffset(44)]
			public bool sweep;

			// Token: 0x0403341D RID: 209949
			[FieldOffset(48)]
			public FString context;
		}

		// Token: 0x0200A542 RID: 42306
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 544)]
		protected ref struct __设置角色变换_FunctionParams
		{
			// Token: 0x0403341E RID: 209950
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x0403341F RID: 209951
			[FieldOffset(16)]
			public FTransformDouble Transform;

			// Token: 0x04033420 RID: 209952
			[FieldOffset(80)]
			public bool sweep;

			// Token: 0x04033421 RID: 209953
			[FieldOffset(88)]
			public FString context;
		}

		// Token: 0x0200A543 RID: 42307
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __设置角色旋转_FunctionParams
		{
			// Token: 0x04033422 RID: 209954
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04033423 RID: 209955
			[FieldOffset(8)]
			public FRotator rotation;

			// Token: 0x04033424 RID: 209956
			[FieldOffset(20)]
			public bool sweep;

			// Token: 0x04033425 RID: 209957
			[FieldOffset(24)]
			public FString context;

			// Token: 0x04033426 RID: 209958
			[FieldOffset(40)]
			public bool __Result;
		}

		// Token: 0x0200A544 RID: 42308
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __设置角色位置_FunctionParams
		{
			// Token: 0x04033427 RID: 209959
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04033428 RID: 209960
			[FieldOffset(8)]
			public FVectorDouble location;

			// Token: 0x04033429 RID: 209961
			[FieldOffset(32)]
			public bool sweep;

			// Token: 0x0403342A RID: 209962
			[FieldOffset(33)]
			public bool teleport;

			// Token: 0x0403342B RID: 209963
			[FieldOffset(40)]
			public FString context;

			// Token: 0x0403342C RID: 209964
			[FieldOffset(56)]
			public bool __Result;
		}

		// Token: 0x0200A545 RID: 42309
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __设置角色Pawn通道碰撞响应_FunctionParams
		{
			// Token: 0x0403342D RID: 209965
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x0403342E RID: 209966
			[FieldOffset(8)]
			public TEnumAsByte<EPawnChannel> pawnChannel;

			// Token: 0x0403342F RID: 209967
			[FieldOffset(9)]
			public TEnumAsByte<ECollisionResponse> newResponse;
		}

		// Token: 0x0200A546 RID: 42310
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __给对象移除标签_FunctionParams
		{
			// Token: 0x04033430 RID: 209968
			[FieldOffset(0)]
			public IntPtr Target;

			// Token: 0x04033431 RID: 209969
			[FieldOffset(8)]
			public FGameplayTag tag;
		}

		// Token: 0x0200A547 RID: 42311
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __给对象添加标签_FunctionParams
		{
			// Token: 0x04033432 RID: 209970
			[FieldOffset(0)]
			public IntPtr Target;

			// Token: 0x04033433 RID: 209971
			[FieldOffset(8)]
			public FGameplayTag tag;
		}

		// Token: 0x0200A548 RID: 42312
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __设置子弹目标_FunctionParams
		{
			// Token: 0x04033434 RID: 209972
			[FieldOffset(0)]
			public IntPtr Attacker;

			// Token: 0x04033435 RID: 209973
			[FieldOffset(8)]
			public FString Key;

			// Token: 0x04033436 RID: 209974
			[FieldOffset(24)]
			public int TargetId;
		}

		// Token: 0x0200A549 RID: 42313
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __修改材质效果_FunctionParams
		{
			// Token: 0x04033437 RID: 209975
			[FieldOffset(0)]
			public FScriptInterface Entity;

			// Token: 0x04033438 RID: 209976
			[FieldOffset(16)]
			public bool IsGroup;

			// Token: 0x04033439 RID: 209977
			[FieldOffset(24)]
			public IntPtr 材质效果;
		}

		// Token: 0x0200A54A RID: 42314
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __设置黑板Rotator_FunctionParams
		{
			// Token: 0x0403343A RID: 209978
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x0403343B RID: 209979
			[FieldOffset(8)]
			public FString key;

			// Token: 0x0403343C RID: 209980
			[FieldOffset(24)]
			public FRotator 值;
		}

		// Token: 0x0200A54B RID: 42315
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __进入瞄准模式_FunctionParams
		{
			// Token: 0x0403343D RID: 209981
			[FieldOffset(0)]
			public bool 瞄准键进入;

			// Token: 0x0403343E RID: 209982
			[FieldOffset(1)]
			public TEnumAsByte<EAimViewState> 瞄准镜头类型;

			// Token: 0x0403343F RID: 209983
			[FieldOffset(2)]
			public bool isWalk;
		}

		// Token: 0x0200A54C RID: 42316
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1800)]
		protected ref struct __对圆柱体类型的合法点检测_FunctionParams
		{
			// Token: 0x04033440 RID: 209984
			[FieldOffset(0)]
			public float 施法者半高;

			// Token: 0x04033441 RID: 209985
			[FieldOffset(4)]
			public float 施法者半径;

			// Token: 0x04033442 RID: 209986
			[FieldOffset(8)]
			public float 目标半高;

			// Token: 0x04033443 RID: 209987
			[FieldOffset(12)]
			public float 目标半径;

			// Token: 0x04033444 RID: 209988
			[FieldOffset(16)]
			public FVectorDouble 起点;

			// Token: 0x04033445 RID: 209989
			[FieldOffset(40)]
			public FVectorDouble 终点;

			// Token: 0x04033446 RID: 209990
			[FieldOffset(64)]
			public FVectorDouble 合法点;
		}

		// Token: 0x0200A54D RID: 42317
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 376)]
		protected ref struct __获取目标正后方的合法点_FunctionParams
		{
			// Token: 0x04033447 RID: 209991
			[FieldOffset(0)]
			public IntPtr 目标Actor;

			// Token: 0x04033448 RID: 209992
			[FieldOffset(8)]
			public float 向后距离;

			// Token: 0x04033449 RID: 209993
			[FieldOffset(16)]
			public FVectorDouble 合法点;

			// Token: 0x0403344A RID: 209994
			[FieldOffset(40)]
			public bool 碰撞挤压;
		}

		// Token: 0x0200A54E RID: 42318
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __获取目标到终点的合法点_FunctionParams
		{
			// Token: 0x0403344B RID: 209995
			[FieldOffset(0)]
			public IntPtr 目标Actor;

			// Token: 0x0403344C RID: 209996
			[FieldOffset(8)]
			public FVectorDouble 终点;

			// Token: 0x0403344D RID: 209997
			[FieldOffset(32)]
			public FVectorDouble 合法点;

			// Token: 0x0403344E RID: 209998
			[FieldOffset(56)]
			public bool 碰撞挤压;
		}

		// Token: 0x0200A54F RID: 42319
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 296)]
		protected ref struct __通过角度获取目标附近的合法点_FunctionParams
		{
			// Token: 0x0403344F RID: 209999
			[FieldOffset(0)]
			public IntPtr 目标Actor;

			// Token: 0x04033450 RID: 210000
			[FieldOffset(8)]
			public float 旋转;

			// Token: 0x04033451 RID: 210001
			[FieldOffset(12)]
			public float 仰角;

			// Token: 0x04033452 RID: 210002
			[FieldOffset(16)]
			public float 长度;

			// Token: 0x04033453 RID: 210003
			[FieldOffset(24)]
			public FVectorDouble 合法点;

			// Token: 0x04033454 RID: 210004
			[FieldOffset(48)]
			public bool 碰撞挤压;
		}

		// Token: 0x0200A550 RID: 42320
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __设置接收同打断等级打断_FunctionParams
		{
			// Token: 0x04033455 RID: 210005
			[FieldOffset(0)]
			public bool skillAcceptInput;
		}

		// Token: 0x0200A551 RID: 42321
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __修改当前技能打断等级_FunctionParams
		{
			// Token: 0x04033456 RID: 210006
			[FieldOffset(0)]
			public float priority;
		}

		// Token: 0x0200A552 RID: 42322
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __移除召唤物_FunctionParams
		{
			// Token: 0x04033457 RID: 210007
			[FieldOffset(0)]
			public int 召唤者ID;

			// Token: 0x04033458 RID: 210008
			[FieldOffset(4)]
			public int 移除召唤物ID;
		}

		// Token: 0x0200A553 RID: 42323
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __根据子弹实体ID销毁子弹_FunctionParams
		{
			// Token: 0x04033459 RID: 210009
			[FieldOffset(0)]
			public int 子弹ID;

			// Token: 0x0403345A RID: 210010
			[FieldOffset(4)]
			public bool isSummonChildBullet;
		}

		// Token: 0x0200A554 RID: 42324
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __获取角色ID_FunctionParams
		{
			// Token: 0x0403345B RID: 210011
			[FieldOffset(0)]
			public IntPtr 目标;

			// Token: 0x0403345C RID: 210012
			[FieldOffset(8)]
			public float RoleID;
		}

		// Token: 0x0200A555 RID: 42325
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __获取游戏事件管理器_FunctionParams
		{
			// Token: 0x0403345D RID: 210013
			[FieldOffset(0)]
			public IntPtr 事件管理器;
		}

		// Token: 0x0200A556 RID: 42326
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __获取黑板String_FunctionParams
		{
			// Token: 0x0403345E RID: 210014
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x0403345F RID: 210015
			[FieldOffset(8)]
			public FString Key;

			// Token: 0x04033460 RID: 210016
			[FieldOffset(24)]
			public FString String;
		}

		// Token: 0x0200A557 RID: 42327
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __设置黑板String_FunctionParams
		{
			// Token: 0x04033461 RID: 210017
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04033462 RID: 210018
			[FieldOffset(8)]
			public FString Key;

			// Token: 0x04033463 RID: 210019
			[FieldOffset(24)]
			public FString 值;
		}

		// Token: 0x0200A558 RID: 42328
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __子弹冻结_FunctionParams
		{
			// Token: 0x04033464 RID: 210020
			[FieldOffset(0)]
			public FString 子弹Id;

			// Token: 0x04033465 RID: 210021
			[FieldOffset(16)]
			public float 冻结时间;
		}

		// Token: 0x0200A559 RID: 42329
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __获取当前GA的技能数据名_FunctionParams
		{
			// Token: 0x04033466 RID: 210022
			[FieldOffset(0)]
			public FString 当前技能数据名;
		}

		// Token: 0x0200A55A RID: 42330
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __获取当前操作角色Actor_FunctionParams
		{
			// Token: 0x04033467 RID: 210023
			[FieldOffset(0)]
			public IntPtr 当前角色;
		}

		// Token: 0x0200A55B RID: 42331
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __设置黑板Vector_FunctionParams
		{
			// Token: 0x04033468 RID: 210024
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04033469 RID: 210025
			[FieldOffset(8)]
			public FString key;

			// Token: 0x0403346A RID: 210026
			[FieldOffset(24)]
			public FVectorDouble 值;
		}

		// Token: 0x0200A55C RID: 42332
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __获取黑板Vector_FunctionParams
		{
			// Token: 0x0403346B RID: 210027
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x0403346C RID: 210028
			[FieldOffset(8)]
			public FString key;

			// Token: 0x0403346D RID: 210029
			[FieldOffset(24)]
			public FVectorDouble 值;
		}

		// Token: 0x0200A55D RID: 42333
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __设置黑板EntityId_FunctionParams
		{
			// Token: 0x0403346E RID: 210030
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x0403346F RID: 210031
			[FieldOffset(8)]
			public FString key;

			// Token: 0x04033470 RID: 210032
			[FieldOffset(24)]
			public int 值;
		}

		// Token: 0x0200A55E RID: 42334
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __获取黑板EntityId_FunctionParams
		{
			// Token: 0x04033471 RID: 210033
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04033472 RID: 210034
			[FieldOffset(8)]
			public FString key;

			// Token: 0x04033473 RID: 210035
			[FieldOffset(24)]
			public int 值;
		}

		// Token: 0x0200A55F RID: 42335
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __查询特定子弹数量_FunctionParams
		{
			// Token: 0x04033474 RID: 210036
			[FieldOffset(0)]
			public FName 子弹名字;

			// Token: 0x04033475 RID: 210037
			[FieldOffset(12)]
			public int 子弹数量;
		}

		// Token: 0x0200A560 RID: 42336
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 504)]
		protected ref struct __获取当前技能攻速_FunctionParams
		{
			// Token: 0x04033476 RID: 210038
			[FieldOffset(0)]
			public float SpeedRatio;
		}

		// Token: 0x0200A561 RID: 42337
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __通过ID获取对象Buff层数_FunctionParams
		{
			// Token: 0x04033477 RID: 210039
			[FieldOffset(0)]
			public long buffId;

			// Token: 0x04033478 RID: 210040
			[FieldOffset(8)]
			public bool enforceOnGoingCheck;

			// Token: 0x04033479 RID: 210041
			[FieldOffset(12)]
			public int 层数;
		}

		// Token: 0x0200A562 RID: 42338
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __施法者移除标签_FunctionParams
		{
			// Token: 0x0403347A RID: 210042
			[FieldOffset(0)]
			public FGameplayTag tag;
		}

		// Token: 0x0200A563 RID: 42339
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __施法者添加标签_FunctionParams
		{
			// Token: 0x0403347B RID: 210043
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A564 RID: 42340
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __创建并播放特效_FunctionParams
		{
			// Token: 0x0403347C RID: 210044
			[FieldOffset(0)]
			public IntPtr DA文件名;

			// Token: 0x0403347D RID: 210045
			[FieldOffset(16)]
			public FTransformDouble transform;

			// Token: 0x0403347E RID: 210046
			[FieldOffset(80)]
			public bool AttachToCharacter;

			// Token: 0x0403347F RID: 210047
			[FieldOffset(84)]
			public int __Result;
		}

		// Token: 0x0200A565 RID: 42341
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __获取两者距离_FunctionParams
		{
			// Token: 0x04033480 RID: 210048
			[FieldOffset(0)]
			public IntPtr 目标A;

			// Token: 0x04033481 RID: 210049
			[FieldOffset(8)]
			public IntPtr 目标B;

			// Token: 0x04033482 RID: 210050
			[FieldOffset(16)]
			public float __Result;
		}

		// Token: 0x0200A566 RID: 42342
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __发送事件_FunctionParams
		{
			// Token: 0x04033483 RID: 210051
			[FieldOffset(0)]
			public IntPtr 发送目标;

			// Token: 0x04033484 RID: 210052
			[FieldOffset(8)]
			public FGameplayTag 事件Tag;
		}

		// Token: 0x0200A567 RID: 42343
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __结束异步任务_FunctionParams
		{
			// Token: 0x04033485 RID: 210053
			[FieldOffset(0)]
			public IntPtr 任务;

			// Token: 0x04033486 RID: 210054
			[FieldOffset(8)]
			public bool 有效;
		}

		// Token: 0x0200A568 RID: 42344
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __设置当前技能打断等级_FunctionParams
		{
			// Token: 0x04033487 RID: 210055
			[FieldOffset(0)]
			public int 打断等级;
		}

		// Token: 0x0200A569 RID: 42345
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 448)]
		protected ref struct __获取地面坐标点_FunctionParams
		{
			// Token: 0x04033488 RID: 210056
			[FieldOffset(0)]
			public FVectorDouble 指定点;

			// Token: 0x04033489 RID: 210057
			[FieldOffset(24)]
			public float 深度;

			// Token: 0x0403348A RID: 210058
			[FieldOffset(32)]
			public FVectorDouble 地面坐标;

			// Token: 0x0403348B RID: 210059
			[FieldOffset(56)]
			public bool 是否存在;
		}

		// Token: 0x0200A56A RID: 42346
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __获取目标Tag层数_FunctionParams
		{
			// Token: 0x0403348C RID: 210060
			[FieldOffset(0)]
			public IntPtr 目标;

			// Token: 0x0403348D RID: 210061
			[FieldOffset(8)]
			public FGameplayTag Tag;

			// Token: 0x0403348E RID: 210062
			[FieldOffset(20)]
			public int 层数;
		}

		// Token: 0x0200A56B RID: 42347
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected ref struct __销毁特定子弹_FunctionParams
		{
			// Token: 0x0403348F RID: 210063
			[FieldOffset(0)]
			public FName 子弹名字;

			// Token: 0x04033490 RID: 210064
			[FieldOffset(12)]
			public bool 是否召唤子子弹;
		}

		// Token: 0x0200A56C RID: 42348
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __面向目标_FunctionParams
		{
			// Token: 0x04033491 RID: 210065
			[FieldOffset(0)]
			public IntPtr 目标;

			// Token: 0x04033492 RID: 210066
			[FieldOffset(8)]
			public IntPtr 面向目标;
		}

		// Token: 0x0200A56D RID: 42349
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __设置技能目标_FunctionParams
		{
			// Token: 0x04033493 RID: 210067
			[FieldOffset(0)]
			public IntPtr SkillTarget;
		}

		// Token: 0x0200A56E RID: 42350
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __获取黑板指定Key值关联对象_FunctionParams
		{
			// Token: 0x04033494 RID: 210068
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x04033495 RID: 210069
			[FieldOffset(8)]
			public FString key;

			// Token: 0x04033496 RID: 210070
			[FieldOffset(24)]
			public IntPtr 对象;

			// Token: 0x04033497 RID: 210071
			[FieldOffset(32)]
			public bool 是否找到对象;
		}

		// Token: 0x0200A56F RID: 42351
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __根据实体ID获取对象_FunctionParams
		{
			// Token: 0x04033498 RID: 210072
			[FieldOffset(0)]
			public int 实体ID;

			// Token: 0x04033499 RID: 210073
			[FieldOffset(8)]
			public IntPtr 对象;

			// Token: 0x0403349A RID: 210074
			[FieldOffset(16)]
			public bool 是否找到对象;
		}

		// Token: 0x0200A570 RID: 42352
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __获取实体ID_FunctionParams
		{
			// Token: 0x0403349B RID: 210075
			[FieldOffset(0)]
			public IntPtr 对象;

			// Token: 0x0403349C RID: 210076
			[FieldOffset(8)]
			public int 实体ID;
		}

		// Token: 0x0200A571 RID: 42353
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __设置黑板Long_FunctionParams
		{
			// Token: 0x0403349D RID: 210077
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x0403349E RID: 210078
			[FieldOffset(8)]
			public FString key;

			// Token: 0x0403349F RID: 210079
			[FieldOffset(24)]
			public long 值;
		}

		// Token: 0x0200A572 RID: 42354
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __获取黑板Long_FunctionParams
		{
			// Token: 0x040334A0 RID: 210080
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x040334A1 RID: 210081
			[FieldOffset(8)]
			public FString key;

			// Token: 0x040334A2 RID: 210082
			[FieldOffset(24)]
			public long 值;
		}

		// Token: 0x0200A573 RID: 42355
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __设置黑板Int_FunctionParams
		{
			// Token: 0x040334A3 RID: 210083
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x040334A4 RID: 210084
			[FieldOffset(8)]
			public FString key;

			// Token: 0x040334A5 RID: 210085
			[FieldOffset(24)]
			public int 值;
		}

		// Token: 0x0200A574 RID: 42356
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __获取黑板_Int_FunctionParams
		{
			// Token: 0x040334A6 RID: 210086
			[FieldOffset(0)]
			public IntPtr 角色;

			// Token: 0x040334A7 RID: 210087
			[FieldOffset(8)]
			public FString key;

			// Token: 0x040334A8 RID: 210088
			[FieldOffset(24)]
			public int 值;
		}

		// Token: 0x0200A575 RID: 42357
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3)]
		protected ref struct __是否联网_FunctionParams
		{
			// Token: 0x040334A9 RID: 210089
			[FieldOffset(0)]
			public bool 联网;
		}

		// Token: 0x0200A576 RID: 42358
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __召唤_FunctionParams
		{
			// Token: 0x040334AA RID: 210090
			[FieldOffset(0)]
			public int 配置表ID;

			// Token: 0x040334AB RID: 210091
			[FieldOffset(16)]
			public FTransformDouble 出生位置;

			// Token: 0x040334AC RID: 210092
			[FieldOffset(80)]
			public bool 是否成功;

			// Token: 0x040334AD RID: 210093
			[FieldOffset(88)]
			public IntPtr 召唤物;

			// Token: 0x040334AE RID: 210094
			[FieldOffset(96)]
			public int 实体ID;
		}

		// Token: 0x0200A577 RID: 42359
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __使用技能_FunctionParams
		{
			// Token: 0x040334AF RID: 210095
			[FieldOffset(0)]
			public IntPtr 释放者;

			// Token: 0x040334B0 RID: 210096
			[FieldOffset(8)]
			public FName 技能ID;

			// Token: 0x040334B1 RID: 210097
			[FieldOffset(24)]
			public IntPtr 技能目标;

			// Token: 0x040334B2 RID: 210098
			[FieldOffset(32)]
			public FName Socket;

			// Token: 0x040334B3 RID: 210099
			[FieldOffset(44)]
			public bool 是否成功释放;
		}

		// Token: 0x0200A578 RID: 42360
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __创建子弹_FunctionParams
		{
			// Token: 0x040334B4 RID: 210100
			[FieldOffset(0)]
			public IntPtr 施法者;

			// Token: 0x040334B5 RID: 210101
			[FieldOffset(8)]
			public FString 子弹ID;

			// Token: 0x040334B6 RID: 210102
			[FieldOffset(32)]
			public FTransformDouble 初始变换;

			// Token: 0x040334B7 RID: 210103
			[FieldOffset(96)]
			public FVectorDouble 目标点;

			// Token: 0x040334B8 RID: 210104
			[FieldOffset(120)]
			public int 子弹;
		}

		// Token: 0x0200A579 RID: 42361
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __设置材质效果_FunctionParams
		{
			// Token: 0x040334B9 RID: 210105
			[FieldOffset(0)]
			public IntPtr 设置对象;

			// Token: 0x040334BA RID: 210106
			[FieldOffset(8)]
			public IntPtr 材质配置;

			// Token: 0x040334BB RID: 210107
			[FieldOffset(16)]
			public int Handle;
		}

		// Token: 0x0200A57A RID: 42362
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __通过_ID移除目标Buff_FunctionParams
		{
			// Token: 0x040334BC RID: 210108
			[FieldOffset(0)]
			public long BuffId;

			// Token: 0x040334BD RID: 210109
			[FieldOffset(8)]
			public int 移除层数;

			// Token: 0x040334BE RID: 210110
			[FieldOffset(16)]
			public IntPtr 目标;
		}

		// Token: 0x0200A57B RID: 42363
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __获取Current属性值_FunctionParams
		{
			// Token: 0x040334BF RID: 210111
			[FieldOffset(0)]
			public IntPtr 目标;

			// Token: 0x040334C0 RID: 210112
			[FieldOffset(8)]
			public int 属性id;

			// Token: 0x040334C1 RID: 210113
			[FieldOffset(12)]
			public float 属性值;
		}

		// Token: 0x0200A57C RID: 42364
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __获取Base属性值_FunctionParams
		{
			// Token: 0x040334C2 RID: 210114
			[FieldOffset(0)]
			public IntPtr 目标;

			// Token: 0x040334C3 RID: 210115
			[FieldOffset(8)]
			public int 属性id;

			// Token: 0x040334C4 RID: 210116
			[FieldOffset(12)]
			public float 属性值;
		}

		// Token: 0x0200A57D RID: 42365
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __通过_ID给对象添加Buff_FunctionParams
		{
			// Token: 0x040334C5 RID: 210117
			[FieldOffset(0)]
			public IntPtr Buff对象;

			// Token: 0x040334C6 RID: 210118
			[FieldOffset(8)]
			public long BuffId;

			// Token: 0x040334C7 RID: 210119
			[FieldOffset(16)]
			public int Buff层数;
		}

		// Token: 0x0200A57E RID: 42366
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __通过Tag移除自身Buff_FunctionParams
		{
			// Token: 0x040334C8 RID: 210120
			[FieldOffset(0)]
			public FGameplayTag tag;
		}

		// Token: 0x0200A57F RID: 42367
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __设置通道的碰撞响应_FunctionParams
		{
			// Token: 0x040334C9 RID: 210121
			[FieldOffset(0)]
			public IntPtr 目标;

			// Token: 0x040334CA RID: 210122
			[FieldOffset(8)]
			public TEnumAsByte<ECollisionChannel> Channel;

			// Token: 0x040334CB RID: 210123
			[FieldOffset(9)]
			public TEnumAsByte<ECollisionResponse> NewResponse;
		}

		// Token: 0x0200A580 RID: 42368
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __设置强制速度_FunctionParams
		{
			// Token: 0x040334CC RID: 210124
			[FieldOffset(0)]
			public FVectorDouble 速度;
		}

		// Token: 0x0200A581 RID: 42369
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __是否拥有任意标签_FunctionParams
		{
			// Token: 0x040334CD RID: 210125
			[FieldOffset(0)]
			public IntPtr 目标;

			// Token: 0x040334CE RID: 210126
			[FieldOffset(8)]
			public byte 标签;

			// Token: 0x040334CF RID: 210127
			[FieldOffset(40)]
			public bool 是否存在;
		}

		// Token: 0x0200A582 RID: 42370
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __获取技能目标距离_FunctionParams
		{
			// Token: 0x040334D0 RID: 210128
			[FieldOffset(0)]
			public bool 平面2D;

			// Token: 0x040334D1 RID: 210129
			[FieldOffset(4)]
			public float 距离;
		}

		// Token: 0x0200A583 RID: 42371
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __获取技能目标_FunctionParams
		{
			// Token: 0x040334D2 RID: 210130
			[FieldOffset(0)]
			public IntPtr 目标;

			// Token: 0x040334D3 RID: 210131
			[FieldOffset(8)]
			public IntPtr 技能目标;
		}

		// Token: 0x0200A584 RID: 42372
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __获取AbilitySystemComponent_FunctionParams
		{
			// Token: 0x040334D4 RID: 210132
			[FieldOffset(0)]
			public IntPtr AbilitySystemComponent;
		}

		// Token: 0x0200A585 RID: 42373
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected new ref struct __K2_CanActivateAbility_FunctionParams
		{
			// Token: 0x040334D5 RID: 210133
			[FieldOffset(0)]
			public byte ActorInfo;

			// Token: 0x040334D6 RID: 210134
			[FieldOffset(80)]
			public byte RelevantTags;

			// Token: 0x040334D7 RID: 210135
			[FieldOffset(112)]
			public bool __Result;
		}

		// Token: 0x0200A586 RID: 42374
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected ref struct __获取技能标签_FunctionParams
		{
			// Token: 0x040334D8 RID: 210136
			[FieldOffset(0)]
			public byte 技能标签;
		}

		// Token: 0x0200A587 RID: 42375
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __获取技能所有动画_FunctionParams
		{
			// Token: 0x040334D9 RID: 210137
			[FieldOffset(0)]
			public byte 技能动画数组;
		}

		// Token: 0x0200A588 RID: 42376
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 968)]
		protected ref struct __获取技能动画_FunctionParams
		{
			// Token: 0x040334DA RID: 210138
			[FieldOffset(0)]
			public int 编号;

			// Token: 0x040334DB RID: 210139
			[FieldOffset(8)]
			public IntPtr 动画;
		}

		// Token: 0x0200A589 RID: 42377
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 464)]
		protected ref struct __获取当前技能配置_FunctionParams
		{
			// Token: 0x040334DC RID: 210140
			[FieldOffset(0)]
			public byte 当前技能数据;
		}

		// Token: 0x0200A58A RID: 42378
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __获取当前技能配置Id_FunctionParams
		{
			// Token: 0x040334DD RID: 210141
			[FieldOffset(0)]
			public FString 当前技能数据名;
		}

		// Token: 0x0200A58B RID: 42379
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __获取施法单位EntityId_FunctionParams
		{
			// Token: 0x040334DE RID: 210142
			[FieldOffset(0)]
			public int EntityId;
		}

		// Token: 0x0200A58C RID: 42380
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __获取施法载具_FunctionParams
		{
			// Token: 0x040334DF RID: 210143
			[FieldOffset(0)]
			public IntPtr 施法载具;
		}

		// Token: 0x0200A58D RID: 42381
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __获取施法者_FunctionParams
		{
			// Token: 0x040334E0 RID: 210144
			[FieldOffset(0)]
			public IntPtr 施法者;
		}

		// Token: 0x0200A58E RID: 42382
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040334E1 RID: 210145
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A58F RID: 42383
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ExecuteUbergraph_GA_Base_FunctionParams
		{
			// Token: 0x040334E2 RID: 210146
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
