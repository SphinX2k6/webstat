using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003EC8 RID: 16072
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SCameraLockOnConfig.SCameraLockOnConfig")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SCameraLockOnConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027ED9 RID: 163545 RVA: 0x009FE2E0 File Offset: 0x009FC4E0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraLockOnConfig._ScriptStructPtr != 0) ? SCameraLockOnConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SCameraLockOnConfig.SCameraLockOnConfig", ref SCameraLockOnConfig._ScriptStructPtr);
		}

		// Token: 0x17005F90 RID: 24464
		// (get) Token: 0x06027EDA RID: 163546 RVA: 0x009FE304 File Offset: 0x009FC504
		// (set) Token: 0x06027EDB RID: 163547 RVA: 0x009FE314 File Offset: 0x009FC514
		public unsafe bool IsEnabled
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraLockOnConfig.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraLockOnConfig.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005F91 RID: 24465
		// (get) Token: 0x06027EDC RID: 163548 RVA: 0x009FE325 File Offset: 0x009FC525
		// (set) Token: 0x06027EDD RID: 163549 RVA: 0x009FE339 File Offset: 0x009FC539
		public unsafe string CameraLockOnBoneName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCameraLockOnConfig.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCameraLockOnConfig.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x06027EDE RID: 163550 RVA: 0x009FE34E File Offset: 0x009FC54E
		public SCameraLockOnConfig()
		{
		}

		// Token: 0x06027EDF RID: 163551 RVA: 0x009FE356 File Offset: 0x009FC556
		public SCameraLockOnConfig(bool IsEnabled, string CameraLockOnBoneName)
		{
			this.IsEnabled = IsEnabled;
			this.CameraLockOnBoneName = CameraLockOnBoneName;
		}

		// Token: 0x06027EE0 RID: 163552 RVA: 0x009FE36C File Offset: 0x009FC56C
		protected override IntPtr GetUStructPtr()
		{
			return SCameraLockOnConfig.StaticStruct();
		}

		// Token: 0x06027EE1 RID: 163553 RVA: 0x009FE378 File Offset: 0x009FC578
		[NullableContext(2)]
		public SCameraLockOnConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027EE2 RID: 163554 RVA: 0x009FE382 File Offset: 0x009FC582
		public SCameraLockOnConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027EE3 RID: 163555 RVA: 0x009FE38D File Offset: 0x009FC58D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraLockOnConfig(Pointer, false, true);
		}

		// Token: 0x06027EE4 RID: 163556 RVA: 0x009FE397 File Offset: 0x009FC597
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraLockOnConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014F66 RID: 85862
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SCameraLockOnConfig.SCameraLockOnConfig";

		// Token: 0x04014F67 RID: 85863
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014F68 RID: 85864
		internal static int __PropertyOffset_0;

		// Token: 0x04014F69 RID: 85865
		internal static int __PropertyOffset_1;
	}
}
