using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Area
{
	// Token: 0x02006179 RID: 24953
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class AreaModel : ModelBase<AreaModel>
	{
		// Token: 0x0603F107 RID: 258311 RVA: 0x0102BFC0 File Offset: 0x0102A1C0
		protected override bool OnInit()
		{
			this.SetAreaInfo(1);
			this.TipsShowCd = ConfigCommonParamById.GetIntConfig("AreaTipsShowCd").GetValueOrDefault();
			return true;
		}

		// Token: 0x0603F108 RID: 258312 RVA: 0x0102BFED File Offset: 0x0102A1ED
		protected override bool OnClear()
		{
			this.AreaStates.Clear();
			this.Areas.Clear();
			this.TipsLastShowTime.Clear();
			this.StreamingBlockedAreas.Clear();
			return true;
		}

		// Token: 0x17009B03 RID: 39683
		// (get) Token: 0x0603F109 RID: 258313 RVA: 0x0102C01C File Offset: 0x0102A21C
		[Nullable(2)]
		public string AreaName
		{
			[NullableContext(2)]
			get
			{
				if (this.CurAreaInfo != null)
				{
					return ConfigBase<AreaConfig>.Instance.GetAreaLocalName(this.CurAreaInfo.Value.Title);
				}
				return null;
			}
		}

		// Token: 0x17009B04 RID: 39684
		// (get) Token: 0x0603F10A RID: 258314 RVA: 0x0102C058 File Offset: 0x0102A258
		[Nullable(2)]
		public string AreaHintName
		{
			[NullableContext(2)]
			get
			{
				if (this.CurAreaInfo == null)
				{
					return null;
				}
				if (string.IsNullOrEmpty(this.CurAreaDisplayNameId))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Area;
					ELogAuthor author = ELogAuthor.YZH;
					string message = "[区域.xlsx]当前需要显示的区域提示没有配置对应文本";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("区域id", this.CurAreaInfo.Value.AreaId);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return null;
				}
				return ConfigBase<AreaConfig>.Instance.GetAreaLocalName(this.CurAreaDisplayNameId);
			}
		}

		// Token: 0x0603F10B RID: 258315 RVA: 0x0102C0D3 File Offset: 0x0102A2D3
		public void SetEnableAreaNamePrompt(bool disable)
		{
			this.EnableAreaNamePrompt = !disable;
		}

		// Token: 0x17009B05 RID: 39685
		// (get) Token: 0x0603F10C RID: 258316 RVA: 0x0102C0DF File Offset: 0x0102A2DF
		public Area? AreaInfo
		{
			get
			{
				return this.CurAreaInfo;
			}
		}

		// Token: 0x17009B06 RID: 39686
		// (get) Token: 0x0603F10D RID: 258317 RVA: 0x0102C0E7 File Offset: 0x0102A2E7
		public Dictionary<int, TsTriggerVolume> AllAreas
		{
			get
			{
				return this.Areas;
			}
		}

		// Token: 0x0603F10E RID: 258318 RVA: 0x0102C0EF File Offset: 0x0102A2EF
		public int GetCurrentAreaId(EAreaLevel? areaLevel = null)
		{
			return this.GetAreaId(this.CurAreaInfo.Value, areaLevel);
		}

		// Token: 0x0603F10F RID: 258319 RVA: 0x0102C104 File Offset: 0x0102A304
		public int GetAreaId(Area targetAreaInfo, EAreaLevel? areaLevel = null)
		{
			if (areaLevel == null)
			{
				return targetAreaInfo.AreaId;
			}
			AreaConfig instance = ConfigBase<AreaConfig>.Instance;
			int num = targetAreaInfo.AreaId;
			Area? areaInfo = instance.GetAreaInfo(num);
			while (areaInfo != null && areaInfo.Value.Level != (int)areaLevel.Value)
			{
				num = areaInfo.Value.Father;
				areaInfo = instance.GetAreaInfo(num);
			}
			return num;
		}

		// Token: 0x0603F110 RID: 258320 RVA: 0x0102C174 File Offset: 0x0102A374
		public List<int> GetAllAreaIdInheritable(Area targetAreaInfo)
		{
			List<int> list = new List<int>();
			list.Add(targetAreaInfo.AreaId);
			AreaConfig instance = ConfigBase<AreaConfig>.Instance;
			int num = targetAreaInfo.Father;
			Area? area = (num == 0) ? null : instance.GetAreaInfo(num);
			while (num != 0 && area != null)
			{
				list.Add(num);
				int father = area.Value.Father;
				if (num == father || father == 0)
				{
					break;
				}
				num = father;
				area = instance.GetAreaInfo(num);
			}
			return list;
		}

		// Token: 0x0603F111 RID: 258321 RVA: 0x0102C1F8 File Offset: 0x0102A3F8
		public List<int> GetAllAreaIdInheritableById(int targetAreaId)
		{
			List<int> list = new List<int>();
			AreaConfig instance = ConfigBase<AreaConfig>.Instance;
			Area? areaInfo = instance.GetAreaInfo(targetAreaId);
			if (areaInfo == null)
			{
				return list;
			}
			list.Add(targetAreaId);
			int num = areaInfo.Value.Father;
			Area? area = (num == 0) ? null : instance.GetAreaInfo(num);
			while (num != 0 && area != null)
			{
				list.Add(num);
				int father = area.Value.Father;
				if (num == father || father == 0)
				{
					break;
				}
				num = father;
				area = instance.GetAreaInfo(num);
			}
			return list;
		}

		// Token: 0x0603F112 RID: 258322 RVA: 0x0102C294 File Offset: 0x0102A494
		public void SetAreaInfo(int areaId)
		{
			if (areaId == 0)
			{
				return;
			}
			if (this.CurAreaInfo != null && this.CurAreaInfo.Value.Level == 2)
			{
				ModelBase<MapModel>.Instance.LastHighLevelArea = new int?(this.CurAreaInfo.Value.AreaId);
			}
			this.CurAreaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaId);
			PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.SetNumberPropById(EPlayerInfoNumber.AreaId, areaId);
		}

		// Token: 0x0603F113 RID: 258323 RVA: 0x0102C30C File Offset: 0x0102A50C
		public void SetAreaName(int areaId, bool timerIgnore = false)
		{
			int? p = (this.CurAreaInfo != null) ? new int?(this.CurAreaInfo.GetValueOrDefault().AreaId) : null;
			this.SetAreaInfo(areaId);
			if (this.CurAreaInfo.Value.Tips == 0)
			{
				Singleton<EventSystem>.Instance.Emit<int?, int>(EEventName.ChangeArea, p, areaId);
				return;
			}
			this.CurAreaDisplayNameId = this.CurAreaInfo.Value.Title;
			int num;
			this.TipsLastShowTime.TryGetValue(areaId, out num);
			if ((!this.TipsLastShowTime.ContainsKey(areaId) || timerIgnore || Singleton<Time>.Instance.PlayerTime - (double)num > (double)this.TipsShowCd) && this.EnableAreaNamePrompt)
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.AreaView))
				{
					Singleton<EventSystem>.Instance.Emit(EEventName.UpdateAreaView);
				}
				else
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.AreaView, null, null);
				}
				this.TipsLastShowTime[areaId] = (int)Singleton<Time>.Instance.PlayerTime;
			}
			Singleton<EventSystem>.Instance.Emit<int?, int>(EEventName.ChangeArea, p, areaId);
		}

		// Token: 0x0603F114 RID: 258324 RVA: 0x0102C42C File Offset: 0x0102A62C
		public unsafe void AddArea(int inAreaId, TsTriggerVolume inArea)
		{
			if (this.Areas.ContainsKey(inAreaId))
			{
				return;
			}
			if (this.StreamingBlockedAreas.Contains(inAreaId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Area;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "传送时应该完成流送的Volume加载完成并触发BeginPlay";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CurAreaId", (this.CurAreaInfo != null) ? new int?(this.CurAreaInfo.GetValueOrDefault().AreaId) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BlockedAreaId", inAreaId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StreamingBlockedAreas", this.StreamingBlockedAreas);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				this.StreamingBlockedAreas.Remove(inAreaId);
			}
			this.Areas[inAreaId] = inArea;
		}

		// Token: 0x0603F115 RID: 258325 RVA: 0x0102C51C File Offset: 0x0102A71C
		public unsafe void AddWatchArea(int inAreaId)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Area;
			ELogAuthor author = ELogAuthor.XDW;
			string message = "传送时应该完成流送的Volume实际上没有加载出来";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CurAreaId", (this.CurAreaInfo != null) ? new int?(this.CurAreaInfo.GetValueOrDefault().AreaId) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BlockedAreaId", inAreaId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StreamingBlockedAreas", this.StreamingBlockedAreas);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.StreamingBlockedAreas.Add(inAreaId);
		}

		// Token: 0x0603F116 RID: 258326 RVA: 0x0102C5E0 File Offset: 0x0102A7E0
		[NullableContext(2)]
		public TsTriggerVolume GetArea(int inAreaId)
		{
			TsTriggerVolume result;
			this.Areas.TryGetValue(inAreaId, out result);
			return result;
		}

		// Token: 0x0603F117 RID: 258327 RVA: 0x0102C600 File Offset: 0x0102A800
		public unsafe void RemoveArea(int inAreaId)
		{
			this.Areas.Remove(inAreaId);
			if (this.StreamingBlockedAreas.Contains(inAreaId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Area;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "传送时应该完成流送的Volume触发了EndPlay";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CurAreaId", (this.CurAreaInfo != null) ? new int?(this.CurAreaInfo.GetValueOrDefault().AreaId) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BlockedAreaId", inAreaId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StreamingBlockedAreas", this.StreamingBlockedAreas);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				this.StreamingBlockedAreas.Remove(inAreaId);
			}
		}

		// Token: 0x0603F118 RID: 258328 RVA: 0x0102C6E0 File Offset: 0x0102A8E0
		public bool? GetAreaState(int inAreaId)
		{
			bool value;
			if (this.AreaStates.TryGetValue(inAreaId, out value))
			{
				return new bool?(value);
			}
			return null;
		}

		// Token: 0x0603F119 RID: 258329 RVA: 0x0102C710 File Offset: 0x0102A910
		public void ToggleAreaState(int inAreaId, bool inEnable)
		{
			TsTriggerVolume tsTriggerVolume2;
			TsTriggerVolume tsTriggerVolume = this.Areas.TryGetValue(inAreaId, out tsTriggerVolume2) ? tsTriggerVolume2 : null;
			bool value;
			bool? flag = this.AreaStates.TryGetValue(inAreaId, out value) ? new bool?(value) : null;
			if (flag.GetValueOrDefault() == inEnable & flag != null)
			{
				return;
			}
			this.AreaStates[inAreaId] = inEnable;
			if (tsTriggerVolume != null)
			{
				tsTriggerVolume.ToggleArea(inEnable);
			}
		}

		// Token: 0x0603F11A RID: 258330 RVA: 0x0102C784 File Offset: 0x0102A984
		public void InitAreaStates(IReadOnlyList<Area> defaultAreaInfos, IReadOnlyList<SceneAreaState> modifiedAreaStates)
		{
			this.AreaStates.Clear();
			foreach (Area area in defaultAreaInfos)
			{
				this.AreaStates[area.AreaId] = area.IsInitActived;
			}
			foreach (SceneAreaState sceneAreaState in modifiedAreaStates)
			{
				this.AreaStates[sceneAreaState.AreaId] = sceneAreaState.State;
			}
		}

		// Token: 0x0603F11B RID: 258331 RVA: 0x0102C830 File Offset: 0x0102AA30
		public void InitArea(IReadOnlyList<SceneAreaState> initModifiedAreaStates)
		{
			List<Area> defaultAreaInfos = ConfigBase<AreaConfig>.Instance.GetAllAreaInfo() ?? new List<Area>();
			this.InitAreaStates(defaultAreaInfos, initModifiedAreaStates);
			int? numberPropById = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.AreaId);
			if (numberPropById != null && numberPropById.GetValueOrDefault() != 0)
			{
				ControllerBase<AreaController>.Instance.EnterAreaRequest(new int?(1), numberPropById.Value, false, "AreaModel.InitArea");
			}
		}

		// Token: 0x0603F11C RID: 258332 RVA: 0x0102C894 File Offset: 0x0102AA94
		public IReadOnlyDictionary<int, bool> GetAreaStates()
		{
			return this.AreaStates;
		}

		// Token: 0x0603F11D RID: 258333 RVA: 0x0102C89C File Offset: 0x0102AA9C
		public int? GetAreaCountryId()
		{
			if (this.CurAreaInfo == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Area, ELogAuthor.XXJ, "区域数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			if (this.CurAreaInfo.Value.CountryId == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Area;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[区域.xlsx]当前区域没有配置所属国家id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("区域id", this.CurAreaInfo.Value.AreaId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return new int?(this.CurAreaInfo.Value.CountryId);
		}

		// Token: 0x0603F11E RID: 258334 RVA: 0x0102C958 File Offset: 0x0102AB58
		public AreaModel.EAreaDangerLevel GetAreaDangerLevel()
		{
			RoleInstance[] roleList = ModelBase<RoleModel>.Instance.GetRoleList();
			int num = 0;
			foreach (RoleInstance roleInstance in roleList)
			{
				if (num < roleInstance.GetLevelData().GetLevel())
				{
					num = roleInstance.GetLevelData().GetLevel();
				}
			}
			int? intConfig = ConfigCommonParamById.GetIntConfig("HighDangerLevelOffset");
			int? intConfig2 = ConfigCommonParamById.GetIntConfig("MidDangerLevelOffset");
			int? num2 = null;
			if (this.CurAreaInfo != null)
			{
				int? num3 = this.CurAreaInfo.Value.GetWorldMonsterLevelMax(ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
				if (num3 != null)
				{
					int valueOrDefault = num3.GetValueOrDefault();
					num2 = new int?(valueOrDefault);
				}
			}
			if (num2 != null)
			{
				int? num3 = num2;
				int i = 0;
				if (!(num3.GetValueOrDefault() == i & num3 != null))
				{
					int num4 = num - num2.Value;
					if (num4 < intConfig2.Value && num4 >= intConfig.Value)
					{
						return AreaModel.EAreaDangerLevel.Mid;
					}
					if (num4 < intConfig.Value)
					{
						return AreaModel.EAreaDangerLevel.High;
					}
				}
			}
			return AreaModel.EAreaDangerLevel.Normal;
		}

		// Token: 0x0603F11F RID: 258335 RVA: 0x0102CA64 File Offset: 0x0102AC64
		public string GetAreaDangerText(AreaModel.EAreaDangerLevel dangerLevel)
		{
			if (dangerLevel == AreaModel.EAreaDangerLevel.High)
			{
				return ConfigBase<TextConfig>.Instance.GetTextById("AreaHighDangerText");
			}
			if (dangerLevel != AreaModel.EAreaDangerLevel.Mid)
			{
				return "";
			}
			return ConfigBase<TextConfig>.Instance.GetTextById("AreaHighMidText");
		}

		// Token: 0x0603F120 RID: 258336 RVA: 0x0102CA94 File Offset: 0x0102AC94
		public bool IsExistRecommendPlayPoint()
		{
			ExploreAreaData currentExploreAreaData = this.GetCurrentExploreAreaData();
			return currentExploreAreaData != null && currentExploreAreaData.IsShowRecommendPlayPoint();
		}

		// Token: 0x0603F121 RID: 258337 RVA: 0x0102CAA8 File Offset: 0x0102ACA8
		[NullableContext(2)]
		public ExploreAreaData GetCurrentExploreAreaData()
		{
			int worldMapLevelOneAreaId = MapUtil.GetWorldMapLevelOneAreaId();
			return ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(worldMapLevelOneAreaId);
		}

		// Token: 0x0603F122 RID: 258338 RVA: 0x0102CAC8 File Offset: 0x0102ACC8
		public string GetDebugString()
		{
			string text = "";
			Area? areaInfo = this.AreaInfo;
			int? num = (areaInfo != null) ? new int?(areaInfo.GetValueOrDefault().AreaId) : null;
			string str = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
			defaultInterpolatedStringHandler.AppendLiteral("当前区域:");
			defaultInterpolatedStringHandler.AppendFormatted<int?>(num);
			defaultInterpolatedStringHandler.AppendLiteral("\n");
			text = str + defaultInterpolatedStringHandler.ToStringAndClear();
			string str2 = text;
			string str3 = "\t关联区块:";
			areaInfo = this.AreaInfo;
			text = str2 + str3 + ((areaInfo != null) ? areaInfo.GetValueOrDefault().AreaName : null) + "\n";
			while (num != null)
			{
				num = new int?(ConfigBase<AreaConfig>.Instance.GetParentAreaId(num.Value));
				int? num2 = num;
				if (num2 == null)
				{
					break;
				}
				string str4 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
				defaultInterpolatedStringHandler.AppendLiteral("父级区域:");
				defaultInterpolatedStringHandler.AppendFormatted<int?>(num);
				defaultInterpolatedStringHandler.AppendLiteral("\n");
				text = str4 + defaultInterpolatedStringHandler.ToStringAndClear();
				string str5 = text;
				string str6 = "\t关联区块:";
				areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(num.Value);
				text = str5 + str6 + ((areaInfo != null) ? areaInfo.GetValueOrDefault().AreaName : null) + "\n";
			}
			return text;
		}

		// Token: 0x040235FC RID: 144892
		private const int DEFAULT_AREA_ID = 1;

		// Token: 0x040235FD RID: 144893
		private Area? CurAreaInfo;

		// Token: 0x040235FE RID: 144894
		private string CurAreaDisplayNameId = "";

		// Token: 0x040235FF RID: 144895
		private readonly Dictionary<int, TsTriggerVolume> Areas = new Dictionary<int, TsTriggerVolume>();

		// Token: 0x04023600 RID: 144896
		private readonly Dictionary<int, bool> AreaStates = new Dictionary<int, bool>();

		// Token: 0x04023601 RID: 144897
		private readonly Dictionary<int, int> TipsLastShowTime = new Dictionary<int, int>();

		// Token: 0x04023602 RID: 144898
		private int TipsShowCd;

		// Token: 0x04023603 RID: 144899
		private readonly HashSet<int> StreamingBlockedAreas = new HashSet<int>();

		// Token: 0x04023604 RID: 144900
		private bool EnableAreaNamePrompt = true;

		// Token: 0x0200C2F7 RID: 49911
		[NullableContext(0)]
		public enum EAreaDangerLevel
		{
			// Token: 0x0403C19B RID: 246171
			High,
			// Token: 0x0403C19C RID: 246172
			Mid,
			// Token: 0x0403C19D RID: 246173
			Normal
		}
	}
}
