using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A3D RID: 10813
public class SkinFadeAnimController : IStaticVariableResetter
{
	// Token: 0x06015A73 RID: 88691 RVA: 0x00602D05 File Offset: 0x00600F05
	static SkinFadeAnimController()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SkinFadeAnimController.CreateStaticDefaultValue), new Action(SkinFadeAnimController.ResetStaticDefaultValue));
	}

	// Token: 0x06015A74 RID: 88692 RVA: 0x00602D24 File Offset: 0x00600F24
	public static void CreateStaticDefaultValue()
	{
		Dictionary<EModelStateInSkinView, Dictionary<EModelStateInSkinView, ValueTuple<EModelFadeType, ERoleFadeCurveDefine>>> dictionary = new Dictionary<EModelStateInSkinView, Dictionary<EModelStateInSkinView, ValueTuple<EModelFadeType, ERoleFadeCurveDefine>>>();
		EModelStateInSkinView key = EModelStateInSkinView.ShowRole;
		Dictionary<EModelStateInSkinView, ValueTuple<EModelFadeType, ERoleFadeCurveDefine>> dictionary2 = new Dictionary<EModelStateInSkinView, ValueTuple<EModelFadeType, ERoleFadeCurveDefine>>();
		dictionary2[EModelStateInSkinView.ShowWeapon] = new ValueTuple<EModelFadeType, ERoleFadeCurveDefine>(EModelFadeType.FadeIn, ERoleFadeCurveDefine.WeaponSkinRoleFadeInCurve);
		dictionary2[EModelStateInSkinView.ShowGlider] = new ValueTuple<EModelFadeType, ERoleFadeCurveDefine>(EModelFadeType.FadeIn, ERoleFadeCurveDefine.FlySkinRoleFadeInCurve);
		dictionary2[EModelStateInSkinView.ShowCalabash] = new ValueTuple<EModelFadeType, ERoleFadeCurveDefine>(EModelFadeType.FadeIn, ERoleFadeCurveDefine.TerminalSkinRoleFadeInCurve);
		dictionary[key] = dictionary2;
		EModelStateInSkinView key2 = EModelStateInSkinView.ShowWeapon;
		Dictionary<EModelStateInSkinView, ValueTuple<EModelFadeType, ERoleFadeCurveDefine>> dictionary3 = new Dictionary<EModelStateInSkinView, ValueTuple<EModelFadeType, ERoleFadeCurveDefine>>();
		dictionary3[EModelStateInSkinView.ShowRole] = new ValueTuple<EModelFadeType, ERoleFadeCurveDefine>(EModelFadeType.FadeOut, ERoleFadeCurveDefine.WeaponSkinRoleFadeOutCurve);
		dictionary[key2] = dictionary3;
		EModelStateInSkinView key3 = EModelStateInSkinView.ShowGlider;
		Dictionary<EModelStateInSkinView, ValueTuple<EModelFadeType, ERoleFadeCurveDefine>> dictionary4 = new Dictionary<EModelStateInSkinView, ValueTuple<EModelFadeType, ERoleFadeCurveDefine>>();
		dictionary4[EModelStateInSkinView.ShowRole] = new ValueTuple<EModelFadeType, ERoleFadeCurveDefine>(EModelFadeType.FadeOut, ERoleFadeCurveDefine.FlySkinRoleFadeOutCurve);
		dictionary[key3] = dictionary4;
		EModelStateInSkinView key4 = EModelStateInSkinView.ShowCalabash;
		Dictionary<EModelStateInSkinView, ValueTuple<EModelFadeType, ERoleFadeCurveDefine>> dictionary5 = new Dictionary<EModelStateInSkinView, ValueTuple<EModelFadeType, ERoleFadeCurveDefine>>();
		dictionary5[EModelStateInSkinView.ShowRole] = new ValueTuple<EModelFadeType, ERoleFadeCurveDefine>(EModelFadeType.FadeOut, ERoleFadeCurveDefine.TerminalSkinRoleFadeOutCurve);
		dictionary[key4] = dictionary5;
		SkinFadeAnimController.fadeCurveMap = dictionary;
	}

	// Token: 0x06015A75 RID: 88693 RVA: 0x00602DD7 File Offset: 0x00600FD7
	public static void ResetStaticDefaultValue()
	{
		SkinFadeAnimController.fadeCurveMap = null;
	}

	// Token: 0x06015A76 RID: 88694 RVA: 0x00602DE0 File Offset: 0x00600FE0
	public void ChangeModelState(EModelStateInSkinView? state)
	{
		EModelStateInSkinView? modelState = this.ModelState;
		EModelStateInSkinView? emodelStateInSkinView = state;
		if (modelState.GetValueOrDefault() == emodelStateInSkinView.GetValueOrDefault() & modelState != null == (emodelStateInSkinView != null))
		{
			return;
		}
		EModelStateInSkinView? modelState2 = this.ModelState;
		this.ModelState = state;
		EModelStateInSkinView? emodelStateInSkinView2 = state;
		TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
		UiModelBase uiModelBase = (tsUiSceneRoleActor != null) ? tsUiSceneRoleActor.Model : null;
		if (uiModelBase == null)
		{
			return;
		}
		Dictionary<EModelStateInSkinView, ValueTuple<EModelFadeType, ERoleFadeCurveDefine>> dictionary = (modelState2 != null) ? SkinFadeAnimController.fadeCurveMap.GetValueOrDefault(modelState2.Value) : null;
		if (dictionary != null && emodelStateInSkinView2 != null)
		{
			ValueTuple<EModelFadeType, ERoleFadeCurveDefine>? valueOrNull = dictionary.GetValueOrNull(emodelStateInSkinView2.Value);
			ValueTuple<EModelFadeType, ERoleFadeCurveDefine>? valueTuple = valueOrNull;
			if (valueTuple != null)
			{
				if (valueOrNull.Value.Item1 == EModelFadeType.FadeIn)
				{
					Singleton<UiModelUtil>.Instance.ModelFadeIn(uiModelBase, new ERoleFadeCurveDefine?(valueOrNull.Value.Item2), null);
					return;
				}
				Singleton<UiModelUtil>.Instance.ModelFadeOut(uiModelBase, new ERoleFadeCurveDefine?(valueOrNull.Value.Item2), null);
			}
		}
	}

	// Token: 0x0400A656 RID: 42582
	[Nullable(new byte[]
	{
		2,
		1,
		0
	})]
	private static Dictionary<EModelStateInSkinView, Dictionary<EModelStateInSkinView, ValueTuple<EModelFadeType, ERoleFadeCurveDefine>>> fadeCurveMap;

	// Token: 0x0400A657 RID: 42583
	[Nullable(2)]
	public TsUiSceneRoleActor TsUiSceneRoleActor;

	// Token: 0x0400A658 RID: 42584
	private EModelStateInSkinView? ModelState = new EModelStateInSkinView?(EModelStateInSkinView.ShowRole);
}
