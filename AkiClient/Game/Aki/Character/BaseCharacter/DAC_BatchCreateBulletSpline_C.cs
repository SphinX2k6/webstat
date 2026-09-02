using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041D3 RID: 16851
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/DAC_BatchCreateBulletSpline.DAC_BatchCreateBulletSpline_C")]
	[UnrealStructLayout(384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 384)]
	public class DAC_BatchCreateBulletSpline_C : DAC_BatchCreateBullet_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CD25 RID: 183589 RVA: 0x00AB099F File Offset: 0x00AAEB9F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (DAC_BatchCreateBulletSpline_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/DAC_BatchCreateBulletSpline.DAC_BatchCreateBulletSpline_C");
			}
			return DAC_BatchCreateBulletSpline_C._ClassPtr;
		}

		// Token: 0x0602CD26 RID: 183590 RVA: 0x00AB09C4 File Offset: 0x00AAEBC4
		public DAC_BatchCreateBulletSpline_C() : this(BuiltinUtils.AllocNativeUObject(DAC_BatchCreateBulletSpline_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CD27 RID: 183591 RVA: 0x00AB09EC File Offset: 0x00AAEBEC
		public DAC_BatchCreateBulletSpline_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(DAC_BatchCreateBulletSpline_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007939 RID: 31033
		// (get) Token: 0x0602CD28 RID: 183592 RVA: 0x00AB0A20 File Offset: 0x00AAEC20
		// (set) Token: 0x0602CD29 RID: 183593 RVA: 0x00AB0A59 File Offset: 0x00AAEC59
		public SBatchBulletPositionSpline Shape
		{
			get
			{
				base.FastCheckIsValid();
				SBatchBulletPositionSpline result;
				if ((result = this._Shape) == null)
				{
					result = (this._Shape = new SBatchBulletPositionSpline(base.NativePtr + (IntPtr)DAC_BatchCreateBulletSpline_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBatchBulletPositionSpline.StaticStruct(), base.NativePtr + (IntPtr)DAC_BatchCreateBulletSpline_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602CD2A RID: 183594 RVA: 0x00AB0A7A File Offset: 0x00AAEC7A
		protected DAC_BatchCreateBulletSpline_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018FBC RID: 102332
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/DAC_BatchCreateBulletSpline.DAC_BatchCreateBulletSpline_C";

		// Token: 0x04018FBD RID: 102333
		private static IntPtr _ClassPtr;

		// Token: 0x04018FBE RID: 102334
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018FBF RID: 102335
		internal new static int __PropertyOffset_0;

		// Token: 0x04018FC0 RID: 102336
		[Nullable(2)]
		private SBatchBulletPositionSpline _Shape;
	}
}
