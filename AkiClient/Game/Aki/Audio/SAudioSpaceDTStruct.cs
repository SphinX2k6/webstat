using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x02004382 RID: 17282
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Audio/SAudioSpaceDTStruct.SAudioSpaceDTStruct")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SAudioSpaceDTStruct : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602DCCE RID: 187598 RVA: 0x00ACC643 File Offset: 0x00ACA843
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAudioSpaceDTStruct._ScriptStructPtr != 0) ? SAudioSpaceDTStruct._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Audio/SAudioSpaceDTStruct.SAudioSpaceDTStruct", ref SAudioSpaceDTStruct._ScriptStructPtr);
		}

		// Token: 0x17007D7F RID: 32127
		// (get) Token: 0x0602DCCF RID: 187599 RVA: 0x00ACC667 File Offset: 0x00ACA867
		// (set) Token: 0x0602DCD0 RID: 187600 RVA: 0x00ACC67B File Offset: 0x00ACA87B
		public unsafe string AudioSpaceActorName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SAudioSpaceDTStruct.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SAudioSpaceDTStruct.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007D80 RID: 32128
		// (get) Token: 0x0602DCD1 RID: 187601 RVA: 0x00ACC690 File Offset: 0x00ACA890
		// (set) Token: 0x0602DCD2 RID: 187602 RVA: 0x00ACC6A4 File Offset: 0x00ACA8A4
		public unsafe FVector AudioSpaceLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAudioSpaceDTStruct.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAudioSpaceDTStruct.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007D81 RID: 32129
		// (get) Token: 0x0602DCD3 RID: 187603 RVA: 0x00ACC6B9 File Offset: 0x00ACA8B9
		// (set) Token: 0x0602DCD4 RID: 187604 RVA: 0x00ACC6CD File Offset: 0x00ACA8CD
		[Nullable(2)]
		public unsafe UAkAudioEvent InSpaceEvent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + SAudioSpaceDTStruct.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SAudioSpaceDTStruct.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007D82 RID: 32130
		// (get) Token: 0x0602DCD5 RID: 187605 RVA: 0x00ACC6E2 File Offset: 0x00ACA8E2
		// (set) Token: 0x0602DCD6 RID: 187606 RVA: 0x00ACC6F6 File Offset: 0x00ACA8F6
		[Nullable(2)]
		public unsafe UAkAudioEvent OutOfSpaceEvent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + SAudioSpaceDTStruct.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SAudioSpaceDTStruct.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007D83 RID: 32131
		// (get) Token: 0x0602DCD7 RID: 187607 RVA: 0x00ACC70C File Offset: 0x00ACA90C
		// (set) Token: 0x0602DCD8 RID: 187608 RVA: 0x00ACC74F File Offset: 0x00ACA94F
		public TArray<BP_SAudioCondition> ModifyAudioCondition
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_SAudioCondition> result;
				if ((result = this._ModifyAudioCondition) == null)
				{
					result = (this._ModifyAudioCondition = new TArray<BP_SAudioCondition>(base.NativePtr + (IntPtr)SAudioSpaceDTStruct.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ModifyAudioCondition.CopyAssign(value);
			}
		}

		// Token: 0x0602DCD9 RID: 187609 RVA: 0x00ACC75D File Offset: 0x00ACA95D
		public SAudioSpaceDTStruct()
		{
		}

		// Token: 0x0602DCDA RID: 187610 RVA: 0x00ACC765 File Offset: 0x00ACA965
		public SAudioSpaceDTStruct(string AudioSpaceActorName, FVector AudioSpaceLocation, UAkAudioEvent InSpaceEvent, UAkAudioEvent OutOfSpaceEvent, TArray<BP_SAudioCondition> ModifyAudioCondition)
		{
			this.AudioSpaceActorName = AudioSpaceActorName;
			this.AudioSpaceLocation = AudioSpaceLocation;
			this.InSpaceEvent = InSpaceEvent;
			this.OutOfSpaceEvent = OutOfSpaceEvent;
			this.ModifyAudioCondition = ModifyAudioCondition;
		}

		// Token: 0x0602DCDB RID: 187611 RVA: 0x00ACC792 File Offset: 0x00ACA992
		protected override IntPtr GetUStructPtr()
		{
			return SAudioSpaceDTStruct.StaticStruct();
		}

		// Token: 0x0602DCDC RID: 187612 RVA: 0x00ACC79E File Offset: 0x00ACA99E
		[NullableContext(2)]
		public SAudioSpaceDTStruct(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602DCDD RID: 187613 RVA: 0x00ACC7A8 File Offset: 0x00ACA9A8
		public SAudioSpaceDTStruct(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602DCDE RID: 187614 RVA: 0x00ACC7B3 File Offset: 0x00ACA9B3
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAudioSpaceDTStruct(Pointer, false, true);
		}

		// Token: 0x0602DCDF RID: 187615 RVA: 0x00ACC7BD File Offset: 0x00ACA9BD
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAudioSpaceDTStruct(Pointer, MemoryOwner);
		}

		// Token: 0x04019DC1 RID: 105921
		public const string __ObjectPath = "/Game/Aki/Audio/SAudioSpaceDTStruct.SAudioSpaceDTStruct";

		// Token: 0x04019DC2 RID: 105922
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019DC3 RID: 105923
		internal static int __PropertyOffset_0;

		// Token: 0x04019DC4 RID: 105924
		internal static int __PropertyOffset_1;

		// Token: 0x04019DC5 RID: 105925
		internal static int __PropertyOffset_2;

		// Token: 0x04019DC6 RID: 105926
		internal static int __PropertyOffset_3;

		// Token: 0x04019DC7 RID: 105927
		internal static int __PropertyOffset_4;

		// Token: 0x04019DC8 RID: 105928
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_SAudioCondition> _ModifyAudioCondition;
	}
}
