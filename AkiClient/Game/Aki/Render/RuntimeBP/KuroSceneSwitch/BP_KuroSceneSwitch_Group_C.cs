using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.KuroSceneSwitch
{
	// Token: 0x02003C6E RID: 15470
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/KuroSceneSwitch/BP_KuroSceneSwitch_Group.BP_KuroSceneSwitch_Group_C")]
	[UnrealStructLayout(1128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1124)]
	public class BP_KuroSceneSwitch_Group_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023E15 RID: 146965 RVA: 0x0098EB44 File Offset: 0x0098CD44
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroSceneSwitch_Group_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/KuroSceneSwitch/BP_KuroSceneSwitch_Group.BP_KuroSceneSwitch_Group_C");
			}
			return BP_KuroSceneSwitch_Group_C._ClassPtr;
		}

		// Token: 0x06023E16 RID: 146966 RVA: 0x0098EB68 File Offset: 0x0098CD68
		public BP_KuroSceneSwitch_Group_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroSceneSwitch_Group_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023E17 RID: 146967 RVA: 0x0098EB90 File Offset: 0x0098CD90
		public BP_KuroSceneSwitch_Group_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroSceneSwitch_Group_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170048D2 RID: 18642
		// (get) Token: 0x06023E18 RID: 146968 RVA: 0x0098EBC3 File Offset: 0x0098CDC3
		// (set) Token: 0x06023E19 RID: 146969 RVA: 0x0098EBD7 File Offset: 0x0098CDD7
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroSceneSwitch_Group_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroSceneSwitch_Group_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170048D3 RID: 18643
		// (get) Token: 0x06023E1A RID: 146970 RVA: 0x0098EBEC File Offset: 0x0098CDEC
		// (set) Token: 0x06023E1B RID: 146971 RVA: 0x0098EC25 File Offset: 0x0098CE25
		public TSet<AActor> Primitive
		{
			get
			{
				base.FastCheckIsValid();
				TSet<AActor> result;
				if ((result = this._Primitive) == null)
				{
					result = (this._Primitive = new TSet<AActor>(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_Group_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.Primitive.CopyAssign(value);
			}
		}

		// Token: 0x170048D4 RID: 18644
		// (get) Token: 0x06023E1C RID: 146972 RVA: 0x0098EC33 File Offset: 0x0098CE33
		// (set) Token: 0x06023E1D RID: 146973 RVA: 0x0098EC43 File Offset: 0x0098CE43
		public unsafe float Sphere_Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_Group_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_Group_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170048D5 RID: 18645
		// (get) Token: 0x06023E1E RID: 146974 RVA: 0x0098EC54 File Offset: 0x0098CE54
		// (set) Token: 0x06023E1F RID: 146975 RVA: 0x0098EC64 File Offset: 0x0098CE64
		public unsafe float Edge_Width
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_Group_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_Group_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170048D6 RID: 18646
		// (get) Token: 0x06023E20 RID: 146976 RVA: 0x0098EC75 File Offset: 0x0098CE75
		// (set) Token: 0x06023E21 RID: 146977 RVA: 0x0098EC85 File Offset: 0x0098CE85
		public unsafe int Side
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_Group_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroSceneSwitch_Group_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x06023E22 RID: 146978 RVA: 0x0098EC96 File Offset: 0x0098CE96
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Uninit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_Group_C.__Uninit_NativeFunctionPtr, null);
		}

		// Token: 0x06023E23 RID: 146979 RVA: 0x0098ECAA File Offset: 0x0098CEAA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_Group_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x06023E24 RID: 146980 RVA: 0x0098ECBE File Offset: 0x0098CEBE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UnInitScene()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_Group_C.__UnInitScene_NativeFunctionPtr, null);
		}

		// Token: 0x06023E25 RID: 146981 RVA: 0x0098ECD2 File Offset: 0x0098CED2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetRadius()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_Group_C.__SetRadius_NativeFunctionPtr, null);
		}

		// Token: 0x06023E26 RID: 146982 RVA: 0x0098ECE6 File Offset: 0x0098CEE6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitScene()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSceneSwitch_Group_C.__InitScene_NativeFunctionPtr, null);
		}

		// Token: 0x06023E27 RID: 146983 RVA: 0x0098ECFA File Offset: 0x0098CEFA
		protected BP_KuroSceneSwitch_Group_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012530 RID: 75056
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/KuroSceneSwitch/BP_KuroSceneSwitch_Group.BP_KuroSceneSwitch_Group_C";

		// Token: 0x04012531 RID: 75057
		private static IntPtr _ClassPtr;

		// Token: 0x04012532 RID: 75058
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012533 RID: 75059
		internal static int __PropertyOffset_0;

		// Token: 0x04012534 RID: 75060
		internal static int __PropertyOffset_1;

		// Token: 0x04012535 RID: 75061
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<AActor> _Primitive;

		// Token: 0x04012536 RID: 75062
		internal static int __PropertyOffset_2;

		// Token: 0x04012537 RID: 75063
		internal static int __PropertyOffset_3;

		// Token: 0x04012538 RID: 75064
		internal static int __PropertyOffset_4;

		// Token: 0x04012539 RID: 75065
		private static IntPtr __Uninit_NativeFunctionPtr;

		// Token: 0x0401253A RID: 75066
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x0401253B RID: 75067
		private static IntPtr __UnInitScene_NativeFunctionPtr;

		// Token: 0x0401253C RID: 75068
		private static IntPtr __SetRadius_NativeFunctionPtr;

		// Token: 0x0401253D RID: 75069
		private static IntPtr __InitScene_NativeFunctionPtr;
	}
}
