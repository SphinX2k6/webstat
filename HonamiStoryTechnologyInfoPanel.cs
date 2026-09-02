using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F6A RID: 8042
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryTechnologyInfoPanel : UiPanelBase
{
	// Token: 0x0600F0D9 RID: 61657 RVA: 0x0041D190 File Offset: 0x0041B390
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText))
		};
	}

	// Token: 0x0600F0DA RID: 61658 RVA: 0x0041D288 File Offset: 0x0041B488
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryTechnologyInfoPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryTechnologyInfoPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F0DB RID: 61659 RVA: 0x0041D2CC File Offset: 0x0041B4CC
	public void Refresh(HonamiStoryTechNodeData data)
	{
		if (data == null)
		{
			return;
		}
		this.CurSelectNode = data;
		HonamiStoryTalent getConfig = this.CurSelectNode.GetConfig;
		bool flag = ModelBase<HonamiStoryModel>.Instance.CheckNodeCanActiveAndIsEnough(data);
		string path = (this.CurSelectNode.GetNodeStatus == ENodeStatus.IsActive) ? this.UnLockBgPath : this.LockBgPath;
		this.SetSpriteByPath(path, base.GetSprite(0), false, null, null);
		base.SetTextureByPath(getConfig.Icon, base.GetTexture(1), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), getConfig.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), getConfig.Desc, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), getConfig.MidTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), getConfig.MidDexc, Array.Empty<object>());
		Dictionary<int, int> dictionary = getConfig.ConsumeItems();
		if (dictionary == null || dictionary.Count == 0)
		{
			this.CostItem.SetUiActive(false);
		}
		else
		{
			this.CostItem.SetUiActive(true);
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				this.CostItem.UpdateItem(key, value);
				this.CostItem.RefreshCountEnableState();
			}
		}
		base.GetItem(5).SetUIActive(false);
		base.GetItem(6).SetUIActive(false);
		base.GetItem(8).SetUIActive(false);
		switch (this.CurSelectNode.GetNodeStatus)
		{
		case ENodeStatus.Lock:
		{
			base.GetItem(6).SetUIActive(true);
			if (!data.PreNodeIsActive)
			{
				this.LockTipsItem.SetTextByTextId("HonamiStory_Tech_PreNodeLock", Array.Empty<string>());
				return;
			}
			string lockPanelTip = data.GetConfig.LockPanelTip;
			this.LockTipsItem.SetTextByTextId(lockPanelTip, Array.Empty<string>());
			return;
		}
		case ENodeStatus.CanActive:
			if (flag)
			{
				base.GetItem(5).SetUIActive(true);
				return;
			}
			base.GetItem(6).SetUIActive(true);
			this.LockTipsItem.SetTextByTextId("HonamiStory_Tech_NotEnough", Array.Empty<string>());
			return;
		case ENodeStatus.IsActive:
			this.CostItem.SetUiActive(false);
			base.GetItem(8).SetUIActive(true);
			return;
		default:
			return;
		}
	}

	// Token: 0x0600F0DC RID: 61660 RVA: 0x0041D540 File Offset: 0x0041B740
	private void OnClickConfirmBtn(int _)
	{
		ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryActivateTalentRequest(this.CurSelectNode.Id, delegate
		{
			HonamiStoryModel instance = ModelBase<HonamiStoryModel>.Instance;
			HonamiStoryTechnologyNodeItem currentSelectNodeItem = instance.CurrentSelectNodeItem;
			if (currentSelectNodeItem != null)
			{
				currentSelectNodeItem.PlayActivateAnim();
			}
			if (instance.CurrentSelectNode != null)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryTechSuccessEffectView, instance.CurrentSelectNode.GetConfig, null);
			}
		});
	}

	// Token: 0x040073B1 RID: 29617
	private HonamiStoryTechNodeData CurSelectNode;

	// Token: 0x040073B2 RID: 29618
	[Nullable(2)]
	private ButtonItem ConfirmBtnItem;

	// Token: 0x040073B3 RID: 29619
	[Nullable(2)]
	private CommonCostItem CostItem;

	// Token: 0x040073B4 RID: 29620
	[Nullable(2)]
	private FunctionalPanelConditionLock LockTipsItem;

	// Token: 0x040073B5 RID: 29621
	private readonly string LockBgPath = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity28/HonamiStory/HonamiStorySkillTree/SP_SkillFrmLockNor.SP_SkillFrmLockNor";

	// Token: 0x040073B6 RID: 29622
	private readonly string UnLockBgPath = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity28/HonamiStory/HonamiStorySkillTree/SP_SkillFrmANor.SP_SkillFrmANor";

	// Token: 0x020082FE RID: 33534
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C6A2 RID: 181922
		SprTechIconBg,
		// Token: 0x0402C6A3 RID: 181923
		TexTechIcon,
		// Token: 0x0402C6A4 RID: 181924
		TxtTechTitle,
		// Token: 0x0402C6A5 RID: 181925
		TxtMidSkillInfo,
		// Token: 0x0402C6A6 RID: 181926
		PnlCost,
		// Token: 0x0402C6A7 RID: 181927
		BtnConfirm,
		// Token: 0x0402C6A8 RID: 181928
		PnlLockTips,
		// Token: 0x0402C6A9 RID: 181929
		TxtTechDesc,
		// Token: 0x0402C6AA RID: 181930
		PnlUnLockTips,
		// Token: 0x0402C6AB RID: 181931
		TxtMidSkillTitle
	}
}
