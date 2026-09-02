using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using UnrealEngine;

namespace CSharpScript.Game.Module.SeamlessTravel
{
	// Token: 0x02005008 RID: 20488
	[NullableContext(1)]
	[Nullable(0)]
	public class SeamlessTravelSceneEffect
	{
		// Token: 0x17008AC4 RID: 35524
		// (get) Token: 0x06034CFF RID: 216319 RVA: 0x00D419B7 File Offset: 0x00D3FBB7
		public bool IsInit
		{
			get
			{
				return this.IsInitInternal;
			}
		}

		// Token: 0x06034D00 RID: 216320 RVA: 0x00D419C0 File Offset: 0x00D3FBC0
		public void Init(SeamlessTravelContext config, Action<bool> callback)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			this.ActorComp = ((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null);
			if (this.ActorComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SeamlessTravel;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[SeamlessTravelSceneEffect]初始化失败，无效的ActorComp";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActorName", Global.BaseCharacter);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.Context = config;
			if (this.IsInit)
			{
				callback(true);
				return;
			}
			UKuroRenderingRuntimeBPPluginBPLibrary.StartSceneColorShotBeforeTonemap(EKuroCaptureSceneColorType.KCSCT_Default);
			this.EffectDaPath = this.Context.SceneEffectDaPath;
			this.LoadEffectAsset(delegate(bool result)
			{
				this.IsInitInternal = true;
				callback(result);
			});
		}

		// Token: 0x06034D01 RID: 216321 RVA: 0x00D41A74 File Offset: 0x00D3FC74
		private unsafe void LoadEffectAsset(Action<bool> callback)
		{
			if (string.IsNullOrEmpty(this.EffectDaPath))
			{
				callback(true);
				return;
			}
			Singleton<ResourceSystem>.Instance.LoadAsync<UEffectModelBase>(this.EffectDaPath, delegate([Nullable(2)] UEffectModelBase effectDaAsset, string path)
			{
				if (effectDaAsset == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SeamlessTravel;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "[SeamlessTravelSceneEffect] 加载DA失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("path", path);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActorName", Global.BaseCharacter);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					callback(false);
					return;
				}
				this.EffectDaAsset = effectDaAsset;
				float num = Math.Max(this.Context.EffectExpandTime, this.EffectDaAsset.StartTime);
				float num2 = Math.Max(this.Context.EffectCollapseTime, this.EffectDaAsset.EndTime);
				this.EffectStartTimeMs = num * 1000f;
				this.EffectEndTimeMs = num2 * 1000f;
				callback(true);
			}, 100, "SeamlessTravel.SceneEffect");
		}

		// Token: 0x06034D02 RID: 216322 RVA: 0x00D41AD3 File Offset: 0x00D3FCD3
		public void Tick(float delta)
		{
		}

