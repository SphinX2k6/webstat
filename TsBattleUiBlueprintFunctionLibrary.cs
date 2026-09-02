using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Battle;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002E30 RID: 11824
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsBattleUiBlueprintFunctionLibrary.TsBattleUiBlueprintFunctionLibrary_C")]
public class TsBattleUiBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x06017FB6 RID: 98230 RVA: 0x006B7414 File Offset: 0x006B5614
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetBattleScoreStr()
	{
		BattleScoreModel instance = ModelBase<BattleScoreModel>.Instance;
		int num = (instance != null) ? instance.GetCurScoreId() : 0;
		if (num == 0)
		{
			return "";
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
		defaultInterpolatedStringHandler.AppendLiteral("Id:");
		defaultInterpolatedStringHandler.AppendFormatted<int>(num);
		defaultInterpolatedStringHandler.AppendLiteral(",Score:");
		BattleScoreModel instance2 = ModelBase<BattleScoreModel>.Instance;
		defaultInterpolatedStringHandler.AppendFormatted<int>((instance2 != null) ? instance2.GetScore(num) : 0);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06017FB7 RID: 98231 RVA: 0x006B7486 File Offset: 0x006B5686
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsBattleUiBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsBattleUiBlueprintFunctionLibrary.TsBattleUiBlueprintFunctionLibrary_C");
		}
		return TsBattleUiBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x06017FB8 RID: 98232 RVA: 0x006B74AC File Offset: 0x006B56AC
	public TsBattleUiBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(TsBattleUiBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017FB9 RID: 98233 RVA: 0x006B74D4 File Offset: 0x006B56D4
	[NullableContext(1)]
	public TsBattleUiBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBattleUiBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017FBA RID: 98234 RVA: 0x006B7507 File Offset: 0x006B5707
	protected TsBattleUiBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06017FBB RID: 98235 RVA: 0x006B7510 File Offset: 0x006B5710
	protected unsafe static void __CPPCALL_GetBattleScoreStr_Implementation(TsBattleUiBlueprintFunctionLibrary.__GetBattleScoreStr_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsBattleUiBlueprintFunctionLibrary.GetBattleScoreStr());
	}

	// Token: 0x0400BA0C RID: 47628
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsBattleUiBlueprintFunctionLibrary.TsBattleUiBlueprintFunctionLibrary_C";

	// Token: 0x0400BA0D RID: 47629
	private static IntPtr _ClassPtr;

	// Token: 0x0400BA0E RID: 47630
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x020090D1 RID: 37073
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBattleScoreStr_FunctionParams
	{
		// Token: 0x040307FC RID: 198652
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x040307FD RID: 198653
		[FieldOffset(8)]
		public FString __Result;
	}
}
