using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Sequence.Struct
{
	// Token: 0x02003E06 RID: 15878
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Sequence/Struct/SpineThingsInfo.SpineThingsInfo")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 17)]
	public class SpineThingsInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060271E3 RID: 160227 RVA: 0x009EA3EF File Offset: 0x009E85EF
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SpineThingsInfo._ScriptStructPtr != 0) ? SpineThingsInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Sequence/Struct/SpineThingsInfo.SpineThingsInfo", ref SpineThingsInfo._ScriptStructPtr);
		}

		// Token: 0x17005B31 RID: 23345
		// (get) Token: 0x060271E4 RID: 160228 RVA: 0x009EA413 File Offset: 0x009E8613
		// (set) Token: 0x060271E5 RID: 160229 RVA: 0x009EA427 File Offset: 0x009E8627
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SpineThingsInfo.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SpineThingsInfo.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005B32 RID: 23346
		// (get) Token: 0x060271E6 RID: 160230 RVA: 0x009EA43C File Offset: 0x009E863C
		// (set) Token: 0x060271E7 RID: 160231 RVA: 0x009EA44C File Offset: 0x009E864C
		public unsafe bool NeedLoop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SpineThingsInfo.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SpineThingsInfo.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x060271E8 RID: 160232 RVA: 0x009EA45D File Offset: 0x009E865D
		public SpineThingsInfo()
		{
		}

		// Token: 0x060271E9 RID: 160233 RVA: 0x009EA465 File Offset: 0x009E8665
		public SpineThingsInfo(string Name, bool NeedLoop)
		{
			this.Name = Name;
			this.NeedLoop = NeedLoop;
		}

		// Token: 0x060271EA RID: 160234 RVA: 0x009EA47B File Offset: 0x009E867B
		protected override IntPtr GetUStructPtr()
		{
			return SpineThingsInfo.StaticStruct();
		}

		// Token: 0x060271EB RID: 160235 RVA: 0x009EA487 File Offset: 0x009E8687
		[NullableContext(2)]
		public SpineThingsInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060271EC RID: 160236 RVA: 0x009EA491 File Offset: 0x009E8691
		public SpineThingsInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060271ED RID: 160237 RVA: 0x009EA49C File Offset: 0x009E869C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SpineThingsInfo(Pointer, false, true);
		}

		// Token: 0x060271EE RID: 160238 RVA: 0x009EA4A6 File Offset: 0x009E86A6
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SpineThingsInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04014710 RID: 83728
		public const string __ObjectPath = "/Game/Aki/Data/Sequence/Struct/SpineThingsInfo.SpineThingsInfo";

		// Token: 0x04014711 RID: 83729
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014712 RID: 83730
		internal static int __PropertyOffset_0;

		// Token: 0x04014713 RID: 83731
		internal static int __PropertyOffset_1;
	}
}
