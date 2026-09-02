using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.InputView.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001A93 RID: 6803
[NullableContext(1)]
[Nullable(0)]
public class CreateCharacterView : UiViewBase
{
	// Token: 0x0600C2CE RID: 49870 RVA: 0x00335684 File Offset: 0x00333884
	public CreateCharacterView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C2CF RID: 49871 RVA: 0x003356A4 File Offset: 0x003338A4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.SelectedMale)),
			new ValueTuple<int, Delegate>(2, new Action(this.SelectedFemale))
		};
	}

	// Token: 0x0600C2D0 RID: 49872 RVA: 0x00335765 File Offset: 0x00333965
	private void SelectedMale()
	{
		this.HandleGenderSwitch(LoginDefine.ELoginSex.Boy);
	}

	// Token: 0x0600C2D1 RID: 49873 RVA: 0x0033576E File Offset: 0x0033396E
	private void SelectedFemale()
	{
		this.HandleGenderSwitch(LoginDefine.ELoginSex.Girl);
	}

	// Token: 0x0600C2D2 RID: 49874 RVA: 0x00335778 File Offset: 0x00333978
	private void HandleGenderSwitch(LoginDefine.ELoginSex loginSex)
	{
		LoginDefine.ELoginSex? selectedSex = this.SelectedSex;
		if (selectedSex.GetValueOrDefault() == loginSex & selectedSex != null)
		{
			return;
		}
		LoginDefine.ELoginSex? selectedSex2 = this.SelectedSex;
		this.SelectedSex = new LoginDefine.ELoginSex?(loginSex);
		base.GetItem(3).SetUIActive(false);
		base.GetItem(4).SetUIActive(false);
		if (this.InSelectedState)
		{
			this.HideNameView(true);
			Singleton<UiLoginSceneManager>.Instance.LoadSequenceAsync(this.GetSwitchSequence(), new Action(this.HandleSequenceCallback), false, null);
			this.GenderButtonList[(int)selectedSex2.Value].RemoveRoleChooseRenderingMaterial();
			this.GenderButtonList[(int)loginSex].SetRoleChooseRenderingMaterial();
			return;
		}
		Singleton<UiLoginSceneManager>.Instance.LoadSequenceAsync(this.GetSelectSequence(), new Action(this.HandleSequenceCallback), false, null);
		this.GenderButtonList[(int)loginSex].SetRoleChooseRenderingMaterial();
	}

	// Token: 0x0600C2D3 RID: 49875 RVA: 0x00335855 File Offset: 0x00333A55
	private string GetSwitchSequence()
	{
		if (this.SelectedSex.GetValueOrDefault() == LoginDefine.ELoginSex.Boy)
		{
			return "LevelSequence_SwitchMale";
		}
		return "LevelSequence_SwitchFemale";
	}

	// Token: 0x0600C2D4 RID: 49876 RVA: 0x00335870 File Offset: 0x00333A70
	private string GetSelectSequence()
	{
		if (this.SelectedSex.GetValueOrDefault() == LoginDefine.ELoginSex.Boy)
		{
			return "LevelSequence_SelectMale";
		}
		return "LevelSequence_SelectFemale";
	}

	// Token: 0x0600C2D5 RID: 49877 RVA: 0x0033588C File Offset: 0x00333A8C
	private void HandleSequenceCallback()
	{
		this.InSelectedState = true;
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		base.GetButton(1).RootUIComp.Get().SetUIActive(this.SelectedSex.GetValueOrDefault() != LoginDefine.ELoginSex.Boy);
		UUIItem uuiitem = base.GetButton(2).RootUIComp.Get();
		LoginDefine.ELoginSex? selectedSex = this.SelectedSex;
		LoginDefine.ELoginSex eloginSex = LoginDefine.ELoginSex.Girl;
		uuiitem.SetUIActive(!(selectedSex.GetValueOrDefault() == eloginSex & selectedSex != null));
	}

	// Token: 0x0600C2D6 RID: 49878 RVA: 0x00335914 File Offset: 0x00333B14
	protected override void OnStart()
	{
		this.UiViewSequence.AddSequenceFinishEvent("hide", delegate(string _)
		{
			this.HideTextInput();
		}, false);
		this.InitialRoles = ConfigBase<CreateCharacterConfig>.Instance.GetInitialRoles();
		this.InitTextInputModule();
		this.InitGenderButton();
		this.HideNameView(false);
		base.GetItem(3).SetUIActive(true);
		base.GetItem(4).SetUIActive(true);
	}

	// Token: 0x0600C2D7 RID: 49879 RVA: 0x0033597B File Offset: 0x00333B7B
	protected override void OnAfterDestroy()
	{
		ModelBase<LoginModel>.Instance.FinishLoginPromise();
	}

	// Token: 0x0600C2D8 RID: 49880 RVA: 0x00335987 File Offset: 0x00333B87
	private void HideTextInput()
	{
		this.TextInputModule.SetActive(false);
	}

	// Token: 0x0600C2D9 RID: 49881 RVA: 0x00335995 File Offset: 0x00333B95
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.CreateRoleShowInputName, new Action(this.ShowInputName));
	}

	// Token: 0x0600C2DA RID: 49882 RVA: 0x003359B3 File Offset: 0x00333BB3
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CreateRoleShowInputName, new Action(this.ShowInputName));
	}

	// Token: 0x0600C2DB RID: 49883 RVA: 0x003359D1 File Offset: 0x00333BD1
	private void ShowInputName()
	{
		this.ShowNameView();
	}

	// Token: 0x0600C2DC RID: 49884 RVA: 0x003359DC File Offset: 0x00333BDC
	private void InitTextInputModule()
	{
		TextInputData inputData = new TextInputData
		{
			ConfirmFunc = new TConfirm(this.ConfirmFunc),
			ResultFunc = new TResult(this.CreateCharacterResult),
			InputText = "",
			IsCheckNone = true
		};
		this.TextInputModule = new TextInputComponent(base.GetItem(0), inputData);
	}

	// Token: 0x0600C2DD RID: 49885 RVA: 0x00335A38 File Offset: 0x00333C38
	private void InitGenderButton()
	{
		CreateCharacterView.GenderButton genderButton = new CreateCharacterView.GenderButton(base.GetButton(2), this.InitialRoles[0]);
		genderButton.BindFunction();
		this.GenderButtonList.Add(genderButton);
		CreateCharacterView.GenderButton genderButton2 = new CreateCharacterView.GenderButton(base.GetButton(1), this.InitialRoles[1]);
		genderButton2.BindFunction();
		this.GenderButtonList.Add(genderButton2);
	}

	// Token: 0x0600C2DE RID: 49886 RVA: 0x00335A9C File Offset: 0x00333C9C
	protected override void OnBeforeDestroy()
	{
		for (int i = 0; i < this.GenderButtonList.Count; i++)
		{
			CreateCharacterView.GenderButton genderButton = this.GenderButtonList[i];
			genderButton.RemoveRoleChooseRenderingMaterial();
			genderButton.UnbindFunction();
		}
		this.TextInputModule.Destroy(null);
	}

	// Token: 0x0600C2DF RID: 49887 RVA: 0x00335AE2 File Offset: 0x00333CE2
	private void ShowNameView()
	{
		base.PlaySequence("show", null, false);
		this.TextInputModule.SetActive(true);
	}

	// Token: 0x0600C2E0 RID: 49888 RVA: 0x00335AFD File Offset: 0x00333CFD
	private void HideNameView(bool isPlaySequence = true)
	{
		if (isPlaySequence)
		{
			base.PlaySequence("hide", null, true);
			return;
		}
		this.TextInputModule.SetActive(false);
	}

	// Token: 0x0600C2E1 RID: 49889 RVA: 0x00335B1C File Offset: 0x00333D1C
	[NullableContext(0)]
	private UniTask<ErrorCode> ConfirmFunc([Nullable(1)] string inputText)
	{
		CreateCharacterView.<ConfirmFunc>d__25 <ConfirmFunc>d__;
		<ConfirmFunc>d__.<>t__builder = AsyncUniTaskMethodBuilder<ErrorCode>.Create();
		<ConfirmFunc>d__.<>4__this = this;
		<ConfirmFunc>d__.inputText = inputText;
		<ConfirmFunc>d__.<>1__state = -1;
		<ConfirmFunc>d__.<>t__builder.Start<CreateCharacterView.<ConfirmFunc>d__25>(ref <ConfirmFunc>d__);
		return <ConfirmFunc>d__.<>t__builder.Task;
	}

	// Token: 0x0600C2E2 RID: 49890 RVA: 0x00335B68 File Offset: 0x00333D68
	private void CreateCharacterResult(bool result)
	{
		if (result)
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.XXJ, "创角界面请求创角成功", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelBase<LoginModel>.Instance.CreateLoginPromise();
			ControllerBase<LoginController>.Instance.HandleLoginGame(false, result).ContinueWith(delegate(bool ret)
			{
				ControllerBase<LoginController>.Instance.DisConnect(ret);
				if (!ret)
				{
					ControllerBase<LoginController>.Instance.CreateCharacterViewToLoginView();
					return;
				}
				this.HideNameView(true);
				base.GetItem(3).SetUIActive(false);
				Singleton<UiLoginSceneManager>.Instance.PlayRoleMontage(this.InitialRoles[(int)this.SelectedSex.Value], EPerformanceRoleState.CreateRole_Head);
				Singleton<UiLoginSceneManager>.Instance.LoadSequenceAsync(this.GetResultSequenceName(), delegate
				{
					ModelBase<RecommendQualityModel>.Instance.CheckOpenRecommendQuality();
				}, false, null);
			}).Forget();
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.XXJ, "创角界面请求创角失败", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.TextInputModule.ClearText();
		base.GetItem(3).SetUIActive(true);
	}

	// Token: 0x0600C2E3 RID: 49891 RVA: 0x00335BF5 File Offset: 0x00333DF5
	private string GetResultSequenceName()
	{
		if (this.SelectedSex.GetValueOrDefault() == LoginDefine.ELoginSex.Boy)
		{
			return "LevelSequence_MaleTurnHead";
		}
		return "LevelSequence_FemaleTurnHead";
	}

	// Token: 0x04005D5A RID: 23898
	private LoginDefine.ELoginSex? SelectedSex;

	// Token: 0x04005D5B RID: 23899
	private bool InSelectedState;

	// Token: 0x04005D5C RID: 23900
	private IReadOnlyList<int> InitialRoles = Array.Empty<int>();

	// Token: 0x04005D5D RID: 23901
	private readonly List<CreateCharacterView.GenderButton> GenderButtonList = new List<CreateCharacterView.GenderButton>();

	// Token: 0x04005D5E RID: 23902
	[Nullable(2)]
	private TextInputComponent TextInputModule;

	// Token: 0x02007D4E RID: 32078
	[NullableContext(0)]
	private class ECreateCharacterCom
	{
		// Token: 0x0402AB56 RID: 174934
		public const int TextInputModule = 0;

		// Token: 0x0402AB57 RID: 174935
		public const int MaleButton = 1;

		// Token: 0x0402AB58 RID: 174936
		public const int FemaleButton = 2;

		// Token: 0x0402AB59 RID: 174937
		public const int GenderPanel = 3;

		// Token: 0x0402AB5A RID: 174938
		public const int TitleItem = 4;
	}

	// Token: 0x02007D4F RID: 32079
	[Nullable(0)]
	private class GenderButton
	{
		// Token: 0x06047D4A RID: 294218 RVA: 0x01329D6A File Offset: 0x01327F6A
		public GenderButton(UUIButtonComponent uiButton, int roleId)
		{
			this.Button = uiButton;
			this.RoleId = roleId;
		}

		// Token: 0x06047D4B RID: 294219 RVA: 0x01329D80 File Offset: 0x01327F80
		public void BindFunction()
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			this.Button.OnPointEnterCallBack.Bind(new Action(this.SetRoleSelectRenderingMaterial));
			this.Button.OnPointExitCallBack.Bind(new Action(this.RemoveRoleRenderingMaterial));
		}

		// Token: 0x06047D4C RID: 294220 RVA: 0x01329DD4 File Offset: 0x01327FD4
		private void SetRoleSelectRenderingMaterial()
		{
			this.RemoveRoleRenderingMaterial();
			this.RoleSelectMaterialId = new int?(Singleton<UiLoginSceneManager>.Instance.SetRoleRenderingMaterial(this.RoleId, "CreateCharacterMaterialController"));
			this.HuluSelectMaterialId = new int?(Singleton<UiLoginSceneManager>.Instance.SetHuluRenderingMaterial(this.RoleId, "CreateCharacterMaterialController"));
		}

		// Token: 0x06047D4D RID: 294221 RVA: 0x01329E28 File Offset: 0x01328028
		public void RemoveRoleRenderingMaterial()
		{
			if (this.RoleSelectMaterialId != null)
			{
				Singleton<UiLoginSceneManager>.Instance.RemoveRoleRenderingMaterialWithEnding(this.RoleId, this.RoleSelectMaterialId.Value);
				this.RoleSelectMaterialId = null;
			}
			if (this.HuluSelectMaterialId != null)
			{
				Singleton<UiLoginSceneManager>.Instance.RemoveHuluRenderingMaterialWithEnding(this.RoleId, this.HuluSelectMaterialId.Value);
				this.HuluSelectMaterialId = null;
			}
		}

		// Token: 0x06047D4E RID: 294222 RVA: 0x01329EA0 File Offset: 0x013280A0
		public void SetRoleChooseRenderingMaterial()
		{
			this.RemoveRoleChooseRenderingMaterial();
			this.RoleChooseMaterialId = new int?(Singleton<UiLoginSceneManager>.Instance.SetRoleRenderingMaterial(this.RoleId, "ChooseCharacterMaterialController"));
			this.HuluChooseMaterialId = new int?(Singleton<UiLoginSceneManager>.Instance.SetHuluRenderingMaterial(this.RoleId, "ChooseCharacterMaterialController"));
		}

		// Token: 0x06047D4F RID: 294223 RVA: 0x01329EF4 File Offset: 0x013280F4
		public void RemoveRoleChooseRenderingMaterial()
		{
			if (this.RoleChooseMaterialId != null)
			{
				Singleton<UiLoginSceneManager>.Instance.RemoveRoleRenderingMaterialWithEnding(this.RoleId, this.RoleChooseMaterialId.Value);
				this.RoleChooseMaterialId = null;
			}
			if (this.HuluChooseMaterialId != null)
			{
				Singleton<UiLoginSceneManager>.Instance.RemoveHuluRenderingMaterialWithEnding(this.RoleId, this.HuluChooseMaterialId.Value);
				this.HuluChooseMaterialId = null;
			}
		}

		// Token: 0x06047D50 RID: 294224 RVA: 0x01329F69 File Offset: 0x01328169
		public void UnbindFunction()
		{
			this.Button.OnPointEnterCallBack.Unbind();
			this.Button.OnPointExitCallBack.Unbind();
		}

		// Token: 0x0402AB5B RID: 174939
		private int? RoleSelectMaterialId;

		// Token: 0x0402AB5C RID: 174940
		private int? HuluSelectMaterialId;

		// Token: 0x0402AB5D RID: 174941
		private int? RoleChooseMaterialId;

		// Token: 0x0402AB5E RID: 174942
		private int? HuluChooseMaterialId;

		// Token: 0x0402AB5F RID: 174943
		private readonly UUIButtonComponent Button;

		// Token: 0x0402AB60 RID: 174944
		private readonly int RoleId;
	}
}
