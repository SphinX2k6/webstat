using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleLangCustomModel;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.RoleUi.RoleFavor;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002870 RID: 10352
[NullableContext(2)]
[Nullable(0)]
public class RoleFavorTabView : UiTabViewBase
{
	// Token: 0x06014807 RID: 83975 RVA: 0x005B00B0 File Offset: 0x005AE2B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickExperienceButton)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickVoiceButton)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickActionButton)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickPreciousItemButton))
		};
	}

	// Token: 0x06014808 RID: 83976 RVA: 0x005B023E File Offset: 0x005AE43E
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.UpdateRoleFavorData, new Action<int>(this.OnUpdateRoleFavorData));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleSystemChangeRole));
	}

	// Token: 0x06014809 RID: 83977 RVA: 0x005B0278 File Offset: 0x005AE478
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateRoleFavorData, new Action<int>(this.OnUpdateRoleFavorData));
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleSystemChangeRole));
	}

	// Token: 0x0601480A RID: 83978 RVA: 0x005B02B4 File Offset: 0x005AE4B4
	protected override UniTask OnBeforeStartAsync()
	{
		RoleFavorTabView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleFavorTabView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601480B RID: 83979 RVA: 0x005B02F8 File Offset: 0x005AE4F8
	protected override void OnStart()
	{
		this.RoleViewAgent = (this.ExtraParams as RoleViewAgent);
		if (this.RoleViewAgent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RoleViewAgent为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("界面名称", "RoleFavorTabView");
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x0601480C RID: 83980 RVA: 0x005B034C File Offset: 0x005AE54C
	protected override void OnBeforeShow()
	{
		this.PlayMontageStart();
		this.RefreshRedDot();
		UAnimInstance animInstance = this.GetAnimInstance();
		if (animInstance != null)
		{
			animInstance.Montage_Stop(0f, null);
		}
		this.Refresh();
	}

	// Token: 0x0601480D RID: 83981 RVA: 0x005B0384 File Offset: 0x005AE584
	protected override void OnHideUiTabViewBase(bool fromToggle)
	{
		if (this.PlayAudioHandle != null)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.PlayAudioHandle.Value, EAudioActionType.Stop, null);
			this.PlayAudioHandle = null;
		}
		RoleLangCustomItem roleLangItem = this.RoleLangItem;
		if (roleLangItem == null)
		{
			return;
		}
		roleLangItem.OnTabViewHide();
	}

	// Token: 0x0601480E RID: 83982 RVA: 0x005B03D9 File Offset: 0x005AE5D9
	private void OnUpdateRoleFavorData(int _)
	{
		this.Refresh();
	}

	// Token: 0x0601480F RID: 83983 RVA: 0x005B03E1 File Offset: 0x005AE5E1
	private void OnRoleSystemChangeRole(int _)
	{
		this.Refresh();
	}

	// Token: 0x06014810 RID: 83984 RVA: 0x005B03EC File Offset: 0x005AE5EC
	private void Refresh()
	{
		int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(curSelectRoleId, true);
		if (roleDataById == null)
		{
			return;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(curSelectRoleId);
		if (roleConfig == null)
		{
			return;
		}
		string roleName = ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name);
		UUIText text = base.GetText(1);
		UUIText text2 = base.GetText(2);
		UUIText text3 = base.GetText(0);
		bool flag = roleConfig.Value.PartyId != 9;
		if (text != null)
		{
			text.SetUIActive(flag);
		}
		if (text2 != null)
		{
			text2.SetUIActive(flag);
		}
		UUIButtonComponent button = base.GetButton(6);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag);
		}
		UUIButtonComponent button2 = base.GetButton(3);
		if (button2 != null)
		{
			button2.RootUIComp.Get().SetUIActive(flag);
		}
		if (flag)
		{
			if (text3 != null)
			{
				text3.SetText(roleName, true);
			}
		}
		else if (text3 != null)
		{
			text3.SetText(roleDataById.GetName(null), true);
		}
		RoleFavorData favorData = roleDataById.GetFavorData();
		int favorLevel = favorData.GetFavorLevel();
		Singleton<LguiUtil>.Instance.SetLocalText(text, "FavorLevel", new <>z__ReadOnlySingleElementList<object>(favorLevel));
		FavorLevel? favorLevelConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorLevelConfig(favorLevel);
		int favorExp = favorData.GetFavorExp();
		if (favorLevelConfig != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text2, "RoleExp", new <>z__ReadOnlyArray<object>(new object[]
			{
				favorExp,
				favorLevelConfig.Value.LevelUpExp
			}));
		}
		else
		{
			FavorLevel? favorLevelConfig2 = ConfigBase<RoleFavorConfig>.Instance.GetFavorLevelConfig(favorLevel - 1);
			if (favorLevelConfig2 != null)
			{
				int levelUpExp = favorLevelConfig2.Value.LevelUpExp;
				Singleton<LguiUtil>.Instance.SetLocalText(text2, "RoleExp", new <>z__ReadOnlyArray<object>(new object[]
				{
					levelUpExp,
					levelUpExp
				}));
			}
		}
		this.RefreshRedDot();
		bool? boolConfig = ConfigCommonParamById.GetBoolConfig("NeedShowRoleLangCustom");
		if (boolConfig != null && boolConfig.Value)
		{
			this.RoleLangItem.Refresh(curSelectRoleId);
			return;
		}
		this.RoleLangItem.SetUiActive(false);
	}

	// Token: 0x06014811 RID: 83985 RVA: 0x005B062C File Offset: 0x005AE82C
	private void RefreshRedDot()
	{
		RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
		if (curSelectRoleData == null)
		{
			return;
		}
		RoleFavorData favorData = curSelectRoleData.GetFavorData();
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(favorData.IsFavorItemCanUnlock(EFavorContentType.ExperienceStory));
		}
		UUIItem item2 = base.GetItem(8);
		if (item2 != null)
		{
			item2.SetUIActive(favorData.IsFavorItemCanUnlock(EFavorContentType.Voice));
		}
		UUIItem item3 = base.GetItem(9);
		if (item3 != null)
		{
			item3.SetUIActive(favorData.IsFavorItemCanUnlock(EFavorContentType.Action));
		}
		UUIItem item4 = base.GetItem(10);
		if (item4 == null)
		{
			return;
		}
		item4.SetUIActive(favorData.IsFavorItemCanUnlock(EFavorContentType.PreciousItem));
	}

	// Token: 0x06014812 RID: 83986 RVA: 0x005B06B5 File Offset: 0x005AE8B5
	protected void PlayMontageStart()
	{
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Favor, false, false, false);
	}

	// Token: 0x06014813 RID: 83987 RVA: 0x005B06C8 File Offset: 0x005AE8C8
	private USkeletalMeshComponent GetRoleActorMesh()
	{
		TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
		if (roleSystemRoleActor == null)
		{
			return null;
		}
		UiModelBase model = roleSystemRoleActor.Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		USkeletalMeshComponent uskeletalMeshComponent = (uiModelActorComponent != null) ? uiModelActorComponent.MainMeshComponent : null;
		if (uskeletalMeshComponent == null)
		{
			return null;
		}
		return uskeletalMeshComponent;
	}

	// Token: 0x06014814 RID: 83988 RVA: 0x005B070C File Offset: 0x005AE90C
	private UAnimInstance GetAnimInstance()
	{
		USkeletalMeshComponent roleActorMesh = this.GetRoleActorMesh();
		if (roleActorMesh == null)
		{
			return null;
		}
		UAnimInstance animInstance = roleActorMesh.GetAnimInstance();
		if (animInstance == null)
		{
			return null;
		}
		return animInstance.GetLinkedAnimGraphInstanceByTag(Singleton<CharacterNameDefines>.Instance.ABP_BASE);
	}

	// Token: 0x06014815 RID: 83989 RVA: 0x005B0740 File Offset: 0x005AE940
	protected void OnClickExperienceButton()
	{
		int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
		if (ConfigBase<RoleFavorConfig>.Instance.GetFavorRoleInfoConfig(curSelectRoleId) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "该角色的好感度配置FavorRoleInfo找不到!!!";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("角色Id", curSelectRoleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleFavorInfoView, new RoleFavorInfoViewParams
		{
			RoleId = curSelectRoleId,
			FavorTabType = EFavorTabType.Experience
		}, null);
	}

	// Token: 0x06014816 RID: 83990 RVA: 0x005B07C0 File Offset: 0x005AE9C0
	protected void OnClickVoiceButton()
	{
		int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
		EFavorVoiceType type = EFavorVoiceType.FavorNatureVoice;
		IReadOnlyList<FavorWord> favorWordConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorWordConfig(curSelectRoleId, (int)type);
		if (favorWordConfig == null || favorWordConfig.Count == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "该角色的好感度配置FavorWord找不到!!!";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("角色Id", curSelectRoleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleFavorInfoView, new RoleFavorInfoViewParams
		{
			RoleId = curSelectRoleId,
			FavorTabType = EFavorTabType.Voice
		}, null);
	}

	// Token: 0x06014817 RID: 83991 RVA: 0x005B0844 File Offset: 0x005AEA44
	protected void OnClickActionButton()
	{
		int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
		EFavorActionType type = EFavorActionType.IdleAction;
		IReadOnlyList<Motion> roleMotionByType = ConfigBase<MotionConfig>.Instance.GetRoleMotionByType(curSelectRoleId, (int)type);
		if (roleMotionByType == null || roleMotionByType.Count == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "该角色的好感度配置Motion找不到!!!";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("角色Id", curSelectRoleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleFavorInfoView, new RoleFavorInfoViewParams
		{
			RoleId = curSelectRoleId,
			FavorTabType = EFavorTabType.Action
		}, null);
	}

	// Token: 0x06014818 RID: 83992 RVA: 0x005B08C8 File Offset: 0x005AEAC8
	protected void OnClickPreciousItemButton()
	{
		int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
		IReadOnlyList<FavorGoods> favorGoodsConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorGoodsConfig(curSelectRoleId);
		if (favorGoodsConfig == null || favorGoodsConfig.Count == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "该角色的好感度配置FavorGoods找不到!!!";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("角色Id", curSelectRoleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleFavorInfoView, new RoleFavorInfoViewParams
		{
			RoleId = curSelectRoleId,
			FavorTabType = EFavorTabType.PreciousItem
		}, null);
	}

	// Token: 0x06014819 RID: 83993 RVA: 0x005B0948 File Offset: 0x005AEB48
	private void OnSetPlayerVoice()
	{
		if (this.PlayAudioHandle != null)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.PlayAudioHandle.Value, EAudioActionType.Stop, null);
		}
		int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
		this.PlayAudioHandle = new int?(ModelBase<RoleLangCustomModel>.Instance.PlayVoiceOnSetVoice(curSelectRoleId));
	}

	// Token: 0x04009E83 RID: 40579
	private RoleViewAgent RoleViewAgent;

	// Token: 0x04009E84 RID: 40580
	private RoleLangCustomItem RoleLangItem;

	// Token: 0x04009E85 RID: 40581
	private int? PlayAudioHandle;
}
