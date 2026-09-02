using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SeamlessTravel
{
	// Token: 0x02005007 RID: 20487
	[NullableContext(2)]
	[Nullable(0)]
	public class SeamlessTravelPostProcess
	{
		// Token: 0x17008AC2 RID: 35522
		// (get) Token: 0x06034CF5 RID: 216309 RVA: 0x00D414BA File Offset: 0x00D3F6BA
		public bool IsInit
		{
			get
			{
				return this.IsInitInternal;
			}
		}

		// Token: 0x17008AC3 RID: 35523
		// (get) Token: 0x06034CF6 RID: 216310 RVA: 0x00D414C2 File Offset: 0x00D3F6C2
		public bool IsActive
		{
			get
			{
				return this.CurrentBlendStatus > SeamlessTravelPostProcess.EPostProcessBlendStatus.FullHide;
			}
		}

		// Token: 0x06034CF7 RID: 216311 RVA: 0x00D414D0 File Offset: 0x00D3F6D0
		[NullableContext(1)]
		public void Init(SeamlessTravelContext config, Action<bool> callback)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			this.ActorComp = ((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null);
			if (this.ActorComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Teleport;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[无缝传送PPV]初始化失败，无效的ActorComp";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActorName", Global.BaseCharacter);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.CurrentBlendStatus = SeamlessTravelPostProcess.EPostProcessBlendStatus.FullHide;
			this.Context = config;
			if (this.IsInit)
			{
				callback(true);
				return;
			}
			this.BlendInTimeMs = this.Context.EffectExpandTime * 1000f;
			this.BlendOutTimeMs = this.Context.EffectCollapseTime * 1000f;
			this.TransitionWeatherDaPath = this.Context.TransitionWeatherDaPath;
			this.CreatePPV(delegate(bool result)
			{
				this.IsInitInternal = true;
				callback(result);
			});
		}

		// Token: 0x06034CF8 RID: 216312 RVA: 0x00D415B4 File Offset: 0x00D3F7B4
		[NullableContext(1)]
		private unsafe void CreatePPV(Action<bool> callback)
		{
			ActorSystem instance = Singleton<ActorSystem>.Instance;
			UClassStackOnlyPtr ueClassPtr = AKuroPostProcessVolume.StaticClass();
			CharacterActorComponent actorComp = this.ActorComp;
			this.PostProcessVolume = (instance.Get(ueClassPtr, (actorComp != null) ? actorComp.ActorTransform : Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as AKuroPostProcessVolume);
			if (!this.PostProcessVolume.IsValid())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Teleport;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[无缝传送PPV] 创建PPV失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActorName", Global.BaseCharacter);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				callback(false);
				return;
			}
			this.PostProcessVolume.BlendWeight = 0f;
			this.PostProcessVolume.bUnbound = true;
			this.PostProcessVolume.bEnabled = false;
			this.PostProcessVolume.Priority = 9999f;
			UKuroRenderingRuntimeBPPluginBPLibrary.MarkWorldPostProcessPriorityDirty(this.PostProcessVolume);
			if (string.IsNullOrEmpty(this.TransitionWeatherDaPath))
			{
				callback(true);
				return;
			}
			Singleton<ResourceSystem>.Instance.LoadAsync<UKuroWeatherDataAsset>(this.TransitionWeatherDaPath, delegate([Nullable(2)] UKuroWeatherDataAsset res, string path)
			{
				if (res == null)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Teleport;
					ELogAuthor author2 = ELogAuthor.ZYL;
					string message2 = "[无缝传送PPV] 加载DA失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("path", path);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActorName", Global.BaseCharacter);
					instance3.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					callback(false);
					return;
				}
				AKuroPostProcessVolume postProcessVolume = this.PostProcessVolume;
				if (postProcessVolume != null)
				{
					postProcessVolume.SetWeatherDataAsset(res);
				}
				callback(true);
			}, ResourceSystem.EResourceLoadPriority.Default, "SeamlessTravel.PostProcess");
		}

		// Token: 0x06034CF9 RID: 216313 RVA: 0x00D416D8 File Offset: 0x00D3F8D8
		public void Tick(float delta)
		{
			if (this.IsInit)
			{
				AKuroPostProcessVolume postProcessVolume = this.PostProcessVolume;
				if (postProcessVolume != null && postProcessVolume.IsValid())
				{
					if (!this.IsActive)
					{
						return;
					}
					if (this.ActorComp == null)
					{
						return;
					}
					float blendWeight = this.PostProcessVolume.BlendWeight;
					SeamlessTravelPostProcess.EPostProcessBlendStatus currentBlendStatus = this.CurrentBlendStatus;
					if (currentBlendStatus != SeamlessTravelPostProcess.EPostProcessBlendStatus.BlendIn)
					{
						if (currentBlendStatus != SeamlessTravelPostProcess.EPostProcessBlendStatus.BlendOut)
						{
							return;
						}
						this.PostProcessVolume.BlendWeight = Singleton<MathUtils>.Instance.Clamp(blendWeight - delta / this.BlendOutTimeMs, 0f, 1f);
						this.PostProcessVolume.D_K2_SetActorLocation(this.ActorComp.ActorLocation, false, ref WorldGlobal.SweepHitResult, true);
						this.PostProcessVolume.bEnabled = (this.PostProcessVolume.BlendWeight > 0f);
						this.PostProcessVolume.PostModify();
						if (blendWeight != 0f && this.PostProcessVolume.BlendWeight == 0f)
						{
							Action<bool> blendOutCallback = this.BlendOutCallback;
							this.BlendOutCallback = null;
							this.CurrentBlendStatus = SeamlessTravelPostProcess.EPostProcessBlendStatus.FullHide;
							if (blendOutCallback == null)
							{
								return;
							}
							blendOutCallback(true);
						}
					}
					else
					{
						this.PostProcessVolume.BlendWeight = Singleton<MathUtils>.Instance.Clamp(blendWeight + delta / this.BlendInTimeMs, 0f, 1f);
						this.PostProcessVolume.D_K2_SetActorLocation(this.ActorComp.ActorLocation, false, ref WorldGlobal.SweepHitResult, true);
						this.PostProcessVolume.bEnabled = (this.PostProcessVolume.BlendWeight > 0f);
						this.PostProcessVolume.PostModify();
						if (blendWeight != 1f && this.PostProcessVolume.BlendWeight == 1f)
						{
							Action<bool> blendInCallback = this.BlendInCallback;
							this.BlendInCallback = null;
							this.CurrentBlendStatus = SeamlessTravelPostProcess.EPostProcessBlendStatus.FullShow;
							if (blendInCallback == null)
							{
								return;
							}
							blendInCallback(true);
							return;
						}
					}
					return;
				}
			}
		}

		// Token: 0x06034CFA RID: 216314 RVA: 0x00D41890 File Offset: 0x00D3FA90
		public void Destroy()
		{
			AKuroPostProcessVolume postProcessVolume = this.PostProcessVolume;
			if (postProcessVolume != null && postProcessVolume.IsValid())
			{
				this.PostProcessVolume.BlendWeight = 0f;
				this.PostProcessVolume.bUnbound = false;
				this.PostProcessVolume.bEnabled = false;
				this.PostProcessVolume.Priority = 0f;
				Singleton<ActorSystem>.Instance.Put("SeamlessTravelPostProcess.Destroy", this.PostProcessVolume, null);
			}
			this.PostProcessVolume = null;
			this.ActorComp = null;
			this.Context = null;
			this.CurrentBlendStatus = SeamlessTravelPostProcess.EPostProcessBlendStatus.FullHide;
			this.BlendInCallback = null;
			this.BlendOutCallback = null;
		}

		// Token: 0x06034CFB RID: 216315 RVA: 0x00D4192A File Offset: 0x00D3FB2A
		[NullableContext(1)]
		public void AppearEffect(Action<bool> callback)
		{
			if (this.IsInit)
			{
				AKuroPostProcessVolume postProcessVolume = this.PostProcessVolume;
				if (postProcessVolume != null && postProcessVolume.IsValid())
				{
					this.BlendInCallback = callback;
					this.CurrentBlendStatus = SeamlessTravelPostProcess.EPostProcessBlendStatus.BlendIn;
					return;
				}
			}
			callback(false);
		}

		// Token: 0x06034CFC RID: 216316 RVA: 0x00D41961 File Offset: 0x00D3FB61
		[NullableContext(1)]
		public void DisappearEffect(Action<bool> callback)
		{
			if (this.IsInit)
			{
				AKuroPostProcessVolume postProcessVolume = this.PostProcessVolume;
				if (postProcessVolume != null && postProcessVolume.IsValid())
				{
					this.BlendOutCallback = callback;
					this.CurrentBlendStatus = SeamlessTravelPostProcess.EPostProcessBlendStatus.BlendOut;
					return;
				}
			}
			callback(false);
		}

		// Token: 0x06034CFD RID: 216317 RVA: 0x00D41998 File Offset: 0x00D3FB98
		[NullableContext(1)]
		public TArray<AActor> GetSeamlessTravelActors(TArray<AActor> arr)
		{
			if (this.PostProcessVolume != null)
			{
				arr.Add(this.PostProcessVolume);
			}
			return arr;
		}

		// Token: 0x0401E6E9 RID: 124649
		private const int DEFAULT_TRANSITION_POSTPROCESS_PRIORITY = 9999;

		// Token: 0x0401E6EA RID: 124650
		private CharacterActorComponent ActorComp;

		// Token: 0x0401E6EB RID: 124651
		private SeamlessTravelContext Context;

		// Token: 0x0401E6EC RID: 124652
		private AKuroPostProcessVolume PostProcessVolume;

		// Token: 0x0401E6ED RID: 124653
		private string TransitionWeatherDaPath;

		// Token: 0x0401E6EE RID: 124654
		private bool IsInitInternal;

		// Token: 0x0401E6EF RID: 124655
		public SeamlessTravelPostProcess.EPostProcessBlendStatus CurrentBlendStatus;

		// Token: 0x0401E6F0 RID: 124656
		private float BlendInTimeMs;

		// Token: 0x0401E6F1 RID: 124657
		private float BlendOutTimeMs;

		// Token: 0x0401E6F2 RID: 124658
		private Action<bool> BlendInCallback;

		// Token: 0x0401E6F3 RID: 124659
		private Action<bool> BlendOutCallback;

		// Token: 0x0200AFD9 RID: 45017
		[NullableContext(0)]
		public enum EPostProcessBlendStatus
		{
			// Token: 0x0403690F RID: 223503
			FullHide,
			// Token: 0x04036910 RID: 223504
			FullShow,
			// Token: 0x04036911 RID: 223505
			BlendIn,
			// Token: 0x04036912 RID: 223506
			BlendOut
		}
	}
}
