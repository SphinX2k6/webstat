using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020027AC RID: 10156
[NullableContext(2)]
[Nullable(0)]
public class RoleElementView : UiViewBase
{
	// Token: 0x060140E0 RID: 82144 RVA: 0x005990A7 File Offset: 0x005972A7
	[NullableContext(1)]
	public RoleElementView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060140E1 RID: 82145 RVA: 0x005990B0 File Offset: 0x005972B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickSwitch))
		};
	}

	// Token: 0x060140E2 RID: 82146 RVA: 0x00599148 File Offset: 0x00597348
	protected override UniTask OnBeforeStartAsync()
	{
		RoleElementView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleElementView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060140E3 RID: 82147 RVA: 0x0059918C File Offset: 0x0059738C
	protected UniTask RefreshAsync()
	{
		RoleElementView.<RefreshAsync>d__12 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<RoleElementView.<RefreshAsync>d__12>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060140E4 RID: 82148 RVA: 0x005991CF File Offset: 0x005973CF
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.ShowRoleElementChangePreviewEffect, new Action<bool>(this.OnShowRoleElementChangePreviewEffect));
	}

	// Token: 0x060140E5 RID: 82149 RVA: 0x005991ED File Offset: 0x005973ED
	protected override void OnAfterShow()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleSystemChangeRole));
	}

	// Token: 0x060140E6 RID: 82150 RVA: 0x0059920B File Offset: 0x0059740B
	[NullableContext(1)]
	private RoleElementItem InitItem()
	{
		RoleElementItem roleElementItem = new RoleElementItem();
		roleElementItem.SetRoleViewAgent(this.RoleViewAgent);
		roleElementItem.OnToggleCallback = new Action<int>(this.OnToggleClick);
		roleElementItem.CanToggleChange = new Func<int, bool>(this.CanToggleChange);
		return roleElementItem;
	}

	// Token: 0x060140E7 RID: 82151 RVA: 0x00599242 File Offset: 0x00597442
	private void OnToggleClick(int gridIndex)
	{
		this.SelectGridByIndex(gridIndex);
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.RoleElement, false, false, false);
		if (this.RoleSwitchPreviewHandEffectHandle != 0)
		{
			this.ShowElementPreviewEffect();
		}
	}

	// Token: 0x060140E8 RID: 82152 RVA: 0x00599268 File Offset: 0x00597468
	private void SelectGridByIndex(int gridIndex)
	{
		this.CurSelectRoleId = this.DataList[gridIndex].Id;
		this.GenericScrollView.GetGenericLayout().SelectGridProxy(gridIndex, false);
		this.RefreshButtonState();
	}

	// Token: 0x060140E9 RID: 82153 RVA: 0x005992A8 File Offset: 0x005974A8
	private void RefreshButtonState()
	{
		bool flag = this.RoleViewAgent.GetCurSelectRoleId() == this.CurSelectRoleId;
		UUIButtonComponent button = base.GetButton(2);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(!flag);
	}

	// Token: 0x060140EA RID: 82154 RVA: 0x005992DE File Offset: 0x005974DE
	private bool CanToggleChange(int gridIndex)
	{
		return gridIndex != this.GenericScrollView.GetGenericLayout().GetSelectedGridIndex();
	}

	// Token: 0x060140EB RID: 82155 RVA: 0x005992F6 File Offset: 0x005974F6
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleSystemChangeRole));
		this.HideElementPreviewEffect();
	}

	// Token: 0x060140EC RID: 82156 RVA: 0x0059931A File Offset: 0x0059751A
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ShowRoleElementChangePreviewEffect, new Action<bool>(this.OnShowRoleElementChangePreviewEffect));
	}

	// Token: 0x060140ED RID: 82157 RVA: 0x00599338 File Offset: 0x00597538
	protected void OnClickClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x060140EE RID: 82158 RVA: 0x00599344 File Offset: 0x00597544
	protected void OnClickSwitch()
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		bool? flag;
		if (baseCharacter == null)
		{
			flag = null;
		}
		else
		{
			BaseTagComponent component = baseCharacter.CharacterActorComponent.Entity.GetComponent<BaseTagComponent>();
			flag = ((component != null) ? new bool?(component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"])) : null);
		}
		bool? flag2 = flag;
		if (flag2.GetValueOrDefault())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(ConfigBase<TextConfig>.Instance.GetTextById("CanNotTransferInFight"));
			return;
		}
		if (this.CurSelectRoleId == 0)
		{
			return;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.CurSelectRoleId);
		if (roleConfig == null)
		{
			return;
		}
		ControllerBase<MainRoleController>.Instance.SendRoleElementChangeRequest(roleConfig.Value.ElementId);
	}

	// Token: 0x060140EF RID: 82159 RVA: 0x00599400 File Offset: 0x00597600
	private void OnRoleSystemChangeRole(int roleId)
	{
		this.IsPlayingChangeSuccessEffect = true;
		Singleton<UiLayer>.Instance.SetShowMaskLayer("RoleElementView", true);
		this.RoleViewAgent.SetCurSelectRoleId(roleId);
		this.RoleViewAgent.CheckMainRoleToIdList(roleId);
		RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
		TsUiSceneRoleActor sceneRoleActor = this.SceneRoleActor;
		object obj;
		if (sceneRoleActor == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = sceneRoleActor.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiRoleDataComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.SetRoleDataId(roleId, curSelectRoleData.GetRoleSkinId());
		}
		this.RoleChangeShow(roleId);
		foreach (RoleElementItem roleElementItem in this.GenericScrollView.GetScrollItemList())
		{
			roleElementItem.RefreshState();
		}
		this.RefreshButtonState();
	}

	// Token: 0x060140F0 RID: 82160 RVA: 0x005994D0 File Offset: 0x005976D0
	private void OnShowRoleElementChangePreviewEffect(bool isShow)
	{
		if (isShow)
		{
			this.ShowElementPreviewEffect();
			return;
		}
		this.HideElementPreviewEffect();
	}

	// Token: 0x060140F1 RID: 82161 RVA: 0x005994E2 File Offset: 0x005976E2
	private void RoleChangeShowSuccess()
	{
		Singleton<UiLayer>.Instance.SetShowMaskLayer("RoleElementView", false);
		this.IsPlayingChangeSuccessEffect = false;
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ElementTransferSuccess", Array.Empty<object>());
	}

	// Token: 0x060140F2 RID: 82162 RVA: 0x00599510 File Offset: 0x00597710
	private void ShowElementPreviewEffect()
	{
		if (this.IsPlayingChangeSuccessEffect)
		{
			return;
		}
		this.ShowElementPreviewEffectById(ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.CurSelectRoleId).Value.ElementId);
	}

	// Token: 0x060140F3 RID: 82163 RVA: 0x0059954C File Offset: 0x0059774C
	private void RoleChangeShow(int roleId)
	{
		RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value;
		ElementInfoConfig instance = ConfigBase<ElementInfoConfig>.Instance;
		ElementInfo? elementInfo;
		string text = (instance != null) ? ((instance.GetElementInfo(value.ElementId) != null) ? elementInfo.GetValueOrDefault().AudioEvent : null) : null;
		if (text != null)
		{
			Singleton<AudioSystem>.Instance.PostEvent(text);
		}
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.RoleElement_End, false, false, false);
		int? roleElementSwitchDelayTime = ConfigBase<RoleConfig>.Instance.GetRoleElementSwitchDelayTime();
		this.ShowElementSuccessEffectById(value.ElementId);
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.RoleChangeShowSuccess();
		}, (float)roleElementSwitchDelayTime.Value, null, null, true, 1f);
	}

	// Token: 0x060140F4 RID: 82164 RVA: 0x00599604 File Offset: 0x00597804
	[return: Nullable(0)]
	private UniTask<int> CreateRoleElementEffect([Nullable(1)] string effectPathKey, USceneComponent parentComponent, FName? socketName, FTransformDouble? relativeTransform, string colorHex = null, string iconPath = null)
	{
		RoleElementView.<CreateRoleElementEffect>d__29 <CreateRoleElementEffect>d__;
		<CreateRoleElementEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder<int>.Create();
		<CreateRoleElementEffect>d__.<>4__this = this;
		<CreateRoleElementEffect>d__.effectPathKey = effectPathKey;
		<CreateRoleElementEffect>d__.parentComponent = parentComponent;
		<CreateRoleElementEffect>d__.socketName = socketName;
		<CreateRoleElementEffect>d__.relativeTransform = relativeTransform;
		<CreateRoleElementEffect>d__.colorHex = colorHex;
		<CreateRoleElementEffect>d__.iconPath = iconPath;
		<CreateRoleElementEffect>d__.<>1__state = -1;
		<CreateRoleElementEffect>d__.<>t__builder.Start<RoleElementView.<CreateRoleElementEffect>d__29>(ref <CreateRoleElementEffect>d__);
		return <CreateRoleElementEffect>d__.<>t__builder.Task;
	}

	// Token: 0x060140F5 RID: 82165 RVA: 0x0059967C File Offset: 0x0059787C
	[NullableContext(1)]
	private void UpdetaColorAndIcon(int handle, FLinearColor lColor, bool isNeedSetIcon, UTexture texObj)
	{
		OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> niagaraComponent = Singleton<EffectSystem>.Instance.GetNiagaraComponent(handle);
		if (niagaraComponent.IsT2)
		{
			UNiagaraComponent asT = niagaraComponent.AsT2;
			UNiagaraSystem asset = asT.Asset;
			asT.SetAsset(null, true);
			asT.SetAsset(asset, true);
		}
		if (niagaraComponent.HasValue)
		{
			niagaraComponent.SetNiagaraVariableLinearColor("Color", lColor);
			if (isNeedSetIcon)
			{
				niagaraComponent.SetKuroNiagaraEmitterCustomTexture("Icon", "Mask", texObj);
			}
		}
	}

	// Token: 0x060140F6 RID: 82166 RVA: 0x005996E8 File Offset: 0x005978E8
	public void ShowElementSuccessEffectById(int elementId)
	{
		ElementInfo? elementInfo = ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(elementId);
		if (elementInfo == null)
		{
			return;
		}
		TsUiSceneRoleActor sceneRoleActor = this.SceneRoleActor;
		UiModelBase model = sceneRoleActor.Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		USkeletalMeshComponent uskeletalMeshComponent = (uiModelActorComponent != null) ? uiModelActorComponent.MainMeshComponent : null;
		if (uskeletalMeshComponent == null)
		{
			return;
		}
		this.CreateRoleElementEffect("AttributeSwitchBodyEffect", sceneRoleActor.K2_GetRootComponent(), new FName?(Singleton<CharacterNameDefines>.Instance.ROOT), null, elementInfo.Value.ElementEffectColor, null).Forget<int>();
		this.CreateRoleElementEffect("AttributeSwitchHandEffect", uskeletalMeshComponent, new FName?(Singleton<CharacterNameDefines>.Instance.ELEMENT_EFFECT_SOCKET_NAME), null, elementInfo.Value.ElementEffectColor, elementInfo.Value.Icon3).Forget<int>();
	}

	// Token: 0x060140F7 RID: 82167 RVA: 0x005997BD File Offset: 0x005979BD
	private void CreateRoleElementEffectFail()
	{
	}

	// Token: 0x060140F8 RID: 82168 RVA: 0x005997C0 File Offset: 0x005979C0
	public void ShowElementPreviewEffectById(int elementId)
	{
		ElementInfo? elementInfo = ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(elementId);
		if (elementInfo == null)
		{
			return;
		}
		if (this.RoleSwitchPreviewHandEffectHandle != 0)
		{
			RoleElementView.<>c__DisplayClass33_0 CS$<>8__locals1 = new RoleElementView.<>c__DisplayClass33_0();
			CS$<>8__locals1.<>4__this = this;
			RoleElementView.<>c__DisplayClass33_0 CS$<>8__locals2 = CS$<>8__locals1;
			FColor fcolor = FColor.FromHex(elementInfo.Value.ElementEffectColor);
			CS$<>8__locals2.lColor = FLinearColor.FromSRGBColor(fcolor);
			Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(elementInfo.Value.Icon3, delegate([Nullable(2)] UTexture textureObject, string _)
			{
				CS$<>8__locals1.<>4__this.UpdetaColorAndIcon(CS$<>8__locals1.<>4__this.RoleSwitchPreviewHandEffectHandle, CS$<>8__locals1.lColor, true, textureObject);
			}, 100, this.MemoryTag);
		}
		else
		{
			TsUiSceneRoleActor sceneRoleActor = this.SceneRoleActor;
			FRotator frotator = new FRotator(0f, 0f, 0f);
			FVectorDouble fvectorDouble = new FVectorDouble(0.0, 0.0, 0.0);
			FVectorDouble fvectorDouble2 = new FVectorDouble(1.0, 1.0, 1.0);
			FVector fvector = fvectorDouble2;
			FTransformDouble value = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
			UiModelBase model = sceneRoleActor.Model;
			UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
			this.CreateRoleElementEffect("AttributePreviewHandEffect", (uiModelActorComponent != null) ? uiModelActorComponent.MainMeshComponent : null, new FName?(Singleton<CharacterNameDefines>.Instance.ELEMENT_EFFECT_SOCKET_NAME), new FTransformDouble?(value), elementInfo.Value.ElementEffectColor, elementInfo.Value.Icon3).ContinueWith(delegate(int handle)
			{
				this.RoleSwitchPreviewHandEffectHandle = handle;
				if (base.IsDestroyOrDestroying)
				{
					this.HideElementPreviewEffect();
				}
			}).Forget();
		}
		try
		{
			AActor actorByTag = Singleton<UiSceneManager>.Instance.GetActorByTag(ConfigCommonParamById.GetStringConfig("RoleElementPreviewEffectCase"));
			if (this.RoleSwitchPreviewBackEffectHandle == 0)
			{
				this.CreateRoleElementEffect("AttributePreviewBodyEffect", null, null, new FTransformDouble?(actorByTag.D_GetTransform()), null, null).ContinueWith(delegate(int handle)
				{
					this.RoleSwitchPreviewBackEffectHandle = handle;
					if (base.IsDestroyOrDestroying)
					{
						this.HideElementPreviewEffect();
					}
				}).Forget();
			}
		}
		catch (Exception)
		{
			Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.LK, "给角色属性切换预览特效寻找坐标参考case点失败，中断后续流程", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x060140F9 RID: 82169 RVA: 0x005999C4 File Offset: 0x00597BC4
	public void HideElementPreviewEffect()
	{
		if (Singleton<EffectSystem>.Instance.IsValid(this.RoleSwitchPreviewHandEffectHandle))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.RoleSwitchPreviewHandEffectHandle, "HideElementPreviewEffect", true, new bool?(true));
			this.RoleSwitchPreviewHandEffectHandle = 0;
		}
		if (this.RoleSwitchPreviewBackEffectHandle != 0)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.RoleSwitchPreviewBackEffectHandle, "HideElementPreviewEffect", true, new bool?(true));
			this.RoleSwitchPreviewBackEffectHandle = 0;
		}
	}

	// Token: 0x04009C3D RID: 39997
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<RoleElementItem, MainRoleConfig> GenericScrollView;

	// Token: 0x04009C3E RID: 39998
	private List<MainRoleConfig> DataList;

	// Token: 0x04009C3F RID: 39999
	private int CurSelectRoleId;

	// Token: 0x04009C40 RID: 40000
	private RoleViewAgent RoleViewAgent;

	// Token: 0x04009C41 RID: 40001
	private int RoleSwitchPreviewHandEffectHandle;

	// Token: 0x04009C42 RID: 40002
	private int RoleSwitchPreviewBackEffectHandle;

	// Token: 0x04009C43 RID: 40003
	private bool IsPlayingChangeSuccessEffect;

	// Token: 0x04009C44 RID: 40004
	private TsUiSceneRoleActor SceneRoleActor;

	// Token: 0x02008B65 RID: 35685
	[NullableContext(0)]
	public enum ERoleElementViewDefine
	{
		// Token: 0x0402EFD7 RID: 192471
		CloseButton,
		// Token: 0x0402EFD8 RID: 192472
		ScrollView,
		// Token: 0x0402EFD9 RID: 192473
		SwitchButton
	}
}
