using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;

// Token: 0x02002924 RID: 10532
[NullableContext(1)]
[Nullable(0)]
public class RouletteListDataMotor : RouletteListDataBase
{
	// Token: 0x17001B78 RID: 7032
	// (get) Token: 0x06014E61 RID: 85601 RVA: 0x005C8F42 File Offset: 0x005C7142
	public override ERouletteType RouletteType
	{
		get
		{
			return ERouletteType.Motor;
		}
	}

	// Token: 0x17001B79 RID: 7033
	// (get) Token: 0x06014E62 RID: 85602 RVA: 0x005C8F45 File Offset: 0x005C7145
	public override ERoulettePriority Priority
	{
		get
		{
			return ERoulettePriority.Special;
		}
	}

	// Token: 0x06014E63 RID: 85603 RVA: 0x005C8F48 File Offset: 0x005C7148
	public override List<int> GetRouletteIdList()
	{
		return this.RouletteIdListServer;
	}

	// Token: 0x06014E64 RID: 85604 RVA: 0x005C8F50 File Offset: 0x005C7150
	public override int GetExtraItemId()
	{
		return 0;
	}

	// Token: 0x06014E65 RID: 85605 RVA: 0x005C8F53 File Offset: 0x005C7153
	public override int GetEquipExploreSkillId()
	{
		return this.EquipExploreSkillIdServer;
	}

	// Token: 0x06014E66 RID: 85606 RVA: 0x005C8F5B File Offset: 0x005C715B
	public override void Init()
	{
	}

	// Token: 0x06014E67 RID: 85607 RVA: 0x005C8F5D File Offset: 0x005C715D
	public override void Clear()
	{
	}

	// Token: 0x06014E68 RID: 85608 RVA: 0x005C8F5F File Offset: 0x005C715F
	public override bool IsActivate()
	{
		return this.InActivate;
	}

