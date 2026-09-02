using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.UiCameraAnimation.Struct
{
	// Token: 0x02003DFE RID: 15870
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/UiCameraAnimation/Struct/SUiCameraFightPhotographSettings.SUiCameraFightPhotographSettings")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class SUiCameraFightPhotographSettings : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602713B RID: 160059 RVA: 0x009E9630 File Offset: 0x009E7830
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SUiCameraFightPhotographSettings._ScriptStructPtr != 0) ? SUiCameraFightPhotographSettings._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/UiCameraAnimation/Struct/SUiCameraFightPhotographSettings.SUiCameraFightPhotographSettings", ref SUiCameraFightPhotographSettings._ScriptStructPtr);
		}

		// Token: 0x17005AE9 RID: 23273
		// (get) Token: 0x0602713C RID: 160060 RVA: 0x009E9654 File Offset: 0x009E7854
		// (set) Token: 0x0602713D RID: 160061 RVA: 0x009E9668 File Offset: 0x009E7868
		public unsafe string Description
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SUiCameraFightPhotographSettings.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SUiCameraFightPhotographSettings.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005AEA RID: 23274
		// (get) Token: 0x0602713E RID: 160062 RVA: 0x009E967D File Offset: 0x009E787D
		// (set) Token: 0x0602713F RID: 160063 RVA: 0x009E9691 File Offset: 0x009E7891
		public unsafe FVectorDouble Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraFightPhotographSettings.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraFightPhotographSettings.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005AEB RID: 23275
		// (get) Token: 0x06027140 RID: 160064 RVA: 0x009E96A6 File Offset: 0x009E78A6
		// (set) Token: 0x06027141 RID: 160065 RVA: 0x009E96BA File Offset: 0x009E78BA
		public unsafe FRotator Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraFightPhotographSettings.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraFightPhotographSettings.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005AEC RID: 23276
		// (get) Token: 0x06027142 RID: 160066 RVA: 0x009E96CF File Offset: 0x009E78CF
		// (set) Token: 0x06027143 RID: 160067 RVA: 0x009E96DF File Offset: 0x009E78DF
		public unsafe int Fov
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraFightPhotographSettings.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraFightPhotographSettings.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06027144 RID: 160068 RVA: 0x009E96F0 File Offset: 0x009E78F0
		public SUiCameraFightPhotographSettings()
		{
		}

		// Token: 0x06027145 RID: 160069 RVA: 0x009E96F8 File Offset: 0x009E78F8
		public SUiCameraFightPhotographSettings(string Description, FVectorDouble Location, FRotator Rotation, int Fov)
		{
			this.Description = Description;
			this.Location = Location;
			this.Rotation = Rotation;
			this.Fov = Fov;
		}

		// Token: 0x06027146 RID: 160070 RVA: 0x009E971D File Offset: 0x009E791D
		protected override IntPtr GetUStructPtr()
		{
			return SUiCameraFightPhotographSettings.StaticStruct();
		}

		// Token: 0x06027147 RID: 160071 RVA: 0x009E9729 File Offset: 0x009E7929
		[NullableContext(2)]
		public SUiCameraFightPhotographSettings(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027148 RID: 160072 RVA: 0x009E9733 File Offset: 0x009E7933
		public SUiCameraFightPhotographSettings(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027149 RID: 160073 RVA: 0x009E973E File Offset: 0x009E793E
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SUiCameraFightPhotographSettings(Pointer, false, true);
		}

		// Token: 0x0602714A RID: 160074 RVA: 0x009E9748 File Offset: 0x009E7948
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SUiCameraFightPhotographSettings(Pointer, MemoryOwner);
		}

		// Token: 0x04014693 RID: 83603
		public const string __ObjectPath = "/Game/Aki/Data/UiCameraAnimation/Struct/SUiCameraFightPhotographSettings.SUiCameraFightPhotographSettings";

		// Token: 0x04014694 RID: 83604
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014695 RID: 83605
		internal static int __PropertyOffset_0;

		// Token: 0x04014696 RID: 83606
		internal static int __PropertyOffset_1;

		// Token: 0x04014697 RID: 83607
		internal static int __PropertyOffset_2;

		// Token: 0x04014698 RID: 83608
		internal static int __PropertyOffset_3;
	}
}
