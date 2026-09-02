using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Sequence.Struct;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053B7 RID: 21431
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotChildView : UiPanelBase
	{
		// Token: 0x06036A76 RID: 223862 RVA: 0x00DD890B File Offset: 0x00DD6B0B
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add<string, bool>(EEventName.PlayPlotSpine, new Action<string, bool>(this.PlaySpineAnimation));
		}

		// Token: 0x06036A77 RID: 223863 RVA: 0x00DD8929 File Offset: 0x00DD6B29
		protected override void OnAfterHide()
		{
			Singleton<EventSystem>.Instance.Remove<string, bool>(EEventName.PlayPlotSpine, new Action<string, bool>(this.PlaySpineAnimation));
		}

		// Token: 0x06036A78 RID: 223864 RVA: 0x00DD8947 File Offset: 0x00DD6B47
		protected override void OnBeforeDestroy()
		{
			this.Niagara.Clear();
			this.SpineMap.Clear();
			this.FrozenSpineMap.Clear();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.Clear();
		}

		// Token: 0x06036A79 RID: 223865 RVA: 0x00DD897C File Offset: 0x00DD6B7C
		public UniTask PreOpenAsync(UUIItem parentItem, string uiName)
		{
			PlotChildView.<PreOpenAsync>d__6 <PreOpenAsync>d__;
			<PreOpenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreOpenAsync>d__.<>4__this = this;
			<PreOpenAsync>d__.parentItem = parentItem;
			<PreOpenAsync>d__.uiName = uiName;
			<PreOpenAsync>d__.<>1__state = -1;
			<PreOpenAsync>d__.<>t__builder.Start<PlotChildView.<PreOpenAsync>d__6>(ref <PreOpenAsync>d__);
			return <PreOpenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036A7A RID: 223866 RVA: 0x00DD89D0 File Offset: 0x00DD6BD0
		public UniTask OpenAsync(UUIItem parentItem, string uiName, string spineName, bool isLoop = true, bool onlyOpen = false)
		{
			PlotChildView.<OpenAsync>d__7 <OpenAsync>d__;
			<OpenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenAsync>d__.<>4__this = this;
			<OpenAsync>d__.parentItem = parentItem;
			<OpenAsync>d__.uiName = uiName;
			<OpenAsync>d__.spineName = spineName;
			<OpenAsync>d__.isLoop = isLoop;
			<OpenAsync>d__.onlyOpen = onlyOpen;
			<OpenAsync>d__.<>1__state = -1;
			<OpenAsync>d__.<>t__builder.Start<PlotChildView.<OpenAsync>d__7>(ref <OpenAsync>d__);
			return <OpenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036A7B RID: 223867 RVA: 0x00DD8A40 File Offset: 0x00DD6C40
		public UniTask OpenAsyncInArray(UUIItem parentItem, string uiName, TArray<SpineThingsInfo> spineArray, bool onlyOpen = false)
		{
			PlotChildView.<OpenAsyncInArray>d__8 <OpenAsyncInArray>d__;
			<OpenAsyncInArray>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenAsyncInArray>d__.<>4__this = this;
			<OpenAsyncInArray>d__.parentItem = parentItem;
			<OpenAsyncInArray>d__.uiName = uiName;
			<OpenAsyncInArray>d__.spineArray = spineArray;
			<OpenAsyncInArray>d__.onlyOpen = onlyOpen;
			<OpenAsyncInArray>d__.<>1__state = -1;
			<OpenAsyncInArray>d__.<>t__builder.Start<PlotChildView.<OpenAsyncInArray>d__8>(ref <OpenAsyncInArray>d__);
			return <OpenAsyncInArray>d__.<>t__builder.Task;
		}

		// Token: 0x06036A7C RID: 223868 RVA: 0x00DD8AA4 File Offset: 0x00DD6CA4
		[NullableContext(0)]
		public UniTask<bool> PlayUiLevelSequence([Nullable(1)] string sequenceName)
		{
			PlotChildView.<PlayUiLevelSequence>d__9 <PlayUiLevelSequence>d__;
			<PlayUiLevelSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PlayUiLevelSequence>d__.<>4__this = this;
			<PlayUiLevelSequence>d__.sequenceName = sequenceName;
			<PlayUiLevelSequence>d__.<>1__state = -1;
			<PlayUiLevelSequence>d__.<>t__builder.Start<PlotChildView.<PlayUiLevelSequence>d__9>(ref <PlayUiLevelSequence>d__);
			return <PlayUiLevelSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06036A7D RID: 223869 RVA: 0x00DD8AF0 File Offset: 0x00DD6CF0
		public UniTask CloseAsync()
		{
			PlotChildView.<CloseAsync>d__10 <CloseAsync>d__;
			<CloseAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseAsync>d__.<>4__this = this;
			<CloseAsync>d__.<>1__state = -1;
			<CloseAsync>d__.<>t__builder.Start<PlotChildView.<CloseAsync>d__10>(ref <CloseAsync>d__);
			return <CloseAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036A7E RID: 223870 RVA: 0x00DD8B33 File Offset: 0x00DD6D33
		private void PlaySpineAnimation(string spineName, bool isLoop = true)
		{
			this.PlaySpineAnimation(spineName, isLoop, false, 0f);
		}

		// Token: 0x06036A7F RID: 223871 RVA: 0x00DD8B44 File Offset: 0x00DD6D44
		public unsafe void PlaySpineAnimation(string spineName, bool isLoop = true, bool freeze = false, float duration = 0f)
		{
			if (StringUtils.IsEmpty(spineName))
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.JYS;
			string message = "Ui预览图:播放Spine动画";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("spineName", spineName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isLoop", isLoop);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("freeze", freeze);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			TArray<UUIItem> tarray = new TArray<UUIItem>();
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.GetAllAttachUIChildren(ref tarray);
			}
			for (int i = 0; i < tarray.Num(); i++)
			{
				UUIItem uuiitem = tarray.Get(i);
				if (uuiitem is UUISpineRenderable)
				{
					AActor owner = uuiitem.GetOwner();
					UTrackEntry utrackEntry = (((owner != null) ? owner.GetComponentByClass(USpineSkeletonAnimationComponent.StaticClass()) : null) as USpineSkeletonAnimationComponent).SetAnimation(0, spineName, isLoop);
					if (utrackEntry != null)
					{
						utrackEntry.SetMixDuration(duration);
					}
					if (utrackEntry != null && utrackEntry.isValidAnimation() && !isLoop)
					{
						if (freeze)
						{
							utrackEntry.SetTimeScale(0f);
							this.FrozenSpineMap[utrackEntry] = utrackEntry.getAnimationDuration();
						}
						if (!this.SpineMap.ContainsKey(spineName))
						{
							this.SpineMap[spineName] = new HashSet<UTrackEntry>();
						}
						this.SpineMap[spineName].Add(utrackEntry);
						if (!freeze)
						{
							utrackEntry.AnimationComplete.Add(new Action<UTrackEntry>(this.OnAnimCompleted));
						}
					}
				}
			}
		}

		// Token: 0x06036A80 RID: 223872 RVA: 0x00DD8CD0 File Offset: 0x00DD6ED0
		[NullableContext(2)]
		private void OnAnimCompleted(UTrackEntry entry)
		{
			if (entry == null)
			{
				return;
			}
			entry.AnimationComplete.Clear();
			if (this.FrozenSpineMap.ContainsKey(entry))
			{
				return;
			}
			string text = null;
			foreach (KeyValuePair<string, HashSet<UTrackEntry>> keyValuePair in this.SpineMap)
			{
				string key = keyValuePair.Key;
				HashSet<UTrackEntry> value = keyValuePair.Value;
				if (value.Remove(entry) && value.Count == 0)
				{
					text = key;
				}
			}
			if (text != null)
			{
				this.SpineMap.Remove(text);
				Action<string> finiteSpineEndCallback = this.FiniteSpineEndCallback;
				if (finiteSpineEndCallback != null)
				{
					finiteSpineEndCallback(text);
				}
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.FiniteSpineEnd, text);
			}
		}

		// Token: 0x06036A81 RID: 223873 RVA: 0x00DD8D98 File Offset: 0x00DD6F98
		public void CloseSpineAnimation(string spineName, float blendOutTime = 0f)
		{
			if (StringUtils.IsEmpty(spineName))
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.JYS;
			string message = "Ui预览图:关闭Spine动画";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("spineName", spineName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.ClearSpineTrackCache(spineName);
			TArray<UUIItem> tarray = new TArray<UUIItem>();
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.GetAllAttachUIChildren(ref tarray);
			}
			for (int i = 0; i < tarray.Num(); i++)
			{
				UUIItem uuiitem = tarray.Get(i);
				if (uuiitem is UUISpineRenderable)
				{
					AActor owner = uuiitem.GetOwner();
					USpineSkeletonAnimationComponent uspineSkeletonAnimationComponent = ((owner != null) ? owner.GetComponentByClass(USpineSkeletonAnimationComponent.StaticClass()) : null) as USpineSkeletonAnimationComponent;
					if (uspineSkeletonAnimationComponent != null && uspineSkeletonAnimationComponent.HasAnimation(spineName))
					{
						uspineSkeletonAnimationComponent.SetEmptyAnimation(0, blendOutTime);
					}
				}
			}
		}

		// Token: 0x06036A82 RID: 223874 RVA: 0x00DD8E54 File Offset: 0x00DD7054
		private void ClearSpineTrackCache(string spineName)
		{
			HashSet<UTrackEntry> hashSet;
			if (!this.SpineMap.TryGetValue(spineName, out hashSet) || hashSet.Count == 0)
			{
				return;
			}
			foreach (UTrackEntry utrackEntry in hashSet)
			{
				utrackEntry.AnimationComplete.Clear();
				utrackEntry.SetTimeScale(1f);
				this.FrozenSpineMap.Remove(utrackEntry);
			}
			this.SpineMap.Remove(spineName);
		}

		// Token: 0x06036A83 RID: 223875 RVA: 0x00DD8EE4 File Offset: 0x00DD70E4
		public void UpdateFrozenSpine(float percentage)
		{
			foreach (KeyValuePair<UTrackEntry, float> keyValuePair in this.FrozenSpineMap)
			{
				UTrackEntry key = keyValuePair.Key;
				float value = keyValuePair.Value;
				if (key.isValidAnimation())
				{
					float num = value * percentage;
					if (key != null)
					{
						key.SetTrackTime(num);
					}
					if (key != null)
					{
						key.SetMixTime(num);
					}
				}
			}
		}

		// Token: 0x06036A84 RID: 223876 RVA: 0x00DD8F64 File Offset: 0x00DD7164
		public void UpdateFrozenSpineByName(string spineName, float percentage)
		{
			HashSet<UTrackEntry> hashSet;
			if (!this.SpineMap.TryGetValue(spineName, out hashSet))
			{
				return;
			}
			foreach (UTrackEntry utrackEntry in hashSet)
			{
				float num;
				if (this.FrozenSpineMap.TryGetValue(utrackEntry, out num) && utrackEntry.isValidAnimation())
				{
					float num2 = num * percentage;
					utrackEntry.SetTrackTime(num2);
					utrackEntry.SetMixTime(num2);
				}
			}
		}

		// Token: 0x06036A85 RID: 223877 RVA: 0x00DD8FEC File Offset: 0x00DD71EC
		public void ManualUpdateNiagara(List<string> varNames, float value)
		{
			foreach (string varName in varNames)
			{
				foreach (UUINiagara uuiniagara in this.Niagara)
				{
					uuiniagara.SetNiagaraVarFloat(varName, value);
				}
			}
		}

		// Token: 0x06036A86 RID: 223878 RVA: 0x00DD9074 File Offset: 0x00DD7274
		public void RestoreFreezeSpine(string spineName, bool isLoop = false)
		{
			HashSet<UTrackEntry> hashSet;
			if (!this.SpineMap.TryGetValue(spineName, out hashSet))
			{
				Action<string> finiteSpineEndCallback = this.FiniteSpineEndCallback;
				if (finiteSpineEndCallback != null)
				{
					finiteSpineEndCallback(spineName);
				}
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.FiniteSpineEnd, spineName);
				return;
			}
			HashSet<UTrackEntry> hashSet2 = new HashSet<UTrackEntry>();
			foreach (UTrackEntry utrackEntry in hashSet)
			{
				this.FrozenSpineMap.Remove(utrackEntry);
				if (!utrackEntry.isValidAnimation())
				{
					hashSet2.Add(utrackEntry);
				}
				else
				{
					utrackEntry.SetLoop(isLoop);
					utrackEntry.SetTimeScale(1f);
				}
			}
			foreach (UTrackEntry item in hashSet2)
			{
				hashSet.Remove(item);
			}
			if (hashSet.Count == 0)
			{
				this.SpineMap.Remove(spineName);
				Action<string> finiteSpineEndCallback2 = this.FiniteSpineEndCallback;
				if (finiteSpineEndCallback2 != null)
				{
					finiteSpineEndCallback2(spineName);
				}
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.FiniteSpineEnd, spineName);
			}
		}

		// Token: 0x06036A87 RID: 223879 RVA: 0x00DD91A0 File Offset: 0x00DD73A0
		public void SetUiParent(UUIItem parentItem)
		{
			if (this.ParentUiItem == parentItem)
			{
				return;
			}
			this.ParentUiItem = parentItem;
			UUIItem originalItem = this.GetOriginalItem();
			if (originalItem == null)
			{
				return;
			}
			originalItem.SetUIParent(parentItem, false);
		}

		// Token: 0x0401F7B8 RID: 128952
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401F7B9 RID: 128953
		private readonly List<UUINiagara> Niagara = new List<UUINiagara>();

		// Token: 0x0401F7BA RID: 128954
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<string> FiniteSpineEndCallback;

		// Token: 0x0401F7BB RID: 128955
		private readonly Dictionary<UTrackEntry, float> FrozenSpineMap = new Dictionary<UTrackEntry, float>();

		// Token: 0x0401F7BC RID: 128956
		private readonly Dictionary<string, HashSet<UTrackEntry>> SpineMap = new Dictionary<string, HashSet<UTrackEntry>>();
	}
}
