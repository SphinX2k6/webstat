using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.Common.View.Widget
{
	// Token: 0x02003985 RID: 14725
	[UnrealObjectPath("/Game/Aki/UI/Module/Common/View/Widget/KuroImage.KuroImage_C")]
	[UnrealStructLayout(1072, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1072)]
	public class KuroImage_C : UImage, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DAB8 RID: 121528 RVA: 0x008DCD9E File Offset: 0x008DAF9E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (KuroImage_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Module/Common/View/Widget/KuroImage.KuroImage_C");
			}
			return KuroImage_C._ClassPtr;
		}

		// Token: 0x0601DAB9 RID: 121529 RVA: 0x008DCDC4 File Offset: 0x008DAFC4
		public KuroImage_C() : this(BuiltinUtils.AllocNativeUObject(KuroImage_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DABA RID: 121530 RVA: 0x008DCDEC File Offset: 0x008DAFEC
		[NullableContext(1)]
		public KuroImage_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(KuroImage_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0601DABB RID: 121531 RVA: 0x008DCE1F File Offset: 0x008DB01F
		protected KuroImage_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E872 RID: 59506
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Module/Common/View/Widget/KuroImage.KuroImage_C";

		// Token: 0x0400E873 RID: 59507
		private static IntPtr _ClassPtr;

		// Token: 0x0400E874 RID: 59508
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
