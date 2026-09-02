using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SceneViedoPlay
{
	// Token: 0x02003B29 RID: 15145
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneViedoPlay/PDA_MediaPlayDataAsset.PDA_MediaPlayDataAsset_C")]
	[UnrealStructLayout(128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 128)]
	public class PDA_MediaPlayDataAsset_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020A6A RID: 133738 RVA: 0x00932CF3 File Offset: 0x00930EF3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_MediaPlayDataAsset_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneViedoPlay/PDA_MediaPlayDataAsset.PDA_MediaPlayDataAsset_C");
			}
			return PDA_MediaPlayDataAsset_C._ClassPtr;
		}

		// Token: 0x06020A6B RID: 133739 RVA: 0x00932D18 File Offset: 0x00930F18
		public PDA_MediaPlayDataAsset_C() : this(BuiltinUtils.AllocNativeUObject(PDA_MediaPlayDataAsset_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020A6C RID: 133740 RVA: 0x00932D40 File Offset: 0x00930F40
		[NullableContext(1)]
		public PDA_MediaPlayDataAsset_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_MediaPlayDataAsset_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003692 RID: 13970
		// (get) Token: 0x06020A6D RID: 133741 RVA: 0x00932D73 File Offset: 0x00930F73
		// (set) Token: 0x06020A6E RID: 133742 RVA: 0x00932D87 File Offset: 0x00930F87
		public unsafe UStaticMesh StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_MediaPlayDataAsset_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_MediaPlayDataAsset_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003693 RID: 13971
		// (get) Token: 0x06020A6F RID: 133743 RVA: 0x00932D9C File Offset: 0x00930F9C
		// (set) Token: 0x06020A70 RID: 133744 RVA: 0x00932DAC File Offset: 0x00930FAC
		public unsafe int MaterialIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_MediaPlayDataAsset_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_MediaPlayDataAsset_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17003694 RID: 13972
		// (get) Token: 0x06020A71 RID: 133745 RVA: 0x00932DBD File Offset: 0x00930FBD
		// (set) Token: 0x06020A72 RID: 133746 RVA: 0x00932DD1 File Offset: 0x00930FD1
		public unsafe UMediaSource MediaSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaSource>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_MediaPlayDataAsset_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_MediaPlayDataAsset_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003695 RID: 13973
		// (get) Token: 0x06020A73 RID: 133747 RVA: 0x00932DE6 File Offset: 0x00930FE6
		// (set) Token: 0x06020A74 RID: 133748 RVA: 0x00932DFA File Offset: 0x00930FFA
		public unsafe UAkAudioEvent AkEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_MediaPlayDataAsset_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_MediaPlayDataAsset_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003696 RID: 13974
		// (get) Token: 0x06020A75 RID: 133749 RVA: 0x00932E0F File Offset: 0x0093100F
		// (set) Token: 0x06020A76 RID: 133750 RVA: 0x00932E23 File Offset: 0x00931023
		public unsafe UMediaSource MediaSource_Male
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaSource>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_MediaPlayDataAsset_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_MediaPlayDataAsset_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003697 RID: 13975
		// (get) Token: 0x06020A77 RID: 133751 RVA: 0x00932E38 File Offset: 0x00931038
		// (set) Token: 0x06020A78 RID: 133752 RVA: 0x00932E4C File Offset: 0x0093104C
		public unsafe UMediaSource MediaSource_Female
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaSource>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_MediaPlayDataAsset_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_MediaPlayDataAsset_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x06020A79 RID: 133753 RVA: 0x00932E61 File Offset: 0x00931061
		protected PDA_MediaPlayDataAsset_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010599 RID: 66969
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneViedoPlay/PDA_MediaPlayDataAsset.PDA_MediaPlayDataAsset_C";

		// Token: 0x0401059A RID: 66970
		private static IntPtr _ClassPtr;

		// Token: 0x0401059B RID: 66971
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401059C RID: 66972
		internal static int __PropertyOffset_0;

		// Token: 0x0401059D RID: 66973
		internal static int __PropertyOffset_1;

		// Token: 0x0401059E RID: 66974
		internal static int __PropertyOffset_2;

		// Token: 0x0401059F RID: 66975
		internal static int __PropertyOffset_3;

		// Token: 0x040105A0 RID: 66976
		internal static int __PropertyOffset_4;

		// Token: 0x040105A1 RID: 66977
		internal static int __PropertyOffset_5;
	}
}
