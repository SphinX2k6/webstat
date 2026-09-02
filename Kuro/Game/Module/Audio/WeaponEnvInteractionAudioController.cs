using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace Kuro.Game.Module.Audio
{
	// Token: 0x020043C0 RID: 17344
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class WeaponEnvInteractionAudioController : ControllerBase<WeaponEnvInteractionAudioController>
	{
		// Token: 0x0602E1C5 RID: 188869 RVA: 0x00AD71A0 File Offset: 0x00AD53A0
		protected override bool OnInit()
		{
			if (!this.Enabled)
			{
				return true;
			}
			if (!WeaponEnvInteractionAudioController.IsWindows)
			{
				return true;
			}
			this.InteractionEffectSystem = (UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UKuroInteractionEffectSystem.StaticClass()) as UKuroInteractionEffectSystem);
			if (this.InteractionEffectSystem == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Audio, ELogAuthor.CH, "武器交互场景时: 获取 InteractionEffectSystem 失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			GlobalConfigFromCsv? config = ConfigGlobalConfigFromCsvByName.GetConfig("GrassCutAudioCd", true);
			float num;
			if (config != null && float.TryParse(config.Value.Value, out num))
			{
				this.PlayAudioCd = num / 1000f;
			}
			else
			{
				this.PlayAudioCd = 0.3f;
			}
			GlobalConfigFromCsv? config2 = ConfigGlobalConfigFromCsvByName.GetConfig("GrassCutAudioThreshold", true);
			float playAudioThreshold;
			if (config2 != null && float.TryParse(config2.Value.Value, out playAudioThreshold))
			{
				this.PlayAudioThreshold = playAudioThreshold;
			}
			else
			{
				this.PlayAudioThreshold = 0.9f;
			}
			return true;
		}

		// Token: 0x0602E1C6 RID: 188870 RVA: 0x00AD7290 File Offset: 0x00AD5490
		protected override bool OnLeaveLevel()
		{
			if (!WeaponEnvInteractionAudioController.IsWindows)
			{
				return true;
			}
			this.InteractionEffectSystem = (UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UKuroInteractionEffectSystem.StaticClass()) as UKuroInteractionEffectSystem);
			if (this.InteractionEffectSystem == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Audio, ELogAuthor.CH, "武器交互场景时: 获取 InteractionEffectSystem 失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.ClearComponentCache();
			return true;
		}

		// Token: 0x0602E1C7 RID: 188871 RVA: 0x00AD72F0 File Offset: 0x00AD54F0
		protected override bool OnClear()
		{
			if (!WeaponEnvInteractionAudioController.IsWindows)
			{
				return true;
			}
			this.InteractionEffectSystem = null;
			this.ClearComponentCache();
			return true;
		}

		// Token: 0x0602E1C8 RID: 188872 RVA: 0x00AD730C File Offset: 0x00AD550C
		private UKuroEnviInteractionComponent GetOrCacheEnviInteractionComponent()
		{
			WeaponEnvInteractionAudioController.<>c__DisplayClass11_0 CS$<>8__locals1 = new WeaponEnvInteractionAudioController.<>c__DisplayClass11_0();
			CS$<>8__locals1.<>4__this = this;
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
			if (worldEntity == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Audio, ELogAuthor.CH, "获取交互组件失败: 当前实体不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			CS$<>8__locals1.entityId = worldEntity.Id;
			UKuroEnviInteractionComponent ukuroEnviInteractionComponent;
			if (this.ComponentCache.TryGetValue(CS$<>8__locals1.entityId, out ukuroEnviInteractionComponent))
			{
				if (ukuroEnviInteractionComponent != null && ukuroEnviInteractionComponent.IsValid())
				{
					return ukuroEnviInteractionComponent;
				}
				this.ComponentCache.Remove(CS$<>8__locals1.entityId);
			}
			BaseActorComponent component = worldEntity.GetComponent<BaseActorComponent>();
			if (((component != null) ? component.Owner : null) == null || !component.Owner.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.CH;
				string message = "获取交互组件失败: 实体不包含 ActorComponent";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", CS$<>8__locals1.entityId.ToString());
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			UKuroEnviInteractionComponent ukuroEnviInteractionComponent2 = component.Owner.GetComponentByClass(UKuroEnviInteractionComponent.StaticClass()) as UKuroEnviInteractionComponent;
			if (ukuroEnviInteractionComponent2 == null || !ukuroEnviInteractionComponent2.IsValid())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Audio;
				ELogAuthor author2 = ELogAuthor.CH;
				string message2 = "获取交互组件失败: 实体不包含 KuroEnviInteractionComponent";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", CS$<>8__locals1.entityId.ToString());
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			this.ComponentCache[CS$<>8__locals1.entityId] = ukuroEnviInteractionComponent2;
			Singleton<EventSystem>.Instance.AddWithTarget(worldEntity, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(CS$<>8__locals1.<GetOrCacheEnviInteractionComponent>g__EntityRemoveHandler|0));
			return ukuroEnviInteractionComponent2;
		}

		// Token: 0x0602E1C9 RID: 188873 RVA: 0x00AD7482 File Offset: 0x00AD5682
		private void ClearComponentCache()
		{
			if (this.ComponentCache.Count > 0)
			{
				this.ComponentCache.Clear();
			}
		}

		// Token: 0x0602E1CA RID: 188874 RVA: 0x00AD74A0 File Offset: 0x00AD56A0
		public unsafe void OnWeaponInteraction(FVector originPoint, float timeInterval)
		{
			if (Singleton<Time>.Instance.PlayerTime - this.LastPlayAudioTime < (double)this.PlayAudioCd)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.CH;
				string message = "武器交互场景时: 播放音频时间间隔不足";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("timeInterval", (Singleton<Time>.Instance.PlayerTime - this.LastPlayAudioTime).ToString("F2"));
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.InteractionEffectSystem == null || !this.InteractionEffectSystem.IsValid())
			{
				Singleton<Log>.Instance.Warn(ELogModule.Audio, ELogAuthor.CH, "武器交互场景时: InteractionEffectSystem 无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.InteractionEffectSystem = (UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UKuroInteractionEffectSystem.StaticClass()) as UKuroInteractionEffectSystem);
			}
			if (this.InteractionEffectSystem.GrassCutReadBack <= this.PlayAudioThreshold)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Audio;
				ELogAuthor author2 = ELogAuthor.CH;
				string message2 = "武器交互场景时: 不满足播放音频条件";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("RtValue", this.InteractionEffectSystem.GrassCutReadBack.ToString("F2"));
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			UKuroEnviInteractionComponent orCacheEnviInteractionComponent = this.GetOrCacheEnviInteractionComponent();
			string text = null;
			foreach (InteractionItemInfo interactionItemInfo in InteractionItemInfos.Items)
			{
				if (interactionItemInfo.Foliages != null && interactionItemInfo.Foliages.Count > 0)
				{
					TArray<string> tarray = new TArray<string>();
					foreach (string value in interactionItemInfo.Foliages)
					{
						tarray.Add(value);
					}
					TArray<int> tarray2 = this.InteractionEffectSystem.SearchInteractionFoliageArray(tarray);
					float num = 0f;
					for (int i = 0; i < tarray2.Count; i++)
					{
						num += (float)tarray2[i];
					}
					if (num > 0f)
					{
						text = interactionItemInfo.AudioKey;
						break;
					}
				}
				if (interactionItemInfo.StaticMeshes != null && interactionItemInfo.StaticMeshes.Count > 0)
				{
					TWeakObjectPtr<AActor>? tweakObjectPtr = (orCacheEnviInteractionComponent != null) ? new TWeakObjectPtr<AActor>?(orCacheEnviInteractionComponent.GetEnviInteractionData().HitBushActor) : null;
					UStaticMeshComponent ustaticMeshComponent = ((tweakObjectPtr != null) ? tweakObjectPtr.GetValueOrDefault().Get().GetComponentByClass(UStaticMeshComponent.StaticClass()) : null) as UStaticMeshComponent;
					if (ustaticMeshComponent != null && ustaticMeshComponent.IsValid())
					{
						string pathName = UKismetSystemLibrary.GetPathName(ustaticMeshComponent.StaticMesh);
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.Audio;
						ELogAuthor author3 = ELogAuthor.CH;
						string message3 = "武器交互场景时";
						ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("pathName", pathName);
						instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
						if (interactionItemInfo.StaticMeshes.Contains(pathName))
						{
							text = interactionItemInfo.AudioKey;
							break;
						}
					}
				}
			}
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Audio;
			ELogAuthor author4 = ELogAuthor.CH;
			string message4 = "武器交互场景时";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("GrassCutReadBack", this.InteractionEffectSystem.GrassCutReadBack.ToString("F2"));
			instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			if (!string.IsNullOrEmpty(text))
			{
				this.LastPlayAudioTime = Singleton<Time>.Instance.PlayerTime;
				AudioSystem instance5 = Singleton<AudioSystem>.Instance;
				string @event = text;
				FVectorDouble fvectorDouble = originPoint;
				instance5.PostEvent(@event, new FTransformDouble?(new FTransformDouble(ref fvectorDouble)), null);
				Log instance6 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.Audio;
				ELogAuthor author5 = ELogAuthor.CH;
				string message5 = "武器交互场景时: 播放割草音频";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("originPoint", originPoint.ToString());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("audioKey", text);
				instance6.Info(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x0602E1CB RID: 188875 RVA: 0x00AD7888 File Offset: 0x00AD5A88
		public bool IsEnabled()
		{
			return this.Enabled;
		}

		// Token: 0x0602E1CC RID: 188876 RVA: 0x00AD7890 File Offset: 0x00AD5A90
		public void SetEnabled(bool enabled)
		{
			if (this.Enabled == enabled)
			{
				return;
			}
			this.Enabled = enabled;
			if (enabled)
			{
				this.OnInit();
				return;
			}
			this.OnClear();
		}

		// Token: 0x17007F07 RID: 32519
		// (get) Token: 0x0602E1CD RID: 188877 RVA: 0x00AD78B5 File Offset: 0x00AD5AB5
		private static bool IsWindows
		{
			get
			{
				return Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Windows;
			}
		}

		// Token: 0x0401A15F RID: 106847
		private const float DEFAULT_PLAY_AUDIO_CD = 0.3f;

		// Token: 0x0401A160 RID: 106848
		private const float PLAY_AUDIO_THRESHOLD = 0.9f;

		// Token: 0x0401A161 RID: 106849
		private bool Enabled;

		// Token: 0x0401A162 RID: 106850
		private UKuroInteractionEffectSystem InteractionEffectSystem;

		// Token: 0x0401A163 RID: 106851
		private double LastPlayAudioTime;

		// Token: 0x0401A164 RID: 106852
		private float PlayAudioCd;

		// Token: 0x0401A165 RID: 106853
		private float PlayAudioThreshold;

		// Token: 0x0401A166 RID: 106854
		private readonly Dictionary<int, UKuroEnviInteractionComponent> ComponentCache = new Dictionary<int, UKuroEnviInteractionComponent>();
	}
}
