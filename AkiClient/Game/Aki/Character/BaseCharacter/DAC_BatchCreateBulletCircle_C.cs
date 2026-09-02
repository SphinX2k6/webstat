using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041D1 RID: 16849
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/DAC_BatchCreateBulletCircle.DAC_BatchCreateBulletCircle_C")]
	[UnrealStructLayout(248, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 248)]
	public class DAC_BatchCreateBulletCircle_C : DAC_BatchCreateBullet_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CD19 RID: 183577 RVA: 0x00AB07D6 File Offset: 0x00AAE9D6
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (DAC_BatchCreateBulletCircle_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/DAC_BatchCreateBulletCircle.DAC_BatchCreateBulletCircle_C");
			}
			return DAC_BatchCreateBulletCircle_C._ClassPtr;
		}

		// Token: 0x0602CD1A RID: 183578 RVA: 0x00AB07FC File Offset: 0x00AAE9FC
		public DAC_BatchCreateBulletCircle_C() : this(BuiltinUtils.AllocNativeUObject(DAC_BatchCreateBulletCircle_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CD1B RID: 183579 RVA: 0x00AB0824 File Offset: 0x00AAEA24
		public DAC_BatchCreateBulletCircle_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(DAC_BatchCreateBulletCircle_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007937 RID: 31031
		// (get) Token: 0x0602CD1C RID: 183580 RVA: 0x00AB0858 File Offset: 0x00AAEA58
		// (set) Token: 0x0602CD1D RID: 183581 RVA: 0x00AB0891 File Offset: 0x00AAEA91
		public SBatchBulletPositionCircle Shape
		{
			get
			{
				base.FastCheckIsValid();
				SBatchBulletPositionCircle result;
				if ((result = this._Shape) == null)
				{
					result = (this._Shape = new SBatchBulletPositionCircle(base.NativePtr + (IntPtr)DAC_BatchCreateBulletCircle_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBatchBulletPositionCircle.StaticStruct(), base.NativePtr + (IntPtr)DAC_BatchCreateBulletCircle_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602CD1E RID: 183582 RVA: 0x00AB08B2 File Offset: 0x00AAEAB2
		protected DAC_BatchCreateBulletCircle_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018FB2 RID: 102322
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/DAC_BatchCreateBulletCircle.DAC_BatchCreateBulletCircle_C";

		// Token: 0x04018FB3 RID: 102323
		private static IntPtr _ClassPtr;

		// Token: 0x04018FB4 RID: 102324
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018FB5 RID: 102325
		internal new static int __PropertyOffset_0;

		// Token: 0x04018FB6 RID: 102326
		[Nullable(2)]
		private SBatchBulletPositionCircle _Shape;
	}
}
