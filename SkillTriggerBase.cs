using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003138 RID: 12600
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Component/Skill/SkillTrigger/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Component/Skill/SkillTrigger/SkillTriggerBase.SkillTriggerBase_C")]
public class SkillTriggerBase : UKuroBpDataAsset, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700236D RID: 9069
	// (get) Token: 0x0601A169 RID: 106857 RVA: 0x007A71CC File Offset: 0x007A53CC
	// (set) Token: 0x0601A16A RID: 106858 RVA: 0x007A7205 File Offset: 0x007A5405
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SSkillBehaviorCondition> TriggerConditionGroup
	{
		get
		{
			base.FastCheckIsValid();
			TArray<SSkillBehaviorCondition> result;
			if ((result = this._TriggerConditionGroup) == null)
			{
				result = (this._TriggerConditionGroup = new TArray<SSkillBehaviorCondition>(base.NativePtr + (IntPtr)SkillTriggerBase.__PropertyOffset_TriggerConditionGroup, this));
			}
			return result;
		}
		set
		{
			this.TriggerConditionGroup.CopyAssign(value);
		}
	}

	// Token: 0x1700236E RID: 9070
	// (get) Token: 0x0601A16B RID: 106859 RVA: 0x007A7213 File Offset: 0x007A5413
	// (set) Token: 0x0601A16C RID: 106860 RVA: 0x007A7227 File Offset: 0x007A5427
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string TriggerConditionFormula
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SkillTriggerBase.__PropertyOffset_TriggerConditionFormula)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SkillTriggerBase.__PropertyOffset_TriggerConditionFormula)), value);
		}
	}

	// Token: 0x0601A16D RID: 106861 RVA: 0x007A723C File Offset: 0x007A543C
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (SkillTriggerBase._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Component/Skill/SkillTrigger/SkillTriggerBase.SkillTriggerBase_C");
		}
		return SkillTriggerBase._ClassPtr;
	}

	// Token: 0x0601A16E RID: 106862 RVA: 0x007A7260 File Offset: 0x007A5460
	public SkillTriggerBase() : this(BuiltinUtils.AllocNativeUObject(SkillTriggerBase.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601A16F RID: 106863 RVA: 0x007A7288 File Offset: 0x007A5488
	public SkillTriggerBase(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SkillTriggerBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601A170 RID: 106864 RVA: 0x007A72BB File Offset: 0x007A54BB
	protected SkillTriggerBase(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400D155 RID: 53589
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Component/Skill/SkillTrigger/SkillTriggerBase.SkillTriggerBase_C";

	// Token: 0x0400D156 RID: 53590
	private static IntPtr _ClassPtr;

	// Token: 0x0400D157 RID: 53591
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400D158 RID: 53592
	private static int __PropertyOffset_TriggerConditionGroup;

	// Token: 0x0400D159 RID: 53593
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SSkillBehaviorCondition> _TriggerConditionGroup;

	// Token: 0x0400D15A RID: 53594
	private static int __PropertyOffset_TriggerConditionFormula;
}
