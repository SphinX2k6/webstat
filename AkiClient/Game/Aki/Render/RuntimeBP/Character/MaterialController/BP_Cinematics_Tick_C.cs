using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Sequence.Seq_BP;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D73 RID: 15731
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/BP_Cinematics_Tick.BP_Cinematics_Tick_C")]
	[UnrealStructLayout(1872, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1866)]
	public class BP_Cinematics_Tick_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026528 RID: 156968 RVA: 0x009D4E90 File Offset: 0x009D3090
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cinematics_Tick_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/MaterialController/BP_Cinematics_Tick.BP_Cinematics_Tick_C");
			}
			return BP_Cinematics_Tick_C._ClassPtr;
		}

		// Token: 0x06026529 RID: 156969 RVA: 0x009D4EB4 File Offset: 0x009D30B4
		public BP_Cinematics_Tick_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cinematics_Tick_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602652A RID: 156970 RVA: 0x009D4EDC File Offset: 0x009D30DC
		[NullableContext(1)]
		public BP_Cinematics_Tick_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cinematics_Tick_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005699 RID: 22169
		// (get) Token: 0x0602652B RID: 156971 RVA: 0x009D4F10 File Offset: 0x009D3110
		// (set) Token: 0x0602652C RID: 156972 RVA: 0x009D4F49 File Offset: 0x009D3149
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700569A RID: 22170
		// (get) Token: 0x0602652D RID: 156973 RVA: 0x009D4F6A File Offset: 0x009D316A
		// (set) Token: 0x0602652E RID: 156974 RVA: 0x009D4F7E File Offset: 0x009D317E
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700569B RID: 22171
		// (get) Token: 0x0602652F RID: 156975 RVA: 0x009D4F93 File Offset: 0x009D3193
		// (set) Token: 0x06026530 RID: 156976 RVA: 0x009D4FA3 File Offset: 0x009D31A3
		public unsafe int Is_Tick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700569C RID: 22172
		// (get) Token: 0x06026531 RID: 156977 RVA: 0x009D4FB4 File Offset: 0x009D31B4
		// (set) Token: 0x06026532 RID: 156978 RVA: 0x009D4FC8 File Offset: 0x009D31C8
		public unsafe ABaseCharacter BP_Character_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ABaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700569D RID: 22173
		// (get) Token: 0x06026533 RID: 156979 RVA: 0x009D4FDD File Offset: 0x009D31DD
		// (set) Token: 0x06026534 RID: 156980 RVA: 0x009D4FED File Offset: 0x009D31ED
		public unsafe float Character_1_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700569E RID: 22174
		// (get) Token: 0x06026535 RID: 156981 RVA: 0x009D4FFE File Offset: 0x009D31FE
		// (set) Token: 0x06026536 RID: 156982 RVA: 0x009D500E File Offset: 0x009D320E
		public unsafe float Character_1_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700569F RID: 22175
		// (get) Token: 0x06026537 RID: 156983 RVA: 0x009D501F File Offset: 0x009D321F
		// (set) Token: 0x06026538 RID: 156984 RVA: 0x009D5033 File Offset: 0x009D3233
		public unsafe ABaseCharacter BP_Character_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ABaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170056A0 RID: 22176
		// (get) Token: 0x06026539 RID: 156985 RVA: 0x009D5048 File Offset: 0x009D3248
		// (set) Token: 0x0602653A RID: 156986 RVA: 0x009D5058 File Offset: 0x009D3258
		public unsafe float Character_2_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170056A1 RID: 22177
		// (get) Token: 0x0602653B RID: 156987 RVA: 0x009D5069 File Offset: 0x009D3269
		// (set) Token: 0x0602653C RID: 156988 RVA: 0x009D5079 File Offset: 0x009D3279
		public unsafe float Character_2_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170056A2 RID: 22178
		// (get) Token: 0x0602653D RID: 156989 RVA: 0x009D508A File Offset: 0x009D328A
		// (set) Token: 0x0602653E RID: 156990 RVA: 0x009D509E File Offset: 0x009D329E
		public unsafe ABaseCharacter BP_Character_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ABaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170056A3 RID: 22179
		// (get) Token: 0x0602653F RID: 156991 RVA: 0x009D50B3 File Offset: 0x009D32B3
		// (set) Token: 0x06026540 RID: 156992 RVA: 0x009D50C3 File Offset: 0x009D32C3
		public unsafe float Character_3_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170056A4 RID: 22180
		// (get) Token: 0x06026541 RID: 156993 RVA: 0x009D50D4 File Offset: 0x009D32D4
		// (set) Token: 0x06026542 RID: 156994 RVA: 0x009D50E4 File Offset: 0x009D32E4
		public unsafe float Character_3_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170056A5 RID: 22181
		// (get) Token: 0x06026543 RID: 156995 RVA: 0x009D50F5 File Offset: 0x009D32F5
		// (set) Token: 0x06026544 RID: 156996 RVA: 0x009D5109 File Offset: 0x009D3309
		public unsafe ABaseCharacter BP_Character_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ABaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170056A6 RID: 22182
		// (get) Token: 0x06026545 RID: 156997 RVA: 0x009D511E File Offset: 0x009D331E
		// (set) Token: 0x06026546 RID: 156998 RVA: 0x009D512E File Offset: 0x009D332E
		public unsafe float Character_4_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170056A7 RID: 22183
		// (get) Token: 0x06026547 RID: 156999 RVA: 0x009D513F File Offset: 0x009D333F
		// (set) Token: 0x06026548 RID: 157000 RVA: 0x009D514F File Offset: 0x009D334F
		public unsafe float Character_4_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170056A8 RID: 22184
		// (get) Token: 0x06026549 RID: 157001 RVA: 0x009D5160 File Offset: 0x009D3360
		// (set) Token: 0x0602654A RID: 157002 RVA: 0x009D5174 File Offset: 0x009D3374
		public unsafe ASkeletalMeshActor SkeletalMesh_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASkeletalMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x170056A9 RID: 22185
		// (get) Token: 0x0602654B RID: 157003 RVA: 0x009D5189 File Offset: 0x009D3389
		// (set) Token: 0x0602654C RID: 157004 RVA: 0x009D5199 File Offset: 0x009D3399
		public unsafe float SkeletalMesh_1_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170056AA RID: 22186
		// (get) Token: 0x0602654D RID: 157005 RVA: 0x009D51AA File Offset: 0x009D33AA
		// (set) Token: 0x0602654E RID: 157006 RVA: 0x009D51BA File Offset: 0x009D33BA
		public unsafe float SkeletalMesh_1_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170056AB RID: 22187
		// (get) Token: 0x0602654F RID: 157007 RVA: 0x009D51CB File Offset: 0x009D33CB
		// (set) Token: 0x06026550 RID: 157008 RVA: 0x009D51DF File Offset: 0x009D33DF
		public unsafe ASkeletalMeshActor SkeletalMesh_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASkeletalMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170056AC RID: 22188
		// (get) Token: 0x06026551 RID: 157009 RVA: 0x009D51F4 File Offset: 0x009D33F4
		// (set) Token: 0x06026552 RID: 157010 RVA: 0x009D5204 File Offset: 0x009D3404
		public unsafe float SkeletalMesh_2_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170056AD RID: 22189
		// (get) Token: 0x06026553 RID: 157011 RVA: 0x009D5215 File Offset: 0x009D3415
		// (set) Token: 0x06026554 RID: 157012 RVA: 0x009D5225 File Offset: 0x009D3425
		public unsafe float SkeletalMesh_2_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170056AE RID: 22190
		// (get) Token: 0x06026555 RID: 157013 RVA: 0x009D5236 File Offset: 0x009D3436
		// (set) Token: 0x06026556 RID: 157014 RVA: 0x009D524A File Offset: 0x009D344A
		public unsafe ASkeletalMeshActor SkeletalMesh_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASkeletalMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x170056AF RID: 22191
		// (get) Token: 0x06026557 RID: 157015 RVA: 0x009D525F File Offset: 0x009D345F
		// (set) Token: 0x06026558 RID: 157016 RVA: 0x009D526F File Offset: 0x009D346F
		public unsafe float SkeletalMesh_3_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170056B0 RID: 22192
		// (get) Token: 0x06026559 RID: 157017 RVA: 0x009D5280 File Offset: 0x009D3480
		// (set) Token: 0x0602655A RID: 157018 RVA: 0x009D5290 File Offset: 0x009D3490
		public unsafe float SkeletalMesh_3_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170056B1 RID: 22193
		// (get) Token: 0x0602655B RID: 157019 RVA: 0x009D52A1 File Offset: 0x009D34A1
		// (set) Token: 0x0602655C RID: 157020 RVA: 0x009D52B5 File Offset: 0x009D34B5
		public unsafe ASkeletalMeshActor SkeletalMesh_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASkeletalMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x170056B2 RID: 22194
		// (get) Token: 0x0602655D RID: 157021 RVA: 0x009D52CA File Offset: 0x009D34CA
		// (set) Token: 0x0602655E RID: 157022 RVA: 0x009D52DA File Offset: 0x009D34DA
		public unsafe float SkeletalMesh_4_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170056B3 RID: 22195
		// (get) Token: 0x0602655F RID: 157023 RVA: 0x009D52EB File Offset: 0x009D34EB
		// (set) Token: 0x06026560 RID: 157024 RVA: 0x009D52FB File Offset: 0x009D34FB
		public unsafe float SkeletalMesh_4_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170056B4 RID: 22196
		// (get) Token: 0x06026561 RID: 157025 RVA: 0x009D530C File Offset: 0x009D350C
		// (set) Token: 0x06026562 RID: 157026 RVA: 0x009D5320 File Offset: 0x009D3520
		public unsafe ASkeletalMeshActor SkeletalMesh_5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASkeletalMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x170056B5 RID: 22197
		// (get) Token: 0x06026563 RID: 157027 RVA: 0x009D5335 File Offset: 0x009D3535
		// (set) Token: 0x06026564 RID: 157028 RVA: 0x009D5345 File Offset: 0x009D3545
		public unsafe float SkeletalMesh_5_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170056B6 RID: 22198
		// (get) Token: 0x06026565 RID: 157029 RVA: 0x009D5356 File Offset: 0x009D3556
		// (set) Token: 0x06026566 RID: 157030 RVA: 0x009D5366 File Offset: 0x009D3566
		public unsafe float SkeletalMesh_5_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170056B7 RID: 22199
		// (get) Token: 0x06026567 RID: 157031 RVA: 0x009D5377 File Offset: 0x009D3577
		// (set) Token: 0x06026568 RID: 157032 RVA: 0x009D538B File Offset: 0x009D358B
		public unsafe ASkeletalMeshActor SkeletalMesh_6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASkeletalMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x170056B8 RID: 22200
		// (get) Token: 0x06026569 RID: 157033 RVA: 0x009D53A0 File Offset: 0x009D35A0
		// (set) Token: 0x0602656A RID: 157034 RVA: 0x009D53B0 File Offset: 0x009D35B0
		public unsafe float SkeletalMesh_6_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x170056B9 RID: 22201
		// (get) Token: 0x0602656B RID: 157035 RVA: 0x009D53C1 File Offset: 0x009D35C1
		// (set) Token: 0x0602656C RID: 157036 RVA: 0x009D53D1 File Offset: 0x009D35D1
		public unsafe float SkeletalMesh_6_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170056BA RID: 22202
		// (get) Token: 0x0602656D RID: 157037 RVA: 0x009D53E2 File Offset: 0x009D35E2
		// (set) Token: 0x0602656E RID: 157038 RVA: 0x009D53F6 File Offset: 0x009D35F6
		public unsafe USkeletalMeshComponent UISceneRole
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x170056BB RID: 22203
		// (get) Token: 0x0602656F RID: 157039 RVA: 0x009D540B File Offset: 0x009D360B
		// (set) Token: 0x06026570 RID: 157040 RVA: 0x009D541F File Offset: 0x009D361F
		public unsafe USkeletalMeshComponent UISceneRole_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x170056BC RID: 22204
		// (get) Token: 0x06026571 RID: 157041 RVA: 0x009D5434 File Offset: 0x009D3634
		// (set) Token: 0x06026572 RID: 157042 RVA: 0x009D5448 File Offset: 0x009D3648
		public unsafe AActor BP_NanzhuSeqV2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x170056BD RID: 22205
		// (get) Token: 0x06026573 RID: 157043 RVA: 0x009D545D File Offset: 0x009D365D
		// (set) Token: 0x06026574 RID: 157044 RVA: 0x009D546D File Offset: 0x009D366D
		public unsafe float BP_NanzhuSeqV2_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x170056BE RID: 22206
		// (get) Token: 0x06026575 RID: 157045 RVA: 0x009D547E File Offset: 0x009D367E
		// (set) Token: 0x06026576 RID: 157046 RVA: 0x009D548E File Offset: 0x009D368E
		public unsafe float BP_NanzhuSeqV2_LightPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x170056BF RID: 22207
		// (get) Token: 0x06026577 RID: 157047 RVA: 0x009D549F File Offset: 0x009D369F
		// (set) Token: 0x06026578 RID: 157048 RVA: 0x009D54AF File Offset: 0x009D36AF
		public unsafe float BP_NanzhuSeqV2_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x170056C0 RID: 22208
		// (get) Token: 0x06026579 RID: 157049 RVA: 0x009D54C0 File Offset: 0x009D36C0
		// (set) Token: 0x0602657A RID: 157050 RVA: 0x009D54D0 File Offset: 0x009D36D0
		public unsafe bool BP_NanzhuSeqV2_UsePointLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_39) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_39) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056C1 RID: 22209
		// (get) Token: 0x0602657B RID: 157051 RVA: 0x009D54E1 File Offset: 0x009D36E1
		// (set) Token: 0x0602657C RID: 157052 RVA: 0x009D54F5 File Offset: 0x009D36F5
		public unsafe AActor BP_NvzhuSeqV2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_40);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_40, value);
			}
		}

		// Token: 0x170056C2 RID: 22210
		// (get) Token: 0x0602657D RID: 157053 RVA: 0x009D550A File Offset: 0x009D370A
		// (set) Token: 0x0602657E RID: 157054 RVA: 0x009D551A File Offset: 0x009D371A
		public unsafe float BP_NvzhuSeqV2_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x170056C3 RID: 22211
		// (get) Token: 0x0602657F RID: 157055 RVA: 0x009D552B File Offset: 0x009D372B
		// (set) Token: 0x06026580 RID: 157056 RVA: 0x009D553B File Offset: 0x009D373B
		public unsafe float BP_NvzhuSeqV2_LightPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x170056C4 RID: 22212
		// (get) Token: 0x06026581 RID: 157057 RVA: 0x009D554C File Offset: 0x009D374C
		// (set) Token: 0x06026582 RID: 157058 RVA: 0x009D555C File Offset: 0x009D375C
		public unsafe float BP_NvzhuSeqV2_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x170056C5 RID: 22213
		// (get) Token: 0x06026583 RID: 157059 RVA: 0x009D556D File Offset: 0x009D376D
		// (set) Token: 0x06026584 RID: 157060 RVA: 0x009D557D File Offset: 0x009D377D
		public unsafe bool BP_NvzhuSeqV2_UsePointLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056C6 RID: 22214
		// (get) Token: 0x06026585 RID: 157061 RVA: 0x009D558E File Offset: 0x009D378E
		// (set) Token: 0x06026586 RID: 157062 RVA: 0x009D55A2 File Offset: 0x009D37A2
		public unsafe AActor Target_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_45);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x170056C7 RID: 22215
		// (get) Token: 0x06026587 RID: 157063 RVA: 0x009D55B7 File Offset: 0x009D37B7
		// (set) Token: 0x06026588 RID: 157064 RVA: 0x009D55C7 File Offset: 0x009D37C7
		public unsafe float Target_1_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x170056C8 RID: 22216
		// (get) Token: 0x06026589 RID: 157065 RVA: 0x009D55D8 File Offset: 0x009D37D8
		// (set) Token: 0x0602658A RID: 157066 RVA: 0x009D55E8 File Offset: 0x009D37E8
		public unsafe float Target_1_LightPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x170056C9 RID: 22217
		// (get) Token: 0x0602658B RID: 157067 RVA: 0x009D55F9 File Offset: 0x009D37F9
		// (set) Token: 0x0602658C RID: 157068 RVA: 0x009D5609 File Offset: 0x009D3809
		public unsafe float Target_1_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x170056CA RID: 22218
		// (get) Token: 0x0602658D RID: 157069 RVA: 0x009D561A File Offset: 0x009D381A
		// (set) Token: 0x0602658E RID: 157070 RVA: 0x009D562A File Offset: 0x009D382A
		public unsafe bool Target_1_UsePointLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056CB RID: 22219
		// (get) Token: 0x0602658F RID: 157071 RVA: 0x009D563B File Offset: 0x009D383B
		// (set) Token: 0x06026590 RID: 157072 RVA: 0x009D564F File Offset: 0x009D384F
		public unsafe AActor Target_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_50);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_50, value);
			}
		}

		// Token: 0x170056CC RID: 22220
		// (get) Token: 0x06026591 RID: 157073 RVA: 0x009D5664 File Offset: 0x009D3864
		// (set) Token: 0x06026592 RID: 157074 RVA: 0x009D5674 File Offset: 0x009D3874
		public unsafe float Target_2_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x170056CD RID: 22221
		// (get) Token: 0x06026593 RID: 157075 RVA: 0x009D5685 File Offset: 0x009D3885
		// (set) Token: 0x06026594 RID: 157076 RVA: 0x009D5695 File Offset: 0x009D3895
		public unsafe float Target_2_LightPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x170056CE RID: 22222
		// (get) Token: 0x06026595 RID: 157077 RVA: 0x009D56A6 File Offset: 0x009D38A6
		// (set) Token: 0x06026596 RID: 157078 RVA: 0x009D56B6 File Offset: 0x009D38B6
		public unsafe float Target_2_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x170056CF RID: 22223
		// (get) Token: 0x06026597 RID: 157079 RVA: 0x009D56C7 File Offset: 0x009D38C7
		// (set) Token: 0x06026598 RID: 157080 RVA: 0x009D56D7 File Offset: 0x009D38D7
		public unsafe bool Target_2_UsePointLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056D0 RID: 22224
		// (get) Token: 0x06026599 RID: 157081 RVA: 0x009D56E8 File Offset: 0x009D38E8
		// (set) Token: 0x0602659A RID: 157082 RVA: 0x009D56FC File Offset: 0x009D38FC
		public unsafe AActor Target_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_55);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_55, value);
			}
		}

		// Token: 0x170056D1 RID: 22225
		// (get) Token: 0x0602659B RID: 157083 RVA: 0x009D5711 File Offset: 0x009D3911
		// (set) Token: 0x0602659C RID: 157084 RVA: 0x009D5721 File Offset: 0x009D3921
		public unsafe float Target_3_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_56);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_56) = value;
			}
		}

		// Token: 0x170056D2 RID: 22226
		// (get) Token: 0x0602659D RID: 157085 RVA: 0x009D5732 File Offset: 0x009D3932
		// (set) Token: 0x0602659E RID: 157086 RVA: 0x009D5742 File Offset: 0x009D3942
		public unsafe float Target_3_LightPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x170056D3 RID: 22227
		// (get) Token: 0x0602659F RID: 157087 RVA: 0x009D5753 File Offset: 0x009D3953
		// (set) Token: 0x060265A0 RID: 157088 RVA: 0x009D5763 File Offset: 0x009D3963
		public unsafe float Target_3_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_58);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x170056D4 RID: 22228
		// (get) Token: 0x060265A1 RID: 157089 RVA: 0x009D5774 File Offset: 0x009D3974
		// (set) Token: 0x060265A2 RID: 157090 RVA: 0x009D5784 File Offset: 0x009D3984
		public unsafe bool Target_3_UsePointLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_59) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_59) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056D5 RID: 22229
		// (get) Token: 0x060265A3 RID: 157091 RVA: 0x009D5795 File Offset: 0x009D3995
		// (set) Token: 0x060265A4 RID: 157092 RVA: 0x009D57A9 File Offset: 0x009D39A9
		public unsafe AActor Target_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_60);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_60, value);
			}
		}

		// Token: 0x170056D6 RID: 22230
		// (get) Token: 0x060265A5 RID: 157093 RVA: 0x009D57BE File Offset: 0x009D39BE
		// (set) Token: 0x060265A6 RID: 157094 RVA: 0x009D57CE File Offset: 0x009D39CE
		public unsafe float Target_4_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_61);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_61) = value;
			}
		}

		// Token: 0x170056D7 RID: 22231
		// (get) Token: 0x060265A7 RID: 157095 RVA: 0x009D57DF File Offset: 0x009D39DF
		// (set) Token: 0x060265A8 RID: 157096 RVA: 0x009D57EF File Offset: 0x009D39EF
		public unsafe float Target_4_LightPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_62);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_62) = value;
			}
		}

		// Token: 0x170056D8 RID: 22232
		// (get) Token: 0x060265A9 RID: 157097 RVA: 0x009D5800 File Offset: 0x009D3A00
		// (set) Token: 0x060265AA RID: 157098 RVA: 0x009D5810 File Offset: 0x009D3A10
		public unsafe float Target_4_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_63);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_63) = value;
			}
		}

		// Token: 0x170056D9 RID: 22233
		// (get) Token: 0x060265AB RID: 157099 RVA: 0x009D5821 File Offset: 0x009D3A21
		// (set) Token: 0x060265AC RID: 157100 RVA: 0x009D5831 File Offset: 0x009D3A31
		public unsafe bool Target_4_UsePointLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_64) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_64) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056DA RID: 22234
		// (get) Token: 0x060265AD RID: 157101 RVA: 0x009D5842 File Offset: 0x009D3A42
		// (set) Token: 0x060265AE RID: 157102 RVA: 0x009D5856 File Offset: 0x009D3A56
		public unsafe AActor Target_5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_65);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_65, value);
			}
		}

		// Token: 0x170056DB RID: 22235
		// (get) Token: 0x060265AF RID: 157103 RVA: 0x009D586B File Offset: 0x009D3A6B
		// (set) Token: 0x060265B0 RID: 157104 RVA: 0x009D587B File Offset: 0x009D3A7B
		public unsafe float Target_5_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_66);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_66) = value;
			}
		}

		// Token: 0x170056DC RID: 22236
		// (get) Token: 0x060265B1 RID: 157105 RVA: 0x009D588C File Offset: 0x009D3A8C
		// (set) Token: 0x060265B2 RID: 157106 RVA: 0x009D589C File Offset: 0x009D3A9C
		public unsafe float Target_5_LightPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_67);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_67) = value;
			}
		}

		// Token: 0x170056DD RID: 22237
		// (get) Token: 0x060265B3 RID: 157107 RVA: 0x009D58AD File Offset: 0x009D3AAD
		// (set) Token: 0x060265B4 RID: 157108 RVA: 0x009D58BD File Offset: 0x009D3ABD
		public unsafe float Target_5_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_68);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_68) = value;
			}
		}

		// Token: 0x170056DE RID: 22238
		// (get) Token: 0x060265B5 RID: 157109 RVA: 0x009D58CE File Offset: 0x009D3ACE
		// (set) Token: 0x060265B6 RID: 157110 RVA: 0x009D58DE File Offset: 0x009D3ADE
		public unsafe bool Target_5_UsePointLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_69) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_69) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056DF RID: 22239
		// (get) Token: 0x060265B7 RID: 157111 RVA: 0x009D58EF File Offset: 0x009D3AEF
		// (set) Token: 0x060265B8 RID: 157112 RVA: 0x009D5903 File Offset: 0x009D3B03
		public unsafe AActor Target_6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_70);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cinematics_Tick_C.__PropertyOffset_70, value);
			}
		}

		// Token: 0x170056E0 RID: 22240
		// (get) Token: 0x060265B9 RID: 157113 RVA: 0x009D5918 File Offset: 0x009D3B18
		// (set) Token: 0x060265BA RID: 157114 RVA: 0x009D5928 File Offset: 0x009D3B28
		public unsafe float Target_6_LightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_71);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_71) = value;
			}
		}

		// Token: 0x170056E1 RID: 22241
		// (get) Token: 0x060265BB RID: 157115 RVA: 0x009D5939 File Offset: 0x009D3B39
		// (set) Token: 0x060265BC RID: 157116 RVA: 0x009D5949 File Offset: 0x009D3B49
		public unsafe float Target_6_LightPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_72);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_72) = value;
			}
		}

		// Token: 0x170056E2 RID: 22242
		// (get) Token: 0x060265BD RID: 157117 RVA: 0x009D595A File Offset: 0x009D3B5A
		// (set) Token: 0x060265BE RID: 157118 RVA: 0x009D596A File Offset: 0x009D3B6A
		public unsafe float Target_6_FaceLightYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_73);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_73) = value;
			}
		}

		// Token: 0x170056E3 RID: 22243
		// (get) Token: 0x060265BF RID: 157119 RVA: 0x009D597B File Offset: 0x009D3B7B
		// (set) Token: 0x060265C0 RID: 157120 RVA: 0x009D598B File Offset: 0x009D3B8B
		public unsafe bool IsHideMesh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_74) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_74) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056E4 RID: 22244
		// (get) Token: 0x060265C1 RID: 157121 RVA: 0x009D599C File Offset: 0x009D3B9C
		// (set) Token: 0x060265C2 RID: 157122 RVA: 0x009D59AC File Offset: 0x009D3BAC
		public unsafe bool IsHideEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_75) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_75) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056E5 RID: 22245
		// (get) Token: 0x060265C3 RID: 157123 RVA: 0x009D59BD File Offset: 0x009D3BBD
		// (set) Token: 0x060265C4 RID: 157124 RVA: 0x009D59CD File Offset: 0x009D3BCD
		public unsafe float LightShakeSpeed_Float
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_76);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_76) = value;
			}
		}

		// Token: 0x170056E6 RID: 22246
		// (get) Token: 0x060265C5 RID: 157125 RVA: 0x009D59DE File Offset: 0x009D3BDE
		// (set) Token: 0x060265C6 RID: 157126 RVA: 0x009D59EE File Offset: 0x009D3BEE
		public unsafe float LightShakeSpeed_Float_Default
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_77);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_77) = value;
			}
		}

		// Token: 0x170056E7 RID: 22247
		// (get) Token: 0x060265C7 RID: 157127 RVA: 0x009D59FF File Offset: 0x009D3BFF
		// (set) Token: 0x060265C8 RID: 157128 RVA: 0x009D5A0F File Offset: 0x009D3C0F
		public unsafe float LightShakePositionX_Float
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_78);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_78) = value;
			}
		}

		// Token: 0x170056E8 RID: 22248
		// (get) Token: 0x060265C9 RID: 157129 RVA: 0x009D5A20 File Offset: 0x009D3C20
		// (set) Token: 0x060265CA RID: 157130 RVA: 0x009D5A30 File Offset: 0x009D3C30
		public unsafe float LightShakePositionX_Float_Default
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_79);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_79) = value;
			}
		}

		// Token: 0x170056E9 RID: 22249
		// (get) Token: 0x060265CB RID: 157131 RVA: 0x009D5A41 File Offset: 0x009D3C41
		// (set) Token: 0x060265CC RID: 157132 RVA: 0x009D5A51 File Offset: 0x009D3C51
		public unsafe float LightShakePositionY_Float
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_80);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_80) = value;
			}
		}

		// Token: 0x170056EA RID: 22250
		// (get) Token: 0x060265CD RID: 157133 RVA: 0x009D5A62 File Offset: 0x009D3C62
		// (set) Token: 0x060265CE RID: 157134 RVA: 0x009D5A72 File Offset: 0x009D3C72
		public unsafe float LightShakePositionY_Float_Default
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_81);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_81) = value;
			}
		}

		// Token: 0x170056EB RID: 22251
		// (get) Token: 0x060265CF RID: 157135 RVA: 0x009D5A83 File Offset: 0x009D3C83
		// (set) Token: 0x060265D0 RID: 157136 RVA: 0x009D5A93 File Offset: 0x009D3C93
		public unsafe float LightShakeScale_Float
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_82);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_82) = value;
			}
		}

		// Token: 0x170056EC RID: 22252
		// (get) Token: 0x060265D1 RID: 157137 RVA: 0x009D5AA4 File Offset: 0x009D3CA4
		// (set) Token: 0x060265D2 RID: 157138 RVA: 0x009D5AB4 File Offset: 0x009D3CB4
		public unsafe float LightShakeScale_Float_Default
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_83);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_83) = value;
			}
		}

		// Token: 0x170056ED RID: 22253
		// (get) Token: 0x060265D3 RID: 157139 RVA: 0x009D5AC5 File Offset: 0x009D3CC5
		// (set) Token: 0x060265D4 RID: 157140 RVA: 0x009D5AD9 File Offset: 0x009D3CD9
		public unsafe FVector MainTexColorTint_Vector
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_84);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_84) = value;
			}
		}

		// Token: 0x170056EE RID: 22254
		// (get) Token: 0x060265D5 RID: 157141 RVA: 0x009D5AEE File Offset: 0x009D3CEE
		// (set) Token: 0x060265D6 RID: 157142 RVA: 0x009D5B02 File Offset: 0x009D3D02
		public unsafe FVector MainTexColorTint_Vector_Default
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_85);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_85) = value;
			}
		}

		// Token: 0x170056EF RID: 22255
		// (get) Token: 0x060265D7 RID: 157143 RVA: 0x009D5B17 File Offset: 0x009D3D17
		// (set) Token: 0x060265D8 RID: 157144 RVA: 0x009D5B27 File Offset: 0x009D3D27
		public unsafe bool MaterialControllerToggle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_86) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_86) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056F0 RID: 22256
		// (get) Token: 0x060265D9 RID: 157145 RVA: 0x009D5B38 File Offset: 0x009D3D38
		// (set) Token: 0x060265DA RID: 157146 RVA: 0x009D5B48 File Offset: 0x009D3D48
		public unsafe bool ReceiveRoleLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_87) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_87) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056F1 RID: 22257
		// (get) Token: 0x060265DB RID: 157147 RVA: 0x009D5B59 File Offset: 0x009D3D59
		// (set) Token: 0x060265DC RID: 157148 RVA: 0x009D5B69 File Offset: 0x009D3D69
		public unsafe bool IsDisableCameraCollision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_88) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_88) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056F2 RID: 22258
		// (get) Token: 0x060265DD RID: 157149 RVA: 0x009D5B7A File Offset: 0x009D3D7A
		// (set) Token: 0x060265DE RID: 157150 RVA: 0x009D5B8A File Offset: 0x009D3D8A
		public unsafe bool IsAutonomousHideMesh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_89) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_89) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056F3 RID: 22259
		// (get) Token: 0x060265DF RID: 157151 RVA: 0x009D5B9B File Offset: 0x009D3D9B
		// (set) Token: 0x060265E0 RID: 157152 RVA: 0x009D5BAB File Offset: 0x009D3DAB
		public unsafe bool IsAutonomousHideEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_90) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_90) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056F4 RID: 22260
		// (get) Token: 0x060265E1 RID: 157153 RVA: 0x009D5BBC File Offset: 0x009D3DBC
		// (set) Token: 0x060265E2 RID: 157154 RVA: 0x009D5BCC File Offset: 0x009D3DCC
		public unsafe bool IsAutonomousHideNpcMesh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_91) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_91) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056F5 RID: 22261
		// (get) Token: 0x060265E3 RID: 157155 RVA: 0x009D5BDD File Offset: 0x009D3DDD
		// (set) Token: 0x060265E4 RID: 157156 RVA: 0x009D5BED File Offset: 0x009D3DED
		public unsafe bool IsAutonomousHideNpcEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_92) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_92) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056F6 RID: 22262
		// (get) Token: 0x060265E5 RID: 157157 RVA: 0x009D5BFE File Offset: 0x009D3DFE
		// (set) Token: 0x060265E6 RID: 157158 RVA: 0x009D5C0E File Offset: 0x009D3E0E
		public unsafe bool IsHideNpcMesh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_93) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_93) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056F7 RID: 22263
		// (get) Token: 0x060265E7 RID: 157159 RVA: 0x009D5C1F File Offset: 0x009D3E1F
		// (set) Token: 0x060265E8 RID: 157160 RVA: 0x009D5C2F File Offset: 0x009D3E2F
		public unsafe bool IsHideNpcEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_94) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_94) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056F8 RID: 22264
		// (get) Token: 0x060265E9 RID: 157161 RVA: 0x009D5C40 File Offset: 0x009D3E40
		// (set) Token: 0x060265EA RID: 157162 RVA: 0x009D5C50 File Offset: 0x009D3E50
		public unsafe float HideDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_95);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_95) = value;
			}
		}

		// Token: 0x170056F9 RID: 22265
		// (get) Token: 0x060265EB RID: 157163 RVA: 0x009D5C61 File Offset: 0x009D3E61
		// (set) Token: 0x060265EC RID: 157164 RVA: 0x009D5C75 File Offset: 0x009D3E75
		[Nullable(1)]
		public unsafe string BasisBoneName
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_96)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_96)), value);
			}
		}

		// Token: 0x170056FA RID: 22266
		// (get) Token: 0x060265ED RID: 157165 RVA: 0x009D5C8A File Offset: 0x009D3E8A
		// (set) Token: 0x060265EE RID: 157166 RVA: 0x009D5C9A File Offset: 0x009D3E9A
		public unsafe bool Target_6_UsePointLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_97) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_97) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056FB RID: 22267
		// (get) Token: 0x060265EF RID: 157167 RVA: 0x009D5CAB File Offset: 0x009D3EAB
		// (set) Token: 0x060265F0 RID: 157168 RVA: 0x009D5CBB File Offset: 0x009D3EBB
		public unsafe bool LightYawNotAddRotate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_98) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_98) = (value ? 1 : 0);
			}
		}

		// Token: 0x170056FC RID: 22268
		// (get) Token: 0x060265F1 RID: 157169 RVA: 0x009D5CCC File Offset: 0x009D3ECC
		// (set) Token: 0x060265F2 RID: 157170 RVA: 0x009D5CE0 File Offset: 0x009D3EE0
		public unsafe FVector2D SubCameraSize1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_99);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_99) = value;
			}
		}

		// Token: 0x170056FD RID: 22269
		// (get) Token: 0x060265F3 RID: 157171 RVA: 0x009D5CF5 File Offset: 0x009D3EF5
		// (set) Token: 0x060265F4 RID: 157172 RVA: 0x009D5D09 File Offset: 0x009D3F09
		[Nullable(1)]
		public unsafe string SubCameraName1
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_100)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_100)), value);
			}
		}

		// Token: 0x170056FE RID: 22270
		// (get) Token: 0x060265F5 RID: 157173 RVA: 0x009D5D1E File Offset: 0x009D3F1E
		// (set) Token: 0x060265F6 RID: 157174 RVA: 0x009D5D32 File Offset: 0x009D3F32
		public unsafe FVector2D SubCameraLocation1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_101);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_101) = value;
			}
		}

		// Token: 0x170056FF RID: 22271
		// (get) Token: 0x060265F7 RID: 157175 RVA: 0x009D5D47 File Offset: 0x009D3F47
		// (set) Token: 0x060265F8 RID: 157176 RVA: 0x009D5D5B File Offset: 0x009D3F5B
		public unsafe FVector2D SubCameraSize2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_102);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_102) = value;
			}
		}

		// Token: 0x17005700 RID: 22272
		// (get) Token: 0x060265F9 RID: 157177 RVA: 0x009D5D70 File Offset: 0x009D3F70
		// (set) Token: 0x060265FA RID: 157178 RVA: 0x009D5D84 File Offset: 0x009D3F84
		[Nullable(1)]
		public unsafe string SubCameraName2
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_103)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_103)), value);
			}
		}

		// Token: 0x17005701 RID: 22273
		// (get) Token: 0x060265FB RID: 157179 RVA: 0x009D5D99 File Offset: 0x009D3F99
		// (set) Token: 0x060265FC RID: 157180 RVA: 0x009D5DAD File Offset: 0x009D3FAD
		public unsafe FVector2D SubCameraLocation2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_104);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_104) = value;
			}
		}

		// Token: 0x17005702 RID: 22274
		// (get) Token: 0x060265FD RID: 157181 RVA: 0x009D5DC2 File Offset: 0x009D3FC2
		// (set) Token: 0x060265FE RID: 157182 RVA: 0x009D5DD2 File Offset: 0x009D3FD2
		public unsafe bool SeamlessSubCamera1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_105) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_105) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005703 RID: 22275
		// (get) Token: 0x060265FF RID: 157183 RVA: 0x009D5DE3 File Offset: 0x009D3FE3
		// (set) Token: 0x06026600 RID: 157184 RVA: 0x009D5DF3 File Offset: 0x009D3FF3
		public unsafe bool SeamlessSubCamera2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_106) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cinematics_Tick_C.__PropertyOffset_106) = (value ? 1 : 0);
			}
		}

		// Token: 0x06026601 RID: 157185 RVA: 0x009D5E04 File Offset: 0x009D4004
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateSeparateCamera()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cinematics_Tick_C.__UpdateSeparateCamera_NativeFunctionPtr, null);
		}

		// Token: 0x06026602 RID: 157186 RVA: 0x009D5E18 File Offset: 0x009D4018
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateCameraCollision(AActor InActor, bool IsDisableCameraCollision)
		{
			BP_Cinematics_Tick_C.__UpdateCameraCollision_FunctionParams* ptr = stackalloc BP_Cinematics_Tick_C.__UpdateCameraCollision_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Cinematics_Tick_C.__UpdateCameraCollision_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cinematics_Tick_C.__UpdateCameraCollision_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InActor = ((InActor != null) ? InActor.NativePtr : IntPtr.Zero);
			ptr->IsDisableCameraCollision = IsDisableCameraCollision;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cinematics_Tick_C.__UpdateCameraCollision_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026603 RID: 157187 RVA: 0x009D5E74 File Offset: 0x009D4074
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FVector EulerToForward(float Pitch, float Yaw)
		{
			BP_Cinematics_Tick_C.__EulerToForward_FunctionParams* ptr = stackalloc BP_Cinematics_Tick_C.__EulerToForward_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_Cinematics_Tick_C.__EulerToForward_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cinematics_Tick_C.__EulerToForward_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Pitch = Pitch;
			ptr->Yaw = Yaw;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cinematics_Tick_C.__EulerToForward_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06026604 RID: 157188 RVA: 0x009D5EC8 File Offset: 0x009D40C8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateMeshAndEffectState([Nullable(2)] AActor InActor, bool IsHideMesh, bool IsHideEffect, bool isDestroyed, bool IsHideNpcMesh, bool IsHideNpcEffect, float HideDistance, string BasisBoneName)
		{
			BP_Cinematics_Tick_C.__UpdateMeshAndEffectState_FunctionParams* ptr = stackalloc BP_Cinematics_Tick_C.__UpdateMeshAndEffectState_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_Cinematics_Tick_C.__UpdateMeshAndEffectState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cinematics_Tick_C.__UpdateMeshAndEffectState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InActor = ((InActor != null) ? InActor.NativePtr : IntPtr.Zero);
			ptr->IsHideMesh = IsHideMesh;
			ptr->IsHideEffect = IsHideEffect;
			ptr->isDestroyed = isDestroyed;
			ptr->IsHideNpcMesh = IsHideNpcMesh;
			ptr->IsHideNpcEffect = IsHideNpcEffect;
			ptr->HideDistance = HideDistance;
			FString.CopyFrom((void*)(&ptr->BasisBoneName), BasisBoneName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cinematics_Tick_C.__UpdateMeshAndEffectState_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_Cinematics_Tick_C.__UpdateMeshAndEffectState_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026605 RID: 157189 RVA: 0x009D5F6C File Offset: 0x009D416C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetActorLight(AActor InActor, float LightYaw, float LightPitch, float FaceLightYaw, bool IsRevert, bool UsePointLight)
		{
			BP_Cinematics_Tick_C.__SetActorLight_FunctionParams* ptr = stackalloc BP_Cinematics_Tick_C.__SetActorLight_FunctionParams[(UIntPtr)255] + 15L / (long)sizeof(BP_Cinematics_Tick_C.__SetActorLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cinematics_Tick_C.__SetActorLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InActor = ((InActor != null) ? InActor.NativePtr : IntPtr.Zero);
			ptr->LightYaw = LightYaw;
			ptr->LightPitch = LightPitch;
			ptr->FaceLightYaw = FaceLightYaw;
			ptr->IsRevert = IsRevert;
			ptr->UsePointLight = UsePointLight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cinematics_Tick_C.__SetActorLight_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026606 RID: 157190 RVA: 0x009D5FEC File Offset: 0x009D41EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ProcessCombinNPC(BP_SeqNPC_C Mesh, float LightYaw, float FaceLightYaw)
		{
			BP_Cinematics_Tick_C.__ProcessCombinNPC_FunctionParams* ptr = stackalloc BP_Cinematics_Tick_C.__ProcessCombinNPC_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_Cinematics_Tick_C.__ProcessCombinNPC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cinematics_Tick_C.__ProcessCombinNPC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			ptr->LightYaw = LightYaw;
			ptr->FaceLightYaw = FaceLightYaw;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cinematics_Tick_C.__ProcessCombinNPC_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026607 RID: 157191 RVA: 0x009D6050 File Offset: 0x009D4250
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RevertLightDirection(USkeletalMeshComponent Mesh)
		{
			BP_Cinematics_Tick_C.__RevertLightDirection_FunctionParams* ptr = stackalloc BP_Cinematics_Tick_C.__RevertLightDirection_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_Cinematics_Tick_C.__RevertLightDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cinematics_Tick_C.__RevertLightDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cinematics_Tick_C.__RevertLightDirection_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026608 RID: 157192 RVA: 0x009D60A8 File Offset: 0x009D42A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetLightDirection(USkeletalMeshComponent Mesh, float LightYaw, float LightPitch, float FaceLightYaw, bool UsePointLight)
		{
			BP_Cinematics_Tick_C.__SetLightDirection_FunctionParams* ptr = stackalloc BP_Cinematics_Tick_C.__SetLightDirection_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_Cinematics_Tick_C.__SetLightDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cinematics_Tick_C.__SetLightDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			ptr->LightYaw = LightYaw;
			ptr->LightPitch = LightPitch;
			ptr->FaceLightYaw = FaceLightYaw;
			ptr->UsePointLight = UsePointLight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cinematics_Tick_C.__SetLightDirection_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026609 RID: 157193 RVA: 0x009D611B File Offset: 0x009D431B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cinematics_Tick_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602660A RID: 157194 RVA: 0x009D612F File Offset: 0x009D432F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cinematics_Tick_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602660B RID: 157195 RVA: 0x009D6144 File Offset: 0x009D4344
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Cinematics_Tick_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cinematics_Tick_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cinematics_Tick_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cinematics_Tick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cinematics_Tick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602660C RID: 157196 RVA: 0x009D618C File Offset: 0x009D438C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Cinematics_Tick_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cinematics_Tick_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cinematics_Tick_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cinematics_Tick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cinematics_Tick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602660D RID: 157197 RVA: 0x009D61D4 File Offset: 0x009D43D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Cinematics_Tick_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cinematics_Tick_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cinematics_Tick_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cinematics_Tick_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cinematics_Tick_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602660E RID: 157198 RVA: 0x009D621C File Offset: 0x009D441C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Cinematics_Tick_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cinematics_Tick_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cinematics_Tick_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cinematics_Tick_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cinematics_Tick_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602660F RID: 157199 RVA: 0x009D6263 File Offset: 0x009D4463
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cinematics_Tick_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x06026610 RID: 157200 RVA: 0x009D6277 File Offset: 0x009D4477
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cinematics_Tick_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026611 RID: 157201 RVA: 0x009D628C File Offset: 0x009D448C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cinematics_Tick_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06026612 RID: 157202 RVA: 0x009D62A0 File Offset: 0x009D44A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cinematics_Tick_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026613 RID: 157203 RVA: 0x009D62B8 File Offset: 0x009D44B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cinematics_Tick(int EntryPoint)
		{
			BP_Cinematics_Tick_C.__ExecuteUbergraph_BP_Cinematics_Tick_FunctionParams* ptr = stackalloc BP_Cinematics_Tick_C.__ExecuteUbergraph_BP_Cinematics_Tick_FunctionParams[(UIntPtr)559] + 15L / (long)sizeof(BP_Cinematics_Tick_C.__ExecuteUbergraph_BP_Cinematics_Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cinematics_Tick_C.__ExecuteUbergraph_BP_Cinematics_Tick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cinematics_Tick_C.__ExecuteUbergraph_BP_Cinematics_Tick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026614 RID: 157204 RVA: 0x009D6302 File Offset: 0x009D4502
		protected BP_Cinematics_Tick_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013E0B RID: 81419
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/BP_Cinematics_Tick.BP_Cinematics_Tick_C";

		// Token: 0x04013E0C RID: 81420
		private static IntPtr _ClassPtr;

		// Token: 0x04013E0D RID: 81421
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013E0E RID: 81422
		internal static int __PropertyOffset_0;

		// Token: 0x04013E0F RID: 81423
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013E10 RID: 81424
		internal static int __PropertyOffset_1;

		// Token: 0x04013E11 RID: 81425
		internal static int __PropertyOffset_2;

		// Token: 0x04013E12 RID: 81426
		internal static int __PropertyOffset_3;

		// Token: 0x04013E13 RID: 81427
		internal static int __PropertyOffset_4;

		// Token: 0x04013E14 RID: 81428
		internal static int __PropertyOffset_5;

		// Token: 0x04013E15 RID: 81429
		internal static int __PropertyOffset_6;

		// Token: 0x04013E16 RID: 81430
		internal static int __PropertyOffset_7;

		// Token: 0x04013E17 RID: 81431
		internal static int __PropertyOffset_8;

		// Token: 0x04013E18 RID: 81432
		internal static int __PropertyOffset_9;

		// Token: 0x04013E19 RID: 81433
		internal static int __PropertyOffset_10;

		// Token: 0x04013E1A RID: 81434
		internal static int __PropertyOffset_11;

		// Token: 0x04013E1B RID: 81435
		internal static int __PropertyOffset_12;

		// Token: 0x04013E1C RID: 81436
		internal static int __PropertyOffset_13;

		// Token: 0x04013E1D RID: 81437
		internal static int __PropertyOffset_14;

		// Token: 0x04013E1E RID: 81438
		internal static int __PropertyOffset_15;

		// Token: 0x04013E1F RID: 81439
		internal static int __PropertyOffset_16;

		// Token: 0x04013E20 RID: 81440
		internal static int __PropertyOffset_17;

		// Token: 0x04013E21 RID: 81441
		internal static int __PropertyOffset_18;

		// Token: 0x04013E22 RID: 81442
		internal static int __PropertyOffset_19;

		// Token: 0x04013E23 RID: 81443
		internal static int __PropertyOffset_20;

		// Token: 0x04013E24 RID: 81444
		internal static int __PropertyOffset_21;

		// Token: 0x04013E25 RID: 81445
		internal static int __PropertyOffset_22;

		// Token: 0x04013E26 RID: 81446
		internal static int __PropertyOffset_23;

		// Token: 0x04013E27 RID: 81447
		internal static int __PropertyOffset_24;

		// Token: 0x04013E28 RID: 81448
		internal static int __PropertyOffset_25;

		// Token: 0x04013E29 RID: 81449
		internal static int __PropertyOffset_26;

		// Token: 0x04013E2A RID: 81450
		internal static int __PropertyOffset_27;

		// Token: 0x04013E2B RID: 81451
		internal static int __PropertyOffset_28;

		// Token: 0x04013E2C RID: 81452
		internal static int __PropertyOffset_29;

		// Token: 0x04013E2D RID: 81453
		internal static int __PropertyOffset_30;

		// Token: 0x04013E2E RID: 81454
		internal static int __PropertyOffset_31;

		// Token: 0x04013E2F RID: 81455
		internal static int __PropertyOffset_32;

		// Token: 0x04013E30 RID: 81456
		internal static int __PropertyOffset_33;

		// Token: 0x04013E31 RID: 81457
		internal static int __PropertyOffset_34;

		// Token: 0x04013E32 RID: 81458
		internal static int __PropertyOffset_35;

		// Token: 0x04013E33 RID: 81459
		internal static int __PropertyOffset_36;

		// Token: 0x04013E34 RID: 81460
		internal static int __PropertyOffset_37;

		// Token: 0x04013E35 RID: 81461
		internal static int __PropertyOffset_38;

		// Token: 0x04013E36 RID: 81462
		internal static int __PropertyOffset_39;

		// Token: 0x04013E37 RID: 81463
		internal static int __PropertyOffset_40;

		// Token: 0x04013E38 RID: 81464
		internal static int __PropertyOffset_41;

		// Token: 0x04013E39 RID: 81465
		internal static int __PropertyOffset_42;

		// Token: 0x04013E3A RID: 81466
		internal static int __PropertyOffset_43;

		// Token: 0x04013E3B RID: 81467
		internal static int __PropertyOffset_44;

		// Token: 0x04013E3C RID: 81468
		internal static int __PropertyOffset_45;

		// Token: 0x04013E3D RID: 81469
		internal static int __PropertyOffset_46;

		// Token: 0x04013E3E RID: 81470
		internal static int __PropertyOffset_47;

		// Token: 0x04013E3F RID: 81471
		internal static int __PropertyOffset_48;

		// Token: 0x04013E40 RID: 81472
		internal static int __PropertyOffset_49;

		// Token: 0x04013E41 RID: 81473
		internal static int __PropertyOffset_50;

		// Token: 0x04013E42 RID: 81474
		internal static int __PropertyOffset_51;

		// Token: 0x04013E43 RID: 81475
		internal static int __PropertyOffset_52;

		// Token: 0x04013E44 RID: 81476
		internal static int __PropertyOffset_53;

		// Token: 0x04013E45 RID: 81477
		internal static int __PropertyOffset_54;

		// Token: 0x04013E46 RID: 81478
		internal static int __PropertyOffset_55;

		// Token: 0x04013E47 RID: 81479
		internal static int __PropertyOffset_56;

		// Token: 0x04013E48 RID: 81480
		internal static int __PropertyOffset_57;

		// Token: 0x04013E49 RID: 81481
		internal static int __PropertyOffset_58;

		// Token: 0x04013E4A RID: 81482
		internal static int __PropertyOffset_59;

		// Token: 0x04013E4B RID: 81483
		internal static int __PropertyOffset_60;

		// Token: 0x04013E4C RID: 81484
		internal static int __PropertyOffset_61;

		// Token: 0x04013E4D RID: 81485
		internal static int __PropertyOffset_62;

		// Token: 0x04013E4E RID: 81486
		internal static int __PropertyOffset_63;

		// Token: 0x04013E4F RID: 81487
		internal static int __PropertyOffset_64;

		// Token: 0x04013E50 RID: 81488
		internal static int __PropertyOffset_65;

		// Token: 0x04013E51 RID: 81489
		internal static int __PropertyOffset_66;

		// Token: 0x04013E52 RID: 81490
		internal static int __PropertyOffset_67;

		// Token: 0x04013E53 RID: 81491
		internal static int __PropertyOffset_68;

		// Token: 0x04013E54 RID: 81492
		internal static int __PropertyOffset_69;

		// Token: 0x04013E55 RID: 81493
		internal static int __PropertyOffset_70;

		// Token: 0x04013E56 RID: 81494
		internal static int __PropertyOffset_71;

		// Token: 0x04013E57 RID: 81495
		internal static int __PropertyOffset_72;

		// Token: 0x04013E58 RID: 81496
		internal static int __PropertyOffset_73;

		// Token: 0x04013E59 RID: 81497
		internal static int __PropertyOffset_74;

		// Token: 0x04013E5A RID: 81498
		internal static int __PropertyOffset_75;

		// Token: 0x04013E5B RID: 81499
		internal static int __PropertyOffset_76;

		// Token: 0x04013E5C RID: 81500
		internal static int __PropertyOffset_77;

		// Token: 0x04013E5D RID: 81501
		internal static int __PropertyOffset_78;

		// Token: 0x04013E5E RID: 81502
		internal static int __PropertyOffset_79;

		// Token: 0x04013E5F RID: 81503
		internal static int __PropertyOffset_80;

		// Token: 0x04013E60 RID: 81504
		internal static int __PropertyOffset_81;

		// Token: 0x04013E61 RID: 81505
		internal static int __PropertyOffset_82;

		// Token: 0x04013E62 RID: 81506
		internal static int __PropertyOffset_83;

		// Token: 0x04013E63 RID: 81507
		internal static int __PropertyOffset_84;

		// Token: 0x04013E64 RID: 81508
		internal static int __PropertyOffset_85;

		// Token: 0x04013E65 RID: 81509
		internal static int __PropertyOffset_86;

		// Token: 0x04013E66 RID: 81510
		internal static int __PropertyOffset_87;

		// Token: 0x04013E67 RID: 81511
		internal static int __PropertyOffset_88;

		// Token: 0x04013E68 RID: 81512
		internal static int __PropertyOffset_89;

		// Token: 0x04013E69 RID: 81513
		internal static int __PropertyOffset_90;

		// Token: 0x04013E6A RID: 81514
		internal static int __PropertyOffset_91;

		// Token: 0x04013E6B RID: 81515
		internal static int __PropertyOffset_92;

		// Token: 0x04013E6C RID: 81516
		internal static int __PropertyOffset_93;

		// Token: 0x04013E6D RID: 81517
		internal static int __PropertyOffset_94;

		// Token: 0x04013E6E RID: 81518
		internal static int __PropertyOffset_95;

		// Token: 0x04013E6F RID: 81519
		internal static int __PropertyOffset_96;

		// Token: 0x04013E70 RID: 81520
		internal static int __PropertyOffset_97;

		// Token: 0x04013E71 RID: 81521
		internal static int __PropertyOffset_98;

		// Token: 0x04013E72 RID: 81522
		internal static int __PropertyOffset_99;

		// Token: 0x04013E73 RID: 81523
		internal static int __PropertyOffset_100;

		// Token: 0x04013E74 RID: 81524
		internal static int __PropertyOffset_101;

		// Token: 0x04013E75 RID: 81525
		internal static int __PropertyOffset_102;

		// Token: 0x04013E76 RID: 81526
		internal static int __PropertyOffset_103;

		// Token: 0x04013E77 RID: 81527
		internal static int __PropertyOffset_104;

		// Token: 0x04013E78 RID: 81528
		internal static int __PropertyOffset_105;

		// Token: 0x04013E79 RID: 81529
		internal static int __PropertyOffset_106;

		// Token: 0x04013E7A RID: 81530
		private static IntPtr __UpdateSeparateCamera_NativeFunctionPtr;

		// Token: 0x04013E7B RID: 81531
		private static IntPtr __UpdateCameraCollision_NativeFunctionPtr;

		// Token: 0x04013E7C RID: 81532
		private static IntPtr __EulerToForward_NativeFunctionPtr;

		// Token: 0x04013E7D RID: 81533
		private static IntPtr __UpdateMeshAndEffectState_NativeFunctionPtr;

		// Token: 0x04013E7E RID: 81534
		private static IntPtr __SetActorLight_NativeFunctionPtr;

		// Token: 0x04013E7F RID: 81535
		private static IntPtr __ProcessCombinNPC_NativeFunctionPtr;

		// Token: 0x04013E80 RID: 81536
		private static IntPtr __RevertLightDirection_NativeFunctionPtr;

		// Token: 0x04013E81 RID: 81537
		private static IntPtr __SetLightDirection_NativeFunctionPtr;

		// Token: 0x04013E82 RID: 81538
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013E83 RID: 81539
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013E84 RID: 81540
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04013E85 RID: 81541
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x04013E86 RID: 81542
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013E87 RID: 81543
		private static IntPtr __ExecuteUbergraph_BP_Cinematics_Tick_NativeFunctionPtr;

		// Token: 0x0200A053 RID: 41043
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __UpdateCameraCollision_FunctionParams
		{
			// Token: 0x04032C95 RID: 208021
			[FieldOffset(0)]
			public IntPtr InActor;

			// Token: 0x04032C96 RID: 208022
			[FieldOffset(8)]
			public bool IsDisableCameraCollision;
		}

		// Token: 0x0200A054 RID: 41044
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __EulerToForward_FunctionParams
		{
			// Token: 0x04032C97 RID: 208023
			[FieldOffset(0)]
			public float Pitch;

			// Token: 0x04032C98 RID: 208024
			[FieldOffset(4)]
			public float Yaw;

			// Token: 0x04032C99 RID: 208025
			[FieldOffset(8)]
			public FVector __Result;
		}

		// Token: 0x0200A055 RID: 41045
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __UpdateMeshAndEffectState_FunctionParams
		{
			// Token: 0x04032C9A RID: 208026
			[FieldOffset(0)]
			public IntPtr InActor;

			// Token: 0x04032C9B RID: 208027
			[FieldOffset(8)]
			public bool IsHideMesh;

			// Token: 0x04032C9C RID: 208028
			[FieldOffset(9)]
			public bool IsHideEffect;

			// Token: 0x04032C9D RID: 208029
			[FieldOffset(10)]
			public bool isDestroyed;

			// Token: 0x04032C9E RID: 208030
			[FieldOffset(11)]
			public bool IsHideNpcMesh;

			// Token: 0x04032C9F RID: 208031
			[FieldOffset(12)]
			public bool IsHideNpcEffect;

			// Token: 0x04032CA0 RID: 208032
			[FieldOffset(16)]
			public float HideDistance;

			// Token: 0x04032CA1 RID: 208033
			[FieldOffset(24)]
			public FString BasisBoneName;
		}

		// Token: 0x0200A056 RID: 41046
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 240)]
		protected ref struct __SetActorLight_FunctionParams
		{
			// Token: 0x04032CA2 RID: 208034
			[FieldOffset(0)]
			public IntPtr InActor;

			// Token: 0x04032CA3 RID: 208035
			[FieldOffset(8)]
			public float LightYaw;

			// Token: 0x04032CA4 RID: 208036
			[FieldOffset(12)]
			public float LightPitch;

			// Token: 0x04032CA5 RID: 208037
			[FieldOffset(16)]
			public float FaceLightYaw;

			// Token: 0x04032CA6 RID: 208038
			[FieldOffset(20)]
			public bool IsRevert;

			// Token: 0x04032CA7 RID: 208039
			[FieldOffset(21)]
			public bool UsePointLight;
		}

		// Token: 0x0200A057 RID: 41047
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ProcessCombinNPC_FunctionParams
		{
			// Token: 0x04032CA8 RID: 208040
			[FieldOffset(0)]
			public IntPtr Mesh;

			// Token: 0x04032CA9 RID: 208041
			[FieldOffset(8)]
			public float LightYaw;

			// Token: 0x04032CAA RID: 208042
			[FieldOffset(12)]
			public float FaceLightYaw;
		}

		// Token: 0x0200A058 RID: 41048
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __RevertLightDirection_FunctionParams
		{
			// Token: 0x04032CAB RID: 208043
			[FieldOffset(0)]
			public IntPtr Mesh;
		}

		// Token: 0x0200A059 RID: 41049
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __SetLightDirection_FunctionParams
		{
			// Token: 0x04032CAC RID: 208044
			[FieldOffset(0)]
			public IntPtr Mesh;

			// Token: 0x04032CAD RID: 208045
			[FieldOffset(8)]
			public float LightYaw;

			// Token: 0x04032CAE RID: 208046
			[FieldOffset(12)]
			public float LightPitch;

			// Token: 0x04032CAF RID: 208047
			[FieldOffset(16)]
			public float FaceLightYaw;

			// Token: 0x04032CB0 RID: 208048
			[FieldOffset(20)]
			public bool UsePointLight;
		}

		// Token: 0x0200A05A RID: 41050
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032CB1 RID: 208049
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A05B RID: 41051
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032CB2 RID: 208050
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A05C RID: 41052
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 544)]
		protected ref struct __ExecuteUbergraph_BP_Cinematics_Tick_FunctionParams
		{
			// Token: 0x04032CB3 RID: 208051
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
