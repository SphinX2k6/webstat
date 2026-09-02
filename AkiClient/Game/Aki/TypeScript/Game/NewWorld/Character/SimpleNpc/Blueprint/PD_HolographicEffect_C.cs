using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.TypeScript.Game.NewWorld.Character.SimpleNpc.Blueprint
{
	// Token: 0x020039BE RID: 14782
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/PD_HolographicEffect.PD_HolographicEffect_C")]
	[UnrealStructLayout(296, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 290)]
	public class PD_HolographicEffect_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DE06 RID: 122374 RVA: 0x008E59B8 File Offset: 0x008E3BB8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_HolographicEffect_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/PD_HolographicEffect.PD_HolographicEffect_C");
			}
			return PD_HolographicEffect_C._ClassPtr;
		}

		// Token: 0x0601DE07 RID: 122375 RVA: 0x008E59DC File Offset: 0x008E3BDC
		public PD_HolographicEffect_C() : this(BuiltinUtils.AllocNativeUObject(PD_HolographicEffect_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DE08 RID: 122376 RVA: 0x008E5A04 File Offset: 0x008E3C04
		public PD_HolographicEffect_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_HolographicEffect_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700279B RID: 10139
		// (get) Token: 0x0601DE09 RID: 122377 RVA: 0x008E5A37 File Offset: 0x008E3C37
		// (set) Token: 0x0601DE0A RID: 122378 RVA: 0x008E5A47 File Offset: 0x008E3C47
		public unsafe float Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700279C RID: 10140
		// (get) Token: 0x0601DE0B RID: 122379 RVA: 0x008E5A58 File Offset: 0x008E3C58
		// (set) Token: 0x0601DE0C RID: 122380 RVA: 0x008E5A68 File Offset: 0x008E3C68
		public unsafe float Loop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700279D RID: 10141
		// (get) Token: 0x0601DE0D RID: 122381 RVA: 0x008E5A79 File Offset: 0x008E3C79
		// (set) Token: 0x0601DE0E RID: 122382 RVA: 0x008E5A89 File Offset: 0x008E3C89
		public unsafe float End
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700279E RID: 10142
		// (get) Token: 0x0601DE0F RID: 122383 RVA: 0x008E5A9C File Offset: 0x008E3C9C
		// (set) Token: 0x0601DE10 RID: 122384 RVA: 0x008E5AD5 File Offset: 0x008E3CD5
		public SHolographicData OutlineData
		{
			get
			{
				base.FastCheckIsValid();
				SHolographicData result;
				if ((result = this._OutlineData) == null)
				{
					result = (this._OutlineData = new SHolographicData(base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SHolographicData.StaticStruct(), base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700279F RID: 10143
		// (get) Token: 0x0601DE11 RID: 122385 RVA: 0x008E5AF8 File Offset: 0x008E3CF8
		// (set) Token: 0x0601DE12 RID: 122386 RVA: 0x008E5B31 File Offset: 0x008E3D31
		public SHolographicData OtherData
		{
			get
			{
				base.FastCheckIsValid();
				SHolographicData result;
				if ((result = this._OtherData) == null)
				{
					result = (this._OtherData = new SHolographicData(base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SHolographicData.StaticStruct(), base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170027A0 RID: 10144
		// (get) Token: 0x0601DE13 RID: 122387 RVA: 0x008E5B52 File Offset: 0x008E3D52
		// (set) Token: 0x0601DE14 RID: 122388 RVA: 0x008E5B62 File Offset: 0x008E3D62
		public unsafe bool CanSkipLoopUpdate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170027A1 RID: 10145
		// (get) Token: 0x0601DE15 RID: 122389 RVA: 0x008E5B73 File Offset: 0x008E3D73
		// (set) Token: 0x0601DE16 RID: 122390 RVA: 0x008E5B83 File Offset: 0x008E3D83
		public unsafe bool ExtraUpdateOnStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_HolographicEffect_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601DE17 RID: 122391 RVA: 0x008E5B94 File Offset: 0x008E3D94
		protected PD_HolographicEffect_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EA29 RID: 59945
		public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/PD_HolographicEffect.PD_HolographicEffect_C";

		// Token: 0x0400EA2A RID: 59946
		private static IntPtr _ClassPtr;

		// Token: 0x0400EA2B RID: 59947
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EA2C RID: 59948
		internal static int __PropertyOffset_0;

		// Token: 0x0400EA2D RID: 59949
		internal static int __PropertyOffset_1;

		// Token: 0x0400EA2E RID: 59950
		internal static int __PropertyOffset_2;

		// Token: 0x0400EA2F RID: 59951
		internal static int __PropertyOffset_3;

		// Token: 0x0400EA30 RID: 59952
		[Nullable(2)]
		private SHolographicData _OutlineData;

		// Token: 0x0400EA31 RID: 59953
		internal static int __PropertyOffset_4;

		// Token: 0x0400EA32 RID: 59954
		[Nullable(2)]
		private SHolographicData _OtherData;

		// Token: 0x0400EA33 RID: 59955
		internal static int __PropertyOffset_5;

		// Token: 0x0400EA34 RID: 59956
		internal static int __PropertyOffset_6;
	}
}
