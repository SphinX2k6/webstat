using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C9D RID: 19613
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class SpecialPanelHandleBase
	{
		// Token: 0x060331B7 RID: 209335 RVA: 0x00CCCC83 File Offset: 0x00CCAE83
		public SpecialPanelHandleBase(string type)
		{
			this.Type = ESpecialPanelHandleDefine.FromString(type);
		}

		// Token: 0x060331B8 RID: 209336 RVA: 0x00CCCCC4 File Offset: 0x00CCAEC4
		protected unsafe void SetNavigationGroupDefaultListener(TsUiNavigationBehaviorListener listener, bool isForce = false)
		{
			NavigationGroup navigationGroup = this.GetNavigationGroup(listener.GroupName);
			if (navigationGroup == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "找不到导航组信息";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("导航组名字", listener.GroupName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("导航监听对象", listener.RootUIComp.Get().displayName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			if (navigationGroup.DefaultListener == null || isForce)
			{
				navigationGroup.DefaultListener = listener;
			}
		}

		// Token: 0x060331B9 RID: 209337 RVA: 0x00CCCD64 File Offset: 0x00CCAF64
		[return: Nullable(2)]
		public NavigationGroup GetNavigationGroup(string groupName)
		{
			if (string.IsNullOrEmpty(groupName))
			{
				return null;
			}
			NavigationGroup result;
			this.GroupMap.TryGetValue(groupName, out result);
			return result;
		}

		// Token: 0x060331BA RID: 209338 RVA: 0x00CCCD8B File Offset: 0x00CCAF8B
		public void Init()
		{
			this.OnInit();
		}

		// Token: 0x060331BB RID: 209339 RVA: 0x00CCCD93 File Offset: 0x00CCAF93
		public void SetGroupMap(Dictionary<string, NavigationGroup> groupMap)
		{
			this.GroupMap = groupMap;
		}

		// Token: 0x060331BC RID: 209340 RVA: 0x00CCCD9C File Offset: 0x00CCAF9C
		public void AddListener(TsUiNavigationBehaviorListener listener)
		{
			this.ListenerSet.Add(listener);
		}

		// Token: 0x060331BD RID: 209341 RVA: 0x00CCCDAB File Offset: 0x00CCAFAB
		public void DeleteListener(TsUiNavigationBehaviorListener listener)
		{
			this.ListenerSet.Remove(listener);
		}

		// Token: 0x060331BE RID: 209342 RVA: 0x00CCCDBC File Offset: 0x00CCAFBC
		public List<TsUiNavigationBehaviorListener> GetListenerListByTag(string tag)
		{
			List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in this.ListenerSet)
			{
				TArray<string> tagArray = tsUiNavigationBehaviorListener.TagArray;
				if (tagArray != null && tagArray.Contains(tag))
				{
					list.Add(tsUiNavigationBehaviorListener);
				}
			}
			return list;
		}

		// Token: 0x060331BF RID: 209343 RVA: 0x00CCCE2C File Offset: 0x00CCB02C
		public HashSet<TsUiNavigationBehaviorListener> GetListenerSet()
		{
			return this.ListenerSet;
		}

		// Token: 0x060331C0 RID: 209344 RVA: 0x00CCCE34 File Offset: 0x00CCB034
		public void SetDefaultNavigationListenerList(TArray<AActor> actorArray)
		{
			this.OnDefaultNavigationListenerList(actorArray);
		}

		// Token: 0x060331C1 RID: 209345 RVA: 0x00CCCE3D File Offset: 0x00CCB03D
		public void ReplaceDefaultNavigationListener(TsUiNavigationBehaviorListener listener, int index)
		{
			if (this.DefaultNavigationListener.Count <= index)
			{
				this.DefaultNavigationListener.Add(listener);
			}
			else
			{
				this.DefaultNavigationListener[index] = listener;
			}
			this.SetNavigationGroupDefaultListener(listener, false);
		}

		// Token: 0x060331C2 RID: 209346 RVA: 0x00CCCE70 File Offset: 0x00CCB070
		public void ForceReplaceDefaultNavigationListener(TsUiNavigationBehaviorListener listener, int index)
		{
			if (this.DefaultNavigationListener.Count <= index)
			{
				this.DefaultNavigationListener.Add(listener);
			}
			else
			{
				this.DefaultNavigationListener[index] = listener;
			}
			this.SetNavigationGroupDefaultListener(listener, true);
		}

		// Token: 0x060331C3 RID: 209347 RVA: 0x00CCCEA3 File Offset: 0x00CCB0A3
		public int GetDefaultListenerIndex(TsUiNavigationBehaviorListener listener)
		{
			return this.DefaultNavigationListener.IndexOf(listener);
		}

		// Token: 0x060331C4 RID: 209348 RVA: 0x00CCCEB1 File Offset: 0x00CCB0B1
		public List<TsUiNavigationBehaviorListener> GetSuitableNavigationListenerList(bool isDefault)
		{
			return this.OnGetSuitableNavigationListenerList(isDefault);
		}

		// Token: 0x060331C5 RID: 209349 RVA: 0x00CCCEBA File Offset: 0x00CCB0BA
		public void NotifyFindResult(FindNavigationResult result)
		{
			this.OnNotifyFindResult(result);
		}

		// Token: 0x060331C6 RID: 209350 RVA: 0x00CCCEC3 File Offset: 0x00CCB0C3
		public TsUiNavigationBehaviorListener GetLoopOrLayoutListener(TsUiNavigationBehaviorListener listener)
		{
			return this.OnGetLoopOrLayoutListener(listener);
		}

		// Token: 0x060331C7 RID: 209351 RVA: 0x00CCCECC File Offset: 0x00CCB0CC
		[return: Nullable(2)]
		public TsUiNavigationBehaviorListener GetSuitableListenerWithoutLayout(TsUiNavigationBehaviorListener listener)
		{
			NavigationGroup navigationGroup = this.GetNavigationGroup(listener.GroupName);
			if (navigationGroup == null)
			{
				return null;
			}
			return ControllerBase<UiNavigationNewController>.Instance.FindSuitableListenerWithoutLayout(navigationGroup);
		}

		// Token: 0x060331C8 RID: 209352 RVA: 0x00CCCEF8 File Offset: 0x00CCB0F8
		public void ResetGroupConfigMemory()
		{
			foreach (NavigationGroup navigationGroup in this.GroupMap.Values)
			{
				if (navigationGroup.SelectableMemory)
				{
					navigationGroup.LastSelectListener = null;
				}
			}
		}

		// Token: 0x060331C9 RID: 209353 RVA: 0x00CCCF58 File Offset: 0x00CCB158
		public void TryRemoveListener(TsUiNavigationBehaviorListener listener)
		{
			this.DeleteListener(listener);
			NavigationGroup navigationGroup = this.GetNavigationGroup(listener.GroupName);
			if (navigationGroup == null)
			{
				return;
			}
			int i = 0;
			int count = navigationGroup.ListenerList.Count;
			while (i < count)
			{
				if (navigationGroup.ListenerList[i].GetOwner() == listener.GetOwner())
				{
					navigationGroup.RemoveListenerByIndex(i);
					break;
				}
				i++;
			}
			if (navigationGroup.ListenerList.Count > 0)
			{
				int defaultListenerIndex = this.GetDefaultListenerIndex(listener);
				if (defaultListenerIndex != -1)
				{
					this.ReplaceDefaultNavigationListener(navigationGroup.ListenerList[0], defaultListenerIndex);
				}
				if (navigationGroup.DefaultListener != null && navigationGroup.DefaultListener == listener)
				{
					navigationGroup.DefaultListener = navigationGroup.ListenerList[0];
				}
			}
		}

		// Token: 0x060331CA RID: 209354 RVA: 0x00CCD007 File Offset: 0x00CCB207
		public bool IsFirstFindFromSubPanel()
		{
			return this.OnIsFirstFindFromSubPanel();
		}

		// Token: 0x060331CB RID: 209355 RVA: 0x00CCD00F File Offset: 0x00CCB20F
		public bool CanOverrideFindNavigation(ELGUINavigationDirection direction, TsUiNavigationBehaviorListener lastListener, [Nullable(2)] TsUiNavigationBehaviorListener targetListener)
		{
			return this.OnCanOverrideFindNavigation(direction, lastListener, targetListener);
		}

		// Token: 0x060331CC RID: 209356 RVA: 0x00CCD01A File Offset: 0x00CCB21A
		[NullableContext(2)]
		public TsUiNavigationBehaviorListener HandleOverrideFindNavigation(ELGUINavigationDirection direction, [Nullable(1)] TsUiNavigationBehaviorListener lastListener, TsUiNavigationBehaviorListener targetListener)
		{
			return this.OnHandleOverrideFindNavigation(direction, lastListener, targetListener);
		}

		// Token: 0x060331CD RID: 209357 RVA: 0x00CCD025 File Offset: 0x00CCB225
		[NullableContext(2)]
		public TsUiNavigationBehaviorListener HandleAfterFindOpposite(ELGUINavigationDirection direction, [Nullable(1)] TsUiNavigationBehaviorListener lastListener, TsUiNavigationBehaviorListener targetListener, bool isPositive)
		{
			return this.OnHandleAfterFindOpposite(direction, lastListener, targetListener, isPositive);
		}

		// Token: 0x060331CE RID: 209358 RVA: 0x00CCD032 File Offset: 0x00CCB232
		protected virtual List<TsUiNavigationBehaviorListener> OnGetSuitableNavigationListenerList(bool isDefault)
		{
			return this.DefaultNavigationListener;
		}

		// Token: 0x060331CF RID: 209359 RVA: 0x00CCD03C File Offset: 0x00CCB23C
		protected virtual void OnDefaultNavigationListenerList(TArray<AActor> actorArray)
		{
			List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
			for (int i = 0; i < actorArray.Num(); i++)
			{
				AActor aactor = actorArray.Get(i);
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = ((aactor != null) ? aactor.GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) : null) as TsUiNavigationBehaviorListener;
				list.Add(tsUiNavigationBehaviorListener);
				if (tsUiNavigationBehaviorListener != null)
				{
					this.SetNavigationGroupDefaultListener(tsUiNavigationBehaviorListener, false);
				}
			}
			this.DefaultNavigationListener = list;
		}

		// Token: 0x060331D0 RID: 209360 RVA: 0x00CCD09C File Offset: 0x00CCB29C
		[return: Nullable(2)]
		protected virtual TsUiNavigationBehaviorListener OnGetLoopOrLayoutListener(TsUiNavigationBehaviorListener listener)
		{
			NavigationGroup navigationGroup = this.GetNavigationGroup(listener.GroupName);
			if (navigationGroup == null)
			{
				return null;
			}
			return ControllerBase<UiNavigationNewController>.Instance.FindLoopOrDynListener(navigationGroup);
		}

		// Token: 0x060331D1 RID: 209361 RVA: 0x00CCD0C6 File Offset: 0x00CCB2C6
		protected virtual void OnNotifyFindResult(FindNavigationResult result)
		{
		}

		// Token: 0x060331D2 RID: 209362 RVA: 0x00CCD0C8 File Offset: 0x00CCB2C8
		protected virtual bool OnIsFirstFindFromSubPanel()
		{
			return false;
		}

		// Token: 0x060331D3 RID: 209363 RVA: 0x00CCD0CB File Offset: 0x00CCB2CB
		protected virtual bool OnCanOverrideFindNavigation(ELGUINavigationDirection direction, TsUiNavigationBehaviorListener lastListener, [Nullable(2)] TsUiNavigationBehaviorListener targetListener)
		{
			return false;
		}

		// Token: 0x060331D4 RID: 209364 RVA: 0x00CCD0CE File Offset: 0x00CCB2CE
		[NullableContext(2)]
		protected virtual TsUiNavigationBehaviorListener OnHandleOverrideFindNavigation(ELGUINavigationDirection direction, [Nullable(1)] TsUiNavigationBehaviorListener lastListener, TsUiNavigationBehaviorListener targetListener)
		{
			return null;
		}

		// Token: 0x060331D5 RID: 209365 RVA: 0x00CCD0D1 File Offset: 0x00CCB2D1
		[NullableContext(2)]
		protected virtual TsUiNavigationBehaviorListener OnHandleAfterFindOpposite(ELGUINavigationDirection direction, [Nullable(1)] TsUiNavigationBehaviorListener lastListener, TsUiNavigationBehaviorListener targetListener, bool isPositive)
		{
			return targetListener;
		}

		// Token: 0x060331D6 RID: 209366 RVA: 0x00CCD0D4 File Offset: 0x00CCB2D4
		public void Clear()
		{
			this.OnClear();
			this.GroupMap.Clear();
			this.ListenerSet.Clear();
		}

		// Token: 0x060331D7 RID: 209367 RVA: 0x00CCD0F2 File Offset: 0x00CCB2F2
		public new ESpecialPanelHandleDefine GetType()
		{
			return this.Type;
		}

		// Token: 0x060331D8 RID: 209368 RVA: 0x00CCD0FA File Offset: 0x00CCB2FA
		protected virtual void OnInit()
		{
		}

		// Token: 0x060331D9 RID: 209369 RVA: 0x00CCD0FC File Offset: 0x00CCB2FC
		protected virtual void OnClear()
		{
		}

		// Token: 0x0401DB74 RID: 121716
		protected List<TsUiNavigationBehaviorListener> DefaultNavigationListener = new List<TsUiNavigationBehaviorListener>();

		// Token: 0x0401DB75 RID: 121717
		private readonly HashSet<TsUiNavigationBehaviorListener> ListenerSet = new HashSet<TsUiNavigationBehaviorListener>();

		// Token: 0x0401DB76 RID: 121718
		private Dictionary<string, NavigationGroup> GroupMap = new Dictionary<string, NavigationGroup>();

		// Token: 0x0401DB77 RID: 121719
		private readonly ESpecialPanelHandleDefine Type = ESpecialPanelHandleDefine.Default;
	}
}
