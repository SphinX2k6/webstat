using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Input.Blueprints;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002E31 RID: 11825
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsControlBlueprintFunctionLibrary.TsControlBlueprintFunctionLibrary_C")]
public class TsControlBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x06017FBC RID: 98236 RVA: 0x006B7524 File Offset: 0x006B5724
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVector2D GetMoveVectorCache(int entityId)
	{
		CharacterInputComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterInputComponent>(entityId);
		if (component == null)
		{
			return FVector2D.ZeroVector;
		}
		Vector moveVectorCache = component.GetMoveVectorCache();
		TsControlBlueprintFunctionLibrary._tmpVector2D.X = (float)moveVectorCache.X;
		TsControlBlueprintFunctionLibrary._tmpVector2D.Y = (float)moveVectorCache.Y;
		return TsControlBlueprintFunctionLibrary._tmpVector2D;
	}

	// Token: 0x06017FBD RID: 98237 RVA: 0x006B7574 File Offset: 0x006B5774
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVector2D GetMoveDirectionCache(int entityId)
	{
		CharacterInputComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterInputComponent>(entityId);
		if (component == null)
		{
			return FVector2D.ZeroVector;
		}
		Vector moveDirectionCache = component.GetMoveDirectionCache();
		TsControlBlueprintFunctionLibrary._tmpVector2D.X = (float)moveDirectionCache.X;
		TsControlBlueprintFunctionLibrary._tmpVector2D.Y = (float)moveDirectionCache.Y;
		return TsControlBlueprintFunctionLibrary._tmpVector2D;
	}

	// Token: 0x06017FBE RID: 98238 RVA: 0x006B75C4 File Offset: 0x006B57C4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVector2D GetWorldMoveDirectionCache(int entityId)
	{
		CharacterInputComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterInputComponent>(entityId);
		if (component == null)
		{
			return FVector2D.ZeroVector;
		}
		Vector worldMoveDirectionCache = component.GetWorldMoveDirectionCache();
		TsControlBlueprintFunctionLibrary._tmpVector2D.X = (float)worldMoveDirectionCache.X;
		TsControlBlueprintFunctionLibrary._tmpVector2D.Y = (float)worldMoveDirectionCache.Y;
		return TsControlBlueprintFunctionLibrary._tmpVector2D;
	}

	// Token: 0x06017FBF RID: 98239 RVA: 0x006B7614 File Offset: 0x006B5814
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVector2D GetMoveVector(int entityId)
	{
		CharacterInputComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterInputComponent>(entityId);
		if (component == null)
		{
			return FVector2D.ZeroVector;
		}
		component.GetMoveVector(TsControlBlueprintFunctionLibrary.TmpVector);
		TsControlBlueprintFunctionLibrary._tmpVector2D.X = (float)TsControlBlueprintFunctionLibrary.TmpVector.X;
		TsControlBlueprintFunctionLibrary._tmpVector2D.Y = (float)TsControlBlueprintFunctionLibrary.TmpVector.Y;
		return TsControlBlueprintFunctionLibrary._tmpVector2D;
	}

	// Token: 0x06017FC0 RID: 98240 RVA: 0x006B7670 File Offset: 0x006B5870
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVector2D GetMoveDirection(int entityId)
	{
		CharacterInputComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterInputComponent>(entityId);
		if (component == null)
		{
			return FVector2D.ZeroVector;
		}
		component.GetMoveDirection(TsControlBlueprintFunctionLibrary.TmpVector);
		TsControlBlueprintFunctionLibrary._tmpVector2D.X = (float)TsControlBlueprintFunctionLibrary.TmpVector.X;
		TsControlBlueprintFunctionLibrary._tmpVector2D.Y = (float)TsControlBlueprintFunctionLibrary.TmpVector.Y;
		return TsControlBlueprintFunctionLibrary._tmpVector2D;
	}

	// Token: 0x06017FC1 RID: 98241 RVA: 0x006B76CC File Offset: 0x006B58CC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void PlayKuroForceFeedback(UKuroForceFeedbackEffect forceFeedbackEffect, FName tag, bool bLooping, bool bIgnoreTimeDilation, bool bPlayWhilePaused)
	{
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		if (Global.CharacterController != null)
		{
			Global.CharacterController.PlayKuroForceFeedback(forceFeedbackEffect, tag, bLooping, bIgnoreTimeDilation, bPlayWhilePaused);
		}
	}

	// Token: 0x06017FC2 RID: 98242 RVA: 0x006B76F2 File Offset: 0x006B58F2
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void StopKuroForceFeedback(UKuroForceFeedbackEffect forceFeedbackEffect, FName tag)
	{
		if (Global.CharacterController != null)
		{
			Global.CharacterController.StopKuroForceFeedback(forceFeedbackEffect, tag);
		}
	}

	// Token: 0x06017FC3 RID: 98243 RVA: 0x006B7708 File Offset: 0x006B5908
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void BpInputReceiveEndPlay(int entityId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity != null && !entity.IsEnd && !UKuroStaticLibrary.IsWorldTearingDown(Singleton<Info>.Instance.World))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Bp Input Destroy at Wrong Time.";
			string item = "Actor";
			CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
			object item2;
			if (component == null)
			{
				item2 = null;
			}
			else
			{
				TsBaseCharacter actor = component.Actor;
				item2 = ((actor != null) ? actor.GetName() : null);
			}
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, item2);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x06017FC4 RID: 98244 RVA: 0x006B7780 File Offset: 0x006B5980
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetUseControllerRotationYaw(int entityId, bool value)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.UseControllerRotation = value;
	}

	// Token: 0x06017FC5 RID: 98245 RVA: 0x006B77A4 File Offset: 0x006B59A4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetBpInputComponent(int entityId, BP_InputBase_C bpInputComp)
	{
		CharacterInputComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterInputComponent>(entityId);
		CharacterActorComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetBpInputComp(bpInputComp);
		if (component2 != null && component2.Actor != null)
		{
			bpInputComp.OwnerActor = component2.Actor;
		}
	}

	// Token: 0x06017FC6 RID: 98246 RVA: 0x006B77EB File Offset: 0x006B59EB
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsControlBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsControlBlueprintFunctionLibrary.TsControlBlueprintFunctionLibrary_C");
		}
		return TsControlBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x06017FC7 RID: 98247 RVA: 0x006B7810 File Offset: 0x006B5A10
	public TsControlBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(TsControlBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017FC8 RID: 98248 RVA: 0x006B7838 File Offset: 0x006B5A38
	[NullableContext(1)]
	public TsControlBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsControlBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017FC9 RID: 98249 RVA: 0x006B786B File Offset: 0x006B5A6B
	protected TsControlBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06017FCA RID: 98250 RVA: 0x006B7874 File Offset: 0x006B5A74
	protected unsafe static void __CPPCALL_GetMoveVectorCache_Implementation(TsControlBlueprintFunctionLibrary.__GetMoveVectorCache_FunctionParams* __Params)
	{
		__Params->__Result = TsControlBlueprintFunctionLibrary.GetMoveVectorCache(__Params->entityId);
	}

	// Token: 0x06017FCB RID: 98251 RVA: 0x006B7887 File Offset: 0x006B5A87
	protected unsafe static void __CPPCALL_GetMoveDirectionCache_Implementation(TsControlBlueprintFunctionLibrary.__GetMoveDirectionCache_FunctionParams* __Params)
	{
		__Params->__Result = TsControlBlueprintFunctionLibrary.GetMoveDirectionCache(__Params->entityId);
	}

	// Token: 0x06017FCC RID: 98252 RVA: 0x006B789A File Offset: 0x006B5A9A
	protected unsafe static void __CPPCALL_GetWorldMoveDirectionCache_Implementation(TsControlBlueprintFunctionLibrary.__GetWorldMoveDirectionCache_FunctionParams* __Params)
	{
		__Params->__Result = TsControlBlueprintFunctionLibrary.GetWorldMoveDirectionCache(__Params->entityId);
	}

	// Token: 0x06017FCD RID: 98253 RVA: 0x006B78AD File Offset: 0x006B5AAD
	protected unsafe static void __CPPCALL_GetMoveVector_Implementation(TsControlBlueprintFunctionLibrary.__GetMoveVector_FunctionParams* __Params)
	{
		__Params->__Result = TsControlBlueprintFunctionLibrary.GetMoveVector(__Params->entityId);
	}

	// Token: 0x06017FCE RID: 98254 RVA: 0x006B78C0 File Offset: 0x006B5AC0
	protected unsafe static void __CPPCALL_GetMoveDirection_Implementation(TsControlBlueprintFunctionLibrary.__GetMoveDirection_FunctionParams* __Params)
	{
		__Params->__Result = TsControlBlueprintFunctionLibrary.GetMoveDirection(__Params->entityId);
	}

	// Token: 0x06017FCF RID: 98255 RVA: 0x006B78D3 File Offset: 0x006B5AD3
	protected unsafe static void __CPPCALL_PlayKuroForceFeedback_Implementation(TsControlBlueprintFunctionLibrary.__PlayKuroForceFeedback_FunctionParams* __Params)
	{
		TsControlBlueprintFunctionLibrary.PlayKuroForceFeedback(BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroForceFeedbackEffect>(__Params->forceFeedbackEffect), __Params->tag, __Params->bLooping, __Params->bIgnoreTimeDilation, __Params->bPlayWhilePaused);
	}

	// Token: 0x06017FD0 RID: 98256 RVA: 0x006B78FD File Offset: 0x006B5AFD
	protected unsafe static void __CPPCALL_StopKuroForceFeedback_Implementation(TsControlBlueprintFunctionLibrary.__StopKuroForceFeedback_FunctionParams* __Params)
	{
		TsControlBlueprintFunctionLibrary.StopKuroForceFeedback(BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroForceFeedbackEffect>(__Params->forceFeedbackEffect), __Params->tag);
	}

	// Token: 0x06017FD1 RID: 98257 RVA: 0x006B7915 File Offset: 0x006B5B15
	protected unsafe static void __CPPCALL_BpInputReceiveEndPlay_Implementation(TsControlBlueprintFunctionLibrary.__BpInputReceiveEndPlay_FunctionParams* __Params)
	{
		TsControlBlueprintFunctionLibrary.BpInputReceiveEndPlay(__Params->entityId);
	}

	// Token: 0x06017FD2 RID: 98258 RVA: 0x006B7922 File Offset: 0x006B5B22
	protected unsafe static void __CPPCALL_SetUseControllerRotationYaw_Implementation(TsControlBlueprintFunctionLibrary.__SetUseControllerRotationYaw_FunctionParams* __Params)
	{
		TsControlBlueprintFunctionLibrary.SetUseControllerRotationYaw(__Params->entityId, __Params->value);
	}

	// Token: 0x06017FD3 RID: 98259 RVA: 0x006B7938 File Offset: 0x006B5B38
	protected unsafe static void __CPPCALL_SetBpInputComponent_Implementation(TsControlBlueprintFunctionLibrary.__SetBpInputComponent_FunctionParams* __Params)
	{
		BP_InputBase_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_InputBase_C>(__Params->bpInputComp);
		TsControlBlueprintFunctionLibrary.SetBpInputComponent(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x0400BA0F RID: 47631
	[StaticVariableRuleIgnore]
	private static FVector2D _tmpVector2D = new FVector2D();

	// Token: 0x0400BA10 RID: 47632
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector = Vector.Create();

	// Token: 0x0400BA11 RID: 47633
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsControlBlueprintFunctionLibrary.TsControlBlueprintFunctionLibrary_C";

	// Token: 0x0400BA12 RID: 47634
	private static IntPtr _ClassPtr;

	// Token: 0x0400BA13 RID: 47635
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x020090D2 RID: 37074
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetMoveVectorCache_FunctionParams
	{
		// Token: 0x040307FE RID: 198654
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040307FF RID: 198655
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030800 RID: 198656
		[FieldOffset(16)]
		public FVector2D __Result;
	}

	// Token: 0x020090D3 RID: 37075
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetMoveDirectionCache_FunctionParams
	{
		// Token: 0x04030801 RID: 198657
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030802 RID: 198658
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030803 RID: 198659
		[FieldOffset(16)]
		public FVector2D __Result;
	}

	// Token: 0x020090D4 RID: 37076
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetWorldMoveDirectionCache_FunctionParams
	{
		// Token: 0x04030804 RID: 198660
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030805 RID: 198661
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030806 RID: 198662
		[FieldOffset(16)]
		public FVector2D __Result;
	}

	// Token: 0x020090D5 RID: 37077
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetMoveVector_FunctionParams
	{
		// Token: 0x04030807 RID: 198663
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030808 RID: 198664
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030809 RID: 198665
		[FieldOffset(16)]
		public FVector2D __Result;
	}

	// Token: 0x020090D6 RID: 37078
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetMoveDirection_FunctionParams
	{
		// Token: 0x0403080A RID: 198666
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403080B RID: 198667
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403080C RID: 198668
		[FieldOffset(16)]
		public FVector2D __Result;
	}

	// Token: 0x020090D7 RID: 37079
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __PlayKuroForceFeedback_FunctionParams
	{
		// Token: 0x0403080D RID: 198669
		[FieldOffset(0)]
		public IntPtr forceFeedbackEffect;

		// Token: 0x0403080E RID: 198670
		[FieldOffset(8)]
		public FName tag;

		// Token: 0x0403080F RID: 198671
		[FieldOffset(20)]
		public bool bLooping;

		// Token: 0x04030810 RID: 198672
		[FieldOffset(21)]
		public bool bIgnoreTimeDilation;

		// Token: 0x04030811 RID: 198673
		[FieldOffset(22)]
		public bool bPlayWhilePaused;

		// Token: 0x04030812 RID: 198674
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090D8 RID: 37080
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __StopKuroForceFeedback_FunctionParams
	{
		// Token: 0x04030813 RID: 198675
		[FieldOffset(0)]
		public IntPtr forceFeedbackEffect;

		// Token: 0x04030814 RID: 198676
		[FieldOffset(8)]
		public FName tag;

		// Token: 0x04030815 RID: 198677
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090D9 RID: 37081
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __BpInputReceiveEndPlay_FunctionParams
	{
		// Token: 0x04030816 RID: 198678
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030817 RID: 198679
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090DA RID: 37082
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetUseControllerRotationYaw_FunctionParams
	{
		// Token: 0x04030818 RID: 198680
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030819 RID: 198681
		[FieldOffset(4)]
		public bool value;

		// Token: 0x0403081A RID: 198682
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090DB RID: 37083
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetBpInputComponent_FunctionParams
	{
		// Token: 0x0403081B RID: 198683
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403081C RID: 198684
		[FieldOffset(8)]
		public IntPtr bpInputComp;

		// Token: 0x0403081D RID: 198685
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}
}
