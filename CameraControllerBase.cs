using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02000E0A RID: 3594
[NullableContext(1)]
[Nullable(0)]
[GeneratePropertyAccessMethod(true)]
public abstract class CameraControllerBase<[Nullable(0)] T> : ICameraControllerBase where T : Enum
{
	// Token: 0x0600548C RID: 21644 RVA: 0x000CF030 File Offset: 0x000CD230
	protected CameraControllerBase(FightCameraLogicComponent camera)
	{
		this.Camera = camera;
		this.OnInit();
	}

	// Token: 0x170005B4 RID: 1460
	// (get) Token: 0x0600548D RID: 21645 RVA: 0x000CF0BA File Offset: 0x000CD2BA
	[Nullable(2)]
	protected CameraModelInstance CameraModel
	{
		[NullableContext(2)]
		get
		{
			return this.Camera.CameraModel;
		}
	}

	// Token: 0x0600548E RID: 21646 RVA: 0x000CF0C8 File Offset: 0x000CD2C8
	protected void SetConfigMap(T key, string value)
	{
		if (this.ConfigMap.ContainsKey(key))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "重复注册了Key";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Key", key);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		if (this.DebugValueSet.Contains(value))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Camera;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "重复注册了Value";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("value", value);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		this.ConfigMap[key] = value;
		this.DebugValueSet.Add(value);
	}

	// Token: 0x0600548F RID: 21647 RVA: 0x000CF15C File Offset: 0x000CD35C
	protected void SetCurveConfigMap(T key, string value)
	{
		if (this.CurveConfigMap.ContainsKey(key))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "重复注册了Key";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Key", key);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		if (this.DebugValueSet.Contains(value))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Camera;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "重复注册了Value";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("value", value);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		this.CurveConfigMap[key] = value;
		this.DebugValueSet.Add(value);
	}

	// Token: 0x06005490 RID: 21648 RVA: 0x000CF1F0 File Offset: 0x000CD3F0
	private void SetConfigValue(string k, double value)
	{
		this.SetMember(k, value);
	}

	// Token: 0x06005491 RID: 21649 RVA: 0x000CF1FF File Offset: 0x000CD3FF
	private void SetCurveConfigValue(string k, CurveBase value)
	{
		this.SetMember(k, value);
	}

