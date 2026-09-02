using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.GameSettings;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.EyeProtect
{
	// Token: 0x020057B2 RID: 22450
	[NullableContext(1)]
	[Nullable(0)]
	public class EyeProtectViewModel
	{
		// Token: 0x06039142 RID: 233794 RVA: 0x00E77668 File Offset: 0x00E75868
		public EyeProtectViewModel()
		{
			this.MenuMetaData = ModelBase<MenuModel>.Instance.GetMenuDataByFunctionId(20210);
			MenuConfig metaConfig;
			if (Singleton<GameSettingsManager>.Instance.ValidApplyConfigMap.TryGetValue(EFunction.EyeProtectionMode, out metaConfig))
			{
				this.ModeMetaData = new MenuData(metaConfig);
				this.ModeCurValue = new int?(Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.EyeProtectionMode, 0, true));
			}
		}

		// Token: 0x170091AA RID: 37290
		// (get) Token: 0x06039143 RID: 233795 RVA: 0x00E776F2 File Offset: 0x00E758F2
		public bool IsDirty
		{
			get
			{
				if (this.ModeCurValue.GetValueOrDefault() != 2)
				{
					return this.IsModeDirty;
				}
				return this.IsModeDirty || this.IsSliderDirty;
			}
		}

		// Token: 0x06039144 RID: 233796 RVA: 0x00E7771C File Offset: 0x00E7591C
		[NullableContext(0)]
		public UniTask<bool> BuildComponentAndOpen()
		{
			EyeProtectViewModel.<BuildComponentAndOpen>d__13 <BuildComponentAndOpen>d__;
			<BuildComponentAndOpen>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<BuildComponentAndOpen>d__.<>4__this = this;
			<BuildComponentAndOpen>d__.<>1__state = -1;
			<BuildComponentAndOpen>d__.<>t__builder.Start<EyeProtectViewModel.<BuildComponentAndOpen>d__13>(ref <BuildComponentAndOpen>d__);
			return <BuildComponentAndOpen>d__.<>t__builder.Task;
		}

		// Token: 0x06039145 RID: 233797 RVA: 0x00E77760 File Offset: 0x00E75960
		public void OnModeValueChange(int value)
		{
			this.ModeCurValue = new int?(value);
			GameSettingsUtils.ApplyEyeProtectionMode(value);
			if (value == 2)
			{
				List<EyeProtectSliderData> sliderDataList = this.GetSliderDataList(EModeValue.Custom);
				if (sliderDataList != null)
				{
					foreach (EyeProtectSliderData eyeProtectSliderData in sliderDataList)
					{
						eyeProtectSliderData.OnSetValue();
					}
				}
			}
			this.IsModeDirty = (Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.EyeProtectionMode, 0, true) != value);
		}

		// Token: 0x06039146 RID: 233798 RVA: 0x00E777EC File Offset: 0x00E759EC
		public void OnModeValueApply()
		{
			if (!this.IsModeDirty)
			{
				return;
			}
			if (this.ModeCurValue != null)
			{
				Singleton<GameSettingsManager>.Instance.HandleValueChange(EFunction.EyeProtectionMode, this.ModeCurValue.Value, EGameSettingsApplyReason.WhenUi);
			}
			this.IsModeDirty = false;
		}

		// Token: 0x06039147 RID: 233799 RVA: 0x00E77826 File Offset: 0x00E75A26
		public string GetTitle()
		{
			return this.MenuMetaData.FunctionName;
		}

		// Token: 0x06039148 RID: 233800 RVA: 0x00E77833 File Offset: 0x00E75A33
		public MenuData GetModeMetaData()
		{
			return this.ModeMetaData;
		}

		// Token: 0x06039149 RID: 233801 RVA: 0x00E7783C File Offset: 0x00E75A3C
		public List<EyeProtectItemData> GetModeDataList()
		{
			List<EyeProtectItemData> list = new List<EyeProtectItemData>();
			if (this.ModeMetaData == null)
			{
				return list;
			}
			IReadOnlyList<int> optionsValueList = this.ModeMetaData.OptionsValueList;
			IReadOnlyList<string> optionsNameList = this.ModeMetaData.OptionsNameList;
			for (int i = 0; i < optionsValueList.Count; i++)
			{
				list.Add(new EyeProtectItemData(optionsValueList[i], optionsNameList[i], this));
			}
			return list;
		}

		// Token: 0x0603914A RID: 233802 RVA: 0x00E778A0 File Offset: 0x00E75AA0
		public UniTask InitParam()
		{
			EyeProtectViewModel.<InitParam>d__20 <InitParam>d__;
			<InitParam>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitParam>d__.<>4__this = this;
			<InitParam>d__.<>1__state = -1;
			<InitParam>d__.<>t__builder.Start<EyeProtectViewModel.<InitParam>d__20>(ref <InitParam>d__);
			return <InitParam>d__.<>t__builder.Task;
		}

		// Token: 0x0603914B RID: 233803 RVA: 0x00E778E4 File Offset: 0x00E75AE4
		public void InitSliderDataList(EModeValue modeValue)
		{
			List<EyeProtectSliderData> list = new List<EyeProtectSliderData>();
			foreach (EFunction key in this.SliderDataFunctionList)
			{
				MenuConfig metaConfig;
				if (Singleton<GameSettingsManager>.Instance.ValidApplyConfigMap.TryGetValue(key, out metaConfig))
				{
					EyeProtectSliderData item = new EyeProtectSliderData(new MenuData(metaConfig), this, modeValue);
					list.Add(item);
				}
			}
			this.SliderDataListMap[modeValue] = list;
		}

		// Token: 0x0603914C RID: 233804 RVA: 0x00E7794C File Offset: 0x00E75B4C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<EyeProtectSliderData> GetSliderDataList(EModeValue modeValue)
		{
			List<EyeProtectSliderData> result;
			if (this.SliderDataListMap.TryGetValue(modeValue, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0603914D RID: 233805 RVA: 0x00E7796C File Offset: 0x00E75B6C
		[NullableContext(2)]
		public void OnDragMoved(ULGUIPointerEventData eventData)
		{
			if (eventData == null)
			{
				return;
			}
			FilterCameraComponent filterCameraComponent = this.FilterCameraComponent;
			if (filterCameraComponent == null)
			{
				return;
			}
			filterCameraComponent.OnDragMoved(eventData);
		}

		// Token: 0x0603914E RID: 233806 RVA: 0x00E77983 File Offset: 0x00E75B83
		public void OnDragBegin()
		{
			FilterCameraComponent filterCameraComponent = this.FilterCameraComponent;
			if (filterCameraComponent == null)
			{
				return;
			}
			filterCameraComponent.OnDragBegin();
		}

		// Token: 0x0603914F RID: 233807 RVA: 0x00E77995 File Offset: 0x00E75B95
		public void OnDragEnded()
		{
			FilterCameraComponent filterCameraComponent = this.FilterCameraComponent;
			if (filterCameraComponent == null)
			{
				return;
			}
			filterCameraComponent.OnDragEnded();
		}

		// Token: 0x06039150 RID: 233808 RVA: 0x00E779A7 File Offset: 0x00E75BA7
		public void OnInputUiLookUp(string axisName, float value)
		{
			FilterCameraComponent filterCameraComponent = this.FilterCameraComponent;
			if (filterCameraComponent == null)
			{
				return;
			}
			filterCameraComponent.OnInputUiLookUp(axisName, value);
		}

		// Token: 0x06039151 RID: 233809 RVA: 0x00E779BB File Offset: 0x00E75BBB
		public void OnInputUiTurn(string axisName, float value)
		{
			FilterCameraComponent filterCameraComponent = this.FilterCameraComponent;
			if (filterCameraComponent == null)
			{
				return;
			}
			filterCameraComponent.OnInputUiTurn(axisName, value);
		}

		// Token: 0x040207E0 RID: 133088
		[Nullable(2)]
		protected MenuData MenuMetaData;

		// Token: 0x040207E1 RID: 133089
		[Nullable(2)]
		protected MenuData ModeMetaData;

		// Token: 0x040207E2 RID: 133090
		public int? ModeCurValue;

		// Token: 0x040207E3 RID: 133091
		[Nullable(2)]
		public FilterCameraComponent FilterCameraComponent;

		// Token: 0x040207E4 RID: 133092
		public bool IsModeDirty;

		// Token: 0x040207E5 RID: 133093
		public bool IsSliderDirty;

		// Token: 0x040207E6 RID: 133094
		protected readonly Dictionary<EModeValue, List<EyeProtectSliderData>> SliderDataListMap = new Dictionary<EModeValue, List<EyeProtectSliderData>>();

		// Token: 0x040207E7 RID: 133095
		[Nullable(2)]
		public UKuroScreenBlueLightFilterParameter ParamStrong;

		// Token: 0x040207E8 RID: 133096
		[Nullable(2)]
		public UKuroScreenBlueLightFilterParameter ParamWeak;

		// Token: 0x040207E9 RID: 133097
		private readonly EFunction[] SliderDataFunctionList = new EFunction[]
		{
			EFunction.EyeProtectionTemp,
			EFunction.EyeProtectionStrength,
			EFunction.EyeProtectionBrightness,
			EFunction.EyeProtectionTexture
		};

		// Token: 0x040207EA RID: 133098
		[Nullable(2)]
		public Action OnSliderValueChange;
	}
}
