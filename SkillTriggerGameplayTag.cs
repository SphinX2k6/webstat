using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200313A RID: 12602
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Component/Skill/SkillTrigger/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Component/Skill/SkillTrigger/SkillTriggerGameplayTag.SkillTriggerGameplayTag_C")]
public class SkillTriggerGameplayTag : SkillTriggerBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700236F RID: 9071
	// (get) Token: 0x0601A176 RID: 106870 RVA: 0x007A7304 File Offset: 0x007A5504
	// (set) Token: 0x0601A177 RID: 106871 RVA: 0x007A733D File Offset: 0x007A553D
	[UProperty(EPropertyFlags.CPF_None)]
	public FAbilityTriggerData TriggerData
	{
		get
		{
			base.FastCheckIsValid();
			FAbilityTriggerData result;
			if ((result = this._TriggerData) == null)
			{
				result = (this._TriggerData = new FAbilityTriggerData(base.NativePtr + (IntPtr)SkillTriggerGameplayTag.__PropertyOffset_TriggerData, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FAbilityTriggerData.StaticStruct(), base.NativePtr + (IntPtr)SkillTriggerGameplayTag.__PropertyOffset_TriggerData, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x0601A178 RID: 106872 RVA: 0x007A7365 File Offset: 0x007A5565
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (SkillTriggerGameplayTag._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Component/Skill/SkillTrigger/SkillTriggerGameplayTag.SkillTriggerGameplayTag_C");
		}
		return SkillTriggerGameplayTag._ClassPtr;
	}

	// Token: 0x0601A179 RID: 106873 RVA: 0x007A738C File Offset: 0x007A558C
	public SkillTriggerGameplayTag() : this(BuiltinUtils.AllocNativeUObject(SkillTriggerGameplayTag.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601A17A RID: 106874 RVA: 0x007A73B4 File Offset: 0x007A55B4
	public SkillTriggerGameplayTag(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SkillTriggerGameplayTag.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601A17B RID: 106875 RVA: 0x007A73E7 File Offset: 0x007A55E7
	protected SkillTriggerGameplayTag(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400D15C RID: 53596
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Component/Skill/SkillTrigger/SkillTriggerGameplayTag.SkillTriggerGameplayTag_C";

	// Token: 0x0400D15D RID: 53597
	private static IntPtr _ClassPtr;

	// Token: 0x0400D15E RID: 53598
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400D15F RID: 53599
	private static int __PropertyOffset_TriggerData;

	// Token: 0x0400D160 RID: 53600
	[Nullable(2)]
	private FAbilityTriggerData _TriggerData;
}
