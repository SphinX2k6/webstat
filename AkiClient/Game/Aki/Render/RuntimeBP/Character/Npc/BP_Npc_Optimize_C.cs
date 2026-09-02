using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D62 RID: 15714
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/BP_Npc_Optimize.BP_Npc_Optimize_C")]
	[UnrealStructLayout(1032, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1032)]
	public class BP_Npc_Optimize_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060263A0 RID: 156576 RVA: 0x009D1DB8 File Offset: 0x009CFFB8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Npc_Optimize_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/Npc/BP_Npc_Optimize.BP_Npc_Optimize_C");
			}
			return BP_Npc_Optimize_C._ClassPtr;
		}

		// Token: 0x060263A1 RID: 156577 RVA: 0x009D1DDC File Offset: 0x009CFFDC
		public BP_Npc_Optimize_C() : this(BuiltinUtils.AllocNativeUObject(BP_Npc_Optimize_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060263A2 RID: 156578 RVA: 0x009D1E04 File Offset: 0x009D0004
		[NullableContext(1)]
		public BP_Npc_Optimize_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Npc_Optimize_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005615 RID: 22037
		// (get) Token: 0x060263A3 RID: 156579 RVA: 0x009D1E37 File Offset: 0x009D0037
		// (set) Token: 0x060263A4 RID: 156580 RVA: 0x009D1E4B File Offset: 0x009D004B
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Npc_Optimize_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Npc_Optimize_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060263A5 RID: 156581 RVA: 0x009D1E60 File Offset: 0x009D0060
		protected BP_Npc_Optimize_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013CFA RID: 81146
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/BP_Npc_Optimize.BP_Npc_Optimize_C";

		// Token: 0x04013CFB RID: 81147
		private static IntPtr _ClassPtr;

		// Token: 0x04013CFC RID: 81148
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013CFD RID: 81149
		internal static int __PropertyOffset_0;
	}
}
