using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Physics_Actor.RuntimeData
{
	// Token: 0x02003BAB RID: 15275
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/RuntimeData/S_PhysicalAudio.S_PhysicalAudio")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 28)]
	public class S_PhysicalAudio : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06021FB0 RID: 139184 RVA: 0x00959048 File Offset: 0x00957248
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_PhysicalAudio._ScriptStructPtr != 0) ? S_PhysicalAudio._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/RuntimeData/S_PhysicalAudio.S_PhysicalAudio", ref S_PhysicalAudio._ScriptStructPtr);
		}

		// Token: 0x17003E05 RID: 15877
		// (get) Token: 0x06021FB1 RID: 139185 RVA: 0x0095906C File Offset: 0x0095726C
		// (set) Token: 0x06021FB2 RID: 139186 RVA: 0x00959080 File Offset: 0x00957280
		public unsafe UPhysicalMaterial ObjectMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicalMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + S_PhysicalAudio.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_PhysicalAudio.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003E06 RID: 15878
		// (get) Token: 0x06021FB3 RID: 139187 RVA: 0x00959095 File Offset: 0x00957295
		// (set) Token: 0x06021FB4 RID: 139188 RVA: 0x009590A9 File Offset: 0x009572A9
		public unsafe UPhysicalMaterial SurfaceMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicalMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + S_PhysicalAudio.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_PhysicalAudio.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003E07 RID: 15879
		// (get) Token: 0x06021FB5 RID: 139189 RVA: 0x009590BE File Offset: 0x009572BE
		// (set) Token: 0x06021FB6 RID: 139190 RVA: 0x009590D2 File Offset: 0x009572D2
		public unsafe UAkAudioEvent Sound
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + S_PhysicalAudio.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_PhysicalAudio.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003E08 RID: 15880
		// (get) Token: 0x06021FB7 RID: 139191 RVA: 0x009590E7 File Offset: 0x009572E7
		// (set) Token: 0x06021FB8 RID: 139192 RVA: 0x009590F7 File Offset: 0x009572F7
		public unsafe float Cooldown
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_PhysicalAudio.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_PhysicalAudio.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06021FB9 RID: 139193 RVA: 0x00959108 File Offset: 0x00957308
		public S_PhysicalAudio()
		{
		}

		// Token: 0x06021FBA RID: 139194 RVA: 0x00959110 File Offset: 0x00957310
		[NullableContext(1)]
		public S_PhysicalAudio(UPhysicalMaterial ObjectMaterial, UPhysicalMaterial SurfaceMaterial, UAkAudioEvent Sound, float Cooldown)
		{
			this.ObjectMaterial = ObjectMaterial;
			this.SurfaceMaterial = SurfaceMaterial;
			this.Sound = Sound;
			this.Cooldown = Cooldown;
		}

		// Token: 0x06021FBB RID: 139195 RVA: 0x00959135 File Offset: 0x00957335
		protected override IntPtr GetUStructPtr()
		{
			return S_PhysicalAudio.StaticStruct();
		}

		// Token: 0x06021FBC RID: 139196 RVA: 0x00959141 File Offset: 0x00957341
		public S_PhysicalAudio(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06021FBD RID: 139197 RVA: 0x0095914B File Offset: 0x0095734B
		public S_PhysicalAudio(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06021FBE RID: 139198 RVA: 0x00959156 File Offset: 0x00957356
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_PhysicalAudio(Pointer, false, true);
		}

		// Token: 0x06021FBF RID: 139199 RVA: 0x00959160 File Offset: 0x00957360
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_PhysicalAudio(Pointer, MemoryOwner);
		}

		// Token: 0x0401129F RID: 70303
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/RuntimeData/S_PhysicalAudio.S_PhysicalAudio";

		// Token: 0x040112A0 RID: 70304
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040112A1 RID: 70305
		internal static int __PropertyOffset_0;

		// Token: 0x040112A2 RID: 70306
		internal static int __PropertyOffset_1;

		// Token: 0x040112A3 RID: 70307
		internal static int __PropertyOffset_2;

		// Token: 0x040112A4 RID: 70308
		internal static int __PropertyOffset_3;
	}
}
