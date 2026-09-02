using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UI.View.Morale;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Morale.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005707 RID: 22279
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleAreaSumView : UiTickViewBase
	{
		// Token: 0x06038B2F RID: 232239 RVA: 0x00E5B713 File Offset: 0x00E59913
		public MoraleAreaSumView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038B30 RID: 232240 RVA: 0x00E5B728 File Offset: 0x00E59928
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUITexture)),
				new ValueTuple<int, Type>(10, typeof(UUITexture)),
				new ValueTuple<int, Type>(11, typeof(UUIItem))
			};
		}

		// Token: 0x06038B31 RID: 232241 RVA: 0x00E5B84B File Offset: 0x00E59A4B
		protected override void OnBeforeCreate()
		{
			this.Model = ModelBase<MoraleModel>.Instance;
		}

		// Token: 0x06038B32 RID: 232242 RVA: 0x00E5B858 File Offset: 0x00E59A58
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleAreaSumView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleAreaSumView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038B33 RID: 232243 RVA: 0x00E5B89B File Offset: 0x00E59A9B
		protected override void OnStart()
		{
			this.InitAreaSumMapData();
		}

		// Token: 0x06038B34 RID: 232244 RVA: 0x00E5B8A4 File Offset: 0x00E59AA4
		public UniTask InitAreaSumMap()
		{
			MoraleAreaSumView.<InitAreaSumMap>d__17 <InitAreaSumMap>d__;
			<InitAreaSumMap>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAreaSumMap>d__.<>4__this = this;
			<InitAreaSumMap>d__.<>1__state = -1;
			<InitAreaSumMap>d__.<>t__builder.Start<MoraleAreaSumView.<InitAreaSumMap>d__17>(ref <InitAreaSumMap>d__);
			return <InitAreaSumMap>d__.<>t__builder.Task;
		}

		// Token: 0x06038B35 RID: 232245 RVA: 0x00E5B8E8 File Offset: 0x00E59AE8
		public UniTask InitEnterConfig()
		{
			MoraleAreaSumView.<InitEnterConfig>d__18 <InitEnterConfig>d__;
			<InitEnterConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitEnterConfig>d__.<>4__this = this;
			<InitEnterConfig>d__.<>1__state = -1;
			<InitEnterConfig>d__.<>t__builder.Start<MoraleAreaSumView.<InitEnterConfig>d__18>(ref <InitEnterConfig>d__);
			return <InitEnterConfig>d__.<>t__builder.Task;
		}

		// Token: 0x06038B36 RID: 232246 RVA: 0x00E5B92C File Offset: 0x00E59B2C
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<BP_MoraleEffectConfig_C> CreateEffectConfig(string resId)
		{
			MoraleAreaSumView.<CreateEffectConfig>d__19 <CreateEffectConfig>d__;
			<CreateEffectConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder<BP_MoraleEffectConfig_C>.Create();
			<CreateEffectConfig>d__.resId = resId;
			<CreateEffectConfig>d__.<>1__state = -1;
			<CreateEffectConfig>d__.<>t__builder.Start<MoraleAreaSumView.<CreateEffectConfig>d__19>(ref <CreateEffectConfig>d__);
			return <CreateEffectConfig>d__.<>t__builder.Task;
		}

		// Token: 0x06038B37 RID: 232247 RVA: 0x00E5B96F File Offset: 0x00E59B6F
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.MoraleProgressRewardUpdate, new Action(this.EventMoraleProgressRewardUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.EventOnActivitySequenceEmitEvent));
		}

		// Token: 0x06038B38 RID: 232248 RVA: 0x00E5B9A9 File Offset: 0x00E59BA9
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.MoraleProgressRewardUpdate, new Action(this.EventMoraleProgressRewardUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.EventOnActivitySequenceEmitEvent));
		}

		// Token: 0x06038B39 RID: 232249 RVA: 0x00E5B9E3 File Offset: 0x00E59BE3
		protected override void OnBeforeShow()
		{
			this.ResetLoopEffect();
			this.UpdateData();
		}

		// Token: 0x06038B3A RID: 232250 RVA: 0x00E5B9F4 File Offset: 0x00E59BF4
		private void ResetLoopEffect()
		{
			for (int i = 0; i < this.AreaMapPanelList.Count; i++)
			{
				MoraleSumAreaMapPanel moraleSumAreaMapPanel = this.AreaMapPanelList[i];
				for (int j = 0; j < moraleSumAreaMapPanel.AreaPlotPanel.PlotList.Count; j++)
				{
					MoraleTickPromise loopTickPromise = moraleSumAreaMapPanel.AreaPlotPanel.PlotList[j].LoopTickPromise;
					if (loopTickPromise != null)
					{
						loopTickPromise.Stop();
					}
				}
			}
		}

		// Token: 0x06038B3B RID: 232251 RVA: 0x00E5BA60 File Offset: 0x00E59C60
		protected override void OnAfterShow()
		{
			this.CheckPlayEnterEffect().Forget();
		}

		// Token: 0x06038B3C RID: 232252 RVA: 0x00E5BA6D File Offset: 0x00E59C6D
		protected override void OnAfterHide()
		{
			this.Model.ClearAllFlagNewUnlockState();
			this.Model.SaveLocalData();
		}

		// Token: 0x06038B3D RID: 232253 RVA: 0x00E5BA85 File Offset: 0x00E59C85
		public void UpdateData()
		{
			this.SumLvInfoPanel.UpdateData();
			this.ScoreProgressPanel.UpdateData();
		}

		// Token: 0x06038B3E RID: 232254 RVA: 0x00E5BA9D File Offset: 0x00E59C9D
		public bool IsMoraleGameOver(bool? active = null)
		{
			if (active.GetValueOrDefault())
			{
				return true;
			}
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			return ((uiViewSequence != null) ? uiViewSequence.StartSequenceName : null) == "Occupy" || this.Model.IsMoraleGameOver();
		}

		// Token: 0x06038B3F RID: 232255 RVA: 0x00E5BAD8 File Offset: 0x00E59CD8
		public UniTask CheckOccupyAllAreaState(bool? active = null)
		{
			MoraleAreaSumView.<CheckOccupyAllAreaState>d__28 <CheckOccupyAllAreaState>d__;
			<CheckOccupyAllAreaState>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckOccupyAllAreaState>d__.<>4__this = this;
			<CheckOccupyAllAreaState>d__.active = active;
			<CheckOccupyAllAreaState>d__.<>1__state = -1;
			<CheckOccupyAllAreaState>d__.<>t__builder.Start<MoraleAreaSumView.<CheckOccupyAllAreaState>d__28>(ref <CheckOccupyAllAreaState>d__);
			return <CheckOccupyAllAreaState>d__.<>t__builder.Task;
		}

		// Token: 0x06038B40 RID: 232256 RVA: 0x00E5BB24 File Offset: 0x00E59D24
		public void InitAreaSumMapData()
		{
			for (int i = 0; i < this.AreaMapPanelList.Count; i++)
			{
				this.AreaMapPanelList[i].InitData();
			}
		}

		// Token: 0x06038B41 RID: 232257 RVA: 0x00E5BB58 File Offset: 0x00E59D58
		private void EventMoraleProgressRewardUpdate()
		{
			this.ScoreProgressPanel.UpdateData();
		}

		// Token: 0x06038B42 RID: 232258 RVA: 0x00E5BB65 File Offset: 0x00E59D65
		private void OnBtnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038B43 RID: 232259 RVA: 0x00E5BB6E File Offset: 0x00E59D6E
		private void EventOnActivitySequenceEmitEvent(string name)
		{
			if (name == "Enter")
			{
				this.CheckPlayEnterEffect().Forget();
			}
		}

		// Token: 0x06038B44 RID: 232260 RVA: 0x00E5BB88 File Offset: 0x00E59D88
		private void OnBtnHelp()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(315);
		}

		// Token: 0x06038B45 RID: 232261 RVA: 0x00E5BB9C File Offset: 0x00E59D9C
		public UniTask CheckPlayEnterEffect()
		{
			MoraleAreaSumView.<CheckPlayEnterEffect>d__34 <CheckPlayEnterEffect>d__;
			<CheckPlayEnterEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckPlayEnterEffect>d__.<>4__this = this;
			<CheckPlayEnterEffect>d__.<>1__state = -1;
			<CheckPlayEnterEffect>d__.<>t__builder.Start<MoraleAreaSumView.<CheckPlayEnterEffect>d__34>(ref <CheckPlayEnterEffect>d__);
			return <CheckPlayEnterEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038B46 RID: 232262 RVA: 0x00E5BBE0 File Offset: 0x00E59DE0
		public UniTask PlayEnterEffect([Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<MoraleAreaPlotData> setEnterList = null, [Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<MoraleAreaPlotData> setNewUnlockList = null)
		{
			MoraleAreaSumView.<PlayEnterEffect>d__35 <PlayEnterEffect>d__;
			<PlayEnterEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayEnterEffect>d__.<>4__this = this;
			<PlayEnterEffect>d__.setEnterList = setEnterList;
			<PlayEnterEffect>d__.setNewUnlockList = setNewUnlockList;
			<PlayEnterEffect>d__.<>1__state = -1;
			<PlayEnterEffect>d__.<>t__builder.Start<MoraleAreaSumView.<PlayEnterEffect>d__35>(ref <PlayEnterEffect>d__);
			return <PlayEnterEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038B47 RID: 232263 RVA: 0x00E5BC33 File Offset: 0x00E59E33
		private static List<MoraleAreaPlotData> CombineLists(IReadOnlyList<MoraleAreaPlotData> a, IReadOnlyList<MoraleAreaPlotData> b)
		{
			List<MoraleAreaPlotData> list = new List<MoraleAreaPlotData>(a.Count + b.Count);
			list.AddRange(a);
			list.AddRange(b);
			return list;
		}

		// Token: 0x06038B48 RID: 232264 RVA: 0x00E5BC58 File Offset: 0x00E59E58
		[NullableContext(2)]
		public void TestPlayEnterEffectByFlag(int[] flagEnterList = null, int[] flagNewUnlockList = null)
		{
			if (this.IsPlayingEnterEffect)
			{
				return;
			}
			IReadOnlyList<MoraleAreaPlotData> idList = this.GetIdList(flagEnterList);
			IReadOnlyList<MoraleAreaPlotData> idList2 = this.GetIdList(flagNewUnlockList);
			this.InitAreaSumMapData();
			this.PlayEnterEffect(idList, idList2).Forget();
		}

		// Token: 0x06038B49 RID: 232265 RVA: 0x00E5BC94 File Offset: 0x00E59E94
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private IReadOnlyList<MoraleAreaPlotData> GetIdList(int[] flagList)
		{
			if (flagList == null)
			{
				return null;
			}
			List<MoraleAreaPlotData> list = new List<MoraleAreaPlotData>();
			foreach (int key in flagList)
			{
				MoraleAreaFlagData moraleAreaFlagData;
				if (this.Model.FlagMap.TryGetValue(key, out moraleAreaFlagData))
				{
					List<MoraleAreaPlotData> areaPlotDataList = moraleAreaFlagData.AreaPlotDataList;
					for (int j = 0; j < areaPlotDataList.Count; j++)
					{
						list.Add(areaPlotDataList[j]);
					}
				}
			}
			if (list.Count > 0)
			{
				MoraleAreaPlotData[] array = new MoraleAreaPlotData[list.Count];
				for (int k = 0; k < list.Count; k++)
				{
					array[k] = list[k];
				}
				MoraleAreaPlotData[] array2 = Singleton<MathUtils>.Instance.Shuffle<MoraleAreaPlotData>(array);
				for (int l = 0; l < array2.Length; l++)
				{
					list[l] = array2[l];
				}
			}
			return list;
		}

		// Token: 0x06038B4A RID: 232266 RVA: 0x00E5BD68 File Offset: 0x00E59F68
		public UniTask PlayAreaPanelEnterEffectTimes(int sumTimes, IReadOnlyList<MoraleAreaPlotData> plotList)
		{
			MoraleAreaSumView.<PlayAreaPanelEnterEffectTimes>d__39 <PlayAreaPanelEnterEffectTimes>d__;
			<PlayAreaPanelEnterEffectTimes>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAreaPanelEnterEffectTimes>d__.<>4__this = this;
			<PlayAreaPanelEnterEffectTimes>d__.sumTimes = sumTimes;
			<PlayAreaPanelEnterEffectTimes>d__.plotList = plotList;
			<PlayAreaPanelEnterEffectTimes>d__.<>1__state = -1;
			<PlayAreaPanelEnterEffectTimes>d__.<>t__builder.Start<MoraleAreaSumView.<PlayAreaPanelEnterEffectTimes>d__39>(ref <PlayAreaPanelEnterEffectTimes>d__);
			return <PlayAreaPanelEnterEffectTimes>d__.<>t__builder.Task;
		}

		// Token: 0x06038B4B RID: 232267 RVA: 0x00E5BDBC File Offset: 0x00E59FBC
		public UniTask PlayAreaPanelEnterEffect(IReadOnlyList<MoraleAreaPlotData> plotList, int? dealTime = null)
		{
			MoraleAreaSumView.<PlayAreaPanelEnterEffect>d__40 <PlayAreaPanelEnterEffect>d__;
			<PlayAreaPanelEnterEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAreaPanelEnterEffect>d__.<>4__this = this;
			<PlayAreaPanelEnterEffect>d__.plotList = plotList;
			<PlayAreaPanelEnterEffect>d__.dealTime = dealTime;
			<PlayAreaPanelEnterEffect>d__.<>1__state = -1;
			<PlayAreaPanelEnterEffect>d__.<>t__builder.Start<MoraleAreaSumView.<PlayAreaPanelEnterEffect>d__40>(ref <PlayAreaPanelEnterEffect>d__);
			return <PlayAreaPanelEnterEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038B4C RID: 232268 RVA: 0x00E5BE10 File Offset: 0x00E5A010
		public UniTask PlayAreaPanelLoopEffect(IReadOnlyList<MoraleAreaPlotData> plotList, int? dealTime = null)
		{
			MoraleAreaSumView.<PlayAreaPanelLoopEffect>d__41 <PlayAreaPanelLoopEffect>d__;
			<PlayAreaPanelLoopEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAreaPanelLoopEffect>d__.<>4__this = this;
			<PlayAreaPanelLoopEffect>d__.plotList = plotList;
			<PlayAreaPanelLoopEffect>d__.dealTime = dealTime;
			<PlayAreaPanelLoopEffect>d__.<>1__state = -1;
			<PlayAreaPanelLoopEffect>d__.<>t__builder.Start<MoraleAreaSumView.<PlayAreaPanelLoopEffect>d__41>(ref <PlayAreaPanelLoopEffect>d__);
			return <PlayAreaPanelLoopEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038B4D RID: 232269 RVA: 0x00E5BE64 File Offset: 0x00E5A064
		public UniTask PlayAreaPanelNewUnlockEffect(IReadOnlyList<MoraleAreaPlotData> plotList)
		{
			MoraleAreaSumView.<PlayAreaPanelNewUnlockEffect>d__42 <PlayAreaPanelNewUnlockEffect>d__;
			<PlayAreaPanelNewUnlockEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAreaPanelNewUnlockEffect>d__.<>4__this = this;
			<PlayAreaPanelNewUnlockEffect>d__.plotList = plotList;
			<PlayAreaPanelNewUnlockEffect>d__.<>1__state = -1;
			<PlayAreaPanelNewUnlockEffect>d__.<>t__builder.Start<MoraleAreaSumView.<PlayAreaPanelNewUnlockEffect>d__42>(ref <PlayAreaPanelNewUnlockEffect>d__);
			return <PlayAreaPanelNewUnlockEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038B4E RID: 232270 RVA: 0x00E5BEB0 File Offset: 0x00E5A0B0
		public UniTask PlayHighMonsterKillEffect()
		{
			MoraleAreaSumView.<PlayHighMonsterKillEffect>d__43 <PlayHighMonsterKillEffect>d__;
			<PlayHighMonsterKillEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayHighMonsterKillEffect>d__.<>4__this = this;
			<PlayHighMonsterKillEffect>d__.<>1__state = -1;
			<PlayHighMonsterKillEffect>d__.<>t__builder.Start<MoraleAreaSumView.<PlayHighMonsterKillEffect>d__43>(ref <PlayHighMonsterKillEffect>d__);
			return <PlayHighMonsterKillEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038B4F RID: 232271 RVA: 0x00E5BEF4 File Offset: 0x00E5A0F4
		private UniTask AwaitTime(float waitTime)
		{
			MoraleAreaSumView.<AwaitTime>d__44 <AwaitTime>d__;
			<AwaitTime>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AwaitTime>d__.<>4__this = this;
			<AwaitTime>d__.waitTime = waitTime;
			<AwaitTime>d__.<>1__state = -1;
			<AwaitTime>d__.<>t__builder.Start<MoraleAreaSumView.<AwaitTime>d__44>(ref <AwaitTime>d__);
			return <AwaitTime>d__.<>t__builder.Task;
		}

		// Token: 0x06038B50 RID: 232272 RVA: 0x00E5BF3F File Offset: 0x00E5A13F
		protected override void OnTick(float delta)
		{
			this.TickAreaMapPanel(delta);
		}

		// Token: 0x06038B51 RID: 232273 RVA: 0x00E5BF48 File Offset: 0x00E5A148
		public void TickAreaMapPanel(float delta)
		{
			for (int i = 0; i < this.AreaMapPanelList.Count; i++)
			{
				this.AreaMapPanelList[i].OnTick(delta);
			}
		}

		// Token: 0x06038B52 RID: 232274 RVA: 0x00E5BF80 File Offset: 0x00E5A180
		public UniTask CheckExistAreaActiveLight()
		{
			MoraleAreaSumView.<CheckExistAreaActiveLight>d__47 <CheckExistAreaActiveLight>d__;
			<CheckExistAreaActiveLight>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckExistAreaActiveLight>d__.<>4__this = this;
			<CheckExistAreaActiveLight>d__.<>1__state = -1;
			<CheckExistAreaActiveLight>d__.<>t__builder.Start<MoraleAreaSumView.<CheckExistAreaActiveLight>d__47>(ref <CheckExistAreaActiveLight>d__);
			return <CheckExistAreaActiveLight>d__.<>t__builder.Task;
		}

		// Token: 0x06038B53 RID: 232275 RVA: 0x00E5BFC4 File Offset: 0x00E5A1C4
		public UniTask CheckNextHighMonsterArea()
		{
			MoraleAreaSumView.<CheckNextHighMonsterArea>d__48 <CheckNextHighMonsterArea>d__;
			<CheckNextHighMonsterArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckNextHighMonsterArea>d__.<>4__this = this;
			<CheckNextHighMonsterArea>d__.<>1__state = -1;
			<CheckNextHighMonsterArea>d__.<>t__builder.Start<MoraleAreaSumView.<CheckNextHighMonsterArea>d__48>(ref <CheckNextHighMonsterArea>d__);
			return <CheckNextHighMonsterArea>d__.<>t__builder.Task;
		}

		// Token: 0x06038B54 RID: 232276 RVA: 0x00E5C008 File Offset: 0x00E5A208
		public void StopLoopEffect()
		{
			for (int i = 0; i < this.AreaMapPanelList.Count; i++)
			{
				MoraleSumAreaMapPanel moraleSumAreaMapPanel = this.AreaMapPanelList[i];
				for (int j = 0; j < moraleSumAreaMapPanel.AreaPlotPanel.PlotList.Count; j++)
				{
					MoraleTickPromise loopTickPromise = moraleSumAreaMapPanel.AreaPlotPanel.PlotList[j].LoopTickPromise;
					if (loopTickPromise != null)
					{
						loopTickPromise.Stop();
					}
				}
			}
		}

		// Token: 0x06038B55 RID: 232277 RVA: 0x00E5C074 File Offset: 0x00E5A274
		private void PlayLoopEffect(IReadOnlyList<MoraleAreaPlotData> setLoopList)
		{
			if (setLoopList.Count <= 0)
			{
				return;
			}
			this.StopLoopEffect();
			int sumTimes = Math.Min(setLoopList.Count, this.LoopConfig.格子入场批次);
			this.LoopFlagNum++;
			this.PlayAreaPanelLoopEffectTimes(sumTimes, setLoopList, this.LoopFlagNum).Forget();
		}

		// Token: 0x06038B56 RID: 232278 RVA: 0x00E5C0CC File Offset: 0x00E5A2CC
		private UniTask PlayAreaPanelLoopEffectTimes(int sumTimes, IReadOnlyList<MoraleAreaPlotData> plotList, int flagNum)
		{
			MoraleAreaSumView.<PlayAreaPanelLoopEffectTimes>d__51 <PlayAreaPanelLoopEffectTimes>d__;
			<PlayAreaPanelLoopEffectTimes>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAreaPanelLoopEffectTimes>d__.<>4__this = this;
			<PlayAreaPanelLoopEffectTimes>d__.sumTimes = sumTimes;
			<PlayAreaPanelLoopEffectTimes>d__.plotList = plotList;
			<PlayAreaPanelLoopEffectTimes>d__.flagNum = flagNum;
			<PlayAreaPanelLoopEffectTimes>d__.<>1__state = -1;
			<PlayAreaPanelLoopEffectTimes>d__.<>t__builder.Start<MoraleAreaSumView.<PlayAreaPanelLoopEffectTimes>d__51>(ref <PlayAreaPanelLoopEffectTimes>d__);
			return <PlayAreaPanelLoopEffectTimes>d__.<>t__builder.Task;
		}

		// Token: 0x06038B57 RID: 232279 RVA: 0x00E5C127 File Offset: 0x00E5A327
		protected override void OnAfterDestroy()
		{
			this.Model.UiEnterConfig = null;
			this.Model.UiLoopConfig = null;
		}

		// Token: 0x06038B58 RID: 232280 RVA: 0x00E5C144 File Offset: 0x00E5A344
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx([Nullable(new byte[]
		{
			2,
			1
		})] string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "FirstFinishedArea")
			{
				for (int i = 0; i < this.AreaMapPanelList.Count; i++)
				{
					MoraleSumAreaMapPanel moraleSumAreaMapPanel = this.AreaMapPanelList[i];
					if (moraleSumAreaMapPanel.AreaTitle.IsShowBoxProgress())
					{
						UUIItem guideUiItem = moraleSumAreaMapPanel.AreaTitle.GetGuideUiItem("0");
						if (guideUiItem != null)
						{
							return new UUIItem[]
							{
								guideUiItem,
								guideUiItem
							};
						}
					}
				}
			}
			if (a == "FirstFinishedAreaBox")
			{
				int j = 0;
				while (j < this.AreaMapPanelList.Count)
				{
					MoraleSumAreaMapPanel moraleSumAreaMapPanel2 = this.AreaMapPanelList[j];
					MoraleSumAreaTitleItem areaTitle = moraleSumAreaMapPanel2.AreaTitle;
					if (areaTitle != null && areaTitle.IsShowBoxProgress())
					{
						MoraleSumAreaTitleItem areaTitle2 = moraleSumAreaMapPanel2.AreaTitle;
						if (areaTitle2 == null)
						{
							return null;
						}
						return areaTitle2.GetGuideUiItemAndUiItemForShowEx(configParams);
					}
					else
					{
						j++;
					}
				}
			}
			if (a == "FirstMoraleArea")
			{
				UUIItem guideUiItem2 = base.GetGuideUiItem("1");
				UUIItem rootItem = this.AreaMapPanelList[0].GetRootItem();
				if (guideUiItem2 != null && rootItem != null)
				{
					return new UUIItem[]
					{
						rootItem,
						guideUiItem2
					};
				}
			}
			return null;
		}

		// Token: 0x04020525 RID: 132389
		public PopupCaptionItem PopupCaption;

		// Token: 0x04020526 RID: 132390
		public MoraleSumLvInfoPanel SumLvInfoPanel;

		// Token: 0x04020527 RID: 132391
		public MoraleScoreProgressPanel ScoreProgressPanel;

		// Token: 0x04020528 RID: 132392
		public MoraleModel Model;

		// Token: 0x04020529 RID: 132393
		public readonly List<MoraleSumAreaMapPanel> AreaMapPanelList = new List<MoraleSumAreaMapPanel>();

		// Token: 0x0402052A RID: 132394
		public BP_MoraleEffectConfig_C EnterConfig;

		// Token: 0x0402052B RID: 132395
		public BP_MoraleEffectConfig_C LoopConfig;

		// Token: 0x0402052C RID: 132396
		public bool IsPlayingEnterEffect;

		// Token: 0x0402052D RID: 132397
		public bool IsPlayedEnterEffect;

		// Token: 0x0402052E RID: 132398
		public int LoopFlagNum;

		// Token: 0x0402052F RID: 132399
		public MoraleHighMonsterProgressPanel HighMonsterProgressPanel;

		// Token: 0x0200B78F RID: 46991
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038C5C RID: 232540
			public const int ItemCaption = 0;

			// Token: 0x04038C5D RID: 232541
			public const int ItemArea1Panel = 1;

			// Token: 0x04038C5E RID: 232542
			public const int ItemArea2Panel = 2;

			// Token: 0x04038C5F RID: 232543
			public const int ItemArea3Panel = 3;

			// Token: 0x04038C60 RID: 232544
			public const int ItemArea4Panel = 4;

			// Token: 0x04038C61 RID: 232545
			public const int ItemArea5Panel = 5;

			// Token: 0x04038C62 RID: 232546
			public const int ItemLevelInfoPanel = 6;

			// Token: 0x04038C63 RID: 232547
			public const int ItemScoreProgressPanel = 7;

			// Token: 0x04038C64 RID: 232548
			public const int ItemOccupyComplete = 8;

			// Token: 0x04038C65 RID: 232549
			public const int TextureMapBg = 9;

			// Token: 0x04038C66 RID: 232550
			public const int TextureMapLightBg = 10;

			// Token: 0x04038C67 RID: 232551
			public const int ItemHighMonsterProgress = 11;
		}
	}
}
