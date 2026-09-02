using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Module.TowerDefenseEvent;
using CSharpScript.Game.Module.TowerDefenseEvent.Model;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D99 RID: 7577
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseBuildTipsPanel : BattleChildViewPanel
{
	// Token: 0x1700117E RID: 4478
	// (get) Token: 0x0600DF3E RID: 57150 RVA: 0x003C109F File Offset: 0x003BF29F
	private bool IsInBuild
	{
		get
		{
			return (this.Type & ETrapDefenseBuildTipsType.Build) > ETrapDefenseBuildTipsType.None && this.IsInSelectBuild;
		}
	}

	// Token: 0x1700117F RID: 4479
	// (get) Token: 0x0600DF3F RID: 57151 RVA: 0x003C10B4 File Offset: 0x003BF2B4
	private bool IsInRecycle
	{
		get
		{
			return (this.Type & ETrapDefenseBuildTipsType.Recycle) > ETrapDefenseBuildTipsType.None;
		}
	}

	// Token: 0x17001180 RID: 4480
	// (get) Token: 0x0600DF40 RID: 57152 RVA: 0x003C10C1 File Offset: 0x003BF2C1
	private bool IsInPollute
	{
		get
		{
			return (this.Type & ETrapDefenseBuildTipsType.Pollute) > ETrapDefenseBuildTipsType.None && this.IsInSelectBuild;
		}
	}

	// Token: 0x17001181 RID: 4481
	// (get) Token: 0x0600DF41 RID: 57153 RVA: 0x003C10D6 File Offset: 0x003BF2D6
	private bool IsInRotate
	{
		get
		{
			return (this.Type & ETrapDefenseBuildTipsType.Rotate) > ETrapDefenseBuildTipsType.None && this.IsInBuild;
		}
	}

	// Token: 0x17001182 RID: 4482
	// (get) Token: 0x0600DF42 RID: 57154 RVA: 0x003C10EB File Offset: 0x003BF2EB
	private bool IsInDisable
	{
		get
		{
			return (this.Type & ETrapDefenseBuildTipsType.Disable) > ETrapDefenseBuildTipsType.None && this.IsInSelectBuild;
		}
	}

	// Token: 0x0600DF43 RID: 57155 RVA: 0x003C1104 File Offset: 0x003BF304
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText))
		};
	}

	// Token: 0x0600DF44 RID: 57156 RVA: 0x003C1210 File Offset: 0x003BF410
	public override UniTask InitializeAsync()
	{
		TrapDefenseBuildTipsPanel.<InitializeAsync>d__26 <InitializeAsync>d__;
		<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeAsync>d__.<>4__this = this;
		<InitializeAsync>d__.<>1__state = -1;
		<InitializeAsync>d__.<>t__builder.Start<TrapDefenseBuildTipsPanel.<InitializeAsync>d__26>(ref <InitializeAsync>d__);
		return <InitializeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DF45 RID: 57157 RVA: 0x003C1254 File Offset: 0x003BF454
	public override void InitializeTemp()
	{
		this.Sequence = new UiSequencePlayer(base.GetRootItem());
		this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.OnEndSequenceEvent));
		this.Type = ControllerBase<TowerDefenseEventController>.Instance.BuildTipsType;
		this.CannotPlaceItem = base.GetItem(9);
		this.CannotPlaceText = base.GetText(10);
		this.RefreshState();
		this.RefreshCannotPlaceText();
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600DF46 RID: 57158 RVA: 0x003C12D4 File Offset: 0x003BF4D4
	private void OnEndSequenceEvent(string sequenceName)
	{
		if (sequenceName == "CloseTip")
		{
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			if (!(sequenceName == "CloseDisable"))
			{
				if (sequenceName == "CloseWarn")
				{
					UUIItem cannotPlaceItem = this.CannotPlaceItem;
					if (cannotPlaceItem == null)
					{
						return;
					}
					cannotPlaceItem.SetUIActive(false);
				}
				return;
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0600DF47 RID: 57159 RVA: 0x003C133F File Offset: 0x003BF53F
	protected override void OnShowBattleChildViewPanel(bool isFirst)
	{
		this.BindAction();
	}

	// Token: 0x0600DF48 RID: 57160 RVA: 0x003C1347 File Offset: 0x003BF547
	protected override void OnHideBattleChildViewPanel()
	{
		this.UnbindAction();
	}

	// Token: 0x0600DF49 RID: 57161 RVA: 0x003C134F File Offset: 0x003BF54F
	public override void OnTickBattleChildViewPanel(float delta)
	{
		if (this.UpdateCannotMode())
		{
			this.RefreshCannotPlaceText();
		}
		this.UpdatePolluteCostNum();
	}

	// Token: 0x0600DF4A RID: 57162 RVA: 0x003C1365 File Offset: 0x003BF565
	protected override void OnBeforeDestroy()
	{
		this.Sequence.Clear();
	}

	// Token: 0x0600DF4B RID: 57163 RVA: 0x003C1374 File Offset: 0x003BF574
	private void BindAction()
	{
		if (!this.IsBindAction)
		{
			ControllerBase<InputDistributeController>.Instance.BindAction("塔防旋转", new TInputHandle<InputDistributeDefine.EActionType>(this.OnRotateMachineCallback));
			ControllerBase<InputDistributeController>.Instance.BindAction("塔防回收机关", new TInputHandle<InputDistributeDefine.EActionType>(this.OnRecycleMachineCallback));
			this.IsBindAction = true;
		}
	}

	// Token: 0x0600DF4C RID: 57164 RVA: 0x003C13C8 File Offset: 0x003BF5C8
	private void UnbindAction()
	{
		if (this.IsBindAction)
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction("塔防旋转", new TInputHandle<InputDistributeDefine.EActionType>(this.OnRotateMachineCallback));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("塔防回收机关", new TInputHandle<InputDistributeDefine.EActionType>(this.OnRecycleMachineCallback));
			this.IsBindAction = false;
		}
	}

	// Token: 0x0600DF4D RID: 57165 RVA: 0x003C141C File Offset: 0x003BF61C
	private void RefreshState()
	{
		this.RefreshDisableItemActive();
		this.RefreshPolluteItemActive();
		if (Singleton<Info>.Instance.IsInTouch())
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(0);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			this.NeedShowBtnSequence = false;
			return;
		}
		bool flag = this.CheckSettingItemActive();
		UUIItem item4 = base.GetItem(1);
		if (item4 != null)
		{
			item4.SetUIActive(this.IsInRotate);
		}
		UUIItem item5 = base.GetItem(2);
		if (item5 != null)
		{
			item5.SetUIActive(this.IsInRecycle);
		}
		UUIItem item6 = base.GetItem(0);
		if (item6 != null)
		{
			item6.SetUIActive(flag);
		}
		bool flag2 = this.IsInRotate || this.IsInRecycle || flag;
		if (flag2 != this.NeedShowBtnSequence)
		{
			this.NeedShowBtnSequence = flag2;
			this.PlayBtnSequence(flag2);
		}
	}

	// Token: 0x0600DF4E RID: 57166 RVA: 0x003C14F7 File Offset: 0x003BF6F7
	private void RefreshTipsItem(ETrapDefenseBuildTipsType type)
	{
		if (this.Type == type)
		{
			return;
		}
		this.Type = type;
		this.RefreshState();
	}

	// Token: 0x0600DF4F RID: 57167 RVA: 0x003C1510 File Offset: 0x003BF710
	private bool CheckSettingItemActive()
	{
		return !Singleton<Info>.Instance.IsInTouch() && this.IsInBuild && (!this.IsInPollute || ModelBase<TrapDefenseModel>.Instance.BattleData.IsPurificationItemEnough);
	}

	// Token: 0x0600DF50 RID: 57168 RVA: 0x003C1544 File Offset: 0x003BF744
	private void PlayBtnSequence(bool isActive)
	{
		if (isActive)
		{
			this.Sequence.StopSequenceByKey("CloseBtn", false, true);
			this.Sequence.PlaySequencePurely("StartBtn", false, false);
			return;
		}
		this.Sequence.StopSequenceByKey("StartBtn", false, true);
		this.Sequence.PlaySequencePurely("CloseBtn", false, false);
	}

	// Token: 0x0600DF51 RID: 57169 RVA: 0x003C15A0 File Offset: 0x003BF7A0
	private void RefreshPolluteItemActive()
	{
		UUIItem item = base.GetItem(4);
		UUITexture texture = base.GetTexture(6);
		if (this.IsInPollute)
		{
			this.UpdatePolluteCostNum();
			TrapDefenseBattleItemData itemData = ModelBase<TrapDefenseModel>.Instance.BattleInventoryData.GetItemData(1);
			if (itemData != null && !string.IsNullOrEmpty(itemData.Icon))
			{
				base.SetTextureByPath(itemData.Icon, texture, null, null);
			}
			this.Sequence.StopSequenceByKey("CloseTip", false, true);
			this.Sequence.PlayOrReplaySequenceByName("StartTip", false, null);
			if (item != null)
			{
				item.SetUIActive(true);
				return;
			}
		}
		else
		{
			this.Sequence.StopSequenceByKey("StartTip", false, true);
			this.Sequence.PlayOrReplaySequenceByName("CloseTip", false, null);
		}
	}

	// Token: 0x0600DF52 RID: 57170 RVA: 0x003C1668 File Offset: 0x003BF868
	private void UpdatePolluteCostNum()
	{
		if (this.IsInPollute)
		{
			TrapDefenseBattleData battleData = ModelBase<TrapDefenseModel>.Instance.BattleData;
			bool isPurificationItemEnough = battleData.IsPurificationItemEnough;
			int currentPurificationItemCount = battleData.GetCurrentPurificationItemCount();
			int purificationItemConsume = battleData.GetPurificationItemConsume();
			this.EnoughItem.SetUIActive(isPurificationItemEnough);
			this.NotEnoughItem.SetUIActive(!isPurificationItemEnough);
			if (isPurificationItemEnough)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(this.CostNumText, "TowerDefense_Main_BdCostGreen_Text", new <>z__ReadOnlyArray<object>(new object[]
				{
					currentPurificationItemCount,
					purificationItemConsume
				}));
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.CostNumText, "TowerDefense_Main_BdCostRed_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				currentPurificationItemCount,
				purificationItemConsume
			}));
		}
	}

	// Token: 0x0600DF53 RID: 57171 RVA: 0x003C1724 File Offset: 0x003BF924
	private void RefreshDisableItemActive()
	{
		UUIItem item = base.GetItem(3);
		if (this.IsInDisable)
		{
			if (item != null)
			{
				item.SetUIActive(true);
			}
			this.Sequence.StopSequenceByKey("CloseDisable", false, true);
			this.Sequence.PlaySequencePurely("StartDisable", false, false);
			return;
		}
		this.Sequence.StopSequenceByKey("StartDisable", false, true);
		this.Sequence.PlaySequencePurely("CloseDisable", false, false);
	}

	// Token: 0x0600DF54 RID: 57172 RVA: 0x003C1794 File Offset: 0x003BF994
	private void RefreshCannotPlaceText()
	{
		if (this.CannotMode == 1 || this.CannotMode == 0 || this.CannotMode == 7)
		{
			this.Sequence.StopSequenceByKey("StartWarn", false, true);
			this.Sequence.PlaySequencePurely("CloseWarn", false, false);
			return;
		}
		if (this.CannotMode == 2 || this.CannotMode == 3 || this.CannotMode == 4)
		{
			TowerDefenseEventRaycastResult raycastResult = ControllerBase<TowerDefenseEventController>.Instance.RaycastResult;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.CannotPlaceText, TrapDefenseBuildTipsPanel.cannotPlaceTextMap[raycastResult.PlacementType], Array.Empty<object>());
		}
		else if (this.CannotMode == 5)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.CannotPlaceText, "TowerDefense_Battle_Numlimit", Array.Empty<object>());
		}
		else if (this.CannotMode == 6)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.CannotPlaceText, "TowerDefense_Battle_Coinlimit", Array.Empty<object>());
		}
		UUIItem cannotPlaceItem = this.CannotPlaceItem;
		if (cannotPlaceItem != null)
		{
			cannotPlaceItem.SetUIActive(true);
		}
		this.Sequence.StopSequenceByKey("CloseWarn", false, true);
		this.Sequence.PlaySequencePurely("StartWarn", false, false);
	}

	// Token: 0x0600DF55 RID: 57173 RVA: 0x003C18AC File Offset: 0x003BFAAC
	private bool UpdateCannotMode()
	{
		int num = 0;
		if (this.IsInDisable)
		{
			TowerDefenseEventRaycastResult raycastResult = ControllerBase<TowerDefenseEventController>.Instance.RaycastResult;
			if (raycastResult.IsInvalidPlacement)
			{
				if (raycastResult.PlacementType == ETowerDefenseEventTrapPlacementType.Ground)
				{
					num = 2;
				}
				else if (raycastResult.PlacementType == ETowerDefenseEventTrapPlacementType.Wall)
				{
					num = 3;
				}
				else if (raycastResult.PlacementType == ETowerDefenseEventTrapPlacementType.Roof)
				{
					num = 4;
				}
			}
			else if (!ModelBase<TowerDefenseEventModel>.Instance.HasPlaceToBuildTrap())
			{
				num = 5;
			}
			else if (!ControllerBase<TowerDefenseEventController>.Instance.IsEnoughGoldToBuildTrap())
			{
				num = 6;
			}
			else
			{
				num = 1;
			}
		}
		else if (!this.IsInSelectBuild)
		{
			num = 7;
		}
		if (num == this.CannotMode)
		{
			return false;
		}
		this.CannotMode = num;
		return true;
	}

	// Token: 0x0600DF56 RID: 57174 RVA: 0x003C193E File Offset: 0x003BFB3E
	private void OnRotateMachineCallback(string name, InputDistributeDefine.EActionType actionType, InputIdentification identification)
	{
		if (!this.IsInRotate)
		{
			return;
		}
		if (actionType != InputDistributeDefine.EActionType.Press)
		{
			return;
		}
		ControllerBase<TowerDefenseEventController>.Instance.ExecuteRotateTrap();
	}

	// Token: 0x0600DF57 RID: 57175 RVA: 0x003C1957 File Offset: 0x003BFB57
	private void OnRecycleMachineCallback(string name, InputDistributeDefine.EActionType actionType, InputIdentification identification)
	{
		if (!this.IsInRecycle)
		{
			return;
		}
		if (actionType != InputDistributeDefine.EActionType.Press)
		{
			return;
		}
		ControllerBase<TowerDefenseEventController>.Instance.ExecuteUnOccupyTrap();
	}

	// Token: 0x0600DF58 RID: 57176 RVA: 0x003C1971 File Offset: 0x003BFB71
	public void SetRecyclePrice(int recyclePrice)
	{
		if (this.RecyclePriceItem != null)
		{
			this.RecyclePriceItem.UpdatePrice(recyclePrice);
		}
	}

	// Token: 0x0600DF59 RID: 57177 RVA: 0x003C1987 File Offset: 0x003BFB87
	public void SetTipsType(ETrapDefenseBuildTipsType type)
	{
		this.RefreshTipsItem(type);
	}

	// Token: 0x0600DF5A RID: 57178 RVA: 0x003C1990 File Offset: 0x003BFB90
	public void ResetCannotMode()
	{
		this.CannotMode = 0;
	}

	// Token: 0x0600DF5B RID: 57179 RVA: 0x003C1999 File Offset: 0x003BFB99
	public void SetIsInSelectBuild(bool isInSelectBuild)
	{
		this.IsInSelectBuild = isInSelectBuild;
		this.RefreshState();
	}

	// Token: 0x0600DF5D RID: 57181 RVA: 0x003C19B0 File Offset: 0x003BFBB0
	// Note: this type is marked as 'beforefieldinit'.
	static TrapDefenseBuildTipsPanel()
	{
		Dictionary<ETowerDefenseEventTrapPlacementType, string> dictionary = new Dictionary<ETowerDefenseEventTrapPlacementType, string>();
		dictionary[ETowerDefenseEventTrapPlacementType.Ground] = "TowerDefense_Battle_Groundonly";
		dictionary[ETowerDefenseEventTrapPlacementType.Wall] = "TowerDefense_Battle_Wallonly";
		dictionary[ETowerDefenseEventTrapPlacementType.Roof] = "TowerDefense_Battle_Toponly";
		TrapDefenseBuildTipsPanel.cannotPlaceTextMap = dictionary;
	}

	// Token: 0x04006B59 RID: 27481
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<ETowerDefenseEventTrapPlacementType, string> cannotPlaceTextMap;

	// Token: 0x04006B5A RID: 27482
	protected bool IsInSelectBuild;

	// Token: 0x04006B5B RID: 27483
	protected bool NeedShowBtnSequence;

	// Token: 0x04006B5C RID: 27484
	private ETrapDefenseBuildTipsType Type;

	// Token: 0x04006B5D RID: 27485
	private bool IsBindAction;

	// Token: 0x04006B5E RID: 27486
	[Nullable(2)]
	private UUIItem CannotPlaceItem;

	// Token: 0x04006B5F RID: 27487
	[Nullable(2)]
	private UUIText CannotPlaceText;

	// Token: 0x04006B60 RID: 27488
	private int CannotMode;

	// Token: 0x04006B61 RID: 27489
	[Nullable(2)]
	private TrapDefenseRecyclePriceItem RecyclePriceItem;

	// Token: 0x04006B62 RID: 27490
	protected UiSequencePlayer Sequence;

	// Token: 0x04006B63 RID: 27491
	protected UUIText CostNumText;

	// Token: 0x04006B64 RID: 27492
	protected UUIItem EnoughItem;

	// Token: 0x04006B65 RID: 27493
	protected UUIItem NotEnoughItem;

	// Token: 0x0200812F RID: 33071
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BE86 RID: 179846
		public const int SettingItem = 0;

		// Token: 0x0402BE87 RID: 179847
		public const int RotateItem = 1;

		// Token: 0x0402BE88 RID: 179848
		public const int RecycleItem = 2;

		// Token: 0x0402BE89 RID: 179849
		public const int DisableItem = 3;

		// Token: 0x0402BE8A RID: 179850
		public const int PolluteItem = 4;

		// Token: 0x0402BE8B RID: 179851
		public const int CostNum = 5;

		// Token: 0x0402BE8C RID: 179852
		public const int CostIcon = 6;

		// Token: 0x0402BE8D RID: 179853
		public const int EnoughItem = 7;

		// Token: 0x0402BE8E RID: 179854
		public const int NotEnoughItem = 8;

		// Token: 0x0402BE8F RID: 179855
		public const int CannotPlaceItem = 9;

		// Token: 0x0402BE90 RID: 179856
		public const int CannotPlaceText = 10;
	}

	// Token: 0x02008130 RID: 33072
	[NullableContext(0)]
	private static class ECannotMode
	{
		// Token: 0x0402BE91 RID: 179857
		public const int None = 0;

		// Token: 0x0402BE92 RID: 179858
		public const int IsInDisable = 1;

		// Token: 0x0402BE93 RID: 179859
		public const int GroundLimit = 2;

		// Token: 0x0402BE94 RID: 179860
		public const int WallLimit = 3;

		// Token: 0x0402BE95 RID: 179861
		public const int RoofLimit = 4;

		// Token: 0x0402BE96 RID: 179862
		public const int NumLimit = 5;

		// Token: 0x0402BE97 RID: 179863
		public const int GoldLimit = 6;

		// Token: 0x0402BE98 RID: 179864
		public const int IsNotInSelectBuild = 7;
	}
}
