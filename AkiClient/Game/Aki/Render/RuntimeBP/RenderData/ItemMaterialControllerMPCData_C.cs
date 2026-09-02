using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.RenderData
{
	// Token: 0x02003B34 RID: 15156
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/RenderData/ItemMaterialControllerMPCData.ItemMaterialControllerMPCData_C")]
	[UnrealStructLayout(240, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 240)]
	public class ItemMaterialControllerMPCData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020B80 RID: 134016 RVA: 0x00934F87 File Offset: 0x00933187
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ItemMaterialControllerMPCData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/RenderData/ItemMaterialControllerMPCData.ItemMaterialControllerMPCData_C");
			}
			return ItemMaterialControllerMPCData_C._ClassPtr;
		}

		// Token: 0x06020B81 RID: 134017 RVA: 0x00934FAC File Offset: 0x009331AC
		public ItemMaterialControllerMPCData_C() : this(BuiltinUtils.AllocNativeUObject(ItemMaterialControllerMPCData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020B82 RID: 134018 RVA: 0x00934FD4 File Offset: 0x009331D4
		public ItemMaterialControllerMPCData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ItemMaterialControllerMPCData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170036DF RID: 14047
		// (get) Token: 0x06020B83 RID: 134019 RVA: 0x00935008 File Offset: 0x00933208
		// (set) Token: 0x06020B84 RID: 134020 RVA: 0x00935041 File Offset: 0x00933241
		public TMap<string, FLinearColor> Vector
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, FLinearColor> result;
				if ((result = this._Vector) == null)
				{
					result = (this._Vector = new TMap<string, FLinearColor>(base.NativePtr + (IntPtr)ItemMaterialControllerMPCData_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.Vector.CopyAssign(value);
			}
		}

		// Token: 0x170036E0 RID: 14048
		// (get) Token: 0x06020B85 RID: 134021 RVA: 0x00935050 File Offset: 0x00933250
		// (set) Token: 0x06020B86 RID: 134022 RVA: 0x00935089 File Offset: 0x00933289
		public TMap<string, float> Scalar
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, float> result;
				if ((result = this._Scalar) == null)
				{
					result = (this._Scalar = new TMap<string, float>(base.NativePtr + (IntPtr)ItemMaterialControllerMPCData_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.Scalar.CopyAssign(value);
			}
		}

		// Token: 0x06020B87 RID: 134023 RVA: 0x00935097 File Offset: 0x00933297
		protected ItemMaterialControllerMPCData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401064C RID: 67148
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/RenderData/ItemMaterialControllerMPCData.ItemMaterialControllerMPCData_C";

		// Token: 0x0401064D RID: 67149
		private static IntPtr _ClassPtr;

		// Token: 0x0401064E RID: 67150
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401064F RID: 67151
		internal static int __PropertyOffset_0;

		// Token: 0x04010650 RID: 67152
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, FLinearColor> _Vector;

		// Token: 0x04010651 RID: 67153
		internal static int __PropertyOffset_1;

		// Token: 0x04010652 RID: 67154
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, float> _Scalar;
	}
}
