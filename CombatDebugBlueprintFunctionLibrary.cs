using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Core.Common;
using CSharpScript.Game.AI.StateMachine;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.Utils;
using CSharpScript.Utils;
using Google.Protobuf.Collections;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003447 RID: 13383
[UClass("/Game/Aki/TypeScript/Game/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Utils/CombatDebugBlueprintFunctionLibrary.CombatDebugBlueprintFunctionLibrary_C")]
public class CombatDebugBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601C0EB RID: 114923 RVA: 0x0085D5AC File Offset: 0x0085B7AC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void AddPassiveSkillForDebug(int entityId, long passiveSkillId)
	{
		CharacterPassiveSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPassiveSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.LearnPassiveSkill(passiveSkillId, new AddPassiveSkillParam
			{
				CombatMessageId = -1L,
				PreMessageId = new long?(-1L)
			});
		}
	}

	// Token: 0x0601C0EC RID: 114924 RVA: 0x0085D5F4 File Offset: 0x0085B7F4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void RemovePassiveSkillForDebug(int entityId, long passiveSkillId)
	{
		CharacterPassiveSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPassiveSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.ForgetPassiveSkill(passiveSkillId, false);
		}
	}

	// Token: 0x0601C0ED RID: 114925 RVA: 0x0085D620 File Offset: 0x0085B820
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool GetDebugMonsterMovePath()
	{
		CombatDebugDrawController instance = ControllerBase<CombatDebugDrawController>.Instance;
		return instance != null && instance.DebugMonsterMovePath;
	}

	// Token: 0x0601C0EE RID: 114926 RVA: 0x0085D632 File Offset: 0x0085B832
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetDebugMonsterMovePath(bool value)
	{
		ControllerBase<CombatDebugDrawController>.Instance.DebugMonsterMovePath = value;
	}

	// Token: 0x0601C0EF RID: 114927 RVA: 0x0085D63F File Offset: 0x0085B83F
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool GetDebugMonsterControl()
	{
		CombatDebugDrawController instance = ControllerBase<CombatDebugDrawController>.Instance;
		return instance != null && instance.DebugMonsterControl;
	}

	// Token: 0x0601C0F0 RID: 114928 RVA: 0x0085D651 File Offset: 0x0085B851
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetDebugMonsterControl(bool value)
	{
		ControllerBase<CombatDebugDrawController>.Instance.DebugMonsterControl = value;
	}

	// Token: 0x0601C0F1 RID: 114929 RVA: 0x0085D660 File Offset: 0x0085B860
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void OpenMonsterServerLogic(bool value)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CloseMonsterServerLogic#");
		defaultInterpolatedStringHandler.AppendFormatted<int>((!value) ? 1 : 0);
		string p = defaultInterpolatedStringHandler.ToStringAndClear();
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.RunGm, p);
	}

	// Token: 0x0601C0F2 RID: 114930 RVA: 0x0085D6A7 File Offset: 0x0085B8A7
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool IsDrawEntityBoxEnabled()
	{
		CombatDebugDrawController instance = ControllerBase<CombatDebugDrawController>.Instance;
		return instance != null && instance.IsDrawEntityBoxEnabled;
	}

	// Token: 0x0601C0F3 RID: 114931 RVA: 0x0085D6B9 File Offset: 0x0085B8B9
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetDrawEntityBoxEnabled(bool isEnable)
	{
		ControllerBase<CombatDebugDrawController>.Instance.IsDrawEntityBoxEnabled = isEnable;
	}

	// Token: 0x0601C0F4 RID: 114932 RVA: 0x0085D6C6 File Offset: 0x0085B8C6
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool IsDrawEntityBoxInfoEnabled()
	{
		CombatDebugDrawController instance = ControllerBase<CombatDebugDrawController>.Instance;
		return instance != null && instance.IsDrawEntityBoxInfoEnabled;
	}

	// Token: 0x0601C0F5 RID: 114933 RVA: 0x0085D6D8 File Offset: 0x0085B8D8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetDrawEntityBoxInfoEnabled(bool isEnable)
	{
		ControllerBase<CombatDebugDrawController>.Instance.IsDrawEntityBoxInfoEnabled = isEnable;
	}

	// Token: 0x0601C0F6 RID: 114934 RVA: 0x0085D6E5 File Offset: 0x0085B8E5
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TArray<string> GetCombatScriptIndexes()
	{
		return ControllerBase<CombatDebugController>.Instance.ScriptHelper.CombatScriptIndexes;
	}

	// Token: 0x0601C0F7 RID: 114935 RVA: 0x0085D6F6 File Offset: 0x0085B8F6
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string FilterScript(string cmd)
	{
		return ControllerBase<CombatDebugController>.Instance.FilterCmd(cmd);
	}

	// Token: 0x0601C0F8 RID: 114936 RVA: 0x0085D704 File Offset: 0x0085B904
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool IsDebugPrintOpened(string moduleName)
	{
		CombatLog.EDebugModule item;
		return Enum.TryParse<CombatLog.EDebugModule>(moduleName, out item) && Singleton<CombatLog>.Instance.DebugCombatInfo.Contains(item);
	}

	// Token: 0x0601C0F9 RID: 114937 RVA: 0x0085D730 File Offset: 0x0085B930
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetDebugPrintOpened(string moduleName, bool isOpen)
	{
		CombatLog.EDebugModule item;
		if (!Enum.TryParse<CombatLog.EDebugModule>(moduleName, out item))
		{
			return;
		}
		if (isOpen)
		{
			Singleton<CombatLog>.Instance.DebugCombatInfo.Add(item);
			return;
		}
		Singleton<CombatLog>.Instance.DebugCombatInfo.Remove(item);
	}

	// Token: 0x0601C0FA RID: 114938 RVA: 0x0085D76E File Offset: 0x0085B96E
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void TryRefreshServerDebugInfo()
	{
		CombatDebugController instance = ControllerBase<CombatDebugController>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.RefreshServerDebugInfo();
	}

	// Token: 0x0601C0FB RID: 114939 RVA: 0x0085D780 File Offset: 0x0085B980
	[NullableContext(1)]
	protected static BaseBuffComponent GetBuffComponent(int entityId, int handle)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		if (((baseBuffComponent != null) ? baseBuffComponent.GetBuffByHandle(handle) : null) != null)
		{
			return baseBuffComponent;
		}
		if (baseBuffComponent != null)
		{
			RoleBuffComponent roleBuffComponent = baseBuffComponent as RoleBuffComponent;
			if (roleBuffComponent != null)
			{
				PlayerBuffComponent formationBuffComp = roleBuffComponent.GetFormationBuffComp();
				if (((formationBuffComp != null) ? formationBuffComp.GetBuffByHandle(handle) : null) != null)
				{
					return roleBuffComponent.GetFormationBuffComp();
				}
			}
		}
		return null;
	}

	// Token: 0x0601C0FC RID: 114940 RVA: 0x0085D7E0 File Offset: 0x0085B9E0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetServerBuffRemainDuration(int entityId, int handle)
	{
		BaseBuffComponent buffComponent = CombatDebugBlueprintFunctionLibrary.GetBuffComponent(entityId, handle);
		CharacterGasDebugComponent characterGasDebugComponent = (buffComponent != null) ? buffComponent.Entity.GetComponent<CharacterGasDebugComponent>() : null;
		if (characterGasDebugComponent == null)
		{
			return -1f;
		}
		return characterGasDebugComponent.GetServerBuffRemainDuration(handle);
	}

	// Token: 0x0601C0FD RID: 114941 RVA: 0x0085D80A File Offset: 0x0085BA0A
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetServerBuffTotalDuration(int entityId, int handle)
	{
		BaseBuffComponent buffComponent = CombatDebugBlueprintFunctionLibrary.GetBuffComponent(entityId, handle);
		CharacterGasDebugComponent characterGasDebugComponent = (buffComponent != null) ? buffComponent.Entity.GetComponent<CharacterGasDebugComponent>() : null;
		if (characterGasDebugComponent == null)
		{
			return -1f;
		}
		return characterGasDebugComponent.GetServerBuffTotalDuration(handle);
	}

	// Token: 0x0601C0FE RID: 114942 RVA: 0x0085D834 File Offset: 0x0085BA34
	[NullableContext(1)]
	private static ActiveBuffInternal GetDebugBuff(int entityId, int handle)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		IActiveBuff activeBuff = (baseBuffComponent != null) ? baseBuffComponent.GetBuffByHandle(handle) : null;
		if (activeBuff != null)
		{
			return activeBuff as ActiveBuffInternal;
		}
		if (activeBuff == null)
		{
			RoleBuffComponent roleBuffComponent = baseBuffComponent as RoleBuffComponent;
			if (roleBuffComponent != null)
			{
				return roleBuffComponent.GetFormationBuffComp().GetBuffByHandle(handle) as ActiveBuffInternal;
			}
		}
		return null;
	}

	// Token: 0x0601C0FF RID: 114943 RVA: 0x0085D891 File Offset: 0x0085BA91
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetBuffRemainDuration(int entityId, int handle)
	{
		ActiveBuffInternal debugBuff = CombatDebugBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		if (debugBuff == null)
		{
			return -1f;
		}
		return debugBuff.GetRemainDuration();
	}

	// Token: 0x0601C100 RID: 114944 RVA: 0x0085D8A9 File Offset: 0x0085BAA9
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetBuffTotalDuration(int entityId, int handle)
	{
		ActiveBuffInternal debugBuff = CombatDebugBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		if (debugBuff == null)
		{
			return -1f;
		}
		return debugBuff.Duration;
	}

	// Token: 0x0601C101 RID: 114945 RVA: 0x0085D8C4 File Offset: 0x0085BAC4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool HasServerBuff(int entityId, int handle)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		CharacterGasDebugComponent characterGasDebugComponent = (entity != null) ? entity.GetComponent<CharacterGasDebugComponent>() : null;
		if (characterGasDebugComponent == null)
		{
			return false;
		}
		Entity entity2 = Singleton<EntitySystem>.Instance.Get(entityId);
		RoleBuffComponent roleBuffComponent = (entity2 != null) ? entity2.GetComponent<RoleBuffComponent>() : null;
		CharacterGasDebugComponent characterGasDebugComponent2;
		if (roleBuffComponent == null)
		{
			characterGasDebugComponent2 = null;
		}
		else
		{
			PlayerBuffComponent formationBuffComp = roleBuffComponent.GetFormationBuffComp();
			characterGasDebugComponent2 = ((formationBuffComp != null) ? formationBuffComp.Entity.GetComponent<CharacterGasDebugComponent>() : null);
		}
		CharacterGasDebugComponent characterGasDebugComponent3 = characterGasDebugComponent2;
		return characterGasDebugComponent.HasServerBuff(handle) || (characterGasDebugComponent3 != null && characterGasDebugComponent3.HasServerBuff(handle)) || (!characterGasDebugComponent.HasBuffRequest(handle) && (characterGasDebugComponent3 == null || !characterGasDebugComponent3.HasBuffRequest(handle)));
	}

	// Token: 0x0601C102 RID: 114946 RVA: 0x0085D958 File Offset: 0x0085BB58
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetAttributeDebugString(int entityId, string filterStr = "")
	{
		HashSet<int> hashSet = new HashSet<int>();
		using (IEnumerator enumerator = Regex.Matches(filterStr, "[0-9]+").GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				int item;
				if (int.TryParse(enumerator.Current.ToString(), out item))
				{
					hashSet.Add(item);
				}
			}
		}
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		BaseAttributeComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<BaseAttributeComponent>(entityId);
		if (component == null || component2 == null)
		{
			return "";
		}
		HashSet<EAttributeType> hashSet2 = new HashSet<EAttributeType>(CharacterAttributeTypes.attributeIdsWithMax.Values);
		HashSet<EAttributeType> hashSet3 = new HashSet<EAttributeType>(CharacterAttributeTypes.attrsAutoRecoverSpeedMap.Values);
		HashSet<EAttributeType> hashSet4 = new HashSet<EAttributeType>(CharacterAttributeTypes.attrsAutoRecoverMaxMap.Values);
		StringBuilder stringBuilder = new StringBuilder();
		EntityBattleInfoResponse serverDebugInfo = component.ServerDebugInfo;
		RepeatedField<GameplayAttributeData> repeatedField = (serverDebugInfo != null) ? serverDebugInfo.Attributes : null;
		GameplayAttributeData[] array = new GameplayAttributeData[143];
		if (repeatedField != null)
		{
			foreach (GameplayAttributeData gameplayAttributeData in repeatedField)
			{
				array[gameplayAttributeData.AttributeType] = gameplayAttributeData;
			}
		}
		for (int i = 1; i < 143; i++)
		{
			EAttributeType eattributeType = (EAttributeType)i;
			if (!CharacterAttributeTypes.attributeIdsWithMax.ContainsKey(eattributeType) && !hashSet2.Contains(eattributeType) && !CharacterAttributeTypes.attrsAutoRecoverSpeedMap.ContainsKey(eattributeType) && !hashSet3.Contains(eattributeType) && !hashSet4.Contains(eattributeType) && (hashSet.Count <= 0 || hashSet.Contains(i)))
			{
				string value = eattributeType.ToString();
				float baseValue = component2.GetBaseValue(eattributeType);
				float currentValue = component2.GetCurrentValue(eattributeType);
				string value2 = currentValue.ToString("0");
				string value3 = (currentValue == baseValue) ? "" : (((currentValue > baseValue) ? "(+" : "(") + (currentValue - baseValue).ToString("0") + ")");
				GameplayAttributeData gameplayAttributeData2 = array[i];
				int num = (gameplayAttributeData2 != null) ? gameplayAttributeData2.BaseValue : 0;
				int num2 = (gameplayAttributeData2 != null) ? gameplayAttributeData2.CurrentValue : 0;
				string value4 = num2.ToString("0");
				string value5 = (num2 == num) ? "" : (((num2 > num) ? "(+" : "(") + (num2 - num).ToString("0") + ")");
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder3 = stringBuilder2;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(10, 6, stringBuilder2);
				appendInterpolatedStringHandler.AppendLiteral("#");
				appendInterpolatedStringHandler.AppendFormatted<int>((int)eattributeType);
				appendInterpolatedStringHandler.AppendLiteral(" ");
				appendInterpolatedStringHandler.AppendFormatted(value);
				appendInterpolatedStringHandler.AppendLiteral(" C:");
				appendInterpolatedStringHandler.AppendFormatted(value2);
				appendInterpolatedStringHandler.AppendFormatted(value3);
				appendInterpolatedStringHandler.AppendLiteral(" | S:");
				appendInterpolatedStringHandler.AppendFormatted(value4);
				appendInterpolatedStringHandler.AppendFormatted(value5);
				stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
			}
		}
		return stringBuilder.ToString().Trim();
	}

	// Token: 0x0601C103 RID: 114947 RVA: 0x0085DC7C File Offset: 0x0085BE7C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetStateAttributeDebugString(int entityId, string filterStr = "")
	{
		HashSet<int> hashSet = new HashSet<int>();
		using (IEnumerator enumerator = Regex.Matches(filterStr, "[0-9]+").GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				int item;
				if (int.TryParse(enumerator.Current.ToString(), out item))
				{
					hashSet.Add(item);
				}
			}
		}
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		BaseAttributeComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<BaseAttributeComponent>(entityId);
		if (component == null || component2 == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		EntityBattleInfoResponse serverDebugInfo = component.ServerDebugInfo;
		RepeatedField<GameplayAttributeData> repeatedField = (serverDebugInfo != null) ? serverDebugInfo.Attributes : null;
		GameplayAttributeData[] array = new GameplayAttributeData[143];
		if (repeatedField != null)
		{
			foreach (GameplayAttributeData gameplayAttributeData in repeatedField)
			{
				array[gameplayAttributeData.AttributeType] = gameplayAttributeData;
			}
		}
		for (int i = 1; i < 143; i++)
		{
			EAttributeType eattributeType = (EAttributeType)i;
			if ((CharacterAttributeTypes.attributeIdsWithMax.ContainsKey(eattributeType) || CharacterAttributeTypes.attrsAutoRecoverSpeedMap.ContainsKey(eattributeType)) && (hashSet.Count <= 0 || hashSet.Contains(i)))
			{
				string value = eattributeType.ToString();
				string value2 = component2.GetBaseValue(eattributeType).ToString("0");
				GameplayAttributeData gameplayAttributeData2 = array[i];
				string value3 = ((gameplayAttributeData2 != null) ? gameplayAttributeData2.BaseValue : 0).ToString("0");
				if (CharacterAttributeTypes.attrsAutoRecoverSpeedMap.ContainsKey(eattributeType))
				{
					EAttributeType eattributeType2 = CharacterAttributeTypes.attrsAutoRecoverSpeedMap[eattributeType];
					EAttributeType eattributeType3 = CharacterAttributeTypes.attrsAutoRecoverMaxMap[eattributeType];
					string value4 = component2.GetCurrentValue(eattributeType3).ToString("0");
					GameplayAttributeData gameplayAttributeData3 = array[(int)eattributeType3];
					string value5 = ((gameplayAttributeData3 != null) ? gameplayAttributeData3.CurrentValue : 0).ToString("0");
					string value6 = component2.GetCurrentValue(eattributeType2).ToString("0");
					GameplayAttributeData gameplayAttributeData4 = array[(int)eattributeType2];
					string value7 = ((gameplayAttributeData4 != null) ? gameplayAttributeData4.CurrentValue : 0).ToString("0");
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder3 = stringBuilder2;
					StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(22, 8, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("#");
					appendInterpolatedStringHandler.AppendFormatted<int>((int)eattributeType);
					appendInterpolatedStringHandler.AppendLiteral(" ");
					appendInterpolatedStringHandler.AppendFormatted(value);
					appendInterpolatedStringHandler.AppendLiteral(" C:");
					appendInterpolatedStringHandler.AppendFormatted(value2);
					appendInterpolatedStringHandler.AppendLiteral("/");
					appendInterpolatedStringHandler.AppendFormatted(value4);
					appendInterpolatedStringHandler.AppendLiteral(" (");
					appendInterpolatedStringHandler.AppendFormatted(value6);
					appendInterpolatedStringHandler.AppendLiteral("/s) | S:");
					appendInterpolatedStringHandler.AppendFormatted(value3);
					appendInterpolatedStringHandler.AppendLiteral("/");
					appendInterpolatedStringHandler.AppendFormatted(value5);
					appendInterpolatedStringHandler.AppendLiteral(" (");
					appendInterpolatedStringHandler.AppendFormatted(value7);
					appendInterpolatedStringHandler.AppendLiteral("/s)");
					stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
				}
				else if (CharacterAttributeTypes.attributeIdsWithMax.ContainsKey(eattributeType))
				{
					EAttributeType eattributeType4 = CharacterAttributeTypes.attributeIdsWithMax[eattributeType];
					string value8 = component2.GetCurrentValue(eattributeType4).ToString("0");
					GameplayAttributeData gameplayAttributeData5 = array[(int)eattributeType4];
					string value9 = ((gameplayAttributeData5 != null) ? gameplayAttributeData5.CurrentValue : 0).ToString("0");
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder4 = stringBuilder2;
					StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 6, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("#");
					appendInterpolatedStringHandler.AppendFormatted<int>((int)eattributeType);
					appendInterpolatedStringHandler.AppendLiteral(" ");
					appendInterpolatedStringHandler.AppendFormatted(value);
					appendInterpolatedStringHandler.AppendLiteral(" C:");
					appendInterpolatedStringHandler.AppendFormatted(value2);
					appendInterpolatedStringHandler.AppendLiteral("/");
					appendInterpolatedStringHandler.AppendFormatted(value8);
					appendInterpolatedStringHandler.AppendLiteral(" | S:");
					appendInterpolatedStringHandler.AppendFormatted(value3);
					appendInterpolatedStringHandler.AppendLiteral("/");
					appendInterpolatedStringHandler.AppendFormatted(value9);
					stringBuilder4.AppendLine(ref appendInterpolatedStringHandler);
				}
			}
		}
		return stringBuilder.ToString().Trim();
	}

	// Token: 0x0601C104 RID: 114948 RVA: 0x0085E088 File Offset: 0x0085C288
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetFormationAttributeDebugString(int entityId, string filterStr = "")
	{
		HashSet<int> hashSet = new HashSet<int>();
		using (IEnumerator enumerator = Regex.Matches(filterStr, "[0-9]+").GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				int item;
				if (int.TryParse(enumerator.Current.ToString(), out item))
				{
					hashSet.Add(item);
				}
			}
		}
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		EntityBattleInfoResponse serverDebugInfo = component.ServerDebugInfo;
		RepeatedField<FormationAttr> repeatedField = (serverDebugInfo != null) ? serverDebugInfo.FormationAttrs : null;
		Dictionary<int, FormationAttr> dictionary = new Dictionary<int, FormationAttr>();
		if (repeatedField != null)
		{
			foreach (FormationAttr formationAttr in repeatedField)
			{
				dictionary[formationAttr.AttrId] = formationAttr;
			}
		}
		foreach (FormationProperty formationProperty in ConfigFormationPropertyAll.GetConfigList(true))
		{
			if (hashSet.Count <= 0 || hashSet.Contains(formationProperty.Id))
			{
				int id = formationProperty.Id;
				EFormationAttributeId eformationAttributeId = (EFormationAttributeId)id;
				float value = ControllerBase<FormationAttributeController>.Instance.GetValue(eformationAttributeId);
				float max = ControllerBase<FormationAttributeController>.Instance.GetMax(eformationAttributeId);
				float speed = ControllerBase<FormationAttributeController>.Instance.GetSpeed(eformationAttributeId);
				FormationAttr formationAttr2;
				dictionary.TryGetValue((int)eformationAttributeId, out formationAttr2);
				string value2 = ((formationAttr2 != null) ? formationAttr2.CurrentValue.ToString("0") : null) ?? "???";
				string value3 = ((formationAttr2 != null) ? formationAttr2.MaxValue.ToString("0") : null) ?? "???";
				string value4 = ((formationAttr2 != null) ? formationAttr2.Ratio.ToString("0") : null) ?? "???";
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder3 = stringBuilder2;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(21, 7, stringBuilder2);
				appendInterpolatedStringHandler.AppendLiteral("#");
				appendInterpolatedStringHandler.AppendFormatted<int>(id);
				appendInterpolatedStringHandler.AppendLiteral(" C:");
				appendInterpolatedStringHandler.AppendFormatted(value.ToString("0"));
				appendInterpolatedStringHandler.AppendLiteral("/");
				appendInterpolatedStringHandler.AppendFormatted(max.ToString("0"));
				appendInterpolatedStringHandler.AppendLiteral(" (");
				appendInterpolatedStringHandler.AppendFormatted(speed.ToString("0"));
				appendInterpolatedStringHandler.AppendLiteral("/s)");
				appendInterpolatedStringHandler.AppendLiteral(" | S:");
				appendInterpolatedStringHandler.AppendFormatted(value2);
				appendInterpolatedStringHandler.AppendLiteral("/");
				appendInterpolatedStringHandler.AppendFormatted(value3);
				appendInterpolatedStringHandler.AppendLiteral(" (");
				appendInterpolatedStringHandler.AppendFormatted(value4);
				appendInterpolatedStringHandler.AppendLiteral("/s)");
				stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
			}
		}
		return stringBuilder.ToString().Trim();
	}

	// Token: 0x0601C105 RID: 114949 RVA: 0x0085E3A0 File Offset: 0x0085C5A0
	[NullableContext(1)]
	protected static Dictionary<string, string> ServerSkillMap(string serverPassiveSkillInfo)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (string text in serverPassiveSkillInfo.Split(new string[]
		{
			"技能:"
		}, StringSplitOptions.None))
		{
			if (!string.IsNullOrEmpty(text))
			{
				Match match = Regex.Match(text, "(?<skillId>\\d+)");
				if (match.Success && match.Groups["skillId"] != null)
				{
					string value = match.Groups["skillId"].Value;
					dictionary[value] = "技能:" + text;
				}
			}
		}
		return dictionary;
	}

	// Token: 0x0601C106 RID: 114950 RVA: 0x0085E438 File Offset: 0x0085C638
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static TArray<long> ExtractInt64ArrayFromString(string content)
	{
		TArray<long> tarray = new TArray<long>();
		if (string.IsNullOrEmpty(content))
		{
			return tarray;
		}
		foreach (object obj in Regex.Matches(content, "[-+]?\\d+"))
		{
			string value = ((Match)obj).Value;
			if (!string.IsNullOrEmpty(value))
			{
				tarray.Add(long.Parse(value));
			}
		}
		return tarray;
	}

	// Token: 0x0601C107 RID: 114951 RVA: 0x0085E4BC File Offset: 0x0085C6BC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static TArray<string> ExtractTagNameArrayFromString(string content)
	{
		TArray<string> tarray = new TArray<string>();
		if (string.IsNullOrEmpty(content))
		{
			return tarray;
		}
		HashSet<string> hashSet = new HashSet<string>();
		foreach (object obj in new Regex("[A-Za-z_\\u3400-\\u9fff][A-Za-z0-9_\\u3400-\\u9fff]*(?:\\.[A-Za-z0-9_\\u3400-\\u9fff]+)+").Matches(content))
		{
			string value = ((Match)obj).Value;
			string text = (value != null) ? value.Trim() : null;
			if (!string.IsNullOrEmpty(text))
			{
				hashSet.Add(text);
			}
		}
		foreach (string value2 in hashSet)
		{
			tarray.Add(value2);
		}
		return tarray;
	}

	// Token: 0x0601C108 RID: 114952 RVA: 0x0085E594 File Offset: 0x0085C794
	[NullableContext(1)]
	protected static string GetPassiveCdString(PassiveSkillCdInfo cdInfo)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (KeyValuePair<int, double> keyValuePair in cdInfo.SkillCdFinishStampMap)
		{
			int key = keyValuePair.Key;
			double curRemainingCd = cdInfo.GetCurRemainingCd(key);
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(14, 2, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("entityId: ");
			appendInterpolatedStringHandler.AppendFormatted<int>(key);
			appendInterpolatedStringHandler.AppendLiteral(" CD:");
			appendInterpolatedStringHandler.AppendFormatted(curRemainingCd.ToString("0.00"));
			stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0601C109 RID: 114953 RVA: 0x0085E64C File Offset: 0x0085C84C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetPassiveDebugString(int entityId, string filterStr = "")
	{
		List<string> list = new List<string>();
		foreach (object obj in Regex.Matches(filterStr, "[0-9]+"))
		{
			list.Add(obj.ToString());
		}
		CharacterPassiveSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPassiveSkillComponent>(entityId);
		CharacterTriggerComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterTriggerComponent>(entityId);
		if (component == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (component.GetAllPassiveSkills().Length != 0)
		{
			BaseSkillCdComponent component3 = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillCdComponent>(entityId);
			stringBuilder.AppendLine("----- 客户端被动技能 -----");
			PassiveSkillData[] allPassiveSkills = component.GetAllPassiveSkills();
			for (int j = 0; j < allPassiveSkills.Length; j++)
			{
				PassiveSkillData skill = allPassiveSkills[j];
				if (list.Count <= 0 || list.Any((string key) => skill.SkillId.ToString().StartsWith(key)))
				{
					Trigger trigger = (component2 != null) ? component2.GetTrigger(skill.TriggerHandle) : null;
					PassiveSkill? config = ConfigPassiveSkillById.GetConfig(skill.SkillId, true);
					PassiveSkillCdInfo passiveSkillCdInfo = (component3 != null) ? component3.GetPassiveSkillCdInfo(skill.SkillId) : null;
					string value = (passiveSkillCdInfo != null) ? CombatDebugBlueprintFunctionLibrary.GetPassiveCdString(passiveSkillCdInfo) : "【无CD组件】";
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder3 = stringBuilder2;
					StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("技能: ");
					appendInterpolatedStringHandler.AppendFormatted<long>(skill.SkillId);
					appendInterpolatedStringHandler.AppendLiteral(" handle: ");
					appendInterpolatedStringHandler.AppendFormatted<int>(skill.TriggerHandle);
					stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder.Append(value);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder4 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(4, 1, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("说明: ");
					appendInterpolatedStringHandler.AppendFormatted((config != null) ? config.GetValueOrDefault().SkillDesc : null);
					stringBuilder4.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder5 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(7, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("触发器类型: ");
					appendInterpolatedStringHandler.AppendFormatted((config != null) ? config.GetValueOrDefault().TriggerType : null);
					appendInterpolatedStringHandler.AppendFormatted(Enum.IsDefined(typeof(ETriggerEvent), (config != null) ? config.GetValueOrDefault().TriggerType : null) ? "" : "(非法类型)");
					stringBuilder5.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder6 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(6, 1, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("触发时机: ");
					appendInterpolatedStringHandler.AppendFormatted((trigger != null) ? trigger.GetDebugTriggerType() : null);
					stringBuilder6.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder7 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(6, 1, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("条件公式: ");
					appendInterpolatedStringHandler.AppendFormatted((trigger != null) ? trigger.GetDebugFormulaString() : null);
					stringBuilder7.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder8 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(6, 1, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("执行类型: ");
					appendInterpolatedStringHandler.AppendFormatted(((EExecuteType)((config != null) ? new int?(config.GetValueOrDefault().ExecuteType) : null).Value).ToString());
					stringBuilder8.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder.AppendLine("触发行为:");
					foreach (SkillActionData act2 in skill.Actions)
					{
						SkillActionData act = act2;
						switch (act.Action)
						{
						case ESkillAction.AddBullet:
						{
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder9 = stringBuilder2;
							appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
							appendInterpolatedStringHandler.AppendLiteral("    添加子弹 ");
							appendInterpolatedStringHandler.AppendFormatted(string.Join('、', act.BulletRowNames));
							stringBuilder9.AppendLine(ref appendInterpolatedStringHandler);
							break;
						}
						case ESkillAction.RemoveBullet:
						{
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder10 = stringBuilder2;
							appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
							appendInterpolatedStringHandler.AppendLiteral("    移除子弹 ");
							appendInterpolatedStringHandler.AppendFormatted(string.Join<string>('、', act.BulletRowNames.Select((string v, int index) => v + ((act.SummonChild != null && act.SummonChild.Length > index && act.SummonChild[index]) ? "创建子子弹" : "不创建子子弹"))));
							stringBuilder10.AppendLine(ref appendInterpolatedStringHandler);
							break;
						}
						case ESkillAction.AddBuff:
						{
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder11 = stringBuilder2;
							appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder2);
							appendInterpolatedStringHandler.AppendLiteral("    添加Buff ");
							appendInterpolatedStringHandler.AppendFormatted(string.Join<long>('、', act.BuffId));
							stringBuilder11.AppendLine(ref appendInterpolatedStringHandler);
							break;
						}
						case ESkillAction.RemoveBuff:
						{
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder12 = stringBuilder2;
							appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder2);
							appendInterpolatedStringHandler.AppendLiteral("    移除Buff ");
							appendInterpolatedStringHandler.AppendFormatted(string.Join<string>('、', act.BuffId.Select(delegate(long v, int i)
							{
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
								defaultInterpolatedStringHandler.AppendFormatted<long>(v);
								string value3;
								if (act.StackCount == null || act.StackCount.Length <= i || act.StackCount[i] <= 0)
								{
									value3 = "";
								}
								else
								{
									DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(5, 1);
									defaultInterpolatedStringHandler2.AppendLiteral("(移除");
									defaultInterpolatedStringHandler2.AppendFormatted<int>(act.StackCount[i]);
									defaultInterpolatedStringHandler2.AppendLiteral("层)");
									value3 = defaultInterpolatedStringHandler2.ToStringAndClear();
								}
								defaultInterpolatedStringHandler.AppendFormatted(value3);
								return defaultInterpolatedStringHandler.ToStringAndClear();
							})));
							stringBuilder12.AppendLine(ref appendInterpolatedStringHandler);
							break;
						}
						case ESkillAction.StartSkill:
						{
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder13 = stringBuilder2;
							appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder2);
							appendInterpolatedStringHandler.AppendLiteral("    触发主动技能 ");
							appendInterpolatedStringHandler.AppendFormatted<int>(act.SkillId);
							stringBuilder13.AppendLine(ref appendInterpolatedStringHandler);
							break;
						}
						case ESkillAction.LockOn:
						{
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder14 = stringBuilder2;
							appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 5, stringBuilder2);
							appendInterpolatedStringHandler.AppendLiteral("    锁定目标 ");
							appendInterpolatedStringHandler.AppendFormatted<bool>(act.IsHardLock);
							appendInterpolatedStringHandler.AppendLiteral(" ");
							appendInterpolatedStringHandler.AppendFormatted<int>(act.LockOnConfigId);
							appendInterpolatedStringHandler.AppendLiteral(" ");
							appendInterpolatedStringHandler.AppendFormatted<ESkillTargetPriority>(act.SkillTargetPriority);
							appendInterpolatedStringHandler.AppendLiteral(" ");
							appendInterpolatedStringHandler.AppendFormatted<bool>(act.ShowTarget);
							appendInterpolatedStringHandler.AppendLiteral(" ");
							appendInterpolatedStringHandler.AppendFormatted<bool>(act.GlobalTarget);
							stringBuilder14.AppendLine(ref appendInterpolatedStringHandler);
							break;
						}
						case ESkillAction.Customize:
						{
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder15 = stringBuilder2;
							appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder2);
							appendInterpolatedStringHandler.AppendLiteral("    自定义行为 ");
							Formula formula = act.Formula;
							appendInterpolatedStringHandler.AppendFormatted((formula != null) ? formula.FormulaStr : null);
							appendInterpolatedStringHandler.AppendLiteral(" ");
							stringBuilder15.AppendLine(ref appendInterpolatedStringHandler);
							break;
						}
						case ESkillAction.ReduceSkillCd:
						{
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder16 = stringBuilder2;
							appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder2);
							appendInterpolatedStringHandler.AppendLiteral("    减少技能CD ");
							appendInterpolatedStringHandler.AppendFormatted(string.Join<string>('、', act.ReduceSkillId.Select(delegate(long v, int i)
							{
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 4);
								defaultInterpolatedStringHandler.AppendFormatted<long>(v);
								defaultInterpolatedStringHandler.AppendFormatted((act.CdResetType != null && act.CdResetType.Length > i) ? act.CdResetType[i].ToString() : "");
								string value3;
								if (act.DecreaseRatio == null || act.DecreaseRatio.Length <= i)
								{
									value3 = "";
								}
								else
								{
									DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(2, 1);
									defaultInterpolatedStringHandler2.AppendLiteral("(");
									defaultInterpolatedStringHandler2.AppendFormatted<float>(act.DecreaseRatio[i]);
									defaultInterpolatedStringHandler2.AppendLiteral(")");
									value3 = defaultInterpolatedStringHandler2.ToStringAndClear();
								}
								defaultInterpolatedStringHandler.AppendFormatted(value3);
								string value4;
								if (act.DecreaseMagnitude == null || act.DecreaseMagnitude.Length <= i)
								{
									value4 = "";
								}
								else
								{
									DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(2, 1);
									defaultInterpolatedStringHandler2.AppendLiteral("(");
									defaultInterpolatedStringHandler2.AppendFormatted<float>(act.DecreaseMagnitude[i]);
									defaultInterpolatedStringHandler2.AppendLiteral(")");
									value4 = defaultInterpolatedStringHandler2.ToStringAndClear();
								}
								defaultInterpolatedStringHandler.AppendFormatted(value4);
								return defaultInterpolatedStringHandler.ToStringAndClear();
							})));
							stringBuilder16.AppendLine(ref appendInterpolatedStringHandler);
							break;
						}
						default:
							stringBuilder.AppendLine("    未知行为");
							break;
						}
					}
					string text = ((trigger != null) ? trigger.GetLastFormulaResult() : null) ?? "";
					if (!string.IsNullOrEmpty(text))
					{
						stringBuilder.AppendLine("最后触发结果:");
						stringBuilder.AppendLine(string.Join("\n", from s in text.Trim().Split('\n', StringSplitOptions.None)
						select "    " + s));
					}
					stringBuilder.AppendLine();
					stringBuilder.AppendLine();
				}
			}
		}
		CharacterGasDebugComponent component4 = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		string text2;
		if (component4 == null)
		{
			text2 = null;
		}
		else
		{
			EntityBattleInfoResponse serverDebugInfo = component4.ServerDebugInfo;
			text2 = ((serverDebugInfo != null) ? serverDebugInfo.EntityPassiveSkillInfo : null);
		}
		string text3 = text2;
		if (!string.IsNullOrEmpty(text3))
		{
			if (list.Count == 0)
			{
				stringBuilder.AppendLine("----- 服务端被动技能 -----");
				stringBuilder.Append(text3);
			}
			else
			{
				foreach (KeyValuePair<string, string> keyValuePair in CombatDebugBlueprintFunctionLibrary.ServerSkillMap(text3))
				{
					string skillId = keyValuePair.Key;
					string value2 = keyValuePair.Value;
					if (list.Any((string key) => skillId.StartsWith(key)))
					{
						stringBuilder.Append(value2);
					}
				}
			}
		}
		return stringBuilder.ToString().Trim();
	}

	// Token: 0x0601C10A RID: 114954 RVA: 0x0085EECC File Offset: 0x0085D0CC
	[NullableContext(1)]
	protected static bool IsRegexFuzzyMatch(string str, string pattern)
	{
		string pattern2 = string.Join<char>(".*", pattern.ToCharArray());
		return Regex.IsMatch(str, pattern2);
	}

	// Token: 0x0601C10B RID: 114955 RVA: 0x0085EEF4 File Offset: 0x0085D0F4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetTagsDebugString(int entityId, string filterStr = "")
	{
		List<string> list = (from name in filterStr.Split(new char[]
		{
			',',
			'，'
		}, StringSplitOptions.RemoveEmptyEntries)
		select name.Trim()).ToList<string>();
		BaseTagComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseTagComponent>(entityId);
		TagContainer tagContainer = (component != null) ? component.TagContainer : null;
		CharacterGasDebugComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component2 == null || tagContainer == null)
		{
			return "";
		}
		RepeatedField<EntityBattleTagInfo> repeatedField;
		if (component2 == null)
		{
			repeatedField = null;
		}
		else
		{
			EntityBattleInfoResponse serverDebugInfo = component2.ServerDebugInfo;
			repeatedField = ((serverDebugInfo != null) ? serverDebugInfo.EntityBattleTagInfo : null);
		}
		RepeatedField<EntityBattleTagInfo> repeatedField2 = repeatedField;
		RepeatedField<EntityBattleTagInfo> repeatedField3;
		if (component2 == null)
		{
			repeatedField3 = null;
		}
		else
		{
			EntityBattleInfoResponse serverDebugInfo2 = component2.ServerDebugInfo;
			repeatedField3 = ((serverDebugInfo2 != null) ? serverDebugInfo2.PlayerTagInfos : null);
		}
		RepeatedField<EntityBattleTagInfo> repeatedField4 = repeatedField3;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		Dictionary<string, Dictionary<int, int>> dictionary2 = new Dictionary<string, Dictionary<int, int>>
		{
			{
				"实体",
				new Dictionary<int, int>()
			},
			{
				"编队",
				new Dictionary<int, int>()
			}
		};
		if (repeatedField2 != null)
		{
			Dictionary<int, int> dictionary3 = dictionary2["实体"];
			foreach (EntityBattleTagInfo entityBattleTagInfo in repeatedField2)
			{
				if (dictionary.ContainsKey(entityBattleTagInfo.TagId))
				{
					Dictionary<int, int> dictionary4 = dictionary;
					int tagId = entityBattleTagInfo.TagId;
					dictionary4[tagId] += entityBattleTagInfo.Count;
				}
				else
				{
					dictionary[entityBattleTagInfo.TagId] = entityBattleTagInfo.Count;
				}
				dictionary3[entityBattleTagInfo.TagId] = entityBattleTagInfo.Count;
			}
		}
		if (repeatedField4 != null)
		{
			Dictionary<int, int> dictionary5 = dictionary2["编队"];
			foreach (EntityBattleTagInfo entityBattleTagInfo2 in repeatedField4)
			{
				if (dictionary.ContainsKey(entityBattleTagInfo2.TagId))
				{
					Dictionary<int, int> dictionary4 = dictionary;
					int tagId = entityBattleTagInfo2.TagId;
					dictionary4[tagId] += entityBattleTagInfo2.Count;
				}
				else
				{
					dictionary[entityBattleTagInfo2.TagId] = entityBattleTagInfo2.Count;
				}
				dictionary5[entityBattleTagInfo2.TagId] = entityBattleTagInfo2.Count;
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("【客户端】");
		foreach (int tagId2 in tagContainer.GetAllExactTags())
		{
			string tagName = GameplayTagUtils.GetNameByTagId(tagId2);
			if (string.IsNullOrEmpty(tagName) || list.Count <= 0 || list.Any((string key) => CombatDebugBlueprintFunctionLibrary.IsRegexFuzzyMatch(tagName, key)))
			{
				int exactTagCount = tagContainer.GetExactTagCount(tagId2);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
				defaultInterpolatedStringHandler.AppendFormatted(GameplayTagUtils.GetNameByTagId(tagId2));
				defaultInterpolatedStringHandler.AppendLiteral(" x ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(exactTagCount);
				defaultInterpolatedStringHandler.AppendLiteral("(");
				StringBuilder stringBuilder2 = new StringBuilder(defaultInterpolatedStringHandler.ToStringAndClear());
				foreach (ETagChannel etagChannel in tagContainer.GetAllChannels())
				{
					int rawTagCount = tagContainer.GetRawTagCount(etagChannel, tagId2);
					if (rawTagCount > 0)
					{
						StringBuilder stringBuilder3 = stringBuilder2;
						StringBuilder stringBuilder4 = stringBuilder3;
						StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, stringBuilder3);
						appendInterpolatedStringHandler.AppendFormatted(TagContainer.channelDebugName[etagChannel]);
						appendInterpolatedStringHandler.AppendLiteral(" x ");
						appendInterpolatedStringHandler.AppendFormatted<int>(rawTagCount);
						appendInterpolatedStringHandler.AppendLiteral(" ");
						stringBuilder4.Append(ref appendInterpolatedStringHandler);
					}
				}
				stringBuilder.AppendLine(stringBuilder2.ToString().TrimEnd() + ")");
			}
		}
		stringBuilder.AppendLine("");
		stringBuilder.AppendLine("【服务端】");
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int key3 = keyValuePair.Key;
			int value = keyValuePair.Value;
			string tagName = GameplayTagUtils.GetNameByTagId(key3);
			if (string.IsNullOrEmpty(tagName) || list.Count <= 0 || list.Any((string key) => CombatDebugBlueprintFunctionLibrary.IsRegexFuzzyMatch(tagName, key)))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
				defaultInterpolatedStringHandler.AppendFormatted(GameplayTagUtils.GetNameByTagId(key3));
				defaultInterpolatedStringHandler.AppendLiteral(" x ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				defaultInterpolatedStringHandler.AppendLiteral("(");
				StringBuilder stringBuilder5 = new StringBuilder(defaultInterpolatedStringHandler.ToStringAndClear());
				foreach (KeyValuePair<string, Dictionary<int, int>> keyValuePair2 in dictionary2)
				{
					string key2 = keyValuePair2.Key;
					int num;
					if (keyValuePair2.Value.TryGetValue(key3, out num) && num > 0)
					{
						StringBuilder stringBuilder3 = stringBuilder5;
						StringBuilder stringBuilder6 = stringBuilder3;
						StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, stringBuilder3);
						appendInterpolatedStringHandler.AppendFormatted(key2);
						appendInterpolatedStringHandler.AppendLiteral(" x ");
						appendInterpolatedStringHandler.AppendFormatted<int>(num);
						appendInterpolatedStringHandler.AppendLiteral(" ");
						stringBuilder6.Append(ref appendInterpolatedStringHandler);
					}
				}
				stringBuilder.AppendLine(stringBuilder5.ToString().TrimEnd() + ")");
			}
		}
		return stringBuilder.ToString().Trim();
	}

	// Token: 0x0601C10C RID: 114956 RVA: 0x0085F4DC File Offset: 0x0085D6DC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetCueDebugString(int entityId, string filterStr = "")
	{
		BaseGameplayCueComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseGameplayCueComponent>(entityId);
		if (component == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("实体Cue:");
		List<string> list = new List<string>();
		foreach (object obj in Regex.Matches(filterStr, "[0-9]+"))
		{
			list.Add(obj.ToString());
		}
		using (IEnumerator<GameplayCueBase> enumerator2 = component.GetAllCurrentCueRef().GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				GameplayCueBase cue = enumerator2.Current;
				if (list.Count <= 0 || list.Any((string key) => cue.CueConfig.Id.ToString().Contains(key)))
				{
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder3 = stringBuilder2;
					StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(42, 4, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("CueId: ");
					appendInterpolatedStringHandler.AppendFormatted<long>(cue.CueConfig.Id);
					appendInterpolatedStringHandler.AppendLiteral(" CueHandleId: [");
					appendInterpolatedStringHandler.AppendFormatted(string.Join<long>(", ", cue.CueHandleIds));
					appendInterpolatedStringHandler.AppendLiteral("] CueType: ");
					appendInterpolatedStringHandler.AppendFormatted<int>(cue.CueConfig.CueType);
					appendInterpolatedStringHandler.AppendLiteral(" BuffId: ");
					appendInterpolatedStringHandler.AppendFormatted<long?>(cue.BuffId);
					stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
				}
			}
		}
		if (!ModelBase<SceneTeamModel>.Instance.GetTeamEntities(false).Any((EntityHandle handle) => handle.Id == entityId))
		{
			return stringBuilder.ToString();
		}
		stringBuilder.AppendLine("\n编队Cue:");
		WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(ModelBase<CreatureModel>.Instance.GetPlayerId());
		PlayerGameplayCueComponent playerGameplayCueComponent = (playerEntity != null) ? playerEntity.GetComponent<PlayerGameplayCueComponent>() : null;
		if (playerGameplayCueComponent == null)
		{
			return stringBuilder.ToString();
		}
		using (IEnumerator<GameplayCueBase> enumerator2 = playerGameplayCueComponent.GetAllCurrentCueRef().GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				GameplayCueBase cue = enumerator2.Current;
				if (list.Count <= 0 || list.Any((string key) => cue.CueConfig.Id.ToString().Contains(key)))
				{
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder4 = stringBuilder2;
					StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(42, 4, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("CueId: ");
					appendInterpolatedStringHandler.AppendFormatted<long>(cue.CueConfig.Id);
					appendInterpolatedStringHandler.AppendLiteral(" CueHandleId: [");
					appendInterpolatedStringHandler.AppendFormatted(string.Join<long>(", ", cue.CueHandleIds));
					appendInterpolatedStringHandler.AppendLiteral("] CueType: ");
					appendInterpolatedStringHandler.AppendFormatted<int>(cue.CueConfig.CueType);
					appendInterpolatedStringHandler.AppendLiteral(" BuffId: ");
					appendInterpolatedStringHandler.AppendFormatted<long?>(cue.BuffId);
					stringBuilder4.AppendLine(ref appendInterpolatedStringHandler);
				}
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0601C10D RID: 114957 RVA: 0x0085F818 File Offset: 0x0085DA18
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static UDataTable LoadDataTable(string assetPath)
	{
		if (!Singleton<Info>.Instance.IsPlayInEditor)
		{
			return null;
		}
		return Singleton<ResourceSystem>.Instance.Load<UDataTable>(assetPath, "Debug");
	}

	// Token: 0x0601C10E RID: 114958 RVA: 0x0085F838 File Offset: 0x0085DA38
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void GetDebugStateMachine(int entityId, ref TArray<FText> output)
	{
		CharacterStateMachineNewComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterStateMachineNewComponent>(entityId);
		AiStateMachineGroup aiStateMachineGroup = (component != null) ? component.StateMachineGroup : null;
		if (aiStateMachineGroup == null)
		{
			output.Add("无角色状态机组件");
			output.Add("");
			return;
		}
		aiStateMachineGroup.RequestServerDebugInfo();
		string[] array = aiStateMachineGroup.ToString(false, false);
		if (array != null)
		{
			foreach (string @string in array)
			{
				output.Add(@string);
			}
		}
	}

	// Token: 0x0601C10F RID: 114959 RVA: 0x0085F8B8 File Offset: 0x0085DAB8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetSkillDebugString(int entityId)
	{
		StringBuilder stringBuilder = new StringBuilder();
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component == null)
		{
			return stringBuilder.ToString();
		}
		CreatureDataComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CreatureDataComponent>(entityId);
		bool flag = component2 != null && component2.IsVehicle();
		CharacterSkillCdComponent characterSkillCdComponent = flag ? null : Singleton<EntitySystem>.Instance.GetComponent<CharacterSkillCdComponent>(entityId);
		bool flag2 = false;
		foreach (global::Skill skill in component.GetAllActivatedSkill())
		{
			flag2 = true;
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(27, 5, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("#");
			appendInterpolatedStringHandler.AppendFormatted<int>(skill.SkillId);
			appendInterpolatedStringHandler.AppendLiteral(" ");
			appendInterpolatedStringHandler.AppendFormatted(skill.SkillName);
			appendInterpolatedStringHandler.AppendLiteral(" | 技能组: ");
			appendInterpolatedStringHandler.AppendFormatted<int>(skill.SkillInfo.GroupId);
			appendInterpolatedStringHandler.AppendLiteral(" | 打断等级: ");
			appendInterpolatedStringHandler.AppendFormatted<int>(skill.InterruptLevel);
			appendInterpolatedStringHandler.AppendLiteral(" | CD: ");
			string text;
			if (characterSkillCdComponent == null)
			{
				text = null;
			}
			else
			{
				GroupSkillCdInfo groupSkillCdInfo = characterSkillCdComponent.GetGroupSkillCdInfo(skill.SkillId);
				text = ((groupSkillCdInfo != null) ? groupSkillCdInfo.CurRemainingCd.ToString("0.00") : null);
			}
			appendInterpolatedStringHandler.AppendFormatted(text ?? "0");
			appendInterpolatedStringHandler.AppendLiteral("s");
			stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
		}
		if (flag2)
		{
			stringBuilder.AppendLine();
		}
		CharacterAnimationComponent characterAnimationComponent = flag ? null : Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		VehicleAnimationComponent vehicleAnimationComponent = flag ? Singleton<EntitySystem>.Instance.GetComponent<VehicleAnimationComponent>(entityId) : null;
		UAnimInstance uanimInstance = ((characterAnimationComponent != null) ? characterAnimationComponent.MainAnimInstance : null) ?? ((vehicleAnimationComponent != null) ? vehicleAnimationComponent.MainAnimInstance : null);
		UAnimMontage uanimMontage = (uanimInstance != null) ? uanimInstance.GetCurrentActiveMontage() : null;
		if (uanimInstance != null && uanimInstance.IsAnyMontagePlaying() && uanimMontage != null)
		{
			string name = uanimMontage.GetName();
			string value = uanimInstance.Montage_GetCurrentSection(uanimMontage).ToString();
			float value2 = uanimInstance.Montage_GetPosition(uanimMontage);
			float playLength = uanimMontage.GetPlayLength();
			float value3 = uanimInstance.Montage_GetPlayRate(uanimMontage);
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder4 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(40, 5, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("Montage: ");
			appendInterpolatedStringHandler.AppendFormatted(name);
			appendInterpolatedStringHandler.AppendLiteral(" | Section: ");
			appendInterpolatedStringHandler.AppendFormatted(value);
			appendInterpolatedStringHandler.AppendLiteral(" | Time: ");
			appendInterpolatedStringHandler.AppendFormatted<float>(value2, "0.00");
			appendInterpolatedStringHandler.AppendLiteral("/");
			appendInterpolatedStringHandler.AppendFormatted<float>(playLength, "0.00");
			appendInterpolatedStringHandler.AppendLiteral(" | Rate: ");
			appendInterpolatedStringHandler.AppendFormatted<float>(value3, "0.00");
			stringBuilder4.Append(ref appendInterpolatedStringHandler);
		}
		else
		{
			string value4 = (uanimInstance != null) ? uanimInstance.GetMainAnimsDebugText() : null;
			stringBuilder.Append(value4);
		}
		TArray<FAnimNotifyEvent> tarray = (uanimInstance != null) ? uanimInstance.ActiveAnimNotifyState : null;
		if (tarray != null && tarray.Num() > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.AppendLine();
			for (int i = 0; i < tarray.Num(); i++)
			{
				UKuroAnimNotifyState ukuroAnimNotifyState = tarray.Get(i).NotifyStateClass as UKuroAnimNotifyState;
				if (ukuroAnimNotifyState != null)
				{
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder5 = stringBuilder2;
					StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(14, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("exportIndex:");
					appendInterpolatedStringHandler.AppendFormatted<int>(ukuroAnimNotifyState.exportIndex);
					appendInterpolatedStringHandler.AppendLiteral("--");
					appendInterpolatedStringHandler.AppendFormatted(ukuroAnimNotifyState.GetNotifyName());
					stringBuilder5.AppendLine(ref appendInterpolatedStringHandler);
				}
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0601C110 RID: 114960 RVA: 0x0085FC50 File Offset: 0x0085DE50
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetSkillLogString(int entityId, string filterStr = "")
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component == null)
		{
			return "";
		}
		return component.GetSkillLogString(filterStr);
	}

	// Token: 0x0601C111 RID: 114961 RVA: 0x0085FC7C File Offset: 0x0085DE7C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ClearSkillLogString(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component != null)
		{
			component.ClearSkillLogString();
		}
	}

	// Token: 0x0601C112 RID: 114962 RVA: 0x0085FCA0 File Offset: 0x0085DEA0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetSkillBehaviorLogString(int entityId, string filterStr = "")
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component == null)
		{
			return "";
		}
		return component.GetSkillBehaviorLogString(filterStr);
	}

	// Token: 0x0601C113 RID: 114963 RVA: 0x0085FCCC File Offset: 0x0085DECC
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ClearSkillBehaviorLogString(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component != null)
		{
			component.ClearSkillBehaviorLogString();
		}
	}

	// Token: 0x0601C114 RID: 114964 RVA: 0x0085FCF0 File Offset: 0x0085DEF0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetBulletDebugString(int entityId)
	{
		BulletModel instance = ModelBase<BulletModel>.Instance;
		IReadOnlyCollection<BulletEntity> readOnlyCollection = (instance != null) ? instance.GetBulletSetByAttacker(entityId) : null;
		if (readOnlyCollection == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (BulletEntity bulletEntity in readOnlyCollection)
		{
			BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(32, 4, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("#RowName:");
			appendInterpolatedStringHandler.AppendFormatted(bulletInfo.BulletRowName);
			appendInterpolatedStringHandler.AppendLiteral(", EntityId:");
			appendInterpolatedStringHandler.AppendFormatted<int>(bulletEntity.Id);
			appendInterpolatedStringHandler.AppendLiteral(", LiveTime:");
			appendInterpolatedStringHandler.AppendFormatted<float>(bulletInfo.LiveTime);
			appendInterpolatedStringHandler.AppendLiteral("/");
			appendInterpolatedStringHandler.AppendFormatted<float>(bulletInfo.Duration);
			stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0601C115 RID: 114965 RVA: 0x0085FDE8 File Offset: 0x0085DFE8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetBulletLogString(int entityId, string filterStr = "")
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return "";
		}
		return component.GetBulletLogString(filterStr);
	}

	// Token: 0x0601C116 RID: 114966 RVA: 0x0085FE1C File Offset: 0x0085E01C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ClearBulletLogString(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.ClearBulletLogString();
		}
	}

	// Token: 0x0601C117 RID: 114967 RVA: 0x0085FE48 File Offset: 0x0085E048
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetEntityDebugMove(int entityId, bool enable)
	{
		ActorDebugMovementComponent component = Singleton<EntitySystem>.Instance.GetComponent<ActorDebugMovementComponent>(entityId);
		if (component != null)
		{
			component.SetDebug(enable);
		}
	}

	// Token: 0x0601C118 RID: 114968 RVA: 0x0085FE6B File Offset: 0x0085E06B
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (CombatDebugBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Utils/CombatDebugBlueprintFunctionLibrary.CombatDebugBlueprintFunctionLibrary_C");
		}
		return CombatDebugBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x0601C119 RID: 114969 RVA: 0x0085FE90 File Offset: 0x0085E090
	public CombatDebugBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(CombatDebugBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601C11A RID: 114970 RVA: 0x0085FEB8 File Offset: 0x0085E0B8
	[NullableContext(1)]
	public CombatDebugBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CombatDebugBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601C11B RID: 114971 RVA: 0x0085FEEB File Offset: 0x0085E0EB
	protected CombatDebugBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601C11C RID: 114972 RVA: 0x0085FEF4 File Offset: 0x0085E0F4
	protected unsafe static void __CPPCALL_AddPassiveSkillForDebug_Implementation(CombatDebugBlueprintFunctionLibrary.__AddPassiveSkillForDebug_FunctionParams* __Params)
	{
		CombatDebugBlueprintFunctionLibrary.AddPassiveSkillForDebug(__Params->entityId, __Params->passiveSkillId);
	}

	// Token: 0x0601C11D RID: 114973 RVA: 0x0085FF07 File Offset: 0x0085E107
	protected unsafe static void __CPPCALL_RemovePassiveSkillForDebug_Implementation(CombatDebugBlueprintFunctionLibrary.__RemovePassiveSkillForDebug_FunctionParams* __Params)
	{
		CombatDebugBlueprintFunctionLibrary.RemovePassiveSkillForDebug(__Params->entityId, __Params->passiveSkillId);
	}

	// Token: 0x0601C11E RID: 114974 RVA: 0x0085FF1A File Offset: 0x0085E11A
	protected unsafe static void __CPPCALL_GetDebugMonsterMovePath_Implementation(CombatDebugBlueprintFunctionLibrary.__GetDebugMonsterMovePath_FunctionParams* __Params)
	{
		__Params->__Result = CombatDebugBlueprintFunctionLibrary.GetDebugMonsterMovePath();
	}

	// Token: 0x0601C11F RID: 114975 RVA: 0x0085FF27 File Offset: 0x0085E127
	protected unsafe static void __CPPCALL_SetDebugMonsterMovePath_Implementation(CombatDebugBlueprintFunctionLibrary.__SetDebugMonsterMovePath_FunctionParams* __Params)
	{
		CombatDebugBlueprintFunctionLibrary.SetDebugMonsterMovePath(__Params->value);
	}

	// Token: 0x0601C120 RID: 114976 RVA: 0x0085FF34 File Offset: 0x0085E134
	protected unsafe static void __CPPCALL_GetDebugMonsterControl_Implementation(CombatDebugBlueprintFunctionLibrary.__GetDebugMonsterControl_FunctionParams* __Params)
	{
		__Params->__Result = CombatDebugBlueprintFunctionLibrary.GetDebugMonsterControl();
	}

	// Token: 0x0601C121 RID: 114977 RVA: 0x0085FF41 File Offset: 0x0085E141
	protected unsafe static void __CPPCALL_SetDebugMonsterControl_Implementation(CombatDebugBlueprintFunctionLibrary.__SetDebugMonsterControl_FunctionParams* __Params)
	{
		CombatDebugBlueprintFunctionLibrary.SetDebugMonsterControl(__Params->value);
	}

	// Token: 0x0601C122 RID: 114978 RVA: 0x0085FF4E File Offset: 0x0085E14E
	protected unsafe static void __CPPCALL_OpenMonsterServerLogic_Implementation(CombatDebugBlueprintFunctionLibrary.__OpenMonsterServerLogic_FunctionParams* __Params)
	{
		CombatDebugBlueprintFunctionLibrary.OpenMonsterServerLogic(__Params->value);
	}

	// Token: 0x0601C123 RID: 114979 RVA: 0x0085FF5B File Offset: 0x0085E15B
	protected unsafe static void __CPPCALL_IsDrawEntityBoxEnabled_Implementation(CombatDebugBlueprintFunctionLibrary.__IsDrawEntityBoxEnabled_FunctionParams* __Params)
	{
		__Params->__Result = CombatDebugBlueprintFunctionLibrary.IsDrawEntityBoxEnabled();
	}

	// Token: 0x0601C124 RID: 114980 RVA: 0x0085FF68 File Offset: 0x0085E168
	protected unsafe static void __CPPCALL_SetDrawEntityBoxEnabled_Implementation(CombatDebugBlueprintFunctionLibrary.__SetDrawEntityBoxEnabled_FunctionParams* __Params)
	{
		CombatDebugBlueprintFunctionLibrary.SetDrawEntityBoxEnabled(__Params->isEnable);
	}

	// Token: 0x0601C125 RID: 114981 RVA: 0x0085FF75 File Offset: 0x0085E175
	protected unsafe static void __CPPCALL_IsDrawEntityBoxInfoEnabled_Implementation(CombatDebugBlueprintFunctionLibrary.__IsDrawEntityBoxInfoEnabled_FunctionParams* __Params)
	{
		__Params->__Result = CombatDebugBlueprintFunctionLibrary.IsDrawEntityBoxInfoEnabled();
	}

	// Token: 0x0601C126 RID: 114982 RVA: 0x0085FF82 File Offset: 0x0085E182
	protected unsafe static void __CPPCALL_SetDrawEntityBoxInfoEnabled_Implementation(CombatDebugBlueprintFunctionLibrary.__SetDrawEntityBoxInfoEnabled_FunctionParams* __Params)
	{
		CombatDebugBlueprintFunctionLibrary.SetDrawEntityBoxInfoEnabled(__Params->isEnable);
	}

	// Token: 0x0601C127 RID: 114983 RVA: 0x0085FF90 File Offset: 0x0085E190
	protected unsafe static void __CPPCALL_GetCombatScriptIndexes_Implementation(CombatDebugBlueprintFunctionLibrary.__GetCombatScriptIndexes_FunctionParams* __Params)
	{
		TArray<string> combatScriptIndexes = CombatDebugBlueprintFunctionLibrary.GetCombatScriptIndexes();
		if (combatScriptIndexes == null)
		{
			return;
		}
		combatScriptIndexes.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x0601C128 RID: 114984 RVA: 0x0085FFBC File Offset: 0x0085E1BC
	protected unsafe static void __CPPCALL_FilterScript_Implementation(CombatDebugBlueprintFunctionLibrary.__FilterScript_FunctionParams* __Params)
	{
		string cmd = FString.ToString((void*)(&__Params->cmd));
		FString.CopyFrom((void*)(&__Params->__Result), CombatDebugBlueprintFunctionLibrary.FilterScript(cmd));
	}

	// Token: 0x0601C129 RID: 114985 RVA: 0x0085FFE8 File Offset: 0x0085E1E8
	protected unsafe static void __CPPCALL_IsDebugPrintOpened_Implementation(CombatDebugBlueprintFunctionLibrary.__IsDebugPrintOpened_FunctionParams* __Params)
	{
		string moduleName = FString.ToString((void*)(&__Params->moduleName));
		__Params->__Result = CombatDebugBlueprintFunctionLibrary.IsDebugPrintOpened(moduleName);
	}

	// Token: 0x0601C12A RID: 114986 RVA: 0x0086000E File Offset: 0x0085E20E
	protected unsafe static void __CPPCALL_SetDebugPrintOpened_Implementation(CombatDebugBlueprintFunctionLibrary.__SetDebugPrintOpened_FunctionParams* __Params)
	{
		CombatDebugBlueprintFunctionLibrary.SetDebugPrintOpened(FString.ToString((void*)(&__Params->moduleName)), __Params->isOpen);
	}

	// Token: 0x0601C12B RID: 114987 RVA: 0x00860027 File Offset: 0x0085E227
	protected unsafe static void __CPPCALL_TryRefreshServerDebugInfo_Implementation(CombatDebugBlueprintFunctionLibrary.__TryRefreshServerDebugInfo_FunctionParams* __Params)
	{
		CombatDebugBlueprintFunctionLibrary.TryRefreshServerDebugInfo();
	}

	// Token: 0x0601C12C RID: 114988 RVA: 0x0086002E File Offset: 0x0085E22E
	protected unsafe static void __CPPCALL_GetServerBuffRemainDuration_Implementation(CombatDebugBlueprintFunctionLibrary.__GetServerBuffRemainDuration_FunctionParams* __Params)
	{
		__Params->__Result = CombatDebugBlueprintFunctionLibrary.GetServerBuffRemainDuration(__Params->entityId, __Params->handle);
	}

	// Token: 0x0601C12D RID: 114989 RVA: 0x00860047 File Offset: 0x0085E247
	protected unsafe static void __CPPCALL_GetServerBuffTotalDuration_Implementation(CombatDebugBlueprintFunctionLibrary.__GetServerBuffTotalDuration_FunctionParams* __Params)
	{
		__Params->__Result = CombatDebugBlueprintFunctionLibrary.GetServerBuffTotalDuration(__Params->entityId, __Params->handle);
	}

	// Token: 0x0601C12E RID: 114990 RVA: 0x00860060 File Offset: 0x0085E260
	protected unsafe static void __CPPCALL_GetBuffRemainDuration_Implementation(CombatDebugBlueprintFunctionLibrary.__GetBuffRemainDuration_FunctionParams* __Params)
	{
		__Params->__Result = CombatDebugBlueprintFunctionLibrary.GetBuffRemainDuration(__Params->entityId, __Params->handle);
	}

	// Token: 0x0601C12F RID: 114991 RVA: 0x00860079 File Offset: 0x0085E279
	protected unsafe static void __CPPCALL_GetBuffTotalDuration_Implementation(CombatDebugBlueprintFunctionLibrary.__GetBuffTotalDuration_FunctionParams* __Params)
	{
		__Params->__Result = CombatDebugBlueprintFunctionLibrary.GetBuffTotalDuration(__Params->entityId, __Params->handle);
	}

	// Token: 0x0601C130 RID: 114992 RVA: 0x00860092 File Offset: 0x0085E292
	protected unsafe static void __CPPCALL_HasServerBuff_Implementation(CombatDebugBlueprintFunctionLibrary.__HasServerBuff_FunctionParams* __Params)
	{
		__Params->__Result = CombatDebugBlueprintFunctionLibrary.HasServerBuff(__Params->entityId, __Params->handle);
	}

	// Token: 0x0601C131 RID: 114993 RVA: 0x008600AC File Offset: 0x0085E2AC
	protected unsafe static void __CPPCALL_GetAttributeDebugString_Implementation(CombatDebugBlueprintFunctionLibrary.__GetAttributeDebugString_FunctionParams* __Params)
	{
		string filterStr = FString.ToString((void*)(&__Params->filterStr));
		FString.CopyFrom((void*)(&__Params->__Result), CombatDebugBlueprintFunctionLibrary.GetAttributeDebugString(__Params->entityId, filterStr));
	}

	// Token: 0x0601C132 RID: 114994 RVA: 0x008600E0 File Offset: 0x0085E2E0
	protected unsafe static void __CPPCALL_GetStateAttributeDebugString_Implementation(CombatDebugBlueprintFunctionLibrary.__GetStateAttributeDebugString_FunctionParams* __Params)
	{
		string filterStr = FString.ToString((void*)(&__Params->filterStr));
		FString.CopyFrom((void*)(&__Params->__Result), CombatDebugBlueprintFunctionLibrary.GetStateAttributeDebugString(__Params->entityId, filterStr));
	}

	// Token: 0x0601C133 RID: 114995 RVA: 0x00860114 File Offset: 0x0085E314
	protected unsafe static void __CPPCALL_GetFormationAttributeDebugString_Implementation(CombatDebugBlueprintFunctionLibrary.__GetFormationAttributeDebugString_FunctionParams* __Params)
	{
		string filterStr = FString.ToString((void*)(&__Params->filterStr));
		FString.CopyFrom((void*)(&__Params->__Result), CombatDebugBlueprintFunctionLibrary.GetFormationAttributeDebugString(__Params->entityId, filterStr));
	}

	// Token: 0x0601C134 RID: 114996 RVA: 0x00860148 File Offset: 0x0085E348
	protected unsafe static void __CPPCALL_ExtractInt64ArrayFromString_Implementation(CombatDebugBlueprintFunctionLibrary.__ExtractInt64ArrayFromString_FunctionParams* __Params)
	{
		TArray<long> tarray = CombatDebugBlueprintFunctionLibrary.ExtractInt64ArrayFromString(FString.ToString((void*)(&__Params->content)));
		if (tarray == null)
		{
			return;
		}
		tarray.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x0601C135 RID: 114997 RVA: 0x00860180 File Offset: 0x0085E380
	protected unsafe static void __CPPCALL_ExtractTagNameArrayFromString_Implementation(CombatDebugBlueprintFunctionLibrary.__ExtractTagNameArrayFromString_FunctionParams* __Params)
	{
		TArray<string> tarray = CombatDebugBlueprintFunctionLibrary.ExtractTagNameArrayFromString(FString.ToString((void*)(&__Params->content)));
		if (tarray == null)
		{
			return;
		}
		tarray.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x0601C136 RID: 114998 RVA: 0x008601B8 File Offset: 0x0085E3B8
	protected unsafe static void __CPPCALL_GetPassiveDebugString_Implementation(CombatDebugBlueprintFunctionLibrary.__GetPassiveDebugString_FunctionParams* __Params)
	{
		string filterStr = FString.ToString((void*)(&__Params->filterStr));
		FString.CopyFrom((void*)(&__Params->__Result), CombatDebugBlueprintFunctionLibrary.GetPassiveDebugString(__Params->entityId, filterStr));
	}

	// Token: 0x0601C137 RID: 114999 RVA: 0x008601EC File Offset: 0x0085E3EC
	protected unsafe static void __CPPCALL_GetTagsDebugString_Implementation(CombatDebugBlueprintFunctionLibrary.__GetTagsDebugString_FunctionParams* __Params)
	{
		string filterStr = FString.ToString((void*)(&__Params->filterStr));
		FString.CopyFrom((void*)(&__Params->__Result), CombatDebugBlueprintFunctionLibrary.GetTagsDebugString(__Params->entityId, filterStr));
	}

	// Token: 0x0601C138 RID: 115000 RVA: 0x00860220 File Offset: 0x0085E420
	protected unsafe static void __CPPCALL_GetCueDebugString_Implementation(CombatDebugBlueprintFunctionLibrary.__GetCueDebugString_FunctionParams* __Params)
	{
		string filterStr = FString.ToString((void*)(&__Params->filterStr));
		FString.CopyFrom((void*)(&__Params->__Result), CombatDebugBlueprintFunctionLibrary.GetCueDebugString(__Params->entityId, filterStr));
	}

	// Token: 0x0601C139 RID: 115001 RVA: 0x00860254 File Offset: 0x0085E454
	protected unsafe static void __CPPCALL_LoadDataTable_Implementation(CombatDebugBlueprintFunctionLibrary.__LoadDataTable_FunctionParams* __Params)
	{
		string assetPath = FString.ToString((void*)(&__Params->assetPath));
		ref IntPtr ptr = ref *(&__Params->__Result);
		UDataTable udataTable = CombatDebugBlueprintFunctionLibrary.LoadDataTable(assetPath);
		ptr = ((udataTable != null) ? udataTable.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601C13A RID: 115002 RVA: 0x0086028C File Offset: 0x0085E48C
	protected unsafe static void __CPPCALL_GetDebugStateMachine_Implementation(CombatDebugBlueprintFunctionLibrary.__GetDebugStateMachine_FunctionParams* __Params)
	{
		TArray<FText> tarray = new TArray<FText>(&__Params->output, true, true);
		CombatDebugBlueprintFunctionLibrary.GetDebugStateMachine(__Params->entityId, ref tarray);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->output, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x0601C13B RID: 115003 RVA: 0x008602CE File Offset: 0x0085E4CE
	protected unsafe static void __CPPCALL_GetSkillDebugString_Implementation(CombatDebugBlueprintFunctionLibrary.__GetSkillDebugString_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), CombatDebugBlueprintFunctionLibrary.GetSkillDebugString(__Params->entityId));
	}

	// Token: 0x0601C13C RID: 115004 RVA: 0x008602E8 File Offset: 0x0085E4E8
	protected unsafe static void __CPPCALL_GetSkillLogString_Implementation(CombatDebugBlueprintFunctionLibrary.__GetSkillLogString_FunctionParams* __Params)
	{
		string filterStr = FString.ToString((void*)(&__Params->filterStr));
		FString.CopyFrom((void*)(&__Params->__Result), CombatDebugBlueprintFunctionLibrary.GetSkillLogString(__Params->entityId, filterStr));
	}

	// Token: 0x0601C13D RID: 115005 RVA: 0x0086031A File Offset: 0x0085E51A
	protected unsafe static void __CPPCALL_ClearSkillLogString_Implementation(CombatDebugBlueprintFunctionLibrary.__ClearSkillLogString_FunctionParams* __Params)
	{
		CombatDebugBlueprintFunctionLibrary.ClearSkillLogString(__Params->entityId);
	}

	// Token: 0x0601C13E RID: 115006 RVA: 0x00860328 File Offset: 0x0085E528
	protected unsafe static void __CPPCALL_GetSkillBehaviorLogString_Implementation(CombatDebugBlueprintFunctionLibrary.__GetSkillBehaviorLogString_FunctionParams* __Params)
	{
		string filterStr = FString.ToString((void*)(&__Params->filterStr));
		FString.CopyFrom((void*)(&__Params->__Result), CombatDebugBlueprintFunctionLibrary.GetSkillBehaviorLogString(__Params->entityId, filterStr));
	}

	// Token: 0x0601C13F RID: 115007 RVA: 0x0086035A File Offset: 0x0085E55A
	protected unsafe static void __CPPCALL_ClearSkillBehaviorLogString_Implementation(CombatDebugBlueprintFunctionLibrary.__ClearSkillBehaviorLogString_FunctionParams* __Params)
	{
		CombatDebugBlueprintFunctionLibrary.ClearSkillBehaviorLogString(__Params->entityId);
	}

	// Token: 0x0601C140 RID: 115008 RVA: 0x00860367 File Offset: 0x0085E567
	protected unsafe static void __CPPCALL_GetBulletDebugString_Implementation(CombatDebugBlueprintFunctionLibrary.__GetBulletDebugString_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), CombatDebugBlueprintFunctionLibrary.GetBulletDebugString(__Params->entityId));
	}

	// Token: 0x0601C141 RID: 115009 RVA: 0x00860380 File Offset: 0x0085E580
	protected unsafe static void __CPPCALL_GetBulletLogString_Implementation(CombatDebugBlueprintFunctionLibrary.__GetBulletLogString_FunctionParams* __Params)
	{
		string filterStr = FString.ToString((void*)(&__Params->filterStr));
		FString.CopyFrom((void*)(&__Params->__Result), CombatDebugBlueprintFunctionLibrary.GetBulletLogString(__Params->entityId, filterStr));
	}

	// Token: 0x0601C142 RID: 115010 RVA: 0x008603B2 File Offset: 0x0085E5B2
	protected unsafe static void __CPPCALL_ClearBulletLogString_Implementation(CombatDebugBlueprintFunctionLibrary.__ClearBulletLogString_FunctionParams* __Params)
	{
		CombatDebugBlueprintFunctionLibrary.ClearBulletLogString(__Params->entityId);
	}

	// Token: 0x0601C143 RID: 115011 RVA: 0x008603BF File Offset: 0x0085E5BF
	protected unsafe static void __CPPCALL_SetEntityDebugMove_Implementation(CombatDebugBlueprintFunctionLibrary.__SetEntityDebugMove_FunctionParams* __Params)
	{
		CombatDebugBlueprintFunctionLibrary.SetEntityDebugMove(__Params->entityId, __Params->enable);
	}

	// Token: 0x0400E2BC RID: 58044
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Utils/CombatDebugBlueprintFunctionLibrary.CombatDebugBlueprintFunctionLibrary_C";

	// Token: 0x0400E2BD RID: 58045
	private static IntPtr _ClassPtr;

	// Token: 0x0400E2BE RID: 58046
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02009511 RID: 38161
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __AddPassiveSkillForDebug_FunctionParams
	{
		// Token: 0x04031547 RID: 202055
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031548 RID: 202056
		[FieldOffset(8)]
		public long passiveSkillId;

		// Token: 0x04031549 RID: 202057
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009512 RID: 38162
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __RemovePassiveSkillForDebug_FunctionParams
	{
		// Token: 0x0403154A RID: 202058
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403154B RID: 202059
		[FieldOffset(8)]
		public long passiveSkillId;

		// Token: 0x0403154C RID: 202060
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009513 RID: 38163
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetDebugMonsterMovePath_FunctionParams
	{
		// Token: 0x0403154D RID: 202061
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x0403154E RID: 202062
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x02009514 RID: 38164
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetDebugMonsterMovePath_FunctionParams
	{
		// Token: 0x0403154F RID: 202063
		[FieldOffset(0)]
		public bool value;

		// Token: 0x04031550 RID: 202064
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009515 RID: 38165
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetDebugMonsterControl_FunctionParams
	{
		// Token: 0x04031551 RID: 202065
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04031552 RID: 202066
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x02009516 RID: 38166
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetDebugMonsterControl_FunctionParams
	{
		// Token: 0x04031553 RID: 202067
		[FieldOffset(0)]
		public bool value;

		// Token: 0x04031554 RID: 202068
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009517 RID: 38167
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __OpenMonsterServerLogic_FunctionParams
	{
		// Token: 0x04031555 RID: 202069
		[FieldOffset(0)]
		public bool value;

		// Token: 0x04031556 RID: 202070
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009518 RID: 38168
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __IsDrawEntityBoxEnabled_FunctionParams
	{
		// Token: 0x04031557 RID: 202071
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04031558 RID: 202072
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x02009519 RID: 38169
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetDrawEntityBoxEnabled_FunctionParams
	{
		// Token: 0x04031559 RID: 202073
		[FieldOffset(0)]
		public bool isEnable;

		// Token: 0x0403155A RID: 202074
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200951A RID: 38170
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __IsDrawEntityBoxInfoEnabled_FunctionParams
	{
		// Token: 0x0403155B RID: 202075
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x0403155C RID: 202076
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x0200951B RID: 38171
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetDrawEntityBoxInfoEnabled_FunctionParams
	{
		// Token: 0x0403155D RID: 202077
		[FieldOffset(0)]
		public bool isEnable;

		// Token: 0x0403155E RID: 202078
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200951C RID: 38172
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCombatScriptIndexes_FunctionParams
	{
		// Token: 0x0403155F RID: 202079
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04031560 RID: 202080
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x0200951D RID: 38173
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __FilterScript_FunctionParams
	{
		// Token: 0x04031561 RID: 202081
		[FieldOffset(0)]
		public FString cmd;

		// Token: 0x04031562 RID: 202082
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04031563 RID: 202083
		[FieldOffset(24)]
		public FString __Result;
	}

	// Token: 0x0200951E RID: 38174
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __IsDebugPrintOpened_FunctionParams
	{
		// Token: 0x04031564 RID: 202084
		[FieldOffset(0)]
		public FString moduleName;

		// Token: 0x04031565 RID: 202085
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04031566 RID: 202086
		[FieldOffset(24)]
		public bool __Result;
	}

	// Token: 0x0200951F RID: 38175
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SetDebugPrintOpened_FunctionParams
	{
		// Token: 0x04031567 RID: 202087
		[FieldOffset(0)]
		public FString moduleName;

		// Token: 0x04031568 RID: 202088
		[FieldOffset(16)]
		public bool isOpen;

		// Token: 0x04031569 RID: 202089
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009520 RID: 38176
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __TryRefreshServerDebugInfo_FunctionParams
	{
		// Token: 0x0403156A RID: 202090
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009521 RID: 38177
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetServerBuffRemainDuration_FunctionParams
	{
		// Token: 0x0403156B RID: 202091
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403156C RID: 202092
		[FieldOffset(4)]
		public int handle;

		// Token: 0x0403156D RID: 202093
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403156E RID: 202094
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009522 RID: 38178
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetServerBuffTotalDuration_FunctionParams
	{
		// Token: 0x0403156F RID: 202095
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031570 RID: 202096
		[FieldOffset(4)]
		public int handle;

		// Token: 0x04031571 RID: 202097
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04031572 RID: 202098
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009523 RID: 38179
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBuffRemainDuration_FunctionParams
	{
		// Token: 0x04031573 RID: 202099
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031574 RID: 202100
		[FieldOffset(4)]
		public int handle;

		// Token: 0x04031575 RID: 202101
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04031576 RID: 202102
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009524 RID: 38180
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBuffTotalDuration_FunctionParams
	{
		// Token: 0x04031577 RID: 202103
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031578 RID: 202104
		[FieldOffset(4)]
		public int handle;

		// Token: 0x04031579 RID: 202105
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403157A RID: 202106
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009525 RID: 38181
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __HasServerBuff_FunctionParams
	{
		// Token: 0x0403157B RID: 202107
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403157C RID: 202108
		[FieldOffset(4)]
		public int handle;

		// Token: 0x0403157D RID: 202109
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403157E RID: 202110
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009526 RID: 38182
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetAttributeDebugString_FunctionParams
	{
		// Token: 0x0403157F RID: 202111
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031580 RID: 202112
		[FieldOffset(8)]
		public FString filterStr;

		// Token: 0x04031581 RID: 202113
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04031582 RID: 202114
		[FieldOffset(32)]
		public FString __Result;
	}

	// Token: 0x02009527 RID: 38183
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetStateAttributeDebugString_FunctionParams
	{
		// Token: 0x04031583 RID: 202115
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031584 RID: 202116
		[FieldOffset(8)]
		public FString filterStr;

		// Token: 0x04031585 RID: 202117
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04031586 RID: 202118
		[FieldOffset(32)]
		public FString __Result;
	}

	// Token: 0x02009528 RID: 38184
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetFormationAttributeDebugString_FunctionParams
	{
		// Token: 0x04031587 RID: 202119
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031588 RID: 202120
		[FieldOffset(8)]
		public FString filterStr;

		// Token: 0x04031589 RID: 202121
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x0403158A RID: 202122
		[FieldOffset(32)]
		public FString __Result;
	}

	// Token: 0x02009529 RID: 38185
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __ExtractInt64ArrayFromString_FunctionParams
	{
		// Token: 0x0403158B RID: 202123
		[FieldOffset(0)]
		public FString content;

		// Token: 0x0403158C RID: 202124
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x0403158D RID: 202125
		[FieldOffset(24)]
		public byte __Result;
	}

	// Token: 0x0200952A RID: 38186
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __ExtractTagNameArrayFromString_FunctionParams
	{
		// Token: 0x0403158E RID: 202126
		[FieldOffset(0)]
		public FString content;

		// Token: 0x0403158F RID: 202127
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04031590 RID: 202128
		[FieldOffset(24)]
		public byte __Result;
	}

	// Token: 0x0200952B RID: 38187
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetPassiveDebugString_FunctionParams
	{
		// Token: 0x04031591 RID: 202129
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031592 RID: 202130
		[FieldOffset(8)]
		public FString filterStr;

		// Token: 0x04031593 RID: 202131
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04031594 RID: 202132
		[FieldOffset(32)]
		public FString __Result;
	}

	// Token: 0x0200952C RID: 38188
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetTagsDebugString_FunctionParams
	{
		// Token: 0x04031595 RID: 202133
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031596 RID: 202134
		[FieldOffset(8)]
		public FString filterStr;

		// Token: 0x04031597 RID: 202135
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04031598 RID: 202136
		[FieldOffset(32)]
		public FString __Result;
	}

	// Token: 0x0200952D RID: 38189
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetCueDebugString_FunctionParams
	{
		// Token: 0x04031599 RID: 202137
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403159A RID: 202138
		[FieldOffset(8)]
		public FString filterStr;

		// Token: 0x0403159B RID: 202139
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x0403159C RID: 202140
		[FieldOffset(32)]
		public FString __Result;
	}

	// Token: 0x0200952E RID: 38190
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __LoadDataTable_FunctionParams
	{
		// Token: 0x0403159D RID: 202141
		[FieldOffset(0)]
		public FString assetPath;

		// Token: 0x0403159E RID: 202142
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x0403159F RID: 202143
		[FieldOffset(24)]
		public IntPtr __Result;
	}

	// Token: 0x0200952F RID: 38191
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetDebugStateMachine_FunctionParams
	{
		// Token: 0x040315A0 RID: 202144
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040315A1 RID: 202145
		[FieldOffset(8)]
		public byte output;

		// Token: 0x040315A2 RID: 202146
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009530 RID: 38192
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetSkillDebugString_FunctionParams
	{
		// Token: 0x040315A3 RID: 202147
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040315A4 RID: 202148
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040315A5 RID: 202149
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009531 RID: 38193
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetSkillLogString_FunctionParams
	{
		// Token: 0x040315A6 RID: 202150
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040315A7 RID: 202151
		[FieldOffset(8)]
		public FString filterStr;

		// Token: 0x040315A8 RID: 202152
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x040315A9 RID: 202153
		[FieldOffset(32)]
		public FString __Result;
	}

	// Token: 0x02009532 RID: 38194
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ClearSkillLogString_FunctionParams
	{
		// Token: 0x040315AA RID: 202154
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040315AB RID: 202155
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009533 RID: 38195
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetSkillBehaviorLogString_FunctionParams
	{
		// Token: 0x040315AC RID: 202156
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040315AD RID: 202157
		[FieldOffset(8)]
		public FString filterStr;

		// Token: 0x040315AE RID: 202158
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x040315AF RID: 202159
		[FieldOffset(32)]
		public FString __Result;
	}

	// Token: 0x02009534 RID: 38196
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ClearSkillBehaviorLogString_FunctionParams
	{
		// Token: 0x040315B0 RID: 202160
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040315B1 RID: 202161
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009535 RID: 38197
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetBulletDebugString_FunctionParams
	{
		// Token: 0x040315B2 RID: 202162
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040315B3 RID: 202163
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040315B4 RID: 202164
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009536 RID: 38198
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetBulletLogString_FunctionParams
	{
		// Token: 0x040315B5 RID: 202165
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040315B6 RID: 202166
		[FieldOffset(8)]
		public FString filterStr;

		// Token: 0x040315B7 RID: 202167
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x040315B8 RID: 202168
		[FieldOffset(32)]
		public FString __Result;
	}

	// Token: 0x02009537 RID: 38199
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ClearBulletLogString_FunctionParams
	{
		// Token: 0x040315B9 RID: 202169
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040315BA RID: 202170
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009538 RID: 38200
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetEntityDebugMove_FunctionParams
	{
		// Token: 0x040315BB RID: 202171
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040315BC RID: 202172
		[FieldOffset(4)]
		public bool enable;

		// Token: 0x040315BD RID: 202173
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}
}
