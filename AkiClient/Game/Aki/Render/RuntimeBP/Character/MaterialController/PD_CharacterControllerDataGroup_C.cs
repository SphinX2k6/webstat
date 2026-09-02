using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D7B RID: 15739
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CharacterControllerDataGroup.PD_CharacterControllerDataGroup_C")]
	[UnrealStructLayout(168, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 162)]
	public class PD_CharacterControllerDataGroup_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602661F RID: 157215 RVA: 0x009D640F File Offset: 0x009D460F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_CharacterControllerDataGroup_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CharacterControllerDataGroup.PD_CharacterControllerDataGroup_C");
			}
			return PD_CharacterControllerDataGroup_C._ClassPtr;
		}

		// Token: 0x06026620 RID: 157216 RVA: 0x009D6434 File Offset: 0x009D4634
		public PD_CharacterControllerDataGroup_C() : this(BuiltinUtils.AllocNativeUObject(PD_CharacterControllerDataGroup_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026621 RID: 157217 RVA: 0x009D645C File Offset: 0x009D465C
		public PD_CharacterControllerDataGroup_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_CharacterControllerDataGroup_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005707 RID: 22279
		// (get) Token: 0x06026622 RID: 157218 RVA: 0x009D6490 File Offset: 0x009D4690
		// (set) Token: 0x06026623 RID: 157219 RVA: 0x009D64C9 File Offset: 0x009D46C9
		public TMap<PD_CharacterControllerData_C, float> DataMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<PD_CharacterControllerData_C, float> result;
				if ((result = this._DataMap) == null)
				{
					result = (this._DataMap = new TMap<PD_CharacterControllerData_C, float>(base.NativePtr + (IntPtr)PD_CharacterControllerDataGroup_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.DataMap.CopyAssign(value);
			}
		}

		// Token: 0x17005708 RID: 22280
		// (get) Token: 0x06026624 RID: 157220 RVA: 0x009D64D7 File Offset: 0x009D46D7
		// (set) Token: 0x06026625 RID: 157221 RVA: 0x009D64E7 File Offset: 0x009D46E7
		public unsafe bool IgnoreTimeDilation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerDataGroup_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerDataGroup_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005709 RID: 22281
		// (get) Token: 0x06026626 RID: 157222 RVA: 0x009D64F8 File Offset: 0x009D46F8
		// (set) Token: 0x06026627 RID: 157223 RVA: 0x009D6508 File Offset: 0x009D4708
		public unsafe bool CleanOriginEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerDataGroup_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerDataGroup_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x06026628 RID: 157224 RVA: 0x009D6519 File Offset: 0x009D4719
		protected PD_CharacterControllerDataGroup_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013ECC RID: 81612
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CharacterControllerDataGroup.PD_CharacterControllerDataGroup_C";

		// Token: 0x04013ECD RID: 81613
		private static IntPtr _ClassPtr;

		// Token: 0x04013ECE RID: 81614
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013ECF RID: 81615
		internal static int __PropertyOffset_0;

		// Token: 0x04013ED0 RID: 81616
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<PD_CharacterControllerData_C, float> _DataMap;

		// Token: 0x04013ED1 RID: 81617
		internal static int __PropertyOffset_1;

		// Token: 0x04013ED2 RID: 81618
		internal static int __PropertyOffset_2;
	}
}
