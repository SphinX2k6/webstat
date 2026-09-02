using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.System.GlobalMapOverride
{
	// Token: 0x02003A3E RID: 14910
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/System/GlobalMapOverride/BP_KuroGlobalMapOverrideVolume.BP_KuroGlobalMapOverrideVolume_C")]
	[UnrealStructLayout(1040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1040)]
	public class BP_KuroGlobalMapOverrideVolume_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EC30 RID: 126000 RVA: 0x008FDE84 File Offset: 0x008FC084
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroGlobalMapOverrideVolume_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/System/GlobalMapOverride/BP_KuroGlobalMapOverrideVolume.BP_KuroGlobalMapOverrideVolume_C");
			}
			return BP_KuroGlobalMapOverrideVolume_C._ClassPtr;
		}

		// Token: 0x0601EC31 RID: 126001 RVA: 0x008FDEA8 File Offset: 0x008FC0A8
		public BP_KuroGlobalMapOverrideVolume_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroGlobalMapOverrideVolume_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EC32 RID: 126002 RVA: 0x008FDED0 File Offset: 0x008FC0D0
		[NullableContext(1)]
		public BP_KuroGlobalMapOverrideVolume_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroGlobalMapOverrideVolume_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002C42 RID: 11330
		// (get) Token: 0x0601EC33 RID: 126003 RVA: 0x008FDF03 File Offset: 0x008FC103
		// (set) Token: 0x0601EC34 RID: 126004 RVA: 0x008FDF17 File Offset: 0x008FC117
		public unsafe UKuroGlobalMapOverrideComponent KuroGlobalMapOverride
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGlobalMapOverrideComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroGlobalMapOverrideVolume_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroGlobalMapOverrideVolume_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17002C43 RID: 11331
		// (get) Token: 0x0601EC35 RID: 126005 RVA: 0x008FDF2C File Offset: 0x008FC12C
		// (set) Token: 0x0601EC36 RID: 126006 RVA: 0x008FDF40 File Offset: 0x008FC140
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroGlobalMapOverrideVolume_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroGlobalMapOverrideVolume_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0601EC37 RID: 126007 RVA: 0x008FDF55 File Offset: 0x008FC155
		protected BP_KuroGlobalMapOverrideVolume_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F2FA RID: 62202
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/System/GlobalMapOverride/BP_KuroGlobalMapOverrideVolume.BP_KuroGlobalMapOverrideVolume_C";

		// Token: 0x0400F2FB RID: 62203
		private static IntPtr _ClassPtr;

		// Token: 0x0400F2FC RID: 62204
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F2FD RID: 62205
		internal static int __PropertyOffset_0;

		// Token: 0x0400F2FE RID: 62206
		internal static int __PropertyOffset_1;
	}
}
