using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;

// Token: 0x02001B30 RID: 6960
[NullableContext(1)]
[Nullable(0)]
public class DynamicTabCamera : IStaticVariableResetter
{
	// Token: 0x0600C8C1 RID: 51393 RVA: 0x00353484 File Offset: 0x00351684
	static DynamicTabCamera()
	{
		Dictionary<EUiViewName, Func<string, string>> dictionary = new Dictionary<EUiViewName, Func<string, string>>();
		EUiViewName roleRootView = EUiViewName.RoleRootView;
		dictionary[roleRootView] = new Func<string, string>(DynamicTabCamera.GetRoleUiCamera);
		EUiViewName roleHandBookRootView = EUiViewName.RoleHandBookRootView;
		dictionary[roleHandBookRootView] = new Func<string, string>(DynamicTabCamera.GetRoleUiCamera);
		DynamicTabCamera.TabCameraNameMap = dictionary;
		StaticVariableRegister.RegisterAndExecute(new Action(DynamicTabCamera.CreateStaticDefaultValue), new Action(DynamicTabCamera.ResetStaticDefaultValue));
	}

	// Token: 0x0600C8C2 RID: 51394 RVA: 0x003534EA File Offset: 0x003516EA
	public static void CreateStaticDefaultValue()
	{
		DynamicTabCamera.CameraFinishedCallbackMap = new Dictionary<string, Action>();
	}

	// Token: 0x0600C8C3 RID: 51395 RVA: 0x003534F6 File Offset: 0x003516F6
	public static void ResetStaticDefaultValue()
	{
		DynamicTabCamera.CameraHandleData = null;
		DynamicTabCamera.CameraFinishedCallbackMap = null;
	}

	// Token: 0x0600C8C4 RID: 51396 RVA: 0x00353504 File Offset: 0x00351704
	private static string GetRoleUiCamera(string uiCameraSettingsName)
	{
		return uiCameraSettingsName + "_" + ModelBase<RoleModel>.Instance.GetCurSelectMainRoleInstance().GetRoleConfig().RoleBody;
	}

	// Token: 0x0600C8C5 RID: 51397 RVA: 0x00353533 File Offset: 0x00351733
	public static UiCameraHandleData GetCameraHandleData()
	{
		return DynamicTabCamera.CameraHandleData;
	}

	// Token: 0x0600C8C6 RID: 51398 RVA: 0x0035353A File Offset: 0x0035173A
	[NullableContext(2)]
	public static void PlayTabUiCamera(EUiTabViewName tabViewName, string uiCameraBlendName = null)
	{
	}

	// Token: 0x0600C8C7 RID: 51399 RVA: 0x0035353C File Offset: 0x0035173C
	public static void OnPlayCameraAnimationFinished(UiCameraAnimationDefine.IFinishData finishData)
	{
		string handleName = finishData.ToHandleData.HandleName;
		Action action;
		if (DynamicTabCamera.CameraFinishedCallbackMap.TryGetValue(handleName, out action) && action != null)
		{
			action();
		}
	}

	// Token: 0x0600C8C8 RID: 51400 RVA: 0x00353570 File Offset: 0x00351770
	public static string GetUiCameraHandleName(EUiTabViewName tabViewName)
	{
		UiDynamicTab viewTab = ConfigBase<DynamicTabConfig>.Instance.GetViewTab(tabViewName);
		EUiViewName key = (EUiViewName)viewTab.ParentViewName;
		Func<string, string> func;
		if (DynamicTabCamera.TabCameraNameMap.TryGetValue(key, out func))
		{
			return func(viewTab.UiCameraSettingsName);
		}
		return viewTab.UiCameraSettingsName;
	}

	// Token: 0x04006046 RID: 24646
	[Nullable(2)]
	private static UiCameraHandleData CameraHandleData;

	// Token: 0x04006047 RID: 24647
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<string, Action> CameraFinishedCallbackMap;

	// Token: 0x04006048 RID: 24648
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<EUiViewName, Func<string, string>> TabCameraNameMap;
}
