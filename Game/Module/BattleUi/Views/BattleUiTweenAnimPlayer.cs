using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FDD RID: 24541
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiTweenAnimPlayer
	{
		// Token: 0x0603DC07 RID: 252935 RVA: 0x00FBB294 File Offset: 0x00FB9494
		public void Clear(bool stopAll = false)
		{
			if (stopAll)
			{
				this.StopAll();
			}
			this.TweenAnimMap.Clear();
			foreach (KeyValuePair<ULGUIPlayTween, FLGUIDelegateHandleWrapper> keyValuePair in this.TweenDelegateWrapperMap)
			{
				ULGUIPlayTween ulguiplayTween;
				FLGUIDelegateHandleWrapper flguidelegateHandleWrapper;
				keyValuePair.Deconstruct(out ulguiplayTween, out flguidelegateHandleWrapper);
				ULGUIPlayTween ulguiplayTween2 = ulguiplayTween;
				FLGUIDelegateHandleWrapper flguidelegateHandleWrapper2 = flguidelegateHandleWrapper;
				ulguiplayTween2.UnregisterOnComplete(flguidelegateHandleWrapper2);
			}
			this.TweenCallbackMap.Clear();
			foreach (Action callBack in this.TweenCallbackMap.Values)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(callBack);
			}
			this.TweenCallbackMap.Clear();
		}

		// Token: 0x0603DC08 RID: 252936 RVA: 0x00FBB368 File Offset: 0x00FB9568
		public void InitTweenAnim(int componentType, UUIItem item, bool stopOnInited = false)
		{
			if (item == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "BattleUiTweenAnimPlayer.InitTweenAnim : 参数item不能为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			List<ULGUIPlayTweenComponent> list = new List<ULGUIPlayTweenComponent>();
			TArray<UActorComponent> tarray = item.GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				list.Add(tarray.Get(i) as ULGUIPlayTweenComponent);
			}
			this.TweenAnimMap[componentType] = list;
			if (stopOnInited)
			{
				this.StopTweenAnim(componentType);
			}
		}

		// Token: 0x0603DC09 RID: 252937 RVA: 0x00FBB3F4 File Offset: 0x00FB95F4
		public void PlayTweenAnim(int componentType)
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					ulguiplayTweenComponent.Play();
				}
			}
		}

		// Token: 0x0603DC0A RID: 252938 RVA: 0x00FBB450 File Offset: 0x00FB9650
		public UniTask PlayTweenAnimAsync(int componentType)
		{
			BattleUiTweenAnimPlayer.<PlayTweenAnimAsync>d__7 <PlayTweenAnimAsync>d__;
			<PlayTweenAnimAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTweenAnimAsync>d__.<>4__this = this;
			<PlayTweenAnimAsync>d__.componentType = componentType;
			<PlayTweenAnimAsync>d__.<>1__state = -1;
			<PlayTweenAnimAsync>d__.<>t__builder.Start<BattleUiTweenAnimPlayer.<PlayTweenAnimAsync>d__7>(ref <PlayTweenAnimAsync>d__);
			return <PlayTweenAnimAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DC0B RID: 252939 RVA: 0x00FBB49C File Offset: 0x00FB969C
		public void StopTweenAnim(int componentType)
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					ulguiplayTweenComponent.Stop();
				}
			}
		}

		// Token: 0x0603DC0C RID: 252940 RVA: 0x00FBB4F8 File Offset: 0x00FB96F8
		public void StopAll()
		{
			foreach (List<ULGUIPlayTweenComponent> list in this.TweenAnimMap.Values)
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					ulguiplayTweenComponent.Stop();
				}
			}
		}

		// Token: 0x0603DC0D RID: 252941 RVA: 0x00FBB584 File Offset: 0x00FB9784
		public void StopAllBut(List<int> exception)
		{
			foreach (KeyValuePair<int, List<ULGUIPlayTweenComponent>> keyValuePair in this.TweenAnimMap)
			{
				if (exception == null || !exception.Contains(keyValuePair.Key))
				{
					foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in keyValuePair.Value)
					{
						ulguiplayTweenComponent.Stop();
					}
				}
			}
		}

		// Token: 0x0603DC0E RID: 252942 RVA: 0x00FBB624 File Offset: 0x00FB9824
		public void Active(int componentType, bool bPlay)
		{
			if (bPlay)
			{
				this.PlayTweenAnim(componentType);
				return;
			}
			this.StopTweenAnim(componentType);
		}

		// Token: 0x0603DC0F RID: 252943 RVA: 0x00FBB638 File Offset: 0x00FB9838
		public bool CheckIsPlaying(int componentType)
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					UObject world = GlobalData.World;
					ULGUIPlayTween playTween = ulguiplayTweenComponent.GetPlayTween();
					if (ULTweenBPLibrary.IsTweening(world, (playTween != null) ? playTween.GetTweener() : null))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x0603DC10 RID: 252944 RVA: 0x00FBB6B4 File Offset: 0x00FB98B4
		public float GetDuration(int componentType)
		{
			float num = 0f;
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					ULGUIPlayTween playTween = ulguiplayTweenComponent.playTween;
					num = Math.Max((playTween != null) ? playTween.duration : 0f, num);
				}
			}
			return num;
		}

		// Token: 0x0603DC11 RID: 252945 RVA: 0x00FBB730 File Offset: 0x00FB9930
		public void SetTweenTimeScale(int componentType, float timeScale)
		{
			List<ULGUIPlayTweenComponent> list;
			if (!this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				return;
			}
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
			{
				ULGUIPlayTween playTween = ulguiplayTweenComponent.GetPlayTween();
				ULTweener ultweener = (playTween != null) ? playTween.GetTweener() : null;
				if (ultweener != null)
				{
					ultweener.SetSpeed(timeScale);
				}
			}
		}

		// Token: 0x0603DC12 RID: 252946 RVA: 0x00FBB7A8 File Offset: 0x00FB99A8
		public void RegisterOnComplete(int componentType, Action callback)
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				ULGUIPlayTween playTween = list[0].GetPlayTween();
				if (playTween != null)
				{
					FLGUIPlayTweenCompleteDynamicDelegate flguiplayTweenCompleteDynamicDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPlayTweenCompleteDynamicDelegate>(callback);
					FLGUIDelegateHandleWrapper value = playTween.RegisterOnComplete(flguiplayTweenCompleteDynamicDelegate);
					this.TweenCallbackMap.Add(componentType, callback);
					this.TweenDelegateWrapperMap.Add(playTween, value);
				}
			}
		}

		// Token: 0x04022A4B RID: 141899
		protected Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();

		// Token: 0x04022A4C RID: 141900
		protected Dictionary<int, Action> TweenCallbackMap = new Dictionary<int, Action>();

		// Token: 0x04022A4D RID: 141901
		protected Dictionary<ULGUIPlayTween, FLGUIDelegateHandleWrapper> TweenDelegateWrapperMap = new Dictionary<ULGUIPlayTween, FLGUIDelegateHandleWrapper>();

		// Token: 0x04022A4E RID: 141902
		private const bool TsDebugLog = false;
	}
}
