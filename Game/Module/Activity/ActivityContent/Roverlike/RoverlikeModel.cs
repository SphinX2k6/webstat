using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063B7 RID: 25527
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class RoverlikeModel : ModelBase<RoverlikeModel>
	{
		// Token: 0x17009D8C RID: 40332
		// (get) Token: 0x060401BE RID: 262590 RVA: 0x0106F1B6 File Offset: 0x0106D3B6
		// (set) Token: 0x060401BF RID: 262591 RVA: 0x0106F1C3 File Offset: 0x0106D3C3
		public string CurRoomMusicState
		{
			get
			{
				return this.CurRoomMusicStateInternal.State;
			}
			set
			{
				this.CurRoomMusicStateInternal.State = (value ?? "none");
			}
		}

		// Token: 0x060401C0 RID: 262592 RVA: 0x0106F1DA File Offset: 0x0106D3DA
		public void CreateInstanceData()
		{
			this.ClearInstanceData();
			this.InstanceData = RoverlikeInstanceData.Create();
		}

		// Token: 0x060401C1 RID: 262593 RVA: 0x0106F1ED File Offset: 0x0106D3ED
		public void ClearInstanceData()
		{
			if (this.InstanceData != null)
			{
				this.InstanceData.Clear();
				this.InstanceData = null;
			}
			this.ClearActionData();
			this.ClearFloatText();
		}

		// Token: 0x060401C2 RID: 262594 RVA: 0x0106F215 File Offset: 0x0106D415
		public int GetMainRoleId()
		{
			if (ModelBase<WorldLevelModel>.Instance.Sex != 1)
			{
				return 5053001;
			}
			return 5053002;
		}

		// Token: 0x060401C3 RID: 262595 RVA: 0x0106F230 File Offset: 0x0106D430
		public int GetCurrency(int configId)
		{
			int result;
			if (!this.CurrencyCountMap.TryGetValue(configId, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x17009D8D RID: 40333
		// (get) Token: 0x060401C4 RID: 262596 RVA: 0x0106F250 File Offset: 0x0106D450
		public int? GoldItemId
		{
			get
			{
				RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
				RoverlikeActivityData roverlikeActivityData = (instance != null) ? instance.GetCurrentActivityData() : null;
				if (roverlikeActivityData == null)
				{
					return null;
				}
				return new int?(roverlikeActivityData.GetParamConfig().Value.InsideCurrencyItemId);
			}
		}

		// Token: 0x17009D8E RID: 40334
		// (get) Token: 0x060401C5 RID: 262597 RVA: 0x0106F298 File Offset: 0x0106D498
		public int Gold
		{
			get
			{
				if (this.GoldItemId == null)
				{
					return 0;
				}
				int result;
				if (!this.CurrencyCountMap.TryGetValue(this.GoldItemId.Value, out result))
				{
					return 0;
				}
				return result;
			}
		}

		// Token: 0x060401C6 RID: 262598 RVA: 0x0106F2D8 File Offset: 0x0106D4D8
		public void UpdateCurrency([Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<RoverRogueItemCurrencyData> itemData)
		{
			foreach (RoverRogueItemCurrencyData roverRogueItemCurrencyData in (itemData ?? new List<RoverRogueItemCurrencyData>()))
			{
				this.UpdateCurrencyByItemId(roverRogueItemCurrencyData.ItemId, roverRogueItemCurrencyData.Count);
			}
		}

		// Token: 0x060401C7 RID: 262599 RVA: 0x0106F334 File Offset: 0x0106D534
		public void UpdateCurrencyByItemId(int itemId, int count)
		{
			this.CurrencyCountMap[itemId] = count;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPlayerCurrencyChange, itemId);
		}

		// Token: 0x060401C8 RID: 262600 RVA: 0x0106F354 File Offset: 0x0106D554
		public void SetCurrentRunRoleTypeId(int roleTypeId)
		{
			this.CurrentRunRoleTypeId = roleTypeId;
		}

		// Token: 0x060401C9 RID: 262601 RVA: 0x0106F35D File Offset: 0x0106D55D
		public void SaveLastPassRoleTypeId()
		{
			if (this.CurrentRunRoleTypeId <= 0)
			{
				return;
			}
			LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.RoverRogueLastPassRoleType, this.CurrentRunRoleTypeId);
		}

		// Token: 0x060401CA RID: 262602 RVA: 0x0106F37A File Offset: 0x0106D57A
		public int GetLastPassRoleTypeId()
		{
			return LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.RoverRogueLastPassRoleType, 0);
		}

		// Token: 0x060401CB RID: 262603 RVA: 0x0106F387 File Offset: 0x0106D587
		public void CreateActionData()
		{
			this.ClearActionData();
			this.ActionData = new RoverlikeActionData();
			this.ActionSubViewManager = new RoverlikeActionSubViewManager();
			this.ActionStack = new RoverlikeActionStack();
		}

		// Token: 0x060401CC RID: 262604 RVA: 0x0106F3B0 File Offset: 0x0106D5B0
		public void ClearActionData()
		{
			if (this.ActionData != null)
			{
				this.ActionData.Clear();
				this.ActionData = null;
			}
			if (this.ActionSubViewManager != null)
			{
				this.ActionSubViewManager.Dispose();
				this.ActionSubViewManager = null;
			}
			if (this.ActionStack != null)
			{
				this.ActionStack.Clear();
				this.ActionStack = null;
			}
		}

		// Token: 0x17009D8F RID: 40335
		// (get) Token: 0x060401CD RID: 262605 RVA: 0x0106F40B File Offset: 0x0106D60B
		public bool NeedOpenMainView
		{
			get
			{
				bool hasNewSettle = this.HasNewSettle;
				this.HasNewSettle = false;
				return hasNewSettle;
			}
		}

		// Token: 0x060401CE RID: 262606 RVA: 0x0106F41A File Offset: 0x0106D61A
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x060401CF RID: 262607 RVA: 0x0106F41D File Offset: 0x0106D61D
		protected override bool OnClear()
		{
			this.ClearInstanceData();
			return true;
		}

		// Token: 0x060401D0 RID: 262608 RVA: 0x0106F428 File Offset: 0x0106D628
		public void EnqueueFloatText(List<IRoverlikeFloatTextData> list)
		{
			foreach (IRoverlikeFloatTextData item in list)
			{
				this.FloatTextQueue.Add(item);
			}
		}

		// Token: 0x17009D90 RID: 40336
		// (get) Token: 0x060401D1 RID: 262609 RVA: 0x0106F47C File Offset: 0x0106D67C
		public bool IsFloatTextEmpty
		{
			get
			{
				return this.FloatTextQueue.Count <= 0;
			}
		}

		// Token: 0x060401D2 RID: 262610 RVA: 0x0106F48F File Offset: 0x0106D68F
		[NullableContext(2)]
		public IRoverlikeFloatTextData ShiftFloatText()
		{
			if (this.FloatTextQueue.Count <= 0)
			{
				return null;
			}
			IRoverlikeFloatTextData result = this.FloatTextQueue[0];
			this.FloatTextQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x060401D3 RID: 262611 RVA: 0x0106F4B9 File Offset: 0x0106D6B9
		public void ClearFloatText()
		{
			this.FloatTextQueue.Clear();
		}

		// Token: 0x060401D4 RID: 262612 RVA: 0x0106F4C6 File Offset: 0x0106D6C6
		public void UpdateReviveTimes(int reviveTimes, int reviveTimesMax)
		{
			this.ReviveTimes = reviveTimes;
			this.ReviveTimesMax = reviveTimesMax;
		}

		// Token: 0x060401D5 RID: 262613 RVA: 0x0106F4D6 File Offset: 0x0106D6D6
		public bool ConsumeReviveTimes()
		{
			if (this.ReviveTimes > 0)
			{
				this.ReviveTimes--;
				return true;
			}
			return false;
		}

		// Token: 0x060401D6 RID: 262614 RVA: 0x0106F4F2 File Offset: 0x0106D6F2
		public bool HasReviveTimes()
		{
			return this.ReviveTimes > 0;
		}

		// Token: 0x060401D7 RID: 262615 RVA: 0x0106F4FD File Offset: 0x0106D6FD
		public int GetReviveTimes()
		{
			return this.ReviveTimes;
		}

		// Token: 0x060401D8 RID: 262616 RVA: 0x0106F505 File Offset: 0x0106D705
		public int GetReviveTimesMax()
		{
			return this.ReviveTimesMax;
		}

		// Token: 0x04023FB2 RID: 147378
		private readonly StateRef CurRoomMusicStateInternal = new StateRef("game_rogue_room_type", "none");

		// Token: 0x04023FB3 RID: 147379
		[Nullable(2)]
		public RoverlikeInstanceData InstanceData;

		// Token: 0x04023FB4 RID: 147380
		private readonly Dictionary<int, int> CurrencyCountMap = new Dictionary<int, int>();

		// Token: 0x04023FB5 RID: 147381
		private int CurrentRunRoleTypeId;

		// Token: 0x04023FB6 RID: 147382
		[Nullable(2)]
		public RoverlikeActionData ActionData;

		// Token: 0x04023FB7 RID: 147383
		[Nullable(2)]
		public RoverlikeActionStack ActionStack;

		// Token: 0x04023FB8 RID: 147384
		[Nullable(2)]
		public RoverlikeActionSubViewManager ActionSubViewManager;

		// Token: 0x04023FB9 RID: 147385
		public bool HasNewSettle;

		// Token: 0x04023FBA RID: 147386
		private readonly List<IRoverlikeFloatTextData> FloatTextQueue = new List<IRoverlikeFloatTextData>();

		// Token: 0x04023FBB RID: 147387
		private int ReviveTimes;

		// Token: 0x04023FBC RID: 147388
		private int ReviveTimesMax;
	}
}
