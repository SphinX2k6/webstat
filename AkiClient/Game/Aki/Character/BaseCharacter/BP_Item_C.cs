using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041CB RID: 16843
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BP_Item.BP_Item_C")]
	[UnrealStructLayout(224, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 224)]
	public class BP_Item_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CCAB RID: 183467 RVA: 0x00AAFB60 File Offset: 0x00AADD60
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Item_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/BP_Item.BP_Item_C");
			}
			return BP_Item_C._ClassPtr;
		}

		// Token: 0x0602CCAC RID: 183468 RVA: 0x00AAFB84 File Offset: 0x00AADD84
		public BP_Item_C() : this(BuiltinUtils.AllocNativeUObject(BP_Item_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CCAD RID: 183469 RVA: 0x00AAFBAC File Offset: 0x00AADDAC
		[NullableContext(1)]
		public BP_Item_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Item_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007910 RID: 30992
		// (get) Token: 0x0602CCAE RID: 183470 RVA: 0x00AAFBDF File Offset: 0x00AADDDF
		// (set) Token: 0x0602CCAF RID: 183471 RVA: 0x00AAFBEF File Offset: 0x00AADDEF
		public unsafe int 注视优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Item_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Item_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007911 RID: 30993
		// (get) Token: 0x0602CCB0 RID: 183472 RVA: 0x00AAFC00 File Offset: 0x00AADE00
		// (set) Token: 0x0602CCB1 RID: 183473 RVA: 0x00AAFC14 File Offset: 0x00AADE14
		public unsafe TEnumAsByte<EEntityType> 实体类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Item_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Item_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007912 RID: 30994
		// (get) Token: 0x0602CCB2 RID: 183474 RVA: 0x00AAFC2C File Offset: 0x00AADE2C
		// (set) Token: 0x0602CCB3 RID: 183475 RVA: 0x00AAFC65 File Offset: 0x00AADE65
		[Nullable(1)]
		public TArray<FName> 可被注视的骨骼
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._可被注视的骨骼) == null)
				{
					result = (this._可被注视的骨骼 = new TArray<FName>(base.NativePtr + (IntPtr)BP_Item_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.可被注视的骨骼.CopyAssign(value);
			}
		}

		// Token: 0x0602CCB4 RID: 183476 RVA: 0x00AAFC73 File Offset: 0x00AADE73
		protected BP_Item_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018F65 RID: 102245
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BP_Item.BP_Item_C";

		// Token: 0x04018F66 RID: 102246
		private static IntPtr _ClassPtr;

		// Token: 0x04018F67 RID: 102247
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018F68 RID: 102248
		internal static int __PropertyOffset_0;

		// Token: 0x04018F69 RID: 102249
		internal static int __PropertyOffset_1;

		// Token: 0x04018F6A RID: 102250
		internal static int __PropertyOffset_2;

		// Token: 0x04018F6B RID: 102251
		[Nullable(2)]
		private TArray<FName> _可被注视的骨骼;
	}
}
