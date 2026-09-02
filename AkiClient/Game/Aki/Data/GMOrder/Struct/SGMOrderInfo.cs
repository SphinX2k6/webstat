using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.GMOrder.Struct
{
	// Token: 0x02003E90 RID: 16016
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/GMOrder/Struct/SGMOrderInfo.SGMOrderInfo")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SGMOrderInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027AAF RID: 162479 RVA: 0x009F78A2 File Offset: 0x009F5AA2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SGMOrderInfo._ScriptStructPtr != 0) ? SGMOrderInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/GMOrder/Struct/SGMOrderInfo.SGMOrderInfo", ref SGMOrderInfo._ScriptStructPtr);
		}

		// Token: 0x17005E2E RID: 24110
		// (get) Token: 0x06027AB0 RID: 162480 RVA: 0x009F78C6 File Offset: 0x009F5AC6
		// (set) Token: 0x06027AB1 RID: 162481 RVA: 0x009F78DA File Offset: 0x009F5ADA
		public unsafe FName Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGMOrderInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGMOrderInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005E2F RID: 24111
		// (get) Token: 0x06027AB2 RID: 162482 RVA: 0x009F78EF File Offset: 0x009F5AEF
		// (set) Token: 0x06027AB3 RID: 162483 RVA: 0x009F7903 File Offset: 0x009F5B03
		public unsafe string Code
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SGMOrderInfo.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SGMOrderInfo.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x06027AB4 RID: 162484 RVA: 0x009F7918 File Offset: 0x009F5B18
		public SGMOrderInfo()
		{
		}

		// Token: 0x06027AB5 RID: 162485 RVA: 0x009F7920 File Offset: 0x009F5B20
		public SGMOrderInfo(FName Name, string Code)
		{
			this.Name = Name;
			this.Code = Code;
		}

		// Token: 0x06027AB6 RID: 162486 RVA: 0x009F7936 File Offset: 0x009F5B36
		protected override IntPtr GetUStructPtr()
		{
			return SGMOrderInfo.StaticStruct();
		}

		// Token: 0x06027AB7 RID: 162487 RVA: 0x009F7942 File Offset: 0x009F5B42
		[NullableContext(2)]
		public SGMOrderInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027AB8 RID: 162488 RVA: 0x009F794C File Offset: 0x009F5B4C
		public SGMOrderInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027AB9 RID: 162489 RVA: 0x009F7957 File Offset: 0x009F5B57
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SGMOrderInfo(Pointer, false, true);
		}

		// Token: 0x06027ABA RID: 162490 RVA: 0x009F7961 File Offset: 0x009F5B61
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SGMOrderInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04014CE5 RID: 85221
		public const string __ObjectPath = "/Game/Aki/Data/GMOrder/Struct/SGMOrderInfo.SGMOrderInfo";

		// Token: 0x04014CE6 RID: 85222
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014CE7 RID: 85223
		internal static int __PropertyOffset_0;

		// Token: 0x04014CE8 RID: 85224
		internal static int __PropertyOffset_1;
	}
}
