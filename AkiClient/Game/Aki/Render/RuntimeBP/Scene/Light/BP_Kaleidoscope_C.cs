using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A84 RID: 14980
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_Kaleidoscope.BP_Kaleidoscope_C")]
	[UnrealStructLayout(1840, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1836)]
	public class BP_Kaleidoscope_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F5EA RID: 128490 RVA: 0x0090FF7C File Offset: 0x0090E17C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Kaleidoscope_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_Kaleidoscope.BP_Kaleidoscope_C");
			}
			return BP_Kaleidoscope_C._ClassPtr;
		}

		// Token: 0x0601F5EB RID: 128491 RVA: 0x0090FFA0 File Offset: 0x0090E1A0
		public BP_Kaleidoscope_C() : this(BuiltinUtils.AllocNativeUObject(BP_Kaleidoscope_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F5EC RID: 128492 RVA: 0x0090FFC8 File Offset: 0x0090E1C8
		[NullableContext(1)]
		public BP_Kaleidoscope_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Kaleidoscope_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002F77 RID: 12151
		// (get) Token: 0x0601F5ED RID: 128493 RVA: 0x0090FFFC File Offset: 0x0090E1FC
		// (set) Token: 0x0601F5EE RID: 128494 RVA: 0x00910035 File Offset: 0x0090E235
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002F78 RID: 12152
		// (get) Token: 0x0601F5EF RID: 128495 RVA: 0x00910056 File Offset: 0x0090E256
		// (set) Token: 0x0601F5F0 RID: 128496 RVA: 0x0091006A File Offset: 0x0090E26A
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002F79 RID: 12153
		// (get) Token: 0x0601F5F1 RID: 128497 RVA: 0x0091007F File Offset: 0x0090E27F
		// (set) Token: 0x0601F5F2 RID: 128498 RVA: 0x00910093 File Offset: 0x0090E293
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002F7A RID: 12154
		// (get) Token: 0x0601F5F3 RID: 128499 RVA: 0x009100A8 File Offset: 0x0090E2A8
		// (set) Token: 0x0601F5F4 RID: 128500 RVA: 0x009100BC File Offset: 0x0090E2BC
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002F7B RID: 12155
		// (get) Token: 0x0601F5F5 RID: 128501 RVA: 0x009100D4 File Offset: 0x0090E2D4
		// (set) Token: 0x0601F5F6 RID: 128502 RVA: 0x0091010D File Offset: 0x0090E30D
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
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002F7C RID: 12156
		// (get) Token: 0x0601F5F7 RID: 128503 RVA: 0x0091011C File Offset: 0x0090E31C
		// (set) Token: 0x0601F5F8 RID: 128504 RVA: 0x00910155 File Offset: 0x0090E355
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
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002F7D RID: 12157
		// (get) Token: 0x0601F5F9 RID: 128505 RVA: 0x00910164 File Offset: 0x0090E364
		// (set) Token: 0x0601F5FA RID: 128506 RVA: 0x0091019D File Offset: 0x0090E39D
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
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002F7E RID: 12158
		// (get) Token: 0x0601F5FB RID: 128507 RVA: 0x009101AB File Offset: 0x0090E3AB
		// (set) Token: 0x0601F5FC RID: 128508 RVA: 0x009101BB File Offset: 0x0090E3BB
		public unsafe float Distance0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002F7F RID: 12159
		// (get) Token: 0x0601F5FD RID: 128509 RVA: 0x009101CC File Offset: 0x0090E3CC
		// (set) Token: 0x0601F5FE RID: 128510 RVA: 0x009101E0 File Offset: 0x0090E3E0
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17002F80 RID: 12160
		// (get) Token: 0x0601F5FF RID: 128511 RVA: 0x009101F5 File Offset: 0x0090E3F5
		// (set) Token: 0x0601F600 RID: 128512 RVA: 0x00910205 File Offset: 0x0090E405
		public unsafe float HollowRadius0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002F81 RID: 12161
		// (get) Token: 0x0601F601 RID: 128513 RVA: 0x00910216 File Offset: 0x0090E416
		// (set) Token: 0x0601F602 RID: 128514 RVA: 0x00910226 File Offset: 0x0090E426
		public unsafe float Rotation0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002F82 RID: 12162
		// (get) Token: 0x0601F603 RID: 128515 RVA: 0x00910237 File Offset: 0x0090E437
		// (set) Token: 0x0601F604 RID: 128516 RVA: 0x00910247 File Offset: 0x0090E447
		public unsafe float Segment0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002F83 RID: 12163
		// (get) Token: 0x0601F605 RID: 128517 RVA: 0x00910258 File Offset: 0x0090E458
		// (set) Token: 0x0601F606 RID: 128518 RVA: 0x0091026C File Offset: 0x0090E46C
		public unsafe UTexture2D Texture0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17002F84 RID: 12164
		// (get) Token: 0x0601F607 RID: 128519 RVA: 0x00910281 File Offset: 0x0090E481
		// (set) Token: 0x0601F608 RID: 128520 RVA: 0x00910291 File Offset: 0x0090E491
		public unsafe float Twist0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002F85 RID: 12165
		// (get) Token: 0x0601F609 RID: 128521 RVA: 0x009102A2 File Offset: 0x0090E4A2
		// (set) Token: 0x0601F60A RID: 128522 RVA: 0x009102B2 File Offset: 0x0090E4B2
		public unsafe float Distance1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002F86 RID: 12166
		// (get) Token: 0x0601F60B RID: 128523 RVA: 0x009102C3 File Offset: 0x0090E4C3
		// (set) Token: 0x0601F60C RID: 128524 RVA: 0x009102D3 File Offset: 0x0090E4D3
		public unsafe float HollowRadius1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002F87 RID: 12167
		// (get) Token: 0x0601F60D RID: 128525 RVA: 0x009102E4 File Offset: 0x0090E4E4
		// (set) Token: 0x0601F60E RID: 128526 RVA: 0x009102F4 File Offset: 0x0090E4F4
		public unsafe float Rotation1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002F88 RID: 12168
		// (get) Token: 0x0601F60F RID: 128527 RVA: 0x00910305 File Offset: 0x0090E505
		// (set) Token: 0x0601F610 RID: 128528 RVA: 0x00910315 File Offset: 0x0090E515
		public unsafe float Segment1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002F89 RID: 12169
		// (get) Token: 0x0601F611 RID: 128529 RVA: 0x00910326 File Offset: 0x0090E526
		// (set) Token: 0x0601F612 RID: 128530 RVA: 0x0091033A File Offset: 0x0090E53A
		public unsafe UTexture2D Texture1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17002F8A RID: 12170
		// (get) Token: 0x0601F613 RID: 128531 RVA: 0x0091034F File Offset: 0x0090E54F
		// (set) Token: 0x0601F614 RID: 128532 RVA: 0x0091035F File Offset: 0x0090E55F
		public unsafe float Twist1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002F8B RID: 12171
		// (get) Token: 0x0601F615 RID: 128533 RVA: 0x00910370 File Offset: 0x0090E570
		// (set) Token: 0x0601F616 RID: 128534 RVA: 0x00910380 File Offset: 0x0090E580
		public unsafe float Distance2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002F8C RID: 12172
		// (get) Token: 0x0601F617 RID: 128535 RVA: 0x00910391 File Offset: 0x0090E591
		// (set) Token: 0x0601F618 RID: 128536 RVA: 0x009103A1 File Offset: 0x0090E5A1
		public unsafe float HollowRadius2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002F8D RID: 12173
		// (get) Token: 0x0601F619 RID: 128537 RVA: 0x009103B2 File Offset: 0x0090E5B2
		// (set) Token: 0x0601F61A RID: 128538 RVA: 0x009103C2 File Offset: 0x0090E5C2
		public unsafe float Rotation2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002F8E RID: 12174
		// (get) Token: 0x0601F61B RID: 128539 RVA: 0x009103D3 File Offset: 0x0090E5D3
		// (set) Token: 0x0601F61C RID: 128540 RVA: 0x009103E3 File Offset: 0x0090E5E3
		public unsafe float Segment2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17002F8F RID: 12175
		// (get) Token: 0x0601F61D RID: 128541 RVA: 0x009103F4 File Offset: 0x0090E5F4
		// (set) Token: 0x0601F61E RID: 128542 RVA: 0x00910408 File Offset: 0x0090E608
		public unsafe UTexture2D Texture2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17002F90 RID: 12176
		// (get) Token: 0x0601F61F RID: 128543 RVA: 0x0091041D File Offset: 0x0090E61D
		// (set) Token: 0x0601F620 RID: 128544 RVA: 0x0091042D File Offset: 0x0090E62D
		public unsafe float Twist2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17002F91 RID: 12177
		// (get) Token: 0x0601F621 RID: 128545 RVA: 0x0091043E File Offset: 0x0090E63E
		// (set) Token: 0x0601F622 RID: 128546 RVA: 0x0091044E File Offset: 0x0090E64E
		public unsafe float CenterOffsetX0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17002F92 RID: 12178
		// (get) Token: 0x0601F623 RID: 128547 RVA: 0x0091045F File Offset: 0x0090E65F
		// (set) Token: 0x0601F624 RID: 128548 RVA: 0x0091046F File Offset: 0x0090E66F
		public unsafe float CenterOffsetY0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17002F93 RID: 12179
		// (get) Token: 0x0601F625 RID: 128549 RVA: 0x00910480 File Offset: 0x0090E680
		// (set) Token: 0x0601F626 RID: 128550 RVA: 0x00910490 File Offset: 0x0090E690
		public unsafe float CenterOffsetX1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17002F94 RID: 12180
		// (get) Token: 0x0601F627 RID: 128551 RVA: 0x009104A1 File Offset: 0x0090E6A1
		// (set) Token: 0x0601F628 RID: 128552 RVA: 0x009104B1 File Offset: 0x0090E6B1
		public unsafe float CenterOffsetY1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17002F95 RID: 12181
		// (get) Token: 0x0601F629 RID: 128553 RVA: 0x009104C2 File Offset: 0x0090E6C2
		// (set) Token: 0x0601F62A RID: 128554 RVA: 0x009104D2 File Offset: 0x0090E6D2
		public unsafe float CenterOffsetX2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17002F96 RID: 12182
		// (get) Token: 0x0601F62B RID: 128555 RVA: 0x009104E3 File Offset: 0x0090E6E3
		// (set) Token: 0x0601F62C RID: 128556 RVA: 0x009104F3 File Offset: 0x0090E6F3
		public unsafe float CenterOffsetY2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17002F97 RID: 12183
		// (get) Token: 0x0601F62D RID: 128557 RVA: 0x00910504 File Offset: 0x0090E704
		// (set) Token: 0x0601F62E RID: 128558 RVA: 0x00910514 File Offset: 0x0090E714
		public unsafe float BlurIntensity0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17002F98 RID: 12184
		// (get) Token: 0x0601F62F RID: 128559 RVA: 0x00910525 File Offset: 0x0090E725
		// (set) Token: 0x0601F630 RID: 128560 RVA: 0x00910535 File Offset: 0x0090E735
		public unsafe float BlurIntensity1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17002F99 RID: 12185
		// (get) Token: 0x0601F631 RID: 128561 RVA: 0x00910546 File Offset: 0x0090E746
		// (set) Token: 0x0601F632 RID: 128562 RVA: 0x00910556 File Offset: 0x0090E756
		public unsafe float BlurIntensity2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17002F9A RID: 12186
		// (get) Token: 0x0601F633 RID: 128563 RVA: 0x00910567 File Offset: 0x0090E767
		// (set) Token: 0x0601F634 RID: 128564 RVA: 0x00910577 File Offset: 0x0090E777
		public unsafe float Distance3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17002F9B RID: 12187
		// (get) Token: 0x0601F635 RID: 128565 RVA: 0x00910588 File Offset: 0x0090E788
		// (set) Token: 0x0601F636 RID: 128566 RVA: 0x00910598 File Offset: 0x0090E798
		public unsafe float HollowRadius3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17002F9C RID: 12188
		// (get) Token: 0x0601F637 RID: 128567 RVA: 0x009105A9 File Offset: 0x0090E7A9
		// (set) Token: 0x0601F638 RID: 128568 RVA: 0x009105B9 File Offset: 0x0090E7B9
		public unsafe float Rotation3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17002F9D RID: 12189
		// (get) Token: 0x0601F639 RID: 128569 RVA: 0x009105CA File Offset: 0x0090E7CA
		// (set) Token: 0x0601F63A RID: 128570 RVA: 0x009105DA File Offset: 0x0090E7DA
		public unsafe float Segment3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17002F9E RID: 12190
		// (get) Token: 0x0601F63B RID: 128571 RVA: 0x009105EB File Offset: 0x0090E7EB
		// (set) Token: 0x0601F63C RID: 128572 RVA: 0x009105FF File Offset: 0x0090E7FF
		public unsafe UTexture2D Texture3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Kaleidoscope_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x17002F9F RID: 12191
		// (get) Token: 0x0601F63D RID: 128573 RVA: 0x00910614 File Offset: 0x0090E814
		// (set) Token: 0x0601F63E RID: 128574 RVA: 0x00910624 File Offset: 0x0090E824
		public unsafe float Twist3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17002FA0 RID: 12192
		// (get) Token: 0x0601F63F RID: 128575 RVA: 0x00910635 File Offset: 0x0090E835
		// (set) Token: 0x0601F640 RID: 128576 RVA: 0x00910645 File Offset: 0x0090E845
		public unsafe float CenterOffsetX3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17002FA1 RID: 12193
		// (get) Token: 0x0601F641 RID: 128577 RVA: 0x00910656 File Offset: 0x0090E856
		// (set) Token: 0x0601F642 RID: 128578 RVA: 0x00910666 File Offset: 0x0090E866
		public unsafe float CenterOffsetY3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17002FA2 RID: 12194
		// (get) Token: 0x0601F643 RID: 128579 RVA: 0x00910677 File Offset: 0x0090E877
		// (set) Token: 0x0601F644 RID: 128580 RVA: 0x00910687 File Offset: 0x0090E887
		public unsafe float BlurIntensity3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17002FA3 RID: 12195
		// (get) Token: 0x0601F645 RID: 128581 RVA: 0x00910698 File Offset: 0x0090E898
		// (set) Token: 0x0601F646 RID: 128582 RVA: 0x009106AC File Offset: 0x0090E8AC
		public unsafe FLinearColor ColorAdj
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17002FA4 RID: 12196
		// (get) Token: 0x0601F647 RID: 128583 RVA: 0x009106C1 File Offset: 0x0090E8C1
		// (set) Token: 0x0601F648 RID: 128584 RVA: 0x009106D1 File Offset: 0x0090E8D1
		public unsafe bool BottomModel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002FA5 RID: 12197
		// (get) Token: 0x0601F649 RID: 128585 RVA: 0x009106E2 File Offset: 0x0090E8E2
		// (set) Token: 0x0601F64A RID: 128586 RVA: 0x009106F2 File Offset: 0x0090E8F2
		public unsafe bool TopModel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002FA6 RID: 12198
		// (get) Token: 0x0601F64B RID: 128587 RVA: 0x00910703 File Offset: 0x0090E903
		// (set) Token: 0x0601F64C RID: 128588 RVA: 0x00910717 File Offset: 0x0090E917
		[Nullable(1)]
		public unsafe string DYName
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_Kaleidoscope_C.__PropertyOffset_47)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_Kaleidoscope_C.__PropertyOffset_47)), value);
			}
		}

		// Token: 0x17002FA7 RID: 12199
		// (get) Token: 0x0601F64D RID: 128589 RVA: 0x0091072C File Offset: 0x0090E92C
		// (set) Token: 0x0601F64E RID: 128590 RVA: 0x0091073C File Offset: 0x0090E93C
		public unsafe float EdgeSoft
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17002FA8 RID: 12200
		// (get) Token: 0x0601F64F RID: 128591 RVA: 0x0091074D File Offset: 0x0090E94D
		// (set) Token: 0x0601F650 RID: 128592 RVA: 0x0091075D File Offset: 0x0090E95D
		public unsafe float Opacity0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17002FA9 RID: 12201
		// (get) Token: 0x0601F651 RID: 128593 RVA: 0x0091076E File Offset: 0x0090E96E
		// (set) Token: 0x0601F652 RID: 128594 RVA: 0x0091077E File Offset: 0x0090E97E
		public unsafe float Opacity1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17002FAA RID: 12202
		// (get) Token: 0x0601F653 RID: 128595 RVA: 0x0091078F File Offset: 0x0090E98F
		// (set) Token: 0x0601F654 RID: 128596 RVA: 0x0091079F File Offset: 0x0090E99F
		public unsafe float Opacity2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17002FAB RID: 12203
		// (get) Token: 0x0601F655 RID: 128597 RVA: 0x009107B0 File Offset: 0x0090E9B0
		// (set) Token: 0x0601F656 RID: 128598 RVA: 0x009107C0 File Offset: 0x0090E9C0
		public unsafe float Opacity3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17002FAC RID: 12204
		// (get) Token: 0x0601F657 RID: 128599 RVA: 0x009107D1 File Offset: 0x0090E9D1
		// (set) Token: 0x0601F658 RID: 128600 RVA: 0x009107E1 File Offset: 0x0090E9E1
		public unsafe float FadeVal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17002FAD RID: 12205
		// (get) Token: 0x0601F659 RID: 128601 RVA: 0x009107F2 File Offset: 0x0090E9F2
		// (set) Token: 0x0601F65A RID: 128602 RVA: 0x00910802 File Offset: 0x0090EA02
		public unsafe float FadeSoft
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Kaleidoscope_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x0601F65B RID: 128603 RVA: 0x00910814 File Offset: 0x0090EA14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetMaterialToPost(UObject Object)
		{
			BP_Kaleidoscope_C.__SetMaterialToPost_FunctionParams* ptr = stackalloc BP_Kaleidoscope_C.__SetMaterialToPost_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_Kaleidoscope_C.__SetMaterialToPost_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Kaleidoscope_C.__SetMaterialToPost_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Object = ((Object != null) ? Object.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_C.__SetMaterialToPost_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F65C RID: 128604 RVA: 0x00910869 File Offset: 0x0090EA69
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Parameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_C.__Set_Parameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601F65D RID: 128605 RVA: 0x0091087D File Offset: 0x0090EA7D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F65E RID: 128606 RVA: 0x00910891 File Offset: 0x0090EA91
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Kaleidoscope_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F65F RID: 128607 RVA: 0x009108A6 File Offset: 0x0090EAA6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F660 RID: 128608 RVA: 0x009108BA File Offset: 0x0090EABA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Kaleidoscope_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F661 RID: 128609 RVA: 0x009108D0 File Offset: 0x0090EAD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Kaleidoscope_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Kaleidoscope_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Kaleidoscope_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Kaleidoscope_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F662 RID: 128610 RVA: 0x00910918 File Offset: 0x0090EB18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Kaleidoscope_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Kaleidoscope_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Kaleidoscope_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Kaleidoscope_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Kaleidoscope_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F663 RID: 128611 RVA: 0x0091095F File Offset: 0x0090EB5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F664 RID: 128612 RVA: 0x00910973 File Offset: 0x0090EB73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Kaleidoscope_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F665 RID: 128613 RVA: 0x00910988 File Offset: 0x0090EB88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Kaleidoscope_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Kaleidoscope_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Kaleidoscope_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Kaleidoscope_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Kaleidoscope_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F666 RID: 128614 RVA: 0x009109D0 File Offset: 0x0090EBD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Kaleidoscope_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Kaleidoscope_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Kaleidoscope_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Kaleidoscope_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Kaleidoscope_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F667 RID: 128615 RVA: 0x00910A18 File Offset: 0x0090EC18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Kaleidoscope(int EntryPoint)
		{
			BP_Kaleidoscope_C.__ExecuteUbergraph_BP_Kaleidoscope_FunctionParams* ptr = stackalloc BP_Kaleidoscope_C.__ExecuteUbergraph_BP_Kaleidoscope_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_Kaleidoscope_C.__ExecuteUbergraph_BP_Kaleidoscope_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Kaleidoscope_C.__ExecuteUbergraph_BP_Kaleidoscope_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Kaleidoscope_C.__ExecuteUbergraph_BP_Kaleidoscope_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F668 RID: 128616 RVA: 0x00910A5F File Offset: 0x0090EC5F
		protected BP_Kaleidoscope_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F92C RID: 63788
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_Kaleidoscope.BP_Kaleidoscope_C";

		// Token: 0x0400F92D RID: 63789
		private static IntPtr _ClassPtr;

		// Token: 0x0400F92E RID: 63790
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F92F RID: 63791
		internal static int __PropertyOffset_0;

		// Token: 0x0400F930 RID: 63792
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F931 RID: 63793
		internal static int __PropertyOffset_1;

		// Token: 0x0400F932 RID: 63794
		internal static int __PropertyOffset_2;

		// Token: 0x0400F933 RID: 63795
		internal static int __PropertyOffset_3;

		// Token: 0x0400F934 RID: 63796
		internal static int __PropertyOffset_4;

		// Token: 0x0400F935 RID: 63797
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400F936 RID: 63798
		internal static int __PropertyOffset_5;

		// Token: 0x0400F937 RID: 63799
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400F938 RID: 63800
		internal static int __PropertyOffset_6;

		// Token: 0x0400F939 RID: 63801
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400F93A RID: 63802
		internal static int __PropertyOffset_7;

		// Token: 0x0400F93B RID: 63803
		internal static int __PropertyOffset_8;

		// Token: 0x0400F93C RID: 63804
		internal static int __PropertyOffset_9;

		// Token: 0x0400F93D RID: 63805
		internal static int __PropertyOffset_10;

		// Token: 0x0400F93E RID: 63806
		internal static int __PropertyOffset_11;

		// Token: 0x0400F93F RID: 63807
		internal static int __PropertyOffset_12;

		// Token: 0x0400F940 RID: 63808
		internal static int __PropertyOffset_13;

		// Token: 0x0400F941 RID: 63809
		internal static int __PropertyOffset_14;

		// Token: 0x0400F942 RID: 63810
		internal static int __PropertyOffset_15;

		// Token: 0x0400F943 RID: 63811
		internal static int __PropertyOffset_16;

		// Token: 0x0400F944 RID: 63812
		internal static int __PropertyOffset_17;

		// Token: 0x0400F945 RID: 63813
		internal static int __PropertyOffset_18;

		// Token: 0x0400F946 RID: 63814
		internal static int __PropertyOffset_19;

		// Token: 0x0400F947 RID: 63815
		internal static int __PropertyOffset_20;

		// Token: 0x0400F948 RID: 63816
		internal static int __PropertyOffset_21;

		// Token: 0x0400F949 RID: 63817
		internal static int __PropertyOffset_22;

		// Token: 0x0400F94A RID: 63818
		internal static int __PropertyOffset_23;

		// Token: 0x0400F94B RID: 63819
		internal static int __PropertyOffset_24;

		// Token: 0x0400F94C RID: 63820
		internal static int __PropertyOffset_25;

		// Token: 0x0400F94D RID: 63821
		internal static int __PropertyOffset_26;

		// Token: 0x0400F94E RID: 63822
		internal static int __PropertyOffset_27;

		// Token: 0x0400F94F RID: 63823
		internal static int __PropertyOffset_28;

		// Token: 0x0400F950 RID: 63824
		internal static int __PropertyOffset_29;

		// Token: 0x0400F951 RID: 63825
		internal static int __PropertyOffset_30;

		// Token: 0x0400F952 RID: 63826
		internal static int __PropertyOffset_31;

		// Token: 0x0400F953 RID: 63827
		internal static int __PropertyOffset_32;

		// Token: 0x0400F954 RID: 63828
		internal static int __PropertyOffset_33;

		// Token: 0x0400F955 RID: 63829
		internal static int __PropertyOffset_34;

		// Token: 0x0400F956 RID: 63830
		internal static int __PropertyOffset_35;

		// Token: 0x0400F957 RID: 63831
		internal static int __PropertyOffset_36;

		// Token: 0x0400F958 RID: 63832
		internal static int __PropertyOffset_37;

		// Token: 0x0400F959 RID: 63833
		internal static int __PropertyOffset_38;

		// Token: 0x0400F95A RID: 63834
		internal static int __PropertyOffset_39;

		// Token: 0x0400F95B RID: 63835
		internal static int __PropertyOffset_40;

		// Token: 0x0400F95C RID: 63836
		internal static int __PropertyOffset_41;

		// Token: 0x0400F95D RID: 63837
		internal static int __PropertyOffset_42;

		// Token: 0x0400F95E RID: 63838
		internal static int __PropertyOffset_43;

		// Token: 0x0400F95F RID: 63839
		internal static int __PropertyOffset_44;

		// Token: 0x0400F960 RID: 63840
		internal static int __PropertyOffset_45;

		// Token: 0x0400F961 RID: 63841
		internal static int __PropertyOffset_46;

		// Token: 0x0400F962 RID: 63842
		internal static int __PropertyOffset_47;

		// Token: 0x0400F963 RID: 63843
		internal static int __PropertyOffset_48;

		// Token: 0x0400F964 RID: 63844
		internal static int __PropertyOffset_49;

		// Token: 0x0400F965 RID: 63845
		internal static int __PropertyOffset_50;

		// Token: 0x0400F966 RID: 63846
		internal static int __PropertyOffset_51;

		// Token: 0x0400F967 RID: 63847
		internal static int __PropertyOffset_52;

		// Token: 0x0400F968 RID: 63848
		internal static int __PropertyOffset_53;

		// Token: 0x0400F969 RID: 63849
		internal static int __PropertyOffset_54;

		// Token: 0x0400F96A RID: 63850
		private static IntPtr __SetMaterialToPost_NativeFunctionPtr;

		// Token: 0x0400F96B RID: 63851
		private static IntPtr __Set_Parameter_NativeFunctionPtr;

		// Token: 0x0400F96C RID: 63852
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F96D RID: 63853
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F96E RID: 63854
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F96F RID: 63855
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400F970 RID: 63856
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F971 RID: 63857
		private static IntPtr __ExecuteUbergraph_BP_Kaleidoscope_NativeFunctionPtr;

		// Token: 0x020098D4 RID: 39124
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __SetMaterialToPost_FunctionParams
		{
			// Token: 0x04031F29 RID: 204585
			[FieldOffset(0)]
			public IntPtr Object;
		}

		// Token: 0x020098D5 RID: 39125
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F2A RID: 204586
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098D6 RID: 39126
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F2B RID: 204587
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098D7 RID: 39127
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_Kaleidoscope_FunctionParams
		{
			// Token: 0x04031F2C RID: 204588
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
