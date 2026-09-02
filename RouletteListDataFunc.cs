using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

// Token: 0x02002923 RID: 10531
[NullableContext(1)]
[Nullable(0)]
public class RouletteListDataFunc : RouletteListDataBase
{
	// Token: 0x17001B76 RID: 7030
	// (get) Token: 0x06014E4A RID: 85578 RVA: 0x005C8944 File Offset: 0x005C6B44
	public override ERoulettePriority Priority
	{
		get
		{
			return ERoulettePriority.Function;
		}
	}

	// Token: 0x06014E4B RID: 85579 RVA: 0x005C8948 File Offset: 0x005C6B48
	public override List<int> GetRouletteIdList()
	{
		if (this.IsRouletteReplace())
		{
			return this.RouletteIdListReplace;
		}
		return this.RouletteIdListServer;
	}

	// Token: 0x06014E4C RID: 85580 RVA: 0x005C895F File Offset: 0x005C6B5F
	public override int GetExtraItemId()
	{
		return 0;
	}

	// Token: 0x06014E4D RID: 85581 RVA: 0x005C8962 File Offset: 0x005C6B62
	public override int GetEquipExploreSkillId()
	{
		return 0;
	}

	// Token: 0x06014E4E RID: 85582 RVA: 0x005C8965 File Offset: 0x005C6B65
	public override bool IsActivate()
	{
		return true;
	}

	// Token: 0x17001B77 RID: 7031
	// (get) Token: 0x06014E4F RID: 85583 RVA: 0x005C8968 File Offset: 0x005C6B68
	public override ERouletteType RouletteType
	{
		get
		{
			return ERouletteType.Function;
		}
	}

	// Token: 0x06014E50 RID: 85584 RVA: 0x005C896B File Offset: 0x005C6B6B
	public override void Init()
	{
		this.InitFunctionRouletteReplaceConfig();
		this.OnAddEvents();
	}

	// Token: 0x06014E51 RID: 85585 RVA: 0x005C8979 File Offset: 0x005C6B79
	public override void Clear()
	{
		this.OnRemoveEvents();
	}

	// Token: 0x06014E52 RID: 85586 RVA: 0x005C8981 File Offset: 0x005C6B81
	public override bool IsRouletteReplace()
	{
		return this.FuncReplaceId != null;
	}

