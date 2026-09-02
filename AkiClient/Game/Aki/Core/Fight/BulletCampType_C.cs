using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F4E RID: 16206
	[UnrealObjectPath("/Game/Aki/Core/Fight/BulletCampType.BulletCampType_C")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 84)]
	public class BulletCampType_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028827 RID: 165927 RVA: 0x00A0D936 File Offset: 0x00A0BB36
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BulletCampType_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/Fight/BulletCampType.BulletCampType_C");
			}
			return BulletCampType_C._ClassPtr;
		}

		// Token: 0x06028828 RID: 165928 RVA: 0x00A0D95C File Offset: 0x00A0BB5C
		public BulletCampType_C() : this(BuiltinUtils.AllocNativeUObject(BulletCampType_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028829 RID: 165929 RVA: 0x00A0D984 File Offset: 0x00A0BB84
		[NullableContext(1)]
		public BulletCampType_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BulletCampType_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700629A RID: 25242
		// (get) Token: 0x0602882A RID: 165930 RVA: 0x00A0D9B7 File Offset: 0x00A0BBB7
		// (set) Token: 0x0602882B RID: 165931 RVA: 0x00A0D9C7 File Offset: 0x00A0BBC7
		public unsafe int 阵营
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BulletCampType_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BulletCampType_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602882C RID: 165932 RVA: 0x00A0D9D8 File Offset: 0x00A0BBD8
		protected BulletCampType_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015519 RID: 87321
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/Fight/BulletCampType.BulletCampType_C";

		// Token: 0x0401551A RID: 87322
		private static IntPtr _ClassPtr;

		// Token: 0x0401551B RID: 87323
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401551C RID: 87324
		internal static int __PropertyOffset_0;
	}
}
