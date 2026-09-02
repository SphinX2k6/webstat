using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200325D RID: 12893
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/TsExploreCameraTriggerVolume.TsExploreCameraTriggerVolume_C")]
public class TsExploreCameraTriggerVolume : TsTriggerVolume, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002485 RID: 9349
	// (get) Token: 0x0601AE17 RID: 110103 RVA: 0x0080547C File Offset: 0x0080367C
	// (set) Token: 0x0601AE18 RID: 110104 RVA: 0x0080548C File Offset: 0x0080368C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Id
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsExploreCameraTriggerVolume.__PropertyOffset_Id);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsExploreCameraTriggerVolume.__PropertyOffset_Id) = value;
		}
	}

	// Token: 0x17002486 RID: 9350
	// (get) Token: 0x0601AE19 RID: 110105 RVA: 0x0080549D File Offset: 0x0080369D
	// (set) Token: 0x0601AE1A RID: 110106 RVA: 0x008054B1 File Offset: 0x008036B1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor LookAtActor1
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + TsExploreCameraTriggerVolume.__PropertyOffset_LookAtActor1);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsExploreCameraTriggerVolume.__PropertyOffset_LookAtActor1, value);
		}
	}

	// Token: 0x17002487 RID: 9351
	// (get) Token: 0x0601AE1B RID: 110107 RVA: 0x008054C6 File Offset: 0x008036C6
	// (set) Token: 0x0601AE1C RID: 110108 RVA: 0x008054DA File Offset: 0x008036DA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor LookAtActor2
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + TsExploreCameraTriggerVolume.__PropertyOffset_LookAtActor2);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsExploreCameraTriggerVolume.__PropertyOffset_LookAtActor2, value);
		}
	}

	// Token: 0x17002488 RID: 9352
	// (get) Token: 0x0601AE1D RID: 110109 RVA: 0x008054EF File Offset: 0x008036EF
	// (set) Token: 0x0601AE1E RID: 110110 RVA: 0x008054FF File Offset: 0x008036FF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float PrepTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsExploreCameraTriggerVolume.__PropertyOffset_PrepTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsExploreCameraTriggerVolume.__PropertyOffset_PrepTime) = value;
		}
	}

	// Token: 0x17002489 RID: 9353
	// (get) Token: 0x0601AE1F RID: 110111 RVA: 0x00805510 File Offset: 0x00803710
	// (set) Token: 0x0601AE20 RID: 110112 RVA: 0x00805520 File Offset: 0x00803720
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float FadeDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsExploreCameraTriggerVolume.__PropertyOffset_FadeDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsExploreCameraTriggerVolume.__PropertyOffset_FadeDistance) = value;
		}
	}

	// Token: 0x1700248A RID: 9354
	// (get) Token: 0x0601AE21 RID: 110113 RVA: 0x00805531 File Offset: 0x00803731
	// (set) Token: 0x0601AE22 RID: 110114 RVA: 0x00805541 File Offset: 0x00803741
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ArmLengthMin
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsExploreCameraTriggerVolume.__PropertyOffset_ArmLengthMin);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsExploreCameraTriggerVolume.__PropertyOffset_ArmLengthMin) = value;
		}
	}

	// Token: 0x1700248B RID: 9355
	// (get) Token: 0x0601AE23 RID: 110115 RVA: 0x00805552 File Offset: 0x00803752
	// (set) Token: 0x0601AE24 RID: 110116 RVA: 0x00805562 File Offset: 0x00803762
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ArmLengthMax
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsExploreCameraTriggerVolume.__PropertyOffset_ArmLengthMax);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsExploreCameraTriggerVolume.__PropertyOffset_ArmLengthMax) = value;
		}
	}

	// Token: 0x0601AE25 RID: 110117 RVA: 0x00805574 File Offset: 0x00803774
	protected override void OnCollisionEnterFunc(AActor otherActor, AActor overlapped)
	{
		if (!(otherActor is TsBaseCharacter))
		{
			return;
		}
		if (Global.BaseCharacter != otherActor)
		{
			return;
		}
		if (UKismetSystemLibrary.IsValid(this.LookAtActor1) && UKismetSystemLibrary.IsValid(this.LookAtActor2))
		{
			FVectorDouble value = this.LookAtActor1.D_K2_GetActorLocation();
			FVectorDouble value2 = this.LookAtActor2.D_K2_GetActorLocation();
			ControllerBase<CameraController>.Instance.EnterCameraExplore(this.Id, new FVectorDouble?(value), new FVectorDouble?(value2), this.PrepTime, this.FadeDistance, this.ArmLengthMin, this.ArmLengthMax, "MainCamera");
			return;
		}
		ControllerBase<CameraController>.Instance.EnterCameraExplore(this.Id, null, null, this.PrepTime, this.FadeDistance, this.ArmLengthMin, this.ArmLengthMax, "MainCamera");
	}

	// Token: 0x0601AE26 RID: 110118 RVA: 0x0080563E File Offset: 0x0080383E
	protected override void OnCollisionExitFunc(AActor otherActor, AActor overlapped)
	{
		if (!(otherActor is TsBaseCharacter))
		{
			return;
		}
		if (Global.BaseCharacter != otherActor)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.ExitCameraExplore(this.Id, "MainCamera");
	}

	// Token: 0x0601AE27 RID: 110119 RVA: 0x00805667 File Offset: 0x00803867
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsExploreCameraTriggerVolume._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/TsExploreCameraTriggerVolume.TsExploreCameraTriggerVolume_C");
		}
		return TsExploreCameraTriggerVolume._ClassPtr;
	}

	// Token: 0x0601AE28 RID: 110120 RVA: 0x0080568C File Offset: 0x0080388C
	public TsExploreCameraTriggerVolume() : this(BuiltinUtils.AllocNativeUObject(TsExploreCameraTriggerVolume.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601AE29 RID: 110121 RVA: 0x008056B4 File Offset: 0x008038B4
	[NullableContext(1)]
	public TsExploreCameraTriggerVolume(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsExploreCameraTriggerVolume.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601AE2A RID: 110122 RVA: 0x008056E7 File Offset: 0x008038E7
	protected TsExploreCameraTriggerVolume(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400DA3E RID: 55870
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/TsExploreCameraTriggerVolume.TsExploreCameraTriggerVolume_C";

	// Token: 0x0400DA3F RID: 55871
	private static IntPtr _ClassPtr;

	// Token: 0x0400DA40 RID: 55872
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DA41 RID: 55873
	private static int __PropertyOffset_Id;

	// Token: 0x0400DA42 RID: 55874
	private static int __PropertyOffset_LookAtActor1;

	// Token: 0x0400DA43 RID: 55875
	private static int __PropertyOffset_LookAtActor2;

	// Token: 0x0400DA44 RID: 55876
	private static int __PropertyOffset_PrepTime;

	// Token: 0x0400DA45 RID: 55877
	private static int __PropertyOffset_FadeDistance;

	// Token: 0x0400DA46 RID: 55878
	private static int __PropertyOffset_ArmLengthMin;

	// Token: 0x0400DA47 RID: 55879
	private static int __PropertyOffset_ArmLengthMax;
}