	// Token: 0x06014E53 RID: 85587 RVA: 0x005C8993 File Offset: 0x005C6B93
	public override bool IsRouletteOpen()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10056);
	}

	// Token: 0x06014E54 RID: 85588 RVA: 0x005C89A4 File Offset: 0x005C6BA4
	public override bool IsMainRouletteCanOpenView(bool checkTips)
	{
		return ModelBase<RouletteModel>.Instance.IsFunctionRouletteOpen();
	}

	// Token: 0x06014E55 RID: 85589 RVA: 0x005C89B0 File Offset: 0x005C6BB0
	public override Dictionary<ERouletteGridType, List<AssemblyGridData>> CreateAssemblyGridData()
	{
		return new Dictionary<ERouletteGridType, List<AssemblyGridData>>
		{
			{
				ERouletteGridType.Function,
				this.CreateAllAssemblyDataFunction()
			}
		};
	}

	// Token: 0x06014E56 RID: 85590 RVA: 0x005C89C4 File Offset: 0x005C6BC4
	public override int? GetRouletteGridId(int index, ERouletteGridType type, bool useDisplay)
	{
		if (type != ERouletteGridType.Function)
		{
			return null;
		}
		if (useDisplay)
		{
			List<int> rouletteIdList = this.GetRouletteIdList();
			if (index >= 0 && index < rouletteIdList.Count)
			{
				return new int?(rouletteIdList[index]);
			}
			return null;
		}
		else
		{
			if (index >= 0 && index < this.RouletteIdListServer.Count)
			{
				return new int?(this.RouletteIdListServer[index]);
			}
			return null;
		}
	}

	// Token: 0x06014E57 RID: 85591 RVA: 0x005C8A3A File Offset: 0x005C6C3A
	public override RouletteMainViewProxyBase GetRouletteMainViewProxy()
	{
		return new RouletteMainViewProxy();
	}

	// Token: 0x06014E58 RID: 85592 RVA: 0x005C8A41 File Offset: 0x005C6C41
	[return: Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public override List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> GetRouletteDataMap()
	{
		return this.FunctionRouletteMap;
	}

	// Token: 0x06014E59 RID: 85593 RVA: 0x005C8A49 File Offset: 0x005C6C49
	protected void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
	}

	// Token: 0x06014E5A RID: 85594 RVA: 0x005C8A67 File Offset: 0x005C6C67
	protected void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
	}

	// Token: 0x06014E5B RID: 85595 RVA: 0x005C8A88 File Offset: 0x005C6C88
	private void InitFunctionRouletteReplaceConfig()
	{
		this.InstSubTypeWithReplaceList.Clear();
		this.InstId2ReplaceId.Clear();
		foreach (FuncMenuReplace funcMenuReplace in ConfigBase<RouletteConfig>.Instance.GetAllFuncReplaceConfig())
		{
			if (funcMenuReplace.InstIdListLength > 0)
			{
				foreach (int key in funcMenuReplace.GetInstIdListArray())
				{
					this.InstId2ReplaceId.Add(key, funcMenuReplace.Id);
				}
			}
			else if (funcMenuReplace.InstSubType != 0)
			{
				this.InstSubTypeWithReplaceList.Add(funcMenuReplace.InstSubType);
			}
		}
	}

	// Token: 0x06014E5C RID: 85596 RVA: 0x005C8B40 File Offset: 0x005C6D40
	private void OnWorldDone()
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		bool flag = this.InstId2ReplaceId.ContainsKey(instanceId);
		if (!ControllerBase<GameModeController>.Instance.IsInInstance() && !flag)
		{
			this.DisActiveFunctionRouletteReplaceConfig();
			return;
		}
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		if (config == null)
		{
			return;
		}
		this.TryActiveFunctionRouletteReplaceConfig(instanceId, config.Value.InstSubType);
	}

	// Token: 0x06014E5D RID: 85597 RVA: 0x005C8BA8 File Offset: 0x005C6DA8
	private void TryActiveFunctionRouletteReplaceConfig(int instId, int instSubType)
	{
		FuncMenuReplace? funcMenuReplace = null;
		int num = 0;
		int num2;
		if (this.InstId2ReplaceId.TryGetValue(instId, out num2))
		{
			funcMenuReplace = ConfigBase<RouletteConfig>.Instance.GetFuncReplaceConfigById(num2);
			num = num2;
		}
		else if (this.InstSubTypeWithReplaceList.Contains(instSubType))
		{
			funcMenuReplace = ConfigBase<RouletteConfig>.Instance.GetFuncReplaceConfig(instSubType);
			num = ((funcMenuReplace != null) ? funcMenuReplace.GetValueOrDefault().Id : 0);
		}
		if (num == 0 || funcMenuReplace == null)
		{
			this.DisActiveFunctionRouletteReplaceConfig();
			return;
		}
		int? funcReplaceId = this.FuncReplaceId;
		int num3 = num;
		if (funcReplaceId.GetValueOrDefault() == num3 & funcReplaceId != null)
		{
			return;
		}
		this.FuncReplaceId = new int?(num);
		if (funcMenuReplace.Value.FuncMenuIdListLength != 8)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[FunctionRoulette] 替换配置功能轮盘Id数量错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ReplaceId", num);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.RouletteIdListReplace.Clear();
		this.RouletteIdListReplace.AddRange(funcMenuReplace.Value.GetFuncMenuIdListArray());
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Phantom;
		ELogAuthor author2 = ELogAuthor.YYZ;
		string message2 = "[FunctionRoulette] 功能轮盘进入替换模式";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ReplaceId", this.FuncReplaceId);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
	}

	// Token: 0x06014E5E RID: 85598 RVA: 0x005C8CF0 File Offset: 0x005C6EF0
	private void DisActiveFunctionRouletteReplaceConfig()
	{
		if (this.FuncReplaceId == null)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Phantom;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[FunctionRoulette] 功能轮盘退出替换模式";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LastReplaceId", this.FuncReplaceId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.FuncReplaceId = null;
	}

	// Token: 0x06014E5F RID: 85599 RVA: 0x005C8D48 File Offset: 0x005C6F48
	private List<AssemblyGridData> CreateAllAssemblyDataFunction()
	{
		List<AssemblyFunctionGridData> list = new List<AssemblyFunctionGridData>();
		foreach (KeyValuePair<int, FuncMenuWheel> keyValuePair in ModelBase<RouletteModel>.Instance.UnlockFunctionDataMap)
		{
			int key = keyValuePair.Key;
			FuncMenuWheel value = keyValuePair.Value;
			if (value.ShowInAssembly)
			{
				list.Add(new AssemblyFunctionGridData
				{
					GridType = ERouletteGridType.Function,
					IconPath = ConfigBase<RouletteConfig>.Instance.GetFuncMenuIconPathByConfig(value),
					Name = value.FuncName,
					Id = key,
					SortId = value.FuncMenuSequence
				});
			}
		}
		list.Sort((AssemblyFunctionGridData dataA, AssemblyFunctionGridData dataB) => dataA.SortId - dataB.SortId);
		return list.Cast<AssemblyGridData>().ToList<AssemblyGridData>();
	}

	// Token: 0x0400A112 RID: 41234
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	private readonly List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> FunctionRouletteMap = new List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>>
	{
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			1
		}, ERouletteComponentNode.RouletteItem1, ERouletteGridType.Function),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			2
		}, ERouletteComponentNode.RouletteItem2, ERouletteGridType.Function),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			3
		}, ERouletteComponentNode.RouletteItem3, ERouletteGridType.Function),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			4
		}, ERouletteComponentNode.RouletteItem4, ERouletteGridType.Function),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			5
		}, ERouletteComponentNode.RouletteItem5, ERouletteGridType.Function),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			6
		}, ERouletteComponentNode.RouletteItem6, ERouletteGridType.Function),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			7
		}, ERouletteComponentNode.RouletteItem7, ERouletteGridType.Function),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			8
		}, ERouletteComponentNode.RouletteItem8, ERouletteGridType.Function)
	};

	// Token: 0x0400A113 RID: 41235
	private int? FuncReplaceId;

	// Token: 0x0400A114 RID: 41236
	private readonly List<int> InstSubTypeWithReplaceList = new List<int>();

	// Token: 0x0400A115 RID: 41237
	private readonly Dictionary<int, int> InstId2ReplaceId = new Dictionary<int, int>();

	// Token: 0x0400A116 RID: 41238
	private readonly List<int> RouletteIdListReplace = new List<int>();
}
