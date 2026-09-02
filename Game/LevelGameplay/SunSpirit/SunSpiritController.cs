using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.NPC.GPUNPC.BP.CrowdAi;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritPerform;
using CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritState;
using CSharpScript.Game.LevelGamePlay.SunSpirit.View;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit
{
	// Token: 0x02006A9B RID: 27291
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class SunSpiritController : ControllerBase<SunSpiritController>
	{
		// Token: 0x1700A272 RID: 41586
		// (get) Token: 0x060437CD RID: 276429 RVA: 0x01163844 File Offset: 0x01161A44
		private bool IsInDebugMode
		{
			get
			{
				SundryModel instance = ModelBase<SundryModel>.Instance;
				if (instance == null)
				{
					return false;
				}
				instance.GetModuleDebugLevel("SunSpirit");
				return true;
			}
		}

		// Token: 0x060437CE RID: 276430 RVA: 0x01163860 File Offset: 0x01161A60
		protected override bool OnInit()
		{
			Singleton<Net>.Instance.Register<SunSpiritListNotify>(ENotifyMessageId.SunSpiritListNotify, new Action<SunSpiritListNotify, Net.CallbackStatus>(this.OnSunSpiritListNotify));
			Singleton<Net>.Instance.Register<SunSpiritCollectNotify>(ENotifyMessageId.SunSpiritCollectNotify, new Action<SunSpiritCollectNotify, Net.CallbackStatus>(this.OnSunSpiritCollectNotify));
			Singleton<Net>.Instance.Register<SunSpiritUpdateNotify>(ENotifyMessageId.SunSpiritUpdateNotify, new Action<SunSpiritUpdateNotify, Net.CallbackStatus>(this.OnSunSpiritUpdateNotify));
			Singleton<Net>.Instance.Register<SunSpiritActionOperationNotify>(ENotifyMessageId.SunSpiritActionOperationNotify, new Action<SunSpiritActionOperationNotify, Net.CallbackStatus>(this.OnSunSpiritActionOperationNotify));
			if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				SundryModel instance = ModelBase<SundryModel>.Instance;
				if (instance != null)
				{
					instance.ChangeModuleDebugLevel("SunSpirit", 1);
				}
			}
			if (!Singleton<EventSystem>.Instance.Has(EEventName.WorldDone, new Action(this.OnWorldDone)))
			{
				Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			}
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			return true;
		}

		// Token: 0x060437CF RID: 276431 RVA: 0x01163958 File Offset: 0x01161B58
		private void OnWorldDone()
		{
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			int? num = (instance != null) ? new int?(instance.GetPlayerId()) : null;
			if (num == null)
			{
				return;
			}
			WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(num.Value);
			BaseTagComponent baseTagComponent = (playerEntity != null) ? playerEntity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent == null)
			{
				return;
			}
			foreach (int value in this.ENABLE_TAGS)
			{
				ITagTask tagTask = baseTagComponent.ListenForTagAddOrRemove(new int?(value), new BaseTagComponent.TTagSwitchedCallback(this.OnEnableTagAddOrRemove), null);
				if (tagTask != null)
				{
					this.TagListeners.Add(tagTask);
				}
			}
			this.UpdateSunSpiritEnable();
		}

		// Token: 0x060437D0 RID: 276432 RVA: 0x01163A04 File Offset: 0x01161C04
		private void OnSunSpiritEnableUpdate()
		{
			bool newEnable = ModelBase<SunSpiritModel>.Instance.GetIsSunSpiritEnable();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SunSpirit;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "日灵系统开启状态更新";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("NewEnable", newEnable);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (newEnable)
			{
				ModelBase<SunSpiritModel>.Instance.LoadAndInitSunSpiritConfig(false, delegate(bool success)
				{
					if (success)
					{
						SunSpiritModel instance3 = ModelBase<SunSpiritModel>.Instance;
						BP_CrowdAiConfig_C bp_CrowdAiConfig_C = (instance3 != null) ? instance3.GetSunSpiritConfig().CrowdAiConfig : null;
						if (bp_CrowdAiConfig_C == null)
						{
							Singleton<Log>.Instance.Error(ELogModule.SunSpirit, ELogAuthor.ZYL, "日灵: 集群启用失败，日灵集群配置获取不到", default(ReadOnlySpan<ValueTuple<string, object>>));
							ControllerBase<CrowdAiController>.Instance.EnableCrowdAiSystemByConfigPath(null);
						}
						else
						{
							ControllerBase<CrowdAiController>.Instance.EnableCrowdAiSystemByConfigAsset(bp_CrowdAiConfig_C);
						}
						this.RefreshSunSpiritsStateFromCachedProto(true);
						this.TryOpenHintView();
						Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnSunSpiritEnableUpdated, newEnable);
						return;
					}
					Singleton<Log>.Instance.Warn(ELogModule.SunSpirit, ELogAuthor.ZYL, "日灵系统开启失败，加载并初始化SunSpiritConfig时被中断", default(ReadOnlySpan<ValueTuple<string, object>>));
				});
				return;
			}
			ControllerBase<CrowdAiController>.Instance.DisableCrowdAiSystem(false);
			SunSpiritModel instance2 = ModelBase<SunSpiritModel>.Instance;
			if (instance2 != null)
			{
				instance2.ClearAndReleaseSunSpiritConfig();
			}
			this.RefreshSunSpiritsStateFromCachedProto(true);
			this.TryCloseHintView();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnSunSpiritEnableUpdated, newEnable);
		}

		// Token: 0x060437D1 RID: 276433 RVA: 0x01163AC0 File Offset: 0x01161CC0
		private void TryOpenHintView()
		{
			if (this.SunSpiritHintView == null)
			{
				this.SunSpiritHintView = new SunSpiritHintView();
				this.SunSpiritHintView.CreateByResourceIdAsync("UiItem_LaHaiLuoRiLing", Singleton<UiLayer>.Instance.GetBattleViewUnit(1), false);
			}
			if (this.SunSpiritLauncherHintView == null)
			{
				this.SunSpiritLauncherHintView = new SunSpiritLauncherHintView();
				this.SunSpiritLauncherHintView.CreateByResourceIdAsync("UiItem_LaHaiLuoRiLing", Singleton<UiLayer>.Instance.GetBattleViewUnit(1), false);
			}
		}

		// Token: 0x060437D2 RID: 276434 RVA: 0x01163B2D File Offset: 0x01161D2D
		private void TryCloseHintView()
		{
			if (this.SunSpiritHintView != null)
			{
				this.SunSpiritHintView.Destroy(null);
				this.SunSpiritHintView = null;
			}
			if (this.SunSpiritLauncherHintView != null)
			{
				this.SunSpiritLauncherHintView.Destroy(null);
				this.SunSpiritLauncherHintView = null;
			}
		}

		// Token: 0x060437D3 RID: 276435 RVA: 0x01163B68 File Offset: 0x01161D68
		private void UpdateSunSpiritEnable()
		{
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			int? num = (instance != null) ? new int?(instance.GetPlayerId()) : null;
			if (num == null)
			{
				return;
			}
			bool flag = false;
			foreach (int tagId in this.ENABLE_TAGS)
			{
				flag = (flag || ControllerBase<FormationDataController>.Instance.HasPlayerTag(num.Value, tagId, true));
				if (flag)
				{
					break;
				}
			}
			this.SetSunSpiritEnable(flag);
		}

		// Token: 0x060437D4 RID: 276436 RVA: 0x01163BE4 File Offset: 0x01161DE4
		public void SetSunSpiritEnable(bool targetEnable)
		{
			bool isSunSpiritEnable = ModelBase<SunSpiritModel>.Instance.GetIsSunSpiritEnable();
			if (isSunSpiritEnable != targetEnable)
			{
				ModelBase<SunSpiritModel>.Instance.SetIsSunSpiritEnable(targetEnable);
			}
			bool isSunSpiritEnable2 = ModelBase<SunSpiritModel>.Instance.GetIsSunSpiritEnable();
			if (isSunSpiritEnable != isSunSpiritEnable2)
			{
				this.OnSunSpiritEnableUpdate();
			}
		}

		// Token: 0x060437D5 RID: 276437 RVA: 0x01163C20 File Offset: 0x01161E20
		public void SetGmOverrideSunSpiritEnable(bool bIsEnable)
		{
			bool isSunSpiritEnable = ModelBase<SunSpiritModel>.Instance.GetIsSunSpiritEnable();
			ModelBase<SunSpiritModel>.Instance.GmOverrideIsSunSpiritEnable = bIsEnable;
			ModelBase<SunSpiritModel>.Instance.IsUsingGmOverrideSunSpiritEnable = true;
			bool isSunSpiritEnable2 = ModelBase<SunSpiritModel>.Instance.GetIsSunSpiritEnable();
			if (isSunSpiritEnable != isSunSpiritEnable2)
			{
				this.OnSunSpiritEnableUpdate();
			}
		}

		// Token: 0x060437D6 RID: 276438 RVA: 0x01163C64 File Offset: 0x01161E64
		public void ClearGmOverrideSunSpiritEnable()
		{
			bool isSunSpiritEnable = ModelBase<SunSpiritModel>.Instance.GetIsSunSpiritEnable();
			ModelBase<SunSpiritModel>.Instance.GmOverrideIsSunSpiritEnable = false;
			ModelBase<SunSpiritModel>.Instance.IsUsingGmOverrideSunSpiritEnable = false;
			bool isSunSpiritEnable2 = ModelBase<SunSpiritModel>.Instance.GetIsSunSpiritEnable();
			if (isSunSpiritEnable != isSunSpiritEnable2)
			{
				this.OnSunSpiritEnableUpdate();
			}
		}

		// Token: 0x060437D7 RID: 276439 RVA: 0x01163CA8 File Offset: 0x01161EA8
		private void RefreshSunSpiritsStateFromCachedProto(bool bDoIfSameState)
		{
			this.TempSunSpiritList.Clear();
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			if (instance != null)
			{
				CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
				int playerId = (instance2 != null) ? instance2.GetPlayerId() : 0;
				AreaModel instance3 = ModelBase<AreaModel>.Instance;
				Area? area;
				instance.GetAllSunSpiritDataByPlayerIdAndAreaId(playerId, ((instance3 != null) ? ((instance3.AreaInfo != null) ? new int?(area.GetValueOrDefault().AreaId) : null) : null).GetValueOrDefault(), true, null, this.TempSunSpiritList);
			}
			foreach (SunSpiritData sunSpiritData in this.TempSunSpiritList)
			{
				sunSpiritData.RefreshSunSpiritStateByCachedProto(bDoIfSameState);
			}
			this.TempSunSpiritList.Clear();
		}

		// Token: 0x060437D8 RID: 276440 RVA: 0x01163D84 File Offset: 0x01161F84
		private void OnEnableTagAddOrRemove(int tagId, bool tagExist)
		{
			this.UpdateSunSpiritEnable();
		}

		// Token: 0x060437D9 RID: 276441 RVA: 0x01163D8C File Offset: 0x01161F8C
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SunSpiritListNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SunSpiritCollectNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SunSpiritUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SunSpiritActionOperationNotify);
			this.TryCloseHintView();
			this.TempSunSpiritList.Clear();
			if (Singleton<EventSystem>.Instance.Has(EEventName.WorldDone, new Action(this.OnWorldDone)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			}
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			foreach (ITagTask tagTask in this.TagListeners)
			{
				tagTask.EndTask();
			}
			this.TagListeners.Clear();
			return true;
		}

		// Token: 0x060437DA RID: 276442 RVA: 0x01163E90 File Offset: 0x01162090
		protected override void OnTick(float delta)
		{
			this.TickSunSpirits((double)delta);
			this.TickView(delta);
		}

		// Token: 0x060437DB RID: 276443 RVA: 0x01163EA1 File Offset: 0x011620A1
		private void TickView(float delta)
		{
			if (this.SunSpiritHintView != null)
			{
				this.SunSpiritHintView.Tick(delta);
			}
			if (this.SunSpiritLauncherHintView != null)
			{
				this.SunSpiritLauncherHintView.Tick((double)delta);
			}
		}

		// Token: 0x060437DC RID: 276444 RVA: 0x01163ECC File Offset: 0x011620CC
		private void TickSunSpirits(double delta)
		{
			this.DeltaFromLastTick += delta;
			if (this.DeltaFromLastTick < 33.0)
			{
				return;
			}
			float deltaSeconds = (float)(this.DeltaFromLastTick * 0.0010000000474974513);
			this.DeltaFromLastTick = 0.0;
			this.TempSunSpiritList.Clear();
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			if (instance != null)
			{
				CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
				int playerId = (instance2 != null) ? instance2.GetPlayerId() : 0;
				AreaModel instance3 = ModelBase<AreaModel>.Instance;
				Area? area;
				instance.GetAllSunSpiritDataByPlayerIdAndAreaId(playerId, ((instance3 != null) ? ((instance3.AreaInfo != null) ? new int?(area.GetValueOrDefault().AreaId) : null) : null).GetValueOrDefault(), true, null, this.TempSunSpiritList);
			}
			foreach (SunSpiritData sunSpiritData in this.TempSunSpiritList)
			{
				sunSpiritData.TickState(deltaSeconds);
			}
			this.TempSunSpiritList.Clear();
		}

		// Token: 0x060437DD RID: 276445 RVA: 0x01163FEC File Offset: 0x011621EC
		[NullableContext(2)]
		private void OnSunSpiritListNotify(SunSpiritListNotify data, Net.CallbackStatus status = null)
		{
			if (this.IsInDebugMode)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SunSpirit;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "日灵: 列表初始化";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SpiritConfigs", data.SpiritInfo);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				Singleton<Log>.Instance.Info(ELogModule.SunSpirit, ELogAuthor.ZYL, "日灵: 列表初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			foreach (SunSpiritPb sunSpiritPb in data.SpiritInfo)
			{
				SunSpiritModel instance2 = ModelBase<SunSpiritModel>.Instance;
				if (instance2 != null)
				{
					instance2.AddOrUpdateSunSpiritDataByPb(sunSpiritPb, true);
				}
			}
		}

		// Token: 0x060437DE RID: 276446 RVA: 0x0116409C File Offset: 0x0116229C
		[NullableContext(2)]
		private void OnSunSpiritCollectNotify(SunSpiritCollectNotify data, Net.CallbackStatus status)
		{
			SunSpiritPb spiritInfo = data.SpiritInfo;
			if (spiritInfo == null)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SunSpirit;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "日灵: 收集";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SpiritConfigId", spiritInfo.EntityConfigId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			SunSpiritModel instance2 = ModelBase<SunSpiritModel>.Instance;
			if (instance2 == null)
			{
				return;
			}
			instance2.AddOrUpdateSunSpiritDataByPb(spiritInfo, true);
		}

		// Token: 0x060437DF RID: 276447 RVA: 0x011640FC File Offset: 0x011622FC
		[NullableContext(2)]
		private void OnSunSpiritUpdateNotify(SunSpiritUpdateNotify data, Net.CallbackStatus status)
		{
			if (this.IsInDebugMode)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SunSpirit;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "日灵: 列表更新";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SpiritConfigs", data.SpiritInfo);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				Singleton<Log>.Instance.Info(ELogModule.SunSpirit, ELogAuthor.ZYL, "日灵: 列表更新", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			foreach (SunSpiritPb sunSpiritPb in data.SpiritInfo)
			{
				SunSpiritModel instance2 = ModelBase<SunSpiritModel>.Instance;
				if (instance2 != null)
				{
					instance2.AddOrUpdateSunSpiritDataByPb(sunSpiritPb, true);
				}
			}
		}

		// Token: 0x060437E0 RID: 276448 RVA: 0x011641AC File Offset: 0x011623AC
		public void OnEntityInitSetSunSpirit(IEnumerable<SunSpiritPb> data)
		{
			if (this.IsInDebugMode)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SunSpirit;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "日灵: 列表更新(实体添加)";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SpiritConfigs", data);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				Singleton<Log>.Instance.Info(ELogModule.SunSpirit, ELogAuthor.ZYL, "日灵: 列表更新(实体添加)", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			foreach (SunSpiritPb sunSpiritPb in data)
			{
				SunSpiritModel instance2 = ModelBase<SunSpiritModel>.Instance;
				if (instance2 != null)
				{
					instance2.AddOrUpdateSunSpiritDataByPb(sunSpiritPb, true);
				}
			}
		}

		// Token: 0x060437E1 RID: 276449 RVA: 0x01164254 File Offset: 0x01162454
		[NullableContext(2)]
		private unsafe void OnSunSpiritActionOperationNotify(SunSpiritActionOperationNotify data, Net.CallbackStatus status)
		{
			if (this.IsInDebugMode)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SunSpirit;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "日灵: 执行操作";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RelatedSceneItemId", data.EntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("OperationType", data.OperationType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SpiritConfigs", data.TakeUpInfo);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SunSpirit;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "日灵: 执行操作";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("OperationType", data.OperationType);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.ActiveActionOperationNotifyHandlerMap[data] = new HashSet<SunSpiritPb>(data.TakeUpInfo);
			SunSpiritOperationType operationType = data.OperationType;
			if (operationType == SunSpiritOperationType.Fly)
			{
				this.HandleSunSpiritActionOperationNotifyFly(data);
				return;
			}
			if (operationType != SunSpiritOperationType.Back)
			{
				return;
			}
			this.HandleSunSpiritActionOperationNotifyBack(data);
		}

		// Token: 0x060437E2 RID: 276450 RVA: 0x01164360 File Offset: 0x01162560
		private void HandleSunSpiritActionOperationNotifyFly(SunSpiritActionOperationNotify notify)
		{
			SunSpiritController.<>c__DisplayClass30_0 CS$<>8__locals1 = new SunSpiritController.<>c__DisplayClass30_0();
			CS$<>8__locals1.notify = notify;
			CS$<>8__locals1.<>4__this = this;
			if (CS$<>8__locals1.notify.OperationType != SunSpiritOperationType.Fly)
			{
				return;
			}
			SunSpiritController.<>c__DisplayClass30_0 CS$<>8__locals2 = CS$<>8__locals1;
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			CS$<>8__locals2.config = ((instance != null) ? instance.GetSunSpiritConfig() : null);
			if (CS$<>8__locals1.config == null)
			{
				return;
			}
			CS$<>8__locals1.gearConfigIds = new List<int>();
			SunSpiritPb sunSpiritPb;
			using (IEnumerator<SunSpiritPb> enumerator = CS$<>8__locals1.notify.TakeUpInfo.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					sunSpiritPb = enumerator.Current;
					SunSpiritTakeUpPb takeUpData = sunSpiritPb.TakeUpData;
					int? num = (takeUpData != null) ? new int?(takeUpData.TrapEntityConfigId) : null;
					if (num != null)
					{
						CS$<>8__locals1.gearConfigIds.Add(num.Value);
					}
					SunSpiritModel instance2 = ModelBase<SunSpiritModel>.Instance;
					if (instance2 != null)
					{
						instance2.AddOrUpdateSunSpiritDataByPb(sunSpiritPb, false);
					}
				}
			}
			WaitEntityTask.CreateWithPbDataId("HandleSunSpiritActionOperationNotifyFly", CS$<>8__locals1.gearConfigIds, delegate(bool? r)
			{
				float flyingDuration2 = CS$<>8__locals1.config.FlyFromPlayerToGearDefaultDuration;
				CreatureModel instance3 = ModelBase<CreatureModel>.Instance;
				EntityHandle entityHandle = (instance3 != null) ? instance3.GetEntityByPbDataId(CS$<>8__locals1.gearConfigIds[0]) : null;
				global::Vector vector = global::Vector.Create();
				bool flag = false;
				if (entityHandle != null && entityHandle.Valid)
				{
					WorldEntity entity = entityHandle.Entity;
					bool flag2;
					if (entity == null)
					{
						flag2 = false;
					}
					else
					{
						SceneItemSunSpiritGearComponent component = entity.GetComponent<SceneItemSunSpiritGearComponent>();
						flag2 = ((component != null) ? new bool?(component.GetSunSpiritSocketLocAndRot(0, vector, null)) : null).GetValueOrDefault();
					}
					flag = flag2;
				}
				if (flag)
				{
					TsBaseCharacter baseCharacter = Global.BaseCharacter;
					global::Vector vector2;
					if (baseCharacter == null)
					{
						vector2 = null;
					}
					else
					{
						CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
						vector2 = ((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null);
					}
					global::Vector vector3 = vector2;
					if (vector3 != null)
					{
						float num2 = (float)global::Vector.Dist(vector, vector3);
						float flyFromPlayerToGearSpeedForCalc = CS$<>8__locals1.config.FlyFromPlayerToGearSpeedForCalc;
						if (flyFromPlayerToGearSpeedForCalc > 0f)
						{
							flyingDuration2 = num2 / flyFromPlayerToGearSpeedForCalc;
						}
					}
				}
				float flyingDuration = flyingDuration2;
				Dictionary<int, List<SunSpiritPb>> dictionary = new Dictionary<int, List<SunSpiritPb>>();
				List<SunSpiritPb> list = new List<SunSpiritPb>();
				foreach (SunSpiritPb sunSpiritPb2 in CS$<>8__locals1.notify.TakeUpInfo)
				{
					if (sunSpiritPb2.TakeUpData == null)
					{
						list.Add(sunSpiritPb2);
					}
					else
					{
						int trapEntityConfigId = sunSpiritPb2.TakeUpData.TrapEntityConfigId;
						List<SunSpiritPb> list2;
						if (!dictionary.TryGetValue(trapEntityConfigId, out list2))
						{
							list2 = new List<SunSpiritPb>();
							dictionary[trapEntityConfigId] = list2;
						}
						list2.Add(sunSpiritPb2);
					}
				}
				foreach (List<SunSpiritPb> list3 in dictionary.Values)
				{
					Comparison<SunSpiritPb> comparison;
					if ((comparison = CS$<>8__locals1.<>9__1) == null)
					{
						comparison = (CS$<>8__locals1.<>9__1 = delegate(SunSpiritPb a, SunSpiritPb b)
						{
							if (!CS$<>8__locals1.config.FlyFromPlayerToGearInOrderFromMinToMax)
							{
								return b.TakeUpData.Index - a.TakeUpData.Index;
							}
							return a.TakeUpData.Index - b.TakeUpData.Index;
						});
					}
					list3.Sort(comparison);
				}
				float num3 = CS$<>8__locals1.config.FlyFromPlayerToGearDelayInterval * 1000f;
				float waitBeforeFlyingDuration = CS$<>8__locals1.config.FlyFromPlayerToGearWaitTimeBeforeFly;
				foreach (List<SunSpiritPb> list4 in dictionary.Values)
				{
					float num4 = 0f;
					using (List<SunSpiritPb>.Enumerator enumerator4 = list4.GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							SunSpiritPb sunSpiritPb = enumerator4.Current;
							if (num4 < 20f)
							{
								CS$<>8__locals1.<>4__this.HandleSunSpiritFlyFromPlayerToGear(CS$<>8__locals1.notify, sunSpiritPb, waitBeforeFlyingDuration, flyingDuration);
							}
							else
							{
								TimerSystem.Instance.Delay(delegate(float _)
								{
									CS$<>8__locals1.<>4__this.HandleSunSpiritFlyFromPlayerToGear(CS$<>8__locals1.notify, sunSpiritPb, waitBeforeFlyingDuration, flyingDuration);
								}, Math.Min(num4, 180000f), null, null, true, 1f);
							}
							num4 += num3;
						}
					}
				}
				foreach (SunSpiritPb singleSunSpiritPb in list)
				{
					CS$<>8__locals1.<>4__this.HandleSunSpiritFlyFromPlayerToGear(CS$<>8__locals1.notify, singleSunSpiritPb, waitBeforeFlyingDuration, flyingDuration);
				}
			}, 60000, true, false);
		}

		// Token: 0x060437E3 RID: 276451 RVA: 0x0116446C File Offset: 0x0116266C
		private void HandleSunSpiritActionOperationNotifyBack(SunSpiritActionOperationNotify notify)
		{
			SunSpiritController.<>c__DisplayClass31_0 CS$<>8__locals1 = new SunSpiritController.<>c__DisplayClass31_0();
			CS$<>8__locals1.notify = notify;
			CS$<>8__locals1.<>4__this = this;
			if (CS$<>8__locals1.notify.OperationType != SunSpiritOperationType.Back)
			{
				return;
			}
			SunSpiritController.<>c__DisplayClass31_0 CS$<>8__locals2 = CS$<>8__locals1;
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			CS$<>8__locals2.config = ((instance != null) ? instance.GetSunSpiritConfig() : null);
			if (CS$<>8__locals1.config == null)
			{
				return;
			}
			CS$<>8__locals1.gearConfigIds = new List<int>();
			SunSpiritPb sunSpiritPb;
			using (IEnumerator<SunSpiritPb> enumerator = CS$<>8__locals1.notify.TakeUpInfo.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					sunSpiritPb = enumerator.Current;
					SunSpiritTakeUpPb takeUpData = sunSpiritPb.TakeUpData;
					int? num = (takeUpData != null) ? new int?(takeUpData.TrapEntityConfigId) : null;
					if (num != null)
					{
						CS$<>8__locals1.gearConfigIds.Add(num.Value);
					}
				}
			}
			WaitEntityTask.CreateWithPbDataId("HandleSunSpiritActionOperationNotifyBack", CS$<>8__locals1.gearConfigIds, delegate(bool? r)
			{
				float flyingDuration2 = CS$<>8__locals1.config.FlyFromGearToPlayerDefaultDuration;
				CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
				EntityHandle entityHandle = (instance2 != null) ? instance2.GetEntityByPbDataId(CS$<>8__locals1.gearConfigIds[0]) : null;
				global::Vector vector = global::Vector.Create();
				bool flag = false;
				if (entityHandle != null && entityHandle.Valid)
				{
					WorldEntity entity = entityHandle.Entity;
					bool flag2;
					if (entity == null)
					{
						flag2 = false;
					}
					else
					{
						SceneItemSunSpiritGearComponent component = entity.GetComponent<SceneItemSunSpiritGearComponent>();
						flag2 = ((component != null) ? new bool?(component.GetSunSpiritSocketLocAndRot(0, vector, null)) : null).GetValueOrDefault();
					}
					flag = flag2;
				}
				if (flag)
				{
					TsBaseCharacter baseCharacter = Global.BaseCharacter;
					global::Vector vector2;
					if (baseCharacter == null)
					{
						vector2 = null;
					}
					else
					{
						CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
						vector2 = ((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null);
					}
					global::Vector vector3 = vector2;
					if (vector3 != null)
					{
						float num2 = (float)global::Vector.Dist(vector, vector3);
						float flyFromGearToPlayerSpeedForCalc = CS$<>8__locals1.config.FlyFromGearToPlayerSpeedForCalc;
						if (flyFromGearToPlayerSpeedForCalc > 0f)
						{
							flyingDuration2 = num2 / flyFromGearToPlayerSpeedForCalc;
						}
					}
				}
				float flyingDuration = flyingDuration2;
				Dictionary<long, List<SunSpiritPb>> dictionary = new Dictionary<long, List<SunSpiritPb>>();
				List<SunSpiritPb> list = new List<SunSpiritPb>();
				foreach (SunSpiritPb sunSpiritPb2 in CS$<>8__locals1.notify.TakeUpInfo)
				{
					if (sunSpiritPb2.TakeUpData == null)
					{
						list.Add(sunSpiritPb2);
					}
					else
					{
						long key = (long)sunSpiritPb2.TakeUpData.TrapEntityConfigId;
						List<SunSpiritPb> list2;
						if (!dictionary.TryGetValue(key, out list2))
						{
							list2 = new List<SunSpiritPb>();
							dictionary[key] = list2;
						}
						list2.Add(sunSpiritPb2);
					}
				}
				foreach (List<SunSpiritPb> list3 in dictionary.Values)
				{
					Comparison<SunSpiritPb> comparison;
					if ((comparison = CS$<>8__locals1.<>9__1) == null)
					{
						comparison = (CS$<>8__locals1.<>9__1 = delegate(SunSpiritPb a, SunSpiritPb b)
						{
							if (!CS$<>8__locals1.config.FlyFromGearToPlayerInOrderFromMinToMax)
							{
								return b.TakeUpData.Index - a.TakeUpData.Index;
							}
							return a.TakeUpData.Index - b.TakeUpData.Index;
						});
					}
					list3.Sort(comparison);
				}
				float num3 = CS$<>8__locals1.config.FlyFromGearToPlayerDelayInterval * 1000f;
				float waitBeforeFlyingDuration = CS$<>8__locals1.config.FlyFromGearToPlayerWaitTimeBeforeFly;
				foreach (List<SunSpiritPb> list4 in dictionary.Values)
				{
					float num4 = 0f;
					using (List<SunSpiritPb>.Enumerator enumerator4 = list4.GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							SunSpiritPb sunSpiritPb = enumerator4.Current;
							if (num4 < 20f)
							{
								CS$<>8__locals1.<>4__this.HandleSunSpiritFlyFromGearToPlayer(CS$<>8__locals1.notify, sunSpiritPb, waitBeforeFlyingDuration, flyingDuration);
							}
							else
							{
								TimerSystem.Instance.Delay(delegate(float _)
								{
									CS$<>8__locals1.<>4__this.HandleSunSpiritFlyFromGearToPlayer(CS$<>8__locals1.notify, sunSpiritPb, waitBeforeFlyingDuration, flyingDuration);
								}, Math.Min(num4, 180000f), null, null, true, 1f);
							}
							num4 += num3;
						}
					}
				}
				foreach (SunSpiritPb singleSunSpiritPb in list)
				{
					CS$<>8__locals1.<>4__this.HandleSunSpiritFlyFromGearToPlayer(CS$<>8__locals1.notify, singleSunSpiritPb, waitBeforeFlyingDuration, flyingDuration);
				}
			}, 60000, true, false);
		}

		// Token: 0x060437E4 RID: 276452 RVA: 0x01164564 File Offset: 0x01162764
		private void HandleSunSpiritFlyFromPlayerToGear(SunSpiritActionOperationNotify notify, SunSpiritPb singleSunSpiritPb, float waitBeforeFlyingDuration, float flyingDuration)
		{
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			SunSpiritData sunSpiritData = (instance != null) ? instance.GetSunSpiritDataByPlayerIdAndConfigId(ModelBase<CreatureModel>.Instance.GetPlayerId(), singleSunSpiritPb.InstId, singleSunSpiritPb.EntityConfigId) : null;
			if (sunSpiritData == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SunSpirit;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "日灵: 执行操作，未找到日灵数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SpiritConfigId", singleSunSpiritPb.EntityConfigId);
				instance2.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.OnActionOperationChildTaskFinish(notify, singleSunSpiritPb);
				return;
			}
			if (singleSunSpiritPb.TakeUpData == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SunSpirit;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "日灵: 操作协议内容有误";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("SpiritConfigId", singleSunSpiritPb.EntityConfigId);
				instance3.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				this.OnActionOperationChildTaskFinish(notify, singleSunSpiritPb);
				return;
			}
			int trapEntityConfigId = singleSunSpiritPb.TakeUpData.TrapEntityConfigId;
			int index = singleSunSpiritPb.TakeUpData.Index;
			SunSpiritFlyingToGearState newState = new SunSpiritFlyingToGearState(sunSpiritData, waitBeforeFlyingDuration, flyingDuration, trapEntityConfigId, index, delegate()
			{
				this.OnActionOperationChildTaskFinish(notify, singleSunSpiritPb);
			});
			sunSpiritData.StopAllAndSetNextSunSpiritState(newState, false);
		}

		// Token: 0x060437E5 RID: 276453 RVA: 0x011646AC File Offset: 0x011628AC
		private void HandleSunSpiritFlyFromGearToPlayer(SunSpiritActionOperationNotify notify, SunSpiritPb singleSunSpiritPb, float waitBeforeFlyingDuration, float flyingDuration)
		{
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			SunSpiritData sunSpiritData = (instance != null) ? instance.GetSunSpiritDataByPlayerIdAndConfigId(ModelBase<CreatureModel>.Instance.GetPlayerId(), singleSunSpiritPb.InstId, singleSunSpiritPb.EntityConfigId) : null;
			if (sunSpiritData == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SunSpirit;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "日灵: 执行操作，未找到日灵数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SpiritConfigId", singleSunSpiritPb.EntityConfigId);
				instance2.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.OnActionOperationChildTaskFinish(notify, singleSunSpiritPb);
				return;
			}
			if (singleSunSpiritPb.TakeUpData == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SunSpirit;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "日灵: 操作协议内容有误";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("SpiritConfigId", singleSunSpiritPb.EntityConfigId);
				instance3.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				this.OnActionOperationChildTaskFinish(notify, singleSunSpiritPb);
				return;
			}
			int trapEntityConfigId = singleSunSpiritPb.TakeUpData.TrapEntityConfigId;
			int index = singleSunSpiritPb.TakeUpData.Index;
			SunSpiritFlyingToPlayerState newState = new SunSpiritFlyingToPlayerState(sunSpiritData, waitBeforeFlyingDuration, flyingDuration, trapEntityConfigId, index, delegate()
			{
				this.OnActionOperationChildTaskFinish(notify, singleSunSpiritPb);
			});
			sunSpiritData.StopAllAndSetNextSunSpiritState(newState, false);
		}

		// Token: 0x060437E6 RID: 276454 RVA: 0x011647F4 File Offset: 0x011629F4
		private unsafe void PushSunSpiritActionOperationEnd(SunSpiritActionOperationNotify reqData)
		{
			if (this.IsInDebugMode)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SunSpirit;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "日灵: 执行操作完成";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RelatedSceneItemId", reqData.EntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("OperationType", reqData.OperationType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SpiritConfigs", reqData.TakeUpInfo);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SunSpirit;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "日灵: 执行操作完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("OperationType", reqData.OperationType);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			SunSpiritActionOperationEndPush sunSpiritActionOperationEndPush = SunSpiritActionOperationEndPush.Create();
			sunSpiritActionOperationEndPush.IncId = reqData.IncId;
			sunSpiritActionOperationEndPush.Index = reqData.Index;
			sunSpiritActionOperationEndPush.PlayerId = reqData.PlayerId;
			Singleton<Net>.Instance.Send(EPushMessageId.SunSpiritActionOperationEndPush, sunSpiritActionOperationEndPush);
		}

		// Token: 0x060437E7 RID: 276455 RVA: 0x01164904 File Offset: 0x01162B04
		private unsafe void OnActionOperationChildTaskFinish(SunSpiritActionOperationNotify notify, SunSpiritPb childTaskPb)
		{
			HashSet<SunSpiritPb> hashSet;
			if (!this.ActiveActionOperationNotifyHandlerMap.TryGetValue(notify, out hashSet))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SunSpirit;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "日灵: 执行操作，单个日灵执行操作完成回调时，发现所属的操作列表已非活跃";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RelatedSceneItemId", notify.EntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("OperationType", notify.OperationType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SunSpiritConfigId", childTaskPb.EntityConfigId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			if (!hashSet.Contains(childTaskPb))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SunSpirit;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "日灵: 执行操作，单个日灵执行操作完成回调时，发现所执行的操作已非活跃";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("RelatedSceneItemId", notify.EntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("OperationType", notify.OperationType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("SunSpiritConfigId", childTaskPb.EntityConfigId);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return;
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.SunSpirit;
			ELogAuthor author3 = ELogAuthor.ZYL;
			string message3 = "日灵: 执行操作，单个日灵执行操作完成";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("RelatedSceneItemId", notify.EntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("OperationType", notify.OperationType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("SunSpiritConfigId", childTaskPb.EntityConfigId);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			hashSet.Remove(childTaskPb);
			if (hashSet.Count == 0)
			{
				this.ActiveActionOperationNotifyHandlerMap.Remove(notify);
				if (notify.OperationType == SunSpiritOperationType.Fly)
				{
					foreach (SunSpiritPb sunSpiritPb in notify.TakeUpInfo)
					{
						SunSpiritModel instance4 = ModelBase<SunSpiritModel>.Instance;
						if (instance4 != null)
						{
							instance4.AddOrUpdateSunSpiritDataByPb(sunSpiritPb, true);
						}
					}
				}
				this.PushSunSpiritActionOperationEnd(notify);
			}
		}

		// Token: 0x060437E8 RID: 276456 RVA: 0x01164B54 File Offset: 0x01162D54
		private void OnBattleStateChanged(bool isInBattleState)
		{
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			if (instance != null)
			{
				CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
				int playerId = (instance2 != null) ? instance2.GetPlayerId() : 0;
				AreaModel instance3 = ModelBase<AreaModel>.Instance;
				Area? area;
				instance.GetAllSunSpiritDataByPlayerIdAndAreaId(playerId, ((instance3 != null) ? ((instance3.AreaInfo != null) ? new int?(area.GetValueOrDefault().AreaId) : null) : null).GetValueOrDefault(), true, null, this.TempSunSpiritList);
			}
			foreach (SunSpiritData sunSpiritData in this.TempSunSpiritList)
			{
				if (sunSpiritData.GetSunSpiritState().StateType == ESunSpiritStateType.OccupiedByPlayer)
				{
					SunSpiritBasePerform sunSpiritPerform = sunSpiritData.GetSunSpiritPerform();
					if (sunSpiritPerform is SunSpiritCrowdPerform)
					{
						((SunSpiritCrowdPerform)sunSpiritPerform).OnBattleStateChanged(isInBattleState);
					}
				}
			}
		}

		// Token: 0x04025B34 RID: 154420
		public const string DEBUG_KEY = "SunSpirit";

		// Token: 0x04025B35 RID: 154421
		public const int TICK_INTERVAL = 33;

		// Token: 0x04025B36 RID: 154422
		[StaticVariableRuleIgnore]
		public readonly int[] ENABLE_TAGS = new int[]
		{
			GameplayTagDefine.EGameplayTagId["关卡.日灵.3_0浮光林POI日灵"]
		};

		// Token: 0x04025B37 RID: 154423
		[Nullable(2)]
		private SunSpiritHintView SunSpiritHintView;

		// Token: 0x04025B38 RID: 154424
		[Nullable(2)]
		private SunSpiritLauncherHintView SunSpiritLauncherHintView;

		// Token: 0x04025B39 RID: 154425
		private readonly List<ITagTask> TagListeners = new List<ITagTask>();

		// Token: 0x04025B3A RID: 154426
		private double DeltaFromLastTick;

		// Token: 0x04025B3B RID: 154427
		private readonly List<SunSpiritData> TempSunSpiritList = new List<SunSpiritData>();

		// Token: 0x04025B3C RID: 154428
		private readonly Dictionary<SunSpiritActionOperationNotify, HashSet<SunSpiritPb>> ActiveActionOperationNotifyHandlerMap = new Dictionary<SunSpiritActionOperationNotify, HashSet<SunSpiritPb>>();
	}
}
