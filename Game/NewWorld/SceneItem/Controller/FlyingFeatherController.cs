using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.NewWorld.SceneItem.SpecificScanEffect;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Controller
{
	// Token: 0x02004874 RID: 18548
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class FlyingFeatherController : ControllerBase<FlyingFeatherController>
	{
		// Token: 0x0603043B RID: 197691 RVA: 0x00BBE0A8 File Offset: 0x00BBC2A8
		protected override void OnTick(float delta)
		{
			if (this.FlyingFeatherScanEffectMap.Count == 0)
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, SpecificScanEffectData> keyValuePair in this.FlyingFeatherScanEffectMap)
			{
				int num;
				SpecificScanEffectData specificScanEffectData;
				keyValuePair.Deconstruct(out num, out specificScanEffectData);
				int item = num;
				if (!specificScanEffectData.Update(delta))
				{
					list.Add(item);
				}
			}
			foreach (int id in list)
			{
				this.StopFlyingFeatherScanEffect(id);
			}
		}

		// Token: 0x0603043C RID: 197692 RVA: 0x00BBE168 File Offset: 0x00BBC368
		public int StartFlyingFeatherScanEffect(FTransformDouble transform)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.CH, "[FlyingFeatherController] StartChargeSlashScanEffect", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.Uid++;
			Singleton<ResourceSystem>.Instance.LoadAsync<UClass>("/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Scanning_2_7.BP_Fx_Scanning_2_7_C", delegate([Nullable(2)] UClass result, string _)
			{
				if (result == null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.LevelEvent;
					ELogAuthor author = ELogAuthor.CH;
					string message = "加载飞雷神扫描特效失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Scanning_2_7.BP_Fx_Scanning_2_7_C");
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				BP_Fx_Scanning_2_7_C bp_Fx_Scanning_2_7_C = Singleton<ActorSystem>.Instance.Spawn<BP_Fx_Scanning_2_7_C>(result.ClassStackOnlyPtr, transform, null);
				if (bp_Fx_Scanning_2_7_C == null)
				{
					return;
				}
				bp_Fx_Scanning_2_7_C.StartScanEffect();
				this.FlyingFeatherScanEffectMap.Add(this.Uid, new SpecificScanEffectData(this.Uid, bp_Fx_Scanning_2_7_C, transform.GetLocation(), new ESpecificScanType?(ESpecificScanType.FlyingFeather)));
			}, 100, "js_undefined");
			return this.Uid;
		}

		// Token: 0x0603043D RID: 197693 RVA: 0x00BBE1DC File Offset: 0x00BBC3DC
		public void StopFlyingFeatherScanEffect(int id)
		{
			SpecificScanEffectData valueOrDefault = this.FlyingFeatherScanEffectMap.GetValueOrDefault(id);
			if (valueOrDefault == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[StopFlyingFeatherScanEffect] data is null";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ActorSystem instance2 = Singleton<ActorSystem>.Instance;
			string reason = "StopChargeSlashScanEffect";
			SpecificScanEffectData specificScanEffectData = valueOrDefault;
			instance2.Put(reason, (specificScanEffectData.EffectActor != null) ? specificScanEffectData.EffectActor.GetValueOrDefault().AsT2 : null, null);
			this.FlyingFeatherScanEffectMap.Remove(id);
		}

		// Token: 0x0603043E RID: 197694 RVA: 0x00BBE264 File Offset: 0x00BBC464
		public void StopAllFlyingFeatherScanEffect()
		{
			foreach (KeyValuePair<int, SpecificScanEffectData> keyValuePair in this.FlyingFeatherScanEffectMap)
			{
				int num;
				SpecificScanEffectData specificScanEffectData;
				keyValuePair.Deconstruct(out num, out specificScanEffectData);
				SpecificScanEffectData specificScanEffectData2 = specificScanEffectData;
				ActorSystem instance = Singleton<ActorSystem>.Instance;
				string reason = "StopAllFlyingFeatherScanEffect";
				SpecificScanEffectData specificScanEffectData3 = specificScanEffectData2;
				instance.Put(reason, (specificScanEffectData3.EffectActor != null) ? specificScanEffectData3.EffectActor.GetValueOrDefault().AsT2 : null, null);
			}
			this.FlyingFeatherScanEffectMap.Clear();
		}

		// Token: 0x0401BB7F RID: 113535
		private const string SCAN_EFFECT_CLASS_PATH = "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Scanning_2_7.BP_Fx_Scanning_2_7_C";

		// Token: 0x0401BB80 RID: 113536
		private int Uid = -1;

		// Token: 0x0401BB81 RID: 113537
		private readonly Dictionary<int, SpecificScanEffectData> FlyingFeatherScanEffectMap = new Dictionary<int, SpecificScanEffectData>();
	}
}
