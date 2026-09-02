using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A32 RID: 18994
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class SceneUiController : ControllerBase<SceneUiController>
	{
		// Token: 0x06031A32 RID: 203314 RVA: 0x00C5DD98 File Offset: 0x00C5BF98
		protected override bool OnInit()
		{
			Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.PostUpdateTick), "SceneUiController", ETickingGroup.TG_PostUpdateWork, true, 0, false);
			this.TickerId = ((ticker != null) ? new int?(ticker.Id) : null);
			return true;
		}

		// Token: 0x06031A33 RID: 203315 RVA: 0x00C5DDE4 File Offset: 0x00C5BFE4
		protected override bool OnLeaveLevel()
		{
			this.Unsubscribe();
			this.ClearAll();
			return true;
		}

		// Token: 0x06031A34 RID: 203316 RVA: 0x00C5DDF3 File Offset: 0x00C5BFF3
		protected override bool OnClear()
		{
			this.Unsubscribe();
			this.ClearAll();
			if (this.TickerId != null)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickerId.Value);
				this.TickerId = null;
			}
			return true;
		}

		// Token: 0x06031A35 RID: 203317 RVA: 0x00C5DE31 File Offset: 0x00C5C031
		private void PostUpdateTick(float delta)
		{
			this.EnsureSubscribed();
			this.UpdateAllFacing();
		}

		// Token: 0x06031A36 RID: 203318 RVA: 0x00C5DE40 File Offset: 0x00C5C040
		private void EnsureSubscribed()
		{
			if (this.SubscribedSubsystem != null && this.SubscribedSubsystem.IsValid())
			{
				return;
			}
			if (this.SubscribedSubsystem != null)
			{
				this.SubscribedSubsystem = null;
				this.ClearAll();
			}
			UWorld world = GlobalData.World;
			if (world == null || !world.IsValid())
			{
				return;
			}
			USceneUiAnchorSubsystem usceneUiAnchorSubsystem = USubsystemBlueprintLibrary.GetWorldSubsystem(world, USceneUiAnchorSubsystem.StaticClass()) as USceneUiAnchorSubsystem;
			if (usceneUiAnchorSubsystem == null || !usceneUiAnchorSubsystem.IsValid())
			{
				return;
			}
			usceneUiAnchorSubsystem.OnPreloadRequest.Add(new Action<ASceneUiAnchorActor, string>(this.OnPreloadRequest));
			usceneUiAnchorSubsystem.OnOpenRequest.Add(new Action<ASceneUiAnchorActor, string, string>(this.OnOpenRequest));
			usceneUiAnchorSubsystem.OnOpenWithMapRequest.Add(new Action<ASceneUiAnchorActor, string>(this.OnOpenWithMapRequest));
			usceneUiAnchorSubsystem.OnCloseRequest.Add(new Action<ASceneUiAnchorActor>(this.OnCloseRequest));
			usceneUiAnchorSubsystem.OnAnchorEndPlay.Add(new Action<ASceneUiAnchorActor>(this.OnAnchorEndPlay));
			this.SubscribedSubsystem = usceneUiAnchorSubsystem;
			Singleton<Log>.Instance.Info(ELogModule.Scene3dUi, ELogAuthor.HYF, "[SceneUiController]已订阅SceneUiAnchorSubsystem", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06031A37 RID: 203319 RVA: 0x00C5DF48 File Offset: 0x00C5C148
		private void Unsubscribe()
		{
			USceneUiAnchorSubsystem subscribedSubsystem = this.SubscribedSubsystem;
			this.SubscribedSubsystem = null;
			if (subscribedSubsystem == null || !subscribedSubsystem.IsValid())
			{
				return;
			}
			subscribedSubsystem.OnPreloadRequest.Remove(new Action<ASceneUiAnchorActor, string>(this.OnPreloadRequest));
			subscribedSubsystem.OnOpenRequest.Remove(new Action<ASceneUiAnchorActor, string, string>(this.OnOpenRequest));
			subscribedSubsystem.OnOpenWithMapRequest.Remove(new Action<ASceneUiAnchorActor, string>(this.OnOpenWithMapRequest));
			subscribedSubsystem.OnCloseRequest.Remove(new Action<ASceneUiAnchorActor>(this.OnCloseRequest));
			subscribedSubsystem.OnAnchorEndPlay.Remove(new Action<ASceneUiAnchorActor>(this.OnAnchorEndPlay));
		}

		// Token: 0x06031A38 RID: 203320 RVA: 0x00C5DFE4 File Offset: 0x00C5C1E4
		private void ClearAll()
		{
			HashSet<SceneUiView>[] array = this.ClosingViewMap.Values.ToArray<HashSet<SceneUiView>>();
			SceneUiView[] array2;
			for (int i = 0; i < array.Length; i++)
			{
				array2 = array[i].ToArray<SceneUiView>();
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j].SkipPlayingSequence();
				}
			}
			this.ClosingViewMap.Clear();
			array2 = this.AnchorViewMap.Values.ToArray<SceneUiView>();
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].DestroyAsync().Forget<bool>();
			}
			this.AnchorViewMap.Clear();
			this.AnchorViewNameMap.Clear();
			this.CreatingAnchorSet.Clear();
		}

		// Token: 0x06031A39 RID: 203321 RVA: 0x00C5E087 File Offset: 0x00C5C287
		private void OnPreloadRequest([Nullable(2)] ASceneUiAnchorActor anchor, string viewName)
		{
			if (anchor == null)
			{
				return;
			}
			this.EnsureCreatedAsync(anchor, viewName, null).Forget<SceneUiView>();
		}

		// Token: 0x06031A3A RID: 203322 RVA: 0x00C5E09B File Offset: 0x00C5C29B
		private void OnOpenRequest([Nullable(2)] ASceneUiAnchorActor anchor, string viewName, string param)
		{
			if (anchor == null)
			{
				return;
			}
			this.OpenAsync(anchor, viewName, param).Forget();
		}

		// Token: 0x06031A3B RID: 203323 RVA: 0x00C5E0B0 File Offset: 0x00C5C2B0
		private void OnOpenWithMapRequest([Nullable(2)] ASceneUiAnchorActor anchor, string viewName)
		{
			if (anchor == null)
			{
				return;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			TMap<string, string> pendingOpenParams = anchor.PendingOpenParams;
			if (pendingOpenParams != null)
			{
				int maxIndex = pendingOpenParams.GetMaxIndex();
				for (int i = 0; i < maxIndex; i++)
				{
					if (pendingOpenParams.IsValidIndex(i))
					{
						string key = pendingOpenParams.GetKey(i);
						if (key != null)
						{
							dictionary[key] = (pendingOpenParams.Get(key) ?? "");
						}
					}
				}
			}
			this.OpenAsync(anchor, viewName, dictionary).Forget();
		}

		// Token: 0x06031A3C RID: 203324 RVA: 0x00C5E121 File Offset: 0x00C5C321
		[NullableContext(2)]
		private void OnCloseRequest(ASceneUiAnchorActor anchor)
		{
			if (anchor == null)
			{
				return;
			}
			SceneUiView valueOrDefault = this.AnchorViewMap.GetValueOrDefault(anchor);
			if (valueOrDefault == null)
			{
				return;
			}
			valueOrDefault.HideAsync().Forget<bool>();
		}

		// Token: 0x06031A3D RID: 203325 RVA: 0x00C5E142 File Offset: 0x00C5C342
		[NullableContext(2)]
		private void OnDestroyRequest(ASceneUiAnchorActor anchor)
		{
			if (anchor == null)
			{
				return;
			}
			this.DestroyAnchorUi(anchor, true);
		}

		// Token: 0x06031A3E RID: 203326 RVA: 0x00C5E150 File Offset: 0x00C5C350
		[NullableContext(2)]
		private void OnAnchorEndPlay(ASceneUiAnchorActor anchor)
		{
			if (anchor == null)
			{
				return;
			}
			this.DestroyAnchorUi(anchor, false);
		}

		// Token: 0x06031A3F RID: 203327 RVA: 0x00C5E160 File Offset: 0x00C5C360
		private UniTask OpenAsync(ASceneUiAnchorActor anchor, string viewName, [Nullable(2)] object param)
		{
			SceneUiController.<OpenAsync>d__19 <OpenAsync>d__;
			<OpenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenAsync>d__.<>4__this = this;
			<OpenAsync>d__.anchor = anchor;
			<OpenAsync>d__.viewName = viewName;
			<OpenAsync>d__.param = param;
			<OpenAsync>d__.<>1__state = -1;
			<OpenAsync>d__.<>t__builder.Start<SceneUiController.<OpenAsync>d__19>(ref <OpenAsync>d__);
			return <OpenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031A40 RID: 203328 RVA: 0x00C5E1BC File Offset: 0x00C5C3BC
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<SceneUiView> EnsureCreatedAsync(ASceneUiAnchorActor anchor, string viewName, [Nullable(2)] object param)
		{
			SceneUiController.<EnsureCreatedAsync>d__20 <EnsureCreatedAsync>d__;
			<EnsureCreatedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<SceneUiView>.Create();
			<EnsureCreatedAsync>d__.<>4__this = this;
			<EnsureCreatedAsync>d__.anchor = anchor;
			<EnsureCreatedAsync>d__.viewName = viewName;
			<EnsureCreatedAsync>d__.param = param;
			<EnsureCreatedAsync>d__.<>1__state = -1;
			<EnsureCreatedAsync>d__.<>t__builder.Start<SceneUiController.<EnsureCreatedAsync>d__20>(ref <EnsureCreatedAsync>d__);
			return <EnsureCreatedAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031A41 RID: 203329 RVA: 0x00C5E217 File Offset: 0x00C5C417
		private void DestroyAnchorUi(ASceneUiAnchorActor anchor, bool playCloseSequence)
		{
			this.DestroyAnchorUiAsync(anchor, playCloseSequence).Forget();
		}

		// Token: 0x06031A42 RID: 203330 RVA: 0x00C5E228 File Offset: 0x00C5C428
		private UniTask DestroyAnchorUiAsync(ASceneUiAnchorActor anchor, bool playCloseSequence)
		{
			SceneUiController.<DestroyAnchorUiAsync>d__22 <DestroyAnchorUiAsync>d__;
			<DestroyAnchorUiAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DestroyAnchorUiAsync>d__.<>4__this = this;
			<DestroyAnchorUiAsync>d__.anchor = anchor;
			<DestroyAnchorUiAsync>d__.playCloseSequence = playCloseSequence;
			<DestroyAnchorUiAsync>d__.<>1__state = -1;
			<DestroyAnchorUiAsync>d__.<>t__builder.Start<SceneUiController.<DestroyAnchorUiAsync>d__22>(ref <DestroyAnchorUiAsync>d__);
			return <DestroyAnchorUiAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031A43 RID: 203331 RVA: 0x00C5E27C File Offset: 0x00C5C47C
		private void SkipClosingViews(AActor anchor)
		{
			HashSet<SceneUiView> source;
			if (!this.ClosingViewMap.TryGetValue(anchor, out source))
			{
				return;
			}
			SceneUiView[] array = source.ToArray<SceneUiView>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SkipPlayingSequence();
			}
		}

		// Token: 0x06031A44 RID: 203332 RVA: 0x00C5E2B8 File Offset: 0x00C5C4B8
		private void UpdateAllFacing()
		{
			if (this.AnchorViewMap.Count == 0)
			{
				return;
			}
			CameraModelInstance mainModel = ControllerBase<CameraController>.Instance.MainModel;
			Rotator rotator = (mainModel != null) ? mainModel.CameraRotator : null;
			if (rotator == null)
			{
				return;
			}
			foreach (SceneUiView sceneUiView in this.AnchorViewMap.Values)
			{
				if (sceneUiView.FaceCamera)
				{
					sceneUiView.UpdateFacing(rotator.Yaw, rotator.Pitch);
				}
			}
		}

		// Token: 0x06031A45 RID: 203333 RVA: 0x00C5E34C File Offset: 0x00C5C54C
		private void UpdateViewFacing(SceneUiView view)
		{
			CameraModelInstance mainModel = ControllerBase<CameraController>.Instance.MainModel;
			Rotator rotator = (mainModel != null) ? mainModel.CameraRotator : null;
			if (rotator == null)
			{
				return;
			}
			if (view.FaceCamera)
			{
				view.UpdateFacing(rotator.Yaw, rotator.Pitch);
			}
		}

		// Token: 0x0401CE3D RID: 118333
		private readonly Dictionary<AActor, SceneUiView> AnchorViewMap = new Dictionary<AActor, SceneUiView>();

		// Token: 0x0401CE3E RID: 118334
		private readonly Dictionary<AActor, string> AnchorViewNameMap = new Dictionary<AActor, string>();

		// Token: 0x0401CE3F RID: 118335
		private readonly HashSet<AActor> CreatingAnchorSet = new HashSet<AActor>();

		// Token: 0x0401CE40 RID: 118336
		private readonly Dictionary<AActor, HashSet<SceneUiView>> ClosingViewMap = new Dictionary<AActor, HashSet<SceneUiView>>();

		// Token: 0x0401CE41 RID: 118337
		[Nullable(2)]
		private USceneUiAnchorSubsystem SubscribedSubsystem;

		// Token: 0x0401CE42 RID: 118338
		private int? TickerId;
	}
}
