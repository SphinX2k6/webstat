using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace UnrealEngine
{
	// Token: 0x020043F0 RID: 17392
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Niagara/DefaultAssets/Structs/LocationEvent.LocationEvent")]
	[UnrealStructLayout(52, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 52)]
	public class LocationEvent : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E307 RID: 189191 RVA: 0x00ADB89A File Offset: 0x00AD9A9A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (LocationEvent._ScriptStructPtr != 0) ? LocationEvent._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Niagara/DefaultAssets/Structs/LocationEvent.LocationEvent", ref LocationEvent._ScriptStructPtr);
		}

		// Token: 0x17007F30 RID: 32560
		// (get) Token: 0x0602E308 RID: 189192 RVA: 0x00ADB8BE File Offset: 0x00AD9ABE
		// (set) Token: 0x0602E309 RID: 189193 RVA: 0x00ADB8D2 File Offset: 0x00AD9AD2
		public unsafe FVector Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)LocationEvent.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)LocationEvent.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007F31 RID: 32561
		// (get) Token: 0x0602E30A RID: 189194 RVA: 0x00ADB8E7 File Offset: 0x00AD9AE7
		// (set) Token: 0x0602E30B RID: 189195 RVA: 0x00ADB8FB File Offset: 0x00AD9AFB
		public unsafe FVector Velocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)LocationEvent.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)LocationEvent.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007F32 RID: 32562
		// (get) Token: 0x0602E30C RID: 189196 RVA: 0x00ADB910 File Offset: 0x00AD9B10
		// (set) Token: 0x0602E30D RID: 189197 RVA: 0x00ADB924 File Offset: 0x00AD9B24
		public unsafe FVector Acceleration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)LocationEvent.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)LocationEvent.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007F33 RID: 32563
		// (get) Token: 0x0602E30E RID: 189198 RVA: 0x00ADB93C File Offset: 0x00AD9B3C
		// (set) Token: 0x0602E30F RID: 189199 RVA: 0x00ADB97F File Offset: 0x00AD9B7F
		public FNiagaraID RibbonID
		{
			get
			{
				base.FastCheckIsValid();
				FNiagaraID result;
				if ((result = this._RibbonID) == null)
				{
					result = (this._RibbonID = new FNiagaraID(base.NativePtr + (IntPtr)LocationEvent.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FNiagaraID.StaticStruct(), base.NativePtr + (IntPtr)LocationEvent.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007F34 RID: 32564
		// (get) Token: 0x0602E310 RID: 189200 RVA: 0x00ADB9A0 File Offset: 0x00AD9BA0
		// (set) Token: 0x0602E311 RID: 189201 RVA: 0x00ADB9B0 File Offset: 0x00AD9BB0
		public unsafe float NormalizedAge
		{
			get
			{
				return *(base.NativePtr + (IntPtr)LocationEvent.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)LocationEvent.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007F35 RID: 32565
		// (get) Token: 0x0602E312 RID: 189202 RVA: 0x00ADB9C1 File Offset: 0x00AD9BC1
		// (set) Token: 0x0602E313 RID: 189203 RVA: 0x00ADB9D1 File Offset: 0x00AD9BD1
		public unsafe float RandomNormalizedFloat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)LocationEvent.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)LocationEvent.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x0602E314 RID: 189204 RVA: 0x00ADB9E2 File Offset: 0x00AD9BE2
		public LocationEvent()
		{
		}

		// Token: 0x0602E315 RID: 189205 RVA: 0x00ADB9EA File Offset: 0x00AD9BEA
		public LocationEvent(FVector Position, FVector Velocity, FVector Acceleration, FNiagaraID RibbonID, float NormalizedAge, float RandomNormalizedFloat)
		{
			this.Position = Position;
			this.Velocity = Velocity;
			this.Acceleration = Acceleration;
			this.RibbonID = RibbonID;
			this.NormalizedAge = NormalizedAge;
			this.RandomNormalizedFloat = RandomNormalizedFloat;
		}

		// Token: 0x0602E316 RID: 189206 RVA: 0x00ADBA1F File Offset: 0x00AD9C1F
		protected override IntPtr GetUStructPtr()
		{
			return LocationEvent.StaticStruct();
		}

		// Token: 0x0602E317 RID: 189207 RVA: 0x00ADBA2B File Offset: 0x00AD9C2B
		[NullableContext(2)]
		public LocationEvent(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E318 RID: 189208 RVA: 0x00ADBA35 File Offset: 0x00AD9C35
		public LocationEvent(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E319 RID: 189209 RVA: 0x00ADBA40 File Offset: 0x00AD9C40
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new LocationEvent(Pointer, false, true);
		}

		// Token: 0x0602E31A RID: 189210 RVA: 0x00ADBA4A File Offset: 0x00AD9C4A
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new LocationEvent(Pointer, MemoryOwner);
		}

		// Token: 0x0401A224 RID: 107044
		public const string __ObjectPath = "/Niagara/DefaultAssets/Structs/LocationEvent.LocationEvent";

		// Token: 0x0401A225 RID: 107045
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A226 RID: 107046
		internal static int __PropertyOffset_0;

		// Token: 0x0401A227 RID: 107047
		internal static int __PropertyOffset_1;

		// Token: 0x0401A228 RID: 107048
		internal static int __PropertyOffset_2;

		// Token: 0x0401A229 RID: 107049
		internal static int __PropertyOffset_3;

		// Token: 0x0401A22A RID: 107050
		[Nullable(2)]
		private FNiagaraID _RibbonID;

		// Token: 0x0401A22B RID: 107051
		internal static int __PropertyOffset_4;

		// Token: 0x0401A22C RID: 107052
		internal static int __PropertyOffset_5;
	}
}
