using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Roulette.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002944 RID: 10564
[NullableContext(1)]
[Nullable(0)]
public class RouletteAssemblyViewProxy
{
	// Token: 0x17001B83 RID: 7043
	// (get) Token: 0x06014F9C RID: 85916 RVA: 0x005CE54C File Offset: 0x005CC74C
	public RouletteListDataBase CurrentRouletteDataList
	{
		get
		{
			RouletteListDataBase result;
			if (ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(this.CurrentRouletteType, out result))
			{
				return result;
			}
			return null;
		}
	}

	// Token: 0x06014F9D RID: 85917 RVA: 0x005CE575 File Offset: 0x005CC775
	public void RegisterView(RouletteAssemblyView view)
	{
		this.View = view;
	}

	// Token: 0x06014F9E RID: 85918 RVA: 0x005CE580 File Offset: 0x005CC780
	public UniTask OnBeforeStartAsync()
	{
		RouletteAssemblyViewProxy.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RouletteAssemblyViewProxy.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014F9F RID: 85919 RVA: 0x005CE5C3 File Offset: 0x005CC7C3
	public void Start()
	{
	}

	// Token: 0x06014FA0 RID: 85920 RVA: 0x005CE5C8 File Offset: 0x005CC7C8
	public void BeforeShow()
	{
		this.OpenParam.SelectGridId = null;
		this.OpenParam.SelectGridIndex = null;
	}

	// Token: 0x06014FA1 RID: 85921 RVA: 0x005CE600 File Offset: 0x005CC800
	public void OnRouletteTypeSwitch(ERouletteType rouletteType)
	{
		this.CurrentRouletteType = rouletteType;
		this.AssemblyGridDataMap = this.CurrentRouletteDataList.CreateAssemblyGridData();
		foreach (KeyValuePair<ERouletteType, RouletteComponentAssembly> keyValuePair in this.RouletteComponentMap)
		{
			ERouletteType key = keyValuePair.Key;
			RouletteComponentAssembly value = keyValuePair.Value;
			if (key != this.CurrentRouletteType)
			{
				value.DeactivateGridToggleChangeEvent();
			}
		}
		this.CurrentRouletteListSaveData = this.CurrentRouletteDataList.GetRouletteListSaveData();
	}

	// Token: 0x06014FA2 RID: 85922 RVA: 0x005CE694 File Offset: 0x005CC894
	public RouletteComponentAssembly GetRouletteComponent()
	{
		RouletteComponentAssembly result;
		if (this.RouletteComponentMap.TryGetValue(this.CurrentRouletteType, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06014FA3 RID: 85923 RVA: 0x005CE6B9 File Offset: 0x005CC8B9
	[return: Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> GetRouletteDataMap()
	{
		return this.CurrentRouletteDataList.GetRouletteDataMap();
	}

	// Token: 0x06014FA4 RID: 85924 RVA: 0x005CE6C8 File Offset: 0x005CC8C8
	public int GetRouletteGridId(int index, ERouletteGridType gridType)
	{
		return this.CurrentRouletteDataList.GetRouletteGridId(index, gridType, false).GetValueOrDefault();
	}

	// Token: 0x06014FA5 RID: 85925 RVA: 0x005CE6EC File Offset: 0x005CC8EC
	public void Destroy()
	{
		foreach (RouletteComponentAssembly rouletteComponentAssembly in this.RouletteComponentMap.Values)
		{
			rouletteComponentAssembly.Destroy(null);
		}
		this.RouletteComponentMap.Clear();
	}

	// Token: 0x06014FA6 RID: 85926 RVA: 0x005CE750 File Offset: 0x005CC950
	public bool CanOpenView()
	{
		return this.GetTabTypeList().Count > 0;
	}

	// Token: 0x06014FA7 RID: 85927 RVA: 0x005CE760 File Offset: 0x005CC960
	private List<ERouletteType> GetTabTypeList()
	{
		List<IRouletteAssemblyTabData> list = new List<IRouletteAssemblyTabData>();
		foreach (KeyValuePair<ERouletteType, RouletteListDataBase> keyValuePair in ModelBase<RouletteModel>.Instance.RouletteListDataMap)
		{
			ERouletteType key = keyValuePair.Key;
			if (keyValuePair.Value.IsRouletteOpen())
			{
				ExploreRouletteType? exploreRouletteTypeById = ConfigBase<RouletteConfig>.Instance.GetExploreRouletteTypeById((int)key);
				if (exploreRouletteTypeById != null)
				{
					ExploreRouletteType value = exploreRouletteTypeById.Value;
					if (value.ShowInPad || Singleton<Info>.Instance.OperationType != EOperationType.Pad)
					{
						list.Add(new RouletteAssemblyTabData
						{
							Type = key,
							SortId = value.SortId
						});
					}
				}
			}
		}
		list.Sort((IRouletteAssemblyTabData a, IRouletteAssemblyTabData b) => a.SortId - b.SortId);
		List<ERouletteType> list2 = new List<ERouletteType>();
		foreach (IRouletteAssemblyTabData rouletteAssemblyTabData in list)
		{
			list2.Add(rouletteAssemblyTabData.Type);
		}
		return list2;
	}

	// Token: 0x0400A19C RID: 41372
	private readonly Dictionary<ERouletteType, RouletteComponentAssembly> RouletteComponentMap = new Dictionary<ERouletteType, RouletteComponentAssembly>();

	// Token: 0x0400A19D RID: 41373
	protected RouletteAssemblyView View;

	// Token: 0x0400A19E RID: 41374
	public IRouletteAssemblyOpenParam OpenParam;

	// Token: 0x0400A19F RID: 41375
	public List<ERouletteType> TypeList = new List<ERouletteType>();

	// Token: 0x0400A1A0 RID: 41376
	public Dictionary<ERouletteType, RouletteListDataBase> RouletteListDataMap = new Dictionary<ERouletteType, RouletteListDataBase>();

	// Token: 0x0400A1A1 RID: 41377
	public ERouletteType CurrentRouletteType;

	// Token: 0x0400A1A2 RID: 41378
	public Dictionary<ERouletteGridType, List<AssemblyGridData>> AssemblyGridDataMap = new Dictionary<ERouletteGridType, List<AssemblyGridData>>();

	// Token: 0x0400A1A3 RID: 41379
	public IRouletteListSaveData CurrentRouletteListSaveData;
}
