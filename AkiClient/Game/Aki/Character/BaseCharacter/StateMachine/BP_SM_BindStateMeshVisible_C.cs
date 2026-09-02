using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042BD RID: 17085
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateMeshVisible.BP_SM_BindStateMeshVisible_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 66)]
	public class BP_SM_BindStateMeshVisible_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D57D RID: 185725 RVA: 0x00ABD960 File Offset: 0x00ABBB60
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateMeshVisible_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateMeshVisible.BP_SM_BindStateMeshVisible_C");
			}
			return BP_SM_BindStateMeshVisible_C._ClassPtr;
		}

		// Token: 0x0602D57E RID: 185726 RVA: 0x00ABD984 File Offset: 0x00ABBB84
		public BP_SM_BindStateMeshVisible_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateMeshVisible_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D57F RID: 185727 RVA: 0x00ABD9AC File Offset: 0x00ABBBAC
		public BP_SM_BindStateMeshVisible_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateMeshVisible_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BA3 RID: 31651
		// (get) Token: 0x0602D580 RID: 185728 RVA: 0x00ABD9DF File Offset: 0x00ABBBDF
		// (set) Token: 0x0602D581 RID: 185729 RVA: 0x00ABD9F3 File Offset: 0x00ABBBF3
		public unsafe string Tag
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_BindStateMeshVisible_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_BindStateMeshVisible_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007BA4 RID: 31652
		// (get) Token: 0x0602D582 RID: 185730 RVA: 0x00ABDA08 File Offset: 0x00ABBC08
		// (set) Token: 0x0602D583 RID: 185731 RVA: 0x00ABDA18 File Offset: 0x00ABBC18
		public unsafe bool 显示
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateMeshVisible_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateMeshVisible_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BA5 RID: 31653
		// (get) Token: 0x0602D584 RID: 185732 RVA: 0x00ABDA29 File Offset: 0x00ABBC29
		// (set) Token: 0x0602D585 RID: 185733 RVA: 0x00ABDA39 File Offset: 0x00ABBC39
		public unsafe bool 包含所有子节点
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateMeshVisible_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateMeshVisible_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D586 RID: 185734 RVA: 0x00ABDA4A File Offset: 0x00ABBC4A
		protected BP_SM_BindStateMeshVisible_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196D3 RID: 104147
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateMeshVisible.BP_SM_BindStateMeshVisible_C";

		// Token: 0x040196D4 RID: 104148
		private static IntPtr _ClassPtr;

		// Token: 0x040196D5 RID: 104149
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196D6 RID: 104150
		internal static int __PropertyOffset_0;

		// Token: 0x040196D7 RID: 104151
		internal static int __PropertyOffset_1;

		// Token: 0x040196D8 RID: 104152
		internal static int __PropertyOffset_2;
	}
}
