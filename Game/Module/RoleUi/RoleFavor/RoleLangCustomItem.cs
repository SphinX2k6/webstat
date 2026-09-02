using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ResManager;
using CSharpScript.Game.Module.RoleLangCustomModel;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Update;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleFavor
{
	// Token: 0x02005078 RID: 20600
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleLangCustomItem : UiPanelBase
	{
		// Token: 0x060351BE RID: 217534 RVA: 0x00D52424 File Offset: 0x00D50624
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickedBtnInfo));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickedBtnSetting));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060351BF RID: 217535 RVA: 0x00D52594 File Offset: 0x00D50794
		protected override void OnStart()
		{
			ControllerBase<ResourceManagerController>.Instance.ChangeHttpTickFrequency();
			this.ScrollView = new GenericScrollViewNew<RoleLangCustomTabItem, IRoleLangCustomInfo>(base.GetScrollViewWithScrollbar(4), new Func<RoleLangCustomTabItem>(this.CreateItem), null, false, null);
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.ToggleCanChangeState));
			base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
			this.TickTimer = TimerSystem.Instance.Forever(new TTimerAction(this.OnTick), 500f, 1f, null, null, true);
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleLangCustomRefresh, new Action<int>(this.OnRefreshByNet));
		}

		// Token: 0x060351C0 RID: 217536 RVA: 0x00D5266C File Offset: 0x00D5086C
		protected override void OnBeforeDestroy()
		{
			ControllerBase<ResourceManagerController>.Instance.RestoreHttpTickFrequency();
			DynamicMaskButton maskButton = this.MaskButton;
			if (maskButton != null)
			{
				maskButton.Destroy(null);
			}
			base.GetExtendToggle(0).CanExecuteChange.Unbind();
			base.GetExtendToggle(0).OnStateChange.Remove(new Action<EToggleState>(this.OnToggleStateChanged));
			if (this.TickTimer != null)
			{
				TimerSystem.Instance.Remove(this.TickTimer);
				this.TickTimer = null;
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.RoleLangCustomRefresh, new Action<int>(this.OnRefreshByNet));
		}

		// Token: 0x060351C1 RID: 217537 RVA: 0x00D52700 File Offset: 0x00D50900
		public void Refresh(int roleId)
		{
			this.RoleId = roleId;
			bool flag = StringUtils.IsBlank(ConfigBase<RoleConfig>.Instance.GetRoleLangStateGroup(roleId));
			base.SetUiActive(!flag);
			if (flag)
			{
				return;
			}
			List<IRoleLangCustomInfo> roleLangCustomInfo = this.GetRoleLangCustomInfo();
			this.ScrollView.RefreshByData(roleLangCustomInfo, null, false);
			int roleLangType = ModelBase<RoleLangCustomModel>.Instance.GetRoleLangType(roleId);
			RoleVoiceLanguage? roleLangCustomConfigById = ConfigBase<MenuBaseConfig>.Instance.GetRoleLangCustomConfigById(roleLangType);
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(roleLangCustomConfigById.Value.Text);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "VoiceDIY_Dubbing", new <>z__ReadOnlySingleElementList<object>(configTextByKey));
			bool valueOrDefault = ((ServerStorageBoolean)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoleLangCustomFuncClicked)).Get().GetValueOrDefault();
			UUIItem item = base.GetItem(6);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(!valueOrDefault);
		}

		// Token: 0x060351C2 RID: 217538 RVA: 0x00D527D0 File Offset: 0x00D509D0
		public void OnTabViewHide()
		{
			if (base.GetExtendToggle(0).GetToggleState() != EToggleState.ETT_Checked)
			{
				return;
			}
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
		}

		// Token: 0x060351C3 RID: 217539 RVA: 0x00D527F4 File Offset: 0x00D509F4
		protected List<IRoleLangCustomInfo> GetRoleLangCustomInfo()
		{
			List<IRoleLangCustomInfo> list = new List<IRoleLangCustomInfo>();
			List<int> allLanguageTypeForAudio = Singleton<LanguageUpdateManager>.Instance.GetAllLanguageTypeForAudio();
			allLanguageTypeForAudio.Sort((int a, int b) => a - b);
			foreach (int num in allLanguageTypeForAudio)
			{
				global::LanguageDefine languageDefineByType = Singleton<LanguageSystem>.Instance.GetLanguageDefineByType(num);
				RoleLangCustomInfo item = new RoleLangCustomInfo
				{
					RoleId = this.RoleId,
					LangIndex = num,
					LangCode = languageDefineByType.AudioCode
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x060351C4 RID: 217540 RVA: 0x00D528AC File Offset: 0x00D50AAC
		protected bool IsInBattle()
		{
			SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
			if (instance.IsPhantomTeam)
			{
				return false;
			}
			EntityHandle getCurrentEntity = instance.GetCurrentEntity;
			if (getCurrentEntity == null || !getCurrentEntity.Valid)
			{
				return false;
			}
			WorldEntity entity = getCurrentEntity.Entity;
			BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			return baseTagComponent != null && baseTagComponent.Valid && baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]);
		}

		// Token: 0x060351C5 RID: 217541 RVA: 0x00D52924 File Offset: 0x00D50B24
		private UniTask ShowMaskButton()
		{
			RoleLangCustomItem.<ShowMaskButton>d__14 <ShowMaskButton>d__;
			<ShowMaskButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowMaskButton>d__.<>4__this = this;
			<ShowMaskButton>d__.<>1__state = -1;
			<ShowMaskButton>d__.<>t__builder.Start<RoleLangCustomItem.<ShowMaskButton>d__14>(ref <ShowMaskButton>d__);
			return <ShowMaskButton>d__.<>t__builder.Task;
		}

		// Token: 0x060351C6 RID: 217542 RVA: 0x00D52967 File Offset: 0x00D50B67
		private void HideMaskButton()
		{
			if (this.MaskButton == null)
			{
				return;
			}
			this.MaskButton.ResetItemParent();
			this.MaskButton.SetActive(false);
		}

		// Token: 0x060351C7 RID: 217543 RVA: 0x00D52989 File Offset: 0x00D50B89
		private void OnClickedBtnInfo()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(584);
		}

		// Token: 0x060351C8 RID: 217544 RVA: 0x00D5299A File Offset: 0x00D50B9A
		private void OnClickedBtnSetting()
		{
			this.OnClickedMask();
			ModelBase<RoleLangCustomModel>.Instance.RoleViewRoleId = this.RoleId;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleLangCustomView, this.RoleId, null);
		}

		// Token: 0x060351C9 RID: 217545 RVA: 0x00D529CD File Offset: 0x00D50BCD
		private RoleLangCustomTabItem CreateItem()
		{
			return new RoleLangCustomTabItem
			{
				OnClickedCallback = new Action<IRoleLangCustomInfo>(this.OnClickedToggleItem),
				CheckScrollActiveCallback = new Func<bool>(this.CheckScrollActiveCallback)
			};
		}

		// Token: 0x060351CA RID: 217546 RVA: 0x00D529F8 File Offset: 0x00D50BF8
		private bool CheckScrollActiveCallback()
		{
			return base.GetScrollViewWithScrollbar(4).RootUIComp.Get().IsUIActiveSelf();
		}

		// Token: 0x060351CB RID: 217547 RVA: 0x00D52A20 File Offset: 0x00D50C20
		private bool ToggleCanChangeState()
		{
			ServerStorageBoolean serverStorageBoolean = (ServerStorageBoolean)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoleLangCustomFuncClicked);
			if (!serverStorageBoolean.Get().GetValueOrDefault())
			{
				serverStorageBoolean.Set(new bool?(true));
				UUIItem item = base.GetItem(6);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoleLangCustomFuncClicked, this.RoleId);
			}
			return ModelBase<RoleLangCustomModel>.Instance.CheckServerVoiceDataSame(false);
		}

		// Token: 0x060351CC RID: 217548 RVA: 0x00D52A95 File Offset: 0x00D50C95
		private void OnToggleStateChanged(EToggleState state)
		{
			this.ScrollView.SetActive(state == EToggleState.ETT_Checked);
			if (state == EToggleState.ETT_Checked)
			{
				this.ShowMaskButton();
				return;
			}
			this.HideMaskButton();
		}

		// Token: 0x060351CD RID: 217549 RVA: 0x00D52AB8 File Offset: 0x00D50CB8
		private void OnClickedToggleItem(IRoleLangCustomInfo data)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
			if (ModelBase<RoleLangCustomModel>.Instance.GetRoleLangType(this.RoleId) == data.LangIndex)
			{
				this.Refresh(this.RoleId);
				return;
			}
			RoleLangSetVoiceParam playerVoice = new RoleLangSetVoiceParam
			{
				RoleId = this.RoleId,
				Lang = data.LangIndex,
				NeedRequest = true,
				IsCustom = true,
				IsCover = false
			};
			ModelBase<RoleLangCustomModel>.Instance.SetPlayerVoice(playerVoice);
			this.Refresh(this.RoleId);
			Action onSetPlayerVoice = this.OnSetPlayerVoice;
			if (onSetPlayerVoice != null)
			{
				onSetPlayerVoice();
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Notice_VoiceDIY_Setting_Success", Array.Empty<object>());
		}

		// Token: 0x060351CE RID: 217550 RVA: 0x00D52B6A File Offset: 0x00D50D6A
		private void OnClickedMask()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
		}

		// Token: 0x060351CF RID: 217551 RVA: 0x00D52B7D File Offset: 0x00D50D7D
		private void OnRefreshByNet(int roleId)
		{
			this.Refresh(this.RoleId);
		}

		// Token: 0x060351D0 RID: 217552 RVA: 0x00D52B8C File Offset: 0x00D50D8C
		private void OnTick(float delta)
		{
			foreach (RoleLangCustomTabItem roleLangCustomTabItem in this.ScrollView.GetScrollItemList())
			{
				roleLangCustomTabItem.OnTick();
			}
		}

		// Token: 0x0401E93F RID: 125247
		private const int HELP_ID = 584;

		// Token: 0x0401E940 RID: 125248
		protected GenericScrollViewNew<RoleLangCustomTabItem, IRoleLangCustomInfo> ScrollView;

		// Token: 0x0401E941 RID: 125249
		protected int RoleId;

		// Token: 0x0401E942 RID: 125250
		private DynamicMaskButton MaskButton;

		// Token: 0x0401E943 RID: 125251
		[Nullable(2)]
		private TimerHandle TickTimer;

		// Token: 0x0401E944 RID: 125252
		[Nullable(2)]
		public Action OnSetPlayerVoice;

		// Token: 0x0200B031 RID: 45105
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x04036A94 RID: 223892
			TogSort,
			// Token: 0x04036A95 RID: 223893
			TxtSort,
			// Token: 0x04036A96 RID: 223894
			BtnInfo,
			// Token: 0x04036A97 RID: 223895
			BtnSetting,
			// Token: 0x04036A98 RID: 223896
			ScrollView,
			// Token: 0x04036A99 RID: 223897
			ToggleItem,
			// Token: 0x04036A9A RID: 223898
			RedDot
		}
	}
}
