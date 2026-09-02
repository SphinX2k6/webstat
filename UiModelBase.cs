using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002CBF RID: 11455
[NullableContext(1)]
[Nullable(0)]
public class UiModelBase
{
	// Token: 0x06016FDB RID: 94171 RVA: 0x0065F874 File Offset: 0x0065DA74
	public UiModelBase(int id, EUiModelUseWay useWay)
	{
		this.Id = id;
		this.UseWay = useWay;
	}

	// Token: 0x06016FDC RID: 94172 RVA: 0x0065F8C4 File Offset: 0x0065DAC4
	[NullableContext(0)]
	[return: Nullable(2)]
	public T GetComponent<T>() where T : UiModelComponentBase
	{
		UiModelComponentBase uiModelComponentBase;
		if (this.ComponentMap.TryGetValue(typeof(T), out uiModelComponentBase))
		{
			return uiModelComponentBase as T;
		}
		return default(T);
	}

	// Token: 0x06016FDD RID: 94173 RVA: 0x0065F900 File Offset: 0x0065DB00
	[NullableContext(0)]
	[return: Nullable(2)]
	public T GetComponentByCtor<T>() where T : UiModelComponentBase
	{
		foreach (KeyValuePair<Type, UiModelComponentBase> keyValuePair in this.ComponentMap)
		{
			T t = keyValuePair.Value as T;
			if (t != null)
			{
				return t;
			}
		}
		return default(T);
	}

	// Token: 0x06016FDE RID: 94174 RVA: 0x0065F978 File Offset: 0x0065DB78
	[NullableContext(0)]
	[return: Nullable(2)]
	public unsafe T CheckGetComponent<T>() where T : UiModelComponentBase
	{
		T component = this.GetComponent<T>();
		if (component == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "获取组件失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("uiModelName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("component", typeof(T).Name);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		return component;
	}

	// Token: 0x06016FDF RID: 94175 RVA: 0x0065FA24 File Offset: 0x0065DC24
	public unsafe void AddComponent(Type componentType)
	{
		if (this.ComponentMap.ContainsKey(componentType))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiComponent;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "添加组件失败：组件已存在，请勿重复添加！";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("uiModelName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("componentName", componentType.Name);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		UiModelComponentHandler uiModelComponentHandler;
		if (UiModelComponentDefine.Handlers.TryGetValue(componentType, out uiModelComponentHandler))
		{
			UiModelComponentBase uiModelComponentBase = uiModelComponentHandler(this);
			this.ComponentMap[componentType] = uiModelComponentBase;
			IUiModelVisible uiModelVisible = uiModelComponentBase as IUiModelVisible;
			if (uiModelVisible != null)
			{
				this.VisibleComponents.Add(uiModelVisible);
			}
			IUiModelSetDitherEffect uiModelSetDitherEffect = uiModelComponentBase as IUiModelSetDitherEffect;
			if (uiModelSetDitherEffect != null)
			{
				this.DitherComponents.Add(uiModelSetDitherEffect);
			}
			IUiModelRenderingMaterialChange uiModelRenderingMaterialChange = uiModelComponentBase as IUiModelRenderingMaterialChange;
			if (uiModelRenderingMaterialChange != null)
			{
				this.RenderingMaterialChangeComponents.Add(uiModelRenderingMaterialChange);
			}
		}
	}

	// Token: 0x06016FE0 RID: 94176 RVA: 0x0065FB10 File Offset: 0x0065DD10
	public void Init()
	{
		foreach (KeyValuePair<Type, UiModelComponentBase> keyValuePair in this.ComponentMap)
		{
			keyValuePair.Value.Init();
		}
	}

	// Token: 0x06016FE1 RID: 94177 RVA: 0x0065FB68 File Offset: 0x0065DD68
	public void Start()
	{
		foreach (KeyValuePair<Type, UiModelComponentBase> keyValuePair in this.ComponentMap)
		{
			keyValuePair.Value.Start();
		}
	}

	// Token: 0x06016FE2 RID: 94178 RVA: 0x0065FBC0 File Offset: 0x0065DDC0
	public void Tick(float deltaTime)
	{
		foreach (KeyValuePair<Type, UiModelComponentBase> keyValuePair in this.ComponentMap)
		{
			if (keyValuePair.Value.NeedTick)
			{
				keyValuePair.Value.Tick(deltaTime);
			}
		}
	}

	// Token: 0x06016FE3 RID: 94179 RVA: 0x0065FC28 File Offset: 0x0065DE28
	public void End()
	{
		foreach (KeyValuePair<Type, UiModelComponentBase> keyValuePair in this.ComponentMap)
		{
			keyValuePair.Value.End();
		}
	}

	// Token: 0x06016FE4 RID: 94180 RVA: 0x0065FC80 File Offset: 0x0065DE80
	public void Clear()
	{
		foreach (KeyValuePair<Type, UiModelComponentBase> keyValuePair in this.ComponentMap)
		{
			keyValuePair.Value.Clear();
		}
		this.VisibleComponents.Clear();
		this.DitherComponents.Clear();
	}

	// Token: 0x06016FE5 RID: 94181 RVA: 0x0065FCF0 File Offset: 0x0065DEF0
	public void OnVisibleChange(bool visible)
	{
		this.VisibleComponents.ForEach(delegate(IUiModelVisible c)
		{
			c.OnModelVisibleChange(visible);
		});
	}

	// Token: 0x06016FE6 RID: 94182 RVA: 0x0065FD24 File Offset: 0x0065DF24
	public void OnSetDitherEffect(float value)
	{
		this.DitherComponents.ForEach(delegate(IUiModelSetDitherEffect c)
		{
			c.OnModelDitherEffectChange(value);
		});
	}

	// Token: 0x06016FE7 RID: 94183 RVA: 0x0065FD58 File Offset: 0x0065DF58
	public void OnRenderingMaterialAdd(int materialId, UObject data, bool isGroup, bool withAnimObject)
	{
		this.RenderingMaterialChangeComponents.ForEach(delegate(IUiModelRenderingMaterialChange c)
		{
			c.OnRenderingMaterialAdd(materialId, data, isGroup, withAnimObject);
		});
	}

	// Token: 0x06016FE8 RID: 94184 RVA: 0x0065FDA0 File Offset: 0x0065DFA0
	public void OnRenderingMaterialRemove(int materialId, bool isGroup, bool withAnimObject)
	{
		this.RenderingMaterialChangeComponents.ForEach(delegate(IUiModelRenderingMaterialChange c)
		{
			c.OnRenderingMaterialRemove(materialId, isGroup, withAnimObject);
		});
	}

	// Token: 0x0400B13C RID: 45372
	private readonly OrderedDictionary<Type, UiModelComponentBase> ComponentMap = new OrderedDictionary<Type, UiModelComponentBase>();

	// Token: 0x0400B13D RID: 45373
	public readonly EUiModelUseWay UseWay;

	// Token: 0x0400B13E RID: 45374
	public readonly int Id;

	// Token: 0x0400B13F RID: 45375
	private readonly List<IUiModelVisible> VisibleComponents = new List<IUiModelVisible>();

	// Token: 0x0400B140 RID: 45376
	private readonly List<IUiModelSetDitherEffect> DitherComponents = new List<IUiModelSetDitherEffect>();

	// Token: 0x0400B141 RID: 45377
	private readonly List<IUiModelRenderingMaterialChange> RenderingMaterialChangeComponents = new List<IUiModelRenderingMaterialChange>();
}
