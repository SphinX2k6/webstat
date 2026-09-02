using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.ClothPath
{
	// Token: 0x02003C04 RID: 15364
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothPath/S_KuroCSClothPath.S_KuroCSClothPath")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class S_KuroCSClothPath : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06022D05 RID: 142597 RVA: 0x0096FF7B File Offset: 0x0096E17B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_KuroCSClothPath._ScriptStructPtr != 0) ? S_KuroCSClothPath._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothPath/S_KuroCSClothPath.S_KuroCSClothPath", ref S_KuroCSClothPath._ScriptStructPtr);
		}

		// Token: 0x170042DD RID: 17117
		// (get) Token: 0x06022D06 RID: 142598 RVA: 0x0096FF9F File Offset: 0x0096E19F
		// (set) Token: 0x06022D07 RID: 142599 RVA: 0x0096FFB3 File Offset: 0x0096E1B3
		[Nullable(2)]
		public unsafe UDataTable Table
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + S_KuroCSClothPath.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_KuroCSClothPath.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170042DE RID: 17118
		// (get) Token: 0x06022D08 RID: 142600 RVA: 0x0096FFC8 File Offset: 0x0096E1C8
		// (set) Token: 0x06022D09 RID: 142601 RVA: 0x0096FFD8 File Offset: 0x0096E1D8
		public unsafe float CollisionWorldRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPath.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPath.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170042DF RID: 17119
		// (get) Token: 0x06022D0A RID: 142602 RVA: 0x0096FFE9 File Offset: 0x0096E1E9
		// (set) Token: 0x06022D0B RID: 142603 RVA: 0x0096FFF9 File Offset: 0x0096E1F9
		public unsafe float UpOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPath.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPath.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170042E0 RID: 17120
		// (get) Token: 0x06022D0C RID: 142604 RVA: 0x0097000A File Offset: 0x0096E20A
		// (set) Token: 0x06022D0D RID: 142605 RVA: 0x0097001A File Offset: 0x0096E21A
		public unsafe int XCOUNT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPath.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPath.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170042E1 RID: 17121
		// (get) Token: 0x06022D0E RID: 142606 RVA: 0x0097002B File Offset: 0x0096E22B
		// (set) Token: 0x06022D0F RID: 142607 RVA: 0x0097003B File Offset: 0x0096E23B
		public unsafe int YCOUNT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPath.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPath.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170042E2 RID: 17122
		// (get) Token: 0x06022D10 RID: 142608 RVA: 0x0097004C File Offset: 0x0096E24C
		// (set) Token: 0x06022D11 RID: 142609 RVA: 0x0097005C File Offset: 0x0096E25C
		public unsafe float AttenuationPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_KuroCSClothPath.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_KuroCSClothPath.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170042E3 RID: 17123
		// (get) Token: 0x06022D12 RID: 142610 RVA: 0x00970070 File Offset: 0x0096E270
		// (set) Token: 0x06022D13 RID: 142611 RVA: 0x009700B3 File Offset: 0x0096E2B3
		public TArray<UMaterialInstance> mobileMat
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._mobileMat) == null)
				{
					result = (this._mobileMat = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)S_KuroCSClothPath.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.mobileMat.CopyAssign(value);
			}
		}

		// Token: 0x06022D14 RID: 142612 RVA: 0x009700C1 File Offset: 0x0096E2C1
		public S_KuroCSClothPath()
		{
		}

		// Token: 0x06022D15 RID: 142613 RVA: 0x009700C9 File Offset: 0x0096E2C9
		public S_KuroCSClothPath(UDataTable Table, float CollisionWorldRadius, float UpOffset, int XCOUNT, int YCOUNT, float AttenuationPower, TArray<UMaterialInstance> mobileMat)
		{
			this.Table = Table;
			this.CollisionWorldRadius = CollisionWorldRadius;
			this.UpOffset = UpOffset;
			this.XCOUNT = XCOUNT;
			this.YCOUNT = YCOUNT;
			this.AttenuationPower = AttenuationPower;
			this.mobileMat = mobileMat;
		}

		// Token: 0x06022D16 RID: 142614 RVA: 0x00970106 File Offset: 0x0096E306
		protected override IntPtr GetUStructPtr()
		{
			return S_KuroCSClothPath.StaticStruct();
		}

		// Token: 0x06022D17 RID: 142615 RVA: 0x00970112 File Offset: 0x0096E312
		[NullableContext(2)]
		public S_KuroCSClothPath(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06022D18 RID: 142616 RVA: 0x0097011C File Offset: 0x0096E31C
		public S_KuroCSClothPath(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06022D19 RID: 142617 RVA: 0x00970127 File Offset: 0x0096E327
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_KuroCSClothPath(Pointer, false, true);
		}

		// Token: 0x06022D1A RID: 142618 RVA: 0x00970131 File Offset: 0x0096E331
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_KuroCSClothPath(Pointer, MemoryOwner);
		}

		// Token: 0x04011AAD RID: 72365
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothPath/S_KuroCSClothPath.S_KuroCSClothPath";

		// Token: 0x04011AAE RID: 72366
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04011AAF RID: 72367
		internal static int __PropertyOffset_0;

		// Token: 0x04011AB0 RID: 72368
		internal static int __PropertyOffset_1;

		// Token: 0x04011AB1 RID: 72369
		internal static int __PropertyOffset_2;

		// Token: 0x04011AB2 RID: 72370
		internal static int __PropertyOffset_3;

		// Token: 0x04011AB3 RID: 72371
		internal static int __PropertyOffset_4;

		// Token: 0x04011AB4 RID: 72372
		internal static int __PropertyOffset_5;

		// Token: 0x04011AB5 RID: 72373
		internal static int __PropertyOffset_6;

		// Token: 0x04011AB6 RID: 72374
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _mobileMat;
	}
}
