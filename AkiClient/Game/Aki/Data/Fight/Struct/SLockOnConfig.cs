using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ED1 RID: 16081
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SLockOnConfig.SLockOnConfig")]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SLockOnConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027F7D RID: 163709 RVA: 0x009FF47D File Offset: 0x009FD67D
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SLockOnConfig._ScriptStructPtr != 0) ? SLockOnConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SLockOnConfig.SLockOnConfig", ref SLockOnConfig._ScriptStructPtr);
		}

		// Token: 0x17005FBF RID: 24511
		// (get) Token: 0x06027F7E RID: 163710 RVA: 0x009FF4A1 File Offset: 0x009FD6A1
		// (set) Token: 0x06027F7F RID: 163711 RVA: 0x009FF4B1 File Offset: 0x009FD6B1
		public unsafe bool IsOpened
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnConfig.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnConfig.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FC0 RID: 24512
		// (get) Token: 0x06027F80 RID: 163712 RVA: 0x009FF4C2 File Offset: 0x009FD6C2
		// (set) Token: 0x06027F81 RID: 163713 RVA: 0x009FF4D2 File Offset: 0x009FD6D2
		public unsafe float Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005FC1 RID: 24513
		// (get) Token: 0x06027F82 RID: 163714 RVA: 0x009FF4E3 File Offset: 0x009FD6E3
		// (set) Token: 0x06027F83 RID: 163715 RVA: 0x009FF4F3 File Offset: 0x009FD6F3
		public unsafe float UpDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005FC2 RID: 24514
		// (get) Token: 0x06027F84 RID: 163716 RVA: 0x009FF504 File Offset: 0x009FD704
		// (set) Token: 0x06027F85 RID: 163717 RVA: 0x009FF514 File Offset: 0x009FD714
		public unsafe float DownDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06027F86 RID: 163718 RVA: 0x009FF525 File Offset: 0x009FD725
		public SLockOnConfig()
		{
		}

		// Token: 0x06027F87 RID: 163719 RVA: 0x009FF52D File Offset: 0x009FD72D
		public SLockOnConfig(bool IsOpened, float Distance, float UpDistance, float DownDistance)
		{
			this.IsOpened = IsOpened;
			this.Distance = Distance;
			this.UpDistance = UpDistance;
			this.DownDistance = DownDistance;
		}

		// Token: 0x06027F88 RID: 163720 RVA: 0x009FF552 File Offset: 0x009FD752
		protected override IntPtr GetUStructPtr()
		{
			return SLockOnConfig.StaticStruct();
		}

		// Token: 0x06027F89 RID: 163721 RVA: 0x009FF55E File Offset: 0x009FD75E
		[NullableContext(2)]
		public SLockOnConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027F8A RID: 163722 RVA: 0x009FF568 File Offset: 0x009FD768
		public SLockOnConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027F8B RID: 163723 RVA: 0x009FF573 File Offset: 0x009FD773
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SLockOnConfig(Pointer, false, true);
		}

		// Token: 0x06027F8C RID: 163724 RVA: 0x009FF57D File Offset: 0x009FD77D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SLockOnConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014FBF RID: 85951
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SLockOnConfig.SLockOnConfig";

		// Token: 0x04014FC0 RID: 85952
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014FC1 RID: 85953
		internal static int __PropertyOffset_0;

		// Token: 0x04014FC2 RID: 85954
		internal static int __PropertyOffset_1;

		// Token: 0x04014FC3 RID: 85955
		internal static int __PropertyOffset_2;

		// Token: 0x04014FC4 RID: 85956
		internal static int __PropertyOffset_3;
	}
}
