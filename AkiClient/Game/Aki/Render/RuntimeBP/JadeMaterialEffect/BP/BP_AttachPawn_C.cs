using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.JadeMaterialEffect.BP
{
	// Token: 0x02003C72 RID: 15474
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/JadeMaterialEffect/BP/BP_AttachPawn.BP_AttachPawn_C")]
	[UnrealStructLayout(1032, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1032)]
	public class BP_AttachPawn_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023E84 RID: 147076 RVA: 0x0098F4EF File Offset: 0x0098D6EF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AttachPawn_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/JadeMaterialEffect/BP/BP_AttachPawn.BP_AttachPawn_C");
			}
			return BP_AttachPawn_C._ClassPtr;
		}

		// Token: 0x06023E85 RID: 147077 RVA: 0x0098F514 File Offset: 0x0098D714
		public BP_AttachPawn_C() : this(BuiltinUtils.AllocNativeUObject(BP_AttachPawn_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023E86 RID: 147078 RVA: 0x0098F53C File Offset: 0x0098D73C
		[NullableContext(1)]
		public BP_AttachPawn_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AttachPawn_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170048FB RID: 18683
		// (get) Token: 0x06023E87 RID: 147079 RVA: 0x0098F56F File Offset: 0x0098D76F
		// (set) Token: 0x06023E88 RID: 147080 RVA: 0x0098F583 File Offset: 0x0098D783
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AttachPawn_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AttachPawn_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06023E89 RID: 147081 RVA: 0x0098F598 File Offset: 0x0098D798
		protected BP_AttachPawn_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012572 RID: 75122
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/JadeMaterialEffect/BP/BP_AttachPawn.BP_AttachPawn_C";

		// Token: 0x04012573 RID: 75123
		private static IntPtr _ClassPtr;

		// Token: 0x04012574 RID: 75124
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012575 RID: 75125
		internal static int __PropertyOffset_0;
	}
}
