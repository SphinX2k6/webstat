using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02001FA3 RID: 8099
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class HudUnitManager : Singleton<HudUnitManager>
{
	// Token: 0x0600F36E RID: 62318 RVA: 0x00428A98 File Offset: 0x00426C98
	public bool GetIsInitHud()
	{
		return this.IsInitHud;
	}

	// Token: 0x0600F36F RID: 62319 RVA: 0x00428AA0 File Offset: 0x00426CA0
	public HudUnitHandleBase New(Type hudUnitHandleClass)
	{
		HudUnitHandleBase hudUnitHandleBase = Activator.CreateInstance(hudUnitHandleClass) as HudUnitHandleBase;
		hudUnitHandleBase.Initialize();
		string name = hudUnitHandleClass.Name;
		this.HudUnitHandleMap[name] = hudUnitHandleBase;
		return hudUnitHandleBase;
	}

	// Token: 0x0600F370 RID: 62320 RVA: 0x00428AD4 File Offset: 0x00426CD4
	public void TryNew(Type hudUnitHandleClass)
	{
		if (this.Get(hudUnitHandleClass) != null)
		{
			return;
		}
		this.New(hudUnitHandleClass).OnShowHud();
	}

	// Token: 0x0600F371 RID: 62321 RVA: 0x00428AEC File Offset: 0x00426CEC
	public void Destroy(Type hudUnitHandleClass)
	{
		HudUnitHandleBase hudUnitHandleBase = this.Get(hudUnitHandleClass);
		if (hudUnitHandleBase != null)
		{
			hudUnitHandleBase.Destroy();
		}
		string name = hudUnitHandleClass.Name;
		this.HudUnitHandleMap.Remove(name);
	}

	// Token: 0x0600F372 RID: 62322 RVA: 0x00428B20 File Offset: 0x00426D20
	public void ShowHud()
	{
		if (!this.IsInitHud)
		{
			foreach (Type hudUnitHandleClass in this.HudUnitHandleClassArray)
			{
				this.New(hudUnitHandleClass);
			}
			this.IsInitHud = true;
			Singleton<EventSystem>.Instance.Emit(EEventName.HudInited);
		}
		foreach (HudUnitHandleBase hudUnitHandleBase in this.HudUnitHandleMap.Values)
		{
			hudUnitHandleBase.OnShowHud();
		}
	}

	// Token: 0x0600F373 RID: 62323 RVA: 0x00428BB8 File Offset: 0x00426DB8
	public void HideHud()
	{
		foreach (HudUnitHandleBase hudUnitHandleBase in this.HudUnitHandleMap.Values)
		{
			hudUnitHandleBase.OnHideHud();
		}
	}

	// Token: 0x0600F374 RID: 62324 RVA: 0x00428C10 File Offset: 0x00426E10
	[return: Nullable(2)]
	public HudUnitHandleBase Get(Type hudUnitHandleClass)
	{
		string name = hudUnitHandleClass.Name;
		HudUnitHandleBase result;
		this.HudUnitHandleMap.TryGetValue(name, out result);
		return result;
	}

	// Token: 0x0600F375 RID: 62325 RVA: 0x00428C34 File Offset: 0x00426E34
	public void Clear()
	{
		foreach (HudUnitHandleBase hudUnitHandleBase in this.HudUnitHandleMap.Values)
		{
			hudUnitHandleBase.Destroy();
		}
		this.HudUnitHandleMap.Clear();
		this.IsInitHud = false;
	}

	// Token: 0x0600F376 RID: 62326 RVA: 0x00428C9C File Offset: 0x00426E9C
	public void RefreshHudOnInputControllerChanged(EInputControllerType last, EInputControllerType now)
	{
		foreach (HudUnitHandleBase hudUnitHandleBase in this.HudUnitHandleMap.Values)
		{
			hudUnitHandleBase.OnInputControllerChanged(last, now);
		}
	}

	// Token: 0x0600F377 RID: 62327 RVA: 0x00428CF4 File Offset: 0x00426EF4
	public void Tick(float delta)
	{
		foreach (HudUnitHandleBase hudUnitHandleBase in this.HudUnitHandleMap.Values)
		{
			hudUnitHandleBase.Tick(delta);
		}
		this.TickCount++;
	}

	// Token: 0x0600F378 RID: 62328 RVA: 0x00428D58 File Offset: 0x00426F58
	public void AfterTick(float delta)
	{
		foreach (HudUnitHandleBase hudUnitHandleBase in this.HudUnitHandleMap.Values)
		{
			hudUnitHandleBase.AfterTick(delta);
		}
	}

	// Token: 0x040074EB RID: 29931
	public Type[] HudUnitHandleClassArray = new Type[0];

	// Token: 0x040074EC RID: 29932
	public Dictionary<EHudUnitType, Type> HudUnitHandleClassMap = new Dictionary<EHudUnitType, Type>();

	// Token: 0x040074ED RID: 29933
	private readonly Dictionary<string, HudUnitHandleBase> HudUnitHandleMap = new Dictionary<string, HudUnitHandleBase>();

	// Token: 0x040074EE RID: 29934
	private bool IsInitHud;

	// Token: 0x040074EF RID: 29935
	public int TickCount;
}
