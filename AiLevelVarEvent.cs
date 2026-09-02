using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Monster.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02000D05 RID: 3333
[NullableContext(1)]
[Nullable(0)]
public class AiLevelVarEvent
{
	// Token: 0x060042AA RID: 17066 RVA: 0x00077F20 File Offset: 0x00076120
	public void AddLevelVarEvent(SAiLevelVar levelVar, UKuroBooleanEventBinder boolEventBinder)
	{
		switch (levelVar.VarSource)
		{
		case EAiLevelVarSource.Global:
		{
			PlayerVarEventPair playerVarEventPair = new PlayerVarEventPair();
			if (playerVarEventPair.Init(levelVar, boolEventBinder))
			{
				this.PlayerVarEventPairs.Add(playerVarEventPair);
			}
			break;
		}
		case EAiLevelVarSource.SelfEntity:
		case EAiLevelVarSource.OtherEntity:
		{
			EntityVarEventPair entityVarEventPair = new EntityVarEventPair();
			if (entityVarEventPair.Init(levelVar, boolEventBinder))
			{
				this.EntityVarEventPairs.Add(entityVarEventPair);
			}
			break;
		}
		case EAiLevelVarSource.Quest:
		case EAiLevelVarSource.LevelPlay:
		{
			TreeVarEventPair treeVarEventPair = new TreeVarEventPair();
			if (treeVarEventPair.Init(levelVar, boolEventBinder))
			{
				this.TreeVarEventPairs.Add(treeVarEventPair);
			}
			break;
		}
		}
		if (this.TreeVarEventPairs.Count > 0 && !Singleton<EventSystem>.Instance.Has(EEventName.GeneralLogicTreeViewForceRefresh, new Action<long>(this.OnReceiveTreeVar)))
		{
			Singleton<EventSystem>.Instance.Add(EEventName.GeneralLogicTreeViewForceRefresh, new Action<long>(this.OnReceiveTreeVar));
		}
		if (this.TreeVarEventPairs.Count > 0 && !Singleton<EventSystem>.Instance.Has(EEventName.OnReceivePlayerVar, new Action<IReadOnlyDictionary<string, VarDefinePb>>(this.OnReceivePlayerVar)))
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlyDictionary<string, VarDefinePb>>(EEventName.OnReceivePlayerVar, new Action<IReadOnlyDictionary<string, VarDefinePb>>(this.OnReceivePlayerVar));
		}
	}

	// Token: 0x060042AB RID: 17067 RVA: 0x0007803C File Offset: 0x0007623C
	public void AddLevelVarEvent(SAiLevelVar levelVar, UKuroIntEventBinder intEventBinder)
	{
		switch (levelVar.VarSource)
		{
		case EAiLevelVarSource.Global:
		{
			PlayerVarEventPair playerVarEventPair = new PlayerVarEventPair();
			if (playerVarEventPair.Init(levelVar, intEventBinder))
			{
				this.PlayerVarEventPairs.Add(playerVarEventPair);
			}
			break;
		}
		case EAiLevelVarSource.SelfEntity:
		case EAiLevelVarSource.OtherEntity:
		{
			EntityVarEventPair entityVarEventPair = new EntityVarEventPair();
			if (entityVarEventPair.Init(levelVar, intEventBinder))
			{
				this.EntityVarEventPairs.Add(entityVarEventPair);
			}
			break;
		}
		case EAiLevelVarSource.Quest:
		case EAiLevelVarSource.LevelPlay:
		{
			TreeVarEventPair treeVarEventPair = new TreeVarEventPair();
			if (treeVarEventPair.Init(levelVar, intEventBinder))
			{
				this.TreeVarEventPairs.Add(treeVarEventPair);
			}
			break;
		}
		}
		if (this.TreeVarEventPairs.Count > 0 && !Singleton<EventSystem>.Instance.Has(EEventName.GeneralLogicTreeViewForceRefresh, new Action<long>(this.OnReceiveTreeVar)))
		{
			Singleton<EventSystem>.Instance.Add(EEventName.GeneralLogicTreeViewForceRefresh, new Action<long>(this.OnReceiveTreeVar));
		}
		if (this.TreeVarEventPairs.Count > 0 && !Singleton<EventSystem>.Instance.Has(EEventName.OnReceivePlayerVar, new Action<IReadOnlyDictionary<string, VarDefinePb>>(this.OnReceivePlayerVar)))
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlyDictionary<string, VarDefinePb>>(EEventName.OnReceivePlayerVar, new Action<IReadOnlyDictionary<string, VarDefinePb>>(this.OnReceivePlayerVar));
		}
	}

	// Token: 0x060042AC RID: 17068 RVA: 0x00078158 File Offset: 0x00076358
	public bool RemoveLevelVarEvent(UKuroBooleanEventBinder boolEventBinder)
	{
		int num = 0;
		foreach (EntityVarEventPair entityVarEventPair in this.EntityVarEventPairs)
		{
			if (entityVarEventPair.BoolEventBinder == boolEventBinder)
			{
				entityVarEventPair.Clear();
				break;
			}
			num++;
		}
		if (num < this.EntityVarEventPairs.Count)
		{
			this.EntityVarEventPairs.RemoveRange(num, this.EntityVarEventPairs.Count - num);
			return true;
		}
		num = 0;
		foreach (TreeVarEventPair treeVarEventPair in this.TreeVarEventPairs)
		{
			if (treeVarEventPair.BoolEventBinder == boolEventBinder)
			{
				treeVarEventPair.Clear();
				break;
			}
			num++;
		}
		if (num < this.TreeVarEventPairs.Count)
		{
			this.TreeVarEventPairs.RemoveRange(num, this.TreeVarEventPairs.Count - num);
			if (this.TreeVarEventPairs.Count == 0 && Singleton<EventSystem>.Instance.Has(EEventName.GeneralLogicTreeViewForceRefresh, new Action<long>(this.OnReceiveTreeVar)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeViewForceRefresh, new Action<long>(this.OnReceiveTreeVar));
			}
			return true;
		}
		num = 0;
		foreach (PlayerVarEventPair playerVarEventPair in this.PlayerVarEventPairs)
		{
			if (playerVarEventPair.BoolEventBinder == boolEventBinder)
			{
				playerVarEventPair.Clear();
				break;
			}
			num++;
		}
		if (num < this.PlayerVarEventPairs.Count)
		{
			this.PlayerVarEventPairs.RemoveRange(num, this.PlayerVarEventPairs.Count - num);
			if (this.PlayerVarEventPairs.Count == 0 && Singleton<EventSystem>.Instance.Has(EEventName.OnReceivePlayerVar, new Action<IReadOnlyDictionary<string, VarDefinePb>>(this.OnReceivePlayerVar)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnReceivePlayerVar, new Action<IReadOnlyDictionary<string, VarDefinePb>>(this.OnReceivePlayerVar));
			}
			return true;
		}
		return false;
	}

	// Token: 0x060042AD RID: 17069 RVA: 0x00078370 File Offset: 0x00076570
	public bool RemoveLevelVarEvent(UKuroIntEventBinder intEventBinder)
	{
		int num = 0;
		foreach (EntityVarEventPair entityVarEventPair in this.EntityVarEventPairs)
		{
			if (entityVarEventPair.IntEventBinder == intEventBinder)
			{
				entityVarEventPair.Clear();
				break;
			}
			num++;
		}
		if (num < this.EntityVarEventPairs.Count)
		{
			this.EntityVarEventPairs.RemoveRange(num, this.EntityVarEventPairs.Count - num);
			return true;
		}
		num = 0;
		foreach (TreeVarEventPair treeVarEventPair in this.TreeVarEventPairs)
		{
			if (treeVarEventPair.IntEventBinder == intEventBinder)
			{
				treeVarEventPair.Clear();
				break;
			}
			num++;
		}
		if (num < this.TreeVarEventPairs.Count)
		{
			this.TreeVarEventPairs.RemoveRange(num, this.TreeVarEventPairs.Count - num);
			if (this.TreeVarEventPairs.Count == 0 && Singleton<EventSystem>.Instance.Has(EEventName.GeneralLogicTreeViewForceRefresh, new Action<long>(this.OnReceiveTreeVar)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeViewForceRefresh, new Action<long>(this.OnReceiveTreeVar));
			}
			return true;
		}
		num = 0;
		foreach (PlayerVarEventPair playerVarEventPair in this.PlayerVarEventPairs)
		{
			if (playerVarEventPair.IntEventBinder == intEventBinder)
			{
				playerVarEventPair.Clear();
				break;
			}
			num++;
		}
		if (num < this.PlayerVarEventPairs.Count)
		{
			this.PlayerVarEventPairs.RemoveRange(num, this.PlayerVarEventPairs.Count - num);
			if (this.PlayerVarEventPairs.Count == 0 && Singleton<EventSystem>.Instance.Has(EEventName.OnReceivePlayerVar, new Action<IReadOnlyDictionary<string, VarDefinePb>>(this.OnReceivePlayerVar)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnReceivePlayerVar, new Action<IReadOnlyDictionary<string, VarDefinePb>>(this.OnReceivePlayerVar));
			}
			return true;
		}
		return false;
	}

	// Token: 0x060042AE RID: 17070 RVA: 0x00078588 File Offset: 0x00076788
	private void OnReceiveTreeVar(long treeId)
	{
		foreach (TreeVarEventPair treeVarEventPair in this.TreeVarEventPairs)
		{
			long? treeIncId = treeVarEventPair.TreeIncId;
			if (treeIncId.GetValueOrDefault() == treeId & treeIncId != null)
			{
				treeVarEventPair.OnReceiveTreeVar();
			}
		}
	}

	// Token: 0x060042AF RID: 17071 RVA: 0x000785F8 File Offset: 0x000767F8
	private void OnReceivePlayerVar(IReadOnlyDictionary<string, VarDefinePb> varInfos)
	{
		foreach (PlayerVarEventPair playerVarEventPair in this.PlayerVarEventPairs)
		{
			playerVarEventPair.OnReceivePlayerVar();
		}
	}

	// Token: 0x060042B0 RID: 17072 RVA: 0x00078648 File Offset: 0x00076848
	public void Clear()
	{
		foreach (EntityVarEventPair entityVarEventPair in this.EntityVarEventPairs)
		{
			entityVarEventPair.Clear();
		}
		this.EntityVarEventPairs.Clear();
		foreach (TreeVarEventPair treeVarEventPair in this.TreeVarEventPairs)
		{
			treeVarEventPair.Clear();
		}
		this.TreeVarEventPairs.Clear();
		foreach (PlayerVarEventPair playerVarEventPair in this.PlayerVarEventPairs)
		{
			playerVarEventPair.Clear();
		}
		this.PlayerVarEventPairs.Clear();
		if (Singleton<EventSystem>.Instance.Has(EEventName.GeneralLogicTreeViewForceRefresh, new Action<long>(this.OnReceiveTreeVar)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeViewForceRefresh, new Action<long>(this.OnReceiveTreeVar));
		}
		if (Singleton<EventSystem>.Instance.Has(EEventName.OnReceivePlayerVar, new Action<IReadOnlyDictionary<string, VarDefinePb>>(this.OnReceivePlayerVar)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnReceivePlayerVar, new Action<IReadOnlyDictionary<string, VarDefinePb>>(this.OnReceivePlayerVar));
		}
	}

	// Token: 0x040010F0 RID: 4336
	private readonly List<EntityVarEventPair> EntityVarEventPairs = new List<EntityVarEventPair>();

	// Token: 0x040010F1 RID: 4337
	private readonly List<TreeVarEventPair> TreeVarEventPairs = new List<TreeVarEventPair>();

	// Token: 0x040010F2 RID: 4338
	private readonly List<PlayerVarEventPair> PlayerVarEventPairs = new List<PlayerVarEventPair>();
}
