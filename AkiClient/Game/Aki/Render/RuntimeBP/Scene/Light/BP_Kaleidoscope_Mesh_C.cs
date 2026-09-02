using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A85 RID: 14981
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_Kaleidoscope_Mesh.BP_Kaleidoscope_Mesh_C")]
	[UnrealStructLayout(1904, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1904)]
	public class BP_Kaleidoscope_Mesh_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F669 RID: 128617 RVA: 0x00910A68 File Offset: 0x0090EC68
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Kaleidoscope_Mesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_Kaleidoscope_Mesh.BP_Kaleidoscope_Mesh_C");
			}
			return BP_Kaleidoscope_Mesh_C._ClassPtr;
		}

		// Token: 0x0601F66A RID: 128618 RVA: 0x00910A8C File Offset: 0x0090EC8C
		public BP_Kaleidoscope_Mesh_C() : this(BuiltinUtils.AllocNativeUObject(BP_Kaleidoscope_Mesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F66B RID: 128619 RVA: 0x00910AB4 File Offset: 0x0090ECB4
		[NullableContext(1)]
		public BP_Kaleidoscope_Mesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Kaleidoscope_Mesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002FAE RID: 12206
		// (get) Token: 0x0601F66C RID: 128620 RVA: 0x00910AE8 File Offset: 0x0090ECE8
		// (set) Token: 0x0601F66D RID: 128621 RVA: 0x00910B21 File Offset: 0x0090ED21
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002FAF RID: 12207
		// (get) Token: 0x0601F66E RID: 128622 RVA: 0x00910B42 File Offset: 0x0090ED42
		// (set) Token: 0x0601F66F RID: 128623 RVA: 0x00910B56 File Offset: 0x0090ED56
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002FB0 RID: 12208
		// (get) Token: 0x0601F670 RID: 128624 RVA: 0x00910B6B File Offset: 0x0090ED6B
		// (set) Token: 0x0601F671 RID: 128625 RVA: 0x00910B7F File Offset: 0x0090ED7F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002FB1 RID: 12209
		// (get) Token: 0x0601F672 RID: 128626 RVA: 0x00910B94 File Offset: 0x0090ED94
		// (set) Token: 0x0601F673 RID: 128627 RVA: 0x00910BA8 File Offset: 0x0090EDA8
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002FB2 RID: 12210
		// (get) Token: 0x0601F674 RID: 128628 RVA: 0x00910BC0 File Offset: 0x0090EDC0
		// (set) Token: 0x0601F675 RID: 128629 RVA: 0x00910BF9 File Offset: 0x0090EDF9
		[Nullable(1)]
		public TMap<FName, float> Scalar_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002FB3 RID: 12211
		// (get) Token: 0x0601F676 RID: 128630 RVA: 0x00910C08 File Offset: 0x0090EE08
		// (set) Token: 0x0601F677 RID: 128631 RVA: 0x00910C41 File Offset: 0x0090EE41
		[Nullable(1)]
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002FB4 RID: 12212
		// (get) Token: 0x0601F678 RID: 128632 RVA: 0x00910C50 File Offset: 0x0090EE50
		// (set) Token: 0x0601F679 RID: 128633 RVA: 0x00910C89 File Offset: 0x0090EE89
		[Nullable(1)]
		public TMap<FName, UTexture> Texture_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002FB5 RID: 12213
		// (get) Token: 0x0601F67A RID: 128634 RVA: 0x00910C97 File Offset: 0x0090EE97
		// (set) Token: 0x0601F67B RID: 128635 RVA: 0x00910CA7 File Offset: 0x0090EEA7
		public unsafe float Distance0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002FB6 RID: 12214
		// (get) Token: 0x0601F67C RID: 128636 RVA: 0x00910CB8 File Offset: 0x0090EEB8
		// (set) Token: 0x0601F67D RID: 128637 RVA: 0x00910CCC File Offset: 0x0090EECC
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17002FB7 RID: 12215
		// (get) Token: 0x0601F67E RID: 128638 RVA: 0x00910CE1 File Offset: 0x0090EEE1
		// (set) Token: 0x0601F67F RID: 128639 RVA: 0x00910CF1 File Offset: 0x0090EEF1
		public unsafe float HollowRadius0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002FB8 RID: 12216
		// (get) Token: 0x0601F680 RID: 128640 RVA: 0x00910D02 File Offset: 0x0090EF02
		// (set) Token: 0x0601F681 RID: 128641 RVA: 0x00910D12 File Offset: 0x0090EF12
		public unsafe float Rotation0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002FB9 RID: 12217
		// (get) Token: 0x0601F682 RID: 128642 RVA: 0x00910D23 File Offset: 0x0090EF23
		// (set) Token: 0x0601F683 RID: 128643 RVA: 0x00910D33 File Offset: 0x0090EF33
		public unsafe float Segment0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002FBA RID: 12218
		// (get) Token: 0x0601F684 RID: 128644 RVA: 0x00910D44 File Offset: 0x0090EF44
		// (set) Token: 0x0601F685 RID: 128645 RVA: 0x00910D58 File Offset: 0x0090EF58
		public unsafe UTexture2D Texture0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17002FBB RID: 12219
		// (get) Token: 0x0601F686 RID: 128646 RVA: 0x00910D6D File Offset: 0x0090EF6D
		// (set) Token: 0x0601F687 RID: 128647 RVA: 0x00910D7D File Offset: 0x0090EF7D
		public unsafe float Twist0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002FBC RID: 12220
		// (get) Token: 0x0601F688 RID: 128648 RVA: 0x00910D8E File Offset: 0x0090EF8E
		// (set) Token: 0x0601F689 RID: 128649 RVA: 0x00910D9E File Offset: 0x0090EF9E
		public unsafe float Distance1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002FBD RID: 12221
		// (get) Token: 0x0601F68A RID: 128650 RVA: 0x00910DAF File Offset: 0x0090EFAF
		// (set) Token: 0x0601F68B RID: 128651 RVA: 0x00910DBF File Offset: 0x0090EFBF
		public unsafe float HollowRadius1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002FBE RID: 12222
		// (get) Token: 0x0601F68C RID: 128652 RVA: 0x00910DD0 File Offset: 0x0090EFD0
		// (set) Token: 0x0601F68D RID: 128653 RVA: 0x00910DE0 File Offset: 0x0090EFE0
		public unsafe float Rotation1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002FBF RID: 12223
		// (get) Token: 0x0601F68E RID: 128654 RVA: 0x00910DF1 File Offset: 0x0090EFF1
		// (set) Token: 0x0601F68F RID: 128655 RVA: 0x00910E01 File Offset: 0x0090F001
		public unsafe float Segment1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002FC0 RID: 12224
		// (get) Token: 0x0601F690 RID: 128656 RVA: 0x00910E12 File Offset: 0x0090F012
		// (set) Token: 0x0601F691 RID: 128657 RVA: 0x00910E26 File Offset: 0x0090F026
		public unsafe UTexture2D Texture1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17002FC1 RID: 12225
		// (get) Token: 0x0601F692 RID: 128658 RVA: 0x00910E3B File Offset: 0x0090F03B
		// (set) Token: 0x0601F693 RID: 128659 RVA: 0x00910E4B File Offset: 0x0090F04B
		public unsafe float Twist1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002FC2 RID: 12226
		// (get) Token: 0x0601F694 RID: 128660 RVA: 0x00910E5C File Offset: 0x0090F05C
		// (set) Token: 0x0601F695 RID: 128661 RVA: 0x00910E6C File Offset: 0x0090F06C
		public unsafe float Distance2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002FC3 RID: 12227
		// (get) Token: 0x0601F696 RID: 128662 RVA: 0x00910E7D File Offset: 0x0090F07D
		// (set) Token: 0x0601F697 RID: 128663 RVA: 0x00910E8D File Offset: 0x0090F08D
		public unsafe float HollowRadius2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002FC4 RID: 12228
		// (get) Token: 0x0601F698 RID: 128664 RVA: 0x00910E9E File Offset: 0x0090F09E
		// (set) Token: 0x0601F699 RID: 128665 RVA: 0x00910EAE File Offset: 0x0090F0AE
		public unsafe float Rotation2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002FC5 RID: 12229
		// (get) Token: 0x0601F69A RID: 128666 RVA: 0x00910EBF File Offset: 0x0090F0BF
		// (set) Token: 0x0601F69B RID: 128667 RVA: 0x00910ECF File Offset: 0x0090F0CF
		public unsafe float Segment2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17002FC6 RID: 12230
		// (get) Token: 0x0601F69C RID: 128668 RVA: 0x00910EE0 File Offset: 0x0090F0E0
		// (set) Token: 0x0601F69D RID: 128669 RVA: 0x00910EF4 File Offset: 0x0090F0F4
		public unsafe UTexture2D Texture2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17002FC7 RID: 12231
		// (get) Token: 0x0601F69E RID: 128670 RVA: 0x00910F09 File Offset: 0x0090F109
		// (set) Token: 0x0601F69F RID: 128671 RVA: 0x00910F19 File Offset: 0x0090F119
		public unsafe float Twist2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17002FC8 RID: 12232
		// (get) Token: 0x0601F6A0 RID: 128672 RVA: 0x00910F2A File Offset: 0x0090F12A
		// (set) Token: 0x0601F6A1 RID: 128673 RVA: 0x00910F3A File Offset: 0x0090F13A
		public unsafe float CenterOffsetX0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17002FC9 RID: 12233
		// (get) Token: 0x0601F6A2 RID: 128674 RVA: 0x00910F4B File Offset: 0x0090F14B
		// (set) Token: 0x0601F6A3 RID: 128675 RVA: 0x00910F5B File Offset: 0x0090F15B
		public unsafe float CenterOffsetY0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17002FCA RID: 12234
		// (get) Token: 0x0601F6A4 RID: 128676 RVA: 0x00910F6C File Offset: 0x0090F16C
		// (set) Token: 0x0601F6A5 RID: 128677 RVA: 0x00910F7C File Offset: 0x0090F17C
		public unsafe float CenterOffsetX1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17002FCB RID: 12235
		// (get) Token: 0x0601F6A6 RID: 128678 RVA: 0x00910F8D File Offset: 0x0090F18D
		// (set) Token: 0x0601F6A7 RID: 128679 RVA: 0x00910F9D File Offset: 0x0090F19D
		public unsafe float CenterOffsetY1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17002FCC RID: 12236
		// (get) Token: 0x0601F6A8 RID: 128680 RVA: 0x00910FAE File Offset: 0x0090F1AE
		// (set) Token: 0x0601F6A9 RID: 128681 RVA: 0x00910FBE File Offset: 0x0090F1BE
		public unsafe float CenterOffsetX2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17002FCD RID: 12237
		// (get) Token: 0x0601F6AA RID: 128682 RVA: 0x00910FCF File Offset: 0x0090F1CF
		// (set) Token: 0x0601F6AB RID: 128683 RVA: 0x00910FDF File Offset: 0x0090F1DF
		public unsafe float CenterOffsetY2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17002FCE RID: 12238
		// (get) Token: 0x0601F6AC RID: 128684 RVA: 0x00910FF0 File Offset: 0x0090F1F0
		// (set) Token: 0x0601F6AD RID: 128685 RVA: 0x00911000 File Offset: 0x0090F200
		public unsafe float BlurIntensity0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17002FCF RID: 12239
		// (get) Token: 0x0601F6AE RID: 128686 RVA: 0x00911011 File Offset: 0x0090F211
		// (set) Token: 0x0601F6AF RID: 128687 RVA: 0x00911021 File Offset: 0x0090F221
		public unsafe float BlurIntensity1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17002FD0 RID: 12240
		// (get) Token: 0x0601F6B0 RID: 128688 RVA: 0x00911032 File Offset: 0x0090F232
		// (set) Token: 0x0601F6B1 RID: 128689 RVA: 0x00911042 File Offset: 0x0090F242
		public unsafe float BlurIntensity2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17002FD1 RID: 12241
		// (get) Token: 0x0601F6B2 RID: 128690 RVA: 0x00911053 File Offset: 0x0090F253
		// (set) Token: 0x0601F6B3 RID: 128691 RVA: 0x00911063 File Offset: 0x0090F263
		public unsafe float Distance3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17002FD2 RID: 12242
		// (get) Token: 0x0601F6B4 RID: 128692 RVA: 0x00911074 File Offset: 0x0090F274
		// (set) Token: 0x0601F6B5 RID: 128693 RVA: 0x00911084 File Offset: 0x0090F284
		public unsafe float HollowRadius3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17002FD3 RID: 12243
		// (get) Token: 0x0601F6B6 RID: 128694 RVA: 0x00911095 File Offset: 0x0090F295
		// (set) Token: 0x0601F6B7 RID: 128695 RVA: 0x009110A5 File Offset: 0x0090F2A5
		public unsafe float Rotation3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17002FD4 RID: 12244
		// (get) Token: 0x0601F6B8 RID: 128696 RVA: 0x009110B6 File Offset: 0x0090F2B6
		// (set) Token: 0x0601F6B9 RID: 128697 RVA: 0x009110C6 File Offset: 0x0090F2C6
		public unsafe float Segment3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17002FD5 RID: 12245
		// (get) Token: 0x0601F6BA RID: 128698 RVA: 0x009110D7 File Offset: 0x0090F2D7
		// (set) Token: 0x0601F6BB RID: 128699 RVA: 0x009110EB File Offset: 0x0090F2EB
		public unsafe UTexture2D Texture3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x17002FD6 RID: 12246
		// (get) Token: 0x0601F6BC RID: 128700 RVA: 0x00911100 File Offset: 0x0090F300
		// (set) Token: 0x0601F6BD RID: 128701 RVA: 0x00911110 File Offset: 0x0090F310
		public unsafe float Twist3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17002FD7 RID: 12247
		// (get) Token: 0x0601F6BE RID: 128702 RVA: 0x00911121 File Offset: 0x0090F321
		// (set) Token: 0x0601F6BF RID: 128703 RVA: 0x00911131 File Offset: 0x0090F331
		public unsafe float CenterOffsetX3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17002FD8 RID: 12248
		// (get) Token: 0x0601F6C0 RID: 128704 RVA: 0x00911142 File Offset: 0x0090F342
		// (set) Token: 0x0601F6C1 RID: 128705 RVA: 0x00911152 File Offset: 0x0090F352
		public unsafe float CenterOffsetY3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17002FD9 RID: 12249
		// (get) Token: 0x0601F6C2 RID: 128706 RVA: 0x00911163 File Offset: 0x0090F363
		// (set) Token: 0x0601F6C3 RID: 128707 RVA: 0x00911173 File Offset: 0x0090F373
		public unsafe float BlurIntensity3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17002FDA RID: 12250
		// (get) Token: 0x0601F6C4 RID: 128708 RVA: 0x00911184 File Offset: 0x0090F384
		// (set) Token: 0x0601F6C5 RID: 128709 RVA: 0x00911198 File Offset: 0x0090F398
		public unsafe FLinearColor ColorAdj
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17002FDB RID: 12251
		// (get) Token: 0x0601F6C6 RID: 128710 RVA: 0x009111AD File Offset: 0x0090F3AD
		// (set) Token: 0x0601F6C7 RID: 128711 RVA: 0x009111BD File Offset: 0x0090F3BD
		public unsafe bool BottomModel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002FDC RID: 12252
		// (get) Token: 0x0601F6C8 RID: 128712 RVA: 0x009111CE File Offset: 0x0090F3CE
		// (set) Token: 0x0601F6C9 RID: 128713 RVA: 0x009111DE File Offset: 0x0090F3DE
		public unsafe bool TopModel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002FDD RID: 12253
		// (get) Token: 0x0601F6CA RID: 128714 RVA: 0x009111EF File Offset: 0x0090F3EF
		// (set) Token: 0x0601F6CB RID: 128715 RVA: 0x00911203 File Offset: 0x0090F403
		[Nullable(1)]
		public unsafe string DYName
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_47)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_47)), value);
			}
		}

		// Token: 0x17002FDE RID: 12254
		// (get) Token: 0x0601F6CC RID: 128716 RVA: 0x00911218 File Offset: 0x0090F418
		// (set) Token: 0x0601F6CD RID: 128717 RVA: 0x00911228 File Offset: 0x0090F428
		public unsafe float EdgeSoft
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17002FDF RID: 12255
		// (get) Token: 0x0601F6CE RID: 128718 RVA: 0x00911239 File Offset: 0x0090F439
		// (set) Token: 0x0601F6CF RID: 128719 RVA: 0x00911249 File Offset: 0x0090F449
		public unsafe float Opacity0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17002FE0 RID: 12256
		// (get) Token: 0x0601F6D0 RID: 128720 RVA: 0x0091125A File Offset: 0x0090F45A
		// (set) Token: 0x0601F6D1 RID: 128721 RVA: 0x0091126A File Offset: 0x0090F46A
		public unsafe float Opacity1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17002FE1 RID: 12257
		// (get) Token: 0x0601F6D2 RID: 128722 RVA: 0x0091127B File Offset: 0x0090F47B
		// (set) Token: 0x0601F6D3 RID: 128723 RVA: 0x0091128B File Offset: 0x0090F48B
		public unsafe float Opacity2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17002FE2 RID: 12258
		// (get) Token: 0x0601F6D4 RID: 128724 RVA: 0x0091129C File Offset: 0x0090F49C
		// (set) Token: 0x0601F6D5 RID: 128725 RVA: 0x009112AC File Offset: 0x0090F4AC
		public unsafe float Opacity3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17002FE3 RID: 12259
		// (get) Token: 0x0601F6D6 RID: 128726 RVA: 0x009112BD File Offset: 0x0090F4BD
		// (set) Token: 0x0601F6D7 RID: 128727 RVA: 0x009112CD File Offset: 0x0090F4CD
		public unsafe float FadeVal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17002FE4 RID: 12260
		// (get) Token: 0x0601F6D8 RID: 128728 RVA: 0x009112DE File Offset: 0x0090F4DE
		// (set) Token: 0x0601F6D9 RID: 128729 RVA: 0x009112EE File Offset: 0x0090F4EE
		public unsafe float FadeSoft
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x17002FE5 RID: 12261
		// (get) Token: 0x0601F6DA RID: 128730 RVA: 0x009112FF File Offset: 0x0090F4FF
		// (set) Token: 0x0601F6DB RID: 128731 RVA: 0x0091130F File Offset: 0x0090F50F
		public unsafe float EdgeSoft_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_55);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_55) = value;
			}
		}

		// Token: 0x17002FE6 RID: 12262
		// (get) Token: 0x0601F6DC RID: 128732 RVA: 0x00911320 File Offset: 0x0090F520
		// (set) Token: 0x0601F6DD RID: 128733 RVA: 0x00911330 File Offset: 0x0090F530
		public unsafe float EdgeSoft_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_56);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_56) = value;
			}
		}

		// Token: 0x17002FE7 RID: 12263
		// (get) Token: 0x0601F6DE RID: 128734 RVA: 0x00911341 File Offset: 0x0090F541
		// (set) Token: 0x0601F6DF RID: 128735 RVA: 0x00911351 File Offset: 0x0090F551
		public unsafe float EdgeSoft_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x17002FE8 RID: 12264
		// (get) Token: 0x0601F6E0 RID: 128736 RVA: 0x00911362 File Offset: 0x0090F562
		// (set) Token: 0x0601F6E1 RID: 128737 RVA: 0x00911372 File Offset: 0x0090F572
		public unsafe float EdgeSoft_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_58);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x17002FE9 RID: 12265
		// (get) Token: 0x0601F6E2 RID: 128738 RVA: 0x00911383 File Offset: 0x0090F583
		// (set) Token: 0x0601F6E3 RID: 128739 RVA: 0x00911393 File Offset: 0x0090F593
		public unsafe float Distance4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_59);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_59) = value;
			}
		}

		// Token: 0x17002FEA RID: 12266
		// (get) Token: 0x0601F6E4 RID: 128740 RVA: 0x009113A4 File Offset: 0x0090F5A4
		// (set) Token: 0x0601F6E5 RID: 128741 RVA: 0x009113B4 File Offset: 0x0090F5B4
		public unsafe float HollowRadius4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_60);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_60) = value;
			}
		}

		// Token: 0x17002FEB RID: 12267
		// (get) Token: 0x0601F6E6 RID: 128742 RVA: 0x009113C5 File Offset: 0x0090F5C5
		// (set) Token: 0x0601F6E7 RID: 128743 RVA: 0x009113D5 File Offset: 0x0090F5D5
		public unsafe float Rotation4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_61);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_61) = value;
			}
		}

		// Token: 0x17002FEC RID: 12268
		// (get) Token: 0x0601F6E8 RID: 128744 RVA: 0x009113E6 File Offset: 0x0090F5E6
		// (set) Token: 0x0601F6E9 RID: 128745 RVA: 0x009113F6 File Offset: 0x0090F5F6
		public unsafe float Segment4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_62);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_62) = value;
			}
		}

		// Token: 0x17002FED RID: 12269
		// (get) Token: 0x0601F6EA RID: 128746 RVA: 0x00911407 File Offset: 0x0090F607
		// (set) Token: 0x0601F6EB RID: 128747 RVA: 0x0091141B File Offset: 0x0090F61B
		public unsafe UTexture2D Texture4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_63);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_Mesh_C.__PropertyOffset_63, value);
			}
		}

		// Token: 0x17002FEE RID: 12270
		// (get) Token: 0x0601F6EC RID: 128748 RVA: 0x00911430 File Offset: 0x0090F630
		// (set) Token: 0x0601F6ED RID: 128749 RVA: 0x00911440 File Offset: 0x0090F640
		public unsafe float Twist4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_64);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_64) = value;
			}
		}

		// Token: 0x17002FEF RID: 12271
		// (get) Token: 0x0601F6EE RID: 128750 RVA: 0x00911451 File Offset: 0x0090F651
		// (set) Token: 0x0601F6EF RID: 128751 RVA: 0x00911461 File Offset: 0x0090F661
		public unsafe float CenterOffsetX4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_65);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_65) = value;
			}
		}

		// Token: 0x17002FF0 RID: 12272
		// (get) Token: 0x0601F6F0 RID: 128752 RVA: 0x00911472 File Offset: 0x0090F672
		// (set) Token: 0x0601F6F1 RID: 128753 RVA: 0x00911482 File Offset: 0x0090F682
		public unsafe float CenterOffsetY4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_66);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_66) = value;
			}
		}

		// Token: 0x17002FF1 RID: 12273
		// (get) Token: 0x0601F6F2 RID: 128754 RVA: 0x00911493 File Offset: 0x0090F693
		// (set) Token: 0x0601F6F3 RID: 128755 RVA: 0x009114A3 File Offset: 0x0090F6A3
		public unsafe float BlurIntensity4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_67);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_67) = value;
			}
		}

		// Token: 0x17002FF2 RID: 12274
		// (get) Token: 0x0601F6F4 RID: 128756 RVA: 0x009114B4 File Offset: 0x0090F6B4
		// (set) Token: 0x0601F6F5 RID: 128757 RVA: 0x009114C4 File Offset: 0x0090F6C4
		public unsafe float Opacity4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_68);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_68) = value;
			}
		}

		// Token: 0x17002FF3 RID: 12275
		// (get) Token: 0x0601F6F6 RID: 128758 RVA: 0x009114D5 File Offset: 0x0090F6D5
		// (set) Token: 0x0601F6F7 RID: 128759 RVA: 0x009114E5 File Offset: 0x0090F6E5
		public unsafe float EdgeSoft4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_69);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_Mesh_C.__PropertyOffset_69) = value;
			}
		}

		// Token: 0x0601F6F8 RID: 128760 RVA: 0x009114F8 File Offset: 0x0090F6F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetMaterialToPost(UObject Object)
		{
			BP_Kaleidoscope_Mesh_C.__SetMaterialToPost_FunctionParams* ptr = stackalloc BP_Kaleidoscope_Mesh_C.__SetMaterialToPost_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_Kaleidoscope_Mesh_C.__SetMaterialToPost_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Kaleidoscope_Mesh_C.__SetMaterialToPost_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Object = ((Object != null) ? Object.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_Mesh_C.__SetMaterialToPost_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F6F9 RID: 128761 RVA: 0x0091154D File Offset: 0x0090F74D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Parameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_Mesh_C.__Set_Parameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601F6FA RID: 128762 RVA: 0x00911561 File Offset: 0x0090F761
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_Mesh_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F6FB RID: 128763 RVA: 0x00911575 File Offset: 0x0090F775
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Kaleidoscope_Mesh_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F6FC RID: 128764 RVA: 0x0091158A File Offset: 0x0090F78A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_Mesh_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F6FD RID: 128765 RVA: 0x0091159E File Offset: 0x0090F79E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Kaleidoscope_Mesh_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F6FE RID: 128766 RVA: 0x009115B4 File Offset: 0x0090F7B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Kaleidoscope_Mesh_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Kaleidoscope_Mesh_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Kaleidoscope_Mesh_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Kaleidoscope_Mesh_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_Mesh_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F6FF RID: 128767 RVA: 0x009115FC File Offset: 0x0090F7FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Kaleidoscope_Mesh_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Kaleidoscope_Mesh_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Kaleidoscope_Mesh_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Kaleidoscope_Mesh_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Kaleidoscope_Mesh_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F700 RID: 128768 RVA: 0x00911643 File Offset: 0x0090F843
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_Mesh_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F701 RID: 128769 RVA: 0x00911657 File Offset: 0x0090F857
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Kaleidoscope_Mesh_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F702 RID: 128770 RVA: 0x0091166C File Offset: 0x0090F86C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Kaleidoscope_Mesh_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Kaleidoscope_Mesh_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Kaleidoscope_Mesh_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Kaleidoscope_Mesh_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_Mesh_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F703 RID: 128771 RVA: 0x009116B4 File Offset: 0x0090F8B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Kaleidoscope_Mesh_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Kaleidoscope_Mesh_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Kaleidoscope_Mesh_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Kaleidoscope_Mesh_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Kaleidoscope_Mesh_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F704 RID: 128772 RVA: 0x009116FC File Offset: 0x0090F8FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Kaleidoscope_Mesh(int EntryPoint)
		{
			BP_Kaleidoscope_Mesh_C.__ExecuteUbergraph_BP_Kaleidoscope_Mesh_FunctionParams* ptr = stackalloc BP_Kaleidoscope_Mesh_C.__ExecuteUbergraph_BP_Kaleidoscope_Mesh_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_Kaleidoscope_Mesh_C.__ExecuteUbergraph_BP_Kaleidoscope_Mesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Kaleidoscope_Mesh_C.__ExecuteUbergraph_BP_Kaleidoscope_Mesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Kaleidoscope_Mesh_C.__ExecuteUbergraph_BP_Kaleidoscope_Mesh_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F705 RID: 128773 RVA: 0x00911743 File Offset: 0x0090F943
		protected BP_Kaleidoscope_Mesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F972 RID: 63858
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_Kaleidoscope_Mesh.BP_Kaleidoscope_Mesh_C";

		// Token: 0x0400F973 RID: 63859
		private static IntPtr _ClassPtr;

		// Token: 0x0400F974 RID: 63860
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F975 RID: 63861
		internal static int __PropertyOffset_0;

		// Token: 0x0400F976 RID: 63862
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F977 RID: 63863
		internal static int __PropertyOffset_1;

		// Token: 0x0400F978 RID: 63864
		internal static int __PropertyOffset_2;

		// Token: 0x0400F979 RID: 63865
		internal static int __PropertyOffset_3;

		// Token: 0x0400F97A RID: 63866
		internal static int __PropertyOffset_4;

		// Token: 0x0400F97B RID: 63867
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400F97C RID: 63868
		internal static int __PropertyOffset_5;

		// Token: 0x0400F97D RID: 63869
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400F97E RID: 63870
		internal static int __PropertyOffset_6;

		// Token: 0x0400F97F RID: 63871
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400F980 RID: 63872
		internal static int __PropertyOffset_7;

		// Token: 0x0400F981 RID: 63873
		internal static int __PropertyOffset_8;

		// Token: 0x0400F982 RID: 63874
		internal static int __PropertyOffset_9;

		// Token: 0x0400F983 RID: 63875
		internal static int __PropertyOffset_10;

		// Token: 0x0400F984 RID: 63876
		internal static int __PropertyOffset_11;

		// Token: 0x0400F985 RID: 63877
		internal static int __PropertyOffset_12;

		// Token: 0x0400F986 RID: 63878
		internal static int __PropertyOffset_13;

		// Token: 0x0400F987 RID: 63879
		internal static int __PropertyOffset_14;

		// Token: 0x0400F988 RID: 63880
		internal static int __PropertyOffset_15;

		// Token: 0x0400F989 RID: 63881
		internal static int __PropertyOffset_16;

		// Token: 0x0400F98A RID: 63882
		internal static int __PropertyOffset_17;

		// Token: 0x0400F98B RID: 63883
		internal static int __PropertyOffset_18;

		// Token: 0x0400F98C RID: 63884
		internal static int __PropertyOffset_19;

		// Token: 0x0400F98D RID: 63885
		internal static int __PropertyOffset_20;

		// Token: 0x0400F98E RID: 63886
		internal static int __PropertyOffset_21;

		// Token: 0x0400F98F RID: 63887
		internal static int __PropertyOffset_22;

		// Token: 0x0400F990 RID: 63888
		internal static int __PropertyOffset_23;

		// Token: 0x0400F991 RID: 63889
		internal static int __PropertyOffset_24;

		// Token: 0x0400F992 RID: 63890
		internal static int __PropertyOffset_25;

		// Token: 0x0400F993 RID: 63891
		internal static int __PropertyOffset_26;

		// Token: 0x0400F994 RID: 63892
		internal static int __PropertyOffset_27;

		// Token: 0x0400F995 RID: 63893
		internal static int __PropertyOffset_28;

		// Token: 0x0400F996 RID: 63894
		internal static int __PropertyOffset_29;

		// Token: 0x0400F997 RID: 63895
		internal static int __PropertyOffset_30;

		// Token: 0x0400F998 RID: 63896
		internal static int __PropertyOffset_31;

		// Token: 0x0400F999 RID: 63897
		internal static int __PropertyOffset_32;

		// Token: 0x0400F99A RID: 63898
		internal static int __PropertyOffset_33;

		// Token: 0x0400F99B RID: 63899
		internal static int __PropertyOffset_34;

		// Token: 0x0400F99C RID: 63900
		internal static int __PropertyOffset_35;

		// Token: 0x0400F99D RID: 63901
		internal static int __PropertyOffset_36;

		// Token: 0x0400F99E RID: 63902
		internal static int __PropertyOffset_37;

		// Token: 0x0400F99F RID: 63903
		internal static int __PropertyOffset_38;

		// Token: 0x0400F9A0 RID: 63904
		internal static int __PropertyOffset_39;

		// Token: 0x0400F9A1 RID: 63905
		internal static int __PropertyOffset_40;

		// Token: 0x0400F9A2 RID: 63906
		internal static int __PropertyOffset_41;

		// Token: 0x0400F9A3 RID: 63907
		internal static int __PropertyOffset_42;

		// Token: 0x0400F9A4 RID: 63908
		internal static int __PropertyOffset_43;

		// Token: 0x0400F9A5 RID: 63909
		internal static int __PropertyOffset_44;

		// Token: 0x0400F9A6 RID: 63910
		internal static int __PropertyOffset_45;

		// Token: 0x0400F9A7 RID: 63911
		internal static int __PropertyOffset_46;

		// Token: 0x0400F9A8 RID: 63912
		internal static int __PropertyOffset_47;

		// Token: 0x0400F9A9 RID: 63913
		internal static int __PropertyOffset_48;

		// Token: 0x0400F9AA RID: 63914
		internal static int __PropertyOffset_49;

		// Token: 0x0400F9AB RID: 63915
		internal static int __PropertyOffset_50;

		// Token: 0x0400F9AC RID: 63916
		internal static int __PropertyOffset_51;

		// Token: 0x0400F9AD RID: 63917
		internal static int __PropertyOffset_52;

		// Token: 0x0400F9AE RID: 63918
		internal static int __PropertyOffset_53;

		// Token: 0x0400F9AF RID: 63919
		internal static int __PropertyOffset_54;

		// Token: 0x0400F9B0 RID: 63920
		internal static int __PropertyOffset_55;

		// Token: 0x0400F9B1 RID: 63921
		internal static int __PropertyOffset_56;

		// Token: 0x0400F9B2 RID: 63922
		internal static int __PropertyOffset_57;

		// Token: 0x0400F9B3 RID: 63923
		internal static int __PropertyOffset_58;

		// Token: 0x0400F9B4 RID: 63924
		internal static int __PropertyOffset_59;

		// Token: 0x0400F9B5 RID: 63925
		internal static int __PropertyOffset_60;

		// Token: 0x0400F9B6 RID: 63926
		internal static int __PropertyOffset_61;

		// Token: 0x0400F9B7 RID: 63927
		internal static int __PropertyOffset_62;

		// Token: 0x0400F9B8 RID: 63928
		internal static int __PropertyOffset_63;

		// Token: 0x0400F9B9 RID: 63929
		internal static int __PropertyOffset_64;

		// Token: 0x0400F9BA RID: 63930
		internal static int __PropertyOffset_65;

		// Token: 0x0400F9BB RID: 63931
		internal static int __PropertyOffset_66;

		// Token: 0x0400F9BC RID: 63932
		internal static int __PropertyOffset_67;

		// Token: 0x0400F9BD RID: 63933
		internal static int __PropertyOffset_68;

		// Token: 0x0400F9BE RID: 63934
		internal static int __PropertyOffset_69;

		// Token: 0x0400F9BF RID: 63935
		private static IntPtr __SetMaterialToPost_NativeFunctionPtr;

		// Token: 0x0400F9C0 RID: 63936
		private static IntPtr __Set_Parameter_NativeFunctionPtr;

		// Token: 0x0400F9C1 RID: 63937
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F9C2 RID: 63938
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F9C3 RID: 63939
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F9C4 RID: 63940
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400F9C5 RID: 63941
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F9C6 RID: 63942
		private static IntPtr __ExecuteUbergraph_BP_Kaleidoscope_Mesh_NativeFunctionPtr;

		// Token: 0x020098D8 RID: 39128
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __SetMaterialToPost_FunctionParams
		{
			// Token: 0x04031F2D RID: 204589
			[FieldOffset(0)]
			public IntPtr Object;
		}

		// Token: 0x020098D9 RID: 39129
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F2E RID: 204590
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098DA RID: 39130
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F2F RID: 204591
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098DB RID: 39131
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_Kaleidoscope_Mesh_FunctionParams
		{
			// Token: 0x04031F30 RID: 204592
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
