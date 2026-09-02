using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render.Effect.ScreenEffectSystem
{
	// Token: 0x02004797 RID: 18327
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class ScreenEffectModel : ModelBase<ScreenEffectModel>
	{
		// Token: 0x0602F8F0 RID: 194800 RVA: 0x00B55391 File Offset: 0x00B53591
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			return true;
		}

		// Token: 0x0602F8F1 RID: 194801 RVA: 0x00B553B0 File Offset: 0x00B535B0
		[NullableContext(2)]
		public int PlayScreenEffect([Nullable(1)] string path, string memoryTag = null, CustomPromise playedPromise = null)
		{
			ScreenEffectModel.ScreenEffectHandle handle;
			if (!this.PathToHandleMap.TryGetValue(path, out handle))
			{
				handle = this.GetHandle();
				handle.Path = path;
				this.PathToHandleMap.Add(path, handle);
			}
			int handleIdGenerator = this.HandleIdGenerator;
			this.HandleIdGenerator = handleIdGenerator + 1;
			int num = handleIdGenerator;
			handle.HandleIds.Add(num);
			this.HandleMap.Add(num, handle);
			if (playedPromise != null)
			{
				if (handle.EffectData != null && !handle.WaitingRootInit)
				{
					playedPromise.SetResult();
				}
				else
				{
					handle.PlayedPromises.Add(playedPromise);
				}
			}
			if (handle.HandleIds.Count == 1)
			{
				handle.LoadResId = this.LoadAndPlayScreenEffect(path, memoryTag);
			}
			return num;
		}

		// Token: 0x0602F8F2 RID: 194802 RVA: 0x00B55458 File Offset: 0x00B53658
		public unsafe void PlayScreenEffectForce(string path, [Nullable(2)] string memoryTag = null)
		{
			ScreenEffectModel.ScreenEffectHandle screenEffectHandle;
			if (this.PathToHandleMap.TryGetValue(path, out screenEffectHandle) && screenEffectHandle.EffectData != null)
			{
				BP_ScreenEffectSystem_C instance = ScreenEffectSystem.GetInstance();
				BP_ScreenEffectPlayer_C bp_ScreenEffectPlayer_C = (instance != null) ? instance.Effects.Get(screenEffectHandle.EffectData) : null;
				if (bp_ScreenEffectPlayer_C != null && bp_ScreenEffectPlayer_C.IsValid() && !(bp_ScreenEffectPlayer_C.State == E_SE_PlayState.Over))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderEffect;
					ELogAuthor author = ELogAuthor.WRY;
					string message = "屏幕特效强制播放: 上次特效未结束";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("path", path);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("playerState", bp_ScreenEffectPlayer_C.State);
					instance2.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				this.EndScreenEffectByPath(path);
			}
			this.PlayScreenEffect(path, memoryTag, null);
		}

		// Token: 0x0602F8F3 RID: 194803 RVA: 0x00B55530 File Offset: 0x00B53730
		private void FlushPlayedPromises(ScreenEffectModel.ScreenEffectHandle handle)
		{
			if (handle.PlayedPromises.Count == 0)
			{
				return;
			}
			List<CustomPromise> playedPromises = handle.PlayedPromises;
			handle.PlayedPromises = new List<CustomPromise>();
			foreach (CustomPromise customPromise in playedPromises)
			{
				customPromise.SetResult();
			}
		}

		// Token: 0x0602F8F4 RID: 194804 RVA: 0x00B5559C File Offset: 0x00B5379C
		private int LoadAndPlayScreenEffect(string path, [Nullable(2)] string memoryTag = null)
		{
			return Singleton<ResourceSystem>.Instance.LoadAsync<EffectScreenPlayData_C>(path, delegate([Nullable(2)] EffectScreenPlayData_C resObj, string _)
			{
				ScreenEffectModel.ScreenEffectHandle screenEffectHandle;
				if (!this.PathToHandleMap.TryGetValue(path, out screenEffectHandle) || screenEffectHandle.HandleIds.Count == 0 || resObj == null)
				{
					return;
				}
				screenEffectHandle.EffectData = resObj;
				screenEffectHandle.RootType = resObj.RootType;
				if (resObj.bUsedForSequence)
				{
					screenEffectHandle.RootType = E_SE_RootType.Plot;
				}
				else
				{
					switch (resObj.RootType)
					{
					case E_SE_RootType.Fight:
						if (!this.FightRootInited)
						{
							screenEffectHandle.WaitingRootInit = true;
							return;
						}
						break;
					case E_SE_RootType.General:
						if (!this.GeneralRootInited)
						{
							screenEffectHandle.WaitingRootInit = true;
							return;
						}
						break;
					case E_SE_RootType.CoverLoading:
						if (!this.CoverLoadingRootInited)
						{
							screenEffectHandle.WaitingRootInit = true;
							return;
						}
						break;
					}
				}
				ScreenEffectSystem.GetInstance().PlayScreenEffect(resObj);
				this.FlushPlayedPromises(screenEffectHandle);
			}, ResourceSystem.EResourceLoadPriority.Ui, memoryTag ?? "js_undefined");
		}

		// Token: 0x0602F8F5 RID: 194805 RVA: 0x00B555E8 File Offset: 0x00B537E8
		public void EndScreenEffectByPath(string path)
		{
			ScreenEffectModel.ScreenEffectHandle screenEffectHandle;
			if (!this.PathToHandleMap.TryGetValue(path, out screenEffectHandle))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderEffect;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "调用停止镜头特效接口时找不到path对应的Handle，尝试直接获取已加载的PlayData来停止特效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				EffectScreenPlayData_C loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<EffectScreenPlayData_C>(path);
				if (loadedAsset != null)
				{
					ScreenEffectSystem.GetInstance().EndScreenEffect(loadedAsset);
				}
				return;
			}
			this.PathToHandleMap.Remove(screenEffectHandle.Path);
			this.ClearEffect(screenEffectHandle);
		}

		// Token: 0x0602F8F6 RID: 194806 RVA: 0x00B55660 File Offset: 0x00B53860
		public int? ChangeScreenEffectState(string path, int state, bool playIfAbsent = false)
		{
			ScreenEffectModel.ScreenEffectHandle screenEffectHandle;
			if (this.PathToHandleMap.TryGetValue(path, out screenEffectHandle) && screenEffectHandle.EffectData != null)
			{
				BP_ScreenEffectSystem_C instance = ScreenEffectSystem.GetInstance();
				if (instance != null)
				{
					instance.SetEffectExtraState(screenEffectHandle.EffectData, state);
				}
				return null;
			}
			if (playIfAbsent)
			{
				CustomPromise playedPromise = new CustomPromise();
				int num = this.PlayScreenEffect(path, null, playedPromise);
				this.ChangeScreenEffectStateAfterPlayed(playedPromise, num, path, state).Forget();
				return new int?(num);
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "ChangeScreenEffectState: 找不到目标特效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", path);
			instance2.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x0602F8F7 RID: 194807 RVA: 0x00B55704 File Offset: 0x00B53904
		private UniTask ChangeScreenEffectStateAfterPlayed(CustomPromise playedPromise, int handleId, string path, int state)
		{
			ScreenEffectModel.<ChangeScreenEffectStateAfterPlayed>d__15 <ChangeScreenEffectStateAfterPlayed>d__;
			<ChangeScreenEffectStateAfterPlayed>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChangeScreenEffectStateAfterPlayed>d__.<>4__this = this;
			<ChangeScreenEffectStateAfterPlayed>d__.playedPromise = playedPromise;
			<ChangeScreenEffectStateAfterPlayed>d__.handleId = handleId;
			<ChangeScreenEffectStateAfterPlayed>d__.path = path;
			<ChangeScreenEffectStateAfterPlayed>d__.state = state;
			<ChangeScreenEffectStateAfterPlayed>d__.<>1__state = -1;
			<ChangeScreenEffectStateAfterPlayed>d__.<>t__builder.Start<ScreenEffectModel.<ChangeScreenEffectStateAfterPlayed>d__15>(ref <ChangeScreenEffectStateAfterPlayed>d__);
			return <ChangeScreenEffectStateAfterPlayed>d__.<>t__builder.Task;
		}

		// Token: 0x0602F8F8 RID: 194808 RVA: 0x00B55768 File Offset: 0x00B53968
		public void EndScreenEffect(int handleId)
		{
			ScreenEffectModel.ScreenEffectHandle screenEffectHandle;
			if (!this.HandleMap.TryGetValue(handleId, out screenEffectHandle))
			{
				return;
			}
			if (!screenEffectHandle.HandleIds.Contains(handleId))
			{
				return;
			}
			screenEffectHandle.HandleIds.Remove(handleId);
			this.HandleMap.Remove(handleId);
			if (screenEffectHandle.HandleIds.Count == 0)
			{
				this.PathToHandleMap.Remove(screenEffectHandle.Path);
				this.ClearEffect(screenEffectHandle);
			}
		}

		// Token: 0x0602F8F9 RID: 194809 RVA: 0x00B557D8 File Offset: 0x00B539D8
		public bool TrySetScreenEffectAlpha(int handleId, float alpha)
		{
			ScreenEffectModel.ScreenEffectHandle screenEffectHandle;
			if (!this.HandleMap.TryGetValue(handleId, out screenEffectHandle))
			{
				return false;
			}
			if (!screenEffectHandle.HandleIds.Contains(handleId))
			{
				return false;
			}
			if (screenEffectHandle.EffectData == null)
			{
				return true;
			}
			BP_ScreenEffectSystem_C instance = ScreenEffectSystem.GetInstance();
			BP_ScreenEffectPlayer_C bp_ScreenEffectPlayer_C = (instance != null) ? instance.Effects.Get(screenEffectHandle.EffectData) : null;
			if (bp_ScreenEffectPlayer_C == null || !bp_ScreenEffectPlayer_C.IsValid())
			{
				return true;
			}
			bp_ScreenEffectPlayer_C.Alpha = alpha;
			bp_ScreenEffectPlayer_C.UpdateComponentsAlpha();
			bp_ScreenEffectPlayer_C.BeforeStart();
			return true;
		}

		// Token: 0x0602F8FA RID: 194810 RVA: 0x00B5584F File Offset: 0x00B53A4F
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			this.HandleIdGenerator = 0;
			this.ClearAllEffect();
			return true;
		}

		// Token: 0x0602F8FB RID: 194811 RVA: 0x00B5587C File Offset: 0x00B53A7C
		private void ClearAllEffect()
		{
			foreach (ScreenEffectModel.ScreenEffectHandle handle in this.PathToHandleMap.Values)
			{
				this.ClearEffect(handle);
			}
			this.PathToHandleMap.Clear();
			this.HandleMap.Clear();
		}

		// Token: 0x0602F8FC RID: 194812 RVA: 0x00B558EC File Offset: 0x00B53AEC
		private void ClearEffect(ScreenEffectModel.ScreenEffectHandle handle)
		{
			foreach (int key in handle.HandleIds)
			{
				this.HandleMap.Remove(key);
			}
			handle.HandleIds.Clear();
			this.FlushPlayedPromises(handle);
			if (handle.EffectData != null)
			{
				ScreenEffectSystem.GetInstance().EndScreenEffect(handle.EffectData);
				handle.EffectData = null;
			}
			if (handle.LoadResId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(handle.LoadResId);
				handle.LoadResId = -1;
			}
			handle.Path = null;
			handle.RootType = E_SE_RootType.Fight;
			handle.WaitingRootInit = false;
			this.ReleaseHandle(handle);
		}

		// Token: 0x0602F8FD RID: 194813 RVA: 0x00B559B4 File Offset: 0x00B53BB4
		public void SetFightRootInited(bool isInit)
		{
			if (this.FightRootInited == isInit)
			{
				return;
			}
			this.FightRootInited = isInit;
			if (isInit)
			{
				foreach (ScreenEffectModel.ScreenEffectHandle screenEffectHandle in this.PathToHandleMap.Values)
				{
					if (screenEffectHandle.WaitingRootInit && screenEffectHandle.RootType == E_SE_RootType.Fight)
					{
						screenEffectHandle.WaitingRootInit = false;
						if (screenEffectHandle.EffectData != null)
						{
							ScreenEffectSystem.GetInstance().PlayScreenEffect(screenEffectHandle.EffectData);
							this.FlushPlayedPromises(screenEffectHandle);
						}
					}
				}
			}
		}

		// Token: 0x0602F8FE RID: 194814 RVA: 0x00B55A50 File Offset: 0x00B53C50
		public void SetGeneralRootInited(bool isInit)
		{
			if (this.GeneralRootInited == isInit)
			{
				return;
			}
			this.GeneralRootInited = isInit;
			if (isInit)
			{
				foreach (ScreenEffectModel.ScreenEffectHandle screenEffectHandle in this.PathToHandleMap.Values)
				{
					if (screenEffectHandle.WaitingRootInit && screenEffectHandle.RootType == E_SE_RootType.General)
					{
						screenEffectHandle.WaitingRootInit = false;
						if (screenEffectHandle.EffectData != null)
						{
							ScreenEffectSystem.GetInstance().PlayScreenEffect(screenEffectHandle.EffectData);
							this.FlushPlayedPromises(screenEffectHandle);
						}
					}
				}
			}
		}

		// Token: 0x0602F8FF RID: 194815 RVA: 0x00B55AEC File Offset: 0x00B53CEC
		public void SetCoverLoadingRootInited(bool isInit)
		{
			if (this.CoverLoadingRootInited == isInit)
			{
				return;
			}
			this.CoverLoadingRootInited = isInit;
			if (isInit)
			{
				foreach (ScreenEffectModel.ScreenEffectHandle screenEffectHandle in this.PathToHandleMap.Values)
				{
					if (screenEffectHandle.WaitingRootInit && screenEffectHandle.RootType == E_SE_RootType.CoverLoading)
					{
						screenEffectHandle.WaitingRootInit = false;
						if (screenEffectHandle.EffectData != null)
						{
							ScreenEffectSystem.GetInstance().PlayScreenEffect(screenEffectHandle.EffectData);
							this.FlushPlayedPromises(screenEffectHandle);
						}
					}
				}
			}
		}

		// Token: 0x0602F900 RID: 194816 RVA: 0x00B55B88 File Offset: 0x00B53D88
		public ScreenEffectModel.ScreenEffectHandle GetHandle()
		{
			ScreenEffectModel.ScreenEffectHandle result;
			if (this.HandlePool.TryPop(out result))
			{
				return result;
			}
			return new ScreenEffectModel.ScreenEffectHandle();
		}

		// Token: 0x0602F901 RID: 194817 RVA: 0x00B55BAC File Offset: 0x00B53DAC
		public void ReleaseHandle(ScreenEffectModel.ScreenEffectHandle target)
		{
			if (this.HandlePool.Contains(target))
			{
				Singleton<Log>.Instance.Warn(ELogModule.RenderEffect, ELogAuthor.CFT, "镜头特效Handel重复入池", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.HandlePool.Add(target);
		}

		// Token: 0x0602F902 RID: 194818 RVA: 0x00B55BF0 File Offset: 0x00B53DF0
		private void OnWorldDone()
		{
			this.LoadScreenEffectRoot();
			this.LoadCoverLoadingRoot();
		}

		// Token: 0x0602F903 RID: 194819 RVA: 0x00B55C00 File Offset: 0x00B53E00
		private void LoadScreenEffectRoot()
		{
			AUIContainerActor auicontainerActor = null;
			BP_ScreenEffectSystem_C instance = ScreenEffectSystem.GetInstance();
			UUIItem layerRootUiItem = Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.ScreenEffect);
			if (instance == null || !instance.IsValid() || layerRootUiItem == null)
			{
				return;
			}
			instance.GetScreenEffectGeneralRoot(ref auicontainerActor);
			if (auicontainerActor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCore, ELogAuthor.ZYL, "ScreenEffectUiRoot获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (auicontainerActor == this.ScreenEffectGeneralRoot)
			{
				return;
			}
			AUIContainerActor screenEffectGeneralRoot = this.ScreenEffectGeneralRoot;
			if (screenEffectGeneralRoot != null && screenEffectGeneralRoot.IsValid())
			{
				Singleton<Log>.Instance.Info(ELogModule.UiCore, ELogAuthor.ZYL, "ScreenEffectUiRoot被替换", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ScreenEffectGeneralRoot.OnPreDestroyed.Remove(new Action<AActor>(this.OnScreenEffectGeneralRootDestroyed));
				AUIContainerActor screenEffectGeneralRoot2 = this.ScreenEffectGeneralRoot;
				if (screenEffectGeneralRoot2 != null)
				{
					screenEffectGeneralRoot2.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
				}
				this.SetGeneralRootInited(false);
			}
			this.ScreenEffectGeneralRoot = auicontainerActor;
			this.ScreenEffectGeneralRoot.OnPreDestroyed.Add(new Action<AActor>(this.OnScreenEffectGeneralRootDestroyed));
			this.ScreenEffectGeneralRoot.K2_AttachRootComponentTo(layerRootUiItem, default(FName), EAttachLocation.KeepRelativeOffset, true);
			UKuroStaticLibrary.SetActorPermanent(instance, true, false);
			UKuroStaticLibrary.SetActorPermanent(auicontainerActor, true, false);
			this.SetGeneralRootInited(true);
		}

		// Token: 0x0602F904 RID: 194820 RVA: 0x00B55D24 File Offset: 0x00B53F24
		[NullableContext(2)]
		private void OnScreenEffectGeneralRootDestroyed(AActor _)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiCore, ELogAuthor.ZYL, "ScreenEffectUiRoot被销毁", default(ReadOnlySpan<ValueTuple<string, object>>));
			AUIContainerActor screenEffectGeneralRoot = this.ScreenEffectGeneralRoot;
			if (screenEffectGeneralRoot != null)
			{
				screenEffectGeneralRoot.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
			}
			this.SetGeneralRootInited(false);
		}

		// Token: 0x0602F905 RID: 194821 RVA: 0x00B55D68 File Offset: 0x00B53F68
		public bool GetIsGeneralScreenEffectActive()
		{
			using (Dictionary<string, ScreenEffectModel.ScreenEffectHandle>.ValueCollection.Enumerator enumerator = this.PathToHandleMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.RootType == E_SE_RootType.General)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0602F906 RID: 194822 RVA: 0x00B55DC8 File Offset: 0x00B53FC8
		private void LoadCoverLoadingRoot()
		{
			AUIContainerActor auicontainerActor = null;
			BP_ScreenEffectSystem_C instance = ScreenEffectSystem.GetInstance();
			UUIItem floatUnit = Singleton<UiLayer>.Instance.GetFloatUnit(ELayerType.Loading, 1);
			if (instance == null || !instance.IsValid() || floatUnit == null)
			{
				return;
			}
			instance.GetScreenEffectCoverLoadingRoot(ref auicontainerActor);
			if (auicontainerActor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCore, ELogAuthor.ZYL, "CoverLoadingUiRoot获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (auicontainerActor == this.ScreenEffectCoverLoadingRoot)
			{
				return;
			}
			AUIContainerActor screenEffectCoverLoadingRoot = this.ScreenEffectCoverLoadingRoot;
			if (screenEffectCoverLoadingRoot != null && screenEffectCoverLoadingRoot.IsValid())
			{
				Singleton<Log>.Instance.Info(ELogModule.UiCore, ELogAuthor.ZYL, "ScreenEffectUiRoot被替换", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ScreenEffectCoverLoadingRoot.OnDestroyed.Remove(new Action<AActor>(this.OnScreenEffectCoverLoadingRootDestroyed));
				AUIContainerActor screenEffectCoverLoadingRoot2 = this.ScreenEffectCoverLoadingRoot;
				if (screenEffectCoverLoadingRoot2 != null)
				{
					screenEffectCoverLoadingRoot2.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
				}
				this.SetCoverLoadingRootInited(false);
			}
			this.ScreenEffectCoverLoadingRoot = auicontainerActor;
			this.ScreenEffectCoverLoadingRoot.OnDestroyed.Add(new Action<AActor>(this.OnScreenEffectCoverLoadingRootDestroyed));
			this.ScreenEffectCoverLoadingRoot.K2_AttachRootComponentTo(floatUnit, default(FName), EAttachLocation.KeepRelativeOffset, true);
			UKuroStaticLibrary.SetActorPermanent(instance, true, false);
			UKuroStaticLibrary.SetActorPermanent(auicontainerActor, true, false);
			this.SetCoverLoadingRootInited(true);
		}

		// Token: 0x0602F907 RID: 194823 RVA: 0x00B55EF0 File Offset: 0x00B540F0
		[NullableContext(2)]
		private void OnScreenEffectCoverLoadingRootDestroyed(AActor _)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiCore, ELogAuthor.ZYL, "CoverLoadingUiRoot被销毁", default(ReadOnlySpan<ValueTuple<string, object>>));
			AUIContainerActor screenEffectCoverLoadingRoot = this.ScreenEffectCoverLoadingRoot;
			if (screenEffectCoverLoadingRoot != null)
			{
				screenEffectCoverLoadingRoot.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
			}
			this.SetCoverLoadingRootInited(false);
		}

		// Token: 0x0401B335 RID: 111413
		public int HandleIdGenerator = 1;

		// Token: 0x0401B336 RID: 111414
		public Dictionary<int, ScreenEffectModel.ScreenEffectHandle> HandleMap = new Dictionary<int, ScreenEffectModel.ScreenEffectHandle>();

		// Token: 0x0401B337 RID: 111415
		public Dictionary<string, ScreenEffectModel.ScreenEffectHandle> PathToHandleMap = new Dictionary<string, ScreenEffectModel.ScreenEffectHandle>();

		// Token: 0x0401B338 RID: 111416
		public List<ScreenEffectModel.ScreenEffectHandle> HandlePool = new List<ScreenEffectModel.ScreenEffectHandle>();

		// Token: 0x0401B339 RID: 111417
		public bool FightRootInited;

		// Token: 0x0401B33A RID: 111418
		public bool GeneralRootInited;

		// Token: 0x0401B33B RID: 111419
		public bool CoverLoadingRootInited;

		// Token: 0x0401B33C RID: 111420
		[Nullable(2)]
		private AUIContainerActor ScreenEffectGeneralRoot;

		// Token: 0x0401B33D RID: 111421
		[Nullable(2)]
		private AUIContainerActor ScreenEffectCoverLoadingRoot;

		// Token: 0x0200A88D RID: 43149
		[Nullable(0)]
		public class ScreenEffectHandle
		{
			// Token: 0x040344CD RID: 214221
			public HashSet<int> HandleIds = new HashSet<int>();

			// Token: 0x040344CE RID: 214222
			[Nullable(2)]
			public string Path;

			// Token: 0x040344CF RID: 214223
			[Nullable(2)]
			public EffectScreenPlayData_C EffectData;

			// Token: 0x040344D0 RID: 214224
			public int LoadResId = -1;

			// Token: 0x040344D1 RID: 214225
			public bool WaitingRootInit;

			// Token: 0x040344D2 RID: 214226
			public E_SE_RootType RootType;

			// Token: 0x040344D3 RID: 214227
			public List<CustomPromise> PlayedPromises = new List<CustomPromise>();
		}
	}
}
