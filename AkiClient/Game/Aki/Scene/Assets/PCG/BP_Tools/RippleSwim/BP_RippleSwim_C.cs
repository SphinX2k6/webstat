using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using AkiClient.Game.Aki.Render.Data.Water;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Scene.Assets.PCG.BP_Tools.RippleSwim
{
	// Token: 0x020039F1 RID: 14833
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Scene/Assets/PCG/BP_Tools/RippleSwim/BP_RippleSwim.BP_RippleSwim_C")]
	[UnrealStructLayout(2016, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2009)]
	public class BP_RippleSwim_C : AKuroBPCustomCookActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E146 RID: 123206 RVA: 0x008EB3B8 File Offset: 0x008E95B8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RippleSwim_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Scene/Assets/PCG/BP_Tools/RippleSwim/BP_RippleSwim.BP_RippleSwim_C");
			}
			return BP_RippleSwim_C._ClassPtr;
		}

		// Token: 0x0601E147 RID: 123207 RVA: 0x008EB3DC File Offset: 0x008E95DC
		public BP_RippleSwim_C() : this(BuiltinUtils.AllocNativeUObject(BP_RippleSwim_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E148 RID: 123208 RVA: 0x008EB404 File Offset: 0x008E9604
		[NullableContext(1)]
		public BP_RippleSwim_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RippleSwim_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700284B RID: 10315
		// (get) Token: 0x0601E149 RID: 123209 RVA: 0x008EB438 File Offset: 0x008E9638
		// (set) Token: 0x0601E14A RID: 123210 RVA: 0x008EB471 File Offset: 0x008E9671
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700284C RID: 10316
		// (get) Token: 0x0601E14B RID: 123211 RVA: 0x008EB492 File Offset: 0x008E9692
		// (set) Token: 0x0601E14C RID: 123212 RVA: 0x008EB4A6 File Offset: 0x008E96A6
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700284D RID: 10317
		// (get) Token: 0x0601E14D RID: 123213 RVA: 0x008EB4BB File Offset: 0x008E96BB
		// (set) Token: 0x0601E14E RID: 123214 RVA: 0x008EB4CF File Offset: 0x008E96CF
		public unsafe UMaterialInstanceDynamic AddNewMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700284E RID: 10318
		// (get) Token: 0x0601E14F RID: 123215 RVA: 0x008EB4E4 File Offset: 0x008E96E4
		// (set) Token: 0x0601E150 RID: 123216 RVA: 0x008EB4F8 File Offset: 0x008E96F8
		public unsafe UMaterialInstanceDynamic tempToPrevMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700284F RID: 10319
		// (get) Token: 0x0601E151 RID: 123217 RVA: 0x008EB50D File Offset: 0x008E970D
		// (set) Token: 0x0601E152 RID: 123218 RVA: 0x008EB521 File Offset: 0x008E9721
		public unsafe UMaterialInstanceDynamic DrawMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002850 RID: 10320
		// (get) Token: 0x0601E153 RID: 123219 RVA: 0x008EB536 File Offset: 0x008E9736
		// (set) Token: 0x0601E154 RID: 123220 RVA: 0x008EB546 File Offset: 0x008E9746
		public unsafe bool bSim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002851 RID: 10321
		// (get) Token: 0x0601E155 RID: 123221 RVA: 0x008EB557 File Offset: 0x008E9757
		// (set) Token: 0x0601E156 RID: 123222 RVA: 0x008EB56B File Offset: 0x008E976B
		public unsafe AActor Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002852 RID: 10322
		// (get) Token: 0x0601E157 RID: 123223 RVA: 0x008EB580 File Offset: 0x008E9780
		// (set) Token: 0x0601E158 RID: 123224 RVA: 0x008EB590 File Offset: 0x008E9790
		public unsafe int PrevState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002853 RID: 10323
		// (get) Token: 0x0601E159 RID: 123225 RVA: 0x008EB5A1 File Offset: 0x008E97A1
		// (set) Token: 0x0601E15A RID: 123226 RVA: 0x008EB5B1 File Offset: 0x008E97B1
		public unsafe int State
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002854 RID: 10324
		// (get) Token: 0x0601E15B RID: 123227 RVA: 0x008EB5C4 File Offset: 0x008E97C4
		// (set) Token: 0x0601E15C RID: 123228 RVA: 0x008EB5FD File Offset: 0x008E97FD
		[Nullable(1)]
		public FGameplayTagContainer Tag_Container
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._Tag_Container) == null)
				{
					result = (this._Tag_Container = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002855 RID: 10325
		// (get) Token: 0x0601E15D RID: 123229 RVA: 0x008EB61E File Offset: 0x008E981E
		// (set) Token: 0x0601E15E RID: 123230 RVA: 0x008EB632 File Offset: 0x008E9832
		public unsafe BP_RippleWater_Data_C Current_Ripple_State
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_RippleWater_Data_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17002856 RID: 10326
		// (get) Token: 0x0601E15F RID: 123231 RVA: 0x008EB647 File Offset: 0x008E9847
		// (set) Token: 0x0601E160 RID: 123232 RVA: 0x008EB657 File Offset: 0x008E9857
		public unsafe float Step
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002857 RID: 10327
		// (get) Token: 0x0601E161 RID: 123233 RVA: 0x008EB668 File Offset: 0x008E9868
		// (set) Token: 0x0601E162 RID: 123234 RVA: 0x008EB678 File Offset: 0x008E9878
		public unsafe float captureSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002858 RID: 10328
		// (get) Token: 0x0601E163 RID: 123235 RVA: 0x008EB689 File Offset: 0x008E9889
		// (set) Token: 0x0601E164 RID: 123236 RVA: 0x008EB69D File Offset: 0x008E989D
		public unsafe UMaterialInstanceDynamic rippleMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17002859 RID: 10329
		// (get) Token: 0x0601E165 RID: 123237 RVA: 0x008EB6B2 File Offset: 0x008E98B2
		// (set) Token: 0x0601E166 RID: 123238 RVA: 0x008EB6C6 File Offset: 0x008E98C6
		public unsafe UTextureRenderTarget2D prevRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x1700285A RID: 10330
		// (get) Token: 0x0601E167 RID: 123239 RVA: 0x008EB6DB File Offset: 0x008E98DB
		// (set) Token: 0x0601E168 RID: 123240 RVA: 0x008EB6EF File Offset: 0x008E98EF
		public unsafe UTextureRenderTarget2D currentRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x1700285B RID: 10331
		// (get) Token: 0x0601E169 RID: 123241 RVA: 0x008EB704 File Offset: 0x008E9904
		// (set) Token: 0x0601E16A RID: 123242 RVA: 0x008EB718 File Offset: 0x008E9918
		public unsafe UTextureRenderTarget2D tempRTRef
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700285C RID: 10332
		// (get) Token: 0x0601E16B RID: 123243 RVA: 0x008EB72D File Offset: 0x008E992D
		// (set) Token: 0x0601E16C RID: 123244 RVA: 0x008EB741 File Offset: 0x008E9941
		public unsafe FVector PlayerLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700285D RID: 10333
		// (get) Token: 0x0601E16D RID: 123245 RVA: 0x008EB756 File Offset: 0x008E9956
		// (set) Token: 0x0601E16E RID: 123246 RVA: 0x008EB76A File Offset: 0x008E996A
		public unsafe FVector2D Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700285E RID: 10334
		// (get) Token: 0x0601E16F RID: 123247 RVA: 0x008EB77F File Offset: 0x008E997F
		// (set) Token: 0x0601E170 RID: 123248 RVA: 0x008EB793 File Offset: 0x008E9993
		public unsafe AActor TestActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x1700285F RID: 10335
		// (get) Token: 0x0601E171 RID: 123249 RVA: 0x008EB7A8 File Offset: 0x008E99A8
		// (set) Token: 0x0601E172 RID: 123250 RVA: 0x008EB7B8 File Offset: 0x008E99B8
		public unsafe float PlayerSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002860 RID: 10336
		// (get) Token: 0x0601E173 RID: 123251 RVA: 0x008EB7C9 File Offset: 0x008E99C9
		// (set) Token: 0x0601E174 RID: 123252 RVA: 0x008EB7DD File Offset: 0x008E99DD
		public unsafe UMaterialParameterCollection Global_MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17002861 RID: 10337
		// (get) Token: 0x0601E175 RID: 123253 RVA: 0x008EB7F2 File Offset: 0x008E99F2
		// (set) Token: 0x0601E176 RID: 123254 RVA: 0x008EB802 File Offset: 0x008E9A02
		public unsafe bool bPlayerInWaterLast
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002862 RID: 10338
		// (get) Token: 0x0601E177 RID: 123255 RVA: 0x008EB813 File Offset: 0x008E9A13
		// (set) Token: 0x0601E178 RID: 123256 RVA: 0x008EB823 File Offset: 0x008E9A23
		public unsafe float RippleDistanceNormal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17002863 RID: 10339
		// (get) Token: 0x0601E179 RID: 123257 RVA: 0x008EB834 File Offset: 0x008E9A34
		// (set) Token: 0x0601E17A RID: 123258 RVA: 0x008EB844 File Offset: 0x008E9A44
		public unsafe float RippleDistanceFluo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17002864 RID: 10340
		// (get) Token: 0x0601E17B RID: 123259 RVA: 0x008EB855 File Offset: 0x008E9A55
		// (set) Token: 0x0601E17C RID: 123260 RVA: 0x008EB869 File Offset: 0x008E9A69
		public unsafe FVector2D PositionOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17002865 RID: 10341
		// (get) Token: 0x0601E17D RID: 123261 RVA: 0x008EB87E File Offset: 0x008E9A7E
		// (set) Token: 0x0601E17E RID: 123262 RVA: 0x008EB892 File Offset: 0x008E9A92
		public unsafe FVector LastRippleLocationNormal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17002866 RID: 10342
		// (get) Token: 0x0601E17F RID: 123263 RVA: 0x008EB8A7 File Offset: 0x008E9AA7
		// (set) Token: 0x0601E180 RID: 123264 RVA: 0x008EB8B7 File Offset: 0x008E9AB7
		public unsafe float RippleOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17002867 RID: 10343
		// (get) Token: 0x0601E181 RID: 123265 RVA: 0x008EB8C8 File Offset: 0x008E9AC8
		// (set) Token: 0x0601E182 RID: 123266 RVA: 0x008EB8DC File Offset: 0x008E9ADC
		public unsafe FVector LastRippleLocationFluo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17002868 RID: 10344
		// (get) Token: 0x0601E183 RID: 123267 RVA: 0x008EB8F1 File Offset: 0x008E9AF1
		// (set) Token: 0x0601E184 RID: 123268 RVA: 0x008EB901 File Offset: 0x008E9B01
		public unsafe float SwimRippleOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17002869 RID: 10345
		// (get) Token: 0x0601E185 RID: 123269 RVA: 0x008EB912 File Offset: 0x008E9B12
		// (set) Token: 0x0601E186 RID: 123270 RVA: 0x008EB926 File Offset: 0x008E9B26
		public unsafe FVector2D PlayerPosNormal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x1700286A RID: 10346
		// (get) Token: 0x0601E187 RID: 123271 RVA: 0x008EB93B File Offset: 0x008E9B3B
		// (set) Token: 0x0601E188 RID: 123272 RVA: 0x008EB94F File Offset: 0x008E9B4F
		public unsafe FVector2D PlayerPosFluo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700286B RID: 10347
		// (get) Token: 0x0601E189 RID: 123273 RVA: 0x008EB964 File Offset: 0x008E9B64
		// (set) Token: 0x0601E18A RID: 123274 RVA: 0x008EB974 File Offset: 0x008E9B74
		public unsafe float LastRipplePastTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x1700286C RID: 10348
		// (get) Token: 0x0601E18B RID: 123275 RVA: 0x008EB985 File Offset: 0x008E9B85
		// (set) Token: 0x0601E18C RID: 123276 RVA: 0x008EB999 File Offset: 0x008E9B99
		public unsafe BP_RippleWater_Data_C Swim_Ripple
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_RippleWater_Data_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x1700286D RID: 10349
		// (get) Token: 0x0601E18D RID: 123277 RVA: 0x008EB9AE File Offset: 0x008E9BAE
		// (set) Token: 0x0601E18E RID: 123278 RVA: 0x008EB9C2 File Offset: 0x008E9BC2
		public unsafe BP_RippleWater_Data_C Gongduola_Ripple
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_RippleWater_Data_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x1700286E RID: 10350
		// (get) Token: 0x0601E18F RID: 123279 RVA: 0x008EB9D7 File Offset: 0x008E9BD7
		// (set) Token: 0x0601E190 RID: 123280 RVA: 0x008EB9EB File Offset: 0x008E9BEB
		public unsafe BP_RippleWater_Data_C Fly_Ripple
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_RippleWater_Data_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x1700286F RID: 10351
		// (get) Token: 0x0601E191 RID: 123281 RVA: 0x008EBA00 File Offset: 0x008E9C00
		// (set) Token: 0x0601E192 RID: 123282 RVA: 0x008EBA14 File Offset: 0x008E9C14
		public unsafe BP_RippleWater_Data_C Drop_Ripple
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_RippleWater_Data_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17002870 RID: 10352
		// (get) Token: 0x0601E193 RID: 123283 RVA: 0x008EBA29 File Offset: 0x008E9C29
		// (set) Token: 0x0601E194 RID: 123284 RVA: 0x008EBA39 File Offset: 0x008E9C39
		public unsafe bool InFixedRippleArea
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_37) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_37) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002871 RID: 10353
		// (get) Token: 0x0601E195 RID: 123285 RVA: 0x008EBA4A File Offset: 0x008E9C4A
		// (set) Token: 0x0601E196 RID: 123286 RVA: 0x008EBA5E File Offset: 0x008E9C5E
		public unsafe UTextureRenderTarget2D PersistRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x17002872 RID: 10354
		// (get) Token: 0x0601E197 RID: 123287 RVA: 0x008EBA73 File Offset: 0x008E9C73
		// (set) Token: 0x0601E198 RID: 123288 RVA: 0x008EBA87 File Offset: 0x008E9C87
		public unsafe UTextureRenderTarget2D FinalRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x17002873 RID: 10355
		// (get) Token: 0x0601E199 RID: 123289 RVA: 0x008EBA9C File Offset: 0x008E9C9C
		// (set) Token: 0x0601E19A RID: 123290 RVA: 0x008EBAAC File Offset: 0x008E9CAC
		public unsafe bool bCustomRippleState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002874 RID: 10356
		// (get) Token: 0x0601E19B RID: 123291 RVA: 0x008EBABD File Offset: 0x008E9CBD
		// (set) Token: 0x0601E19C RID: 123292 RVA: 0x008EBAD1 File Offset: 0x008E9CD1
		public unsafe BP_SceneBattleInteract_C BulletConfig
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SceneBattleInteract_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_41);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_41, value);
			}
		}

		// Token: 0x17002875 RID: 10357
		// (get) Token: 0x0601E19D RID: 123293 RVA: 0x008EBAE6 File Offset: 0x008E9CE6
		// (set) Token: 0x0601E19E RID: 123294 RVA: 0x008EBAFA File Offset: 0x008E9CFA
		public unsafe FVector2D BulletUV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17002876 RID: 10358
		// (get) Token: 0x0601E19F RID: 123295 RVA: 0x008EBB0F File Offset: 0x008E9D0F
		// (set) Token: 0x0601E1A0 RID: 123296 RVA: 0x008EBB23 File Offset: 0x008E9D23
		public unsafe FVector2D LastBulletUV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17002877 RID: 10359
		// (get) Token: 0x0601E1A1 RID: 123297 RVA: 0x008EBB38 File Offset: 0x008E9D38
		// (set) Token: 0x0601E1A2 RID: 123298 RVA: 0x008EBB48 File Offset: 0x008E9D48
		public unsafe bool bSetUV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002878 RID: 10360
		// (get) Token: 0x0601E1A3 RID: 123299 RVA: 0x008EBB59 File Offset: 0x008E9D59
		// (set) Token: 0x0601E1A4 RID: 123300 RVA: 0x008EBB69 File Offset: 0x008E9D69
		public unsafe bool bShowDebugData
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002879 RID: 10361
		// (get) Token: 0x0601E1A5 RID: 123301 RVA: 0x008EBB7A File Offset: 0x008E9D7A
		// (set) Token: 0x0601E1A6 RID: 123302 RVA: 0x008EBB8A File Offset: 0x008E9D8A
		public unsafe double 翱翔射线长度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x1700287A RID: 10362
		// (get) Token: 0x0601E1A7 RID: 123303 RVA: 0x008EBB9B File Offset: 0x008E9D9B
		// (set) Token: 0x0601E1A8 RID: 123304 RVA: 0x008EBBAB File Offset: 0x008E9DAB
		public unsafe float CurrRippleOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x1700287B RID: 10363
		// (get) Token: 0x0601E1A9 RID: 123305 RVA: 0x008EBBBC File Offset: 0x008E9DBC
		// (set) Token: 0x0601E1AA RID: 123306 RVA: 0x008EBBCC File Offset: 0x008E9DCC
		public unsafe float CurrRippleIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x1700287C RID: 10364
		// (get) Token: 0x0601E1AB RID: 123307 RVA: 0x008EBBDD File Offset: 0x008E9DDD
		// (set) Token: 0x0601E1AC RID: 123308 RVA: 0x008EBBED File Offset: 0x008E9DED
		public unsafe float RippleIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x1700287D RID: 10365
		// (get) Token: 0x0601E1AD RID: 123309 RVA: 0x008EBBFE File Offset: 0x008E9DFE
		// (set) Token: 0x0601E1AE RID: 123310 RVA: 0x008EBC0E File Offset: 0x008E9E0E
		public unsafe float FlyMaxDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x1700287E RID: 10366
		// (get) Token: 0x0601E1AF RID: 123311 RVA: 0x008EBC1F File Offset: 0x008E9E1F
		// (set) Token: 0x0601E1B0 RID: 123312 RVA: 0x008EBC2F File Offset: 0x008E9E2F
		public unsafe float FlyMinDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x1700287F RID: 10367
		// (get) Token: 0x0601E1B1 RID: 123313 RVA: 0x008EBC40 File Offset: 0x008E9E40
		// (set) Token: 0x0601E1B2 RID: 123314 RVA: 0x008EBC50 File Offset: 0x008E9E50
		public unsafe float RippleAttenuation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17002880 RID: 10368
		// (get) Token: 0x0601E1B3 RID: 123315 RVA: 0x008EBC61 File Offset: 0x008E9E61
		// (set) Token: 0x0601E1B4 RID: 123316 RVA: 0x008EBC75 File Offset: 0x008E9E75
		public unsafe FVectorDouble AvailblePoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17002881 RID: 10369
		// (get) Token: 0x0601E1B5 RID: 123317 RVA: 0x008EBC8A File Offset: 0x008E9E8A
		// (set) Token: 0x0601E1B6 RID: 123318 RVA: 0x008EBC9E File Offset: 0x008E9E9E
		public unsafe FVectorDouble LastAvailblePoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x17002882 RID: 10370
		// (get) Token: 0x0601E1B7 RID: 123319 RVA: 0x008EBCB3 File Offset: 0x008E9EB3
		// (set) Token: 0x0601E1B8 RID: 123320 RVA: 0x008EBCC3 File Offset: 0x008E9EC3
		public unsafe float BulletMinConnectDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_55);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_55) = value;
			}
		}

		// Token: 0x17002883 RID: 10371
		// (get) Token: 0x0601E1B9 RID: 123321 RVA: 0x008EBCD4 File Offset: 0x008E9ED4
		// (set) Token: 0x0601E1BA RID: 123322 RVA: 0x008EBCE4 File Offset: 0x008E9EE4
		public unsafe float BulletMaxConnectDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_56);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_56) = value;
			}
		}

		// Token: 0x17002884 RID: 10372
		// (get) Token: 0x0601E1BB RID: 123323 RVA: 0x008EBCF5 File Offset: 0x008E9EF5
		// (set) Token: 0x0601E1BC RID: 123324 RVA: 0x008EBD05 File Offset: 0x008E9F05
		public unsafe double Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x17002885 RID: 10373
		// (get) Token: 0x0601E1BD RID: 123325 RVA: 0x008EBD16 File Offset: 0x008E9F16
		// (set) Token: 0x0601E1BE RID: 123326 RVA: 0x008EBD26 File Offset: 0x008E9F26
		public unsafe float BulletLastHitTime0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_58);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x17002886 RID: 10374
		// (get) Token: 0x0601E1BF RID: 123327 RVA: 0x008EBD38 File Offset: 0x008E9F38
		// (set) Token: 0x0601E1C0 RID: 123328 RVA: 0x008EBD71 File Offset: 0x008E9F71
		[Nullable(1)]
		public TArray<FVectorDouble> BulletPointList0
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._BulletPointList0) == null)
				{
					result = (this._BulletPointList0 = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_59, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BulletPointList0.CopyAssign(value);
			}
		}

		// Token: 0x17002887 RID: 10375
		// (get) Token: 0x0601E1C1 RID: 123329 RVA: 0x008EBD7F File Offset: 0x008E9F7F
		// (set) Token: 0x0601E1C2 RID: 123330 RVA: 0x008EBD8F File Offset: 0x008E9F8F
		public unsafe float BulletLastHitTime1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_60);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_60) = value;
			}
		}

		// Token: 0x17002888 RID: 10376
		// (get) Token: 0x0601E1C3 RID: 123331 RVA: 0x008EBDA0 File Offset: 0x008E9FA0
		// (set) Token: 0x0601E1C4 RID: 123332 RVA: 0x008EBDD9 File Offset: 0x008E9FD9
		[Nullable(1)]
		public TArray<FVectorDouble> BulletPointList1
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._BulletPointList1) == null)
				{
					result = (this._BulletPointList1 = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_61, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BulletPointList1.CopyAssign(value);
			}
		}

		// Token: 0x17002889 RID: 10377
		// (get) Token: 0x0601E1C5 RID: 123333 RVA: 0x008EBDE7 File Offset: 0x008E9FE7
		// (set) Token: 0x0601E1C6 RID: 123334 RVA: 0x008EBDF7 File Offset: 0x008E9FF7
		public unsafe float BulletLastHitTime2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_62);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_62) = value;
			}
		}

		// Token: 0x1700288A RID: 10378
		// (get) Token: 0x0601E1C7 RID: 123335 RVA: 0x008EBE08 File Offset: 0x008EA008
		// (set) Token: 0x0601E1C8 RID: 123336 RVA: 0x008EBE41 File Offset: 0x008EA041
		[Nullable(1)]
		public TArray<FVectorDouble> BulletPointList2
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._BulletPointList2) == null)
				{
					result = (this._BulletPointList2 = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_63, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BulletPointList2.CopyAssign(value);
			}
		}

		// Token: 0x1700288B RID: 10379
		// (get) Token: 0x0601E1C9 RID: 123337 RVA: 0x008EBE4F File Offset: 0x008EA04F
		// (set) Token: 0x0601E1CA RID: 123338 RVA: 0x008EBE5F File Offset: 0x008EA05F
		public unsafe int CatMullStep
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_64);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_64) = value;
			}
		}

		// Token: 0x1700288C RID: 10380
		// (get) Token: 0x0601E1CB RID: 123339 RVA: 0x008EBE70 File Offset: 0x008EA070
		// (set) Token: 0x0601E1CC RID: 123340 RVA: 0x008EBE80 File Offset: 0x008EA080
		public unsafe float Alpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_65);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_65) = value;
			}
		}

		// Token: 0x1700288D RID: 10381
		// (get) Token: 0x0601E1CD RID: 123341 RVA: 0x008EBE91 File Offset: 0x008EA091
		// (set) Token: 0x0601E1CE RID: 123342 RVA: 0x008EBEA1 File Offset: 0x008EA0A1
		public unsafe float Tension
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_66);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_66) = value;
			}
		}

		// Token: 0x1700288E RID: 10382
		// (get) Token: 0x0601E1CF RID: 123343 RVA: 0x008EBEB4 File Offset: 0x008EA0B4
		// (set) Token: 0x0601E1D0 RID: 123344 RVA: 0x008EBEED File Offset: 0x008EA0ED
		[Nullable(1)]
		public TArray<FVectorDouble> AvailblePointList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._AvailblePointList) == null)
				{
					result = (this._AvailblePointList = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_67, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.AvailblePointList.CopyAssign(value);
			}
		}

		// Token: 0x1700288F RID: 10383
		// (get) Token: 0x0601E1D1 RID: 123345 RVA: 0x008EBEFB File Offset: 0x008EA0FB
		// (set) Token: 0x0601E1D2 RID: 123346 RVA: 0x008EBF0F File Offset: 0x008EA10F
		public unsafe UTextureRenderTarget2D PointRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_68);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_68, value);
			}
		}

		// Token: 0x17002890 RID: 10384
		// (get) Token: 0x0601E1D3 RID: 123347 RVA: 0x008EBF24 File Offset: 0x008EA124
		// (set) Token: 0x0601E1D4 RID: 123348 RVA: 0x008EBF38 File Offset: 0x008EA138
		public unsafe UMaterialInstanceDynamic AddPointsMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_69);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_69, value);
			}
		}

		// Token: 0x17002891 RID: 10385
		// (get) Token: 0x0601E1D5 RID: 123349 RVA: 0x008EBF4D File Offset: 0x008EA14D
		// (set) Token: 0x0601E1D6 RID: 123350 RVA: 0x008EBF61 File Offset: 0x008EA161
		public unsafe UMaterialInstanceDynamic AddCapsuleMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_70);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_70, value);
			}
		}

		// Token: 0x17002892 RID: 10386
		// (get) Token: 0x0601E1D7 RID: 123351 RVA: 0x008EBF76 File Offset: 0x008EA176
		// (set) Token: 0x0601E1D8 RID: 123352 RVA: 0x008EBF8A File Offset: 0x008EA18A
		[Nullable(0)]
		public unsafe TEnumAsByte<EDrawDebugTrace> Fly_Ray_Debug_Type
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_71);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_71) = value;
			}
		}

		// Token: 0x17002893 RID: 10387
		// (get) Token: 0x0601E1D9 RID: 123353 RVA: 0x008EBF9F File Offset: 0x008EA19F
		// (set) Token: 0x0601E1DA RID: 123354 RVA: 0x008EBFB3 File Offset: 0x008EA1B3
		public unsafe FVector2D CurrentRippleCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_72);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_72) = value;
			}
		}

		// Token: 0x17002894 RID: 10388
		// (get) Token: 0x0601E1DB RID: 123355 RVA: 0x008EBFC8 File Offset: 0x008EA1C8
		// (set) Token: 0x0601E1DC RID: 123356 RVA: 0x008EBFD8 File Offset: 0x008EA1D8
		public unsafe bool UseOldRipple
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_73) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_73) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002895 RID: 10389
		// (get) Token: 0x0601E1DD RID: 123357 RVA: 0x008EBFE9 File Offset: 0x008EA1E9
		// (set) Token: 0x0601E1DE RID: 123358 RVA: 0x008EBFF9 File Offset: 0x008EA1F9
		public unsafe float NewCaptureSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_74);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_74) = value;
			}
		}

		// Token: 0x17002896 RID: 10390
		// (get) Token: 0x0601E1DF RID: 123359 RVA: 0x008EC00A File Offset: 0x008EA20A
		// (set) Token: 0x0601E1E0 RID: 123360 RVA: 0x008EC01E File Offset: 0x008EA21E
		public unsafe UMaterialInstanceDynamic NewRipplePrevMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_75);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_75, value);
			}
		}

		// Token: 0x17002897 RID: 10391
		// (get) Token: 0x0601E1E1 RID: 123361 RVA: 0x008EC033 File Offset: 0x008EA233
		// (set) Token: 0x0601E1E2 RID: 123362 RVA: 0x008EC047 File Offset: 0x008EA247
		public unsafe FLinearColor Weapon_0_Debug_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_76);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_76) = value;
			}
		}

		// Token: 0x17002898 RID: 10392
		// (get) Token: 0x0601E1E3 RID: 123363 RVA: 0x008EC05C File Offset: 0x008EA25C
		// (set) Token: 0x0601E1E4 RID: 123364 RVA: 0x008EC070 File Offset: 0x008EA270
		public unsafe FLinearColor Weapon_1_Debug_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_77);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_77) = value;
			}
		}

		// Token: 0x17002899 RID: 10393
		// (get) Token: 0x0601E1E5 RID: 123365 RVA: 0x008EC085 File Offset: 0x008EA285
		// (set) Token: 0x0601E1E6 RID: 123366 RVA: 0x008EC099 File Offset: 0x008EA299
		public unsafe FLinearColor Weapon_2_Debug_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_78);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_78) = value;
			}
		}

		// Token: 0x1700289A RID: 10394
		// (get) Token: 0x0601E1E7 RID: 123367 RVA: 0x008EC0AE File Offset: 0x008EA2AE
		// (set) Token: 0x0601E1E8 RID: 123368 RVA: 0x008EC0C2 File Offset: 0x008EA2C2
		public unsafe FVector2D RippleCenterOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_79);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_79) = value;
			}
		}

		// Token: 0x1700289B RID: 10395
		// (get) Token: 0x0601E1E9 RID: 123369 RVA: 0x008EC0D7 File Offset: 0x008EA2D7
		// (set) Token: 0x0601E1EA RID: 123370 RVA: 0x008EC0EB File Offset: 0x008EA2EB
		public unsafe BP_RippleWater_Data_C Fuludelisi_Ripple
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_RippleWater_Data_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_80);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_80, value);
			}
		}

		// Token: 0x1700289C RID: 10396
		// (get) Token: 0x0601E1EB RID: 123371 RVA: 0x008EC100 File Offset: 0x008EA300
		// (set) Token: 0x0601E1EC RID: 123372 RVA: 0x008EC110 File Offset: 0x008EA310
		public unsafe bool bEnableSwimRipple
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_81) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_81) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700289D RID: 10397
		// (get) Token: 0x0601E1ED RID: 123373 RVA: 0x008EC121 File Offset: 0x008EA321
		// (set) Token: 0x0601E1EE RID: 123374 RVA: 0x008EC131 File Offset: 0x008EA331
		public unsafe float WaterDepth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_82);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_82) = value;
			}
		}

		// Token: 0x1700289E RID: 10398
		// (get) Token: 0x0601E1EF RID: 123375 RVA: 0x008EC142 File Offset: 0x008EA342
		// (set) Token: 0x0601E1F0 RID: 123376 RVA: 0x008EC152 File Offset: 0x008EA352
		public unsafe float FallJumpDepthThreshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_83);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_83) = value;
			}
		}

		// Token: 0x1700289F RID: 10399
		// (get) Token: 0x0601E1F1 RID: 123377 RVA: 0x008EC163 File Offset: 0x008EA363
		// (set) Token: 0x0601E1F2 RID: 123378 RVA: 0x008EC177 File Offset: 0x008EA377
		public unsafe BP_RippleWater_Data_C Moto_Ripple
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_RippleWater_Data_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_84);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RippleSwim_C.__PropertyOffset_84, value);
			}
		}

		// Token: 0x170028A0 RID: 10400
		// (get) Token: 0x0601E1F3 RID: 123379 RVA: 0x008EC18C File Offset: 0x008EA38C
		// (set) Token: 0x0601E1F4 RID: 123380 RVA: 0x008EC19C File Offset: 0x008EA39C
		public unsafe bool bForceSwimRipple
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_85) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleSwim_C.__PropertyOffset_85) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601E1F5 RID: 123381 RVA: 0x008EC1AD File Offset: 0x008EA3AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Ripple_Stamp()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Ripple_Stamp_NativeFunctionPtr, null);
		}

		// Token: 0x0601E1F6 RID: 123382 RVA: 0x008EC1C1 File Offset: 0x008EA3C1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Ripple_Simulation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Ripple_Simulation_NativeFunctionPtr, null);
		}

		// Token: 0x0601E1F7 RID: 123383 RVA: 0x008EC1D8 File Offset: 0x008EA3D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CheckAndSetPos(float DeltaSeconds, ref float LastRippleTime)
		{
			BP_RippleSwim_C.__CheckAndSetPos_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__CheckAndSetPos_FunctionParams[(UIntPtr)1359] + 15L / (long)sizeof(BP_RippleSwim_C.__CheckAndSetPos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__CheckAndSetPos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			ptr->LastRippleTime = LastRippleTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__CheckAndSetPos_NativeFunctionPtr, (void*)ptr);
			LastRippleTime = ptr->LastRippleTime;
		}

		// Token: 0x0601E1F8 RID: 123384 RVA: 0x008EC231 File Offset: 0x008EA431
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetCloseSwimRipple()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__SetCloseSwimRipple_NativeFunctionPtr, null);
		}

		// Token: 0x0601E1F9 RID: 123385 RVA: 0x008EC248 File Offset: 0x008EA448
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Set_Bullet_Data(BP_SceneBattleInteract_C Config)
		{
			BP_RippleSwim_C.__Set_Bullet_Data_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__Set_Bullet_Data_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_RippleSwim_C.__Set_Bullet_Data_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__Set_Bullet_Data_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Set_Bullet_Data_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E1FA RID: 123386 RVA: 0x008EC29D File Offset: 0x008EA49D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetNewRipple()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__SetNewRipple_NativeFunctionPtr, null);
		}

		// Token: 0x0601E1FB RID: 123387 RVA: 0x008EC2B1 File Offset: 0x008EA4B1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetOldRipple()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__SetOldRipple_NativeFunctionPtr, null);
		}

		// Token: 0x0601E1FC RID: 123388 RVA: 0x008EC2C8 File Offset: 0x008EA4C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TexcoordToPosition(FVectorDouble RippleCenter, FVector2D RippleUV, float CaptureSize, ref FVector2D Position)
		{
			BP_RippleSwim_C.__TexcoordToPosition_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__TexcoordToPosition_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_RippleSwim_C.__TexcoordToPosition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__TexcoordToPosition_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RippleCenter = RippleCenter;
			ptr->RippleUV = RippleUV;
			ptr->CaptureSize = CaptureSize;
			ptr->Position = Position;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__TexcoordToPosition_NativeFunctionPtr, (void*)ptr);
			Position = ptr->Position;
		}

		// Token: 0x0601E1FD RID: 123389 RVA: 0x008EC33C File Offset: 0x008EA53C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Calc_Circle_Weapon_2(BP_SceneBattleInteract_C BulletConfig, FVectorDouble AvailblePoint)
		{
			BP_RippleSwim_C.__Calc_Circle_Weapon_2_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__Calc_Circle_Weapon_2_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_RippleSwim_C.__Calc_Circle_Weapon_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__Calc_Circle_Weapon_2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BulletConfig = ((BulletConfig != null) ? BulletConfig.NativePtr : IntPtr.Zero);
			ptr->AvailblePoint = AvailblePoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Calc_Circle_Weapon_2_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E1FE RID: 123390 RVA: 0x008EC39C File Offset: 0x008EA59C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Calc_Capsule_Weapon_2(BP_SceneBattleInteract_C BulletConfig, FVectorDouble AvailblePoint)
		{
			BP_RippleSwim_C.__Calc_Capsule_Weapon_2_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__Calc_Capsule_Weapon_2_FunctionParams[(UIntPtr)247] + 15L / (long)sizeof(BP_RippleSwim_C.__Calc_Capsule_Weapon_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__Calc_Capsule_Weapon_2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BulletConfig = ((BulletConfig != null) ? BulletConfig.NativePtr : IntPtr.Zero);
			ptr->AvailblePoint = AvailblePoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Calc_Capsule_Weapon_2_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E1FF RID: 123391 RVA: 0x008EC3FC File Offset: 0x008EA5FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Compare_New_Point_Weapon_2(FVectorDouble V2, ref bool Vaild)
		{
			BP_RippleSwim_C.__Compare_New_Point_Weapon_2_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__Compare_New_Point_Weapon_2_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_RippleSwim_C.__Compare_New_Point_Weapon_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__Compare_New_Point_Weapon_2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->V2 = V2;
			ptr->Vaild = Vaild;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Compare_New_Point_Weapon_2_NativeFunctionPtr, (void*)ptr);
			Vaild = ptr->Vaild;
		}

		// Token: 0x0601E200 RID: 123392 RVA: 0x008EC454 File Offset: 0x008EA654
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Calc_Catmull_Weapon_2(BP_SceneBattleInteract_C BulletConfig, FVectorDouble AvailblePoint)
		{
			BP_RippleSwim_C.__Calc_Catmull_Weapon_2_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__Calc_Catmull_Weapon_2_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(BP_RippleSwim_C.__Calc_Catmull_Weapon_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__Calc_Catmull_Weapon_2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BulletConfig = ((BulletConfig != null) ? BulletConfig.NativePtr : IntPtr.Zero);
			ptr->AvailblePoint = AvailblePoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Calc_Catmull_Weapon_2_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E201 RID: 123393 RVA: 0x008EC4B4 File Offset: 0x008EA6B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Compare_New_Point_Weapon_1(FVectorDouble V2, ref bool Vaild)
		{
			BP_RippleSwim_C.__Compare_New_Point_Weapon_1_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__Compare_New_Point_Weapon_1_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_RippleSwim_C.__Compare_New_Point_Weapon_1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__Compare_New_Point_Weapon_1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->V2 = V2;
			ptr->Vaild = Vaild;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Compare_New_Point_Weapon_1_NativeFunctionPtr, (void*)ptr);
			Vaild = ptr->Vaild;
		}

		// Token: 0x0601E202 RID: 123394 RVA: 0x008EC50C File Offset: 0x008EA70C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Calc_Catmull_Weapon_1(BP_SceneBattleInteract_C BulletConfig, FVectorDouble AvailblePoint)
		{
			BP_RippleSwim_C.__Calc_Catmull_Weapon_1_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__Calc_Catmull_Weapon_1_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(BP_RippleSwim_C.__Calc_Catmull_Weapon_1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__Calc_Catmull_Weapon_1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BulletConfig = ((BulletConfig != null) ? BulletConfig.NativePtr : IntPtr.Zero);
			ptr->AvailblePoint = AvailblePoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Calc_Catmull_Weapon_1_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E203 RID: 123395 RVA: 0x008EC56C File Offset: 0x008EA76C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Compare_New_Point_Weapon_0(FVectorDouble V2, ref bool Vaild)
		{
			BP_RippleSwim_C.__Compare_New_Point_Weapon_0_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__Compare_New_Point_Weapon_0_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_RippleSwim_C.__Compare_New_Point_Weapon_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__Compare_New_Point_Weapon_0_NativeFunctionPtr, (void*)ptr, 1);
			ptr->V2 = V2;
			ptr->Vaild = Vaild;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Compare_New_Point_Weapon_0_NativeFunctionPtr, (void*)ptr);
			Vaild = ptr->Vaild;
		}

		// Token: 0x0601E204 RID: 123396 RVA: 0x008EC5C4 File Offset: 0x008EA7C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Calc_Catmull_Weapon_0(BP_SceneBattleInteract_C BulletConfig, FVectorDouble AvailblePoint)
		{
			BP_RippleSwim_C.__Calc_Catmull_Weapon_0_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__Calc_Catmull_Weapon_0_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(BP_RippleSwim_C.__Calc_Catmull_Weapon_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__Calc_Catmull_Weapon_0_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BulletConfig = ((BulletConfig != null) ? BulletConfig.NativePtr : IntPtr.Zero);
			ptr->AvailblePoint = AvailblePoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Calc_Catmull_Weapon_0_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E205 RID: 123397 RVA: 0x008EC624 File Offset: 0x008EA824
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcTexCoord2D(FVectorDouble RippleCenter, FVector2D RipplePointLocation, float CaptureSize, ref FVector2D TexCoord)
		{
			BP_RippleSwim_C.__CalcTexCoord2D_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__CalcTexCoord2D_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_RippleSwim_C.__CalcTexCoord2D_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__CalcTexCoord2D_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RippleCenter = RippleCenter;
			ptr->RipplePointLocation = RipplePointLocation;
			ptr->CaptureSize = CaptureSize;
			ptr->TexCoord = TexCoord;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__CalcTexCoord2D_NativeFunctionPtr, (void*)ptr);
			TexCoord = ptr->TexCoord;
		}

		// Token: 0x0601E206 RID: 123398 RVA: 0x008EC698 File Offset: 0x008EA898
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetPointsV3(ref TArray<FVectorDouble> PointList, ref bool Vaild, ref FVector2D P_0, ref FVector2D P_1, ref FVector2D P_2, ref FVector2D P_3)
		{
			BP_RippleSwim_C.__GetPointsV3_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__GetPointsV3_FunctionParams[(UIntPtr)343] + 15L / (long)sizeof(BP_RippleSwim_C.__GetPointsV3_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__GetPointsV3_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FVectorDouble> tarray = PointList;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->PointList);
			}
			ptr->Vaild = Vaild;
			ptr->P_0 = P_0;
			ptr->P_1 = P_1;
			ptr->P_2 = P_2;
			ptr->P_3 = P_3;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__GetPointsV3_NativeFunctionPtr, (void*)ptr);
			TArray<FVectorDouble> tarray2 = PointList;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->PointList);
			}
			Vaild = ptr->Vaild;
			P_0 = ptr->P_0;
			P_1 = ptr->P_1;
			P_2 = ptr->P_2;
			P_3 = ptr->P_3;
			UnrealReflectionUtils.DestroyStruct(BP_RippleSwim_C.__GetPointsV3_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601E207 RID: 123399 RVA: 0x008EC78C File Offset: 0x008EA98C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetPoints(ref TArray<FVector2D> PointList, ref bool Vaild, ref FVector2D P_0, ref FVector2D P_1, ref FVector2D P_2, ref FVector2D P_3)
		{
			BP_RippleSwim_C.__GetPoints_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__GetPoints_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_RippleSwim_C.__GetPoints_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__GetPoints_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FVector2D> tarray = PointList;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->PointList);
			}
			ptr->Vaild = Vaild;
			ptr->P_0 = P_0;
			ptr->P_1 = P_1;
			ptr->P_2 = P_2;
			ptr->P_3 = P_3;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__GetPoints_NativeFunctionPtr, (void*)ptr);
			TArray<FVector2D> tarray2 = PointList;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->PointList);
			}
			Vaild = ptr->Vaild;
			P_0 = ptr->P_0;
			P_1 = ptr->P_1;
			P_2 = ptr->P_2;
			P_3 = ptr->P_3;
			UnrealReflectionUtils.DestroyStruct(BP_RippleSwim_C.__GetPoints_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601E208 RID: 123400 RVA: 0x008EC880 File Offset: 0x008EAA80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CatmullRom(ref TArray<FVector2D> PointList, int StepCount, ref bool Vaild, ref TArray<FVector2D> CurveList)
		{
			BP_RippleSwim_C.__CatmullRom_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__CatmullRom_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(BP_RippleSwim_C.__CatmullRom_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__CatmullRom_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FVector2D> tarray = PointList;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->PointList);
			}
			ptr->StepCount = StepCount;
			ptr->Vaild = Vaild;
			TArray<FVector2D> tarray2 = CurveList;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->CurveList);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__CatmullRom_NativeFunctionPtr, (void*)ptr);
			TArray<FVector2D> tarray3 = PointList;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->PointList);
			}
			Vaild = ptr->Vaild;
			TArray<FVector2D> tarray4 = CurveList;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->CurveList);
			}
			UnrealReflectionUtils.DestroyStruct(BP_RippleSwim_C.__CatmullRom_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601E209 RID: 123401 RVA: 0x008EC93C File Offset: 0x008EAB3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcDistance2D(FVectorDouble V1, FVectorDouble V2, ref double Distance)
		{
			BP_RippleSwim_C.__CalcDistance2D_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__CalcDistance2D_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_RippleSwim_C.__CalcDistance2D_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__CalcDistance2D_NativeFunctionPtr, (void*)ptr, 1);
			ptr->V1 = V1;
			ptr->V2 = V2;
			ptr->Distance = Distance;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__CalcDistance2D_NativeFunctionPtr, (void*)ptr);
			Distance = ptr->Distance;
		}

		// Token: 0x0601E20A RID: 123402 RVA: 0x008EC99C File Offset: 0x008EAB9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Choose_Available_Point(FVectorDouble CollisionPoint, FVectorDouble WeaponPoint, BP_SceneBattleInteract_C ConfigDA, ref FVectorDouble AvailblePoint)
		{
			BP_RippleSwim_C.__Choose_Available_Point_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__Choose_Available_Point_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_RippleSwim_C.__Choose_Available_Point_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__Choose_Available_Point_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CollisionPoint = CollisionPoint;
			ptr->WeaponPoint = WeaponPoint;
			ptr->ConfigDA = ((ConfigDA != null) ? ConfigDA.NativePtr : IntPtr.Zero);
			ptr->AvailblePoint = AvailblePoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Choose_Available_Point_NativeFunctionPtr, (void*)ptr);
			AvailblePoint = ptr->AvailblePoint;
		}

		// Token: 0x0601E20B RID: 123403 RVA: 0x008ECA1C File Offset: 0x008EAC1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Change_Ripple_Preset(BP_RippleWater_Data_C NewRippleState)
		{
			BP_RippleSwim_C.__Change_Ripple_Preset_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__Change_Ripple_Preset_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_RippleSwim_C.__Change_Ripple_Preset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__Change_Ripple_Preset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewRippleState = ((NewRippleState != null) ? NewRippleState.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Change_Ripple_Preset_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E20C RID: 123404 RVA: 0x008ECA74 File Offset: 0x008EAC74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcTexCoord(FVectorDouble RippleCenter, FVectorDouble RipplePointLocation, float CaptureSize, ref FVector TexCoord)
		{
			BP_RippleSwim_C.__CalcTexCoord_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__CalcTexCoord_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_RippleSwim_C.__CalcTexCoord_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RippleCenter = RippleCenter;
			ptr->RipplePointLocation = RipplePointLocation;
			ptr->CaptureSize = CaptureSize;
			ptr->TexCoord = TexCoord;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr);
			TexCoord = ptr->TexCoord;
		}

		// Token: 0x0601E20D RID: 123405 RVA: 0x008ECAE5 File Offset: 0x008EACE5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Clear_RT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Clear_RT_NativeFunctionPtr, null);
		}

		// Token: 0x0601E20E RID: 123406 RVA: 0x008ECAFC File Offset: 0x008EACFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetWaterRippleData(BP_RippleWater_Data_C InputPin)
		{
			BP_RippleSwim_C.__SetWaterRippleData_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__SetWaterRippleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_RippleSwim_C.__SetWaterRippleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__SetWaterRippleData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InputPin = ((InputPin != null) ? InputPin.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__SetWaterRippleData_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E20F RID: 123407 RVA: 0x008ECB54 File Offset: 0x008EAD54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AboveWater(FVector Location, ref bool bAboveWater)
		{
			BP_RippleSwim_C.__AboveWater_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__AboveWater_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_RippleSwim_C.__AboveWater_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__AboveWater_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Location = Location;
			ptr->bAboveWater = bAboveWater;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__AboveWater_NativeFunctionPtr, (void*)ptr);
			bAboveWater = ptr->bAboveWater;
		}

		// Token: 0x0601E210 RID: 123408 RVA: 0x008ECBAA File Offset: 0x008EADAA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E211 RID: 123409 RVA: 0x008ECBBE File Offset: 0x008EADBE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RippleSwim_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E212 RID: 123410 RVA: 0x008ECBD3 File Offset: 0x008EADD3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E213 RID: 123411 RVA: 0x008ECBE7 File Offset: 0x008EADE7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RippleSwim_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E214 RID: 123412 RVA: 0x008ECBFC File Offset: 0x008EADFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_RippleSwim_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RippleSwim_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E215 RID: 123413 RVA: 0x008ECC44 File Offset: 0x008EAE44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_RippleSwim_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RippleSwim_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RippleSwim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E216 RID: 123414 RVA: 0x008ECC8B File Offset: 0x008EAE8B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Refresh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__Refresh_NativeFunctionPtr, null);
		}

		// Token: 0x0601E217 RID: 123415 RVA: 0x008ECC9F File Offset: 0x008EAE9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeCookForMobile()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__BeforeCookForMobile_NativeFunctionPtr, null);
		}

		// Token: 0x0601E218 RID: 123416 RVA: 0x008ECCB3 File Offset: 0x008EAEB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeCookForMobile_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RippleSwim_C.__BeforeCookForMobile_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E219 RID: 123417 RVA: 0x008ECCC8 File Offset: 0x008EAEC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnBulletHitWater(FVectorDouble ImpactPoint, BP_SceneBattleInteract_C Config, FVectorDouble OriginPoint, int Id)
		{
			BP_RippleSwim_C.__OnBulletHitWater_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__OnBulletHitWater_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_RippleSwim_C.__OnBulletHitWater_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__OnBulletHitWater_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ImpactPoint = ImpactPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->OriginPoint = OriginPoint;
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__OnBulletHitWater_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E21A RID: 123418 RVA: 0x008ECD34 File Offset: 0x008EAF34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BulletHitPos(FVectorDouble ImpactPoint, BP_SceneBattleInteract_C Config, FVectorDouble OriginPoint, int Id)
		{
			BP_RippleSwim_C.__BulletHitPos_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__BulletHitPos_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_RippleSwim_C.__BulletHitPos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__BulletHitPos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ImpactPoint = ImpactPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->OriginPoint = OriginPoint;
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__BulletHitPos_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E21B RID: 123419 RVA: 0x008ECDA0 File Offset: 0x008EAFA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnBulletHitPos(FVectorDouble ImpactPoint, BP_SceneBattleInteract_C Config, FVectorDouble OriginPoint, int Id)
		{
			BP_RippleSwim_C.__OnBulletHitPos_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__OnBulletHitPos_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_RippleSwim_C.__OnBulletHitPos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__OnBulletHitPos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ImpactPoint = ImpactPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->OriginPoint = OriginPoint;
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__OnBulletHitPos_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E21C RID: 123420 RVA: 0x008ECE0C File Offset: 0x008EB00C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TestHitEvent(FVectorDouble ImpactPoint, BP_SceneBattleInteract_C Config, FVectorDouble OriginPoint, int Id)
		{
			BP_RippleSwim_C.__TestHitEvent_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__TestHitEvent_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_RippleSwim_C.__TestHitEvent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__TestHitEvent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ImpactPoint = ImpactPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->OriginPoint = OriginPoint;
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__TestHitEvent_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E21D RID: 123421 RVA: 0x008ECE78 File Offset: 0x008EB078
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_RippleSwim_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_RippleSwim_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RippleSwim_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E21E RID: 123422 RVA: 0x008ECEC4 File Offset: 0x008EB0C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_RippleSwim_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_RippleSwim_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RippleSwim_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E21F RID: 123423 RVA: 0x008ECF10 File Offset: 0x008EB110
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_RippleSwim(int EntryPoint)
		{
			BP_RippleSwim_C.__ExecuteUbergraph_BP_RippleSwim_FunctionParams* ptr = stackalloc BP_RippleSwim_C.__ExecuteUbergraph_BP_RippleSwim_FunctionParams[(UIntPtr)4063] + 15L / (long)sizeof(BP_RippleSwim_C.__ExecuteUbergraph_BP_RippleSwim_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RippleSwim_C.__ExecuteUbergraph_BP_RippleSwim_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RippleSwim_C.__ExecuteUbergraph_BP_RippleSwim_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E220 RID: 123424 RVA: 0x008ECF5A File Offset: 0x008EB15A
		protected BP_RippleSwim_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EC39 RID: 60473
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Scene/Assets/PCG/BP_Tools/RippleSwim/BP_RippleSwim.BP_RippleSwim_C";

		// Token: 0x0400EC3A RID: 60474
		private static IntPtr _ClassPtr;

		// Token: 0x0400EC3B RID: 60475
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EC3C RID: 60476
		internal static int __PropertyOffset_0;

		// Token: 0x0400EC3D RID: 60477
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EC3E RID: 60478
		internal static int __PropertyOffset_1;

		// Token: 0x0400EC3F RID: 60479
		internal static int __PropertyOffset_2;

		// Token: 0x0400EC40 RID: 60480
		internal static int __PropertyOffset_3;

		// Token: 0x0400EC41 RID: 60481
		internal static int __PropertyOffset_4;

		// Token: 0x0400EC42 RID: 60482
		internal static int __PropertyOffset_5;

		// Token: 0x0400EC43 RID: 60483
		internal static int __PropertyOffset_6;

		// Token: 0x0400EC44 RID: 60484
		internal static int __PropertyOffset_7;

		// Token: 0x0400EC45 RID: 60485
		internal static int __PropertyOffset_8;

		// Token: 0x0400EC46 RID: 60486
		internal static int __PropertyOffset_9;

		// Token: 0x0400EC47 RID: 60487
		private FGameplayTagContainer _Tag_Container;

		// Token: 0x0400EC48 RID: 60488
		internal static int __PropertyOffset_10;

		// Token: 0x0400EC49 RID: 60489
		internal static int __PropertyOffset_11;

		// Token: 0x0400EC4A RID: 60490
		internal static int __PropertyOffset_12;

		// Token: 0x0400EC4B RID: 60491
		internal static int __PropertyOffset_13;

		// Token: 0x0400EC4C RID: 60492
		internal static int __PropertyOffset_14;

		// Token: 0x0400EC4D RID: 60493
		internal static int __PropertyOffset_15;

		// Token: 0x0400EC4E RID: 60494
		internal static int __PropertyOffset_16;

		// Token: 0x0400EC4F RID: 60495
		internal static int __PropertyOffset_17;

		// Token: 0x0400EC50 RID: 60496
		internal static int __PropertyOffset_18;

		// Token: 0x0400EC51 RID: 60497
		internal static int __PropertyOffset_19;

		// Token: 0x0400EC52 RID: 60498
		internal static int __PropertyOffset_20;

		// Token: 0x0400EC53 RID: 60499
		internal static int __PropertyOffset_21;

		// Token: 0x0400EC54 RID: 60500
		internal static int __PropertyOffset_22;

		// Token: 0x0400EC55 RID: 60501
		internal static int __PropertyOffset_23;

		// Token: 0x0400EC56 RID: 60502
		internal static int __PropertyOffset_24;

		// Token: 0x0400EC57 RID: 60503
		internal static int __PropertyOffset_25;

		// Token: 0x0400EC58 RID: 60504
		internal static int __PropertyOffset_26;

		// Token: 0x0400EC59 RID: 60505
		internal static int __PropertyOffset_27;

		// Token: 0x0400EC5A RID: 60506
		internal static int __PropertyOffset_28;

		// Token: 0x0400EC5B RID: 60507
		internal static int __PropertyOffset_29;

		// Token: 0x0400EC5C RID: 60508
		internal static int __PropertyOffset_30;

		// Token: 0x0400EC5D RID: 60509
		internal static int __PropertyOffset_31;

		// Token: 0x0400EC5E RID: 60510
		internal static int __PropertyOffset_32;

		// Token: 0x0400EC5F RID: 60511
		internal static int __PropertyOffset_33;

		// Token: 0x0400EC60 RID: 60512
		internal static int __PropertyOffset_34;

		// Token: 0x0400EC61 RID: 60513
		internal static int __PropertyOffset_35;

		// Token: 0x0400EC62 RID: 60514
		internal static int __PropertyOffset_36;

		// Token: 0x0400EC63 RID: 60515
		internal static int __PropertyOffset_37;

		// Token: 0x0400EC64 RID: 60516
		internal static int __PropertyOffset_38;

		// Token: 0x0400EC65 RID: 60517
		internal static int __PropertyOffset_39;

		// Token: 0x0400EC66 RID: 60518
		internal static int __PropertyOffset_40;

		// Token: 0x0400EC67 RID: 60519
		internal static int __PropertyOffset_41;

		// Token: 0x0400EC68 RID: 60520
		internal static int __PropertyOffset_42;

		// Token: 0x0400EC69 RID: 60521
		internal static int __PropertyOffset_43;

		// Token: 0x0400EC6A RID: 60522
		internal static int __PropertyOffset_44;

		// Token: 0x0400EC6B RID: 60523
		internal static int __PropertyOffset_45;

		// Token: 0x0400EC6C RID: 60524
		internal static int __PropertyOffset_46;

		// Token: 0x0400EC6D RID: 60525
		internal static int __PropertyOffset_47;

		// Token: 0x0400EC6E RID: 60526
		internal static int __PropertyOffset_48;

		// Token: 0x0400EC6F RID: 60527
		internal static int __PropertyOffset_49;

		// Token: 0x0400EC70 RID: 60528
		internal static int __PropertyOffset_50;

		// Token: 0x0400EC71 RID: 60529
		internal static int __PropertyOffset_51;

		// Token: 0x0400EC72 RID: 60530
		internal static int __PropertyOffset_52;

		// Token: 0x0400EC73 RID: 60531
		internal static int __PropertyOffset_53;

		// Token: 0x0400EC74 RID: 60532
		internal static int __PropertyOffset_54;

		// Token: 0x0400EC75 RID: 60533
		internal static int __PropertyOffset_55;

		// Token: 0x0400EC76 RID: 60534
		internal static int __PropertyOffset_56;

		// Token: 0x0400EC77 RID: 60535
		internal static int __PropertyOffset_57;

		// Token: 0x0400EC78 RID: 60536
		internal static int __PropertyOffset_58;

		// Token: 0x0400EC79 RID: 60537
		internal static int __PropertyOffset_59;

		// Token: 0x0400EC7A RID: 60538
		private TArray<FVectorDouble> _BulletPointList0;

		// Token: 0x0400EC7B RID: 60539
		internal static int __PropertyOffset_60;

		// Token: 0x0400EC7C RID: 60540
		internal static int __PropertyOffset_61;

		// Token: 0x0400EC7D RID: 60541
		private TArray<FVectorDouble> _BulletPointList1;

		// Token: 0x0400EC7E RID: 60542
		internal static int __PropertyOffset_62;

		// Token: 0x0400EC7F RID: 60543
		internal static int __PropertyOffset_63;

		// Token: 0x0400EC80 RID: 60544
		private TArray<FVectorDouble> _BulletPointList2;

		// Token: 0x0400EC81 RID: 60545
		internal static int __PropertyOffset_64;

		// Token: 0x0400EC82 RID: 60546
		internal static int __PropertyOffset_65;

		// Token: 0x0400EC83 RID: 60547
		internal static int __PropertyOffset_66;

		// Token: 0x0400EC84 RID: 60548
		internal static int __PropertyOffset_67;

		// Token: 0x0400EC85 RID: 60549
		private TArray<FVectorDouble> _AvailblePointList;

		// Token: 0x0400EC86 RID: 60550
		internal static int __PropertyOffset_68;

		// Token: 0x0400EC87 RID: 60551
		internal static int __PropertyOffset_69;

		// Token: 0x0400EC88 RID: 60552
		internal static int __PropertyOffset_70;

		// Token: 0x0400EC89 RID: 60553
		internal static int __PropertyOffset_71;

		// Token: 0x0400EC8A RID: 60554
		internal static int __PropertyOffset_72;

		// Token: 0x0400EC8B RID: 60555
		internal static int __PropertyOffset_73;

		// Token: 0x0400EC8C RID: 60556
		internal static int __PropertyOffset_74;

		// Token: 0x0400EC8D RID: 60557
		internal static int __PropertyOffset_75;

		// Token: 0x0400EC8E RID: 60558
		internal static int __PropertyOffset_76;

		// Token: 0x0400EC8F RID: 60559
		internal static int __PropertyOffset_77;

		// Token: 0x0400EC90 RID: 60560
		internal static int __PropertyOffset_78;

		// Token: 0x0400EC91 RID: 60561
		internal static int __PropertyOffset_79;

		// Token: 0x0400EC92 RID: 60562
		internal static int __PropertyOffset_80;

		// Token: 0x0400EC93 RID: 60563
		internal static int __PropertyOffset_81;

		// Token: 0x0400EC94 RID: 60564
		internal static int __PropertyOffset_82;

		// Token: 0x0400EC95 RID: 60565
		internal static int __PropertyOffset_83;

		// Token: 0x0400EC96 RID: 60566
		internal static int __PropertyOffset_84;

		// Token: 0x0400EC97 RID: 60567
		internal static int __PropertyOffset_85;

		// Token: 0x0400EC98 RID: 60568
		private static IntPtr __Ripple_Stamp_NativeFunctionPtr;

		// Token: 0x0400EC99 RID: 60569
		private static IntPtr __Ripple_Simulation_NativeFunctionPtr;

		// Token: 0x0400EC9A RID: 60570
		private static IntPtr __CheckAndSetPos_NativeFunctionPtr;

		// Token: 0x0400EC9B RID: 60571
		private static IntPtr __SetCloseSwimRipple_NativeFunctionPtr;

		// Token: 0x0400EC9C RID: 60572
		private static IntPtr __Set_Bullet_Data_NativeFunctionPtr;

		// Token: 0x0400EC9D RID: 60573
		private static IntPtr __SetNewRipple_NativeFunctionPtr;

		// Token: 0x0400EC9E RID: 60574
		private static IntPtr __SetOldRipple_NativeFunctionPtr;

		// Token: 0x0400EC9F RID: 60575
		private static IntPtr __TexcoordToPosition_NativeFunctionPtr;

		// Token: 0x0400ECA0 RID: 60576
		private static IntPtr __Calc_Circle_Weapon_2_NativeFunctionPtr;

		// Token: 0x0400ECA1 RID: 60577
		private static IntPtr __Calc_Capsule_Weapon_2_NativeFunctionPtr;

		// Token: 0x0400ECA2 RID: 60578
		private static IntPtr __Compare_New_Point_Weapon_2_NativeFunctionPtr;

		// Token: 0x0400ECA3 RID: 60579
		private static IntPtr __Calc_Catmull_Weapon_2_NativeFunctionPtr;

		// Token: 0x0400ECA4 RID: 60580
		private static IntPtr __Compare_New_Point_Weapon_1_NativeFunctionPtr;

		// Token: 0x0400ECA5 RID: 60581
		private static IntPtr __Calc_Catmull_Weapon_1_NativeFunctionPtr;

		// Token: 0x0400ECA6 RID: 60582
		private static IntPtr __Compare_New_Point_Weapon_0_NativeFunctionPtr;

		// Token: 0x0400ECA7 RID: 60583
		private static IntPtr __Calc_Catmull_Weapon_0_NativeFunctionPtr;

		// Token: 0x0400ECA8 RID: 60584
		private static IntPtr __CalcTexCoord2D_NativeFunctionPtr;

		// Token: 0x0400ECA9 RID: 60585
		private static IntPtr __GetPointsV3_NativeFunctionPtr;

		// Token: 0x0400ECAA RID: 60586
		private static IntPtr __GetPoints_NativeFunctionPtr;

		// Token: 0x0400ECAB RID: 60587
		private static IntPtr __CatmullRom_NativeFunctionPtr;

		// Token: 0x0400ECAC RID: 60588
		private static IntPtr __CalcDistance2D_NativeFunctionPtr;

		// Token: 0x0400ECAD RID: 60589
		private static IntPtr __Choose_Available_Point_NativeFunctionPtr;

		// Token: 0x0400ECAE RID: 60590
		private static IntPtr __Change_Ripple_Preset_NativeFunctionPtr;

		// Token: 0x0400ECAF RID: 60591
		private static IntPtr __CalcTexCoord_NativeFunctionPtr;

		// Token: 0x0400ECB0 RID: 60592
		private static IntPtr __Clear_RT_NativeFunctionPtr;

		// Token: 0x0400ECB1 RID: 60593
		private static IntPtr __SetWaterRippleData_NativeFunctionPtr;

		// Token: 0x0400ECB2 RID: 60594
		private static IntPtr __AboveWater_NativeFunctionPtr;

		// Token: 0x0400ECB3 RID: 60595
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400ECB4 RID: 60596
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400ECB5 RID: 60597
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400ECB6 RID: 60598
		private static IntPtr __Refresh_NativeFunctionPtr;

		// Token: 0x0400ECB7 RID: 60599
		private static IntPtr __BeforeCookForMobile_NativeFunctionPtr;

		// Token: 0x0400ECB8 RID: 60600
		private static IntPtr __OnBulletHitWater_NativeFunctionPtr;

		// Token: 0x0400ECB9 RID: 60601
		private static IntPtr __BulletHitPos_NativeFunctionPtr;

		// Token: 0x0400ECBA RID: 60602
		private static IntPtr __OnBulletHitPos_NativeFunctionPtr;

		// Token: 0x0400ECBB RID: 60603
		private static IntPtr __TestHitEvent_NativeFunctionPtr;

		// Token: 0x0400ECBC RID: 60604
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400ECBD RID: 60605
		private static IntPtr __ExecuteUbergraph_BP_RippleSwim_NativeFunctionPtr;

		// Token: 0x02009752 RID: 38738
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1344)]
		protected ref struct __CheckAndSetPos_FunctionParams
		{
			// Token: 0x04031CCC RID: 203980
			[FieldOffset(0)]
			public float DeltaSeconds;

			// Token: 0x04031CCD RID: 203981
			[FieldOffset(4)]
			public float LastRippleTime;
		}

		// Token: 0x02009753 RID: 38739
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __Set_Bullet_Data_FunctionParams
		{
			// Token: 0x04031CCE RID: 203982
			[FieldOffset(0)]
			public IntPtr Config;
		}

		// Token: 0x02009754 RID: 38740
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __TexcoordToPosition_FunctionParams
		{
			// Token: 0x04031CCF RID: 203983
			[FieldOffset(0)]
			public FVectorDouble RippleCenter;

			// Token: 0x04031CD0 RID: 203984
			[FieldOffset(24)]
			public FVector2D RippleUV;

			// Token: 0x04031CD1 RID: 203985
			[FieldOffset(32)]
			public float CaptureSize;

			// Token: 0x04031CD2 RID: 203986
			[FieldOffset(36)]
			public FVector2D Position;
		}

		// Token: 0x02009755 RID: 38741
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __Calc_Circle_Weapon_2_FunctionParams
		{
			// Token: 0x04031CD3 RID: 203987
			[FieldOffset(0)]
			public IntPtr BulletConfig;

			// Token: 0x04031CD4 RID: 203988
			[FieldOffset(8)]
			public FVectorDouble AvailblePoint;
		}

		// Token: 0x02009756 RID: 38742
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 232)]
		protected ref struct __Calc_Capsule_Weapon_2_FunctionParams
		{
			// Token: 0x04031CD5 RID: 203989
			[FieldOffset(0)]
			public IntPtr BulletConfig;

			// Token: 0x04031CD6 RID: 203990
			[FieldOffset(8)]
			public FVectorDouble AvailblePoint;
		}

		// Token: 0x02009757 RID: 38743
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __Compare_New_Point_Weapon_2_FunctionParams
		{
			// Token: 0x04031CD7 RID: 203991
			[FieldOffset(0)]
			public FVectorDouble V2;

			// Token: 0x04031CD8 RID: 203992
			[FieldOffset(24)]
			public bool Vaild;
		}

		// Token: 0x02009758 RID: 38744
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected ref struct __Calc_Catmull_Weapon_2_FunctionParams
		{
			// Token: 0x04031CD9 RID: 203993
			[FieldOffset(0)]
			public IntPtr BulletConfig;

			// Token: 0x04031CDA RID: 203994
			[FieldOffset(8)]
			public FVectorDouble AvailblePoint;
		}

		// Token: 0x02009759 RID: 38745
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __Compare_New_Point_Weapon_1_FunctionParams
		{
			// Token: 0x04031CDB RID: 203995
			[FieldOffset(0)]
			public FVectorDouble V2;

			// Token: 0x04031CDC RID: 203996
			[FieldOffset(24)]
			public bool Vaild;
		}

		// Token: 0x0200975A RID: 38746
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected ref struct __Calc_Catmull_Weapon_1_FunctionParams
		{
			// Token: 0x04031CDD RID: 203997
			[FieldOffset(0)]
			public IntPtr BulletConfig;

			// Token: 0x04031CDE RID: 203998
			[FieldOffset(8)]
			public FVectorDouble AvailblePoint;
		}

		// Token: 0x0200975B RID: 38747
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __Compare_New_Point_Weapon_0_FunctionParams
		{
			// Token: 0x04031CDF RID: 203999
			[FieldOffset(0)]
			public FVectorDouble V2;

			// Token: 0x04031CE0 RID: 204000
			[FieldOffset(24)]
			public bool Vaild;
		}

		// Token: 0x0200975C RID: 38748
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected ref struct __Calc_Catmull_Weapon_0_FunctionParams
		{
			// Token: 0x04031CE1 RID: 204001
			[FieldOffset(0)]
			public IntPtr BulletConfig;

			// Token: 0x04031CE2 RID: 204002
			[FieldOffset(8)]
			public FVectorDouble AvailblePoint;
		}

		// Token: 0x0200975D RID: 38749
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __CalcTexCoord2D_FunctionParams
		{
			// Token: 0x04031CE3 RID: 204003
			[FieldOffset(0)]
			public FVectorDouble RippleCenter;

			// Token: 0x04031CE4 RID: 204004
			[FieldOffset(24)]
			public FVector2D RipplePointLocation;

			// Token: 0x04031CE5 RID: 204005
			[FieldOffset(32)]
			public float CaptureSize;

			// Token: 0x04031CE6 RID: 204006
			[FieldOffset(36)]
			public FVector2D TexCoord;
		}

		// Token: 0x0200975E RID: 38750
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 328)]
		protected ref struct __GetPointsV3_FunctionParams
		{
			// Token: 0x04031CE7 RID: 204007
			[FieldOffset(0)]
			public byte PointList;

			// Token: 0x04031CE8 RID: 204008
			[FieldOffset(16)]
			public bool Vaild;

			// Token: 0x04031CE9 RID: 204009
			[FieldOffset(20)]
			public FVector2D P_0;

			// Token: 0x04031CEA RID: 204010
			[FieldOffset(28)]
			public FVector2D P_1;

			// Token: 0x04031CEB RID: 204011
			[FieldOffset(36)]
			public FVector2D P_2;

			// Token: 0x04031CEC RID: 204012
			[FieldOffset(44)]
			public FVector2D P_3;
		}

		// Token: 0x0200975F RID: 38751
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __GetPoints_FunctionParams
		{
			// Token: 0x04031CED RID: 204013
			[FieldOffset(0)]
			public byte PointList;

			// Token: 0x04031CEE RID: 204014
			[FieldOffset(16)]
			public bool Vaild;

			// Token: 0x04031CEF RID: 204015
			[FieldOffset(20)]
			public FVector2D P_0;

			// Token: 0x04031CF0 RID: 204016
			[FieldOffset(28)]
			public FVector2D P_1;

			// Token: 0x04031CF1 RID: 204017
			[FieldOffset(36)]
			public FVector2D P_2;

			// Token: 0x04031CF2 RID: 204018
			[FieldOffset(44)]
			public FVector2D P_3;
		}

		// Token: 0x02009760 RID: 38752
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __CatmullRom_FunctionParams
		{
			// Token: 0x04031CF3 RID: 204019
			[FieldOffset(0)]
			public byte PointList;

			// Token: 0x04031CF4 RID: 204020
			[FieldOffset(16)]
			public int StepCount;

			// Token: 0x04031CF5 RID: 204021
			[FieldOffset(20)]
			public bool Vaild;

			// Token: 0x04031CF6 RID: 204022
			[FieldOffset(24)]
			public byte CurveList;
		}

		// Token: 0x02009761 RID: 38753
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __CalcDistance2D_FunctionParams
		{
			// Token: 0x04031CF7 RID: 204023
			[FieldOffset(0)]
			public FVectorDouble V1;

			// Token: 0x04031CF8 RID: 204024
			[FieldOffset(24)]
			public FVectorDouble V2;

			// Token: 0x04031CF9 RID: 204025
			[FieldOffset(48)]
			public double Distance;
		}

		// Token: 0x02009762 RID: 38754
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __Choose_Available_Point_FunctionParams
		{
			// Token: 0x04031CFA RID: 204026
			[FieldOffset(0)]
			public FVectorDouble CollisionPoint;

			// Token: 0x04031CFB RID: 204027
			[FieldOffset(24)]
			public FVectorDouble WeaponPoint;

			// Token: 0x04031CFC RID: 204028
			[FieldOffset(48)]
			public IntPtr ConfigDA;

			// Token: 0x04031CFD RID: 204029
			[FieldOffset(56)]
			public FVectorDouble AvailblePoint;
		}

		// Token: 0x02009763 RID: 38755
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __Change_Ripple_Preset_FunctionParams
		{
			// Token: 0x04031CFE RID: 204030
			[FieldOffset(0)]
			public IntPtr NewRippleState;
		}

		// Token: 0x02009764 RID: 38756
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __CalcTexCoord_FunctionParams
		{
			// Token: 0x04031CFF RID: 204031
			[FieldOffset(0)]
			public FVectorDouble RippleCenter;

			// Token: 0x04031D00 RID: 204032
			[FieldOffset(24)]
			public FVectorDouble RipplePointLocation;

			// Token: 0x04031D01 RID: 204033
			[FieldOffset(48)]
			public float CaptureSize;

			// Token: 0x04031D02 RID: 204034
			[FieldOffset(52)]
			public FVector TexCoord;
		}

		// Token: 0x02009765 RID: 38757
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __SetWaterRippleData_FunctionParams
		{
			// Token: 0x04031D03 RID: 204035
			[FieldOffset(0)]
			public IntPtr InputPin;
		}

		// Token: 0x02009766 RID: 38758
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __AboveWater_FunctionParams
		{
			// Token: 0x04031D04 RID: 204036
			[FieldOffset(0)]
			public FVector Location;

			// Token: 0x04031D05 RID: 204037
			[FieldOffset(12)]
			public bool bAboveWater;
		}

		// Token: 0x02009767 RID: 38759
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D06 RID: 204038
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009768 RID: 38760
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __OnBulletHitWater_FunctionParams
		{
			// Token: 0x04031D07 RID: 204039
			[FieldOffset(0)]
			public FVectorDouble ImpactPoint;

			// Token: 0x04031D08 RID: 204040
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04031D09 RID: 204041
			[FieldOffset(32)]
			public FVectorDouble OriginPoint;

			// Token: 0x04031D0A RID: 204042
			[FieldOffset(56)]
			public int Id;
		}

		// Token: 0x02009769 RID: 38761
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __BulletHitPos_FunctionParams
		{
			// Token: 0x04031D0B RID: 204043
			[FieldOffset(0)]
			public FVectorDouble ImpactPoint;

			// Token: 0x04031D0C RID: 204044
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04031D0D RID: 204045
			[FieldOffset(32)]
			public FVectorDouble OriginPoint;

			// Token: 0x04031D0E RID: 204046
			[FieldOffset(56)]
			public int Id;
		}

		// Token: 0x0200976A RID: 38762
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __OnBulletHitPos_FunctionParams
		{
			// Token: 0x04031D0F RID: 204047
			[FieldOffset(0)]
			public FVectorDouble ImpactPoint;

			// Token: 0x04031D10 RID: 204048
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04031D11 RID: 204049
			[FieldOffset(32)]
			public FVectorDouble OriginPoint;

			// Token: 0x04031D12 RID: 204050
			[FieldOffset(56)]
			public int Id;
		}

		// Token: 0x0200976B RID: 38763
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __TestHitEvent_FunctionParams
		{
			// Token: 0x04031D13 RID: 204051
			[FieldOffset(0)]
			public FVectorDouble ImpactPoint;

			// Token: 0x04031D14 RID: 204052
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04031D15 RID: 204053
			[FieldOffset(32)]
			public FVectorDouble OriginPoint;

			// Token: 0x04031D16 RID: 204054
			[FieldOffset(56)]
			public int Id;
		}

		// Token: 0x0200976C RID: 38764
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031D17 RID: 204055
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200976D RID: 38765
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4048)]
		protected ref struct __ExecuteUbergraph_BP_RippleSwim_FunctionParams
		{
			// Token: 0x04031D18 RID: 204056
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
