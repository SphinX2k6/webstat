using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Aki.Config;
using Aki.Protocol;
using Aki.Protocol.Ai;
using Aki.Protocol.Debug;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.NewWorld.Vehicle.Motorcycle;
using CSharpScript.Game.World.Model;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x02002EB9 RID: 11961
[NullableContext(1)]
[Nullable(0)]
public class CharacterGasDebugComponent : EntityComponent, IStaticVariableResetter
{
	// Token: 0x0601888A RID: 100490 RVA: 0x006E25D0 File Offset: 0x006E07D0
	static CharacterGasDebugComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterGasDebugComponent.CreateStaticDefaultValue), new Action(CharacterGasDebugComponent.ResetStaticDefaultValue));
	}

	// Token: 0x0601888B RID: 100491 RVA: 0x006E26C0 File Offset: 0x006E08C0
	public static void CreateStaticDefaultValue()
	{
		EAttributeType[] array = new EAttributeType[59];
		RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.3973461535FC1DE073DB99C9A3B678C6854BAF094837AEAB59A9AF282D227447).FieldHandle);
		CharacterGasDebugComponent._attributeIdArray = array;
		CharacterGasDebugComponent._moveRecordStrings = new List<string>();
		CharacterGasDebugComponent._damageRecordStrings = new List<string>();
		CharacterGasDebugComponent._moveSumTable = new Dictionary<int, RecordMoveSum>();
		CharacterGasDebugComponent._roleDamageSumTable = new Dictionary<string, RecordDamageSum>();
		CharacterGasDebugComponent._monsterDamageSumTable = new Dictionary<string, RecordDamageSum>();
		CharacterGasDebugComponent._bulletCreateMap = new Dictionary<int, string[]>();
		CharacterGasDebugComponent._bulletCreateEntityId = new List<int>();
		CharacterGasDebugComponent._buffRecordArray = new List<string>();
		CharacterGasDebugComponent._damageRecordSnipeshotArray = new List<string>();
		CharacterGasDebugComponent._damageRecordAttrArray = new List<string>();
	}

	// Token: 0x0601888C RID: 100492 RVA: 0x006E2748 File Offset: 0x006E0948
	public static void ResetStaticDefaultValue()
	{
		CharacterGasDebugComponent._attributeIdArray = null;
		CharacterGasDebugComponent.IsServerLogOnInternal = false;
		CharacterGasDebugComponent.ShouldRecord = false;
		CharacterGasDebugComponent.RecordStartTime = 0.0;
		CharacterGasDebugComponent.RecordStartTimeStamp = 0.0;
		CharacterGasDebugComponent._moveRecordStrings = null;
		CharacterGasDebugComponent._damageRecordStrings = null;
		CharacterGasDebugComponent._moveSumTable = null;
		CharacterGasDebugComponent._roleDamageSumTable = null;
		CharacterGasDebugComponent._monsterDamageSumTable = null;
		CharacterGasDebugComponent._bulletCreateMap = null;
		CharacterGasDebugComponent._bulletCreateEntityId = null;
		CharacterGasDebugComponent._buffRecordArray = null;
		CharacterGasDebugComponent._damageRecordSnipeshotArray = null;
		CharacterGasDebugComponent._damageRecordAttrArray = null;
		CharacterGasDebugComponent.DamageRecordDspMap = null;
		CharacterGasDebugComponent.InTimeStop = false;
		CharacterGasDebugComponent.TimeStopSpanTime = 0f;
		CharacterGasDebugComponent.FrameUpdateSpanTime = 0L;
	}

	// Token: 0x1700211A RID: 8474
	// (get) Token: 0x0601888D RID: 100493 RVA: 0x006E27DC File Offset: 0x006E09DC
	private static EAttributeType[] AttributeIdArray
	{
		get
		{
			return CharacterGasDebugComponent._attributeIdArray;
		}
	}

	// Token: 0x0601888E RID: 100494 RVA: 0x006E27E4 File Offset: 0x006E09E4
	protected override bool OnStart()
	{
		CharacterActorComponent component = base.Entity.GetComponent<CharacterActorComponent>();
		this.DebugGasComponent = ((component != null) ? component.Actor.AbilitySystemComponent : null);
		this.BeginDebugTask();
		this.StartListenMovementHistory();
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharRecordOperate, new Action<EntityHandle, int, ESkillGenre>(this.RecordMove));
		Singleton<EventSystem>.Instance.AddWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnBeginSkill));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.BulletCreate, new Action<BulletInfo>(this.OnBulletCreate));
		return true;
	}

	// Token: 0x0601888F RID: 100495 RVA: 0x006E2884 File Offset: 0x006E0A84
	protected override void OnTick(float delta)
	{
		if (CharacterGasDebugComponent.InTimeStop && (long)Singleton<Time>.Instance.Frame > CharacterGasDebugComponent.FrameUpdateSpanTime)
		{
			CharacterGasDebugComponent.TimeStopSpanTime += delta * 0.001f;
			CharacterGasDebugComponent.FrameUpdateSpanTime = (long)Singleton<Time>.Instance.Frame;
		}
		if (this.EnableCollisionDebugDraw)
		{
			BaseActorComponent component = base.Entity.GetComponent<BaseActorComponent>();
			if (component != null)
			{
				AActor owner = component.Owner;
				TArray<UActorComponent> tarray = (owner != null) ? owner.K2_GetComponentsByClass(UCapsuleComponent.StaticClass()) : null;
				int num = 0;
				while (tarray != null && num < tarray.Num())
				{
					UCapsuleComponent ucapsuleComponent = tarray.Get(num) as UCapsuleComponent;
					UKismetSystemLibrary.D_DrawDebugCapsule(component.Owner, ucapsuleComponent.D_K2_GetComponentLocation(), ucapsuleComponent.CapsuleHalfHeight, ucapsuleComponent.CapsuleRadius, ucapsuleComponent.K2_GetComponentRotation(), new FLinearColor?(new FLinearColor(1f, 1f, 0f, 1f)), 0f, 1f);
					num++;
				}
			}
		}
	}

	// Token: 0x06018890 RID: 100496 RVA: 0x006E2974 File Offset: 0x006E0B74
	protected override bool OnEnd()
	{
		UAsyncTaskEffectDebugString geDebugTask = this.GeDebugTask;
		if (geDebugTask != null)
		{
			geDebugTask.EndTask();
		}
		this.GeDebugTask = null;
		this.EndListenMovementHistory();
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharRecordOperate, new Action<EntityHandle, int, ESkillGenre>(this.RecordMove));
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnBeginSkill));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.BulletCreate, new Action<BulletInfo>(this.OnBulletCreate));
		return true;
	}

	// Token: 0x06018891 RID: 100497 RVA: 0x006E2A03 File Offset: 0x006E0C03
	private void BeginDebugTask()
	{
		if (this.DebugGasComponent == null)
		{
			return;
		}
		this.GeDebugTask = UAsyncTaskEffectDebugString.ListenForGameplayEffectExecutedDebugString(this.DebugGasComponent);
		UAsyncTaskEffectDebugString geDebugTask = this.GeDebugTask;
		if (geDebugTask == null)
		{
			return;
		}
		geDebugTask.OnAnyGameplayEffectExecuted.Add(new Action<string>(this.GeDebugTaskCallback));
	}

	// Token: 0x06018892 RID: 100498 RVA: 0x006E2A40 File Offset: 0x006E0C40
	private void GeDebugTaskCallback(string debugInfo)
	{
		if (debugInfo.Contains("Tag"))
		{
			return;
		}
		this.GeDebugId++;
		this.DebugStrings.Insert(0, "Num " + this.GeDebugId.ToString() + ": " + debugInfo);
		if (this.DebugStrings.Count > 50)
		{
			this.DebugStrings.RemoveAt(this.DebugStrings.Count - 1);
		}
	}

	// Token: 0x06018893 RID: 100499 RVA: 0x006E2AB7 File Offset: 0x006E0CB7
	public string GetGeDebugStrings()
	{
		return string.Join(" ", this.DebugStrings);
	}

	// Token: 0x06018894 RID: 100500 RVA: 0x006E2AC9 File Offset: 0x006E0CC9
	public string GetTagDebugStrings()
	{
		BaseTagComponent component = base.Entity.GetComponent<BaseTagComponent>();
		return ((component != null) ? component.TagContainer.GetDebugString() : null) ?? "找不到tag组件";
	}

	// Token: 0x06018895 RID: 100501 RVA: 0x006E2AF0 File Offset: 0x006E0CF0
	public unsafe void AddSkillLogString(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		if (this.SkillLogStrings.Count >= 50)
		{
			this.SkillLogStrings.RemoveAt(0);
		}
		StringBuilder sb = CharacterGasDebugComponent.Sb;
		sb.Clear();
		sb.Append('#');
		sb.Append(message);
		ReadOnlySpan<ValueTuple<string, object>> readOnlySpan = pairs;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			ValueTuple<string, object> valueTuple = *readOnlySpan[i];
			string item = valueTuple.Item1;
			object item2 = valueTuple.Item2;
			sb.Append(' ');
			StringBuilder stringBuilder = sb;
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, stringBuilder);
			appendInterpolatedStringHandler.AppendLiteral("[");
			appendInterpolatedStringHandler.AppendFormatted(item);
			appendInterpolatedStringHandler.AppendLiteral(": ");
			appendInterpolatedStringHandler.AppendFormatted((item2 != null) ? item2.ToString() : "null");
			appendInterpolatedStringHandler.AppendLiteral("]");
			stringBuilder2.Append(ref appendInterpolatedStringHandler);
		}
		string text = sb.ToString();
		if (text.Contains("BeginSkill"))
		{
			text = "\n" + text;
		}
		this.SkillLogStrings.Add(text);
	}

	// Token: 0x06018896 RID: 100502 RVA: 0x006E2C00 File Offset: 0x006E0E00
	public string GetSkillLogString(string filterStr)
	{
		List<string> list = new List<string>();
		if (!string.IsNullOrEmpty(filterStr))
		{
			MatchCollection matchCollection = Regex.Matches(filterStr, "[0-9]+");
			for (int i = 0; i < matchCollection.Count; i++)
			{
				string value = matchCollection[i].Value;
				list.Add(value);
			}
		}
		List<string> list2 = new List<string>();
		int j = 0;
		while (j < this.SkillLogStrings.Count)
		{
			string text = this.SkillLogStrings[j];
			if (list.Count <= 0)
			{
				goto IL_9A;
			}
			bool flag = false;
			for (int k = 0; k < list.Count; k++)
			{
				string value2 = list[k];
				if (text.Contains(value2))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				goto IL_9A;
			}
			IL_A2:
			j++;
			continue;
			IL_9A:
			list2.Add(text);
			goto IL_A2;
		}
		return string.Join("\n", list2);
	}

	// Token: 0x06018897 RID: 100503 RVA: 0x006E2CCF File Offset: 0x006E0ECF
	public void ClearSkillLogString()
	{
		this.SkillLogStrings.Clear();
	}

	// Token: 0x06018898 RID: 100504 RVA: 0x006E2CDC File Offset: 0x006E0EDC
	public unsafe void AddSkillBehaviorLogString(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		if (this.SkillBehaviorLogStrings.Count >= 50)
		{
			this.SkillBehaviorLogStrings.RemoveAt(0);
		}
		StringBuilder sb = CharacterGasDebugComponent.Sb;
		sb.Clear();
		sb.Append('#');
		sb.Append(message);
		ReadOnlySpan<ValueTuple<string, object>> readOnlySpan = pairs;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			ValueTuple<string, object> valueTuple = *readOnlySpan[i];
			string item = valueTuple.Item1;
			object item2 = valueTuple.Item2;
			sb.Append(' ');
			StringBuilder stringBuilder = sb;
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, stringBuilder);
			appendInterpolatedStringHandler.AppendLiteral("[");
			appendInterpolatedStringHandler.AppendFormatted(item);
			appendInterpolatedStringHandler.AppendLiteral(": ");
			appendInterpolatedStringHandler.AppendFormatted((item2 != null) ? item2.ToString() : "null");
			appendInterpolatedStringHandler.AppendLiteral("]");
			stringBuilder2.Append(ref appendInterpolatedStringHandler);
		}
		string item3 = sb.ToString();
		this.SkillBehaviorLogStrings.Add(item3);
	}

	// Token: 0x06018899 RID: 100505 RVA: 0x006E2DD4 File Offset: 0x006E0FD4
	public string GetSkillBehaviorLogString(string filterStr)
	{
		List<string> list = new List<string>();
		foreach (object obj in Regex.Matches(filterStr, "[0-9]+"))
		{
			Match match = (Match)obj;
			list.Add(match.Value);
		}
		List<string> list2 = new List<string>();
		foreach (string text in this.SkillBehaviorLogStrings)
		{
			if (list.Count > 0)
			{
				bool flag = false;
				foreach (string value in list)
				{
					if (text.Contains(value))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
			}
			list2.Add(text);
		}
		return string.Join("\n", list2);
	}

	// Token: 0x0601889A RID: 100506 RVA: 0x006E2EF0 File Offset: 0x006E10F0
	public void ClearSkillBehaviorLogString()
	{
		this.SkillBehaviorLogStrings.Clear();
	}

	// Token: 0x0601889B RID: 100507 RVA: 0x006E2F00 File Offset: 0x006E1100
	public unsafe void AddBulletDebugLogString(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		if (this.BulletDebugStrings.Count >= 50)
		{
			this.BulletDebugStrings.RemoveAt(0);
		}
		StringBuilder sb = CharacterGasDebugComponent.Sb;
		sb.Clear();
		sb.Append('#');
		sb.Append(message);
		if (pairs.Length > 0)
		{
			sb.Append(' ');
			ReadOnlySpan<ValueTuple<string, object>> readOnlySpan = pairs;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				ValueTuple<string, object> valueTuple = *readOnlySpan[i];
				StringBuilder stringBuilder = sb;
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, stringBuilder);
				appendInterpolatedStringHandler.AppendLiteral("[");
				appendInterpolatedStringHandler.AppendFormatted(valueTuple.Item1);
				appendInterpolatedStringHandler.AppendLiteral(": ");
				appendInterpolatedStringHandler.AppendFormatted((valueTuple.Item2 != null) ? valueTuple.Item2.ToString() : "null");
				appendInterpolatedStringHandler.AppendLiteral("]");
				stringBuilder2.Append(ref appendInterpolatedStringHandler);
			}
		}
		this.BulletDebugStrings.Add(sb.ToString());
	}

	// Token: 0x0601889C RID: 100508 RVA: 0x006E2FFC File Offset: 0x006E11FC
	public void AddBulletDebugLogString(string message, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] IReadOnlyCollection<ValueTuple<string, object>> pairs)
	{
		if (this.BulletDebugStrings.Count >= 50)
		{
			this.BulletDebugStrings.RemoveAt(0);
		}
		StringBuilder sb = CharacterGasDebugComponent.Sb;
		sb.Clear();
		sb.Append("#");
		sb.Append(message);
		if (pairs.Count > 0)
		{
			sb.Append(' ');
			foreach (ValueTuple<string, object> valueTuple in pairs)
			{
				StringBuilder stringBuilder = sb;
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, stringBuilder);
				appendInterpolatedStringHandler.AppendLiteral("[");
				appendInterpolatedStringHandler.AppendFormatted(valueTuple.Item1);
				appendInterpolatedStringHandler.AppendLiteral(": ");
				appendInterpolatedStringHandler.AppendFormatted((valueTuple.Item2 != null) ? valueTuple.Item2.ToString() : "null");
				appendInterpolatedStringHandler.AppendLiteral("]");
				stringBuilder2.Append(ref appendInterpolatedStringHandler);
			}
		}
		this.BulletDebugStrings.Add(sb.ToString());
	}

	// Token: 0x0601889D RID: 100509 RVA: 0x006E3108 File Offset: 0x006E1308
	public string GetBulletLogString(string filterStr)
	{
		List<string> list = new List<string>();
		foreach (object obj in Regex.Matches(filterStr, "[0-9]+"))
		{
			Match match = (Match)obj;
			list.Add(match.Value);
		}
		List<string> list2 = new List<string>();
		foreach (string text in this.BulletDebugStrings)
		{
			if (list.Count > 0)
			{
				bool flag = false;
				foreach (string value in list)
				{
					if (text.Contains(value))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
			}
			list2.Add(text);
		}
		return string.Join("\n", list2);
	}

	// Token: 0x0601889E RID: 100510 RVA: 0x006E3224 File Offset: 0x006E1424
	public void ClearBulletLogString()
	{
		this.BulletDebugStrings.Clear();
	}

	// Token: 0x0601889F RID: 100511 RVA: 0x006E3234 File Offset: 0x006E1434
	public string GetTagContainerDebugString(FGameplayTagContainer tagContainer)
	{
		TArray<FGameplayTag> gameplayTags = tagContainer.GameplayTags;
		int num = (gameplayTags != null) ? gameplayTags.Num() : 0;
		if (num <= 0)
		{
			return "";
		}
		string text = "";
		for (int i = 0; i < num; i++)
		{
			text = text + tagContainer.GameplayTags.Get(i).TagName.ToString() + " ";
		}
		return text;
	}

	// Token: 0x060188A0 RID: 100512 RVA: 0x006E329C File Offset: 0x006E149C
	public string GetBuffEffectDebugString(string searchStr)
	{
		string text = "";
		foreach (BuffEffect buffEffect in base.Entity.GetComponent<CharacterBuffComponent>().BuffEffectManager.GetAllEffects())
		{
			if (this.MatchBuffId(searchStr, buffEffect.BuffId.ToString()))
			{
				string str = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 3);
				defaultInterpolatedStringHandler.AppendFormatted(buffEffect.GetType().Name);
				defaultInterpolatedStringHandler.AppendLiteral(" buffId:");
				defaultInterpolatedStringHandler.AppendFormatted<long>(buffEffect.BuffId);
				defaultInterpolatedStringHandler.AppendLiteral(" handle:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(buffEffect.ActiveHandleId);
				defaultInterpolatedStringHandler.AppendLiteral("\n");
				text = str + defaultInterpolatedStringHandler.ToStringAndClear();
			}
		}
		return text;
	}

	// Token: 0x060188A1 RID: 100513 RVA: 0x006E337C File Offset: 0x006E157C
	public string GetShieldDebugString(string filterStr = "")
	{
		this.ShieldDebugStrings.Clear();
		string[] array = (from match in Regex.Matches(filterStr, "[0-9]+")
		select match.Value).ToArray<string>();
		CharacterShieldComponent component = base.Entity.GetComponent<CharacterShieldComponent>();
		if (component != null)
		{
			foreach (KeyValuePair<int, CharacterShield> keyValuePair in component.GetDebugShieldInfo())
			{
				int num;
				CharacterShield shield2;
				keyValuePair.Deconstruct(out num, out shield2);
				CharacterShield shield = shield2;
				if (array.Length == 0 || array.Any((string key) => shield.TemplateId.ToString().StartsWith(key)))
				{
					float shieldValue = shield.ShieldValue;
					int priority = shield.Priority;
					int templateId = shield.TemplateId;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 3);
					defaultInterpolatedStringHandler.AppendLiteral("Shield magnitude: ");
					defaultInterpolatedStringHandler.AppendFormatted<float>(shieldValue);
					defaultInterpolatedStringHandler.AppendLiteral(" priority: ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(priority);
					defaultInterpolatedStringHandler.AppendLiteral(" templateId: ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(templateId);
					string item = defaultInterpolatedStringHandler.ToStringAndClear();
					this.ShieldDebugStrings.Add(item);
				}
			}
		}
		BaseAttributeComponent component2 = base.Entity.GetComponent<BaseAttributeComponent>();
		string str = ((component2 != null) ? component2.GetLockDebugString(array) : null) ?? "";
		return "\n\nShields:\n" + string.Join("\n", this.ShieldDebugStrings) + str;
	}

	// Token: 0x060188A2 RID: 100514 RVA: 0x006E3518 File Offset: 0x006E1718
	public string GetAttributeDebugStrings()
	{
		BaseAttributeComponent component = base.Entity.GetComponent<BaseAttributeComponent>();
		if (component == null)
		{
			return "Invalid";
		}
		string text = "";
		for (int i = 1; i < 143; i++)
		{
			float baseValue = component.GetBaseValue((EAttributeType)i);
			float currentValue = component.GetCurrentValue((EAttributeType)i);
			EAttributeType eattributeType = (EAttributeType)i;
			string value = eattributeType.ToString();
			if (CharacterAttributeTypes.stateAttributeIds.Contains((EAttributeType)i) || currentValue == baseValue)
			{
				string str = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 3);
				defaultInterpolatedStringHandler.AppendLiteral("#");
				defaultInterpolatedStringHandler.AppendFormatted<int>(i);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(value);
				defaultInterpolatedStringHandler.AppendLiteral("\t= ");
				defaultInterpolatedStringHandler.AppendFormatted(currentValue.ToString("F0"));
				defaultInterpolatedStringHandler.AppendLiteral("\n");
				text = str + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else if (currentValue > baseValue)
			{
				string str2 = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 4);
				defaultInterpolatedStringHandler.AppendLiteral("#");
				defaultInterpolatedStringHandler.AppendFormatted<int>(i);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(value);
				defaultInterpolatedStringHandler.AppendLiteral("\t= ");
				defaultInterpolatedStringHandler.AppendFormatted(currentValue.ToString("F0"));
				defaultInterpolatedStringHandler.AppendLiteral("(+");
				defaultInterpolatedStringHandler.AppendFormatted((currentValue - baseValue).ToString("F0"));
				defaultInterpolatedStringHandler.AppendLiteral(")\n");
				text = str2 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				string str3 = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 4);
				defaultInterpolatedStringHandler.AppendLiteral("#");
				defaultInterpolatedStringHandler.AppendFormatted<int>(i);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(value);
				defaultInterpolatedStringHandler.AppendLiteral("\t= ");
				defaultInterpolatedStringHandler.AppendFormatted(currentValue.ToString("F0"));
				defaultInterpolatedStringHandler.AppendLiteral("(");
				defaultInterpolatedStringHandler.AppendFormatted((currentValue - baseValue).ToString("F0"));
				defaultInterpolatedStringHandler.AppendLiteral(")\n");
				text = str3 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
		}
		return text + "\n队伍属性：\n" + CharacterGasDebugComponent.GetFormationAttributeDebugStrings();
	}

	// Token: 0x060188A3 RID: 100515 RVA: 0x006E373C File Offset: 0x006E193C
	public string GetAllAttributeDebugStrings()
	{
		this.AttributeDebugStrings.Clear();
		BaseAttributeComponent component = base.Entity.GetComponent<BaseAttributeComponent>();
		for (int i = 1; i < 143; i++)
		{
			float baseValue = component.GetBaseValue((EAttributeType)i);
			float currentValue = component.GetCurrentValue((EAttributeType)i);
			EAttributeType eattributeType = (EAttributeType)i;
			string value = eattributeType.ToString();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 4);
			defaultInterpolatedStringHandler.AppendLiteral("Attribute ID: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(i);
			defaultInterpolatedStringHandler.AppendLiteral("   ");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("  \n    Base: ");
			defaultInterpolatedStringHandler.AppendFormatted(baseValue.ToString("F0"));
			defaultInterpolatedStringHandler.AppendLiteral("    Current: ");
			defaultInterpolatedStringHandler.AppendFormatted(currentValue.ToString("F0"));
			defaultInterpolatedStringHandler.AppendLiteral(" \n");
			string item = defaultInterpolatedStringHandler.ToStringAndClear();
			this.AttributeDebugStrings.Add(item);
		}
		return string.Join("\n", this.AttributeDebugStrings);
	}

	// Token: 0x060188A4 RID: 100516 RVA: 0x006E383C File Offset: 0x006E1A3C
	public static string GetFormationAttributeDebugStrings()
	{
		string text = "";
		foreach (FormationProperty formationProperty in ConfigFormationPropertyAll.GetConfigList(true))
		{
			int id = formationProperty.Id;
			EFormationAttributeId attrId = (EFormationAttributeId)id;
			float value = ControllerBase<FormationAttributeController>.Instance.GetValue(attrId);
			float max = ControllerBase<FormationAttributeController>.Instance.GetMax(attrId);
			float speed = ControllerBase<FormationAttributeController>.Instance.GetSpeed(attrId);
			string str = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 4);
			defaultInterpolatedStringHandler.AppendLiteral("#");
			defaultInterpolatedStringHandler.AppendFormatted<int>(id);
			defaultInterpolatedStringHandler.AppendLiteral(" = ");
			defaultInterpolatedStringHandler.AppendFormatted(value.ToString("F0"));
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(max.ToString("F0"));
			defaultInterpolatedStringHandler.AppendLiteral(" (");
			defaultInterpolatedStringHandler.AppendFormatted(speed.ToString("F0"));
			defaultInterpolatedStringHandler.AppendLiteral("/s)\n");
			text = str + defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return text;
	}

	// Token: 0x060188A5 RID: 100517 RVA: 0x006E395C File Offset: 0x006E1B5C
	public string GetAllAttributeDebugInfo()
	{
		BaseAttributeComponent component = base.Entity.GetComponent<BaseAttributeComponent>();
		if (component == null)
		{
			return "Invalid";
		}
		string text = "";
		EntityBattleInfoResponse serverDebugInfo = this.ServerDebugInfo;
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
			float baseValue = component.GetBaseValue((EAttributeType)i);
			float currentValue = component.GetCurrentValue((EAttributeType)i);
			string value = currentValue.ToString("F0");
			string text2 = (currentValue - baseValue).ToString("F0");
			if (currentValue >= baseValue)
			{
				text2 = "+" + text2;
			}
			text2 = ((currentValue == baseValue) ? "" : ("(" + text2 + ")"));
			EAttributeType eattributeType = (EAttributeType)i;
			string value2 = eattributeType.ToString().Replace("Proto_", "");
			GameplayAttributeData gameplayAttributeData2 = array[i];
			string value3 = ((gameplayAttributeData2 != null) ? gameplayAttributeData2.CurrentValue.ToString("F0") : null) ?? "0";
			string text3 = (gameplayAttributeData2 != null) ? (gameplayAttributeData2.CurrentValue - gameplayAttributeData2.BaseValue).ToString("F0") : "0";
			if (gameplayAttributeData2 != null && gameplayAttributeData2.CurrentValue > gameplayAttributeData2.BaseValue)
			{
				text3 = "+" + text3;
			}
			int? num = (gameplayAttributeData2 != null) ? new int?(gameplayAttributeData2.CurrentValue) : null;
			int? num2 = (gameplayAttributeData2 != null) ? new int?(gameplayAttributeData2.BaseValue) : null;
			text3 = ((num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null)) ? "" : ("(" + text3 + ")"));
			if (CharacterAttributeTypes.stateAttributeIds.Contains((EAttributeType)i) || currentValue == baseValue)
			{
				string str = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 4);
				defaultInterpolatedStringHandler.AppendLiteral("#");
				defaultInterpolatedStringHandler.AppendFormatted<int>(i);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(value2);
				defaultInterpolatedStringHandler.AppendLiteral("\t C:");
				defaultInterpolatedStringHandler.AppendFormatted(value);
				defaultInterpolatedStringHandler.AppendLiteral(" | S:");
				defaultInterpolatedStringHandler.AppendFormatted(value3);
				defaultInterpolatedStringHandler.AppendLiteral("\n");
				text = str + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				string str2 = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 6);
				defaultInterpolatedStringHandler.AppendLiteral("#");
				defaultInterpolatedStringHandler.AppendFormatted<int>(i);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(value2);
				defaultInterpolatedStringHandler.AppendLiteral("\t C:");
				defaultInterpolatedStringHandler.AppendFormatted(value);
				defaultInterpolatedStringHandler.AppendLiteral("(");
				defaultInterpolatedStringHandler.AppendFormatted(text2);
				defaultInterpolatedStringHandler.AppendLiteral(") | S:");
				defaultInterpolatedStringHandler.AppendFormatted(value3);
				defaultInterpolatedStringHandler.AppendLiteral("(");
				defaultInterpolatedStringHandler.AppendFormatted(text3);
				defaultInterpolatedStringHandler.AppendLiteral(")\n");
				text = str2 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
		}
		text += "\n队伍属性：\n";
		EntityBattleInfoResponse serverDebugInfo2 = this.ServerDebugInfo;
		RepeatedField<FormationAttr> repeatedField2 = (serverDebugInfo2 != null) ? serverDebugInfo2.FormationAttrs : null;
		Dictionary<int, FormationAttr> dictionary = new Dictionary<int, FormationAttr>();
		if (repeatedField2 != null)
		{
			foreach (FormationAttr formationAttr in repeatedField2)
			{
				dictionary[formationAttr.AttrId] = formationAttr;
			}
		}
		foreach (FormationProperty formationProperty in ConfigFormationPropertyAll.GetConfigList(true))
		{
			int id = formationProperty.Id;
			EFormationAttributeId attrId = (EFormationAttributeId)id;
			float value4 = ControllerBase<FormationAttributeController>.Instance.GetValue(attrId);
			float max = ControllerBase<FormationAttributeController>.Instance.GetMax(attrId);
			float speed = ControllerBase<FormationAttributeController>.Instance.GetSpeed(attrId);
			FormationAttr formationAttr2;
			dictionary.TryGetValue(id, out formationAttr2);
			string value5 = ((formationAttr2 != null) ? formationAttr2.CurrentValue.ToString("F0") : null) ?? "???";
			string value6 = ((formationAttr2 != null) ? formationAttr2.MaxValue.ToString("F0") : null) ?? "???";
			string value7 = ((formationAttr2 != null) ? formationAttr2.Ratio.ToString("F0") : null) ?? "???";
			string str3 = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 7);
			defaultInterpolatedStringHandler.AppendLiteral("#");
			defaultInterpolatedStringHandler.AppendFormatted<int>(id);
			defaultInterpolatedStringHandler.AppendLiteral("\t C:");
			defaultInterpolatedStringHandler.AppendFormatted(value4.ToString("F0"));
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(max.ToString("F0"));
			defaultInterpolatedStringHandler.AppendLiteral(" (");
			defaultInterpolatedStringHandler.AppendFormatted(speed.ToString("F0"));
			defaultInterpolatedStringHandler.AppendLiteral("/s)");
			defaultInterpolatedStringHandler.AppendLiteral(" | S:");
			defaultInterpolatedStringHandler.AppendFormatted(value5);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(value6);
			defaultInterpolatedStringHandler.AppendLiteral(" (");
			defaultInterpolatedStringHandler.AppendFormatted(value7);
			defaultInterpolatedStringHandler.AppendLiteral("/s)\n");
			text = str3 + defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return text;
	}

	// Token: 0x060188A6 RID: 100518 RVA: 0x006E3F28 File Offset: 0x006E2128
	private void StartListenMovementHistory()
	{
		Singleton<EventSystem>.Instance.AddWithTarget<int, EMovementMode, EMovementMode, byte, byte>(base.Entity, EEventName.CharMovementModeChanged, new Action<int, EMovementMode, EMovementMode, byte, byte>(this.OnCharacterMovementModeChanged));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.MoveStateChangeHandler));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.PositionStateChangeHandler));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnSetNewBeHit, new Action<bool>(this.NewBeHitChangeHandler));
	}

	// Token: 0x060188A7 RID: 100519 RVA: 0x006E3FC0 File Offset: 0x006E21C0
	private void EndListenMovementHistory()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, EMovementMode, EMovementMode, byte, byte>(base.Entity, EEventName.CharMovementModeChanged, new Action<int, EMovementMode, EMovementMode, byte, byte>(this.OnCharacterMovementModeChanged));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.MoveStateChangeHandler));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.PositionStateChangeHandler));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnSetNewBeHit, new Action<bool>(this.NewBeHitChangeHandler));
	}

	// Token: 0x060188A8 RID: 100520 RVA: 0x006E4058 File Offset: 0x006E2258
	private void OnCharacterMovementModeChanged(int charId, EMovementMode prevMovementMode, EMovementMode newMovementMode, byte prevCustomMode, byte newCustomMode)
	{
		int num = (int)prevMovementMode;
		int num2 = (int)newMovementMode;
		string text;
		if (num < 0 || num >= Enum.GetNames<EMovementModeName>().Length)
		{
			text = prevMovementMode.ToString();
		}
		else
		{
			EMovementModeName emovementModeName = (EMovementModeName)num;
			text = emovementModeName.ToString();
		}
		string text2 = text;
		string text3;
		if (num2 < 0 || num2 >= Enum.GetNames<EMovementModeName>().Length)
		{
			text3 = newMovementMode.ToString();
		}
		else
		{
			EMovementModeName emovementModeName = (EMovementModeName)num2;
			text3 = emovementModeName.ToString();
		}
		string text4 = text3;
		this.MovementDebugStrings.Insert(0, string.Concat(new string[]
		{
			text2,
			".",
			prevCustomMode.ToString(),
			" ->",
			text4,
			".",
			newCustomMode.ToString()
		}));
	}

	// Token: 0x060188A9 RID: 100521 RVA: 0x006E4110 File Offset: 0x006E2310
	private void MoveStateChangeHandler(global::ECharMoveState oldState, global::ECharMoveState newState)
	{
		this.MovementDebugStrings.Insert(0, oldState.ToString() + " ->" + newState.ToString());
	}

	// Token: 0x060188AA RID: 100522 RVA: 0x006E4142 File Offset: 0x006E2342
	private void PositionStateChangeHandler(global::ECharPositionState oldState, global::ECharPositionState newState)
	{
		this.MovementDebugStrings.Insert(0, oldState.ToString() + " ->" + newState.ToString());
	}

	// Token: 0x060188AB RID: 100523 RVA: 0x006E4174 File Offset: 0x006E2374
	private void NewBeHitChangeHandler(bool beHit)
	{
		this.MovementDebugStrings.Insert(0, "Set NewBeHit:" + beHit.ToString());
	}

	// Token: 0x060188AC RID: 100524 RVA: 0x006E4193 File Offset: 0x006E2393
	public string GetAllMovementHistory()
	{
		if (this.MovementDebugStrings.Count > 50)
		{
			this.MovementDebugStrings.RemoveAt(this.MovementDebugStrings.Count - 1);
		}
		return string.Join("\n", this.MovementDebugStrings);
	}

	// Token: 0x060188AD RID: 100525 RVA: 0x006E41CC File Offset: 0x006E23CC
	public void DebugResetBaseValue(int id, float val)
	{
		if (id >= 1 && id < 143)
		{
			BaseAttributeComponent component = base.Entity.GetComponent<BaseAttributeComponent>();
			if (component == null)
			{
				return;
			}
			component.SetBaseValue((EAttributeType)id, val);
		}
	}

	// Token: 0x1700211B RID: 8475
	// (get) Token: 0x060188AE RID: 100526 RVA: 0x006E41F1 File Offset: 0x006E23F1
	public static bool IsServerLogOff
	{
		get
		{
			return CharacterGasDebugComponent.IsServerLogOnInternal;
		}
	}

	// Token: 0x060188AF RID: 100527 RVA: 0x006E41F8 File Offset: 0x006E23F8
	public static void ReceiveSwitchServerLogMode(bool isClientControl)
	{
		CharacterGasDebugComponent.IsServerLogOnInternal = isClientControl;
	}

	// Token: 0x060188B0 RID: 100528 RVA: 0x006E4200 File Offset: 0x006E2400
	public static void RequestSwitchServerMode(bool isClientControl)
	{
		SwitchBattleModeRequest switchBattleModeRequest = SwitchBattleModeRequest.Create();
		switchBattleModeRequest.Client = isClientControl;
		switchBattleModeRequest.ClientControllerModule = BattleModule.Log;
		Singleton<Net>.Instance.Call<SwitchBattleModeResponse>(ERequestMessageId.SwitchBattleModeRequest, switchBattleModeRequest, delegate(SwitchBattleModeResponse response, Net.CallbackStatus _)
		{
			if (response != null)
			{
				CharacterGasDebugComponent.ReceiveSwitchServerLogMode(response.Client);
			}
		}, 0);
	}

	// Token: 0x060188B1 RID: 100529 RVA: 0x006E4254 File Offset: 0x006E2454
	public static string SecondsSinceStartup()
	{
		return (Singleton<Time>.Instance.WorldTimeSeconds - CharacterGasDebugComponent.RecordStartTime - (double)CharacterGasDebugComponent.TimeStopSpanTime).ToString("F2");
	}

	// Token: 0x060188B2 RID: 100530 RVA: 0x006E4285 File Offset: 0x006E2485
	public static void SetDistanceMax(float max)
	{
	}

	// Token: 0x060188B3 RID: 100531 RVA: 0x006E4288 File Offset: 0x006E2488
	public static void BeginRecord()
	{
		CharacterGasDebugComponent.TimeStopSpanTime = 0f;
		CharacterGasDebugComponent.ShouldRecord = true;
		CharacterGasDebugComponent.RecordStartTime = Singleton<Time>.Instance.WorldTimeSeconds;
		CharacterGasDebugComponent.RecordStartTimeStamp = Singleton<Time>.Instance.ServerTimeStamp;
		CharacterGasDebugComponent.SetDamageRecord(true);
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.OnChangeRole;
		Action<EntityHandle, EntityHandle> handle;
		if ((handle = CharacterGasDebugComponent.<>O.<0>__OnChangeRole) == null)
		{
			handle = (CharacterGasDebugComponent.<>O.<0>__OnChangeRole = new Action<EntityHandle, EntityHandle>(CharacterGasDebugComponent.OnChangeRole));
		}
		instance.Add<EntityHandle, EntityHandle>(name, handle);
		CharacterGasDebugComponent.DamageRecordDspMap = null;
		CharacterGasDebugComponent.OnChangeRoleInternal(Global.BaseCharacter.EntityId, true, false);
		EventSystem instance2 = Singleton<EventSystem>.Instance;
		EEventName name2 = EEventName.OnAbsoluteTimeStop;
		Action<bool, float> handle2;
		if ((handle2 = CharacterGasDebugComponent.<>O.<1>__OnAbsoluteTimeStop) == null)
		{
			handle2 = (CharacterGasDebugComponent.<>O.<1>__OnAbsoluteTimeStop = new Action<bool, float>(CharacterGasDebugComponent.OnAbsoluteTimeStop));
		}
		instance2.Add<bool, float>(name2, handle2);
	}

	// Token: 0x060188B4 RID: 100532 RVA: 0x006E4338 File Offset: 0x006E2538
	public static string EndRecord()
	{
		if (CharacterGasDebugComponent.ShouldRecord)
		{
			CharacterGasDebugComponent.ShouldRecord = false;
			CharacterGasDebugComponent.SetDamageRecord(false);
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnChangeRole;
			Action<EntityHandle, EntityHandle> handle;
			if ((handle = CharacterGasDebugComponent.<>O.<0>__OnChangeRole) == null)
			{
				handle = (CharacterGasDebugComponent.<>O.<0>__OnChangeRole = new Action<EntityHandle, EntityHandle>(CharacterGasDebugComponent.OnChangeRole));
			}
			instance.Remove(name, handle);
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.OnAbsoluteTimeStop;
			Action<bool, float> handle2;
			if ((handle2 = CharacterGasDebugComponent.<>O.<1>__OnAbsoluteTimeStop) == null)
			{
				handle2 = (CharacterGasDebugComponent.<>O.<1>__OnAbsoluteTimeStop = new Action<bool, float>(CharacterGasDebugComponent.OnAbsoluteTimeStop));
			}
			instance2.Remove(name2, handle2);
			string result = CharacterGasDebugComponent.Output();
			CharacterGasDebugComponent.CleanupRecord();
			return result;
		}
		return "";
	}

	// Token: 0x1700211C RID: 8476
	// (get) Token: 0x060188B5 RID: 100533 RVA: 0x006E43BE File Offset: 0x006E25BE
	private static List<string> MoveRecordStrings
	{
		get
		{
			return CharacterGasDebugComponent._moveRecordStrings;
		}
	}

	// Token: 0x1700211D RID: 8477
	// (get) Token: 0x060188B6 RID: 100534 RVA: 0x006E43C5 File Offset: 0x006E25C5
	private static List<string> DamageRecordStrings
	{
		get
		{
			return CharacterGasDebugComponent._damageRecordStrings;
		}
	}

	// Token: 0x1700211E RID: 8478
	// (get) Token: 0x060188B7 RID: 100535 RVA: 0x006E43CC File Offset: 0x006E25CC
	private static Dictionary<int, RecordMoveSum> MoveSumTable
	{
		get
		{
			return CharacterGasDebugComponent._moveSumTable;
		}
	}

	// Token: 0x1700211F RID: 8479
	// (get) Token: 0x060188B8 RID: 100536 RVA: 0x006E43D3 File Offset: 0x006E25D3
	private static Dictionary<string, RecordDamageSum> RoleDamageSumTable
	{
		get
		{
			return CharacterGasDebugComponent._roleDamageSumTable;
		}
	}

	// Token: 0x17002120 RID: 8480
	// (get) Token: 0x060188B9 RID: 100537 RVA: 0x006E43DA File Offset: 0x006E25DA
	private static Dictionary<string, RecordDamageSum> MonsterDamageSumTable
	{
		get
		{
			return CharacterGasDebugComponent._monsterDamageSumTable;
		}
	}

	// Token: 0x17002121 RID: 8481
	// (get) Token: 0x060188BA RID: 100538 RVA: 0x006E43E1 File Offset: 0x006E25E1
	private static Dictionary<int, string[]> BulletCreateMap
	{
		get
		{
			return CharacterGasDebugComponent._bulletCreateMap;
		}
	}

	// Token: 0x17002122 RID: 8482
	// (get) Token: 0x060188BB RID: 100539 RVA: 0x006E43E8 File Offset: 0x006E25E8
	private static List<int> BulletCreateEntityId
	{
		get
		{
			return CharacterGasDebugComponent._bulletCreateEntityId;
		}
	}

	// Token: 0x060188BC RID: 100540 RVA: 0x006E43F0 File Offset: 0x006E25F0
	private static string Output()
	{
		List<string> list = new List<string>();
		string text = "";
		string str = "X秒,当前时间,对象,对象ID,对象名称,技能ID,技能类型,攻击,暴击,爆伤,生命,防御,伤害加成\n";
		UKuroStaticLibrary.SaveStringToFile(str + string.Join("\n", CharacterGasDebugComponent.MoveRecordStrings), UBlueprintPathsLibrary.ProjectSavedDir() + "Statistics/FightDataRecord/SkillRecord.csv", true);
		List<string> list2 = new List<string>();
		str = "X秒,当前时间,对象,对象ID,对象名称,子弹ID,子弹名称,伤害ID,技能ID,技能类型,子弹是否命中\n";
		foreach (int num in CharacterGasDebugComponent.BulletCreateEntityId)
		{
			string[] array = CharacterGasDebugComponent.BulletCreateMap[num];
			string[] array2 = new string[array.Length + 1];
			Array.Copy(array, array2, array.Length);
			array2[array.Length] = (ModelBase<BulletModel>.Instance.IsBulletHit(num) ? "1" : "0");
			list2.Add(string.Join(",", array2));
		}
		UKuroStaticLibrary.SaveStringToFile(str + string.Join("\n", list2), UBlueprintPathsLibrary.ProjectSavedDir() + "Statistics/FightDataRecord/BulletRecord.csv", true);
		str = "X秒,当前时间,对象,对象ID,对象名称,伤害来源,结算ID,子弹名称,伤害值,技能ID,技能名称,唯一ID,Config ID,攻击,暴击,爆伤,生命,防御,伤害加成\n";
		UKuroStaticLibrary.SaveStringToFile(str + string.Join("\n", CharacterGasDebugComponent.DamageRecordStrings), UBlueprintPathsLibrary.ProjectSavedDir() + "Statistics/FightDataRecord/DamageRecord.csv", true);
		str = "X秒,当前时间,对象,对象ID,对象名称,伤害来源,结算ID,子弹名称,伤害值,期望伤害,技能ID,技能名称,是否暴击,唯一ID,当前生命值,生命值上限,攻击,暴击,暴击伤害,防御,共鸣效率,共鸣能量上限,共鸣能量,普攻速度,重击速度,共鸣技能伤害加成,通用伤害加成,声骸技能伤害加成,普攻伤害加成,蓄力攻击伤害加成,共鸣解放伤害加成,连携技能伤害加成,物理伤害加成,冷凝伤害加成,热熔伤害加成,导电伤害加成,气动伤害加成,衍射伤害加成,解离伤害加成,物理伤害抗性,冷凝伤害抗性,热熔伤害抗性,导电伤害抗性,气动伤害抗性,衍射伤害抗性,解离伤害抗性,治疗效果加成,受治疗效果加成,通用受伤减免,物理伤害减免,冷凝伤害减免,热熔伤害减免,导电伤害减免,气动伤害减免,衍射伤害减免,解离伤害减免,韧性上限,韧性,韧性恢复速度,削韧倍率,被削韧倍率,狂暴上限,狂暴,狂暴恢复,空狂暴惩罚时间,破狂暴倍率,被破狂暴倍率,共振度上限,共振度上限,共振度恢复速度,空共振度惩罚时间,破共振度倍率,被破共振度倍率,削刃,大招能量,元素能量类型,元素能量,存在的BuffID,存在的Buff名称,存在的BuffID,存在的Buff名称\n";
		UKuroStaticLibrary.SaveStringToFile(str + string.Join("\n", CharacterGasDebugComponent.DamageRecordAttrArray), UBlueprintPathsLibrary.ProjectSavedDir() + "Statistics/FightDataRecord/DamageRecord_Attr.csv", true);
		str = "X秒,当前时间,对象,对象ID,对象名称,伤害来源,结算ID,子弹名称,伤害值,技能ID,技能名称,唯一ID,是否暴击,当前生命值,生命值上限,攻击,暴击,暴击伤害,防御,共鸣效率,共鸣能量上限,共鸣能量,普攻速度,重击速度,共鸣技能伤害加成,通用伤害加成,声骸技能伤害加成,普攻伤害加成,蓄力攻击伤害加成,共鸣解放伤害加成,连携技能伤害加成,物理伤害加成,冷凝伤害加成,热熔伤害加成,导电伤害加成,气动伤害加成,衍射伤害加成,解离伤害加成,物理伤害抗性,冷凝伤害抗性,热熔伤害抗性,导电伤害抗性,气动伤害抗性,衍射伤害抗性,解离伤害抗性,治疗效果加成,受治疗效果加成,通用受伤减免,物理伤害减免,冷凝伤害减免,热熔伤害减免,导电伤害减免,气动伤害减免,衍射伤害减免,解离伤害减免,韧性上限,韧性,韧性恢复速度,削韧倍率,被削韧倍率,狂暴上限,狂暴,狂暴恢复,空狂暴惩罚时间,破狂暴倍率,被破狂暴倍率,共振度上限,共振度上限,共振度恢复速度,空共振度惩罚时间,破共振度倍率,被破共振度倍率,削刃,大招能量,元素能量类型,元素能量,存在的BuffID,存在的Buff名称,存在的BuffID,存在的Buff名称\n";
		UKuroStaticLibrary.SaveStringToFile(str + string.Join("\n", CharacterGasDebugComponent.DamageRecordSnipeshotArray), UBlueprintPathsLibrary.ProjectSavedDir() + "Statistics/FightDataRecord/DamageRecord_Snipeshot.csv", true);
		str = "X秒,当前时间,对象,对象ID,对象名称,BuffId,Buff名称,添加or删除\n";
		string text2 = str + string.Join("\n", CharacterGasDebugComponent.BuffRecordArray);
		UKuroStaticLibrary.SaveStringToFile(text2, UBlueprintPathsLibrary.ProjectSavedDir() + "Statistics/FightDataRecord/BuffRecord.csv", true);
		foreach (RecordMoveSum recordMoveSum in CharacterGasDebugComponent.MoveSumTable.Values)
		{
			list.Add(string.Join(",", recordMoveSum.ToCsv()));
		}
		str = "对象ID,对象名称,唯一Id,普攻,蓄力,E技能,大招,QTE,极限闪避反击,地面闪避,极限闪避,被动技能,战斗幻想技,探索幻象技,空中闪避\n";
		text2 = str + string.Join("\n", list);
		UKuroStaticLibrary.SaveStringToFile(text2, UBlueprintPathsLibrary.ProjectSavedDir() + "Statistics/FightDataRecord/MoveSum.csv", true);
		list.Clear();
		text = text + text2 + "\n";
		str = "角色ID,角色名称,受伤来源ConfigId,受伤来源名称,受伤来源唯一ID,总伤害,普攻,蓄力,E技能,大招,QTE,极限闪避反击,地面闪避,极限闪避,被动技能,战斗幻想技,探索幻象技,空中闪避\n";
		foreach (RecordDamageSum recordDamageSum in CharacterGasDebugComponent.RoleDamageSumTable.Values)
		{
			list.Add(string.Join(",", recordDamageSum.ToCsvForRole()));
		}
		text2 = str + string.Join("\n", list);
		UKuroStaticLibrary.SaveStringToFile(text2, UBlueprintPathsLibrary.ProjectSavedDir() + "Statistics/FightDataRecord/RoleDamageSum.csv", true);
		list.Clear();
		text = text + text2 + "\n";
		str = "怪物ConfigID,怪物名称,怪物唯一Id,攻击者ConfigId,攻击者名称,总伤害,普攻,蓄力,E技能,大招,QTE,极限闪避反击,地面闪避,极限闪避,被动技能,战斗幻想技,探索幻象技,空中闪避\n";
		foreach (RecordDamageSum recordDamageSum2 in CharacterGasDebugComponent.MonsterDamageSumTable.Values)
		{
			list.Add(string.Join(",", recordDamageSum2.ToCsvForMonster()));
		}
		text2 = str + string.Join("\n", list);
		UKuroStaticLibrary.SaveStringToFile(text2, UBlueprintPathsLibrary.ProjectSavedDir() + "Statistics/FightDataRecord/MonsterDamageSum.csv", true);
		list.Clear();
		text = text + text2 + "\n";
		CharacterGasDebugComponent.SaveRoleDsp();
		return text;
	}

	// Token: 0x060188BD RID: 100541 RVA: 0x006E47A8 File Offset: 0x006E29A8
	private static void SaveRoleDsp()
	{
		bool isPlayInEditor = Singleton<Info>.Instance.IsPlayInEditor;
	}

	// Token: 0x060188BE RID: 100542 RVA: 0x006E47B5 File Offset: 0x006E29B5
	private bool CheckDistance(Entity entity)
	{
		return CharacterStatisticsComponent.IsInRecordArea(entity);
	}

	// Token: 0x060188BF RID: 100543 RVA: 0x006E47BD File Offset: 0x006E29BD
	private static string DamageIdToDesc(long damageId)
	{
		if (CharacterGasDebugComponent.DamageIdToString.ContainsKey(damageId))
		{
			return CharacterGasDebugComponent.DamageIdToString[damageId];
		}
		return damageId.ToString();
	}

	// Token: 0x060188C0 RID: 100544 RVA: 0x006E47E0 File Offset: 0x006E29E0
	public static void RecordDamage(Entity attackerEntity, DamageRecordNotify data, string secondSinceStartup, string currTimeString)
	{
		List<string> list = new List<string>();
		list.Add(secondSinceStartup);
		list.Add(currTimeString);
		CharacterGasDebugComponent.EntityInfo entityInfo = CharacterGasDebugComponent.GetEntityInfo(attackerEntity);
		if (entityInfo == null)
		{
			return;
		}
		list.Add(entityInfo.Type);
		list.Add(entityInfo.ConfigId);
		list.Add(entityInfo.Name);
		if (attackerEntity.GetComponent<RoleGrowComponent>() != null)
		{
			list.Add("角色");
		}
		else
		{
			CreatureDataComponent component = attackerEntity.GetComponent<CreatureDataComponent>();
			if (component != null && component.GetEntityType() == EEntityType.SceneEntity)
			{
				list.Add("场景伤害");
			}
			else
			{
				list.Add("怪物");
			}
		}
		list.Add(CharacterGasDebugComponent.DamageIdToDesc(data.DamageConfId));
		BulletDataMain bulletData = ConfigBase<BulletConfig>.Instance.GetBulletData(attackerEntity, data.BulletId.ToString(), false);
		Entity entity = null;
		if (bulletData == null)
		{
			int customEntityId = ControllerBase<WorldController>.Instance.GetCustomEntityId(attackerEntity.Id, 1);
			entity = Singleton<EntitySystem>.Instance.Get(customEntityId);
			if (entity != null && entity.Valid)
			{
				bulletData = ConfigBase<BulletConfig>.Instance.GetBulletData(entity, data.BulletId.ToString(), true);
			}
		}
		int skillId = (int)data.SkillId;
		list.Add(((bulletData != null) ? bulletData.BulletName : null) ?? "");
		list.Add(data.DamageValue.ToString("F0"));
		list.Add(skillId.ToString("F0"));
		BaseSkillComponent component2 = attackerEntity.GetComponent<BaseSkillComponent>();
		SSkillInfo sskillInfo = (component2 != null) ? component2.GetSkillInfo(skillId) : null;
		if (sskillInfo == null)
		{
			SSkillInfo sskillInfo2;
			if (entity == null)
			{
				sskillInfo2 = null;
			}
			else
			{
				BaseSkillComponent component3 = entity.GetComponent<BaseSkillComponent>();
				sskillInfo2 = ((component3 != null) ? component3.GetSkillInfo(skillId) : null);
			}
			sskillInfo = sskillInfo2;
		}
		list.Add(((sskillInfo != null) ? sskillInfo.SkillName.ToString() : null) ?? "");
		list.Add(data.Attacker.EntityId.ToString());
		string item = attackerEntity.GetComponent<CreatureDataComponent>().GetPbDataId().ToString();
		list.Add(item);
		int count = list.Count;
		foreach (GameplayAttributeData gameplayAttributeData in data.Victim.Attr)
		{
			if (gameplayAttributeData.AttributeType == 7)
			{
				while (list.Count <= count)
				{
					list.Add("");
				}
				list[count] = gameplayAttributeData.CurrentValue.ToString("F0");
			}
			else if (gameplayAttributeData.AttributeType == 8)
			{
				while (list.Count <= count + 1)
				{
					list.Add("");
				}
				list[count + 1] = gameplayAttributeData.CurrentValue.ToString("F0");
			}
			else if (gameplayAttributeData.AttributeType == 9)
			{
				while (list.Count <= count + 2)
				{
					list.Add("");
				}
				list[count + 2] = gameplayAttributeData.CurrentValue.ToString("F0");
			}
			else if (gameplayAttributeData.AttributeType == 3)
			{
				while (list.Count <= count + 3)
				{
					list.Add("");
				}
				list[count + 3] = gameplayAttributeData.CurrentValue.ToString("F0");
			}
			else if (gameplayAttributeData.AttributeType == 10)
			{
				while (list.Count <= count + 4)
				{
					list.Add("");
				}
				list[count + 4] = gameplayAttributeData.CurrentValue.ToString("F0");
			}
			else if (gameplayAttributeData.AttributeType == 15)
			{
				while (list.Count <= count + 5)
				{
					list.Add("");
				}
				list[count + 5] = gameplayAttributeData.CurrentValue.ToString("F0");
			}
		}
		CharacterGasDebugComponent.DamageRecordStrings.Add(string.Join(",", list));
		int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(Singleton<MathUtils>.Instance.LongToNumber(data.Victim.EntityId));
		Entity target = Singleton<EntitySystem>.Instance.Get(entityId);
		float damageMagnitude = (float)data.DamageValue;
		TEnumAsByte<ESkillGenre>? tenumAsByte = (sskillInfo != null) ? new TEnumAsByte<ESkillGenre>?(sskillInfo.SkillGenre) : null;
		CharacterGasDebugComponent.RecordDamageSumTable(target, attackerEntity, damageMagnitude, (tenumAsByte != null) ? new ESkillGenre?(tenumAsByte.GetValueOrDefault()) : null);
	}

	// Token: 0x060188C1 RID: 100545 RVA: 0x006E4C70 File Offset: 0x006E2E70
	private void OnBulletCreate(BulletInfo bulletInfo)
	{
		if (!CharacterGasDebugComponent.ShouldRecord)
		{
			return;
		}
		Entity attacker = bulletInfo.Attacker;
		if (!this.CheckDistance(attacker))
		{
			return;
		}
		List<string> list = new List<string>();
		list.Add(CharacterGasDebugComponent.SecondsSinceStartup());
		list.Add(CharacterGasDebugComponent.TimeStringFromStamp(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()));
		CreatureDataComponent component = attacker.GetComponent<CreatureDataComponent>();
		EEntityType entityType = component.GetEntityType();
		if (entityType == EEntityType.Player)
		{
			list.Add("角色");
			list.Add(component.GetPbDataId().ToString("F0"));
			int id = component.Valid ? component.GetRoleId() : 0;
			int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(id);
			if (baseRoleId == 0)
			{
				return;
			}
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(baseRoleId);
			string item = (roleConfig != null) ? ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name) : "";
			list.Add(item);
		}
		else if (entityType == EEntityType.Monster)
		{
			list.Add("怪物");
			list.Add(component.GetPbDataId().ToString("F0"));
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(component.GetEntityTidName() ?? "");
			list.Add(configTextByKey);
		}
		else
		{
			if (entityType != EEntityType.Vehicle)
			{
				return;
			}
			if (!CharacterGasDebugComponent.IsMoto(attacker))
			{
				return;
			}
			string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey(component.GetEntityTidName() ?? "");
			list.Add("摩托车");
			list.Add(component.GetPbDataId().ToString("F0"));
			list.Add(configTextByKey2);
		}
		list.Add(bulletInfo.BulletRowName);
		BulletDataMain bulletDataMain = bulletInfo.BulletDataMain;
		list.Add(((bulletDataMain != null) ? bulletDataMain.BulletName : null) ?? "0");
		list.Add(bulletInfo.CollisionInfo.DamageId.ToString());
		int skillId = bulletInfo.BulletInitParams.SkillId;
		list.Add((skillId != 0) ? skillId.ToString() : "");
		BaseSkillComponent component2 = attacker.GetComponent<BaseSkillComponent>();
		SSkillInfo sskillInfo = (skillId != 0) ? component2.GetSkillInfo(skillId) : null;
		int num = (sskillInfo != null) ? ((int)sskillInfo.SkillGenre) : -1;
		List<string> list2 = list;
		string item2;
		if (num < 0 || num >= Enum.GetNames<ESkillGenreName>().Length)
		{
			item2 = "";
		}
		else
		{
			ESkillGenreName eskillGenreName = (ESkillGenreName)num;
			item2 = eskillGenreName.ToString();
		}
		list2.Add(item2);
		int id2 = bulletInfo.Entity.Id;
		CharacterGasDebugComponent.BulletCreateMap[id2] = list.ToArray();
		CharacterGasDebugComponent.BulletCreateEntityId.Add(id2);
	}

	// Token: 0x060188C2 RID: 100546 RVA: 0x006E4F08 File Offset: 0x006E3108
	private static void RecordDamageSumTable([Nullable(2)] Entity target, Entity source, float damageMagnitude, ESkillGenre? skillGenre)
	{
		Dictionary<string, RecordDamageSum> dictionary = CharacterGasDebugComponent.RoleDamageSumTable;
		if (((target != null) ? target.GetComponent<RoleGrowComponent>() : null) == null)
		{
			dictionary = CharacterGasDebugComponent.MonsterDamageSumTable;
		}
		string key = target.Id.ToString() + source.Id.ToString();
		RecordDamageSum recordDamageSum = dictionary.ContainsKey(key) ? dictionary[key] : null;
		if (recordDamageSum != null)
		{
			recordDamageSum.TotalDamage += (int)damageMagnitude;
			if (skillGenre != null)
			{
				int num = recordDamageSum.RecordDamage.ContainsKey(skillGenre.Value) ? recordDamageSum.RecordDamage[skillGenre.Value] : 0;
				recordDamageSum.RecordDamage[skillGenre.Value] = num + (int)damageMagnitude;
				return;
			}
		}
		else
		{
			RecordDamageSum recordDamageSum2 = new RecordDamageSum();
			int? num2;
			if (target == null)
			{
				num2 = null;
			}
			else
			{
				CreatureDataComponent component = target.GetComponent<CreatureDataComponent>();
				num2 = ((component != null) ? new int?(component.GetPbDataId()) : null);
			}
			int? num3 = num2;
			recordDamageSum2.ConfigId = num3.GetValueOrDefault();
			recordDamageSum2.UniqueId = target.Id;
			RecordDamageSum recordDamageSum3 = recordDamageSum2;
			string text;
			if (target == null)
			{
				text = null;
			}
			else
			{
				BaseActorComponent component2 = target.GetComponent<BaseActorComponent>();
				if (component2 == null)
				{
					text = null;
				}
				else
				{
					AActor owner = component2.Owner;
					text = ((owner != null) ? owner.GetName() : null);
				}
			}
			recordDamageSum3.Name = (text ?? "");
			CreatureDataComponent component3 = source.GetComponent<CreatureDataComponent>();
			recordDamageSum2.DamageSourceConfigId = ((component3 != null) ? new int?(component3.GetPbDataId()) : null).GetValueOrDefault();
			RecordDamageSum recordDamageSum4 = recordDamageSum2;
			BaseActorComponent component4 = source.GetComponent<BaseActorComponent>();
			string text2;
			if (component4 == null)
			{
				text2 = null;
			}
			else
			{
				AActor owner2 = component4.Owner;
				text2 = ((owner2 != null) ? owner2.GetName() : null);
			}
			recordDamageSum4.SourceName = (text2 ?? "");
			recordDamageSum2.SourceUniqueId = source.Id;
			recordDamageSum2.TotalDamage = (int)damageMagnitude;
			if (skillGenre != null)
			{
				int num4 = recordDamageSum2.RecordDamage.ContainsKey(skillGenre.Value) ? recordDamageSum2.RecordDamage[skillGenre.Value] : 0;
				recordDamageSum2.RecordDamage[skillGenre.Value] = num4 + (int)damageMagnitude;
			}
			dictionary[key] = recordDamageSum2;
		}
	}

	// Token: 0x060188C3 RID: 100547 RVA: 0x006E5110 File Offset: 0x006E3310
	[NullableContext(2)]
	public void RecordMove(EntityHandle handle, int skillId, ESkillGenre skillGenre)
	{
		if (!CharacterGasDebugComponent.ShouldRecord)
		{
			return;
		}
		if (handle == null || !handle.Valid || !this.CheckDistance(base.Entity))
		{
			return;
		}
		Entity entity = base.Entity;
		List<string> list = new List<string>();
		list.Add(CharacterGasDebugComponent.SecondsSinceStartup());
		list.Add(CharacterGasDebugComponent.TimeStringFromStamp(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()));
		if (((entity != null) ? entity.GetComponent<RoleGrowComponent>() : null) != null)
		{
			list.Add("角色");
		}
		else
		{
			list.Add("怪物");
		}
		int? num;
		if (entity == null)
		{
			num = null;
		}
		else
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			num = ((component != null) ? new int?(component.GetPbDataId()) : null);
		}
		int? num2 = num;
		list.Add(num2.GetValueOrDefault().ToString("F0"));
		string text;
		if (entity == null)
		{
			text = null;
		}
		else
		{
			CharacterActorComponent component2 = entity.GetComponent<CharacterActorComponent>();
			text = ((component2 != null) ? component2.Actor.GetName() : null);
		}
		string item = text ?? "";
		list.Add(item);
		list.Add(skillId.ToString());
		List<string> list2 = list;
		string item2;
		if (skillGenre < ESkillGenre.普攻0 || (int)skillGenre >= Enum.GetNames<ESkillGenreName>().Length)
		{
			item2 = "";
		}
		else
		{
			ESkillGenreName eskillGenreName = (ESkillGenreName)skillGenre;
			item2 = eskillGenreName.ToString();
		}
		list2.Add(item2);
		BaseAttributeComponent component3 = entity.GetComponent<BaseAttributeComponent>();
		list.Add(component3.GetCurrentValue(EAttributeType.Atk).ToString("F0"));
		list.Add(component3.GetCurrentValue(EAttributeType.Crit).ToString("F0"));
		list.Add(component3.GetCurrentValue(EAttributeType.CritDamage).ToString("F0"));
		list.Add(component3.GetCurrentValue(EAttributeType.Life).ToString("F0"));
		list.Add(component3.GetCurrentValue(EAttributeType.Def).ToString("F0"));
		list.Add(component3.GetCurrentValue(EAttributeType.DamageChange).ToString("F0"));
		CharacterGasDebugComponent.MoveRecordStrings.Add(string.Join(",", list));
		CharacterGasDebugComponent.RecordMoveSumTable(entity, handle.Entity, skillGenre);
	}

	// Token: 0x060188C4 RID: 100548 RVA: 0x006E5328 File Offset: 0x006E3528
	[NullableContext(2)]
	private static void RecordMoveSumTable(Entity entity1, Entity entity2, ESkillGenre skillGenre)
	{
		string name = ((entity1 != null) ? entity1.GetComponent<CharacterActorComponent>().Actor.GetName() : null) ?? "";
		int num = (entity1 != null) ? entity1.GetComponent<CreatureDataComponent>().GetPbDataId() : 0;
		long num2 = (long)((entity2 != null) ? entity2.Id : 0);
		RecordMoveSum recordMoveSum = CharacterGasDebugComponent.MoveSumTable.ContainsKey(num + (int)num2) ? CharacterGasDebugComponent.MoveSumTable[num + (int)num2] : null;
		if (recordMoveSum != null)
		{
			int num3;
			recordMoveSum.RecordNum[skillGenre] = (recordMoveSum.RecordNum.TryGetValue(skillGenre, out num3) ? (num3 + 1) : 1);
			return;
		}
		RecordMoveSum recordMoveSum2 = new RecordMoveSum();
		recordMoveSum2.ConfigId = num;
		recordMoveSum2.Name = name;
		recordMoveSum2.TargetUniqueId = (int)num2;
		recordMoveSum2.RecordNum[skillGenre] = 1;
		CharacterGasDebugComponent.MoveSumTable[num + (int)num2] = recordMoveSum2;
	}

	// Token: 0x060188C5 RID: 100549 RVA: 0x006E53FC File Offset: 0x006E35FC
	private bool MatchBuffId(string searchStr, string buffId)
	{
		return string.IsNullOrEmpty(searchStr) || buffId.Contains(searchStr) || searchStr.Contains(buffId);
	}

	// Token: 0x060188C6 RID: 100550 RVA: 0x006E5418 File Offset: 0x006E3618
	public string GetServerBuffString()
	{
		EntityBattleInfoResponse serverDebugInfo = this.ServerDebugInfo;
		bool flag;
		if (serverDebugInfo == null)
		{
			flag = (null != null);
		}
		else
		{
			FightBuffComponentPb fightBuffComponentPb = serverDebugInfo.FightBuffComponentPb;
			flag = (((fightBuffComponentPb != null) ? fightBuffComponentPb.FightBuffInfos : null) != null);
		}
		if (!flag)
		{
			return "";
		}
		string text = "";
		foreach (FightBuffInformation fightBuffInformation in this.ServerDebugInfo.FightBuffComponentPb.FightBuffInfos)
		{
			long buffId = fightBuffInformation.BuffId;
			string instigatorId = fightBuffInformation.InstigatorId.ToString();
			BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, null);
			string desc = (buffDefinition != null) ? buffDefinition.Desc : "";
			text += this.GetServerBuffInfoString(buffId.ToString(), fightBuffInformation.HandleId, desc, fightBuffInformation.StackCount, fightBuffInformation.Level, fightBuffInformation.IsActive, instigatorId, fightBuffInformation.LeftDuration, fightBuffInformation.Duration);
		}
		if (this.ServerDebugInfo.FightBuffComponentPb.ListBuffEffectCd.Count > 0)
		{
			text += "\nCD : \n";
			foreach (BuffEffectCd buffEffectCd in this.ServerDebugInfo.FightBuffComponentPb.ListBuffEffectCd)
			{
				if (buffEffectCd.ListCdRemaining.Count > 0)
				{
					text = text + "[" + buffEffectCd.BuffId.ToString() + "] ";
					foreach (int num in buffEffectCd.ListCdRemaining)
					{
						text = text + num.ToString("F0") + ", ";
					}
				}
			}
		}
		return text;
	}

	// Token: 0x060188C7 RID: 100551 RVA: 0x006E5604 File Offset: 0x006E3804
	public float GetServerBuffRemainDuration(int handle)
	{
		EntityBattleInfoResponse serverDebugInfo = this.ServerDebugInfo;
		bool flag;
		if (serverDebugInfo == null)
		{
			flag = (null != null);
		}
		else
		{
			FightBuffComponentPb fightBuffComponentPb = serverDebugInfo.FightBuffComponentPb;
			flag = (((fightBuffComponentPb != null) ? fightBuffComponentPb.FightBuffInfos : null) != null);
		}
		if (!flag)
		{
			return -1f;
		}
		float result = -1f;
		foreach (FightBuffInformation fightBuffInformation in this.ServerDebugInfo.FightBuffComponentPb.FightBuffInfos)
		{
			if (fightBuffInformation.HandleId == handle)
			{
				result = fightBuffInformation.LeftDuration;
				break;
			}
		}
		return result;
	}

	// Token: 0x060188C8 RID: 100552 RVA: 0x006E5694 File Offset: 0x006E3894
	public float GetServerBuffTotalDuration(int handle)
	{
		EntityBattleInfoResponse serverDebugInfo = this.ServerDebugInfo;
		bool flag;
		if (serverDebugInfo == null)
		{
			flag = (null != null);
		}
		else
		{
			FightBuffComponentPb fightBuffComponentPb = serverDebugInfo.FightBuffComponentPb;
			flag = (((fightBuffComponentPb != null) ? fightBuffComponentPb.FightBuffInfos : null) != null);
		}
		if (!flag)
		{
			return -1f;
		}
		float result = 0f;
		foreach (FightBuffInformation fightBuffInformation in this.ServerDebugInfo.FightBuffComponentPb.FightBuffInfos)
		{
			if (fightBuffInformation.HandleId == handle)
			{
				result = fightBuffInformation.Duration;
				break;
			}
		}
		return result;
	}

	// Token: 0x060188C9 RID: 100553 RVA: 0x006E5724 File Offset: 0x006E3924
	public bool HasBuffRequest(int handle)
	{
		return this.HasRequestServerBuff.Contains(handle);
	}

	// Token: 0x060188CA RID: 100554 RVA: 0x006E5734 File Offset: 0x006E3934
	public bool HasServerBuff(int handle)
	{
		EntityBattleInfoResponse serverDebugInfo = this.ServerDebugInfo;
		bool flag;
		if (serverDebugInfo == null)
		{
			flag = (null != null);
		}
		else
		{
			FightBuffComponentPb fightBuffComponentPb = serverDebugInfo.FightBuffComponentPb;
			flag = (((fightBuffComponentPb != null) ? fightBuffComponentPb.FightBuffInfos : null) != null);
		}
		if (!flag)
		{
			return false;
		}
		using (IEnumerator<FightBuffInformation> enumerator = this.ServerDebugInfo.FightBuffComponentPb.FightBuffInfos.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.HandleId == handle)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060188CB RID: 100555 RVA: 0x006E57B4 File Offset: 0x006E39B4
	private string GetServerBuffInfoString(string id, int handle, string desc, int stackCount, int level, bool isActive, string instigatorId, float leftDuration, float duration)
	{
		return string.Concat(new string[]
		{
			"[",
			id,
			", ",
			handle.ToString(),
			"] ",
			stackCount.ToString(),
			"层,",
			level.ToString(),
			"级,",
			isActive ? "激活. " : "失效. ",
			"施:",
			instigatorId,
			". 时:",
			leftDuration.ToString("F1"),
			"/",
			duration.ToString(),
			". ",
			desc,
			"\n"
		});
	}

	// Token: 0x060188CC RID: 100556 RVA: 0x006E5880 File Offset: 0x006E3A80
	public string GetServerTagString()
	{
		string text = "";
		EntityBattleInfoResponse serverDebugInfo = this.ServerDebugInfo;
		if (((serverDebugInfo != null) ? serverDebugInfo.EntityBattleTagInfo : null) != null)
		{
			foreach (EntityBattleTagInfo entityBattleTagInfo in this.ServerDebugInfo.EntityBattleTagInfo)
			{
				text = string.Concat(new string[]
				{
					text,
					GameplayTagUtils.GetNameByTagId(entityBattleTagInfo.TagId),
					" ",
					entityBattleTagInfo.Count.ToString(),
					"\n"
				});
			}
		}
		EntityBattleInfoResponse serverDebugInfo2 = this.ServerDebugInfo;
		if (((serverDebugInfo2 != null) ? serverDebugInfo2.PlayerTagInfos : null) != null)
		{
			foreach (EntityBattleTagInfo entityBattleTagInfo2 in this.ServerDebugInfo.PlayerTagInfos)
			{
				text = string.Concat(new string[]
				{
					text,
					"[编] ",
					GameplayTagUtils.GetNameByTagId(entityBattleTagInfo2.TagId),
					" ",
					entityBattleTagInfo2.Count.ToString(),
					"\n"
				});
			}
		}
		return text;
	}

	// Token: 0x060188CD RID: 100557 RVA: 0x006E59C0 File Offset: 0x006E3BC0
	public string GetServerAttributeString()
	{
		EntityBattleInfoResponse serverDebugInfo = this.ServerDebugInfo;
		if (((serverDebugInfo != null) ? serverDebugInfo.Attributes : null) == null)
		{
			return "";
		}
		string text = "";
		foreach (GameplayAttributeData gameplayAttributeData in this.ServerDebugInfo.Attributes)
		{
			text = string.Concat(new string[]
			{
				text,
				gameplayAttributeData.AttributeType.ToString(),
				" ",
				((EAttributeType)gameplayAttributeData.AttributeType).ToString(),
				":[",
				gameplayAttributeData.BaseValue.ToString(),
				"][",
				gameplayAttributeData.CurrentValue.ToString(),
				"]\n"
			});
		}
		text += "\n队伍属性：\n";
		foreach (FormationAttr formationAttr in this.ServerDebugInfo.FormationAttrs)
		{
			text = string.Concat(new string[]
			{
				text,
				formationAttr.AttrId.ToString(),
				"=",
				formationAttr.CurrentValue.ToString(),
				"/",
				formationAttr.MaxValue.ToString(),
				"(",
				formationAttr.Ratio.ToString(),
				"/s)\n"
			});
		}
		return text;
	}

	// Token: 0x060188CE RID: 100558 RVA: 0x006E5B7C File Offset: 0x006E3D7C
	public string GetServerPartString()
	{
		EntityBattleInfoResponse serverDebugInfo = this.ServerDebugInfo;
		bool flag;
		if (serverDebugInfo == null)
		{
			flag = (null != null);
		}
		else
		{
			PartComponentPb partComponentPb = serverDebugInfo.PartComponentPb;
			flag = (((partComponentPb != null) ? partComponentPb.PartLifeInfos : null) != null);
		}
		if (!flag)
		{
			return "";
		}
		string text = "";
		foreach (PartInformation partInformation in this.ServerDebugInfo.PartComponentPb.PartLifeInfos)
		{
			text = string.Concat(new string[]
			{
				text,
				partInformation.PartId.ToString(),
				" :  ",
				partInformation.LifeValue.ToString("F1"),
				" / ",
				partInformation.LifeMax.ToString("F1"),
				", ",
				partInformation.Activated.ToString(),
				"\n"
			});
		}
		return text;
	}

	// Token: 0x060188CF RID: 100559 RVA: 0x006E5C84 File Offset: 0x006E3E84
	public string GetServerHateString()
	{
		EntityBattleInfoResponse serverDebugInfo = this.ServerDebugInfo;
		if (((serverDebugInfo != null) ? serverDebugInfo.HateList : null) == null)
		{
			return "";
		}
		string text = "";
		foreach (AiHateEntity aiHateEntity in this.ServerDebugInfo.HateList)
		{
			text = string.Concat(new string[]
			{
				text,
				aiHateEntity.EntityId.ToString(),
				" : ",
				aiHateEntity.HatredValue.ToString("F1"),
				"\n"
			});
		}
		return text;
	}

	// Token: 0x060188D0 RID: 100560 RVA: 0x006E5D38 File Offset: 0x006E3F38
	public string GetServerShieldString()
	{
		EntityBattleInfoResponse serverDebugInfo = this.ServerDebugInfo;
		if (((serverDebugInfo != null) ? serverDebugInfo.ShieldComponentPb : null) == null)
		{
			return "";
		}
		string text = "护盾总值: " + this.ServerDebugInfo.ShieldComponentPb.ShieldValueTotal.ToString() + "\n";
		foreach (ShieldInfoPb shieldInfoPb in this.ServerDebugInfo.ShieldComponentPb.ShieldInfoPbList)
		{
			text = string.Concat(new string[]
			{
				text,
				"[",
				shieldInfoPb.ConfigId.ToString(),
				",",
				shieldInfoPb.Handle.ToString(),
				"] ",
				shieldInfoPb.IsValid ? "生效" : "失效",
				", ",
				shieldInfoPb.ShieldValue.ToString(),
				",",
				shieldInfoPb.BuffHandle.ToString(),
				",",
				shieldInfoPb.Priority.ToString(),
				"\n"
			});
		}
		return text;
	}

	// Token: 0x060188D1 RID: 100561 RVA: 0x006E5E8C File Offset: 0x006E408C
	public HashSet<int> GetCltBuffHandleSet()
	{
		HashSet<int> result = new HashSet<int>();
		BaseBuffComponent component = base.Entity.GetComponent<BaseBuffComponent>();
		if (component != null)
		{
			IActiveBuff[] allBuffs = component.GetAllBuffs();
			if (allBuffs != null)
			{
				allBuffs.ToList<IActiveBuff>().ForEach(delegate(IActiveBuff buff)
				{
					result.Add(buff.Handle);
				});
			}
		}
		return result;
	}

	// Token: 0x060188D2 RID: 100562 RVA: 0x006E5EE4 File Offset: 0x006E40E4
	public void Union(HashSet<int> left, HashSet<int> right)
	{
		foreach (int item in right)
		{
			if (!left.Contains(item))
			{
				left.Add(item);
			}
		}
	}

	// Token: 0x060188D3 RID: 100563 RVA: 0x006E5F3C File Offset: 0x006E413C
	public void ServerDebugInfoRequest()
	{
		this.InnerRequestHandle++;
		int key = this.InnerRequestHandle;
		HashSet<int> cltBuffHandleSet = this.GetCltBuffHandleSet();
		List<int> list = new List<int>();
		foreach (int item in this.HasRequestServerBuff)
		{
			if (!cltBuffHandleSet.Contains(item))
			{
				list.Add(item);
			}
		}
		foreach (int item2 in list)
		{
			this.HasRequestServerBuff.Remove(item2);
		}
		this.WaitResponseBuff[key] = cltBuffHandleSet;
		EntityBattleInfoRequest entityBattleInfoRequest = EntityBattleInfoRequest.Create();
		entityBattleInfoRequest.EntityId = Singleton<MathUtils>.Instance.NumberToLong(ModelBase<CreatureModel>.Instance.GetCreatureDataId(base.Entity.Id));
		Singleton<Net>.Instance.Call<EntityBattleInfoResponse>(ERequestMessageId.EntityBattleInfoRequest, entityBattleInfoRequest, delegate(EntityBattleInfoResponse response, Net.CallbackStatus _)
		{
			if (this.WaitResponseBuff.ContainsKey(key))
			{
				this.Union(this.HasRequestServerBuff, this.WaitResponseBuff[key]);
				this.WaitResponseBuff.Remove(key);
			}
			if (response == null)
			{
				return;
			}
			this.ServerDebugInfo = response;
			this.ServerDebugInfoDirty = true;
		}, 0);
	}

	// Token: 0x17002123 RID: 8483
	// (get) Token: 0x060188D4 RID: 100564 RVA: 0x006E6070 File Offset: 0x006E4270
	private static List<string> BuffRecordArray
	{
		get
		{
			return CharacterGasDebugComponent._buffRecordArray;
		}
	}

	// Token: 0x060188D5 RID: 100565 RVA: 0x006E6078 File Offset: 0x006E4278
	public void OnBuffAdded(ActiveBuffInternal buff)
	{
		if (!CharacterGasDebugComponent.ShouldRecord)
		{
			return;
		}
		string[] array = this.OnBuffRecord(buff, "添加");
		if (array != null)
		{
			CharacterGasDebugComponent.BuffRecordArray.Add(string.Join(",", array));
		}
	}

	// Token: 0x060188D6 RID: 100566 RVA: 0x006E60B4 File Offset: 0x006E42B4
	public void OnBuffRemoved(ActiveBuffInternal buff)
	{
		if (!CharacterGasDebugComponent.ShouldRecord)
		{
			return;
		}
		string[] array = this.OnBuffRecord(buff, "删除");
		if (array != null)
		{
			CharacterGasDebugComponent.BuffRecordArray.Add(string.Join(",", array));
		}
	}

	// Token: 0x060188D7 RID: 100567 RVA: 0x006E60F0 File Offset: 0x006E42F0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private string[] OnBuffRecord(ActiveBuffInternal buff, string opt)
	{
		List<string> list = new List<string>();
		list.Add(CharacterGasDebugComponent.SecondsSinceStartup());
		list.Add(CharacterGasDebugComponent.TimeStringFromStamp(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()));
		Entity instigator = buff.GetInstigator();
		CharacterGasDebugComponent.EntityInfo entityInfo = (instigator != null) ? CharacterGasDebugComponent.GetEntityInfo(instigator) : null;
		if (entityInfo == null)
		{
			return null;
		}
		list.Add(entityInfo.Type);
		list.Add(entityInfo.ConfigId);
		list.Add(entityInfo.Name);
		list.Add(buff.Config.Id.ToString());
		list.Add(buff.Config.Desc);
		list.Add(opt);
		return list.ToArray();
	}

	// Token: 0x060188D8 RID: 100568 RVA: 0x006E61A0 File Offset: 0x006E43A0
	[return: Nullable(2)]
	private static CharacterGasDebugComponent.EntityInfo GetEntityInfo(Entity attacker)
	{
		CreatureDataComponent component = attacker.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return null;
		}
		EEntityType entityType = component.GetEntityType();
		if (entityType == EEntityType.Player)
		{
			int id = component.Valid ? component.GetRoleId() : 0;
			int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(id);
			if (baseRoleId == 0)
			{
				return null;
			}
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(baseRoleId);
			string name = (roleConfig != null) ? ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name) : "";
			return new CharacterGasDebugComponent.EntityInfo
			{
				Name = name,
				Type = "角色",
				ConfigId = component.GetPbDataId().ToString()
			};
		}
		else
		{
			if (entityType == EEntityType.Monster)
			{
				string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(component.GetEntityTidName() ?? "");
				return new CharacterGasDebugComponent.EntityInfo
				{
					Name = configTextByKey,
					Type = "怪物",
					ConfigId = component.GetPbDataId().ToString()
				};
			}
			if (entityType == EEntityType.SceneEntity)
			{
				string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey(component.GetEntityTidName() ?? "");
				return new CharacterGasDebugComponent.EntityInfo
				{
					Name = configTextByKey2,
					Type = "场景实体",
					ConfigId = component.GetPbDataId().ToString()
				};
			}
			if (entityType == EEntityType.Vehicle && CharacterGasDebugComponent.IsMoto(attacker))
			{
				string configTextByKey3 = Singleton<PublicUtil>.Instance.GetConfigTextByKey(component.GetEntityTidName() ?? "");
				return new CharacterGasDebugComponent.EntityInfo
				{
					Name = configTextByKey3,
					Type = "摩托车",
					ConfigId = component.GetPbDataId().ToString()
				};
			}
			return null;
		}
	}

	// Token: 0x060188D9 RID: 100569 RVA: 0x006E6344 File Offset: 0x006E4544
	public static void SetDamageRecord(bool enable)
	{
		EnableDamageRecordRequest enableDamageRecordRequest = EnableDamageRecordRequest.Create();
		enableDamageRecordRequest.Enable = enable;
		Singleton<Net>.Instance.Call<EnableDamageRecordResponse>(ERequestMessageId.EnableDamageRecordRequest, enableDamageRecordRequest, delegate(EnableDamageRecordResponse response, Net.CallbackStatus _)
		{
		}, 0);
	}

	// Token: 0x060188DA RID: 100570 RVA: 0x006E6390 File Offset: 0x006E4590
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.DamageRecordNotify, true, false)]
	public static void OnDamageRecordNotify(Entity owner, [Nullable(1)] DamageRecordNotify data, CombatCommon combatCommon = null)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(ModelBase<CreatureModel>.Instance.GetEntityId(data.Attacker.EntityId));
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component == null || component.GetEntityType() != EEntityType.SceneEntity)
		{
			CreatureDataComponent component2 = entity.GetComponent<CreatureDataComponent>();
			if (component2 == null || component2.GetEntityType() != EEntityType.Vehicle || !CharacterGasDebugComponent.IsMoto(entity))
			{
				CharacterStatisticsComponent component3 = entity.GetComponent<CharacterStatisticsComponent>();
				if (component3 == null || !component3.GetStatisticsEnable())
				{
					return;
				}
			}
		}
		string secondSinceStartup = (((double)data.TimestampMs - CharacterGasDebugComponent.RecordStartTimeStamp) * 0.0010000000474974513 - (double)CharacterGasDebugComponent.TimeStopSpanTime).ToString("F2");
		string currTimeString = CharacterGasDebugComponent.TimeStringFromStamp(data.TimestampMs);
		CharacterGasDebugComponent.RecordDamage(entity, data, secondSinceStartup, currTimeString);
		CharacterGasDebugComponent.OnDamageRecordAttr(entity, data, secondSinceStartup, currTimeString);
		CharacterGasDebugComponent.OnDamageRecordSnapshot(entity, data, secondSinceStartup, currTimeString);
		CharacterGasDebugComponent.OnDamageRecordDsp(entity, data);
	}

	// Token: 0x060188DB RID: 100571 RVA: 0x006E646A File Offset: 0x006E466A
	private static bool IsMoto(Entity entity)
	{
		return entity.GetComponent<MotorcyclePerformComponent>() != null;
	}

	// Token: 0x060188DC RID: 100572 RVA: 0x006E6475 File Offset: 0x006E4675
	private static int RecordDspCompare(DamageRecordDsp a, DamageRecordDsp b)
	{
		return (int)(a.TimeStamp - b.TimeStamp);
	}

	// Token: 0x060188DD RID: 100573 RVA: 0x006E6488 File Offset: 0x006E4688
	private static void OnDamageRecordDsp(Entity attackerEntity, DamageRecordNotify data)
	{
		CreatureDataComponent component = attackerEntity.GetComponent<CreatureDataComponent>();
		if (component == null || component.GetEntityType() != EEntityType.Player)
		{
			return;
		}
		if (CharacterGasDebugComponent.DamageRecordDspMap == null)
		{
			CharacterGasDebugComponent.DamageRecordDspMap = new Dictionary<int, PriorityQueue<DamageRecordDsp>>();
		}
		int id = attackerEntity.Id;
		PriorityQueue<DamageRecordDsp> priorityQueue = CharacterGasDebugComponent.DamageRecordDspMap.ContainsKey(id) ? CharacterGasDebugComponent.DamageRecordDspMap[id] : null;
		if (priorityQueue == null)
		{
			Comparison<DamageRecordDsp> compare;
			if ((compare = CharacterGasDebugComponent.<>O.<2>__RecordDspCompare) == null)
			{
				compare = (CharacterGasDebugComponent.<>O.<2>__RecordDspCompare = new Comparison<DamageRecordDsp>(CharacterGasDebugComponent.RecordDspCompare));
			}
			priorityQueue = new PriorityQueue<DamageRecordDsp>(compare);
			CharacterGasDebugComponent.DamageRecordDspMap[id] = priorityQueue;
		}
		DamageRecordDsp item = new DamageRecordDsp((float)(Singleton<Time>.Instance.WorldTimeSeconds - (double)CharacterGasDebugComponent.TimeStopSpanTime), (float)data.DamageValue, false, false, false, false);
		priorityQueue.Push(item);
	}

	// Token: 0x060188DE RID: 100574 RVA: 0x006E6538 File Offset: 0x006E4738
	private void OnBeginSkill(int entityId, int skillId, bool isAutonomousProxy)
	{
		BaseSkillComponent component = base.Entity.GetComponent<BaseSkillComponent>();
		SSkillInfo sskillInfo = (component != null) ? component.GetSkillInfo(skillId) : null;
		if (CharacterGasDebugComponent.DamageRecordDspMap == null)
		{
			CharacterGasDebugComponent.DamageRecordDspMap = new Dictionary<int, PriorityQueue<DamageRecordDsp>>();
		}
		int id = base.Entity.Id;
		if (sskillInfo.SkillGenre == ESkillGenre.QTE4)
		{
			PriorityQueue<DamageRecordDsp> priorityQueue = CharacterGasDebugComponent.DamageRecordDspMap.ContainsKey(id) ? CharacterGasDebugComponent.DamageRecordDspMap[id] : null;
			if (priorityQueue == null)
			{
				Comparison<DamageRecordDsp> compare;
				if ((compare = CharacterGasDebugComponent.<>O.<2>__RecordDspCompare) == null)
				{
					compare = (CharacterGasDebugComponent.<>O.<2>__RecordDspCompare = new Comparison<DamageRecordDsp>(CharacterGasDebugComponent.RecordDspCompare));
				}
				priorityQueue = new PriorityQueue<DamageRecordDsp>(compare);
				CharacterGasDebugComponent.DamageRecordDspMap[id] = priorityQueue;
			}
			DamageRecordDsp item = new DamageRecordDsp((float)(Singleton<Time>.Instance.WorldTimeSeconds - (double)CharacterGasDebugComponent.TimeStopSpanTime), -1f, true, false, false, false);
			priorityQueue.Push(item);
			return;
		}
		if (sskillInfo.SkillGenre == ESkillGenre.退场技12)
		{
			PriorityQueue<DamageRecordDsp> priorityQueue2 = CharacterGasDebugComponent.DamageRecordDspMap.ContainsKey(id) ? CharacterGasDebugComponent.DamageRecordDspMap[id] : null;
			if (priorityQueue2 == null)
			{
				Comparison<DamageRecordDsp> compare2;
				if ((compare2 = CharacterGasDebugComponent.<>O.<2>__RecordDspCompare) == null)
				{
					compare2 = (CharacterGasDebugComponent.<>O.<2>__RecordDspCompare = new Comparison<DamageRecordDsp>(CharacterGasDebugComponent.RecordDspCompare));
				}
				priorityQueue2 = new PriorityQueue<DamageRecordDsp>(compare2);
				CharacterGasDebugComponent.DamageRecordDspMap[id] = priorityQueue2;
			}
			DamageRecordDsp item2 = new DamageRecordDsp((float)(Singleton<Time>.Instance.WorldTimeSeconds - (double)CharacterGasDebugComponent.TimeStopSpanTime), -1f, false, false, false, true);
			priorityQueue2.Push(item2);
		}
	}

	// Token: 0x060188DF RID: 100575 RVA: 0x006E6692 File Offset: 0x006E4892
	private static void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		CharacterGasDebugComponent.OnChangeRoleInternal(newEntity.Id, true, false);
		if (oldEntity != null)
		{
			CharacterGasDebugComponent.OnChangeRoleInternal(oldEntity.Id, false, true);
		}
	}

	// Token: 0x060188E0 RID: 100576 RVA: 0x006E66B4 File Offset: 0x006E48B4
	private static void OnChangeRoleInternal(int entityId, bool inGame, bool outGame)
	{
		if (CharacterGasDebugComponent.DamageRecordDspMap == null)
		{
			CharacterGasDebugComponent.DamageRecordDspMap = new Dictionary<int, PriorityQueue<DamageRecordDsp>>();
		}
		PriorityQueue<DamageRecordDsp> priorityQueue = CharacterGasDebugComponent.DamageRecordDspMap.ContainsKey(entityId) ? CharacterGasDebugComponent.DamageRecordDspMap[entityId] : null;
		if (priorityQueue == null)
		{
			Comparison<DamageRecordDsp> compare;
			if ((compare = CharacterGasDebugComponent.<>O.<2>__RecordDspCompare) == null)
			{
				compare = (CharacterGasDebugComponent.<>O.<2>__RecordDspCompare = new Comparison<DamageRecordDsp>(CharacterGasDebugComponent.RecordDspCompare));
			}
			priorityQueue = new PriorityQueue<DamageRecordDsp>(compare);
			CharacterGasDebugComponent.DamageRecordDspMap[entityId] = priorityQueue;
		}
		DamageRecordDsp item = new DamageRecordDsp((float)(Singleton<Time>.Instance.WorldTimeSeconds - (double)CharacterGasDebugComponent.TimeStopSpanTime), -1f, false, inGame, outGame, false);
		priorityQueue.Push(item);
	}

	// Token: 0x17002124 RID: 8484
	// (get) Token: 0x060188E1 RID: 100577 RVA: 0x006E6748 File Offset: 0x006E4948
	private static List<string> DamageRecordSnipeshotArray
	{
		get
		{
			return CharacterGasDebugComponent._damageRecordSnipeshotArray;
		}
	}

	// Token: 0x060188E2 RID: 100578 RVA: 0x006E6750 File Offset: 0x006E4950
	private unsafe static void OnDamageRecordSnapshot(Entity attackerEntity, DamageRecordNotify data, string secondSinceStartup, string currTimeString)
	{
		long damageConfId = data.DamageConfId;
		Damage? damageConfigById = ModelBase<DamageModel>.Instance.GetDamageConfigById(damageConfId);
		if (damageConfigById == null)
		{
			string item = "";
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "伤害配置为空";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("伤害ID", damageConfId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Name", item);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		Damage value = damageConfigById.Value;
		List<string> list = new List<string>();
		list.Add(secondSinceStartup);
		list.Add(currTimeString);
		CharacterGasDebugComponent.EntityInfo entityInfo = CharacterGasDebugComponent.GetEntityInfo(attackerEntity);
		if (entityInfo == null)
		{
			return;
		}
		list.Add(entityInfo.Type);
		list.Add(entityInfo.ConfigId);
		list.Add(entityInfo.Name);
		list.Add((data.DamageSourceType == DamageSourceType.FromBullet) ? "子弹" : "Buff");
		list.Add(CharacterGasDebugComponent.DamageIdToDesc(data.DamageConfId));
		BulletDataMain bulletData = ConfigBase<BulletConfig>.Instance.GetBulletData(attackerEntity, data.BulletId.ToString(), false);
		Entity entity = null;
		if (bulletData == null)
		{
			int customEntityId = ControllerBase<WorldController>.Instance.GetCustomEntityId(attackerEntity.Id, 1);
			entity = Singleton<EntitySystem>.Instance.Get(customEntityId);
			if (entity != null && entity.Valid)
			{
				bulletData = ConfigBase<BulletConfig>.Instance.GetBulletData(entity, data.BulletId.ToString(), true);
			}
		}
		list.Add(((bulletData != null) ? bulletData.BulletName : null) ?? "");
		list.Add(data.DamageValue.ToString("F0"));
		int skillId = (int)data.SkillId;
		list.Add(skillId.ToString("F0"));
		BaseSkillComponent component = attackerEntity.GetComponent<BaseSkillComponent>();
		string text;
		if (component == null)
		{
			text = null;
		}
		else
		{
			SSkillInfo skillInfo = component.GetSkillInfo(skillId);
			text = ((skillInfo != null) ? skillInfo.SkillName.ToString() : null);
		}
		string text2 = text;
		if (string.IsNullOrEmpty(text2))
		{
			string text3;
			if (entity == null)
			{
				text3 = null;
			}
			else
			{
				BaseSkillComponent component2 = entity.GetComponent<BaseSkillComponent>();
				if (component2 == null)
				{
					text3 = null;
				}
				else
				{
					SSkillInfo skillInfo2 = component2.GetSkillInfo(skillId);
					text3 = ((skillInfo2 != null) ? skillInfo2.SkillName.ToString() : null);
				}
			}
			text2 = text3;
		}
		list.Add(text2 ?? "");
		list.Add(data.Attacker.EntityId.ToString());
		list.Add(data.IsCritical ? "1" : "0");
		int count = list.Count;
		int num = CharacterGasDebugComponent.AttributeIdArray.Length;
		CharacterGasDebugComponent.ColletSnapshot(data.Victim.AttrSnapshot.ToArray<GameplayAttributeData>(), list, count);
		CharacterGasDebugComponent.ColletSnapshot(data.Attacker.AttrSnapshot.ToArray<GameplayAttributeData>(), list, count + num);
		int skillLevel = data.SkillLevel;
		int num2 = count + num * 2;
		int index = num2 + 1;
		int index2 = num2 + 2;
		int index3 = num2 + 3;
		int index4 = num2 + 4;
		int index5 = num2 + 5;
		int index6 = num2 + 6;
		int num3 = num2 + 7;
		while (list.Count <= num3)
		{
			list.Add("");
		}
		list[num2] = AbilityUtils.GetLevelValue<int>(value.GetToughLvArray(), skillLevel, 0).ToString();
		list[index] = AbilityUtils.GetLevelValue<int>(value.GetEnergyArray(), skillLevel, 0).ToString();
		list[index2] = value.ElementPowerType.ToString();
		list[index3] = AbilityUtils.GetLevelValue<int>(value.GetElementPowerArray(), skillLevel, 0).ToString();
		List<string> list2 = new List<string>();
		List<long> list3 = new List<long>();
		foreach (long num4 in data.Attacker.BuffIds)
		{
			BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(num4, null);
			list2.Add(((buffDefinition != null) ? buffDefinition.Desc : null) ?? "");
			list3.Add(num4);
		}
		list[index4] = string.Join<long>("|", list3);
		list[index5] = string.Join("|", list2);
		list2.Clear();
		list3.Clear();
		foreach (long num5 in data.Victim.BuffIds)
		{
			BuffDefinition buffDefinition2 = ControllerBase<BuffController>.Instance.GetBuffDefinition(num5, null);
			list2.Add(((buffDefinition2 != null) ? buffDefinition2.Desc : null) ?? "");
			list3.Add(num5);
		}
		list[index6] = string.Join<long>("|", list3);
		list[num3] = string.Join("|", list2);
		string item2 = string.Join(",", list);
		CharacterGasDebugComponent.DamageRecordSnipeshotArray.Add(item2);
	}

	// Token: 0x060188E3 RID: 100579 RVA: 0x006E6C54 File Offset: 0x006E4E54
	private static void ColletSnapshot(GameplayAttributeData[] attrsSnapshot, List<string> result, int baseIndexBase)
	{
		foreach (GameplayAttributeData gameplayAttributeData in attrsSnapshot)
		{
			int j = 0;
			int num = CharacterGasDebugComponent.AttributeIdArray.Length;
			while (j < num)
			{
				if (gameplayAttributeData.AttributeType == (int)CharacterGasDebugComponent.AttributeIdArray[j])
				{
					while (result.Count <= baseIndexBase + j)
					{
						result.Add("");
					}
					result[baseIndexBase + j] = CharacterGasDebugComponent.ResolveSnapshotValue(gameplayAttributeData).ToString();
					break;
				}
				j++;
			}
		}
	}

	// Token: 0x060188E4 RID: 100580 RVA: 0x006E6CC8 File Offset: 0x006E4EC8
	private static string TimeStringFromStamp(long timestampMs)
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds((double)Singleton<MathUtils>.Instance.LongToNumber(timestampMs));
		return StringUtils.Format("{0}月{1}日{2}:{3}:{4}:{5}", new string[]
		{
			(dateTime.Month - 1).ToString(),
			dateTime.Day.ToString(),
			dateTime.Hour.ToString(),
			dateTime.Minute.ToString(),
			dateTime.Second.ToString(),
			dateTime.Millisecond.ToString()
		});
	}

	// Token: 0x17002125 RID: 8485
	// (get) Token: 0x060188E5 RID: 100581 RVA: 0x006E6D78 File Offset: 0x006E4F78
	private static List<string> DamageRecordAttrArray
	{
		get
		{
			return CharacterGasDebugComponent._damageRecordAttrArray;
		}
	}

	// Token: 0x060188E6 RID: 100582 RVA: 0x006E6D80 File Offset: 0x006E4F80
	private unsafe static void OnDamageRecordAttr(Entity attackerEntity, DamageRecordNotify data, string secondSinceStartup, string currTimeString)
	{
		long damageConfId = data.DamageConfId;
		Damage? damageConfigById = ModelBase<DamageModel>.Instance.GetDamageConfigById(damageConfId);
		if (damageConfigById == null)
		{
			string item = "";
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "伤害配置为空";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("伤害ID", damageConfId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Name", item);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		Damage value = damageConfigById.Value;
		List<string> list = new List<string>();
		list.Add(secondSinceStartup);
		list.Add(currTimeString);
		CharacterGasDebugComponent.EntityInfo entityInfo = CharacterGasDebugComponent.GetEntityInfo(attackerEntity);
		if (entityInfo == null)
		{
			return;
		}
		list.Add(entityInfo.Type);
		list.Add(entityInfo.ConfigId);
		list.Add(entityInfo.Name);
		list.Add((data.DamageSourceType == DamageSourceType.FromBullet) ? "子弹" : "Buff");
		list.Add(CharacterGasDebugComponent.DamageIdToDesc(data.DamageConfId));
		BulletDataMain bulletData = ConfigBase<BulletConfig>.Instance.GetBulletData(attackerEntity, data.BulletId.ToString(), false);
		Entity entity = null;
		if (bulletData == null)
		{
			int customEntityId = ControllerBase<WorldController>.Instance.GetCustomEntityId(attackerEntity.Id, 1);
			entity = Singleton<EntitySystem>.Instance.Get(customEntityId);
			if (entity != null && entity.Valid)
			{
				bulletData = ConfigBase<BulletConfig>.Instance.GetBulletData(entity, data.BulletId.ToString(), true);
			}
		}
		list.Add(((bulletData != null) ? bulletData.BulletName : null) ?? "");
		list.Add(data.DamageValue.ToString("F0"));
		list.Add(data.DamageCalculationDetails.ExceptedDamageValue.ToString("F2"));
		int skillId = (int)data.SkillId;
		list.Add(skillId.ToString());
		BaseSkillComponent component = attackerEntity.GetComponent<BaseSkillComponent>();
		string text;
		if (component == null)
		{
			text = null;
		}
		else
		{
			SSkillInfo skillInfo = component.GetSkillInfo(skillId);
			text = ((skillInfo != null) ? skillInfo.SkillName.ToString() : null);
		}
		string text2 = text;
		if (string.IsNullOrEmpty(text2))
		{
			string text3;
			if (entity == null)
			{
				text3 = null;
			}
			else
			{
				BaseSkillComponent component2 = entity.GetComponent<BaseSkillComponent>();
				if (component2 == null)
				{
					text3 = null;
				}
				else
				{
					SSkillInfo skillInfo2 = component2.GetSkillInfo(skillId);
					text3 = ((skillInfo2 != null) ? skillInfo2.SkillName.ToString() : null);
				}
			}
			text2 = text3;
		}
		list.Add(text2 ?? "");
		list.Add(data.IsCritical ? "1" : "0");
		list.Add(data.Attacker.EntityId.ToString());
		int count = list.Count;
		list.Add("0");
		foreach (GameplayAttributeData gameplayAttributeData in data.Attacker.Attr)
		{
			if (gameplayAttributeData.AttributeType == 77)
			{
				list[count] = gameplayAttributeData.BaseValue.ToString("F0");
				break;
			}
		}
		DamageCalculationDetails damageCalculationDetails = data.DamageCalculationDetails;
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.ABaseAttackValue : 0L).ToString());
		list.Add((((damageCalculationDetails != null) ? damageCalculationDetails.ARate : 0f) * 100f).ToString("F2"));
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.ADamageFactor : 0f).ToString());
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.ADamageBonusRate : 0f).ToString());
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.HitDamageBonusRate : 0f).ToString());
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.VWeaknessBuffStack : 0).ToString());
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.WeakDamageBonusRate : 0f).ToString());
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.VDefFactor : 0f).ToString());
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.VResistanceFactor : 0f).ToString());
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.VEffectiveDefense : 0f).ToString());
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.AEnergyChange : 0L).ToString());
		list.Add((damageCalculationDetails != null && damageCalculationDetails.ACritChance != 0L) ? Singleton<MathUtils>.Instance.LongToNumber(damageCalculationDetails.ACritChance).ToString() : "0");
		list.Add(data.IsWeakness ? "1" : "0");
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.AWeaknessMasteryCoefficient : 0f).ToString());
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.VMonsterTypeRate : 0f).ToString());
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.VbDamageReduce : 0f).ToString());
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.VbElementReduce : 0f).ToString());
		list.Add(((damageCalculationDetails != null) ? damageCalculationDetails.WeaknessLvValue : 0f).ToString());
		count = list.Count;
		int num = CharacterGasDebugComponent.AttributeIdArray.Length;
		CharacterGasDebugComponent.CollectAttr(data.Attacker.Attr.ToArray<GameplayAttributeData>(), data.Attacker.AttrSnapshot.ToArray<GameplayAttributeData>(), list, count, count + num);
		CharacterGasDebugComponent.CollectAttr(data.Victim.Attr.ToArray<GameplayAttributeData>(), data.Victim.AttrSnapshot.ToArray<GameplayAttributeData>(), list, count + num * 2, count + num * 3);
		int skillLevel = data.SkillLevel;
		int num2 = count + num * 4;
		while (list.Count <= num2)
		{
			list.Add("");
		}
		list[num2] = AbilityUtils.GetLevelValue<int>(value.GetHardnessLvArray(), skillLevel, 0).ToString();
		list.Add(AbilityUtils.GetLevelValue<int>(value.GetPercent0Array(), skillLevel, 0).ToString());
		list.Add(AbilityUtils.GetLevelValue<int>(value.GetPercent1Array(), skillLevel, 0).ToString());
		list.Add(AbilityUtils.GetLevelValue<int>(value.GetToughLvArray(), skillLevel, 0).ToString());
		list.Add(AbilityUtils.GetLevelValue<int>(value.GetEnergyArray(), skillLevel, 0).ToString());
		list.Add(value.ElementPowerType.ToString());
		list.Add(AbilityUtils.GetLevelValue<int>(value.GetElementPowerArray(), skillLevel, 0).ToString());
		List<string> list2 = new List<string>();
		List<long> list3 = new List<long>();
		foreach (long num3 in data.Attacker.BuffIds)
		{
			BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(num3, null);
			list2.Add(((buffDefinition != null) ? buffDefinition.Desc : null) ?? "");
			list3.Add(num3);
		}
		list.Add(string.Join<long>("|", list3));
		list.Add(string.Join("|", list2));
		list2.Clear();
		list3.Clear();
		foreach (long num4 in data.Victim.BuffIds)
		{
			BuffDefinition buffDefinition2 = ControllerBase<BuffController>.Instance.GetBuffDefinition(num4, null);
			list2.Add(((buffDefinition2 != null) ? buffDefinition2.Desc : null) ?? "");
			list3.Add(num4);
		}
		list.Add(string.Join<long>("|", list3));
		list.Add(string.Join("|", list2));
		string item2 = string.Join(",", list);
		CharacterGasDebugComponent.DamageRecordAttrArray.Add(item2);
	}

	// Token: 0x060188E7 RID: 100583 RVA: 0x006E75D0 File Offset: 0x006E57D0
	private static int ResolveSnapshotValue(GameplayAttributeData attrSnapshot)
	{
		if (attrSnapshot.CurrentValue == -2147483648)
		{
			return 0;
		}
		if (attrSnapshot.CurrentValue == 0)
		{
			return attrSnapshot.BaseValue;
		}
		return attrSnapshot.CurrentValue;
	}

	// Token: 0x060188E8 RID: 100584 RVA: 0x006E75F8 File Offset: 0x006E57F8
	private static void CollectAttr(GameplayAttributeData[] attrs, GameplayAttributeData[] attrsSnapshot, List<string> result, int baseIndexCurrent, int baseIndexBase)
	{
		int i = 0;
		int num = CharacterGasDebugComponent.AttributeIdArray.Length;
		while (i < num)
		{
			foreach (GameplayAttributeData gameplayAttributeData in attrsSnapshot)
			{
				if (gameplayAttributeData.AttributeType == (int)CharacterGasDebugComponent.AttributeIdArray[i])
				{
					while (result.Count <= baseIndexCurrent + i)
					{
						result.Add("");
					}
					result[baseIndexCurrent + i] = CharacterGasDebugComponent.ResolveSnapshotValue(gameplayAttributeData).ToString();
					break;
				}
			}
			foreach (GameplayAttributeData gameplayAttributeData2 in attrs)
			{
				if (gameplayAttributeData2.AttributeType == (int)CharacterGasDebugComponent.AttributeIdArray[i])
				{
					while (result.Count <= baseIndexBase + i)
					{
						result.Add("");
					}
					result[baseIndexBase + i] = gameplayAttributeData2.BaseValue.ToString();
					break;
				}
			}
			i++;
		}
	}

	// Token: 0x060188E9 RID: 100585 RVA: 0x006E76D4 File Offset: 0x006E58D4
	public static void CleanupRecord()
	{
		CharacterGasDebugComponent.InTimeStop = false;
		CharacterGasDebugComponent.TimeStopSpanTime = 0f;
		CharacterGasDebugComponent.MoveRecordStrings.Clear();
		CharacterGasDebugComponent.DamageRecordStrings.Clear();
		CharacterGasDebugComponent.MoveSumTable.Clear();
		CharacterGasDebugComponent.RoleDamageSumTable.Clear();
		CharacterGasDebugComponent.MonsterDamageSumTable.Clear();
		CharacterGasDebugComponent.BulletCreateMap.Clear();
		CharacterGasDebugComponent.BulletCreateEntityId.Clear();
		CharacterGasDebugComponent.BuffRecordArray.Clear();
		Dictionary<int, PriorityQueue<DamageRecordDsp>> damageRecordDspMap = CharacterGasDebugComponent.DamageRecordDspMap;
		if (damageRecordDspMap != null)
		{
			damageRecordDspMap.Clear();
		}
		CharacterGasDebugComponent.DamageRecordSnipeshotArray.Clear();
		CharacterGasDebugComponent.DamageRecordAttrArray.Clear();
	}

	// Token: 0x060188EA RID: 100586 RVA: 0x006E7765 File Offset: 0x006E5965
	private static void OnAbsoluteTimeStop(bool open, float _)
	{
		CharacterGasDebugComponent.InTimeStop = open;
	}

	// Token: 0x060188EB RID: 100587 RVA: 0x006E7770 File Offset: 0x006E5970
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterGasDebugComponent characterGasDebugComponent = (CharacterGasDebugComponent)componentTemplate;
		if (base.CanResetComponentProperty("DebugGasComponent"))
		{
			if (characterGasDebugComponent.DebugGasComponent == null)
			{
				this.DebugGasComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UBaseAbilitySystemComponent>(this.DebugGasComponent), "DebugGasComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("EnableCollisionDebugDraw"))
		{
			this.EnableCollisionDebugDraw = characterGasDebugComponent.EnableCollisionDebugDraw;
		}
		if (base.CanResetComponentProperty("GeDebugId"))
		{
			this.GeDebugId = characterGasDebugComponent.GeDebugId;
		}
		if (base.CanResetComponentProperty("GeDebugTask"))
		{
			if (characterGasDebugComponent.GeDebugTask == null)
			{
				this.GeDebugTask = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UAsyncTaskEffectDebugString>(this.GeDebugTask), "GeDebugTask"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DebugStrings") && characterGasDebugComponent.DebugStrings != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<string>>(this.DebugStrings), "DebugStrings"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SkillLogStrings") && characterGasDebugComponent.SkillLogStrings != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<string>>(this.SkillLogStrings), "SkillLogStrings"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SkillBehaviorLogStrings") && characterGasDebugComponent.SkillBehaviorLogStrings != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<string>>(this.SkillBehaviorLogStrings), "SkillBehaviorLogStrings"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ShieldDebugStrings") && characterGasDebugComponent.ShieldDebugStrings != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<string>>(this.ShieldDebugStrings), "ShieldDebugStrings"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("BulletDebugStrings") && characterGasDebugComponent.BulletDebugStrings != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<string>>(this.BulletDebugStrings), "BulletDebugStrings"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("AttributeDebugStrings") && characterGasDebugComponent.AttributeDebugStrings != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<string>>(this.AttributeDebugStrings), "AttributeDebugStrings"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("MovementDebugStrings") && characterGasDebugComponent.MovementDebugStrings != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<string>>(this.MovementDebugStrings), "MovementDebugStrings"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ServerDebugInfo"))
		{
			if (characterGasDebugComponent.ServerDebugInfo == null)
			{
				this.ServerDebugInfo = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<EntityBattleInfoResponse>(this.ServerDebugInfo), "ServerDebugInfo"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ServerDebugInfoDirty"))
		{
			this.ServerDebugInfoDirty = characterGasDebugComponent.ServerDebugInfoDirty;
		}
		if (base.CanResetComponentProperty("HasRequestServerBuff") && characterGasDebugComponent.HasRequestServerBuff != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.HasRequestServerBuff), "HasRequestServerBuff"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("WaitResponseBuff") && characterGasDebugComponent.WaitResponseBuff != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, HashSet<int>>>(this.WaitResponseBuff), "WaitResponseBuff"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("InnerRequestHandle"))
		{
			this.InnerRequestHandle = characterGasDebugComponent.InnerRequestHandle;
		}
		return true;
	}

	// Token: 0x0400BDA9 RID: 48553
	[StaticVariableRuleIgnore]
	private static readonly StringBuilder Sb = new StringBuilder(256);

	// Token: 0x0400BDAA RID: 48554
	private const int MAX_DEBUG_STRING_NUMS = 50;

	// Token: 0x0400BDAB RID: 48555
	[Nullable(2)]
	private static EAttributeType[] _attributeIdArray;

	// Token: 0x0400BDAC RID: 48556
	[Nullable(2)]
	private UBaseAbilitySystemComponent DebugGasComponent;

	// Token: 0x0400BDAD RID: 48557
	public bool EnableCollisionDebugDraw;

	// Token: 0x0400BDAE RID: 48558
	private int GeDebugId;

	// Token: 0x0400BDAF RID: 48559
	[Nullable(2)]
	private UAsyncTaskEffectDebugString GeDebugTask;

	// Token: 0x0400BDB0 RID: 48560
	private readonly List<string> DebugStrings = new List<string>();

	// Token: 0x0400BDB1 RID: 48561
	private readonly List<string> SkillLogStrings = new List<string>();

	// Token: 0x0400BDB2 RID: 48562
	private readonly List<string> SkillBehaviorLogStrings = new List<string>();

	// Token: 0x0400BDB3 RID: 48563
	private readonly List<string> ShieldDebugStrings = new List<string>();

	// Token: 0x0400BDB4 RID: 48564
	private readonly List<string> BulletDebugStrings = new List<string>();

	// Token: 0x0400BDB5 RID: 48565
	private readonly List<string> AttributeDebugStrings = new List<string>();

	// Token: 0x0400BDB6 RID: 48566
	private readonly List<string> MovementDebugStrings = new List<string>();

	// Token: 0x0400BDB7 RID: 48567
	private static bool IsServerLogOnInternal = false;

	// Token: 0x0400BDB8 RID: 48568
	private static bool ShouldRecord = false;

	// Token: 0x0400BDB9 RID: 48569
	private static double RecordStartTime = 0.0;

	// Token: 0x0400BDBA RID: 48570
	private static double RecordStartTimeStamp = 0.0;

	// Token: 0x0400BDBB RID: 48571
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<string> _moveRecordStrings;

	// Token: 0x0400BDBC RID: 48572
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<string> _damageRecordStrings;

	// Token: 0x0400BDBD RID: 48573
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<int, RecordMoveSum> _moveSumTable;

	// Token: 0x0400BDBE RID: 48574
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<string, RecordDamageSum> _roleDamageSumTable;

	// Token: 0x0400BDBF RID: 48575
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<string, RecordDamageSum> _monsterDamageSumTable;

	// Token: 0x0400BDC0 RID: 48576
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<int, string[]> _bulletCreateMap;

	// Token: 0x0400BDC1 RID: 48577
	[Nullable(2)]
	private static List<int> _bulletCreateEntityId;

	// Token: 0x0400BDC2 RID: 48578
	private const string SavePath = "Statistics/FightDataRecord/";

	// Token: 0x0400BDC3 RID: 48579
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<long, string> DamageIdToString = new Dictionary<long, string>
	{
		{
			1001L,
			"1001(风蚀)"
		},
		{
			1002L,
			"1002(电磁)"
		},
		{
			1003L,
			"1003(霜渐)"
		},
		{
			1004L,
			"1004(聚爆)"
		},
		{
			1005L,
			"1005(光噪)"
		},
		{
			1006L,
			"1006(虚湮)"
		}
	};

	// Token: 0x0400BDC4 RID: 48580
	[Nullable(2)]
	public EntityBattleInfoResponse ServerDebugInfo;

	// Token: 0x0400BDC5 RID: 48581
	public bool ServerDebugInfoDirty;

	// Token: 0x0400BDC6 RID: 48582
	private readonly HashSet<int> HasRequestServerBuff = new HashSet<int>();

	// Token: 0x0400BDC7 RID: 48583
	private readonly Dictionary<int, HashSet<int>> WaitResponseBuff = new Dictionary<int, HashSet<int>>();

	// Token: 0x0400BDC8 RID: 48584
	private int InnerRequestHandle;

	// Token: 0x0400BDC9 RID: 48585
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<string> _buffRecordArray;

	// Token: 0x0400BDCA RID: 48586
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<int, PriorityQueue<DamageRecordDsp>> DamageRecordDspMap = null;

	// Token: 0x0400BDCB RID: 48587
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<string> _damageRecordSnipeshotArray;

	// Token: 0x0400BDCC RID: 48588
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<string> _damageRecordAttrArray;

	// Token: 0x0400BDCD RID: 48589
	private static bool InTimeStop = false;

	// Token: 0x0400BDCE RID: 48590
	private static float TimeStopSpanTime = 0f;

	// Token: 0x0400BDCF RID: 48591
	private static long FrameUpdateSpanTime = 0L;

	// Token: 0x02009319 RID: 37657
	[Nullable(0)]
	public class EntityInfo
	{
		// Token: 0x04030FB5 RID: 200629
		public string Name = "";

		// Token: 0x04030FB6 RID: 200630
		public string Type = "";

		// Token: 0x04030FB7 RID: 200631
		public string ConfigId = "";
	}

	// Token: 0x0200931A RID: 37658
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04030FB8 RID: 200632
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<EntityHandle, EntityHandle> <0>__OnChangeRole;

		// Token: 0x04030FB9 RID: 200633
		[Nullable(0)]
		public static Action<bool, float> <1>__OnAbsoluteTimeStop;

		// Token: 0x04030FBA RID: 200634
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Comparison<DamageRecordDsp> <2>__RecordDspCompare;
	}
}
