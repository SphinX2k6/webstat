using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight.Manager
{
	// Token: 0x02003F7B RID: 16251
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C")]
	[UnrealStructLayout(584, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 584)]
	public class BP_FightManager_C : BP_ManagerBase_C, IUnrealUObject, IUnrealObject, IBPI_Tick_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x06028A17 RID: 166423 RVA: 0x00A10CF8 File Offset: 0x00A0EEF8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FightManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C");
			}
			return BP_FightManager_C._ClassPtr;
		}

		// Token: 0x06028A18 RID: 166424 RVA: 0x00A10D1C File Offset: 0x00A0EF1C
		public BP_FightManager_C() : this(BuiltinUtils.AllocNativeUObject(BP_FightManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028A19 RID: 166425 RVA: 0x00A10D44 File Offset: 0x00A0EF44
		public BP_FightManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FightManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006342 RID: 25410
		// (get) Token: 0x06028A1A RID: 166426 RVA: 0x00A10D78 File Offset: 0x00A0EF78
		// (set) Token: 0x06028A1B RID: 166427 RVA: 0x00A10DB1 File Offset: 0x00A0EFB1
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006343 RID: 25411
		// (get) Token: 0x06028A1C RID: 166428 RVA: 0x00A10DD2 File Offset: 0x00A0EFD2
		// (set) Token: 0x06028A1D RID: 166429 RVA: 0x00A10DE6 File Offset: 0x00A0EFE6
		[Nullable(2)]
		public unsafe BP_ActorManager_C 角色管理器
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_ActorManager_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FightManager_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FightManager_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006344 RID: 25412
		// (get) Token: 0x06028A1E RID: 166430 RVA: 0x00A10DFB File Offset: 0x00A0EFFB
		// (set) Token: 0x06028A1F RID: 166431 RVA: 0x00A10E0B File Offset: 0x00A0F00B
		public unsafe bool 初始化完成
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006345 RID: 25413
		// (get) Token: 0x06028A20 RID: 166432 RVA: 0x00A10E1C File Offset: 0x00A0F01C
		// (set) Token: 0x06028A21 RID: 166433 RVA: 0x00A10E55 File Offset: 0x00A0F055
		public 三消触发 三消触发
		{
			get
			{
				base.FastCheckIsValid();
				三消触发 result;
				if ((result = this._三消触发) == null)
				{
					result = (this._三消触发 = new 三消触发(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_3, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17006346 RID: 25414
		// (get) Token: 0x06028A22 RID: 166434 RVA: 0x00A10E78 File Offset: 0x00A0F078
		// (set) Token: 0x06028A23 RID: 166435 RVA: 0x00A10EB1 File Offset: 0x00A0F0B1
		public 击飞触发 击飞触发
		{
			get
			{
				base.FastCheckIsValid();
				击飞触发 result;
				if ((result = this._击飞触发) == null)
				{
					result = (this._击飞触发 = new 击飞触发(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_4, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17006347 RID: 25415
		// (get) Token: 0x06028A24 RID: 166436 RVA: 0x00A10ED4 File Offset: 0x00A0F0D4
		// (set) Token: 0x06028A25 RID: 166437 RVA: 0x00A10F0D File Offset: 0x00A0F10D
		public 破白条触发 破白条触发
		{
			get
			{
				base.FastCheckIsValid();
				破白条触发 result;
				if ((result = this._破白条触发) == null)
				{
					result = (this._破白条触发 = new 破白条触发(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_5, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17006348 RID: 25416
		// (get) Token: 0x06028A26 RID: 166438 RVA: 0x00A10F30 File Offset: 0x00A0F130
		// (set) Token: 0x06028A27 RID: 166439 RVA: 0x00A10F69 File Offset: 0x00A0F169
		public 三红触发 三红触发
		{
			get
			{
				base.FastCheckIsValid();
				三红触发 result;
				if ((result = this._三红触发) == null)
				{
					result = (this._三红触发 = new 三红触发(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_6, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17006349 RID: 25417
		// (get) Token: 0x06028A28 RID: 166440 RVA: 0x00A10F8A File Offset: 0x00A0F18A
		// (set) Token: 0x06028A29 RID: 166441 RVA: 0x00A10F9E File Offset: 0x00A0F19E
		[Nullable(2)]
		public unsafe UDataTable 阵营关系数据
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FightManager_C.__PropertyOffset_7);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FightManager_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700634A RID: 25418
		// (get) Token: 0x06028A2A RID: 166442 RVA: 0x00A10FB4 File Offset: 0x00A0F1B4
		// (set) Token: 0x06028A2B RID: 166443 RVA: 0x00A10FED File Offset: 0x00A0F1ED
		public 队伍角色加载完成 队伍角色加载完成
		{
			get
			{
				base.FastCheckIsValid();
				队伍角色加载完成 result;
				if ((result = this._队伍角色加载完成) == null)
				{
					result = (this._队伍角色加载完成 = new 队伍角色加载完成(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_8, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700634B RID: 25419
		// (get) Token: 0x06028A2C RID: 166444 RVA: 0x00A11010 File Offset: 0x00A0F210
		// (set) Token: 0x06028A2D RID: 166445 RVA: 0x00A11049 File Offset: 0x00A0F249
		public TMap<int, UObject> BPai数组
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, UObject> result;
				if ((result = this._BPai数组) == null)
				{
					result = (this._BPai数组 = new TMap<int, UObject>(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.BPai数组.CopyAssign(value);
			}
		}

		// Token: 0x1700634C RID: 25420
		// (get) Token: 0x06028A2E RID: 166446 RVA: 0x00A11058 File Offset: 0x00A0F258
		// (set) Token: 0x06028A2F RID: 166447 RVA: 0x00A11091 File Offset: 0x00A0F291
		public TArray<UObject> 怪物临时BPAI数组
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UObject> result;
				if ((result = this._怪物临时BPAI数组) == null)
				{
					result = (this._怪物临时BPAI数组 = new TArray<UObject>(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.怪物临时BPAI数组.CopyAssign(value);
			}
		}

		// Token: 0x1700634D RID: 25421
		// (get) Token: 0x06028A30 RID: 166448 RVA: 0x00A1109F File Offset: 0x00A0F29F
		// (set) Token: 0x06028A31 RID: 166449 RVA: 0x00A110AF File Offset: 0x00A0F2AF
		public unsafe bool 场景加载完成
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700634E RID: 25422
		// (get) Token: 0x06028A32 RID: 166450 RVA: 0x00A110C0 File Offset: 0x00A0F2C0
		// (set) Token: 0x06028A33 RID: 166451 RVA: 0x00A110F9 File Offset: 0x00A0F2F9
		public TMap<string, ABaseCharacter> Debug的对象集合
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, ABaseCharacter> result;
				if ((result = this._Debug的对象集合) == null)
				{
					result = (this._Debug的对象集合 = new TMap<string, ABaseCharacter>(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.Debug的对象集合.CopyAssign(value);
			}
		}

		// Token: 0x1700634F RID: 25423
		// (get) Token: 0x06028A34 RID: 166452 RVA: 0x00A11108 File Offset: 0x00A0F308
		// (set) Token: 0x06028A35 RID: 166453 RVA: 0x00A11141 File Offset: 0x00A0F341
		public 添加Debug的FightAttribute 添加Debug的FightAttribute
		{
			get
			{
				base.FastCheckIsValid();
				添加Debug的FightAttribute result;
				if ((result = this._添加Debug的FightAttribute) == null)
				{
					result = (this._添加Debug的FightAttribute = new 添加Debug的FightAttribute(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_13, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17006350 RID: 25424
		// (get) Token: 0x06028A36 RID: 166454 RVA: 0x00A11164 File Offset: 0x00A0F364
		// (set) Token: 0x06028A37 RID: 166455 RVA: 0x00A1119D File Offset: 0x00A0F39D
		public 删除Debug的FightAttribute 删除Debug的FightAttribute
		{
			get
			{
				base.FastCheckIsValid();
				删除Debug的FightAttribute result;
				if ((result = this._删除Debug的FightAttribute) == null)
				{
					result = (this._删除Debug的FightAttribute = new 删除Debug的FightAttribute(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_14, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17006351 RID: 25425
		// (get) Token: 0x06028A38 RID: 166456 RVA: 0x00A111C0 File Offset: 0x00A0F3C0
		// (set) Token: 0x06028A39 RID: 166457 RVA: 0x00A111F9 File Offset: 0x00A0F3F9
		public TMap<int, int> 站位怪物数量
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, int> result;
				if ((result = this._站位怪物数量) == null)
				{
					result = (this._站位怪物数量 = new TMap<int, int>(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.站位怪物数量.CopyAssign(value);
			}
		}

		// Token: 0x17006352 RID: 25426
		// (get) Token: 0x06028A3A RID: 166458 RVA: 0x00A11207 File Offset: 0x00A0F407
		// (set) Token: 0x06028A3B RID: 166459 RVA: 0x00A1121B File Offset: 0x00A0F41B
		[Nullable(2)]
		public unsafe UDataTable 受击类型覆盖表
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FightManager_C.__PropertyOffset_16);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FightManager_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17006353 RID: 25427
		// (get) Token: 0x06028A3C RID: 166460 RVA: 0x00A11230 File Offset: 0x00A0F430
		// (set) Token: 0x06028A3D RID: 166461 RVA: 0x00A11240 File Offset: 0x00A0F440
		public unsafe int 攻击位数量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17006354 RID: 25428
		// (get) Token: 0x06028A3E RID: 166462 RVA: 0x00A11254 File Offset: 0x00A0F454
		// (set) Token: 0x06028A3F RID: 166463 RVA: 0x00A1128D File Offset: 0x00A0F48D
		public TMap<string, int> DebugEntityMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, int> result;
				if ((result = this._DebugEntityMap) == null)
				{
					result = (this._DebugEntityMap = new TMap<string, int>(base.NativePtr + (IntPtr)BP_FightManager_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				this.DebugEntityMap.CopyAssign(value);
			}
		}

		// Token: 0x06028A40 RID: 166464 RVA: 0x00A1129C File Offset: 0x00A0F49C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RemoveDebugEntity(int EntityId, string ObjectName)
		{
			BP_FightManager_C.__RemoveDebugEntity_FunctionParams* ptr = stackalloc BP_FightManager_C.__RemoveDebugEntity_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_FightManager_C.__RemoveDebugEntity_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FightManager_C.__RemoveDebugEntity_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntityId = EntityId;
			FString.CopyFrom((void*)(&ptr->ObjectName), ObjectName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__RemoveDebugEntity_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_FightManager_C.__RemoveDebugEntity_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028A41 RID: 166465 RVA: 0x00A11300 File Offset: 0x00A0F500
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddDebugEntity(int EntityId, string ObjectName)
		{
			BP_FightManager_C.__AddDebugEntity_FunctionParams* ptr = stackalloc BP_FightManager_C.__AddDebugEntity_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_FightManager_C.__AddDebugEntity_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FightManager_C.__AddDebugEntity_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntityId = EntityId;
			FString.CopyFrom((void*)(&ptr->ObjectName), ObjectName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__AddDebugEntity_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_FightManager_C.__AddDebugEntity_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028A42 RID: 166466 RVA: 0x00A11364 File Offset: 0x00A0F564
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 查询受击类型覆盖(int ID, ref SHitMapping 受击覆盖, ref bool 是否找到)
		{
			BP_FightManager_C.__查询受击类型覆盖_FunctionParams* ptr = stackalloc BP_FightManager_C.__查询受击类型覆盖_FunctionParams[(UIntPtr)311] + 15L / (long)sizeof(BP_FightManager_C.__查询受击类型覆盖_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FightManager_C.__查询受击类型覆盖_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ID = ID;
			if (受击覆盖 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHitMapping.StaticStruct(), &ptr->受击覆盖, 受击覆盖.NativePtr, 1, false);
			}
			ptr->是否找到 = 是否找到;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__查询受击类型覆盖_NativeFunctionPtr, (void*)ptr);
			if (受击覆盖 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHitMapping.StaticStruct(), 受击覆盖.NativePtr, &ptr->受击覆盖, 1, false);
			}
			是否找到 = ptr->是否找到;
			UnrealReflectionUtils.DestroyStruct(BP_FightManager_C.__查询受击类型覆盖_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028A43 RID: 166467 RVA: 0x00A11418 File Offset: 0x00A0F618
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 站位控制([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UObject> 怪物数组)
		{
			BP_FightManager_C.__站位控制_FunctionParams* ptr = stackalloc BP_FightManager_C.__站位控制_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_FightManager_C.__站位控制_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FightManager_C.__站位控制_NativeFunctionPtr, (void*)ptr, 1);
			TArray<UObject> tarray = 怪物数组;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->怪物数组);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__站位控制_NativeFunctionPtr, (void*)ptr);
			TArray<UObject> tarray2 = 怪物数组;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->怪物数组);
			}
			UnrealReflectionUtils.DestroyStruct(BP_FightManager_C.__站位控制_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028A44 RID: 166468 RVA: 0x00A11490 File Offset: 0x00A0F690
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 删除Debug的对象(in ABaseCharacter baseChar)
		{
			BP_FightManager_C.__删除Debug的对象_FunctionParams* ptr = stackalloc BP_FightManager_C.__删除Debug的对象_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_FightManager_C.__删除Debug的对象_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FightManager_C.__删除Debug的对象_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_FightManager_C.__删除Debug的对象_FunctionParams ptr2 = ref *ptr;
			object obj = baseChar;
			ptr2.baseChar = ((obj != null) ? obj.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__删除Debug的对象_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028A45 RID: 166469 RVA: 0x00A114E8 File Offset: 0x00A0F6E8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 添加Debug的对象(in ABaseCharacter baseChar)
		{
			BP_FightManager_C.__添加Debug的对象_FunctionParams* ptr = stackalloc BP_FightManager_C.__添加Debug的对象_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_FightManager_C.__添加Debug的对象_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FightManager_C.__添加Debug的对象_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_FightManager_C.__添加Debug的对象_FunctionParams ptr2 = ref *ptr;
			object obj = baseChar;
			ptr2.baseChar = ((obj != null) ? obj.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__添加Debug的对象_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028A46 RID: 166470 RVA: 0x00A11540 File Offset: 0x00A0F740
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 注册BPai(UObject BPAI对象)
		{
			BP_FightManager_C.__注册BPai_FunctionParams* ptr = stackalloc BP_FightManager_C.__注册BPai_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_FightManager_C.__注册BPai_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FightManager_C.__注册BPai_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BPAI对象 = ((BPAI对象 != null) ? BPAI对象.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__注册BPai_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028A47 RID: 166471 RVA: 0x00A11595 File Offset: 0x00A0F795
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 烈度获取所有Actor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__烈度获取所有Actor_NativeFunctionPtr, null);
		}

		// Token: 0x06028A48 RID: 166472 RVA: 0x00A115A9 File Offset: 0x00A0F7A9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 烈度返回NPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__烈度返回NPC_NativeFunctionPtr, null);
		}

		// Token: 0x06028A49 RID: 166473 RVA: 0x00A115C0 File Offset: 0x00A0F7C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 阵营判断(ECamp 自身阵营, ECamp 目标阵营, ref ERelation 关系, ref int 关系整数)
		{
			BP_FightManager_C.__阵营判断_FunctionParams* ptr = stackalloc BP_FightManager_C.__阵营判断_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_FightManager_C.__阵营判断_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FightManager_C.__阵营判断_NativeFunctionPtr, (void*)ptr, 1);
			ptr->自身阵营 = 自身阵营;
			ptr->目标阵营 = 目标阵营;
			ptr->关系 = 关系;
			ptr->关系整数 = 关系整数;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__阵营判断_NativeFunctionPtr, (void*)ptr);
			关系 = ptr->关系;
			关系整数 = ptr->关系整数;
		}

		// Token: 0x06028A4A RID: 166474 RVA: 0x00A11644 File Offset: 0x00A0F844
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void 初始化(BP_MainGameInstance_C 游戏实例)
		{
			BP_FightManager_C.__初始化_FunctionParams* ptr = stackalloc BP_FightManager_C.__初始化_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_FightManager_C.__初始化_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FightManager_C.__初始化_NativeFunctionPtr, (void*)ptr, 1);
			ptr->游戏实例 = ((游戏实例 != null) ? 游戏实例.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__初始化_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028A4B RID: 166475 RVA: 0x00A11699 File Offset: 0x00A0F899
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 战斗初始化()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__战斗初始化_NativeFunctionPtr, null);
		}

		// Token: 0x06028A4C RID: 166476 RVA: 0x00A116B0 File Offset: 0x00A0F8B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Tick(float DeltaSeconds)
		{
			BP_FightManager_C.__Tick_FunctionParams* ptr = stackalloc BP_FightManager_C.__Tick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FightManager_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FightManager_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__Tick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028A4D RID: 166477 RVA: 0x00A116F6 File Offset: 0x00A0F8F6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 当阵容加载完成时()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FightManager_C.__当阵容加载完成时_NativeFunctionPtr, null);
		}

		// Token: 0x06028A4E RID: 166478 RVA: 0x00A1170C File Offset: 0x00A0F90C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FightManager(int EntryPoint)
		{
			BP_FightManager_C.__ExecuteUbergraph_BP_FightManager_FunctionParams* ptr = stackalloc BP_FightManager_C.__ExecuteUbergraph_BP_FightManager_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_FightManager_C.__ExecuteUbergraph_BP_FightManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FightManager_C.__ExecuteUbergraph_BP_FightManager_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FightManager_C.__ExecuteUbergraph_BP_FightManager_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028A4F RID: 166479 RVA: 0x00A11753 File Offset: 0x00A0F953
		protected BP_FightManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040156DA RID: 87770
		public new const string __ObjectPath = "/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C";

		// Token: 0x040156DB RID: 87771
		private static IntPtr _ClassPtr;

		// Token: 0x040156DC RID: 87772
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040156DD RID: 87773
		public static IntPtr __删除Debug的FightAttribute__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040156DE RID: 87774
		public static IntPtr __添加Debug的FightAttribute__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040156DF RID: 87775
		public static IntPtr __队伍角色加载完成__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040156E0 RID: 87776
		public static IntPtr __破白条触发__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040156E1 RID: 87777
		public static IntPtr __击飞触发__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040156E2 RID: 87778
		public static IntPtr __三消触发__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040156E3 RID: 87779
		public static IntPtr __三红触发__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040156E4 RID: 87780
		internal new static int __PropertyOffset_0;

		// Token: 0x040156E5 RID: 87781
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040156E6 RID: 87782
		internal new static int __PropertyOffset_1;

		// Token: 0x040156E7 RID: 87783
		internal new static int __PropertyOffset_2;

		// Token: 0x040156E8 RID: 87784
		internal static int __PropertyOffset_3;

		// Token: 0x040156E9 RID: 87785
		[Nullable(2)]
		private 三消触发 _三消触发;

		// Token: 0x040156EA RID: 87786
		internal static int __PropertyOffset_4;

		// Token: 0x040156EB RID: 87787
		[Nullable(2)]
		private 击飞触发 _击飞触发;

		// Token: 0x040156EC RID: 87788
		internal static int __PropertyOffset_5;

		// Token: 0x040156ED RID: 87789
		[Nullable(2)]
		private 破白条触发 _破白条触发;

		// Token: 0x040156EE RID: 87790
		internal static int __PropertyOffset_6;

		// Token: 0x040156EF RID: 87791
		[Nullable(2)]
		private 三红触发 _三红触发;

		// Token: 0x040156F0 RID: 87792
		internal static int __PropertyOffset_7;

		// Token: 0x040156F1 RID: 87793
		internal static int __PropertyOffset_8;

		// Token: 0x040156F2 RID: 87794
		[Nullable(2)]
		private 队伍角色加载完成 _队伍角色加载完成;

		// Token: 0x040156F3 RID: 87795
		internal static int __PropertyOffset_9;

		// Token: 0x040156F4 RID: 87796
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, UObject> _BPai数组;

		// Token: 0x040156F5 RID: 87797
		internal static int __PropertyOffset_10;

		// Token: 0x040156F6 RID: 87798
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UObject> _怪物临时BPAI数组;

		// Token: 0x040156F7 RID: 87799
		internal static int __PropertyOffset_11;

		// Token: 0x040156F8 RID: 87800
		internal static int __PropertyOffset_12;

		// Token: 0x040156F9 RID: 87801
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, ABaseCharacter> _Debug的对象集合;

		// Token: 0x040156FA RID: 87802
		internal static int __PropertyOffset_13;

		// Token: 0x040156FB RID: 87803
		[Nullable(2)]
		private 添加Debug的FightAttribute _添加Debug的FightAttribute;

		// Token: 0x040156FC RID: 87804
		internal static int __PropertyOffset_14;

		// Token: 0x040156FD RID: 87805
		[Nullable(2)]
		private 删除Debug的FightAttribute _删除Debug的FightAttribute;

		// Token: 0x040156FE RID: 87806
		internal static int __PropertyOffset_15;

		// Token: 0x040156FF RID: 87807
		[Nullable(2)]
		private TMap<int, int> _站位怪物数量;

		// Token: 0x04015700 RID: 87808
		internal static int __PropertyOffset_16;

		// Token: 0x04015701 RID: 87809
		internal static int __PropertyOffset_17;

		// Token: 0x04015702 RID: 87810
		internal static int __PropertyOffset_18;

		// Token: 0x04015703 RID: 87811
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, int> _DebugEntityMap;

		// Token: 0x04015704 RID: 87812
		private static IntPtr __RemoveDebugEntity_NativeFunctionPtr;

		// Token: 0x04015705 RID: 87813
		private static IntPtr __AddDebugEntity_NativeFunctionPtr;

		// Token: 0x04015706 RID: 87814
		private static IntPtr __查询受击类型覆盖_NativeFunctionPtr;

		// Token: 0x04015707 RID: 87815
		private static IntPtr __站位控制_NativeFunctionPtr;

		// Token: 0x04015708 RID: 87816
		private static IntPtr __删除Debug的对象_NativeFunctionPtr;

		// Token: 0x04015709 RID: 87817
		private static IntPtr __添加Debug的对象_NativeFunctionPtr;

		// Token: 0x0401570A RID: 87818
		private static IntPtr __注册BPai_NativeFunctionPtr;

		// Token: 0x0401570B RID: 87819
		private static IntPtr __烈度获取所有Actor_NativeFunctionPtr;

		// Token: 0x0401570C RID: 87820
		private static IntPtr __烈度返回NPC_NativeFunctionPtr;

		// Token: 0x0401570D RID: 87821
		private static IntPtr __阵营判断_NativeFunctionPtr;

		// Token: 0x0401570E RID: 87822
		private static IntPtr __初始化_NativeFunctionPtr;

		// Token: 0x0401570F RID: 87823
		private static IntPtr __战斗初始化_NativeFunctionPtr;

		// Token: 0x04015710 RID: 87824
		private static IntPtr __Tick_NativeFunctionPtr;

		// Token: 0x04015711 RID: 87825
		private static IntPtr __当阵容加载完成时_NativeFunctionPtr;

		// Token: 0x04015712 RID: 87826
		private static IntPtr __ExecuteUbergraph_BP_FightManager_NativeFunctionPtr;

		// Token: 0x0200A120 RID: 41248
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __RemoveDebugEntity_FunctionParams
		{
			// Token: 0x04032E4D RID: 208461
			[FieldOffset(0)]
			public int EntityId;

			// Token: 0x04032E4E RID: 208462
			[FieldOffset(8)]
			public FString ObjectName;
		}

		// Token: 0x0200A121 RID: 41249
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __AddDebugEntity_FunctionParams
		{
			// Token: 0x04032E4F RID: 208463
			[FieldOffset(0)]
			public int EntityId;

			// Token: 0x04032E50 RID: 208464
			[FieldOffset(8)]
			public FString ObjectName;
		}

		// Token: 0x0200A122 RID: 41250
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 296)]
		protected ref struct __查询受击类型覆盖_FunctionParams
		{
			// Token: 0x04032E51 RID: 208465
			[FieldOffset(0)]
			public int ID;

			// Token: 0x04032E52 RID: 208466
			[FieldOffset(8)]
			public byte 受击覆盖;

			// Token: 0x04032E53 RID: 208467
			[FieldOffset(48)]
			public bool 是否找到;
		}

		// Token: 0x0200A123 RID: 41251
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __站位控制_FunctionParams
		{
			// Token: 0x04032E54 RID: 208468
			[FieldOffset(0)]
			public byte 怪物数组;
		}

		// Token: 0x0200A124 RID: 41252
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __删除Debug的对象_FunctionParams
		{
			// Token: 0x04032E55 RID: 208469
			[FieldOffset(0)]
			public IntPtr baseChar;
		}

		// Token: 0x0200A125 RID: 41253
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __添加Debug的对象_FunctionParams
		{
			// Token: 0x04032E56 RID: 208470
			[FieldOffset(0)]
			public IntPtr baseChar;
		}

		// Token: 0x0200A126 RID: 41254
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __注册BPai_FunctionParams
		{
			// Token: 0x04032E57 RID: 208471
			[FieldOffset(0)]
			public IntPtr BPAI对象;
		}

		// Token: 0x0200A127 RID: 41255
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __阵营判断_FunctionParams
		{
			// Token: 0x04032E58 RID: 208472
			[FieldOffset(0)]
			public TEnumAsByte<ECamp> 自身阵营;

			// Token: 0x04032E59 RID: 208473
			[FieldOffset(1)]
			public TEnumAsByte<ECamp> 目标阵营;

			// Token: 0x04032E5A RID: 208474
			[FieldOffset(2)]
			public TEnumAsByte<ERelation> 关系;

			// Token: 0x04032E5B RID: 208475
			[FieldOffset(4)]
			public int 关系整数;
		}

		// Token: 0x0200A128 RID: 41256
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __初始化_FunctionParams
		{
			// Token: 0x04032E5C RID: 208476
			[FieldOffset(0)]
			public IntPtr 游戏实例;
		}

		// Token: 0x0200A129 RID: 41257
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Tick_FunctionParams
		{
			// Token: 0x04032E5D RID: 208477
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A12A RID: 41258
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_FightManager_FunctionParams
		{
			// Token: 0x04032E5E RID: 208478
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
