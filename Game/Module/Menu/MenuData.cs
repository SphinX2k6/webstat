using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005747 RID: 22343
	[NullableContext(1)]
	[Nullable(0)]
	public class MenuData
	{
		// Token: 0x06038E45 RID: 233029 RVA: 0x00E6BAF8 File Offset: 0x00E69CF8
		public MenuData(MenuConfig metaConfig)
		{
			this.MetaConfig = metaConfig;
		}

		// Token: 0x17009133 RID: 37171
		// (get) Token: 0x06038E46 RID: 233030 RVA: 0x00E6BB12 File Offset: 0x00E69D12
		public int ConfigId
		{
			get
			{
				return this.MetaConfig.Id;
			}
		}

		// Token: 0x17009134 RID: 37172
		// (get) Token: 0x06038E47 RID: 233031 RVA: 0x00E6BB1F File Offset: 0x00E69D1F
		public int SubType
		{
			get
			{
				return this.MetaConfig.SubType;
			}
		}

		// Token: 0x17009135 RID: 37173
		// (get) Token: 0x06038E48 RID: 233032 RVA: 0x00E6BB2C File Offset: 0x00E69D2C
		public string SubName
		{
			get
			{
				return this.MetaConfig.SubName;
			}
		}

		// Token: 0x17009136 RID: 37174
		// (get) Token: 0x06038E49 RID: 233033 RVA: 0x00E6BB39 File Offset: 0x00E69D39
		public virtual string FunctionName
		{
			get
			{
				return this.MetaConfig.Name;
			}
		}

		// Token: 0x17009137 RID: 37175
		// (get) Token: 0x06038E4A RID: 233034 RVA: 0x00E6BB46 File Offset: 0x00E69D46
		public int FunctionSort
		{
			get
			{
				return this.MetaConfig.FunctionSort;
			}
		}

		// Token: 0x17009138 RID: 37176
		// (get) Token: 0x06038E4B RID: 233035 RVA: 0x00E6BB53 File Offset: 0x00E69D53
		public int SubSort
		{
			get
			{
				return this.MetaConfig.SubSort;
			}
		}

		// Token: 0x17009139 RID: 37177
		// (get) Token: 0x06038E4C RID: 233036 RVA: 0x00E6BB60 File Offset: 0x00E69D60
		public EFunction FunctionId
		{
			get
			{
				return (EFunction)this.MetaConfig.FunctionId;
			}
		}

		// Token: 0x1700913A RID: 37178
		// (get) Token: 0x06038E4D RID: 233037 RVA: 0x00E6BB6D File Offset: 0x00E69D6D
		public bool NeedScale
		{
			get
			{
				return this.MetaConfig.NeedScale;
			}
		}

		// Token: 0x1700913B RID: 37179
		// (get) Token: 0x06038E4E RID: 233038 RVA: 0x00E6BB7A File Offset: 0x00E69D7A
		public ESetType SetType
		{
			get
			{
				return (ESetType)this.MetaConfig.SetType;
			}
		}

		// Token: 0x1700913C RID: 37180
		// (get) Token: 0x06038E4F RID: 233039 RVA: 0x00E6BB87 File Offset: 0x00E69D87
		public float[] SliderRange
		{
			get
			{
				return this.MetaConfig.SliderRange();
			}
		}

		// Token: 0x1700913D RID: 37181
		// (get) Token: 0x06038E50 RID: 233040 RVA: 0x00E6BB94 File Offset: 0x00E69D94
		public float[] SliderRangeDisplay
		{
			get
			{
				if (this.MetaConfig.SliderRangeDisplayLength > 0)
				{
					return this.MetaConfig.SliderRangeDisplay();
				}
				return this.MetaConfig.SliderRange();
			}
		}

		// Token: 0x1700913E RID: 37182
		// (get) Token: 0x06038E51 RID: 233041 RVA: 0x00E6BBBB File Offset: 0x00E69DBB
		public float SliderDefault
		{
			get
			{
				return this.MetaConfig.SliderDefault;
			}
		}

		// Token: 0x1700913F RID: 37183
		// (get) Token: 0x06038E52 RID: 233042 RVA: 0x00E6BBC8 File Offset: 0x00E69DC8
		public int SliderDigits
		{
			get
			{
				return this.MetaConfig.Digits;
			}
		}

		// Token: 0x17009140 RID: 37184
		// (get) Token: 0x06038E53 RID: 233043 RVA: 0x00E6BBD5 File Offset: 0x00E69DD5
		public int OptionsDefault
		{
			get
			{
				return this.MetaConfig.OptionsDefault;
			}
		}

		// Token: 0x17009141 RID: 37185
		// (get) Token: 0x06038E54 RID: 233044 RVA: 0x00E6BBE2 File Offset: 0x00E69DE2
		public bool BtnDisableTipsEnable
		{
			get
			{
				return this.MetaConfig.BtnDisableTipsEnable;
			}
		}

		// Token: 0x17009142 RID: 37186
		// (get) Token: 0x06038E55 RID: 233045 RVA: 0x00E6BBEF File Offset: 0x00E69DEF
		public bool CanShowInLogin
		{
			get
			{
				return this.MetaConfig.CanShowInLogin;
			}
		}

		// Token: 0x17009143 RID: 37187
		// (get) Token: 0x06038E56 RID: 233046 RVA: 0x00E6BBFC File Offset: 0x00E69DFC
		protected string[] OptionsNameListInternal
		{
			get
			{
				return this.MetaConfig.OptionsName();
			}
		}

		// Token: 0x17009144 RID: 37188
		// (get) Token: 0x06038E57 RID: 233047 RVA: 0x00E6BC09 File Offset: 0x00E69E09
		protected int[] OptionsValueListInternal
		{
			get
			{
				return this.MetaConfig.OptionsValue();
			}
		}

		// Token: 0x17009145 RID: 37189
		// (get) Token: 0x06038E58 RID: 233048 RVA: 0x00E6BC16 File Offset: 0x00E69E16
		public string SubImage
		{
			get
			{
				return this.MetaConfig.SubImage;
			}
		}

		// Token: 0x17009146 RID: 37190
		// (get) Token: 0x06038E59 RID: 233049 RVA: 0x00E6BC23 File Offset: 0x00E69E23
		public string FunctionImage
		{
			get
			{
				return this.MetaConfig.FunctionImage;
			}
		}

		// Token: 0x17009147 RID: 37191
		// (get) Token: 0x06038E5A RID: 233050 RVA: 0x00E6BC30 File Offset: 0x00E69E30
		public virtual string ButtonTextId
		{
			get
			{
				return this.MetaConfig.ButtonText;
			}
		}

		// Token: 0x17009148 RID: 37192
		// (get) Token: 0x06038E5B RID: 233051 RVA: 0x00E6BC3D File Offset: 0x00E69E3D
		public string ButtonViewName
		{
			get
			{
				return this.MetaConfig.OpenView;
			}
		}

		// Token: 0x17009149 RID: 37193
		// (get) Token: 0x06038E5C RID: 233052 RVA: 0x00E6BC4A File Offset: 0x00E69E4A
		public int[] RelationFuncIds
		{
			get
			{
				return this.MetaConfig.RelationFunction();
			}
		}

		// Token: 0x1700914A RID: 37194
		// (get) Token: 0x06038E5D RID: 233053 RVA: 0x00E6BC57 File Offset: 0x00E69E57
		public int[] AffectedValue
		{
			get
			{
				return this.MetaConfig.AffectedValue();
			}
		}

		// Token: 0x1700914B RID: 37195
		// (get) Token: 0x06038E5E RID: 233054 RVA: 0x00E6BC64 File Offset: 0x00E69E64
		public Dictionary<int, int> AffectedFunction
		{
			get
			{
				return this.MetaConfig.AffectedFunction();
			}
		}

		// Token: 0x1700914C RID: 37196
		// (get) Token: 0x06038E5F RID: 233055 RVA: 0x00E6BC71 File Offset: 0x00E69E71
		public int[] DisableValue
		{
			get
			{
				return this.MetaConfig.DisableValue();
			}
		}

		// Token: 0x1700914D RID: 37197
		// (get) Token: 0x06038E60 RID: 233056 RVA: 0x00E6BC7E File Offset: 0x00E69E7E
		public int[] DisableFunction
		{
			get
			{
				return this.MetaConfig.DisableFunction();
			}
		}

		// Token: 0x1700914E RID: 37198
		// (get) Token: 0x06038E61 RID: 233057 RVA: 0x00E6BC8B File Offset: 0x00E69E8B
		public string BtnDisableTips
		{
			get
			{
				return this.MetaConfig.BtnDisableTips;
			}
		}

		// Token: 0x1700914F RID: 37199
		// (get) Token: 0x06038E62 RID: 233058 RVA: 0x00E6BC98 File Offset: 0x00E69E98
		public Dictionary<int, string> ValueTipsMap
		{
			get
			{
				return this.MetaConfig.ValueTipsMap();
			}
		}

		// Token: 0x17009150 RID: 37200
		// (get) Token: 0x06038E63 RID: 233059 RVA: 0x00E6BCA5 File Offset: 0x00E69EA5
		public Dictionary<int, int> ClickedTipsMap
		{
			get
			{
				return this.MetaConfig.ClickedTipsMap();
			}
		}

		// Token: 0x17009151 RID: 37201
		// (get) Token: 0x06038E64 RID: 233060 RVA: 0x00E6BCB2 File Offset: 0x00E69EB2
		public bool IsDataCache
		{
			get
			{
				return this.MetaConfig.IsDataCache;
			}
		}

		// Token: 0x17009152 RID: 37202
		// (get) Token: 0x06038E65 RID: 233061 RVA: 0x00E6BCBF File Offset: 0x00E69EBF
		public string ClickedTips
		{
			get
			{
				return this.MetaConfig.ClickedTips;
			}
		}

		// Token: 0x17009153 RID: 37203
		// (get) Token: 0x06038E66 RID: 233062 RVA: 0x00E6BCCC File Offset: 0x00E69ECC
		private string DetailTextId
		{
			get
			{
				return this.MetaConfig.DetailText;
			}
		}

		// Token: 0x17009154 RID: 37204
		// (get) Token: 0x06038E67 RID: 233063 RVA: 0x00E6BCD9 File Offset: 0x00E69ED9
		public bool CanClickWhenDisable
		{
			get
			{
				return this.MetaConfig.CanDisableDetailShow;
			}
		}

		// Token: 0x17009155 RID: 37205
		// (get) Token: 0x06038E68 RID: 233064 RVA: 0x00E6BCE6 File Offset: 0x00E69EE6
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public virtual string[] CustomTitleArgs
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				return null;
			}
		}

		// Token: 0x06038E69 RID: 233065 RVA: 0x00E6BCEC File Offset: 0x00E69EEC
		public bool GetEnable()
		{
			if (this.FunctionId == EFunction.MobileGamepadMode)
			{
				MenuModel instance = ModelBase<MenuModel>.Instance;
				return instance != null && instance.GetDataCacheOrCurValue(EFunction.MobileGamepadMode).GetValueOrDefault() == 1;
			}
			if (this.FunctionId == EFunction.Filter)
			{
				MenuModel instance2 = ModelBase<MenuModel>.Instance;
				return instance2 != null && instance2.GetDataCacheOrCurValue(EFunction.ImageDisplayMode).GetValueOrDefault() == 1;
			}
			if (this.FunctionId == EFunction.EyeProtection)
			{
				MenuModel instance3 = ModelBase<MenuModel>.Instance;
				return instance3 != null && instance3.GetDataCacheOrCurValue(EFunction.ImageDisplayMode).GetValueOrDefault() == 2;
			}
			if (this.FunctionId == EFunction.HDR)
			{
				return UKuroGISystem.CheckWindowsSupportHDR();
			}
			if (this.CheckIsDisableFunctionInInstance())
			{
				return false;
			}
			foreach (KeyValuePair<EFunction, int[]> keyValuePair in this.OtherFunctionTargetDisableValueCache)
			{
				EFunction key = keyValuePair.Key;
				int[] value = keyValuePair.Value;
				MenuModel instance4 = ModelBase<MenuModel>.Instance;
				int? num = (instance4 != null) ? instance4.GetDataCacheOrCurValue(key) : null;
				if (num != null && Array.IndexOf<int>(value, num.Value) >= 0)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06038E6A RID: 233066 RVA: 0x00E6BE30 File Offset: 0x00E6A030
		private bool CheckIsDisableFunctionInInstance()
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			if (instanceId == 0)
			{
				return false;
			}
			InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
			InstanceDungeon? instanceDungeon = (instance != null) ? instance.GetConfig(instanceId) : null;
			if (instanceDungeon == null)
			{
				return false;
			}
			EFunction[] array = null;
			if (instanceDungeon.Value.InstSubType != 12)
			{
				MenuDefineInstSettings.disableSettingsInstMap.TryGetValue((EDungeonSubType)instanceDungeon.Value.InstSubType, out array);
			}
			else
			{
				MenuDefineInstSettings.disableSettingsWorldInstMap.TryGetValue((EWorldDungeonSubType)instanceDungeon.Value.WorldDungeonSubType, out array);
			}
			return array != null && Array.IndexOf<EFunction>(array, this.FunctionId) >= 0;
		}

		// Token: 0x17009156 RID: 37206
		// (get) Token: 0x06038E6B RID: 233067 RVA: 0x00E6BEDC File Offset: 0x00E6A0DC
		public virtual bool EnableRedDot
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06038E6C RID: 233068 RVA: 0x00E6BEDF File Offset: 0x00E6A0DF
		public virtual void OnRefresh()
		{
		}

		// Token: 0x06038E6D RID: 233069 RVA: 0x00E6BEE1 File Offset: 0x00E6A0E1
		public virtual bool GetButtonEnable()
		{
			return true;
		}

		// Token: 0x06038E6E RID: 233070 RVA: 0x00E6BEE4 File Offset: 0x00E6A0E4
		public void CacheDisableState(EFunction targetFunction, int[] targetValues)
		{
			this.OtherFunctionTargetDisableValueCache[targetFunction] = targetValues;
		}

		// Token: 0x06038E6F RID: 233071 RVA: 0x00E6BEF3 File Offset: 0x00E6A0F3
		public void ResetDisableStateCache()
		{
			this.OtherFunctionTargetDisableValueCache.Clear();
		}

		// Token: 0x06038E70 RID: 233072 RVA: 0x00E6BF00 File Offset: 0x00E6A100
		[NullableContext(2)]
		private string GetDisableOverrideTextForTarget(int targetFunctionId)
		{
			for (int i = 0; i < this.MetaConfig.DisableOverrideTextLength; i++)
			{
				DicIntString? dicIntString = this.MetaConfig.DisableOverrideText(i);
				if (dicIntString != null && dicIntString.Value.Key == targetFunctionId)
				{
					return dicIntString.Value.Value;
				}
			}
			return null;
		}

		// Token: 0x06038E71 RID: 233073 RVA: 0x00E6BF5C File Offset: 0x00E6A15C
		[NullableContext(2)]
		public string GetDisableOverrideText()
		{
			if (this.GetEnable())
			{
				return null;
			}
			foreach (KeyValuePair<EFunction, int[]> keyValuePair in this.OtherFunctionTargetDisableValueCache)
			{
				EFunction key = keyValuePair.Key;
				int[] value = keyValuePair.Value;
				MenuModel instance = ModelBase<MenuModel>.Instance;
				int? num = (instance != null) ? instance.GetDataCacheOrCurValue(key) : null;
				if (num != null && Array.IndexOf<int>(value, num.Value) >= 0)
				{
					MenuModel instance2 = ModelBase<MenuModel>.Instance;
					MenuData menuData = (instance2 != null) ? instance2.GetMenuDataByFunctionId((int)key) : null;
					if (menuData != null)
					{
						string disableOverrideTextForTarget = menuData.GetDisableOverrideTextForTarget((int)this.FunctionId);
						if (disableOverrideTextForTarget != null)
						{
							return disableOverrideTextForTarget;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06038E72 RID: 233074 RVA: 0x00E6C030 File Offset: 0x00E6A230
		public bool CanAffectedFunction(int value)
		{
			return Array.IndexOf<int>(this.AffectedValue, value) >= 0 && this.AffectedFunction.Count > 0;
		}

		// Token: 0x06038E73 RID: 233075 RVA: 0x00E6C051 File Offset: 0x00E6A251
		public bool HasDisableFunction()
		{
			return this.DisableFunction.Length != 0;
		}

		// Token: 0x17009157 RID: 37207
		// (get) Token: 0x06038E74 RID: 233076 RVA: 0x00E6C05D File Offset: 0x00E6A25D
		public IReadOnlyList<string> OptionsNameList
		{
			get
			{
				return this.OptionsNameListInternal;
			}
		}

		// Token: 0x17009158 RID: 37208
		// (get) Token: 0x06038E75 RID: 233077 RVA: 0x00E6C065 File Offset: 0x00E6A265
		public IReadOnlyList<int> OptionsValueList
		{
			get
			{
				return this.OptionsValueListInternal;
			}
		}

		// Token: 0x06038E76 RID: 233078 RVA: 0x00E6C070 File Offset: 0x00E6A270
		public bool HasDetailText()
		{
			string detailTextId = this.DetailTextId;
			return !string.IsNullOrEmpty(detailTextId) && !StringUtils.IsBlank(detailTextId);
		}

		// Token: 0x06038E77 RID: 233079 RVA: 0x00E6C099 File Offset: 0x00E6A299
		public int GetDetailPopId()
		{
			return this.MetaConfig.DetailPop;
		}

		// Token: 0x06038E78 RID: 233080 RVA: 0x00E6C0A6 File Offset: 0x00E6A2A6
		public bool ShowHelpBtn()
		{
			return this.MetaConfig.DetailPop > 0 || this.HasDetailText();
		}

		// Token: 0x06038E79 RID: 233081 RVA: 0x00E6C0BE File Offset: 0x00E6A2BE
		[NullableContext(2)]
		public string GetDetailTextId()
		{
			return this.DetailTextId;
		}

		// Token: 0x06038E7A RID: 233082 RVA: 0x00E6C0C6 File Offset: 0x00E6A2C6
		public void SetDetailTextVisible(bool bVisible)
		{
			this.IsDetailTextVisible = bVisible;
		}

		// Token: 0x06038E7B RID: 233083 RVA: 0x00E6C0CF File Offset: 0x00E6A2CF
		public bool GetIsDetailTextVisible()
		{
			return this.IsDetailTextVisible;
		}

		// Token: 0x06038E7C RID: 233084 RVA: 0x00E6C0D8 File Offset: 0x00E6A2D8
		public bool IsRecommendIndex(int index)
		{
			if (this.FunctionId != EFunction.IMAGEQUALITY)
			{
				return false;
			}
			if (ModelBase<MenuModel>.Instance.IsImageQualityCustom)
			{
				return false;
			}
			EGameQualitySettingLevel? recommendQualityLv = Singleton<GameSettingsDeviceRender>.Instance.GetRecommendQualityLv();
			return recommendQualityLv != null && Array.IndexOf<int>(this.OptionsValueListInternal, (int)recommendQualityLv.Value) == index;
		}

		// Token: 0x06038E7D RID: 233085 RVA: 0x00E6C12C File Offset: 0x00E6A32C
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<string, string> GetDetailSpritePath()
		{
			string text = (this.GetDetailPopId() > 0) ? "SP_BtnMenuDetailPop" : "SP_BtnMenuDetailText";
			string text2;
			if (!this.CanClickWhenDisable)
			{
				text2 = "SP_BtnMenuDetailLock";
			}
			else
			{
				text2 = text;
			}
			string text3;
			if (text == null)
			{
				text3 = null;
			}
			else
			{
				UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
				text3 = ((instance != null) ? instance.GetResourcePath(text) : null);
			}
			string text4;
			if (text2 == null)
			{
				text4 = null;
			}
			else
			{
				UiResourceConfig instance2 = ConfigBase<UiResourceConfig>.Instance;
				text4 = ((instance2 != null) ? instance2.GetResourcePath(text2) : null);
			}
			string text5 = text4;
			return new ValueTuple<string, string>(text3 ?? "", text5 ?? "");
		}

		// Token: 0x04020632 RID: 132658
		private MenuConfig MetaConfig;

		// Token: 0x04020633 RID: 132659
		private bool IsDetailTextVisible;

		// Token: 0x04020634 RID: 132660
		private readonly Dictionary<EFunction, int[]> OtherFunctionTargetDisableValueCache = new Dictionary<EFunction, int[]>();
	}
}
