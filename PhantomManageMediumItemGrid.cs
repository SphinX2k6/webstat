using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200203D RID: 8253
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhantomManageMediumItemGrid : LoopScrollMediumItemGrid<PhantomItemData>, IStaticVariableResetter
{
	// Token: 0x0600FB70 RID: 64368 RVA: 0x0045081C File Offset: 0x0044EA1C
	static PhantomManageMediumItemGrid()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PhantomManageMediumItemGrid.CreateStaticDefaultValue), new Action(PhantomManageMediumItemGrid.ResetStaticDefaultValue));
	}

	// Token: 0x0600FB71 RID: 64369 RVA: 0x0045083B File Offset: 0x0044EA3B
	public override void CreateThenShowByActor(AActor actor)
	{
	}

	// Token: 0x0600FB72 RID: 64370 RVA: 0x00450840 File Offset: 0x0044EA40
	public override UniTask CreateThenShowByActorAsync(AActor actor)
	{
		PhantomManageMediumItemGrid.<CreateThenShowByActorAsync>d__2 <CreateThenShowByActorAsync>d__;
		<CreateThenShowByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateThenShowByActorAsync>d__.<>1__state = -1;
		<CreateThenShowByActorAsync>d__.<>t__builder.Start<PhantomManageMediumItemGrid.<CreateThenShowByActorAsync>d__2>(ref <CreateThenShowByActorAsync>d__);
		return <CreateThenShowByActorAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FB73 RID: 64371 RVA: 0x0045087C File Offset: 0x0044EA7C
	public override UniTask CreateByActorAsync(AActor actor)
	{
		PhantomManageMediumItemGrid.<CreateByActorAsync>d__3 <CreateByActorAsync>d__;
		<CreateByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateByActorAsync>d__.<>1__state = -1;
		<CreateByActorAsync>d__.<>t__builder.Start<PhantomManageMediumItemGrid.<CreateByActorAsync>d__3>(ref <CreateByActorAsync>d__);
		return <CreateByActorAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FB74 RID: 64372 RVA: 0x004508B7 File Offset: 0x0044EAB7
	public static void CreateStaticDefaultValue()
	{
		PhantomManageMediumItemGrid.CallbackCheckSelect = null;
		PhantomManageMediumItemGrid.CallbackCheckTips = null;
		PhantomManageMediumItemGrid.CallbackListenerFocus = null;
	}

	// Token: 0x0600FB75 RID: 64373 RVA: 0x004508CB File Offset: 0x0044EACB
	public static void ResetStaticDefaultValue()
	{
		PhantomManageMediumItemGrid.CallbackCheckSelect = null;
		PhantomManageMediumItemGrid.CallbackCheckTips = null;
		PhantomManageMediumItemGrid.CallbackListenerFocus = null;
	}

	// Token: 0x0600FB76 RID: 64374 RVA: 0x004508DF File Offset: 0x0044EADF
	protected override void OnStart()
	{
		base.OnStart();
		this.GetItemGridExtendToggle().FocusListenerDelegate.Bind(new Action(this.OnListenerFocus));
	}

	// Token: 0x0600FB77 RID: 64375 RVA: 0x00450903 File Offset: 0x0044EB03
	private void OnListenerFocus()
	{
		if (this.Data != null && PhantomManageMediumItemGrid.CallbackListenerFocus != null)
		{
			PhantomManageMediumItemGrid.CallbackListenerFocus(this.Data as PhantomItemData);
		}
	}

	// Token: 0x0600FB78 RID: 64376 RVA: 0x00450929 File Offset: 0x0044EB29
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		this.GetItemGridExtendToggle().FocusListenerDelegate.Unbind();
	}

	// Token: 0x0600FB79 RID: 64377 RVA: 0x00450941 File Offset: 0x0044EB41
	protected override void OnRefresh(PhantomItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshPrivate(data);
	}

	// Token: 0x0600FB7A RID: 64378 RVA: 0x00450954 File Offset: 0x0044EB54
	private void RefreshPrivate(PhantomItemData data)
	{
		PhantomItem value = data.GetConfig().As<PhantomItem>().Value;
		int uniqueId = data.GetUniqueId();
		int qualityId = value.QualityId;
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		bool selectState = this.GetSelectState(data);
		bool tipsState = this.GetTipsState(data);
		PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.GetConfigId()),
			StarLevel = new int?(qualityId),
			IsNewVisible = new bool?(instance.IsNewAttributeItem(uniqueId)),
			IsLockVisible = new bool?(data.GetIsLock()),
			IsDeprecate = new bool?(data.GetIsDeprecated()),
			IsRedDotVisible = new bool?(instance.IsAttributeItemHasRedDot(uniqueId)),
			IsGreenSelected = new bool?(selectState)
		};
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
		List<VisionSlotData> currentSlotData = phantomBattleData.GetCurrentSlotData();
		propMediumItemGrid.Level = new int?(phantomBattleData.GetCost());
		propMediumItemGrid.IsLevelTextUseChangeColor = new bool?(true);
		propMediumItemGrid.BottomText = "+" + phantomBattleData.GetPhantomLevel().ToString();
		propMediumItemGrid.IsOmitBottomText = new bool?(true);
		if (currentSlotData.Count > 0)
		{
			EVisionSlotState? evisionSlotState;
			if (currentSlotData.Count <= 0)
			{
				evisionSlotState = null;
			}
			else
			{
				VisionSlotData visionSlotData = currentSlotData[0];
				evisionSlotState = ((visionSlotData != null) ? new EVisionSlotState?(visionSlotData.SlotState) : null);
			}
			EVisionSlotState? evisionSlotState2 = evisionSlotState;
			EVisionSlotState? evisionSlotState3;
			if (currentSlotData.Count <= 1)
			{
				evisionSlotState3 = null;
			}
			else
			{
				VisionSlotData visionSlotData2 = currentSlotData[1];
				evisionSlotState3 = ((visionSlotData2 != null) ? new EVisionSlotState?(visionSlotData2.SlotState) : null);
			}
			EVisionSlotState? evisionSlotState4 = evisionSlotState3;
			EVisionSlotState? evisionSlotState5;
			if (currentSlotData.Count <= 2)
			{
				evisionSlotState5 = null;
			}
			else
			{
				VisionSlotData visionSlotData3 = currentSlotData[2];
				evisionSlotState5 = ((visionSlotData3 != null) ? new EVisionSlotState?(visionSlotData3.SlotState) : null);
			}
			EVisionSlotState? evisionSlotState6 = evisionSlotState5;
			EVisionSlotState valueOrDefault = evisionSlotState2.GetValueOrDefault();
			EVisionSlotState valueOrDefault2 = evisionSlotState4.GetValueOrDefault();
			EVisionSlotState valueOrDefault3 = evisionSlotState6.GetValueOrDefault();
			switch (qualityId)
			{
			case 3:
				propMediumItemGrid.VisionSlotStateList = new int[]
				{
					(int)valueOrDefault
				};
				break;
			case 4:
				propMediumItemGrid.VisionSlotStateList = new int[]
				{
					(int)valueOrDefault,
					(int)valueOrDefault2
				};
				break;
			case 5:
				propMediumItemGrid.VisionSlotStateList = new int[]
				{
					(int)valueOrDefault,
					(int)valueOrDefault2,
					(int)valueOrDefault3
				};
				break;
			}
		}
		if (!selectState && ControllerBase<PhantomBattleController>.Instance.CheckIsEquip(uniqueId))
		{
			int uniqueId2 = phantomBattleData.GetUniqueId();
			int? equipRole = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(uniqueId2);
			bool value2 = ModelBase<PhantomBattleModel>.Instance.CheckPhantomIsMain(uniqueId2);
			propMediumItemGrid.VisionRoleHeadInfo = new VisionRoleHeadInfo
			{
				RoleConfigId = equipRole,
				VisionUniqueId = new int?(uniqueId2)
			};
			propMediumItemGrid.IsMainVisionVisible = new bool?(value2);
		}
		propMediumItemGrid.VisionFetterGroupId = new int?(phantomBattleData.GetFetterGroupId());
		base.Apply<PropMediumItemGrid>(propMediumItemGrid);
		base.SetCheckTickPerformance(new bool?(selectState), "bf5c5c", new float?(0.9f), "663738");
		this.SetSelected(tipsState, true);
	}

	// Token: 0x0600FB7B RID: 64379 RVA: 0x00450C62 File Offset: 0x0044EE62
	public void RefreshByView(PhantomItemData data)
	{
		this.RefreshPrivate(data);
	}

	// Token: 0x0600FB7C RID: 64380 RVA: 0x00450C6B File Offset: 0x0044EE6B
	private bool GetTipsState(PhantomItemData data)
	{
		return PhantomManageMediumItemGrid.CallbackCheckTips != null && PhantomManageMediumItemGrid.CallbackCheckTips(data);
	}

	// Token: 0x0600FB7D RID: 64381 RVA: 0x00450C81 File Offset: 0x0044EE81
	private bool GetSelectState(PhantomItemData data)
	{
		return PhantomManageMediumItemGrid.CallbackCheckSelect != null && PhantomManageMediumItemGrid.CallbackCheckSelect(data);
	}

	// Token: 0x0600FB7E RID: 64382 RVA: 0x00450C97 File Offset: 0x0044EE97
	public override object GetKey(PhantomItemData data, int gridIndex)
	{
		return data.GetUniqueId();
	}

	// Token: 0x040078BA RID: 30906
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Func<PhantomItemData, bool> CallbackCheckSelect;

	// Token: 0x040078BB RID: 30907
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Func<PhantomItemData, bool> CallbackCheckTips;

	// Token: 0x040078BC RID: 30908
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Action<PhantomItemData> CallbackListenerFocus;

	// Token: 0x040078BD RID: 30909
	private const string RED_TICK_HEX = "bf5c5c";

	// Token: 0x040078BE RID: 30910
	private const string TICK_COLOR_HEX = "663738";

	// Token: 0x040078BF RID: 30911
	private const float RED_TICK_ALPHA = 0.9f;
}
