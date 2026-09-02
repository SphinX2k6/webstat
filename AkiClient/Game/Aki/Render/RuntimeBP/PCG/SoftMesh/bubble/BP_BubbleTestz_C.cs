using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SoftMesh.bubble
{
	// Token: 0x02003B70 RID: 15216
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/bubble/BP_BubbleTestz.BP_BubbleTestz_C")]
	[UnrealStructLayout(1032, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1032)]
	public class BP_BubbleTestz_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060217EF RID: 137199 RVA: 0x0094AD18 File Offset: 0x00948F18
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BubbleTestz_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/bubble/BP_BubbleTestz.BP_BubbleTestz_C");
			}
			return BP_BubbleTestz_C._ClassPtr;
		}

		// Token: 0x060217F0 RID: 137200 RVA: 0x0094AD3C File Offset: 0x00948F3C
		public BP_BubbleTestz_C() : this(BuiltinUtils.AllocNativeUObject(BP_BubbleTestz_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060217F1 RID: 137201 RVA: 0x0094AD64 File Offset: 0x00948F64
		[NullableContext(1)]
		public BP_BubbleTestz_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BubbleTestz_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003B75 RID: 15221
		// (get) Token: 0x060217F2 RID: 137202 RVA: 0x0094AD97 File Offset: 0x00948F97
		// (set) Token: 0x060217F3 RID: 137203 RVA: 0x0094ADAB File Offset: 0x00948FAB
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleTestz_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleTestz_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060217F4 RID: 137204 RVA: 0x0094ADC0 File Offset: 0x00948FC0
		protected BP_BubbleTestz_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010DE4 RID: 69092
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/bubble/BP_BubbleTestz.BP_BubbleTestz_C";

		// Token: 0x04010DE5 RID: 69093
		private static IntPtr _ClassPtr;

		// Token: 0x04010DE6 RID: 69094
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010DE7 RID: 69095
		internal static int __PropertyOffset_0;
	}
}
