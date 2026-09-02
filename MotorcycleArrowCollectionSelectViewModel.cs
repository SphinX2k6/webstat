using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

// Token: 0x02001D3D RID: 7485
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleArrowCollectionSelectViewModel
{
	// Token: 0x0600DC7A RID: 56442 RVA: 0x003B41FD File Offset: 0x003B23FD
	public static MotorcycleArrowCollectionSelectViewModel Create(MotorcycleArrowSubModel model)
	{
		return new MotorcycleArrowCollectionSelectViewModel
		{
			Model = model
		};
	}

	// Token: 0x0600DC7B RID: 56443 RVA: 0x003B420B File Offset: 0x003B240B
	private MotorcycleArrowCollectionSelectViewModel()
	{
	}

	// Token: 0x0600DC7C RID: 56444 RVA: 0x003B423F File Offset: 0x003B243F
	public void PushPendingData(MotorFightBossDropNotify data)
	{
		this.PendingData.Add(data);
	}

	// Token: 0x0600DC7D RID: 56445 RVA: 0x003B4250 File Offset: 0x003B2450
	public bool SetCollectionList(MotorFightBossDropNotify dropData)
	{
		this.SubLevelIndex = dropData.SubLevelIndex;
		this.WaveGroupIndex = dropData.WaveGroupIndex;
		this.BossId = dropData.BossId;
		this.UpdateDrop(dropData.Drops);
		this.SetSelectCollectionId(null);
		this.RemainRefreshCount = this.MaxRefreshCount;
		return true;
	}

	// Token: 0x0600DC7E RID: 56446 RVA: 0x003B42AC File Offset: 0x003B24AC
	public void UpdateDrop(RepeatedField<MotorFightCollectionDrop> drops)
	{
		this.CollectionList.Clear();
		for (int i = 0; i < drops.Count; i++)
		{
			MotorFightCollectionDrop motorFightCollectionDrop = drops[i];
			MotorFightItem? config = ConfigMotorFightItemById.GetConfig(motorFightCollectionDrop.CollectionId, true);
			if (config != null)
			{
				MotorcycleArrowCollectionItemData item = MotorcycleArrowCollectionItemData.Create(config.Value, (int)motorFightCollectionDrop.Pos);
				this.CollectionList.Add(item);
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiModel;
				ELogAuthor author = ELogAuthor.TZQ;
				string message = "[摩托战斗]不存在的藏品配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", motorFightCollectionDrop.CollectionId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
	}

	// Token: 0x0600DC7F RID: 56447 RVA: 0x003B4348 File Offset: 0x003B2548
	public void SetSelectCollectionId(int? id)
	{
		MotorcycleArrowCollectionItemData selectCollectionItem = null;
		if (id != null)
		{
			for (int i = 0; i < this.CollectionList.Count; i++)
			{
				if (this.CollectionList[i].Id == id.Value)
				{
					selectCollectionItem = this.CollectionList[i];
					break;
				}
			}
		}
		this.SetSelectCollectionItem(selectCollectionItem);
	}

	// Token: 0x0600DC80 RID: 56448 RVA: 0x003B43A6 File Offset: 0x003B25A6
	[NullableContext(2)]
	public void SetSelectCollectionItem(MotorcycleArrowCollectionItemData collectionItem)
	{
		this.CurSelectCollectionItem = collectionItem;
	}

	// Token: 0x0600DC81 RID: 56449 RVA: 0x003B43AF File Offset: 0x003B25AF
	public void SetMaxRefreshCount(int count)
	{
		this.MaxRefreshCount = count;
	}

	// Token: 0x0600DC82 RID: 56450 RVA: 0x003B43B8 File Offset: 0x003B25B8
	public void SetRemainRefreshCount(int count)
	{
		this.RemainRefreshCount = count;
	}

	// Token: 0x0600DC83 RID: 56451 RVA: 0x003B43C1 File Offset: 0x003B25C1
	public void OnOpenView()
	{
		this.ShowingViewProcess = true;
	}

	// Token: 0x0600DC84 RID: 56452 RVA: 0x003B43CC File Offset: 0x003B25CC
	public void OnViewClose()
	{
		this.ShowingViewProcess = false;
		if (this.PendingData.Count > 0)
		{
			MotorFightBossDropNotify collectionList = this.PendingData[0];
			this.PendingData.RemoveAt(0);
			this.SetCollectionList(collectionList);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleArrowCollectionSelectView, this, null);
		}
	}

	// Token: 0x0600DC85 RID: 56453 RVA: 0x003B4420 File Offset: 0x003B2620
	public void ViewProcessFinish()
	{
		this.ShowingViewProcess = false;
	}

	// Token: 0x17001168 RID: 4456
	// (get) Token: 0x0600DC86 RID: 56454 RVA: 0x003B4429 File Offset: 0x003B2629
	public MotorcycleArrowSubController Controller
	{
		get
		{
			return (MotorcycleArrowSubController)ControllerBase<KuroSimpleCombatController>.Instance.CurSubController;
		}
	}

	// Token: 0x0600DC87 RID: 56455 RVA: 0x003B443C File Offset: 0x003B263C
	[NullableContext(0)]
	public UniTask<bool> RequestCollectionSelect()
	{
		MotorcycleArrowCollectionSelectViewModel.<RequestCollectionSelect>d__24 <RequestCollectionSelect>d__;
		<RequestCollectionSelect>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestCollectionSelect>d__.<>4__this = this;
		<RequestCollectionSelect>d__.<>1__state = -1;
		<RequestCollectionSelect>d__.<>t__builder.Start<MotorcycleArrowCollectionSelectViewModel.<RequestCollectionSelect>d__24>(ref <RequestCollectionSelect>d__);
		return <RequestCollectionSelect>d__.<>t__builder.Task;
	}

	// Token: 0x0600DC88 RID: 56456 RVA: 0x003B4480 File Offset: 0x003B2680
	[NullableContext(0)]
	public UniTask<bool> RequestUpdateCollectionList()
	{
		MotorcycleArrowCollectionSelectViewModel.<RequestUpdateCollectionList>d__25 <RequestUpdateCollectionList>d__;
		<RequestUpdateCollectionList>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestUpdateCollectionList>d__.<>4__this = this;
		<RequestUpdateCollectionList>d__.<>1__state = -1;
		<RequestUpdateCollectionList>d__.<>t__builder.Start<MotorcycleArrowCollectionSelectViewModel.<RequestUpdateCollectionList>d__25>(ref <RequestUpdateCollectionList>d__);
		return <RequestUpdateCollectionList>d__.<>t__builder.Task;
	}

	// Token: 0x0600DC89 RID: 56457 RVA: 0x003B44C4 File Offset: 0x003B26C4
	public void AddItemData(int itemId)
	{
		MotorFightItem? config = ConfigMotorFightItemById.GetConfig(itemId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiModel;
			ELogAuthor author = ELogAuthor.TZQ;
			string message = "[摩托战斗]不存在的藏品配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		MotorFightItem value = config.Value;
		MotorcycleArrowCollectionItemData itemData;
		if (this.ItemDataMap.TryGetValue(value.Id, out itemData))
		{
			this.TypeToItemDataMap[value.Type].AddItemData(itemData, false);
			return;
		}
		MotorcycleArrowCollectionItemData motorcycleArrowCollectionItemData = MotorcycleArrowCollectionItemData.Create(value, 0);
		this.ItemDataMap[value.Id] = motorcycleArrowCollectionItemData;
		int type = value.Type;
		MotorcycleArrowCollectionTypeItemData motorcycleArrowCollectionTypeItemData;
		if (!this.TypeToItemDataMap.TryGetValue(type, out motorcycleArrowCollectionTypeItemData))
		{
			motorcycleArrowCollectionTypeItemData = new MotorcycleArrowCollectionTypeItemData(type);
			this.TypeToItemDataMap[type] = motorcycleArrowCollectionTypeItemData;
		}
		motorcycleArrowCollectionTypeItemData.AddItemData(motorcycleArrowCollectionItemData, true);
	}

	// Token: 0x0600DC8A RID: 56458 RVA: 0x003B45A0 File Offset: 0x003B27A0
	public List<int> GetSortedMotorFightItemTypeList()
	{
		List<MotorcycleArrowCollectionTypeItemData> list = new List<MotorcycleArrowCollectionTypeItemData>(this.TypeToItemDataMap.Values);
		list.Sort(delegate(MotorcycleArrowCollectionTypeItemData a, MotorcycleArrowCollectionTypeItemData b)
		{
			if (a.TotalCount != b.TotalCount)
			{
				return b.TotalCount - a.TotalCount;
			}
			for (int j = 5; j >= 1; j--)
			{
				int itemNumWithQuality = a.GetItemNumWithQuality(j);
				int itemNumWithQuality2 = b.GetItemNumWithQuality(j);
				if (itemNumWithQuality != itemNumWithQuality2)
				{
					return itemNumWithQuality2 - itemNumWithQuality;
				}
			}
			return 0;
		});
		List<int> list2 = new List<int>();
		for (int i = 0; i < list.Count; i++)
		{
			list2.Add(list[i].Type);
		}
		return list2;
	}

	// Token: 0x0600DC8B RID: 56459 RVA: 0x003B4610 File Offset: 0x003B2810
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<MotorcycleArrowCollectionItemData> GetMotorFightItemDataListByType(int type)
	{
		MotorcycleArrowCollectionTypeItemData motorcycleArrowCollectionTypeItemData;
		if (!this.TypeToItemDataMap.TryGetValue(type, out motorcycleArrowCollectionTypeItemData))
		{
			return null;
		}
		List<MotorcycleArrowCollectionItemData> itemList = motorcycleArrowCollectionTypeItemData.ItemList;
		itemList.Sort(delegate(MotorcycleArrowCollectionItemData a, MotorcycleArrowCollectionItemData b)
		{
			if (a.Config.Quality != b.Config.Quality)
			{
				return b.Config.Quality - a.Config.Quality;
			}
			if (a.Num != b.Num)
			{
				return b.Num - a.Num;
			}
			return b.Id - a.Id;
		});
		return itemList;
	}

	// Token: 0x0600DC8C RID: 56460 RVA: 0x003B465A File Offset: 0x003B285A
	public List<MotorcycleArrowCollectionItemData> GetAllMotorFightItemData()
	{
		return new List<MotorcycleArrowCollectionItemData>(this.ItemDataMap.Values);
	}

	// Token: 0x0600DC8D RID: 56461 RVA: 0x003B466C File Offset: 0x003B286C
	public bool IsMotorFightItemEmpty()
	{
		return this.ItemDataMap.Count <= 0;
	}

	// Token: 0x0600DC8E RID: 56462 RVA: 0x003B467F File Offset: 0x003B287F
	public void Clear()
	{
		this.ItemDataMap.Clear();
		this.TypeToItemDataMap.Clear();
		this.PendingData.Clear();
	}

	// Token: 0x04006988 RID: 27016
	public MotorcycleArrowSubModel Model;

	// Token: 0x04006989 RID: 27017
	public readonly List<MotorcycleArrowCollectionItemData> CollectionList = new List<MotorcycleArrowCollectionItemData>();

	// Token: 0x0400698A RID: 27018
	[Nullable(2)]
	public MotorcycleArrowCollectionItemData CurSelectCollectionItem;

	// Token: 0x0400698B RID: 27019
	public int SubLevelIndex;

	// Token: 0x0400698C RID: 27020
	public int WaveGroupIndex;

	// Token: 0x0400698D RID: 27021
	public int BossId;

	// Token: 0x0400698E RID: 27022
	public int MaxRefreshCount;

	// Token: 0x0400698F RID: 27023
	public int RemainRefreshCount;

	// Token: 0x04006990 RID: 27024
	public bool ShowingViewProcess;

	// Token: 0x04006991 RID: 27025
	public List<MotorFightBossDropNotify> PendingData = new List<MotorFightBossDropNotify>();

	// Token: 0x04006992 RID: 27026
	private readonly Dictionary<int, MotorcycleArrowCollectionItemData> ItemDataMap = new Dictionary<int, MotorcycleArrowCollectionItemData>();

	// Token: 0x04006993 RID: 27027
	private readonly Dictionary<int, MotorcycleArrowCollectionTypeItemData> TypeToItemDataMap = new Dictionary<int, MotorcycleArrowCollectionTypeItemData>();
}
