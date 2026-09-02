using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x020040B5 RID: 16565
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotThrow_Launch.GA_Role_PilotThrow_Launch_C")]
	[UnrealStructLayout(1600, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1596)]
	public class GA_Role_PilotThrow_Launch_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B3AF RID: 177071 RVA: 0x00A74EC7 File Offset: 0x00A730C7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_PilotThrow_Launch_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotThrow_Launch.GA_Role_PilotThrow_Launch_C");
			}
			return GA_Role_PilotThrow_Launch_C._ClassPtr;
		}

		// Token: 0x0602B3B0 RID: 177072 RVA: 0x00A74EEC File Offset: 0x00A730EC
		public GA_Role_PilotThrow_Launch_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_PilotThrow_Launch_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B3B1 RID: 177073 RVA: 0x00A74F14 File Offset: 0x00A73114
		[NullableContext(1)]
		public GA_Role_PilotThrow_Launch_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_PilotThrow_Launch_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007125 RID: 28965
		// (get) Token: 0x0602B3B2 RID: 177074 RVA: 0x00A74F48 File Offset: 0x00A73148
		// (set) Token: 0x0602B3B3 RID: 177075 RVA: 0x00A74F81 File Offset: 0x00A73181
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007126 RID: 28966
		// (get) Token: 0x0602B3B4 RID: 177076 RVA: 0x00A74FA2 File Offset: 0x00A731A2
		// (set) Token: 0x0602B3B5 RID: 177077 RVA: 0x00A74FB6 File Offset: 0x00A731B6
		[Nullable(2)]
		public unsafe TsBaseCharacter 施法者_0
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotThrow_Launch_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotThrow_Launch_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007127 RID: 28967
		// (get) Token: 0x0602B3B6 RID: 177078 RVA: 0x00A74FCB File Offset: 0x00A731CB
		// (set) Token: 0x0602B3B7 RID: 177079 RVA: 0x00A74FDB File Offset: 0x00A731DB
		public unsafe int Entity_Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007128 RID: 28968
		// (get) Token: 0x0602B3B8 RID: 177080 RVA: 0x00A74FEC File Offset: 0x00A731EC
		// (set) Token: 0x0602B3B9 RID: 177081 RVA: 0x00A74FFC File Offset: 0x00A731FC
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007129 RID: 28969
		// (get) Token: 0x0602B3BA RID: 177082 RVA: 0x00A7500D File Offset: 0x00A7320D
		// (set) Token: 0x0602B3BB RID: 177083 RVA: 0x00A7501D File Offset: 0x00A7321D
		public unsafe float 角色胶囊体半高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700712A RID: 28970
		// (get) Token: 0x0602B3BC RID: 177084 RVA: 0x00A7502E File Offset: 0x00A7322E
		// (set) Token: 0x0602B3BD RID: 177085 RVA: 0x00A75042 File Offset: 0x00A73242
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700712B RID: 28971
		// (get) Token: 0x0602B3BE RID: 177086 RVA: 0x00A75057 File Offset: 0x00A73257
		// (set) Token: 0x0602B3BF RID: 177087 RVA: 0x00A7506B File Offset: 0x00A7326B
		public unsafe FVector LastDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700712C RID: 28972
		// (get) Token: 0x0602B3C0 RID: 177088 RVA: 0x00A75080 File Offset: 0x00A73280
		// (set) Token: 0x0602B3C1 RID: 177089 RVA: 0x00A75094 File Offset: 0x00A73294
		public unsafe FVectorDouble LastVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700712D RID: 28973
		// (get) Token: 0x0602B3C2 RID: 177090 RVA: 0x00A750A9 File Offset: 0x00A732A9
		// (set) Token: 0x0602B3C3 RID: 177091 RVA: 0x00A750B9 File Offset: 0x00A732B9
		public unsafe bool 开启摩托技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700712E RID: 28974
		// (get) Token: 0x0602B3C4 RID: 177092 RVA: 0x00A750CA File Offset: 0x00A732CA
		// (set) Token: 0x0602B3C5 RID: 177093 RVA: 0x00A750DA File Offset: 0x00A732DA
		public unsafe bool 正常结束技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700712F RID: 28975
		// (get) Token: 0x0602B3C6 RID: 177094 RVA: 0x00A750EB File Offset: 0x00A732EB
		// (set) Token: 0x0602B3C7 RID: 177095 RVA: 0x00A750FB File Offset: 0x00A732FB
		public unsafe bool 是否忽略碰撞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007130 RID: 28976
		// (get) Token: 0x0602B3C8 RID: 177096 RVA: 0x00A7510C File Offset: 0x00A7330C
		// (set) Token: 0x0602B3C9 RID: 177097 RVA: 0x00A7511C File Offset: 0x00A7331C
		public unsafe int 速度方向遮挡帧数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007131 RID: 28977
		// (get) Token: 0x0602B3CA RID: 177098 RVA: 0x00A7512D File Offset: 0x00A7332D
		// (set) Token: 0x0602B3CB RID: 177099 RVA: 0x00A7513D File Offset: 0x00A7333D
		public unsafe int 变身特效Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007132 RID: 28978
		// (get) Token: 0x0602B3CC RID: 177100 RVA: 0x00A7514E File Offset: 0x00A7334E
		// (set) Token: 0x0602B3CD RID: 177101 RVA: 0x00A7515E File Offset: 0x00A7335E
		public unsafe int 变身材质handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007133 RID: 28979
		// (get) Token: 0x0602B3CE RID: 177102 RVA: 0x00A7516F File Offset: 0x00A7336F
		// (set) Token: 0x0602B3CF RID: 177103 RVA: 0x00A7517F File Offset: 0x00A7337F
		public unsafe int 氮气特效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotThrow_Launch_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x0602B3D0 RID: 177104 RVA: 0x00A75190 File Offset: 0x00A73390
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddTags(ref TArray<FGameplayTag> TagsArray)
		{
			GA_Role_PilotThrow_Launch_C.__AddTags_FunctionParams* ptr = stackalloc GA_Role_PilotThrow_Launch_C.__AddTags_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Role_PilotThrow_Launch_C.__AddTags_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotThrow_Launch_C.__AddTags_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FGameplayTag> tarray = TagsArray;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->TagsArray);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__AddTags_NativeFunctionPtr, (void*)ptr);
			TArray<FGameplayTag> tarray2 = TagsArray;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->TagsArray);
			}
			UnrealReflectionUtils.DestroyStruct(GA_Role_PilotThrow_Launch_C.__AddTags_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B3D1 RID: 177105 RVA: 0x00A75208 File Offset: 0x00A73408
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SummonMoter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__SummonMoter_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3D2 RID: 177106 RVA: 0x00A7521C File Offset: 0x00A7341C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RemoveTags(ref TArray<FGameplayTag> TagsArray)
		{
			GA_Role_PilotThrow_Launch_C.__RemoveTags_FunctionParams* ptr = stackalloc GA_Role_PilotThrow_Launch_C.__RemoveTags_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Role_PilotThrow_Launch_C.__RemoveTags_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotThrow_Launch_C.__RemoveTags_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FGameplayTag> tarray = TagsArray;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->TagsArray);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__RemoveTags_NativeFunctionPtr, (void*)ptr);
			TArray<FGameplayTag> tarray2 = TagsArray;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->TagsArray);
			}
			UnrealReflectionUtils.DestroyStruct(GA_Role_PilotThrow_Launch_C.__RemoveTags_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B3D3 RID: 177107 RVA: 0x00A75294 File Offset: 0x00A73494
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ActivateMotreState()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__ActivateMotreState_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3D4 RID: 177108 RVA: 0x00A752A8 File Offset: 0x00A734A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndNiagara()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__EndNiagara_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3D5 RID: 177109 RVA: 0x00A752BC File Offset: 0x00A734BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void NiagaraSetting()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__NiagaraSetting_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3D6 RID: 177110 RVA: 0x00A752D0 File Offset: 0x00A734D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LaunchTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__LaunchTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3D7 RID: 177111 RVA: 0x00A752E4 File Offset: 0x00A734E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LaunchStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__LaunchStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3D8 RID: 177112 RVA: 0x00A752F8 File Offset: 0x00A734F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__EndAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3D9 RID: 177113 RVA: 0x00A7530C File Offset: 0x00A7350C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__OnBegin_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3DA RID: 177114 RVA: 0x00A75320 File Offset: 0x00A73520
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81BCF59A99()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__OnTick_5D118C384AE61F1C80292E81BCF59A99_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3DB RID: 177115 RVA: 0x00A75334 File Offset: 0x00A73534
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81BCF59A99()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__OnCancelled_5D118C384AE61F1C80292E81BCF59A99_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3DC RID: 177116 RVA: 0x00A75348 File Offset: 0x00A73548
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81BCF59A99()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__OnInterrupted_5D118C384AE61F1C80292E81BCF59A99_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3DD RID: 177117 RVA: 0x00A7535C File Offset: 0x00A7355C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81BCF59A99()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__OnBlendOut_5D118C384AE61F1C80292E81BCF59A99_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3DE RID: 177118 RVA: 0x00A75370 File Offset: 0x00A73570
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81BCF59A99()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__OnCompleted_5D118C384AE61F1C80292E81BCF59A99_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3DF RID: 177119 RVA: 0x00A75384 File Offset: 0x00A73584
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_4C78DB704CE78EA4FE6D38B9C20F4287()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__OnFinish_4C78DB704CE78EA4FE6D38B9C20F4287_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3E0 RID: 177120 RVA: 0x00A75398 File Offset: 0x00A73598
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_4C78DB704CE78EA4FE6D38B9C20F4287()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__OnTick_4C78DB704CE78EA4FE6D38B9C20F4287_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3E1 RID: 177121 RVA: 0x00A753AC File Offset: 0x00A735AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3E2 RID: 177122 RVA: 0x00A753C0 File Offset: 0x00A735C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B3E3 RID: 177123 RVA: 0x00A753D8 File Offset: 0x00A735D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_PilotThrow_Launch_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_PilotThrow_Launch_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_PilotThrow_Launch_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotThrow_Launch_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B3E4 RID: 177124 RVA: 0x00A75420 File Offset: 0x00A73620
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_PilotThrow_Launch_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_PilotThrow_Launch_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_PilotThrow_Launch_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotThrow_Launch_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B3E5 RID: 177125 RVA: 0x00A75468 File Offset: 0x00A73668
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementModeChange(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Role_PilotThrow_Launch_C.__MovementModeChange_FunctionParams* ptr = stackalloc GA_Role_PilotThrow_Launch_C.__MovementModeChange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Role_PilotThrow_Launch_C.__MovementModeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotThrow_Launch_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B3E6 RID: 177126 RVA: 0x00A754D0 File Offset: 0x00A736D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayMontage()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__PlayMontage_NativeFunctionPtr, null);
		}

		// Token: 0x0602B3E7 RID: 177127 RVA: 0x00A754E4 File Offset: 0x00A736E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_PilotThrow_Launch(int EntryPoint)
		{
			GA_Role_PilotThrow_Launch_C.__ExecuteUbergraph_GA_Role_PilotThrow_Launch_FunctionParams* ptr = stackalloc GA_Role_PilotThrow_Launch_C.__ExecuteUbergraph_GA_Role_PilotThrow_Launch_FunctionParams[(UIntPtr)951] + 15L / (long)sizeof(GA_Role_PilotThrow_Launch_C.__ExecuteUbergraph_GA_Role_PilotThrow_Launch_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotThrow_Launch_C.__ExecuteUbergraph_GA_Role_PilotThrow_Launch_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotThrow_Launch_C.__ExecuteUbergraph_GA_Role_PilotThrow_Launch_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B3E8 RID: 177128 RVA: 0x00A7552E File Offset: 0x00A7372E
		protected GA_Role_PilotThrow_Launch_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017AD2 RID: 96978
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotThrow_Launch.GA_Role_PilotThrow_Launch_C";

		// Token: 0x04017AD3 RID: 96979
		private static IntPtr _ClassPtr;

		// Token: 0x04017AD4 RID: 96980
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017AD5 RID: 96981
		internal new static int __PropertyOffset_0;

		// Token: 0x04017AD6 RID: 96982
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017AD7 RID: 96983
		internal new static int __PropertyOffset_1;

		// Token: 0x04017AD8 RID: 96984
		internal new static int __PropertyOffset_2;

		// Token: 0x04017AD9 RID: 96985
		internal new static int __PropertyOffset_3;

		// Token: 0x04017ADA RID: 96986
		internal static int __PropertyOffset_4;

		// Token: 0x04017ADB RID: 96987
		internal static int __PropertyOffset_5;

		// Token: 0x04017ADC RID: 96988
		internal static int __PropertyOffset_6;

		// Token: 0x04017ADD RID: 96989
		internal static int __PropertyOffset_7;

		// Token: 0x04017ADE RID: 96990
		internal static int __PropertyOffset_8;

		// Token: 0x04017ADF RID: 96991
		internal static int __PropertyOffset_9;

		// Token: 0x04017AE0 RID: 96992
		internal static int __PropertyOffset_10;

		// Token: 0x04017AE1 RID: 96993
		internal static int __PropertyOffset_11;

		// Token: 0x04017AE2 RID: 96994
		internal static int __PropertyOffset_12;

		// Token: 0x04017AE3 RID: 96995
		internal static int __PropertyOffset_13;

		// Token: 0x04017AE4 RID: 96996
		internal static int __PropertyOffset_14;

		// Token: 0x04017AE5 RID: 96997
		private static IntPtr __AddTags_NativeFunctionPtr;

		// Token: 0x04017AE6 RID: 96998
		private static IntPtr __SummonMoter_NativeFunctionPtr;

		// Token: 0x04017AE7 RID: 96999
		private static IntPtr __RemoveTags_NativeFunctionPtr;

		// Token: 0x04017AE8 RID: 97000
		private static IntPtr __ActivateMotreState_NativeFunctionPtr;

		// Token: 0x04017AE9 RID: 97001
		private static IntPtr __EndNiagara_NativeFunctionPtr;

		// Token: 0x04017AEA RID: 97002
		private static IntPtr __NiagaraSetting_NativeFunctionPtr;

		// Token: 0x04017AEB RID: 97003
		private static IntPtr __LaunchTick_NativeFunctionPtr;

		// Token: 0x04017AEC RID: 97004
		private static IntPtr __LaunchStart_NativeFunctionPtr;

		// Token: 0x04017AED RID: 97005
		private static IntPtr __EndAbility_NativeFunctionPtr;

		// Token: 0x04017AEE RID: 97006
		private static IntPtr __OnBegin_NativeFunctionPtr;

		// Token: 0x04017AEF RID: 97007
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81BCF59A99_NativeFunctionPtr;

		// Token: 0x04017AF0 RID: 97008
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81BCF59A99_NativeFunctionPtr;

		// Token: 0x04017AF1 RID: 97009
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81BCF59A99_NativeFunctionPtr;

		// Token: 0x04017AF2 RID: 97010
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81BCF59A99_NativeFunctionPtr;

		// Token: 0x04017AF3 RID: 97011
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81BCF59A99_NativeFunctionPtr;

		// Token: 0x04017AF4 RID: 97012
		private static IntPtr __OnFinish_4C78DB704CE78EA4FE6D38B9C20F4287_NativeFunctionPtr;

		// Token: 0x04017AF5 RID: 97013
		private static IntPtr __OnTick_4C78DB704CE78EA4FE6D38B9C20F4287_NativeFunctionPtr;

		// Token: 0x04017AF6 RID: 97014
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017AF7 RID: 97015
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017AF8 RID: 97016
		private static IntPtr __MovementModeChange_NativeFunctionPtr;

		// Token: 0x04017AF9 RID: 97017
		private static IntPtr __PlayMontage_NativeFunctionPtr;

		// Token: 0x04017AFA RID: 97018
		private static IntPtr __ExecuteUbergraph_GA_Role_PilotThrow_Launch_NativeFunctionPtr;

		// Token: 0x0200A332 RID: 41778
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __AddTags_FunctionParams
		{
			// Token: 0x04033109 RID: 209161
			[FieldOffset(0)]
			public byte TagsArray;
		}

		// Token: 0x0200A333 RID: 41779
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __RemoveTags_FunctionParams
		{
			// Token: 0x0403310A RID: 209162
			[FieldOffset(0)]
			public byte TagsArray;
		}

		// Token: 0x0200A334 RID: 41780
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403310B RID: 209163
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A335 RID: 41781
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementModeChange_FunctionParams
		{
			// Token: 0x0403310C RID: 209164
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x0403310D RID: 209165
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x0403310E RID: 209166
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A336 RID: 41782
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 936)]
		protected ref struct __ExecuteUbergraph_GA_Role_PilotThrow_Launch_FunctionParams
		{
			// Token: 0x0403310F RID: 209167
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
