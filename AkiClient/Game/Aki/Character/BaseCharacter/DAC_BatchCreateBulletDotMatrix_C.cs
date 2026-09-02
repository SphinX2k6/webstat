using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041D2 RID: 16850
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/DAC_BatchCreateBulletDotMatrix.DAC_BatchCreateBulletDotMatrix_C")]
	[UnrealStructLayout(208, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 208)]
	public class DAC_BatchCreateBulletDotMatrix_C : DAC_BatchCreateBullet_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CD1F RID: 183583 RVA: 0x00AB08BB File Offset: 0x00AAEABB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (DAC_BatchCreateBulletDotMatrix_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/DAC_BatchCreateBulletDotMatrix.DAC_BatchCreateBulletDotMatrix_C");
			}
			return DAC_BatchCreateBulletDotMatrix_C._ClassPtr;
		}

		// Token: 0x0602CD20 RID: 183584 RVA: 0x00AB08E0 File Offset: 0x00AAEAE0
		public DAC_BatchCreateBulletDotMatrix_C() : this(BuiltinUtils.AllocNativeUObject(DAC_BatchCreateBulletDotMatrix_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CD21 RID: 183585 RVA: 0x00AB0908 File Offset: 0x00AAEB08
		public DAC_BatchCreateBulletDotMatrix_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(DAC_BatchCreateBulletDotMatrix_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007938 RID: 31032
		// (get) Token: 0x0602CD22 RID: 183586 RVA: 0x00AB093C File Offset: 0x00AAEB3C
		// (set) Token: 0x0602CD23 RID: 183587 RVA: 0x00AB0975 File Offset: 0x00AAEB75
		public SBatchBulletPositionPointMatrix Shape
		{
			get
			{
				base.FastCheckIsValid();
				SBatchBulletPositionPointMatrix result;
				if ((result = this._Shape) == null)
				{
					result = (this._Shape = new SBatchBulletPositionPointMatrix(base.NativePtr + (IntPtr)DAC_BatchCreateBulletDotMatrix_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBatchBulletPositionPointMatrix.StaticStruct(), base.NativePtr + (IntPtr)DAC_BatchCreateBulletDotMatrix_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602CD24 RID: 183588 RVA: 0x00AB0996 File Offset: 0x00AAEB96
		protected DAC_BatchCreateBulletDotMatrix_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018FB7 RID: 102327
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/DAC_BatchCreateBulletDotMatrix.DAC_BatchCreateBulletDotMatrix_C";

		// Token: 0x04018FB8 RID: 102328
		private static IntPtr _ClassPtr;

		// Token: 0x04018FB9 RID: 102329
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018FBA RID: 102330
		internal new static int __PropertyOffset_0;

		// Token: 0x04018FBB RID: 102331
		[Nullable(2)]
		private SBatchBulletPositionPointMatrix _Shape;
	}
}
