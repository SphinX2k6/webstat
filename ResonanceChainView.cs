using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Render;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028A3 RID: 10403
[NullableContext(2)]
[Nullable(0)]
public class ResonanceChainView : UiTabViewBase
{
	// Token: 0x06014A66 RID: 84582 RVA: 0x005B8720 File Offset: 0x005B6920
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x06014A67 RID: 84583 RVA: 0x005B87BC File Offset: 0x005B69BC
	protected override UniTask OnBeforeStartAsync()
	{
		ResonanceChainView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ResonanceChainView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014A68 RID: 84584 RVA: 0x005B8800 File Offset: 0x005B6A00
	private void InitData()
	{
		this.ItemParentList = new UUIItem[6];
		this.ShowingItemList = new ResonanceChainBaseItem[6];
		int num = 0;
		for (int i = 0; i < 6; i++)
		{
			this.ItemParentList[i] = base.GetItem(num + i);
		}
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.SequencePlayer.BindSequenceStartEvent(new TSequenceStartEvent(this.OnSequenceStart));
	}

	// Token: 0x06014A69 RID: 84585 RVA: 0x005B886C File Offset: 0x005B6A6C
	private void CreateSceneEffect()
	{
		FTransformDouble? kuroCurrentUiSceneTransform = ControllerBase<RenderModuleController>.Instance.GetKuroCurrentUiSceneTransform();
		string effectPath = EffectUtil.GetEffectPath("DA_Fx_Group_UIScene_SystemNew_Line");
		this.SceneEffectHandle = new int?(Singleton<EffectSystem>.Instance.SpawnEffect(GlobalData.World, kuroCurrentUiSceneTransform, effectPath, "[ResonanceChainView.CreateSceneEffect]", null, EEffectType.UiScene3D, null, null, null, false, false));
	}

	// Token: 0x06014A6A RID: 84586 RVA: 0x005B88B8 File Offset: 0x005B6AB8
	private void SetEffectHidden(bool bHidden)
	{
		if (this.SceneEffectHandle == null)
		{
			return;
		}
		Singleton<EffectSystem>.Instance.SetEffectHidden(this.SceneEffectHandle.Value, bHidden, "[ResonanceChainView.SetEffectHidden]", false);
	}

	// Token: 0x06014A6B RID: 84587 RVA: 0x005B88E4 File Offset: 0x005B6AE4
	private void DestroySceneEffect()
	{
		if (this.SceneEffectHandle == null)
		{
			return;
		}
		Singleton<EffectSystem>.Instance.StopEffectById(this.SceneEffectHandle.Value, "[ResonanceChainView.DestroySceneEffect]", true, null);
		this.SceneEffectHandle = null;
	}

	// Token: 0x06014A6C RID: 84588 RVA: 0x005B8930 File Offset: 0x005B6B30
	private void ResetStates()
	{
		this.CurSelectId = -1;
	}

	// Token: 0x06014A6D RID: 84589 RVA: 0x005B893C File Offset: 0x005B6B3C
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateRoleResonanceDetailView, new Action(this.OnResonanceUnlockSuccess));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleInternalViewQuit, new Action(this.OnRoleInternalViewQuit));
	}

	// Token: 0x06014A6E RID: 84590 RVA: 0x005B89A0 File Offset: 0x005B6BA0
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateRoleResonanceDetailView, new Action(this.OnResonanceUnlockSuccess));
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleInternalViewQuit, new Action(this.OnRoleInternalViewQuit));
	}

	// Token: 0x06014A6F RID: 84591 RVA: 0x005B8A04 File Offset: 0x005B6C04
	[NullableContext(1)]
	private void OnSequenceStart(string sequenceName)
	{
		if (sequenceName == "CamLef" || sequenceName == "CamRig")
		{
			TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
			this.SequencePlayer.SetActorTag(sequenceName, RoleDefine.UI_SCENE_ROLE_TAG, roleSystemRoleActor);
			this.SequencePlayer.SetRelativeTransform(sequenceName, ControllerBase<RenderModuleController>.Instance.GetKuroCurrentUiSceneTransform().Value);
		}
	}

	// Token: 0x06014A70 RID: 84592 RVA: 0x005B8A68 File Offset: 0x005B6C68
	private void OnResonanceUnlockSuccess()
	{
		this.RefreshInfoItem();
		int num = this.RoleViewAgent.GetCurRoleResonanceGroupIndex() - 1;
		ResonanceChainBaseItem resonanceChainBaseItem = this.ShowingItemList[num];
		if (resonanceChainBaseItem == null)
		{
			return;
		}
		int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
		resonanceChainBaseItem.SetSelectState(true);
		resonanceChainBaseItem.Update(curSelectRoleId, resonanceChainBaseItem.GetResonanceId(), true);
		resonanceChainBaseItem.SetUiActive(true);
		this.ShowingItemList[num] = resonanceChainBaseItem;
		resonanceChainBaseItem.PlayActivateSequence();
		int num2 = num + 1;
		if (num2 < this.ShowingItemList.Length)
		{
			this.ShowingItemList[num2].RefreshRedDot();
			return;
		}
		ResonanceChainBaseItem[] showingItemList = this.ShowingItemList;
		for (int i = 0; i < showingItemList.Length; i++)
		{
			showingItemList[i].RefreshMaxActivateItem(true);
		}
	}

	// Token: 0x06014A71 RID: 84593 RVA: 0x005B8B10 File Offset: 0x005B6D10
	private void OnRoleChange(int roleId)
	{
		this.PlayMontageStart();
		this.SequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
		this.Refresh();
		this.ShowItems();
	}

	// Token: 0x06014A72 RID: 84594 RVA: 0x005B8B4C File Offset: 0x005B6D4C
	private void OnRoleInternalViewQuit()
	{
		this.HideInfoItem();
		this.SequencePlayer.PlayOrReplaySequenceByName("CamLef", false, null);
		this.CancelToggleSelect();
	}

	// Token: 0x06014A73 RID: 84595 RVA: 0x005B8B7F File Offset: 0x005B6D7F
	protected override void OnBeforeShow()
	{
		this.PlayMontageStart();
		this.Refresh();
		this.ShowItems();
		this.SetEffectHidden(false);
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.FinishGuideStepByEvent, "ResonanceChainGuide");
	}

	// Token: 0x06014A74 RID: 84596 RVA: 0x005B8BAF File Offset: 0x005B6DAF
	protected override void OnBeforeHide()
	{
		this.SetEffectHidden(true);
	}

	// Token: 0x06014A75 RID: 84597 RVA: 0x005B8BB8 File Offset: 0x005B6DB8
	public void ShowItems()
	{
		ResonanceChainBaseItem[] showingItemList = this.ShowingItemList;
		for (int i = 0; i < showingItemList.Length; i++)
		{
			showingItemList[i].ShowItem();
		}
	}

	// Token: 0x06014A76 RID: 84598 RVA: 0x005B8BE4 File Offset: 0x005B6DE4
	private void EnterRoleInternalView()
	{
		this.ShowInfoItem();
		this.SequencePlayer.StopSequenceByKey("CamRig", false, false);
		this.SequencePlayer.PlayLevelSequenceByName("CamRig", false, null, false);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRoleInternalViewEnter);
	}

	// Token: 0x06014A77 RID: 84599 RVA: 0x005B8C34 File Offset: 0x005B6E34
	protected void PlayMontageStart()
	{
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Resonance, false, false, false);
	}

	// Token: 0x06014A78 RID: 84600 RVA: 0x005B8C44 File Offset: 0x005B6E44
	private void ShowInfoItem()
	{
		ResonanceChainInfoItem infoItem = this.InfoItem;
		if (infoItem != null)
		{
			infoItem.SetUiActive(true);
		}
		this.InfoItem.ShowItem();
	}

	// Token: 0x06014A79 RID: 84601 RVA: 0x005B8C63 File Offset: 0x005B6E63
	private void HideInfoItem()
	{
		ResonanceChainInfoItem infoItem = this.InfoItem;
		if (infoItem != null)
		{
			infoItem.SetUiActive(false);
		}
		this.InfoItem.HideItem();
	}

	// Token: 0x06014A7A RID: 84602 RVA: 0x005B8C84 File Offset: 0x005B6E84
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<ResonanceChainBaseItem> InitChainItemAsync(int index)
	{
		ResonanceChainView.<InitChainItemAsync>d__29 <InitChainItemAsync>d__;
		<InitChainItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<ResonanceChainBaseItem>.Create();
		<InitChainItemAsync>d__.<>4__this = this;
		<InitChainItemAsync>d__.index = index;
		<InitChainItemAsync>d__.<>1__state = -1;
		<InitChainItemAsync>d__.<>t__builder.Start<ResonanceChainView.<InitChainItemAsync>d__29>(ref <InitChainItemAsync>d__);
		return <InitChainItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014A7B RID: 84603 RVA: 0x005B8CD0 File Offset: 0x005B6ED0
	private ResonanceChainBaseItem GetItemByResonanceId(int resonanceId)
	{
		ResonantChain? roleResonanceById = ConfigBase<RoleResonanceConfig>.Instance.GetRoleResonanceById(resonanceId);
		if (roleResonanceById != null)
		{
			int num = roleResonanceById.Value.GroupIndex - 1;
			if (num >= 0 && num < 6)
			{
				return this.ShowingItemList[num];
			}
		}
		return null;
	}

	// Token: 0x06014A7C RID: 84604 RVA: 0x005B8D18 File Offset: 0x005B6F18
	private void Refresh()
	{
		int curRoleResonanceGroupIndex = this.RoleViewAgent.GetCurRoleResonanceGroupIndex();
		List<ResonantChain> curRoleResonanceConfigList = this.RoleViewAgent.GetCurRoleResonanceConfigList();
		int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
		foreach (ResonanceChainBaseItem resonanceChainBaseItem in this.ShowingItemList)
		{
			if (resonanceChainBaseItem != null)
			{
				resonanceChainBaseItem.SetUiActive(false);
			}
		}
		if (curRoleResonanceConfigList != null && curRoleResonanceConfigList.Count > 0)
		{
			foreach (ResonantChain resonantChain in curRoleResonanceConfigList)
			{
				int groupIndex = resonantChain.GroupIndex;
				int num = groupIndex - 1;
				ResonanceChainBaseItem resonanceChainBaseItem2 = this.ShowingItemList[num];
				if (num < 6)
				{
					resonanceChainBaseItem2.SetUiActive(true);
					resonanceChainBaseItem2.Update(curSelectRoleId, resonantChain.Id, groupIndex <= curRoleResonanceGroupIndex);
					this.ShowingItemList[num] = resonanceChainBaseItem2;
					resonanceChainBaseItem2.RefreshMaxActivateItem(curRoleResonanceGroupIndex == curRoleResonanceConfigList.Count);
				}
			}
		}
	}

	// Token: 0x06014A7D RID: 84605 RVA: 0x005B8E1C File Offset: 0x005B701C
	private void OnToggleCallBack(int resonanceId)
	{
		int curSelectId = this.CurSelectId;
		ResonanceChainBaseItem resonanceChainBaseItem = null;
		if (curSelectId >= 0)
		{
			resonanceChainBaseItem = this.GetItemByResonanceId(curSelectId);
		}
		ResonanceChainBaseItem resonanceChainBaseItem2 = null;
		if (resonanceId >= 0)
		{
			this.CurSelectId = resonanceId;
			resonanceChainBaseItem2 = this.GetItemByResonanceId(resonanceId);
		}
		if (resonanceChainBaseItem != null)
		{
			resonanceChainBaseItem.SetSelectState(false);
		}
		if (resonanceChainBaseItem != null)
		{
			resonanceChainBaseItem.RefreshToggleState(false);
		}
		if (resonanceChainBaseItem2 != null)
		{
			resonanceChainBaseItem2.SetSelectState(true);
		}
		if (resonanceChainBaseItem2 != null)
		{
			resonanceChainBaseItem2.RefreshToggleState(true);
		}
		if (this.RoleViewAgent.RoleViewState == ERoleViewState.External)
		{
			this.EnterRoleInternalView();
		}
		this.RefreshInfoItem();
	}

	// Token: 0x06014A7E RID: 84606 RVA: 0x005B8E98 File Offset: 0x005B7098
	private void CancelToggleSelect()
	{
		int curSelectId = this.CurSelectId;
		ResonanceChainBaseItem resonanceChainBaseItem = null;
		if (curSelectId >= 0)
		{
			resonanceChainBaseItem = this.GetItemByResonanceId(curSelectId);
		}
		this.CurSelectId = -1;
		if (resonanceChainBaseItem != null)
		{
			resonanceChainBaseItem.SetSelectState(false);
		}
		if (resonanceChainBaseItem != null)
		{
			resonanceChainBaseItem.RefreshToggleState(true);
		}
	}

	// Token: 0x06014A7F RID: 84607 RVA: 0x005B8ED8 File Offset: 0x005B70D8
	private void RefreshInfoItem()
	{
		RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
		this.InfoItem.Update(curSelectRoleData.GetDataId(), this.CurSelectId, curSelectRoleData.IsTrialRole());
	}

	// Token: 0x06014A80 RID: 84608 RVA: 0x005B8F0E File Offset: 0x005B710E
	protected override void OnBeforeDestroy()
	{
		this.DestroySceneEffect();
		this.ShowingItemList = null;
		this.ItemParentList = null;
		this.SequencePlayer = null;
		this.ResetStates();
	}

	// Token: 0x06014A81 RID: 84609 RVA: 0x005B8F34 File Offset: 0x005B7134
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			string message = "共鸣链聚焦引导extraParam字段配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		UUIItem uuiitem = this.FindGuideUiItem(configParams[0]);
		if (uuiitem == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Guide;
			ELogAuthor author2 = ELogAuthor.TL;
			string message2 = "共鸣链聚焦引导extraParam字段配置错误, 找不到对应的共鸣链界面UI节点";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("configParams", configParams);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x06014A82 RID: 84610 RVA: 0x005B8FB4 File Offset: 0x005B71B4
	[NullableContext(1)]
	[return: Nullable(2)]
	private UUIItem FindGuideUiItem(string param)
	{
		UUIItem result = null;
		int num;
		if (int.TryParse(param, out num) && num > 0)
		{
			ResonanceChainBaseItem resonanceChainBaseItem = this.ShowingItemList[--num];
			result = ((resonanceChainBaseItem != null) ? resonanceChainBaseItem.GetUiItemForGuide() : null);
		}
		else if (param == "btn")
		{
			ResonanceChainInfoItem infoItem = this.InfoItem;
			result = ((infoItem != null) ? infoItem.GetUiItemForGuide() : null);
		}
		return result;
	}

	// Token: 0x04009F52 RID: 40786
	private const int RESONANCE_ITEM_COUNT = 6;

	// Token: 0x04009F53 RID: 40787
	private RoleViewAgent RoleViewAgent;

	// Token: 0x04009F54 RID: 40788
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ResonanceChainBaseItem[] ShowingItemList;

	// Token: 0x04009F55 RID: 40789
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private UUIItem[] ItemParentList;

	// Token: 0x04009F56 RID: 40790
	private ResonanceChainInfoItem InfoItem;

	// Token: 0x04009F57 RID: 40791
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x04009F58 RID: 40792
	private int CurSelectId = -1;

	// Token: 0x04009F59 RID: 40793
	private int? SceneEffectHandle;

	// Token: 0x02008BF1 RID: 35825
	[NullableContext(0)]
	private enum EResonanceChainViewCom
	{
		// Token: 0x0402F242 RID: 193090
		ResonanceItem1,
		// Token: 0x0402F243 RID: 193091
		ResonanceItem2,
		// Token: 0x0402F244 RID: 193092
		ResonanceItem3,
		// Token: 0x0402F245 RID: 193093
		ResonanceItem4,
		// Token: 0x0402F246 RID: 193094
		ResonanceItem5,
		// Token: 0x0402F247 RID: 193095
		ResonanceItem6
	}
}