		// Token: 0x06034D03 RID: 216323 RVA: 0x00D41AD8 File Offset: 0x00D3FCD8
		public void Destroy()
		{
			if (this.EffectHandle != null && Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle.Value))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.EffectHandle.Value, "[SeamlessTravelSceneEffect] DisappearEffect", true, null);
			}
			this.EffectActor = null;
			this.EffectHandle = null;
			this.EffectDaAsset = null;
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.KuroCaptureSceneColor.Release", null);
		}

		// Token: 0x06034D04 RID: 216324 RVA: 0x00D41B58 File Offset: 0x00D3FD58
		public void AppearEffect(Action<bool> callback)
		{
			if (this.IsInit)
			{
				CharacterActorComponent actorComp = this.ActorComp;
				bool flag;
				if (actorComp == null)
				{
					flag = true;
				}
				else
				{
					TsBaseCharacter actor = actorComp.Actor;
					flag = !((actor != null) ? new bool?(actor.IsValid()) : null).GetValueOrDefault();
				}
				if (!flag)
				{
					UEffectModelBase effectDaAsset = this.EffectDaAsset;
					if (effectDaAsset == null || !effectDaAsset.IsValid())
					{
						callback(false);
						return;
					}
					EffectSystem instance = Singleton<EffectSystem>.Instance;
					UObject world = GlobalData.World;
					FTransformDouble? ftransformDouble = new FTransformDouble?(this.ActorComp.ActorTransform);
					TTimerAction <>9__1;
					this.EffectHandle = new int?(instance.SpawnEffect(world, ftransformDouble, this.EffectDaPath, "[SeamlessTravelSceneEffect] AppearEffect", new EffectContext(null, this.ActorComp.Actor, false), EEffectType.Fight, null, null, delegate(int handle)
					{
						AActor sureEffectActor = Singleton<EffectSystem>.Instance.GetSureEffectActor(handle);
						if (sureEffectActor == null || !sureEffectActor.IsValid())
						{
							callback(false);
							return;
						}
						UKuroRenderingRuntimeBPPluginBPLibrary.StopSceneColorShotBeforeTonemap(EKuroCaptureSceneColorType.KCSCT_Default, 0f);
						CharacterActorComponent actorComp2 = this.ActorComp;
						if (actorComp2 != null && actorComp2.Actor.IsValid())
						{
							sureEffectActor.K2_AttachToActor(this.ActorComp.Actor, null, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
						}
						this.EffectActor = sureEffectActor;
						if (this.EffectStartTimeMs < 20f)
						{
							callback(true);
							return;
						}
						TimerSystemInstance instance2 = TimerSystem.Instance;
						TTimerAction action;
						if ((action = <>9__1) == null)
						{
							action = (<>9__1 = delegate(float _)
							{
								callback(true);
							});
						}
						instance2.Delay(action, this.EffectStartTimeMs, null, null, true, 1f);
					}, false, false));
					return;
				}
			}
			callback(false);
		}

		// Token: 0x06034D05 RID: 216325 RVA: 0x00D41C50 File Offset: 0x00D3FE50
		public void DisappearEffect(Action<bool> callback)
		{
			if (!this.IsInit)
			{
				callback(false);
				return;
			}
			if (this.EffectHandle == null || !Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle.Value))
			{
				this.EffectActor = null;
				this.EffectHandle = null;
				callback(true);
				return;
			}
			Singleton<EffectSystem>.Instance.StopEffectById(this.EffectHandle.Value, "[SeamlessTravelSceneEffect] DisappearEffect", false, null);
			this.EffectActor = null;
			this.EffectHandle = null;
			if (this.EffectEndTimeMs < 20f)
			{
				callback(true);
				return;
			}
			TimerSystem.Instance.Delay(delegate(float _)
			{
				callback(true);
			}, this.EffectEndTimeMs, null, null, true, 1f);
		}

		// Token: 0x06034D06 RID: 216326 RVA: 0x00D41D3A File Offset: 0x00D3FF3A
		public TArray<AActor> GetSeamlessTravelActors(TArray<AActor> arr)
		{
			if (this.EffectActor != null)
			{
				arr.Add(this.EffectActor);
			}
			return arr;
		}

		// Token: 0x0401E6F4 RID: 124660
		[Nullable(2)]
		private CharacterActorComponent ActorComp;

		// Token: 0x0401E6F5 RID: 124661
		[Nullable(2)]
		private SeamlessTravelContext Context;

		// Token: 0x0401E6F6 RID: 124662
		[Nullable(2)]
		private string EffectDaPath;

		// Token: 0x0401E6F7 RID: 124663
		[Nullable(2)]
		private UEffectModelBase EffectDaAsset;

		// Token: 0x0401E6F8 RID: 124664
		private int? EffectHandle;

		// Token: 0x0401E6F9 RID: 124665
		[Nullable(2)]
		private AActor EffectActor;

		// Token: 0x0401E6FA RID: 124666
		private bool IsInitInternal;

		// Token: 0x0401E6FB RID: 124667
		private float EffectStartTimeMs;

		// Token: 0x0401E6FC RID: 124668
		private float EffectEndTimeMs;
	}
}
