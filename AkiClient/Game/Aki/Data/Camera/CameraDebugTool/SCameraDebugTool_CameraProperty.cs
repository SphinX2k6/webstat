using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Camera.CameraDebugTool
{
	// Token: 0x02003F19 RID: 16153
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraProperty.SCameraDebugTool_CameraProperty")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 21)]
	public class SCameraDebugTool_CameraProperty : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060284E1 RID: 165089 RVA: 0x00A0759C File Offset: 0x00A0579C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraDebugTool_CameraProperty._ScriptStructPtr != 0) ? SCameraDebugTool_CameraProperty._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraProperty.SCameraDebugTool_CameraProperty", ref SCameraDebugTool_CameraProperty._ScriptStructPtr);
		}

		// Token: 0x170061BB RID: 25019
		// (get) Token: 0x060284E2 RID: 165090 RVA: 0x00A075C0 File Offset: 0x00A057C0
		// (set) Token: 0x060284E3 RID: 165091 RVA: 0x00A075D4 File Offset: 0x00A057D4
		public unsafe string PropertyName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_CameraProperty.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCameraDebugTool_CameraProperty.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170061BC RID: 25020
		// (get) Token: 0x060284E4 RID: 165092 RVA: 0x00A075E9 File Offset: 0x00A057E9
		// (set) Token: 0x060284E5 RID: 165093 RVA: 0x00A075F9 File Offset: 0x00A057F9
		public unsafe float Value
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraDebugTool_CameraProperty.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraDebugTool_CameraProperty.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170061BD RID: 25021
		// (get) Token: 0x060284E6 RID: 165094 RVA: 0x00A0760A File Offset: 0x00A0580A
		// (set) Token: 0x060284E7 RID: 165095 RVA: 0x00A0761A File Offset: 0x00A0581A
		public unsafe bool IsEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraDebugTool_CameraProperty.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraDebugTool_CameraProperty.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x060284E8 RID: 165096 RVA: 0x00A0762B File Offset: 0x00A0582B
		public SCameraDebugTool_CameraProperty()
		{
		}

		// Token: 0x060284E9 RID: 165097 RVA: 0x00A07633 File Offset: 0x00A05833
		public SCameraDebugTool_CameraProperty(string PropertyName, float Value, bool IsEffect)
		{
			this.PropertyName = PropertyName;
			this.Value = Value;
			this.IsEffect = IsEffect;
		}

		// Token: 0x060284EA RID: 165098 RVA: 0x00A07650 File Offset: 0x00A05850
		protected override IntPtr GetUStructPtr()
		{
			return SCameraDebugTool_CameraProperty.StaticStruct();
		}

		// Token: 0x060284EB RID: 165099 RVA: 0x00A0765C File Offset: 0x00A0585C
		[NullableContext(2)]
		public SCameraDebugTool_CameraProperty(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060284EC RID: 165100 RVA: 0x00A07666 File Offset: 0x00A05866
		public SCameraDebugTool_CameraProperty(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060284ED RID: 165101 RVA: 0x00A07671 File Offset: 0x00A05871
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraDebugTool_CameraProperty(Pointer, false, true);
		}

		// Token: 0x060284EE RID: 165102 RVA: 0x00A0767B File Offset: 0x00A0587B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraDebugTool_CameraProperty(Pointer, MemoryOwner);
		}

		// Token: 0x04015332 RID: 86834
		public const string __ObjectPath = "/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraProperty.SCameraDebugTool_CameraProperty";

		// Token: 0x04015333 RID: 86835
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015334 RID: 86836
		internal static int __PropertyOffset_0;

		// Token: 0x04015335 RID: 86837
		internal static int __PropertyOffset_1;

		// Token: 0x04015336 RID: 86838
		internal static int __PropertyOffset_2;
	}
}
