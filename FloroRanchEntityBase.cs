using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BEF RID: 7151
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchEntityBase
{
	// Token: 0x0600D016 RID: 53270 RVA: 0x00373A83 File Offset: 0x00371C83
	public FloroRanchEntityBase(FloroRanchPlayUnit entityData)
	{
		this.EntityId = entityData.PlayIncId;
		this.EntityType = (EFloroRanchEntityType)entityData.Type;
	}

	// Token: 0x0600D017 RID: 53271 RVA: 0x00373AB0 File Offset: 0x00371CB0
	[NullableContext(0)]
	public unsafe void AddComponent<T>() where T : FloroRanchEntityComponentBase, new()
	{
		int index = FloroRanchEntityComponentIndexGetter<T>.Index;
		if (index < 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "组件未注册, 请检查是否使用在EFloroRanchEntityComponent注册";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("componentName", typeof(T).Name);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (index >= this.ComponentList.Count)
		{
			for (int i = this.ComponentList.Count; i <= index; i++)
			{
				this.ComponentList.Add(null);
			}
		}
		if (this.ComponentList[index] != null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.FloroRanchGamePlay;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "添加组件失败：组件已存在，请勿重复添加！";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("entityName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("componentName", typeof(T).Name);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		T t = Activator.CreateInstance<T>();
		t.Create(this);
		this.ComponentList[index] = t;
	}

	// Token: 0x0600D018 RID: 53272 RVA: 0x00373C0C File Offset: 0x00371E0C
	public unsafe void AddComponent(Type componentType, Func<FloroRanchEntityComponentBase> ctor)
	{
		int byType = FloroRanchEntityComponentIndexGetter<FloroRanchEntityComponentBase>.GetByType(componentType.Name, false);
		if (byType < 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "组件未注册, 请检查是否使用在EFloroRanchEntityComponent注册";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("componentName", componentType.Name);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (byType >= this.ComponentList.Count)
		{
			for (int i = this.ComponentList.Count; i <= byType; i++)
			{
				this.ComponentList.Add(null);
			}
		}
		if (this.ComponentList[byType] != null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.FloroRanchGamePlay;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "添加组件失败：组件已存在，请勿重复添加！";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("entityName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("componentName", componentType.Name);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		FloroRanchEntityComponentBase floroRanchEntityComponentBase = ctor();
		floroRanchEntityComponentBase.Create(this);
		this.ComponentList[byType] = floroRanchEntityComponentBase;
	}

	// Token: 0x0600D019 RID: 53273 RVA: 0x00373D54 File Offset: 0x00371F54
	[NullableContext(0)]
	[return: Nullable(2)]
	public T GetComponent<T>() where T : FloroRanchEntityComponentBase
	{
		int index = FloroRanchEntityComponentIndexGetter<T>.Index;
		return this.ComponentList[index] as T;
	}

	// Token: 0x0600D01A RID: 53274 RVA: 0x00373D80 File Offset: 0x00371F80
	[NullableContext(0)]
	[return: Nullable(2)]
	public unsafe T CheckGetComponent<T>() where T : FloroRanchEntityComponentBase
	{
		T component = this.GetComponent<T>();
		if (component == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "获取组件失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityId", this.EntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entityName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("component", FloroRanchEntityComponentIndexGetter<T>.Index);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		return component;
	}

	// Token: 0x0600D01B RID: 53275 RVA: 0x00373E2C File Offset: 0x0037202C
	public List<FloroRanchEntityDataBaseComponent> GetDataComponentList()
	{
		List<FloroRanchEntityDataBaseComponent> list = new List<FloroRanchEntityDataBaseComponent>();
		foreach (FloroRanchEntityComponentBase floroRanchEntityComponentBase in this.ComponentList)
		{
			if (floroRanchEntityComponentBase != null)
			{
				FloroRanchEntityDataBaseComponent floroRanchEntityDataBaseComponent = floroRanchEntityComponentBase as FloroRanchEntityDataBaseComponent;
				if (floroRanchEntityDataBaseComponent != null)
				{
					list.Add(floroRanchEntityDataBaseComponent);
				}
			}
		}
		return list;
	}

	// Token: 0x0600D01C RID: 53276 RVA: 0x00373E94 File Offset: 0x00372094
	[NullableContext(2)]
	public unsafe FloroRanchUiItemBaseComponent GetUiItemComponent()
	{
		foreach (FloroRanchEntityComponentBase floroRanchEntityComponentBase in this.ComponentList)
		{
			if (floroRanchEntityComponentBase != null)
			{
				FloroRanchUiItemBaseComponent floroRanchUiItemBaseComponent = floroRanchEntityComponentBase as FloroRanchUiItemBaseComponent;
				if (floroRanchUiItemBaseComponent != null)
				{
					return floroRanchUiItemBaseComponent;
				}
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanchGamePlay;
		ELogAuthor author = ELogAuthor.BB;
		string message = "获取组件失败";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityId", this.EntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entityName", base.GetType().Name);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("component", "FloroRanchUiItemBaseComponent");
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		return null;
	}

	// Token: 0x0600D01D RID: 53277 RVA: 0x00373F80 File Offset: 0x00372180
	public void Init()
	{
		foreach (FloroRanchEntityComponentBase floroRanchEntityComponentBase in this.ComponentList)
		{
			if (floroRanchEntityComponentBase != null)
			{
				floroRanchEntityComponentBase.Init();
			}
		}
	}

	// Token: 0x0600D01E RID: 53278 RVA: 0x00373FD8 File Offset: 0x003721D8
	public void Tick(float deltaTime)
	{
		foreach (FloroRanchEntityComponentBase floroRanchEntityComponentBase in this.ComponentList)
		{
			if (floroRanchEntityComponentBase != null)
			{
				floroRanchEntityComponentBase.Tick(deltaTime);
			}
		}
	}

	// Token: 0x0600D01F RID: 53279 RVA: 0x00374030 File Offset: 0x00372230
	public void End()
	{
		foreach (FloroRanchEntityComponentBase floroRanchEntityComponentBase in this.ComponentList)
		{
			if (floroRanchEntityComponentBase != null)
			{
				floroRanchEntityComponentBase.End();
			}
		}
	}

	// Token: 0x0600D020 RID: 53280 RVA: 0x00374088 File Offset: 0x00372288
	public void RefreshEntityData(FloroRanchPlayUnit entityData)
	{
		foreach (FloroRanchEntityDataBaseComponent floroRanchEntityDataBaseComponent in this.GetDataComponentList())
		{
			floroRanchEntityDataBaseComponent.RefreshEntityData(entityData);
		}
	}

	// Token: 0x0600D021 RID: 53281 RVA: 0x003740DC File Offset: 0x003722DC
	public int GetPoint()
	{
		FloroRanchEntityDataComponent floroRanchEntityDataComponent = this.CheckGetComponent<FloroRanchEntityDataComponent>();
		if (floroRanchEntityDataComponent == null)
		{
			return -1;
		}
		return floroRanchEntityDataComponent.Point;
	}

	// Token: 0x0600D022 RID: 53282 RVA: 0x003740FC File Offset: 0x003722FC
	public int GetRarity()
	{
		int result = -1;
		EFloroRanchEntityType entityType = this.EntityType;
		if (entityType != EFloroRanchEntityType.Card)
		{
			if (entityType == EFloroRanchEntityType.Toy)
			{
				FloroRanchToyDataComponent floroRanchToyDataComponent = this.CheckGetComponent<FloroRanchToyDataComponent>();
				if (floroRanchToyDataComponent != null && floroRanchToyDataComponent.ToyData != null)
				{
					result = floroRanchToyDataComponent.ToyData.GetRarity();
				}
			}
		}
		else
		{
			FloroRanchCardDataComponent floroRanchCardDataComponent = this.CheckGetComponent<FloroRanchCardDataComponent>();
			if (floroRanchCardDataComponent != null && floroRanchCardDataComponent.CardData != null)
			{
				result = floroRanchCardDataComponent.CardData.GetRarity();
			}
		}
		return result;
	}

	// Token: 0x0600D023 RID: 53283 RVA: 0x0037415C File Offset: 0x0037235C
	public int GetRace()
	{
		int result = -1;
		EFloroRanchEntityType entityType = this.EntityType;
		if (entityType != EFloroRanchEntityType.Card)
		{
			if (entityType == EFloroRanchEntityType.Toy)
			{
				FloroRanchToyDataComponent floroRanchToyDataComponent = this.CheckGetComponent<FloroRanchToyDataComponent>();
				if (floroRanchToyDataComponent != null && floroRanchToyDataComponent.ToyData != null)
				{
					result = floroRanchToyDataComponent.ToyData.GetRace();
				}
			}
		}
		else
		{
			FloroRanchCardDataComponent floroRanchCardDataComponent = this.CheckGetComponent<FloroRanchCardDataComponent>();
			if (floroRanchCardDataComponent != null && floroRanchCardDataComponent.CardData != null)
			{
				result = floroRanchCardDataComponent.CardData.GetRace();
			}
		}
		return result;
	}

	// Token: 0x0600D024 RID: 53284 RVA: 0x003741BC File Offset: 0x003723BC
	public string Info()
	{
		List<FloroRanchEntityDataBaseComponent> dataComponentList = this.GetDataComponentList();
		List<string> list = new List<string>();
		for (int i = dataComponentList.Count - 1; i >= 0; i--)
		{
			FloroRanchEntityDataBaseComponent floroRanchEntityDataBaseComponent = dataComponentList[i];
			list.Add(floroRanchEntityDataBaseComponent.Info());
		}
		return string.Join(" ", list);
	}

	// Token: 0x0600D025 RID: 53285 RVA: 0x00374208 File Offset: 0x00372408
	public string DebugInfo()
	{
		List<FloroRanchEntityDataBaseComponent> dataComponentList = this.GetDataComponentList();
		List<string> list = new List<string>();
		foreach (FloroRanchEntityDataBaseComponent floroRanchEntityDataBaseComponent in dataComponentList)
		{
			list.Add(floroRanchEntityDataBaseComponent.DebugInfo());
		}
		string str = string.Join(" ", list);
		return "<color=Orange>【" + str + "】</color>";
	}

	// Token: 0x0600D026 RID: 53286 RVA: 0x00374284 File Offset: 0x00372484
	public string DebugUiShowInfo()
	{
		List<FloroRanchEntityDataBaseComponent> dataComponentList = this.GetDataComponentList();
		List<string> list = new List<string>();
		foreach (FloroRanchEntityDataBaseComponent floroRanchEntityDataBaseComponent in dataComponentList)
		{
			list.Add(floroRanchEntityDataBaseComponent.DebugInfo());
		}
		string str = string.Join("\n", list);
		return "<color=Red>" + str + "</color>";
	}

	// Token: 0x040062F6 RID: 25334
	public readonly int EntityId;

	// Token: 0x040062F7 RID: 25335
	public readonly EFloroRanchEntityType EntityType;

	// Token: 0x040062F8 RID: 25336
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly List<FloroRanchEntityComponentBase> ComponentList = new List<FloroRanchEntityComponentBase>();
}
