using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ED7 RID: 16087
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SOcclusionDitherConfig.SOcclusionDitherConfig")]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SOcclusionDitherConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602800B RID: 163851 RVA: 0x00A0013A File Offset: 0x009FE33A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SOcclusionDitherConfig._ScriptStructPtr != 0) ? SOcclusionDitherConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SOcclusionDitherConfig.SOcclusionDitherConfig", ref SOcclusionDitherConfig._ScriptStructPtr);
		}

		// Token: 0x17005FEE RID: 24558
		// (get) Token: 0x0602800C RID: 163852 RVA: 0x00A0015E File Offset: 0x009FE35E
		// (set) Token: 0x0602800D RID: 163853 RVA: 0x00A0016E File Offset: 0x009FE36E
		public unsafe bool bEnableOcclusionDither
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SOcclusionDitherConfig.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SOcclusionDitherConfig.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FEF RID: 24559
		// (get) Token: 0x0602800E RID: 163854 RVA: 0x00A0017F File Offset: 0x009FE37F
		// (set) Token: 0x0602800F RID: 163855 RVA: 0x00A0018F File Offset: 0x009FE38F
		public unsafe float OcclusionDitherValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SOcclusionDitherConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SOcclusionDitherConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005FF0 RID: 24560
		// (get) Token: 0x06028010 RID: 163856 RVA: 0x00A001A0 File Offset: 0x009FE3A0
		// (set) Token: 0x06028011 RID: 163857 RVA: 0x00A001B0 File Offset: 0x009FE3B0
		public unsafe float OcclusionDitherInterpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SOcclusionDitherConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SOcclusionDitherConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005FF1 RID: 24561
		// (get) Token: 0x06028012 RID: 163858 RVA: 0x00A001C1 File Offset: 0x009FE3C1
		// (set) Token: 0x06028013 RID: 163859 RVA: 0x00A001D5 File Offset: 0x009FE3D5
		public unsafe FGameplayTag IgnoreOcclusionDitherTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SOcclusionDitherConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SOcclusionDitherConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06028014 RID: 163860 RVA: 0x00A001EA File Offset: 0x009FE3EA
		public SOcclusionDitherConfig()
		{
		}

		// Token: 0x06028015 RID: 163861 RVA: 0x00A001F2 File Offset: 0x009FE3F2
		public SOcclusionDitherConfig(bool bEnableOcclusionDither, float OcclusionDitherValue, float OcclusionDitherInterpSpeed, FGameplayTag IgnoreOcclusionDitherTag)
		{
			this.bEnableOcclusionDither = bEnableOcclusionDither;
			this.OcclusionDitherValue = OcclusionDitherValue;
			this.OcclusionDitherInterpSpeed = OcclusionDitherInterpSpeed;
			this.IgnoreOcclusionDitherTag = IgnoreOcclusionDitherTag;
		}

		// Token: 0x06028016 RID: 163862 RVA: 0x00A00217 File Offset: 0x009FE417
		protected override IntPtr GetUStructPtr()
		{
			return SOcclusionDitherConfig.StaticStruct();
		}

		// Token: 0x06028017 RID: 163863 RVA: 0x00A00223 File Offset: 0x009FE423
		[NullableContext(2)]
		public SOcclusionDitherConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028018 RID: 163864 RVA: 0x00A0022D File Offset: 0x009FE42D
		public SOcclusionDitherConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028019 RID: 163865 RVA: 0x00A00238 File Offset: 0x009FE438
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SOcclusionDitherConfig(Pointer, false, true);
		}

		// Token: 0x0602801A RID: 163866 RVA: 0x00A00242 File Offset: 0x009FE442
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SOcclusionDitherConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04015003 RID: 86019
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SOcclusionDitherConfig.SOcclusionDitherConfig";

		// Token: 0x04015004 RID: 86020
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015005 RID: 86021
		internal static int __PropertyOffset_0;

		// Token: 0x04015006 RID: 86022
		internal static int __PropertyOffset_1;

		// Token: 0x04015007 RID: 86023
		internal static int __PropertyOffset_2;

		// Token: 0x04015008 RID: 86024
		internal static int __PropertyOffset_3;
	}
}
