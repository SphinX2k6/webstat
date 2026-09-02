using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.PathLine
{
	// Token: 0x02003E50 RID: 15952
	[UnrealObjectPath("/Game/Aki/Data/PathLine/BP_Miaozhunxian_Bullet.BP_Miaozhunxian_Bullet_C")]
	[UnrealStructLayout(1032, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1032)]
	public class BP_Miaozhunxian_Bullet_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060275CC RID: 161228 RVA: 0x009F00E8 File Offset: 0x009EE2E8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Miaozhunxian_Bullet_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/PathLine/BP_Miaozhunxian_Bullet.BP_Miaozhunxian_Bullet_C");
			}
			return BP_Miaozhunxian_Bullet_C._ClassPtr;
		}

		// Token: 0x060275CD RID: 161229 RVA: 0x009F010C File Offset: 0x009EE30C
		public BP_Miaozhunxian_Bullet_C() : this(BuiltinUtils.AllocNativeUObject(BP_Miaozhunxian_Bullet_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060275CE RID: 161230 RVA: 0x009F0134 File Offset: 0x009EE334
		[NullableContext(1)]
		public BP_Miaozhunxian_Bullet_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Miaozhunxian_Bullet_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005C69 RID: 23657
		// (get) Token: 0x060275CF RID: 161231 RVA: 0x009F0167 File Offset: 0x009EE367
		// (set) Token: 0x060275D0 RID: 161232 RVA: 0x009F017B File Offset: 0x009EE37B
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Miaozhunxian_Bullet_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Miaozhunxian_Bullet_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060275D1 RID: 161233 RVA: 0x009F0190 File Offset: 0x009EE390
		protected BP_Miaozhunxian_Bullet_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040149B9 RID: 84409
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/PathLine/BP_Miaozhunxian_Bullet.BP_Miaozhunxian_Bullet_C";

		// Token: 0x040149BA RID: 84410
		private static IntPtr _ClassPtr;

		// Token: 0x040149BB RID: 84411
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040149BC RID: 84412
		internal static int __PropertyOffset_0;
	}
}
