using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.Assets.PCG.BP_Tools
{
	// Token: 0x020039ED RID: 14829
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Scene/Assets/PCG/BP_Tools/InstanceVolumeParametersStructure.InstanceVolumeParametersStructure")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class InstanceVolumeParametersStructure : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601E121 RID: 123169 RVA: 0x008EAFDC File Offset: 0x008E91DC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (InstanceVolumeParametersStructure._ScriptStructPtr != 0) ? InstanceVolumeParametersStructure._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Scene/Assets/PCG/BP_Tools/InstanceVolumeParametersStructure.InstanceVolumeParametersStructure", ref InstanceVolumeParametersStructure._ScriptStructPtr);
		}

		// Token: 0x17002847 RID: 10311
		// (get) Token: 0x0601E122 RID: 123170 RVA: 0x008EB000 File Offset: 0x008E9200
		// (set) Token: 0x0601E123 RID: 123171 RVA: 0x008EB014 File Offset: 0x008E9214
		public unsafe string ActorName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)InstanceVolumeParametersStructure.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)InstanceVolumeParametersStructure.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17002848 RID: 10312
		// (get) Token: 0x0601E124 RID: 123172 RVA: 0x008EB029 File Offset: 0x008E9229
		// (set) Token: 0x0601E125 RID: 123173 RVA: 0x008EB039 File Offset: 0x008E9239
		public unsafe bool Delete
		{
			get
			{
				return *(base.NativePtr + (IntPtr)InstanceVolumeParametersStructure.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)InstanceVolumeParametersStructure.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002849 RID: 10313
		// (get) Token: 0x0601E126 RID: 123174 RVA: 0x008EB04A File Offset: 0x008E924A
		// (set) Token: 0x0601E127 RID: 123175 RVA: 0x008EB05A File Offset: 0x008E925A
		public unsafe float Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)InstanceVolumeParametersStructure.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)InstanceVolumeParametersStructure.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700284A RID: 10314
		// (get) Token: 0x0601E128 RID: 123176 RVA: 0x008EB06B File Offset: 0x008E926B
		// (set) Token: 0x0601E129 RID: 123177 RVA: 0x008EB07F File Offset: 0x008E927F
		public unsafe string ReplaceInstance
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)InstanceVolumeParametersStructure.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)InstanceVolumeParametersStructure.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x0601E12A RID: 123178 RVA: 0x008EB094 File Offset: 0x008E9294
		public InstanceVolumeParametersStructure()
		{
		}

		// Token: 0x0601E12B RID: 123179 RVA: 0x008EB09C File Offset: 0x008E929C
		public InstanceVolumeParametersStructure(string ActorName, bool Delete, float Rotation, string ReplaceInstance)
		{
			this.ActorName = ActorName;
			this.Delete = Delete;
			this.Rotation = Rotation;
			this.ReplaceInstance = ReplaceInstance;
		}

		// Token: 0x0601E12C RID: 123180 RVA: 0x008EB0C1 File Offset: 0x008E92C1
		protected override IntPtr GetUStructPtr()
		{
			return InstanceVolumeParametersStructure.StaticStruct();
		}

		// Token: 0x0601E12D RID: 123181 RVA: 0x008EB0CD File Offset: 0x008E92CD
		[NullableContext(2)]
		public InstanceVolumeParametersStructure(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E12E RID: 123182 RVA: 0x008EB0D7 File Offset: 0x008E92D7
		public InstanceVolumeParametersStructure(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E12F RID: 123183 RVA: 0x008EB0E2 File Offset: 0x008E92E2
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new InstanceVolumeParametersStructure(Pointer, false, true);
		}

		// Token: 0x0601E130 RID: 123184 RVA: 0x008EB0EC File Offset: 0x008E92EC
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new InstanceVolumeParametersStructure(Pointer, MemoryOwner);
		}

		// Token: 0x0400EC20 RID: 60448
		public const string __ObjectPath = "/Game/Aki/Scene/Assets/PCG/BP_Tools/InstanceVolumeParametersStructure.InstanceVolumeParametersStructure";

		// Token: 0x0400EC21 RID: 60449
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400EC22 RID: 60450
		internal static int __PropertyOffset_0;

		// Token: 0x0400EC23 RID: 60451
		internal static int __PropertyOffset_1;

		// Token: 0x0400EC24 RID: 60452
		internal static int __PropertyOffset_2;

		// Token: 0x0400EC25 RID: 60453
		internal static int __PropertyOffset_3;
	}
}