	// Token: 0x06014E69 RID: 85609 RVA: 0x005C8F68 File Offset: 0x005C7168
	private void Activate()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Phantom;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[RouletteMotor] 激活";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EquipSkillId", this.EquipExploreSkillIdServer);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ModelBase<CharacterExploreModel>.Instance.SetExploreSkillId(this.EquipExploreSkillIdServer, EExploreSkillLayer.Roulette, "摩托轮盘激活");
		ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest(this.EquipExploreSkillIdServer, null, false);
	}

	// Token: 0x06014E6A RID: 85610 RVA: 0x005C8FD0 File Offset: 0x005C71D0
	private void Deactivate()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Phantom;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[RouletteMotor] 取消激活";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EquipSkillId", this.EquipExploreSkillIdServer);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ModelBase<RouletteModel>.Instance.RecoverEquipExploreSkillId();
	}

	// Token: 0x06014E6B RID: 85611 RVA: 0x005C9018 File Offset: 0x005C7218
	public override bool IsRouletteReplace()
	{
		return false;
	}

	// Token: 0x06014E6C RID: 85612 RVA: 0x005C901C File Offset: 0x005C721C
	public override bool IsRouletteOpen()
	{
		ExploreRouletteType? exploreRouletteTypeById = ConfigBase<RouletteConfig>.Instance.GetExploreRouletteTypeById((int)this.RouletteType);
		return exploreRouletteTypeById != null && (exploreRouletteTypeById.Value.UnlockFuncId == 0 || ModelBase<FunctionModel>.Instance.IsOpen(exploreRouletteTypeById.Value.UnlockFuncId));
	}

	// Token: 0x06014E6D RID: 85613 RVA: 0x005C9074 File Offset: 0x005C7274
	public override bool IsMainRouletteCanOpenView(bool checkTips)
	{
		if (!this.IsRouletteOpen())
		{
			return false;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		object obj;
		if (getCurrentEntity == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = getCurrentEntity.Entity;
			obj = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null && obj2.HasAnyTag(ModelBase<RouletteModel>.Instance.GetExploreRouletteBanTagIds()))
		{
			if (checkTips)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ExploreToolCantOpen", Array.Empty<object>());
			}
			return false;
		}
		if (!ModelBase<LevelFuncFlagModel>.Instance.GetFuncFlagEnable(ELevelFuncFlagId.ExploreSkillRoulette))
		{
			if (checkTips)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ExploreToolCantOpen", Array.Empty<object>());
			}
			return false;
		}
		return true;
	}

	// Token: 0x06014E6E RID: 85614 RVA: 0x005C9105 File Offset: 0x005C7305
	public override Dictionary<ERouletteGridType, List<AssemblyGridData>> CreateAssemblyGridData()
	{
		return new Dictionary<ERouletteGridType, List<AssemblyGridData>>
		{
			{
				ERouletteGridType.Explore,
				this.CreateAllAssemblyDataExplore()
			}
		};
	}

	// Token: 0x06014E6F RID: 85615 RVA: 0x005C911C File Offset: 0x005C731C
	public override int? GetRouletteGridId(int index, ERouletteGridType type, bool useDisplay)
	{
		if (type != ERouletteGridType.Explore)
		{
			return null;
		}
		List<int> rouletteIdList = this.GetRouletteIdList();
		if (index >= 0 && index < rouletteIdList.Count)
		{
			return new int?(rouletteIdList[index]);
		}
		return null;
	}

	// Token: 0x06014E70 RID: 85616 RVA: 0x005C9160 File Offset: 0x005C7360
	public override RouletteMainViewProxyBase GetRouletteMainViewProxy()
	{
		return new MotorRouletteMainViewProxy();
	}

	// Token: 0x06014E71 RID: 85617 RVA: 0x005C9167 File Offset: 0x005C7367
	[return: Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public override List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> GetRouletteDataMap()
	{
		return this.MotorRouletteMap;
	}

	// Token: 0x06014E72 RID: 85618 RVA: 0x005C916F File Offset: 0x005C736F
	public void ChangeRouletteActivateStatus(bool bActive)
	{
		if (this.InActivate == bActive)
		{
			return;
		}
		this.InActivate = bActive;
		if (bActive)
		{
			this.Activate();
			return;
		}
		this.Deactivate();
	}

	// Token: 0x06014E73 RID: 85619 RVA: 0x005C9194 File Offset: 0x005C7394
	private List<AssemblyGridData> CreateAllAssemblyDataExplore()
	{
		List<AssemblyExploreGridData> list = new List<AssemblyExploreGridData>();
		foreach (KeyValuePair<int, ExploreTools> keyValuePair in ModelBase<RouletteModel>.Instance.UnlockExploreSkillDataMap)
		{
			int key = keyValuePair.Key;
			ExploreTools value = keyValuePair.Value;
			if (value.GetRouletteTypeArray().Contains((int)this.RouletteType) && value.CanAssemblyShow)
			{
				AssemblyExploreGridData assemblyExploreGridData = new AssemblyExploreGridData();
				assemblyExploreGridData.GridType = ERouletteGridType.Explore;
				assemblyExploreGridData.IconPath = value.BackGround;
				assemblyExploreGridData.Name = value.Name;
				assemblyExploreGridData.Id = key;
				int? sort = value.GetSort((int)this.RouletteType);
				if (sort != null && sort.Value > 0)
				{
					assemblyExploreGridData.SortId = sort.Value;
				}
				else
				{
					assemblyExploreGridData.SortId = 0;
				}
				list.Add(assemblyExploreGridData);
			}
		}
		list.Sort((AssemblyExploreGridData a, AssemblyExploreGridData b) => a.SortId - b.SortId);
		return list.Cast<AssemblyGridData>().ToList<AssemblyGridData>();
	}

	// Token: 0x0400A117 RID: 41239
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	private readonly List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> MotorRouletteMap = new List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>>
	{
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			1
		}, ERouletteComponentNode.RouletteItem1, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			2
		}, ERouletteComponentNode.RouletteItem2, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			3
		}, ERouletteComponentNode.RouletteItem3, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			4
		}, ERouletteComponentNode.RouletteItem4, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			5
		}, ERouletteComponentNode.RouletteItem5, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			6
		}, ERouletteComponentNode.RouletteItem6, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			7
		}, ERouletteComponentNode.RouletteItem7, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			8
		}, ERouletteComponentNode.RouletteItem8, ERouletteGridType.Explore)
	};

	// Token: 0x0400A118 RID: 41240
	private bool InActivate;
}