	// Token: 0x06005492 RID: 21650 RVA: 0x000CF20C File Offset: 0x000CD40C
	public void SetDefaultConfigs([Nullable(new byte[]
	{
		1,
		0,
		1
	})] TMap<TEnumAsByte<T>, float> config, [Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})] TMap<TEnumAsByte<T>, SBaseCurve> curveConfig)
	{
		foreach (KeyValuePair<TEnumAsByte<T>, float> keyValuePair in config)
		{
			TEnumAsByte<T> tenumAsByte;
			float num;
			keyValuePair.Deconstruct(out tenumAsByte, out num);
			TEnumAsByte<T> value = tenumAsByte;
			float value2 = num;
			this.DefaultConfigs[value] = value2;
		}
		foreach (KeyValuePair<TEnumAsByte<T>, SBaseCurve> keyValuePair2 in curveConfig)
		{
			TEnumAsByte<T> tenumAsByte;
			SBaseCurve sbaseCurve;
			keyValuePair2.Deconstruct(out tenumAsByte, out sbaseCurve);
			TEnumAsByte<T> value3 = tenumAsByte;
			SBaseCurve curveStruct = sbaseCurve;
			this.DefaultCurveConfigs[value3] = CurveUtils.CreateCurveByStruct(curveStruct);
		}
	}

	// Token: 0x06005493 RID: 21651 RVA: 0x000CF2D4 File Offset: 0x000CD4D4
	public unsafe virtual void SetConfigs(Dictionary<T, float> config, Dictionary<T, CurveBase> curveConfig)
	{
		foreach (KeyValuePair<T, float> keyValuePair in config)
		{
			T t;
			float num;
			keyValuePair.Deconstruct(out t, out num);
			T key = t;
			float num2 = num;
			string k;
			if (this.ConfigMap.TryGetValue(key, out k))
			{
				this.SetConfigValue(k, (double)num2);
			}
		}
		foreach (KeyValuePair<T, string> keyValuePair2 in this.ConfigMap)
		{
			T t;
			string text;
			keyValuePair2.Deconstruct(out t, out text);
			T t2 = t;
			string text2 = text;
			object obj;
			if (!this.TryGetMember(text2, out obj))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "CameraController缺少配置";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CameraType", base.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("key", t2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("value", text2);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				this.SetConfigValue(text2, 1.0);
			}
		}
		foreach (KeyValuePair<T, CurveBase> keyValuePair3 in curveConfig)
		{
			T t;
			CurveBase curveBase;
			keyValuePair3.Deconstruct(out t, out curveBase);
			T key2 = t;
			CurveBase value = curveBase;
			string k2;
			if (this.CurveConfigMap.TryGetValue(key2, out k2))
			{
				this.SetCurveConfigValue(k2, value);
			}
		}
		foreach (KeyValuePair<T, string> keyValuePair2 in this.CurveConfigMap)
		{
			T t;
			string text;
			keyValuePair2.Deconstruct(out t, out text);
			T t3 = t;
			string text3 = text;
			object obj;
			if (!this.TryGetMember(text3, out obj))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Camera;
				ELogAuthor author2 = ELogAuthor.LCZ;
				string message2 = "CameraController缺少曲线配置";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CameraType", base.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("key", t3);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("value", text3);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				this.SetCurveConfigValue(text3, CurveUtils.CreateCurve(ECurveType.Linear, Array.Empty<float>()));
			}
		}
		this.PostProcessConfig(config, curveConfig);
	}

	// Token: 0x06005494 RID: 21652 RVA: 0x000CF59C File Offset: 0x000CD79C
	public void ResetDefaultConfig()
	{
		this.SetConfigs(this.DefaultConfigs, this.DefaultCurveConfigs);
	}

	// Token: 0x06005495 RID: 21653 RVA: 0x000CF5B0 File Offset: 0x000CD7B0
	public virtual void OnStart()
	{
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
	}

	// Token: 0x06005496 RID: 21654 RVA: 0x000CF5CF File Offset: 0x000CD7CF
	public virtual void OnEnd()
	{
		Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
	}

	// Token: 0x06005497 RID: 21655 RVA: 0x000CF5EE File Offset: 0x000CD7EE
	protected virtual void OnInit()
	{
	}

	// Token: 0x06005498 RID: 21656 RVA: 0x000CF5F0 File Offset: 0x000CD7F0
	protected virtual void OnEnable()
	{
	}

	// Token: 0x06005499 RID: 21657 RVA: 0x000CF5F2 File Offset: 0x000CD7F2
	protected virtual void OnDisable()
	{
	}

	// Token: 0x0600549A RID: 21658 RVA: 0x000CF5F4 File Offset: 0x000CD7F4
	protected virtual bool UpdateCustomEnableCondition()
	{
		return true;
	}

	// Token: 0x0600549B RID: 21659 RVA: 0x000CF5F7 File Offset: 0x000CD7F7
	protected virtual void UpdateInternal(float deltaTime)
	{
	}

	// Token: 0x0600549C RID: 21660 RVA: 0x000CF5F9 File Offset: 0x000CD7F9
	protected virtual void UpdateDeactivateInternal(float deltaTime)
	{
	}

	// Token: 0x0600549D RID: 21661 RVA: 0x000CF5FB File Offset: 0x000CD7FB
	protected virtual void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
	}

	// Token: 0x0600549E RID: 21662
	public abstract string Name();

	// Token: 0x0600549F RID: 21663 RVA: 0x000CF600 File Offset: 0x000CD800
	public void Lock(object control)
	{
		bool isActivate = this.IsActivate;
		this.BlockSet.Add(control);
		if (!this.IsActivate && isActivate)
		{
			this.OnDisable();
		}
	}

	// Token: 0x060054A0 RID: 21664 RVA: 0x000CF634 File Offset: 0x000CD834
	public void Unlock(object control)
	{
		bool isActivate = this.IsActivate;
		this.BlockSet.Remove(control);
		if (this.IsActivate && !isActivate)
		{
			this.OnEnable();
		}
	}

	// Token: 0x060054A1 RID: 21665 RVA: 0x000CF668 File Offset: 0x000CD868
	public void Update(float deltaTime)
	{
		bool isActivate = this.IsActivate;
		this.IsActivateInternal = this.UpdateCustomEnableCondition();
		if (this.IsActivate != isActivate)
		{
			if (this.IsActivate)
			{
				this.OnEnable();
			}
			else
			{
				this.OnDisable();
			}
		}
		if (this.IsActivate)
		{
			this.UpdateInternal(deltaTime);
			return;
		}
		this.UpdateDeactivateInternal(deltaTime);
	}

	// Token: 0x170005B5 RID: 1461
	// (get) Token: 0x060054A2 RID: 21666 RVA: 0x000CF6BE File Offset: 0x000CD8BE
	public virtual bool IsActivate
	{
		get
		{
			return this.IsActivateInternal && this.BlockSet.Count == 0;
		}
	}

	// Token: 0x060054A3 RID: 21667 RVA: 0x000CF6D8 File Offset: 0x000CD8D8
	public unsafe void ShowBlockSetInfo(string controllerName)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Camera;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "[ShowCameraBlockSet]";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("controllerName", controllerName);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		foreach (object obj in this.BlockSet)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Camera;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "[ShowCameraBlockSet]";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("elementName", obj.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("controllerName", controllerName);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x060054A4 RID: 21668 RVA: 0x000CF7A8 File Offset: 0x000CD9A8
	public virtual string GetConfigMapValue(T key)
	{
		return this.ConfigMap.GetValueOrDefault(key, "");
	}

	// Token: 0x060054A5 RID: 21669 RVA: 0x000CF7BC File Offset: 0x000CD9BC
	public virtual string GetConfigMapValue(int key)
	{
		T key2 = (T)((object)Enum.ToObject(typeof(T), key));
		return this.GetConfigMapValue(key2);
	}

	// Token: 0x060054A6 RID: 21670 RVA: 0x000CF7E8 File Offset: 0x000CD9E8
	public bool GetPairConfigKey<[Nullable(0)] TKey>(TKey key, out TKey pairKey) where TKey : Enum
	{
		if (key is T)
		{
			T key2 = key as T;
			T t;
			if (this.PairConfigKeySet.TryGetValue(key2, out t))
			{
				pairKey = (TKey)((object)t);
				return true;
			}
		}
		pairKey = default(TKey);
		return false;
	}

	// Token: 0x060054A7 RID: 21671 RVA: 0x000CF840 File Offset: 0x000CDA40
	public virtual float GetConfigValue(string key)
	{
		object obj;
		if (!this.TryGetMember(key, out obj) || obj == null)
		{
			return 0f;
		}
		object obj2 = obj;
		float result;
		if (obj2 is float)
		{
			float num = (float)obj2;
			result = num;
		}
		else if (obj2 is double)
		{
			double num2 = (double)obj2;
			result = (float)num2;
		}
		else if (obj2 is int)
		{
			int num3 = (int)obj2;
			result = (float)num3;
		}
		else if (obj2 is long)
		{
			long num4 = (long)obj2;
			result = (float)num4;
		}
		else
		{
			IConvertible convertible = obj as IConvertible;
			if (convertible != null)
			{
				result = Convert.ToSingle(convertible);
			}
			else
			{
				result = 0f;
			}
		}
		return result;
	}

	// Token: 0x060054A8 RID: 21672 RVA: 0x000CF8EC File Offset: 0x000CDAEC
	public unsafe virtual void PostProcessConfig(Dictionary<T, float> config, Dictionary<T, CurveBase> curveConfig)
	{
		foreach (ValueTuple<T, T> valueTuple in this.PairKeyArray)
		{
			T item = valueTuple.Item1;
			T item2 = valueTuple.Item2;
			bool flag = config.ContainsKey(item);
			bool flag2 = config.ContainsKey(item2);
			if (flag && !flag2)
			{
				this.SetValueFromDefaultConfig(item2);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.ZJL;
				string message = "相机上下限缺少配对项，已使用默认值自动补齐";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CameraType", base.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("missingKey", this.GetConfigMapValue(item2));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("defaultValue", this.GetConfigValue(this.GetConfigMapValue(item2)));
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			else if (!flag && flag2)
			{
				this.SetValueFromDefaultConfig(item);
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Camera;
				ELogAuthor author2 = ELogAuthor.ZJL;
				string message2 = "相机上下限缺少配对项，已使用默认值自动补齐";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CameraType", base.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("missingKey", this.GetConfigMapValue(item));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("defaultValue", this.GetConfigValue(this.GetConfigMapValue(item)));
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			}
			if (this.NeedValueCheckPairKeySet.Contains(item))
			{
				float configValue = this.GetConfigValue(this.GetConfigMapValue(item));
				float configValue2 = this.GetConfigValue(this.GetConfigMapValue(item2));
				if (configValue > configValue2 && (flag || flag2))
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Camera;
					ELogAuthor author3 = ELogAuthor.ZJL;
					string message3 = "相机配置值下限大于上限，检查配置是否有误(通常为第一个报错的配置项有误)";
					<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray5<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("CameraType", base.GetType().Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("key1", this.GetConfigMapValue(item));
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("key2", this.GetConfigMapValue(item2));
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("value1", configValue);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("value2", configValue2);
					instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 5));
				}
			}
		}
	}

	// Token: 0x060054A9 RID: 21673 RVA: 0x000CFBBC File Offset: 0x000CDDBC
	public void RegisterPairConfigKey(T key1, T key2, bool needCheckValue = true)
	{
		if (!this.PairConfigKeySet.ContainsKey(key1) && !this.PairConfigKeySet.ContainsKey(key2))
		{
			this.PairKeyArray.Add(new ValueTuple<T, T>(key1, key2));
		}
		this.PairConfigKeySet.TryAdd(key1, key2);
		this.PairConfigKeySet.TryAdd(key2, key1);
		if (needCheckValue)
		{
			this.NeedValueCheckPairKeySet.Add(key1);
		}
	}

	// Token: 0x060054AA RID: 21674 RVA: 0x000CFC24 File Offset: 0x000CDE24
	public void SetValueFromDefaultConfig(T key)
	{
		float num;
		if (this.DefaultConfigs.TryGetValue(key, out num))
		{
			string configMapValue = this.GetConfigMapValue(key);
			object obj;
			if (this.TryGetMember(configMapValue, out obj))
			{
				this.SetMember(configMapValue, num);
			}
		}
	}

	// Token: 0x060054AB RID: 21675 RVA: 0x000CFC64 File Offset: 0x000CDE64
	[NullableContext(0)]
	public virtual bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 6:
				if (key == "Camera")
				{
					value = this.Camera;
					return true;
				}
				break;
			case 8:
				if (key == "BlockSet")
				{
					value = this.BlockSet;
					return true;
				}
				break;
			case 9:
				if (key == "ConfigMap")
				{
					value = this.ConfigMap;
					return true;
				}
				break;
			case 10:
				if (key == "IsActivate")
				{
					value = this.IsActivate;
					return true;
				}
				break;
			case 11:
				if (key == "CameraModel")
				{
					value = this.CameraModel;
					return true;
				}
				break;
			case 12:
				if (key == "PairKeyArray")
				{
					value = this.PairKeyArray;
					return true;
				}
				break;
			case 13:
				if (key == "DebugValueSet")
				{
					value = this.DebugValueSet;
					return true;
				}
				break;
			case 14:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'D')
					{
						if (key == "DefaultConfigs")
						{
							value = this.DefaultConfigs;
							return true;
						}
					}
				}
				else if (key == "CurveConfigMap")
				{
					value = this.CurveConfigMap;
					return true;
				}
				break;
			}
			case 16:
				if (key == "PairConfigKeySet")
				{
					value = this.PairConfigKeySet;
					return true;
				}
				break;
			case 18:
				if (key == "IsActivateInternal")
				{
					value = this.IsActivateInternal;
					return true;
				}
				break;
			case 19:
				if (key == "DefaultCurveConfigs")
				{
					value = this.DefaultCurveConfigs;
					return true;
				}
				break;
			case 24:
				if (key == "NeedValueCheckPairKeySet")
				{
					value = this.NeedValueCheckPairKeySet;
					return true;
				}
				break;
			}
		}
		value = null;
		return false;
	}

	// Token: 0x060054AC RID: 21676 RVA: 0x000CFE8F File Offset: 0x000CE08F
	[NullableContext(0)]
	public virtual void SetMember(string key, object value)
	{
		if (key == "IsActivateInternal")
		{
			this.IsActivateInternal = (bool)value;
			return;
		}
		throw new KeyNotFoundException("设置CameraControllerBase成员属性失败" + key + ")");
	}

	// Token: 0x060054AD RID: 21677 RVA: 0x000CFEC0 File Offset: 0x000CE0C0
	[NullableContext(0)]
	public virtual IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraControllerBase<T>.<MemberIter>d__51 <MemberIter>d__ = new CameraControllerBase<T>.<MemberIter>d__51(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x0400198A RID: 6538
	[StaticVariableRuleIgnore]
	private static readonly Stat UpdateCustomEnableConditionStat = Stat.Create("UpdateCustomEnableConditionStat", "", "");

	// Token: 0x0400198B RID: 6539
	[StaticVariableRuleIgnore]
	private static readonly Stat OnEnableStat = Stat.Create("OnEnableStat", "", "");

	// Token: 0x0400198C RID: 6540
	[StaticVariableRuleIgnore]
	private static readonly Stat OnDisableStat = Stat.Create("OnDisableStat", "", "");

	// Token: 0x0400198D RID: 6541
	[StaticVariableRuleIgnore]
	private static readonly Stat UpdateInternalStat = Stat.Create("UpdateInternalStat", "", "");

	// Token: 0x0400198E RID: 6542
	[StaticVariableRuleIgnore]
	private static readonly Stat UpdateDeactivateInternalStat = Stat.Create("UpdateDeactivateInternalStat", "", "");

	// Token: 0x0400198F RID: 6543
	public readonly FightCameraLogicComponent Camera;

	// Token: 0x04001990 RID: 6544
	private bool IsActivateInternal = true;

	// Token: 0x04001991 RID: 6545
	private readonly HashSet<object> BlockSet = new HashSet<object>();

	// Token: 0x04001992 RID: 6546
	private readonly Dictionary<T, float> DefaultConfigs = new Dictionary<T, float>();

	// Token: 0x04001993 RID: 6547
	private readonly Dictionary<T, string> ConfigMap = new Dictionary<T, string>();

	// Token: 0x04001994 RID: 6548
	private readonly Dictionary<T, CurveBase> DefaultCurveConfigs = new Dictionary<T, CurveBase>();

	// Token: 0x04001995 RID: 6549
	private readonly Dictionary<T, string> CurveConfigMap = new Dictionary<T, string>();

	// Token: 0x04001996 RID: 6550
	private readonly HashSet<string> DebugValueSet = new HashSet<string>();

	// Token: 0x04001997 RID: 6551
	private readonly Dictionary<T, T> PairConfigKeySet = new Dictionary<T, T>();

	// Token: 0x04001998 RID: 6552
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})]
	private readonly List<ValueTuple<T, T>> PairKeyArray = new List<ValueTuple<T, T>>();

	// Token: 0x04001999 RID: 6553
	private readonly HashSet<T> NeedValueCheckPairKeySet = new HashSet<T>();
}
