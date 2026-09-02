using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Enum;

// Token: 0x02002C33 RID: 11315
[NullableContext(1)]
[Nullable(0)]
public class UiCameraMappingData
{
	// Token: 0x06016AC2 RID: 92866 RVA: 0x0064C105 File Offset: 0x0064A305
	public UiCameraMappingData(UiCameraMapping config)
	{
		this.Config = new UiCameraAnimationDefine.IUiCameraMapping(config);
		this.ViewName = config.ViewName;
		this.IsChildView = false;
	}

	// Token: 0x06016AC3 RID: 92867 RVA: 0x0064C12D File Offset: 0x0064A32D
	public UiCameraMappingData(ChildUiCameraMapping config)
	{
		this.Config = new UiCameraAnimationDefine.IUiCameraMapping(config);
		this.ViewName = config.ViewName;
		this.IsChildView = true;
	}

	// Token: 0x06016AC4 RID: 92868 RVA: 0x0064C155 File Offset: 0x0064A355
	public UiCameraAnimationDefine.IUiCameraMapping GetUiCameraMappingConfig()
	{
		return this.Config;
	}

	// Token: 0x06016AC5 RID: 92869 RVA: 0x0064C160 File Offset: 0x0064A360
	public string GetSourceHandleName()
	{
		EUiCameraAnimationTargetType euiCameraAnimationTargetType = (EUiCameraAnimationTargetType)this.Config.BodyTargetType;
		string defaultUiCameraSettingsName = this.Config.DefaultUiCameraSettingsName;
		if (euiCameraAnimationTargetType == EUiCameraAnimationTargetType.None)
		{
			return defaultUiCameraSettingsName;
		}
		string targetBodyKey = Singleton<UiCameraAnimationManager>.Instance.GetTargetBodyKey(euiCameraAnimationTargetType);
		if (string.IsNullOrEmpty(targetBodyKey))
		{
			return defaultUiCameraSettingsName;
		}
		Dictionary<string, string> bodyCameraSettingsNameMap = this.Config.BodyCameraSettingsNameMap;
		if (bodyCameraSettingsNameMap == null)
		{
			return defaultUiCameraSettingsName;
		}
		string text;
		bodyCameraSettingsNameMap.TryGetValue(targetBodyKey, out text);
		if (string.IsNullOrEmpty(text))
		{
			return defaultUiCameraSettingsName;
		}
		return text;
	}

	// Token: 0x06016AC6 RID: 92870 RVA: 0x0064C1CC File Offset: 0x0064A3CC
	[NullableContext(2)]
	public string GetTargetBodyKey()
	{
		int bodyTargetType = this.Config.BodyTargetType;
		string targetBodyKey = Singleton<UiCameraAnimationManager>.Instance.GetTargetBodyKey((EUiCameraAnimationTargetType)bodyTargetType);
		if (string.IsNullOrEmpty(targetBodyKey))
		{
			return null;
		}
		return targetBodyKey;
	}

	// Token: 0x06016AC7 RID: 92871 RVA: 0x0064C200 File Offset: 0x0064A400
	public bool CanPushCameraHandle()
	{
		string defaultUiCameraSettingsName = this.Config.DefaultUiCameraSettingsName;
		return !(defaultUiCameraSettingsName == "None") && !string.IsNullOrEmpty(defaultUiCameraSettingsName);
	}

	// Token: 0x06016AC8 RID: 92872 RVA: 0x0064C234 File Offset: 0x0064A434
	public string GetToBlendName(string toViewName)
	{
		Dictionary<string, string> uiCameraBlendNameMap = this.Config.UiCameraBlendNameMap;
		if (uiCameraBlendNameMap == null)
		{
			return this.Config.DefaultCameraBlendName;
		}
		if (string.IsNullOrEmpty(toViewName))
		{
			return this.Config.DefaultCameraBlendName;
		}
		string text;
		if (!uiCameraBlendNameMap.TryGetValue(toViewName, out text) || string.IsNullOrEmpty(text))
		{
			return this.Config.DefaultCameraBlendName;
		}
		return text;
	}

	// Token: 0x06016AC9 RID: 92873 RVA: 0x0064C290 File Offset: 0x0064A490
	public float GetUiCameraDelayTime()
	{
		return this.Config.UiCameraDelayTime;
	}

	// Token: 0x06016ACA RID: 92874 RVA: 0x0064C29D File Offset: 0x0064A49D
	public string GetViewName()
	{
		return this.ViewName;
	}

	// Token: 0x0400AEE2 RID: 44770
	private readonly UiCameraAnimationDefine.IUiCameraMapping Config;

	// Token: 0x0400AEE3 RID: 44771
	private readonly string ViewName;

	// Token: 0x0400AEE4 RID: 44772
	public readonly bool IsChildView;
}
