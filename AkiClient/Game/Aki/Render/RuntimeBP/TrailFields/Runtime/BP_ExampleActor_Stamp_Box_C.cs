using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Drawers;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime
{
	// Token: 0x02003A27 RID: 14887
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_ExampleActor_Stamp_Box.BP_ExampleActor_Stamp_Box_C")]
	[UnrealStructLayout(1040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1040)]
	public class BP_ExampleActor_Stamp_Box_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EA00 RID: 125440 RVA: 0x008F9E20 File Offset: 0x008F8020
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ExampleActor_Stamp_Box_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_ExampleActor_Stamp_Box.BP_ExampleActor_Stamp_Box_C");
			}
			return BP_ExampleActor_Stamp_Box_C._ClassPtr;
		}

		// Token: 0x0601EA01 RID: 125441 RVA: 0x008F9E44 File Offset: 0x008F8044
		public BP_ExampleActor_Stamp_Box_C() : this(BuiltinUtils.AllocNativeUObject(BP_ExampleActor_Stamp_Box_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EA02 RID: 125442 RVA: 0x008F9E6C File Offset: 0x008F806C
		[NullableContext(1)]
		public BP_ExampleActor_Stamp_Box_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ExampleActor_Stamp_Box_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002B91 RID: 11153
		// (get) Token: 0x0601EA03 RID: 125443 RVA: 0x008F9E9F File Offset: 0x008F809F
		// (set) Token: 0x0601EA04 RID: 125444 RVA: 0x008F9EB3 File Offset: 0x008F80B3
		public unsafe UStaticMeshComponent Cube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ExampleActor_Stamp_Box_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ExampleActor_Stamp_Box_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17002B92 RID: 11154
		// (get) Token: 0x0601EA05 RID: 125445 RVA: 0x008F9EC8 File Offset: 0x008F80C8
		// (set) Token: 0x0601EA06 RID: 125446 RVA: 0x008F9EDC File Offset: 0x008F80DC
		public unsafe BP_TrailDrawComponent_Stamp_C DrawComponent_Stamp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_TrailDrawComponent_Stamp_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ExampleActor_Stamp_Box_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ExampleActor_Stamp_Box_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0601EA07 RID: 125447 RVA: 0x008F9EF1 File Offset: 0x008F80F1
		protected BP_ExampleActor_Stamp_Box_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F198 RID: 61848
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_ExampleActor_Stamp_Box.BP_ExampleActor_Stamp_Box_C";

		// Token: 0x0400F199 RID: 61849
		private static IntPtr _ClassPtr;

		// Token: 0x0400F19A RID: 61850
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F19B RID: 61851
		internal static int __PropertyOffset_0;

		// Token: 0x0400F19C RID: 61852
		internal static int __PropertyOffset_1;
	}
}
