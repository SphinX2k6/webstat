using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.SpecificScanEffect;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Controller
{
	// Token: 0x02004873 RID: 18547
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class ChargeSlashGameplayController : ControllerBase<ChargeSlashGameplayController>
	{
		// Token: 0x06030430 RID: 197680 RVA: 0x00BBD964 File Offset: 0x00BBBB64
		public void StartChargeSlash(GrapplingHookPointComponent targetHook)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.ChargeSlash, ELogAuthor.CH, "[ChargeSlashGameplayController] StartChargeSlash", default(ReadOnlySpan<ValueTuple<string, object>>));
			IChargeSlashHook chargeSlashHook = targetHook.GetHookInteractConfig() as IChargeSlashHook;
			if (chargeSlashHook == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.ChargeSlash, ELogAuthor.CH, "[StartChargeSlash] interactConfig is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			float valueOrDefault = chargeSlashHook.MaxRandomDelayTime.GetValueOrDefault(1f);
			using (List<int>.Enumerator enumerator = chargeSlashHook.TargetEntityIds.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int id = enumerator.Current;
					EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(id);
					if (((entityByPbDataId != null) ? entityByPbDataId.Entity : null) == null)
					{
						global::Log instance = Singleton<global::Log>.Instance;
						ELogModule module = ELogModule.ChargeSlash;
						ELogAuthor author = ELogAuthor.CH;
						string message = "[StartChargeSlash] cannont find entity";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataId", id);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
					else if (!entityByPbDataId.IsInit || !entityByPbDataId.Entity.IsInit)
					{
						global::Log instance2 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.ChargeSlash;
						ELogAuthor author2 = ELogAuthor.CH;
						string message2 = "[StartChargeSlash] entity is not init";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("pbDataId", id);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					}
					else
					{
						SceneItemCurveControlComponent curveControlComp = entityByPbDataId.Entity.GetComponent<SceneItemCurveControlComponent>();
						if (curveControlComp == null)
						{
							global::Log instance3 = Singleton<global::Log>.Instance;
							ELogModule module3 = ELogModule.ChargeSlash;
							ELogAuthor author3 = ELogAuthor.CH;
							string message3 = "[StartChargeSlash] Entity has no curveControlComp";
							ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("pbDataId", id);
							instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
						}
						else
						{
							float randomTime = Math.Max(Random.Shared.NextSingle() * valueOrDefault, 0.02f);
							TimerHandle timerHandle = TimerSystem.Instance.Delay(delegate(float _)
							{
								this.TimerHandlesMap.Remove(id);
								this.SceneItemStartPerformance(curveControlComp, randomTime);
							}, randomTime * 1000f, null, null, true, 1f);
							if (timerHandle == null)
							{
								global::Log instance4 = Singleton<global::Log>.Instance;
								ELogModule module4 = ELogModule.ChargeSlash;
								ELogAuthor author4 = ELogAuthor.CH;
								string message4 = "[StartChargeSlash] timerHandle is null";
								ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("pbDataId", id);
								instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
							}
							else
							{
								this.TimerHandlesMap[id] = timerHandle;
							}
						}
					}
				}
			}
		}

		// Token: 0x06030431 RID: 197681 RVA: 0x00BBDBDC File Offset: 0x00BBBDDC
		public void StopChargeSlash(GrapplingHookPointComponent targetHook)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.ChargeSlash, ELogAuthor.CH, "[ChargeSlashGameplayController] StopChargeSlash", default(ReadOnlySpan<ValueTuple<string, object>>));
			IChargeSlashHook chargeSlashHook = targetHook.GetHookInteractConfig() as IChargeSlashHook;
			if (chargeSlashHook == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.ChargeSlash, ELogAuthor.CH, "[StopChargeSlash] interactConfig is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			foreach (int num in chargeSlashHook.TargetEntityIds)
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num);
				if (((entityByPbDataId != null) ? entityByPbDataId.Entity : null) == null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.ChargeSlash;
					ELogAuthor author = ELogAuthor.CH;
					string message = "[StopChargeSlash] cannont find entity";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataId", num);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else if (!entityByPbDataId.IsInit || !entityByPbDataId.Entity.IsInit)
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.ChargeSlash;
					ELogAuthor author2 = ELogAuthor.CH;
					string message2 = "[StopChargeSlash] entity is not init";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("pbDataId", num);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				else
				{
					SceneItemCurveControlComponent component = entityByPbDataId.Entity.GetComponent<SceneItemCurveControlComponent>();
					if (component == null)
					{
						global::Log instance3 = Singleton<global::Log>.Instance;
						ELogModule module3 = ELogModule.ChargeSlash;
						ELogAuthor author3 = ELogAuthor.CH;
						string message3 = "[StopChargeSlash] Entity has no curveControlComp";
						ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("pbDataId", num);
						instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					}
					else if (this.TimerHandlesMap.ContainsKey(num))
					{
						TimerSystem.Instance.Remove(this.TimerHandlesMap[num]);
						this.TimerHandlesMap.Remove(num);
					}
					else
					{
						component.StopPerformance();
					}
				}
			}
		}

		// Token: 0x06030432 RID: 197682 RVA: 0x00BBDDAC File Offset: 0x00BBBFAC
		private void SceneItemStartPerformance(SceneItemCurveControlComponent curveControlComp, float delayTime)
		{
			curveControlComp.StartPerformance(delayTime);
		}

		// Token: 0x06030433 RID: 197683 RVA: 0x00BBDDB8 File Offset: 0x00BBBFB8
		private void ClearTimerHandles()
		{
			foreach (TimerHandle handle in this.TimerHandlesMap.Values)
			{
				TimerSystem.Instance.Remove(handle);
			}
			this.TimerHandlesMap.Clear();
		}

		// Token: 0x06030434 RID: 197684 RVA: 0x00BBDE20 File Offset: 0x00BBC020
		protected override bool OnLeaveLevel()
		{
			this.ClearTimerHandles();
			return true;
		}

		// Token: 0x06030435 RID: 197685 RVA: 0x00BBDE29 File Offset: 0x00BBC029
		protected override bool OnClear()
		{
			this.ClearTimerHandles();
			return true;
		}

		// Token: 0x06030436 RID: 197686 RVA: 0x00BBDE34 File Offset: 0x00BBC034
		protected override void OnTick(float delta)
		{
			if (this.ChargeSlashScanEffectMap.Count == 0)
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, SpecificScanEffectData> keyValuePair in this.ChargeSlashScanEffectMap)
			{
				if (!keyValuePair.Value.Update(delta))
				{
					list.Add(keyValuePair.Key);
				}
			}
			foreach (int id in list)
			{
				this.StopChargeSlashScanEffect(id);
			}
		}

		// Token: 0x06030437 RID: 197687 RVA: 0x00BBDEF0 File Offset: 0x00BBC0F0
		public int StartChargeSlashScanEffect(FTransformDouble transform)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.ChargeSlash, ELogAuthor.CH, "[ChargeSlashGameplayController] StartChargeSlashScanEffect", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.Uid++;
			Singleton<ResourceSystem>.Instance.LoadAsync<UClass>("/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_DistortionWave.BP_DistortionWave_C", delegate([Nullable(2)] UClass result, string _)
			{
				if (result == null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.LevelEvent;
					ELogAuthor author = ELogAuthor.CH;
					string message = "加载ChargeSlash扫描特效失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_DistortionWave.BP_DistortionWave_C");
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				BP_DistortionWave_C bp_DistortionWave_C = Singleton<ActorSystem>.Instance.Spawn(result.ClassStackOnlyPtr, transform, null) as BP_DistortionWave_C;
				bp_DistortionWave_C.StartScanEffect();
				this.ChargeSlashScanEffectMap.Add(this.Uid, new SpecificScanEffectData(this.Uid, bp_DistortionWave_C, transform.GetLocation(), new ESpecificScanType?(ESpecificScanType.ChargeSlash)));
			}, 100, "js_undefined");
			return this.Uid;
		}

		// Token: 0x06030438 RID: 197688 RVA: 0x00BBDF68 File Offset: 0x00BBC168
		public void StopChargeSlashScanEffect(int id)
		{
			SpecificScanEffectData specificScanEffectData;
			if (this.ChargeSlashScanEffectMap.TryGetValue(id, out specificScanEffectData))
			{
				ActorSystem instance = Singleton<ActorSystem>.Instance;
				string reason = "StopChargeSlashScanEffect";
				SpecificScanEffectData specificScanEffectData2 = specificScanEffectData;
				instance.Put(reason, (specificScanEffectData2.EffectActor != null) ? specificScanEffectData2.EffectActor.GetValueOrDefault().AsT1 : null, null);
				this.ChargeSlashScanEffectMap.Remove(id);
				return;
			}
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.ChargeSlash;
			ELogAuthor author = ELogAuthor.CH;
			string message = "[StopChargeSlashScanEffect] data is null";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06030439 RID: 197689 RVA: 0x00BBDFF4 File Offset: 0x00BBC1F4
		public void StopAllChargeSlashScanEffect()
		{
			foreach (SpecificScanEffectData specificScanEffectData in this.ChargeSlashScanEffectMap.Values)
			{
				ActorSystem instance = Singleton<ActorSystem>.Instance;
				string reason = "StopAllChargeSlashScanEffect";
				SpecificScanEffectData specificScanEffectData2 = specificScanEffectData;
				instance.Put(reason, (specificScanEffectData2.EffectActor != null) ? specificScanEffectData2.EffectActor.GetValueOrDefault().AsT1 : null, null);
			}
			this.ChargeSlashScanEffectMap.Clear();
		}

		// Token: 0x0401BB7A RID: 113530
		private const float SMALLEST_RANDOM_TIME = 0.02f;

		// Token: 0x0401BB7B RID: 113531
		private const string SCAN_EFFECT_CLASS_PATH = "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_DistortionWave.BP_DistortionWave_C";

		// Token: 0x0401BB7C RID: 113532
		private readonly Dictionary<int, TimerHandle> TimerHandlesMap = new Dictionary<int, TimerHandle>();

		// Token: 0x0401BB7D RID: 113533
		private int Uid = -1;

		// Token: 0x0401BB7E RID: 113534
		private readonly Dictionary<int, SpecificScanEffectData> ChargeSlashScanEffectMap = new Dictionary<int, SpecificScanEffectData>();
	}
}
