using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.KuroSceneSwitch
{
	// Token: 0x02003C6D RID: 15469
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/KuroSceneSwitch/BP_KuroSceneSwitch.BP_KuroSceneSwitch_C")]
	[UnrealStructLayout(1216, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1212)]
	public class BP_KuroSceneSwitch_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023DFB RID: 146939 RVA: 0x0098E8D0 File Offset: 0x0098CAD0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroSceneSwitch_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/KuroSceneSwitch/BP_KuroSceneSwitch.BP_KuroSceneSwitch_C");
			}
			return BP_KuroSceneSwitch_C._ClassPtr;
		}

		// Token: 0x06023DFC RID: 146940 RVA: 0x0098E8F4 File Offset: 0x0098CAF4
		public BP_KuroSceneSwitch_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroSceneSwitch_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023DFD RID: 146941 RVA: 0x0098E91C File Offset: 0x0098CB1C
		public BP_KuroSceneSwitch_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroSceneSwitch_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170048CC RID: 18636
		// (get) Token: 0x06023DFE RID: 146942 RVA: 0x0098E94F File Offset: 0x0098CB4F
		// (set) Token: 0x06023DFF RID: 146943 RVA: 0x0098E963 File Offset: 0x0098CB63
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroSceneSwitch_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroSceneSwitch_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170048CD RID: 18637
		// (get) Token: 0x06023E00 RID: 146944 RVA: 0x0098E978 File Offset: 0x0098CB78
		// (set) Token: 0x06023E01 RID: 146945 RVA: 0x0098E9B1 File Offset: 0x0098CBB1
		public TSet<AActor> PrimitiveB
		{
			get
			{
				base.FastCheckIsValid();
				TSet<AActor> result;
				if ((result = this._PrimitiveB) == null)
				{
					result = (this._PrimitiveB = new TSet<AActor>(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.PrimitiveB.CopyAssign(value);
			}
		}

		// Token: 0x170048CE RID: 18638
		// (get) Token: 0x06023E02 RID: 146946 RVA: 0x0098E9C0 File Offset: 0x0098CBC0
		// (set) Token: 0x06023E03 RID: 146947 RVA: 0x0098E9F9 File Offset: 0x0098CBF9
		public TSet<AActor> PrimitiveA
		{
			get
			{
				base.FastCheckIsValid();
				TSet<AActor> result;
				if ((result = this._PrimitiveA) == null)
				{
					result = (this._PrimitiveA = new TSet<AActor>(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.PrimitiveA.CopyAssign(value);
			}
		}

		// Token: 0x170048CF RID: 18639
		// (get) Token: 0x06023E04 RID: 146948 RVA: 0x0098EA07 File Offset: 0x0098CC07
		// (set) Token: 0x06023E05 RID: 146949 RVA: 0x0098EA1B File Offset: 0x0098CC1B
		public unsafe FVector Sphere_Center
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170048D0 RID: 18640
		// (get) Token: 0x06023E06 RID: 146950 RVA: 0x0098EA30 File Offset: 0x0098CC30
		// (set) Token: 0x06023E07 RID: 146951 RVA: 0x0098EA40 File Offset: 0x0098CC40
		public unsafe float Sphere_Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170048D1 RID: 18641
		// (get) Token: 0x06023E08 RID: 146952 RVA: 0x0098EA51 File Offset: 0x0098CC51
		// (set) Token: 0x06023E09 RID: 146953 RVA: 0x0098EA61 File Offset: 0x0098CC61
		public unsafe float Edge_Width
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x06023E0A RID: 146954 RVA: 0x0098EA72 File Offset: 0x0098CC72
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Uninit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_C.__Uninit_NativeFunctionPtr, null);
		}

		// Token: 0x06023E0B RID: 146955 RVA: 0x0098EA86 File Offset: 0x0098CC86
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x06023E0C RID: 146956 RVA: 0x0098EA9A File Offset: 0x0098CC9A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CheckABOverlap()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_C.__CheckABOverlap_NativeFunctionPtr, null);
		}

		// Token: 0x06023E0D RID: 146957 RVA: 0x0098EAAE File Offset: 0x0098CCAE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UnInitSceneB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_C.__UnInitSceneB_NativeFunctionPtr, null);
		}

		// Token: 0x06023E0E RID: 146958 RVA: 0x0098EAC2 File Offset: 0x0098CCC2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UnInitSceneA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_C.__UnInitSceneA_NativeFunctionPtr, null);
		}

		// Token: 0x06023E0F RID: 146959 RVA: 0x0098EAD6 File Offset: 0x0098CCD6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetRadius()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_C.__SetRadius_NativeFunctionPtr, null);
		}

		// Token: 0x06023E10 RID: 146960 RVA: 0x0098EAEA File Offset: 0x0098CCEA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitSceneB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_C.__InitSceneB_NativeFunctionPtr, null);
		}

		// Token: 0x06023E11 RID: 146961 RVA: 0x0098EAFE File Offset: 0x0098CCFE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitSceneA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_C.__InitSceneA_NativeFunctionPtr, null);
		}

		// Token: 0x06023E12 RID: 146962 RVA: 0x0098EB12 File Offset: 0x0098CD12
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023E13 RID: 146963 RVA: 0x0098EB26 File Offset: 0x0098CD26
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroSceneSwitch_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023E14 RID: 146964 RVA: 0x0098EB3B File Offset: 0x0098CD3B
		protected BP_KuroSceneSwitch_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401251C RID: 75036
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/KuroSceneSwitch/BP_KuroSceneSwitch.BP_KuroSceneSwitch_C";

		// Token: 0x0401251D RID: 75037
		private static IntPtr _ClassPtr;

		// Token: 0x0401251E RID: 75038
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401251F RID: 75039
		internal static int __PropertyOffset_0;

		// Token: 0x04012520 RID: 75040
		internal static int __PropertyOffset_1;

		// Token: 0x04012521 RID: 75041
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<AActor> _PrimitiveB;

		// Token: 0x04012522 RID: 75042
		internal static int __PropertyOffset_2;

		// Token: 0x04012523 RID: 75043
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<AActor> _PrimitiveA;

		// Token: 0x04012524 RID: 75044
		internal static int __PropertyOffset_3;

		// Token: 0x04012525 RID: 75045
		internal static int __PropertyOffset_4;

		// Token: 0x04012526 RID: 75046
		internal static int __PropertyOffset_5;

		// Token: 0x04012527 RID: 75047
		private static IntPtr __Uninit_NativeFunctionPtr;

		// Token: 0x04012528 RID: 75048
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x04012529 RID: 75049
		private static IntPtr __CheckABOverlap_NativeFunctionPtr;

		// Token: 0x0401252A RID: 75050
		private static IntPtr __UnInitSceneB_NativeFunctionPtr;

		// Token: 0x0401252B RID: 75051
		private static IntPtr __UnInitSceneA_NativeFunctionPtr;

		// Token: 0x0401252C RID: 75052
		private static IntPtr __SetRadius_NativeFunctionPtr;

		// Token: 0x0401252D RID: 75053
		private static IntPtr __InitSceneB_NativeFunctionPtr;

		// Token: 0x0401252E RID: 75054
		private static IntPtr __InitSceneA_NativeFunctionPtr;

		// Token: 0x0401252F RID: 75055
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
