using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrackParticles.DT
{
	// Token: 0x02003A3B RID: 14907
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrackParticles/DT/Struct_TrackParticles.Struct_TrackParticles")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 60)]
	public class Struct_TrackParticles : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601EBE8 RID: 125928 RVA: 0x008FD645 File Offset: 0x008FB845
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (Struct_TrackParticles._ScriptStructPtr != 0) ? Struct_TrackParticles._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/TrackParticles/DT/Struct_TrackParticles.Struct_TrackParticles", ref Struct_TrackParticles._ScriptStructPtr);
		}

		// Token: 0x17002C2D RID: 11309
		// (get) Token: 0x0601EBE9 RID: 125929 RVA: 0x008FD669 File Offset: 0x008FB869
		// (set) Token: 0x0601EBEA RID: 125930 RVA: 0x008FD679 File Offset: 0x008FB879
		public unsafe bool Visible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C2E RID: 11310
		// (get) Token: 0x0601EBEB RID: 125931 RVA: 0x008FD68A File Offset: 0x008FB88A
		// (set) Token: 0x0601EBEC RID: 125932 RVA: 0x008FD69E File Offset: 0x008FB89E
		[Nullable(2)]
		public unsafe UTexture2D TrackTexture
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_TrackParticles.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_TrackParticles.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002C2F RID: 11311
		// (get) Token: 0x0601EBED RID: 125933 RVA: 0x008FD6B3 File Offset: 0x008FB8B3
		// (set) Token: 0x0601EBEE RID: 125934 RVA: 0x008FD6C7 File Offset: 0x008FB8C7
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17002C30 RID: 11312
		// (get) Token: 0x0601EBEF RID: 125935 RVA: 0x008FD6DC File Offset: 0x008FB8DC
		// (set) Token: 0x0601EBF0 RID: 125936 RVA: 0x008FD6EC File Offset: 0x008FB8EC
		public unsafe float Brightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002C31 RID: 11313
		// (get) Token: 0x0601EBF1 RID: 125937 RVA: 0x008FD6FD File Offset: 0x008FB8FD
		// (set) Token: 0x0601EBF2 RID: 125938 RVA: 0x008FD70D File Offset: 0x008FB90D
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002C32 RID: 11314
		// (get) Token: 0x0601EBF3 RID: 125939 RVA: 0x008FD71E File Offset: 0x008FB91E
		// (set) Token: 0x0601EBF4 RID: 125940 RVA: 0x008FD72E File Offset: 0x008FB92E
		public unsafe float TrackSpawnRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002C33 RID: 11315
		// (get) Token: 0x0601EBF5 RID: 125941 RVA: 0x008FD73F File Offset: 0x008FB93F
		// (set) Token: 0x0601EBF6 RID: 125942 RVA: 0x008FD74F File Offset: 0x008FB94F
		public unsafe float SparkSpawnRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002C34 RID: 11316
		// (get) Token: 0x0601EBF7 RID: 125943 RVA: 0x008FD760 File Offset: 0x008FB960
		// (set) Token: 0x0601EBF8 RID: 125944 RVA: 0x008FD770 File Offset: 0x008FB970
		public unsafe float LifeTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002C35 RID: 11317
		// (get) Token: 0x0601EBF9 RID: 125945 RVA: 0x008FD781 File Offset: 0x008FB981
		// (set) Token: 0x0601EBFA RID: 125946 RVA: 0x008FD791 File Offset: 0x008FB991
		public unsafe float Width
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002C36 RID: 11318
		// (get) Token: 0x0601EBFB RID: 125947 RVA: 0x008FD7A2 File Offset: 0x008FB9A2
		// (set) Token: 0x0601EBFC RID: 125948 RVA: 0x008FD7B2 File Offset: 0x008FB9B2
		public unsafe int PointsNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_TrackParticles.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x0601EBFD RID: 125949 RVA: 0x008FD7C3 File Offset: 0x008FB9C3
		public Struct_TrackParticles()
		{
		}

		// Token: 0x0601EBFE RID: 125950 RVA: 0x008FD7CC File Offset: 0x008FB9CC
		[NullableContext(1)]
		public Struct_TrackParticles(bool Visible, UTexture2D TrackTexture, FLinearColor Color, float Brightness, float Speed, float TrackSpawnRate, float SparkSpawnRate, float LifeTime, float Width, int PointsNum)
		{
			this.Visible = Visible;
			this.TrackTexture = TrackTexture;
			this.Color = Color;
			this.Brightness = Brightness;
			this.Speed = Speed;
			this.TrackSpawnRate = TrackSpawnRate;
			this.SparkSpawnRate = SparkSpawnRate;
			this.LifeTime = LifeTime;
			this.Width = Width;
			this.PointsNum = PointsNum;
		}

		// Token: 0x0601EBFF RID: 125951 RVA: 0x008FD82C File Offset: 0x008FBA2C
		protected override IntPtr GetUStructPtr()
		{
			return Struct_TrackParticles.StaticStruct();
		}

		// Token: 0x0601EC00 RID: 125952 RVA: 0x008FD838 File Offset: 0x008FBA38
		[NullableContext(2)]
		public Struct_TrackParticles(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601EC01 RID: 125953 RVA: 0x008FD842 File Offset: 0x008FBA42
		public Struct_TrackParticles(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601EC02 RID: 125954 RVA: 0x008FD84D File Offset: 0x008FBA4D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new Struct_TrackParticles(Pointer, false, true);
		}

		// Token: 0x0601EC03 RID: 125955 RVA: 0x008FD857 File Offset: 0x008FBA57
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new Struct_TrackParticles(Pointer, MemoryOwner);
		}

		// Token: 0x0400F2D1 RID: 62161
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrackParticles/DT/Struct_TrackParticles.Struct_TrackParticles";

		// Token: 0x0400F2D2 RID: 62162
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400F2D3 RID: 62163
		internal static int __PropertyOffset_0;

		// Token: 0x0400F2D4 RID: 62164
		internal static int __PropertyOffset_1;

		// Token: 0x0400F2D5 RID: 62165
		internal static int __PropertyOffset_2;

		// Token: 0x0400F2D6 RID: 62166
		internal static int __PropertyOffset_3;

		// Token: 0x0400F2D7 RID: 62167
		internal static int __PropertyOffset_4;

		// Token: 0x0400F2D8 RID: 62168
		internal static int __PropertyOffset_5;

		// Token: 0x0400F2D9 RID: 62169
		internal static int __PropertyOffset_6;

		// Token: 0x0400F2DA RID: 62170
		internal static int __PropertyOffset_7;

		// Token: 0x0400F2DB RID: 62171
		internal static int __PropertyOffset_8;

		// Token: 0x0400F2DC RID: 62172
		internal static int __PropertyOffset_9;
	}
}
